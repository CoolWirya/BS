using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.CustomListSelector
{
    public partial class WebOilFailure_GS_Nozzle_Control : System.Web.UI.UserControl
    {
        public string GasStationSQL
        {
            get
            {
                return ClassLibrary.JEnryption.DecryptStr(hfdGS.Value, WebClassLibrary.SessionManager.Current.SessionID);
            }

            set
            {
                hfdGS.Value = ClassLibrary.JEnryption.EncryptStr(value, WebClassLibrary.SessionManager.Current.SessionID);
            }
        }
        public string NozzleSQL
        {
            get
            {
                return ClassLibrary.JEnryption.DecryptStr(hfdNozzle.Value, WebClassLibrary.SessionManager.Current.SessionID);
            }

            set
            {
                hfdNozzle.Value = ClassLibrary.JEnryption.EncryptStr(value, WebClassLibrary.SessionManager.Current.SessionID);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}