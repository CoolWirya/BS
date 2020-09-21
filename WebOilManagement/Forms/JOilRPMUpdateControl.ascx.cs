using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;
using System.Data.OleDb;


namespace WebOilManagement.Forms
{

    public partial class JRPMUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                btnDownloadFile.Visible = true;
                OilProductsDistributionCompany.RPM.JRPM jRPM = new OilProductsDistributionCompany.RPM.JRPM();
                jRPM.GetData(Code);
                txtVersion.Text = jRPM.Version;
                ((WebControllers.MainControls.Date.JDateControl)jDateRegister).SetDate(jRPM.DateRegister);
                txtComment.Text = jRPM.Comment;
                txtTableQuotas.Text = jRPM.TableQuotas.ToString();
                txtTablePrices.Text = jRPM.TablePrices.ToString();
                txtPtVersion.Text = jRPM.PtVersion;
                txtVersion.Text = jRPM.Version;
            }
            else
                btnDownloadFile.Visible = false;
        }

        public bool Save()
        {
            OilProductsDistributionCompany.RPM.JRPM jRPM = new OilProductsDistributionCompany.RPM.JRPM();
            if (Code > 0) jRPM.GetData(Code);

            jRPM.Comment = txtComment.Text;
            jRPM.DateRegister = ((WebControllers.MainControls.Date.JDateControl)jDateRegister).GetDate();
            jRPM.PtVersion = txtPtVersion.Text;
            jRPM.TablePrices = int.Parse(txtTablePrices.Text);
            jRPM.TableQuotas = int.Parse(txtTableQuotas.Text);
            jRPM.Version = txtPtVersion.Text;

            bool result=false;
            if (Code > 0)
                result = jRPM.Update();
            else
                Code = jRPM.Insert();

            if (Code > 0)
                result = true;


            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = WebClassLibrary.JDataManager.ReadToEnd(radUpload.UploadedFiles[0].InputStream);
                jFile.FileName = txtPtVersion.Text;
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                if (jRPM.FileCode > 0 && archive.Retrieve(jRPM.FileCode))
                    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "PT_File");
                else
                {
                    jRPM.FileCode = archive.ArchiveDocument(jFile, jRPM.GetType().FullName, jRPM.Code, "PT_File", true);
                    jRPM.Update();
                }
            }
            catch { }
            OilProductsDistributionCompany.RPM.JOilRPMGS jOilRPMGS = new OilProductsDistributionCompany.RPM.JOilRPMGS();
            if (Code > 0 )
            {
                string Path = Convert.ToString(DateTime.Now.Month) + "." + Convert.ToString(DateTime.Now.Day) + "." + Convert.ToString(DateTime.Now.Hour) + "." +
                   Convert.ToString(DateTime.Now.Minute) + "." + Convert.ToString(DateTime.Now.Second),
                   FilePath = Server.MapPath(@"\Temp\" + Path + radUploadXls.FileName);
                radUploadXls.SaveAs(FilePath);
                OilProductsDistributionCompany.RPM.JOilRPMGS jRPMGS = new OilProductsDistributionCompany.RPM.JOilRPMGS();
                jRPMGS.Insert(FilePath,Code);
            }
            return result;
        }


       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDownloadFile_Click(object sender, EventArgs e)
        {
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(person.PersonImageCode))
                {
                    ClassLibrary.JFile file = archive.Content;
                    if (file != null)
                    {
                        try
                        {
                            WebClient req = new WebClient();
                            HttpResponse response = HttpContext.Current.Response;
                            response.Clear();
                            response.ClearContent();
                            response.ClearHeaders();
                            response.Buffer = true;
                            response.AddHeader("Content-Disposition", "attachment;filename=\"" + txtVersion.Text + "\"");
                            byte[] data = file.Content;
                            response.BinaryWrite(data);
                            response.End();


                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch { }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.RPM.JRPM jRPM = new OilProductsDistributionCompany.RPM.JRPM();
            jRPM.Code = Code;
            if (jRPM.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}