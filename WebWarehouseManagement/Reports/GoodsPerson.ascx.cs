using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WarehouseManagement.Warehouse;

namespace WebWarehouseManagement
{
    public partial class GoodsPerson : System.Web.UI.UserControl
    {
        #region Declaration
        //int Code;
        //int WhCode;

        //public int WarehouseCode;
        //public int PersonCode;
        //public int TypeOfGoodsCode;
        //public int GoodsCode;

        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlWarGoods;
        protected global::WebControllers.MainControls.Grid.JGridViewControl JGridViewControl1;
        #endregion Declaration

        #region Initilization
        //________________________________________________________________________________________________________________
        protected void Page_Load(object sender, EventArgs e)
        {
            //int.TryParse(Request["Code"], out Code);
            //int.TryParse(Request["WhCode"], out WhCode);
            if (!IsPostBack)
                LoadData();
            // _SetForm();
        }
        //________________________________________________________________________________________________________________
        public void LoadData()
        {

            //TypesOfGoodSes
            int selected = 0;
            DataTable dtGoods = new DataTable();
            dtGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetTypeOfGoodsInStock();
            CmbWarTypesOfGoods.DataSource = dtGoods;
            CmbWarTypesOfGoods.DataTextField = "NAME";
            CmbWarTypesOfGoods.DataValueField = "Code";
            CmbWarTypesOfGoods.DataBind();

            Telerik.Web.UI.RadComboBoxItem cmbItem2 = new Telerik.Web.UI.RadComboBoxItem();
            cmbItem2.Text = "__ انتخاب کنید __";
            cmbItem2.Value = "0";
            cmbItem2.Selected = true;
            CmbWarTypesOfGoods.Items.Add(cmbItem2);

            //WarGoods
            JCustomListSelectorControlWarGoods.Code = 0;
            JCustomListSelectorControlWarGoods.SQL =
            @"SELECT
                    M1.Code AS Code,WTOG.Name AS Title
			    FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)    Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue;

        }
        //________________________________________________________________________________________________________________
        #endregion Initilization


        protected void btnSave_Click(object sender, EventArgs e)
        {

            int WarGoods = JCustomListSelectorControlWarGoods.Code;
            int PersonCode = ((WebControllers.MainControls.JSearchPersonControl)personCode).PersonCode;
            int TypesOfGoodsCode = int.Parse(CmbWarTypesOfGoods.SelectedValue);


            string Query;

            if (RbReportKind.SelectedValue == "1")
                Query = JWarehousees.GetGoodsWithPerson(WarGoods, TypesOfGoodsCode);
            else
                Query = JWarehousees.GetPersonWithGoods(PersonCode);

            //JGridViewControl1.
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("GoodsPerson");
            jGridView.SQL = Query;
            jGridView.Title = "GoodsPerson";
            jGridView.PageOrderByField = "Code";
            jGridView.Buttons = "";
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("CountOfGoods", 1);
            JGridViewControl1.GridView = jGridView;
            JGridViewControl1.LoadGrid(true);
            // JGridViewControl1.d
            //  return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);


        }

        protected void cmbTypesOfGoods_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            JCustomListSelectorControlWarGoods.Code = 0;
            JCustomListSelectorControlWarGoods.SQL = @"SELECT
                    M1.Code AS Code,WTOG.Name + '_' + M1.[Description] AS Title
			    FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)    Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue;

        }


        protected void RbReportKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RbSelected = RbReportKind.SelectedValue;
            if (RbSelected == "1")
            {
                TD_Goods.Visible = true;
                TD_Type.Visible = true;
                TD_Person.Visible = false;

                
            }
            else
            {
                TD_Goods.Visible = false;
                TD_Person.Visible = true;
                TD_Type.Visible = false;
            }

            CmbWarTypesOfGoods.SelectedIndex = -1;
            JCustomListSelectorControlWarGoods.Code = 0;
            ((WebControllers.MainControls.JSearchPersonControl)personCode).PersonCode = 0;
        }
    }
}