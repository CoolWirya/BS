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
    public partial class JRealPriceForm : ClassLibrary.JBaseForm
    {
        public int _Code = 0;
        public int _ConcernCode = 0;
        public JRealPrice RealPrice;
        public bool isSave = false;

        public JRealPriceForm()
        {
            InitializeComponent();
        }

        public JRealPriceForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }

        /// <summary>
        /// انتخاب صادر کننده و دریافت کننده بصورت پیشفرض
        /// </summary>
        /// <param name="pExporter"></param>
        /// <param name="pReciever"></param>
        public JRealPriceForm(int pExporter, int pReciever)
            : this()
        {
            personExport.SelectedCode = pExporter;
            PersonReciver.SelectedCode = pReciever;
        }

        private void JRealPriceForm_Load(object sender, EventArgs e)
        {
            personExport.Text = "صادر کننده";
            PersonReciver.Text = "دریافت کننده";
            if (State == JFormState.Update)
                setForm();
            FillCombo();
        }

        private void FillCombo()
        {
            Finance.JConcernTypes Subjects = new Finance.JConcernTypes();
            //cmbConcern.Items.Clear();
            Subjects.SetComboBox(cmbConcern, _ConcernCode);
            //foreach (JSubBaseDefine Subject in Subjects.Items)
            //{
            //    cmbConcern.Items.Add(Subject);
            //    if (_ConcernCode != 0 && _ConcernCode == Subject.Code)
            //        cmbConcern.SelectedItem = Subject;
            //}
        }

        public void setForm()
        {
            JRealPrice tmp = new JRealPrice(_Code);
            txtDeliverDate.Date = tmp.Create_Date;
            txtPrice.Text = tmp.Price.ToString();
            PersonReciver.SelectedCode = tmp.ReceiverCode;
            personExport.SelectedCode = tmp.ExporterCode;
            txtDesc.Text = tmp.Description;
            _ConcernCode = tmp.Concern;
            FillCombo();
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
            if (personExport.SelectedCode == 0)
            {
                JMessages.Information("Please  Enter ExportCode", "Information");
                return false;
            }
            return true;
        }

        public bool Save(JDataBase tempdb)
        {
            if (RealPrice == null)
                RealPrice = new JRealPrice();
            
            if (CheckData())
            {
                RealPrice.Create_Date = txtDeliverDate.Date;
                RealPrice.Price = txtPrice.MoneyValue;
                RealPrice.ReceiverCode = PersonReciver.SelectedCode;
                RealPrice.ExporterCode = personExport.SelectedCode;
                RealPrice.Description = txtDesc.Text.Trim();
                RealPrice.Concern = Convert.ToInt32(cmbConcern.SelectedValue);

                    if (State != JFormState.Update)
                    {
                        _Code = RealPrice.Insert(tempdb);
                        if (_Code > 0)
                        {
                            State = JFormState.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        RealPrice.Code = _Code;
                        if (RealPrice.Update(tempdb))
                            return true;
                        else
                            return false;
                    }
                return true;
            }
            else
                return false;
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
                        JMessages.Error("Process Not Successfuly ", "خطا در ورود اطلاعات");
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

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید صادر کننده و دریافت کننده جابجا شوند؟", "") == DialogResult.Yes)
            {
                int temp = personExport.SelectedCode;
                personExport.SelectedCode = PersonReciver.SelectedCode;
                PersonReciver.SelectedCode = temp;
            }
        }
    }
}
