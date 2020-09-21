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
        int InComeCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["Code"], out InComeCode);
            _SetForm();
        }

        public void _SetForm()
        {
            ((WebControllers.MainControls.Date.JDateControl)txtPaymentDate).SetDate(DateTime.Now);

            if (!IsPostBack)
            {
                LoadBusCredit();
            }
        }

        public void LoadBusCredit()
        {
            DataTable report = JAUTDocumentDetails.GetBusCredit(InComeCode);
            RadGridPaymentDetail.DataSource = report;
            RadGridPaymentDetail.MasterTableView.EditMode = Telerik.Web.UI.GridEditMode.InPlace;
            if (RadGridPaymentDetail.MasterTableView.DataSource == null)
            {
                RadGridPaymentDetail.DataBind();
            }

            if (InComeCode > 0)
            {
                DataTable DtFinDocDet = WebClassLibrary.JWebDataBase.GetDataTable("select dbo.dateentofa(DateSave)FaDate,(select max(code)+1 from AUTPayment)PayCode from FinDocument where Code = " + InComeCode);
                txtPaymentDiscription.Text = "سند " + DtFinDocDet.Rows[0]["FaDate"].ToString() + " به شماره " + 
                          DtFinDocDet.Rows[0]["PayCode"].ToString() + " - سند " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            }
            else
            {
                txtPaymentDiscription.Text = "سند  پرداخت تاریخ " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
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
                        //if (Code > 0)
                        //{
                        //    payment.Update(db);
                        //}
                        //else
                        //{
                        Code = payment.Insert(db, true);
                        if (Code == 0)
                            throw new Exception();
                        // }

                        #endregion Save

                        #region Save Details

                        //DataTable SelectedOwners = (DataTable)RadGridPaymentDetail.MasterTableView.DataSource;
                        //bool[] SendToBankStatus = new bool[RadGridPaymentDetail.MasterTableView.Items.Count];
                        List<string> OwnerCodes = new List<string>();
                        List<string> BusCodes = new List<string>();
                        for (int i = 0; i < RadGridPaymentDetail.MasterTableView.Items.Count; i++)
                        {
                            if (((CheckBox)(RadGridPaymentDetail.MasterTableView.Items[i]["PaymnetStatus"].FindControl("chbSelect"))).Checked == true)
                            {
                                OwnerCodes.Add(RadGridPaymentDetail.MasterTableView.Items[i]["OwnerPCode"].Text.ToString());
                                // BusCodes.Add(RadGridPaymentDetail.MasterTableView.Items[i]["BusCode"].Text.ToString());
                                //SendToBankStatus[i] = true;
                                //JAUTPaymentDetail detail = new JAUTPaymentDetail();
                                //detail.PaymentCode = Code;
                                //txt_PaymentCodeInput.Value = Code.ToString();
                                //detail.BusCode = Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["BusCode"].Text.ToString());
                                //detail.OwnerPCode = Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["OwnerPCode"].Text.ToString());
                                //detail.PaymentPrice = Convert.ToDecimal(Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["PaymentPrice"].Text.ToString()) / 10);
                                //detail.TotalPrice = Convert.ToDecimal(Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["TotalPrice"].Text.ToString()) / 10);
                                //if (detail.Insert(db) == 0)
                                //{
                                //    throw new Exception();
                                //}
                                //else
                                //{
                                //    JAUTDocumentDetail DocumentDetail = new JAUTDocumentDetail();
                                //    DocumentDetail.GetData(null, Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["Code"].Text.ToString()));
                                //    DocumentDetail.Code = Convert.ToInt32(RadGridPaymentDetail.MasterTableView.Items[i]["Code"].Text.ToString());
                                //    DocumentDetail.SentToBank = true;
                                //    if (DocumentDetail.Update(db) == false)
                                //        throw new Exception();
                                //}
                            }
                            //else
                            //{
                            //SendToBankStatus[i] = false;
                            //}
                        }

                        //                        db.setQuery(@"Insert Into AUTPaymentDetail 
                        //                                        select ROW_NUMBER() over (order by Code)+(select isnull(MAX(Code),0)+1 from AUTPaymentDetail)Code," + Code + @" PaymentCode,
                        //                                        OwnerPCode,BusCode,Amount TottalPrice,Amount PaymentPrice from AUTDocumentDetail where SentToBank = 0 and Code in (" + String.Join(",", OwnerCodes.ToArray()) + @")");


                        //                        db.setQuery(@"Insert Into AUTPaymentDetail select ROW_NUMBER() over(order by TafziliCode1)+(select max(Code) from AUTPaymentDetail)Code," + Code + @" PaymentCode,TafziliCode1 OwnerPCode
                        //                                        ,CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT) TotalPrice
                        //                                        ,CASE WHEN CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)<0 THEN 0 ELSE CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT) END PaymentPrice
                        //                                        from FinDocumentDetails
                        //                                        where MoeinCode = 3 and (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) IS NOT NULL
                        //                                        --and (select ISOK from FinDocument where Code = DocCode) = 1
                        //										and TafziliCode1 in (" + String.Join(",", OwnerCodes.ToArray()) + @")
                        //                                        group by TafziliCode1,MoeinCode
                        //                                        having CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)>0");
                        if (InComeCode > 0)
                        {
                            db.setQuery(@"Insert Into AUTPaymentDetail
                                            select TOP 100 PERCENT ROW_NUMBER() over(order by a.TafziliCode1)+(select max(Code) from AUTPaymentDetail)Code,
                                            " + Code + @" PaymentCode,a.TafziliCode1 OwnerPCode,cast(a.TottalPrice as bigint) TotalPrice,cast(a.PaymentPrice as bigint) PaymentPrice from (
                                            select TafziliCode1,cast(sum(BesPrice - BedPrice) as float)TottalPrice,cast(sum(BesPrice) as float)PaymentPrice from FinDocumentDetails 
                                            where DocCode in(" + InComeCode + @") and TafziliCode1 <> 20000001
                                            and TafziliCode1 in (" + String.Join(",", OwnerCodes.ToArray()) + @")
                                            and MoeinCode = 3
                                            group by TafziliCode1)a");
                        }
                        else
                        {
                            //string BlackListStr = "(select -1)";
                            //DataTable DtBlackList = WebClassLibrary.JWebDataBase.GetDataTable(@"select pCode from UnpaidBlackList where @PaymentDate between FromDate and ToDate".Replace("@PaymentDate", "'" + payment.PaymentDate.ToString("yyyy-MM-dd") + "'"));
                            //if(DtBlackList!=null)
                            //{
                            //    if(DtBlackList.Rows.Count > 0)
                            //    {
                            //        BlackListStr = "(select pCode from UnpaidBlackList where FinDocumentDetails.DateSave between FromDate and ToDate) "
                            //            .Replace("@PaymentDate", "'" + payment.PaymentDate.ToString("yyyy-MM-dd") + "'");
                            //    }
                            //}

                            if (cmbPayInstallments.SelectedValue == "1")
                            { 
                                db.setQuery("exec [dbo].[SP_InstallmentPay] @input_date");
                                db.AddParams("input_date", payment.PaymentDate.ToString("yyyy-MM-dd"));
                                DataTable dt = db.Query_DataTable();
                                if (dt == null || dt.Rows[0][0].ToString() != "1")
                                    throw new Exception();
                            }

                            db.setQuery(@"
                            select FinDocumentDetails.Code into #TTT from FinDocumentDetails 
                            inner join UnpaidBlackList ON FinDocumentDetails.DateSave between FromDate and ToDate and pCode=TafziliCode1
                            where 1=1
	                            and DocCode between 100000000 and 200000000
	                            and (select code from FinDocument where code=DocCode and IsOk=1) is not null
	                            and DocCode<>120160534	
	                            and isnull(PayAfterFinish,0) = 0

                                declare @error int = 0
	                            select TOP 100 PERCENT *
	                            into #tempTbl
	                            from
	                            (
		                            select TOP 100 PERCENT Max(DocCode) DocumentCode,TafziliCode1 OwnerPCode,
                                    (select Name From clsAllPerson where Code = TafziliCode1)OwnerName,
		                            TafziliCode1 TafsiliCode
                                    ,CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT) TotalPrice
                                    ,CASE WHEN CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)<0 THEN 0 ELSE 
			                            CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)
		                            END PaymentPrice
                                    from FinDocumentDetails
		                            left join FinDocument on FinDocument.code = FinDocumentDetails.DocCode
                                    where MoeinCode = 3
                                    and FinDocument.IsOk = 1
		                            and (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) IS NOT NULL
                                    and FinDocumentDetails.Code not in ( select Code from #TTT)
                                    group by TafziliCode1,MoeinCode
                                    having sum(BesPrice) <> sum(BedPrice)
                                    order by TotalPrice 
	                            ) as a
		                            where (PaymentPrice) > 0 
		                            and OwnerPCode in (" + String.Join(",", OwnerCodes.ToArray()) + @") 
	                            order by OwnerPCode,TotalPrice
		                    
	                            begin transaction	
							
		                            Insert Into AUTPaymentDetail 								
		                            select TOP 100 PERCENT ROW_NUMBER() over(order by totalprice)+(select max(Code) from AUTPaymentDetail)Code," +Code+@" PaymentCode
		                            ,OwnerPCode,PaymentPrice TotalPrice,PaymentPrice PaymentPrice from #tempTbl 
		
		                            set @error = @@ERROR; 
		                            if (@error<> 0)
			                            goto error_handler;

                                    if " + cmbUpdateBlackList.SelectedValue + @" = 1
                                    begin

	                                    select TOP 100 PERCENT *
	                                    into #tempTbl2
	                                    from
	                                    (
		                                    select TOP 100 PERCENT Max(DocCode) DocumentCode,TafziliCode1 OwnerPCode,
                                            (select Name From clsAllPerson where Code = TafziliCode1)OwnerName,
		                                    TafziliCode1 TafsiliCode
                                            ,CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT) TotalPrice
                                            ,CASE WHEN CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)<0 THEN 0 ELSE 
			                                    CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)
		                                    END PaymentPrice
                                            from FinDocumentDetails
		                                    left join FinDocument on FinDocument.code = FinDocumentDetails.DocCode
                                            where MoeinCode = 3
                                            and FinDocument.IsOk = 1
		                                    and (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) IS NOT NULL
                                            and FinDocumentDetails.Code in ( select Code from #TTT)
                                            group by TafziliCode1,MoeinCode
                                            having sum(BesPrice) <> sum(BedPrice)
                                            order by TotalPrice 
	                                    ) as a
		                                    where (PaymentPrice) > 0 
		                                    and OwnerPCode in (" + String.Join(",", OwnerCodes.ToArray()) + @") 
	                                    order by OwnerPCode,TotalPrice

                                       --update dbo.UnpaidBlackList set BlockedPrice = ISNULL(block.BlockedPrice, 0) + tbl.PaymentPrice
                                       --from dbo.UnpaidBlackList block
                                       --inner join #tempTbl2 tbl on tbl.OwnerPCode = block.pCode

                                    end
		
		                            set @error = @@ERROR; 
		                            if (@error<> 0)
			                            goto error_handler;


		                            INSERT INTO [dbo].[SMSSend]
                                    ([Code],[Mobile],[Text],[Send],[RegDate],[SendDate],[Description],[Project],[ClassName],[ObjectCode],[PersonCode],[DeliveryDate],[SendDevice],[BatchId])
		                            select TOP 100 PERCENT 
		                            (select isnull(max(code), 0) + 1 from [dbo].[SMSSend]) + row_number() over(order by T.documentCode),
		                            address.Mobile,
		                            CONCAT((select Description from AutPayment where Code=" + Code + @"), N' به مبلغ ', TotalPrice * 10, N' به نام ', OwnerName, N' -- شرکت اتوبوسرانی (بخش خصوصی)'),
		                            0, null, getdate(), null, null,'JPaymentGetDetailReportControl', 0, OwnerPCode, null, null, null
		                            from #tempTbl T
		                            inner join clsPersonAddress address on T.OwnerPCode = address.PCode
		                            where LEN(ISNULL(address.Mobile, 0)) > 1

		                            set @error = @@ERROR; 
		                            if (@error<> 0)
			                            goto error_handler;

	                            commit transaction

	                            error_handler:
	                            IF @error <> 0
	                            begin
	                            ROLLBACK TRANSACTION;
	                            end");
                        }

                        if (db.Query_Execute() <= 0)
                            throw new Exception();

                        //db.setQuery(@"update AUTDocumentDetail set SentToBank = 1 where Code in (" + String.Join(",", OwnerCodes.ToArray()) + @")");
                        // db.setQuery(@"update AUTDocumentDetail set SentToBank = 1 where SentToBank = 0 and 
                        //OwnerPCode in (" + String.Join(",", OwnerCodes.ToArray()) + @") and BusCode in (" + String.Join(",", BusCodes.ToArray()) + @")");

                        //   if (db.Query_Execute() <= 0)
                        //   throw new Exception();

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
                        btnSavePayment.Enabled = false;

                        try
                        {
                            ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
                            dbAccProc.setQuery("EXEC SP_FinPaymentToFinDocument " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + "," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode);
                            dbAccProc.Query_Execute();

                            dbAccProc.setQuery("EXEC SP_FinPaymentCdToFinDocument " + Code);
                            dbAccProc.Query_Execute(true);
                        }
                        catch { }

                        #endregion Details

                        txtPaymentDiscription.Text = "";
                        ((WebControllers.MainControls.Date.JDateControl)txtPaymentDate).SetDate(DateTime.Now);

                        //CreateFile
                        //CreateFile();
                        //btnGetFile.Enabled = true;
                        //RadGridPaymentDetail.Enabled = false;
                        //btnSavePayment.Enabled = false;

                        WebClassLibrary.JWebManager.CloseAndRefresh();

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
                        // WebClassLibrary.JWebManager.RunClientScript("alert('" + ex.Message.ToString() + "');", "ConfirmDialog");
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
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT ad.OwnerPCode,Sum(ad.PaymentPrice) * 10 as PaymentPrice FROM AUTPaymentDetail ad 
                                                                                    WHERE ad.PaymentCode=" + txt_PaymentCodeInput.Value + @" 
                                                                                    Group by ad.OwnerPCode
                                                                                    order by PaymentPrice");
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Sum += Convert.ToInt64(Dt.Rows[i]["PaymentPrice"].ToString());
            }
            return Sum.ToString();
        }

        public void CreateFile()
        {

            try
            {
                ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
                dbAccProc.setQuery("EXEC SP_FinPaymentCDToFinDocument");
                dbAccProc.Query_Execute();
            }
            catch { }

            var sb = new System.Text.StringBuilder();
            string SumPrice = GetPaymentPriceSum(Code.ToString());
            string line = "1   1   " + SumPrice;
            sb.AppendLine(line);
            line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + SumPrice + " D";
            sb.AppendLine(line);

            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT ad.OwnerPCode,fba.AccountNo as AccountNo,Sum(ad.PaymentPrice)PaymentPrice
                                                                                    ,max(ap.Description)PDiscription 
                                                                            FROM AUTPaymentDetail ad 
                                                                            left join finBankAccount fba on fba.PCode = ad.OwnerPCode
                                                                            left join AUTPayment ap on ap.Code = ad.PaymentCode
                                                                            WHERE ad.PaymentCode=" + Code.ToString() + @" 
                                                                            Group by ad.OwnerPCode,fba.AccountNo
                                                                            order by PaymentPrice");
            string AccountNumber = "", PaymentPrice = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                AccountNumber = table.Rows[i]["AccountNo"].ToString();
                PaymentPrice = (Convert.ToInt32(table.Rows[i]["PaymentPrice"].ToString()) * 10).ToString();
                long Price, AcNumber;
                if (long.TryParse(AccountNumber, out AcNumber) == false)
                    AccountNumber = "0";
                if (long.TryParse(PaymentPrice, out Price) == false)
                    PaymentPrice = "0";
                sb.AppendLine(AccountNumber +
                    " " + PaymentPrice + " C");
            }

            //sb.AppendLine("     ");

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

            // WebClassLibrary.JWebManager.CloseWindow();

            //Encoding outputEnc = new UTF8Encoding(false); // create encoding with no BOM
            //TextWriter file = new StreamWriter(HttpContext.Current.Server.MapPath("~/document.txt"), false, outputEnc); // open file with encoding
            //file.WriteLine(sb);
            //file.Close();
            //System.Diagnostics.Process.Start(HttpContext.Current.Server.MapPath("~/document.txt"));
        }

        public string GetPaymentPriceSum(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT ad.OwnerPCode,Sum(ad.PaymentPrice) * 10 as PaymentPrice FROM AUTPaymentDetail ad 
                                                                                    WHERE ad.PaymentCode=" + PaymentCode + @" 
                                                                                    Group by ad.OwnerPCode
                                                                                    order by PaymentPrice");
            Int64 SumPrice = 0;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                SumPrice += Convert.ToInt64(Dt.Rows[i]["PaymentPrice"].ToString());
            }
            Res = SumPrice.ToString();
            return Res;
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