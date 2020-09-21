using System;
using ProjectManagement;

namespace WebProjectManagement.Forms
{
    public partial class MainPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                System.Data.DataTable dt = ProjectManagement.Project.JProjects.GetDataTable(true);
                ProjectManagement.MixedObjects.ItemAndProjectDetails i;
                if (dt == null) return;
                System.Data.DataTable temp = new System.Data.DataTable();
                temp.Columns.Add("code");
                temp.Columns.Add("parentCode");
                temp.Columns.Add("name");
                temp.Columns.Add("improvePercent");
                temp.Columns.Add("description");
                temp.Columns.Add("improvementPercent");
                temp.Rows.Add("-1", null, "سامانه مدیریت پروژه الهیه", 100,"","");
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    i = new ProjectManagement.MixedObjects.ItemAndProjectDetails(-1, dr["Code"].ToString().ToInt32());
                    if (i.Project == null || i.Project.Code==0) continue;
                    temp.Rows.Add(i.Project.Code.ToString(),-1, i.Project.Name, 15+i.TotalReportedPercentage, i.Project.ProjectDescription,"("+i.TotalReportedPercentage.ToString("0.00")+"%)");
                }
                TreeMap1.DataFieldID = "code";
                TreeMap1.DataFieldParentID = "parentCode";
                TreeMap1.DataTextField = "name";
                TreeMap1.DataValueField = "improvePercent";
                TreeMap1.DataSource = temp;
                TreeMap1.Colors.Remove(System.Drawing.Color.White);
                TreeMap1.DataBind();
            }
        }
    }
}