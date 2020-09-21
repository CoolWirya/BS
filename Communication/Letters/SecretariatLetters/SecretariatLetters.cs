using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Automation;

namespace Communication
{
    public class JCSecretariatLetter : JCLetter
    {
        #region Properties
    
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد نامه
        /// </summary>
        public int Letter_Code { get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code { get; set; }
        /// <summary>
        /// شماره ثبت 
        /// </summary>
        public int register_no { get; set; }
        /// <summary>
        /// شماره نامه 
        /// </summary>
        public string letter_no { get; set; }
        /// <summary>
        /// تاریخ ثبت 
        /// </summary>
        public DateTime register_date_time { get; set; }
        /// <summary>
        /// پست ثبت کننده 
        /// </summary>
        public int register_post_code { get; set; }

        #endregion

                        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCSecretariatLetter()
        {
        }


        #endregion

        // Insert , Update , Delete
        #region BaseFunctions
        public int Insert(JDataBase db)
        {
            JSecretariatLettersTable ActionTable = new JSecretariatLettersTable();
            ActionTable.SetValueProperty(this);
            Code = ActionTable.Insert(db);
            if (Code < 0)
            {
               db.Rollback(db.TransactionName);
               return 0;
            }
            return Code;
        }

        public bool Delete(int pCode)
        {
            JSecretariatLettersTable ActionTable = new JSecretariatLettersTable();
            ActionTable.Code = pCode;
            return ActionTable.Delete();
        }

        public bool Update()
        {
            JSecretariatLettersTable ActionTable = new JSecretariatLettersTable();
            ActionTable.SetValueProperty(this);
            return ActionTable.Update();
        }

        #endregion BaseFunctions


        // GetInfo
        #region GetInfo
        /// <summary>
        /// لیست کلیه ارجاعات
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetList(int pLetterCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"select SL.*,S.name from " + JTableNamesLetters.secretariatLetters + " SL inner join secretariat S on SL.secretariat_code=S.Code Where " + secretariatLetters.Letter_Code + "=" + pLetterCode);
                return db.Query_DataTable();                
            }
            finally
            {
                db.Dispose();
            } 
        }

        /// <summary>
        /// اطلاعات 
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"SELECT * FROM " + JTableNamesLetters.secretariatLetters + " WHERE " + secretariatLetters.Code + "=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion GetInfo
    }
}
