using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMSClassLibrary.Site;

namespace CMS.SiteManagement
{
    public class JSites
    {
        JSite NewSite;
        public int Code { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }

        public bool Insert()
        {
            NewSite = new JSite();
            NewSite.Title = Title;
            NewSite.Domain = Domain;
            NewSite.Description = Description;
            if (Code != 0)
            {
                NewSite.Code = Code;
                return NewSite.Update();
            }
            else
                return NewSite.Insert();
        }
    }
}