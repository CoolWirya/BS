using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusManagment.Zone;
using System.Data;
using BusManagment.Station;
using ClassLibrary;
using System.IO;

namespace WebBusManagement.FormsManagement
{
    public partial class JRTPISFileDownloadUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);

        }

        protected void uplFile_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            string configPath = "~/";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
            string __appPath = config.AppSettings.Settings["RootPath"].Value;
            if (__appPath.EndsWith("\\") == true) __appPath = __appPath.Substring(0, __appPath.Length - 1);

            __appPath = "D:\\Service";
            
            if (File.Exists(__appPath + "\\RTPISFile\\Tablo.bin"))
                File.Delete(__appPath + "\\RTPISFile\\Tablo.bin");
            var fileStream = File.Create(__appPath + "\\RTPISFile\\Tablo.bin");
            e.File.InputStream.Seek(0, SeekOrigin.Begin);
            e.File.InputStream.CopyTo(fileStream);
            fileStream.Close();
        }


        public void _SetForm()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}