using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JApartmentUpdateControl : System.Web.UI.UserControl
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
                System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT [Code]
                                                                                            ,[ProjectName]
                                                                                            ,[Metraj]
                                                                                            ,[TedadeVahed]
                                                                                            ,[TedadKhab]
                                                                                            ,[ShomareVahed]
                                                                                            ,[Tabaghe]
                                                                                            ,[Emkanat]
                                                                                            ,[Gheymat],ArchiveCode
                                                                                        FROM [dbo].[Android_Apartments] where Code = " + Code);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        txtEmkanat.Text = Dt.Rows[0]["Emkanat"].ToString();
                        txtGheymat.Text = Dt.Rows[0]["Gheymat"].ToString();
                        txtMetraj.Text = Dt.Rows[0]["Metraj"].ToString();
                        txtShomareVahed.Text = Dt.Rows[0]["ShomareVahed"].ToString();
                        txtTabaghe.Text = Dt.Rows[0]["Tabaghe"].ToString();
                        txtTedadKhab.Text = Dt.Rows[0]["TedadKhab"].ToString();
                        txtTedadVahed.Text = Dt.Rows[0]["TedadeVahed"].ToString();
                        txtTitle.Text = Dt.Rows[0]["ProjectName"].ToString();
                        ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                        archive.GetData(Convert.ToInt32(Dt.Rows[0]["ArchiveCode"].ToString()));
                        try
                        {
                            System.Data.DataTable DtA = archive.Retrieve("AndroidElahiye", 123456);
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

                ArchiveCode = archive.ArchiveDocument(jFile, "AndroidElahiye", WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "EntProjects", true);

                CuArchiveCode = ArchiveCode;
            }

            if (Code > 0)
            {




                Db.setQuery(@"Update [dbo].[Android_Apartments] Set 
                                           [ProjectName] = N'" + txtTitle.Text + @"' , 
                                           [Metraj] = N'" + txtMetraj.Text + @"' , 
                                           [TedadeVahed] = N'" + txtTedadVahed.Text + @"' , 
                                           [TedadKhab] = N'" + txtTedadKhab.Text + @"' , 
                                           [ShomareVahed] = N'" + txtShomareVahed.Text + @"' , 
                                           [Tabaghe] = N'" + txtTabaghe.Text + @"' , 
                                           [Emkanat] = N'" + txtEmkanat.Text + @"' , 
                                           [Gheymat] = N'" + txtGheymat.Text + @"' 
                                            ,ArchiveCode=" + CuArchiveCode + @"
                                           where Code = " + Code);
            }
            else
            {
                Db.setQuery(@"INSERT INTO [dbo].[Android_Apartments]
                               ([ProjectName]
                               ,[Metraj]
                               ,[TedadeVahed]
                               ,[TedadKhab]
                               ,[ShomareVahed]
                               ,[Tabaghe]
                               ,[Emkanat]
                               ,[Gheymat],ArchiveCode)
                         VALUES
                               (N'" + txtTitle.Text + @"'
                               ,N'" + txtMetraj.Text + @"'
                               ,N'" + txtTedadVahed.Text + @"'
                               ,N'" + txtTedadKhab.Text + @"'
                               ,N'" + txtShomareVahed.Text + @"'
                               ,N'" + txtTabaghe.Text + @"'
                               ,N'" + txtEmkanat.Text + @"'
                               ,N'" + txtGheymat.Text + @"'," + CuArchiveCode + @")");
            }
            if (Db.Query_Execute() >= 0)
            {
                return true;
            }
            else { return false; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                Db.setQuery(@"delete from [Android_Apartments] where Code = " + Code);
                if (Db.Query_Execute() >= 0)
                    WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }

    }
}