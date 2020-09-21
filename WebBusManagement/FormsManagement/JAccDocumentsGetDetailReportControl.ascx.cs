using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JAccDocumentsGetDetailReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            GetReport(Code);
        }

        public void GetReport(int DocumnetCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("JDocumentsGetDetailReportControl");
            jGridView.ClassName = "WebBusManagement_FormsManagement_JAccDocumentsGetDetailReportControl_" + DocumnetCode;
            jGridView.SQL = @"SELECT TOP 100 PERCENT FDD.[Code]
                                  ,FDD.[DocCode]
                                  ,FDD.[DateSave]
                                  ,FDD.[DateModifie]
                                  ,FM.Name MoeinName
                                  ,FT.Name Tafzili1
                                  ,FT2.Name Tafzili2
                                  ,fba.AccountNo
                                  ,FDD.[BedPrice]
                                  ,FDD.[BesPrice]
                                  ,FDD.[Description]
                              FROM [dbo].[FinDocumentDetails] FDD
                              left join FinDocument FD on FD.Code = FDD.DocCode  
                              left join finMoein FM on FM.Code = FDD.MoeinCode
                              left join finTafzili FT on FT.Code = FDD.TafziliCode1
                              left join finTafzili FT2 on FT2.Code = FDD.TafziliCode2
                              left join finBankAccount fba on fba.PCode = FDD.TafziliCode1
	                            where FDD.doccode = " + DocumnetCode.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDocumentsGetDetailReportControl";
            jGridView.PageOrderByField = "Code";
            jGridView.Buttons = "excel";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("BedPrice", 0);
            jGridView.SumFields.Add("BesPrice", 0);
            jGridView.Bind();

        }
    }
}