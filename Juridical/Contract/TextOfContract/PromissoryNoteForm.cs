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
    public partial class JPromissoryNoteForm : ClassLibrary.JBaseForm
    {
        public int _Code = 0;
        private int _ConcernCode = 0;
        
        public JPromissoryNoteForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.PromissoryNote";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JPromissoryNoteForm(int pCode)
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.PromissoryNote";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            _Code = pCode;
        }

        #region Methods

        private void FillCombo()
        {
            JConcernTypes Subjects = new JConcernTypes();
            cmbConcern.Items.Clear();
            foreach (JSubBaseDefine Subject in Subjects.Items)
            {
                cmbConcern.Items.Add(Subject);
                if (_ConcernCode != 0 && _ConcernCode == Subject.Code)
                    cmbConcern.SelectedItem = Subject;
            }
        }

        public void setForm()
        {
            JPromissoryNote tmp = new JPromissoryNote(_Code);
            //jdgvDoc.DataSource = tmp.GetAllData(ContractForms.Contract.Code);
            JArchive.ObjectCode = _Code;
            
            //tmp.Bank_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBank.SelectedItem)).Code);
            //tmp.branch_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBranch.SelectedItem)).Code);
            txtNo.Text = tmp.Serial_No.ToString();
            txtDeliverDate.Date = tmp.Create_Date;
            //tmp.Issue_Date = txtDateRecieve.Date;
            txtPrice.Text = tmp.Price.ToString();
            txtReceiverCode.Text = tmp.ReceiverCode.ToString();
            txtExportCode.Text = tmp.ExporterCode.ToString();
            //tmp.Back_Note = txtNo.Text.Trim();
            txtDesc.Text = tmp.Description;
            _ConcernCode = tmp.Concern;
            FillCombo();
            AddDiePerson_Click(null, null);
            btnAddReceiver_Click(null, null);
        }
        public bool Save()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            if (Save(tempdb))
                return true;
            else
                return false;
        }

        public bool Save(JDataBase tempdb)
        {
            if ((txtNo.Text.Trim() != "") && (txtDeliverDate.Date != null) && (txtPrice.Text.Trim() != "") && (txtReceiverCode.Text != "") && (txtExportCode.Text != "") && (cmbConcern.SelectedItem != null))
            {
                JPromissoryNote tmp = new JPromissoryNote();
                //tmp.Bank_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBank.SelectedItem)).Code);
                //tmp.branch_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBranch.SelectedItem)).Code);
                tmp.Serial_No = Convert.ToInt32(txtNo.Text.Trim());
                tmp.Create_Date = txtDeliverDate.Date;
                //tmp.Issue_Date = txtDateRecieve.Date;
                tmp.Price = Convert.ToInt32(txtPrice.Text.Trim());
                tmp.ReceiverCode = Convert.ToInt32(txtReceiverCode.Text);
                tmp.ExporterCode = Convert.ToInt32(txtExportCode.Text);
                //tmp.Back_Note = txtNo.Text.Trim();
                tmp.Description = txtDesc.Text.Trim();
                tmp.Concern = ((ClassLibrary.JSubBaseDefine)(cmbConcern.SelectedItem)).Code;

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Legal.PromissoryNote";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                if (State != JFormState.Update)
                {
                    _Code = tmp.Insert(tempdb);
                    if (_Code > 0)//_ContractSubjectCode
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tmp.Code = _Code;
                    if (tmp.Update(tempdb))//_ContractSubjectCode
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
            }
            else
            {
                JMessages.Information("Please Enter Data", "Information");
                return false;
            }
        }

        #endregion

        #region Events

        private void AddDiePerson_Click(object sender, EventArgs e)
        {
            int Code = 0;
            if (State == JFormState.Insert)
            {
                JFindPersonForm FPF = new JFindPersonForm();
                FPF.ShowDialog();
                if (FPF.SelectedPerson != null)
                    Code = FPF.SelectedPerson.Code;
            }
            else
                Code = Convert.ToInt32(txtExportCode.Text);
            if (Code != 0)
            {
                JPerson JDP = new JPerson();
                if (JDP.getData(Code))
                {
                    if (Code.ToString() != txtReceiverCode.Text)
                    {
                        txtExportCode.Text = JDP.Code.ToString();
                        labDeadName.Text = JDP.Name.ToString();
                        labDeadFamily.Text = JDP.Fam.ToString();
                        labDeadshsh.Text = JDP.ShSh.ToString();
                        labDeaFatherName.Text = JDP.FatherName.ToString();
                        labDeadNationalCode.Text = JDP.ShMeli.ToString();
                        labDeadDateofbirth.Text = JDateTime.FarsiDate(JDP.BthDate);
                    }
                    else
                        JMessages.Error("Person Code is repeated", "Error");
                }
                else
                    JMessages.Error("PersonCodeNotFound", "Error");
            }
        }

        private void btnAddReceiver_Click(object sender, EventArgs e)
        {
            int Code = 0;
            if (State == JFormState.Insert)
            {
                JFindPersonForm FPF = new JFindPersonForm();
                FPF.ShowDialog();
                if (FPF.SelectedPerson != null)
                    Code = FPF.SelectedPerson.Code;
            }
            else
                Code = Convert.ToInt32(txtReceiverCode.Text);
            if (Code != 0)
            {
                JPerson JDP = new JPerson();
                if (JDP.getData(Code))
                {
                    if (txtExportCode.Text != Code.ToString())
                    {
                        txtReceiverCode.Text = JDP.Code.ToString();
                        lblName.Text = JDP.Name.ToString();
                        lblLastName.Text = JDP.Fam.ToString();
                        lblshsh.Text = JDP.ShSh.ToString();
                        lblFather.Text = JDP.FatherName.ToString();
                        lblNational.Text = JDP.ShMeli.ToString();
                        lblBrith.Text = JDateTime.FarsiDate(JDP.BthDate);
                    }
                    else
                        JMessages.Error("Person Code is repeated", "Error");
                }
                else
                    JMessages.Error("PersonCodeNotFound", "Error");
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (MessageBox.Show("DoYouWantToSaveChanges", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        private void cmbTypeDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDeliverDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDateRecieve_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtExportCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtReceiverCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        
        private void JPromissoryNoteForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                setForm();
            FillCombo();
        }
        #endregion
    }
}
