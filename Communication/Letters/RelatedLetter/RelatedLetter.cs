using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Employment;

namespace Communication
{
    class JCRelatedLetter : JCommunication
    {
        #region Peroperties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code { get; set; }
        /// <summary>
        /// کد نامه وابسته
        /// </summary>
        public int dependent_LetterCode { get; set; }
        /// <summary>
        /// نوع  عطف/پیرو
        /// </summary>
        public int type { get; set; }

        #endregion Peroperties


        /// <summary>
        /// درج عطف جدید
        /// </summary>
        /// <param name="db">JDataBase</param>
        /// <returns>int</returns>
        public int Insert(JDataBase db)
        {
            JRelatedLetterTable JST = new JRelatedLetterTable();
            JST.SetValueProperty(this);
            int mCode = JST.Insert(db);
            if (mCode != 0)
            {
                return mCode;
            }
            return -1;
        }
        /// <summary>
        /// ویرایش عطف 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            try
            {
                JRelatedLetterTable JST = new JRelatedLetterTable();
                JST.SetValueProperty(this);
                return JST.Update(db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }            
        }
        /// <summary>
        /// حذف عطف
        /// </summary>
        public void Delete()
        {
            JRelatedLetterTable ActionTable = new JRelatedLetterTable();
            ActionTable.SetValueProperty(this);
            ActionTable.Delete();
        }
        /// <summary>
        /// حذف دستی عطف
        /// </summary>
        public void DeleteManual(string pExpression)
        {
            JRelatedLetterTable ActionTable = new JRelatedLetterTable();
            ActionTable.SetValueProperty(this);
            ActionTable.DeleteManual(pExpression);
        }
        public bool DelManual(int pLetterCode, JDataBase db)
        {
            JRelatedLetterTable JST = new JRelatedLetterTable();
            return JST.DeleteManual(LetterDependent.letter_code + "=" + pLetterCode, db);
        }

        /// <summary>
        /// جستجوی  
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean FindByLetterCode(int pCode, JDataBase pDB)
        {
            try
            {
                pDB.setQuery("SELECT * FROM " + JTableNamesLetters.LetterDependent + " WHERE " + LetterDependent.letter_code  + "=" + JDataBase.Quote(pCode.ToString()));
                pDB.Query_DataReader();
                return pDB.DataReader.HasRows;
            }
            finally
            {
                // pDB.Dispose();
            }
        }

        /// <summary>
        /// حذف عطف
        /// </summary>
        public bool DelUp(int pLetterCode, DataTable pdtRelatedLetter, JDataBase pDB)
        {
            JRelatedLetterTable ActionTable = new JRelatedLetterTable();
            ActionTable.SetValueProperty(this);
            ActionTable.DeleteManual(LetterDependent.letter_code + "=" + pLetterCode);
            foreach (DataRow dr in pdtRelatedLetter.Rows)
            {
                letter_code = pLetterCode;
                dependent_LetterCode = Convert.ToInt32(dr[LetterDependent.Code.ToString()].ToString());
                type = Convert.ToInt32(dr[LetterDependent.type.ToString()].ToString());
                if (Insert(pDB) == 0)
                    return false;
            }
            return true;
        }        
        
        /// <summary>
        /// درج گروهی عطف
        /// </summary>
        public bool InsertAll(int pLetterCode, DataTable pdtRelatedLetter, JDataBase pDB)
        {            
            JRelatedLetterTable ActionTable = new JRelatedLetterTable();
            ActionTable.SetValueProperty(this);
            foreach (DataRow dr in pdtRelatedLetter.Rows)
            {
                letter_code = pLetterCode;
                dependent_LetterCode = Convert.ToInt32(dr[LetterDependent.Code.ToString()].ToString());
                type = Convert.ToInt32(dr[LetterDependent.type.ToString()].ToString());
                if (Insert(pDB) == 0)
                    return false;
           }
            return true;
        }

        /// <summary>
        /// لیست کلیه عطف نامه
        /// </summary>
        /// <param name="receiver_post_code"></param>
        /// <param name="receiver_code"></param>
        /// <returns></returns>
        public DataTable GetDate(int pLetterCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesLetters.LetterDependent + " Where " + LetterDependent.letter_code + "=" + pLetterCode);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }
        }
    }

