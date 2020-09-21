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
    public partial class JFishForm : ClassLibrary.JBaseForm
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
                    cmbConcern.SelectedValue = _concern;
                }
            }
        }

        private int _BankCode = 0;
        private int _BranchCode = 0;
        public JFish Fish;
        public int _PersonGroup;

        public JFishForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JFish";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            _Load();
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
            _Load();
        }

        /// <summary>
        /// انتخاب صادر کننده و دریافت کننده بصورت پیشفرض
        /// </summary>
        /// <param name="pExporter"></param>
        /// <param name="pReciever"></param>
        public JFishForm(int pExporter, int pReciever)
            : this()
        {
            InitializeComponent();
            PersonExport.SelectedCode = pExporter;
            PersonReciver.SelectedCode = pReciever;
            _Load();
        }

        #region Methods

        private void FillCombo()
        {
            if (cmbBank.Items.Count > 0)
                return;
            //Finance.JConcernTypes Subjects = new Finance.JConcernTypes();
            //Subjects.SetComboBox(cmbConcern, _ConcernCode);

            Finance.JBankTypes Banks = new Finance.JBankTypes();
            Banks.SetComboBox(cmbBank, _BankCode);

            SetCombo(cmbBank, "select * from Trs_View_Resource", "Name", "Code");

            SetCombo(cmbConcern, "select Code,Name,ClassCode1,ClassCode2,ClassCode3 from dbo.Trs_View_Concern", "Name", "Code");

            SetCombo(cmbForm, "select * from dbo.Trs_View_FormConcern", "Name", "Code");
        }

        public void SetCombo(JComboBox pBox, String pSql, String pDisplayMember, string pValueMember)
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
            JFish tmp = new JFish(_Code);
            JArchive.ObjectCode = _Code;

            _BankCode = tmp.Bank_Code;
            _BranchCode = tmp.branch_Code;
            txtNo.Text = tmp.Serial_No.ToString();
            txtDeliverDate.Date = tmp.Create_Date;
            txtPrice.Text = tmp.Price.ToString();
            PersonReciver.SelectedCode = tmp.ReceiverCode;
            PersonExport.SelectedCode = tmp.ExporterCode;
            txtDesc.Text = tmp.Description;

            txtSerial.Text = tmp.ConcernSerial;
            txtAcc1.Text = tmp.Acc1.ToString();
            txtAcc2.Text = tmp.Acc2.ToString();
            txtAcc3.Text = tmp.Acc3.ToString();

            txtDateRecieve.Date = tmp.PaymentDate;

            try
            {
                cmbForm.SelectedValue = tmp.ConcernForm;
                cmbBank.SelectedValue = tmp.Bank_Code;
                cmbConcern.SelectedValue = tmp.Concern;
            }
            catch
            {

            }

            _ConcernCode = tmp.Concern;

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
            if (cmbBank.SelectedItem == null)
            {
                JMessages.Information("Please  Enter Bank", "Information");
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
            if (Fish == null)
                Fish = new JFish();
            if (CheckData())
            {
                Fish.Bank_Code = Convert.ToInt32(cmbBank.SelectedValue);
                Fish.Serial_No = txtNo.Text;
                Fish.Create_Date = txtDeliverDate.Date;
                Fish.PaymentDate = txtDateRecieve.Date;
                Fish.Price = txtPrice.DecimalValue;
                Fish.ReceiverCode = PersonReciver.SelectedCode;
                Fish.ExporterCode = PersonExport.SelectedCode;
                Fish.Description = txtDesc.Text.Trim();

                Fish.ConcernSerial = txtSerial.Text;
                Fish.ConcernForm = Convert.ToInt32(cmbForm.SelectedValue);
                Fish.Concern = Convert.ToInt32(cmbConcern.SelectedValue);

                try { Fish.Acc1 = int.Parse(txtAcc1.Text); } catch { }
                try { Fish.Acc2 = int.Parse(txtAcc2.Text); } catch { }
                try { Fish.Acc3 = int.Parse(txtAcc3.Text); } catch { }
                
                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Legal.JFish";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                if (State != JFormState.Update)
                {
                    Fish.PersonGroup = _PersonGroup;
                    _Code = Fish.Insert(tempdb);
                    Fish.Code = _Code;
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
                    Fish.Code = _Code;
                    if (Fish.Update(tempdb))
                    {
                        JArchive.ObjectCode = Fish.Code;
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

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }


        #endregion

        private void _Load()
        {
            PersonExport.Text = "صادر کننده";
            PersonReciver.Text = "دریافت کننده";

            if (_ConcernCode > 0)
            {
                cmbConcern.Enabled = false;
            }

            if (State == JFormState.Update)
                setForm();
            else
                FillCombo();
        }
        private void JFishForm_Load(object sender, EventArgs e)
        {
            PersonExport.Text = "صادر کننده";
            PersonReciver.Text = "دریافت کننده";

            if (_ConcernCode > 0)
            {
                cmbConcern.Enabled = false;
            }

            if (State == JFormState.Update)
                setForm();
            else
                FillCombo();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید صادر کننده و دریافت کننده جابجا شوند؟", "") == DialogResult.Yes)
            {
                int temp = PersonExport.SelectedCode;
                PersonExport.SelectedCode = PersonReciver.SelectedCode;
                PersonReciver.SelectedCode = temp;
            }
        }

        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSerial.Text = (cmbForm.SelectedItem as DataRowView)["Text2"].ToString();

        }

        private void txtAcc1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try {
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
            catch
            {

            }
        }
    }
}
