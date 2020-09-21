using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JDocumentsGetDetailReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            GetReport(Code);
            //GetReportTotal(Code);
        }

        public void GetReport(int DocumnetCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("JDocumentsGetDetailReportControl");
            jGridView.ClassName = "WebBusManagement_FormsManagement_JDocumentsGetDetailReportControl_" + DocumnetCode;
            jGridView.SQL = @"select top 100 percent ade.Code,cap.Name OwnerName,ISNULL(fcc.Value,0) TafsiliCode,ab.BUSNumber,ab.LastLineNumber,ad.Description,ade.CardCount,ade.Amount * 10 as Price from AUTDocumentDetail ade
                                left join clsAllPerson cap on ade.OwnerPCode = cap.Code
                                left join AUTBus ab on ab.Code = ade.BusCode 
                                left join AutDocument ad on ad.Code = ade.DocumentCode
                                left join (select * from finComparativeCode where ClassName = 'ClassLibrary.Person.AllPerson') fcc on fcc.ObjectCode = cap.Code
                                where ade.DocumentCode=" + DocumnetCode.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDocumentsGetDetailReportControl";
            jGridView.PageOrderByField = "OwnerName";
            jGridView.Buttons = "excel";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("CardCount", 0);
            jGridView.SumFields.Add("Price", 0);
            jGridView.Bind();

        }

        //        public void GetReportTotal(int DocumnetCode)
        //        {
        //           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("JDocumentsGetDetailReportControlTotal");
        //            jGridView.SQL = @"select top 100 percent max(ade.Code)Code,ade.DocumentCode,sum(ade.CardCount)CardCount,sum(ade.Amount) * 10 as Amount from AUTDocumentDetail ade
        //                                 where ade.DocumentCode=" + DocumnetCode.ToString()
        //                                 + @" Group By ade.DocumentCode";
        //            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
        //            jGridView.PageSize = 50;
        //            jGridView.HiddenColumns = "Code";
        //            jGridView.Title = "JDocumentsGetDetailReportControlTotal";
        //            jGridView.Buttons = "excel";
        //            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportTotal).GridView = jGridView;
        //            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportTotal).LoadGrid(true);
        //        }
    }
}