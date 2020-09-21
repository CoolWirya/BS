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
    public partial class JCommissionForm : ClassLibrary.JBaseForm
    {
        private int _Code;
        public JLegislation tmpLeg;
        DataTable _dtLegCom;
        DataTable _dtPerson;

        public JCommissionForm()
        {
            InitializeComponent();
            tmpLeg = new JLegislation();
            PatternDt();
        }
        public JCommissionForm(int pCode)
        {
            InitializeComponent();
            tmpLeg = new JLegislation(pCode);
            _Code = pCode;
            PatternDt();
        }

        private void GetPattern()
        {
            try
            {
                if (_Code > 0)
                    _dtLegCom = JLegCommission.GetDataTable(_Code);
                else
                    _dtLegCom = JLegCommission.GetDataTable(-1);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void PatternDt()
        {
            _dtPerson = JCommissionPersonss.GetDataTableWithCode(-1);
        }

        private void SetForm()
        {
            JCommission tmp = new JCommission(_Code);
            txtName.Text = tmp.Name;
            jdgvProgram.DataSource = _dtLegCom;

            _dtPerson = JCommissionPersonss.GetDataTableWithCode(_Code);
            jdgvVicarious.DataSource = _dtPerson;
            btnSave.Enabled = false;
        }

        private bool SaveLeg()
        {
            JCommission tmp = new JCommission();
            tmp.Name = txtName.Text.Trim();
            tmp.Code = _Code;
            if (this.State == JFormState.Update)
            {
                if (tmp.Update(_dtLegCom))
                {
                    return true;
                    //JMessages.Information("Save Successfuly", "Information");
                    //Close();
                }
                else
                {
                    JMessages.Error("Save Not Successfuly", "error");
                    return false;
                }
            }
            else
            {
                _Code = tmp.Insert(_dtLegCom);
                if (_Code > 0)
                {
                    return true;
                    //JMessages.Information("Save Successfuly", "Information");
                    //Close();
                }
                else
                {
                    JMessages.Error("Save Not Successfuly", "error");
                    return false;                    
                }
            }
        }

        private void JCommissionForm_Load(object sender, EventArgs e)
        {
            GetPattern();

            JSubBaseDefines LegGroup = new JSubBaseDefines(JBaseDefine.LegislationGroupType);
            LegGroup.SetComboBox(cmbGroup, tmpLeg.LegislationGroup);


            if (State == JFormState.Update)
                SetForm();
        }

        private void btnDelProgram_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvProgram.CurrentRow != null)
                {
                    jdgvProgram.Rows.Remove(jdgvProgram.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((((_dtLegCom.Rows.Count > 0) && (_dtLegCom.Select(" LegislationGroup=" + cmbGroup.SelectedValue.ToString()).Length < 1)) || (_dtLegCom.Rows.Count == 0)))
                {
                    DataRow dr = _dtLegCom.NewRow();
                    //dr["Code"] = cmbGroup.SelectedValue;
                    dr["LegislationGroup"] = cmbGroup.SelectedValue;
                    dr["Name"] = cmbGroup.Text;
                    _dtLegCom.Rows.Add(dr);
                    jdgvProgram.DataSource = null;
                    jdgvProgram.DataSource = _dtLegCom;
                    btnSave.Enabled = true;
                }
                else
                    JMessages.Message("مصوبه تکراری است ", "", JMessageType.Information);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
        private bool Save()
        {
            if (SaveLeg())
            {
                JCommissionPersons tmpCommissionPerson = new JCommissionPersons();
                //---------ویرایش------------
                if (State == JFormState.Update)
                {
                    //----------Update Archive------------
                    tmpCommissionPerson.Code = _Code;
                    if (tmpCommissionPerson.Update(_dtPerson, Convert.ToInt32(_Code)))
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                }
                else
                {
                    if (tmpCommissionPerson.Update(_dtPerson, Convert.ToInt32(_Code)))
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
            else
                return false;
        }

        //private void SetForm()
        //{
        //    //cmbCommission.SelectedValue = _Code;
        //    _dtPerson = JCommissionPersonss.GetDataTableWithCode(_Code);
        //    jdgvVicarious.DataSource = _dtPerson;
        //    btnSave.Enabled = false;
        //}

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

    }
}
