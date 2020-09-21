using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTOMOBILE.AutomobileDefine;

namespace WebAutomobile.Forms
{
    public partial class JAutomobileDefineUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadAutomobileType();
            LoadMakerCompany();
            _SetForm();
        }

        public void LoadAutomobileType()
        {
            cmbAutomobileType.DataSource = JAutomobileTypes.GetDataTable(ClassLibrary.JBaseDefine.AutomobileType);
            cmbAutomobileType.DataValueField = "Code";
            cmbAutomobileType.DataTextField = "name";
            cmbAutomobileType.DataBind();
            if (cmbAutomobileType.Items.Count > 0)
            {
                cmbAutomobileType.Items[0].Remove();
                cmbAutomobileType.Items[0].Selected = true;
            }
        }

        public void LoadMakerCompany()
        {
            cmbManufacturerCompany.DataSource = JMakerCompanies.GetDataTable(ClassLibrary.JBaseDefine.MakerCompany);
            cmbManufacturerCompany.DataValueField = "Code";
            cmbManufacturerCompany.DataTextField = "name";
            cmbManufacturerCompany.DataBind();
            if (cmbManufacturerCompany.Items.Count > 0)
            {
                cmbManufacturerCompany.Items[0].Remove();
                cmbManufacturerCompany.Items[0].Selected = true;
            }
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                JAutomobileDefine automoile = new JAutomobileDefine();
                automoile.GetData(Code);
                txtPelakIranCode.Text = automoile.Plaque.Substring(7, 2);
                txtPelakRightNumber.Text = automoile.Plaque.Substring(3, 3);
                cmbPelakChar.SelectedValue = automoile.Plaque.Substring(2, 1);
                txtPelakLeftNumber.Text = automoile.Plaque.Substring(0, 2);
                cmbAutomobileType.SelectedValue = automoile.Type.ToString();
                txtModel.Text = automoile.Model.ToString();
                cmbManufacturerCompany.SelectedValue = automoile.maker.ToString();
                txtCapacity.Text = automoile.Capacity.ToString();
                chkStatus.Checked = automoile.Active;
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "AUTOMOBILE.AutomobileDefine.JAutomobileDefine";
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = Code;
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).LoadArchive();
            }
            LoadImage();
               
        }
        private void LoadImage()
        {
            if (Code < 1)
            {
                imgPerson.DataValue = WebClassLibrary.JDataManager.LoadFile("~/WebAVL/Icons/car.png");
                return;
            }
            JAutomobileDefine automoile = new JAutomobileDefine();
            automoile.GetData(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(automoile.IconCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                        imgPerson.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                }
                else
                    imgPerson.DataValue = WebClassLibrary.JDataManager.LoadFile("~/WebAVL/Icons/car.png");
                automoile.Update();
            }
            catch { }

        }
        public bool Save()
        {
            JAutomobileDefine automoile = new JAutomobileDefine();
            automoile.GetData(Code);
            string str = txtPelakLeftNumber.Text + cmbPelakChar.Text + txtPelakRightNumber.Text + "-" + txtPelakIranCode.Text;
            automoile.Plaque = str;
            try
            {
                automoile.Capacity = int.Parse(txtCapacity.Text);
            }
            catch
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('ظرفیت اتومبیل تنها عدد می تواند باشد.')", "ConfirmDialog");
                return false;
            }
            try
            {
                automoile.Model = int.Parse(txtModel.Text);
            }
            catch
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('مدل اتومبیل تنها عدد می تواند باشد.')", "ConfirmDialog");
                return false;
            }
            automoile.Type = Convert.ToInt32(cmbAutomobileType.SelectedValue);
            automoile.Active = chkStatus.Checked;
            automoile.maker = Convert.ToInt32(cmbManufacturerCompany.SelectedValue);

            if (Code > 0)
            {
                if (automoile.Update())
                {
                   // SaveImage();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                int code = automoile.Insert();
                if (code > 0)
                {
                    Code = code;
                  //  SaveImage();
                    return true;
                }
                else if (code == -1)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('این پلاک قبلا ثبت شده است.');", "ConfirmDialog");

                    return false;
                }
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "AUTOMOBILE.AutomobileDefine.JAutomobileDefine";
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = Code;
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).SaveToArchive();
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');GetRadWindow().close();", "ConfirmDialog");
            }
            else
            {
                
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                JAutomobileDefine automoile = new JAutomobileDefine();
                automoile.GetData(Code);
                if (automoile.GetData(Code) && automoile.Delete())
                    WebClassLibrary.JWebManager.RunClientScript("alert('حذف با موفقیت انجام شد');GetRadWindow().close();", "ConfirmDialog");
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');GetRadWindow().close();", "ConfirmDialog");
            }
        }



        protected void upldPhoto_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            imgPerson.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
            imgPerson.ToolTip = e.File.FileName;
            SaveImage();
        }


        private void SaveImage()
        {
         //   if (Code == 0) return;
            if (imgPerson.DataValue == null) return;
            AUTOMOBILE.AutomobileDefine.JAutomobileDefine au = new JAutomobileDefine();
            au.GetData(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = imgPerson.DataValue;
                jFile.FileName = imgPerson.ToolTip;
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                if (au.IconCode > 0 && archive.Retrieve(au.IconCode))
                    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "آیکون خودرو");
                else
                    au.IconCode = archive.ArchiveDocument(jFile, au.GetType().FullName, au.Code, ClassLibrary.JLanguages._Text("CarIcon"), true);
                 
                if(au.Update())
                {

                }
            }
            catch { }

        }


    }
}