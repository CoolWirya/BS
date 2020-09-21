using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JSubjectAdvocacy : JSystem
    {

        #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد مجتمع
            /// </summary>
            public int Advocacy_Code { get; set; }
            /// <summary>
            /// کد موضوع
            /// </summary>
            public int SubjectCode { get; set; }
            /// <summary>
            /// توضیحات
            /// </summary>
            public string Description { get; set; }

        #endregion


        #region سازنده

        public JSubjectAdvocacy()
        {
        }
        public JSubjectAdvocacy(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JSubjectAdvocacyTable PDT = new JSubjectAdvocacyTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                Histroy.Save(this, PDT, Code, "Insert");
                return Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
            return 0;
        }
        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JSubjectAdvocacyTable PDT = new JSubjectAdvocacyTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update())
                {
                    Histroy.Save(this, PDT, Code, "Update");
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            JSubjectAdvocacyTable PDT = new JSubjectAdvocacyTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    Histroy.Save(this, PDT, Code, "Delete");
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp,JDataBase pDB)
        {
            JSubjectAdvocacyTable PDT = new JSubjectAdvocacyTable();
            try
            {
                if (PDT.DeleteManual(exp, pDB) || PDT.GetDeleteCount() >= 0)
                {
                    Histroy.Save(this, PDT, Code, "Delete");
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.SubjectTable + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// موضوعات وکالتی خاص
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetAllSubject(int pAdvocacy_Code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.SubjectTable + " WHERE  Advocacy_Code=" + pAdvocacy_Code.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }            
        }
        /// <summary>
        /// ذخیره 
        /// </summary>
        /// <returns></returns>
        public bool Save(List<int> SubjectAdd,List<int> SubjectDelete,int pAdvocacy_Code, JDataBase pDB)
        {
            JSubjectAdvocacyTable PDT = new JSubjectAdvocacyTable();
            try
            {
                for (int i = 0; i < SubjectAdd.Count; i++)
                {
                    Advocacy_Code=pAdvocacy_Code;
                    SubjectCode = SubjectAdd[i];
                    Insert(pDB);
                }
                if (SubjectDelete != null)
                for (int i = 0; i < SubjectDelete.Count; i++)
                    DeleteManual("Advocacy_Code= " + pAdvocacy_Code + " And SubjectCode=" + SubjectDelete[i], pDB);
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        #endregion
    }
}
