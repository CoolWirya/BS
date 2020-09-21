using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
        /// <summary>
        /// گروه کالا
        /// </summary>
        public class JGoodsGroup : JSubBaseDefine
        {
            public JGoodsGroup()
                : base(JBaseDefine.GoodsGroup)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class JGoodsGroups : JSubBaseDefines
        {
            public JGoodsGroups()
                : base(JBaseDefine.GoodsGroup)
            {

            }
        }    
}
