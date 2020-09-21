using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JWorkingForm : JBaseForm
    {
        int _EmpCode;
        int _PersonCart;
        DataTable _dtAll;
        int i = 0;

        public JWorkingForm()
        {
            InitializeComponent();
        }

        public JWorkingForm(int pEmpCode)
        {
            InitializeComponent();
            _EmpCode = pEmpCode;
            _dtAll = JEmployeeInfos.GetDataTable(0, "");
            DataRow[] dr = _dtAll.Select(" Code=" + _EmpCode);
            i=_dtAll.Rows.IndexOf(dr[0]);
        }

        private void Bind()
        {
            try
            {
                jdgvList.DataSource = null;
                jdgvList.Refresh();

                System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
                JConnection conn = new JConnection();
                SqlBuilder = conn.GetSQlServerConnection("PWKara", 0);
                JDataBase MyDB = new JDataBase(SqlBuilder);

                string Where = "";
                if (txtStartDate.Date != DateTime.MinValue)
                    Where = Where + " And dbo.Miladi2Shamsi(dbo.PwKara2Miladi(date_),2) >='" + JDateTime.FarsiDate(txtStartDate.Date) + "'";
                if (txtEndDate.Date != DateTime.MinValue)
                    Where = Where + " And dbo.Miladi2Shamsi(dbo.PwKara2Miladi(date_),2) <='" + JDateTime.FarsiDate(txtEndDate.Date) + "'";

                MyDB.setQuery(@" select 
  (select TITLE from CARDS where CARD_NO=STATUS) TitleSTATUS, 
case datepart(dw,dbo.PwKara2Miladi(date_)) 
when 6 then 'جمعه'
when 5 then 'پنجشنبه'
when 4 then 'چهار شنبه'
when 3 then 'سه شنبه'
when 2 then 'دوشنبه'
when 1 then 'یکشنبه'
when 7 then 'شنبه'
end WeekDays,
dbo.Miladi2Shamsi(dbo.PwKara2Miladi(date_),2) DateFarsi,
case len(cast(Time_ as CHAR))  
When 3 then substring(('0'+cast(Time_ as CHAR)),0,3)+':'+substring(('0'+cast(Time_ as CHAR)),3,5)
else substring((cast(Time_ as CHAR)),0,3)+':'+substring((cast(Time_ as CHAR)),3,5)
 end Time,STATUS,DATE_,TIME_,EMP_NO,MODIFY
from DataFile 
where EMP_NO=" + _PersonCart + Where + @"
order by DATE_,TIME_ ");

                DataTable DtMain = MyDB.Query_DataTable();
                DtMain.Columns.Add("Time0");
                DtMain.Columns.Add("Time1");
                DtMain.Columns.Add("Time2");
                DtMain.Columns.Add("Time3");
                DtMain.Columns.Add("Time4");
                DtMain.Columns.Add("Time5");
                DtMain.Columns.Add("Time6");
                DtMain.Columns.Add("Time7");
                DtMain.Columns.Add("Time8");
                DtMain.Columns.Add("Time9");
                DataTable SubMain = DtMain.Clone();
                int RowCurrent = 0;
                DateTime tmpDate = DateTime.MinValue;

                if (DtMain.Rows.Count == 0)
                {
                    JMessages.Information(" اطلاعاتی موجود نمی باشد ", "");
                    return;
                }
                if (DtMain.Rows[0]["DateFarsi"].ToString() != txtStartDate.Text)
                {
                    tmpDate = txtStartDate.Date;
                    int Count = -1;
                    for (int i = 0; i != Count; i++)
                    {
                        if (JDateTime.GregorianDate(DtMain.Rows[0]["DateFarsi"].ToString()) == tmpDate.Date.AddDays(1))
                            i = -2;
                        else
                        {
                            DataRow Newdr = SubMain.NewRow();
                            Newdr["TitleSTATUS"] = "";
                            Newdr["WeekDays"] = JDateTime.FarsiDay(tmpDate.Date.AddDays(1));
                            Newdr["DateFarsi"] = JDateTime.FarsiDate(tmpDate.Date.AddDays(1));
                            Newdr["Time"] = "";
                            Newdr["STATUS"] = 0;
                            Newdr["DATE_"] = 0;
                            Newdr["TIME_"] = 0;
                            Newdr["EMP_NO"] = DtMain.Rows[0]["EMP_NO"];
                            Newdr["MODIFY"] = 0;
                            SubMain.Rows.Add(Newdr);
                            tmpDate = tmpDate.Date.AddDays(1);
                            RowCurrent++;
                        }
                    }
                }

                tmpDate = DateTime.MinValue;

                foreach (DataRow dr in DtMain.Rows)
                {
                    if ((tmpDate.Date != DateTime.MinValue)
                        && (tmpDate.Date != JDateTime.GregorianDate(dr["DateFarsi"].ToString()))
                        && (tmpDate.Date.AddDays(1) != JDateTime.GregorianDate(dr["DateFarsi"].ToString())))
                    {
                        int Count = -1;
                        for (int i = 0; i != Count; i++)
                        {
                            if (JDateTime.GregorianDate(dr["DateFarsi"].ToString()) == tmpDate.Date.AddDays(1))
                                i = -2;
                            else
                            {
                                DataRow Newdr = SubMain.NewRow();
                                Newdr["TitleSTATUS"] = "";
                                Newdr["WeekDays"] = JDateTime.FarsiDay(tmpDate.Date.AddDays(1));
                                Newdr["DateFarsi"] = JDateTime.FarsiDate(tmpDate.Date.AddDays(1));
                                Newdr["Time"] = "";
                                Newdr["STATUS"] = 0;
                                Newdr["DATE_"] = 0;
                                Newdr["TIME_"] = 0;
                                Newdr["EMP_NO"] = dr["EMP_NO"];
                                Newdr["MODIFY"] = 0;
                                SubMain.Rows.Add(Newdr);
                                tmpDate = tmpDate.Date.AddDays(1);
                                RowCurrent++;
                            }
                        }
                    }

                    if (SubMain.Select(" Date_=" + dr["Date_"]).Length > 0)
                    {
                        if (SubMain.Rows[RowCurrent - 1]["Time0"].ToString() == "")
                        {
                            SubMain.Rows[RowCurrent - 1]["Time0"] = dr["Time"];
                            if (dr["TitleSTATUS"].ToString() != "")
                                SubMain.Rows[RowCurrent - 1]["TitleSTATUS"] = SubMain.Rows[RowCurrent - 1]["TitleSTATUS"].ToString() + "," + dr["TitleSTATUS"].ToString();
                        }
                        else if (SubMain.Rows[RowCurrent - 1]["Time1"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time1"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time2"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time2"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time3"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time3"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time4"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time4"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time5"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time5"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time6"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time6"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time7"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time7"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time8"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time8"] = dr["Time"];
                        else if (SubMain.Rows[RowCurrent - 1]["Time9"].ToString() == "")
                            SubMain.Rows[RowCurrent - 1]["Time9"] = dr["Time"];
                    }
                    else
                    {
                        DataRow Newdr = SubMain.NewRow();
                        Newdr["TitleSTATUS"] = dr["TitleSTATUS"];
                        Newdr["WeekDays"] = dr["WeekDays"];
                        Newdr["DateFarsi"] = dr["DateFarsi"];
                        Newdr["Time"] = dr["Time"];
                        Newdr["STATUS"] = dr["STATUS"];
                        Newdr["DATE_"] = dr["DATE_"];
                        Newdr["TIME_"] = dr["TIME_"];
                        Newdr["EMP_NO"] = dr["EMP_NO"];
                        Newdr["MODIFY"] = dr["MODIFY"];
                        SubMain.Rows.Add(Newdr);
                        RowCurrent++;
                    }
                    tmpDate = JDateTime.GregorianDate(dr["DateFarsi"].ToString());
                }

                if (DtMain.Rows[DtMain.Rows.Count-1]["DateFarsi"].ToString() != txtEndDate.Text)
                {
                    tmpDate = JDateTime.GregorianDate(DtMain.Rows[DtMain.Rows.Count-1]["DateFarsi"].ToString());
                    int Count = -1;
                    for (int i = 0; i != Count; i++)
                    {
                        if (txtEndDate.Date == tmpDate.Date)
                            i = -2;
                        else
                        {
                            DataRow Newdr = SubMain.NewRow();
                            Newdr["TitleSTATUS"] = "";
                            Newdr["WeekDays"] = JDateTime.FarsiDay(tmpDate.Date.AddDays(1));
                            Newdr["DateFarsi"] = JDateTime.FarsiDate(tmpDate.Date.AddDays(1));
                            Newdr["Time"] = "";
                            Newdr["STATUS"] = 0;
                            Newdr["DATE_"] = 0;
                            Newdr["TIME_"] = 0;
                            Newdr["EMP_NO"] = DtMain.Rows[0]["EMP_NO"];
                            Newdr["MODIFY"] = 0;
                            SubMain.Rows.Add(Newdr);
                            tmpDate = tmpDate.Date.AddDays(1);
                            RowCurrent++;
                        }
                    }
                }

                jdgvList.DataSource = SubMain;

                jdgvList.Columns["DATE_"].Visible = false;
                jdgvList.Columns["TIME_"].Visible = false;
                jdgvList.Columns["EMP_NO"].Visible = false;
                jdgvList.Columns["STATUS"].Visible = false;
                jdgvList.Columns["MODIFY"].Visible = false;
                jdgvList.Columns["TitleSTATUS"].ReadOnly = true;
                jdgvList.Columns["WeekDays"].ReadOnly = true;
                jdgvList.Columns["DateFarsi"].ReadOnly = true;

                CheckList();
                CheckListColor(DtMain);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void CheckListColor(DataTable DtPWKara)
        {
            JDataBase db = new JDataBase();
            try
            {
                //DataGridViewCellStyle MakeItRed = new DataGridViewCellStyle();
                //MakeItRed.BackColor = Color.Red;
                //And Date_= " + row.Cells["Date_"].Value.ToString() + " And Time_=" + row.Cells["Time_"].Value.ToString()))
                foreach (DataRow rowKara in DtPWKara.Select(" 1=1 ").CopyToDataTable().Rows)
                    foreach (System.Windows.Forms.DataGridViewRow row in jdgvList.Rows)
                        if ((row.Cells["Date_"].Value.ToString() == rowKara["Date_"].ToString()))
                            foreach (System.Windows.Forms.DataGridViewColumn Col in jdgvList.Columns)
                                if (row.Cells[Col.Name].Value.ToString().Trim() == rowKara["Time"].ToString().Trim() && (rowKara["Status"].ToString() != "0"))
                                {
                                    DataGridViewCellStyle MakeItRed = new DataGridViewCellStyle();
                                    if (rowKara["Status"].ToString() == "17")

                                        MakeItRed.BackColor = Color.Green;

                                    else if (rowKara["Status"].ToString() == "2")
                                        MakeItRed.BackColor = Color.Yellow;
                                    else if (rowKara["Status"].ToString() == "5")
                                        MakeItRed.BackColor = Color.Violet;
                                    else if (rowKara["Status"].ToString() == "9")
                                        MakeItRed.BackColor = Color.Silver;
                                    row.Cells[Col.Name].Style = MakeItRed;
                                }
                                else if (row.Cells[Col.Name].Value.ToString().Trim() == rowKara["Time"].ToString().Trim() && (rowKara["Status"].ToString() == "0") && (rowKara["Modify"].ToString() == "True"))
                                {
                                    DataGridViewCellStyle MakeItRed = new DataGridViewCellStyle();
                                    MakeItRed.BackColor = Color.Brown;
                                    row.Cells[Col.Name].Style = MakeItRed;
                                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        private void CheckList()
        {
            JDataBase db = new JDataBase();
            try
            {
                DataTable DtWorkingForm = JWorking.GetDataTableEMPForm();

                DataGridViewCellStyle MakeItRed = new DataGridViewCellStyle();
                MakeItRed.BackColor = Color.Red;

                foreach (System.Windows.Forms.DataGridViewRow row in jdgvList.Rows)
                    foreach (DataRow _node in DtWorkingForm.Rows)
                    {
                        if (_node["SQl"].ToString() != "")
                        {
                            db.setQuery(_node["SQl"].ToString().Replace("@Date", JDateTime.GregorianDate(row.Cells["DateFarsi"].Value.ToString()).ToShortDateString()).Replace("@EmpCode", _EmpCode.ToString()).ToString());
                            if (db.Query_DataTable().Rows.Count > 0)
                                row.Cells[2].Style = MakeItRed;
                        }
                    }
            }

            //foreach (DataRow dr in ((DataTable)(jdgvList.DataSource)).Rows)
            //{
            //    foreach (DataRow _node in DtWorkingForm.Rows)
            //    {
            //        db.setQuery(_node["SQl"].ToString().Replace("@Date", JDateTime.GregorianDate(dr[""].ToString()).ToShortDateString()).Replace("@EmpCode", _EmpCode.ToString()).ToString(););
            //        if(db.Query_DataTable().Rows.Count > 0)
            //            jdgvList.Rows[0].DefaultCellStyle.BackColor =  

            //    }
            //}

            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool CheckPermission()
        {
            if (!(JPermission.CheckPermission("Employment.JWorkingForm.CheckPermission", false)))
                return false;
            return true;
        }

        private void JWorkingForm_Load(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                DataTable dt = JEmployeeInfos.GetDataTable(0, " And Code=" + _EmpCode);
                groupBox1.Text = dt.Rows[0]["Full_Title"].ToString();
                _PersonCart = Convert.ToInt32(dt.Rows[0]["PersonCart"].ToString());
                //Bind();
                if (!(CheckPermission()))
                {
                    jdgvList.ReadOnly = true;
                    btnBefore.Visible = false;
                    btnNext.Visible = false;
                    btnSearchPersonnel.Visible = false;
                }
                if (Globals.JRegistry.Read("StartDate") != null)
                    txtStartDate.Date = Convert.ToDateTime(Globals.JRegistry.Read("StartDate"));
                if (Globals.JRegistry.Read("EndDate") != null)
                    txtEndDate.Date = Convert.ToDateTime(Globals.JRegistry.Read("EndDate"));

                db.setQuery("SELECT * From [subdefine] WHERE Code=-1 or [bcode]=214 ORDER BY [name]");
                DataTable tmp = db.Query_DataTable();

                cmbFeild.DataSource = db.Query_DataTable();
                cmbFeild.DisplayMember = "name";
                cmbFeild.ValueMember = "TempCode";
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Globals.JRegistry.Write("StartDate", txtStartDate.Date.ToString());
            Globals.JRegistry.Write("EndDate", txtEndDate.Date.ToString());
            Bind();
        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run();
        }

        private void ShowSubMenu(string pDate, int pEmpCode, string pTime)
        {
            contextMenuStripContract.Items.Clear();
            EventHandler ClickEvent = new EventHandler(run);
            string Str = "";

            ToolStripItem TSI = contextMenuStripContract.Items.Add(" ثبت فرم ", null, ClickEvent);
            TSI.Tag = new JAction("RegisterForm...", "Employment.JWorking.ShowDialogFormObjects", new object[] { _EmpCode }, null);

            if (CheckPermission())
                foreach (DataRow _node in JWorking.GetDataTableEMPForm().Rows)
                {
                    TSI = contextMenuStripContract.Items.Add(_node["FormName"].ToString(), null, ClickEvent);
                    Str = _node["SQl"].ToString().Replace("@Date", JDateTime.GregorianDate(pDate).ToShortDateString()).Replace("@EmpCode", _EmpCode.ToString()).ToString();
                    TSI.Tag =
                        new JAction("Vacations...", "Employment.JWorking.ListForm", new object[] { Str, Convert.ToInt32(_node["CodeForm"].ToString()), _PersonCart, pTime, pDate }, null);
                }
            contextMenuStripContract.Show(MousePosition);
        }

        //ClassLibrary.TimeEdit maskedTextBox;

        private void jdgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.maskedTextBox.Visible)
            {
                //this.jdgvList.CurrentCell.Value = this.maskedTextBox.Text;
                this.maskedTextBox.Visible = false;
            }

            if (!(CheckPermission()))
                return;
            if ((jdgvList[e.ColumnIndex, e.RowIndex] == null) && (e.ColumnIndex == 0))
                return;

            if (JMessages.Question(" آیا از ثبت اطلاعات مطمئن هستید ", "") == DialogResult.No)
            {
                return;
            }
            System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
            JConnection conn = new JConnection();
            SqlBuilder = conn.GetSQlServerConnection("PWKara", 0);
            JDataBase MyDB = new JDataBase(SqlBuilder);

            try
            {
                string Date_ = JDateTime.GregorianDate(jdgvList.SelectedRows[0].Cells["DateFarsi"].Value.ToString()).ToShortDateString();
                string Time_ = jdgvList.SelectedRows[0].Cells[e.ColumnIndex].Value.ToString().Trim();
                if (Time_.Trim().Length > 0)
                    if ((Time_.Length != 5) || (Convert.ToInt32(Time_.Substring(0, 2)) < 0) || (Convert.ToInt32(Time_.Substring(0, 2)) > 24) || (Convert.ToInt32(Time_.Substring(3, 2)) > 60))
                    {
                        JMessages.Error(" ساعت را درست وارد کنید ", "");
                        return;
                    }
                Time_ = Time_.Replace(":", "");
                if ((Time_ != "") && (Time_[0].ToString() == "0")) Time_ = Time_.Remove(0, 1);

                _BeforeTime = _BeforeTime.Replace(":", "");
                if ((_BeforeTime != "") && (_BeforeTime[0].ToString() == "0")) _BeforeTime = _BeforeTime.Remove(0, 1);

                MyDB.setQuery(@" Select * From DataFile Where Status=0 And Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_='" + Time_ + "' And EMP_NO=" + _PersonCart);
                if (MyDB.Query_DataTable().Rows.Count == 0)
                {
                    if (Time_.Trim() == "")
                        MyDB.setQuery(@" Delete From DataFile Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + _BeforeTime + " And Emp_No=" + _PersonCart);
                    else
                        MyDB.setQuery(@" insert into DataFile values(0, dbo.Miladi2Pwkara(cast('" +
                            Date_ + "' as date)) , " + Time_ + "," +
                              _PersonCart + " ,1 ,0 ,NULL	,NULL	,NULL	,NULL	,NULL)");
                    if (MyDB.Query_Execute() > 0)
                    {
                        JMessages.Information("   ثبت شد", "");
                        //Bind();
                    }
                }
                //else
                //    JMessages.Error("  قبلا ثبت شده", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا در ثبت ", "");
            }
            finally
            {
                MyDB.Dispose();
            }
        }

        private void jdgvList_MouseDown(object sender, MouseEventArgs e)
        {
            return;
            if (e.Button == MouseButtons.Right)
            {
                if (jdgvList.CurrentRow == null)
                    return;
                if (jdgvList.RowCount > 0)
                {
                    string Time_ = jdgvList.CurrentCell.Value.ToString().Trim(); ;
                    if (Time_ != "")
                        if ((Time_.Length != 5) || (Convert.ToInt32(Time_.Substring(0, 2)) < 0) || (Convert.ToInt32(Time_.Substring(0, 2)) > 13) || (Convert.ToInt32(Time_.Substring(3, 2)) > 60))
                        {
                            //JMessages.Error(" لطفا روی ساعت کلیک کنید", "");
                            return;
                        }
                    //else
                    ShowSubMenu(jdgvList.CurrentRow.Cells["DateFarsi"].Value.ToString(), Convert.ToInt32(jdgvList.CurrentRow.Cells["EMP_NO"].Value.ToString()), jdgvList.CurrentRow.Cells["Time_"].Value.ToString());
                }
            }
            else
            {
                DataGridViewCellStyle MakeItRed = new DataGridViewCellStyle();
                MakeItRed.BackColor = Color.White;
                jdgvList.Columns["Time"].DefaultCellStyle.Format = "0:00"; // 192:40

                //jdgvList.Columns["Time"].DefaultCellStyle.Format. = "t";
                //jdgvList.CurrentCell.FormattedValueType.Attributes. = System.Reflection.TypeAttributes.StringFormatMask;
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if ((_dtAll != null) && (i > 1))
            {
                _EmpCode = Convert.ToInt32(_dtAll.Rows[i--]["Code"]);
                JWorkingForm_Load(null, null);
                Bind();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((_dtAll != null) && (_dtAll.Rows.Count > i))
            {
                _EmpCode = Convert.ToInt32(_dtAll.Rows[i++]["Code"]);
                JWorkingForm_Load(null, null);
                Bind();
            }
        }

        private void JWorkingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
                btnSearchPersonnel_Click(null, null);
            if ((e.KeyCode == Keys.F7) && (btnNext.Visible == true))
                btnNext_Click(null, null);
            if ((e.KeyCode == Keys.F8) && (btnBefore.Visible == true))
                btnBefore_Click(null, null);
            if ((e.KeyCode == Keys.F5) && (btnSearch.Visible == true))
                btnSearch_Click(null, null);
        }
        string _BeforeTime;

        private void jdgvList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _BeforeTime = _Time;

            if ((e.ColumnIndex == this.jdgvList.Columns["Time0"].Index ||
                e.ColumnIndex == this.jdgvList.Columns["Time1"].Index ||
                e.ColumnIndex == this.jdgvList.Columns["Time2"].Index ||
                e.ColumnIndex == this.jdgvList.Columns["Time3"].Index ||
                e.ColumnIndex == this.jdgvList.Columns["Time4"].Index ||
                e.ColumnIndex == this.jdgvList.Columns["Time5"].Index
                ))//&& e.RowIndex < this.jdgvList.NewRowIndex
            {

                //string type = this.jdgvList["Type", e.RowIndex].Value.ToString();

                if (true)
                {
                    //ClassLibrary.TimeEdit maskedTextBox = new TimeEdit();

                    //this.maskedTextBox.Mask = "##:##";

                    Rectangle rect =
                       this.jdgvList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    this.maskedTextBox.Location = rect.Location;

                    this.maskedTextBox.Size = rect.Size;

                    this.maskedTextBox.Text = jdgvList.CurrentCell.Value.ToString();

                    if (this.jdgvList[e.ColumnIndex, e.RowIndex].Value != null)
                    {

                        this.maskedTextBox.Text = this.jdgvList[e.ColumnIndex,
                            e.RowIndex].Value.ToString();

                    }

                    this.maskedTextBox.Visible = true;

                }
                // if type is Email, do no show the MaskedTextBox
            }
        }

        private void jdgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.maskedTextBox.Visible)
            {
                //we have to adjust the location for the MaskedTextBox while scrolling

                Rectangle rect = this.jdgvList.GetCellDisplayRectangle(

                    this.jdgvList.CurrentCell.ColumnIndex,

                    this.jdgvList.CurrentCell.RowIndex, true);

                this.maskedTextBox.Location = rect.Location;
            }
        }

        private void jdgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (!(CheckPermission()))
                return;

            if (jdgvList.CurrentRow == null)
                return;

            _Date = jdgvList.CurrentRow.Cells["DateFarsi"].Value.ToString();
            _Emp_Card = Convert.ToInt32(jdgvList.CurrentRow.Cells["EMP_NO"].Value.ToString());
            _Time = jdgvList.CurrentCell.Value.ToString();

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select Code,ObjectCode, (select Fa_Date From StaticDates where En_Date=[تاریخ__درخواست]) 'تاریخ__درخواست',[از__ساعت],[تا__ساعت],[توضیحات],[تایید__مدیر],[تایید__کارگزینی] from [Propperty_ClassName_ClassLibrary.FormManagers_1000001] Where [تاریخ__درخواست]='" + JDateTime.GregorianDate(_Date).ToShortDateString() + "' And ObjectCode in (select Code from FormObjects where FormCode=1000001 And ObjectCode=" + _EmpCode + ") And [تایید__مدیر]= 1");
                dgvHour.DataSource = db.Query_DataTable();
                dgvHour.Columns["Code"].Visible = false;
                dgvHour.Columns["ObjectCode"].Visible = false;
                db.setQuery("select (select Fa_Date From StaticDates where En_Date=[تاریخ__کارکرد]) [تاریخ__کارکرد1],* from [Propperty_ClassName_ClassLibrary.FormManagers_1000003] Where [تاریخ__کارکرد]='" + JDateTime.GregorianDate(_Date).ToShortDateString() + "' And ObjectCode in (select Code from FormObjects where FormCode=1000003 And ObjectCode=" + _EmpCode + ") And [تایید__مدیر__اداری]= 1 And [تایید__مدیر]= 1");
                dgvConfirm.DataSource = db.Query_DataTable();
                dgvConfirm.Columns["Code"].Visible = false;
                dgvConfirm.Columns["ObjectCode"].Visible = false;
                dgvConfirm.Columns["تاریخ__کارکرد"].Visible = false;
                if (((DataTable)(dgvHour.DataSource)).Rows.Count > 0)
                    grHour.Visible = true;
                else
                    grHour.Visible = false;
                if (((DataTable)(dgvConfirm.DataSource)).Rows.Count > 0)
                    grConfirm.Visible = true;
                else
                    grConfirm.Visible = false;

                if ((_Time.Contains(':')))
                {
                    lblConfirm.Text = _Time;
                    lblHour.Text = _Time;
                }

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا در ثبت ", "");
            }
            finally
            {
                db.Dispose();
            }
        }

        int _FormCode;
        string _Time;
        string _Date;
        int _Emp_Card;
        int _FormObjectCode;

        private void Confirm()
        {
            //Automation.JAObject tmpObjects = new Automation.JAObject();
            //tmpObjects.GetData("ClassLibrary.FormManagers", _FormObjectCode, _FormCode);
            Automation.JARefer tmpRefer = new Automation.JARefer();
            if (tmpRefer.FindLastRefer("ClassLibrary.FormManagers", _FormObjectCode, _FormCode, JMainFrame.CurrentPostCode) <= 0)
            {
                JMessages.Error(" در کارتابل شما هنوز نیامده است ", "");
                return;
            }
            JDataBase db = new JDataBase();
            JDataBase db1 = new JDataBase();
            System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
            JConnection conn = new JConnection();
            SqlBuilder = conn.GetSQlServerConnection("PWKara", 0);
            JDataBase MyDB = new JDataBase(SqlBuilder);

            try
            {
                if (_Time == "")
                {
                    JMessages.Error(" ساعت در فرم وجود ندارد به فرم قبلی برگردید و از روی ساعت کلیک کرده و وارد این فرم شوید ", "");
                    return;
                }
                string Date_ = JDateTime.GregorianDate(_Date).ToShortDateString(); ;// Convert.ToDateTime(jdgvList.SelectedRows[0].Cells["تاریخ__درخواست"].Value.ToString()).ToShortDateString();
                string Time_ = _Time;//jdgvList.SelectedRows[0].Cells["تا__ساعت"].Value.ToString();
                Time_ = Time_.Replace(":", "");
                if (Time_[0].ToString() == "0") Time_ = Time_.Remove(0, 1);
                JEmpLog tmpJEmpLog = new JEmpLog();
                tmpJEmpLog.FormCode = _FormCode;
                tmpJEmpLog.FormObjectCode = _FormObjectCode;//Convert.ToInt32(jdgvList.SelectedRows[0].Cells["Code"].Value.ToString());
                db.beginTransaction("Vacation");
                if (tmpJEmpLog.insert(db) > 0)
                {
                    // مرخصی ساعتی
                    if (_FormCode == 1000001)
                    {
                        MyDB.setQuery(@" Update DataFile Set Status=17 Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + Time_ + " And Emp_No=" + _Emp_Card);
                    }
                    // فرم تایید کارکرد
                    else if ((_FormCode == 1000003) && (cmbFeild.SelectedValue.ToString() != ""))
                    {
                        MyDB.setQuery(@" Update DataFile Set Status=" + cmbFeild.SelectedValue.ToString() + " Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + Time_ + " And Emp_No=" + _Emp_Card);
                        // فرم مرخصی روزانه
                        //                        else if (_FormCode == 1000002)
                        //MyDB.setQuery(@" Insert into Mor_Mam values(" +_Emp_Card + ",Null, dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)), dbo.Miladi2Pwkara(cast('" + EDate_ + "' as date)),dbo.Miladi2Pwkara(cast('" + EDate_ + "' as date))-dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)),");
                        //                            MyDB.setQuery(@" Update DataFile Set Status=" + cmbFeild.SelectedValue.ToString() + " Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + Time_ + " And Emp_No=" + _Emp_Card);
                    }
                    else
                    {
                        //db.Rollback("Vacation");
                        //JMessages.Error("  خطا در ثبت اطلاعات یا قبلا این مرخصی ثبت شده است", "");
                        //return;
                    }

                    MyDB.beginTransaction("PWKARA");
                    if ((MyDB.SQL == null) || (MyDB.Query_Execute() > 0))
                    {
                        if (_FormCode == 1000001)
                            db1.setQuery("update [Propperty_ClassName_ClassLibrary.FormManagers_" + _FormCode.ToString() + "] set [تاييد__کارگزيني] = 1 where Code = " + Convert.ToInt32(dgvHour.SelectedRows[0].Cells["Code"].Value.ToString()));
                        else
                            db1.setQuery("update [Propperty_ClassName_ClassLibrary.FormManagers_" + _FormCode.ToString() + "] set [تاييد__کارگزيني] = 1 where Code = " + Convert.ToInt32(dgvConfirm.SelectedRows[0].Cells["Code"].Value.ToString()));
                        if (db1.Query_Execute() > 0)
                        {
                            Automation.JWorkFlow.AutoGoToNextNode("ClassLibrary.FormManagers", tmpJEmpLog.FormObjectCode, _FormCode, FormManagers.GetData(tmpJEmpLog.FormObjectCode), Automation.JNodeType.End);
                        //if (db.Query_Execute() > 0)
                        //{
                            if (db.Commit())
                            {
                                MyDB.Commit();
                                JMessages.Information(" با موفقیت ثبت شد ", "");
                            }
                            else
                            {
                                db1.setQuery("update [Propperty_ClassName_ClassLibrary.FormManagers_" + _FormCode.ToString() + "] set [تاييد__کارگزيني] = 0 where Code = " + Convert.ToInt32(dgvConfirm.SelectedRows[0].Cells["Code"].Value.ToString()));
                                db1.Query_Execute();
                                db.Rollback("Vacation");
                                MyDB.Rollback("PWKARA");
                                JMessages.Error(" خطا در ثبت ", "");
                                return;
                            }
                        }
                        else
                        {
                            db1.setQuery("update [Propperty_ClassName_ClassLibrary.FormManagers_" + _FormCode + "] set [تاييد__کارگزيني] = 0 where Code = " + Convert.ToInt32(dgvConfirm.SelectedRows[0].Cells["Code"].Value.ToString()));
                            db1.Query_Execute();
                            db.Rollback("Vacation");
                            MyDB.Rollback("PWKARA");
                            JMessages.Error(" خطا در ثبت ", "");
                            return;
                        }
                    }
                    else
                    {
                        db.Rollback("Vacation");
                        MyDB.Rollback("PWKARA");
                        JMessages.Error(" خطا در ثبت ", "");
                        return;
                    }
                    //}
                    //else
                    //{
                    //    db.Rollback("Vacation");
                    //    JMessages.Error("  خطا در ثبت اطلاعات یا قبلا این مرخصی ثبت شده است", "");
                    //}
                }
                else
                {
                    db.Rollback("Vacation");
                    JMessages.Error("  خطا در ثبت اطلاعات یا قبلا این مرخصی ثبت شده است", "");
                    return;
                }

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("Vacation");
                MyDB.Rollback("PWKARA");
                JMessages.Error(" خطا در ثبت ", "");
            }
            finally
            {
                db.Dispose();
                db1.Dispose();
                MyDB.Dispose();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!(CheckPermission()))
                return;

            if (!(_Time.Contains(':')))
            {
                JMessages.Error(" روی ساعت کلیک کنید ", "");
                return;
            }

            if (dgvHour.SelectedRows == null)
            {
                JMessages.Error(" از لیست انتخاب کنید ", "");
                return;
            }

            _FormCode = 1000003;
            _FormObjectCode = Convert.ToInt32(dgvConfirm.SelectedRows[0].Cells["ObjectCode"].Value.ToString());
            Confirm();
            //Bind();
        }

        private void btnHour_Click(object sender, EventArgs e)
        {
            if (!(CheckPermission()))
                return;

            if (!(_Time.Contains(':')))
            {
                JMessages.Error(" روی ساعت کلیک کنید ", "");
                return;
            }

            if (dgvHour.SelectedRows == null)
            {
                JMessages.Error(" از لیست انتخاب کنید ", "");
                return;
            }

            _FormCode = 1000001;
            _FormObjectCode = Convert.ToInt32(dgvHour.SelectedRows[0].Cells["ObjectCode"].Value.ToString());
            Confirm();
            //Bind();
        }

        private void btnRegForm_Click(object sender, EventArgs e)
        {
            Employment.JWorking p = new Employment.JWorking();
            p.ShowDialogFormObjects(_EmpCode);
            Bind();
        }

        private void btnSearchPersonnel_Click(object sender, EventArgs e)
        {
            SearchEmpForm p = new SearchEmpForm();
            p.ShowDialog();
            if (p._Code > 0)
            {
                _EmpCode = p._Code;
                JWorkingForm_Load(null, null);
                Bind();
            }
        }

        private void jdgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblConfirm.Text = "";
            lblHour.Text = "";
            _Time = "";
            if (jdgvList.CurrentCell != null)
            {
                _Time = jdgvList.CurrentCell.Value.ToString();
                if ((_Time.Contains(':')))
                {
                    lblConfirm.Text = _Time;
                    lblHour.Text = _Time;
                }
            }
        }

    }
}