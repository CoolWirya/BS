using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JWarehouseUpdateControl : System.Web.UI.UserControl
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
            cmbUsers.DataSource = (new Globals.JUsers()).GetUserList();
            cmbUsers.DataTextField = "fullname";
            cmbUsers.DataValueField = "code";
            cmbUsers.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                WarehouseManagement.Warehouse.JWarehouse jWarehouse = new WarehouseManagement.Warehouse.JWarehouse();
                jWarehouse.GetData(Code);
                txtName.Text = jWarehouse.Name;
                if ( jWarehouse.StockClerk != 0 && cmbUsers.FindItemByValue(jWarehouse.StockClerk.ToString()) !=null )
                    cmbUsers.FindItemByValue(jWarehouse.StockClerk.ToString()).Selected = true;
                ((WebControllers.MainControls.JSearchPersonControl)personOwner).PersonCode = jWarehouse.OwnerCode;
            }
        }

        public bool Save()
        {
            WarehouseManagement.Warehouse.JWarehouse jWarehouse = new WarehouseManagement.Warehouse.JWarehouse();
            jWarehouse.Code = Code;
            jWarehouse.Name = txtName.Text;
            jWarehouse.OwnerCode = ((WebControllers.MainControls.JSearchPersonControl)personOwner).PersonCode;
            jWarehouse.StockClerk = int.Parse(cmbUsers.SelectedValue);
            if (Code > 0)
                return jWarehouse.Update();
            else
                return jWarehouse.Insert() > 0 ? true : false;
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