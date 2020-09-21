using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ShareProfit
{
    public class JSDocumentTable:JTable
    {

        public JSDocumentTable()
            : base(JTableNamesShareProfit.Documents)
        {
        }
        public int CourseCode;
        public string DocDate ;
        public string DocNo ;
        public int PayLoc ;
        /// <summary>
        /// مبلغ کل پرداختی سند
        /// </summary>
        public decimal DocCost;
        public string DocDesc ;
        public bool ShowDeactiveSheet;
        public int DefaultPayDate;
    }

    public enum JSDocumentEnum
    {
        Code,
        coursecode,
        docdate,
        docno,
        docdesc,
        payloc,
        doccost,
    }
}
