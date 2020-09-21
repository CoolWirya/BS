using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JTypesOfGoodsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadData();
            _SetForm();
        }

        public void LoadData()
        {
            DataTable dt = new DataTable();
            dt = WarehouseManagement.Goods.JGoodsHierarchies.GetList();
            cmbGoodsHierarchies.DataSource = dt;
            cmbGoodsHierarchies.DataTextField = "Name";
            cmbGoodsHierarchies.DataValueField = "Code";
            cmbGoodsHierarchies.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                WarehouseManagement.Goods.JTypesOfGoods jTypesOfGoods = new WarehouseManagement.Goods.JTypesOfGoods();
                jTypesOfGoods.GetData(Code);
                txtName.Text = jTypesOfGoods.Name;
         //       chbHasSerial.Checked = jTypesOfGoods.HasSerial;
                cmbGoodsHierarchies.SelectedValue = jTypesOfGoods.GoodsHierarchyCode.ToString();
            }
        }

        public bool Save()
        {
            WarehouseManagement.Goods.JTypesOfGoods jTypesOfGoods = new WarehouseManagement.Goods.JTypesOfGoods();
            jTypesOfGoods.Code = Code;
            jTypesOfGoods.Name = txtName.Text;
        //    jTypesOfGoods.HasSerial = chbHasSerial.Checked;
            jTypesOfGoods.GoodsHierarchyCode = Convert.ToInt32(cmbGoodsHierarchies.SelectedValue);
            if (Code > 0)
                return jTypesOfGoods.Update();
            else
                return jTypesOfGoods.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                WebClassLibrary.JWebManager.RefreshGrid();
                WebClassLibrary.JWebManager.CloseWindow();
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید.");
        }

    }
}