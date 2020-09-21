using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ArchivedDocuments;
using ClassLibrary;


namespace ManagementShares
{
    public partial class CandidListForm : ClassLibrary.JBaseForm
    {
        int AssemblyCode;
		int _CompanyCode;
        public CandidListForm(int pCode, int pCompanyCode)
        {
            InitializeComponent();
			_CompanyCode = pCompanyCode;
            AssemblyCode = pCode;
        }

        private void CandidListForm_Load(object sender, EventArgs e)
        {
            JPollings Polling = new JPollings(AssemblyCode);
            DataTable dt = Polling.GetData(0);
            DataTable dt2 = Polling.GetData(0);
            DataTable dt3 = Polling.GetData(0);
            DataTable dt4 = Polling.GetData(0);
            cmb1.DisplayMember = "Title";
            cmb1.ValueMember = "Code";
            cmb2.DisplayMember = "Title";
            cmb2.ValueMember = "Code";
            cmb3.DisplayMember = "Title";
            cmb3.ValueMember = "Code";
            cmb4.DisplayMember = "Title";
            cmb4.ValueMember = "Code";
            cmb1.DataSource = dt;
            cmb2.DataSource = dt2;
            cmb3.DataSource = dt3;
            cmb4.DataSource = dt4;
        }

        private void chkShowAraa_CheckedChanged(object sender, EventArgs e)
        {
            CandidListForm_Load(null,null);
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb1.SelectedValue != null)
            {
				JCountPollings CountPolling = new JCountPollings(Convert.ToInt32(cmb1.SelectedValue), _CompanyCode);
                dgv1.DataSource = CountPolling.GetPollingResultCandida();
                dgv1.Columns["Rowno"].Visible = false;
                dgv1.Columns["PCode"].Visible = false;
                dgv1.Columns["Count_Percent"].Visible = false;
                if (chkShowAraa.Checked)
                {
                    dgv1.Columns["VoteCount"].Visible = true;
                    dgv1.Columns["Percent"].Visible = true;                    
                }
                else
                {
                    dgv1.Columns["VoteCount"].Visible = false;
                    dgv1.Columns["Percent"].Visible = false;
                    dgv1.Columns["Count_Percent"].Visible = false;
                }
            }
            else
                gb1.Visible = false;
        }

        private void cmb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb2.SelectedValue != null)
            {
                JCountPollings CountPolling = new JCountPollings(Convert.ToInt32(cmb2.SelectedValue),_CompanyCode);
                dgv2.DataSource = CountPolling.GetPollingResultCandida();
                dgv2.Columns["Rowno"].Visible = false;
                dgv2.Columns["PCode"].Visible = false;
                dgv2.Columns["Count_Percent"].Visible = false;
                if (chkShowAraa.Checked)
                {
                    dgv2.Columns["VoteCount"].Visible = true;
                    dgv2.Columns["Percent"].Visible = true;
                }
                else
                {
                    dgv2.Columns["VoteCount"].Visible = false;
                    dgv2.Columns["Percent"].Visible = false;
                    dgv2.Columns["Count_Percent"].Visible = false;
                }
            }
            else
                gb2.Visible = false;
        }

        private void cmb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb3.SelectedValue != null)
            {
                JCountPollings CountPolling = new JCountPollings(Convert.ToInt32(cmb3.SelectedValue),_CompanyCode);
                dgv3.DataSource = CountPolling.GetPollingResultCandida();
                dgv3.Columns["Rowno"].Visible = false;
                dgv3.Columns["PCode"].Visible = false;
                dgv3.Columns["Count_Percent"].Visible = false;
                if (chkShowAraa.Checked)
                {
                    dgv3.Columns["VoteCount"].Visible = true;
                    dgv3.Columns["Percent"].Visible = true;
                }
                else
                {
                    dgv3.Columns["VoteCount"].Visible = false;
                    dgv3.Columns["Percent"].Visible = false;
                    dgv3.Columns["Count_Percent"].Visible = false;
                }
            }
            else
                gb3.Visible = false;
        }

        private void cmb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb4.SelectedValue != null)
            {
                JCountPollings CountPolling = new JCountPollings(Convert.ToInt32(cmb4.SelectedValue),_CompanyCode);
                dgv4.DataSource = CountPolling.GetPollingResultCandida();
                dgv4.Columns["Rowno"].Visible = false;
                dgv4.Columns["PCode"].Visible = false;
                dgv4.Columns["Count_Percent"].Visible = false;
                if (chkShowAraa.Checked)
                {
                    dgv4.Columns["VoteCount"].Visible = true;
                    dgv4.Columns["Percent"].Visible = true;
                }
                else
                {
                    dgv4.Columns["VoteCount"].Visible = false;
                    dgv4.Columns["Percent"].Visible = false;
                    dgv4.Columns["Count_Percent"].Visible = false;
                }
            }
            else
                gb4.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmb1_SelectedIndexChanged(null, null);
            cmb2_SelectedIndexChanged(null, null);
            cmb3_SelectedIndexChanged(null, null);
            cmb4_SelectedIndexChanged(null, null);
        }
    }
}
