using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JPersonExecutive : JSystem
    {

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int ExecutiveCode { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int Type { get; set; }

        #endregion

        #region سازنده

        public JPersonExecutive()
        {
        }
        public JPersonExecutive(int pCode)
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
            JPersonExecutiveTable PDT = new JPersonExecutiveTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                if (Code > 0)
                {
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
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JPersonExecutiveTable PDT = new JPersonExecutiveTable();
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
            JPersonExecutiveTable PDT = new JPersonExecutiveTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PDT.ExecutiveCode = pPetitionCode;
                            PDT.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            PDT.Type = Type;
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
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Insert(DataTable tmpdt, int pPetitionCode, int Type, JDataBase db)
        {
            JPersonExecutiveTable PDT = new JPersonExecutiveTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        PDT.ExecutiveCode = pPetitionCode;
                        PDT.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                        PDT.Type = Type;
                        PDT.Code = PDT.Insert(db);
                        dr["Code"] = PDT.Code;
                        if (PDT.Code < 1)
                            return false;
                        Histroy.Save(this, PDT, PDT.Code, "Insert");
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
            JPersonExecutiveTable PDT = new JPersonExecutiveTable();
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
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JPersonExecutiveTable PDT = new JPersonExecutiveTable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.PersonExecute + " WHERE Code=" + pCode.ToString());
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
        ///  اطلاعات افراد در اجرائیه
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pPetitionCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesLegal.PersonExecute + " A inner join clsAllPerson P on A." + LegPersonExecutive.PersonCode + "=P.Code WHERE " + LegPersonExecutive.ExecutiveCode + "=" + pPetitionCode.ToString());
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
        /// اطلاعات افراد در اجرائیه با شرط نوع فرد 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataType(int pPetitionCode,int pType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesLegal.PersonExecute + " A inner join clsAllPerson P on A." + LegPersonExecutive.PersonCode + "=P.Code WHERE " + LegPersonExecutive.Type + " = " + pType.ToString() + " And " + LegPersonExecutive.ExecutiveCode + "=" + pPetitionCode.ToString());
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
