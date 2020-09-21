using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JEContractForm : ClassLibrary.JBaseForm
    {
        int _Code;
        
        public JEContractForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Employment.JEContract";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JEContractForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Employment.JEContract";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;
            ComPerson.Enabled = false;
        }

        private void Set_From()
        {
            JEContract contract = new JEContract(_Code);
            txtContractDate.Date = contract.DateContract;
            txtDateStart.Date = contract.DateStart;
            txtDateEnd.Date = contract.DateEnd;
            txtNo.Text = contract.ContractNo;
            txtEmpDate.Date = contract.DateEmployee;
            cmbActivity.SelectedValue = contract.ActivityType;
            cmbWorkShift.SelectedValue = contract.ShiftCode;
            txtDesc.Text = contract.ContractDesc;
            ComPerson.SelectedCode = contract.PCode;
            btnSave.Enabled = false;
            btnReContract.Enabled = true;
        }

        private void FillComboBox()
        {

            //پرکردن کمبو غذاها
            JSubBaseDefine NullDef = new JSubBaseDefine(0);
            NullDef.Name = "---------";
            NullDef.Code = -1;
            cmbWorkShift.Items.Add(NullDef);
            cmbWorkShift.SelectedItem = NullDef;
            cmbActivity.Items.Add(NullDef);
            cmbActivity.SelectedItem = NullDef;

            //پرکردن کمبو شیفت
            JShiftTypes JCCs = new JShiftTypes();
            JCCs.SetComboBox(cmbWorkShift,-1);

            //پرکردن کمبو فعالیت
            JActivityTypes JAc = new JActivityTypes();
            JAc.SetComboBox(cmbActivity, -1);

            //cmbPerson.TitleFieldName = "NameFam";
            //cmbPerson.AccessCodeFieldName = "PCode";
            //cmbPerson.CodeFieldName = "PCode";
            //cmbPerson.dataTable = JPerson.SearchPerson(0, "");
            //cmbPerson.SetComboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }          
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if ((btnSave.Enabled) && (MessageBox.Show(JLanguages._Text("DoYouWantToSaveChanges"), "Information", MessageBoxButtons.OKCancel) == DialogResult.OK))
                if (Save())
                    this.Close();
                else
                    JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
            else
                this.Close();
        }

        private bool Save()
        {
            try
            {
                #region CheckControl
                if (txtContractDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ قرارداد را وارد است", "error");
                    return false;
                }
                if (txtDateStart.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ شروع قرارداد را وارد کنید", "error");
                    return false;
                }
                if (txtDateEnd.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ پایان قرارداد را وارد کنید", "error");
                    return false;
                }
                //if (txtNo.Text == "")
                //{
                //    JMessages.Error("شماره قرارداد را وارد کنید", "error");
                //    return false;
                //}
                if (!(txtDateStart.Date < txtDateEnd.Date))
                {
                    JMessages.Error("تاریخ شروع و پایان قرارداد را درست وارد کنید", "error");
                    return false;
                }
                if (ComPerson.SelectedCode == 0)
                {
                    JMessages.Error("شخص را انتخاب کنید", "error");
                    return false;
                }
                #endregion

                JEContract contract = new JEContract();
                contract.DateContract = txtContractDate.Date;
                contract.DateStart = txtDateStart.Date;
                contract.DateEnd = txtDateEnd.Date;
                contract.ContractNo = txtNo.Text;
                contract.DateEmployee = txtEmpDate.Date;
                contract.ActivityType = Convert.ToInt32(cmbActivity.SelectedValue);
                contract.ShiftCode = Convert.ToInt32(cmbWorkShift.SelectedValue);
                contract.ContractDesc = txtDesc.Text;
                contract.PCode = ComPerson.SelectedCode;
                //DialogResult = DialogResult.OK;

                JArchive.ClassName = "Employment.JEContract";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------
                if (this.State != JFormState.Update)
                {
                    //----------Update Archive------------
                    _Code = contract.Insert();
                    if (_Code > 0)
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                }
                else
                {
                    contract.Code = _Code;
                    if (contract.Update())
                    {
                        contract.Code = _Code;
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void JEContractForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
            FillComboBox();
            if (State == JFormState.Update)
                Set_From();
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            ClassLibrary.JPersonListForm form = new JPersonListForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //_SetPersonCombo();
                //cmbPerson.SetValue(form.SelectedRow["PCode"]);
            }
            form.Dispose();
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnReContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (State == JFormState.Update)
                {
                    this.State = JFormState.Insert;
                    if (Save())
                    {
                        btnSave.Enabled = false;
                        this.State = JFormState.Update;
                    }
                }
                else
                    JMessages.Message(" لطفا ابتدا شخصی را از قراداد قبلی انتخاب کنید ", "", JMessageType.Error);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            } 
        }
    }
}
