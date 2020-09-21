using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JBillOfGoodsUpdateControl : System.Web.UI.UserControl
    {
        /// ______________________Edit By Sheikh Nezami_______________________

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

        /// 

        #region Public
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (hfCode.Value == string.Empty)
            {
                int.TryParse(Request["Code"], out Code);
                hfCode.Value = Code.ToString();
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
            // WebClassLibrary.JWebManager.AddToAjaxManager(CmbWarTypesOfGoods.ID, lblTotal.ID, "SelectedIndexChanged");
            if (!IsPostBack)
            {

                LoadData();
                _SetForm();
            }

        }
        ///// ----------------------------------------------------------------------------------------------------------------------
        //protected override void OnPreRender(EventArgs e)
        //{
        //    TotalRemainStock();
        //}
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Public

        /// 

        #region Methods
        /// ----------------------------------------------------------------------------------------------------------------------
        public void LoadData()
        {
            if (int.Parse(hfCode.Value) == 0) rpvGoodsOfReceipt.Visible = false;
            else
            {
                rpvGoodsOfReceipt.Visible = true;
                //if (IsPostBack == false)
                //    Page.PreRender += (sender, args) => { RadMultiPage1.SelectedIndex = 1; };
            }

            // Warehouses
            DataTable dtWarehouses = new DataTable();

            dtWarehouses = WarehouseManagement.Warehouse.JWarehousees.GetDataTableVsPermision();
            cmbWarehouse.DataSource = dtWarehouses;
            cmbWarehouse.DataTextField = "Name";
            cmbWarehouse.DataValueField = "Code";
            cmbWarehouse.DataBind();


            dtWarehouses = WarehouseManagement.Warehouse.JWarehousees.GetDataTable();
            DataRow dr = dtWarehouses.NewRow();
            dr["Name"] = "هیچکدام";
            dr["Code"] = "-1";
            dtWarehouses.BeginInit();
            dtWarehouses.Rows.Add(dr);
            dtWarehouses.EndInit();

            dtWarehouses.AcceptChanges();
            cmbAimWearCode.DataSource = dtWarehouses.DefaultView;
            cmbAimWearCode.DataTextField = "Name";
            cmbAimWearCode.DataValueField = "Code";
            cmbAimWearCode.DataBind();
            cmbAimWearCode.ClearSelection();
            cmbAimWearCode.Items.FindByValue("-1").Selected = true;

            cmbAimWearCode.Items.RemoveAt(cmbAimWearCode.Items.IndexOf(cmbWarehouse.Items.FindByValue(cmbWarehouse.SelectedValue)));
            //ListItem Nothing = new ListItem("هیچکدام", "0");
            //cmbAimWearCode.Items.Add(Nothing);



            if (int.Parse(hfCode.Value) > 0) LoadDetails();
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        private void LoadDetails()
        {
            // Grid GoodsOfBill
            DataTable dtGoodsOfBill = new DataTable();
            dtGoodsOfBill = WarehouseManagement.Goods.JBillOfGoodsDetailSes.GetDataTableByBillOfGoodsCode(int.Parse(hfCode.Value));
            grdGoodsOfBill.DataSource = dtGoodsOfBill;
            grdGoodsOfBill.DataBind();

            WarehouseManagement.Goods.JBillOfGoods jBillOfGoods = new WarehouseManagement.Goods.JBillOfGoods();
            jBillOfGoods.GetData(int.Parse(hfCode.Value));

            if (jBillOfGoods.Status == (short)WarehouseManagement.Goods.JStatusBillOfGoods.Send)
            {
                btnAddGood.Enabled = false;
                btnDeleteGood.Enabled = false;
                btnSendStatus.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                btnAddGood.Enabled = true;
                btnDeleteGood.Enabled = true;
            }

            if (dtGoodsOfBill.Rows.Count == 0)
            {
                btnSendStatus.Enabled = false;
            }
            else
            {
                btnSendStatus.Enabled = true;
            }

        }
        /// ----------------------------------------------------------------------------------------------------------------------
        public void _SetForm()
        {
            DataTable dtTypesOfGoods = new DataTable();
            if (int.Parse(hfCode.Value) > 0)
            {
                WarehouseManagement.Goods.JBillOfGoods jBillOfGoods = new WarehouseManagement.Goods.JBillOfGoods();
                jBillOfGoods.GetData(int.Parse(hfCode.Value));
                ((WebControllers.MainControls.JSearchPersonControl)personDeliver).PersonCode = jBillOfGoods.DeliveryPersonCode;
                ((WebControllers.MainControls.JSearchPersonControl)personTransferee).PersonCode = jBillOfGoods.TransfereePersonCode;
                if (jBillOfGoods.WarehouseCode > 0)
                {
                    int selected = CmbWarTypesOfGoods.SelectedIndex;
                    cmbWarehouse.SelectedValue = jBillOfGoods.WarehouseCode.ToString();
                    if (jBillOfGoods.AimWearCode > 0)
                        cmbAimWearCode.SelectedValue = jBillOfGoods.AimWearCode.ToString();
                    DataTable dtGoods = new DataTable();
                    dtGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetTypeOfGoodsInStock(int.Parse(cmbWarehouse.SelectedValue));
                    CmbWarTypesOfGoods.DataSource = dtGoods;
                    CmbWarTypesOfGoods.DataTextField = "NAME";
                    CmbWarTypesOfGoods.DataValueField = "Code";
                    CmbWarTypesOfGoods.DataBind();
                    CmbWarTypesOfGoods.SelectedIndex = selected;

                    JCustomListSelectorControlWarGoods.Code = 0;
                    JCustomListSelectorControlWarGoods.SQL =
                                                            @"SELECT
	                                                    (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                            LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                                                            LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                            WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
					                                            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
			                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode = " + cmbWarehouse.SelectedValue + @" ) As Count 
                                                           ,M1.Code AS Code,WTOG.Name AS Title
			                                            FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)    Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
                                                                @" AND (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                            LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                                                            LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                            WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
					                                            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
			                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode = " + cmbWarehouse.SelectedValue + @" ) > 0";

                    JCustomListSelectorControlWarGoods.ControlToSet = lblTotal.ClientID;
                    JCustomListSelectorControlWarGoods.PropertyToSet = "innerHTML";
                    JCustomListSelectorControlWarGoods.ExtraField = "Count";
                    
                    dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(CmbWarTypesOfGoods.SelectedValue));

                    if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
                    {
                        txtGoodsCount.Enabled = false;
                        txtGoodsCount.Text = "1";
                        //txtFromSerial.Enabled = true;
                        //txtFromSerial.Text = string.Empty;
                    }
                    else
                    {
                        txtGoodsCount.Enabled = true;
                        txtGoodsCount.Text = string.Empty;
                        //txtFromSerial.Enabled = false;
                        //txtFromSerial.Text = string.Empty;
                    }

                    if (jBillOfGoods.Status == (short)WarehouseManagement.Goods.JStatusBillOfGoods.Send)
                    {
                        btnAddGood.Enabled = false;
                        btnDeleteGood.Enabled = false;
                        btnSendStatus.Enabled = false;
                        btnSave.Enabled = false;
                    }

                    JCustomListSelectorControlWarGoods.Clear();
                }
                ((WebControllers.MainControls.Date.JDateControl)dteBillDate).SetDate(jBillOfGoods.BillDate);
                ((WebControllers.MainControls.Date.JDateControl)dteRegisterDate).SetDate(jBillOfGoods.RegisterDate);
                WarehouseCode = jBillOfGoods.WarehouseCode;
                goodCode = JCustomListSelectorControlWarGoods.Code;



                JCustomListSelectorControlWarGoods.Code = 0;
                // JCustomListSelectorControlWarGoods.Controls.Add(
                //JCustomListSelectorControlWarGoods.
                //  JCustomListSelectorControlWarGoods.OnSelectedCodeChanged += CustomListSelectorSelectedCodeChanged();
                JCustomListSelectorControlWarGoods.SQL = @"SELECT
	                                                    (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                            LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                                                            LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                            WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
					                                            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
			                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode = " + cmbWarehouse.SelectedValue + @" ) As Count 
                                                           ,M1.Code AS Code,WTOG.Name AS Title
			                                            FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)    Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
                                                            @" AND (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                            LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                                                            LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                            WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
					                                            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
			                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode = " + cmbWarehouse.SelectedValue + @" ) > 0";
                JCustomListSelectorControlWarGoods.ControlToSet = lblTotal.ClientID;
                JCustomListSelectorControlWarGoods.PropertyToSet = "innerHTML";
                JCustomListSelectorControlWarGoods.ExtraField = "Count";




                 dtTypesOfGoods = new DataTable();
                dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(CmbWarTypesOfGoods.Items[0].Value));
                if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
                {
                    txtGoodsCount.Enabled = false;
                    txtGoodsCount.Text = "1";
                    //txtFromSerial.Enabled = true;
                    //txtFromSerial.Text = string.Empty;
                }
                else
                {
                    txtGoodsCount.Enabled = true;
                    txtGoodsCount.Text = string.Empty;
                    //txtFromSerial.Enabled = false;
                    //txtFromSerial.Text = string.Empty;
                }


                JCustomListSelectorControlWarGoods.Clear();


            }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        public bool Save()
        {
            WarehouseManagement.Goods.JBillOfGoods jBillOfGoods = new WarehouseManagement.Goods.JBillOfGoods();
            jBillOfGoods.GetData(int.Parse(hfCode.Value));
            jBillOfGoods.DeliveryPersonCode = ((WebControllers.MainControls.JSearchPersonControl)personDeliver).PersonCode;
            jBillOfGoods.BillDate = ((WebControllers.MainControls.Date.JDateControl)dteBillDate).GetDate();
            jBillOfGoods.RegisterDate = ((WebControllers.MainControls.Date.JDateControl)dteRegisterDate).GetDate();
            jBillOfGoods.TransfereePersonCode = ((WebControllers.MainControls.JSearchPersonControl)personTransferee).PersonCode;
            jBillOfGoods.class_Name = JWebWarehouseManagement._ConstClassName;
            jBillOfGoods.Status = (short)WarehouseManagement.Goods.JStatusBillOfGoods.Draft;
            if (ViewState["ClassName"] != null && !string.IsNullOrEmpty(ViewState["ClassName"].ToString()))
            {
                jBillOfGoods.class_Name = ViewState["ClassName"].ToString();
            }
            if (ViewState["ObjectCode"] != null && (int)ViewState["ObjectCode"] > 0)
            {
                jBillOfGoods.object_code = (int)ViewState["ObjectCode"];
            }
            if (cmbWarehouse.SelectedValue != cmbAimWearCode.SelectedValue)
            {
                jBillOfGoods.WarehouseCode = Convert.ToInt32(cmbWarehouse.SelectedValue);
                jBillOfGoods.AimWearCode = Convert.ToInt32(cmbAimWearCode.SelectedValue);
            }
            else
                lblError.Text=" انبار مبدا و مقصد نباید یکسان باشد.";


            if (int.Parse(hfCode.Value) > 0)
            {
                return jBillOfGoods.Update();
            }
            else
            {
                hfCode.Value = jBillOfGoods.Insert().ToString();
                return int.Parse(hfCode.Value) > 0 ? true : false;
            }

        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void TotalRemainStock()
        {
            //if (CmbWarTypesOfGoods.SelectedValue != string.Empty && int.Parse(CmbWarTypesOfGoods.SelectedValue) > 0)
            //{
            //    int.TryParse(CmbWarTypesOfGoods.SelectedValue, out goodCode);
            //int Count = WarehouseManagement.Goods.JGoodSes.GetGoodStock(goodCode, WarehouseCode);
            //lblTotal.Text =  Count.ToString();
            //txtGoodsCount.MaxValue = Count;

            // }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Methods

        ///  

        #region Events

        #region Bill
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(hfCode.Value) > 0 && Save())
                {
                    _SetForm();
                    LoadData();
                    WebClassLibrary.JWebManager.RefreshGrid();
                }
                else if (int.Parse(hfCode.Value) == 0 && Save())
                {

                    WebClassLibrary.JWebManager.RefreshGrid();
                    _SetForm();
                    LoadData();

                }
                else
                    lblError.Text="امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید.";
            }
            catch (Exception ex)
            {
                lblError.Text="امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید.";
            }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtWarehouses = WarehouseManagement.Warehouse.JWarehousees.GetDataTable();
            DataRow dr = dtWarehouses.NewRow();
            dr["Name"] = "هیچکدام";
            dr["Code"] = "-1";
            dtWarehouses.BeginInit();
            dtWarehouses.Rows.Add(dr);
            dtWarehouses.EndInit();

            dtWarehouses.AcceptChanges();
            cmbAimWearCode.DataSource = dtWarehouses.DefaultView;
            cmbAimWearCode.DataTextField = "Name";
            cmbAimWearCode.DataValueField = "Code";
            cmbAimWearCode.DataBind();
            cmbAimWearCode.ClearSelection();
            cmbAimWearCode.Items.FindByValue("-1").Selected = true;

            cmbAimWearCode.Items.RemoveAt(cmbAimWearCode.Items.IndexOf(cmbWarehouse.Items.FindByValue(cmbWarehouse.SelectedValue)));
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Bill

        #region Goods
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnAddGood_Click(object sender, EventArgs e)
        {
            try
            {
                goodCode = JCustomListSelectorControlWarGoods.Code;
                WarehouseCode = int.Parse(cmbWarehouse.SelectedValue);
                DataTable dtTypesOfGoods = new DataTable();

                dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(CmbWarTypesOfGoods.SelectedValue));
                if ( txtGoodsCount.Text != string.Empty && (int.Parse(txtGoodsCount.Text) <= WarehouseManagement.Goods.JGoodSes.GetGoodStock(goodCode, WarehouseCode)))
                {
                    //if (!(bool)dtTypesOfGoods.Rows[0]["HasSerial"] || JCustomListSelectorControlWarGoods.Code != 0)//|| (txtFromSerial.Text != string.Empty && WarehouseManagement.Goods.JGoodSes.FindBySerial(goodCode, WarehouseCode, int.Parse(txtFromSerial.Text)) != 0))
                    //{
                        WarehouseManagement.Goods.JBillOfGoodsDetails jBillOfGoodsDetails = new WarehouseManagement.Goods.JBillOfGoodsDetails();
                        jBillOfGoodsDetails.BillOfGoodsCode = int.Parse(hfCode.Value);
                        //if ((bool)dtTypesOfGoods.Rows[0]["HasSerial"] && txtFromSerial.Text != string.Empty)
                        //if ((bool)dtTypesOfGoods.Rows[0]["HasSerial"] )
                        //    jBillOfGoodsDetails.GoodsCode = WarehouseManagement.Goods.JGoodSes.FindBySerial(goodCode, WarehouseCode, int.Parse(txtFromSerial.Text));
                        //else
                        jBillOfGoodsDetails.GoodsCode = JCustomListSelectorControlWarGoods.Code;

                        jBillOfGoodsDetails.Number = Convert.ToInt32(txtGoodsCount.Text);
                        jBillOfGoodsDetails.RegisterDate = DateTime.Now;
                        jBillOfGoodsDetails.Insert();
                        _SetForm();
                        LoadDetails();
                        TotalRemainStock();
                        btnSendStatus.Enabled = true;
                    //}
                    //else
                    //    lblError.Text="سریال وارد شده برای این کالا صحیح نیست.");
                }
                else
                    lblError.Text="تعداد وارد شده بیش از موجودی انبار |" + WarehouseManagement.Goods.JGoodSes.GetGoodStock(goodCode, WarehouseCode) + "| است .";
            }
            catch (Exception ex)
            {
                lblError.Text="!عملیات مورد نظر با مشکل مواجه شد";
            }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void btnDeleteGood_Click(object sender, EventArgs e)
        {
            WarehouseManagement.Goods.JBillOfGoodsDetails jBillOfGoodsDetails;
            for (int i = 0; i < grdGoodsOfBill.MasterTableView.Items.Count; i++)
            {
                if (((CheckBox)grdGoodsOfBill.MasterTableView.Items[i]["chbSelect"].FindControl("chbSelect")).Checked == true)
                {
                    jBillOfGoodsDetails = new WarehouseManagement.Goods.JBillOfGoodsDetails();
                    jBillOfGoodsDetails.GetData(Convert.ToInt32(grdGoodsOfBill.MasterTableView.Items[i].KeyValues.Split(':')[1].Replace("\"", string.Empty).Replace("}", string.Empty)));
                    jBillOfGoodsDetails.Delete();
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
        //protected void rblBased_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (rblBased.SelectedValue)
        //    {
        //        case "1":
        //            txtFromSerial.Enabled = false;
        //            //  txtToSerial.Enabled = false;
        //            txtGoodsCount.Enabled = true;
        //            txtGoodsCount.Text = string.Empty;
        //            txtFromSerial.Text = string.Empty;
        //            //   txtToSerial.Text = string.Empty;
        //            break;
        //        case "2":
        //            txtFromSerial.Enabled = true;
        //            //   txtToSerial.Enabled = true;
        //            txtGoodsCount.Enabled = false;
        //            txtGoodsCount.Text = "1";
        //            txtFromSerial.Text = string.Empty;
        //            //txtToSerial.Text = string.Empty;
        //            break;
        //    }
        //}
        /// ----------------------------------------------------------------------------------------------------------------------
        protected void CmbWarTypesOfGoods_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //
            JCustomListSelectorControlWarGoods.Code = 0;
            // JCustomListSelectorControlWarGoods.Controls.Add(
            //JCustomListSelectorControlWarGoods.
            //  JCustomListSelectorControlWarGoods.OnSelectedCodeChanged += CustomListSelectorSelectedCodeChanged();
            JCustomListSelectorControlWarGoods.SQL = @"SELECT
	                                                    (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                            LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                                                            LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                            WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
					                                            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
			                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode = " + cmbWarehouse.SelectedValue + @" ) As Count 
                                                           ,M1.Code AS Code,WTOG.Name AS Title
			                                            FROM WarGoods M1  LEFT JOIN WarTypesOfGoods WTOG ON(WTOG.Code = M1.TypeOfGoodsCode)    Where M1.TypeOfGoodsCode = " + CmbWarTypesOfGoods.SelectedValue +
                                                        @" AND (SELECT ISNULL(Sum(d1.Number),0) FROM WarReceiptOfGoodsDetails d1  
                                                            LEFT JOIN WarGoods G1 ON (G1.Code=d1.GoodsCode) 
                                                            LEFT JOIN WarReceiptOfGoods r1 ON (r1.Code=d1.ReceiptOfGoodsCode)
			                                            WHERE d1.GoodsCode = M1.Code AND r1.WarehouseCode =" + cmbWarehouse.SelectedValue + @"  )-
				                                            (SELECT ISNULL(Sum(d2.Number),0) FROM WarBillOfGoodsDetails d2
                                                                LEFT JOIN WarGoods G2 ON (G2.Code=d2.GoodsCode)
					                                            LEFT JOIN WarBillOfGoods W ON (W.Code=d2.BillOfGoodsCode)
			                                                WHERE d2.GoodsCode  =  M1.Code  AND W.WarehouseCode = " + cmbWarehouse.SelectedValue + @" ) > 0";
            JCustomListSelectorControlWarGoods.ControlToSet = lblTotal.ClientID;
            JCustomListSelectorControlWarGoods.PropertyToSet = "innerHTML";
            JCustomListSelectorControlWarGoods.ExtraField = "Count";




            DataTable dtTypesOfGoods = new DataTable();
            dtTypesOfGoods = WarehouseManagement.Goods.JTypesOfGoodSes.GetDataTable(int.Parse(e.Value));
            if (dtTypesOfGoods.Rows.Count > 0 && (bool)dtTypesOfGoods.Rows[0]["HasSerial"])
            {
                txtGoodsCount.Enabled = false;
                txtGoodsCount.Text = "1";
                //txtFromSerial.Enabled = true;
                //txtFromSerial.Text = string.Empty;
            }
            else
            {
                txtGoodsCount.Enabled = true;
                txtGoodsCount.Text = string.Empty;
                //txtFromSerial.Enabled = false;
                //txtFromSerial.Text = string.Empty;
            }


            JCustomListSelectorControlWarGoods.Clear();
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


        /// <summary>
        /// تایید نهایی ارسال کالا
        /// بعد از این مرحله دیگه سند حواله قابل ویرایش نخواهد بود
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendStatus_Click(object sender, EventArgs e)
        {
            try
            {
                WarehouseManagement.Goods.JBillOfGoods jBillOfGoods = new WarehouseManagement.Goods.JBillOfGoods();
                jBillOfGoods.GetData(int.Parse(hfCode.Value));
                jBillOfGoods.Status = (short)WarehouseManagement.Goods.JStatusBillOfGoods.Send;
                jBillOfGoods.Update();
                btnAddGood.Enabled = false;
                btnDeleteGood.Enabled = false;
                btnSendStatus.Enabled = false;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text=" عملیات ارسال کالا با مشکل مواجه شد.";
            }
        }
        /// ----------------------------------------------------------------------------------------------------------------------
        #endregion Goods

        #endregion Events

        ///
    }
}