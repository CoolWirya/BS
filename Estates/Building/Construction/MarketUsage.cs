using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
    public class jMarketUsage: JSystem
    {
     public int Code { get; set; }
     public int MarketCode { get; set; }
     public int UsageCode { get; set; }
     public int Infrastructure { get; set; }

     #region Methods Insert,Update,delete,GetData

     /// <summary>
     /// درج 
     /// </summary>
     /// <returns></returns>
     public int Insert()
     {
         jMarketUsageTable PDT = new jMarketUsageTable();
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
         jMarketUsageTable PDT = new jMarketUsageTable();
         try
         {
             if (tmpdt != null)
             foreach (DataRow dr in tmpdt.Rows)
             {
                 if (dr.RowState == DataRowState.Added)
                 {
                     PDT.MarketCode = MarketCode;
                     PDT.UsageCode = Convert.ToInt32(dr[estMarketUsage.UsageCode.ToString()].ToString());
                     PDT.Infrastructure = dr[estMarketUsage.Infrastructure.ToString()].ToString();
                     PDT.Code = PDT.Insert(db);
                     if (PDT.Code < 1)
                         return false;
                     Histroy.Save(PDT, PDT.Code, "Insert");
                 }
                 else if (dr.RowState == DataRowState.Deleted)
                 {
                     dr.RejectChanges();
                     delete((int)dr[estMarketUsage.Code.ToString()], "", db);
                     dr.Delete();
                     Histroy.Save(PDT, PDT.Code, "");
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
         jMarketUsageTable PDT = new jMarketUsageTable();
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
         jMarketUsageTable PDT = new jMarketUsageTable();
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
                 Histroy.Save(PDT, PDT.Code, "Delete");
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
             DB.setQuery("SELECT * FROM " + JTableNamesEstate.MarketUsage + " WHERE " + estMarketUsage.Code + "=" + pCode.ToString());
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
             DB.setQuery("select MU." + estMarketUsage.Code + "," + estMarketUsage.UsageCode + "," + SubDefine.Name + "," + estMarketUsage.Infrastructure + " from " + JTableNamesEstate.MarketUsage + " MU inner join " + JTableNamesClassLibrary.SubBaseDefine + " SD on SD.Code=MU." + estMarketUsage.UsageCode + " WHERE " + estMarketUsage.MarketCode + "=" + pMarketCode.ToString());
             //DB.setQuery("SELECT * FROM " + JTableNamesEstate.MarketUsage + " WHERE " + estMarketUsage.MarketCode + "=" + pMarketCode.ToString());
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
