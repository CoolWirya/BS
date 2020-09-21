using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
    /// <summary>
    /// انواع عمل روی تعرفه
    /// </summary>
    public enum JَActionSheetType
    {
        /// <summary>
        /// تفکیک
        /// </summary>
        BreakDown = 1,
        /// <summary>
        /// تجمیع
        /// </summary>
        Aggregate = 2,
    }

    public class JSheetLog : JSystem
    {
        public JSheetLog()
        {
            SheetLogDetails = JSheetLogDetails.GetDataTable(-1);
        }

        public JSheetLog(int pCode)
        {
            GetData(pCode);
            SheetLogDetails = JSheetLogDetails.GetDataTable(-1);
        }

        private DataTable _SheetLogDetails;
        public DataTable SheetLogDetails { get; set; }

        #region Property                
        public int Code { get; set; }
        public int SheetCode { get; set; }
        public DateTime CreateDate { get; set; }
        public int Creator { get; set; }
        public int Action { get; set; }
        public string Desc { get; set; }
        #endregion


        public static DataTable ListPCodeinGCode(int GCode, int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
             string Where = " Where DeActive=0 ";
            if(GCode!=0)
                Where=Where+ " And GCode="+GCode;
            if(pCode!=0)
                Where=Where+ " And pCode="+pCode;
            try
            {
                Db.setQuery(" select *,Code SheetCodeDetails from estsheet " + Where);
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


        #region method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from estSheetLog where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                return Insert(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase Db)
        {
            //if (!(JPermission.CheckPermission("Estates.JSheetLog.Insert")))
            //    return -1;
            
            JSheetLogTable JLT = new JSheetLogTable();
            JSheetLogDetails tmpBillListGoods = new JSheetLogDetails();
            try
            {
                JLT.SetValueProperty(this);
                Db.beginTransaction("InsertSheetLog");

                Code = JLT.Insert(Db);
                if (Code > 0)
                {
                    tmpBillListGoods._Insert = true;
                    if (tmpBillListGoods.Save(Code, SheetLogDetails, Db))
                    {
                        if (Db.Commit())
                        {
                            //Nodes.DataTable.Merge(JBillGoodss.GetDataTable(Code));
                            return Code;
                        }
                        else
                        {
                            Db.Rollback("InsertSheetLog");
                            return 0;
                        }
                    }
                    else
                    {
                        Db.Rollback("InsertSheetLog");
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertBillGoods");
                return 0;
            }
            finally
            {
                JLT.Dispose();
                Db.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            //if (!(JPermission.CheckPermission("Estates.JSheetLog.Delete")))
            //    return false;

            if (!(JMessages.Question("آیا می خواهید آیتم مورد نظر حذف شود ؟", "Confirm?") == System.Windows.Forms.DialogResult.Yes))
                return false;

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JSheetLogTable PDT = new JSheetLogTable();
            JSheetLogDetails tmpBillListGoods = new JSheetLogDetails();
            GetData(pCode);
            if (Creator != JMainFrame.CurrentPersonCode)
            {
                JMessages.Error(" فقط شخص ایجاد کننده فاکتور می تواند فاکتور را حذف کند ", "");
                return false;
            }
            try
            {
                Db.beginTransaction("DeleteBillGoods");
                Code = pCode;
                PDT.SetValueProperty(this);
                tmpBillListGoods.Delete(Code, Db);
                if (PDT.Delete(Db))
                {
                    if (Db.Commit())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                    {
                        Db.Rollback("DeleteBillGoods");
                        return false;
                    }
                }
                else
                {
                    Db.Rollback("DeleteBillGoods");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Db.Rollback("DeleteBillGoods");
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
                PDT.Dispose();
                tmpBillListGoods.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                //if (!(JPermission.CheckPermission("Estates.JSheetLog.Update")))
               //     return false;

                JSheetLogDetails tmpBillListGoods = new JSheetLogDetails();
                JSheetLogTable PDT = new JSheetLogTable();
                PDT.SetValueProperty(this);
                Db.beginTransaction("UpdateBillGoods");
                PDT.Code = Code;
                if (PDT.Update())
                {
                    if (tmpBillListGoods.Save(Code, SheetLogDetails, Db))
                    {
                        if (Db.Commit())
                        {
                            //Nodes.Refreshdata(Nodes.CurrentNode, JBillGoodss.GetDataTable(Code).Rows[0]);
                            return true;
                        }
                        else
                        {
                            Db.Rollback("UpdateBillGoods");
                            return false;
                        }
                    }
                    else
                    {
                        Db.Rollback("UpdateBillGoods");
                        return false;
                    }
                }
                Db.Rollback("UpdateBillGoods");
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }       
             
        #endregion
    }

}
