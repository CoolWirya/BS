using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globals.Property
{
    public class JPropertyTable: ClassLibrary.JTable
    {
        #region Fields
        /// <summary>
        /// نام فیلد
        /// </summary>
        public string Name;
        /// <summary>
        /// عنوان کلاس
        /// </summary>
        public string ClassName;
        /// <summary>
        /// كد شی
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// نوع
        /// </summary>
        public string DataType;
        /// <summary>
        /// 
        /// </summary>
        public string ListType;
        /// <summary>
        /// مقدار پیش فرض
        /// </summary>
        public object DefaultValue;
        /// <summary>
        /// ترتیب
        /// </summary>
        public int Ordered;
        /// <summary>
        /// فعال
        /// </summary>
        public bool Active;
        /// <summary>
        /// لیست
        /// </summary>
        public string List;
        /// <summary>
        /// 
        /// </summary>
        public string ListCanView;
        /// <summary>
        /// 
        /// </summary>
        public string ListCanEdit;
        #endregion

        public JPropertyTable()
            : base("propertydefinetables")
        {
        }
    }
}
