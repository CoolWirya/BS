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
    public partial class JMeetingForm : ClassLibrary.JBaseForm
    {
        private int _Code;
        private int _Subject;
        DataTable _dtVicarious;

        public JMeetingForm()
        {
            InitializeComponent();
        }

        public JMeetingForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }

        private void PatternDt()
        {
            _dtVicarious = JCommissionPersonss.GetDataTable(-1);
        }

        private void SetForm()
        {

            _dtVicarious = JCommissionPersonss.GetDataTable(_Code);

        }

        private void JMeetingForm_Load(object sender, EventArgs e)
        {
            cmbCommission.DisplayMember = "Name";
            cmbCommission.ValueMember = "Code";
            cmbCommission.DataSource = JCommissions.GetDataTable(0);


            if (State == JFormState.Update)
                SetForm();
        }

        private void cmbCommission_SelectedIndexChanged(object sender, EventArgs e)
        {
            jdgvVicarious.DataSource = JCommissionPersonss.GetDataTable(Convert.ToInt32( cmbCommission.SelectedValue));
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

        private void btnaddClient_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (!((_dtVicarious.Rows.Count != 0) && (Convert.ToInt32(_dtVicarious.Rows[0]["PersonCode"]) == p.SelectedPerson.Code)))
                    {
                        if (_dtVicarious.Rows.Count > 0)
                            jdgvVicarious.Rows.Remove(jdgvVicarious.CurrentRow);

                        if ((((_dtVicarious.Rows.Count > 0) && (_dtVicarious.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtVicarious.Rows.Count == 0)))
                        {
                            DataRow dr = _dtVicarious.NewRow();
                            dr["PersonCode"] = p.SelectedPerson.Code;
                            dr["Name"] = p.SelectedPerson.Name;
                            dr["PersonType"] = p.SelectedPerson.PersonType;
                            _dtVicarious.Rows.Add(dr);
                            jdgvVicarious.DataSource = _dtVicarious;
                            btnSave.Enabled = true;
                        }
                        else
                            JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                    }
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
            //JMeetings tmpMeetings = new JMeetings();
            ////---------ویرایش------------
            //if (State == JFormState.Update)
            //{
            //    //----------Update Archive------------
            //    tmpMeetings.Code = _Code;
            //    if (tmpMeetings.Insert(_dtVicarious) > 0)
            //    {
            //        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
            //        return true;
            //    }
            //    else
            //        JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
            //}
            //else
            //{
            //    if (tmpMeetings.Update(_dtVicarious))
            //    //_Code > 0)
            //    {
            //        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
            //        return true;
            //    }
            //    else
            //        JMessages.Message(" Insert Not Successfuly ", "", JMessageType.Error);
            //}
            return true;
        }
    }
}
