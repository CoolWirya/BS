using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using WebControllers.FormManager;
using WebControllers.MainControls.Grid;
using WebControllers.MainControls.ToolBar;

namespace WebBaseDefine
{
    public class JDashboard
    {
        public const string _ConstClassName = "WebBaseDefine.JDashboard";
        private JNode dashboardActionInfoNode = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Dashboard", null, new List<object>() { }) }, "Dashboard", _ConstClassName + "._Dashboard", JDomains.Images.MenuImages.Item, null);
        public static string DashboardActionString
        {
            get
            {
                var temp = new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Dashboard", null, new List<object>() { }) }, "Dashboard", _ConstClassName + "._Dashboard", JDomains.Images.MenuImages.Item, null);
                var actionString = temp.ActionsToString();
                temp.Actions[0] = null;
                temp.Actions.Clear();
                temp = null;
                return actionString;
            }
        }
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(dashboardActionInfoNode);
            return nodes;
        }
        public string _Dashboard()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Dashboard", "~/WebBaseDefine/Dashboard/JDashboardControl.ascx", "داشبورد", null, WindowTarget.NewWindow, false, true, true, 500, 500, true);
        }
    }
    public class JWebBaseDefine
    {
        public static bool isAVL = false;
        public const string _ConstClassName = "WebBaseDefine.JWebBaseDefine";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            //nodes.Add(new JNode(null, "BaseDefine", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            //{
            //    new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JobTitle", null, new List<object>() { }) }, "JobTitle", _ConstClassName, JDomains.Images.MenuImages.Item, null),
            //    new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PostTitle", null, new List<object>() { }) }, "PostTitle", _ConstClassName, JDomains.Images.MenuImages.Item, null)
            //}));
            nodes.Add(new JNode(null, "DefinePersons", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RealPerson", null, new List<object>() { }) }, "RealPersons", _ConstClassName + "._RealPerson", JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LegalPerson", null, new List<object>() { }) }, "LegalPersons", _ConstClassName + "._LegalPerson", JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OtherPerson", null, new List<object>() { }) }, "OtherPersons", _ConstClassName + "._OtherPerson", JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonAccount", null, new List<object>() { }) }, "PersonAccount", _ConstClassName + "._PersonAccount", JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonTafsiliCode", null, new List<object>() { }) }, "PersonTafsiliCode", _ConstClassName + "._PersonTafsiliCode", JDomains.Images.MenuImages.Item, null)
            }));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonAccount", null, new List<object>() { }) }, "PersonAccountNo", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._User", null, new List<object>() { }) }, "Users", _ConstClassName + "._User", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OrganizationChart", null, new List<object>() { }) }, "OrganizationChart", _ConstClassName + "._OrganizationChart", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Successor", null, new List<object>() { }) }, "Successor", _ConstClassName + "._Successor", JDomains.Images.MenuImages.Item, null));
            System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select * from Forms");
            List<JNode> forms = new List<JNode>();
            foreach (System.Data.DataRow Dr in dt.Rows)
            {
                forms.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click"
                                                                            , JDomains.JActionEvents.MouseClick,_ConstClassName+ ".GetFormData"
                                                                            , null, new List<object>() {Dr["Code"].ToString(),Dr["ClassName"].ToString(),Dr["FormName"].ToString() }) }
                                                                , Dr["FormName"].ToString(), _ConstClassName + ".GetFormData", JDomains.Images.ControlImages.Inbox, null));
            }
            nodes.Add(new JNode(null, "Forms", _ConstClassName, JDomains.Images.MenuImages.Folder, forms));

            //List<JNode> groups = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click"
                                                                            , JDomains.JActionEvents.MouseClick,_ConstClassName+ "._Group"
                                                                            , null, new List<object>() {}) }
                                                                , "Groups", _ConstClassName + "._Group", JDomains.Images.ControlImages.Inbox, null));
            //foreach (System.Data.DataRow dr in ClassLibrary.Domains.JApplication.JApplicationType.GetData().Rows)
            //{
            //	groups.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click"
            //																, JDomains.JActionEvents.MouseClick,_ConstClassName+ ".GetGroupData"
            //																, null, new List<object>() {dr["value"].ToString(),dr["FarsiName"].ToString()}) }
            //													, dr["FarsiName"].ToString(), _ConstClassName + ".GetGroupData", JDomains.Images.ControlImages.Inbox, null));
            //}
            //nodes.Add(new JNode(null, "Groups", _ConstClassName + "._Group", JDomains.Images.MenuImages.Folder, groups));
            List<JNode> perms = new List<JNode>();
            //perms.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Decision", null, new List<object>() { }) }, "Decisions", _ConstClassName + "._Decision", JDomains.Images.MenuImages.Item, null));
            perms.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Class", null, new List<object>() { }) }, "Classes", _ConstClassName + "._Class", JDomains.Images.MenuImages.Item, null));
            perms.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LoadDLLs", null, new List<object>() { }) }, "LoadDLLs", _ConstClassName + "._LoadDLLs", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "Permissions", _ConstClassName, JDomains.Images.MenuImages.Folder, perms));
            return nodes;
        }

        #region JobTitle
        //_JobTitle
        public string _JobTitle()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_JobTitle";

            jGridView.SQL = @"SELECT TOP 100 percent EmpJobTitle.Code As Code, 
                                (Select [name] from subdefine where subdefine.Code = EmpJobTitle.TitleCode) as [name] 
                                from EmpJobTitle";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JobTitle";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JobTitleNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JobTitleUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JobTitleUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _JobTitleNew()
        {
            return _JobTitleNew(null);
        }
        public string _JobTitleNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("JobTitle"
                , "~/WebBaseDefine/Forms/JJobTitleUpdateControl.ascx"
                , "تعریف شغل"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _JobTitleUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("JobTitle"
                , "~/WebBaseDefine/Forms/JJobTitleUpdateControl.ascx"
                , "ویرایش شغل"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        #endregion

        #region PostTitle
        //_PostTitle
        public string _PostTitle()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_PostTitle";
            jGridView.SQL = @"select TOP 100 percent Code,Title from EmpPostTitle";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "PostTitle";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PostTitleNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PostTitleUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PostTitleUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PostTitleNew()
        {
            return _PostTitleNew(null);
        }
        public string _PostTitleNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PostTitle"
                , "~/WebBaseDefine/Forms/JPostTitleUpdateControl.ascx"
                , "تعریف سمت"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _PostTitleUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PostTitle"
                , "~/WebBaseDefine/Forms/JPostTitleUpdateControl.ascx"
                , "ویرایش سمت"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        #endregion

        #region PersonTafsiliCode
        //_PersonTafsiliCode
        public string _PersonTafsiliCode()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "PersonTafsiliCode");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_PersonTafsiliCode";

            jGridView.SQL = @"select top 100 percent fcc.Code,cap.Name PersonName,fcc.Value TafsiliCode from finComparativeCode fcc
                                    left join clsAllPerson cap on cap.Code = fcc.ObjectCode
                                    where fcc.ClassName = 'ClassLibrary.Person.AllPerson'";
            //Finance.JBankAccount.GetWebQuery();
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "PersonTafsiliCode";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonTafsiliCodeNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonTafsiliCodeUpdate2", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PersonTafsiliCodeUpdate2", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PersonTafsiliCodeNew()
        {
            return _PersonTafsiliCodeNew(null);
        }
        public string _PersonTafsiliCodeNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PersonTafsiliCode"
                , "~/WebBaseDefine/Forms/JPersonTafsiliCodeUpdateControl.ascx"
                , "کد تفصیلی شخص"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _PersonTafsiliCodeUpdate2(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PersonTafsiliCode2"
                , "~/WebBaseDefine/Forms/JPersonTafsiliCodeUpdateControl.ascx"
                , "کد تفصیلی شخص"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        #endregion

        #region PersonAccount
        public string _PersonAccount()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "PersonAccount");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_PersonAccount";

            jGridView.SQL = @"select top 100 percent FBA.[Code]
                                                    ,Cap.[Name]
                                                    ,FBA.[AccountNo] from finBankAccount FBA
                                                    left join ClsAllPerson Cap on Cap.Code = FBA.PCode";
            //Finance.JBankAccount.GetWebQuery();
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "PersonAccount";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonAccountNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonAccountUpdate2", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PersonAccountUpdate2", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PersonAccountNew()
        {
            return _PersonAccountNew(null);
        }
        public string _PersonAccountNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PersonAccount"
                , "~/WebBaseDefine/Forms/JBankAccountUpdateControl.ascx"
                , "حساب بانکی اشخاص"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _PersonAccountUpdate2(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PersonAccount2"
                , "~/WebBaseDefine/Forms/JBankAccountUpdateControl.ascx"
                , "حساب بانکی اشخاص"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        #endregion

        #region RealPerson
        public string _RealPerson()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_RealPerson";

            jGridView.SQL = @"SELECT top 100 percent cp.Code, cp.Fam, cp.Name, cp.FatherName, cp.ShSh, CASE cp.Gender WHEN 0 THEN N'زن' WHEN 1 THEN N'مرد' END AS Gender
                                FROM clsPerson cp
                                ORDER BY cp.Fam, cp.Name";
            /*             AVL                   */
            try
            {
                if (isAVL)
                {
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    string query = @"SELECT top 1 * FROM AVLObjectList";//
                    DB.setQuery(query);
                    //If this statement return, true;It means code is running under WebAvl project.
                    if (DB.Query_DataTable() != null)
                    {
                        if (!WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
                        {
                            jGridView.SQL = @"SELECT top 100 percent cp.Code, cp.Fam, cp.Name, cp.FatherName, cp.ShSh, CASE cp.Gender WHEN 0 THEN N'زن' WHEN 1 THEN N'مرد' END AS Gender
                                FROM clsPerson cp
                                INNER JOIN  users u ON u.pcode=cp.code 
								inner join AVLDevice ad on u.code=ad.personCode
                                WHERE ad.personCode={0} ORDER BY cp.Fam, cp.Name";
                            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
                            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_RealPersonNORMAL";
                        }
                    }
                    DB.Dispose();
                }
            }
            catch (Exception er)
            {

            }
            /*             AVL                   */


            //ClassLibrary.JPersons.GetWebQuery();
            jGridView.Title = "RealPersons";
            jGridView.PageOrderByField = "Fam,Name";
            //jGridView.PageSize = 15;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RealPersonNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RealPersonUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._RealPersonUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        // Real Person New/Edit
        public string _RealPersonNew()
        {
            return _RealPersonNew(null);
        }



        // public string FormManagerClassName;
        // //"ClassLibrary.FormManagers";
        // public int ObjectCode;
        // public int FormCode;
        // public int ValueObjectCode;
        // //public int FormObject_ItemCode;
        // public int TableCode;
        // public int ReferCode;
        //public string ClassName;
        // bool isMultiple = false;

        //     int valueObjectCode = 0;
        //     if (panelFormObjects.SelectedItem != null)
        //         valueObjectCode = Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelFormObjects.SelectedItem.Value));
        //     //JFormManager.ShowForm(ObjectCode, Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)), 0);
        //     //JFormManager.ShowForm(Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)), ObjectCode, valueObjectCode, 0);
        //     // JFormManager.ShowForm(FormCode, ObjectCode, valueObjectCode, 0, ClassName);
        //     JFormManager.ShowForm(FormCode, ObjectCode, valueObjectCode, 0, ClassName);
        public string _RealPersonNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RealPersons"
                , "~/WebBaseDefine/Forms/JRealPersonUpdateControl.ascx"
                , "شخص حقیقی"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);




        }

        public string _RealPersonUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RealPersons"
                , "~/WebBaseDefine/Forms/JRealPersonUpdateControl.ascx"
                , "شخص حقیقی"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        #endregion

        #region LegalPerson
        public string _LegalPerson()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Legal");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_LegalPerson";

            jGridView.SQL = @"SELECT top 100 percent o.code, o.name, o.[address], o.phone_number
                                FROM organization o ORDER BY o.name";
            //ClassLibrary.JOrganizations.GetWebQuery();
            jGridView.Title = "LegalPersons";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LegalPersonNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LegalPersonUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._LegalPersonUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        // Legal Person New/Edit
        public string _LegalPersonNew()
        {
            return _LegalPersonNew(null);
        }
        public string _LegalPersonNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LegalPersons"
                , "~/WebBaseDefine/Forms/JLegalPersonUpdateControl.ascx"
                , "شخص حقوقی"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _LegalPersonUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LegalPersons"
                , "~/WebBaseDefine/Forms/JLegalPersonUpdateControl.ascx"
                , "شخص حقوقی"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
        #endregion

        #region User
        public string _User()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_User");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_User";
            //jGridView.ContextMenuItems = new List<JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UserNew", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UserUpdate", null, null) });
            //jGridView.ContextMenuItems = new List<JToolBarItem>();
            //jGridView.ContextMenuItems.Add(new JToolBarItem() { Name = "Edit", Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UserUpdate", null, null) });
            jGridView.SQL = Globals.JUsers.GetWebQuery();
            jGridView.Title = "Users";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UserNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UserUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SetUserPermission", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        // User New/Edit
        public string _UserNew()
        {
            return _UserNew(null);
        }
        public string _UserNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("User"
                , "~/WebBaseDefine/Forms/JUserUpdateControl.ascx"
                , "کاربر"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }

        public string _UserUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("User"
                , "~/WebBaseDefine/Forms/JUserUpdateControl.ascx"
                , "کاربر"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        public string _SetUserPermission(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UserPermission"
                , "~/WebBaseDefine/Forms/JPermissionSetUserControl.ascx"
                , "مجوزهای کاربر"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        #endregion

        public string _OrganizationChart()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OrganizationChart", "~/WebBaseDefine/Forms/JOrganizationChartControl.ascx", "چارت سازمانی", null, WindowTarget.NewWindow, true, true, true, 0, 0, true);
        }

        #region Other Person
        public string _OtherPerson()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Other");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_OtherPerson";

            jGridView.SQL = @"SELECT top 100 percent * from ClsOtherPerson ORDER BY Title";
            //ClassLibrary.JOrganizations.GetWebQuery();
            jGridView.Title = "OtherPersons";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OtherPersonNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OtherPersonUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OtherPersonUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, true), true);
        }
        // Other Person New/Edit
        public string _OtherPersonNew()
        {
            return _OtherPersonNew(null);
        }
        public string _OtherPersonNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OtherPersons"
                , "~/WebBaseDefine/Forms/JOtherPersonUpdateControl.ascx"
                , "شخص متفرقه"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public string _OtherPersonUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OtherPersons"
                , "~/WebBaseDefine/Forms/JOtherPersonUpdateControl.ascx"
                , "شخص متفرقه"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , false, true, true, 630, 350);
        }
        #endregion

        #region Successor
        public string _Successor()
        {
            //WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            //jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Successor";

            //jGridView.SQL = Globals.JUsers.GetWebQuery();
            //jGridView.Title = "Successor";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SuccessorNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SuccessorUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            ////jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SuccessorUpdate", null, null));
            ////JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

            return WebClassLibrary.JWebManager.LoadClientControl("Successor", "~/WebBaseDefine/Forms/JSuccessorUpdateControl.ascx", "جانشین", null, WindowTarget.NewWindow, true, true, true, 0, 0, true);
        }

        // Successor New/Edit
        //public string _SuccessorNew()
        //{
        //	return _SuccessorNew(null);
        //}
        //public string _SuccessorNew(string code)
        //{
        //	return WebClassLibrary.JWebManager.LoadClientControl("Successor"
        //		, "~/WebBaseDefine/Forms/JSuccessorUpdateControl.ascx"
        //		, "جانشین"
        //		, null
        //		, WindowTarget.NewWindow
        //		, true, false, true, 600, 350);
        //}
        //public string _SuccessorUpdate(string code)
        //{
        //	return WebClassLibrary.JWebManager.LoadClientControl("Successor"
        //		, "~/WebBaseDefine/Forms/JSuccessorUpdateControl.ascx"
        //		, "جانشین"
        //		, new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //		, WindowTarget.NewWindow
        //		, true, false, true, 630, 350);
        //}
        #endregion

        #region Form Manager
        public string GetFormData(string code = "", string className = "", string title = "")
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "GetFormData");
            jGridView.SQL = (new ClassLibrary.FormManagers()).GetFromQueryForReport(Convert.ToInt32(code));
            jGridView.SQLType = Convert.ToInt32(WebControllers.MainControls.Grid.SQLTypeEnum.Query);
            jGridView.Title = title;
            jGridView.PageOrderByField = "ObjectCode desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("نمایش", "نمایش", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JAutomation.ShowItem", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JAutomation.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebAutomation.JAutomation.ShowItem", null, null));
            return JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, true, false), true);
        }
        #endregion

        #region Group
        public string _Group()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Group";
            //jGridView.ContextMenuItems = new List<JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupNew", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUpdate", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "GroupUsers", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUsers", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "GroupClasses", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupClasses", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "GroupDecisions", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupDecisions", null, null) });
            jGridView.SQL = "select * from PermissionDefineGroup";
            jGridView.Title = "Groups";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("GroupUsers", "GroupUsers", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUsers", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
            //jGridView.Toolbar.AddButton("GroupClasses", "GroupClasses", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupClasses", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
            //jGridView.Toolbar.AddButton("GroupDecisions", "GroupDecisions", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupDecisions", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SetGroupPermission", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        //public string GetGroupData(string parentCode, string title)
        //{
        //	WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
        //	jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Group";
        //	jGridView.ContextMenuItems = new List<JContextMenuItem>();
        //	jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupNew", null, new List<object>() { parentCode }) });
        //	jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUpdate", null, null) });
        //	jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "GroupUsers", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUsers", null, null) });
        //	jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "GroupClasses", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupClasses", null, null) });
        //	jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "GroupDecisions", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupDecisions", null, null) });
        //	jGridView.SQL = "select * from PermissionDefineGroup WHERE Code = " + parentCode;
        //	jGridView.Title = title;
        //	jGridView.PageOrderByField = "code desc";
        //	jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
        //	jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupNew", null, new List<object>() { parentCode }), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
        //	jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //	jGridView.Toolbar.AddButton("GroupUsers", "GroupUsers", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupUsers", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
        //	jGridView.Toolbar.AddButton("GroupClasses", "GroupClasses", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupClasses", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
        //	jGridView.Toolbar.AddButton("GroupDecisions", "GroupDecisions", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroupDecisions", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
        //	jGridView.Actions = new List<JActionsInfo>();
        //	jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SetGroupPermission", null, null));
        //	return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        //}

        // Group New/Edit
        public string _GroupNew()
        {
            return _GroupNew(null, null);
        }
        public string _GroupNew(string parentCode = null)
        {
            return _GroupNew(null, parentCode);
        }
        public string _GroupNew(string code, string parentCode = null)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Group"
                , "~/WebBaseDefine/Forms/JGroupControl.ascx"
                , "گروه"
                , null//parentCode != null ? new List<Tuple<string, string>>() { new Tuple<string, string>("ParentCode", parentCode) } : null
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }

        public string _GroupUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Group"
                , "~/WebBaseDefine/Forms/JGroupControl.ascx"
                , "گروه"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        public string _SetGroupPermission(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GroupPermission"
                , "~/WebBaseDefine/Forms/JPermissionSetGroupControl.ascx"
                , "مجوزهای گروه"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        public string _GroupUsers(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GroupUsers"
                , "~/WebBaseDefine/Forms/JGroupUsersControl.ascx"
                , "کاربران گروه"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code), new Tuple<string, string>("ClassName", _ConstClassName.Replace(".", "_") + "_GroupUsers") }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        public string _Decision(string code)
        {
            //WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            //jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Decision";
            //jGridView.ContextMenuItems = new List<JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DecisionNew", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DecisionUpdate", null, null) });
            //jGridView.SQL = "select * from PermissionDecision";
            //jGridView.Title = "Decisions";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DecisionNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DecisionUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DecisionUpdate", null, null));
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.LoadClientControl("DecisionsGrid"
                , "~/WebBaseDefine/Forms/JDecisionListControl.ascx"
                , "تصمیمات"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }

        public string _DecisionNew(string permissionDefineCode, string code)
        {
            return _DecisionNew(permissionDefineCode);
        }

        public string _DecisionNew(string permissionDefineCode)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Decisions"
                , "~/WebBaseDefine/Forms/JDecisionsControl.ascx"
                , "تصمیمات"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("ClassCode", permissionDefineCode) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }
        public string _DecisionUpdate(string permissionDefineCode, string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Decisions"
                , "~/WebBaseDefine/Forms/JDecisionsControl.ascx"
                , "تصمیمات"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("ClassCode", permissionDefineCode), new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        public string _LoadDLLs()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LoadDLLs"
                , "~/WebBaseDefine/Forms/JLoadDLLControl.ascx"
                , "Load DLLs"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 800, 600);
        }
        public string _Class()
        {
            //WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            //jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Class";
            //jGridView.ContextMenuItems = new List<JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "New", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ClassNew", null, null) });
            //jGridView.ContextMenuItems.Add(new JContextMenuItem() { Text = "Edit", Action = new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ClassUpdate", null, null) });
            //jGridView.SQL = "select * from PermissionDefineClass";
            //jGridView.Title = "Classes";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ClassNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ClassUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ClassUpdate", null, null));
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.LoadClientControl("ClassesGrid"
                , "~/WebBaseDefine/Forms/JClassListControl.ascx"
                , "کلاس ها"
                , null
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }

        public string _ClassNew(string code)
        {
            return _ClassNew();
        }

        public string _ClassNew()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Classes"
                , "~/WebBaseDefine/Forms/JClassesControl.ascx"
                , "کلاس ها"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }
        public string _ClassUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Classes"
                , "~/WebBaseDefine/Forms/JClassesControl.ascx"
                , "کلاس ها"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }
        #endregion
    }
}