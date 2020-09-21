using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    public class JFinancePetition : JLegal
    {
        #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد وکالت
            /// </summary>
            public int PetitionCode { get; set; }
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

        public JFinancePetition()
        {
        }
        public JFinancePetition(int pCode)
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
            JFinancePetitionTable PDT = new JFinancePetitionTable();
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
                    tmpJRelation.ForeignClassName = "Legal.JFinancePetition";
                    tmpJRelation.ForeignObjectCode = PDT.Code;
                    tmpJRelation.Comment = "برای این اموال دادخواست ثبت شده است";
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
        public bool Insert(DataTable tmpdt, int pPetitionCode, JDataBase pDB)
        {
            JFinancePetitionTable PDT = new JFinancePetitionTable();
            try
            {
                foreach (DataRow dr in tmpdt.Rows)
                {
                    PetitionCode = pPetitionCode;
                    if (dr.RowState != DataRowState.Deleted )
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
            JFinancePetitionTable PDT = new JFinancePetitionTable();
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
            JFinancePetitionTable PDT = new JFinancePetitionTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JFinancePetition", Code, pDB))
                        if (!tmpJRelation.Delete("Legal.JFinancePetition", Code, pDB))
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
        public bool DeleteManual(int pPetitionCode, JDataBase pDB)
        {
            JFinancePetitionTable PDT = new JFinancePetitionTable();
            try
            {
                DataTable dt = new DataTable();
                foreach (DataRow dr in GetAllByPetition(pPetitionCode).Rows)
                {
                    Code = (int)dr["Code"];
                    if (!delete(pDB))
                        return false;
                }
                return true;
                //if ((PDT.DeleteManual(exp, pDB)) || (PDT.GetDeleteCount() == 0))
                //    return true;
                //else
                //    return false;
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
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinancePetition + " WHERE Code=" + pCode.ToString());
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
        public static DataTable GetAllByPetition(int pPetitionCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                //if (pPetitionCode != 0)
                    DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinancePetition + " WHERE  PetitionCode=" + pPetitionCode.ToString());
                //else
                //    DB.setQuery("SELECT * FROM " + JTableNamesPetition.FinancePetition);
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
            JFinancePetitionTable PDT = new JFinancePetitionTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PetitionCode = pPetitionCode;
                            FinanceCode = Convert.ToInt32(dr["FinanceCode"]);
                            Comment = dr["Comment"].ToString();
                            Code = Insert(db);                            
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;
                            //Histroy.Save(PDT, PDT.Code, "Insert");
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
                PDT.Dispose();
            }
        }
        /// <summary>
        /// ذخیره 
        /// </summary>
        /// <returns></returns>
        //public bool Save(List<int> SubjectAdd,List<int> SubjectDelete,int pPetitionCode, JDataBase pDB)
        //{
        //    JFinancePetitionTable PDT = new JFinancePetitionTable();
        //    try
        //    {
        //        for (int i = 0; i < SubjectAdd.Count; i++)
        //        {
        //            PDT.PetitionCode = pPetitionCode;
        //            PDT.FinanceCode = SubjectAdd[i];
        //            Code = PDT.Insert(pDB);
        //        }
        //        if (SubjectDelete != null)
        //        for (int i = 0; i < SubjectDelete.Count; i++)
        //            PDT.DeleteManual("PetitionCode= " + pPetitionCode + " And FinanceCode=" + SubjectDelete[i], pDB);
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
