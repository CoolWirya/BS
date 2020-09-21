using ClassLibrary;
using Globals.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace WebBaseDefine.Forms
{
    public partial class JFormObjectControl : System.Web.UI.UserControl
    {

        //protected global::WebAutomation.Refer.JReferViewControl jReferViewControl;

        public string FormManagerClassName;//"ClassLibrary.FormManagers";
        public int ObjectCode = 0;
        public int FormCode = 1;
        public int ValueObjectCode; 
        //public int FormObject_ItemCode;
        public int TableCode;
        public int ReferCode;
        HtmlTable table = new HtmlTable();
        bool isMultiple = false;

       // public string ClassName = "";
            //"WebBaseDefine_JWebBaseDefine_RealPerson";

        public string ClassName
        {
            get
            {
                if (ViewState["ClassName"] == null)
                    return "";
                return ViewState["ClassName"].ToString();
            }
            set
            {
                ViewState["ClassName"] = value;
            }
        }








        //public int ObjectCode
        //{
        //    get
        //    {
        //        if (ViewState["ObjectCode"] == null)
        //            return 0;
        //        return (int)ViewState["ObjectCode"];
        //    }
        //    set
        //    {
        //        ViewState["ObjectCode"] = value;
        //    }
        //}
        //public int FormCode
        //{
        //    get
        //    {
        //        if (ViewState["FormCode"] == null)
        //            return 0;
        //        return (int)ViewState["FormCode"];
        //    }
        //    set
        //    {
        //        ViewState["FormCode"] = value;
        //    }
        //}


        protected void Page_Init(object sender, EventArgs e)
        {

            // Get Variables
            // ClassName = Request["ClassName"];
            ClassName = "WebBaseDefine_JWebBaseDefine_RealPerson";
           FormManagerClassName = ClassName;
            WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager("FormManagers");
            FormCode = Convert.ToInt32(formSUID.GetObject("FormCode"));
            ObjectCode = Convert.ToInt32(formSUID.GetObject("ObjectCode"));
            if (formSUID.GetObject("TableCode") != null)
                TableCode = Convert.ToInt32(formSUID.GetObject("TableCode"));
            if (formSUID.GetObject("ClassName") != null)
                FormManagerClassName = formSUID.GetObject("ClassName").ToString();
            ClassLibrary.JFormObjects jFormObjects = new ClassLibrary.JFormObjects(FormCode);
            //FormCode = jFormObjects.Code;
            if (formSUID.GetObject("ReferCode") != null)
                ReferCode = Convert.ToInt32(formSUID.GetObject("ReferCode"));
            else
                ReferCode = 0;
            if (formSUID.GetObject("ValueObjectCode") != null)
                ValueObjectCode = Convert.ToInt32(formSUID.GetObject("ValueObjectCode"));
            else
                ValueObjectCode = jFormObjects.Code;
            if (formSUID.GetObject("IsMultiple") != null)
                isMultiple = (bool)formSUID.GetObject("IsMultiple");
            else
                isMultiple = false;
            gridView2.Visible = isMultiple;
            //WebBaseDefine.Forms.JFormObjectControl obj = new WebBaseDefine.Forms.JFormObjectControl();
        
            if (isMultiple)
                databind();

           

            // Configure Buttons

            //if (ReferCode == 0)
            //{
            //    ReferCode = (new automa).
            //            FindLastRefer(FormManagerClassName, ValueObjectCode, FormCode, ClassLibrary.JMainFrame.CurrentPostCode);
            //    if (ReferCode <= 0)
            //        ReferCode = (new Automation.JARefer()).
            //                FindRefer(FormManagerClassName, ValueObjectCode, FormCode);
            //}
            //if (ReferCode != 0)
            //{
            //    Automation.JARefer jaRefer = new Automation.JARefer(ReferCode);
            //    if (jaRefer.receiver_post_code != ClassLibrary.JMainFrame.CurrentPostCode || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
            //    {
            //        btnSave.Enabled = false;
            //        //if (isMultiple) propertyValueGridControl1.SwitchToViewMode();
            //        btnRefer.Enabled = false;
            //        //txtDescription.ChangeToViewMode();
            //    }
            //}
            // Load New Property

            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).ClassName = FormManagerClassName;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).ObjectCode = FormCode;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).FormObjectCode = ObjectCode;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).ValueObjectCode = ValueObjectCode;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).TableCode = TableCode; // Insert Mode(New Record)
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).isMultiple = isMultiple;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).LoadProperty(false);
            // Load Properties
            bool loadData = true;
            if (IsPostBack) loadData = false;

            //if (jFormObjects.Form.isMultiple == false)
            if (isMultiple == false)
            {
                WebControllers.Property.JPropertyViewControl jPropertyViewControl = new WebControllers.Property.JPropertyViewControl();
                jPropertyViewControl.ID = "prop01";
                jPropertyViewControl.ClassName = FormManagerClassName;
                jPropertyViewControl.ObjectCode = FormCode;
                jPropertyViewControl.ValueObjectCode = ValueObjectCode;
                jPropertyViewControl.TableCode = TableCode;
                jPropertyViewControl.FormObjectCode = ObjectCode;
                jPropertyViewControl.isMultiple = isMultiple;
                jPropertyViewControl.KeyColumnWidth = "200";
                jPropertyViewControl.ValueColumnWidth = "450";
                jPropertyViewControl.LoadPropertyOnPageLoad(loadData);
                divProperties.Controls.Add(jPropertyViewControl);
                HtmlTableRow row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].Controls.Add(jPropertyViewControl);
                table.Rows.Add(row);
                
            }
            else
            {
                WebControllers.Property.JPropertyViewControl jPropertyViewControl = new WebControllers.Property.JPropertyViewControl(); 
                jPropertyViewControl.ID = "prop01";
                jPropertyViewControl.ClassName = FormManagerClassName;
                jPropertyViewControl.ObjectCode = FormCode;
                jPropertyViewControl.ValueObjectCode = ValueObjectCode;
                jPropertyViewControl.TableCode = TableCode;
                jPropertyViewControl.FormObjectCode = ObjectCode;
                jPropertyViewControl.isMultiple = isMultiple;
                jPropertyViewControl.KeyColumnWidth = "200";
                jPropertyViewControl.ValueColumnWidth = "450";
                jPropertyViewControl.LoadPropertyOnPageLoad(!IsPostBack);
                divProperties.Controls.Add(jPropertyViewControl);
                HtmlTableRow row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].Controls.Add(jPropertyViewControl);
                table.Rows.Add(row);


                databind();
                Globals.Property.JProperties jProperties = new Globals.Property.JProperties("ClassLibrary.FormManagers", FormCode);
                List<int> RowCodes = jProperties.GetPropertyTableDataCode(ValueObjectCode);
                int counter = 0;
                string color = "";
                if (RowCodes != null)
                    foreach (int FormObject_ItemCode in RowCodes)
                    {
                        counter++;
                        if (color == "#ECC")
                            color = "#CCE";
                        else color = "#ECC";

                        // Table preparation
                        HtmlTableRow row1 = new HtmlTableRow(); 
                        HtmlTableCell cell_1 = new HtmlTableCell();
                        cell_1.Width = "35";
                        cell_1.Style.Add("background-color", color);
                        cell_1.Style.Add("color", "#999");
                        cell_1.Style.Add("font-size", "20px");
                        cell_1.Style.Add("text-align", "center");
                        cell_1.Style.Add("vertical-align", "top");
                        HtmlTableCell cell_2 = new HtmlTableCell();
                        cell_2.Style.Add("background-color", color);
                        row1.Cells.Add(cell_1);
                        row1.Cells.Add(cell_2);

                        // Property preparation
                        WebControllers.Property.JPropertyViewControl jPropertyViewControl2 = new WebControllers.Property.JPropertyViewControl(); 
                        jPropertyViewControl2.ID = "prop_" + FormObject_ItemCode;
                        jPropertyViewControl2.ClassName = "ClassLibrary.FormManagers";
                        jPropertyViewControl2.ObjectCode = FormCode;
                        jPropertyViewControl2.ValueObjectCode = ValueObjectCode;
                        jPropertyViewControl2.FormObjectCode = ObjectCode;
                        jPropertyViewControl2.TableCode = FormObject_ItemCode;
                        jPropertyViewControl2.isMultiple = isMultiple;
                        jPropertyViewControl2.KeyColumnWidth = "200";
                        jPropertyViewControl2.ValueColumnWidth = "450";
                        jPropertyViewControl2.LoadPropertyOnPageLoad(loadData);
                        row1.Cells[0].InnerText = counter.ToString();
                        row1.Cells[1].Controls.Add(jPropertyViewControl2);
                        table.Rows.Add(row1);
                    }
                divProperties.Controls.Add(table);
            }
        }
        public void databind()
        {
            if (FormManagerClassName == null || FormManagerClassName.Length <= 0 || FormCode <= 0)
                return;

            JProperties PT = new JProperties(FormManagerClassName, FormCode);
            DataTable dt = PT.GetPropertyTableData(ValueObjectCode);
            dt.Rows.Clear();
            DataTable DTValue = PT.GetPropertyTableDataForPrint(ValueObjectCode);
            //if (_OriginalDataTable == null)
            //    _OriginalDataTable = DTValue.Copy();
            //_NewDataTable = DTValue.Copy();

            // Prepare Unformatted Values In DataGrid Table
            DataTable DTProp = PT.GetBaseDataTable("ASC");
            JProperty TempProp = new JProperty();
            for (int i = 0; i < DTProp.Rows.Count; i++)
            {
                DataRow _DR = DTProp.Rows[i];
                ClassLibrary.JTable.SetToClassProperty(TempProp, _DR);
                if (TempProp.DataType == JSQLDataType.عدد.ToString())
                {
                    // عدد
                }
                else if (TempProp.DataType == JSQLDataType.تاریخ.ToString())
                {
                    string OldCol = TempProp.Name.Replace(" ", "__");
                    string NewCol = TempProp.Name.Replace(" ", "__") + "_";
                    DTValue.Columns.Add(NewCol);
                    for (int j = 0; j < DTValue.Rows.Count; j++)
                    {
                        try
                        {
                            DTValue.Rows[j][NewCol] = JDateTime.FarsiDate(DateTime.Parse(DTValue.Rows[j][OldCol].ToString()));
                        }
                        catch { DTValue.Rows[j][NewCol] = ""; }
                        finally { }
                    }
                    DTValue.Columns.Remove(OldCol);
                }
                else if (TempProp.DataType == JSQLDataType.اس_کیو_ال.ToString())
                {
                    string _SQL = TempProp.List;
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();

                    try
                    {
                        DB.setQuery(_SQL);
                        DataTable _DataT = DB.Query_DataTable();
                        for (int j = 0; j < DTValue.Rows.Count; j++)
                        {
                            string columnName = TempProp.Name.Replace(" ", "__");
                            for (int k = 0; k < _DataT.Rows.Count; k++)
                            {

                                if (_DataT.Rows[k][0].ToString() == DTValue.Rows[j][columnName].ToString())
                                {
                                    DTValue.Rows[j][columnName] = _DataT.Rows[k][1];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        DB.Dispose();
                    }

                }
                else
                {
                    // Other conditions
                }

                if (TempProp.ListType == JProppertyListType.لیست_ثابت.ToString() &&
                    TempProp.DataType != JSQLDataType.اس_کیو_ال.ToString())
                {
                    //DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                    char[] newLine = { (char)13, (char)10 };

                    string[] StrList = TempProp.List.Split(newLine, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                    }
                }

            }


            gridView2.DataSource = dt;
            gridView2.DataBind();
            //gridView.Columns.Add(new BoundField());
        }
        private bool Save()
        {
            // Save Properties' Data
            if (table.Rows.Count == 0) return false;
            bool result = true;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //if (table.Rows[i].Cells.Count < 2 || table.Rows[i].Cells[1].Controls.Count == 0) continue;
                if (table.Rows[i].Cells.Count < 1 || table.Rows[i].Cells[0].Controls.Count == 0) continue;
                WebControllers.Property.JPropertyViewControl prop = (WebControllers.Property.JPropertyViewControl)table.Rows[i].Cells[0].Controls[0];
                if (prop.Save() == false) result = false;
            }
            return result;
        }

        void GridDoubleClick(int index)
        {
            string SUID = "FormManagers";
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager(SUID);
            //jSUIDManager.SetObject("FormObjectCode", Convert.ToInt32(e.Item.Value));
            bool isMultiple = (new ClassLibrary.JForms(FormCode)).isMultiple;
            jSUIDManager.SetObject("ValueObjectCode", gridView2.Items[index]["ObjectCode"].Text);
            jSUIDManager.SetObject("TableCode", isMultiple ? "0" : gridView2.Items[index]["Code"].Text);
            jSUIDManager.SetObject("ReferCode", 0);
            jSUIDManager.SetObject("ObjectCode", isMultiple ? gridView2.Items[index]["ListObjectCode"].Text : ObjectCode.ToString());
            jSUIDManager.SetObject("FormCode", FormCode);
            jSUIDManager.SetObject("IsMultiple", isMultiple);
            jSUIDManager.SetObject("ClassName", ClassName);
            WebClassLibrary.JWebManager.LoadControl(SUID
                    , "~/WebControllers/FormManager/JFormObjectControl.ascx"
                    , "فرم"
                    , null
                    , WebClassLibrary.WindowTarget.CurrentWindow
                    , true, false, true, 600, 350);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"].ToLower() == "gridviewdblclicked")
            //{
            //    int index = int.Parse(Request["__EVENTARGUMENT"]);
            //    GridDoubleClick(index);
            //    return;
            //}
            //ClassName = Request["ClassName"];
            //FormManagerClassName = ClassName;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                if (!isMultiple)
                    WebClassLibrary.JWebManager.LoadControl("FormManagers"
                                , "~/WebControllers/FormManager/JFormListControl.ascx"
                                , "فرم ساز"
                                , null
                                , WebClassLibrary.WindowTarget.CurrentWindow
                                , true, true, true, 600, 350);
                else
                {
                    ValueObjectCode = (int)new WebClassLibrary.JSUIDManager("FormManagers").GetObject("ValueObjectCode");
                    databind();
                }
            //WebClassLibrary.JWebManager.CloseWindow();
            else
                WebClassLibrary.JWebManager.ShowMessage("خطا در ذخیره سازی، مجددا سعی نمایید.");
        }

        protected void btnRefer_Click(object sender, EventArgs e)
        {
            if (!Save())
            {
                WebClassLibrary.JWebManager.ShowMessage("خطا در ذخیره سازی، مجددا سعی نمایید.");
                return;
            }

            DataTable dt = new DataTable();
            WebControllers.Automation.JAutomationRefer.ShowRefer(FormManagerClassName, FormCode, ValueObjectCode, dt, ReferCode, "فرم ساز");
           
        }
    
        protected void btnSaveProperty_Click(object sender, EventArgs e)
        {
            if (!((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).Save())
                WebClassLibrary.JWebManager.ShowMessage("خطا در ثبت اطلاعات. لطفا مجددا سعی نمایید.");
            else
            {
               
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).TableCode = 0;
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).LoadProperty(true);
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ci = e.Row.Cells.Count - 1;
                LinkButton btn = new LinkButton();
                btn.Text = "حذف";
                btn.CommandName = "remove";
                btn.CommandArgument = e.Row.Cells[0].Text + "|" + e.Row.Cells[1].Text;
                btn.OnClientClick = "return confirm('آیا از حذف این رکورد اطمینان دارید؟');";
                //e.Row.Cells[ci].Controls.Add(btn);
                TableCell cell = new TableCell();
                cell.Controls.Add(btn);
                e.Row.Cells.Add(cell);
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() != "remove")
                return;
            int code = int.Parse(e.CommandArgument.ToString().Split('|')[0]);
            int valueObjectCode = int.Parse(e.CommandArgument.ToString().Split('|')[1]);//int.Parse(gridView.Rows[e.RowIndex].Cells[1].Text);
            JProperty jProperty = new JProperty();
            if (jProperty.DeleteDataByValueObjectCode(null, FormManagerClassName, FormCode, valueObjectCode, code))
                databind();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد.", WebClassLibrary.MessageType.Error);
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridView2_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                LinkButton btn = new LinkButton();
                btn.Text = "حذف";
                btn.CommandName = "remove";
                btn.CommandArgument = (e.Item.DataItem as DataRowView)[0] + "|" + (e.Item.DataItem as DataRowView)[1];
                btn.OnClientClick = "return confirm('آیا از حذف این رکورد اطمینان دارید؟');";
                //e.Row.Cells[ci].Controls.Add(btn);
                TableCell cell = new TableCell();
                cell.Controls.Add(btn);
                e.Item.Cells.Add(cell);
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                Label lbl = new Label();
                lbl.Text = "عملیات";
                TableCell cell = new TableCell();
                cell.Controls.Add(lbl);
                e.Item.Cells.Add(cell);
            }
        }

        protected void gridView2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() != "remove")
                return;
            int code = int.Parse(e.CommandArgument.ToString().Split('|')[0]);
            int valueObjectCode = int.Parse(e.CommandArgument.ToString().Split('|')[1]);//int.Parse(gridView.Rows[e.RowIndex].Cells[1].Text);
            JProperty jProperty = new JProperty();
            if (jProperty.DeleteDataByValueObjectCode(null, FormManagerClassName, FormCode, valueObjectCode, code))
                databind();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد.", WebClassLibrary.MessageType.Error);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            //WebClassLibrary.JWebManager.LoadControl("FormManagers"
            //                    , "~/WebControllers/FormManager/JFormListControl.ascx"
            //                    , "فرم ساز"
            //                    , null
            //                    , WebClassLibrary.WindowTarget.CurrentWindow
            //                    , true, true, true, 600, 350);

            WebClassLibrary.JWebManager.CloseWindow();

        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (e.Tab.PageViewID.ToLower() == "rpvrefer")
            { }
        }

  


        //protected void gridView_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        //{

        //}
    }
}