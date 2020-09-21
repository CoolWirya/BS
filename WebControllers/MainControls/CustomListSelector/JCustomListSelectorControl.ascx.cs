using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls
{
    public partial class JCustomListSelectorControl : System.Web.UI.UserControl
    {
        // public event EventHandler<SearchEventArgs> OnSelectedCodeChanged;
        public event EventHandler OnSelectedCodeChanged;

        public class SearchEventArgs : EventArgs
        {
            public int SelectedCode { get; set; }
            public string SelectedTitle { get; set; }
        }

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

        public bool isReadOnly
        {
            set
            {
                if (value == true)
                    btnSearch.Visible = false;
                else
                    btnSearch.Visible = true;
            }
        }

        public string Title
        {
            get
            {
                return txtTitle.Text;
            }
        }

        public int Code
        {
            get
            {
                int d;
                int.TryParse(txtCode.Text, out d);
                return d;
            }
            set
            {
                if (value > 0)
                {
                    txtCode.Text = value.ToString();
                    txtTitle.Text = (new ClassLibrary.JAllPerson(value)).Name;
                    LoadFields();
                }
            }
        }

        public bool IsRequired
        {
            get
            {
                return RequiredFieldValidator1.Enabled;
            }
            set
            {
                RequiredFieldValidator1.Enabled = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return RequiredFieldValidator1.ValidationGroup;
            }
            set
            {
                RequiredFieldValidator1.ValidationGroup = value;
            }
        }

        public string SQL
        {
            get
            {
                return hfd.Value;//ClassLibrary.JEnryption.DecryptStr(hfd.Value, WebClassLibrary.SessionManager.Current.SessionID);
            }

            set
            {
                hfd.Value = value;//ClassLibrary.JEnryption.EncryptStr(value, WebClassLibrary.SessionManager.Current.SessionID);
                LoadFields();
            }
        }

        public string SearchFields
        {
            get
            {
                return ClassLibrary.JEnryption.DecryptStr(hfdfields.Value, WebClassLibrary.SessionManager.Current.SessionID);
            }
            set
            {
                hfdfields.Value = ClassLibrary.JEnryption.EncryptStr(value, WebClassLibrary.SessionManager.Current.SessionID);
            }
        }

        public void LoadFields()
        {
            if (Code > 0 && SQL != "")
            {
                DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT top 1 [Title] FROM (" + SQL + ") weberp_customsearch_1 WHERE Code=" + Code, false);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtTitle.Text = dt.Rows[0][0].ToString();
                }
            }
        } 

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            #region txtCode_Settings
            JJson.JsonResponse txtCode_res = new JJson.JsonResponse();
            txtCode_res.Type = JJson.JsonResponseType.Item;
            txtCode_res.Params = new List<JJson.JsonResponseParam>();
            txtCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtTitle.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            txtCode.OnSuccessControlsAction = new List<JJson.JsonResponse>() { txtCode_res };
            JJson.JsonRequest txtCode_req = new JJson.JsonRequest();
            txtCode_req.URL = "WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/Run";////GetTitleByCode";
            txtCode_req.Type = JJson.JsonRequestType.SQL;
            txtCode_req.data = "Select title From (@sql) weberp_tbl_customlistview_1 Where Code =@code";
            txtCode_req.Params = new List<JJson.JsonRequestParam>();
            txtCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@code", Type = JJson.JsonAction.Value, ControlID = txtCode.ClientID });
            txtCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@sql", Type = JJson.JsonAction.Value, ControlID = hfd.ClientID });
            txtCode.Request = new List<JJson.JsonRequest>() { txtCode_req };
            JJson.JsonResponse txtCode_error = new JJson.JsonResponse();
            txtCode_error.Params = new List<JJson.JsonResponseParam>();
            txtCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            txtCode.OnErrorControlsAction = new List<JJson.JsonResponse>() { txtCode_error };
            #endregion
            if (OnSelectedCodeChanged != null)
                OnSelectedCodeChanged(Page, e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //OnSelectedCodeChanged+=JCustomListSelectorControl_OnSelectedCodeChanged;
            hdnUid.Value = "CustomSearch" + WebClassLibrary.JWebManager.GetSUID() + ClassLibrary.JEnryption.EncryptStr(SQL);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Creating Unique ID For Control
            string uId = WebClassLibrary.JWebManager.ResolveQueryStringValue("CustomSearch" + WebClassLibrary.JWebManager.GetSUID() + Title, "_");
            // Creating and saving new instance of JCustomListSelector needed for JCustomListView Control
            JCustomListSelector jCustomListSelector = new JCustomListSelector(uId);
            jCustomListSelector.CodeElementID = txtCode.ClientID;
            jCustomListSelector.TitleElementID = txtTitle.ClientID;
            jCustomListSelector.SQL = SQL;
            jCustomListSelector.SearchFields = SearchFields;
            jCustomListSelector.Title = "جستجو";

            jCustomListSelector.SessionSave();

            WebClassLibrary.JWebManager.LoadControl(uId, "~/WebControllers/MainControls/CustomListSelector/JCustomListViewControl.ascx"
                , "Search", new List<Tuple<string, string>>() { new Tuple<string, string>("ControlToSet", ControlToSet), new Tuple<string, string>("PropertyToSet", PropertyToSet)
                    , new Tuple<string, string>("ExtraField", ExtraField) }, WebClassLibrary.WindowTarget.NewWindow, true, false, false, 500, 400);
        }

        protected void txtCode_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("Select title From (" + SQL + ") weberp_tbl_customlistview_1 Where Code =" + txtCode.Text, true);
            if (dt != null && dt.Rows.Count != 0)
                txtTitle.Text = dt.Rows[0]["title"].ToString();
            else
            {
                txtCode.Text = string.Empty;
                txtTitle.Text = string.Empty;
            }
        }

        protected void btnUnSelect_Click(object sender, EventArgs e)
        {
            Code = 0;
            txtCode.Text = "";
            txtTitle.Text = "";
        }

        public void Clear()
        {
            txtTitle.Text = string.Empty; txtCode.Text = string.Empty;
        }
    }
}