using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace Automation
{
    public partial class JSuccessorForm : Globals.JBaseForm
    {
        public JSuccessorForm()
        {
            InitializeComponent();
        }

        private void Set_Data()
        {            
            DataTable dt = JSuccessor.GetDataTable(0);
            jdgvSuccessor.DataSource = dt;
            jdgvSuccessor.bind(dt, "JanusSuccessor", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
        }

        private void JSuccessorForm_Load(object sender, EventArgs e)
        {
            //-------------- ارجاعات داخل سازمانی ----------
            cdbReferInternal.TitleFieldName = "full_title";
            cdbReferInternal.AccessCodeFieldName = "accesscode";
            cdbReferInternal.CodeFieldName = "code";
            cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
            cdbReferInternal.SetComboBox();
            Set_Data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cdbReferInternal.SelectedItem["code"]) == -1)
            {
                JMessages.Message("لطفا جانشین را انتخاب کنید", "", JMessageType.Information);
                return;
            }
            if(txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Message("لطفا تاریخ شروع را وارد کنید", "", JMessageType.Information);
                return;
            }
            if (txtEndDate.Date == DateTime.MinValue)
            {
                JMessages.Message("لطفا تاریخ پایان را وارد کنید", "", JMessageType.Information);
                return;
            }
            JSuccessor tmpSuccessor = new JSuccessor();
            tmpSuccessor.Successer_post_code = Convert.ToInt32(cdbReferInternal.SelectedItem["code"]);
            tmpSuccessor.Person_post_code = JMainFrame.CurrentPostCode;
            tmpSuccessor.Start_date_time = txtStartDate.Date;
            tmpSuccessor.End_date_time = txtEndDate.Date;
            if (tmpSuccessor.Insert() > 0)
                JMessages.Message("ثبت با موفقیت انجام شد","", JMessageType.Information);
            else
                JMessages.Message("ثبت با موفقیت انجام نشد", "", JMessageType.Information);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jdgvSuccessor.SelectedRow != null)
            {
                JSuccessor tmpSuccessor = new JSuccessor();
                tmpSuccessor.Code = Convert.ToInt32(jdgvSuccessor.SelectedRow[0].ToString());
                tmpSuccessor.Delete();
            }
        }
    }
}
