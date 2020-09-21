using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectManagement.Forms
{
    public partial class CustomGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(JWebProjectManagement._ConstClassName.Replace(".", "_") + "_customgrid");
            jGridView.ClassName = JWebProjectManagement._ConstClassName.Replace(".", "_") + "._customgrid";
            string query = @"select * from exceptiontable";
            jGridView.SQL = query;


            jGridView.Title = "_customgrid";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            jGridView.Bind();
            pnldata.Controls.Add(jGridView);
        }
    }
}