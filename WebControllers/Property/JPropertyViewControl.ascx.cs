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
//dsf
namespace WebControllers.Property
{
    public partial class JPropertyViewControl : System.Web.UI.UserControl
    {
        public string ClassName    // in FormManager : always ClassLibrary.FormManagers || Otherwise it can be anything.
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
        public int ObjectCode      // in FormManager : Code in Forms Table || Otherwise it can be anything.
        {
            get
            {
                if (ViewState["ObjectCode"] == null)
                    return 0;
                return (int)ViewState["ObjectCode"];
            }
            set
            {
                ViewState["ObjectCode"] = value;
            }
        }
        public int ValueObjectCode // ObjectCode   in Property Table && in FormManager: Code in FormObjects Table
        {
            get
            {
                if (ViewState["ValueObjectCode"] == null)
                    return 0;
                return (int)ViewState["ValueObjectCode"];
            }
            set
            {
                ViewState["ValueObjectCode"] = value;
            }
        }
        public int TableCode       // Code         in Property Table
        {
            get
            {
                if (ViewState["TableCode"] == null)
                    return 0;
                return (int)ViewState["TableCode"];
            }
            set
            {
                ViewState["TableCode"] = value;
            }
        }
        public int FormObjectCode;
        public bool AddPersianDateScriptManager = true;
        public bool isReadOnly = false;
        public string KeyColumnWidth = "";
        public string ValueColumnWidth = "";
        //public bool isMultiple = false;
        public bool isMultiple
        {
            get
            {
                if (ViewState["isMultiple"] == null)
                    return false;
                return (bool)ViewState["isMultiple"];
            }
            set
            {
                ViewState["isMultiple"] = value;
            }
        }

        static HtmlTable PropertyContainer;
        #region Methods
        public void LoadProperty(bool loadData = true)
        {
            CreateFields(loadData);
        }

