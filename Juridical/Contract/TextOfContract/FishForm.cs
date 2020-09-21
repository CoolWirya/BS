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
    public partial class JFishForm : ClassLibrary.JBaseForm
    {
        public int _Code = 0;
        private int _ConcernCode = 0;
        private int _BankCode = 0;
        private int _BranchCode = 0;

        public JFishForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JFish";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JFishForm(int pCode)
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JFish";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = pCode;
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
            JFish tmp = new JFish(_Code);
            JArchive.ObjectCode = _Code;

            _BankCode = tmp.Bank_Code;
            _BranchCode = tmp.branch_Code;
            txtNo.Text = tmp.Serial_No.ToString();
            txtDeliverDate.Date = tmp.Create_Date;
            txtPrice.Text = tmp.Price.ToString();
            txtReceiverCode.Text = tmp.ReceiverCode.ToString();
            txtExportCode.Text = tmp.ExporterCode.ToString();
            txtDesc.Text = tmp.Description;
            _ConcernCode = tmp.Concern;
            FillCombo();
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
            JFish tmp = new JFish();
            if ((cmbConcern.SelectedItem != null) && (cmbBank.SelectedItem != null) && (cmbBranch.SelectedItem != null) && (txtNo.Text.Trim() != "") && (txtDeliverDate.Date != null) && (txtPrice.Text.Trim() != "") && (txtReceiverCode.Text.Trim() != "") && (txtExportCode.Text.Trim() != ""))
            {
                tmp.Bank_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBank.SelectedItem)).Code);
                tmp.branch_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBranch.SelectedItem)).Code);
                tmp.Serial_No = Convert.ToInt32(txtNo.Text);
                tmp.Create_Date = txtDeliverDate.Date;
                tmp.Price = Convert.ToInt32(txtPrice.Text.Trim());
                tmp.ReceiverCode = Convert.ToInt32(txtReceiverCode.Text);
                tmp.ExporterCode = Convert.ToInt32(txtExportCode.Text);
                tmp.Description = txtDesc.Text.Trim();
                tmp.Concern = ((ClassLibrary.JSubBaseDefine)(cmbConcern.SelectedItem)).Code;

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Legal.JFish";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                if (State != JFormState.Update)
                {
                    _Code = tmp.Insert(tempdb);
                    if (_Code > 0)
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
                    if (tmp.Update(tempdb))
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
                JMessages.Information("Please Enter Data", "Information");
                return false;
            }
        }

        #endregion

        #region Events

        private void JChequesForm_Load(object sender, EventArgs e)
        {
            //if (State != JStateContractForm.Change)
            //{
                //cmbTypeDoc.DisplayMember = "Title";
                //cmbTypeDoc.ValueMember = "Code";
                //cmbTypeDoc.DataSource = JDocumentType.GetAllData();
                FillCombo();
                //GetPatern();
            //}
            //if ((ContractForms.Contract.Code != 0) && (State != JStateContractForm.Change))
            //{
            //    setForm();
            //    State = JStateContractForm.Change;
            //}
        }

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

        private void JFishForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                setForm();
            FillCombo();
        }

    }
}
