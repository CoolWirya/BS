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
    public partial class JNotaryLetterForm : JBaseForm
    {

        public int _NotaryLetterCode;
        

        public JNotaryLetterForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveList1.ClassName = "Legal.JNotaryLetter";
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.PlaceCode = 0;
            FillCombo();
        }

        public JNotaryLetterForm(int pNotaryCode)
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveList1.ClassName = "Legal.JNotaryLetter";
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.PlaceCode = 0;
            jArchiveList1.ObjectCode = pNotaryCode;
            _NotaryLetterCode = pNotaryCode;
            FillCombo();
            Set_Form();
        }

        #region Methods
        private void FillNoteryCombo()
        {
            /// دفترخانه ها
            jcmbNotary.DataSource = JNotarys.GetDataTable();
            jcmbNotary.DisplayMember = "FullName";
            jcmbNotary.ValueMember = "Code";
        }
        public void FillCombo()
        {

            FillNoteryCombo();
            JNotaryLetterSubjects LetterSubjects = new JNotaryLetterSubjects();
            JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            nullDeff.Code = -1;
            nullDeff.Name = "-----------";
            cmbSubject.Items.Clear();
            cmbSubject.Items.Add(nullDeff);
            cmbSubject.SelectedItem = nullDeff;

            JNotaryLetter Letter = new JNotaryLetter(this._NotaryLetterCode);
            LetterSubjects.SetComboBox(cmbSubject, Letter.Subject);

            //foreach (JSubBaseDefine Subject in LetterSubjects.Items)
            //{
            //    cmbSubject.Items.Add(Subject);
            //    JNotaryLetter Letter=new JNotaryLetter(this._NotaryLetterCode);
            //    if (Subject.Code == Letter.Subject)
            //    {
            //        cmbSubject.SelectedItem = (JSubBaseDefine)Subject;
            //    }
            //}                       
        }

        private void Set_Form()
        {
            try
            {
                /// مقداردهی پراپرتی های لیست آرشیو
                jArchiveList1.ClassName = "Legal.JNotaryLetter";
                jArchiveList1.SubjectCode = 0;
                jArchiveList1.PlaceCode = 0;
                jArchiveList1.ObjectCode = _NotaryLetterCode;

                JNotaryLetter tmpJNotaryLetter = new JNotaryLetter();
                tmpJNotaryLetter.GetData(_NotaryLetterCode);
                DateLetter.Date = tmpJNotaryLetter.Date;
                txtLetterNo.Text = tmpJNotaryLetter.LetterNumber;
                //txtNotary.Text = tmpJNotaryLetter.Notary_Code.ToString();
                JNotary tmp = new JNotary(tmpJNotaryLetter.Notary_Code);
               // txtNotary.Text = tmp.NumNotary.ToString();
                jcmbNotary.SelectedValue = tmp.Code;
                chkSended.Checked = tmpJNotaryLetter.Sended;
                //if (!String.IsNullOrEmpty(txtNotary.Text.Trim()))
                //{

            
                //jcmbNotary.Items.Add(null);
                //jcmbNotary.SelectedItem = null;
                //}
                JCitiy Sb = new JCitiy();
                if (Sb.GetData(tmp.City))
                {
                    jcmbNotary.Text = Sb.Name;
                }

                //txtNotary.Text = tmp.NumNotary.ToString();
                //tmpJNotaryLetter.Notary_Code.ToString();
                txtDesc.Text = tmpJNotaryLetter.Description;

                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private bool Save()
        {
            try
            {
                #region Check Data

                if (jcmbNotary.SelectedValue == null)
                {
                    JMessages.Message("شماره دفتر خانه را وارد کنید ", "", JMessageType.Information);
                    return false;
                }
                if (Convert.ToInt32(cmbSubject.SelectedValue) == -1)
                {
                    JMessages.Message("موضوع نامه را وارد کنید ", "", JMessageType.Information);
                    return false;
                }
                if (txtLetterNo.Text == "")
                {
                    JMessages.Message("شماره نامه را وارد کنید ", "", JMessageType.Information);
                    return false;
                }
                if (DateLetter.Date == DateTime.MinValue)
                {
                    JMessages.Message("تاریخ نامه را وارد کنید ", "", JMessageType.Information);
                    return false;
                }
                
                #endregion

                JNotaryLetter tmpJNotaryLetter = new JNotaryLetter();
                    tmpJNotaryLetter.Date = DateLetter.Date;
                    tmpJNotaryLetter.LetterNumber = txtLetterNo.Text;
                    tmpJNotaryLetter.Notary_Code = (int)jcmbNotary.SelectedValue;
                    tmpJNotaryLetter.Subject = Convert.ToInt32(cmbSubject.SelectedValue);
                    tmpJNotaryLetter.Description = txtDesc.Text.Trim();
                    tmpJNotaryLetter.Sended = chkSended.Checked;
                    //-----------اطلاعات آرشیو------------
                    jArchiveList1.ClassName = "Legal.JNotaryLetter";
                    jArchiveList1.PlaceCode = 0;
                    jArchiveList1.SubjectCode = 0;

                    //---------ویرایش------------
                    if (State == JFormState.Update)
                    {
                        //----------Update Archive------------
                        tmpJNotaryLetter.Code = _NotaryLetterCode;
                        jArchiveList1.ObjectCode = _NotaryLetterCode;
                        jArchiveList1.ArchiveList();
                        if (tmpJNotaryLetter.Update())
                        {
                            JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                    }
                    else
                    {
                        _NotaryLetterCode = tmpJNotaryLetter.Insert();
                        if (tmpJNotaryLetter.Code > 0)
                        {
                            jArchiveList1.ObjectCode = tmpJNotaryLetter.Code;
                            jArchiveList1.ArchiveList();
                            JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message(" Insert Not Successfuly ", "", JMessageType.Error);
                    }                
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        #endregion

        #region Event Changes

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JNotaryLetterForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                Set_Form();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                btnSave.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
                    if (Save())
                        Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    Close();
            }
            else
                Close();
        }

        private void btnSearchNotary_Click(object sender, EventArgs e)
        {
            //JNotaryForm p = new JNotaryForm();
            //p.ShowDialog();
        }

        private void txtNotary_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!String.IsNullOrEmpty(txtNotary.Text.Trim()))
            //    {
            //        jcmbNotary.DisplayMember = "City";
            //        jcmbNotary.ValueMember = "Code";
            //        jcmbNotary.DataSource = JNotarys.FindCity(Convert.ToInt32(txtNotary.Text.Trim()));
            //    }
            //}
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //}
        }

        #endregion

        private void btnAddNotery_Click(object sender, EventArgs e)
        {
            JNotary notery = new JNotary();
            notery.ShowDialog(false);
            FillNoteryCombo();
        }

    }
}
