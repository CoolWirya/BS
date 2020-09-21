using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebOrder
    {
        public const string _ConstClassName = "WebOilManagement.JWebOrder";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(null, "نظارت و کنترل بر Re-Initial و Initial کردن HDD", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست مربوط به تأسیس جایگاه در سیستم", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ارجاع درخواست به پیمانکار منطقه", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست SAM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت گزارش تاسیس یا راه اندازي مجدد جایگاه", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "کنترل درخواست Initial و Re-Initial کردن جایگاه", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "اولویت‌بندی درخواست", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست Initial و Re-Initial کردن جایگاه و ارجاع به Ping، Help Desk و PT Config", _ConstClassName, JDomains.Images.MenuImages.Item, null));

            return nodes;
        }
    }
}