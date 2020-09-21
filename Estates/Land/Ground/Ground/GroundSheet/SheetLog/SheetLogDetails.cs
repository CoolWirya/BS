using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
    public class JSheetLogDetails : JSystem
    {
        #region constructor
        public JSheetLogDetails()
        {
        }
        public JSheetLogDetails(int pCode)
        {
            //GetData(pCode);
        }
        #endregion

        #region property
        /// <summary>
        ///  
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int SheetLogCode { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int SheetCodeDetails { set; get; }
        
        #endregion
        
        #region Method
        public int insert(JDataBase pDb)
        {
            JSheetLogDetailsTable JPOT = new JSheetLogDetailsTable();
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
                if (Code > 0)
                    return Code;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool Delete(JDataBase PDb)
        {
            try
            {
                JSheetLogDetailsTable JPOT = new JSheetLogDetailsTable();
                JPOT.SetValueProperty(this);
                if (JPOT.Delete(PDb) || JPOT.GetDeleteCount() == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete(int pBillGoodsCode, JDataBase PDb)
        {
            try
            {
                JSheetLogDetailsTable JPOT = new JSheetLogDetailsTable();
                if (JPOT.DeleteManual(" SheetLogCode= " + pBillGoodsCode, PDb))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Update(JDataBase pDb)
        {
            JSheetLogDetailsTable JPOT = new JSheetLogDetailsTable();
            try
            {
                JPOT.SetValueProperty(this);
                return JPOT.Update(pDb);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool _Insert = false;

        public bool Save(int pBillGoodsCode, DataTable pGoodsList, JDataBase pDb)
        {
            JSheetLogDetails JPOB = new JSheetLogDetails(0);
            try
            {               
                foreach (DataRow Row in pGoodsList.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if ((Row.RowState == DataRowState.Added) || ((Row.RowState == DataRowState.Modified) || (_Insert)))
                    {
                        SheetLogCode = pBillGoodsCode;
                        SheetCodeDetails = Convert.ToInt32(Row["SheetCodeDetails"].ToString());
                        Code = insert(pDb);
                        if (Code <= 0)
                            return false;

                        //Add Relation
                        JRelation tmpJRelation = new JRelation();
                        tmpJRelation.PrimaryClassName = "Estates.JGroundSheet";
                        tmpJRelation.PrimaryObjectCode = SheetCodeDetails;
                        tmpJRelation.ForeignClassName = "Estates.JSheetLogDetails";
                        tmpJRelation.ForeignObjectCode = Code;
                        tmpJRelation.Comment = "برای این تعرفه log ثبت شده است";
                        if (!tmpJRelation.Insert(pDb))
                            return false;
                    }
                    /// در صورتی که سطر حذف شده باشد
                    else if ((Row.RowState == DataRowState.Deleted) && (_Insert == false))
                    {
                        Row.RejectChanges();
                        if (Row["Code"] != DBNull.Value)
                        {
                            Code = (int)Row["Code"];
                            if (!(Delete(pDb)))
                                return false;
                            Row.Delete();
                        }
                        else
                            Row.Delete();

                        //Delete Relation
                        JRelation tmpJRelation = new JRelation();
                        if (!tmpJRelation.CheckRelation("Estates.JSheetLogDetails", Code, pDb))
                            if (!tmpJRelation.Delete("Estates.JSheetLogDetails", Code, pDb))
                                return false;
                    }
                    /// در صورتی که سطر ویرایش شده باشد
                    else if ((Row.RowState == DataRowState.Modified) && (_Insert == false))
                    {
                        Code = (int)Row["Code"];
                        SheetLogCode = pBillGoodsCode;
                        SheetCodeDetails = Convert.ToInt32(Row["SheetCodeDetails"].ToString());
                        if (!Update(pDb))
                            return false;
                    }
                }
                pGoodsList.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        #endregion

        public static DataTable GetDataTable(int pBillGoodsCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pBillGoodsCode != 0)
                    Where = " Where SheetLogCode=" + pBillGoodsCode;
                Db.setQuery(@" Select * From estSheetLogDetails " + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }


    public class JSheetLogDetailsTable : ClassLibrary.JTable
    {
        public JSheetLogDetailsTable()
            : base("estSheetLogDetails")
        {

        }
        public int SheetLogCode;
        public int SheetCodeDetails;
    }
}
