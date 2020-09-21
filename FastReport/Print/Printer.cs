using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Printing;
using FastReport.Preview;
using FastReport.Forms;
using FastReport.Utils;

namespace FastReport.Print
{
  internal class Printer
  {
    private Report FReport;

    public bool Print(int curPage)
    { 
      PrinterSettings printerSettings = null;
      
      if (FReport.PrintSettings.ShowDialog)
      {
        using (PrinterSetupForm dialog = new PrinterSetupForm())
        {
          dialog.Report = FReport;
          dialog.PrintDialog = true;
          if (dialog.ShowDialog() != DialogResult.OK)
            return false;
          printerSettings = dialog.PrinterSettings;  
        }
      }
      
      using (PrintDocument doc = new PrintDocument())
      {
        if (printerSettings != null)
          doc.PrinterSettings = printerSettings;
        
        PrintControllerBase controller = null;
        switch (FReport.PrintSettings.PrintMode)
        {
          case PrintMode.Default:
            controller = new DefaultPrintController(FReport, doc, curPage);
            break;

          case PrintMode.Split:
            controller = new SplitPrintController(FReport, doc, curPage);
            break;

          case PrintMode.Scale:
            controller = new ScalePrintController(FReport, doc, curPage);
            break;
        }

        doc.PrintController = new StandardPrintController();
        doc.PrintPage += new PrintPageEventHandler(controller.PrintPage);
        doc.QueryPageSettings += new QueryPageSettingsEventHandler(controller.QueryPageSettings);
        Duplex duplex = FReport.PrintSettings.Duplex;
        if (duplex != Duplex.Default)
          doc.PrinterSettings.Duplex = duplex;
        
        try
        {
          Config.ReportSettings.OnStartProgress(FReport);
          doc.Print();
        }
        finally
        {
          Config.ReportSettings.OnFinishProgress(FReport);
        }
        return true;
      }
    }

    public Printer(Report report) 
    {
      FReport = report;
    }
  }
}