using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JExpertiseTable:JTable
    {
        public JExpertiseTable()
            : base(JTableNameLegal.Expertise)
        {
        }

        public int PetitionCode;
        /// <summary>
        ///نظر کارشناسی 
        /// </summary>
        public string Comment;
         

    }
}
