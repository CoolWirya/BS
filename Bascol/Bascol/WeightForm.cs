using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
//using AxMSCommLib;

namespace Bascol
{
    public partial class JWeightForm : JBaseForm
    {
        long _Code;
        int _Price;
        //int _PriceKhales;
        int _WeightKhales;
        public string s1;
        int _Counter;
        int _Type;
        // <summary>
        /// ظرفیت باسکول جهت نمایش در چاپ
        /// </summary>
        public static int _bascoolCapacity;

        private string txtplok
        {
            get
            {
                return txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;
            }
        }

        public JWeightForm()
        {
            InitializeComponent();
        }

        public JWeightForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }

        private void SetForm()
        {
            try
            {
                JWeight tmpWeight = new JWeight(_Code);
                //lsTrucks.SelectedValue = tmpWeight.TruckCode;
                _Price = Convert.ToInt32(tmpWeight.pay.ToString());
                txtPay.Text = tmpWeight.pay_h.ToString();
                //tmpWeight.BascoolCode = tssBascol.Text;
                //txtDate.Text = tmpWeight.WDate.ToString();
                lblDate.Text = tmpWeight.WDate.ToString();
                //txtTime.Text = tmpWeight.WTime;
                lblTime.Text = tmpWeight.WTime;
                txtPlak1.Text = tmpWeight.PlokNo.Substring(0, 3);
                txtPlak2.Text = tmpWeight.PlokNo.Substring(0, 3);
                cmbPlak.Text = tmpWeight.PlokNo.Substring(3, 1);
                lblWeight.Text = tmpWeight.Weights.ToString();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        //public bool InsertAccess()
        //{
        //    ClassLibrary.JOLeDbDataBase MyDB = new ClassLibrary.JOLeDbDataBase();
        //    try
        //    {
        //        string txtplok = txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;
        //        MyDB.setQuery(@"INSERT INTO Weight (WDate,WTime,Plokno,UserNo,ProductNo,Weights,TruckNo,PrintNo,hamrahno,pay_h, BascoolNo,UserPostCode,Pay) VALUES ('" +
        //    txtDate.Date + "','" + txtTime.Text + "','" + txtplok + "'," + JMainFrame.CurrentPersonCode + "," + cmbProduct.SelectedValue.ToString() + "," +
        //    lblWeight.Text + "," + lsTrucks.SelectedValue.ToString() + ",1," + txtHamrah.Text + "," + (Convert.ToInt32(txtPay.Text)+ Convert.ToInt32(lblBedehkari.Text)).ToString()
        //    + "," + lblBascolNum.Text + "," + JMainFrame.CurrentPostCode + "," + _Price+ ")");

        //        if (MyDB.Query_Execute() > 0)
        //        {
        //            Print();
        //            btnClear_Click(null, null);
        //            JMessages.Error(" با موفقیت ثبت شد ", "");
        //            return true;
        //        }
        //        else
        //        {
        //            JMessages.Error(" با موفقیت ثبت نشد ", "");
        //            return false;
        //        }
        //    }
        //    finally
        //    {
        //        MyDB.Dispose();
        //    }
        //}

        private void btnSabt_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (Convert.ToInt32(cmbTruck.SelectedValue) == -1)
                {
                    JMessages.Error(" ماشین را وارد کنید ", "");
                    cmbTruck.Focus();
                    return;
                }
                if (txtPay.Text == "")
                {
                    JMessages.Error(" قیمت را وارد کنید ", "");
                    txtPay.Focus();
                    return;
                }
                if ((txtPlak1.Text == "") || (txtPlak1.Text.Length < 2))
                {
                    JMessages.Error(" شماره پلاک را وارد کنید ", "");
                    txtPlak1.Focus();
                    return;
                }
                if ((txtPlak2.Text == "") || (txtPlak2.Text.Length < 3))
                {
                    JMessages.Error(" شماره پلاک را وارد کنید ", "");
                    txtPlak2.Focus();
                    return;
                }
                if ((txtPlak3.Text == "") || (txtPlak3.Text.Length < 2))
                {
                    JMessages.Error(" شماره پلاک را وارد کنید ", "");
                    txtPlak2.Focus();
                    return;
                }
                if (cmbPlak.Text == "")
                {
                    JMessages.Error(" شماره پلاک را وارد کنید ", "");
                    txtPlak2.Focus();
                    return;
                }                
                if (lblBascolNum.Text == "0")
                {
                    JMessages.Error(" شماره باسکول وجود ندارد در قسمت تنظیمات شماره باسکول را تنظیم کنید ", "");
                    return;
                }
                if (lblWeight.Text == "0")
                {
                    JMessages.Error(" توزینی روی باسکول وجود ندارد ", "");
                    return;
                }
                #endregion

                string txtplok = txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;
                JWeight tmpWeight = new JWeight();
                //tmpWeight.TruckCode = Convert.ToInt32(lsTrucks.SelectedValue.ToString());
                tmpWeight.TruckCode = Convert.ToInt32(cmbTruck.SelectedValue.ToString());
                tmpWeight.UserPostCode = JMainFrame.CurrentPostCode;
                tmpWeight.PersonCode = JMainFrame.CurrentPersonCode;
                tmpWeight.pay = _Price;//Convert.ToInt32(txtPay.Text);
                tmpWeight.pay_h = Convert.ToInt32(txtPay.Text);
                tmpWeight.BascoolCode = Convert.ToInt32(lblBascolNum.Text);
                //tmpWeight.WDate = txtDate.Date;
                tmpWeight.WDate = DateTime.Now;
                tmpWeight.WTime = lblTime.Text;
                tmpWeight.PlokNo = txtplok;
                tmpWeight.Weights = Convert.ToInt32(lblWeight.Text);
                tmpWeight.Duty = (tmpWeight.pay / (100 + _Duty + _Tax)) * _Duty;
                tmpWeight.Tax = (tmpWeight.pay / (100 + _Duty + _Tax)) *_Tax ;
                if (txtHamrah.Text == "")
                    txtHamrah.Text = "0";
                tmpWeight.hamrahno = Convert.ToInt32(txtHamrah.Text);
                tmpWeight.ProductCode = Convert.ToInt32(cmbProduct.SelectedValue.ToString());
                tmpWeight.PrintNo = 1;
                if (_Counter == 0)
                    tmpWeight.BascoolID = JWeights.GetCounter();
                else
                    tmpWeight.BascoolID = _Counter;
                if (tmpWeight.BascoolID == 0)
                {
                    JMessages.Error(" خطا در شماره سریال قبض ","");
                    return;
                }
                if ((JSystem.Nodes.DataTable.Rows.Count > 0) && ((JSystem.Nodes.DataTable.Rows.Count % 5) == 0) && (FlagKhales))
                {
                    Transfer(false);
                    lblWeight.Visible = false;
                    lblWeight.Visible = true;
                }
                _Code = tmpWeight.Insert();
                if (_Code > 0)
                {
                    //InsertAccess();
                    txtPlak1.Text = "";
                    Print();
                    //if (JSystem.Nodes.DefaultView.Rows.Count > 20)
                    //    btnHamgam_Click(null,null);
                    Clear();
                    txtPlak1.Focus();
                }
                else
                    JMessages.Error(" با موفقیت ثبت نشد ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" با موفقیت ثبت نشد ", "");
            }
        }

        private void JWeightForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                for (int i = 0; i < _Shortcut.Length - 1; i++)
                {
                    if ((e.KeyCode == Keys.F1) && (_Shortcut[i, 1].Trim() == "F1"))
                    {
                        //lsTrucks.SelectedValue = _Shortcut[i, 0];
                        //lsTrucks_SelectedIndexChanged(null, null);
                        cmbTruck.SelectedValue = _Shortcut[i, 0];
                        cmbTruck_SelectedIndexChanged(null, null);
                    }
                    if ((e.KeyCode == Keys.F2) && (_Shortcut[i, 1].Trim() == "F2"))
                    {
                        cmbTruck.SelectedValue = _Shortcut[i, 0];
                        cmbTruck_SelectedIndexChanged(null, null);
                    }
                    if ((e.KeyCode == Keys.F3) && (_Shortcut[i, 1].Trim() == "F3"))
                    {
                        cmbTruck.SelectedValue = _Shortcut[i, 0];
                        cmbTruck_SelectedIndexChanged(null, null);
                    }
                    if ((e.KeyCode == Keys.F4) && (_Shortcut[i, 1].Trim() == "F4"))
                    {
                        cmbTruck.SelectedValue = _Shortcut[i, 0];
                        cmbTruck_SelectedIndexChanged(null, null);
                    }
                    if ((e.KeyCode == Keys.F5) && (_Shortcut[i, 1].Trim() == "F5"))
                    {
                        cmbTruck.SelectedValue = _Shortcut[i, 0];
                        cmbTruck_SelectedIndexChanged(null, null);
                    }
                    if ((e.KeyCode == Keys.F6) && (_Shortcut[i, 1].Trim() == "F6"))
                    {
                        cmbTruck.SelectedValue = _Shortcut[i, 0];
                        cmbTruck_SelectedIndexChanged(null, null);
                    }
                    //if ((e.KeyCode == Keys.F7) && (_Shortcut[i, 1].Trim() == "F7"))
                    //{
                    //    cmbTruck.SelectedValue = _Shortcut[i, 0];
                    //    cmbTruck_SelectedIndexChanged(null, null);
                    //}
                }

                if ((e.Control) && (e.KeyCode == Keys.N))
                    btnClear_Click(null, null);
                if ((e.KeyCode == Keys.F9))
                    btnPrint_Click(null, null);
                if ((e.KeyCode == Keys.F10))
                    btnPrint2_Click(null, null);

                if ((e.Control) && (e.KeyCode == Keys.S))
                    btnClear_Click(null, null);
                if (e.KeyCode == Keys.F11)
                    btnKhales_Click(null, null);
                if (e.KeyCode == Keys.F12)
                    btnSabt_Click(null, null);
                if ((e.KeyCode == Keys.F8))
                    btnHamgam_Click(null, null);
                if ((e.KeyCode == Keys.F7))
                {
                    if (lblWeight.Visible)
                        lblWeight.Visible = false;
                    else
                        lblWeight.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        decimal _Tax, _Duty;
        private void GetTaxDuty()
        {
            JTransferData tmpT = new JTransferData();
            tmpT.GetTaxDuty();
            _Tax = tmpT._Tax;
            _Duty = tmpT._Duty;
        }

        private void JWeightForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserName.Text = JMainFrame.CurrentUser.Person.Name + "  " + JMainFrame.CurrentUser.Person.Fam;
                //if (Globals.JRegistry.Read("BascolNum") != null)
                //{
                    lblBascolNum.Text = JReport.GetBascoolNumber().ToString();// Globals.JRegistry.Read("BascolNum").ToString();
                    _Type = JReport.GetBascoolType();
                    //_bascoolCapacity = Convert.ToInt32(JReport.GetBascols(Convert.ToInt32(lblBascolNum.Text)).Rows[0]["Capacity"]);
                //}
                txtPlak1.Focus();
                FillTruck();
                if (this.State == JFormState.Insert)
                {
                    //txtTime.Text = DateTime.Now.ToLongTimeString();
                    string Min = "";
                    if (DateTime.Now.Minute.ToString().Length == 1)
                        Min = "0" + DateTime.Now.Minute.ToString();
                    else
                        Min =  DateTime.Now.Minute.ToString();
                    string Hour = "";
                    if (DateTime.Now.Hour.ToString().Length == 1)
                        Hour = "0" + DateTime.Now.Hour.ToString();
                    else
                        Hour = DateTime.Now.Hour.ToString();
                    lblTime.Text = Hour + ":" + Min;
                    //txtDate.Date = DateTime.Now;// Convert.ToDateTime(Globals.JRegistry.Read("DateExternalResturant"));
                    lblDate.Text = JDateTime.FarsiDate(DateTime.Now);
                    lblDay.Text = JLanguages._Text(DateTime.Now.DayOfWeek.ToString());
                }
                else
                {
                    SetForm();
                }
                GetTaxDuty();
                InitComPort();
                cmbProduct.SelectedIndex = 1;
                //lsTrucks.SelectedIndex = 1;
                //lsTrucks.SelectedIndex = 0;
                cmbPlak.SelectedIndex = 20;
                txtPlak1.Focus();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        string[,] _Shortcut;

        private void FillTruck()
        {
            try
            {
                DataTable dtTrucks = JTruck.GetDataTable(0);
                //lsTrucks.DataSource = dtTrucks;
                //lsTrucks.DisplayMember = "FullName";
                //lsTrucks.ValueMember = "Code";
                _Shortcut = new string[dtTrucks.Rows.Count, 2];
                for (int i = 0; i < dtTrucks.Rows.Count; i++)
                {
                    _Shortcut[i, 0] = dtTrucks.Rows[i]["Code"].ToString();
                    _Shortcut[i, 1] = dtTrucks.Rows[i]["Shortcut"].ToString();
                }

                dtTrucks.Rows.Add(-1, " ", 0, DateTime.Now, DateTime.Now, "", " ");
                cmbTruck.DataSource = dtTrucks;                
                cmbTruck.DisplayMember = "FullName";
                cmbTruck.ValueMember = "Code";
                //JProductss JCCs = new JProductss();
                //JCCs.SetComboBox(cmbProduct, 1);

                DataTable dtProduct  = JProductss.GetDataTable();
                dtProduct.Rows.Add(-1, 901,"");
                dtProduct.Select("", "Code");
                cmbProduct.DataSource = dtProduct;
                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Code";
            }
            catch (Exception ex)

            {
                JSystem.Except.AddException(ex);
            }
        }
        int Talab = 1;

        private void Bedehi()
        {
            if ((txtPlak1.Text != "") && (cmbPlak.Text != "") && (txtPlak2.Text != "") && (txtPlak3.Text != "")
                && (txtPlak1.Text.Length == 2) && (txtPlak2.Text.Length == 3) && (txtPlak3.Text.Length == 2))
            {
                string str = txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;
                lblBedehkari.Text = JWeight.GetBedehi(str, Convert.ToInt32(cmbTruck.SelectedValue.ToString())).ToString();
                lblBedehkariName.Text = "";
                lblB.Text = "";
                if (Convert.ToInt32(lblBedehkari.Text) > 0)
                    lblB.Text = lblB.Text + " بدهکار به آقای";
                else if (Convert.ToInt32(lblBedehkari.Text) < 0)
                    lblB.Text = lblB.Text + "طلبکار از آقای ";
                if (lblBedehkari.Text != "0")
                {
                    txtPay.Text = (Convert.ToInt32(_Price) + Convert.ToInt32(lblBedehkari.Text)).ToString();
                    lblBedehkariName.Text = JWeight.GetBedehiName(str);
                    lblBedehkariName.Text = lblB.Text + lblBedehkariName.Text + " می باشد ";
                    if (lblBedehkariName.Text != "")
                        if (Convert.ToInt32(lblBedehkari.Text) < 0)
                            JMessages.Information(" این ماشین  " + lblBedehkariName.Text + " ", "طلبکاری");
                        else
                            JMessages.Information(" این ماشین  " + lblBedehkariName.Text + " ", "بدهکاری");
                }
                if (Convert.ToInt32(lblBedehkari.Text) < 0)
                {
                    Talab = -1;
                    lblBedehkari.Text = (Convert.ToInt32(lblBedehkari.Text) ).ToString();//* Talab
                }
                else
                    Talab = 1;

                //if (ClassLibrary.JPing.Ping("192.168.3.38"))
                //{
                //    if (JReport.GetBlackList(str).Rows.Count > 0)
                //        JMessages.Error(" این ماشین در لیست سیاه است ", "");
                //}
            }
        }

        private void GetPlak()
        {

            if ((txtPlak1.Text != "") && (cmbPlak.Text != "") && (txtPlak2.Text != "") && (txtPlak3.Text != "")
                && (txtPlak1.Text.Length == 2) && (txtPlak2.Text.Length == 3) && (txtPlak3.Text.Length == 2))
            {
                string str = txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;
                int TruckNo = JWeight.GetPlak(str);
                if (TruckNo.ToString() != "0")
                {
                    //this.label4.ForeColor = System.Drawing.Color.Black;
                    //this.cmbTruck.ForeColor = System.Drawing.Color.Black;
                    cmbTruck.SelectedValue = TruckNo;
                }
                else
                {
                    cmbTruck.SelectedValue = -1;
                    //this.label4.ForeColor = System.Drawing.Color.Red;
                    //this.cmbTruck.ForeColor = System.Drawing.Color.Red;
                }
                //lsTrucks.SelectedValue = TruckNo;
                //else
                //    cmbPlak.ForeColor = System.Drawing.Color.Red;
            }
        } 

        private void lsTrucks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lsTrucks.SelectedItem != null)
            //{
            //    _Price = Convert.ToInt32(((System.Data.DataRowView)(lsTrucks.SelectedItem)).Row["Price"].ToString());
            //    txtPay.Text = _Price.ToString();
            //}
            //Bedehi();
            //txtPlak1.Focus();
        }

