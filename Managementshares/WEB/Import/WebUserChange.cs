using System;
using System.Linq;
using System.Data;
using ClassLibrary;

namespace ManagementShares
{
    public class JWebUserChange
    {
    }

    public class JWebUserChanges
    {
        public JWebUserChanges()
        {
        }

        //public DataTable GetData()
        //{
        //    return GetData(true);
        //}

        public bool Update(int pCode)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(@" Update jos_saham_persons set edited=0 Where code=" + pCode.ToString());
                    if (MyDB.Query_Execute() > 0)                    
                        return true;                    
                    else
                        return false;
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            return false;
        }

//        public DataTable GetData(bool Change)
//        {
//            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
//            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
//            {
//                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
//                try
//                {
//                    MyDB.setQuery(@"select a.id, 
//  a.code,
//  a.name,
//  a.fam as 'Fam',
//  a.father_name as 'FatherName',
//  a.sh_sh as 'ShSh',
//  a.sh_meli as 'ShMeli',
//  a.sader,
//  a.bth_day as 'BthDate',
//  a.sex,  
//case a.Sex 
//when 0 then 'مرد'
//when 1 then 'زن'
//end 'جنسیت',
//a.maried,
//case a.maried 
//when 0 then 'بلی'
//when 1 then 'خیر'
//end 'متاهل',
//  a.child,
//  a.Suport,
//case a.Suport 
//when 0 then 'بلی'
//when 1 then 'خیر'
//end 'سرپرست خانواده',
//  a.m_address as 'Maddress',
//  a.m_tell as 'mTell',
//  a.m_city as 'mCity',
//  a.post_code as 'PostCode',
//  a.o_address as 'OAddress',
//  a.o_tell as 'OTell',
//  a.o_city as 'OCity',
//  a.mobile,  
//  a.block,
//case a.Block 
//when 0 then 'بلوکه نشده'
//when 1 then 'بلوکه شده'
//end 'وضعیت شخص',
//  a.death as 'Die',
//  a.edited,
//
//  b.personnel_code as 'کد پاسداری',
//  b.percent as 'درصد جانبازی',
//  b.fax as 'َشماره فکس',
//  b.status as 'وضعیت پاسداری',
//  b.reason as 'شرایط سهامدار شدن',
//  b.janbaz as 'جانباز',
//  b.azadeh as 'آزاده',
//  b.education as 'مدرک تحصیلی',
//  b.edited as 'ویرایش'
//
//From jos_saham_persons a left join jos_saham_person_properties b ON a.code = b.code where a.edited=1");
//                    return MyDB.Query_DataTable();
//                }
//                finally
//                {
//                    MyDB.Dispose();
//                }

//            }
//            return null;
//        }
        /// <summary>
        /// فیلدهای استثناء
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetExceptField()
        {
            string query = "SELECT * FROM ShareExceptWebField ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
//        public static string Query = @"               
//Select  clsPerson.Code, clsPerson.Name, Fam, FatherName, ShSh, ShMeli, BthDate, SD3.name Sader
//	, (Select Mobile From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) Mobile
//	, (Select Name From subdefine WHERE Code = 
//        (Select City From clsPersonAddress WHERE PCode = clsPerson.Code  AND AddressType = 1))City
//	, (Select Address From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) HomeAddress
//	, (Select Tel From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) HomeTel
//	, (Select PostalCode From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) PostalCode
//	, (Select Address From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 2) WorkAddress
//	, (Select Tel From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 2) WorkTel
//	, (Select Email From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) Email
//	, SD1.name AS BankName ,SD2.name AS NewBankName  
//	, (Select City From clsPersonAddress WHERE PCode = clsPerson.Code  AND AddressType = 1) CityCode
//	, Sader SaderCode,FB.BankCode, FB.NewBankCode,FB.NewAccountNo 
//    From clsPerson
//                    LEFT JOIN finBankAccount FB ON clsPerson.Code = FB.PCode
//                    LEFT JOIN subdefine SD1 ON SD1.Code = FB.BankCode
//                    LEFT JOIN subdefine SD2 ON SD2.Code = FB.NewBankCode
//                    LEFT JOIN subdefine SD3 ON SD3.Code = Sader ";
        public static string Query = @" 
        Select  clsPerson.Code, clsPerson.Name, Fam, FatherName, ShSh, ShMeli, BthDate
	, (Select Name From subdefine WHERE Code = Sader) Sader
	, (Select Mobile From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) Mobile
	, (Select Name From subdefine WHERE Code = 
        (Select City From clsPersonAddress WHERE PCode = clsPerson.Code  AND AddressType = 1))City
	, (Select Address From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) HomeAddress
	, (Select Tel From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) HomeTel
	, (Select PostalCode From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) PostalCode
	, (Select Address From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 2) WorkAddress
	, (Select Tel From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 2) WorkTel
	, (Select Email From clsPersonAddress WHERE PCode = clsPerson.Code AND AddressType = 1) Email
	, (Select Name From subdefine WHERE Code = BankCode) AS BankName ,(Select Name From subdefine WHERE Code = NewBankCode) AS NewBankName  
	, (Select City From clsPersonAddress WHERE PCode = clsPerson.Code  AND AddressType = 1) CityCode
	, Sader SaderCode,FB.BankCode, FB.NewBankCode,FB.NewAccountNo,FB.AccountNo,clsPerson.edited_On  
    From 
    (
    select Code, Name, Fam, FatherName, ShSh, ShMeli, BthDate, Sader,edited,edited_On from clsPerson ORDER BY clsPerson.edited_On DESC  Limit 1, 30 
    )
    clsPerson
                    LEFT JOIN finBankAccount FB ON clsPerson.Code = FB.PCode";

        /// <summary>
        /// اطلاعات ویرایش شده از وب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetDataWeb(string filter)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(Query + filter); //+" limit 1, 30 "
                    return MyDB.Query_DataTable();
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return null;
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            else
                return null;
        }
        /// <summary>
        /// اطلاعات اشخاص
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static DataTable GetDataLocal(string filter)
        {
            string query = Query + filter;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
         /// <summary>
        /// اطلاعات شخص
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPerson(int PCode)
        {
            string query = "SELECT * FROM clsPerson WHERE Code = " + PCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// اطلاعات شخص از وب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonWeb(int PCode)
        {
           ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
           if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
           {
               ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
               try
               {
                   MyDB.setQuery(string.Format(" SELECT * FROM clsPerson WHERE Code = {0} AND edited=1 ", PCode));
                   return MyDB.Query_DataTable();
               }
               finally
               {
                   MyDB.Dispose();
               }
           }
           else
               return null;
        }

        /// <summary>
        /// آدرس منزل
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonAddressH(int PCode)
        {
            string query = " SELECT * FROM clsPersonAddress WHERE AddressType = 1 AND PCode = " + PCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// آدرس منزل از وب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonAddressHWeb(int PCode)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(string.Format(" SELECT * FROM  clsPersonAddress WHERE PCode = {0} AND AddressType = 1 AND   edited=1 ", PCode));
                    return MyDB.Query_DataTable();
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            else
                return null;
        }

        /// <summary>
        /// آدرس محل کار
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonAddressW(int PCode)
        {
            string query = " SELECT * FROM clsPersonAddress WHERE AddressType = 2 AND PCode = " + PCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// آدرس محل کار از وب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonAddressWWeb(int PCode)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(string.Format(" SELECT * FROM clsPersonAddress WHERE PCode = {0} AND AddressType = 2 AND   edited=1 ", PCode));
                    return MyDB.Query_DataTable();
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            else
                return null;
        }

        /// <summary>
        /// ویژگی ها
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonProperties(int PCode)
        {
            string query = " SELECT * FROM [Propperty_ClassName_ClassLibrary.JRealPerson_1] WHERE ObjectCode = " + PCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// ویژگی از وب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonPropertiesWeb(int PCode)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(string.Format("SELECT * FROM  Property WHERE ObjectCode = {0} AND edited = 1 ", PCode));
                    return MyDB.Query_DataTable();
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            else
                return null;
        }


        /// <summary>
        /// شماره حساب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetAccounts(int PCode)
        {
            string query = " SELECT * FROM finBankAccount WHERE PCode  = " + PCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// شماره حساب از وب
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetAccountsWeb(int PCode)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(string.Format("  SELECT * FROM finBankAccount WHERE PCode = {0} AND edited = 1 ", PCode));
                    return MyDB.Query_DataTable();
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            else
                return null;
        }
        public static bool UpdateLocal(string Command, int PCode)
        {
            JDataBase db = new JDataBase();
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            Cn.GetData("ManagementShares.WEB.JWebUserChange", 0);
            JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
            try
            {
                bool result = false;
                ///اشخاص
                #region Person
                db.setQuery(Command);
                db.beginTransaction("UpdateLocal");
                //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)
                if (db.Query_Execute() > 0)
                {
                    string editedCommand = string.Format(@" Update clsPerson set edited = 0 Where Code={0} ;
                                                          Update finBankAccount set edited = 0 Where PCode={0}", PCode);
                    MyDB.setQuery(@" " + PCode);
                    MyDB.Query_Execute();
                    ClassLibrary.JSMSSend SMSSend = new JSMSSend();

                    JPersonAddress Pers = new JPersonAddress(PCode,JAddressTypes.Home);
                    if (Pers.Mobile.Length == 11)
                    {
                        SMSSend.Mobile = Pers.Mobile;
                        SMSSend.PersonCode = PCode;
                        SMSSend.RegDate = JDateTime.Now();
                        SMSSend.Text = "اطلاعات شما در بانک سهام شرکت سپاد خراسان بروز شد. مدیریت سهام";
                        SMSSend.Insert();
                    }

                    result = true;
                }
                #endregion Person
                db.Commit();
                return result;
            }

            catch (Exception ex)
            {
                db.Rollback("UpdateLocal");
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
                MyDB.Dispose();
            }
        }
        public static string CreateUpdateCommand(string fieldName, string fieldValue, int PCode)
        {
            string command = "";

            string personFields = @" Name, Fam, FatherName, ShSh, ShMeli, BthDate";
            if(personFields.Contains(fieldName ))
                command = string.Format(" UPDATE clsPerson SET [{0}] = '{1}' WHERE Code = {2}", fieldName, fieldValue, PCode);
            
            if (fieldName == "Mobile" || fieldName == "PostalCode" || fieldName == "Email")
                command = string.Format(" UPDATE clsPersonAddress SET [{0}] = '{1}' WHERE PCode = {2} AND AddressType = 1 ", fieldName, fieldValue, PCode);

            if (fieldName == "HomeAddress")
                command = string.Format(" UPDATE clsPersonAddress SET Address = '{0}' WHERE PCode = {1} AND AddressType = 1 ",  fieldValue, PCode);

            if (fieldName == "HomeTel")
                command = string.Format(" UPDATE clsPersonAddress SET Tel = '{0}' WHERE PCode = {1} AND AddressType = 1 ",  fieldValue, PCode);

            if (fieldName == "WorkAddress")
                command = string.Format(" UPDATE clsPersonAddress SET Address = '{0}' WHERE PCode = {1} AND AddressType = 2 ",  fieldValue, PCode);

            if (fieldName == "WorkTel")
                command = string.Format(" UPDATE clsPersonAddress SET Tel = '{0}' WHERE PCode = {1} AND AddressType = 2 ", fieldValue, PCode);

            if (fieldName == "CityCode")
                command = string.Format(" UPDATE clsPersonAddress SET City = '{0}' WHERE PCode = {1} AND AddressType = 1 ", fieldValue, PCode);

            if (fieldName == "SaderCode")
                command = string.Format(" UPDATE clsPerson SET Sader = '{0}' WHERE Code = {1} ", fieldValue, PCode);

            if (fieldName == "BankCode" || fieldName == "NewBankCode")
                command = string.Format(" UPDATE finBankAccount SET {0} = '{1}' WHERE PCode = {2} ", fieldName, fieldValue, PCode);

            return command;
        }
        /// <summary>
        /// بروز رسانی اطلاعات
        /// </summary>
        /// <param name="PersonTable"></param>
        /// <param name="PropertiesTable"></param>
        /// <param name="AccountTable"></param>
        /// <param name="AddressTable"></param>
        /// <returns></returns>
        public static bool UpdateLocal(DataTable PersonTable, DataTable AddressHTable, DataTable AddressWTable, DataTable PropertiesTable, DataTable AccountTable, string[] ChangeTable)
        {
            //     if (JPermission.CheckPermission("ManagementShares.JWebUserChanges.UpdateLocal"))
           JDataBase db = new JDataBase();
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            Cn.GetData("ManagementShares.WEB.JWebUserChange", 0);
            JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
            try
            {
                bool result = false;
                bool excecutePerson= false;
                ///اشخاص
                #region Person
                if (PersonTable != null && PersonTable.Rows.Count > 0)
                {
                    string updateQuery = " UPDATE clsPerson SET ";
                    int i = 0;
                    foreach (DataColumn col in PersonTable.Columns)
                    {
                        i++;
                        string fieldName = col.ColumnName;
                        //if (fieldName != "Code" && fieldName != "edited" && fieldName != "PCode" )
                        if(ChangeTable.Contains(fieldName))
                        {
                            excecutePerson = true;
                            string fieldValue = PersonTable.Rows[0][col.ColumnName].ToString();
                            updateQuery += string.Format("[{0}] = '{1}'", fieldName, fieldValue);
                            if (i != PersonTable.Columns.Count)
                                updateQuery += ",";
                        }
                    }
                    updateQuery += " WHERE Code = " + PersonTable.Rows[0]["Code"].ToString();
                    db.setQuery(updateQuery);
                    //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)
                    if (excecutePerson && db.Query_Execute() > 0)
                    {
                        excecutePerson = false;
                        MyDB.setQuery(@" Update clsPerson set edited = 0 Where Code=" + PersonTable.Rows[0]["Code"].ToString());
                        MyDB.Query_Execute();
                    }
                }
                #endregion Person
                ///آدرس منزل
                #region Home Addreess
                bool excecuteHomeAddress= false;
                if (AddressHTable != null && AddressHTable.Rows.Count > 0)
                {
                    string updateQuery = " UPDATE clsPersonAddress SET ";
                    int i = 0;
                    foreach (DataColumn col in AddressHTable.Columns)
                    {
                        i++;
                        string fieldName = col.ColumnName;
                       // if (fieldName != "Code" && fieldName != "edited" && fieldName != "PCode")
                        if (ChangeTable.Contains(fieldName))
                        {
                            excecuteHomeAddress = true;
                            string fieldValue = AddressHTable.Rows[0][col.ColumnName].ToString();
                            updateQuery += string.Format("[{0}] = '{1}'", fieldName, fieldValue);
                            updateQuery += ",";
                        }
                    }
                    updateQuery = updateQuery.Substring(0, updateQuery.Length - 1);
                    updateQuery += " WHERE PCode = " + AddressHTable.Rows[0]["PCode"].ToString() +" AND AddressType = 1 ";
                    db.setQuery(updateQuery);
                    //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)
                    if (excecuteHomeAddress && db.Query_Execute() > 0)
                    {
                        excecuteHomeAddress = false;
                        MyDB.setQuery(@" Update clsPersonAddress set edited = 0 Where  PCode=" + AddressHTable.Rows[0]["PCode"].ToString() + " AND Type = 1");
                        MyDB.Query_Execute();
                    }
                }
                #endregion Home Addreess
                ///آدرس محل کار
                #region Work Addreess
                bool excecuteWorkAddress=false ;
                if (AddressWTable != null && AddressWTable.Rows.Count > 0)
                {
                    string updateQuery = " UPDATE clsPersonAddress SET ";
                    int i = 0;
                    foreach (DataColumn col in AddressWTable.Columns)
                    {
                        i++;
                        string fieldName = col.ColumnName;
                      //  if (fieldName != "Code" && fieldName != "edited")
                        if (ChangeTable.Contains(fieldName))
                        {
                            excecuteWorkAddress = true;
                            string fieldValue = AddressWTable.Rows[0][col.ColumnName].ToString();
                            updateQuery += string.Format("[{0}] = '{1}'", fieldName, fieldValue);
                            updateQuery += ",";
                        }
                    }
                    updateQuery = updateQuery.Substring(0, updateQuery.Length - 1);
                    updateQuery += " WHERE PCode = " + AddressWTable.Rows[0]["PCode"].ToString() + " AND AddressType = 2 ";
                    db.setQuery(updateQuery);
                    //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)
                    if (excecuteWorkAddress && db.Query_Execute() > 0)
                    {
                        excecuteWorkAddress = false;
                        MyDB.setQuery(@" Update clsPersonAddress set edited = 0 Where  PCode=" + AddressWTable.Rows[0]["PCode"].ToString() + " AND Type = 2");
                        MyDB.Query_Execute();
                    }
                }
                #endregion Work Addreess

                /// ویژگی ها 
                #region Propeties
                bool excecuteProperty = false;
                if (PropertiesTable != null && PropertiesTable.Rows.Count > 0)
                {
                    string updateQuery = " UPDATE  [Propperty_ClassName_ClassLibrary.JRealPerson_1] SET ";
                    int i = 0;
                    foreach (DataColumn col in PropertiesTable.Columns)
                    {
                        string fieldName = col.ColumnName;
                        //  if (fieldName != "Code" && fieldName != "edited" && fieldName != "ObjectCode")
                        if (ChangeTable.Contains(fieldName))
                        {
                            excecuteProperty = true;
                            string fieldValue = PropertiesTable.Rows[0][col.ColumnName].ToString();
                            updateQuery += string.Format("[{0}] = '{1}'", fieldName, fieldValue);
                                updateQuery += ",";
                        }
                    }
                    updateQuery = updateQuery.Substring(0, updateQuery.Length - 1);
                    updateQuery += " WHERE ObjectCode = " + PropertiesTable.Rows[0]["ObjectCode"].ToString();
                    db.setQuery(updateQuery);
                    //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)
                    if (excecuteProperty && db.Query_Execute() > 0)
                    {
                        excecuteProperty = false;
                        MyDB.setQuery(@" Update [Propperty_ClassName_ClassLibrary.JRealPerson_1]  set edited = 0 Where  ObjectCode =" + PropertiesTable.Rows[0]["ObjectCode"].ToString());
                        MyDB.Query_Execute();
                    }
                }
                #endregion Propeties
                /// شماره حساب 
                #region Accounts
                bool excecuteAccount = false;
                if (AccountTable != null && AccountTable.Rows.Count > 0)
                {
                    string updateQuery = " UPDATE finBankAccount SET ";
                    int i = 0;
                    foreach (DataColumn col in AccountTable.Columns)
                    {
                        i++;
                        string fieldName = col.ColumnName;
                        //  if (fieldName != "Code" && fieldName != "edited")
                        if (ChangeTable.Contains(fieldName))
                        {
                            excecuteAccount = true;
                            string fieldValue = AccountTable.Rows[0][col.ColumnName].ToString();
                            updateQuery += string.Format("[{0}] = '{1}'", fieldName, fieldValue);
                            updateQuery += ",";
                        }
                    }
                    updateQuery = updateQuery.Substring(0, updateQuery.Length - 1);
                    updateQuery += " WHERE PCode = " + AccountTable.Rows[0]["PCode"].ToString();
                    db.setQuery(updateQuery);
                    //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)
                    if (excecuteAccount && db.Query_Execute() > 0)
                    {
                        excecuteAccount = false;
                        MyDB.setQuery(@" Update finBankAccount set edited = 0 Where  PCode=" + AccountTable.Rows[0]["PCode"].ToString());
                        MyDB.Query_Execute();
                    }


                    if (excecuteAccount && db.Query_Execute() > 0)
                    {
                        excecuteAccount = false;
                        MyDB.setQuery(@" Update finBankAccount set edited = 0 Where  PCode =" + AccountTable.Rows[0]["PCode"].ToString());
                        MyDB.Query_Execute();
                    }
                }

                //                if (AccountTable != null && AccountTable.Rows.Count > 0)
                //                {
                //                    int pCode =Convert.ToInt32(AccountTable.Rows[0]["PCode"]);
                //                    string updateFields = " ";
                //                    string insertFields = " ";
                //                    int i = 0;
                //                    foreach (DataColumn col in AccountTable.Columns)
                //                    {
                //                        i++;
                //                        excecuteAccount = true;
                //                        string fieldName = col.ColumnName;
                //                       // if (fieldName != "edited" )
                //                        if (ChangeTable.Contains(fieldName))
                //                        {
                //                            string fieldValue = AccountTable.Rows[0][col.ColumnName].ToString();
                //                            updateFields += string.Format("[{0}] = '{1}'", fieldName, fieldValue);
                //                            insertFields += string.Format("'{0}'", fieldValue);
                //                            updateFields += ",";
                //                            insertFields += ",";
                //                        }
                //                    }
                //                    updateFields = updateFields.Substring(0, updateFields.Length - 1);
                //                    insertFields = insertFields.Substring(0, insertFields.Length - 1);
                //                    /// در صورتی که شماره حساب قبلا وارد نشده است، یک رکورد جدید درج میشود
                //                    string updateQuery = string.Format(@"IF EXISTS (SELECT * FROM finBankAccount WHERE PCode={0})
                //                            UPDATE finBankAccount SET {1} WHERE PCode={0}
                //                            ELSE
                //                            INSERT INTO finBankAccount VALUES ({2}) ", pCode, updateFields , insertFields);
                //                    db.setQuery(updateQuery);
                //// در صورتی که بروزرسانی انجام شود، وب سایت بروز میشود (edited = 0)

                #endregion Accounts
                if (!excecutePerson && !excecuteAccount && !excecuteHomeAddress && !excecuteProperty && !excecuteWorkAddress )
                {
                    MyDB.setQuery(@" Update clsPerson set edited = 0 Where Code=" + PersonTable.Rows[0]["Code"].ToString());
                    MyDB.Query_Execute();
                    result = true;
                }
                return result;
            }

            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
                MyDB.Dispose();
            }
        }
    }
}
