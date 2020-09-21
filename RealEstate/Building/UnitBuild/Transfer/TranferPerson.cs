using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace RealEstate
{
    public enum TransferPersonType
    {
        Seller = 1,
        Buyer = 2,
    }

    public class JTranferPerson : JSystem
    {

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد انتقال
        /// </summary>
        public int TransferCode { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int PersonType { get; set; }
        /// <summary>
        /// سهم قدیم
        /// </summary>
        public decimal OldShare { get; set; }
        /// <summary>
        /// سهم جدید
        /// </summary>
        public decimal NewShare { get; set; }

        #endregion

        #region سازنده

        public JTranferPerson()
        {
        }
        public JTranferPerson(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }
        public JTranferPerson(int pCode, JDataBase pDB)
        {
            Code=pCode;
            GetData(Code, pDB);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JTranferPersonTable PDT = new JTranferPersonTable();
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
        public bool Update(JDataBase pDB)
        {
            JTranferPersonTable PDT = new JTranferPersonTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(pDB))
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
        public static  bool Update(DataTable tmpdt, int pTransferCode, int Type, JDataBase db)
        {
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            JTranferPerson PDT = new JTranferPerson();
                            //JTranferPersonTable PDT = new JTranferPersonTable();
                            PDT.TransferCode = pTransferCode;
                            PDT.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            PDT.PersonType = Type;
                            if (dr["OldShare"].ToString() != "")
                                PDT.OldShare = Convert.ToDecimal(dr["OldShare"]);
                            if (dr["NewShare"].ToString() != "")
                                PDT.NewShare = Convert.ToDecimal(dr["NewShare"]);
                            PDT.Insert(db);
                            dr["Code"] = PDT.Code;
                            if (PDT.Code < 1)
                                return false;
                            //Histroy.Save(this, PDT, PDT.Code, "Insert");
                        }

                        if (dr.RowState == DataRowState.Modified)
                        {
                            JTranferPerson PDTP = new JTranferPerson(Convert.ToInt32(dr["Code"]), db);
                            if (dr["OldShare"].ToString() != "")
                                PDTP.OldShare = Convert.ToDecimal(dr["OldShare"]);
                            if (dr["NewShare"].ToString() != "")
                                PDTP.NewShare = Convert.ToDecimal(dr["NewShare"]);
                            if (!PDTP.Update(db))
                                return false;
                        }

                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            int _Code = (int)dr["Code"];
                            JTranferPerson PDTP = new JTranferPerson(_Code,db);
                            PDTP.delete(db);
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
            JTranferPersonTable PDT = new JTranferPersonTable();
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
            JTranferPersonTable PDT = new JTranferPersonTable();
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
            return (GetData(pCode, null));
        }
        public bool GetData(int pCode, JDataBase pDB)
        {
            JDataBase DB;
            if (pDB == null)
                DB = JGlobal.MainFrame.GetDBO();
            else
                DB = pDB;
            try
            {
                DB.setQuery("SELECT * FROM " + JRETableNames.RestTransferPersons + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT Code,PersonCode,Name,PersonType FROM " + JRETableNames.RestTransferPersons + " WHERE AssertionCode=" + pPetitionCode.ToString());
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
        public static DataTable GetAllDataType(int pTransferCode, TransferPersonType pType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT T.Code,T.PersonCode,P.Name,T.PersonType,T.OldShare,T.NewShare FROM " + JRETableNames.RestTransferPersons
                    + " T inner join clsAllPerson P On P.Code=T.PersonCode WHERE T.PersonType = " + 
                    pType.GetHashCode().ToString() + " And TransferCode=" + pTransferCode.ToString());
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
        public static DataTable GetAllDataByPrint(int pTransferCode, TransferPersonType pType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT P.*,T.OldShare,T.NewShare FROM " + JRETableNames.RestTransferPersons
                    + " T inner join PersonAddressView P On P.Code=T.PersonCode WHERE T.PersonType = " + 
                    pType.GetHashCode().ToString() + " And TransferCode=" + pTransferCode.ToString());
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
