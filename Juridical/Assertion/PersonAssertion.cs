using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JPersonAssertion : JSystem
    {

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد اظهارنامه
        /// </summary>
        public int AssertionCode { get; set; }
        /// <summary>
        /// نام شخص
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int PersonType { get; set; }

        #endregion

        #region سازنده

        public JPersonAssertion()
        {
        }
        public JPersonAssertion(int pCode)
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
            JPersonAssertionTable PDT = new JPersonAssertionTable();
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
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JPersonAssertionTable PDT = new JPersonAssertionTable();
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
        public bool Update(DataTable tmpdt, int pPetitionCode,int Type, JDataBase db)
        {
            JPersonAssertionTable PDT = new JPersonAssertionTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PDT.AssertionCode = pPetitionCode;
                            PDT.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            PDT.Name = dr["Name"].ToString();
                            //if (dr["PersonType"].ToString() != "0")
                            PDT.PersonType = Type;
                            PDT.Code = PDT.Insert(db);
                            dr["Code"] = PDT.Code;
                            if (PDT.Code < 1)
                                return false;
                            Histroy.Save(this, PDT, PDT.Code, "Insert");
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
            JPersonAssertionTable PDT = new JPersonAssertionTable();
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
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JPersonAssertionTable PDT = new JPersonAssertionTable();
            try
            {
                return PDT.DeleteManual(exp, pDB);
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
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.AssertionPerson + " WHERE Code=" + pCode.ToString());
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
        public static DataTable GetAllData(int pPetitionCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                //DB.setQuery("SELECT A.Code,P.Code PersonCode,A.Name,PersonType FROM " + JTableNamesPetition.AssertionPerson + " A inner join clsAllPerson P on A." + LegPersonPetition.PersonCode + "=P.Code WHERE AssertionCode=" + pPetitionCode.ToString());
                DB.setQuery("SELECT Code,PersonCode,Name,PersonType FROM " + JTableNamesPetition.AssertionPerson + " WHERE AssertionCode=" + pPetitionCode.ToString());
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
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataType(int pPetitionCode,int pType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
//               DB.setQuery("SELECT A.Code,P.Code PersonCode,A.Name,PersonType FROM " + JTableNamesPetition.AssertionPerson + " A inner join clsAllPerson P on A." + LegPersonPetition.PersonCode + "=P.Code WHERE Type = " + pType.ToString() + " And AssertionCode=" + pPetitionCode.ToString());
                DB.setQuery("SELECT Code,PersonCode,Name,PersonType FROM " + JTableNamesPetition.AssertionPerson + " WHERE PersonType = " + pType.ToString() + " And AssertionCode=" + pPetitionCode.ToString());
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
