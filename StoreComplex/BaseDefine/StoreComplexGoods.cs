using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    /// <summary>
    /// کالاها در مجتمع انبارها
    /// </summary>
    public class JSCGood : JSubBaseDefine
    {
        public JSCGood() :
            base(JBaseDefine.GoodsGroup)
        {
        }
    }

    public class JSCGoods : JSubBaseDefines
    {
        public JSCGoods() :
            base(JBaseDefine.GoodsGroup)
        {
        }
    }
}
