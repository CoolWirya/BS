using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace Estates
{
    class JAggregateGrounds:JSystem
    {
        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد زمینی که با زمین های دیگر تجمیع می شود
        /// </summary>
        public int GroundsAggregationbyCode { get; set; }
        /// <summary>
        /// کد زمین حاصل از تجمیع زمین ها
        /// </summary>
        public int GroundAggregationbyCode { set; get; }
        #endregion
        #region Method
        public int insert(JDataBase Db)
        {
            JAggregateGroundsTable JAGsT = new JAggregateGroundsTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JAggregateGrounds.Insert"))
                {
                    JAGsT.SetValueProperty(this);
                    return JAGsT.Insert(Db);
                }
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
                JAGsT.Dispose();
            }
           
        }
        public bool Update(JDataBase Db)
        {
            JAggregateGroundsTable JAGsT = new JAggregateGroundsTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JAggregateGrounds.Update"))
                {
                    JAGsT.SetValueProperty(this);
                    return JAGsT.Update(Db);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JAGsT.Dispose();
            }

        }
        public bool Delete(JDataBase Db)
        {
            JAggregateGroundsTable JAGsT = new JAggregateGroundsTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JAggregateGrounds.Delete"))
                {
                    JAGsT.SetValueProperty(this);
                    return JAGsT.Delete(Db);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JAGsT.Dispose();
            }

        }




        #endregion


    }
    public class JAggregateGroundsAll
    {
        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where " + JTableNamesEstates.AggregateGrounds + "." +
                JAggregateGroundsTableEnum.GroundAggregationbyCode + "=" + pCode + " And " +
                JPermission.getObjectSql("Estates.JAggregateGroundsAll.GetDataTable", JTableNamesEstates.AggregateGrounds + ".Code");
            JDataBase Db = new JDataBase();
            string Qoury = "select " + JTableNamesEstates.AggregateGrounds + "." + JAggregateGroundsTableEnum.Code + "," +
                                  JAggregateGroundsTableEnum.GroundsAggregationbyCode + "," +
                                  JAggregateGroundsTableEnum.GroundAggregationbyCode + "," +
                                  JGroundTableEnum.MainAve + "," +
                                  JGroundTableEnum.SubNo + "," +
                                  JGroundTableEnum.Area +" from " +
                                  //JGroundTableEnum.Usage +                                 
                                  JTableNamesEstates.AggregateGrounds + " left Outer Join " +
                                  JTableNamesEstate.GroundTable + " on " +
                                  JTableNamesEstates.AggregateGrounds + "." + JAggregateGroundsTableEnum.GroundsAggregationbyCode + "=" + JTableNamesEstate.GroundTable + "." + JGroundTableEnum.Code;
            try
            {
                Db.setQuery(Qoury+Where);
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

        public static bool Save(DataTable GroundsAggregationby, int GroundAggregationbyCode, JDataBase Db)
        {
            try
            {
                bool ResultOut = false;
                foreach (DataRow Row in GroundsAggregationby.Rows)
                {
                    JAggregateGrounds JAGs;
                    //if (Row.RowState == DataRowState.Added)
                    //{
                    JAGs = new JAggregateGrounds();
                    //JAGs.Code = Convert.ToInt32(Row[JAggregateGroundsTableEnum.Code.ToString()]);
                    JAGs.GroundAggregationbyCode = GroundAggregationbyCode;
                    JAGs.GroundsAggregationbyCode = Convert.ToInt32(Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                    JAGs.insert(Db);
                    //غیر فعال کردن زمین تجمیع شده در جدول زمین هاو دارایی ها
                    int GroundCode = Convert.ToInt32(Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                    JGround Ground = new JGround(GroundCode, Db);
                    Ground.InactiveGround(Db,JGroundStatus.Aggregated);
                    ResultOut = true;
                    
                   



                    //}
                    //if (Row.RowState == DataRowState.Modified)
                    //{
                    //    JAGsT = new JAggregateGroundsTable();
                    //    JAGsT.Code = Convert.ToInt32(Row[JAggregateGroundsTableEnum.Code.ToString()]);
                    //    JAGsT.GroundAggregationbyCode = GroundAggregationbyCode;
                    //    JAGsT.GroundsAggregationbyCode = Convert.ToInt32(Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                    //    JAGsT.Update();

                    //}
                    //if (Row.RowState == DataRowState.Deleted)
                    //{
                    //    Row.RejectChanges();
                    //    if (Row[JAggregateGroundsTableEnum.Code.ToString()] != DBNull.Value)
                    //    {
                    //        JAGs = new JAggregateGrounds();
                    //        JAGs.Code = Convert.ToInt32(Row[JAggregateGroundsTableEnum.Code.ToString()]);
                    //        JAGs.Delete(Db);
                    //        //فعال کردن زمین خارج شده از تجمیع
                    //        int GroundCode = Convert.ToInt32(Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                    //        JGround Ground = new JGround(GroundCode);
                    //        Ground.ActivateGround();
                    //        Row.Delete();
                    //        ResultOut = true;


                    //    }
                    //    else
                    //        Row.Delete();


                    //    }
                }
                GroundsAggregationby.AcceptChanges();
                return ResultOut;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        public static bool Delete(DataTable GroundsAggregationby,  JDataBase Db)
        {
            try
            {
                bool ResultOut = true;
                foreach (DataRow Row in GroundsAggregationby.Rows)
                {
                    JAggregateGrounds JAGs;
                    if (Row[JAggregateGroundsTableEnum.Code.ToString()] != DBNull.Value)
                    {
                        JAGs = new JAggregateGrounds();
                        JAGs.Code = Convert.ToInt32(Row[JAggregateGroundsTableEnum.Code.ToString()]);
                        JAGs.Delete(Db);
                        //فعال کردن زمین خارج شده از تجمیع
                        int GroundCode = Convert.ToInt32(Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                        JGround Ground = new JGround(GroundCode);
                        Ground.ActivateGround(Db);
                        Row.Delete();
                        ResultOut = true;


                    }
                    else
                        Row.Delete();


                }
                GroundsAggregationby.AcceptChanges();
                return ResultOut;
            
            }
               
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            
        }

        
        
    }
}
