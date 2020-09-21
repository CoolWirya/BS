using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    /// <summary>
    /// کلاس سهامدارن نرم افزار سهام
    /// </summary>
    public class JShareHolder : JPerson
    {      
        /// <summary>
        /// حداکثر طول فیلد کد سهامداری
        /// </summary>
        public static int MaxLength = 10000000;
        private int _ManagementsharesCode;
        /// <summary>
        /// کد سهامداری
        /// </summary>
        public int ManagementsharesCode
        {
            set
            {
                _ManagementsharesCode = value;
            }
            get
            {
                if (_ManagementsharesCode == 0 && Code != 0)
                {
                    getWithCode(Code);
                }
                return _ManagementsharesCode;
            }
        }
        /// <summary>
        /// سازنده کلاس
        /// </summary>
        public JShareHolder()
        {
        }

        public bool Find(int pCode)
        {
            return this.find(pCode);
        }

        private void getWithExternalCode(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT Code FROM ExternalTables WHERE ExternalCode=" + pCode.ToString() + " AND ExternalTableName=" + JDataBase.Quote(JGlobal.MainFrame.GetConfig().PersonSahamTableName));
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    _ManagementsharesCode = int.Parse(DB.DataReader["Code"].ToString());
                    this.getData(int.Parse(DB.DataReader["Code"].ToString()));
                }
            }
            finally
            {
                DB.Dispose();
            }
        }      

        private void getWithCode(int pCode)
        {
            getData(pCode);
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT ExternalCode FROM ExternalTables WHERE Code=" + pCode.ToString() + " AND ExternalTableName=" + JDataBase.Quote(JGlobal.MainFrame.GetConfig().PersonSahamTableName));
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    _ManagementsharesCode = int.Parse(DB.DataReader["ExternalCode"].ToString());
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int getData(int pCode, bool pIsExternalCode)
        {
            if (pIsExternalCode)
            {
                getWithExternalCode(pCode);
            }
            else
            {
                getWithCode(pCode);
            }
            return _ManagementsharesCode;
        }
    }

    public class JShareHolders : JSystem
    {
       // JShareHolder[] Items;

        public JShareHolders()
        {
           // getData();
        }

        //private void getData()
        //{
        //    int Count = 0;
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        DB.setQuery(@"SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + " * FROM Person WHERE Code IN (SELECT Code FROM ExternalTables WHERE ExternalTableName=" +
        //            JDataBase.Quote(JGlobal.MainFrame.GetConfig().PersonSahamTableName) + ")");
        //        DB.Query_DataReader();
        //        if (DB.DataReader.HasRows)
        //        {
        //            Items = new JShareHolder[DB.RecordCount];
        //            while (DB.DataReader.Read())
        //            {
        //                Items[Count] = new JShareHolder();
        //                JTable.SetToClassProperty(Items[Count], DB.DataReader);
        //                Count++;
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}
        private void GetDataFromSahamDB()
        {
            GetDataFromSahamDB(0);
        }

        private void GetDataFromSahamDB(int LastCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
            try
            {
                //            JDataBase DB = new JDataBase(JManagementshares.DBConfig());
                DB.setQuery(@"SELECT Code ManagementsharesCode,Name FirstName,Fam LastName,FatherName FatherName,
               ShSh ShSh,ShMeli ShMelli,Sader BirthplaceCode,null BirthDate FROM " + JGlobal.MainFrame.GetConfig().PersonSahamTableName + " WHERE Code>" + LastCode);
                DB.Query_DataReader();
                if (DB.DataReader.HasRows)
                {
                    JPerson Person = new JPerson();
                    while (DB.DataReader.Read())
                    {
                        JTable.SetToClassProperty(Person, DB.DataReader);
                        int pCode = Person.insert();

                        if (pCode > 0)
                        {
                            JExternalTable OT = new JExternalTable();
                            OT.Code = Person.Code;
                            OT.ExternalCode = int.Parse(DB.DataReader["ManagementsharesCode"].ToString());
                            OT.ExternalTableName = JGlobal.MainFrame.GetConfig().PersonSahamTableName;
                            OT.Insert();
                        }
                    }
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void RefreshAll()
        {
            GetDataFromSahamDB();
        }

        public void RefreshInsert()
        {
            int MAX = 0;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT ISNULL(Max(ExternalCode),0)AS OC FROM ExternalTables WHERE ExternalTableName=" + JDataBase.Quote(JGlobal.MainFrame.GetConfig().PersonSahamTableName));
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                    MAX = int.Parse(DB.DataReader["OC"].ToString());
                /// دریافت آخرین اطلاعات اشخاص از سهام و درج در جدول اشخاص پروژه
                //GetDataFromSahamDB(MAX);
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// جستجو بر اساس کد سهامداری - نام و نام خانوادگی - شماره برگه سهم - شماره سهم
        /// </summary>
        /// <param name="ShareHolderCode">کد سهامداری در صورتی که  0 باشد همه سهامداران</param>
        /// <param name="NameFamily">نام و نام خانوادگی </param>
        /// <param name="SheetNo">شماره برگه در صورتی که 0 باشد همه برگه ها </param>
        /// <param name="ShareNo">شماره سهم در صورتی که 0 باشد همه سهمها</param>
        /// <returns></returns>
//        public static System.Data.DataTable SearchSheets(int pShareHolderCode, int pSheetNo, int pShareNo)
//        {
//            //JDataBase DB = JGlobal.MainFrame.GetDBO();
//            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
//            try
//            {
//                string Query = @" SELECT [PCode] ShareHolder, NameFam 	,[FatherName] ,[ShSh]
//                , SheetNo , Az, Ela , SumSahm FROM (" + JSQLViews.PersonSheet + " ) AS PersonSheet WHERE 1=1 ";
//                if (pShareHolderCode != 0)
//                {
//                    Query = Query + " AND PCode = " + pShareHolderCode.ToString();
//                }

//                if (pSheetNo != 0)
//                {
//                    Query = Query + " AND SheetNo = " + pSheetNo.ToString();
//                }
//                if (pShareNo != 0)
//                {
//                    Query = Query + " and Az <=" + pShareNo.ToString() + " AND Ela >=" + pShareNo.ToString();
//                }
//                DB.setQuery(Query);
//                return DB.Query_DataTable();
//            }
//            catch (Exception ex)
//            {
//                JSystem.Except.AddException(ex);
//                return null;
//            }
//            finally
//            {
//                DB.Dispose();
//            }
//        }

        #region Share Person
        ///  انتقال شهرها از جدول شهرها در دیتایبس سهام قدیم
        public bool ImportCityFromShareManagement()
        {
            JDataBase Db = JGlobal.MainFrame.GetSharesDB();
            Db.setQuery(" SELECT * FROM " + JTableNamesShares.ShareCities);//+ " WHERE Code>102");
            if (Db.Query_DataReader())
            {
                JDataBase myDB = new JDataBase();
                try
                {
                    while (Db.DataReader.Read())
                    {
                        JSubBaseDefine define = new JSubBaseDefine(JBaseDefine.CityCode);
                        define.Code = Convert.ToInt32(Db.DataReader[JSharesCitiesEnum.Code.ToString()]);
                        define.Name = Db.DataReader[JSharesCitiesEnum.City.ToString()].ToString();
                        define.Insert(define.Code, myDB);
                    }
                    return true;
                }
                finally
                {
                    myDB.Dispose();
                }
            }
            return false;
        }
        /// <summary>
        ///  انتقال اشخاص از جدول اشخاص در دیتایبس سهام قدیم
        /// </summary>
        /// <returns></returns>
        public bool ImportPersonFromShareManagement()
        {
            JDataBase Db = JGlobal.MainFrame.GetSharesDB();
            Db.setQuery(" SELECT * FROM " + JTableNamesShares.OtherPerson);
            if (Db.Query_DataReader())
            {
                while (Db.DataReader.Read())
                {
                    JPerson person = new JPerson();

                    person.Code = (int)Db.DataReader[JOtherPersonEnum.Code.ToString()];
                    person.Name = Db.DataReader[JOtherPersonEnum.Name.ToString()].ToString();
                    person.Fam = Db.DataReader[JOtherPersonEnum.Fam.ToString()].ToString();
                    person.FatherName = Db.DataReader[JOtherPersonEnum.FatherName.ToString()].ToString();
                    person.Sader = (int)Db.DataReader[JOtherPersonEnum.Sader.ToString()];
                    person.Gender = (bool)Db.DataReader[JOtherPersonEnum.Sex.ToString()];
                    person.ShMeli = Db.DataReader[JOtherPersonEnum.ShMeli.ToString()].ToString();
                    person.ShSh = Db.DataReader[JOtherPersonEnum.ShSh.ToString()].ToString();

                    //person.Block = (bool)Db.DataReader[JOtherPersonEnum.Block.ToString()];
                    person.Died = (bool)Db.DataReader[JOtherPersonEnum.Die.ToString()];
                    person.BthDate = JDateTime.GregorianDate(Db.DataReader[JOtherPersonEnum.BthDate.ToString()].ToString());

                    person.HomeAddress.City = (int)Db.DataReader[JOtherPersonEnum.MCity.ToString()];
                    person.HomeAddress.Address = Db.DataReader[JOtherPersonEnum.MAddress.ToString()].ToString();
                    person.HomeAddress.Tel = Db.DataReader[JOtherPersonEnum.MTell.ToString()].ToString();
                    person.HomeAddress.Mobile = Db.DataReader[JOtherPersonEnum.Mobile.ToString()].ToString();
                    person.HomeAddress.PostalCode = Db.DataReader[JOtherPersonEnum.PostCode.ToString()].ToString();

                    person.WorkAddress.City = (int)Db.DataReader[JOtherPersonEnum.OCity.ToString()];
                    person.WorkAddress.Address = Db.DataReader[JOtherPersonEnum.OAddress.ToString()].ToString();
                    person.WorkAddress.Tel = Db.DataReader[JOtherPersonEnum.OTell.ToString()].ToString();
                    person.insert();
                }
            }
            return false;
        }

        #endregion
        private static DataTable SearchResult;
        /// <summary>
        /// جستجو در جدول اشخاص سهام 
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pName"></param>
        /// <param name="pFam"></param>
        /// <returns></returns>
        public static DataTable SearchOtherPerson(int pCode, string pName, string pFam, int pSheetNo)
        {
            JDataBase DB = new JDataBase();// JGlobal.MainFrame.GetSharesDB();
            try
            {
                string Query = @" SELECT  ~(Status) Active, Code SheetNo , Az, Ela, Sharecount, [PCode] ,  
 Replace(Replace( Name , N'ي',N'ی'),N'ك',N'ک')  Name ,  Replace(Replace(Fam, N'ي',N'ی'),N'ك',N'ک') 
 Fam	,[FatherName]  FROM (" + (JSheet.Query) + ")AS PersonSheet ORDER BY Az"; //(" + JSQLViews.PersonSheet + " ) AS PersonSheet

               // if (SearchResult == null)
                {
                    DB.setQuery(Query, false);
                    SearchResult = DB.Query_DataTable();
                }

                string Where = " 1=1 ";
                if (pCode != 0)
                {
                    Where = Where + " AND PCode = " + pCode.ToString();
                }

                if (pName.Trim() != "")
                {
                    Where = Where + " AND Name LIKE " + JDataBase.Quote('%' + pName + '%', false);
                }
                if (pFam.Trim() != "")
                {
                    Where = Where + " AND Fam LIKE " + JDataBase.Quote('%' + pFam + '%', false);
                }
                if (pSheetNo != 0)
                {
                    Where = Where + " AND SheetNo = " + pSheetNo.ToString();
                }
                DataView view = SearchResult. DefaultView;
                view.RowFilter =JDataBase._ImproveSQL(Where);
                return view.Table;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }

        }

    }
}
