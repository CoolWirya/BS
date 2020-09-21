using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JJudicalComplexTable:JTable
    {
       public JJudicalComplexTable()
            : base(JTableNamesLegal.JudicialComplex)
        {
        }
        
        /// <summary>
        /// نام مجتمع قضایی
        /// </summary>
        public string Name;
        /// <summary>
        /// کد شهر محل اقامت مجتمع قضایی 
        /// </summary>
        public int City;
        /// <summary>
        /// آدرس اقامت گاه مجتمع قضایی
        /// </summary>
        public string Address;
        /// <summary>
        /// تلفن مجتمع قضایی
        /// </summary>
        public string Tel;
        /// <summary>
        /// نمابر مجتمع قضایی
        /// </summary>
        public string Fax;
        /// <summary>
        /// نام سرپرست مجتمع
        /// </summary>
        public string SupervisorNameComplex;
    }
    enum JJudicalComplexTableEnum
    {
        /// <summary>
        /// کد مجتمع قضایی
        /// </summary>
        Code,
        /// <summary>
        /// نام مجتمع قضایی
        /// </summary>
        Name,
        /// <summary>
        /// کد شهر محل اقامت مجتمع قضایی 
        /// </summary>
        City,
        /// <summary>
        /// آدرس اقامت گاه مجتمع قضایی
        /// </summary>
        Address,
        /// <summary>
        /// تلفن مجتمع قضایی
        /// </summary>
        Tel,
        /// <summary>
        /// نمابر مجتمع قضایی
        /// </summary>
        Fax,
        SupervisorNameComplex,
    }
}
