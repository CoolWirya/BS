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
    public class JMeasureType : JSubBaseDefine
    {
        public JMeasureType()
            : base(JBaseDefine.MeasureType)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JMeasureTypes : JSubBaseDefines
    {
        public JMeasureTypes()
            : base(JBaseDefine.MeasureType)
        {

        }
    } 
}
