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
    public partial class JListForm : JBaseForm
    {
        string _SQL;
        int _FormCode;
        //int _FormObjectCode;
        int _Emp_Card;
        string _Time;
        string _Date;
        string _EDate;

        public JListForm(string pSQL, int pFormCode, int pEmp_Card, string pTime, string pDate)
        {
            InitializeComponent();
            _SQL = pSQL;
            _FormCode = pFormCode;
            //_FormObjectCode = pFormObjectCode;
            _Emp_Card = pEmp_Card;
            _Time = pTime;
            _Date = pDate;
        }

        private void JListForm_Load(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                // مرخصی ساعتی
                if (_FormCode == 1000001)
                    cmbFeild.Visible = false;
                db.setQuery(_SQL);
                jdgvList.DataSource = db.Query_DataTable();

                db.setQuery("SELECT * From [subdefine] WHERE Code=-1 or [bcode]=214 ORDER BY [name]");
                DataTable tmp = db.Query_DataTable();

                cmbFeild.DataSource = db.Query_DataTable();
                cmbFeild.DisplayMember = "name";
                cmbFeild.ValueMember = "TempCode";

                cmbFeild.Focus();
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();

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
                string Date_ = JDateTime.GregorianDate(_Date).ToShortDateString();;// Convert.ToDateTime(jdgvList.SelectedRows[0].Cells["تاریخ__درخواست"].Value.ToString()).ToShortDateString();
                string EDate_ = JDateTime.GregorianDate(_EDate).ToShortDateString();

                string Time_ = _Time;//jdgvList.SelectedRows[0].Cells["تا__ساعت"].Value.ToString();
                Time_ = Time_.Replace(":", "");
                //if (Time_[0].ToString() == "0") Time_ = Time_.Remove(0, 1);
                JEmpLog tmpJEmpLog = new JEmpLog();
                tmpJEmpLog.FormCode = _FormCode;
                tmpJEmpLog.FormObjectCode = Convert.ToInt32(jdgvList.SelectedRows[0].Cells["Code"].Value.ToString());
                db.beginTransaction("Vacation");
                if (tmpJEmpLog.insert(db) > 0)
                {
                    //MyDB.setQuery(@" Select * From DataFile Where Status=17 And Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_='" + Time_ + "' And EMP_NO=" + _Emp_Card);
                    //if (MyDB.Query_DataTable().Rows.Count == 0)
                    //{
                        // مرخصی ساعتی
                        if (_FormCode == 1000001)
                        {
                            MyDB.setQuery(@" Update DataFile Set Status=17 Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + Time_ + " And Emp_No=" + _Emp_Card);

                            //MyDB.setQuery(@" insert into DataFile values(17, dbo.Miladi2Pwkara(cast('" + Convert.ToDateTime(Date_).ToShortDateString() + "' as date)) , " + Time_ + "," +
                            //    _Emp_Card + " ,1 ,0 ,NULL	,NULL	,NULL	,NULL	,NULL)");
                        }
                        // فرم تایید کارکرد
                        else if (_FormCode == 1000003)
                            MyDB.setQuery(@" Update DataFile Set Status=" + cmbFeild.SelectedValue.ToString() + " Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + Time_ + " And Emp_No=" + _Emp_Card);                                                    
                        // فرم مرخصی روزانه
//                        else if (_FormCode == 1000002)
//MyDB.setQuery(@" Insert into Mor_Mam values(" +_Emp_Card + ",Null, dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)), dbo.Miladi2Pwkara(cast('" + EDate_ + "' as date)),dbo.Miladi2Pwkara(cast('" + EDate_ + "' as date))-dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)),");
//                            MyDB.setQuery(@" Update DataFile Set Status=" + cmbFeild.SelectedValue.ToString() + " Where Date_=dbo.Miladi2Pwkara(cast('" + Date_ + "' as date)) And Time_=" + Time_ + " And Emp_No=" + _Emp_Card);
                        else
                        {
                            db.Rollback("Vacation");
                            JMessages.Error("  خطا در ثبت اطلاعات یا قبلا این مرخصی ثبت شده است", "");
                            return;
                        }
                       
                        MyDB.beginTransaction("PWKARA");
                        if (MyDB.Query_Execute() > 0)
                        {
                            if (db.Commit())
                                MyDB.Commit();
                            else
                            {
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
                MyDB.Dispose();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
