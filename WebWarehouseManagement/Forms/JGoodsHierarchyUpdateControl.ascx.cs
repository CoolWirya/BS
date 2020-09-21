using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JGoodsHierarchyUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int ParentCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["ParentCode"], out ParentCode);

            _SetForm();
        }

        private void _SetForm()
        {
            if (Code > 0)
            {
                WarehouseManagement.Goods.JGoodsHierarchy jgoodsHierarchy = new WarehouseManagement.Goods.JGoodsHierarchy();
                jgoodsHierarchy.GetData(Code);
                txtName.Text = jgoodsHierarchy.Name;
            }
        }

        private bool Save()
        {
            if (Code > 0) // Edit Mode
            {
                WarehouseManagement.Goods.JGoodsHierarchy jgoodsHierarchy = new WarehouseManagement.Goods.JGoodsHierarchy();
                jgoodsHierarchy.GetData(Code);
                jgoodsHierarchy.Name = txtName.Text;
                if (jgoodsHierarchy.Update())
                    return true;
            }
            if (ParentCode > 0 || ParentCode == -1)
            {
                WarehouseManagement.Goods.JGoodsHierarchy jgoodsHierarchy = new WarehouseManagement.Goods.JGoodsHierarchy();
                if (ParentCode > 0)
                    jgoodsHierarchy.ParentCode = ParentCode;
                jgoodsHierarchy.Name = txtName.Text;
                if (jgoodsHierarchy.Insert() > 0)
                    return true;
            }

            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                WebClassLibrary.JWebManager.RefreshGrid();
                WebClassLibrary.JWebManager.CloseWindow();
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره سازی اطلاعات وجود ندارد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }
    }
}