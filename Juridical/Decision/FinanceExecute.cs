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
    public class JFinanceExecute : JLegal
    {
          #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد وکالت
            /// </summary>
            public int ExecuteCode { get; set; }
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

        public JFinanceExecute()
        {
        }
        public JFinanceExecute(int pCode)
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
            JFinanceExecuteTable PDT = new JFinanceExecuteTable();
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
                    tmpJRelation.ForeignClassName = "Legal.JFinanceExecute";
                    tmpJRelation.ForeignObjectCode = PDT.Code;
                    tmpJRelation.Comment = "برای این اموال اجرائیه ثبت شده است";
                    if (!tmpJRelation.Insert(pDB))
                        return -1;

                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
                }
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
            JFinanceExecuteTable PDT = new JFinanceExecuteTable();
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
            JFinanceExecuteTable PDT = new JFinanceExecuteTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JFinanceExecute", Code,pDB))
                        if (!tmpJRelation.Delete("Legal.JFinanceExecute", Code, pDB))
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
        public bool DeleteManual(int pExecuteCode, JDataBase pDB)
        {
            JFinanceExecuteTable PDT = new JFinanceExecuteTable();
            try
            {
                DataTable dt = new DataTable();
                foreach (DataRow dr in GetAllByExecute(pExecuteCode).Rows)
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
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceExecute + " WHERE Code=" + pCode.ToString());
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
        public static DataTable GetAllSubject(int pExecuteCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceExecute + " WHERE  ExecuteCode=" + pExecuteCode.ToString());
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
                            ExecuteCode = pPetitionCode;
                            FinanceCode = Convert.ToInt32(dr["FinanceCode"]);
                            Comment = dr["Comment"].ToString();                             
                            if (Insert(db) < 1)
                                return false;
                            dr["Code"] = Code;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            if (dr["Code"].ToString() != "")
                            {
                                Code = (int)dr["Code"];
                                GetData(Code);
                                delete(db);
                                dr.Delete();
                            }
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
        public static DataTable GetAllByExecute(int pExecuteCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                //if (pExecuteCode != 0)
                    DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceExecute + " WHERE  ExecuteCode=" + pExecuteCode.ToString());
                //else
                //    DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinanceExecute);
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
        //public bool Save(List<int> SubjectAdd,List<int> SubjectDelete,int pExecuteCode, JDataBase pDB)
        //{
        //    JFinancePetitionTable PDT = new JFinancePetitionTable();
        //    try
        //    {
        //        for (int i = 0; i < SubjectAdd.Count; i++)
        //        {
        //            PDT.PetitionCode = pExecuteCode;
        //            PDT.FinanceCode = SubjectAdd[i];
        //            Code = PDT.Insert(pDB);
        //        }
        //        if (SubjectDelete != null)
        //        for (int i = 0; i < SubjectDelete.Count; i++)
        //            PDT.DeleteManual("ExecuteCode= " + pExecuteCode + " And FinanceCode=" + SubjectDelete[i], pDB);
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
