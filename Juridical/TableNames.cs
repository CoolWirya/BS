using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
    public class JTableNamesContracts
    {
        public static string DocumentContract = "LegDocumentContract";
        public static string ContractType = "LegContractType";
        public static string Pony = "LegPony";
        public static string AdvocacyFinance = "LegAdvocacyFinance";
        /// <summary>
        /// جدول انواع قرارداد 
        /// </summary>
        public static string ContractDynamicType = "legContractDynamicTypes";
        /// <summary>
        /// جدول تنظیمات مربوط به انواع قرارداد
        /// </summary>
        public static string ContractTypeSettings = "legContractTypeSettings";
        /// <summary>
        ///جدول ترتیب فرمهای انواع قرارداد
        /// </summary>
        public static string ContractFormsOrder = "legContractFormsOrder";
        /// <summary>
        ///تعریف فیلد متن قرارداد
        /// </summary>
        public static string DefineField = "legDefineField";

    }

    public class JTableNamesPetition
    {
        public static string Assertion = "LegAssertion";
        public static string AssertionPerson = "legassertionperson";
        public static string Petition = "legpetition";
        public static string FinancePetition = "legFinancePetition";
        public static string PersonPetirion = "legpersonpetition";
        public static string FinanceDecision = "legFinanceDecision";
        public static string FinanceExecute = "legFinanceExecute";
        public static string BreakupOrg = "legBreakupOrganization";
    }


}
