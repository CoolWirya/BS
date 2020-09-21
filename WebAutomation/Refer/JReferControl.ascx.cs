using Automation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebControllers;

namespace WebAutomation.Refer
{
    public partial class JReferControl : System.Web.UI.UserControl
    {
        public string ClassName;
        public int DynamicClassCode;
        public int ObjectCode;
        public DataTable PublicDataRow;
        public int ParentReferCode;
        public string Title;
        private int _workFlowCode;

        //protected global::WebControllers.ArchiveDocument.JArchiveControl JArchiveControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get data from Session using SUID and JAutomationRefer
            WebControllers.Automation.JAutomationRefer jAutomationRefer = new WebControllers.Automation.JAutomationRefer();
            ClassName = jAutomationRefer.ClassName;
            ObjectCode = jAutomationRefer.ObjectCode;
            DynamicClassCode = jAutomationRefer.DynamicClassCode;
            PublicDataRow = jAutomationRefer.PublicDataRow;
            ParentReferCode = jAutomationRefer.ParentReferCode;
            Title = jAutomationRefer.Title;

            //  hfReferCode.Value = (new Automation.JARefer()).FindRefer(ClassName, ObjectCode, 0).ToString();
            //   hfReferCode.Value = jAutomationRefer.ReferCode;
            // WorkFlow Preparation
            int _ReferCode = 0;
            _workFlowCode = 0;
            if (ParentReferCode > 0)
            {
                Automation.JARefer Refer = new Automation.JARefer(ParentReferCode);
                _workFlowCode = Refer.WorkFlowCode;
                _ReferCode = Refer.Code;

                // JArchiveControl.ObjectCode = Refer.Code;
            }

            JWorkFlow WorkFlow = new JWorkFlow(PublicDataRow, _ReferCode);
            WorkFlow.GetData(_workFlowCode, ClassName, DynamicClassCode);

            try
            {
                using (ClassLibrary.JDataBase db = new ClassLibrary.JDataBase())
                {
                    db.setQuery(String.Format("SELECT * FROM WorkflowObjects WHERE ClassName = N'{0}' AND DynamicClassCode={1}", ClassName, DynamicClassCode));
                    try {
                        if (db.Query_DataTable().Rows.Count == 0)
                        {
                            db.setQuery(String.Format("INSERT INTO WorkflowObjects (ClassName,DynamicClassCode)Values (N'{0}',{1})", ClassName, DynamicClassCode));
                            db.Query_Execute();
                        }
                    }
                    catch
                    {

                    }
                    db.Dispose();
                }
            }
            catch
            {

            }

            if (WorkFlow.NodeType == JNodeType.PreviousEmployment)
            {
                Automation.JARefer _R = new Automation.JARefer(ParentReferCode);
                _R.GetData(_R.parent_code);
                if (_R.parent_code != 0)
                {
                    _R.GetData(_R.parent_code);
                    WorkFlow.GetData(_R.WorkFlowCode, "", 0);
                }
                else
                {
                    WorkFlow.GetFirst();
                }
            }
            var nodes = WorkFlow.GetNextNodes();
            if (nodes == null)
            {
                mainTable.Visible = false;
                WebClassLibrary.JWebManager.ShowMessage(" مرحله بعدی برای این وضعیت تعریف نشده است ");
                return;
            }
            else
            {
                var NextNodes = nodes.AsEnumerable().Select(m => new { Code = WebClassLibrary.JDataManager.EncryptString(m.Code.ToString()), Name = m.Name });
                cmbNextNodes.DataSource = NextNodes.ToList();
                if (!IsPostBack) cmbNextNodes.DataBind();
            }

            if (cmbNextNodes.SelectedValue != null)
            {
                _workFlowCode = 0;
                int.TryParse(WebClassLibrary.JDataManager.DecryptString(cmbNextNodes.SelectedValue), out _workFlowCode);
            }
            //JArchiveControl.ClassName = ClassName;
            //JArchiveControl.LoadArchive();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Error = false;
            List<Tuple<string, string>> Recievers = new List<Tuple<string, string>>();
            for (int i = 0; i < grdReceivers.Items.Count; i++)
            {
                var btnCheck = (Telerik.Web.UI.RadButton)grdReceivers.MasterTableView.Items[i]["colSel"].FindControl("btnSelect");
                if (btnCheck.ToggleStates[1].Selected)
                {
                    string[] PostCodes = ((HiddenField)grdReceivers.MasterTableView.Items[i]["colSel"].FindControl("hidPostCode")).Value.Split(';');
                    string comment = ((Telerik.Web.UI.RadTextBox)grdReceivers.MasterTableView.Items[i]["colRec"].FindControl("txtReferText")).Text;
                    if (PostCodes.Length < 2)
                    {
                        int PostCode = Convert.ToInt32(((HiddenField)grdReceivers.MasterTableView.Items[i]["colSel"].FindControl("hidPostCode")).Value);
                        Recievers.Add(new Tuple<string, string>(PostCode.ToString(), comment));
                    }
                    else
                    {
                        foreach (string PCode in PostCodes)
                        {
                            Recievers.Add(new Tuple<string, string>(PCode, comment));
                        }
                    }
                }
            }

