using System;
using System.Collections.Generic;
using System.Text;
using FastReport.Data;

namespace FastReport.Engine
{
  public partial class ReportEngine
  {
    private void InitGroupHeaders(GroupHeaderBand header)
    {
      GroupHeaderBand h = header;
      while (h != null)
      {
        h.RowNo = 0;
        h = h.NestedGroup;
      }
      ShowGroupHeaders(header);
    }

    private void ShowGroupHeaders(GroupHeaderBand header)
    {
      while (header != null)
      {
        header.RowNo++;
        header.AbsRowNo++;
        ShowGroupHeader(header);
        header.ResetGroupValue();
        header = header.NestedGroup;
      }
    }

    private void ShowGroupFooters(GroupHeaderBand header, bool needEndKeep, bool keepLastRowWithSummary)
    {
      // rollback to previous data row to print the header condition in the footer.
      DataBand dataBand = header.GroupDataBand;
      DataSourceBase dataSource = dataBand.DataSource;
      dataSource.Prior();

      // show groupfooters in the reverse order!
      List<GroupHeaderBand> headers = new List<GroupHeaderBand>();
      while (header != null)
      {
        headers.Insert(0, header);
        header = header.NestedGroup;
      }
      
      bool footerShown = false;
      foreach (GroupHeaderBand band in headers)
      {
        footerShown = ShowGroupFooter(band, needEndKeep, keepLastRowWithSummary);
      }

      // restore current row
      if (footerShown)
        dataSource.Next();
    }

    private void CheckGroupValues(GroupHeaderBand header)
    {
      while (header != null)
      {
        if (header.GroupValueChanged())
        {
          // if value is changed, show all related footers, then headers.
          ShowGroupFooters(header, true, false);
          ShowGroupHeaders(header);
          break;
        }
        header = header.NestedGroup;
      }
    }

    private bool GroupValuesChanged(GroupHeaderBand header)
    {
      while (header != null)
      {
        if (header.GroupValueChanged())
          return true;
        header = header.NestedGroup;
      }
      return false;
    }

    private void ShowGroupHeader(GroupHeaderBand header)
    {
      if (header.ResetPageNumber && header.AbsRowNo > 1)
        ResetLogicalPageNumber();
      if (header.KeepTogether)
        StartKeep(header);
      if (header.KeepWithData)
        StartKeep(header.GroupDataBand);
      
      ShowBand(header);
      if (header.RepeatOnEveryPage)
        AddReprint(header);
      
      GroupFooterBand footer = header.GroupFooter;
      if (footer != null)
      {
        if (footer.RepeatOnEveryPage)
          AddReprint(footer);
      }
    }

    private bool ShowGroupFooter(GroupHeaderBand header, bool needEndKeep, bool keepLastRowWithSummary)
    {
      bool showFooter = true;
      GroupFooterBand footer = header.GroupFooter;
      if (footer != null && footer.RepeatOnEveryPage && keepLastRowWithSummary)
      {
        // see the ShowDataFooter method for explanation what's going on here
        ReportSummaryBand summaryBand = (header.Page as ReportPage).ReportSummary;
        if (summaryBand.Height > FreeSpace)
          showFooter = false;
      }

      if (showFooter)
      {
        RemoveReprint(footer);

        if (footer != null && footer.RepeatOnEveryPage && footer.KeepWithData)
        {
          // In case everything fits on the page, keep is not needed.
          // Finish it to print correct totals in the footer. 
          if (footer.Height < FreeSpace)
            EndKeep();
        }  
        
        ShowBand(footer);
        RemoveReprint(header);
      }
      
      OutlineUp(header);
      if (header.KeepTogether)
        EndKeep();
      if (needEndKeep && footer != null && footer.KeepWithData)
        EndKeep();
        
      return showFooter;  
    }

    private int GetNumberOfDataRows(GroupHeaderBand header)
    {
      int result = 0;
      DataSourceBase dataSource = header.DataSource;
      int startRow = dataSource.CurrentRowNo;

      while (dataSource.HasMoreRows)
      {
        if (GroupValuesChanged(header))
          break;
        dataSource.Next();
        result++;
      }

      dataSource.CurrentRowNo = startRow;
      return result;
    }
    
    private void RunGroup(GroupHeaderBand groupBand)
    {
      DataBand dataBand = groupBand.GroupDataBand;
      if (dataBand == null)
        return;

      // determine whether is necessary to keep first/last data rows with group header/footer
      bool keepFirstRow = false;
      bool keepLastRow = false;
      GroupHeaderBand header = groupBand;
      while (header != null)
      {
        if (header.KeepWithData)
          keepFirstRow = true;
        if (header.GroupFooter != null && header.GroupFooter.KeepWithData)
          keepLastRow = true;
        header = header.NestedGroup;
      }
      
      ReportPage page = groupBand.Page as ReportPage;
      bool needKeepSummary = dataBand.KeepSummary && page.ReportSummary != null && page.ReportSummary.KeepWithData;

      DataSourceBase dataSource = groupBand.DataSource;
      if (dataSource != null)
      {
        groupBand.InitDataSource();
        bool isFirstRow = true;
        bool rowsPrinted = false;

        // cycle through records
        dataSource.First();
        while (dataSource.HasMoreRows)
        {
          // show all group headers at first start; in other case, check if group's values are changed.
          if (isFirstRow)
          {
            ShowDataHeader(groupBand);
            InitGroupHeaders(groupBand);
          }  
          else
            CheckGroupValues(groupBand);

          // show data
          int dataRowsCount = GetNumberOfDataRows(groupBand);
          bool isLastGroup = dataSource.CurrentRowNo + dataRowsCount >= dataSource.RowCount;
          RunDataBand(dataBand, dataRowsCount, keepFirstRow, keepLastRow,
            isLastGroup ? needKeepSummary : false);

          isFirstRow = false;
          rowsPrinted = true;
          if (Report.Aborted)
            break;
        }

        // show all group footers after the last row
        if (rowsPrinted)
        {
          ShowGroupFooters(groupBand, !needKeepSummary, needKeepSummary);
          ShowDataFooter(groupBand);
        }
          
        // finalize the datasource, remove the group condition 
        // from the databand sort
        groupBand.FinalizeDataSource();
      }
    }

    private void ShowDataHeader(GroupHeaderBand groupBand)
    {
      DataHeaderBand header = groupBand.Header;
      if (header != null)
      {
        ShowBand(header);
        if (header.RepeatOnEveryPage)
          AddReprint(header);
      }

      DataFooterBand footer = groupBand.Footer;
      if (footer != null)
      {
        if (footer.RepeatOnEveryPage)
          AddReprint(footer);
      }
    }

    private void ShowDataFooter(GroupHeaderBand groupBand)
    {
      DataFooterBand footer = groupBand.Footer;
      RemoveReprint(footer);
      ShowBand(footer);
      RemoveReprint(groupBand.Header);
    }
  }
}
