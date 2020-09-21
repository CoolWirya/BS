using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Globalization;



namespace RealEstate
{
 public   class JPrintableGhabz 
    {
        public int Code { get; set; }
        public string CodeGhabz { get; set; }
        public int CodeUnitBuild { get; set; }
        public int PreviousDebt { get; set; }
        public int Yaraneh { get; set; }
        public int debt { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public int Month { get; set; }
        public int CodeCustomer { get; set; }
        public int CodeMarket { get; set; }
        public Boolean StatusPay { get; set; }
        public int CodeUser { get; set; }
        public DateTime DateCreate { get; set; }
        public int BastanKari { get; set; }
        
        public JPrintableGhabz()
        {

        }
          

        
        #region Method

        public int insert(JDataBase pDb)
        {
            JPrintableGhabzTable JPG = new JPrintableGhabzTable();
       
            try
            {
                int Code;
                JPG.SetValueProperty(this);
                Code = JPG.Insert(pDb);
                if (Code > 0)
                {
                    return Code;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JPG.Dispose();
            }
        }
        public int insert()
        {
            JPrintableGhabzTable JPG = new JPrintableGhabzTable();

            try
            {
                int Code;
                JPG.SetValueProperty(this);
                Code = JPG.Insert();
                if (Code > 0)
                {
                    return Code;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JPG.Dispose();
            }
        }
        public bool Delete(JDataBase PDb)
        {
            try
            {
                JPrintableGhabzTable JPG = new JPrintableGhabzTable();
                JPG.SetValueProperty(this);
                if (JPG.Delete(PDb))
                {
                  return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }                          
        }

        public void ShowForm()
        {
            if (JPermission.CheckPermission("RealEstate.JPrintBillForm.ShowForm"))
            {
                JPrintBillForm form = new JPrintBillForm();
                form.ShowDialog();
            }
        }


        public bool Update(JDataBase pDb)
        {
            JPrintableGhabzTable JPG = new JPrintableGhabzTable();
            try
            {
                JPG.SetValueProperty(this);
                return JPG.Update(pDb);
               
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JPG.Dispose();
            }
        }
        public bool Update()
        {
            JPrintableGhabzTable JPG = new JPrintableGhabzTable();
            try
            {
                JPG.SetValueProperty(this);
                return JPG.Update();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JPG.Dispose();
            }
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("Select * from RePrintedCharge Where Code=" + pCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public Boolean GetData(string Query)
        {
            JDataBase Jdb = new JDataBase();
            try
            {
                
                JChargeBuildTable JCBT = new JChargeBuildTable();
                Jdb.setQuery(Query);
                JCBT.SetValueProperty(Jdb.Query_ExecutSacler());
                if (JCBT.Code != 0) return true; else return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Jdb.Dispose();
            }
        }

        /// <summary>
        ///اطلاعات را از جداول مختلف برای درج در جدول شارژ آماده می کند
        /// </summary>
        public System.Data.DataTable  GetListOfPrintingCharge(int CodeMarket,int BeginUnitBuild,int EndUnitBuild)
        {
            System.Data.DataTable dt = null;
            int Counter=0;
             JDataBase jdb = new JDataBase();
           
             try
             {
                 string TempNumber = "";

                 JChargeBuildTable JCBT = new JChargeBuildTable();
                 //+dbo.CalculateYaraneh(UB.Code)
                 jdb.setQuery(@"SELECT DISTINCT   ISNULL(P.Code, 0) AS PersonCode, ISNULL(P.Name, 'نا معلوم') AS NamePerson, ISNULL(RE.Code, 0) AS CodeGhabz, UB.MarketCode, ISNULL(RE.CurrentCharge, 0) AS CurrentCharge, ISNULL(RE.PeriodCharge, 0) AS PeriodCharge, 
                 (select top 1 ISNULL(Tel.Tel, '-------') AS tel from estUnitBuildTels Tel where UB.Code = Tel.UnitBuildCode AND Tel.[DefaultValue] = 'True')," +//ISNULL(Tel.Tel, '-------') AS tel, 
                     "UB.Code AS CodeUnitbuild, UB.Number, flr.Name, ISNULL(RE.Yaraneh, 0) AS Yaraneh, GETDATE() AS MonthSodor,ISNULL(dbo.MaliErp" + CodeMarket + ".MondehKol, 0) AS Perviuosdebt,UB.Tafsili2, ISNULL(dbo.MaliErp" + CodeMarket + ".BastanKari, 0) AS BastanKari  " +
                " FROM         dbo.estMarketFloors AS flr RIGHT OUTER JOIN "+
                      "dbo.estUnitBuild AS UB ON flr.Code = UB.FloorCode LEFT OUTER JOIN "+
                          "(SELECT     ActiveContracts.Code, ActiveContracts.Type, ActiveContracts.Number, ActiveContracts.Date, ActiveContracts.StartDate, "+
                                                   "ActiveContracts.EndDate, ActiveContracts.Description, ActiveContracts.SharjByRenter, PC.PersonCode, FA.ObjectCode "+
                            " FROM         (SELECT     Code, Type, Number, Date, DateDeliver, StartDate, EndDate, Location, FinanceCode, FinancePercent, Description, Guarantee, "+
                                                                           "Condition, Status, PriceMonth, Sharj, Price, TotalPrice, RealPrice, RealPriceDate, CountPayment, StartpaymentDate, "+
                                                                           "EndpaymentDate, DecisionCode, DecisionDesc, CancelDate, CancelReason, CancelDesc, ConfirmSeller, ConfirmBuyer, "+
                                                                           "ConfirmIntuition, FileCode, Confirmed, GoodwillPrice, Disabled, SharjByRenter, Duration, Job, EstenkafRight, ReturnChCount, "+
                                                                           "FineT1, FineT2, GoodwillCostsBy, GoodwillDesc, RentDesc, CopyCount "+
                                                     "FROM         dbo.LegSubjectContract AS C "+
                                                     "WHERE  C.Status=1 And   (Type IN " +
                                                                               "(SELECT     Code "+
                                                                                  "FROM         dbo.LegContractType "+
                                                                                  "WHERE     (ContractType IN " +
                                                                                                            "(SELECT     Code "+
                                                                                                               "FROM         dbo.legContractDynamicTypes "+
                                                                                                               "WHERE     (AssetTransferType = 3))))) AND (EndDate >= GETDATE())  "+ //AND (SharjByRenter = 1)
                                                   "  UNION "+
                                                    " SELECT     Code, Type, Number, Date, DateDeliver, StartDate, EndDate, Location, FinanceCode, FinancePercent, Description, Guarantee, "+
                                                                           "Condition, Status, PriceMonth, Sharj, Price, TotalPrice, RealPrice, RealPriceDate, CountPayment, StartpaymentDate, "+ 
                                                                           "EndpaymentDate, DecisionCode, DecisionDesc, CancelDate, CancelReason, CancelDesc, ConfirmSeller, ConfirmBuyer, "+
                                                                           "ConfirmIntuition, FileCode, Confirmed, GoodwillPrice, Disabled, SharjByRenter, Duration, Job, EstenkafRight, ReturnChCount, "+
                                                                           "FineT1, FineT2, GoodwillCostsBy, GoodwillDesc, RentDesc, CopyCount "+
                                                     "FROM         dbo.LegSubjectContract AS C "+
                                                     "WHERE  C.Status=1 And   (Type IN " +
                                                                               "(SELECT     Code "+
                                                                                  "FROM         dbo.LegContractType AS LegContractType_2 "+
                                                                                  "WHERE     (ContractType IN "+
                                                                                                            "(SELECT     Code "+
                                                                                                               "FROM         dbo.legContractDynamicTypes AS legContractDynamicTypes_2 "+
                                                                                                               " WHERE     (AssetTransferType = 2))))) AND (FinanceCode NOT IN  "+
                                                                               "(SELECT     FinanceCode "+
                                                                                  "FROM         dbo.LegSubjectContract AS C "+
                                                                                  "WHERE     (Type IN "+
                                                                                                            "(SELECT     Code "+
                                                                                                               "FROM         dbo.LegContractType AS LegContractType_1 "+
                                                                                                               "WHERE     (ContractType IN "+
                                                                                                                                         "(SELECT     Code "+
                                                                                                                                            "FROM         dbo.legContractDynamicTypes AS legContractDynamicTypes_1 "+
                                                                                                                                            "WHERE     (AssetTransferType = 3))))) AND (EndDate >= GETDATE()) ))) "+ //AND (SharjByRenter = 1)
                                                   "AS ActiveContracts INNER JOIN " +
                                                   "dbo.LegPersonContract AS PC ON ActiveContracts.Code = PC.ContractSubjectCode AND PC.Type = 9 INNER JOIN "+
                                                   "dbo.finAsset AS FA ON ActiveContracts.FinanceCode = FA.Code) AS Contracts ON UB.Code = Contracts.ObjectCode LEFT OUTER JOIN "+
                      "dbo.clsAllPerson AS P ON Contracts.PersonCode = P.Code LEFT OUTER JOIN "+
                      "dbo.ReChargeBuild AS RE ON UB.Code = RE.CodeUnitBuild LEFT OUTER JOIN "+
                      "  " + //LEFT OUTER JOIN dbo.estUnitBuildTels AS Tel ON UB.Code = Tel.UnitBuildCode AND Tel.[DefaultValue] = 'True'
                      "dbo.MaliErp" + CodeMarket + " ON UB.Tafsili2 = dbo.MaliErp" + CodeMarket + ".UnitBuildMaliCode " +
                                                   " where UB.Tafsili2>=" + BeginUnitBuild + " and UB.Tafsili2<=" + EndUnitBuild + " And ub.MarketCode=" + CodeMarket + " order by UB.Tafsili2");
                
                 dt = jdb.Query_DataTable();
                
                 //حذف ركوردهاي تكراري

                 for (Counter = 0; Counter < dt.Rows.Count; Counter++)
                 {
                     if (TempNumber == dt.Rows[Counter]["Tafsili2"].ToString())
                     {
                         dt.Rows[Counter - 1].Delete();
                     }
                     TempNumber = dt.Rows[Counter]["Tafsili2"].ToString();
                 }
                 dt.AcceptChanges();
                 return dt;
             }
             catch
             {
                
                 return null;
             }
             finally
             {
                 jdb.DisConnect();
             }
      
                           
        }
        /// <summary>
        /// لیست قبض های چاپ شده را بر می گرداند
        /// </summary>
        public System.Data.DataTable GetListOfprintedCharch(string Query)
        {
            JDataBase jdb = new JDataBase();
            try
            {
                
                jdb.setQuery("SELECT     dbo.RePrintedCharge.CodeGhabz, dbo.MiladiTOShamsi(dbo.RePrintedCharge.PaymentDeadline) AS Date, dbo.RePrintedCharge.debt, "+
                              "dbo.RePrintedCharge.PreviousDebt, dbo.RePrintedCharge.Yaraneh, ISNULL(dbo.clsAllPerson.Name, ' نا معلوم') AS PersonName, "+
                              "dbo.estMarketFloors.Name AS Floors, ISNULL(dbo.estUnitBuild.Area, 0) AS Area, dbo.estUnitBuild.Plaque, dbo.RePrintedCharge.Code, "+
                              "dbo.ReChargeBuild.CurrentCharge, dbo.ReChargeBuild.PeriodCharge, dbo.RePrintedCharge.StatusPay, "+
                              "ISNULL(dbo.MiladiTOShamsi(dbo.RePrintedCharge.DateCreate), 'نا معلوم') AS IssueDate, ISNULL(dbo.estUnitBuildTels.Tel, '---------') AS MainTel, "+
                              "ISNULL(dbo.estUnitBuild.Number, '--------') AS Number, ISNull(dbo.RePrintedCharge.BastanKari,0) AS BastanKari, dbo.ReMonth.Name AS HintMonth, " +
                          "dbo.RePrintedCharge.Month "+
                        "FROM         dbo.estMarketFloors RIGHT OUTER JOIN "+
                              "dbo.clsAllPerson RIGHT OUTER JOIN "+
                              "dbo.ReMonth RIGHT OUTER JOIN "+
                              "dbo.RePrintedCharge ON dbo.ReMonth.Code = dbo.RePrintedCharge.Month LEFT OUTER JOIN "+
                              "dbo.estUnitBuild LEFT OUTER JOIN "+
                              "dbo.ReChargeBuild ON dbo.estUnitBuild.Code = dbo.ReChargeBuild.CodeUnitBuild ON dbo.RePrintedCharge.CodeUnitBuild = dbo.estUnitBuild.Code ON "+
                               "dbo.clsAllPerson.Code = dbo.RePrintedCharge.CodeCustomer ON dbo.estMarketFloors.Code = dbo.estUnitBuild.FloorCode LEFT OUTER JOIN "+
                              "dbo.estUnitBuildTels ON dbo.estUnitBuild.Code = dbo.estUnitBuildTels.UnitBuildCode AND dbo.estUnitBuildTels.[DefaultValue] = 'True' " +
                        "WHERE (1=1) " + Query+" order by CodeGhabz"); 
                
                return jdb.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                jdb.Dispose();
            }
        }
        /// <summary>
        /// لیست شارژ را برای ارسال به  گزارش ساز ÷ویا آماده می کند
        /// </summary>
        public Boolean PrintGhabZCharch(string Query)
        {

            System.Data.DataTable[] data = new System.Data.DataTable[1];
            data[0] = GetListOfprintedCharch(Query);

            data[0].Columns["Month"].Caption = "ماه";
            data[0].Columns["CodeGhabz"].Caption = "شماره قبض";
            data[0].Columns["PersonName"].Caption = "نام شخص";
            data[0].Columns["Number"].Caption = "شماره واحد تجاری";
            data[0].Columns["Plaque"].Caption = "شماره قديم";
            data[0].Columns["MainTel"].Caption = "تلفن";
            data[0].Columns["Floors"].Caption = "طبقه";
            data[0].Columns["Area"].Caption = "متراژ واحد تجاری";
            data[0].Columns["PeriodCharge"].Caption = "مبلغ شارژ ماهيانه";
            data[0].Columns["CurrentCharge"].Caption = "مبلغ شارژ اين دوره";
            data[0].Columns["PreviousDebt"].Caption = "بدهي قبلي";
            data[0].Columns["Yaraneh"].Caption = "يارانه";
            data[0].Columns["debt"].Caption = "مبلغ قابل پرداخت";
            data[0].Columns["Date"].Caption = "آخرین مهلت پرداخت";
            data[0].Columns["Code"].Caption = "کد جدول قبض";
            data[0].Columns["StatusPay"].Caption = "تصفيه شده";
            data[0].Columns["IssueDate"].Caption = "تاريخ صدور";
            
            data[0].Columns["BastanKari"].Caption = "مبلغ بستانكاري";
            data[0].Columns["HintMonth"].Caption = "نام ماه";
            
            JDynamicReportForm DRF = new JDynamicReportForm(Convert.ToInt32(ProjectsEnum.ShopSharj));
            DRF.AddRange(data);
            DRF.ShowDialog();
            return true;
        }
        /// <summary>
        ///اطلاعات مالی را بروز می کند
        /// </summary>
        private  Boolean GetMaliData(int CodeMarket)
        {
            JDataBase JDataInsert = new JDataBase();
            JConnection connection = new JConnection();
            System.Data.SqlClient.SqlConnectionStringBuilder conn = connection.GetConnection("RealEstate.jMarket", CodeMarket);

            System.Data.DataTable Dt = new System.Data.DataTable();
            JDataBase jdb = new JDataBase(conn);
            try
            {

                jdb.setQuery("SELECT [Badhkari],[BastanKari],[UnitBuildMaliCode],[HintUnitBuild],[MondehKol] FROM  [" + connection.DataBaseName + "].[dbo].[BadahiKhorfeha]");
                Dt = jdb.Query_DataTable();

                
                JDataInsert.setQuery("if exists(Select * From dbo.sysobjects where [name]='MaliErp" + CodeMarket + "') Drop Table dbo.MaliErp" + CodeMarket + "  Create Table dbo.MaliErp" + CodeMarket + "(Badhkari Int  null,BastanKari Int null,UnitBuildMaliCode Int Not null ,[HintUnitBuild] nvarchar(80) null,MondehKol Numeric  not null)");
                JDataInsert.Query_Execute();

                string Str = "";
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Str = Str + "INSERT INTO [dbo].[MaliErp" + CodeMarket + "] ([Badhkari],[BastanKari],[UnitBuildMaliCode],[HintUnitBuild],[MondehKol]) VALUES (" + Convert.ToInt32(Dt.Rows[i]["Badhkari"]) + "," + Convert.ToInt32(Dt.Rows[i]["BastanKari"]) + "," + Convert.ToInt32(Dt.Rows[i]["UnitBuildMaliCode"]) + ",'" + Dt.Rows[i]["HintUnitBuild"].ToString() + "'," + Convert.ToInt32(Dt.Rows[i]["MondehKol"]) + ")\r\n ";


                }
                JDataInsert.setQuery(Str);
                if (JDataInsert.Query_Execute() >= 0) return true; else return false;

            }

            catch
            {
                return false;
            }
            finally
            {
                jdb.Dispose();
                JDataInsert.Dispose();

            }
        }
        public Boolean GetMaliData(int CodeMarket,string path)
        {
            
            JDataBase JDataInsert = new JDataBase();
            JConnection connection = new JConnection();
            try
            {
                if (path.Length != 0)
                {

                    System.Data.DataTable Dt = new System.Data.DataTable();
                    Dt = ImportExcelToData(path);
                    JDataInsert.setQuery("if exists(Select * From dbo.sysobjects where [name]='MaliErp" + CodeMarket + "') Drop Table dbo.MaliErp" + CodeMarket + "  Create Table dbo.MaliErp" + CodeMarket + "(Badhkari Numeric  null,BastanKari Numeric null,UnitBuildMaliCode Int Not null ,[HintUnitBuild] nvarchar(80) null,MondehKol Numeric  not null)");
                    JDataInsert.Query_Execute();

                    string Str = "";
                    for (int i = 0; i < Dt.Rows.Count-1; i++)
                    {
                        Str = Str + "INSERT INTO [dbo].[MaliErp" + CodeMarket + "] ([Badhkari],[BastanKari],[UnitBuildMaliCode],[HintUnitBuild],[MondehKol]) VALUES (" + Convert.ToSingle(Dt.Rows[i]["Badhkari"]) + "," + Convert.ToSingle(Dt.Rows[i]["BastanKari"]) + "," + Convert.ToSingle(Dt.Rows[i]["UnitBuildMaliCode"]) + ",'" + Dt.Rows[i]["HintUnitBuild"].ToString() + "'," + Convert.ToSingle(Dt.Rows[i]["MondehKol"]) + ")\r\n ";


                    }
                    JDataInsert.setQuery(Str);
                    if (JDataInsert.Query_Execute() >= 0) return true; else return false;
                }
                else
                {
                   return GetMaliData(CodeMarket);
                }
               
            }

            catch
            {
                return false;
            }
            finally
            {
                
                JDataInsert.Dispose();
             

            }
        }
        public int  ChangeSharhSand(int CodeMarket,string Sharh,int ShSand)
        {
           
            JConnection connection = new JConnection();

            System.Data.SqlClient.SqlConnectionStringBuilder conn = connection.GetConnection("RealEstate.jMarket", CodeMarket);
            int Count = 0;
             JDataBase jdb = new JDataBase(conn);
            try
            {
               
                jdb.setQuery("update mdsanad  set mdsa07='"+Sharh+"' where mdsa01="+ShSand);
                jdb.beginTransaction("Sharh");
                Count = jdb.Query_Execute();
                if (Count > 0)
                {

                    jdb.Commit();
                    return Count;
                }
                else
                {
                    jdb.Rollback("Sharh");
                    return -1;
                }

            }

            catch
            {
                jdb.Rollback("Sharh");  
                return -1;
            }
            finally
            {
                jdb.Dispose();
               

            }
        }
        private System.Data.DataTable ImportExcelToData(String path)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);

            Microsoft.Office.Interop.Excel.ApplicationClass app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
            int index = 0;
            object rowIndex = 2;
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Badhkari");
            dt.Columns.Add("BastanKari");
            dt.Columns.Add("UnitBuildMaliCode");
            dt.Columns.Add("HintUnitBuild");
            dt.Columns.Add("MondehKol");
         

            DataRow row;

            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
            {
                rowIndex = 2 + index;
                row = dt.NewRow();
                row[0] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 1]).Value2);
                row[1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 2]).Value2);
                row[2] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 3]).Value2);
                row[3] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 4]).Value2);
                row[4] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, 5]).Value2);
                index++;
                dt.Rows.Add(row);
            }
            app.Workbooks.Close();
            return dt;
        }
        #endregion

    }
}
