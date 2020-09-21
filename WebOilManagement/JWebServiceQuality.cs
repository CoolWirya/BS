using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebServiceQuality
    {
        public const string _ConstClassName = "WebOilManagement.JWebServiceQuality";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(null, "تعریف SLA  بر اساس اولویت خرابی ", _ConstClassName, JDomains.Images.MenuImages.Folder, null));
            nodes.Add(new JNode(null, "مانیتورینگ SLA  در درخواست ها وخرابی ها ", _ConstClassName, JDomains.Images.MenuImages.Folder, null));
            nodes.Add(new JNode(null, "رویت میزان رعایت SLA", _ConstClassName, JDomains.Images.MenuImages.Folder, null));

            return nodes;
        }
    }
}