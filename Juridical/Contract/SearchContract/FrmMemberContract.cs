using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Security
{
    public partial class FrmMemberContract : JBaseForm
    {
        private JMemberContract _Mem;
        private JAllPerson Person;
        FrmGetContract Frm;
        Legal.JSubjectContract ActiveContract;

        public FrmMemberContract(JMemberContract Mem)
        {
            InitializeComponent();
           
            _Mem = Mem;
            fillComboBox();
            ActiveContract = new Legal.JSubjectContract();

            if (_Mem.Code == 0)
            {
                
                State = JFormState.Insert;
            }
            else
            {
                State = JFormState.Update;
                Display();
            }
        }
        private void Display()
        {
            txtCode.Text = _Mem.Code.ToString();
             Person = new JAllPerson(_Mem.PersonCode);
            TxtPerson.Text = Person.Name;
            Frm = new FrmGetContract(_Mem.CodeContract);
            TxtGhNumber.Text = TxtGhNumber.Text = "كد قرارداد: " + Frm.Contract.Code.ToString() + " : طرف قرارداد " + Frm.Person.Name;
            TxtExpireDate.Date = _Mem.Expire_Date;
            CmbSamat.SelectedValue = Convert.ToInt32(_Mem.JobPostion);
            ChkBlock.Checked = _Mem.Status;
            
        }
        private void fillComboBox()
        {
            // پرکردن وضعیت کارت
            JobPostion JS = new JobPostion();
            CmbSamat.Items.Clear();
            JS.SetComboBox(CmbSamat);
        }
        private void FrmMemberContract_Load(object sender, EventArgs e)
        {

        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm searchPerson = new JFindPersonForm(JPersonTypes.RealPerson);
            if (searchPerson.ShowDialog() == DialogResult.OK)
            {
                /// انتخاب یکی
                Person = searchPerson.SelectedPerson;
                TxtPerson.Text = Person.Name;
                

            }
           

        }
        private Boolean validtion()
        {
            if (TxtPerson.Text == "")
            {
                JMessages.Error("فردي در حال انتخاب نيست", "هشدار");
                TxtPerson.Focus();
                return false;
            }
            if (TxtExpireDate.Text == "")
            {
                JMessages.Error("تاريخ وارد نشده است", "هشدار");
                TxtExpireDate.Focus();
                return false;
            }
            if (Convert.ToInt32(CmbSamat.SelectedValue) == 0 || Convert.ToInt32(CmbSamat.SelectedValue) == -1)
            {
                JMessages.Error("بايد براي فرد يك سمت انتخاب نماييد", "هشدار");
                CmbSamat.Focus();
                return false;
            }
            if (Frm.Contract.Code <= 0)
            {
                JMessages.Error("شماره قرارداد فرد غير معتبر است", "هشدار");
                TxtGhNumber.Focus();
                return false;
            }
            return true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!validtion())
                {
                    return;
                }
                _Mem.PersonCode = Person.Code;
                _Mem.CodeContract = Frm.Contract.Code;
                _Mem.Expire_Date = TxtExpireDate.Date;
                _Mem.JobPostion = Convert.ToInt32(CmbSamat.SelectedValue);
                _Mem.Status = ChkBlock.Checked;
                _Mem.Hint = Person.Name;
                

                if (State == JFormState.Insert)
                {
                    int code = _Mem.Insert();
                    if (code != 0)
                    {
                        JMessages.Error("Insert Succefully", "هشدار");
                        this.Close();
                    }
                    else
                    {
                        JMessages.Error("Insert Not Succefuly", "هشدار");
                    }
                }
                else
                {
                   
                    _Mem.Code = Convert.ToInt32(txtCode.Text);
                    if (_Mem.Update())
                    {
                       
                        JMessages.Error("Update Succefully", "هشدار");
                        this.Close();

                    }
                    else
                    {
                        JMessages.Error("Update Not Succefuly", "هشدار");
                    }
                }
            }
            catch(Exception Ex)
            {
                JMessages.Error(Ex.Message, "هشدار");
                    
            }
        }

        private void BtnGharardad_Click(object sender, EventArgs e)
        {
            if (State == JFormState.Insert)
            {
                Frm = new FrmGetContract();
                Frm.ShowDialog();
                if (Frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    TxtGhNumber.Text = "كد قرارداد: " + Frm.Contract.Code.ToString() + " : طرف قرارداد " + Frm.Person.Name;
                }
            }
            else
            {
                Frm = new FrmGetContract(Frm.Contract.Code);
                Frm.ShowDialog();
                if (Frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    TxtGhNumber.Text = "كد قرارداد: " + Frm.Contract.Code.ToString() + " : طرف قرارداد " + Frm.Person.Name;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validtion())
                {
                    return;
                }
                _Mem.PersonCode = Person.Code;
                _Mem.CodeContract = Frm.Contract.Code;
                _Mem.Expire_Date = TxtExpireDate.Date;
                _Mem.JobPostion = Convert.ToInt32(CmbSamat.SelectedValue);
                _Mem.Status = ChkBlock.Checked;
                _Mem.Hint = Person.Name;


                if (State == JFormState.Insert)
                {
                    int code = _Mem.Insert();
                    if (code != 0)
                    {
                        JMessages.Error("Insert Succefully", "هشدار");
                    }
                    else
                    {
                        JMessages.Error("Insert Not Succefuly", "هشدار");
                    }
                }
                else
                {

                    _Mem.Code = Convert.ToInt32(txtCode.Text);
                    if (_Mem.Update())
                    {

                        JMessages.Error("Update Succefully", "هشدار");

                    }
                    else
                    {
                        JMessages.Error("Update Not Succefuly", "هشدار");
                    }
                }
            }
            catch
            {
            }
        }
    }
}
