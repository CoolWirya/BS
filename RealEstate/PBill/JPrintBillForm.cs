using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Data.OleDb;
using Microsoft.Office.Interop;

namespace RealEstate
{

    public partial class JPrintBillForm : ClassLibrary.JBaseForm
    {
        DataTable dt;
        private String NameUnitBuild = "";

        public JPrintBillForm()
        {
            InitializeComponent();
            _FillComboBox();
        }

        public void _FillComboBox()
        {

            // پر كردن نام مجتمع / بازارها
            DataTable Markets = jMarkets.GetDataTable(0);
            cmbComplex.DisplayMember = estMarket.Title.ToString();
            cmbComplex.ValueMember = estMarket.Code.ToString();
            cmbComplex.DataSource = Markets;
            cmbComplex.SelectedItem = 1;
           
            // ****************************
            JDataBase jMonth = new JDataBase();
            try
            {
                jMonth.setQuery("select * from Remonth");
                DataTable Dt = jMonth.Query_DataTable();
                CmbMonth.DisplayMember = Dt.Columns[1].ToString();
                CmbMonth.ValueMember = Dt.Columns[0].ToString();
                CmbMonth.DataSource = Dt;
                CmbMonth.SelectedItem = 1;
            }
            finally
            {
                jMonth.Dispose();
            }

        }

