using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JNotaryForm : ClassLibrary.JBaseForm
    {
        private JNotary _newNotary;
        //تعیین می کند که فیلد ها تغیر کرده است یا نه
        private bool ChangeField = false;
        public bool RefreshNode;

        public JNotaryForm()
        {
            InitializeComponent();
            _newNotary = new JNotary();
            _FillComboBox();

        }
        public JNotaryForm(int pCode)
        {
            InitializeComponent();
            _newNotary = new JNotary(pCode);
            _ShowData();
            _FillComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void btmSave_Click(object sender, EventArgs e)
        {
            if (_CheckField())
            {
                if (_save())
                {
                    btmSave.Enabled = false;
                }
            }
        }

        private void _ShowData()
        {
            txtNumNotary.Text = Convert.ToString(_newNotary.NumNotary);
            txtHeadOffice.Text = _newNotary.HeadOffice;
            txtAssistant.Text = _newNotary.Assistant;
            txtAddress.Text = _newNotary.Address;
            txtTel.Text = Convert.ToString(_newNotary.Tel);
            txtMobile.Text = Convert.ToString(_newNotary.Mobile);
            txtFax.Text = Convert.ToString(_newNotary.Fax);
            btmSave.Enabled = false;
        }
        private void _FillComboBox()
        {
            JCities cities = new JCities();
            cities.SetComboBox(cmbCity, _newNotary.City);
            //foreach (JSubBaseDefine citiy in cities.Items)
            //{
            //    cmbCity.Items.Add(citiy);
            //    if (_newNotary.City != 0 && _newNotary.City == citiy.Code)
            //    {
            //        cmbCity.SelectedItem = citiy;
            //    }
            //}
        }

        private void JNotaryForm_Load(object sender, EventArgs e)
        {
             if (this.State == ClassLibrary.JFormState.Update)
            { 
               
                txtNumNotary.ReadOnly = true;
            }
          
        }
        private bool _save()
        {
            try
            {
                _newNotary.NumNotary = Convert.ToInt32(txtNumNotary.Text);
                _newNotary.HeadOffice = txtHeadOffice.Text;
                _newNotary.Assistant = txtAssistant.Text;
                _newNotary.Address = txtAddress.Text;
                _newNotary.Tel = txtTel.Text;
                _newNotary.Mobile = txtMobile.Text;
                _newNotary.Fax = txtFax.Text;
                _newNotary.City = Convert.ToInt32(cmbCity.SelectedValue);
                if (this.State == ClassLibrary.JFormState.Insert)
                {
                    if (_newNotary.Insert(RefreshNode) > 0)
                        return true;
                }
                else
                {
                    return _newNotary.Update();
                }
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            return false;
        }

        private bool _CheckField()
        {
            if (txtNumNotary.Text == "")
            {
                JMessages.Error("شماره دفتر وارد نشده است", "خطا در ثبت اطلاعات");
                return false;
            }
            if(txtHeadOffice.Text=="")
            {
                JMessages.Error("نام سر دفتر وارد نشده است", "خطا در ثبت اطلاعات");
                return false;
            }
            if(cmbCity.SelectedItem==null)
            {
                JMessages.Error("شهر اقامت دفتر اسناد رسمی انتخاب نشده است", "خطا در ثبت اطلاعات");
                return false;
            }
            return true;


        }

        private void txtHeadOffice_TextChanged(object sender, EventArgs e)
        {
            btmSave.Enabled = true;
            
        }                
    }
}
