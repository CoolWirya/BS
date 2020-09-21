using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Janus.Windows.GridEX;

namespace Employment
{
    public partial class JSearchVacationForm : JBaseForm
    {

        int _Type;
        bool Koli = false;
        int pCode=0;

        public JSearchVacationForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pCode =  Convert.ToInt32(cmbRequester.SelectedValue);
            if (Koli)
            {
                pCode = 0;
                Koli = false;
            }
            if (cmbType.SelectedIndex == 0)
            {
                JVacationHour tmp = new JVacationHour();
                tmp.Date = txtStartDate.Date;
                tmp.pCode =pCode;
                jgrSearch.DataSource = tmp.Search(txtEndDate.Date);
                _Type = 0;
            }
            if (cmbType.SelectedIndex == 1)
            {
                JVacationDaily tmp = new JVacationDaily();
                tmp.StartDate = txtStartDate.Date;
                tmp.EndDate = txtStartDate2.Date;
                tmp.pCode = pCode;
                jgrSearch.DataSource = tmp.Search(txtEndDate.Date, txtEndDate2.Date);
                _Type = 1;
            }
            if (cmbType.SelectedIndex == 2)
            {
                JConfirmWork tmp = new JConfirmWork();
                tmp.Date = txtStartDate.Date;
                tmp.pCode = pCode;
                if(chkNoAbsent.Checked)
                    tmp.NoAbsent = true;
                if (chkOverTime.Checked)
                    tmp.OverTime = true;
                jgrSearch.DataSource = tmp.Search(txtEndDate.Date);
                _Type = 2;
            }
        }

        private void SearchVacationForm_Load(object sender, EventArgs e)
        {
            //cmbRequester.DisplayMember = "Name";
            //cmbRequester.ValueMember = "Code";
            //cmbRequester.DataSource = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
                //JVacationHour.GetUserReport(); 
            //  ---------------------- Set ComboBox Sender --------------------------
            cmbRequester.DisplayMember = "full_title";
            cmbRequester.ValueMember = "pCode";
            DataTable dt = JEmployeeInfos.GetDataTable(0,"");
            DataRow dr = dt.NewRow();
            dr["full_title"] = "-----------------";
            dr["pCode"] = -1;
            dt.Rows.Add(dr);
            cmbRequester.DataSource = dt;

            cmbType.SelectedIndex = 0;
            btnKoli_Click(null,null);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                grbDaily.Enabled = false;
                grbWork.Enabled = false;
            }
            if (cmbType.SelectedIndex == 1)
            {
                grbDaily.Enabled = true;
                grbWork.Enabled = false;
            }
            if (cmbType.SelectedIndex == 2)
            {
                grbDaily.Enabled = false;
                grbWork.Enabled = true;
            }
        }

        private void jgrSearch_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (e.Row.DataRow != null)
            {
                if (_Type == 0)
                {
                    JVacationHourForm p = new JVacationHourForm(Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[0]), 0);
                    p.State = JFormState.Update;
                    p.ShowDialog();
                    //btnSearch_Click(null,null);
                    TypeSearch();
                }
                if (_Type == 1)
                {
                    JVacationDailyForm p = new JVacationDailyForm(Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[0]), 0);
                    p.State = JFormState.Update;
                    p.ShowDialog();
                    //btnSearch_Click(null, null);
                    TypeSearch();
                }
                if (_Type == 2)
                {
                    JConfirmWorkFrom p = new JConfirmWorkFrom(Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[0]), 0);
                    p.State = JFormState.Update;
                    p.ShowDialog();
                    //btnSearch_Click(null, null);
                    TypeSearch();
                }
            }
            else
                JMessages.Message("Please Selected Item ", "", JMessageType.Information);
        }

        private void btnKoli_Click(object sender, EventArgs e)
        {
            if (JPermission.CheckPermission("Employment.JSearchVacationForm.btnKoli_Click", false))
            {
                btnKoli.Visible = true;
                Koli = true;
                btnSearch_Click(null, null);
            }
        }
        private void TypeSearch()
        {
            if (pCode==0)
                btnKoli_Click(null,null);
            else
                btnSearch_Click(null, null);
        }
    }
}
