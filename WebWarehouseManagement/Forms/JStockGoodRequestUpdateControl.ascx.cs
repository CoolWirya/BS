using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebWarehouseManagement.Forms
{
    public partial class JStockGoodRequestUpdateControl : System.Web.UI.UserControl
    {

        int Code = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32.TryParse(Request["Code"], out this.Code);
            if (!this.IsPostBack) FillFormControls(this.Code);
        }

        private void FillFormControls(int code)
        {
            if (code == 0) return;

            DataTable dt = new DataTable();

            WarehouseManagement.Goods.JWarGoodRequest WGR = new WarehouseManagement.Goods.JWarGoodRequest();
            WarehouseManagement.Goods.JWarGoodRequestDetails WGRD = new WarehouseManagement.Goods.JWarGoodRequestDetails();
            WarehouseManagement.Goods.JGoods G = new WarehouseManagement.Goods.JGoods();
            WarehouseManagement.Warehouse.JWarehouse WH = new WarehouseManagement.Warehouse.JWarehouse();
            
            WGR.GetData(code);
            WH.GetData(WGR.WarCode);

            dt = WebClassLibrary.JWebDataBase.GetDataTable(" select username from users where code= " + WGR.UserCode);

            //this.lblRequestdate.Text = ClassLibrary.JDateTime.FarsiDate(WGR.RequestDate);
           ((WebControllers.MainControls.Date.JDateControl)this.dteRegisterDate).SetDate(WGR.RequestDate);

            this.lblWarName.Text = WH.Name;
            this.lblGoodRequestUser.Text =dt.Rows[0]["username"].ToString();
            
            //لیست کالاهای درخواستی از یک انبار خاص
            dt= WebClassLibrary.JWebDataBase.GetDataTable(" select wg.Description, wgrd.Count from WarGoodRequestDetails as wgrd inner join WarGoods as wg "
                                                        + " on wgrd.GoodCode = wg.Code where wgrd.GRCode= " + WH.Code);
            
            this.ddlGoods.DataSource = dt;
            this.ddlGoods.DataTextField = "Description";
            this.ddlGoods.DataValueField = "Count";
            this.ddlGoods.DataBind();

            if (ddlGoods.Items.Count >0)
                txtGoodCount.Text = ddlGoods.Items[0].Value;

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }

        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGoodCount.Text = ddlGoods.SelectedValue;
        }

    }
}