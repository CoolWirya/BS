using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AndroidWebManagement.Forms
{
    public partial class JPicGalleryPicUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        public string PicStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadCategory();

            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                //ArchiveCode
                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from [EntPicGalleryLvl2] where Code = " + Code);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        txtTitle.Text = Dt.Rows[0]["Name"].ToString();
                        cmbPicCategory.SelectedValue = Dt.Rows[0]["Lvl1Code"].ToString();

                        ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                        archive.GetData(Convert.ToInt32(Dt.Rows[0]["ArchiveCode"].ToString()));
                        try
                        {
                            DataTable DtA = archive.Retrieve("AndroidElahiye", 123456);
                            if (DtA.Rows.Count > 0)
                            {
                                ClassLibrary.JFile image = archive._RetrieveContent(Convert.ToInt32(archive.ArchiveCode));
                                PicStr = "<img src='data:image/jpg;base64," + Convert.ToBase64String(WebClassLibrary.JDataManager.ReadToEnd(image.Stream)) + "' style='max-width:500px'/>";
                            }
                        }
                        catch { }

                    }
                }

            }
        }

        public bool Save()
        {

            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            int CuArchiveCode = 0;
            if (FileUpload.HasFile)
            {
                int ArchiveCode = 0;

                string[] segments = FileUpload.FileName.Split(new char[] { '.' });
                string fileExt = segments[segments.Length - 1];

                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = FileUpload.FileBytes;
                jFile.FileName = FileUpload.FileName;
                jFile.Extension = ".jpg";

                jFile.FileText = jFile.FileName;

                ArchiveCode = archive.ArchiveDocument(jFile, "AndroidElahiye", WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "EntPicGalleryLvl2", true);

                CuArchiveCode = ArchiveCode;
            }

            if (Code > 0)
                Db.setQuery(@"update EntPicGalleryLvl2 set Name = N'" + txtTitle.Text + "' ,ArchiveCode=" + CuArchiveCode + ",Lvl1Code=" + cmbPicCategory.SelectedValue + " where Code = " + Code);
            else
                Db.setQuery(@"INSERT INTO [EntPicGalleryLvl2] ([Lvl1Code],[Name],[ArchiveCode]) VALUES (" + cmbPicCategory.SelectedValue + ",N'" + txtTitle.Text + "'," + CuArchiveCode + ") ");

            if (Db.Query_Execute() >= 0)
                return true;
            else
                return false;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Code > 0)
            {

                Db.setQuery(@"delete from EntPicGalleryLvl2 where Code = " + Code);

                if (Db.Query_Execute() >= 0)
                    WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت حذف شد');", "OKDialog");

            }
        }

        public void LoadCategory()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT [Code]
                                                                                  ,[Name]
                                                                              FROM [EntPicGalleryLvl1]");
            cmbPicCategory.DataSource = dt;
            cmbPicCategory.DataTextField = "Name";
            cmbPicCategory.DataValueField = "Code";
            cmbPicCategory.DataBind();
        }
    }


}