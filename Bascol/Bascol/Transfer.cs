using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using System.Reflection;
using System.IO;

namespace Bascol
{
    public class JTransferData : JBascol
    {
        public decimal _Tax, _Duty;
        private static System.IO.StreamReader Filereader;
        JConfig _Config;

        public bool CreateConnectionServer()
        {
            _Config = new JConfig();
            if (System.IO.File.Exists(JConfig.appPath + "\\" + "EncMain"))
            {
                Filereader = File.OpenText(JConfig.appPath + "\\" + "EncMain");
                System.IO.StreamReader reader = Filereader;
                string configLine = null;
                // Decryption of the Config File 
                while ((configLine = JEnryption.DecryptStr(reader.ReadLine())) != null)
                {
                    string config = configLine.Split('=')[0].Trim();
                    string value = configLine.Split('=')[1].Trim();
                    if (config == "Server")
                        _Config.Server = value;
                    if (config == "Database")
                        _Config.Database = value;
                    if (config == "Username")
                        _Config.Username = value;
                    if (config == "Password")
                        _Config.Password = value;
                }

                //if (!(ClassLibrary.JPing.Ping("192.168.3.38")))
                //{
                //    JMessages.Error(" ارتباط با بانک اصلی برقرار نمی شود ", "");
                //    return false;
                //}

                reader.Close();
                return true;
            }
            else
                return false;
        }

        public JDataBase CreateConMainServer(bool msg)
        {
            if (!(CreateConnectionServer()))
            {
                if (msg)
                    JMessages.Error(" ارتباط با بانک اصلی برقرار نمی شود ", "");
                return null;
            }
            if (!(ClassLibrary.JPing.Ping("192.168.3.1")))
            {
                if(msg)
                    JMessages.Error(" ارتباط با بانک اصلی برقرار نمی شود ", "");
                return null;
            }
            ClassLibrary.JDataBase MyDB = new JDataBase(_Config);
            return MyDB;
        }

