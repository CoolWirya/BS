using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JCountPollingForm : ClassLibrary.JBaseForm
    {
        int _PollingCode;
        public int _AssemblyCode;
        int _PollingCountCode;
        public DataTable selectedTable;
        private JPolling _Polling;
		int _CompanyCode;

        public JCountPollingForm(int PollingCountCode, int pCompanyCode,string P)
        {
            InitializeComponent();
			_CompanyCode = pCompanyCode;
            _PollingCountCode = PollingCountCode;
            ShowData();
            LoadCandida();
            txtVoteNo.Enabled = false;
        }
        private void ShowData()
        {
			JCountPolling count = new JCountPolling(_PollingCountCode, _CompanyCode);
            txtVoteNo.Text = count.VoteNo.ToString();
            txtRightCount.Text = count.RightCount.ToString();
            txtSahamdari.Text = count.PCode.ToString();
            _PollingCode = count.PollingCode;
            _Polling = new JPolling(_PollingCode);
            selectedTable = new DataTable();
            selectedTable = count.GetSelectedChoice();
            grdSelected.DataSource = selectedTable;
            grdSelected.Columns["SelectedCode"].Visible = false;
            btnSaveVote.Enabled = false;
            btnSaveVote.Enabled = false;
        }
        public JCountPollingForm(int PollingCode, int assemblyCode, int pCompanyCode)
        {
            InitializeComponent();
			_CompanyCode = pCompanyCode;
            _PollingCode = PollingCode;
            _AssemblyCode = assemblyCode;
            selectedTable = new DataTable();
            selectedTable.Columns.Add("SelectedCode");
            selectedTable.Columns.Add("Title");
            _Polling = new JPolling(_PollingCode);
            JCountPollings polling = new JCountPollings(_PollingCode,_CompanyCode);
            txtVoteNo.Text = polling.GetNextVoteNo().ToString();
            LoadCandida();
        }
        private void LoadCandida()
        {
            JPollingCandidas polling = new JPollingCandidas();
            cmbCandidas.DataSource = polling.GetData(_PollingCode, 0);
            cmbCandidas.ValueMember = "Code";
            cmbCandidas.DisplayMember = "Title";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRightCount.IntValue == 0)
            {
                JMessages.Error("لطفا تعداد حق رأی را وارد کنید.", "");
                return;
            }
            if (txtVoteNo.IntValue == 0)
            {
                JMessages.Error("لطفا شماره برگه را وارد کنید.", "");
                return;
            }
            if (cmbCandidas.SelectedItem != null)
            {
                if (selectedTable.Rows.Count < _Polling.MainMembers)
                {
                    selectedTable.DefaultView.RowFilter = "SelectedCode=" + cmbCandidas.SelectedValue.ToString();
                    if (selectedTable.DefaultView.ToTable().Rows.Count == 0)
                    {
                        DataRow row = selectedTable.NewRow();
                        row["SelectedCode"] = cmbCandidas.SelectedValue;
                        row["Title"] = cmbCandidas.Text.ToString();
                        selectedTable.Rows.Add(row);
                        selectedTable.DefaultView.RowFilter = "";
                        grdSelected.DataSource = selectedTable;
                        cmbCandidas.Focus();
                    }
                    else
                    {
                        selectedTable.DefaultView.RowFilter = "";
                        JMessages.Error("این گزینه قبلا انتخاب شده است!", "");
                        cmbCandidas.Focus();
                    }
                    btnSaveVote.Enabled = true;
                }
                else
                {
                    JMessages.Error(string.Format("حداکثر تعداد گزینه های انتخابی نباید بیشتر از {0} باشد!", _Polling.MainMembers), "");
                }
            }
            else
            {
                JMessages.Error("لطفا یک گزینه از لیست انتخاب کنید.", "");
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSelected.CurrentRow != null)
                {
                    grdSelected.Rows.Remove(grdSelected.CurrentRow);
                    btnSaveVote.Enabled = true;
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            //if (grdSelected.SelectedRows.Count > 0)
            //{
            //    selectedTable.Rows.Remove((grdSelected.SelectedRows[0].Index);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JCountPollingForm_Shown(object sender, EventArgs e)
        {
            txtSahamdari.Focus();
        }

        private void btnSaveVote_Click(object sender, EventArgs e)
        {
            if (!btnSaveVote.Enabled)
                return;
            if (selectedTable.Rows.Count == 0)
            {
                JMessages.Error("هیچ گزینه ای انتخاب نشده است.", "");
                return;
            }
            #region Check Existing
            JAssemblyPresences presence = new JAssemblyPresences(_AssemblyCode,_CompanyCode);
            if (presence.GetData(txtRightCount.IntValue, false).Rows.Count == 0)
            {
                JMessages.Error("شخصی  با این تعداد حق رأی در مجمع حاضر نیست.", "");
                return;
            }
            if (this.State != JFormState.Update)
            {
                JCountPollings pollings = new JCountPollings(_PollingCode,_CompanyCode);
                if (pollings.CheckExistanceVoteNo(txtVoteNo.IntValue))
                {
                    JMessages.Error("این شماره برگه قبلاً وارد شده است.", "");
                    return;
                }
                if ((txtSahamdari.IntValue != 0) && (pollings.CheckExistancePCode(txtSahamdari.IntValue)))
                {
                    JMessages.Error("این شماره سریال قبلاً وارد شده است.", "");
                    return;
                }
            }
            #endregion Check Existing
            JCountPolling polling = new JCountPolling(_CompanyCode,"");
            polling.PollingCode = _PollingCode;
            polling.RightCount = txtRightCount.IntValue;
            polling.VoteNo = txtVoteNo.IntValue;
            polling.PCode = txtSahamdari.IntValue;

            if (this.State != JFormState.Update)
            {
                if (polling.SaveVote(selectedTable))
                    this.DialogResult = DialogResult.Retry;
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "");
            }
            else if (this.State == JFormState.Update)
            {
                polling.Code = _PollingCountCode;
                if (polling.UpdateVote(selectedTable))
                    JMessages.Information("عملیات ویرایش با موفقیت ثبت شد ", "");
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "");
            }
        }

        private void JCountPollingForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnSaveVote.PerformClick();
            }
        }

        private void txtSahamdari_Leave(object sender, EventArgs e)
        {
            txtRightCount.Text = "0";
            if (txtSahamdari.Text == "")
                return;

			

            ClassLibrary.JAllPerson tmpPerson = new JAllPerson();
			tmpPerson.GetData(ShareCompany.JSharepCode.GetPersonShare(_CompanyCode, txtSahamdari.IntValue));
            if (!(JAssemblyPresence.ExistsSahamdarCode(tmpPerson.Code, _AssemblyCode)))
            {
                if (JMessages.Question(" این شخص غایب است آیا میخواهید در حاضرین بیاید ؟ ", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    JAssemblyPresence presence = new JAssemblyPresence(_CompanyCode,"");
                    presence.ACode = _AssemblyCode;
                    presence.AgentPCode = tmpPerson.Code;
                    presence.PresenceTime = DateTime.Now;
                    //presence.VoteRight = JAssemblyPresences.GetVoteRight(txtSahamdari.IntValue);
                    if (!presence.Exists())
                    {
                        presence.Insert();
                    }
                }
            }

			txtRightCount.Text = JAssemblyPresences.GetVoteRightOfExistingAgents(_AssemblyCode, tmpPerson.Code).ToString();
        }

        private void JCountPollingForm_Load(object sender, EventArgs e)
        {
            txtSahamdari.Focus();
        }

        private void JCountPollingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnSaveVote_Click(null, null);
            }
        }

        private void txtRightCount_TextChanged(object sender, EventArgs e)
        {
            btnSaveVote.Enabled = true;
        }
    }
}
