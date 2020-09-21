using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
    /// <summary>
    /// نوع کاربری
    /// </summary>
    public enum JEnvContractUsages
    {
        /// <summary>
        /// تبلیغاتی
        /// </summary>
        Advertisment = 1,
        /// <summary>
        /// تجاری
        /// </summary>
        Trade = 2,
        /// <summary>
        /// هردو
        /// </summary>
        Both = 100
    }
    /// <summary>
    /// نحوه پرداخت اجاره
    /// </summary>
    public enum JEnvPaymentType
    {
    /// <summary>
    /// اجاره کامل
    /// </summary>
        Rent = 1,
        /// <summary>
        /// تهاتر
        /// </summary>
        Tahator = 2,
        /// <summary>
        /// هردو
        /// </summary>
        Both = 100
    }
    /// <summary>
    /// نحوه تسویه حساب
    /// </summary>
    public enum JEnvPonyType
    {
        /// <summary>
        /// هیچ کدام
        /// </summary>
        None = 0,
        /// <summary>
        /// درصد فروش
        /// </summary>
        SellPercent = 1,
        /// <summary>
        /// خدمات
        /// </summary>
        Services = 2,
    }
    /// <summary>
    /// 
    /// </summary>
    public class JEnviromentContract
    {
        public JEnvContractUsages usage { get; set; }

    }
}
