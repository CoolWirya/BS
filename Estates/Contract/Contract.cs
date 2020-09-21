using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Contract
{
    /// <summary>
    /// موضوع قرارداد
    /// </summary>
    class JSubjectContract
    {
        public string ObjectName;
        public int ObjectCode;
    }
    /// <summary>
    /// طرفین قرارداد
    /// </summary>
    class JPartiesToTheContract
    {
        int[] BuyerCode;
        int[] SellerCode;
    }

    /// <summary>
    /// قرار داد 
    /// </summary>
    public class JContract
    {
        /// <summary>
        /// متن قرارداد
        /// </summary>
        int Code;
        /// <summary>
        /// طرفین قرارداد
        /// </summary>
        JPartiesToTheContract PartContract;
        /// <summary>
        /// موضوع قرارداد
        /// </summary>
        JSubjectContract Subject;
        /// <summary>
        /// مبلغ قرارداد
        /// </summary>
        int Price;
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        int ContractNo;
        /// <summary>
        /// شروط قرارداد
        /// </summary>
        string ContractTerms;
        /// <summary>
        /// تعهدات قرارداد
        /// </summary>
        string ContractCommitments;
        /// <summary>
        /// داوری قرارداد
        /// </summary>
        string ArbitrationAgreement;
        /// <summary>
        /// شرایط دیگر
        /// </summary>
        string Other;
        /// <summary>
        /// متن قرارداد
        /// </summary>
        string Content;
    }
}

