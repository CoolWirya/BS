using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls
{
    public partial class JCustomListViewControl : System.Web.UI.UserControl
    {
        public JCustomListSelector CustomListSelector;

        public string ControlToSet
        {
            get
            {
                if (ViewState["ControlToSet"] != null)
                    return ViewState["ControlToSet"].ToString();
                return "";
            }
            set
            {
                ViewState["ControlToSet"] = value;
            }
        }

        public string PropertyToSet
        {
            get
            {
                if (ViewState["PropertyToSet"] != null)
                    return ViewState["PropertyToSet"].ToString();
                return "";
            }
            set
            {
                ViewState["PropertyToSet"] = value;
            }
        }

        public string ExtraField
        {
            get
            {
                if (ViewState["ExtraField"] != null)
                    return ViewState["ExtraField"].ToString();
                return "";
            }
            set
            {
                ViewState["ExtraField"] = value;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            Telerik.Web.UI.RadAjaxManager manager = Telerik.Web.UI.RadAjaxManager.GetCurrent(Page);
            //manager.ClientEvents.OnRequestStart = "onRequestStart";
            //manager.ClientEvents.OnResponseEnd = "onResponseEnd";
            if (!string.IsNullOrEmpty(Request["ControlToSet"]))
                ControlToSet = Request["ControlToSet"];
            if (!string.IsNullOrEmpty(Request["PropertyToSet"]))
                PropertyToSet = Request["PropertyToSet"];
            if (!string.IsNullOrEmpty(Request["ExtraField"]))
                ExtraField = Request["ExtraField"];
            manager.AjaxRequest += manager_AjaxRequest;
            JCustomListSelectorControl s = new JCustomListSelectorControl();
            s.OnSelectedCodeChanged += btnSelect_Click;
        }

        void manager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            //CustomListSelector = new JCustomListSelector(WebClassLibrary.JWebManager.GetSUID());
            //if (Request.Form["EventType"] == "GridRowDblClick")
            //{
            //    string index = Request.Form["radGridClickedRowIndex"].ToString();
            //    int personCode = Convert.ToInt32(grdList.Items[Convert.ToInt32(index)]["Code"].Text);
            //    string personName = grdList.Items[Convert.ToInt32(index)]["Name"].Text;
            //    WebClassLibrary.JWebManager.RunClientScript(new List<string>()
            //    {
            //        //"{Parent}.getElementById('" + PersonList.PersonCodeElementID + "').value = '" + personCode + "';",
            //        //"{Parent}.getElementById('" + PersonList.PersonNameElementID + "').value = '" + personName + "';",
            //        "{CloseWindow};"
            //    }, "SendPersonInfo", true);
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CustomListSelector = new JCustomListSelector(WebClassLibrary.JWebManager.GetSUID());
            string search_query = "";
            if (CustomListSelector.SearchFields == "") search_query += "[Title] Like N'%{VALUE}%'";
            else
            {
                foreach (string item in CustomListSelector.SearchFields.Split(','))
                {
                    search_query += "OR [" + item + "] Like N'%{VALUE}%'";
                }
                search_query = search_query.Substring(2);
            }
            search_query = search_query.Replace("{VALUE}", txtSearch.Text.Replace("'", "''"));
            Hfsearch_query.Value = search_query;
            grdList.DataSource = WebClassLibrary.JWebDataBase.GetDataTable("Select * From (" + CustomListSelector.SQL + ") weberp_tbl_customlistview_1 Where " + search_query, true);
            grdList.Rebind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            CustomListSelector = new JCustomListSelector(WebClassLibrary.JWebManager.GetSUID());
            string index = Request.Form["radGridClickedRowIndex"].ToString();
            if (index == "") return;
            string code = grdList.Items[Convert.ToInt32(index)]["Code"].Text;
            string title = grdList.Items[Convert.ToInt32(index)]["Title"].Text;
            string extra = string.Empty;
            //if (!string.IsNullOrEmpty(ExtraField))
            //    extra = grdList.MasterTableView.FindItemByKeyValue("Code", code)[ExtraField].Text;

            WebClassLibrary.JWebManager.RunClientScript(new List<string>()
                {
                    "{Parent}.document.getElementById('" + CustomListSelector.CodeElementID + "').value = '" + code + "';",
                    "{Parent}.document.getElementById('" + CustomListSelector.TitleElementID + "').value = '" + title + "';",
                    ControlToSet!=""&&PropertyToSet!=""?("{Parent}.document.getElementById('" + ControlToSet + "')."+PropertyToSet +"= '" + extra + "';"):"",
                    "{CloseWindow};"
                }, "SendPersonInfo", true);
        }

        protected void grdList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            CustomListSelector = new JCustomListSelector(WebClassLibrary.JWebManager.GetSUID());
            if (Hfsearch_query.Value != string.Empty)
            {
                DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("Select * From (" + CustomListSelector.SQL + ") weberp_tbl_customlistview_1 Where " + Hfsearch_query.Value, true);
                grdList.DataSource = dt;
            }
        }

        protected void grdList_PreRender(object sender, EventArgs e)
        {
            if (grdList.DataSource == null) return;
            foreach (DataColumn col in (grdList.DataSource as DataTable).Columns)
                grdList.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
            grdList.MasterTableView.Rebind();
        }

    }
}