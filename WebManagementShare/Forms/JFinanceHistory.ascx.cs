using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JFinanceHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GatData();
        }

        private void GatData()
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusReports_JBusReports");
            jGridView.SQL =
                @"select a.Code,dbo.DateEnToFa([تاریخ]) Fdate,[مبلغ__واریز] Variz,[مبلغ__برداشت] Bardasht,a.توضیحات as description from [Propperty_ClassName_ClassLibrary.FormManagers_6] a
                inner join FormObjects FO on a.ObjectCode=FO.Code
                where FO.ObjectCode=" + person.Code;

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "Asset";
            jGridView.Buttons = "excel";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("Variz", 0);
            jGridView.SumFields.Add("Bardasht", 0);

            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridAsset).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridAsset).LoadGrid(true);

        }
    
    }
}