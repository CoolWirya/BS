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
    public partial class JChequesForm : ClassLibrary.JBaseForm
    {
        public int _Code = 0;
        private int _concern;
        public int _ConcernCode
        {
            get
            {
                return _concern;
            }
            set
            {
                _concern = value;
                if (cmbConcern != null && cmbConcern.Items.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    cmbConcern.SelectedValue = _ConcernCode;
                }
            }
        }

        public int _BankCode = 0;
        public int _BranchCode = 0;
        public JCheque Cheque;
        public bool isSave = false;
        private bool _SetFrorm = false;
        public int _PersonGroup;

        public string PropertyClassName
        {
            get
            {
                return jPropertyValueUserControl1.ClassName;
            }
            set
            {
                //jPropertyValueUserControl1.ClassName = "Legal.JCheque."+value;
            }
        }
        
        public JChequesForm()
        {
            InitializeComponent();

            State = JFormState.Insert;

            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JCheque";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;


            jPropertyValueUserControl1.ClassName = "Legal.JCheque";
            jPropertyValueUserControl1.ObjectCode = 0;
            _Load();
        }

        public JChequesForm(int pCode)
        {
            InitializeComponent();

            State = JFormState.Update;
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JCheque";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;

            jPropertyValueUserControl1.ClassName = "Legal.JCheque";
            jPropertyValueUserControl1.ObjectCode = 0;
            jPropertyValueUserControl1.ValueObjectCode = _Code;
            _Load();
        }

        /// <summary>
        /// انتخاب صادر کننده و دریافت کننده بصورت پیشفرض
        /// </summary>
        /// <param name="pExporter"></param>
        /// <param name="pReciever"></param>
        public JChequesForm(int pExporter, int pReciever)
            : this()
        {
            personExport.SelectedCode = pExporter;
            PersonReciver.SelectedCode = pReciever;
        }

        #region Methods

        //private void GetPatern()
        //{
        //    JCheque tmp = new JCheque();
        //    _dt = tmp.GetAllData(0);
        //}

        private void FillCombo()
        {
            JBranchTypes Branchs = new JBranchTypes();
            Branchs.SetComboBox(cmbBranch, _BranchCode);

            SetCombo(cmbBank, "select Code,Name from dbo.Trs_View_Banks", "Name", "Code");
            SetCombo(cmbConcern, "select Code,Name,ClassCode1,ClassCode2,ClassCode3 from dbo.Trs_View_Concern", "Name", "Code");
            SetCombo(cmbForm, "select * from dbo.Trs_View_FormConcern", "Name", "Code");
            SetCombo(cmbState, "select * from dbo.Trs_View_State", "Name", "Code");
            cmbState.SelectedValue = 31;

            cmbConcern.SelectedValue = _ConcernCode;
        }

        public void SetCombo(JComboBox pBox,String pSql,String pDisplayMember,string pValueMember)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(pSql);
                DataTable DT = DB.Query_DataTable();
                pBox.DataSource = DT;
                pBox.DisplayMember = pDisplayMember;
                pBox.ValueMember = pValueMember;
            }
            finally
            {
                DB.Dispose();
            }

        }

        public void setForm()
        {
            _SetFrorm = true;
            try {
                FillCombo();

                JCheque tmp = new JCheque(_Code);
                if (tmp.Code == 0)
                    return;
                JArchive.ObjectCode = _Code;
                txtAccountNumber.Text = tmp.AccountNo.ToString();
                txtNo.Text = tmp.Cheque_No.ToString();
                txtDeliverDate.Date = tmp.Create_Date;
                txtDateRecieve.Date = tmp.Issue_Date;
                txtPrice.Text = tmp.Price.ToString();
                PersonReciver.SelectedCode = tmp.ReceiverCode;
                personExport.SelectedCode = tmp.ExporterCode;
                //txtExportCode.Text = tmp.ExporterCode.ToString();
                txtNote.Text = tmp.Back_Note;
                txtDesc.Text = tmp.Description;
                txtSerial.Text = tmp.ConcernSerial;
                txtAcc1.Text = tmp.Acc1.ToString();
                txtAcc2.Text = tmp.Acc2.ToString();
                txtAcc3.Text = tmp.Acc3.ToString();
                txtBranch_Number.Text = tmp.branch_Number.ToString();

                cmbForm.SelectedValue = tmp.ConcernForm;
                cmbState.SelectedValue = tmp.State;
                SetCombo(cmbCity, "select * from dbo.Trs_View_City where ParentNode=" + cmbState.SelectedValue.ToString(), "Name", "Code");
                cmbCity.SelectedValue = tmp.City;
                cmbBank.SelectedValue = tmp.Bank_Code;
                cmbBranch.SelectedValue = tmp.branch_Code;
                cmbConcern.SelectedValue = tmp.Concern;


                _ConcernCode = tmp.Concern;
                _BankCode = tmp.Bank_Code;
                _BranchCode = tmp.branch_Code;
                //AddDiePerson_Click(null,null);
                //btnAddReceiver_Click(null, null);
            }
            catch
            {

            }
            finally
            {
                _SetFrorm = false;
            }
        }

        public bool Save()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                if (Save(tempdb))
                    return true;
                else
                    return false;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        private bool CheckData()
        {
            if(cmbConcern.SelectedItem == null) 
            {
                JMessages.Information("Please  Enter Concern", "Information");
                return false;
            }
            if (cmbBank.SelectedItem == null)
            {
                JMessages.Information("Please  Enter Bank", "Information");
                return false;
            }
            if (cmbBranch.SelectedItem == null)
            {
                JMessages.Information("Please  Enter Branch", "Information");
                return false;
            }
            if (txtNo.Text.Trim() == "")
            {
                JMessages.Information("Please  Enter Number", "Information");
                return false;
            }
            if (txtAccountNumber.Text.Trim() == "")
            {
                JMessages.Information("Please  Enter AccountNumber", "Information");
                return false;
            }
            if (txtDeliverDate.Date == null)
            {
                JMessages.Information("Please  Enter DeliverDate", "Information");
                return false;
            }
            if (txtDateRecieve.Date == null)
            {
                JMessages.Information("Please  Enter DateRecieve", "Information");
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
            if (personExport.SelectedCode == 0)
            {
                JMessages.Information("Please  Enter ExportCode", "Information");
                return false;
            }
            return true;
        }

        public bool Save(JDataBase tempdb)
        {
            //JCheque Cheque;
            if (Cheque == null)
                Cheque = new JCheque();
            //else
                //Cheque = Cheque;
            if (CheckData())
            {
                Cheque.AccountNo = txtAccountNumber.Text;
                Cheque.Bank_Code = Convert.ToInt32(cmbBank.SelectedValue);
                Cheque.branch_Code = Convert.ToInt32(cmbBranch.SelectedValue);
                Cheque.Cheque_No = txtNo.Text;
                Cheque.Create_Date = txtDeliverDate.Date;
                Cheque.Issue_Date = txtDateRecieve.Date;
                Cheque.Price = txtPrice.MoneyValue;
                Cheque.ReceiverCode = PersonReciver.SelectedCode;
                Cheque.ExporterCode = personExport.SelectedCode;
                Cheque.Back_Note = txtNote.Text.Trim();
                Cheque.Description = txtDesc.Text.Trim();
                Cheque.Concern = Convert.ToInt32(cmbConcern.SelectedValue);

                Cheque.ConcernForm = Convert.ToInt32(cmbForm.SelectedValue);
                Cheque.ConcernSerial = txtSerial.Text;
                try { Cheque.branch_Number = int.Parse(txtBranch_Number.Text); } catch { }
                Cheque.City = Convert.ToInt32(cmbCity.SelectedValue);
                Cheque.State = Convert.ToInt32(cmbState.SelectedValue);

                try { Cheque.Acc1 = int.Parse(txtAcc1.Text); } catch { }
                try { Cheque.Acc2 = int.Parse(txtAcc2.Text); } catch { }
                try { Cheque.Acc3 = int.Parse(txtAcc3.Text); } catch { }


                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Legal.JCheque";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //if (Cheque == null)
                {
                    if (State != JFormState.Update)
                    {
                        Cheque.PersonGroup = _PersonGroup;
                        _Code = Cheque.Insert(tempdb);
                        if (_Code > 0)//_ContractSubjectCode
                        {
                            JArchive.ObjectCode = Cheque.Code;
                            JArchive.ArchiveList();

                            jPropertyValueUserControl1.ValueObjectCode = _Code;
                            jPropertyValueUserControl1.Save();

                            State = JFormState.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        Cheque.Code = _Code;
                        if (Cheque.Update(tempdb))//_ContractSubjectCode
                        {
                            JArchive.ObjectCode = Cheque.Code;
                            JArchive.ArchiveList();
                            jPropertyValueUserControl1.Save();
                            return true;
                        }
                        else
                            return false;
                    }
                }
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Events

        private void JChequesForm_Load(object sender, EventArgs e)
        {
        }

        private void _Load()
        {
            personExport.Text = "صادر کننده";
            PersonReciver.Text = "دریافت کننده";
            if (State == JFormState.Update)
                setForm();
            else
                FillCombo();

            if (_ConcernCode > 0)
            {
                cmbConcern.Enabled = false;
            }
        }


        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
                isSave = true;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
                isSave = true;
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
   
        #endregion

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید صادر کننده و دریافت کننده جابجا شوند؟", "") == DialogResult.Yes)
            {
                int temp = personExport.SelectedCode;
                personExport.SelectedCode = PersonReciver.SelectedCode;
                PersonReciver.SelectedCode = temp;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_SetFrorm)
                    return;
                txtSerial.Text = (cmbForm.SelectedItem as DataRowView)["Text2"].ToString();
            }
            catch
            {

            }
        }

        private void jPropertyValueUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SetFrorm)
                return;
            SetCombo(cmbCity, "select * from dbo.Trs_View_City where ParentNode="+cmbState.SelectedValue.ToString(), "Name", "Code");

        }

        private void textEdit5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender == txtAcc1)
            {
                Finance.FinanceDocuments.Cheques.JSelectAccForm SAF = new FinanceDocuments.Cheques.JSelectAccForm(int.Parse(txtDateRecieve.Text.Substring(0, 4)), (int)(cmbConcern.SelectedItem as DataRowView)["ClassCode1"]);
                if (SAF.ShowDialog() == DialogResult.OK)
                {
                    txtAcc1.Text = SAF.ReturnValue.ToString();
                }
            }
            if (sender == txtAcc2)
            {
                Finance.FinanceDocuments.Cheques.JSelectAccForm SAF = new FinanceDocuments.Cheques.JSelectAccForm(int.Parse(txtDateRecieve.Text.Substring(0, 4)), (int)(cmbConcern.SelectedItem as DataRowView)["ClassCode2"]);
                if (SAF.ShowDialog() == DialogResult.OK)
                {
                    txtAcc2.Text = SAF.ReturnValue.ToString();
                }
            }
            if (sender == txtAcc3)
            {
                Finance.FinanceDocuments.Cheques.JSelectAccForm SAF = new FinanceDocuments.Cheques.JSelectAccForm(int.Parse(txtDateRecieve.Text.Substring(0, 4)), (int)(cmbConcern.SelectedItem as DataRowView)["ClassCode3"]);
                if (SAF.ShowDialog() == DialogResult.OK)
                {
                    txtAcc3.Text = SAF.ReturnValue.ToString();
                }
            }
        }

        private void txtDateRecieve_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtAcc1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
