using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace AUTOMOBILE.AutomobileDefine
{
    public partial class JAutomobileForm : ClassLibrary.JBaseForm
    {

        private int Code;
        private ArchivedDocuments.JArchiveList jArchiveListCar;
        public JAutomobileForm()
        {
            InitializeComponent();
            SetDefalut();
            State = ClassLibrary.JFormState.Insert;
        }

        public void Delete()
        {
            if (MessageBox.Show("آیا تمایل دارید مورد انتخاب شده حذف گردد", "اخطار!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                JAutomobileDefine objAutoDefine = new JAutomobileDefine();
                objAutoDefine.Code = Code;
                if (objAutoDefine.Delete())
                {
                    Close();                    
                }
                else
                {
                    MessageBox.Show("پردازش با خطا مواجه شد");
                }
            }
            else
            {
                Close();
            }
        }
        public JAutomobileForm(int Pcode)
        {
            InitializeComponent();
            SetDefalut();
            Code = Pcode;
            Load1(Pcode);
            this.State = ClassLibrary.JFormState.Update;
        }


        private bool Validation()
        {
            bool result = true;

            if (result && (txtPlak3.Text == null || txtPlak3.Text.Trim() == string.Empty))
            {
                MessageBox.Show("مشخصات پلاک را بطور کامل وارد کنید");
                txtPlak3.Focus();
                result = false;
            }

            if (result && (txtPlak2.Text == null || txtPlak2.Text.Trim() == string.Empty))
            {
                MessageBox.Show("مشخصات پلاک را بطور کامل وارد کنید");
                txtPlak2.Focus();
                result = false;
            }

            if (result && (cmbPlak.SelectedItem == null))
            {
                MessageBox.Show("مشخصات پلاک را بطور کامل وارد کنید");
                cmbPlak.Focus();
                result = false;
            }

            if (result && (txtPlak1.Text == null || txtPlak1.Text.Trim() == string.Empty))
            {
                MessageBox.Show("مشخصات پلاک را بطور کامل وارد کنید");
                txtPlak1.Focus();
                result = false;
            }

            if (result && (cmbType.SelectedValue == null))
            {
                MessageBox.Show("نوع را مشخص کنید");
                cmbType.Focus();
                result = false;
            }

            int model;
            if (result && (txtModel.Text == null || !int.TryParse(txtModel.Text,out model)))
            {
                MessageBox.Show("مدل را مشخص کنید");
                txtModel.Focus();
                result = false;
            }

            if (result && (cmbMakerCompany.SelectedValue == null))
            {
                MessageBox.Show("سازنده را مشخص کنید");
                cmbMakerCompany.Focus();
                result = false;
            }

            int capacity;
            if (result && (txtCapacity.Text == null || !int.TryParse(txtCapacity.Text, out capacity)))
            {
                MessageBox.Show("ظرفیت را مشخص کنید");
                txtCapacity.Focus();
                result = false;
            }
            

            return result;
        }
        

        public void SetDefalut()
        {
            JAutomobileTypes AT = new JAutomobileTypes();
            AT.SetComboBox(cmbType);

            JMakerCompanies MC = new JMakerCompanies();
            MC.SetComboBox(cmbMakerCompany);

            jArchiveListCar = new ArchivedDocuments.JArchiveList();
            tabPage2.Controls.Add(jArchiveListCar);
            jArchiveListCar.Dock = DockStyle.Fill;
            jArchiveListCar.ClassName = "AUTOMOBILE.JAutomobileDefine";
        }

        private void Load1(int pCode)
        {
            JAutomobileDefine Auto = new JAutomobileDefine();
            Auto.GetData(pCode);


            txtPlak1.Text = Auto.Plaque.Substring(0, 2);
            cmbPlak.Text = Auto.Plaque.Substring(2, 1);
            txtPlak2.Text = Auto.Plaque.Substring(3, 3);
            txtPlak3.Text = Auto.Plaque.Substring(7, 2);
            cmbMakerCompany.SelectedValue = Auto.maker;
            txtCapacity.Text = Auto.Capacity.ToString();
            txtModel.Text = Auto.Model.ToString();
            cmbType.SelectedValue = Auto.Type;
            chkActive.Checked = Auto.Active;

            jArchiveListCar.ObjectCode = pCode;

        }

        private void SetData(JAutomobileDefine Auto)
        {
            Auto.Code = Code;

            string str = txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;
            Auto.Plaque = str;
            Auto.Capacity = int.Parse(txtCapacity.Text);
            Auto.Model = int.Parse(txtModel.Text);
            Auto.Type = (int)cmbType.SelectedValue;
            Auto.Active = chkActive.Checked;
            Auto.maker = (int)cmbMakerCompany.SelectedValue;
        }

        private int Save()
        {
            JAutomobileDefine objAutoDefine = new JAutomobileDefine();
          
            {
                SetData(objAutoDefine);
                if (State == ClassLibrary.JFormState.Insert)
                    Code = objAutoDefine.Insert();
                else
                    if (State == ClassLibrary.JFormState.Update)
                        objAutoDefine.Update();
                State = ClassLibrary.JFormState.Update;

                if (jArchiveListCar.ObjectCode == 0)
                {
                    jArchiveListCar.ObjectCode = Code;
                }
                jArchiveListCar.ArchiveList();
                return Code;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Save();
                Close();
            }
            //if (this.State == ClassLibrary.JFormState.Insert)
            //{
            //    MessageBox.Show("عملیات درج با موفقیت انجام شد");
            //    this.Close();
            //}
            //else {
            //    MessageBox.Show("مجدد انجام شود");
            //}
        }//end of button ok

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Validation())
                Save();
            //if (this.State == ClassLibrary.JFormState.Insert)
            //{
            //    JAutomobileDefine objAutoDefine = new JAutomobileDefine();
            //    objAutoDefine.Insert();
            //    MessageBox.Show("عملیات درج با موفقیت انجام شد");
            // }
            //else
            //{
            //    MessageBox.Show("مجدد انجام شود");
            //}

        }//end of button Apply

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsole_Click(object sender, EventArgs e)
        {

        }

        private void JAutomobileForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
