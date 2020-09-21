using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Finance
{
    public partial class JPromissoryNoteForm : ClassLibrary.JBaseForm
    {
        public int _Code = 0;
        private int _ConcernCode = 0;
        public JPromissoryNote PromissoryNote;
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

        /// <summary>
        /// انتخاب صادر کننده و دریافت کننده بصورت پیشفرض
        /// </summary>
        /// <param name="pExporter"></param>
        /// <param name="pReciever"></param>
        public JPromissoryNoteForm(int pExporter, int pReciever)
            : this()
        {
            //InitializeComponent();
            PersonExport.SelectedCode = pExporter;
            PersonReciver.SelectedCode = pReciever;
        }

        #region Methods

        private void FillCombo()
        {
            JConcernTypes Subjects = new JConcernTypes();
            //cmbConcern.Items.Clear();
            Subjects.SetComboBox(cmbConcern,-1 );//_ConcernCode
            //foreach (JSubBaseDefine Subject in Subjects.Items)
            //{
            //    cmbConcern.Items.Add(Subject);
            //    if (_ConcernCode != 0 && _ConcernCode == Subject.Code)
            //        cmbConcern.SelectedItem = Subject;
            //}
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
            PersonReciver.SelectedCode = tmp.ReceiverCode;
            PersonExport.SelectedCode = tmp.ExporterCode;
            //tmp.Back_Note = txtNo.Text.Trim();
            txtDesc.Text = tmp.Description;
            _ConcernCode = tmp.Concern;
            FillCombo();
            //AddDiePerson_Click(null, null);
            //btnAddReceiver_Click(null, null);
        }
        public bool Save()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            if (Save(tempdb))
                return true;
            else
                return false;
        }

        private bool CheckData()
        {
            if (cmbConcern.SelectedItem == null)
            {
                JMessages.Information("Please  Enter Concern", "Information");
                return false;
            }
            if (txtNo.Text.Trim() == "")
            {
                JMessages.Information("Please  Enter Number", "Information");
                return false;
            }
            if (txtDeliverDate.Date == null)
            {
                JMessages.Information("Please  Enter DeliverDate", "Information");
                return false;
            }
            if (txtPrice.Text.Trim() == "")
            {
                JMessages.Information("Please  Enter Price", "Information");
                return false;
            }
            if (PersonReciver.SelectedCode == 0)
            {
                JMessages.Information("Please  Enter ReceiverCode", "Information");
                return false;
            }
            if (PersonExport.SelectedCode == 0)
            {
                JMessages.Information("Please  Enter ExportCode", "Information");
                return false;
            }
            return true;
        }

        public bool Save(JDataBase tempdb)
        {
            if (CheckData())
            {
                if (PromissoryNote == null)
                    PromissoryNote = new JPromissoryNote();
                //tmp.Bank_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBank.SelectedItem)).Code);
                //tmp.branch_Code = Convert.ToInt32(((ClassLibrary.JSubBaseDefine)(cmbBranch.SelectedItem)).Code);
                PromissoryNote.Serial_No = (txtNo.Text.Trim()).ToString();
                PromissoryNote.Create_Date = txtDeliverDate.Date;
                //tmp.Issue_Date = txtDateRecieve.Date;
                PromissoryNote.Price = txtPrice.MoneyValue;
                PromissoryNote.ReceiverCode = PersonReciver.SelectedCode;
                PromissoryNote.ExporterCode =PersonExport.SelectedCode;
                //tmp.Back_Note = txtNo.Text.Trim();
                PromissoryNote.Description = txtDesc.Text.Trim();
                PromissoryNote.Concern = Convert.ToInt32(cmbConcern.SelectedValue);

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Legal.PromissoryNote";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                if (State != JFormState.Update)
                {
                    _Code = PromissoryNote.Insert(tempdb);
                    PromissoryNote.Code = _Code;
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
                    PromissoryNote.Code = _Code;
                    if (PromissoryNote.Update(tempdb))//_ContractSubjectCode
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
             return false;
        }

        #endregion

        #region Events

        //private void AddDiePerson_Click(object sender, EventArgs e)
        //{
        //    int Code = 0;
        //    if (State == JFormState.Insert)
        //    {
        //        JFindPersonForm FPF = new JFindPersonForm();
        //        FPF.ShowDialog();
        //        if (FPF.SelectedPerson != null)
        //            Code = FPF.SelectedPerson.Code;
        //    }
        //    else
        //        Code = Convert.ToInt32(txtExportCode.Text);
        //    if (Code != 0)
        //    {
        //        JPerson JDP = new JPerson();
        //        if (JDP.getData(Code))
        //        {
        //            if (Code.ToString() != txtReceiverCode.Text)
        //            {
        //                txtExportCode.Text = JDP.Code.ToString();
        //                labDeadName.Text = JDP.Name.ToString();
        //                labDeadFamily.Text = JDP.Fam.ToString();
        //                labDeadshsh.Text = JDP.ShSh.ToString();
        //                labDeaFatherName.Text = JDP.FatherName.ToString();
        //                labDeadNationalCode.Text = JDP.ShMeli.ToString();
        //                labDeadDateofbirth.Text = JDateTime.FarsiDate(JDP.BthDate);
        //            }
        //            else
        //                JMessages.Error("Person Code is repeated", "Error");
        //        }
        //        else
        //            JMessages.Error("PersonCodeNotFound", "Error");
        //    }
        //}

        //private void btnAddReceiver_Click(object sender, EventArgs e)
        //{
        //    int Code = 0;
        //    if (State == JFormState.Insert)
        //    {
        //        JFindPersonForm FPF = new JFindPersonForm();
        //        FPF.ShowDialog();
        //        if (FPF.SelectedPerson != null)
        //            Code = FPF.SelectedPerson.Code;
        //    }
        //    else
        //        Code = Convert.ToInt32(txtReceiverCode.Text);
        //    if (Code != 0)
        //    {
        //        JPerson JDP = new JPerson();
        //        if (JDP.getData(Code))
        //        {
        //            if (PersonExport.SelectedCode != Code)
        //            {
        //                txtReceiverCode.Text = JDP.Code.ToString();
        //                lblName.Text = JDP.Name.ToString();
        //                lblLastName.Text = JDP.Fam.ToString();
        //                lblshsh.Text = JDP.ShSh.ToString();
        //                lblFather.Text = JDP.FatherName.ToString();
        //                lblNational.Text = JDP.ShMeli.ToString();
        //                lblBrith.Text = JDateTime.FarsiDate(JDP.BthDate);
        //            }
        //            else
        //                JMessages.Error("Person Code is repeated", "Error");
        //        }
        //        else
        //            JMessages.Error("PersonCodeNotFound", "Error");
        //    }
        //}

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
                if (JMessages.Question("DoYouWantToSaveChanges", "Information") == DialogResult.Yes)                
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
            PersonExport.Text = "صادر کننده";
            PersonReciver.Text = "دریافت کننده";
            if (State == JFormState.Update)
                setForm();
            FillCombo();
        }
        #endregion

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید صادر کننده و دریافت کننده جابجا شوند؟", "") == DialogResult.Yes)
            {
                int temp = PersonExport.SelectedCode;
                PersonExport.SelectedCode = PersonReciver.SelectedCode;
                PersonReciver.SelectedCode = temp;
            }
        }
    }
}
