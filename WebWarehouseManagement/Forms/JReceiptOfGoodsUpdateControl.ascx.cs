using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JReceiptOfGoodsUpdateControl : System.Web.UI.UserControl
    {
        #region Initilization
        /// ----------------------------------------------------------------------------------------------------------------------
        int Code;
        /// ----------------------------------------------------------------------------------------------------------------------
        int goodCode = 0;
        /// ----------------------------------------------------------------------------------------------------------------------
        int WarehouseCode = 0;
        /// ----------------------------------------------------------------------------------------------------------------------
        protected global::WebControllers.MainControls.JCustomListSelectorControl JCustomListSelectorControlWarGoods;
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Initilization

        #region Public
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["Code"] == null)
            {
                int.TryParse(Request["Code"], out Code);
                ViewState["Code"] = Code;
            }
            if (ViewState["ClassName"] == null)
            {
                int.TryParse(Request["ClassName"], out Code);
                ViewState["ClassName"] = Code;
            }
            if (ViewState["ObjectCode"] == null)
            {
                int.TryParse(Request["ObjectCode"], out Code);
                ViewState["ObjectCode"] = Code;
            }
            if (!IsPostBack)
            {
                LoadData();
                _SetForm();
            }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Public

        #region Methods
        /// ----------------------------------------------------------------------------------------------------------------------
        public void LoadData()
        {
            //if ((int)ViewState["Code"] == 0) rpvGoodsOfReceipt.Visible = false;
            //else
            //    rpvGoodsOfReceipt.Visible = true;
            //else
            //    if (IsPostBack == false)
            //        Page.PreRender += (sender, args) => { RadMultiPage1.SelectedIndex = 1; };

            // Warehouses
            DataTable dtWarehouses = new DataTable();
            dtWarehouses = WarehouseManagement.Warehouse.JWarehousees.GetDataTableVsPermision();
            cmbWarehouse.DataSource = dtWarehouses;
            cmbWarehouse.DataTextField = "Name";
            cmbWarehouse.DataValueField = "Code";
            cmbWarehouse.DataBind();

            //// Goods
            //DataTable dtGoods = new DataTable();
            //dtGoods = WarehouseManagement.Goods.JGoodSes.GetDataTable();
            //cmbGoods.DataSource = dtGoods;
            //cmbGoods.DataTextField = "GoodName";
            //cmbGoods.DataValueField = "Code";
            //cmbGoods.DataBind();
            JCustomListSelectorControlWarGoods.ValidationGroup = "Goods";
            JCustomListSelectorControlWarGoods.IsRequired = true;
            JCustomListSelectorControlWarGoods.Code = 0;
            JCustomListSelectorControlWarGoods.SQL = @" SELECT
            		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
            			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
            			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
            		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
            				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                        LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
            			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
            		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @" ) As Count 
                                                                       ,M1.Code AS Code,WTOG.Name AS Title
            			                                            FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)   Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
                                                        @" AND 
            		                                                ((M1.Serial is not null AND 
            		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
            			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
            			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
            		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
            				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                        LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
            			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
            		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @")  = 0)
                                                                    OR M1.Serial = '0' OR M1.Serial IS NULL )";
            //            JCustomListSelectorControlWarGoods.SQL = @" SELECT
            //		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
            //			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
            //			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
            //		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
            //				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
            //                                                            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
            //			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
            //		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @" ) As Count 
            //                                                           ,M1.Serial AS Code,M1.Name AS Title
            //			                                            FROM WarGoods M1 Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
            //                                                        @" AND 
            //		                                                ((M1.Serial is not null AND 
            //		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
            //			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
            //			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
            //		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
            //				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
            //                                                            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
            //			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
            //		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @")  = 0)
            //                                                        OR M1.Serial = '0' OR M1.Serial IS NULL )";

            JCustomListSelectorControlWarGoods.ControlToSet = lblTotal.ClientID;
            JCustomListSelectorControlWarGoods.PropertyToSet = "innerHTML";
            JCustomListSelectorControlWarGoods.ExtraField = "Count";




            if (ViewState["Code"] != null && (int)ViewState["Code"] > 0) LoadDetails();


        }
        /// ----------------------------------------------------------------------------------------------------------------------
        private void LoadDetails()
        {
            // Grid GoodsOfReceipt
            DataTable dtGoodsOfReceipt = new DataTable();
            dtGoodsOfReceipt = WarehouseManagement.Goods.JReceiptOfGoodsDetailSes.GetDataTableByReceiptOfGoodsCode((int)ViewState["Code"]);
            grdGoodsOfRec.DataSource = dtGoodsOfReceipt;
            grdGoodsOfRec.DataBind();
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        public void _SetForm()
        {
            if (ViewState["Code"] != null && (int)ViewState["Code"] > 0)
            {
                WarehouseManagement.Goods.JReceiptOfGoods jReceiptOfGoods = new WarehouseManagement.Goods.JReceiptOfGoods();
                jReceiptOfGoods.GetData((int)ViewState["Code"]);
                ((WebControllers.MainControls.JSearchPersonControl)personDeliver).PersonCode = jReceiptOfGoods.DeliveryPersonCode;
                ((WebControllers.MainControls.JSearchPersonControl)personTransferee).PersonCode = jReceiptOfGoods.TransfereePersonCode;
                ((WebControllers.MainControls.Date.JDateControl)dteReceiptDate).SetDate(jReceiptOfGoods.ReceiptDate);
                ((WebControllers.MainControls.Date.JDateControl)dteRegisterDate).SetDate(jReceiptOfGoods.RegisterDate);

                if (jReceiptOfGoods.WarehouseCode > 0)
                {
                    int selected = CmbWarTypesOfGoods.SelectedIndex;
                    cmbWarehouse.SelectedValue = jReceiptOfGoods.WarehouseCode.ToString();
                    DataTable dtGoods = new DataTable();
                    dtGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetTypeOfGoodsInStock(int.Parse(cmbWarehouse.SelectedValue));
                    CmbWarTypesOfGoods.DataSource = dtGoods;
                    CmbWarTypesOfGoods.DataTextField = "NAME";
                    CmbWarTypesOfGoods.DataValueField = "Code";
                    CmbWarTypesOfGoods.DataBind();
                    CmbWarTypesOfGoods.SelectedIndex = selected;
                }
                WarehouseCode = jReceiptOfGoods.WarehouseCode;
                goodCode = JCustomListSelectorControlWarGoods.Code;
            }

            //
            JCustomListSelectorControlWarGoods.Code = 0;
            // JCustomListSelectorControlWarGoods.Controls.Add(
            //JCustomListSelectorControlWarGoods.
            JCustomListSelectorControlWarGoods.OnSelectedCodeChanged += CustomListSelectorSelectedCodeChanged();
            JCustomListSelectorControlWarGoods.ValidationGroup = "Goods";
            JCustomListSelectorControlWarGoods.IsRequired = true;
            JCustomListSelectorControlWarGoods.SQL = @" SELECT
		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @" ) As Count 
                                                           ,M1.Code AS Code,WTOG.Name AS Title
			                                            FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)   Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
                                                        @" AND 
		                                                ((M1.Serial is not null AND 
		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @")  = 0)
                                                        OR M1.Serial = '0' OR M1.Serial IS NULL )";

            JCustomListSelectorControlWarGoods.ControlToSet = lblTotal.ClientID;
            JCustomListSelectorControlWarGoods.PropertyToSet = "innerHTML";
            JCustomListSelectorControlWarGoods.ExtraField = "Count";
            DataTable dtTypesOfGoods = new DataTable();
            if (CmbWarTypesOfGoods.SelectedValue != null && CmbWarTypesOfGoods.SelectedValue != string.Empty)
                dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(CmbWarTypesOfGoods.SelectedValue));
            if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
            {
                txtGoodsCount.Enabled = false;
                txtGoodsCount.Text = "1";

            }
            else
            {
                txtGoodsCount.Enabled = true;
                txtGoodsCount.Text = string.Empty;
            }


            JCustomListSelectorControlWarGoods.Clear();
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        public bool Save()
        {
            WarehouseManagement.Goods.JReceiptOfGoods jReceiptOfGoods = new WarehouseManagement.Goods.JReceiptOfGoods();
            jReceiptOfGoods.GetData((int)ViewState["Code"]);
            jReceiptOfGoods.DeliveryPersonCode = ((WebControllers.MainControls.JSearchPersonControl)personDeliver).PersonCode;
            jReceiptOfGoods.ReceiptDate = ((WebControllers.MainControls.Date.JDateControl)dteReceiptDate).GetDate();
            jReceiptOfGoods.RegisterDate = ((WebControllers.MainControls.Date.JDateControl)dteRegisterDate).GetDate();//.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
            jReceiptOfGoods.TransfereePersonCode = ((WebControllers.MainControls.JSearchPersonControl)personTransferee).PersonCode;
            jReceiptOfGoods.WarehouseCode = Convert.ToInt32(cmbWarehouse.SelectedValue);
            jReceiptOfGoods.class_Name = JWebWarehouseManagement._ConstClassName;
            if (ViewState["ClassName"] != null && !string.IsNullOrEmpty(ViewState["ClassName"].ToString()))
            {
                jReceiptOfGoods.class_Name = ViewState["ClassName"].ToString();
            }
            if (ViewState["ObjectCode"] != null && (int)ViewState["ObjectCode"] > 0)
            {
                jReceiptOfGoods.object_code = (int)ViewState["ObjectCode"];
            }
            if (ViewState["Code"] != null && (int)ViewState["Code"] > 0)
            {
                return jReceiptOfGoods.Update();
            }
            else
            {
                ViewState["Code"] = jReceiptOfGoods.Insert();
                return ViewState["Code"] != null && (int)ViewState["Code"] > 0 ? true : false;
            }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void TotalRemainStock()
        {
            //if (CmbWarTypesOfGoods.SelectedValue != string.Empty && int.Parse(CmbWarTypesOfGoods.SelectedValue) > 0)
            //{
            //    int.TryParse(CmbWarTypesOfGoods.SelectedValue, out goodCode);

            lblTotal.Text = WarehouseManagement.Goods.JGoodSes.GetGoodStock(goodCode, WarehouseCode).ToString();
            // }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Methods

        #region Events

        #region Receipt
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["Code"] != null && (int)ViewState["Code"] > 0 && Save())
            {
                WebClassLibrary.JWebManager.RefreshGrid();
                WebClassLibrary.JWebManager.CloseWindow();
            }
            else if (ViewState["Code"] != null && (int)ViewState["Code"] == 0 && Save())
            {
                WebClassLibrary.JWebManager.RefreshGrid();
                _SetForm();
                LoadData();
            }
            else
                lblError.Text = "امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید.";
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            // e.Tab.SelectedTab = e.Tab;

            //ViewState["SelectedTab"] = e.Tab.PageViewID;

            RadMultiPage1.FindPageViewByID(e.Tab.PageViewID).Selected = true;
            RadTabStrip1.FindTabByValue(e.Tab.PageViewID).Selected = true;

            //if (!string.IsNullOrEmpty(cmbWarehouse.SelectedValue))
            //    switch (e.Tab.PageViewID)
            //    {
            //        case "rpvReceiptFromBills":
            //            DataTable dt = WarehouseManagement.Goods.JBillOfGoodSes.GetData("'" + JWebWarehouseManagement._ConstClassName + "'", -1);
            //            dt.DefaultView.RowFilter = " AimWearCode =" + cmbWarehouse.SelectedValue;
            //            rgBills.DataSource = dt;
            //            rgBills.DataBind();

            //            break;
            //        //case:
            //        //break;
            //        //case:
            //        //break;

            //    }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Receipt

        #region Goods
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnAddGood_Click(object sender, EventArgs e)
        {


            WarehouseManagement.Goods.JReceiptOfGoodsDetails jReceiptOfGoodsDetails = new WarehouseManagement.Goods.JReceiptOfGoodsDetails();
            jReceiptOfGoodsDetails.ReceiptOfGoodsCode = (int)ViewState["Code"];

            jReceiptOfGoodsDetails.GoodsCode = JCustomListSelectorControlWarGoods.Code;// WarehouseManagement.Goods.JGoodSes.FindBySerial();
            if (txtGoodsCount.Text != string.Empty)
                jReceiptOfGoodsDetails.Number = Convert.ToInt32(txtGoodsCount.Text);
            else
                jReceiptOfGoodsDetails.Number = 1;
            jReceiptOfGoodsDetails.RegisterDate = DateTime.Now;

            jReceiptOfGoodsDetails.Insert();
            _SetForm();
            LoadDetails();
            TotalRemainStock();
            JCustomListSelectorControlWarGoods.Clear();

        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnDeleteGood_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdGoodsOfRec.MasterTableView.Items.Count; i++)
            {
                if (((CheckBox)grdGoodsOfRec.MasterTableView.Items[i]["chbSelect"].FindControl("chbSelect")).Checked == true)
                {
                    WarehouseManagement.Goods.JReceiptOfGoodsDetails jReceiptOfGoodsDetails = new WarehouseManagement.Goods.JReceiptOfGoodsDetails();
                    jReceiptOfGoodsDetails.GetData(Convert.ToInt32(grdGoodsOfRec.MasterTableView.Items[i].KeyValues.Split(':')[1].Replace("\"", string.Empty).Replace("}", string.Empty)));
                    if (WarehouseManagement.Goods.JGoodSes.GetGoodStock(jReceiptOfGoodsDetails.GoodsCode, int.Parse(cmbWarehouse.SelectedValue)) - jReceiptOfGoodsDetails.Number >= 0)
                        jReceiptOfGoodsDetails.Delete();
                    else
                        lblError.Text = "موجودی انبار نباید منفی شود .";
                }
            }
            _SetForm();
            LoadDetails();
            TotalRemainStock();
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void cmbGoods_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            // WarehouseManagement.Goods.JTypesOfGoodSes.GetTypeOfGoodsInStock(int.Parse(cmbWarehouse.SelectedValue))
            //if ((bool)WarehouseManagement.Goods.JGoodSes.GetDataTable(int.Parse(CmbWarTypesOfGoods.SelectedValue)).Rows[0]["HasSerial"])
            goodCode = JCustomListSelectorControlWarGoods.Code;
            WarehouseCode = int.Parse(cmbWarehouse.SelectedValue);

        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void cmbGoods_Load(object sender, EventArgs e)
        {
            if (CmbWarTypesOfGoods.Items.Count <= 0) return;
            goodCode = JCustomListSelectorControlWarGoods.Code;
            WarehouseCode = int.Parse(cmbWarehouse.SelectedValue);

        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void CmbWarTypesOfGoods_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //
            JCustomListSelectorControlWarGoods.Code = 0;
            // JCustomListSelectorControlWarGoods.Controls.Add(
            //JCustomListSelectorControlWarGoods.
            JCustomListSelectorControlWarGoods.OnSelectedCodeChanged += CustomListSelectorSelectedCodeChanged();
            JCustomListSelectorControlWarGoods.ValidationGroup = "Goods";
            JCustomListSelectorControlWarGoods.IsRequired = true;
            JCustomListSelectorControlWarGoods.SQL = @" SELECT
		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @" ) As Count 
                                                           ,M1.Code AS Code,WTOG.Name AS Title
			                                            FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)   Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
                                                        @" AND 
		                                                ((M1.Serial is not null AND 
		                                                (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
			                                                LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
			                                                LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
		                                                WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                            LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
			                                                LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
		                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode =  " + cmbWarehouse.SelectedValue + @")  = 0)
                                                        OR M1.Serial = '0' OR M1.Serial IS NULL )";

            JCustomListSelectorControlWarGoods.ControlToSet = lblTotal.ClientID;
            JCustomListSelectorControlWarGoods.PropertyToSet = "innerHTML";
            JCustomListSelectorControlWarGoods.ExtraField = "Count";
            DataTable dtTypesOfGoods = new DataTable();
            dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(e.Value));
            if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
            {
                txtGoodsCount.Enabled = false;
                txtGoodsCount.Text = "1";

            }
            else
            {
                txtGoodsCount.Enabled = true;
                txtGoodsCount.Text = string.Empty;
            }


            JCustomListSelectorControlWarGoods.Clear();
            //  CmbWarTypesOfGoods.FindItemByValue(e.Value).Selected = true;
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        private EventHandler CustomListSelectorSelectedCodeChanged()
        {
            TotalRemainStock();
            return null;
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnJGoodsUpdateControl_Click(object sender, ImageClickEventArgs e)
        {
            WebClassLibrary.JWebManager.LoadControl("Goods"
               , "~/WebWarehouseManagement/Forms/JGoodsUpdateControl.ascx"
               , "درج کالا"
               , null // new List<Tuple<string, string>>() { new Tuple<string, string>("ReferCode", ReferCode.ToString()) }
               , WebClassLibrary.WindowTarget.NewWindow
               , true, false, true, 650, 450);
        }

        protected void btnAutomatic_Click(object sender, EventArgs e)
        {
            //#region Init
            //WarehouseManagement.Goods.JReceiptOfGoods jReceiptOfGoods = new WarehouseManagement.Goods.JReceiptOfGoods();
            //WarehouseManagement.Goods.JReceiptOfGoodsDetails JReceiptOfGoodsDetails = new WarehouseManagement.Goods.JReceiptOfGoodsDetails();
            //WarehouseManagement.Goods.JBillOfGoods JBillOfGoodS = new WarehouseManagement.Goods.JBillOfGoods();
            //WarehouseManagement.Goods.JBillOfGoodsDetails JBillOfGoodsDet = new WarehouseManagement.Goods.JBillOfGoodsDetails();
            //#endregion Init

            //for (int i = 0; i < rgBills.MasterTableView.Items.Count; i++)
            //{
            //    if (((CheckBox)rgBills.MasterTableView.Items[i]["chbSelect"].FindControl("chbSelect")).Checked == true)
            //    {
            //        #region Find JBill
            //        JBillOfGoodS.GetData(Convert.ToInt32(rgBills.MasterTableView.Items[i].KeyValues.Split(':')[1].Replace("\"", string.Empty).Replace("}", string.Empty)));
            //        #endregion Find JBill

            //        #region Insert Receiption

            //        jReceiptOfGoods.DeliveryPersonCode = JBillOfGoodS.DeliveryPersonCode;
            //        jReceiptOfGoods.ReceiptDate = DateTime.Now;
            //        jReceiptOfGoods.RegisterDate = DateTime.Now;
            //        jReceiptOfGoods.TransfereePersonCode = JBillOfGoodS.TransfereePersonCode;
            //        jReceiptOfGoods.WarehouseCode = JBillOfGoodS.AimWearCode;
            //        jReceiptOfGoods.class_Name = JWebWarehouseManagement._ConstClassName;
            //        jReceiptOfGoods.object_code = JBillOfGoodS.Code;
            //        ViewState["Code"] = jReceiptOfGoods.Insert();

            //        JBillOfGoodS.object_code = JBillOfGoodS.Code;
            //        JBillOfGoodS.Update();

            //        #endregion  Insert Receiption

            //        #region Find JBillDetails
            //        DataTable Bills_dt = WarehouseManagement.Goods.JBillOfGoodsDetailSes.GetDataTableByBillOfGoodsCode(JBillOfGoodS.Code);
            //        #endregion Find JBillDetails

            //        #region  Insert JReceiptOfGoodsDetails
            //        for (int j = 0; j < Bills_dt.Rows.Count; j++)
            //        {
            //            JReceiptOfGoodsDetails.ReceiptOfGoodsCode = (int)ViewState["Code"];
            //            JReceiptOfGoodsDetails.GoodsCode = (int)Bills_dt.Rows[j]["GoodsCode"];
            //            JReceiptOfGoodsDetails.Number = (int)Bills_dt.Rows[j]["Number"];
            //            JReceiptOfGoodsDetails.RegisterDate = DateTime.Now;
            //            JReceiptOfGoodsDetails.Insert();
            //        }
            //        #endregion Insert JReceiptOfGoodsDetails
            //    }
            //}
            //btnAutomatic.Enabled = false;
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Close And Refresh Grid", "<script>GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);</script>", false);
        }

        protected void grdGoodsOfRec_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dtGoodsOfReceipt = new DataTable();
            dtGoodsOfReceipt = WarehouseManagement.Goods.JReceiptOfGoodsDetailSes.GetDataTableByReceiptOfGoodsCode((int)ViewState["Code"]);
            grdGoodsOfRec.DataSource = dtGoodsOfReceipt;
        }

        protected void rgBills_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //DataTable dt = WarehouseManagement.Goods.JBillOfGoodSes.GetData("'" + JWebWarehouseManagement._ConstClassName + "'", -1);
            //dt.DefaultView.RowFilter = " AimWearCode =" + cmbWarehouse.SelectedValue;
            //rgBills.DataSource = dt;
        }
        /// ----------------------------------------------------------------------------------------------------------------------

        #endregion Goods

        #endregion Events
    }
}