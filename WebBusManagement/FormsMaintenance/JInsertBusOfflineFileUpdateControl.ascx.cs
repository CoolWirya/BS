using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JInsertBusOfflineFileUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
            _SetForm();
            if (!IsPostBack)
                LoadBus();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.JBusOfflineFiles BusOFFlineFiles = new BusManagment.JBusOfflineFiles();
                BusOFFlineFiles.GetData(Code);
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(BusOFFlineFiles.Date);
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = BusOFFlineFiles.SenderPersonCode;
                cmbBus.SelectedValue = BusOFFlineFiles.BusCode.ToString();
                txtDiscription.Text = BusOFFlineFiles.Discription;
            }
        }

        public bool Save()
        {
            if (FileUpload.HasFile)
            {
                BusManagment.JBusOfflineFiles BusOFFlineFiles = new BusManagment.JBusOfflineFiles();
                BusOFFlineFiles.Code = Code;
                BusOFFlineFiles.Date = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate();
                BusOFFlineFiles.SenderPersonCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
                BusOFFlineFiles.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
                BusOFFlineFiles.Discription = txtDiscription.Text;

                int ArchiveCode = 0;

                string[] segments = FileUpload.FileName.Split(new char[] { '.' });
                string fileExt = segments[segments.Length - 1];

                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = FileUpload.FileBytes;
                jFile.FileName = FileUpload.FileName;

                string FleetFileType = "";
                if (BusManagment.Settings.JBusSettings.Get("FleetCode").ToString() == "1000002")
                {
                    FleetFileType = "Public";
                }
                else
                {
                    FleetFileType = "";
                }
                if (fileExt.ToLower() == "bin")
                    jFile.Extension = "." + FleetFileType + "bus";
                else if (fileExt.ToLower() == "db")
                    jFile.Extension = "." + FleetFileType + "db";
                else if (fileExt.ToLower() == "ini")
                    jFile.Extension = "." + FleetFileType + "ini";

                jFile.FileText = jFile.FileName;

                if (fileExt.ToLower() == "bin")
                    ArchiveCode = archive.ArchiveDocument(jFile, "WebBusManagement.FormsMaintenance.JInsertBusOfflineFileUpdateControl", ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, "BusOfflineFile", true);
                else if (fileExt.ToLower() == "db")
                    ArchiveCode = archive.ArchiveDocument(jFile, "WebBusManagement.FormsMaintenance.JInsertBusOfflineFileUpdateControl", ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, "BusSqlLiteDataBase", true);
                else if (fileExt.ToLower() == "ini")
                    ArchiveCode = archive.ArchiveDocument(jFile, "WebBusManagement.FormsMaintenance.JInsertBusOfflineFileUpdateControl", ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, "BusPublicIniFile", true);

                BusOFFlineFiles.ArchiveCode = ArchiveCode;

                if (Code > 0)
                    return BusOFFlineFiles.Update();
                else
                    return BusOFFlineFiles.Insert() > 0 ? true : false;
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