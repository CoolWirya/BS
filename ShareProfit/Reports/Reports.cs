using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ShareProfit
{
    public class JReports:JSystem
    {
        public void ListView()
        {
            //Nodes.Insert(JSPStaticNode._ShareProfitReport());
            Nodes.Insert(JSPStaticNode._PrintForm());
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[2];
            //N[0] = JSPStaticNode._ShareProfitReport();
            N[1] = JSPStaticNode._PrintForm();
            return N;
        }
        /// <summary>
        /// نمایش فرم گزارش سود سهام
        /// </summary>
        //public void ShowReportPerson()
        //{
        //    JSPersonReportForm reportform = new JSPersonReportForm();
        //    reportform.ShowDialog();
        //}
        /// <summary>
        /// نمایش فرم مربوط به چاپ فرم
        /// </summary>
        public void ShowPrintForm()
        {
            JReportForm reportForm = new JReportForm();
            reportForm.ShowDialog();
            //JPaymentFormReport reportform = new JPaymentFormReport();
            //reportform.ShowDialog();
        }
    }
}
