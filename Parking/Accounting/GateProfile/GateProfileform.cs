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
  
    public partial class JGateProfileForm : Globals.JBaseForm
    {
        JUserProfile GateUser;
        public JGateProfileForm(JUserProfile _Gate,int Gate)
        {
            InitializeComponent();
            if (_Gate.Code > 0)
            {
                GateUser = _Gate;
                Display();
                State = JFormState.Update;
               
            }
            else
            {
                GateUser = new JUserProfile();
                State = JFormState.Insert;

            }
            
            
        }
        private void Display()
        {
            
            txtAmount.Text = GateUser.Amount.ToString();
            TxtHint.Text = GateUser.Hint.ToString();
            TxtCode.Text = GateUser.Code.ToString();
            lbldate.Text = GateUser.DateShift.Date.ToString();
            JPerson p = new JPerson(GateUser.Oprator);
             txtUser.Text = p.Name + p.Fam;
  
 

            
           
        }
        private void GateProfileform_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (State == JFormState.Insert)
            {
                GateUser.Amount = txtAmount.IntValue;
                JDataBase jdb = new JDataBase();
                GateUser.DateShift = jdb.GetCurrentDateTime().Date;
                GateUser.Gate = Properties.Settings.Default.Gate;
                GateUser.Hint = TxtHint.Text;
                GateUser.Market = Properties.Settings.Default.Complex;
                GateUser.Oprator = JMainFrame.CurrentUserCode;
                GateUser.Shift = JBaseShift.GetShiftOfTime();
                GateUser.Time = GateUser.DateShift.TimeOfDay.Hours.ToString() +":"+ GateUser.DateShift.TimeOfDay.Minutes.ToString();
                GateUser.Insert(jdb);
                if (GateUser.Code > 0)
                    this.Close();
            }
            else
            {
                GateUser.Amount = txtAmount.IntValue;
                JDataBase jdb = new JDataBase();
                GateUser.DateShift = jdb.GetCurrentDateTime().Date;
                GateUser.Gate = Properties.Settings.Default.Gate;
                GateUser.Hint = TxtHint.Text;
                GateUser.Market = Properties.Settings.Default.Complex;
                GateUser.Oprator = 1;
                GateUser.Shift = JBaseShift.GetShiftOfTime();
                GateUser.Time = GateUser.DateShift.TimeOfDay.Hours.ToString() + GateUser.DateShift.TimeOfDay.Minutes.ToString();
                if (GateUser.Update())
                    this.Close();
            }

        }
    }
}
