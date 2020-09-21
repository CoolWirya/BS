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
    public partial class JChequesForm : ClassLibrary.JBaseForm
    {
        public int _Code = 0;
        public int _ConcernCode = 0;
        public int _BankCode = 0;
        public int _BranchCode = 0;

        public JChequesForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JCheque";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JChequesForm(int pCode)
        {
            InitializeComponent();

            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JCheque";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;
        }

        #region Methods

        //private void GetPatern()
        //{
        //    JCheque tmp = new JCheque();
        //    _dt = tmp.GetAllData(0);
        //}

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

            JBankTypes Banks = new JBankTypes();
            cmbBank.Items.Clear();
            foreach (JSubBaseDefine Bank in Banks.Items)
            {
                cmbBank.Items.Add(Bank);
                if (_BankCode != 0 && _BankCode == Bank.Code)
                    cmbBank.SelectedItem = Bank;
            }

            JDefineSubjectTypes Branchs = new JDefineSubjectTypes();
            cmbBranch.Items.Clear();
            foreach (JSubBaseDefine Branch in Branchs.Items)
            {
                cmbBranch.Items.Add(Branch);
                if (_BranchCode != 0 && _BranchCode == Branch.Code)
                    cmbBranch.SelectedItem = Branch;
            }
        }

        public void setForm()
        {
            JCheque tmp = new JCheque(_Code);
            JArchive.ObjectCode = _Code;

           txtNo.Text = tmp.Cheque_No.ToString();
           txtDeliverDate.Date = tmp.Create_Date;
           txtDateRecieve.Date = tmp.Issue_Date;
           txtPrice.Text = tmp.Price.ToString();
           txtReceiverCode.Text = tmp.ReceiverCode.ToString();
           txtExportCode.Text = tmp.ExporterCode.ToString();
           txtNote.Text = tmp.Back_Note;
           txtDesc.Text = tmp.Description;
           _ConcernCode = tmp.Concern;
           _BankCode = tmp.Bank_Code;
           _BranchCode = tmp.branch_Code;
           FillCombo();
            AddDiePerson_Click(null,null);
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
            JCheque tmp = new JCheque();
            if ((cmbConcern.SelectedItem != null) && (cmbBank.SelectedItem != null) && (cmbBranch.SelectedItem != null) && (txtNo.Text.Trim() != "") && (txtDeliverDate.Date != null) && (txtDateRecieve.Date != null) && (txtPrice.Text.Trim() != "") && (txtReceiverCode.Text.Trim() != "") && (txtExportCode.Text.Trim() != ""))
            {
                tmp.Bank_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBank.SelectedItem)).Code);
                tmp.branch_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBranch.SelectedItem)).Code);
                tmp.Cheque_No = Convert.ToInt32(txtNo.Text);
                tmp.Create_Date = txtDeliverDate.Date;
                tmp.Issue_Date = txtDateRecieve.Date;
                tmp.Price = Convert.ToInt32(txtPrice.Text.Trim());
                tmp.ReceiverCode = Convert.ToInt32(txtReceiverCode.Text);
                tmp.ExporterCode = Convert.ToInt32(txtExportCode.Text);
                tmp.Back_Note = txtNote.Text.Trim();
                tmp.Description = txtDesc.Text.Trim();
                //dr["Return_Date"]  = ;
                //dr["Pass_Date"]  = ;
                tmp.Concern = ((ClassLibrary.JSubBaseDefine)(cmbConcern.SelectedItem)).Code;

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Legal.JCheque";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                if (State != JFormState.Update)
                {
                    _Code = tmp.Insert(tempdb);
                    if (_Code > 0)//_ContractSubjectCode
                    {
                        JArchive.ObjectCode = tmp.Code;
                        JArchive.ArchiveList();
                        State = JFormState.Update;
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
                        JArchive.ObjectCode = tmp.Code;
                        JArchive.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
            }
            else
            {
                JMessages.Information("Please  Enter Data", "Information");
                return false;
            }
        }

        #endregion

        #region Events

        private void JChequesForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                setForm();
            //if (State != JStateContractForm.Change)
            //{
                //cmbTypeDoc.DisplayMember = "Title";
                //cmbTypeDoc.ValueMember = "Code";
                //cmbTypeDoc.DataSource = JDocumentType.GetAllData();
                FillCombo();
        }
        
        private void AddDiePerson_Click(object sender, EventArgs e)
        {
            int Code=0;
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
        #endregion

    }
}
