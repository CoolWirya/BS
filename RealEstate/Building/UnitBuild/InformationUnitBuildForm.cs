using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Estates;

namespace RealEstate
{
    public partial class JInformationUnitBuildForm : ClassLibrary.JBaseForm
    {
        DataTable _dt = new DataTable();
        private int _UnitBuildCode;
        public JInformationUnitBuildForm()
        {
            InitializeComponent();
        }

        public JInformationUnitBuildForm(int pCode)
        {
            InitializeComponent();
            _dt = JInformationUnitBuild.GetDataTable(pCode);
            jdgvTel.DataSource = _dt;
            jdgvTel.Columns[0].Visible = false;
            jdgvTel.Columns[1].Visible = false;
            jdgvTel.Columns[2].ReadOnly = true;
            _UnitBuildCode = pCode;
        }
        
        private void JInformationUnitBuildForm_Load(object sender, EventArgs e)
        {
            //  ---------------------- Set ComboBox Urgency --------------------------
            cmbTitle.DisplayMember = "FarsiName";
            cmbTitle.ValueMember = "value";
            cmbTitle.DataSource = ClassLibrary.Domains.JGlobal.JTelType.GetData();
            cmbTitle.SelectedValue = ClassLibrary.Domains.JGlobal.JTelType.Tel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckControl
                if (txtTel.Text == "")
                {
                    JMessages.Error("لطفا تلفن را وارد کنید", "error");
                    txtTel.Focus();
                    return ;
                }
                //if (txtCodeTel.Text == "")
                //{
                //    JMessages.Error("لطفا کد شهر را وارد کنید", "error");
                //    txtCodeTel.Focus();
                //    return ;
                //}
                #endregion
                if (!(chkDefault.Checked && (_dt.Select("DefaultValue=True").Length == 0)))
                {
                    JMessages.Message("شماره پیش فرض فقط یکی می تواند ثبت شود ", "", JMessageType.Information);
                    return;
                }
                if ((((_dt.Rows.Count > 0) && (_dt.Select("Tel='" + txtTel.Text + "'").Length < 1)) || (_dt.Rows.Count == 0)))
                {
                    DataRow dr = _dt.NewRow();
                    dr["Tel"] = txtTel.Text;
                    dr["TelType"] = cmbTitle.SelectedValue;
                    dr["TitleType"] = cmbTitle.Text;
                    dr["DefaultValue"] = chkDefault.Checked;
                    _dt.Rows.Add(dr);
                    jdgvTel.DataSource = _dt;
                    btnSave.Enabled = true;
                }
                else
                    JMessages.Message("Tel is Repeated ", "", JMessageType.Information);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvTel.CurrentRow != null)
                {
                    jdgvTel.Rows.Remove(jdgvTel.CurrentRow);
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
            try
            {
                JInformationUnitBuild tmp=new JInformationUnitBuild();
                if (tmp.InsertUpdate(_UnitBuildCode, _dt))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
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

        private void jdgvTel_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
