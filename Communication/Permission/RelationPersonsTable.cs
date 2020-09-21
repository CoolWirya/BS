using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JRelationPersonsTable: JTable
    {
        #region Property

        /// <summary>
        /// پست کد فرستنده
        /// </summary>
        public int Sender_Post_Code;
        /// <summary>
        /// پست کد گیرنده
        /// </summary>
        public int Receiver_Post_Code;

        #endregion

        public JRelationPersonsTable()
            : base("ClsRelationPersons", "")
        {
        }
    }
}
