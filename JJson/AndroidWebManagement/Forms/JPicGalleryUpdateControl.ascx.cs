using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AndroidWebManagement.Forms
{
    public partial class JPicGalleryUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        public string PicStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                Entertainment.JPicGallery PicGallery = new Entertainment.JPicGallery();
                PicGallery.GetData(Code);
                txtText.Text = PicGallery.Text;

                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                archive.GetData(PicGallery.ArchiveCode);
                try
                {
                    DataTable Dt = archive.Retrieve("AndroidElahiye", 123456);
                    if (Dt.Rows.Count > 0)
                    {
                        ClassLibrary.JFile image = archive._RetrieveContent(Convert.ToInt32(archive.ArchiveCode));
                        PicStr = "<img src='data:image/jpg;base64," + Convert.ToBase64String(WebClassLibrary.JDataManager.ReadToEnd(image.Stream)) + "' style='max-width:500px'/>";
                    }
                }
                catch { }
            }
        }

        public bool Save()
        {
            if (FileUpload.HasFile)
            {
                Entertainment.JPicGallery PicGallery = new Entertainment.JPicGallery();
                PicGallery.Code = Code;
                PicGallery.Text = txtText.Text;
                PicGallery.ClassName = "AndroidElahiye";

                int ArchiveCode = 0;

                string[] segments = FileUpload.FileName.Split(new char[] { '.' });
                string fileExt = segments[segments.Length - 1];

                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = FileUpload.FileBytes;
                jFile.FileName = FileUpload.FileName;
                jFile.Extension = ".jpg";

                jFile.FileText = jFile.FileName;

                ArchiveCode = archive.ArchiveDocument(jFile, "AndroidElahiye", 123456, "EntPicGalleryPic", true);

                PicGallery.ArchiveCode = ArchiveCode;

                if (Code > 0)
                    return PicGallery.Update();
                else
                    return PicGallery.Insert() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}