        private void txtPlak1_TextChanged(object sender, EventArgs e)
        {
            if (txtPlak1.Text.Length >= 2)
                cmbPlak.Focus();
            Bedehi();
        }

        private void txtPlak2_TextChanged(object sender, EventArgs e)
        {
            if (txtPlak2.Text.Length >= 3)
                txtPlak3.Focus();
            Bedehi();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            //if (JMessages.Question(" آیا می خواهید آخرین قبض دوباره چاپ شود ؟ ", "") == DialogResult.Yes)
            //{
                DataTable tmpdt;
                tmpdt = JWeights.GetLastDataTableAccess();
                if ((tmpdt != null) && (tmpdt.Rows.Count > 0))
                {
                }
                else
                    tmpdt = JWeights.GetLastDataTable();

                if ((tmpdt != null) && (tmpdt.Rows.Count > 0))
                {
                    _Code = Convert.ToInt32(tmpdt.Rows[0]["Code"]);
                    Print();                    
                }
                else
                    JMessages.Error(" آخرین قبضی برای چاپ وجود ندارد ","");
            //}
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            JReportUserForm p = new JReportUserForm(true);
            p.ShowDialog();
        }

        private void Clear()
        {
            txtPlak1.Text = "";
            txtPlak2.Text = "";
            txtPlak3.Text = "";
            txtPlak1.Text = "";
            _Price = 0;
            //txtPay.Text = "";
            //lblWeight.Text = "0";
            txtHamrah.Text = "0";
            _Code = 0;
            //lsTrucks_SelectedIndexChanged(null,null);
            cmbTruck_SelectedIndexChanged(null, null);   
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            JWeight tmpWeight = new JWeight();
            DataTable tmpdt;
            try
            {
                tmpdt = JWeights.GetLastDataTable();
                if ((tmpdt != null) && (tmpdt.Rows.Count > 0))
                {                    
                    tmpWeight.GetData(Convert.ToInt32(tmpdt.Rows[0]["Code"]));
                    if (tmpWeight.verify == true)
                    {
                        JMessages.Error(" این تورین تایید مالی شده و قابل تغییر نمی باشد ","");
                        return;
                    }
                    tmpWeight.pay_h = Convert.ToInt32(txtPay.Text);
                    if (tmpWeight.Update())
                        JMessages.Information(" ویرایش با موفقیت انجام شد ", "");
                    else
                        JMessages.Error(" خطا در ویرایش ", "");
                }
                else
                    JMessages.Error(" رکوردی با این کاربری پیدا نشد ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblDate.Text == "")
                txtPlak1.Focus();
            string Min = "";
            if (DateTime.Now.Minute.ToString().Length == 1)
                Min = "0" + DateTime.Now.Minute.ToString();
            else
                Min = DateTime.Now.Minute.ToString();

            string Hour = "";
            if (DateTime.Now.Hour.ToString().Length == 1)
                Hour = "0" + DateTime.Now.Hour.ToString();
            else
                Hour = DateTime.Now.Hour.ToString();
            lblTime.Text = Hour + ":" + Min;
            lblDate.Text = JDateTime.FarsiDate(DateTime.Now);
        }

        bool FlagKhales = true;
        private void btnKhales_Click(object sender, EventArgs e)
        {
            if (!((txtPlak1.Text != "") && (cmbPlak.Text != "") && (txtPlak2.Text != "") && (txtPlak3.Text != "")
                && (txtPlak1.Text.Length == 2) && (txtPlak2.Text.Length == 3) && (txtPlak3.Text.Length == 2)))
            {
                JMessages.Error(" شماره پلاک را وارد کنید ", "");
                txtPlak1.Focus();
                return;
            }
            bool Flag = true;
            if (ClassLibrary.JPing.Ping("192.168.3.1"))
            {
                JReportUserForm pUser = new JReportUserForm(txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text);
                if (pUser.ShowDialog() == DialogResult.OK)
                {
                    Flag = false;
                    _WeightKhales = pUser._Weight;
                    JEmptyWeight tmp = new JEmptyWeight();
                    tmp.BascoolNo = Convert.ToInt32(lblBascolNum.Text);
                    tmp.EmptyBascoolNo = pUser._BascolCode;
                    tmp.DateWeight = pUser._Date;
                    tmp.EmptyWeight = pUser._Weight;
                    _Counter = JWeights.GetCounter();
                    tmp.WeightID = _Counter;
                    if (tmp.WeightID == 0)
                    {
                        JMessages.Error(" خطا در شماره سریال قبض ", "");
                        return;
                    }
                    if (JMessages.Confirm(" وزن " + tmp.EmptyWeight.ToString(), "") == DialogResult.Yes)
                    {
                        if (tmp.Insert() > 0)
                        {
                            FlagKhales = false;
                            btnSabt_Click(null, null);
                            FlagKhales = true;
                        }
                        else
                            JMessages.Error(" با موفقیت ثبت نشد ", "");
                        _Counter = 0;
                    }
                }
            }
            if(Flag)
            {
                JKhalesWeightForm p = new JKhalesWeightForm();
                if (p.ShowDialog() == DialogResult.OK)
                {
                    _WeightKhales = p._Weight;
                    JEmptyWeight tmp = new JEmptyWeight();
                    tmp.BascoolNo = Convert.ToInt32(lblBascolNum.Text);
                    tmp.EmptyBascoolNo = p._BascolCode;
                    tmp.DateWeight = p._Date;
                    tmp.EmptyWeight = p._Weight;
                    _Counter = JWeights.GetCounter();
                    tmp.WeightID = _Counter;
                    if (tmp.WeightID == 0)
                    {
                        JMessages.Error(" خطا در شماره سریال قبض ", "");
                        return;
                    }
                    if (tmp.Insert() > 0)
                    {
                        FlagKhales = false;
                        btnSabt_Click(null, null);
                        FlagKhales = true;
                    }
                    else
                        JMessages.Error(" با موفقیت ثبت نشد ", "");
                    _Counter = 0;
                }
            }
        }

        private void txtPlak3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPlak3.Text.Length >= 2)
                {
                    cmbTruck.Focus();
                    GetPlak();
                    Bedehi();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا در محاسبه بدهی ", "");
            }
        }

