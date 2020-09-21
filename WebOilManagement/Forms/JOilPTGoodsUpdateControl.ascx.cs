using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JOilPTGoodsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            cmbGoods.DataSource = WarehouseManagement.Goods.JGoodSes.GetDataTable();
            cmbGoods.DataTextField = "GoodName";
            cmbGoods.DataValueField = "Code";
            cmbGoods.DataBind();

            if (Code > 0)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            grdGoods.DataSource = OilProductsDistributionCompany.PT.JPTGoodss.GetPTsGoods(Code);
            grdGoods.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.PT.JPTGoods jPTGoods = new OilProductsDistributionCompany.PT.JPTGoods();
            jPTGoods.GoodCode = Convert.ToInt32(cmbGoods.SelectedValue);
            jPTGoods.PTCode = Code;
            jPTGoods.Status = 0; // Default Status
            jPTGoods.Insert();
            LoadGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.PT.JPTGoods jPTGoods = new OilProductsDistributionCompany.PT.JPTGoods();
            var index = Request["radGridClickedRowIndex"];
            if (index != null)
            {
                jPTGoods.GetData(Convert.ToInt32(grdGoods.MasterTableView.Items[Convert.ToInt32(index)]["Code"].Text));
                jPTGoods.Delete();
                LoadGrid();
            }
        }

    }
}