            Automation.JWorkFlow workFlow = new JWorkFlow();
            workFlow.GetData(_workFlowCode, "", 0);

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                foreach (var Reciever in Recievers)
                {
                    int d;
                    if (int.TryParse(Reciever.Item1, out d))
                    {
                        Employment.JEOrganizationChart jeoc = new Employment.JEOrganizationChart(d);

                        Automation.JARefer jaRefer = new Automation.JARefer(ParentReferCode);

                        Automation.JARefer tmprefer = new Automation.JARefer();
                        tmprefer.send_date_time = ClassLibrary.JDateTime.Now();

                        tmprefer.sender_code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                        tmprefer.sender_full_title = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle;
                        tmprefer.sender_post_code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode;
                        tmprefer.receiver_code = Convert.ToInt32(jeoc.user_code);
                        tmprefer.receiver_full_title = jeoc.full_Name;
                        tmprefer.receiver_post_code = d;
                        tmprefer.register_user_code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                        tmprefer.register_Date_Time = ClassLibrary.JDateTime.Now();
                        tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                        tmprefer.is_active = true;
                        tmprefer.ReferGroup = 1;
                        tmprefer.parent_code = ParentReferCode;
                        tmprefer.description = Reciever.Item2;
                        tmprefer.WorkFlowCode = _workFlowCode;

                        tmprefer.object_code = tmprefer.SendToAutomation(ObjectCode,
                                                                        "", Title, ClassName, DynamicClassCode, db,
                                                                        WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle, WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode,
                                                                        WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, false);
                        if (tmprefer.Send(db, true) > 0)
                        {
                            DataColumn dc = new DataColumn();
                            dc.ColumnName = "ReferCode";
                            if (!PublicDataRow.Columns.Contains("ReferCode"))
                                PublicDataRow.Columns.Add(dc);
                            PublicDataRow.Rows[0].BeginEdit();
                            PublicDataRow.Rows[0]["ReferCode"] = tmprefer.Code;
                            PublicDataRow.Rows[0].AcceptChanges();
                            workFlow._PublicDataRow = PublicDataRow;
                            workFlow.RUNSQL();
                            workFlow.RUNACTION();
                            //_ReferCode = tmprefer.Code;
                            if (jaRefer.parent_code > 0)
                            {
                                /* Save Archive Files 
                                 * */
                                //jArchiveList1.ClassName = _ConstClassName;
                                //jArchiveList1.ObjectCode = _ParentRefer;
                                //jArchiveList1.ArchiveList();
                            }
                            //WebClassLibrary.JWebManager.ReferSuccess();
                        }
                        else
                        {
                            Error = true;
                            WebClassLibrary.JWebManager.ShowMessage("اتوماسیون با خطا مواجه شد.", WebClassLibrary.MessageType.Information);
                        }
                    }

                }
                if (!Error)
                {
                    WebClassLibrary.JWebManager.ShowMessage("با موفقیت ارجاع داده شد.", WebClassLibrary.MessageType.Information);
                }
                WebClassLibrary.JWebManager.CloseWindow();
                //WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);GetRadWindow().BrowserWindow.RefreshTree();", "refer successed");
            }
            finally
            {
                db.Dispose();
            }
        }

        protected void cmbNextNodes_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int workFlowCode = Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(e.Value));
            DataTable dt = PublicDataRow;
            if (dt.Columns.IndexOf("PostCode") < 0)
            {
                dt.Columns.Add("PostCode");
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                }
                dt.Rows[0]["PostCode"] = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode;
            }
            JWorkFlow jWorkFlow = new JWorkFlow(dt, 0);
            jWorkFlow.GetData(workFlowCode, null, 0);
            DataTable dtPosts = jWorkFlow.GetPosts();
            grdReceivers.DataSource = dtPosts;
            grdReceivers.Rebind();
        }
    }
}