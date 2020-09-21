using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    /// <summary>
    /// نوع کالا
    /// </summary>
    public class JStorageType : JSubBaseDefine
    {
        public JStorageType()
            : base(JBaseDefine.StorageType)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JStorageTypes : JSubBaseDefines
    {
        public JStorageTypes()
            : base(JBaseDefine.StorageType)
        {

        }
    } 

}
