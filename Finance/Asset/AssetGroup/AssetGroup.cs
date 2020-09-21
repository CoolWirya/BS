using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Finance
{
    public class JAssetGroup : JFinance
    {
        /// <summary>
        /// کد گروه اموال زمین و سهام که در دیتابیس به همین صورت وارد شده
        /// </summary>
        public static int GroundGroupCode = 1;
        public static int ShareGroupCode = 2;
        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// نام گروه
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName
        {
            get;
            set;
        }
        /// <summary>
        /// کد 
        /// </summary>
        public int ObjectCode
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            try
            {
                JAssetGroupTable PDT = new JAssetGroupTable();
                PDT.SetValueProperty(this);
                if(Code>0)
                    Code = PDT.InsertManual();
                else
                    Code = PDT.Insert();

                if (Code > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JAssetGroupTable PDT = new JAssetGroupTable();
            try
            {               
                    PDT.SetValueProperty(this);
                    if (PDT.Delete())
                        return true;
                    return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //Db.Dispose();
            }
        }

        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            try
            {
                JAssetGroupTable PDT = new JAssetGroupTable();
                PDT.SetValueProperty(this);
                if (PDT.Update())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from " + JTableNamesFinance.AssetGroup + Where +
                " And " + JPermission.getObjectSql("Finance.JAssetGroup.GetDataTable", JTableNamesFinance.AssetGroup + ".Code");
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
