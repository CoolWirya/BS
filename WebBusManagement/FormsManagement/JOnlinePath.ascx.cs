using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JOnlinePath : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLines();
            }
        }
        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            cmbLines.DataSource = dt;
            cmbLines.DataTextField = "LineNumber";
            cmbLines.DataValueField = "Code";
            cmbLines.DataBind();
        }
        public string BusUrl
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
    }
}