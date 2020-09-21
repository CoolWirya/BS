using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JAggregateGroundTable:JTable
    {
        public JAggregateGroundTable()
            : base(JTableNamesEstates.AggregateGround)
        {
        }
       
        /// <summary>
        /// شماره نامه تجمیع
        /// </summary>
        public string LetterNum  ; 
        /// <summary>
        /// تاریخ نامه تجمیع  
        /// </summary>
        public DateTime LetterDate ; 
        /// <summary>
        /// کد زمین حاصل از تجمیع زمین ها
        /// </summary>
        public int GroundAggregationbyCode;
        /// <summary>
        /// نام اداره مخاطب
        /// </summary>
        public string RegistrationOffice;
        /// <summary>
        /// متن درخواست تجمیع
        /// </summary>
        public string TextReuest;
        
        
    }
}