        private void Print()
        {
            try
            {
                DataTable dt = JWeights.GetDataTableAll(_Code, false);
                dt.Columns.Add("State");
                dt.Columns.Add("StateHamrah");
                if (Convert.ToInt32(dt.Rows[0]["PrintNo"]) >= 2)
                   dt.Rows[0]["State"] =  "این برگه المثنی" + " قبض شماره " + dt.Rows[0]["BascoolID"].ToString() + " مورخ " + dt.Rows[0]["WDate"].ToString() + "ساعت" + dt.Rows[0]["WTime"].ToString().Trim() + "می باشد";
                else
                    dt.Rows[0]["State"] = "";
                if (Convert.ToInt32(dt.Rows[0]["HamrahNO"]) != 0)
                    dt.Rows[0]["StateHamrah"] = dt.Rows[0]["HamrahNO"] + "    تعداد همراه  ";
                else
                    dt.Rows[0]["StateHamrah"] = "";

                if (JMainFrame.BaseCurrentPostCode == 1)
                {
                    JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Bascool.GetHashCode());
                    DRF.Add(dt);
                    DRF.ShowDialog();
                }
                else
                {
                    JDynamicReports DRF = new JDynamicReports(JReportDesignCodes.BillGoods.GetHashCode());
                    DRF.Add(dt);
                    DRF.Print("چاپ قبض", false, false);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا در چاپ ", "");
            }
        }

