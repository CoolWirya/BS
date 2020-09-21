using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JDecisionType : JSystem
    {

        #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد تصمیم
            /// </summary>
            public int DecisionCode { get; set; }
            /// <summary>
            /// کد نوع رای
            /// </summary>
            public int Type { get; set; }

        #endregion


        #region سازنده

        public JDecisionType()
        {
        }
        public JDecisionType(int pCode)
        {
            Code=pCode;
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JDecisionTypeTable PDT = new JDecisionTypeTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
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
            JDecisionTypeTable PDT = new JDecisionTypeTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Update();
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
            JDecisionTypeTable PDT = new JDecisionTypeTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Delete(pDB);
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
            JDecisionTypeTable PDT = new JDecisionTypeTable();
            try
            {
                return PDT.DeleteManual(exp,pDB);
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.DecisionType + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.DecisionType + " WHERE  DecisionCode=" + pAdvocacy_Code.ToString());
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
        public bool Save(List<int> SubjectAdd, List<int> SubjectDelete, int pDecisionCode, JDataBase pDB)
        {
            JDecisionTypeTable PDT = new JDecisionTypeTable();
            try
            {
                for (int i = 0; i < SubjectAdd.Count; i++)
                {
                    PDT.DecisionCode = pDecisionCode;
                    PDT.Type = SubjectAdd[i];
                    Code = PDT.Insert(pDB);
                    Histroy.Save(this, PDT, Code, "Insert");
                }
                if (SubjectDelete != null)
                for (int i = 0; i < SubjectDelete.Count; i++)
                    PDT.DeleteManual("DecisionCode= " + pDecisionCode + " And Type=" + SubjectDelete[i], pDB);
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
