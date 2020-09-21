using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;

namespace Globals
{
    /// <summary>
    /// کلاس امنیت
    /// </summary>
    public class JPermissionUser : JCore
    {
        #region Property
        /// <summary>
        /// کد پرمیشن کاربر
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد پرمیشن
        /// </summary>
        public int DecisionCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public int DefineClassCode { get; set; }
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int User_Post_Code { get; set; }
        /// <summary>
        /// مجوز
        /// </summary>
        public bool HasPermission { get; set; }
        /// <summary>
        /// ثبت کننده
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        ///  تاریخ شروع مجوز 
        /// </summary>
        public DateTime Start_Date { get; set; }
        /// <summary>
        /// تاریخ پایان مجوز
        /// </summary>
        public DateTime End_Date { get; set; }

        #endregion

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pUserCode"></param>
        /// <param name="pObjectCode"></param>
        public JPermissionUser()
        {
            ObjectCode = 0;
        }        
        /// <summary>
        /// جستجوی اطلاعات کاربر بر اساس کد جدول
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT * FROM " + JTableNamesPermission.PermissionUser + " WHERE Code=" + pCode.ToString());
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
        /// درج مجوزهای کاربر
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JPermissionUserTable PUT = new JPermissionUserTable();
            try
            {
                PUT.SetValueProperty(this);
                Code = PUT.Insert();
                return Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                PUT.Dispose();
            }
            return 0;
        }
        /// <summary>
        /// ویرایش مجوزهای کاربر
        /// </summary>
        /// <returns></returns>
        public bool update()
        {
            JPermissionUserTable PUT = new JPermissionUserTable();
            try
            {
                PUT.SetValueProperty(this);
                return PUT.Update();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                PUT.Dispose();
            }
            return false;
        }
        /// <summary>
        /// حذف مجوز کاربر
        /// </summary>
        /// <returns></returns>
        public bool delete()
        {
            JPermissionUserTable PUT = new JPermissionUserTable();
            try
            {
                PUT.SetValueProperty(this);
                return PUT.Delete();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                PUT.Dispose();
            }
            return false;
        }

        public override string ToString()
        {
            JPermissionDecision PD = new JPermissionDecision();
            PD.GetData(DecisionCode);

            JPermissionDefineClass PDC = new JPermissionDefineClass();
            PDC.GetData(PD.PermissionDefineCode);

            if (PDC.SQL!=null && PDC.SQL.Length > 0 && ObjectCode != 0)
            {
                return PDC + "->" + PDC.GetObjectKey(ObjectCode) + "->" + PD;
            }

            return PDC + "->" + PD;
        }
        /// <summary>
        /// جستجوی دسترسی کاربر به یک تصمیم خاص
        /// </summary>
        /// <param name="User_Code"></param>
        /// <param name="Class_Code"></param>
        /// <param name="Decesion_Code"></param>
        /// <returns></returns>
    //    public static int Find_PermissionUser(int pUser_Code, int pClass_Code, int pDecesion_Code, int pObjectCode)
    //    {
    //        JDataBase DB = JGlobal.MainFrame.GetDBO();
    //        try
    //        {
    //            if (pObjectCode==0)
    //                DB.setQuery("SELECT " + PermissionUser.Code + " FROM " +
    //                JTableNamesPermission.PermissionUser + " WHERE " +
    //                PermissionUser.HasPermission + "='True' And " +
    //                PermissionUser.User_post_Code + "=" + pUser_Code.ToString() +
    //                " AND " + PermissionUser.DefineClassCode + " =" + pClass_Code.ToString() +
    //                " AND  " + PermissionUser.DecisionCode + "  =" + pDecesion_Code.ToString());
    //            else
    //            DB.setQuery(@"SELECT Code FROM " + JTableNamesPermission.PermissionUser + " WHERE " +
    //                PermissionUser.HasPermission + "='true' And "
    //                + PermissionUser.User_post_Code + "=" + pUser_Code.ToString()
    //                + " And " + PermissionUser.DefineClassCode + "=" + pClass_Code.ToString()
    //                + " And " + PermissionUser.DecisionCode + "=" + pDecesion_Code.ToString()
    //                + " And " + PermissionUser.ObjectCode + "=" + pObjectCode.ToString());
    //            return Convert.ToInt32(DB.Query_ExecutSacler());
    //            //if (DB.DataReader.Read())
    //            //{
    //            //    return Convert.ToInt32(DB.DataReader[0].ToString());
    //            //}
    //        }
    //        catch (Exception ex)
    //        {
    //            Except.AddException(ex);
    //        }
    //        finally
    //        {
    //            DB.Dispose();
    //        }
    //        return 0;
    //    }
    }


    /// <summary>
    /// کلاس امنیت کاربر
    /// </summary>
    public class JPermissionsUser : JCore
    {
        #region Property
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int UserCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JPermissionUser[] Items;
        #endregion

        /// <summary>
        ///  سازنده کلاس
        /// </summary>
        /// <param name="pUserCode"></param>
        public JPermissionsUser(int pUserCode)
        {
            UserCode = pUserCode;
        }

        /// <summary>
        /// جستجوی کد مجوزهای کاربر بر اساس کد کاربر
        /// </summary>
        /// <returns></returns>
        public Boolean GetData()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT Code FROM PermissionUser WHERE " + PermissionUser.User_post_Code + "=" + UserCode.ToString());

                DB.Query_DataReader();
                Items = new JPermissionUser[DB.RecordCount];
                int count = 0;
                while (DB.DataReader.Read())
                {
                    Items[count] = new JPermissionUser();
                    Items[count].GetData(int.Parse(DB.DataReader["Code"].ToString()));
                    count++;
                }
                return true;
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
}
