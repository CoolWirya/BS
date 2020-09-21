using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JGoodsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int WhCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["WhCode"], out WhCode);
            LoadData();
            _SetForm();
        }

        public void LoadData()
        {
            int selected = cmbTypesOfGoods.SelectedIndex;
            // Types of Goods
            DataTable dtTypesOfGoods = new DataTable();
            dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable();
            cmbTypesOfGoods.DataSource = dtTypesOfGoods;
            cmbTypesOfGoods.DataTextField = "Name";
            cmbTypesOfGoods.DataValueField = "Code";
            cmbTypesOfGoods.DataBind();
            cmbTypesOfGoods.SelectedIndex = selected;

            // Warehouses
            //DataTable dtWarehouses = new DataTable();
            //dtWarehouses = WarehouseManagement.Warehouse.JWarehousees.GetDataTable();
            //cmbWarehouse.DataSource = dtWarehouses;
            //cmbWarehouse.DataTextField = "Name";
            //cmbWarehouse.DataValueField = "Code";
            //cmbWarehouse.DataBind();

            // Manufacturers
            //DataTable dtManufacturer = new DataTable();
            //dtManufacturer = WarehouseManagement.JManufacturers.GetDataTable(WarehouseManagement.Define.JDefine.Manufacturers);
            //cmbManufacturers.DataSource = dtManufacturer;
            //cmbManufacturers.DataTextField = "Name";
            //cmbManufacturers.DataValueField = "Code";
            //cmbManufacturers.DataBind();

            ///حذف شد 1394/02/16
            // StatusOfGoods
            //DataTable dtStatusOfGoods = new DataTable();
            //dtStatusOfGoods = WebClassLibrary.JDataManager.EnumToDataTable(typeof(WarehouseManagement.Goods.JStatusOfGoods));
            //cmbStatusOfGoods.DataSource = dtStatusOfGoods;
            //cmbStatusOfGoods.DataTextField = "Key";
            //cmbStatusOfGoods.DataValueField = "Value";
            //cmbStatusOfGoods.DataBind();
        }

        public void _SetForm()
        {

            if (Code > 0)
            {
                WarehouseManagement.Goods.JGoods jGoods = new WarehouseManagement.Goods.JGoods();
                jGoods.GetData(Code);


                cmbTypesOfGoods.SelectedValue = jGoods.TypeOfGoodsCode.ToString();
                ///حذف شد 1394/02/16
                //txtSerial.Text = jGoods.Serial;
                txtModel.Text = jGoods.Model;
                ((WebControllers.MainControls.JSearchPersonControl)personCode).PersonCode = jGoods.PersonCode;
                txtBuildYear.Text = jGoods.YearBuilt.ToString();
                txtName.Text = jGoods.Description;

                ///  cmbWarehouse.SelectedValue = jGoods.WarehouseCode.ToString();
                //cmbStatusOfGoods.SelectedValue = jGoods.StatusOfGoods.GetHashCode().ToString();

                DataTable dtTypesOfGoods = new DataTable();
                dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(cmbTypesOfGoods.SelectedValue));
                ///حذف شد 1394/02/16
                //if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
                //{
                //    txtSerial.Enabled = true;
                //    rfvSerial.Enabled = true;
                //}
                //else
                //{
                //    txtSerial.Enabled = false;
                //    rfvSerial.Enabled = false;
                //}
            }
        }

        public bool Save()
        {
            WarehouseManagement.Goods.JGoods jGoods = new WarehouseManagement.Goods.JGoods();
            jGoods.GetData(Code);

            jGoods.PersonCode = ((WebControllers.MainControls.JSearchPersonControl)personCode).PersonCode;
            jGoods.Model = txtModel.Text;
            ///حذف شد 1394/02/16
            //jGoods.Serial = txtSerial.Text;
            //jGoods.StatusOfGoods = (WarehouseManagement.Goods.JStatusOfGoods)Convert.ToInt32(cmbStatusOfGoods.SelectedValue);
            jGoods.TypeOfGoodsCode = Convert.ToInt32(cmbTypesOfGoods.SelectedValue);
            if (txtBuildYear.Text != string.Empty)
                jGoods.YearBuilt = Convert.ToInt32(txtBuildYear.Text);
            else
                jGoods.YearBuilt = 0;
            if (txtName.Text != string.Empty)
                jGoods.Description = txtName.Text;
            else
                jGoods.Description = cmbTypesOfGoods.SelectedItem.Text;
            ///حذف شد 1394/02/16
            //txtSerial.Text = string.Empty;
            if (WhCode == 0)
            {
                if (Code > 0)
                {
                    if (jGoods.Update())
                    {
                        WebClassLibrary.JWebManager.RefreshGrid();
                        WebClassLibrary.JWebManager.CloseWindow();
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    Code = jGoods.Insert();
                    if (Code > 0) { WebClassLibrary.JWebManager.RefreshGrid(); return true; } else return false;
                }
            }
            else
            {

                Code = jGoods.Insert(WhCode);
                WebClassLibrary.JWebManager.ShowMessage(" کالا " + jGoods.GoodName + " با سریال  " + jGoods.Serial + "با موفقیت ثبت گردید . ");
                WebClassLibrary.JWebManager.CloseWindow();
                if (Code > 0) { WebClassLibrary.JWebManager.RefreshGrid(); return true; } else return false;


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {

                _SetForm();
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید.");
        }

        protected void cmbTypesOfGoods_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataTable dtTypesOfGoods = new DataTable();
            dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(e.Value));
            ///حذف شد 1394/02/16
            //if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
            //{
            //    txtSerial.Enabled = true;
            //    rfvSerial.Enabled = true;
            //}
            //else
            //{
            //    txtSerial.Enabled = false;
            //    rfvSerial.Enabled = false;
            //}

        }
    }
}