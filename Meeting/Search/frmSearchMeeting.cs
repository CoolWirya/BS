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

namespace Meeting
{
    public partial class JfrmSearchMeeting : ClassLibrary.JBaseForm
    {
        public JfrmSearchMeeting()
        {
            InitializeComponent();
        }

        private void FillMeeting()
        {
            DataTable dtCommission = new DataTable();
            dtCommission = JCommissions.GetDataTable(0);
            DataRow dr = dtCommission.NewRow();
            dr["Code"] = -1;
            dr["name"] = "-----------";
            dtCommission.Rows.Add(dr);
            cmbCommissionCode.DisplayMember = "Name";
            cmbCommissionCode.ValueMember = "Code";
            cmbCommissionCode.DataSource = dtCommission;
            cmbCommissionCode.SelectedValue = -1;

            //DataTable dtLeg1Flow = new DataTable();
            //dtLeg1Flow = ClassLibrary.Domains.JGlobal.JStatus.GetData();
            //DataRow dr1 = dtLeg1Flow.NewRow();
            //dr1["value"] = -1;
            //dr1["FarsiName"] = "-----------";
            //dr1["name"] = "-----------";
            //dtLeg1Flow.Rows.Add(dr1);
            //MetLeg1Flow.DisplayMember = "FarsiName";
            //MetLeg1Flow.ValueMember = "value";
            //MetLeg1Flow.DataSource = dtLeg1Flow;
            //MetLeg1Flow.SelectedValue = -1;

            JSubBaseDefines LegGroup = new JSubBaseDefines(JBaseDefine.LegislationGroupType);
            JLegislation tmpLeg = new JLegislation();
            LegGroup.SetComboBox(cmbLegislationGroup, tmpLeg.LegislationGroup);
        }

        private void frmSearchMeeting_Load(object sender, EventArgs e)
        {
            FillMeeting();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Where = "1=1 ";
            if (Convert.ToInt32(cmbCommissionCode.SelectedValue) != -1)
                Where = Where + " And CommissionCode=" + cmbCommissionCode.SelectedValue.ToString();
            if(txtDate.Date != DateTime.MinValue)
                Where = Where + " And Date >= '" + txtDate.Date.ToString() + "'";
            if (txtDate2.Date != DateTime.MinValue)
                Where = Where + " And Date <= '" + txtDate2.Date.ToString() + "'";
            if (txtSubject.Text.Trim() != "")
                Where = Where + " And Subject like '%" + txtSubject.Text.Trim() + "%'";
            if (txtLocation.Text.Trim() != "")
                Where = Where + " And Location Like '%" + txtLocation.Text.Trim() + "%'";
            string WhereLeg = "1=1 ";
            if (Convert.ToInt32(cmbLegislationGroup.SelectedValue) > 1)
                Where = Where + " And LegislationGroup=" + cmbCommissionCode.SelectedValue.ToString();
            if (txtLegislation.Text.Trim() != "")
                Where = Where + " And Legislation '%" + txtLegislation.Text.Trim() + "%'";
            //if(PersonCode.SelectedCode != 0)
            //    Where = Where + " And PersonCode=" + PersonCode.SelectedCode.ToString();
            JSearch p = new JSearch();
            DataTable dt = p.Find(Where, WhereLeg);
            jdgvSearch.DataSource = dt;
            jdgvSearch.bind(dt, "JanusSearchMeeting", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);

        }

        private void jdgvSearch_OnRowDBClick(object Sender, RowActionEventArgs e)
        {
            if (e.Row.DataRow != null)
            {
                JLegMeetingForm tmp = new JLegMeetingForm(Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[0]));
                tmp.State = JFormState.Update;
                tmp.ShowDialog();
            }
            else
                JMessages.Message("Please Selected Item ", "", JMessageType.Information);
        }
    }
}
