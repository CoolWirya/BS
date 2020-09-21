using Employment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
    public partial class JOrganizationChartUpdateControl : System.Web.UI.UserControl
    {
        int UserPostCode;
        int ParentPostCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["UserPostCode"], out UserPostCode);
            int.TryParse(Request["ParentPostCode"], out ParentPostCode);

            _SetForm();
        }

        private void _SetForm()
        {
            cmbUsers.DataSource = (new Globals.JUsers()).GetUserList();
            cmbUsers.DataTextField = "fullname";
            cmbUsers.DataValueField = "code";
            cmbUsers.DataBind();

            cmbJobs.DataSource = (new JJobTitle()).GetList();
            cmbJobs.DataTextField = "name";
            cmbJobs.DataValueField = "Code";
            cmbJobs.DataBind();

            cmbPosts.DataSource = (new JPostTitle()).GetList();
            cmbPosts.DataTextField = "Title";
            cmbPosts.DataValueField = "Code";
            cmbPosts.DataBind();
            
            cmbSecretariat.DataTextField = "title";
            cmbSecretariat.DataValueField = "code";
            cmbSecretariat.DataSource = (new Communication.JCSecretariat()).GetSecretariat(0, "code , name AS title"); ;
            cmbSecretariat.DataBind();

            if (UserPostCode > 0)
            {
                Employment.JEOrganizationChart orgChart = new JEOrganizationChart(UserPostCode);
                cmbUsers.SelectedValue = orgChart.user_code.ToString();
                cmbPosts.SelectedValue = orgChart.PostTitleCode.ToString();
                cmbJobs.SelectedValue = orgChart.JobTitleCode.ToString();
                cmbSecretariat.SelectedValue = orgChart.secretariat_code.ToString();
                cmbUnit.SelectedValue = orgChart.is_unit == true ? "1" : "0";
            }
        }

        private bool Save()
        {
            if (UserPostCode > 0) // Edit Mode
            {
                Employment.JEOrganizationChart orgChart = new JEOrganizationChart(UserPostCode);
                orgChart.user_code = Convert.ToInt32(cmbUsers.SelectedValue);
                orgChart.PostTitleCode = Convert.ToInt32(cmbPosts.SelectedValue);
                orgChart.JobTitleCode = Convert.ToInt32(cmbJobs.SelectedValue);
                orgChart.is_unit = cmbUnit.SelectedValue == "1" ? true : false;
                orgChart.secretariat_code = Convert.ToInt32(cmbSecretariat.SelectedValue);
                if (orgChart.UpdateNode())
                    return true;
            }
			if (ParentPostCode > 0 || ParentPostCode == -1)
			{
				Employment.JEOrganizationChart orgChart = new JEOrganizationChart();
				if (ParentPostCode > 0)
					orgChart.parentcode = ParentPostCode;
				try
				{
					orgChart.user_code = Convert.ToInt32(cmbUsers.SelectedValue);
				}
				catch
				{
				}
				try
				{
					orgChart.PostTitleCode = Convert.ToInt32(cmbPosts.SelectedValue);
				}
				catch
				{
				}
				try
				{
					orgChart.JobTitleCode = Convert.ToInt32(cmbJobs.SelectedValue);
				}
				catch
				{
				}
				orgChart.is_unit = cmbUnit.SelectedValue == "1" ? true : false;
				try
				{
					orgChart.secretariat_code = Convert.ToInt32(cmbSecretariat.SelectedValue);
				}
				catch
				{
				}
				if (orgChart.InsertNode())
					return true;
			}

            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
            else
                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره سازی اطلاعات وجود ندارد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }
    }
}