        private void CreateFields(bool loadData)
        {
            DataTable ItemValues = null;
            PropertyContainer = new HtmlTable();
            // Loading Field Values
            if (TableCode > 0 || (isMultiple == false && ValueObjectCode > 0))
            {
                Globals.Property.JPropertyTables jPropertyTables = new Globals.Property.JPropertyTables(ClassName, ObjectCode);
                ItemValues = jPropertyTables.GetData(ValueObjectCode, TableCode, true);
                if (ItemValues != null && ItemValues.Rows.Count > 0)
                    TableCode = Convert.ToInt32(ItemValues.Rows[0]["Code"]);
            }
            else // TableCode == 0
            {
                Globals.Property.JPropertyTables jPropertyTables = new Globals.Property.JPropertyTables(ClassName, ObjectCode);
                ItemValues = jPropertyTables.GetData(ValueObjectCode, TableCode, true);
                if (ItemValues != null && ItemValues.Rows.Count == 0)
                    ItemValues.Rows.Add(ItemValues.NewRow());
            }
            Globals.Property.JProperties jProperties = new Globals.Property.JProperties(ClassName, ObjectCode);
            bool style = false;
            bool isPersianDateScriptManagerAdded = false;
            DataTable dt_prop = jProperties.GetDataTable(false);
            if (dt_prop == null)
            {
                System.Web.UI.HtmlControls.HtmlTableRow row = new System.Web.UI.HtmlControls.HtmlTableRow();
                if (style) row.Style.Add("background-color", "#EEE");
                else row.Style.Add("background-color", "#DDD");
                System.Web.UI.HtmlControls.HtmlTableCell cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                cell.Width = KeyColumnWidth;
                row.Cells.Add(cell);
                PropertyContainer.Rows.Add(row);
                return;
            }

            #region Multiple Mode Insertion
            //if (isMultiple)
            //{
            //    GridView mgv = new GridView();
            //    mgv.DataSource = dt_prop;
            //    mgv.DataBind();
            //    //mgv.
            //    PropertyContainer.Controls.Add(mgv);
            //}
            #endregion

            #region Single Mode Insertion
            //else
            foreach (DataRow field in dt_prop.Rows)
            {
                style = !style;
                System.Web.UI.HtmlControls.HtmlTableRow row = new System.Web.UI.HtmlControls.HtmlTableRow();
                if (style) row.Style.Add("background-color", "#EEE");
                else row.Style.Add("background-color", "#DDD");
                System.Web.UI.HtmlControls.HtmlTableCell cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                cell.Width = KeyColumnWidth;
                row.Cells.Add(cell);
                cell = new System.Web.UI.HtmlControls.HtmlTableCell();
                cell.Width = ValueColumnWidth;
                row.Cells.Add(cell);

                row.Cells[0].InnerText = field["Name"].ToString();
                string rawfieldName = field["Name"].ToString().Replace(" ", "__");
                string fieldName = "Property" + field["Code"].ToString();
                bool isReadOnly = this.isReadOnly;
                bool isVisible = true;
                // Check Field ReadOnly Property
                if (field["ListCanView"] != null && field["ListCanView"].ToString() != "" && this.isReadOnly == false)
                {
                    var q = field["ListCanView"].ToString().Split(',').Where(m => m == WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode.ToString());
                    if (q.Count() == 0)
                        isVisible = false;
                }
                // Check Field Visiblity Property
                if (field["ListCanEdit"] != null && field["ListCanEdit"].ToString() != "")
                {
                    var q = field["ListCanEdit"].ToString().Split(',').Where(m => m == WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode.ToString());
                    if (q.Count() == 0)
                        isReadOnly = true;
                }
                switch (field["DataType"].ToString())
                {
                    case "رشته":
                        if (field["ListType"].ToString() == "متغیر")
                        {
                            Telerik.Web.UI.RadTextBox radTextBox = new Telerik.Web.UI.RadTextBox();
                            radTextBox.ID = fieldName;
                            radTextBox.ReadOnly = isReadOnly;
                            radTextBox.Visible = isVisible;
                            if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                                radTextBox.Text = ItemValues.Rows[0][rawfieldName].ToString();
                            row.Cells[1].Controls.Add(radTextBox);
                        }
                        else if (field["ListType"].ToString() == "لیست_ثابت")
                        {
                            Telerik.Web.UI.RadComboBox radComboBoxText = new Telerik.Web.UI.RadComboBox();
                            radComboBoxText.ID = fieldName;
                            radComboBoxText.Enabled = !isReadOnly;
                            radComboBoxText.Visible = isVisible;
                            char[] newLine = { (char)13, (char)10 };
                            foreach (string item in field["List"].ToString().Split(newLine))
                                if (item != "")
                                    radComboBoxText.Items.Add(new Telerik.Web.UI.RadComboBoxItem(item, item));
                            radComboBoxText.AllowCustomText = false;
                            if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                                radComboBoxText.SelectedValue = ItemValues.Rows[0][rawfieldName].ToString();
                            row.Cells[1].Controls.Add(radComboBoxText);
                        }
                        break;
                    case "رشته_چند_خطی":
                        Telerik.Web.UI.RadEditor radEditor = new Telerik.Web.UI.RadEditor();
                        radEditor.ID = fieldName;
                        radEditor.Enabled = !isReadOnly;
                        radEditor.Visible = isVisible;
                        if (ItemValues != null && ItemValues.Rows.Count > 0)
                            radEditor.Content = ItemValues.Rows[0][rawfieldName].ToString();
                        row.Cells[1].Controls.Add(radEditor);
                        break;
                    case "عدد":
                        if (field["ListType"].ToString() == "متغیر")
                        {
                            Telerik.Web.UI.RadTextBox radTextBoxNum = new Telerik.Web.UI.RadTextBox();
                            radTextBoxNum.ID = fieldName;
                            radTextBoxNum.ReadOnly = isReadOnly;
                            radTextBoxNum.Visible = isVisible;
                            radTextBoxNum.InputType = Telerik.Web.UI.Html5InputType.Number;
                            if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                                radTextBoxNum.Text = ItemValues.Rows[0][rawfieldName].ToString();
                            row.Cells[1].Controls.Add(radTextBoxNum);
                        }
                        break;
                    case "زمان":
                        if (field["ListType"].ToString() == "متغیر")
                        {
                            Telerik.Web.UI.RadTextBox radTextBoxTimeHour = new Telerik.Web.UI.RadTextBox();
                            radTextBoxTimeHour.ID = fieldName + "H";
                            radTextBoxTimeHour.Width = new Unit("60px");
                            radTextBoxTimeHour.ReadOnly = isReadOnly;
                            radTextBoxTimeHour.Visible = isVisible;
                            radTextBoxTimeHour.InputType = Telerik.Web.UI.Html5InputType.Number;
                            radTextBoxTimeHour.RenderMode = Telerik.Web.UI.RenderMode.Lightweight;
                            radTextBoxTimeHour.Style.Add("text-align", "center");

                            Label lblSeprator = new Label();
                            lblSeprator.ID = fieldName + "SEPRATOR";
                            lblSeprator.Text = "&nbsp;:&nbsp;";

                            Telerik.Web.UI.RadTextBox radTextBoxTimeMinute = new Telerik.Web.UI.RadTextBox();
                            radTextBoxTimeMinute.ID = fieldName + "M";
                            radTextBoxTimeMinute.Width = new Unit("60px");
                            radTextBoxTimeMinute.ReadOnly = isReadOnly;
                            radTextBoxTimeMinute.Visible = isVisible;
                            radTextBoxTimeMinute.InputType = Telerik.Web.UI.Html5InputType.Number;
                            radTextBoxTimeMinute.RenderMode = Telerik.Web.UI.RenderMode.Lightweight;
                            radTextBoxTimeMinute.Style.Add("text-align", "center");

                            radTextBoxTimeHour.EmptyMessage = "ساعت";
                            radTextBoxTimeMinute.EmptyMessage = "دقیقه";
                            if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                            {
                                string[] str = ItemValues.Rows[0][rawfieldName].ToString().Split(':');
                                radTextBoxTimeHour.Text = str[0];
                                radTextBoxTimeMinute.Text = str[1];
                            }
                            row.Cells[1].Controls.Add(radTextBoxTimeMinute);
                            row.Cells[1].Controls.Add(lblSeprator);
                            row.Cells[1].Controls.Add(radTextBoxTimeHour);
                        }
                        break;
                    case "تاریخ":
                        if (isPersianDateScriptManagerAdded == false && AddPersianDateScriptManager == true && WebClassLibrary.JWebManager.CurrentPage.FindControl("persianDateScriptManager") == null)
                        {
                            // Add PersianDate Script Manager if it doesn't exist.
                            PersianDateControls.PersianDateScriptManager persianDateScriptManager = new PersianDateControls.PersianDateScriptManager();
                            persianDateScriptManager.ID = "persianDateScriptManager";
                            persianDateScriptManager.CalendarCSS = "calendarCSS";
                            persianDateScriptManager.FooterCSS = "footerCSS";
                            persianDateScriptManager.ForbidenCSS = "forbidenCSS";
                            persianDateScriptManager.FrameCSS = "frameCSS";
                            persianDateScriptManager.HeaderCSS = "headerCSS";
                            persianDateScriptManager.SelectedCSS = "selectedCSS";
                            persianDateScriptManager.WeekDayCSS = "weekDayCSS";
                            persianDateScriptManager.WorkDayCSS = "workDayCSS";
                            row.Cells[1].Controls.Add(persianDateScriptManager);
                            isPersianDateScriptManagerAdded = true;
                        }

                        PersianDateControls.PersianDateTextBox persianDateTextBox = new PersianDateControls.PersianDateTextBox();
                        persianDateTextBox.ID = fieldName;
                        persianDateTextBox.ReadOnly = isReadOnly;
                        persianDateTextBox.Visible = isVisible;
                        persianDateTextBox.IconUrl = "~/" + WebClassLibrary.JDomains.Images.ControlImages.Calendar;
                        persianDateTextBox.ShowIcon = true;
						persianDateTextBox.DateValue = DateTime.Now;
                        if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                        {
                            if (ItemValues.Rows[0][rawfieldName] != null)
                                persianDateTextBox.DateValue = Convert.ToDateTime(ItemValues.Rows[0][rawfieldName] == DBNull.Value ? DateTime.Now : ItemValues.Rows[0][rawfieldName]);
                        }

                        row.Cells[1].Controls.Add(persianDateTextBox);
                        break;
                    case "پول":
                        Telerik.Web.UI.RadTextBox radTextBoxMoney = new Telerik.Web.UI.RadTextBox();
                        radTextBoxMoney.ID = fieldName;
                        radTextBoxMoney.ReadOnly = isReadOnly;
                        radTextBoxMoney.Visible = isVisible;
                        radTextBoxMoney.InputType = Telerik.Web.UI.Html5InputType.Number;
                        if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                            radTextBoxMoney.Text = ItemValues.Rows[0][rawfieldName].ToString();
                        row.Cells[1].Controls.Add(radTextBoxMoney);
                        break;
                    case "تصمیم":
                        Telerik.Web.UI.RadButton radButton = new Telerik.Web.UI.RadButton();
                        radButton.ButtonType = Telerik.Web.UI.RadButtonType.ToggleButton;
                        radButton.ToggleStates.Add("بلی");
                        radButton.ToggleStates.Add("خیر");
                        radButton.AutoPostBack = false;
                        radButton.ToggleType = Telerik.Web.UI.ButtonToggleType.CheckBox;
                        radButton.Text = "OK";
                        radButton.ID = fieldName;
                        radButton.Enabled = !isReadOnly;
                        radButton.Visible = isVisible;
                        if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                            radButton.Checked = Convert.ToBoolean(ItemValues.Rows[0][rawfieldName] == DBNull.Value ? false : ItemValues.Rows[0][rawfieldName]);
                        row.Cells[1].Controls.Add(radButton);
                        break;
                    case "اس_کیو_ال":
                        Telerik.Web.UI.RadComboBox radComboBox = new Telerik.Web.UI.RadComboBox();
                        radComboBox.ID = fieldName;
                        radComboBox.Enabled = !isReadOnly;
                        radComboBox.Visible = isVisible;
                        radComboBox.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(field["List"].ToString());
                        radComboBox.DataValueField = "Code";
						if ((radComboBox.DataSource as DataTable).Columns.IndexOf("Code") == 0)
							radComboBox.DataTextField = (radComboBox.DataSource as DataTable).Columns[1].ColumnName;
						else
							radComboBox.DataTextField = (radComboBox.DataSource as DataTable).Columns[0].ColumnName;
							radComboBox.AllowCustomText = false;
                        radComboBox.DataBind();
                        if (ItemValues != null && ItemValues.Rows.Count > 0 && ((isReadOnly == false && loadData == true) || isReadOnly == true))
                            radComboBox.SelectedValue = ItemValues.Rows[0][rawfieldName].ToString();
                        row.Cells[1].Controls.Add(radComboBox);
                        break;
                }
                PropertyContainer.Rows.Add(row);
            }
            #endregion

            this.Controls.Add(PropertyContainer);
        }

