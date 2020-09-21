using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JPersonPetition : JSystem
    {

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int PetitionCode { get; set; }
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

        public JPersonPetition()
        {
        }
        public JPersonPetition(int pCode)
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
            JPersonPetitionTable PDT = new JPersonPetitionTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                if (Code > 0)
                {
                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.AllPerson";
                    tmpJRelation.PrimaryObjectCode = PDT.PersonCode;
                    tmpJRelation.ForeignClassName = "Legal.JPersonPetition";
                    tmpJRelation.ForeignObjectCode = PetitionCode;
                    tmpJRelation.Comment = "برای این شخص وکیل دادخواست/شکوائیه شده است";
                    if (!tmpJRelation.Insert(pDB))
                        return -1;

                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
                }
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
            JPersonPetitionTable PDT = new JPersonPetitionTable();
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
        public bool Update(DataTable tmpdt, int pPetitionCode,int pType, JDataBase db)
        {
            JPersonPetitionTable PDT = new JPersonPetitionTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PetitionCode = pPetitionCode;
                            PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            Type = pType;
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
            JPersonPetitionTable PDT = new JPersonPetitionTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JPersonPetition", Code, pDB))
                        if (!tmpJRelation.Delete("Legal.JPersonPetition", Code, pDB))
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
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JPersonPetitionTable PDT = new JPersonPetitionTable();
            try
            {
                if (PDT.DeleteManual(exp, pDB) || PDT.GetDeleteCount() >= 0)
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JPersonPetition", PetitionCode, pDB))
                        if (!tmpJRelation.Delete("Legal.JPersonPetition", PetitionCode, pDB))
                            return false;
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.PersonPetition + " WHERE Code=" + pCode.ToString());
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
                string Quoery = "SELECT A.Code,P.Code PersonCode,P.Name,A.Type FROM " + JTableNamesPetition.PersonPetirion + " A inner join clsAllPerson P on A." + LegPersonPetition.PersonCode + "=P.Code WHERE PetitionCode=" + pPetitionCode.ToString();
                DB.setQuery(Quoery);
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
                string Qouery = "SELECT A.Code,P.Code PersonCode,P.Name,A.Type FROM " + JTableNamesPetition.PersonPetirion + " A inner join clsAllPerson P on A." + LegPersonPetition.PersonCode + "=P.Code WHERE A.Type= " + pType.ToString() + " And PetitionCode=" + pPetitionCode.ToString();
                DB.setQuery(Qouery);
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
