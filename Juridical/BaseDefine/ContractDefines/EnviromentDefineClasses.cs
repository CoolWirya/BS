using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    /// <summary>
    /// نوع کاربری در قرارداد مشاعات
    /// </summary>
    public class JEnviromentUsage : JSubBaseDefine
    {
        public JEnviromentUsage()
            : base(Legal.JContractBaseDefines.EnviromentUsage)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JEnviromentUsages : JSubBaseDefines
    {
        public JEnviromentUsages()
            : base(Legal.JContractBaseDefines.EnviromentUsage)
        {

        }
    }
    //////////////////////////////
    /// نحوه پرداخت در قرارداد مشاعات
    /// //////////////////////////
 

   /// <summary>
    /// 
    /// </summary>
    public class JEnviromentPaymentType : JSubBaseDefine
    {
        public JEnviromentPaymentType()
            : base(Legal.JContractBaseDefines.EnviromentPaymentType)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JEnviromentPaymentTypes : JSubBaseDefines
    {
        public JEnviromentPaymentTypes()
            : base(Legal.JContractBaseDefines.EnviromentPaymentType)
        {

        }
    }


     //////////////////////////////
    /// نحوه تسویه حساب در قرارداد مشاعات
    //////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public class JEnviromentPonyType : JSubBaseDefine
    {
        public JEnviromentPonyType()
            : base(Legal.JContractBaseDefines.EnviromentPonyType)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JEnviromentPonyTypes : JSubBaseDefines
    {
        public JEnviromentPonyTypes()
            : base(Legal.JContractBaseDefines.EnviromentPonyType)
        {

        }
    }
}

