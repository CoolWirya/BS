using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace Meeting
{
    public partial class JCommissionPersonsForm : ClassLibrary.JBaseForm
    {
        private int _CommissionCode;
        DataTable _dtPerson;

        public JCommissionPersonsForm()
        {
            InitializeComponent();
        }

        public JCommissionPersonsForm(int pCommissionCode)
        {
            InitializeComponent();
            _CommissionCode = pCommissionCode;
            PatternDt();
        }
       
        private void PatternDt()
        {
            _dtPerson = JCommissionPersonss.GetDataTableWithCode(-1);
        }

        private void btnaddClient_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(JPersonTypes.RealPerson,
                     JTableNamesClassLibrary.PersonTable + ".Code IN (SELECT PCode From empcontract WHERE state = 1) ");
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {                    
                        if ((((_dtPerson.Rows.Count > 0) && (_dtPerson.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPerson.Rows.Count == 0)))
                        {
                            DataRow dr = _dtPerson.NewRow();
                            dr["PersonCode"] = p.SelectedPerson.Code;
                            dr["Name"] = p.SelectedPerson.Name;
                            //dr["PersonType"] = p.SelectedPerson.PersonType;
                            _dtPerson.Rows.Add(dr);
                            jdgvVicarious.DataSource = _dtPerson;
                            btnSave.Enabled = true;
                        }
                        else
                            JMessages.Message("Person is Repeat", "", JMessageType.Information);                    
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btndelClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvVicarious.CurrentRow != null)
                {
                    jdgvVicarious.Rows.Remove(jdgvVicarious.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
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

        private bool Save()
        {
            JCommissionPersons tmpCommissionPerson = new JCommissionPersons();
            //---------ویرایش------------
            if (State == JFormState.Update)
            {
                //----------Update Archive------------
                tmpCommissionPerson.Code = _CommissionCode;
                if (tmpCommissionPerson.Update(_dtPerson , Convert.ToInt32(cmbCommission.SelectedValue)))
                {
                    JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                    return true;
                }
                else
                    JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
            }
            else
            {
                if ( tmpCommissionPerson.Update(_dtPerson, Convert.ToInt32(cmbCommission.SelectedValue)))
                //_Code > 0)
                {
                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    return true;
                }
                else
                    JMessages.Message(" Insert Not Successfuly ", "", JMessageType.Error);
            }
            return true;
        }

        private void SetForm()
        {
            cmbCommission.SelectedValue = _CommissionCode;
            _dtPerson = JCommissionPersonss.GetDataTableWithCode(_CommissionCode);            
            jdgvVicarious.DataSource = _dtPerson;
            btnSave.Enabled = false;
        }

        private void JCommissionPersonsForm_Load(object sender, EventArgs e)
        {
            cmbCommission.DisplayMember = "Name";
            cmbCommission.ValueMember = "Code";
            cmbCommission.DataSource = JCommissions.GetDataTable(0);
            PatternDt();
            if (State == JFormState.Update)
            {
                SetForm();
                cmbCommission.Enabled = false;
            }
        }

        private void cmbCommission_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtPerson = JCommissionPersonss.GetDataTableWithCode(Convert.ToInt32(cmbCommission.SelectedValue));
            jdgvVicarious.DataSource = _dtPerson;
            btnSave.Enabled = true;
        }
    }
}
