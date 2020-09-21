using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment.Defined.OrganizationChart
{
    public partial class JEfrmOrganizationChartMove : JBaseForm
    {
        BindingSource _BindingSource = new BindingSource();
        int _UserPostCode;

        public JEfrmOrganizationChartMove(int UserPostCode)
        {
            InitializeComponent();
            _UserPostCode = UserPostCode;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrganizationChartMove_Load(object sender, EventArgs e)
        {
            JEOrganizationChart jeOrg = new JEOrganizationChart(_UserPostCode);
            lblPerson.Text = jeOrg.full_title;
            jeOrg.GetData(jeOrg.parentcode);
            lblParent.Text = "زیر مجموعه " + jeOrg.full_title;

            _BindingSource.DataSource = JEOrganizationChart.GetUserPosts();
            dgrList.DataSource = _BindingSource;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _BindingSource.Filter = string.Format("Title LIKE '%{0}%'", txtSearch.Text.Replace("'", "''"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgrList.SelectedRows.Count == 0) return;
            JEOrganizationChart jeOrg = new JEOrganizationChart(_UserPostCode);
            jeOrg.parentcode = Convert.ToInt32(dgrList.SelectedRows[0].Cells["Code"].Value);
            if (jeOrg.parentcode == jeOrg.code) return;
            if (jeOrg.UpdateNode())
            {
                JMessages.Information(lblPerson.Text + "\r\n از \r\n" + lblParent.Text + "\r\n به \r\n" + dgrList.SelectedRows[0].Cells["Title"].Value.ToString() + "منتقل شد.", "انتقال پست سازمانی");
                this.Close();
            }
            else
                JMessages.Error("عملیات با خطا مواجه شد.", "انتقال پست سازمانی");
        }
    }
}