        private bool CheckComplex()
        {
            if (Convert.ToInt32(cmbComplex.SelectedValue) == 0 || Convert.ToInt32(cmbComplex.SelectedValue )== -1)
            {
                JMessages.Error("هیچ مجتمعی در حال انتخاب نیست", "خطا");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void JPrintBillForm_Load(object sender, EventArgs e)
        {
           
        }

        private Boolean InsertGhabz(ref DataTable Data)
        {
            int i = 0;
            JDataBase Jdb = new JDataBase();
            JPrintableGhabz PrintedGhabz = new JPrintableGhabz();
            try
            {
                DateTime CurrentDate = txtDeadDate.Date;

                txtReport.Text = txtReport.Text + txtReport.Text + "سيستم در حال اخذ اطلاعات بدهي قبلي غرفه ها  .....\r\n";
                ///اطلاعات پايه همه قبض هاي در حال صدور
                PrintedGhabz.CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue.ToString());
                PrintedGhabz.PaymentDeadline = txtDeadDate.Date;
                PrintedGhabz.DateCreate = DateTime.Now.Date;

                string St = JDateTime.FarsiDate(JDateTime.Now()).ToString();
                St = St.Replace("/", "");
                ///محاسبه پيشوند شماره قبض ها
                string ShGhabz = "";
                if (Convert.ToInt32(CmbMonth.SelectedValue) < 10)
                {
                    ShGhabz = St.Remove(4, St.Length - 4) + cmbComplex.SelectedValue.ToString() + "0" + CmbMonth.SelectedValue.ToString();
                }
                else
                {
                    ShGhabz = St.Remove(4, St.Length - 4) + cmbComplex.SelectedValue.ToString() + CmbMonth.SelectedValue.ToString();
                }
                ///اخذ بدهي از سيستم مالي
               
                if (PrintedGhabz.GetMaliData(Convert.ToInt32(cmbComplex.SelectedValue),txtpath.Text))
                {

                    txtReport.Text = txtReport.Text + "اطلاعات مالي دريافت شد...\r\n";
                    txtReport.Text = txtReport.Text + "دريافت اطلاعات صدور قبض...\r\n";
                    Data = PrintedGhabz.GetListOfPrintingCharge(PrintedGhabz.CodeMarket, Convert.ToInt32(CmbBeginPlaque.SelectedValue), Convert.ToInt32(CmbEndPluge.SelectedValue));
                    txtReport.Text = txtReport.Text + " اطلاعات تعداد" + Data.Rows.Count + "  غرفه در يافت شد\r\n";
                    txtReport.Text = txtReport.Text + " سيستم در حال درج اطلاعات قبوض.....\r\n";

                    Jdb.beginTransaction("DesinGhabz");
                    for (i = 0; Data.Rows.Count > i; i++)
                    {
                        ///محاسبه مبلغ قابل پرداخت و بدهي قبلي
                        PrintedGhabz.CodeCustomer = Convert.ToInt32(Data.Rows[i]["PersonCode"]);

                        PrintedGhabz.CodeGhabz = ShGhabz + Data.Rows[i]["Tafsili2"].ToString();

                        PrintedGhabz.CodeUnitBuild = Convert.ToInt32(Data.Rows[i]["CodeUnitbuild"]);
                        PrintedGhabz.CodeUser = 1;
                        PrintedGhabz.Month = Convert.ToInt32(CmbMonth.SelectedValue);// Convert.ToDateTime(Data.Rows[i]["MonthSodor"]);
                        PrintedGhabz.StatusPay = false;
                        ///محاسبه مبلغ قابل پرداخت و بدهي قبلي
                        int CurCharge = Convert.ToInt32(Data.Rows[i]["CurrentCharge"].ToString());
                        if (chkMali.Checked == true)
                        {
                            PrintedGhabz.PreviousDebt = Convert.ToInt32(Data.Rows[i]["Perviuosdebt"]) - CurCharge;
                        }
                        else
                        {
                            PrintedGhabz.PreviousDebt = Convert.ToInt32(Data.Rows[i]["Perviuosdebt"]);

                        }
                        PrintedGhabz.debt = CurCharge + PrintedGhabz.PreviousDebt;
                        if (PrintedGhabz.debt < 0) PrintedGhabz.debt = 0;
                        ///روند كردن
                        string Str = PrintedGhabz.debt.ToString();
                        if (Str.Length > 3)
                        {
                            Str = Str.Remove(Str.Length - 3, 3);
                            Str = Str + "000";

                        }
                        PrintedGhabz.debt = Convert.ToInt32(Str);
                        ///محاسبه يارانه ماه*يارانه
                        PrintedGhabz.Yaraneh = Convert.ToInt32(Data.Rows[i]["Yaraneh"]);
                        ///مبلغ بستانكاري
                        PrintedGhabz.BastanKari = Convert.ToInt32(Data.Rows[i]["BastanKari"]);

                        if (PrintedGhabz.insert(Jdb) == 0)
                        {
                            Jdb.Rollback("DesinGhabz");
                            txtReport.Text = "اين قبض ها قبلا صادر شده است\r\n";

                            return false;
                        }

                    }
                    txtReport.Text = txtReport.Text + " اطلاعات " + i.ToString() + "  اطلاعات غرفه درج شد\r\n";
                    if (i == Data.Rows.Count)
                    {
                        Jdb.Commit();
                        return true;
                    }
                    else
                        Jdb.Rollback("DesinGhabz");
                    //////////////
                }
                else
                {
                    txtReport.Text = txtReport.Text + "سيستم در دريافت اطلاعات مالي دچار مشكل شده است/r/n";
                    return false;
                }
                return true;
            }
            catch
            {
                txtReport.Text = txtReport.Text + "سيستم در دريافت اطلاعات مالي دچار مشكل شده است/r/n";
                Jdb.Rollback("DesinGhabz");
                return false;
            }
            finally
            {

                Jdb.Dispose();
            }
        }

        private Boolean PrintGhabzCharch()
        {
            try
            {
                JPrintableGhabz Ghabz = new JPrintableGhabz();
                txtReport.Text = txtReport.Text + "چاپ قبوض لطفا صبر كنيد .....\r\n";
                txtReport.Text = txtReport.Text + ".............................................. .....\r\n";
                if (Ghabz.PrintGhabZCharch(createQuerySearch()))
                {

                    return true;
                }
                else
                {
                    txtReport.Text = txtReport.Text + "عمليات چاپ دچار ايراد شده است.....\r\n";
                    return false;
                }
            }
            catch (Exception ex)
            {
                JMessages.Message(ex.Message + "\r\n صدور قبض چاپ دچار مشكل شده است", "هشدار", JMessageType.Error);
                return false;
            }
        }

        private DialogResult OprateMassage(string Message)
        {
            return JMessages.Question("آيا از عمليات "+Message  + " ازشماره  " + CmbBeginPlaque.Text + " تا شماره " + CmbEndPluge.Text + " مطمئن هستيد", "هشدار");
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                
              if(OprateMassage("صدور قبض شارژ") ==DialogResult.Yes)
                {
                BtnPrint.Enabled = false;
                txtReport.Text =txtReport.Text+ "ايجاد ليست شارژها .....\r\n";
                txtReport.Text = txtReport.Text + "..................................\r\n";
                DateTime DTDead = txtDeadDate.Date;
                dt = new DataTable();

                if (!CheckComplex())
                {
                    JMessages.Error("هیچ بازاری در حال انتخاب نیست", "خطا");
                    return;
                }

                Boolean Result = InsertGhabz(ref dt);
                if (Result == true)
                {
                    if (PrintGhabzCharch())
                    {
                       txtReport.Text = txtReport.Text+"اجراي عمليات موفقيت آميز بود\r\n";
                    }
                    else
                    {
                        txtReport.Text = txtReport.Text + "اجراي عمليات موفقيت آميز نبود\r\n";
                    }
                    
                }
                else
                {
                    JMessages.Message("در اجراي عمليات مشكلي بروز كرده است", "هشدار", JMessageType.Error);
                }
                BtnPrint.Enabled = true;
                }
            }
            catch
            {
                JMessages.Message("همه اطلاعات لازم براي صدور قبض موجود نيست", "هشدار", JMessageType.Error);
            }
            finally
            {
                BtnPrint.Enabled = true;
            }
           
        }
        
       

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckComplex())
                {
                    JChargeBuild List = new JChargeBuild();
                    List.CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
                    DataTable Data = List.GetListOfCharge(createQueryGhorfeh());
                    GrdCharge.bind(Data);

                    txtReport.Text = " تعداد فضاهاي تجاري مجتمع " + cmbComplex.Text + " " + Data.Rows.Count.ToString() + " فضاهي تجاري مي باشد";
                    //
                    JPrintableGhabz Ghabz = new JPrintableGhabz();
                    DataTable DtGhabz = new DataTable();
                    GrdPrintedGhabz.DataSource = Ghabz.GetListOfprintedCharch(createQuerySearch());
                    //
                }

            }
            catch
            {
                JMessages.Error("بروز خطا در اجرای عملیات", "خطا");
            }
        }

        private string createQueryOparate()
        {
            string Str = "";
            Str = Str + "And dbo.RePrintedCharge.CodeMarket=" + Convert.ToInt32(cmbComplex.SelectedValue);
            Str = Str + " And dbo.RePrintedCharge.Month=" + Convert.ToInt32(CmbMonth.SelectedValue);
            Str = Str + " And dbo.RePrintedCharge.CodeGhabz Like '" + cmbSal.Text.Trim() + cmbComplex.SelectedValue.ToString() + "%'";
            return Str;
        }

        private string createQuerySearch()
        {
           string Str="";
           Str = Str + "And dbo.estUnitBuild.MarketCode=" + Convert.ToInt32(cmbComplex.SelectedValue);
           Str = Str + " And dbo.estUnitBuild.Tafsili2>=" + JDataBase.Quote(CmbBeginPlaque.SelectedValue.ToString()) + " And dbo.estUnitBuild.Tafsili2<=" + JDataBase.Quote(CmbEndPluge.SelectedValue.ToString());
           Str = Str + " And dbo.RePrintedCharge.Month=" + Convert.ToInt32(CmbMonth.SelectedValue);
           Str = Str + " And dbo.RePrintedCharge.CodeGhabz Like '" + cmbSal.Text.Trim() + cmbComplex.SelectedValue.ToString() + "%'";
           return Str;
        }

        private string createQueryGhorfeh()
        {
            string Str = "";
            Str = Str + "And dbo.estUnitBuild.MarketCode=" + Convert.ToInt32(cmbComplex.SelectedValue);
            Str = Str + " And dbo.estUnitBuild.Tafsili2>=" + JDataBase.Quote(CmbBeginPlaque.SelectedValue.ToString()) + " And dbo.estUnitBuild.Tafsili2<=" + JDataBase.Quote(CmbEndPluge.SelectedValue.ToString());
          
            return Str;
        }

        private void cmbComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                JChargeBuild CH = new JChargeBuild();
                CH.GetListOFUnitBuild(CmbBeginPlaque, "Tafsili2", Convert.ToInt32(cmbComplex.SelectedValue));
                CmbBeginPlaque.SelectedItem = 1;
                JChargeBuild CH1 = new JChargeBuild();
                CH1.GetListOFUnitBuild(CmbEndPluge, "Tafsili2", Convert.ToInt32(cmbComplex.SelectedValue));
                //CmbEndPluge.SelectedItem = CmbEndPluge.Items[CmbEndPluge.Items.Count - 1];
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JPrintableGhabz Ghabz = new JPrintableGhabz();
            Ghabz.PrintGhabZCharch(createQuerySearch());
        }

        public  void DelGhabz_Click(object sender, EventArgs e)
        {

            JDataBase jdb = new JDataBase();
            DataTable Dt;
            try
            {
                if (JPermission.CheckPermission("RealEstate.JPrintBillForm.DelGhabz_Click"))
                {

                    if (OprateMassage("حذف قبوض") == DialogResult.Yes)
                    {
                        jdb.beginTransaction("DeleteGhabz");
                        jdb.setQuery("DELETE FROM " + JRETableNames.PrintedCharge + " Where (1=1) " + createQueryOparate());
                        Dt = jdb.Query_DataTable();
                        if (Dt != null)
                        {
                            jdb.Commit();
                            GrdPrintedGhabz.DataSource = Dt;
                        }
                        else
                        {
                            jdb.Rollback("DeleteGhabz");
                        }
                    }
                }
            }
            catch
            {

            }

            finally
            {
                jdb.Dispose();
            }

        }

      

        private void PrintGhabz_Click(object sender, EventArgs e)
        {
            
            if (OprateMassage("چاپ مجدد") == DialogResult.Yes)
            {
                JPrintableGhabz Ghabz = new JPrintableGhabz();
                Ghabz.PrintGhabZCharch(createQuerySearch());
            }
         
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                JChargeBuild BuildCharge = new JChargeBuild();
                JPrintableGhabz GhorfeMali = new JPrintableGhabz();
                if (CheckComplex())
                {
                    if (GhorfeMali.GetMaliData(Convert.ToInt32(cmbComplex.SelectedValue), txtpath.Text))
                    {
                        JMessages.Information("بروز رسانی کامل شد", "");
                        GhorfeMali.CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
                        BuildCharge.CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
                    }
                    else
                    {
                        JMessages.Information("اين قسمت به نرم افزار مالي متصل نيست", "");
                    }
                }
                GrdCharge.bind(BuildCharge.GetListOfCharge(createQueryGhorfeh()));
             
            }
            catch
            {
                JMessages.Error("هیچ بازاری در حال انتخاب نیست", "خطا");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab == tabPage2)
            {
                JChargeBuild List = new JChargeBuild();
                List.CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
                DataTable Data = List.GetListOfCharge(createQueryGhorfeh());
                GrdCharge.bind (Data);
            }
            if (((TabControl)sender).SelectedTab == tabPage3)
            {
                //
                JPrintableGhabz Ghabz = new JPrintableGhabz();
                DataTable DtGhabz = new DataTable();

                GrdPrintedGhabz.DataSource = Ghabz.GetListOfprintedCharch(createQuerySearch());
                //
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CmbBeginPlaque_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtReport_TextChanged(object sender, EventArgs e)
        {

        }

        public  void button1_Click(object sender, EventArgs e)
        {
            JDataBase jdb = new JDataBase();
            DataTable Dt;
            try
            {
                if (JPermission.CheckPermission("RealEstate.JPrintBillForm.button1_Click"))
                {
                    
                    if (OprateMassage("حذف قبوض") == DialogResult.Yes)
                    {
                        jdb.beginTransaction("DeleteGhabz");
                        jdb.setQuery("DELETE FROM " + JRETableNames.PrintedCharge + " Where (1=1) " + createQueryOparate()+" And   (PreviousDebt = 0 AND debt = 0)");
                        Dt = jdb.Query_DataTable();
                        if (Dt != null)
                        {
                            jdb.Commit();
                            GrdPrintedGhabz.DataSource = Dt;
                        }
                        else
                        {
                            jdb.Rollback("DeleteGhabz");
                        }
                    }
                }
            }
            catch
            {

            }

            finally
            {
                jdb.Dispose();
            }

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
//            string str = "";
//            JDataBase jdb = new JDataBase();
//            jdb.setQuery("SELECT  dbo.estUnitBuild.Code, dbo.estUnitBuild.Plaque, dbo.estUnitBuild.MarketCode, dbo.Sheet1$.[New Plaque], dbo.Sheet1$.charge, " +
//                      "dbo.Sheet1$.maincharge, dbo.Sheet1$.yaraneh " +
//"FROM         dbo.estUnitBuild INNER JOIN " +
//                      "dbo.Sheet1$ ON dbo.estUnitBuild.Tafsili2 = dbo.Sheet1$.[New Plaque] " +
//"WHERE     (dbo.estUnitBuild.MarketCode = 100) ORDER BY dbo.estUnitBuild.Plaque ");
//            DataTable dt = jdb.Query_DataTable();
//            foreach (System.Data.DataRow dr in dt.Rows)
//            {
//                try
//                {
//                    str = str + "UPDATE [ReChargeBuild]    SET CurrentCharge = '" + Convert.ToInt32(dr["charge"]).ToString() + "',PeriodCharge = +'" + Convert.ToInt32(dr["maincharge"]).ToString() + "',[Yaraneh] = '" + Convert.ToInt32(dr["yaraneh"]).ToString() + "'  WHERE CodeUnitBuild='" + dr["Code"].ToString() + "' \r\n";
//                }
//                catch
//                {
//                    int k = 0;
//                }

//            }
//            jdb.setQuery(str);
//            int code = jdb.Query_Execute();
//            txtSh.Text = code.ToString();
            //-----------
            //try
            //{
            //    if (JPermission.CheckPermission("RealEstate.JPrintBillForm.DelGhabz_Click"))
            //    {
            //        if (CheckComplex())
            //        {
            //            JPrintableGhabz Gh = new JPrintableGhabz();
            //           int Code= Gh.ChangeSharhSand(Convert.ToInt32(cmbComplex.SelectedValue), TxtSharh.Text, txtSh.IntValue);
            //           if (Code > -1)
            //           {
            //               JMessages.Information("عمليات با موفقيت انجام شد", "ٍError");
            //           }
            //           else
            //           {
            //               JMessages.Error("در اجراي عمليات مشكلي بروز كرده است", "ٍError");
            //           }

            //        }
            //    }
            //}
            //catch
            //{
            //    JMessages.Error("در اجراي عمليات مشكلي بروز كرده است", "ٍError");
            //}
            try
            {
               
                JConnectionForm con = new JConnectionForm(0);
                con.ShowDialog();
            }
            catch(Exception ex)
            {
                JMessages.Error(ex.Message, "error");
            }
           
        }

        private void GrdCharge_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
              
                System.Data.DataRow _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
                int Pcode = (Convert.ToInt32(_DR["Code"]));
                JChargeBuild List = new JChargeBuild(Pcode);
                FSetCharege FCH = new FSetCharege(List);
                FCH.ShowDialog();
                GrdCharge.DataSource = List.GetListOfCharge(createQueryGhorfeh());
            }
            catch
            {
            }
        }

        private void GrdPrintedGhabz_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            System.Data.DataRow _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
            int Pcode = (Convert.ToInt32(_DR["Code"]));
            JPrintableGhabz gh = new JPrintableGhabz();
            gh.GetData(Pcode);
            PrintedGhabzForm prn = new PrintedGhabzForm(gh);
            prn.ShowDialog();
        }
       


       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //openFileDialog.Filter = "Files (*.xls)|*.xls|(*.xlsm)|*.xlsm"; openFileDialog.DefaultExt = ".xls"; 
                OpenFileDialog openFileDialog = new OpenFileDialog(); 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   txtpath.Text = openFileDialog.FileName;
                 // System.Data.DataTable dt=Import(txtpath.Text);
                  
                }
              
            }
            catch
            {
            }
        }
      

            
    }
}
