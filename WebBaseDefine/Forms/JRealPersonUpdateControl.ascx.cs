using ClassLibrary;
using Globals.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebBaseDefine.Forms
{
    public partial class JRealPersonUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        private const string SUID = "Forms";


        public string FormManagerClassName = "WebBaseDefine.JWebBaseDefine";//"ClassLibrary.FormManagers";
        public int ObjectCode;
        public int FormCode;
        public int ValueObjectCode;
        //public int FormObject_ItemCode;
        public int TableCode;
        public int ReferCode;
        HtmlTable table = new HtmlTable();
        bool isMultiple = false;
        // public string className;//= "WebControllers.FormManager.JWebForms";

        public string ClassName;
        private Telerik.Web.UI.RadPanelBar panelFormObjects = new Telerik.Web.UI.RadPanelBar();
        protected void Page_Load(object sender, EventArgs e)
        {

            //ClassName = "WebBaseDefine_JWebBaseDefine_RealPerson";
            //int valueObjectCode = 0;
            //if (panelFormObjects.SelectedItem != null)

            //    JFormManager.ShowForm(ObjectCode, Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)), 0);
            //JFormManager.ShowForm(Convert.ToInt32(WebClassLibrary.JDataManager.DecryptString(panelForms.SelectedItem.Value)), ObjectCode, valueObjectCode, 0);
            //JFormManager.ShowForm(FormCode, ObjectCode, valueObjectCode, 0, ClassName);

            int.TryParse(Request["Code"], out Code);

            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtBirthDate).SetDate(DateTime.Now);
            }

            _SetForm();

            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ClassName = "ClassLibrary.JRealPerson";
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ObjectCode = 1;
            if (Code > 0) ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueObjectCode = Code;
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).KeyColumnWidth = "150px";
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueColumnWidth = "400px";
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).LoadPropertyOnPageLoad();

            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = (new ClassLibrary.JOrganization()).GetType().FullName;
            if (Code > 0) ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = Code;
            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).LoadArchive();

        }

        public void _SetForm()
        {
            // Birth Place
            cmbBirthPlace.DataValueField = "Code";
            cmbBirthPlace.DataTextField = "name";
            cmbBirthPlace.DataSource = ClassLibrary.JCities.GetDataTable(ClassLibrary.JBaseDefine.CityCode);
            cmbBirthPlace.DataBind();
            // Issue Place (Sader)
            cmbIssuePlace.DataValueField = "Code";
            cmbIssuePlace.DataTextField = "name";
            cmbIssuePlace.DataSource = ClassLibrary.JCities.GetDataTable(ClassLibrary.JBaseDefine.CityCode);
            cmbIssuePlace.DataBind();
            // Work City
            cmbWorkCity.DataValueField = "Code";
            cmbWorkCity.DataTextField = "name";
            cmbWorkCity.DataSource = ClassLibrary.JCities.GetDataTable(ClassLibrary.JBaseDefine.CityCode);
            cmbWorkCity.DataBind();
            // Home City
            cmbHomeCity.DataValueField = "Code";
            cmbHomeCity.DataTextField = "name";
            cmbHomeCity.DataSource = ClassLibrary.JCities.GetDataTable(ClassLibrary.JBaseDefine.CityCode);
            cmbHomeCity.DataBind();

            if (Code > 0)
            {
                ClassLibrary.JPerson jPerson = new ClassLibrary.JPerson(Code);
                txtCode.Text = Code.ToString();
                txtName.Text = jPerson.Name;
                txtFam.Text = jPerson.Fam;
                txtFather.Text = jPerson.FatherName;
                txtShSh.Text = jPerson.ShSh;
                txtDescription.Text = jPerson.PDesc;
                txtShareHolderCode.Text = jPerson._SharePCode.ToString();

                txtCodeMelli.Text = jPerson.ShMeli;
                ((WebControllers.MainControls.Date.JDateControl)txtBirthDate).SetDate(jPerson.BthDate);
                txtTafsili.Text = jPerson._TafsiliCode.ToString();
                // Birth Place
                cmbBirthPlace.SelectedValue = jPerson.BirthplaceCode.ToString();
                // Issue Place (Sader)
                cmbIssuePlace.SelectedValue = jPerson.Sader.ToString();
                // Gender (Male, Female)
                cmbGender.SelectedValue = jPerson.Gender == true ? "1" : "0";
                int PersonNumber = jPerson.GetPersonNumber();
                if (PersonNumber > 0) txtPersonNumber.Text = PersonNumber.ToString();
                // Person Image
                LoadImage();

                // // // Tab: Home
                txtHomeAddress.Text = jPerson.HomeAddress.Address;
                // Home City
                cmbHomeCity.SelectedValue = jPerson.HomeAddress.City.ToString();

                txtHomePostalCode.Text = jPerson.HomeAddress.PostalCode;
                txtHomeTel.Text = jPerson.HomeAddress.Tel;
                txtHomeFax.Text = jPerson.HomeAddress.Fax;
                txtHomeMobile.Text = jPerson.HomeAddress.Mobile;
                txtHomeEmail.Text = jPerson.HomeAddress.Email;

                // // // Tab: Work
                txtWorkAddress.Text = jPerson.WorkAddress.Address;
                // Work City
                cmbWorkCity.SelectedValue = jPerson.WorkAddress.City.ToString();

                txtWorkPostalCode.Text = jPerson.HomeAddress.PostalCode;
                txtWorkTel.Text = jPerson.WorkAddress.Tel;
                txtWorkFax.Text = jPerson.WorkAddress.Fax;
                txtWorkWebSite.Text = jPerson.WorkAddress.WebSite;
                txtWorkEmail.Text = jPerson.WorkAddress.Email;

                // // // Tab: Smart Card
                //dgrSmartCard.DataSource = SmartCardSepad.JCardDefines.GetCards(jPerson.Code);
                try
                {
                    // // // Tab: Assets
                    dgrAssets.DataSource = (new Finance.JAsset(Code)).GetAssetPerson(jPerson.Code);
                    dgrAssets.DataBind();
                }
                catch
                {

                }
                // // // Tab: Contract
                dgrContract.DataSource = Legal.JSubjectContracts.PersonContractHistory(jPerson.Code);
            }
        }

        private void LoadImage()
        {
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(person.PersonImageCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                        imgPerson.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                }
                else
                    imgPerson.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage);
            }
            catch { }

        }

        private void SaveImage()
        {
            if (Code == 0) return;
            if (imgPerson.DataValue == null) return;
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = imgPerson.DataValue;
                jFile.FileName = imgPerson.ToolTip;
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                if (person.PersonImageCode > 0 && archive.Retrieve(person.PersonImageCode))
                    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر شخص");
                else
                    person.PersonImageCode = archive.ArchiveDocument(jFile, person.GetType().FullName, person.Code, JLanguages._Text("PersonPicture"), true);
                if (person.UpdateAvl())// person.Update())
                {

                }
            }
            catch { }

        }

        public bool Save()
        {
            int tmp = 0;
            ClassLibrary.JPerson jPerson = new ClassLibrary.JPerson(Code);
            jPerson.Name = txtName.Text;
            jPerson.Fam = txtFam.Text;
            jPerson.FatherName = txtFather.Text;
            jPerson.ShSh = txtShSh.Text;
            jPerson.PDesc = txtDescription.Text;
            int.TryParse(txtShareHolderCode.Text, out tmp);
            jPerson._SharePCode = tmp;

            jPerson.ShMeli = txtCodeMelli.Text;
            jPerson.BthDate = ((WebControllers.MainControls.Date.JDateControl)txtBirthDate).GetDate();
            int.TryParse(txtTafsili.Text, out tmp);
            jPerson._TafsiliCode = tmp;
            // Birth Place
            int.TryParse(cmbBirthPlace.SelectedValue, out tmp);
            jPerson.BirthplaceCode = tmp;
            // Issue Place (Sader)
            int.TryParse(cmbIssuePlace.SelectedValue, out tmp);
            jPerson.Sader = tmp;
            // Gender (Male, Female)
            jPerson.Gender = (cmbGender.SelectedValue == "1" ? true : false);
            cmbGender.SelectedValue = (jPerson.Gender == true ? "1" : "0");

            // // // Home
            if (jPerson.HomeAddress == null) jPerson.HomeAddress = new JPersonAddress();
            jPerson.HomeAddress.Address = txtHomeAddress.Text;
            int.TryParse(cmbHomeCity.SelectedValue, out tmp);
            jPerson.HomeAddress.City = tmp;
            jPerson.HomeAddress.PostalCode = txtHomePostalCode.Text;
            jPerson.HomeAddress.Tel = txtHomeTel.Text;
            jPerson.HomeAddress.Fax = txtHomeFax.Text;
            jPerson.HomeAddress.Mobile = txtHomeMobile.Text;
            jPerson.HomeAddress.Email = txtHomeEmail.Text;

            // // // Work
            if (jPerson.WorkAddress == null) jPerson.WorkAddress = new JPersonAddress();
            jPerson.WorkAddress.Address = txtWorkAddress.Text;
            int.TryParse(cmbWorkCity.SelectedValue, out tmp);
            jPerson.WorkAddress.City = tmp;
            jPerson.WorkAddress.PostalCode = txtWorkPostalCode.Text;
            jPerson.WorkAddress.Tel = txtWorkTel.Text;
            jPerson.WorkAddress.Fax = txtWorkFax.Text;
            jPerson.WorkAddress.WebSite = txtWorkWebSite.Text;
            jPerson.WorkAddress.Email = txtWorkEmail.Text;
            int PersonNumber = 0;
            int.TryParse(txtPersonNumber.Text, out PersonNumber);

            // Property and Archive
            ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).Save();

            if (Code > 0)
            {
                jPerson.Code = Code;
                if ( jPerson.Update() && jPerson.UpdateEmp(PersonNumber))
                    return true;
            }
            else
            {
                Code = jPerson.insert();
                if (Code == 0) return false;
                else return jPerson.InsertEmp(PersonNumber) > 0 ? true : false;
            }

            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (JPermission.CheckPermission("WebBaseDefine.Forms.JRealPersonUpdateControl.btnSave"))
            {
                if (txtFam.Text != "" && txtFam.Text != null)
                {
                    if (txtName.Text != "" && txtName.Text != null)
                    {
                        if (Save() || Code > 0)
                        {
                            WebClassLibrary.JWebManager.ShowMessage("ثبت با موفقیت انجام شد");
                            WebClassLibrary.JWebManager.RunClientScript("GetRadWindow().close();", "ConfirmDialog");
                        }
                        else
                            WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید");
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.ShowMessage("لطفا نام را وارد کنید");
                    }
                }
                else
                {
                    WebClassLibrary.JWebManager.ShowMessage("لطفا نام خانوادگی را وارد کنید");
                }
                return;
            }
            ClassLibrary.JPerson jPerson = new ClassLibrary.JPerson();
            //if (txtCodeMelli.Text != "" && txtCodeMelli.Text != null)
            //{
            //if (jPerson.checkCodeMeliNew(txtCodeMelli.Text))
            //{
            if (jPerson.find(txtCodeMelli.Text) == false)
            {
                if (txtShSh.Text != "" && txtShSh.Text != null)
                {
                    if (txtFam.Text != "" && txtFam.Text != null)
                    {
                        if (txtName.Text != "" && txtName.Text != null)
                        {
                            if (Save())
                                WebClassLibrary.JWebManager.ShowMessage("ثبت با موفقیت انجام شد");
                            else
                                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. لطفا پس از بررسی مجددا سعی نمایید");
                        }
                        else
                        {
                            WebClassLibrary.JWebManager.ShowMessage("لطفا نام را وارد کنید");
                        }
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.ShowMessage("لطفا نام خانوادگی را وارد کنید");
                    }
                }
                else
                {
                    WebClassLibrary.JWebManager.ShowMessage("لطفا شماره شناسنامه را وارد کنید");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.ShowMessage("کد ملی تکراری است");
            }
            //}
            //else
            //{
            //    WebClassLibrary.JWebManager.ShowMessage("لطفا کد ملی را صحیح وارد کنید");
            //}
            //}
            //else
            //{
            //    WebClassLibrary.JWebManager.ShowMessage("لطفا کد ملی را وارد کنید");
            //}
        }

        protected void upldPhoto_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            imgPerson.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
            imgPerson.ToolTip = e.File.FileName;
            SaveImage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                ClassLibrary.JPerson jPerson = new ClassLibrary.JPerson(Code);
                jPerson.getData(Code);
                if (jPerson.WebDelete())
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('حذف شخص حقیقی مورد نظر با موفقیت انجام شد');", "ConfirmDialog");
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
                }
            }
        }

        ///@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@----@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        /// 

        //public string ClassName
        //{
        //    get
        //    {
        //        if (ViewState["ClassName"] == null)
        //            return "";
        //        return ViewState["ClassName"].ToString();
        //    }
        //    set
        //    {
        //        ViewState["ClassName"] = value;
        //    }
        //}
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    // Get Variables
        //    WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager("FormManagers");
        //    FormCode = Convert.ToInt32(formSUID.GetObject("FormCode"));
        //    ObjectCode = Convert.ToInt32(formSUID.GetObject("ObjectCode"));
        //    if (formSUID.GetObject("TableCode") != null)
        //        TableCode = Convert.ToInt32(formSUID.GetObject("TableCode"));
        //    if (formSUID.GetObject("ClassName") != null)
        //        FormManagerClassName = formSUID.GetObject("ClassName").ToString();
        //    ClassLibrary.JFormObjects jFormObjects = new ClassLibrary.JFormObjects(FormCode);
        //    //FormCode = jFormObjects.Code;
        //    if (formSUID.GetObject("ReferCode") != null)
        //        ReferCode = Convert.ToInt32(formSUID.GetObject("ReferCode"));
        //    else
        //        ReferCode = 0;
        //    if (formSUID.GetObject("ValueObjectCode") != null)
        //        ValueObjectCode = Convert.ToInt32(formSUID.GetObject("ValueObjectCode"));
        //    else
        //        ValueObjectCode = jFormObjects.Code;
        //    if (formSUID.GetObject("IsMultiple") != null)
        //        isMultiple = (bool)formSUID.GetObject("IsMultiple");
        //    else
        //        isMultiple = false;
        //    gridView2.Visible = isMultiple;
        //    if (isMultiple)
        //        databind();


        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).ClassName = FormManagerClassName;
        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).ObjectCode = FormCode;
        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).FormObjectCode = ObjectCode;
        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).ValueObjectCode = ValueObjectCode;
        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).TableCode = TableCode; // Insert Mode(New Record)
        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).isMultiple = isMultiple;
        //    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl1).LoadProperty(false);



        //    bool loadData = true;
        //    if (IsPostBack) loadData = false;
        //    if (isMultiple == false)
        //    {
        //        WebControllers.Property.JPropertyViewControl jPropertyViewControl = new WebControllers.Property.JPropertyViewControl();

        //        jPropertyViewControl.ID = "prop01";
        //        jPropertyViewControl.ClassName = FormManagerClassName;
        //        jPropertyViewControl.ObjectCode = FormCode;
        //        jPropertyViewControl.ValueObjectCode = ValueObjectCode;
        //        jPropertyViewControl.TableCode = TableCode;
        //        jPropertyViewControl.FormObjectCode = ObjectCode;
        //        jPropertyViewControl.isMultiple = isMultiple;
        //        jPropertyViewControl.KeyColumnWidth = "200";
        //        jPropertyViewControl.ValueColumnWidth = "450";
        //        jPropertyViewControl.LoadPropertyOnPageLoad(loadData);
        //        divProperties.Controls.Add(jPropertyViewControl);
        //        HtmlTableRow row = new HtmlTableRow();
        //        row.Cells.Add(new HtmlTableCell());
        //        row.Cells[0].Controls.Add(jPropertyViewControl);
        //        table.Rows.Add(row);
        //    }
        //    else
        //    {
        //        WebControllers.Property.JPropertyViewControl jPropertyViewControl = new WebControllers.Property.JPropertyViewControl();
        //        //Property.JPropertyViewControl();
        //        jPropertyViewControl.ID = "prop01";
        //        jPropertyViewControl.ClassName = FormManagerClassName;
        //        jPropertyViewControl.ObjectCode = FormCode;
        //        jPropertyViewControl.ValueObjectCode = ValueObjectCode;
        //        jPropertyViewControl.TableCode = TableCode;
        //        jPropertyViewControl.FormObjectCode = ObjectCode;
        //        jPropertyViewControl.isMultiple = isMultiple;
        //        jPropertyViewControl.KeyColumnWidth = "200";
        //        jPropertyViewControl.ValueColumnWidth = "450";
        //        jPropertyViewControl.LoadPropertyOnPageLoad(!IsPostBack);
        //        divProperties.Controls.Add(jPropertyViewControl);
        //        HtmlTableRow row = new HtmlTableRow();
        //        row.Cells.Add(new HtmlTableCell());
        //        row.Cells[0].Controls.Add(jPropertyViewControl);
        //        table.Rows.Add(row);
        //        databind();

        //    }
        //}

        //public void databind()
        //{
        //    if (FormManagerClassName == null || FormManagerClassName.Length <= 0 || FormCode <= 0)
        //        return;

        //    JProperties PT = new JProperties(FormManagerClassName, FormCode);
        //    DataTable dt = PT.GetPropertyTableData(ValueObjectCode);



        //    gridView2.DataSource = dt;
        //    gridView2.DataBind();

        //}

        //private bool Save2()
        //{

        //    if (table.Rows.Count == 0) return false;
        //    bool result = true;
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {

        //        if (table.Rows[i].Cells.Count < 1 || table.Rows[i].Cells[0].Controls.Count == 0) continue;
        //        WebControllers.Property.JPropertyViewControl prop = (WebControllers.Property.JPropertyViewControl)table.Rows[i].Cells[0].Controls[0];
        //        if (prop.Save() == false) result = false;
        //    }
        //    return result;
        //}

        //protected void btnSaveProp_Click(object sender, EventArgs e)
        //{
        //    if (Save2())
        //        if (!isMultiple)
        //        { }
        //        //WebClassLibrary.JWebManager.LoadControl("FormManagers"
        //        //            , "~/WebControllers/FormManager/JFormListControl.ascx"
        //        //            , "فرم ساز"
        //        //            , null
        //        //            , WebClassLibrary.WindowTarget.CurrentWindow
        //        //            , true, true, true, 600, 350);
        //        else
        //        {
        //            ValueObjectCode = (int)new WebClassLibrary.JSUIDManager("FormManagers").GetObject("ValueObjectCode");
        //            databind();
        //        }
        //    //WebClassLibrary.JWebManager.CloseWindow();
        //    else
        //        WebClassLibrary.JWebManager.ShowMessage("خطا در ذخیره سازی، مجددا سعی نمایید.");
        //}

        //protected void btnSaveProperty_Click(object sender, EventArgs e)
        //{
        //    if (!((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).Save())
        //        WebClassLibrary.JWebManager.ShowMessage("خطا در ثبت اطلاعات. لطفا مجددا سعی نمایید.");
        //    else
        //    {
        //        ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).TableCode = 0;
        //        ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).LoadProperty(true);
        //    }
        //}

        //protected void gridView2_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
        //    {
        //        LinkButton btn = new LinkButton();
        //        btn.Text = "حذف";
        //        btn.CommandName = "remove";
        //        btn.CommandArgument = (e.Item.DataItem as DataRowView)[0] + "|" + (e.Item.DataItem as DataRowView)[1];
        //        btn.OnClientClick = "return confirm('آیا از حذف این رکورد اطمینان دارید؟');";
        //        //e.Row.Cells[ci].Controls.Add(btn);
        //        TableCell cell = new TableCell();
        //        cell.Controls.Add(btn);
        //        e.Item.Cells.Add(cell);
        //    }
        //    if (e.Item.ItemType == GridItemType.Header)
        //    {
        //        Label lbl = new Label();
        //        lbl.Text = "عملیات";
        //        TableCell cell = new TableCell();
        //        cell.Controls.Add(lbl);
        //        e.Item.Cells.Add(cell);
        //    }
        //}

        //protected void gridView2_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    if (e.CommandName.ToLower() != "remove")
        //        return;
        //    int code = int.Parse(e.CommandArgument.ToString().Split('|')[0]);
        //    int valueObjectCode = int.Parse(e.CommandArgument.ToString().Split('|')[1]);//int.Parse(gridView.Rows[e.RowIndex].Cells[1].Text);
        //    JProperty jProperty = new JProperty();
        //    if (jProperty.DeleteDataByValueObjectCode(null, FormManagerClassName, FormCode, valueObjectCode, code))
        //        databind();
        //    else
        //        WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد.", WebClassLibrary.MessageType.Error);
        //}

        ////protected void btnClose_Click(object sender, EventArgs e)
        ////{
        ////    WebClassLibrary.JWebManager.LoadControl("FormManagers"
        ////                        , "~/WebControllers/FormManager/JFormListControl.ascx"
        ////                        , "فرم ساز"
        ////                        , null
        ////                        , WebClassLibrary.WindowTarget.CurrentWindow
        ////                        , true, true, true, 600, 350);
        ////}






    }


}


