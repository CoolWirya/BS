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
    public partial class JNoticeForm : JBaseForm
    {
        public int _PetitionCode;
        public int _Code;

        public JNoticeForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveNotice.ClassName = "Legal.JNotice";
            jArchiveNotice.SubjectCode = 0;
            jArchiveNotice.PlaceCode = 0;
        }

        public JNoticeForm(int Code)
        {
            InitializeComponent();
            _Code = Code;
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveNotice.ClassName = "Legal.JNotice";
            jArchiveNotice.SubjectCode = 0;
            jArchiveNotice.PlaceCode = 0;
            jArchiveNotice.ObjectCode = _Code;
        }

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        #endregion

        private void btnSearchPetition_Click(object sender, EventArgs e)
        {
            JPetitionSearchForm tmpfrm = new JPetitionSearchForm();
            tmpfrm.ShowDialog();
            if (tmpfrm.DialogResult == DialogResult.OK)
            {
                _PetitionCode = tmpfrm._Code;
                Set_Form();
            }
        }

        #region Methods

        private void Set_Form()
        {
            if (State == JFormState.Update)
            {
                JNotice tmp = new JNotice(_Code);
                _PetitionCode = tmp.PetitionCode;
                txtDate.Date = tmp.Date;
                txtTime.Text = tmp.Time.ToString();
                txtReason.Text = tmp.Reasons;
                txtResult.Text = tmp.Result;
                txtDateNotified.Date = tmp.DateNotified;
                txtDateEnd.Date = tmp.DateEnd;
                txtDateMax.Text = tmp.DateMax.ToString();
                chkInformed.Checked = tmp.Informed;
            }

            JPetition tmpJPetition = new JPetition(_PetitionCode);
            txtNumber.Text = tmpJPetition.Number;
            //cmbSubject.SelectedValue = tmpJPetition.Subject_Code;
            JJudicialBranch tmpJJudicialBranch = new JJudicialBranch(tmpJPetition.judicialCode);
            JJudicialComplex tmpJJudicialComplex = new JJudicialComplex(tmpJJudicialBranch.JudicialComplex);
            txtJudicial.Text = tmpJJudicialBranch.Name.ToString();
            txtBranch.Text = tmpJJudicialComplex.Name.ToString();

            txtSubject.Text = (new JSubBaseDefine(JBaseDefine.PetitionSubjectTypes, tmpJPetition.Subject_Code)).Name;
            jdgvFey.DataSource = JPersonPetition.GetAllDataType(_PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);
            //JAllPerson tmpPerson = new JAllPerson(tmpJPetition.per);
            //txtCode.Text = tmpPerson.Code.ToString();
            //txtName.Text = tmpPerson.Name;
            //if (tmpPerson.PersonType == JPersonTypes.RealPerson)
            //    txtTypePerson.Text = "حقیقی";
            //else
            //    txtTypePerson.Text = "حقوقی";
            btnSave.Enabled = false;
        }

        private bool Save()
        {
            #region checkField
            if((txtDate.Date == null)||txtTime.Text=="")
            {
                JMessages.Error("زمان و ساعت حضور را مشخص کنید","error");
                txtDate.Focus();
                return false;
            }
            if(   _PetitionCode == 0)
            {
                JMessages.Error("دادخواست یا شکواییه را انتخاب کنید","error");
                txtNumber.Focus();
                return false;
                
            }
            #endregion
            JNotice tmpJNotice=new JNotice();
            tmpJNotice.PetitionCode = _PetitionCode;
            tmpJNotice.ReferPersonCode = 0;
            tmpJNotice.Date = txtDate.Date;
            tmpJNotice.Time = txtTime.Text;
            tmpJNotice.Reasons = txtReason.Text;
            tmpJNotice.Result = txtResult.Text;
            tmpJNotice.DateNotified = txtDateNotified.Date;
            tmpJNotice.DateEnd = txtDateEnd.Date;
            tmpJNotice.DateMax =Convert.ToInt32( txtDateMax.Text);
            tmpJNotice.Informed = chkInformed.Checked;

            //---------ویرایش------------
                if (State == JFormState.Update)
                {
                    tmpJNotice.Code = _Code;
                    //----------Update Archive------------
                    tmpJNotice.Code = _Code;
                    jArchiveNotice.ObjectCode = _Code;
                    jArchiveNotice.ArchiveList();
                    if (tmpJNotice.Update())
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                    {
                        JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                        return false;
                    }

                }
                else
                {
            //---------درج------------
                    _Code=tmpJNotice.Insert();
                    if (_Code > 0)
                    {

                        jArchiveNotice.ObjectCode = tmpJNotice.Code;
                        jArchiveNotice.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                    {
                        JMessages.Message(" Insert Not Successfuly ", "", JMessageType.Error);
                        return false;
                    }
                    
                }                      
        }

        #endregion

        private void JNotice_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                Set_Form();
        }

        private void txtDateMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtDateMax.Text!="")
            {
                DateTime DateNotified = txtDateNotified.Date;
                txtDateEnd.Date = DateNotified.AddDays(Convert.ToDouble(txtDateMax.Text));
            }
        }

     
      

       
       

      


      

        
    }
}
