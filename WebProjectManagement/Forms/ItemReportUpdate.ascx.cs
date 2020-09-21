using System;
using ProjectManagement;

namespace WebProjectManagement.Forms
{
    public partial class ItemReportUpdate : System.Web.UI.UserControl
    {
        int code, itemcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            code = itemcode = 0;
            int.TryParse(Request["Code"].ToString(), out code);
            int.TryParse(Request["ItemCode"].ToString(), out itemcode);

            ProjectManagement.ItemReport.JItemReport r = null;
            ProjectManagement.MixedObjects.ItemAndProjectDetails i = null;
            if (code > 0)
            { r = new ProjectManagement.ItemReport.JItemReport(code);
                itemcode = r.ItemCode;
            }
            if (itemcode > 0)
                i = new ProjectManagement.MixedObjects.ItemAndProjectDetails(itemcode,new ProjectManagement.Item.JItem(itemcode).ProjectCode);

            _SetForms(r, i);
        }

        private void _SetForms(ProjectManagement.ItemReport.JItemReport r, ProjectManagement.MixedObjects.ItemAndProjectDetails i)
        {
            if (i != null)
            {
                if (i.Project != null) txtProjectName.Text = i.Project.Name;
                if (i.ParentItem != null) txtParentNodes.Text = i.ParentItem.Name;
                if (i.Item != null) txtName.Text = i.Item.Name;
            }

            int itemcode = (i != null && i.Item != null) ? i.Item.Code : (r != null) ? r.ItemCode : 0;
            //Load Pictures
            System.Data.DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from pmItemReport WHERE ItemCode=" +itemcode );
            if (DtReport == null) return;
            Tools.LoadItemReportImages(pnlImages, DtReport);

            ((WebControllers.MainControls.Date.JDateControl)date).SetDate(DateTime.Today);
                txtImprovementPercent.Text = "0";
            if (r == null) return;
                txtImprovementPercent.Text =((int) r.WeightPercentage).ToString();
            txtReportDescription.Text = r.ReportDescription;
            txtImprovementPercent.Visible = true;
            ((WebControllers.MainControls.Date.JDateControl)date).SetDate(r.RegisterDate);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtImprovementPercent.Text.ContainsNonDigit())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('برای وزن فقط عدد باید وارد کرد.');", "ConfirmDialog");
                return;
            }
            ProjectManagement.ItemReport.JItemReport p = new ProjectManagement.ItemReport.JItemReport(code);

            p.ItemCode = itemcode;
            p.RegisterDate = ((WebControllers.MainControls.Date.JDateControl)date).GetDate();// DateTime.Now;
            p.ReportDescription = txtReportDescription.Text;
            p.UserCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            p.WeightPercentage =(int) txtImprovementPercent.Text.ToFloat();
            if (p.WeightPercentage > 100) p.WeightPercentage = 100;
            if (p.WeightPercentage <0) p.WeightPercentage = 0;
            p.HasPic = uploadPhoto.UploadedFiles.Count > 0;
            bool res;
            if (p.Code == 0) res = (p.Insert() > 0);
            else res = p.Update();

            if (res)
            {
                SaveImages(p.Code);
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعات وارد شد.');CloseDialog(null);", "ConfirmDialog");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات.');", "ConfirmDialog");

        }

        private void SaveImages(int itemReportCode)
        {
            Telerik.Web.UI.RadBinaryImage img;
            ClassLibrary.JFile jFile;
            foreach (Telerik.Web.UI.UploadedFile f in uploadPhoto.UploadedFiles)
            {
                img = new Telerik.Web.UI.RadBinaryImage();
                img.DataValue = WebClassLibrary.JDataManager.ReadToEnd(f.InputStream);
                img.ToolTip = f.FileName;
                img.Height = 200;
                img.Width = 200;
                img.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;

                jFile = new ClassLibrary.JFile();
                jFile.Content = img.DataValue;
                jFile.FileName = itemReportCode + "-" + DateTime.Now.ToString() + ".jpg";
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                pnlImages.Controls.Add(img);
                SaveImage(jFile, itemReportCode);
            }
        }


        private void SaveImage(ClassLibrary.JFile jFile, int itemReportCode)
        {

            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                //  archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر شخص");
               archive.ArchiveDocument(jFile,typeof(ProjectManagement.ItemReport.JItemReport).FullName, itemReportCode, "ItemReportImages", true);
                    

            }
            catch (Exception er)
            {
            }
        }
        
    }
}