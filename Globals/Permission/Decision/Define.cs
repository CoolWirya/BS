using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Globals
{
    public class JPermissionDefineClass : JCore
    {
        /// <summary>
        /// لیست فیلد ها
        /// </summary>
        #region Property
        //public JPermissionDecision[] Items;
        public int Code { get; set; }
        public string ClassName { get; set; }
        public string SQL { get; set; }
        public int ParentCode { get; set; }
        public bool HasData;
        #endregion
        /// <summary>
        /// سازنده
        /// </summary>
        #region Constructor
        public JPermissionDefineClass()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        /// <param name="pClassName"></param>
        public JPermissionDefineClass(string pClassName)
        {
            ClassName = pClassName;
            HasData = GetData(ClassName);
        }
        #endregion

        /// <summary>
        /// جستجوی اطلاعات کلاس بر اساس نام آن
        /// </summary>
        /// <param name="pClassName"></param>
        /// <returns></returns>
        public Boolean GetData(string pClassName)
        {
           // if (Items != null)
            //    Array.Resize(ref Items, 0);
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                try
                {
                    DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass+ " WHERE ClassName=" + JDataBase.Quote(pClassName));
                    DB.Query_DataReader();
                    if (DB.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, DB.DataReader);
                        return true;
                    }
                    //GetDecisions();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// جستجوی کلاس خاص بر اساس کد آن
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                try
                {
                    DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass + " WHERE " + PermissionDefineClass.Code + "=" + pCode.ToString());
                    DB.Query_DataReader();
                    if (DB.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, DB.DataReader);
                    }
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
            finally
            {
                DB.Dispose();
            }
            return true;
        }
        /// <summary>
        /// درج کلاس
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            /// در صورتی که نام کلاس وجود دارد
            if (GetData(ClassName))
            {
                JMessages.Error("ClassNameExists", "Error");
                return 0;
            }
            JPermissionDefineClassTable PDC = new JPermissionDefineClassTable();
            try
            {
                PDC.SetValueProperty(this);
                int result = PDC.Insert();
                if (result > 0)
                {
                    JPermissionDecision decInsert = new JPermissionDecision();
                    decInsert.PermissionDefineCode = result;
                    decInsert.Name = JLanguages._Text("Insert");
                    decInsert.Insert();
                    decInsert.Name = JLanguages._Text("Update");
                    decInsert.Insert();
                    decInsert.Name = JLanguages._Text("Delete");
                    decInsert.Insert();
                    decInsert.Name = JLanguages._Text("View");
                    decInsert.Insert();
                }
                return result;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
            }
        }
        /// <summary>
        /// حذف کلاس
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Delete()
        {
            return Delete(this.Code);
        }

        public Boolean Delete(int pCode)
        {
            try
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                DB.setQuery("SELECT COUNT(*) FROM " + JTableNamesPermission.PermissionUser +
                    " WHERE " + PermissionUser.DecisionCode.ToString() + " IN (" +
                    " SELECT  " + PermissionDecision.Code.ToString() + " FROM " + JTableNamesPermission.PermissionDecision +
                    " WHERE " + PermissionDecision.PermissionDefineCode.ToString() + "=" + pCode.ToString() + ")");
                if ((int)DB.Query_ExecutSacler() > 0)
                {
                    JMessages.Error("DefineClassHasPermissions", "Error");
                    return false;
                }

                JPermissionDefineClassTable PDC = new JPermissionDefineClassTable();
                PDC.SetValueProperty(this);
                return PDC.Delete();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }
        /// <summary>
        /// بروزرسانی کلاس
        /// </summary>
        public Boolean Update()
        {
            JPermissionDefineClassTable PDC = new JPermissionDefineClassTable();
            try
            {
                PDC.SetValueProperty(this);
                return PDC.Update();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }

        /// <summary>
        /// لیست آبجکتهایی که از اس کیو ال برگردانده شده
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetObjectList()
        {
            IDictionary<string, object> Dic = new Dictionary<string, object>();
            if (SQL.Length > 0)
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    DB.setQuery(SQL);
                    DB.Query_DataReader();
                    while (DB.DataReader.Read())
                    {
                        Dic.Add(DB.DataReader[0].ToString(), DB.DataReader[1]);
                    }
                    return Dic;
                }
                finally
                {
                    DB.Dispose();
                }

            }
            return null;
        }

        public string GetObjectKey(int pCode)
        {
            foreach (KeyValuePair<string, object> dic in GetObjectList())
                if (Int32.Parse(dic.Key) == pCode)
                    return dic.Value.ToString();
            return "";
        }

        public override string ToString()
        {
            return JLanguages._Text(ClassName);
        }

        #region Removed

        /// <summary>
        /// پیدا کردن اطلاعات کلاس از نام آن
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        //public static DataTable FindPermissionDefineClass(string pClassName)
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        if ( pClassName == "" )
        //            DB.setQuery("SELECT * FROM " + ClassLibrary.JTableNamesPermission.PermissionDefineClass);
        //        else
        //            DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass + " WHERE " + PermissionDefineClass.ClassName + "='" + pClassName.Trim() + "'");
        //        return DB.Query_DataTable();
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}
        
        
        /// <summary>
        /// پیدا کردن لیست کاربرانی که مجوز به یک کلاس و تصمیم خاص را دارند
        /// </summary>
        /// <param name="Class_Code"></param>
        /// <param name="Decesion_Code"></param>
        /// <returns></returns>
        //public static DataTable Permission_UserList(int Class_Code, int Decesion_Code, int _Object_Code)
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        if (_Object_Code == 0)
        //            DB.setQuery(@"SELECT * FROM ( SELECT users.code as 'codeU',clsPerson.* FROM " + JTableNamesClassLibrary.PersonTable + " inner join users on users.pcode=clsPerson.Code) AS Person WHERE codeU in (Select " + PermissionUser.User_post_Code + " from " + JTableNamesPermission.PermissionUser + " Where " + PermissionUser.HasPermission + "='True' And " + PermissionUser.DecisionCode + "=" + Decesion_Code + " and " + PermissionUser.DefineClassCode + "= " + Class_Code + ")");
        //        else
        //            DB.setQuery(@"SELECT * FROM ( SELECT users.code as 'codeU',clsPerson.* FROM " + JTableNamesClassLibrary.PersonTable + " inner join users on users.pcode=clsPerson.Code) AS Person WHERE codeU in (Select " + PermissionUser.User_post_Code + " from " + JTableNamesPermission.PermissionUser + " Where " + PermissionUser.HasPermission + "='True' And " + PermissionUser.DecisionCode + "=" + Decesion_Code + " and " + PermissionUser.DefineClassCode + "= " + Class_Code + " And " + PermissionUser.ObjectCode + "=" + _Object_Code + ")");
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
        /// <summary>
        /// ساختار درختی لیست مجوزهای یک کاربر خاص
        /// </summary>
        /// <param name="User_Code"></param>
        /// <returns></returns>
        //public DataTable User_PermissionList(int User_Code)
        //{
        //    JPermissionDecision tmpJPermissionDecisions = new JPermissionDecision();
        //    JPermissionDefineClass tmpJPermissionsDefineClass = new JPermissionDefineClass();
        //    JPermission tmpJPermission = new JPermission();
        //    DataTable tmpdtClass = new DataTable();
        //    DataTable tmpdtDecision = new DataTable();
        //    DataTable tmpdt = new DataTable();
        //    try
        //    {
        //        tmpdtClass = JPermissionDefineClass.FindPermissionDefineClass("");
        //        tmpdt.Columns.Add("ID");
        //        tmpdt.Columns.Add("parentcode");
        //        tmpdt.Columns.Add("code");
        //        tmpdt.Columns.Add("class_code");
        //        tmpdt.Columns.Add("full_title");
        //        tmpdt.Columns.Add("User_code");
        //        tmpdt.Columns.Add("Start_Date");
        //        tmpdt.Columns.Add("End_Date");
        //        tmpdt.Columns.Add("ObjectCode");
        //        int ID = 1;
        //        int IDParent = 0, tmpIDParent = 0;
        //        DataRow tmpdr;
        //        tmpdr = tmpdt.NewRow();
        //        tmpdr["ID"] = ID;
        //        tmpdr["code"] = null;
        //        tmpdr["class_code"] = null;
        //        tmpdr["full_title"] = "مجوز کاربر";
        //        tmpdr["parentcode"] = null;
        //        tmpdr["User_code"] = null;
        //        tmpdr["Start_Date"] = null;
        //        tmpdr["End_Date"] = null;
        //        tmpdr["ObjectCode"] = null;
        //        tmpdt.Rows.Add(tmpdr);
        //        int i = 0, flag = 0;
        //        foreach (DataRow drClass in tmpdtClass.Rows)
        //        {
        //            i = 0;
        //            if ((drClass["SQL"] != null) && (drClass["SQL"].ToString() != ""))
        //            {
        //                JDataBase DB = JGlobal.MainFrame.GetDBO();
        //                DataTable dt = new DataTable();
        //                DB.setQuery(drClass["SQL"].ToString());
        //                dt = DB.Query_DataTable();
        //                ///
        //                flag = 1;
        //                foreach (DataRow drClassType in dt.Rows)
        //                {
        //                    i = 0;
        //                    tmpdtDecision = JPermissionDecisions.FindPermissionDecision_All(Convert.ToInt32(drClass["Code"].ToString()));
        //                    foreach (DataRow drDecision in tmpdtDecision.Rows)
        //                    {
        //                        if (tmpJPermission.UserAllowbyCodeObject1(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drClassType["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()))) i++;
        //                        if (i == 1)
        //                        {
        //                            if (flag == 1)
        //                            {
        //                                ID++;
        //                                tmpdr = tmpdt.NewRow();
        //                                tmpdr["ID"] = ID;
        //                                tmpdr["code"] = drClass["Code"];
        //                                tmpdr["class_code"] = null;
        //                                tmpdr["full_title"] = drClass["ClassName"].ToString();
        //                                tmpdr["parentcode"] = null;
        //                                tmpdr["User_code"] = null;
        //                                tmpdr["Start_Date"] = null;
        //                                tmpdr["End_Date"] = null;
        //                                tmpdr["ObjectCode"] = null;
        //                                tmpdt.Rows.Add(tmpdr);
        //                                IDParent = ID;
        //                                tmpIDParent = IDParent;
        //                                flag = 2;
        //                            }
        //                            ID++;
        //                            tmpdr = tmpdt.NewRow();
        //                            tmpdr["ID"] = ID;
        //                            tmpdr["code"] = drClassType["Code"];
        //                            tmpdr["class_code"] = null;
        //                            tmpdr["full_title"] = drClassType["Name"].ToString();
        //                            tmpdr["parentcode"] = tmpIDParent;
        //                            tmpdr["User_code"] = null;
        //                            tmpdr["Start_Date"] = null;
        //                            tmpdr["End_Date"] = null;
        //                            tmpdr["ObjectCode"] = null;
        //                            tmpdt.Rows.Add(tmpdr);
        //                            IDParent = ID;
        //                        }
        //                        if (tmpJPermission.UserAllowbyCodeObject1(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drClassType["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString())))
        //                        {
        //                            ID++;
        //                            tmpdr = tmpdt.NewRow();
        //                            tmpdr["ID"] = ID;
        //                            tmpdr["code"] = drDecision["Code"];
        //                            tmpdr["class_code"] = drClass["Code"];
        //                            tmpdr["full_title"] = drDecision["Name"];
        //                            tmpdr["parentcode"] = IDParent;
        //                            tmpdr["ObjectCode"] = drClassType["Code"]; ;// tmpJPermissionDecisions.Find_UserObjectCode(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()));
        //                            tmpdr["User_code"] = JPermissionUser.Find_PermissionUser(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()), Convert.ToInt32(tmpdr["ObjectCode"]));
        //                            tmpdr["Start_Date"] = null;//drDecision["Start_Date"];
        //                            tmpdr["End_Date"] = null;//drDecision["End_Date"];
        //                            tmpdt.Rows.Add(tmpdr);
        //                            i = 2;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                tmpdtDecision = JPermissionDecisions.FindPermissionDecision_All(Convert.ToInt32(drClass["Code"].ToString()));
        //                foreach (DataRow drDecision in tmpdtDecision.Rows)
        //                {
        //                    if (tmpJPermission.UserAllowbyCodeObject1(User_Code, Convert.ToInt32(drClass["Code"].ToString()), 0, Convert.ToInt32(drDecision["Code"].ToString()))) i++;
        //                    if (i == 1)
        //                    {
        //                        ID++;
        //                        tmpdr = tmpdt.NewRow();
        //                        tmpdr["ID"] = ID;
        //                        tmpdr["code"] = drClass["Code"];
        //                        tmpdr["class_code"] = null;
        //                        tmpdr["full_title"] = drClass["ClassName"].ToString();
        //                        tmpdr["parentcode"] = null;
        //                        tmpdr["User_code"] = null;
        //                        tmpdr["Start_Date"] = null;
        //                        tmpdr["End_Date"] = null;
        //                        tmpdr["ObjectCode"] = null;
        //                        tmpdt.Rows.Add(tmpdr);
        //                        IDParent = ID;
        //                    }
        //                    if (tmpJPermission.UserAllowbyCodeObject1(User_Code, Convert.ToInt32(drClass["Code"].ToString()),0, Convert.ToInt32(drDecision["Code"].ToString())))
        //                    {
        //                        ID++;
        //                        tmpdr = tmpdt.NewRow();
        //                        tmpdr["ID"] = ID;
        //                        tmpdr["code"] = drDecision["Code"];
        //                        tmpdr["class_code"] = drClass["Code"];
        //                        tmpdr["full_title"] = drDecision["Name"];
        //                        tmpdr["parentcode"] = IDParent;
        //                        tmpdr["ObjectCode"] = null;
        //                        //JPermissionUser.Find_UserObjectCode(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()));
        //                        tmpdr["User_code"] = JPermissionUser.Find_PermissionUser(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()), 0);
        //                        tmpdr["Start_Date"] = null;//drDecision["Start_Date"];
        //                        tmpdr["End_Date"] = null;//drDecision["End_Date"];                                
        //                        tmpdt.Rows.Add(tmpdr);
        //                        i = 2;
        //                    }
        //                }
        //            }
        //        }
        //        return tmpdt;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //    }
        //    finally
        //    {
        //        tmpJPermissionDecisions.Dispose();
        //        tmpJPermissionsDefineClass.Dispose();
        //        tmpJPermission.Dispose();
        //        tmpdtClass.Dispose();
        //        tmpdtDecision.Dispose();
        //        tmpdt.Dispose();
        //    }
        //    return null;
        //}

        ///// <summary>
        /////ساختار درختی لیست مجوزهای یک کنترل خاص   
        ///// </summary>
        ///// <param name="User_Code"></param>
        ///// <returns></returns>
        //public DataTable Control_PermissionList(string pClass_Name, string pObject_Name, int pType)
        //{
        //    JPermissionDecision tmpJPermissionDecisions = new JPermissionDecision();
        //    JPermissionDefineClass tmpJPermissionsDefineClass = new JPermissionDefineClass();
        //    JPermission tmpJPermission = new JPermission();
        //    JPermissionControls tmpJPermissionControls = new JPermissionControls();
        //    DataTable tmpdtClass = new DataTable();
        //    DataTable tmpdtDecision = new DataTable();
        //    DataTable tmpdt = new DataTable();
        //    JPermissionControls tmpJPermissionControls1 = new JPermissionControls();
        //    bool flagtmpJPermissionControls = false;
        //    try
        //    {
        //        tmpdtClass = JPermissionDefineClass.FindPermissionDefineClass("");
        //        tmpdt.Columns.Add("ID");
        //        tmpdt.Columns.Add("parentcode");
        //        tmpdt.Columns.Add("code");
        //        tmpdt.Columns.Add("class_code");
        //        tmpdt.Columns.Add("full_title");
        //        //tmpdt.Columns.Add("User_code");
        //        //tmpdt.Columns.Add("Start_Date");
        //        //tmpdt.Columns.Add("End_Date");
        //        tmpdt.Columns.Add("ObjectCode");
        //        int ID = 1;
        //        int IDParent = 1, tmpIDParent = 1;
        //        DataRow tmpdr;
        //        tmpdr = tmpdt.NewRow();
        //        tmpdr["ID"] = ID;
        //        tmpdr["code"] = null;
        //        tmpdr["class_code"] = null;
        //        tmpdr["full_title"] = "مجوز کاربر";
        //        tmpdr["parentcode"] = null;
        //        //tmpdr["User_code"] = null;
        //        //tmpdr["Start_Date"] = null;
        //        //tmpdr["End_Date"] = null;
        //        tmpdr["ObjectCode"] = null;
        //        tmpdt.Rows.Add(tmpdr);
        //        int i = 0, flag = 0;
        //        foreach (DataRow drClass in tmpdtClass.Rows)
        //        {
        //            i = 0;
        //            tmpdtDecision = JPermissionDecisions.FindPermissionDecision_All(Convert.ToInt32(drClass["Code"].ToString()));
        //            foreach (DataRow drDecision in tmpdtDecision.Rows)
        //            {
        //                tmpJPermissionControls1.Class_Name = pClass_Name;
        //                tmpJPermissionControls1.Object_Name = pObject_Name;
        //                tmpJPermissionControls1.Class_Code = Convert.ToInt32(drClass["Code"].ToString());
        //                tmpJPermissionControls1.Decision_Code = Convert.ToInt32(drDecision["Code"].ToString());
        //                tmpJPermissionControls1.Type = pType;                        
        //                flagtmpJPermissionControls=tmpJPermissionControls1.SearchControl();

        //                if (flagtmpJPermissionControls) i++;
        //                if (i == 1)
        //                {
        //                    ID++;
        //                    tmpdr = tmpdt.NewRow();
        //                    tmpdr["ID"] = ID;
        //                    tmpdr["code"] = drClass["Code"];
        //                    tmpdr["class_code"] = null;
        //                    tmpdr["full_title"] = drClass["ClassName"].ToString();
        //                    tmpdr["parentcode"] = tmpIDParent;
        //                    //tmpdr["User_code"] = null;
        //                    //tmpdr["Start_Date"] = null;
        //                    //tmpdr["End_Date"] = null;
        //                    tmpdr["ObjectCode"] = null;
        //                    tmpdt.Rows.Add(tmpdr);
        //                    IDParent = ID;
        //                }
        //                if (flagtmpJPermissionControls)
        //                {
        //                    ID++;
        //                    tmpdr = tmpdt.NewRow();
        //                    tmpdr["ID"] = ID;
        //                    tmpdr["code"] = drDecision["Code"];
        //                    tmpdr["class_code"] = drClass["Code"];
        //                    tmpdr["full_title"] = drDecision["Name"];
        //                    tmpdr["parentcode"] = IDParent;
        //                    tmpdr["ObjectCode"] = null;// tmpJPermissionDecisions.Find_UserObjectCode(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()));
        //                    //tmpdr["User_code"] = null; //tmpJPermissionDecisions.Find_UserCode(User_Code, Convert.ToInt32(drClass["Code"].ToString()), Convert.ToInt32(drDecision["Code"].ToString()), Convert.ToInt32(tmpdr["ObjectCode"]));
        //                    //tmpdr["Start_Date"] = null;//drDecision["Start_Date"];
        //                    //tmpdr["End_Date"] = null;//drDecision["End_Date"];                                
        //                    tmpdt.Rows.Add(tmpdr);
        //                    i = 2;
        //                }
        //            }
        //        }
        //        return tmpdt;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //    }
        //    finally
        //    {
        //        tmpJPermissionDecisions.Dispose();
        //        tmpJPermissionsDefineClass.Dispose();
        //        tmpJPermission.Dispose();
        //        tmpdtClass.Dispose();
        //        tmpdtDecision.Dispose();
        //        tmpdt.Dispose();
        //    }
        //    return null;
        //}
        ///// <summary>
        ///// ساختار درختی لیست کلیه مجوزها
        ///// </summary>
        ///// <returns></returns>
        //public DataTable Permission_List()
        //{
        //    JPermissionDecision tmpJPermissionDecisions = new JPermissionDecision();
        //    JPermissionDefineClass tmpJPermissionsDefineClass = new JPermissionDefineClass();
        //    DataTable tmpdtClass = new DataTable();
        //    DataTable tmpdtDecision = new DataTable();
        //    DataTable tmpdt = new DataTable();
        //    try
        //    {
        //        tmpdtClass = JPermissionDefineClass.FindPermissionDefineClass("");
        //        tmpdt.Columns.Add("ID");
        //        tmpdt.Columns.Add("parentcode");
        //        tmpdt.Columns.Add("code");
        //        tmpdt.Columns.Add("class_code");
        //        tmpdt.Columns.Add("full_title");
        //        tmpdt.Columns.Add("ObjectCode");
        //        int ID = 1;
        //        int IDParent, tmpIDParent = 0;
        //        DataRow tmpdr;
        //        tmpdr = tmpdt.NewRow();
        //        tmpdr["ID"] = ID;
        //        tmpdr["code"] = 0;
        //        tmpdr["class_code"] = null;
        //        tmpdr["full_title"] = "لیست مجوزها";
        //        tmpdr["parentcode"] = null;
        //        tmpdr["ObjectCode"] = null;
        //        tmpdt.Rows.Add(tmpdr);
        //        foreach (DataRow drClass in tmpdtClass.Rows)
        //        {
        //            ID++;
        //            tmpdr = tmpdt.NewRow();
        //            tmpdr["ID"] = ID;
        //            tmpdr["code"] = drClass["Code"];
        //            tmpdr["class_code"] = null;
        //            tmpdr["full_title"] = drClass["ClassName"].ToString();
        //            tmpdr["parentcode"] = null;
        //            tmpdr["ObjectCode"] = null;
        //            tmpdt.Rows.Add(tmpdr);
        //            IDParent = ID;
        //            if ((drClass["SQL"] != null) && (drClass["SQL"].ToString() != ""))
        //            {
        //                JDataBase DB = JGlobal.MainFrame.GetDBO();
        //                DataTable dt = new DataTable();
        //                DB.setQuery(drClass["SQL"].ToString());
        //                dt = DB.Query_DataTable();
        //                tmpIDParent = IDParent;
        //                foreach (DataRow drClassType in dt.Rows)
        //                {
        //                    ID++;
        //                    tmpdr = tmpdt.NewRow();
        //                    tmpdr["ID"] = ID;
        //                    tmpdr["code"] = drClassType["Code"];
        //                    tmpdr["class_code"] = drClass["Code"];
        //                    tmpdr["full_title"] = drClassType["Name"].ToString();
        //                    tmpdr["parentcode"] = tmpIDParent;
        //                    tmpdr["ObjectCode"] = null;
        //                    tmpdt.Rows.Add(tmpdr);
        //                    IDParent = ID;
        //                    tmpdtDecision = JPermissionDecisions.FindPermissionDecision_All(Convert.ToInt32(drClass["Code"].ToString()));
        //                    foreach (DataRow drDecision in tmpdtDecision.Rows)
        //                    {
        //                        ID++;
        //                        tmpdr = tmpdt.NewRow();
        //                        tmpdr["ID"] = ID;
        //                        tmpdr["code"] = drDecision["Code"];
        //                        tmpdr["class_code"] = drClass["Code"];
        //                        tmpdr["full_title"] = drDecision["Name"];
        //                        tmpdr["parentcode"] = IDParent;
        //                        tmpdr["ObjectCode"] = drClassType["Code"];
        //                        tmpdt.Rows.Add(tmpdr);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                tmpdtDecision = JPermissionDecisions.FindPermissionDecision_All(Convert.ToInt32(drClass["Code"].ToString()));
        //                foreach (DataRow drDecision in tmpdtDecision.Rows)
        //                {
        //                    ID++;
        //                    tmpdr = tmpdt.NewRow();
        //                    tmpdr["ID"] = ID;
        //                    tmpdr["code"] = drDecision["Code"];
        //                    tmpdr["class_code"] = drClass["Code"];
        //                    tmpdr["full_title"] = drDecision["Name"];
        //                    tmpdr["parentcode"] = IDParent;
        //                    tmpdr["ObjectCode"] = null;
        //                    tmpdt.Rows.Add(tmpdr);
        //                }
        //            }
        //        }
        //        return tmpdt;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        tmpJPermissionDecisions.Dispose();
        //        tmpJPermissionsDefineClass.Dispose();
        //        tmpdtClass.Dispose();
        //        tmpdtDecision.Dispose();
        //        tmpdt.Dispose();
        //    }
        //}
        #endregion Removed
    }

    /// <summary>
    /// کلاس ها
    /// </summary>
    public class JPermissionsDefineClass : JCore
    {
        public JPermissionDefineClass[] Items;

        public JPermissionsDefineClass()
        {
        }
        /// <summary>
        /// لیست کلاسها
        /// </summary>
        public void GetData()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesPermission.PermissionDefineClass);
                DB.Query_DataReader();
                Items = new JPermissionDefineClass[DB.RecordCount];
                int count = 0;
                while (DB.DataReader.Read())
                {
                    Items[count] = new JPermissionDefineClass();
                    JTable.SetToClassProperty(Items[count], DB.DataReader);
                    count++;
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
        }
    }
}
