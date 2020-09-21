using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace FastReport.Utils
{
  internal static class PrinterUtils
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    private static extern IntPtr GlobalLock(IntPtr mem);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    private static extern uint GlobalUnlock(IntPtr mem);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    private static extern uint GlobalFree(IntPtr mem);

    [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern uint OpenPrinter(string name, ref uint handle, uint defaults);

    [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int DocumentProperties(uint hwnd, uint printer,
      string devicename, IntPtr devModeOut, IntPtr devModeInput, uint mode);

    [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern uint ClosePrinter(uint handle);

    public static void ShowPropertiesDialog(PrinterSettings settings)
    {
      string name = settings.PrinterName;
      IntPtr hDevMode = settings.GetHdevmode();
      try
      {
        uint handle = 0;
        if (OpenPrinter(name, ref handle, 0) != 0)
        {
          IntPtr pDevMode = GlobalLock(hDevMode);
          uint result = (uint)DocumentProperties(0, handle, name, pDevMode, pDevMode, 14);
          ClosePrinter(handle);
          GlobalUnlock(hDevMode);
          if (result == 1)
            settings.SetHdevmode(hDevMode);
        }
      }
      finally
      {
        GlobalFree(hDevMode);
      }
    }
  }  
}
