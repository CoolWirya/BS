using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ClassLibrary;
using System.Data; 

namespace Legal
{
    public class JFinanceDecision : JLegal
    {
        #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد وکالت
            /// </summary>
            public int DecisionCode { get; set; }
            /// <summary>
            /// کد اموال
            /// </summary>
            public int FinanceCode { get; set; }
            /// <summary>
            /// توضیحات اموال
            /// </summary>
            public string Comment { get; set; }

        #endregion

        #region سازنده

        public JFinanceDecision()
        {
        }
        public JFinanceDecision(int pCode)
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
            JFinanceDecisionTable PDT = new JFinanceDecisionTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                if (Code > 0)
                {
                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.AssetShare";
                    tmpJRelation.PrimaryObjectCode = PDT.FinanceCode;
                    tmpJRelation.ForeignClassName = "Legal.JFinanceDecision";
                    tmpJRelation.ForeignObjectCode = Code;
                    tmpJRelation.Comment = "برای این اموال رای دادگاه ثبت شده است";
                    if (!tmpJRelation.Insert(pDB))
                        return -1;

                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
                }
                else
                    return -1;
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
        /// درج 
        /// </summary>
        /// <returns></returns>
        public bool Insert(DataTable tmpdt, int pDecisionCode, JDataBase pDB)
        {
            JFinanceDecisionTable PDT = new JFinanceDecisionTable();
            try
            {
                foreach (DataRow dr in tmpdt.Rows)
                {
                    DecisionCode = pDecisionCode;
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        FinanceCode = Convert.ToInt32(dr["FinanceCode"]);
                        Comment = dr["Comment"].ToString();
                        if (Insert(pDB) < 1)
                            return false;
                    }
                }
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
        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JFinanceDecisionTable PDT = new JFinanceDecisionTable();
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
            JFinanceDecisionTable PDT = new JFinanceDecisionTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JFinanceDecision", Code, pDB))
                    {
                        if (!tmpJRelation.Delete("Legal.JFinanceDecision", Code, pDB))
                            return false;
                    }
                    else
                        return false;

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
        public bool DeleteManual(int pDecisionCode,JDataBase pDB)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (DataRow dr in GetAllByDecision(pDecisionCode).Rows)
                {
                    Code = (int)dr["Code"];
                    if (!delete(pDB))
                        return false;
                }
                return true;
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
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceDecision + " WHERE Code=" + pCode.ToString());
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
        public static DataTable GetAllSubject(int pDecisionCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceDecision + " WHERE  DecisionCode=" + pDecisionCode.ToString());
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
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable tmpdt, int pPetitionCode, JDataBase db)
        {
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            DecisionCode = pPetitionCode;
                            FinanceCode = Convert.ToInt32(dr["FinanceCode"]);
                            Comment = dr["Comment"].ToString();
                            dr["Code"] = Insert(db);
                            if (Code < 1)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            delete(db);
                            dr.Delete();
                        }
                    }
                tmpdt.AcceptChanges();
                return true;
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
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllByDecision(int pDecisionCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                //if (pDecisionCode != 0)
                    DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceDecision + " WHERE  DecisionCode=" + pDecisionCode.ToString());
                //else
                //    DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceDecision);
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
        //public bool Save(List<int> SubjectAdd, List<int> SubjectDelete, int pDecisionCode, JDataBase pDB)
        //{
        //    JFinancePetitionTable PDT = new JFinancePetitionTable();
        //    try
        //    {
        //        for (int i = 0; i < SubjectAdd.Count; i++)
        //        {
        //            DecisionCode = pDecisionCode;
        //            FinanceCode = SubjectAdd[i];
        //            if (Insert(pDB) < 0)
        //                return false;
        //        }
        //        if (SubjectDelete != null)
        //        for (int i = 0; i < SubjectDelete.Count; i++)
        //            PDT.DeleteManual("DecisionCode= " + pDecisionCode + " And FinanceCode=" + SubjectDelete[i], pDB);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        PDT.Dispose();
        //    }
        //}
        #endregion
    }
}
