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
    public class JGoodsType : JSubBaseDefine
    {
        public JGoodsType()
            : base(JBaseDefine.GoodsType)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JGoodsTypes : JSubBaseDefines
    {
        public JGoodsTypes()
            : base(JBaseDefine.GoodsType)
        {
        }
    }  

}
