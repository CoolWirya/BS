using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Globals
{
    /// <summary>
    /// کلاس تصمیمات مجوز ها
    /// </summary>
    public class JPermissionDecision : JCore
    {
        /// <summary>
        /// لیست فیلدها
        /// </summary>
        #region Property
        //public JPermissionDecision[] Items;
        public int Code { get; set; }
        public String Name { get; set; }
        public int PermissionDefineCode { get; set; }
        public bool DefaultValue { get; set; }
        public string ClassName
        {
            get
            {
                JPermissionDefineClass defClass = new JPermissionDefineClass();
                defClass.GetData(this.PermissionDefineCode);
                return defClass.ClassName;
            }
        }
        #endregion
        /// <summary>
        /// سازنده
        /// </summary>
        public JPermissionDecision()
        {
        }
        /// <summary>
        /// درج در جدول تصمیمات
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (GetData(this.PermissionDefineCode, this.Name))
                return this.Code;
            JPermissionDecisionsTable PDT = new JPermissionDecisionsTable();
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
        /// بروزرسانی در جدول تصمیمات
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JPermissionDecisionsTable PDT = new JPermissionDecisionsTable();
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
        /// حذف از جدول تصمیمات بر اساس کد جدول
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            try
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                DB.setQuery("SELECT COUNT(*) FROM " + JTableNamesPermission.PermissionUser +
                    " WHERE " + PermissionUser.DecisionCode.ToString() + "=" + this.Code.ToString());
                if ((int)DB.Query_ExecutSacler() > 0)
                {
                    JMessages.Error("DecisionHasPermissions", "Error");
                    return false;
                }
                JPermissionDecisionsTable PDT = new JPermissionDecisionsTable();
                PDT.SetValueProperty(this);
                return PDT.Delete();
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
        /// چک کردن وجود اطلاعات در جدول تصمیمات بر اساس کد
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDecision + " WHERE " + PermissionDecision.Code + "=" + pCode.ToString());
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
        /// <returns></returns>
        public override string ToString()
        {
            return JLanguages._Text(Name);
        }
        /// <summary>
        /// پیدا کردن اطلاعات تصمیم بر اساس کد کلاس و نام آن
        /// </summary>
        /// <param name="pClassCode"></param>
        /// <param name="pName"></param>
        /// <returns></returns>
        public bool GetData(int pClassCode, string pName)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDecision + " WHERE " + PermissionDecision.PermissionDefineCode + "=" + pClassCode.ToString() +
                    " AND " + PermissionDecision.Name + " =" + JDataBase.Quote(pName));
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
    }


    public class JPermissionDecisions : JCore
    {
        public JPermissionDecision[] Items = new JPermissionDecision[0];
        public JPermissionDecisions()
        {
        }
        
        /// <summary>
        /// لیست تصمیمات مربوط به کلاس خاص
        /// </summary>
        /// <param name="pClassCode"></param>
        /// <returns></returns>
        public bool GetData(int pClassCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Query = "SELECT * FROM " + JTableNamesPermission.PermissionDecision;
                if (pClassCode != 0)
                    Query = Query + " WHERE " + PermissionDecision.PermissionDefineCode.ToString() + " = " + pClassCode.ToString();
                DB.setQuery(Query);
                DB.Query_DataReader();
                int count = 0;
                while (DB.DataReader.Read())
                {
                    Array.Resize(ref Items, count + 1);
                    Items[count] = new JPermissionDecision();
                    JTable.SetToClassProperty(Items[count], DB.DataReader);
                    count++;
                }
                return count > 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// لیست تصمیمات مربوط به کلاس خاص
        /// </summary>
        /// <param name="pClassCode"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pClassCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Query = "SELECT * FROM " + JTableNamesPermission.PermissionDecision;
                if (pClassCode != 0)
                    Query = Query + " WHERE " + PermissionDecision.PermissionDefineCode.ToString() + " = " + pClassCode.ToString();
                DB.setQuery(Query);
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
        /// پیدا کردن کد تصمیم بر اساس نام کد کلاس 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="PermissionDefineCode"></param>
        /// <returns></returns>
        //public static int FindPermissionDecision_Code(string pDecisionName, int pPermissionDefineCode)
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        DB.setQuery("SELECT " + PermissionDecision.Code + " FROM " + JTableNamesPermission.PermissionDecision + " WHERE " + PermissionDecision.Name + "='" + pDecisionName.Trim() + "' And " + PermissionDecision.PermissionDefineCode + "=" + pPermissionDefineCode);
        //        //(int)DB.Query_ExecutSacler();
        //        DB.Query_DataReader();
        //        if (DB.DataReader.Read())
        //        {
        //            return Convert.ToInt32(DB.DataReader["Code"].ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //    return 0;
        //}        
        /// <summary>
        ///لیست تصمیمات یک کلاس خاص 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        //public static DataTable FindPermissionDecision_All(int pClass_Code)
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        if (pClass_Code==0)
        //            DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDecision);
        //        else
        //            DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDecision + " Where " + PermissionDecision.PermissionDefineCode + "=" + pClass_Code);
        //        return DB.Query_DataTable();
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //    return null;
        //}
    }  
}
