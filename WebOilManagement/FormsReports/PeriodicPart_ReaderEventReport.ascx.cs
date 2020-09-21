using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebOilManagement.FormsReports
{
    public partial class PeriodicPart_ReaderEventReport : System.Web.UI.UserControl
    {
        
        protected global::WebControllers.MainControls.JCustomListSelectorControl JLstCtrGood;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
                btnGenerateReport_Click(null, null);
            else
            {
                this.LoadTypeOfGoods();
                this.LoadWarWareHouse();
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //ads
        }

        #region Method
        
        private void LoadTypeOfGoods()
        {
            JLstCtrGood.Code = 0;
            JLstCtrGood.SQL = @"SELECT Code, name as Title from WarTypesOfGoods";
        }
        private void LoadWarWareHouse()
        {
            
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT code, name from WarWarehouse");
            var p = (from v in Dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbWarHouses.DataSource = p;
            cmbWarHouses.DataTextField = "Name";
            cmbWarHouses.DataValueField = "Code";
            cmbWarHouses.DataBind();
        }
        private void GetReport(int WareHouseCode = 0, int TypeOfGoodcode = 0, DateTime? AsDate = null, DateTime? ToDate = null)
        {

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("PeriodicPart_ReaderEventReport");

            jGridView.SQL = WarehouseManagement.Warehouse.JWarehousees.PeriodicPartReaderEventReport(WareHouseCode,TypeOfGoodcode,AsDate,ToDate);

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 100;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "PeriodicPart_ReaderEventReport";
            jGridView.Buttons = "excel";

            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdManagerPortalReports).LoadGrid(true);

        }

        #endregion Method

        
    }
}