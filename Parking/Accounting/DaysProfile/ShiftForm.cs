using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Parking
{
    public partial class JShiftForm : ClassLibrary.JBaseForm
    {
        JDayProfile _JDayProfile;
        System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
        //JConfig ParkingConfig;

        int _Market;
        public int _GateMode=0;
       
        private void FillComboBox()
        {
            // پر كردن نام مجتمع / بازارها
           
            JDataBase Jdb=new JDataBase();
            Jdb.setQuery("Select * from users");
            cmbHeadShift.DataSource = Jdb.Query_DataTable();
            cmbHeadShift.DisplayMember = "username";
            cmbHeadShift.ValueMember = "Code";
        }
       

        public JShiftForm(JDayProfile DayProfile,int Market,int Mode)
        {
            InitializeComponent();
            FillComboBox();
            
            JConnection conn = new JConnection();
            SqlBuilder = conn.GetSQlServerConnection("Parking.JDayProfile", 0);
        
             _GateMode=Mode;
             if (DayProfile.Code > 0)
            {
                _JDayProfile = DayProfile;
                _JDayProfile.Market = Market;
                Display();
                State = JFormState.Update;
                _Market = Market;
                if (_GateMode == 0)
                {
                    btnGate.Enabled = true;
                    BtnReport.Enabled = true;
                    btnDamgeReport.Enabled = true;
                }
              
            }
            else
            {
                _JDayProfile = new JDayProfile();
                JDataBase jdb = new JDataBase(SqlBuilder);
                _JDayProfile.Date = jdb.GetCurrentDateTime().Date.Date;
                _JDayProfile.Market = Market;
                State = JFormState.Insert;
               DateTime DtCurent = jdb.GetCurrentDateTime();
                txtDate.Text = JDateTime.FarsiDate(DtCurent);
                Txtnumber.Text = DtCurent.TimeOfDay.ToString();
                _JDayProfile.Dispose();
                            

            }
        }

        private void Save()
        {
           
            _JDayProfile.HeadShift = Convert.ToInt32(cmbHeadShift.SelectedValue);
          
            _JDayProfile.Description = txtDescription.Text;
            _JDayProfile.UserReg = 1;
         
            if (!Validate())
                return;
            _JDayProfile.AmountKol = txtMoney.IntValue;
            if (State == JFormState.Insert)
            {
                JDataBase jdb = new JDataBase();
                JBaseShift Shift = new JBaseShift();
              
                DateTime DtNow = jdb.GetCurrentDateTime();
                Shift.GetTime(DtNow.ToString("HH:mm"), _JDayProfile.Market);
                _JDayProfile.shift = Shift.Code;
                _JDayProfile.Date = DtNow.Date;
                 _JDayProfile.NameShift = " روز " + JDateTime.FarsiDate(DtNow)+" " + Shift.Name;
                 _JDayProfile.Time = DtNow.ToString("HH:mm");
                 _JDayProfile.Code = _JDayProfile.Insert(jdb);
                 if (_JDayProfile.Code > 0)
                 {
                     JMessages.Information("ثبت با موفقيت انجام شد", "هشدار");
                 }
                 else
                 {
                     JMessages.Information("در انجام عمليات مشكلي بروز كرده است", "هشدار");
                 }
                 
            }
            else
            {
                _JDayProfile.Description = txtDescription.Text;
                _JDayProfile.AmountKol = txtMoney.IntValue;
               

                if (_JDayProfile.Update())
                {
                    JMessages.Information("ثبت با موفقيت انجام شد", "هشدار");

                }
                else
                {
                    JMessages.Information("در انجام عمليات مشكلي بروز كرده است", "هشدار");
                }


            }
        }
      

        private void JShiftForm_Load(object sender, EventArgs e)
        {
            JConnection conn = new JConnection();
            SqlBuilder = conn.GetSQlServerConnection("Parking.JDayProfile", 0);

        }

        

      private void Display()
        {
            txtDescription.Text = _JDayProfile.Description;
            cmbHeadShift.SelectedValue = Convert.ToInt32(_JDayProfile.HeadShift);
            txtDate.Text = JDateTime.FarsiDate(_JDayProfile.Date);
            Txtnumber.Text = _JDayProfile.Time;
            this.Text = _JDayProfile.NameShift;
           
            txtDate.Enabled = false;
        
            txtMoney.Text = _JDayProfile.AmountKol.ToString();
            
        }

      private void btnSave_Click(object sender, EventArgs e)
      {
          Save();
          if (_GateMode == 0)
          {
              btnGate.Enabled = true;
              BtnReport.Enabled = true;
              btnDamgeReport.Enabled = true;
          }
          else
          {
              BtnReport.Enabled = true;
          }

      }

      private void BtnReport_Click(object sender, EventArgs e)
      {
         
          JDataBase jdb = new JDataBase(SqlBuilder);
       try
       {
         
          DateTime DtNow = _JDayProfile.Date;
          _JDayProfile.GetReportParking(jdb, DtNow, DtNow, _GateMode,_Market);
      }
           catch
            {
                ClassLibrary.JMessages.Error("در تهيه گزارش خطايي بروز كرده است", "هشدار");
               
            }
            finally
            {
                jdb.Dispose();
            }
      }
      private Boolean CValdtion()
      {
          if (_JDayProfile.HeadShift <= 0)
          {
              JMessages.Error("سر شيفت خود را وارد نماييد", "خطا در ورود اطلاعات");
              return false;
          }
          if (_JDayProfile.Description =="")
          {
              JMessages.Error("توضيحات", "خطا در ورود اطلاعات");
              return false;
          }
          
          return true;

      }
      private void btnGate_Click(object sender, EventArgs e)
      {
         
          JDataBase jdb = new JDataBase(SqlBuilder);
          try
          {

              DateTime DtNow = _JDayProfile.Date;
              _JDayProfile.GetReportGate(jdb, DtNow, DtNow, _GateMode);
          }
          catch
          {
              ClassLibrary.JMessages.Error("در تهيه گزارش خطايي بروز كرده است", "هشدار");

          }
          finally
          {
              jdb.Dispose();
          }
      }

      private void btnDamgeReport_Click(object sender, EventArgs e)
      {
          JDataBase jdb = new JDataBase(SqlBuilder);
          try
          {

              DateTime DtNow = _JDayProfile.Date;
              _JDayProfile.GetReportOfDamge(jdb, DtNow, DtNow, _GateMode);
          }
          catch
          {
              ClassLibrary.JMessages.Error("در تهيه گزارش خطايي بروز كرده است", "هشدار");

          }
          finally
          {
              jdb.Dispose();
          }

      }

     

      
    }
}