        public bool Transfer()
        {
            if (!(CreateConnectionServer()))
            {
                JMessages.Error(" ارتباط با بانک اصلی برقرار نمی شود ", "");
                return false;
            }

            if (!(ClassLibrary.JPing.Ping("192.168.3.1")))
            {
                JMessages.Error(" ارتباط با بانک اصلی برقرار نمی شود ", "");
                return false;
            }

            ClassLibrary.JDataBase MyDB = new JDataBase(_Config);
            ClassLibrary.JDataBase CurrentDB = new JDataBase();
            try
            {
                if (CurrentDB.DataBaseName == MyDB.DataBaseName)//"ERP_Sepad")
                {
                    JMessages.Error(" بانک جاری با بانک اصلی یکی است امکان انتقال اطلاعات نیست ", "");
                    return false;
                }

                string StrPlok = "";
                //int Count = 0;
                //ماشین ها پلاک
                CurrentDB.setQuery(@"select distinct PlokNo,TruckCode from BascolWeights ");
                foreach (DataRow dr4 in CurrentDB.Query_DataTable().Rows) //+ @"' And TruckCode = " + dr4["TruckCode"]
                {
                    StrPlok = @"
declare  @Count int
select @Count=(Select COUNT(*) From BascolPlakTruck  where plokno = N'" + dr4["PlokNo"].ToString().Trim() + @"')
select @Count
if (@Count = 0)
INSERT INTO BascolPlakTruck Values('" + dr4["PlokNo"].ToString().Trim() + "'," + dr4["TruckCode"] + @")";
                    //Count++;
                    //if (Count == 10)
                    //{
                    //    //MyDB.CommandTimeout = 5;
                    //    MyDB.setQuery(StrPlok);
                    //    MyDB.Query_Execute();
                    //    StrPlok = "";
                    //    Count = 0;
                    //}
                    MyDB.CommandTimeout = 2;
                    MyDB.setQuery(StrPlok);
                    MyDB.Query_Execute();
                }


                MyDB.beginTransaction("MainDB");
                CurrentDB.beginTransaction("CurrentDB");

                DataTable _DtAccess = JWeights.GetData();
                JWeight tmpWeight = new JWeight();
                foreach (DataRow dr in _DtAccess.Rows)
                {
                    tmpWeight.TruckCode = Convert.ToInt32(dr["TruckCode"]);
                    tmpWeight.UserPostCode = Convert.ToInt32(dr["UserPostCode"]);
                    tmpWeight.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                    tmpWeight.pay = Convert.ToInt32(dr["Pay"]);
                    tmpWeight.pay_h = Convert.ToInt32(dr["pay_h"]);
                    tmpWeight.BascoolCode = Convert.ToInt32(dr["BascoolCode"]);
                    tmpWeight.WDate = Convert.ToDateTime(dr["WDate"]);
                    tmpWeight.WTime = dr["WTime"].ToString();
                    tmpWeight.PlokNo = dr["PlokNo"].ToString();
                    tmpWeight.Weights = Convert.ToInt32(dr["Weights"]);
                    tmpWeight.Duty = Convert.ToDecimal(dr["Duty"]);//(tmpWeight.pay / (100 + _Duty + _Tax)) * _Tax;
                    tmpWeight.Tax = Convert.ToDecimal(dr["Tax"]);//(tmpWeight.pay / (100 + _Duty + _Tax)) * _Duty;
                    tmpWeight.hamrahno = Convert.ToInt32(dr["hamrahNo"]);
                    tmpWeight.ProductCode = Convert.ToInt32(dr["ProductCode"]);
                    tmpWeight.BascoolID = Convert.ToInt32(dr["BascoolID"]);
                    tmpWeight.FullW = Convert.ToInt32(dr["FullW"]);
                    tmpWeight.PrintNo = Convert.ToInt32(dr["PrintNo"]);
                    //tmpWeight.dele = Convert.ToBoolean(dr["dele"]);
                    //tmpWeight.verify = Convert.ToBoolean(dr["verify"]);

                    if (tmpWeight.Insert(MyDB) > 0)
                    {
                        if (!(tmpWeight.DeleteTransfer(Convert.ToInt32(dr["Code"]), CurrentDB)))
                        {
                            MyDB.Rollback("MainDB");
                            CurrentDB.Rollback("CurrentDB");
                            JMessages.Error(" خطا در همگام سازی ", "");
                            return false;
                        }
                    }
                    else
                    {
                        MyDB.Rollback("MainDB");
                        CurrentDB.Rollback("CurrentDB");
                        JMessages.Error(" خطا در همگام سازی ", "");
                        return false;
                    }
                }


                _DtAccess = JEmptyWeight.GetDataTable(-1);
                JEmptyWeight tmpEmptyWeight = new JEmptyWeight();
                foreach (DataRow dr in _DtAccess.Rows)
                {
                    tmpEmptyWeight.Code = 0;
                    tmpEmptyWeight.BascoolNo = Convert.ToInt32(dr["BascoolNo"]);
                    tmpEmptyWeight.WeightID = Convert.ToInt32(dr["WeightID"]);
                    tmpEmptyWeight.EmptyBascoolNo = Convert.ToInt32(dr["EmptyBascoolNo"]);
                    tmpEmptyWeight.WeightSerial = Convert.ToInt32(dr["WeightSerial"]);
                    tmpEmptyWeight.DateWeight = Convert.ToDateTime(dr["DateWeight"]);
                    tmpEmptyWeight.EmptyWeight = Convert.ToInt32(dr["EmptyWeight"]);
                    tmpEmptyWeight.EmptyID = Convert.ToInt32(dr["EmptyID"]);
                    if (tmpEmptyWeight.Insert(MyDB) > 0)
                    {
                        tmpEmptyWeight.Code = Convert.ToInt32(dr["Code"]);
                        if (!(tmpEmptyWeight.Delete(CurrentDB)))
                        {
                            MyDB.Rollback("MainDB");
                            CurrentDB.Rollback("CurrentDB");
                            JMessages.Error(" خطا در همگام سازی ", "");
                            return false;
                        }
                    }
                    else
                    {
                        MyDB.Rollback("MainDB");
                        CurrentDB.Rollback("CurrentDB");
                        JMessages.Error(" خطا در همگام سازی ", "");
                        return false;
                    }
                }

                if (MyDB.Commit())
                    if (CurrentDB.Commit())
                    {
                    }
                    else
                    {
                        MyDB.Rollback("MainDB");
                        CurrentDB.Rollback("CurrentDB");
                        JMessages.Error(" خطا در همگام سازی ", "");
                        return false;
                    }
                else
                {
                    MyDB.Rollback("MainDB");
                    CurrentDB.Rollback("CurrentDB");
                    JMessages.Error(" خطا در همگام سازی ", "");
                    return false;
                }

                //  باسکول
                CurrentDB.setQuery(@" delete From Bascols ");
                CurrentDB.Query_Execute();
                //if (CurrentDB.Query_Execute() > 0)
                {
                    foreach (DataRow dr1 in JReport.GetBascols(0, MyDB).Rows)
                    {
                        //MyDB.setQuery(@" Insert Into Bascols Values(" + dr1["Code"] + ",'" + dr1["Location"] + "'," + dr1["Capacity"] + ",'" + dr1["BDesc"] + "'," + dr1["Active"]+ ")");
                        CurrentDB.setQuery(@" Insert Into Bascols Values(" + dr1["Code"] + ",NULL," + dr1["Capacity"] + ",'" + dr1["BDesc"] + "',NULL)");
                        if (CurrentDB.Query_Execute() <= 0)
                            return false;
                    }
                }

                //  محصول
                CurrentDB.setQuery(@" delete From Subdefine Where bCode=901");
                CurrentDB.Query_Execute();
                //if (CurrentDB.Query_Execute() > 0)
                {
                    foreach (DataRow dr3 in JProductss.GetDataTable(MyDB).Rows)
                    {
                        CurrentDB.setQuery(@" Insert Into Subdefine Values(" + dr3["Code"] + ",901,'" + dr3["Name"] + "',0,NULL)");
                        if (CurrentDB.Query_Execute() <= 0)
                            return false;
                    }
                }

                //  ماشینها
                CurrentDB.setQuery(@" delete From BascolTruck ");
                CurrentDB.Query_Execute();
                //if (CurrentDB.Query_Execute() > 0)
                {
                    foreach (DataRow dr2 in JTruck.GetDataTransfer(MyDB).Rows)
                    {
                        CurrentDB.setQuery(@"INSERT INTO BascolTruck Values(" + dr2["Code"] + ",'" + dr2["Name"] + "'," + dr2["Price"] + ",'" + Convert.ToDateTime(dr2["StartDate"]).ToShortDateString() + "' ,'" + Convert.ToDateTime(dr2["EndDate"]).ToShortDateString() + "','" + dr2["Shortcut"].ToString().Trim() + "')");
                        if (CurrentDB.Query_Execute() <= 0)
                            return false;
                    }
                }

                //ماشین ها پلاک
                CurrentDB.setQuery(@" Select Max(Code) From BascolPlakTruck ");
                int MaxCode = Convert.ToInt32(CurrentDB.Query_ExecutSacler());
                //if (CurrentDB.Query_Execute() > 0)
                //{
                MyDB.setQuery(@"select Code,PlokNo,TruckCode from BascolPlakTruck Where Code > " + MaxCode);
                foreach (DataRow dr4 in MyDB.Query_DataTable().Rows)
                {
                    CurrentDB.setQuery("INSERT INTO BascolPlakTruck Values( " + dr4["Code"] + ",'" + dr4["PlokNo"] + "'," + dr4["TruckCode"] + ")");
                    if (CurrentDB.Query_Execute() <= 0)
                        return false;
                }
                CurrentDB.setQuery(@"delete from BascolPlakTruck Where Code in
(select B.Code from BascolPlakTruck A inner join BascolPlakTruck B on A.PlokNo=B.PlokNo And A.Code > B.Code)");
                CurrentDB.Query_Execute();
                //return false;
                //}

                //  لیست سیاه
                //CurrentDB.setQuery(@" delete From BascoolBlackList ");
                //if (CurrentDB.Query_Execute() > 0)
                //{
                //    MyDB.setQuery("select * from BascoolBlackList ");
                //    foreach (DataRow dr5 in MyDB.Query_DataTable().Rows)
                //    {
                //        CurrentDB.setQuery(@" Insert Into BascoolBlackList Values(" + dr5["Code"] + ")");
                //        if (CurrentDB.Query_Execute() <= 0)
                //            return false;
                //    }
                //}

                //  
                //CurrentDB.setQuery(@" delete From BascolTaxFormula ");
                //if (CurrentDB.Query_Execute() > 0)
                //{
                //    MyDB.setQuery(@"Select top 1 Duty From BascolTaxFormula ");
                //    _Duty = Convert.ToDecimal(MyDB.Query_ExecutSacler());
                //    MyDB.setQuery(@"Select top 1 Tax From BascolTaxFormula ");
                //    _Tax = Convert.ToDecimal(MyDB.Query_ExecutSacler());
                //    CurrentDB.setQuery(@"INSERT INTO BascolTaxFormula values(" + _Duty + "," + _Tax + ")");
                //    if (CurrentDB.Query_Execute() <= 0)
                //        return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                MyDB.Rollback("MainDB");
                CurrentDB.Rollback("CurrentDB");
                return false;
            }
            finally
            {
                MyDB.Dispose();
                CurrentDB.Dispose();
            }
        }

        public bool TransferAccess()
        {
            try
            {
                if (CreateConnectionServer())
                {
                    JMessages.Error(" ارتباط با بانک اصلی برقرار نمی شود ","");
                    return false;
                }
                ClassLibrary.JDataBase MyDB = new JDataBase(_Config);            
                //ClassLibrary.JOLeDbDataBase MyDB = new ClassLibrary.JOLeDbDataBase();
                JWeights tmpWeights = new JWeights();
                //MyDB.setQuery(@"Select * From Weight");
                DataTable _DtAccess = tmpWeights.GetDataTable();
                DataTable _DtSQL;
                foreach (DataRow dr in _DtAccess.Rows)
                {
                    JWeight tmpWeight = new JWeight();
                    tmpWeight.TruckCode = Convert.ToInt32(dr["TruckNo"]);
                    tmpWeight.UserPostCode = Convert.ToInt32(dr["UserPostCode"]);
                    tmpWeight.PersonCode = Convert.ToInt32(dr["UserNo"]);
                    tmpWeight.pay = Convert.ToInt32(dr["Pay"]);
                    tmpWeight.pay_h = Convert.ToInt32(dr["pay_h"]);
                    tmpWeight.BascoolCode = Convert.ToInt32(dr["BascoolCode"]);
                    tmpWeight.WDate = Convert.ToDateTime(dr["WDate"]);
                    tmpWeight.WTime = dr["WTime"].ToString();
                    tmpWeight.PlokNo = dr["PlokNo"].ToString();
                    tmpWeight.Weights = Convert.ToInt32(dr["Weights"]);
                    tmpWeight.Duty = Convert.ToDecimal(dr["Duty"]);//(tmpWeight.pay / (100 + _Duty + _Tax)) * _Tax;
                    tmpWeight.Tax = Convert.ToDecimal(dr["Tax"]);//(tmpWeight.pay / (100 + _Duty + _Tax)) * _Duty;
                    tmpWeight.hamrahno = Convert.ToInt32(dr["hamrahNo"]);
                    tmpWeight.ProductCode = Convert.ToInt32(dr["ProductNo"]);

                    if (tmpWeight.Insert(MyDB) > 0)
                    {
                        tmpWeight.Delete(tmpWeight.Code);
                        MyDB.setQuery(@"Delete From Weight Where id = " + dr["Code"]);
                        if (MyDB.Query_Execute() <= 0)
                        {
                            JMessages.Error(" خطا در همگام سازی ", "");
                            return false;
                        }
                    }
                }

                MyDB.setQuery(@"SELECT ID, WeightSerial, BascoolNo, DateWeight, EmptyWeight, WeightID  FROM EmptyTruck");
                _DtAccess = MyDB.Query_DataTable();
                foreach (DataRow dr in _DtAccess.Rows)
                {
                    JEmptyWeight tmpEmptyWeight = new JEmptyWeight();
                    tmpEmptyWeight.BascoolNo = Convert.ToInt32(dr["BascoolNo"]);
                    tmpEmptyWeight.WeightID = Convert.ToInt32(dr["WeightID"]);
                    tmpEmptyWeight.EmptyBascoolNo = Convert.ToInt32(dr["EmptyBascoolNo"]);
                    tmpEmptyWeight.WeightSerial = Convert.ToInt32(dr["WeightSerial"]);
                    tmpEmptyWeight.DateWeight = Convert.ToDateTime(dr["DateWeight"]);
                    tmpEmptyWeight.EmptyWeight = Convert.ToInt32(dr["EmptyWeight"]);
                    tmpEmptyWeight.EmptyID = Convert.ToInt32(dr["EmptyID"]);

                    if (tmpEmptyWeight.Insert() > 0)
                    {
                        MyDB.setQuery(@"Delete From Weight Where id = " + dr["Code"]);
                        if (MyDB.Query_Execute() <= 0)
                        {
                            JMessages.Error(" خطا در همگام سازی ", "");
                            return false;
                        }
                    }
                }
                //  باسکول
                MyDB.setQuery(@" delete From Bascools ");
                if (MyDB.Query_Execute() > 0)
                {
                    foreach (DataRow dr1 in JReport.GetBascols(0).Rows)
                    {
                        MyDB.setQuery(@" Insert Into Bascools (" + dr1["Code"] + ",'" + dr1["Location"] + "'," + dr1["Capacity"] + ",'" + dr1["BDesc"] + "'," + dr1["Active"]);
                        if (MyDB.Query_Execute() <= 0)
                            return false;
                    }
                }

                //  محصول
                MyDB.setQuery(@" delete From Product ");
                if (MyDB.Query_Execute() > 0)
                {
                    foreach (DataRow dr3 in JProductss.GetDataTable().Rows)
                    {
                        MyDB.setQuery(@" Insert Into Product (" + dr3["Code"] + ",'" + dr3["Name"] + "'");
                        if (MyDB.Query_Execute() <= 0)
                            return false;
                    }
                }

                //  ماشینها
                MyDB.setQuery(@" delete From Truck ");
                if (MyDB.Query_Execute() > 0)
                {
                    foreach (DataRow dr2 in JTruck.GetDataTable(0).Rows)
                    {
                        MyDB.setQuery(@"INSERT INTO Truck(TruckId,Name,wp)values(" + dr2["Code"] + ",'" + dr2["Name"] + "'," + dr2["Price"] + ")");
                        if (MyDB.Query_Execute() <= 0)
                            return false;
                    }
                }

                //  
                MyDB.setQuery(@" delete From TaxFormula ");
                if (MyDB.Query_Execute() > 0)
                {
                    //GetTaxDuty();
                    //MyDB.setQuery(@"INSERT INTO (Duty, Tax) values(" + _Duty + "," + _Tax + ")");
                    if (MyDB.Query_Execute() <= 0)
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public void GetTaxDuty()
        {
            //ClassLibrary.JOLeDbDataBase MyDB = new ClassLibrary.JOLeDbDataBase();
            //MyDB.setQuery(@"Select * From BascolTaxFormula");
            //DataTable _dtTax = MyDB.Query_DataTable();
            //if (_dtTax != null)
            //{
            //    _Tax = Convert.ToDecimal(_dtTax.Rows[0]["Tax"].ToString());
            //    _Duty = Convert.ToDecimal(_dtTax.Rows[0]["Duty"].ToString());
            //}

            string Query = @" Select * From BascolTaxFormula ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                _Tax = Convert.ToDecimal(dt.Rows[0]["Tax"].ToString());
                _Duty = Convert.ToDecimal(dt.Rows[0]["Duty"].ToString());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }


    }
}
