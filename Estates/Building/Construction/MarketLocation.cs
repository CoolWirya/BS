using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
    public class jMarketLocation : JSystem
    {
        public int Code { get; set; }
        public int MarketCode { get; set; }
        public int GroundCode { get; set; }
        public int occupancy { get; set; }

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            jMarketLocationTable PDT = new jMarketLocationTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Insert();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
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
        public bool Insert(DataTable tmpdt, int MarketCode, JDataBase db)
        {
            jMarketLocationTable PDT = new jMarketLocationTable();
            try
            {
                if (tmpdt != null)
                foreach(DataRow dr in tmpdt.Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        PDT.MarketCode = MarketCode;
                        PDT.GroundCode = Convert.ToInt32(dr[estMarketLocation.GroundCode.ToString()].ToString());
                        PDT.occupancy = dr[estMarketLocation.occupancy.ToString()].ToString();
                        if (PDT.Insert(db) < 1)
                            return false;
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        dr.RejectChanges();
                        delete((int)dr[estMarketLocation.Code.ToString()], "", db);
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
        /// بروزرسانی 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            jMarketLocationTable PDT = new jMarketLocationTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Update();
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
        public bool delete(int pCode, string Exp, JDataBase db)
        {
            jMarketLocationTable PDT = new jMarketLocationTable();
            try
            {
                if (Exp == "")
                {
                    GetData(pCode);
                    PDT.SetValueProperty(this);
                    return PDT.Delete();
                }
                else
                {
                    PDT.Delete(true, Exp, db);
                    return PDT.GetDeleteCount() > -1;                    
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
                DB.setQuery("SELECT * FROM " + JTableNamesEstate.MarketLocation + " WHERE " + estMarketLocation.Code + "=" + pCode.ToString());
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
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetDataByMarketCode(int pMarketCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"select L." + estMarketLocation.Code + "," + estMarketLocation.GroundCode + "," + JGroundTableEnum.BlockNum + "," + JGroundTableEnum.PartNum + "," + JGroundTableEnum.MainAve + "+" + JGroundTableEnum.SubNo + " as 'Pelak', " + estMarketLocation.occupancy + " from " + JTableNamesEstate.MarketLocation + " L inner join " + JTableNamesEstate.GroundTable + " G on G.Code=L.GroundCode" + " WHERE L." + estMarketLocation.MarketCode + "=" + pMarketCode.ToString());
                //DB.setQuery("SELECT * FROM " + JTableNamesEstate.MarketLocation + " WHERE " + estMarketLocation.MarketCode + "=" + pMarketCode.ToString());
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
        /// <returns></returns>
        //public override string ToString()
        //{
        //    return JLanguages._Text(Name);
        //}

        #endregion
    }
}
