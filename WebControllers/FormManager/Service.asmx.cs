﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebControllers.FormManager
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetSqlTypes()
        {
            string[] vals = Enum.GetNames(typeof(Globals.Property.JSQLDataType));
            return String.Join(",", vals); ;
        }
        [WebMethod]
        public string GetPropertyListTypes()
        {
            string[] vals = Enum.GetNames(typeof(Globals.Property.JProppertyListType));
            return String.Join(",", vals); ;
        }
    }
}
