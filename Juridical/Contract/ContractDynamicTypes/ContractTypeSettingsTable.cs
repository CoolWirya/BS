using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JContractTypeSettingsTable:JTable
    {
        /// <summary>
        /// کد نوع قرارداد از جدول ContractDynamicTypes
        /// </summary>
        public int ContractTypeCode;
        /// <summary>
        /// نام تنظیم
        /// </summary>
        public string SettingName;
        /// <summary>
        /// مقدار تنظیم
        /// </summary>
        public object SettingValue;

        public JContractTypeSettingsTable()
            : base(JTableNamesContracts.ContractTypeSettings)
        {
        }
    }

    public enum JContractTypeSettingsEnum
    {
        Code,
        ContractTypeCode,
        SettingName,
        SettingValue
    }
}
