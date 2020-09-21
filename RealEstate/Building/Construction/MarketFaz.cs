using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;


namespace RealEstate
{
    public class JMarketFaz : JSystem
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
        public string Title { get; set; }        
        /// <summary>
        ///  زیربنا
        /// </summary>
        public decimal Area { get; set; }        

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JMarketFazTable PDT = new JMarketFazTable();
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
            JMarketFazTable PDT = new JMarketFazTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PDT.MarketCode = MarketCode;
                            PDT.Title = dr[estMarketFaz.Title.ToString()].ToString();
                            PDT.Area = Convert.ToDecimal(dr[estMarketFaz.Area.ToString()].ToString());
                            PDT.Code = PDT.Insert(db);
                            if (PDT.Code < 1)
                                return false;
                            Histroy.Save(this, PDT, PDT.Code, "Insert");
                        }
                        else
                            if (dr.RowState == DataRowState.Deleted)
                            {
                                dr.RejectChanges();
                                if (delete((int)dr[estMarketFaz.Code.ToString()], "", null))
                                {
                                    dr.Delete();
                                    //Histroy.Save("Deleted", this.Code);
                                }

                            }
                            else
                                if (dr.RowState == DataRowState.Modified)
                                {
                                    PDT.Code = (int)dr[estMarketFaz.Code.ToString()];
                                    PDT.MarketCode = MarketCode;
                                    PDT.Title = dr[estMarketFaz.Title.ToString()].ToString();
                                    PDT.Area = Convert.ToDecimal(dr[estMarketFaz.Area.ToString()].ToString());
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
            JMarketFazTable PDT = new JMarketFazTable();
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
            JMarketFazTable PDT = new JMarketFazTable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesEstate.MarketFaz + " WHERE " + estMarketFaz.Code + "=" + pCode.ToString());
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
                    estMarketFaz.Code.ToString() + "," +
                    estMarketFaz.Title.ToString() + "," + 
                    estMarketFaz.Area.ToString()
                + " FROM " + JTableNamesEstate.MarketFaz + " WHERE "
                + estMarketFaz.MarketCode + "=" + pMarketCode.ToString() + " ORDER BY " + estMarketFaz.Title.ToString());
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
            return Title;
        }

        #endregion
    }
}
