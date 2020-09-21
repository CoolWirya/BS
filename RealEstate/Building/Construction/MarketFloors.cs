using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace RealEstate
{
    public class jMarketFloors : JSystem
    {

        #region Property

        public int Code { get; set; }
        /// <summary>
        ///  کد مجتمع
        /// </summary>
        public int MarketCode { get; set; }
        /// <summary>
        ///  نام طبقه
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  شماره طبقه
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        ///  زیربنا
        /// </summary>
        public decimal Infrastructure { get; set; }
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Methods Insert,Update,delete,GetData
        public jMarketFloors()
        {
        }
        public jMarketFloors(int pCode)
        {
            GetData(pCode);
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            jMarketFloorsTable PDT = new jMarketFloorsTable();
            try
            {
                PDT.SetValueProperty(this);
                PDT.Code = PDT.Insert();
                Histroy.Save(this, PDT, PDT.Code, "Insert");
                return PDT.Code;
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
            jMarketFloorsTable PDT = new jMarketFloorsTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PDT.MarketCode = MarketCode;
                            PDT.Name = dr[estMarketFloors.Name.ToString()].ToString();
                            PDT.Number = Convert.ToInt32(dr[estMarketFloors.Number.ToString()].ToString());
                            PDT.Infrastructure = Convert.ToDecimal(dr[estMarketFloors.Infrastructure.ToString()].ToString());
                            PDT.Description = dr[estMarketFloors.Description.ToString()].ToString();
                            PDT.Code = PDT.Insert(db);
                            if (PDT.Code < 1)
                                return false;
                            Histroy.Save(this, PDT, PDT.Code, "Insert");
                        }
                        else
                            if (dr.RowState == DataRowState.Deleted)
                            {
                                dr.RejectChanges();
                                if (delete((int)dr[estMarketFloors.Code.ToString()], "", null))
                                {
                                    dr.Delete();
                                    Histroy.Save(this, PDT, this.Code, "Delete");
                                }

                            }
                            else
                                if (dr.RowState == DataRowState.Modified)
                                {
                                    PDT.Code = (int)dr[estMarketFloors.Code.ToString()];
                                    PDT.MarketCode = MarketCode;
                                    PDT.Name = dr[estMarketFloors.Name.ToString()].ToString();
                                    PDT.Number = Convert.ToInt32(dr[estMarketFloors.Number.ToString()].ToString());
                                    PDT.Infrastructure = Convert.ToDecimal(dr[estMarketFloors.Infrastructure.ToString()].ToString());
                                    PDT.Description = dr[estMarketFloors.Description.ToString()].ToString();
                                    if (!PDT.Update(db))
                                        return false;
                                    Histroy.Save(this, PDT, PDT.Code, "Update");
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
            return Update(new JDataBase());
        }

        public bool Update(JDataBase db)
        {
            jMarketFloorsTable PDT = new jMarketFloorsTable();
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
            jMarketFloorsTable PDT = new jMarketFloorsTable();
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
                    Histroy.Save(this, PDT, PDT.Code, "Delete");
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
                DB.setQuery("SELECT * FROM " + JTableNamesEstate.MarketFloors + " WHERE " + estMarketFloors.Code + "=" + pCode.ToString());
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
                DB.setQuery(@"SELECT " +
                    estMarketFloors.Code.ToString() + "," +
                    estMarketFloors.Number.ToString() + "," + estMarketFloors.Name.ToString() + "," +
                    estMarketFloors.Infrastructure.ToString() + "," + estMarketFloors.Description.ToString()
                + " FROM " + JTableNamesEstate.MarketFloors + " WHERE "
                + estMarketFloors.MarketCode + "=" + pMarketCode.ToString() + " ORDER BY " + estMarketFloors.Number.ToString());
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
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