        private void Transfer(bool msg)
        {
            JTransferData tmp = new JTransferData();
            try
            {
                if (!(tmp.Transfer()))
                {
                    if (msg)
                        JMessages.Error(" انتقال با مشکل مواجه شده است ", "");
                }
                else
                {
                    if (msg)
                        JMessages.Information(" انتقال با موفقیت انجام گردید ", "");
                }
                //JSystem.Nodes.CurrentAction = JSystem.Nodes.CurrentAction;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                tmp.Dispose();
            }
        }

        private void btnHamgam_Click(object sender, EventArgs e)
        {
            Transfer(true);
        }

        private void lblBedehkari_TextChanged(object sender, EventArgs e)
        {
            txtPay.Text = (Convert.ToInt32(txtPay.Text) + Convert.ToInt32(lblBedehkari.Text) ).ToString();//* Talab
        }

        /// <summary>
        /// //////////////Port//////////////////////////////////////////////////////
        /// </summary>

        private void InitComPort()
        {
            try
            {
                // Set the com port to be 1
                com.PortName = "COM1";
                if (com.IsOpen)
                    com.Close();
                com.Open();
                // This port is already open, then close.
                if (!(com.IsOpen))
                {
                    JMessages.Information(" ارتباط بر قرار نشد ", "");
                    return;
                }
                // Trigger the OnComm event whenever data is received
                //com.RThreshold = 1;
                com.ReceivedBytesThreshold = 1;

                // Set the port to 1200 baud, no parity bit, 8 data bits, 1 stop bit (all standard)
                //com.BaudRate = "1200,n,8,1";
                com.BaudRate = 1200;
                com.Parity = System.IO.Ports.Parity.None;
                com.DataBits = 8;
                com.StopBits = System.IO.Ports.StopBits.One;

                // Force the DTR line high, used sometimes to hang up modems
                //com.DTREnable = true;
                com.RtsEnable = true;
                //com.RTSEnable = true;

                // No handshaking is used
                //com.Handshaking = MSCommLib.HandshakeConstants.comNone;
                com.Handshake = System.IO.Ports.Handshake.None;

                // Use this line instead for byte array input, best for most communications
                //com.InputMode = MSCommLib.InputModeConstants.comInputModeText;
                //com.inp

                // Read the entire waiting data when com.Input is used
                //com.InputLen = 0;


                // Don't discard nulls, 0x00 is a useful byte
                com.DiscardNull = false;

                // Attach the event handler
                // com.OnComm += new System.EventHandler(this.com_OnComm);

                //com.PortOpen = true;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        // If you receive binary data as response.
        private void ProcessResponseText(string input)
        {
            // Send incoming data to a Rich Text Box

            try
            {
            }
            catch
            {
            }
        }

        //System.IO.TextWriter tw = new System.IO.StreamWriter("Hasan.txt");

        private void com_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string msg = com.ReadExisting();
            try
            {
                //if (Globals.JRegistry.Read("BascolType").ToString() == "جدید")
                if (_Type == 0)
                {
                    if (msg.IndexOf("kg") == 0)
                    {
                        lblWeight.Text = s1.Trim();
                    }
                    else
                    {
                        s1 = msg;
                        if (!msg.Contains("kg"))
                        {
                            string str = msg.Substring(0, msg.Length - 2);
                            lblWeight.Text = Convert.ToInt64(str.Trim()).ToString();
                        }
                    }
                }
                else
                {
                    if (msg.IndexOf("kg") == 0)
                        lblWeight.Text = s1.Trim();
                    else s1 = msg;
                }
            }
            catch
            {
            }
        }

        private void JWeightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the stream
            //tw.Close();
            com.Close();
        }

