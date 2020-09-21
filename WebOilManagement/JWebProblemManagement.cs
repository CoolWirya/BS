using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebProblemManagement
    {
        public const string _ConstClassName = "WebOilManagement.JWebProblemManagement";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(null, "ثبت و نگهداري راهکارهاي خرابی ها و مشکلات", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "جستجوي سریع راهکارهاي مربوط به مشکلات", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت تقویم PM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "یاد آوری برنامه PM بصورت اتوماتیک", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت گزارش PM توسط پیمانکار", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "جستجوی سریع راهکارهای مربوط به مشکلات", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت برنامه بر روی PM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت فعالیتهای PM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت فعالیتهای انجام شده به تفکیک تیم های موجود", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "درخواست کد رهگیری بصورت سیستمی برای PM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت انواع مشکلات", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ارجاع به GS Back Office", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "Import کردن اطلاعات پایداری", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ثبت انواع مشکلات، ثبت خلاقیتها و رفع مشکلات جهت Share تجربیات", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "ارجاع مشکلات خاص به معاونت اجرایی یا امور جایگاه ها", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "امکان ثبت و نگهداری راهکارهای خرابی‌ها و مشکلات", _ConstClassName, JDomains.Images.MenuImages.Item, null));

            return nodes;
        }
    }
}