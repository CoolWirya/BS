using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebChangeManagement
    {
        public const string _ConstClassName = "WebOilManagement.JWebChangeManagement";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(null, "مشاهده روال تغییرات", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست تغییر نوع سوخت و مخزن", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست تغییر مشخصات دفتر جایگاه", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست تغییر در SAM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت درخواست افزایش نازل", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "دانلود کردن   RPM براي پیمانکاران مناطق", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت تاریخ نصب   RPM توسط پیمانکار", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "تعیین جایگاههای نیازمند RPM برای پیمانکار", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "رویت تغییرات درخواستی مناطق برای SAM، Fuel Type و ناحیه جدیدالاحداث", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "مشاهده تغییرات درخواست شده و تایید برای تغییراتی نظیر Fuel Type و ظرفیت مخزن و SAM و ...", _ConstClassName, JDomains.Images.MenuImages.Item, null));

            return nodes;
        }
    }
}