        private void btnSabt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                txtHamrah.Focus();
        }

        private void txtHamrah_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) && (txtHamrah.Text == ""))
                cmbProduct.Focus();
            else if (e.KeyCode == Keys.Enter)
                groupBox2.Focus();//btnSabt.Focus();
        }

        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    txtHamrah.Focus();
            if (e.KeyCode == Keys.Enter)
                return;
            if (e.KeyCode == Keys.Back)
                cmbTruck.Focus();
            else if (!((e.KeyValue >= 65) && (e.KeyValue <= 91)))
            {
                //cmbProduct.Text = "";
                //cmbProduct.SelectedIndex = 0;
                //flag1 = true;
            }
            
        }

        private void txtPlak3_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9)) || ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9)))
            {
                if (txtPlak3.Text.Length >= 1)
                {
                    cmbTruck.Focus();
                    cmbTruck.Select();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (txtPlak3.Text.Length <= 1)
                {
                    txtPlak2.Focus();
                    txtPlak2.Select();
                    txtPlak1.SelectionStart = 3;
                }
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPlak2_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9)) || ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9)))
            {
                if (txtPlak2.Text.Length >= 2)
                {
                    txtPlak3.Focus();
                    txtPlak3.Select();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (txtPlak2.Text.Length <= 1)
                {
                    cmbPlak.Focus();
                    cmbPlak.Select();
                }
            }
            else
            {
                e.Handled = true;

                e.SuppressKeyPress = true;
            }
        }

        private void txtPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPrint2.Focus();
        }

        private void JWeightForm_Shown(object sender, EventArgs e)
        {
            txtPlak1.Focus();
        }
        private void cmbPlak_TextChanged(object sender, EventArgs e)
        {
            if (cmbPlak.Text == "ا")
            {
                cmbPlak.SelectedIndex = 0;
                txtPlak2.Focus();
            }
            if (cmbPlak.Text.Length >= 1)
                txtPlak2.Focus();            
        }

        private void cmbPlak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPlak2.Focus();
            else if (e.KeyCode == Keys.Back)
                txtPlak1.Focus();
            else if (!((e.KeyValue >= 65) && (e.KeyValue <= 91)))
            {
                //string t = cmbPlak.SelectedText;
                //cmbPlak.Text = "";
                //cmbPlak.SelectedIndex = cmbPlak.SelectedIndex;
                //cmbPlak.Text = t;
            }
            //else
            //    cmbPlak.Text = e.KeyCode.ToString();

            //else if ((e.KeyValue >= 96) && (e.KeyValue <= 105))
            //{
            //    cmbPlak.Text = "";
            //    cmbPlak.SelectedIndex = e.KeyValue - 96;
            //}
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;
            else if (e.KeyCode == Keys.Back)
                txtPlak1.Focus();
            else if (!((e.KeyValue >= 65) && (e.KeyValue <= 91)))
            {
                //string t = cmbPlak.SelectedText;
                //cmbPlak.Text = "";
                //cmbPlak.SelectedIndex = cmbPlak.SelectedIndex;
                //cmbPlak.Text = t;
                //flag = true;
            }
        }

        private void cmbPlak_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlak2.Focus();
        }

        private void txtPlak1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9)) || ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9)))
            {
                if (txtPlak1.Text.Length >= 1)
                {
                    cmbPlak.Focus();
                    cmbPlak.Select();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lsTrucks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPlak3.Focus();
                txtPlak3.Select();
            }
        }

        private void cmbTruck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTruck.SelectedItem != null)
            {
                _Price = Convert.ToInt32(((System.Data.DataRowView)(cmbTruck.SelectedItem)).Row["Price"].ToString());
                txtPay.Text = (Convert.ToInt32(_Price) + Convert.ToInt32(lblBedehkari.Text)).ToString();
            }
        }

        private void cmbTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;
            if (e.KeyCode == Keys.Back)
                txtPlak3.Focus();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            JReportUserForm p = new JReportUserForm();
            p.ShowDialog();
        }

        private void cmbTruck_Leave(object sender, EventArgs e)
        {
            _Price = Convert.ToInt32(((System.Data.DataRowView)(cmbTruck.SelectedItem)).Row["Price"].ToString());
            txtPay.Text = (Convert.ToInt32(_Price) + Convert.ToInt32(lblBedehkari.Text)).ToString();
        }

        private void btnBlackList_Click(object sender, EventArgs e)
        {
            BlackListForm p = new BlackListForm();
            p.ShowDialog();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            if (!((txtPlak1.Text != "") && (cmbPlak.Text != "") && (txtPlak2.Text != "") && (txtPlak3.Text != "")
    && (txtPlak1.Text.Length == 2) && (txtPlak2.Text.Length == 3) && (txtPlak3.Text.Length == 2)))
            {
                JMessages.Error(" شماره پلاک را وارد کنید ", "");
                txtPlak1.Focus();
                return;
            }

            JReportUserForm pUser = new JReportUserForm(txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text,true);
            pUser.ShowDialog();
        }
    }
}