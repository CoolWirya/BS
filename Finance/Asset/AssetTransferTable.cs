using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{

    public class JAssetTransferTable : ClassLibrary.JTable
    {
        public JAssetTransferTable()
            : base("finAssetTransfer")
        {
        }

        /// <summary>
        /// کد دارای
        /// </summary>
        public int ACode;
        /// <summary>
        /// 
        /// </summary>
        public int ParentCode;
        /// <summary>
        /// نوع مالکیت
        /// </summary>
        public JOwnershipType OwnershipType;
        /// <summary>
        /// نام کلاس انتقال
        /// </summary>
        public string ClassName;
        /// <summary>
        /// کد شی انتقال
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment;
    }

    public enum finAssetTransfer
    {
        Code,
        ACode,
        ParentCode,
        OwnershipType,
        ClassName,
        ObjectCode,
        Comment
    }
}
