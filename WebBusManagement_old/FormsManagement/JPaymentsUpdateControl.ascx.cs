using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;
using ClassLibrary;
using BusManagment.Documents;
using System.Data;
using System.IO;
using System.Text;

namespace WebBusManagement.FormsManagement
{
    public partial class JPaymentsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            ((WebControllers.MainControls.Date.JDateControl)txtPaymentDate).SetDate(DateTime.Now);

            if (!IsPostBack)
            {
                LoadBusCredit();
            }

            if (Code > 0)
            {
            }
        }

        public void LoadBusCredit()
        {
            DataTable report = JAUTDocumentDetails.GetBusCredit();
            RadGridPaymentDetail.DataSource = report;
            RadGridPaymentDetail.MasterTableView.EditMode = Telerik.Web.UI.GridEditMode.InPlace;
            if (RadGridPaymentDetail.MasterTableView.DataSource == null)
            {
                RadGridPaymentDetail.DataBind();
            }
        }

        protected void btnSavePayment_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtPaymentDate).GetFarsiDate().Length == 10)
            {
                if (RadGridPaymentDetail.MasterTableView.Items.Count > 0)
                {
                    JDataBase db = new JDataBase();
                    try
                    {
                        #region Save Payment
                        JAUTPayment payment = new JAUTPayment(db, Code);
                        payment.Description = txtPaymentDiscription.Text;
                        payment.PaymentDate = ((WebControllers.MainControls.Date.JDateControl)txtPaymentDate).GetDate();
                        payment.Register_Full_Title = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle;
                        payment.Register_Post_Code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode;
                        payment.Register_User_Code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                        db.beginTransaction("SavePayment");
                        if (Code > 0)
                        {
                            payment.Update(db);
                        }
                        else
                        {
                            Code = payment.Insert(db, true);
                            if (Code == 0)
                                throw new Exception();
                        }

                        #endregion Save

                        #region Save Details

                        //DataTable SelectedOwners = (DataTable)RadGridPaymentDetail.MasterTableView.DataSource;
                        //bool[] SendToBankStatus = new bool[RadGridPaymentDetail.MasterTableView.Items.Count];
                        for (int i = 0; i < RadGridPaymentDetail.MasterTableView.Items.Count; i++)
                        {
                            if (((CheckBox)(RadGridPaymentDetail.MasterTableView.Items[i]["PaymnetStatus"].FindControl("chbSelect"))).Checked == true)
                            {
                                //SendToBankStatus[i] = true;
                                JAUTPaymentDetail detail = new JAUTPaymentDetail();
                                detail.PaymentCode = Code;
                                detail.BusCode = Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["BusCode"].Text.ToString());
                                detail.OwnerPCode = Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["OwnerPCode"].Text.ToString());
                                detail.PaymentPrice = Convert.ToDecimal(RadGridPaymentDetail.MasterTableView.Items[i]["PaymentPrice"].Text.ToString());
                                detail.TotalPrice = Convert.ToDecimal(RadGridPaymentDetail.MasterTableView.Items[i]["TotalPrice"].Text.ToString());
                                if (detail.Insert(db) == 0)
                                    throw new Exception();
                            }
                            //else
                            //{
                            //SendToBankStatus[i] = false;
                            //}
                        }

                        //int SendToBankCounter = 0;
                        //foreach (DataRow row in SelectedOwners.Rows)
                        //{
                        //    if (SendToBankStatus[SendToBankCounter])
                        //    {
                        //        JAUTPaymentDetail detail = new JAUTPaymentDetail();
                        //        detail.PaymentCode = Code;
                        //        detail.BusCode = Convert.ToInt32(row["BusCode"]);
                        //        detail.OwnerPCode = Convert.ToInt32(row["OwnerPCode"]);
                        //        detail.PaymentPrice = Convert.ToDecimal(row["PaymentPrice"]);
                        //        detail.TotalPrice = Convert.ToDecimal(row["TotalPrice"]);
                        //        if (detail.Insert(db) == 0)
                        //            throw new Exception();
                        //    }
                        //    SendToBankCounter++;
                        //}
                        db.Commit();
                        #endregion Details

                        txtPaymentDiscription.Text = "";
                        ((WebControllers.MainControls.Date.JDateControl)txtPaymentDate).SetDate(DateTime.Now);

                        //CreateFile
                        //CreateFile();
                        btnGetFile.Enabled = true;
                        RadGridPaymentDetail.Enabled = false;
                        btnSavePayment.Enabled = false;

                        //LoadBusCredit();

                        //WebClassLibrary.JWebManager.RunClientScript("if (confirm('ثبت پرداختها با موفقیت انجام شد ، آیا می خواهید فایل دریافت کنید') == true) {document.getElementById('GetFileConfirmHideField').value = '1';}", "ConfirmDialog");
                        //if (Request.Form["GetFileConfirmHideField"].ToString() == "1")
                        //{

                        //WebClassLibrary.JWebManager.RunClientScript("document.getElementById('GetFileConfirmHideField').value = '0';", "ConfirmDialog");
                        //}

                        //WebClassLibrary.JWebManager.RunClientScript("alert('ثبت پرداختها با موفقیت انجام شد');", "ConfirmDialog");

                    }
                    catch (Exception ex)
                    {
                        db.Rollback("SavePayment");
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ثبت با مشکل مواجه شده است');", "ConfirmDialog");
                    }
                    finally
                    {
                        db.Dispose();
                        //WebClassLibrary.JWebManager.CloseAndRefresh();
                    }

                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('هیچ موردی جهت پرداخت وجود ندارد');", "ConfirmDialog");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تاریخ بسته شدن را انتخاب کنید');", "ConfirmDialog");
            }
        }

        public string GetPriceSum()
        {
            Int64 Sum = 0;
            for (int i = 0; i < RadGridPaymentDetail.MasterTableView.Items.Count; i++)
            {
                if (((CheckBox)(RadGridPaymentDetail.MasterTableView.Items[i]["PaymnetStatus"].FindControl("chbSelect"))).Checked == true)
                {
                    Sum += Convert.ToInt64(RadGridPaymentDetail.MasterTableView.Items[i]["PaymentPrice"].Text.ToString());
                }
            }
            return Sum.ToString();
        }

        public void CreateFile()
        {
            var sb = new StringBuilder();
            string line = "1   1   " + GetPriceSum();
            sb.AppendLine(line);
            line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + GetPriceSum() + " D";
            sb.AppendLine(line);

            DataTable table = (DataTable)RadGridPaymentDetail.MasterTableView.DataSource;
            string AccountNumber = "", PaymentPrice = "";
            for (int i = 0; i < RadGridPaymentDetail.MasterTableView.Items.Count; i++)
            {
                if (((CheckBox)(RadGridPaymentDetail.MasterTableView.Items[i]["PaymnetStatus"].FindControl("chbSelect"))).Checked == true)
                {
                    AccountNumber = RadGridPaymentDetail.MasterTableView.Items[i]["AccountNo"].Text.ToString();
                    PaymentPrice = RadGridPaymentDetail.MasterTableView.Items[i]["PaymentPrice"].Text.ToString();
                    int AcNumber;
                    long Price;
                    if (int.TryParse(AccountNumber,out AcNumber)==false)
                        AccountNumber = "0";
                    if (long.TryParse(PaymentPrice, out Price) == false)
                        PaymentPrice = "0";
                    sb.AppendLine(AccountNumber +
                        " " + PaymentPrice + " C");
                }
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-disposition", "attathment;filename=document.txt");
            Response.AddHeader("Content-Length", sb.Length.ToString());
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        public DataTable GetRadGridDatatable()
        {
            DataTable dtRecords = new DataTable();
            int i = 0;
            foreach (DataColumn col in (RadGridPaymentDetail.DataSource as DataTable).Columns)
            {
                DataColumn colString = new DataColumn(col.ColumnName);
                dtRecords.Columns.Add(colString);
                i++;
            }
            foreach (DataRow row in (RadGridPaymentDetail.DataSource as DataTable).Rows) // loops through each rows in RadGrid
            {
                DataRow dr = dtRecords.NewRow();
                foreach (DataColumn col in (RadGridPaymentDetail.DataSource as DataTable).Columns) //loops through each column in RadGrid
                    dr[col.ColumnName] = row[col.ColumnName];
                dtRecords.Rows.Add(dr);
            }
            return dtRecords;
        }

        protected void btnGetFile_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        protected void RadGridPaymentDetail_PreRender(object sender, EventArgs e)
        {
            if (RadGridPaymentDetail.DataSource == null) return;
            foreach (DataColumn col in (RadGridPaymentDetail.DataSource as DataTable).Columns)
            {
                RadGridPaymentDetail.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
            }
            RadGridPaymentDetail.MasterTableView.Rebind();
        }

        protected void RadGridPaymentDetail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
                LoadBusCredit();
            }
        }

        protected void RadGridPaymentDetail_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LoadBusCredit();
            }
        }

    }
}