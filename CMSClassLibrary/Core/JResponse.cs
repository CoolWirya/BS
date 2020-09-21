using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace CMSClassLibrary.Core
{
    public class JResponse 
    {
        public JResponse()
        {
           
            
        }

        public void JRedirect(string input)
        {
            HttpContext.Current.Response.Redirect("~/administrator/" + input);
        }
    }
}
