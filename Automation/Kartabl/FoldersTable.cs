using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JFolderTable : JTable
    {
        #region Properties

        /// <summary>
        ///کد پست کاربر 
        /// </summary>
        public int User_post_code;
        /// <summary>
        ///کد پدر
        /// </summary>
        public int parent_code;
        /// <summary>
        ///نام کارتابل 
        /// </summary>
        public string Name;
        /// <summary>
        /// نوع فولدر
        /// </summary>
        public int FolderType;
        /// <summary>
        ///  تاریخ ایجاد 
        /// </summary>
        public DateTime Create_Date_Time;
        /// <summary>
        /// ارسال کننده 
        /// </summary>
        public int Sender_User_post_code;
        /// <summary>
        /// نوع شی
        /// </summary>
        public string Object_type;
		public string Subject;
        public bool DeleteFromKartable;

        #endregion

        public JFolderTable() :
            base(JTableNamesAutomation.Folders, "parent_code,Sender_User_post_code,Object_type")
        {
        }
    }
}
