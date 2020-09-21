using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JExternalReferTable : JTable
    {
        #region Properties        
        /// <summary>
        /// کد
        /// </summary>
        public int Refer_Code;
        /// <summary>
        /// کد
        /// </summary>
        public int receiver_external_code;
        /// <summary>
        /// کد
        /// </summary>
        public string receiver_full_title;
        /// <summary>
        /// کد
        /// </summary>
        public int Send_Type;
        /// <summary>
        /// کد
        /// </summary>
        public DateTime Send_Date;
        /// <summary>
        /// کد
        /// </summary>
        public bool ConfirmReceiver;
        /// <summary>
        /// کد
        /// </summary>
        public string Description;
        #endregion

        public JExternalReferTable() :
            base(JTableNamesAutomation.ExternalRefer, "")
        {
        }
    }
}
