using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls.Configuration
{
    public class JConfiguration
    {
        public string MainConfiguration()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Configuration"
                , "~/WebControllers/MainControls/Configuration/JMainConfigurationControl.ascx"
                , "پروفایل"
                , null
                , WebClassLibrary.WindowTarget.NewWindow
                , false, true, true, 500, 500, true);
        }

        public string _Information()
        {
            return "";
            //return WebClassLibrary.JWebManager.LoadClientControl("Configuration_Information"
            //    , "~/WebControllers/MainControls/Configuration/JUserPasswordUpdateControl.ascx"
            //    , "تغییر کلمه عبور"
            //    , null
            //    , WebClassLibrary.WindowTarget.NewWindow
            //    , true, false, true, 500, 400, false);
        }

        public string _ChangePassword()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Configuration_ChangePassword"
                , "~/WebControllers/MainControls/Configuration/JUserPasswordUpdateControl.ascx"
                , "تغییر کلمه عبور"
                , null
                , WebClassLibrary.WindowTarget.NewWindow
                , true, false, true, 500, 250, false);
        }

        public string _Settings()
        {
            return "";
            //return WebClassLibrary.JWebManager.LoadClientControl("Configuration_Settings"
            //    , "~/WebControllers/MainControls/Configuration/JUserPasswordUpdateControl.ascx"
            //    , "تغییر کلمه عبور"
            //    , null
            //    , WebClassLibrary.WindowTarget.NewWindow
            //    , true, false, true, 500, 400, false);
        }
    }
}