        private bool loadPropertyOnPageLoad = false;
        private bool loadPropertyData = true;
        public void LoadPropertyOnPageLoad(bool loadData = true)
        {
            loadPropertyOnPageLoad = true;
            loadPropertyData = loadData;
        }

        public bool Save(ClassLibrary.JDataBase pDB = null)
        {
            ClassLibrary.JDataBase db = null;
            if (pDB == null) db = new ClassLibrary.JDataBase();
            else db = pDB;
            //JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("FormObjectViewForm");
                if (ValueObjectCode == 0)// && isMultiple == false)
                {
                    ClassLibrary.JFormObjects jFormObjects = new ClassLibrary.JFormObjects();
                    jFormObjects.Date = JDateTime.Now();
                    jFormObjects.FormCode = ObjectCode;
                    jFormObjects.ObjectCode = FormObjectCode;
                    //jFormObjects.Comment = txtComment.Text;
                    //jFormObjects.Description = txtDescription.Text;
                    ValueObjectCode = jFormObjects.Insert(db);
                    if (ValueObjectCode <= 0)
                    {
                        JMessages.Error("ایجاد فرم جدید با خطا مواجه شده است.", "فرم جدید");
                        db.Rollback("FormObjectViewForm");
                        //this.Close();
                        return false;
                    }
                    //jPropertyValueUserControl1.ValueObjectCode = _ValueObjectCode;
                }

                //if ((isMultiple == false && PTSave(db)) || (isMultiple == true && PTSave(db)))
                if (PTSave(db))
                {
                    db.Commit();
                    JFormObjects jFormObjects = new JFormObjects();
                    jFormObjects.Update(ValueObjectCode, "", "");
                    if (isMultiple)
                        new WebClassLibrary.JSUIDManager("FormManagers").SetObject("ValueObjectCode", ValueObjectCode);
                }
                else
                {
                    db.Rollback("FormObjectViewForm");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                db.Rollback("FormObjectViewForm");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool PTSave(JDataBase db)
        {
            JPropertyTables PropTables = new JPropertyTables(ClassName, ObjectCode);
            if (TableCode == 0)
            {
                TableCode = PropTables.Insert(GetDataRowValue(), db);
                return TableCode > 0;
            }
            else
            {
                return PropTables.Update(GetDataRowValue(), db);
            }
        }
        private DataRow GetDataRowValue(DataRow pDR = null)
        {
            JPropertyTables PTs = new JPropertyTables(ClassName, ObjectCode);
            DataTable _DT = PTs.GetData(0);
            if (_DT == null)
            {
                return null;
            }
            DataRow DR = _DT.NewRow();
            Globals.Property.JProperties jProperties = new Globals.Property.JProperties(ClassName, ObjectCode);
            foreach (DataRow field in jProperties.GetDataTable(false).Rows)
            {
                string rawFieldName = field["Name"].ToString().Replace(" ", "__");
                string fieldName = "Property" + field["Code"].ToString();
                try
                {
                    switch (field["DataType"].ToString())
                    {
                        case "رشته":
                            if (field["ListType"].ToString() == "متغیر")
                            {
                                Telerik.Web.UI.RadTextBox radTextBox = ((Telerik.Web.UI.RadTextBox)PropertyContainer.FindControl(fieldName));
                                DR[rawFieldName] = radTextBox.Text;
                            }
                            else if (field["ListType"].ToString() == "لیست_ثابت")
                            {
                                Telerik.Web.UI.RadComboBox radComboBoxText = ((Telerik.Web.UI.RadComboBox)PropertyContainer.FindControl(fieldName));
                                DR[rawFieldName] = radComboBoxText.SelectedValue;
                            }
                            break;
                        case "رشته_چند_خطی":
                            Telerik.Web.UI.RadEditor radEditor = ((Telerik.Web.UI.RadEditor)PropertyContainer.FindControl(fieldName));
                            DR[rawFieldName] = radEditor.Content;
                            break;
                        case "عدد":
                            if (field["ListType"].ToString() == "متغیر")
                            {
                                Telerik.Web.UI.RadTextBox radTextBoxNum = ((Telerik.Web.UI.RadTextBox)PropertyContainer.FindControl(fieldName));
                                DR[rawFieldName] = radTextBoxNum.Text;
                            }
                            break;
                        case "زمان":
                            if (field["ListType"].ToString() == "متغیر")
                            {
                                Telerik.Web.UI.RadTextBox radTextBoxTimeHour = ((Telerik.Web.UI.RadTextBox)PropertyContainer.FindControl(fieldName + "H"));
                                Telerik.Web.UI.RadTextBox radTextBoxTimeMinute = ((Telerik.Web.UI.RadTextBox)PropertyContainer.FindControl(fieldName + "M"));
                                DR[rawFieldName] = radTextBoxTimeHour.Text + ":" + radTextBoxTimeMinute.Text;
                            }
                            break;
                        case "تاریخ":
                            PersianDateControls.PersianDateTextBox persianDateTextBox = ((PersianDateControls.PersianDateTextBox)PropertyContainer.FindControl(fieldName));
                            try
                            {
                                DR[rawFieldName] = Convert.ToDateTime(persianDateTextBox.DateValue);
                            }
                            catch { }
                            break;
                        case "پول":
                            Telerik.Web.UI.RadTextBox radTextBoxMoney = ((Telerik.Web.UI.RadTextBox)PropertyContainer.FindControl(fieldName));
                            DR[rawFieldName] = Convert.ToDecimal(radTextBoxMoney.Text);
                            break;
                        case "تصمیم":
                            Telerik.Web.UI.RadButton radButton = ((Telerik.Web.UI.RadButton)PropertyContainer.FindControl(fieldName));
                            DR[rawFieldName] = radButton.Checked;
                            break;
                        case "اس_کیو_ال":
                            Telerik.Web.UI.RadComboBox radComboBox = ((Telerik.Web.UI.RadComboBox)PropertyContainer.FindControl(fieldName));
                            DR[rawFieldName] = radComboBox.SelectedValue;
                            break;
                    }
                }
                catch (Exception ex) { }
            }
            DR["ObjectCode"] = ValueObjectCode;
            DR["Code"] = TableCode;
            return DR;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (loadPropertyOnPageLoad)
                LoadProperty(loadPropertyData);
            // Add PersianDate StyleSheet to Current Page
            HtmlLink myHtmlLink = new HtmlLink();
            myHtmlLink.Href = ResolveUrl("~/Style/PersianDateStyle.css");
            myHtmlLink.Attributes.Add("rel", "stylesheet");
            myHtmlLink.Attributes.Add("type", "text/css");

            Page.Header.Controls.Add(myHtmlLink);
        }
    }
}