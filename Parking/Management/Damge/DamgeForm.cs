using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;

namespace Parking
{
    public partial class DamgeForm : Globals.JBaseForm
    {
       
        public JDamge _Damge;
     
        public DamgeForm()
        {
            InitializeComponent();
        }
        private void Display()
        {
            txthint.Text = _Damge.Hint;
            CmbGate.SelectedValue = Convert.ToInt32(_Damge.Gate);
            CmbTypeDamge.SelectedValue = Convert.ToInt32(_Damge.Type);
                      
         
        }
        private void FillComboBox(int Pmarket)
        {
            // پر كردن نام مجتمع / بازارها
    
            CmbGate.DataSource = JGates.GetDataTable(0,Pmarket);
            CmbGate.DisplayMember = "Name";
            CmbGate.ValueMember = "Code";
            CmbGate.SelectedValue = Convert.ToInt32(_Damge.Gate);
            CmbGate.Enabled = false;

            // ****************************
            // پر كردن نوع خرابي
            JTypeDamege rg = new JTypeDamege();
            CmbTypeDamge.Items.Clear();
            rg.SetComboBox(CmbTypeDamge);

        }
       
        private Boolean Validate()
        {
            
            if (txthint.Text == "")
            {
                JMessages.Warning("نام به شكل صحيح وارد نشده است", "توجه");
                txthint.Focus();
                return false;
            }
           
            if (Convert.ToInt32(CmbTypeDamge.SelectedValue) == -1 || Convert.ToInt32(CmbTypeDamge.SelectedValue) == 0)
            {
                JMessages.Warning("نوع خرابي نا مشخص است", "توجه");
                CmbTypeDamge.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (Validate() == false) return;
            
            _Damge.Type = Convert.ToInt32(CmbTypeDamge.SelectedValue);
            _Damge.Hint = txthint.Text;
           
           if (State == JFormState.Insert)
            {
                int _Code = _Damge.Insert();

                if (_Code != 0)
                {
                    State = JFormState.Update;
                    _Damge.GetData(_Code);
                    Display();
                    JMessages.Information("اطلاعات ثبت شد", "توجه");
                }
                else
                {
                    JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                }
            }
            else
            {
                if (_Damge.Update())
                {
                    Display();
                    JMessages.Information("اطلاعات ثبت شد", "توجه");
                }
                else
                {
                    JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                }
            }

        }

        public DamgeForm(JDamge Damge)
        {
          InitializeComponent();
          _Damge = Damge;
          FillComboBox(Damge.Market);
         
          State = JFormState.Insert; 
          DateTime Dt = DateTime.Now;
         CmbGate.SelectedValue = Convert.ToInt32(_Damge.Gate);
             
       
        }
         public DamgeForm(JDamge Damge,int PmarketCode)
        {
            InitializeComponent();
          _Damge= Damge;
          _Damge.Market = PmarketCode;
          FillComboBox(PmarketCode);


         
         
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
