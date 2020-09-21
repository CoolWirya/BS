using System;
using System.Collections.Generic;
using ProjectManagement;

namespace WebProjectManagement.Forms
{
    public partial class EnterDataHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int projectCode = Request["ProjectCode"].ToInt32();
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(JWebProjectManagement._ConstClassName.Replace(".", "_") + "_ReportData_history");
            jGridView.ClassName = JWebProjectManagement._ConstClassName.Replace(".", "_") + "._ReportData_history";
            string query = @"select ir.Code,i.Name,u.username as reporter,cast(i.WeightPercentage as numeric(36,2)) as itemProject,ir.ReportDescription,Convert(date,ir.RegisterDate) as RegisterDate,cast(ir.WeightPercentage as numeric(36,2)) as reportPercentage,
cast((ir.WeightPercentage*i.WeightPercentage/100) as numeric(36,2)) as improveProjectPercentage
, ir.HasPic
from pmItemReport ir
inner join pmItems i on i.Code=ir.ItemCode
inner join users u on ir.UserCode=u.code
where i.ProjectCode=" + projectCode;
            jGridView.SQL = query;


            jGridView.Buttons = "Refresh,Print,record_print,PDF,Excel,Word,CSV";
            jGridView.Title = "Items";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, JWebProjectManagement._ConstClassName + "._EditReport", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("Delete", "Delete", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, JWebProjectManagement._ConstClassName + "._DeleteReport", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Delete));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            jGridView.Width = pnlGrid.Width;
            jGridView.Bind();
            pnlGrid.Controls.Add(jGridView);
        }
    }
}