using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JAdvocate : JSystem
    {
        #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد شخص
            /// </summary>
            public int Person_Code { get; set; }
            /// <summary>
            /// کد وکالت
            /// </summary>
            public int Advocacy_Code { get; set; }
            /// <summary>
            /// تاریخ شروع
            /// </summary>
            public DateTime Start_Date { get; set; }
            /// <summary>
            /// تاریخ پایان
            /// </summary>
            public DateTime End_Date { get; set; }

        #endregion

        #region سازنده

        public JAdvocate()
        {
        }

        public JAdvocate(int pCode)
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
            JAdvocateTable PDT = new JAdvocateTable();
            try
            {
                //if (!Find(MarketNumber))
                //{
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                if (Code > 0)
                {
                    Histroy.Save(this, PDT, Code, "Insert");

                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.AllPerson";
                    tmpJRelation.PrimaryObjectCode = PDT.Person_Code;
                    tmpJRelation.ForeignClassName = "Legal.JAdvocacy";
                    tmpJRelation.ForeignObjectCode = Advocacy_Code;
                    tmpJRelation.Comment = "برای این شخص وکیل ثبت شده است";
                    if (!tmpJRelation.Insert(pDB))
                        return -1;
                }
                else
                    return Code;
                //}
                //else
                //{
                //    JMessages.Message("کد مجتمع تکراری است", "خطا", JMessageType.Error);
                //    return -2;
                //}
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
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JAdvocateTable PDT = new JAdvocateTable();
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
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable tmpdt, int pAdvocacy_Code,JDataBase db)
        {
            JAdvocateTable PDT = new JAdvocateTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            Advocacy_Code = pAdvocacy_Code;
                            Person_Code = Convert.ToInt32(dr["PersonCode"]);
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;                                                        
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!delete(db))
                                return false;
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
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            return delete(pDB, -1);
        }
        public bool delete(JDataBase pDB, int pCode)
        {
            if (pCode > 0)
            {
                GetData(pCode);
            }
            JAdvocateTable PDT = new JAdvocateTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    Histroy.Save(this, PDT, Code, "Delete");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
            return false;
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp,JDataBase pDB)
        {
            JAdvocateTable PDT = new JAdvocateTable();
            try
            {
                if (PDT.DeleteManual(exp, pDB) || PDT.GetDeleteCount() >= 0)
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JAdvocacy", Advocacy_Code, pDB))
                        if (!tmpJRelation.Delete("Legal.JAdvocacy", Advocacy_Code, pDB))
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
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.AdvocateTable + " WHERE Code=" + pCode.ToString());
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
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pAdvocacy_Code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesLegal.AdvocateTable + " A inner join clsAllPerson P on A.Person_Code=P.Code WHERE Advocacy_Code=" + pAdvocacy_Code.ToString());
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
        #endregion
    }
}
