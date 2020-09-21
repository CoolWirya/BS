using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Bascol
{
    public partial class JReportUserForm : JBaseForm
    {
        public int _Code;
        public string _PlakNo;

        public int _BascolCode;
        public int _Weight;
        public DateTime _Date;

        public JReportUserForm()
        {
            InitializeComponent();
        }

        public JReportUserForm(string pPlakNo)
        {
            InitializeComponent();
            _PlakNo = pPlakNo;
        }

        public JReportUserForm(string pPlakNo, bool Bedehi)
        {
            InitializeComponent();
            _PlakNo = pPlakNo;
            chkBedehi.Checked = Bedehi;
        }

        public JReportUserForm(bool Almosana)
        {
            InitializeComponent();
            if (Almosana)
            {
                btnPrint.Visible = false;
                chkBedehi.Visible = false;
                chkAllUser.Checked = true;
                btnPrint2.Visible = true;
                chkAllUser.Enabled = false;
            }
        }

        private void FillList()
        {
            DataTable tmpdt = JTruck.GetDataTable(0);
            JKeyValue[] M = new JKeyValue[tmpdt.Rows.Count];
            int count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                M[count] = new JKeyValue();
                M[count].Key = dr["Name"].ToString();
                M[count].Value = dr["Code"];
                count++;
            }
            chklistTrucks.Items.AddRange(M);

            tmpdt = JReport.GetBascols(0);
            JKeyValue[] B = new JKeyValue[tmpdt.Rows.Count];
            count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                B[count] = new JKeyValue();
                B[count].Key = dr["Code"].ToString();
                B[count].Value = dr["Code"];
                count++;
            }
            chkListBascol.Items.AddRange(B);

            tmpdt = JProductss.GetDataTable();
            JKeyValue[] T = new JKeyValue[tmpdt.Rows.Count];
            count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                T[count] = new JKeyValue();
                T[count].Key = dr["Name"].ToString();
                T[count].Value = dr["Code"];
                count++;
            }
            chklistTozin.Items.AddRange(T);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable DtBase = new DataTable();
            DataTable _DT = new DataTable();
            try
            {
                DtBase.Columns.Add("StartDate");
                DtBase.Columns.Add("EndDate");
                DtBase.Rows.Add(txtDate.Text, txtEndDate.Text);
                DtBase.TableName = "اطلاعات پایه";

                _DT.TableName = "اطلاعات";
                _DT = JReport.GetDataMali(Str + " And UserPostCode=" + JMainFrame.CurrentPostCode);
                //JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Bascool.GetHashCode());
                JDynamicReports DRF = new JDynamicReports(JReportDesignCodes.BillGoods.GetHashCode());
                DRF.Add(_DT);
                DRF.Add(DtBase);
                //DRF.ShowDialog();
                DRF.Print("توزین کاربر", true, false);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DtBase.Dispose();
                _DT.Dispose();
            }
        }

        string Str = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtPrice.Text = "";
            if (chkBedehi.Checked)
            {
                jJanusGridBedehi.Visible = true;
                jJanusGrid1.Visible = false;
            }
            else
            {
                jJanusGridBedehi.Visible = false;
                jJanusGrid1.Visible = true;
            }
            Str = "";
            if (!(chkAllUser.Checked))
                if (((_PlakNo == null)) || (_PlakNo == ""))
                    if (!(chkBedehi.Checked))
                        Str = Str + " And UserPostCode=" + JMainFrame.CurrentPostCode;
            if (chkListBascol.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chkListBascol.Items.Count; i++)
                    if (chkListBascol.GetItemChecked(i))
                        CodeGH = CodeGH + "" + ((ClassLibrary.JKeyValue)(chkListBascol.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And BascoolCode in (" + CodeGH + "0)";
            }

            if (chklistTozin.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistTozin.Items.Count; i++)
                    if (chklistTozin.GetItemChecked(i))
                        CodeGH = CodeGH + "" + ((ClassLibrary.JKeyValue)(chklistTozin.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And ProductCode in (" + CodeGH + "0)";
            }

            if (chklistTrucks.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistTrucks.Items.Count; i++)
                    if (chklistTrucks.GetItemChecked(i))
                        CodeGH = CodeGH + "" + ((ClassLibrary.JKeyValue)(chklistTrucks.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And TruckCode in (" + CodeGH + "0)";
            }

            if (txtDate.Date != DateTime.MinValue)
                Str = Str + " And Cast(WDate as Date) >= '" + txtDate.Date.ToString("yyyy/MM/dd") + "'";

            if (txtEndDate.Date != DateTime.MinValue)
                Str = Str + " And Cast(WDate as Date) <= '" + txtEndDate.Date.ToString("yyyy/MM/dd") + "'";
            if (txtplok2.Text != "      -")
            {
                if (txtplok2.Text.Contains("ا"))
                    Str = Str + " And PlokNo=N'" + txtplok2.Text.Replace("ا", "الف") + "'";
                else
                    Str = Str + " And PlokNo=N'" + txtplok2.Text + "'";
            }

            if (chkBedehi.Checked)
            {
                lblBedehkari.Text = "0";
                lblBestankari.Text = "0";
                DataTable tmpdt = JReport.GetDataBedehkari(Str);
                jJanusGridBedehi.bind(tmpdt, "ReportBedehi");
                foreach (DataRow dr in tmpdt.Rows)
                {
                    lblBedehkari.Text = (Convert.ToDecimal(lblBedehkari.Text) + Convert.ToDecimal(dr["debit"])).ToString();
                    lblBestankari.Text = (Convert.ToDecimal(lblBestankari.Text) + Convert.ToDecimal(dr["crdit"])).ToString();
                }
            }
            else if (groupBox1.Enabled == true)
            {
                DataTable dtManager = JReport.GetDataManager(Str);
                jJanusGrid1.bind(dtManager, "ReportManagerBascolShow");
                lblCount.Text = "0";
                lblTotal.Text = "0";
                foreach (DataRow dr in dtManager.Rows)
                {
                    lblCount.Text = (Convert.ToDecimal(lblCount.Text) + 1).ToString();
                    lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(dr["Pay"])).ToString();
                }
            }
            if (groupBox1.Enabled == false)
            {
                jJanusGrid1.bind(JReport.GetDataTop3(Str), "ReportManagerBascolShow");
                jJanusGrid1.Columns["BascoolCode"].Visible = false;
                jJanusGrid1.Columns["Code"].Visible = false;
            }
            else if (!(chkBedehi.Checked))
            {
                jJanusGrid1.Columns["PrintNo"].Visible = false;
                //jJanusGrid1.Columns["hamrahno"].Visible = false;
                jJanusGrid1.Columns["dele"].Visible = false;
                jJanusGrid1.Columns["verify"].Visible = false;
                jJanusGrid1.Columns["pay"].Visible = false;
                //jJanusGrid1.Columns["pay_h"].Visible = false;
                jJanusGrid1.Columns["Duty"].Visible = false;
                jJanusGrid1.Columns["Tax"].Visible = false;
                jJanusGrid1.Columns["FirstWeight"].Visible = false;
                jJanusGrid1.Columns["Khales"].Visible = false;
                jJanusGrid1.Columns["PersonName"].Visible = false;
                //jJanusGrid1.Columns["PostName"].Visible = false;
                jJanusGrid1.Columns["UserPostCode"].Visible = false;
            }
        }
        //dele,verify,pay,Duty,Tax,
        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.DataSource == null)
            {
                JMessages.Error(" ابتدا دکمه جستجو را بزنید ", "");
                return;
            }
            if (jJanusGrid1.SelectedRow == null)
            {
                JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
                return;
            }
            _Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"].ToString());
            DataTable dt = JWeights.GetDataTableAll(_Code, true);
            string State = "این برگه المثنی" + " قبض شماره " + dt.Rows[0]["BascoolID"].ToString() + " مورخ " + dt.Rows[0]["WDate"].ToString() + "ساعت" + dt.Rows[0]["WTime"].ToString().Trim() + "می باشد";

            JWeight tmpWeight = new JWeight();
            tmpWeight.TruckCode = Convert.ToInt32(dt.Rows[0]["TruckCode"].ToString());
            tmpWeight.UserPostCode = JMainFrame.CurrentPostCode;
            tmpWeight.PersonCode = JMainFrame.CurrentPersonCode;
            tmpWeight.pay = Convert.ToInt32(dt.Rows[0]["pay"].ToString());
            tmpWeight.pay_h = Convert.ToInt32(dt.Rows[0]["pay"].ToString());
            tmpWeight.BascoolCode = Convert.ToInt32(dt.Rows[0]["BascoolCode"].ToString());
            tmpWeight.PlokNo = dt.Rows[0]["P1"].ToString() + dt.Rows[0]["P2"].ToString() + dt.Rows[0]["P3"].ToString() + dt.Rows[0]["P4"].ToString();
            tmpWeight.Weights = Convert.ToInt32(dt.Rows[0]["Weights"].ToString());
            //tmpWeight.Duty = Convert.ToDecimal(dt.Rows[0]["Duty"].ToString());
            //tmpWeight.Tax = Convert.ToDecimal(dt.Rows[0]["Tax"].ToString());
            JTransferData tmpT = new JTransferData();
            tmpT.GetTaxDuty();
            tmpWeight.Duty = (tmpWeight.pay / (100 + tmpT._Duty + tmpT._Tax)) * tmpT._Duty;
            tmpWeight.Tax = (tmpWeight.pay / (100 + tmpT._Duty + tmpT._Tax)) * tmpT._Tax;

            tmpWeight.hamrahno = Convert.ToInt32(dt.Rows[0]["hamrahno"].ToString());
            tmpWeight.ProductCode = Convert.ToInt32(dt.Rows[0]["ProductCode"].ToString());
            tmpWeight.PrintNo = 2;
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
            tmpWeight.WTime = Hour + ":" + Min;

            tmpWeight.BascoolID = JWeights.GetCounter();
            tmpWeight.WDate = DateTime.Now;

            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);

            if (tmpWeight.Insert() > 0)//dbMain
                dt = JWeights.GetDataTableAll(tmpWeight.Code, false);
            dt.Columns.Add("State");
            dt.Columns.Add("StateHamrah");
            dt.Rows[0]["State"] = State;
            if (Convert.ToInt32(dt.Rows[0]["HamrahNO"]) != 0)
                dt.Rows[0]["StateHamrah"] = dt.Rows[0]["HamrahNO"] + "    تعداد همراه  ";
            else
                dt.Rows[0]["StateHamrah"] = "";
            if (dt != null)
            {
                //JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Bascool.GetHashCode());
                JDynamicReports DRF = new JDynamicReports(JReportDesignCodes.BillGoods.GetHashCode());
                DRF.Add(dt);
                //DRF.ShowDialog();
                DRF.Print("چاپ قبض", false, false);
            }

            try
            {
                dbMain.setQuery("Update BascolWeights set PrintNo=PrintNo+1 Where Code=" + _Code);
                dbMain.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        private void JReportUserForm_Load(object sender, EventArgs e)
        {
            if (_PlakNo == null)
            {
                txtDate.Date = DateTime.Now;
                txtEndDate.Date = DateTime.Now;
            }
            FillList();
            if (_PlakNo != null)
            {
                //rbBedehi.Checked = true;
                txtplok2.Text = _PlakNo;
                groupBox1.Enabled = false;
                btnPrint2.Enabled = true;
                btnSearch_Click(null, null);
                if ((jJanusGrid1.DataSource == null) || (jJanusGrid1.DataSource.Rows.Count == 0))
                    this.Close();
            }
        }

        private void jJanusGrid1_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView SelectedRow = ((DataRowView)jJanusGrid1.SelectedRow);
            _Code = Convert.ToInt32(SelectedRow.Row["Code"]);
        }

        private void jJanusGrid1_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (groupBox1.Enabled == false)
            {
                DataRowView SelectedRow = ((DataRowView)jJanusGrid1.SelectedRow);
                
                _BascolCode = Convert.ToInt32(SelectedRow.Row["BascoolCode"]);
                _Weight = Convert.ToInt32(SelectedRow.Row["Weights"]);
                _Date = JDateTime.GregorianDate(SelectedRow.Row["WDate"].ToString());                
                this.DialogResult = DialogResult.OK;
                Close();
            }
            _Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"]);
            txtPrice.Text = jJanusGrid1.SelectedRow.Row["pay_h"].ToString();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                txtDate.Date = DateTime.MinValue;
                txtEndDate.Date = DateTime.MinValue;
            }
            else
            {
                txtDate.Date = DateTime.Now;
                txtEndDate.Date = DateTime.Now;
            }
        }

        private void chkBedehi_CheckedChanged(object sender, EventArgs e)
        {
            lblBedehkari.Text = "0";
            lblBestankari.Text = "0";
            if (chkBedehi.Checked)
            {
                lblCount.Visible = false;
                lblCount1.Visible = false;
                lblTotal.Visible = false;
                lblTotal1.Visible = false;
                lblBedehkari.Visible = true;
                lblBestankari.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                chkDate.Checked = true;
            }
            else
            {
                lblCount.Visible = true;
                lblCount1.Visible = true;
                lblTotal.Visible = true;
                lblTotal1.Visible = true;
                lblBedehkari.Visible = false;
                lblBestankari.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                chkDate.Checked = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (JMessages.Question(" آیا از ویرایش مبلغ پرداختی توزین مطمئن هستید ؟ ", "") != DialogResult.Yes)
                return;
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            try
            {
                dbMain.setQuery(" Update BascolWeights set Pay_h= " + txtPrice.IntValue + " Where Code=" + _Code + " And UserPostCode=" + JMainFrame.CurrentPostCode);
                if (dbMain.Query_Execute() > 0)
                    JMessages.Information(" تایید شد ", "");
                else
                    JMessages.Error(" خطا در ثبت ", "");
            }
            finally
            {
                dbMain.Dispose();
            }
        }
    }
}
