using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{

    public class JDayProfile : JParking
    {
        JDataBase conn;

        public class JDayState
        {
            public int Count = 0;
            public decimal Amount = 0;
            public int CountC = 0;
            public int CountE = 0;
            public decimal AmountC = 0;
            public decimal AmountE = 0;
        }

        public int Code { get; set; }
        /// <summary>
        /// عنوان شیفت
        /// </summary>
        public string NameShift { get; set; }
        /// <summary>
        /// تاریخ ثبت
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// زمان ثبت
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// سر شیفت
        /// </summary>
        public int HeadShift { get; set; }
        /// <summary>
        /// توضيحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///مجتمع
        /// </summary>
        public int Market { get; set; }
        /// <summary>
        /// شيفت
        /// </summary>
        public int shift { get; set; }
        /// <summary>
        /// كاربر
        /// </summary>
        public int UserReg { get; set; }
        /// <summary>
        /// مبلغ كل
        /// </summary>
        public int AmountKol { get; set; }

        public int Insert(JDataBase pDB)
        {
            try
            {
                //if (JPermission.CheckPermission("Parking.JDayProfile.Insert"))
                //{
                JDayProfileTable JGCT = new JDayProfileTable();
                JGCT.SetValueProperty(this);
                pDB.setQuery("Select ISNull(Max(Code),0) from [dbo].[PrkDayProfile] ");
                int _Code = Convert.ToInt32(pDB.Query_ExecutSacler());
                _Code = _Code + 1;
                pDB.setQuery("INSERT INTO [dbo].[PrkDayProfile] ([Code],[NameShift],[Date],[HeadShift],[Description],[Market],[shift],[UserReg],[Time],[AmountKol]) VALUES ('" +
      _Code + "','" + JGCT.NameShift + "','" + JGCT.Date.ToString("yyyy/MM/dd") + "','" + JGCT.HeadShift + "','" + JGCT.Description + "','" + JGCT.Market + "','" + JGCT.shift + "','" + _Code + "'" + ",'" + JGCT.Time + "','" + AmountKol + "')");
                if (pDB.Query_Execute() > 0)
                {
                    this.Code = _Code;
                    return _Code;
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }

        public bool Update()
        {
            JDataBase Jdb = new JDataBase();
            //if (JPermission.CheckPermission("Parking.JDayProfile.Update"))
            //{
            JDayProfileTable JGCT = new JDayProfileTable();
            JGCT.SetValueProperty(this);
            Jdb.setQuery("UPDATE [dbo].[PrkDayProfile]   SET " + "[NameShift] ='" + NameShift + "',[Date] ='" + JGCT.Date.ToString("yyyy/MM/dd") + "',[HeadShift] ='" + JGCT.HeadShift + "',[Description] ='" + JGCT.Description + "',[Market] ='" + JGCT.Market + "',[shift] ='" + JGCT.shift + "',[UserReg] ='" + JGCT.UserReg + "',[Time] ='" + JGCT.Time + "',[AmountKol]='" + JGCT.AmountKol + "' WHERE Code=" + JGCT.Code.ToString());
            if (Jdb.Query_Execute() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //}
            //else
            //    return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JDayProfile.Delete"))
            {
                Code = pCode;
                JDayProfileTable JGCT = new JDayProfileTable();
                JGCT.SetValueProperty(this);
                if (JGCT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.DayProfile + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
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

        public bool GetData(int Market, Boolean State)
        {
            JDataBase Jdb = new JDataBase();
            DateTime DYear = Jdb.GetCurrentDateTime().Date;


            try
            {
                Jdb.setQuery("Select Count(*) from " + JTableNamesParking.DayProfile +
                           " Where Date=" + JDataBase.Quote(DYear.ToString("yyyy/MM/dd")) + " And Market=" + Market.ToString());
                Jdb.Query_DataReader();
                if (Jdb.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Jdb.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                Jdb.Dispose();
            }
        }

        public JDayProfile()
        {
        }

        public JDayProfile(int PCode)
        {
            this.GetData(PCode);

        }

        public void ShowForm(int pCode, int Market, int Gate)
        {



            if (pCode == 0)
            {
                JShiftForm JGCF = new JShiftForm(this, Market, Gate);
                JGCF.State = JFormState.Insert;
                JGCF.ShowDialog();
            }
            else
            {
                GetData(pCode);
                JShiftForm JGCF = new JShiftForm(this, Market, Gate);
                JGCF.State = JFormState.Update;
                JGCF.ShowDialog();
            }
        }
        /// <summary>
        /// آيا شيفت ايجاد شده است
        /// </summary>
        public int CreateShift(int Market)
        {
            JDataBase Jdb = new JDataBase();
            try
            {

                DateTime DYear = Jdb.GetCurrentDateTime();
                JBaseShift TimeShift = new JBaseShift();
                TimeShift.GetTime(DYear.ToString("HH:mm"), Market);
                Jdb.setQuery("Select Code from " + JTableNamesParking.DayProfile +
                " Where Date=" + JDataBase.Quote(DYear.ToString("yyyy/MM/dd")) + " And Market=" + Market.ToString() + " And Shift=" + TimeShift.Code.ToString());
                int _Code = Convert.ToInt32(Jdb.Query_ExecutSacler());
                if (_Code > 0)
                    return _Code;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                Jdb.Dispose();
            }



        }

        /// <summary>
        /// خودروهايي كه وضعيتشان نا مشخص است
        /// </summary>
        public System.Data.DataTable DayNonDefine()
        {
            JDayState jdaystate = new JDayState();
            JDataBase DB = conn.NewDataBase();
            try
            {
                DateTime DtAmroz = DB.GetCurrentDateTime();
                DB.setQuery("SELECT     dbo.PrkTraffic.Code AS CodeTraffic, ISNULL(dbo.PrkTraffic.IDCard, 'نا معلوم') AS IDCard, dbo.PrkTraffic.Amount, " +
                      "ISNULL(dbo.MiladiTOShamsi(dbo.PrkTraffic.DateIn), 'نا معلوم') AS Datein, ISNULL(dbo.PrkTraffic.TimeIn, 'نا معلوم') AS Timein, " +
                      "dbo.MiladiTOShamsi(dbo.PrkTraffic.DateOut) AS Dateout, ISNULL(dbo.PrkTraffic.TimeOut, 'نا معلوم') AS Timeout, ISNULL(dbo.PrkGroups.TypeGroup, 0) " +
                      "AS TypeCard, ISNULL(dbo.PrkGate.Name, 'نا معلوم') AS Gatein, ISNULL(PrkGate_1.Name, 'نا معلوم') AS GateOut, ISNULL(dbo.users.username, 'نا معلوم') " +
                      "AS Userin, ISNULL(users_1.username, 'نا معلوم') AS Userout " +
"FROM         dbo.PrkTraffic LEFT OUTER JOIN " +
                      "dbo.PrkGroups ON dbo.PrkTraffic.GroupCard = dbo.PrkGroups.Code LEFT OUTER JOIN " +
                      "dbo.PrkGate AS PrkGate_1 ON dbo.PrkTraffic.GateOut = PrkGate_1.Code LEFT OUTER JOIN " +
                      "dbo.PrkGate ON dbo.PrkTraffic.GateIn = dbo.PrkGate.Code LEFT OUTER JOIN " +
                      "dbo.users ON dbo.PrkTraffic.UserIn = dbo.users.code LEFT OUTER JOIN " +
                      "dbo.users AS users_1 ON dbo.PrkTraffic.UserOut = users_1.code " +
"WHERE     ( dbo.PrkTraffic.DateIn = '" + this.Date.Date.ToString("yyyy/MM/dd") + "') AND ( dbo.PrkTraffic.MarketCode =" + this.Market.ToString() + ") AND ( dbo.PrkTraffic.Amount IS NULL) OR " +
                      "( dbo.PrkTraffic.DateOut = '" + this.Date.Date.ToString("yyyy/MM/dd") + "') AND ( dbo.PrkTraffic.MarketCode =" + this.Market.ToString() + ") AND ( dbo.PrkTraffic.Amount IS NULL)");


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
        /// گزارش كلي پاركينگ
        /// </summary>
        public Boolean GetReportParking(JDataBase dbAccounting, DateTime DtBegin, DateTime DtEnd, int Gate, int Market)
        {
            try
            {
                conn = dbAccounting.NewDataBase();
                string Where2 = " ";
                string Where1 = "  Where (Traffic.MarketCode='" + Market.ToString() + "') And  (Traffic.DateIn='" + DtBegin.ToString("yyyy/MM/dd") + "' or Traffic.DateOut='" + DtEnd.ToString("yyyy/MM/dd") + "') ";
                if (Gate != 0)
                {
                    Where2 = " And Traffic.GateAmount=" + Gate.ToString() + " ";
                }

                System.Data.DataTable[] Dt = new System.Data.DataTable[1];

                Delrepeted(conn, DtBegin, DtEnd);
                dbAccounting.setQuery("SELECT     dbo.PrkGroups.TypeGroup, ISNUll(SUM(Traffic.Amount),0) AS Amount, COUNT(Traffic.Code) AS Count, AVG(Traffic.DurationStayParking) AS StopTimes, " +
                         " COUNT(Traffic.DateIn) AS Input, COUNT(Traffic.DateOut) AS Output FROM         dbo.Traffic  INNER JOIN   dbo.PrkGroups ON Traffic.GroupCard = dbo.PrkGroups.GroupNumber " + Where1 + Where2 +
    " GROUP BY dbo.PrkGroups.TypeGroup Union All \r\n " +
    " SELECT     'مجموع كاركرد اين گيت' As TypeGroup, ISNUll(SUM(Traffic.Amount),0) AS Amount, COUNT(Traffic.Code) AS Count, AVG(Traffic.DurationStayParking) AS StopTimes, " +
                         " COUNT(Traffic.DateIn) AS Input, COUNT(Traffic.DateOut) AS Output FROM         dbo.Traffic  INNER JOIN   dbo.PrkGroups ON Traffic.GroupCard = dbo.PrkGroups.GroupNumber " + Where1 + Where2 +
                       "  Union All \r\n " +
    " SELECT     'كاركرد كل پاركينگ' As TypeGroup, ISNUll(SUM(Traffic.Amount),0) AS Amount, COUNT(Traffic.Code) AS Count, AVG(Traffic.DurationStayParking) AS StopTimes, " +
                         " COUNT(Traffic.DateIn) AS Input, COUNT(Traffic.DateOut) AS Output FROM         dbo.Traffic  INNER JOIN   dbo.PrkGroups ON Traffic.GroupCard = dbo.PrkGroups.GroupNumber " + Where1);

                dbAccounting.Query_DataSet();
                Dt[0] = dbAccounting.DataSet.Tables[0];
                dbAccounting.Dispose();
                GetGenralOption(ref Dt[0]);

                JDynamicReportForm DRF = new JDynamicReportForm(Convert.ToInt32(ProjectsEnum.Parking));
                DRF.AddRange(Dt);
                DRF.ShowDialog();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }

        /// <summary>
        /// گزارش به تفكيك گيت ها
        /// </summary>
        public Boolean GetReportGate(JDataBase dbAccounting, DateTime DtBegin, DateTime DtEnd, int Gate)
        {

            try
            {
                string Where = "  Where (dbo.Traffic.MarketCode='" + this.Market.ToString() + "') And  (Traffic.DateIn='" + DtBegin.ToString("yyyy/MM/dd") + "' Or Traffic.DateOut='" + DtEnd.ToString("yyyy/MM/dd") + "') ";
                if (Gate != 0)
                {
                    Where = Where + " And Traffic.GateAmount=" + Gate.ToString();
                }


                dbAccounting.setQuery("SELECT      pG.Name,  (Select ISNULL(SUM(dbo.Traffic.Amount),0) from dbo.Traffic " + Where + " And dbo.Traffic.GateAmount in(select  GateIn from dbo.Traffic " + Where + ") ) AS Amount, COUNT(dbo.Traffic.Code) AS Count,(SELECT     STUFF  ((SELECT     ' | ' + UserInTitle " +
                                                             "FROM         dbo.Traffic INNER JOIN  dbo.PrkGate ON dbo.Traffic.GateIn = dbo.PrkGate.Code " + Where + " And  pG.Name=prkGate.Name  group by UserInTitle   FOR XML PATH('')), 1, 2, ''))  as Users " +
    "FROM         dbo.PrkGate   As pG  INNER JOIN " +
                          "dbo.Traffic ON  pG.Code = dbo.Traffic.GateIn" + Where +
    " GROUP BY  pG.Name " +
    " Union " +
  " SELECT      pG.Name,  (Select ISNULL(SUM(dbo.Traffic.Amount),0) from dbo.Traffic " + Where + " And dbo.Traffic.GateAmount in(select  GateOut from dbo.Traffic " + Where + ") ) AS Amount, COUNT(dbo.Traffic.Code) AS Count,(SELECT     STUFF  ((SELECT     ' | ' + UserOutTitle " +
                                                             "FROM         dbo.Traffic INNER JOIN  dbo.PrkGate ON dbo.Traffic.GateOut = dbo.PrkGate.Code " + Where + " And  pG.Name=prkGate.Name  group by UserOutTitle   FOR XML PATH('')), 1, 2, ''))  as Users " +
    "FROM         dbo.PrkGate   As pG  INNER JOIN " +
                          "dbo.Traffic ON  pG.Code = dbo.Traffic.GateOut" + Where +
    " GROUP BY  pG.Name ");
                dbAccounting.Query_DataSet();

                System.Data.DataTable[] Dt = new System.Data.DataTable[1];
                Dt[0] = dbAccounting.DataSet.Tables[0];
                GetGenralOption(ref Dt[0]);
                JDynamicReportForm DRF = new JDynamicReportForm(Convert.ToInt32(ProjectsEnum.Parking));
                DRF.AddRange(Dt);
                DRF.ShowDialog();
                return true;
            }
            catch
            {
                ClassLibrary.JMessages.Error("در تهيه گزارش خطايي بروز كرده است", "هشدار");
                return false;
            }
            finally
            {
                dbAccounting.Dispose();
            }
        }

        /// <summary>
        /// گزارش خرابي هاي ثبت شده
        /// </summary>
        public Boolean GetReportOfDamge(JDataBase dbAccounting, DateTime DtBegin, DateTime DtEnd, int Gate)
        {


            string Where = "  Where (dbo.PrkDamage.Market='" + this.Market.ToString() + "') And  (dbo.PrkDamage.DateStop='" + DtBegin.ToString("yyyy/MM/dd") + "' Or dbo.PrkDamage.DateStop='" + DtEnd.ToString("yyyy/MM/dd") + "') ";
            if (Gate != 0)
            {
                Where = Where + " And dbo.PrkDamage.Gate=" + Gate.ToString();
            }


            dbAccounting.setQuery("SELECT     dbo.subdefine.name, dbo.PrkDamage.Hint, dbo.PrkDamage.DateStop, dbo.PrkDamage.Time, dbo.PrkGate.Name AS Gate, ISNULL(dbo.users.username, " +
                  "'نا مشخص') AS Oprator FROM         dbo.PrkDamage INNER JOIN   dbo.subdefine ON dbo.PrkDamage.Type = dbo.subdefine.Code INNER JOIN  dbo.PrkGate ON dbo.PrkDamage.Gate = dbo.PrkGate.Code LEFT OUTER JOIN " +
                  "dbo.users ON dbo.PrkDamage.Oprator = dbo.users.code " + Where);

            dbAccounting.Query_DataSet();
            System.Data.DataTable[] Dt = new System.Data.DataTable[1];
            Dt[0] = dbAccounting.Query_DataTable();

            JDynamicReportForm DRF = new JDynamicReportForm(Convert.ToInt32(ProjectsEnum.Parking));
            DRF.AddRange(Dt);
            DRF.ShowDialog();
            return true;
        }

        public Boolean Delrepeted(JDataBase sqlcon, DateTime DataBegin, DateTime DataEnd)
        {

            JDataBase newdb = sqlcon;
            try
            {
                newdb.setQuery(" delete from [dbo].[Traffic] where DateIn='" + DataBegin.ToString("yyyy/MM/dd") + "'  and Code not in ( " +
     " SELECT MIN(Code) 	FROM  [dbo].[Traffic] b  where b.DateIn='" + DataBegin.ToString("yyyy/MM/dd") + "'  " +
     " GROUP BY b.idcard, b.timein 	having COUNT(*) >=1) \r\n " +

     " delete from [dbo].[Traffic] where DateOut='" + DataEnd.ToString("yyyy/MM/dd") + "' and Code not in ( " +
     " SELECT MIN(Code) 	FROM  [dbo].[Traffic] b  where b.DateIn='" + DataEnd.ToString("yyyy/MM/dd") + "'  " +
     " GROUP BY b.idcard, b.timeOut 	having COUNT(*) >=1)  ");

                if (newdb.Query_Execute() > 0)
                {
                    return true;
                }


                return false;

            }
            catch
            {
                newdb.Dispose();
                return false;
            }
        }

        private void GetGenralOption(ref System.Data.DataTable DtRef)
        {
            JDataBase jdb = new JDataBase();
            try
            {
                RealEstate.jMarket Market = new RealEstate.jMarket(this.Market);
                System.Data.DataColumn Colum = new System.Data.DataColumn();
                Colum.ColumnName = "MarketRef";
                Colum.DefaultValue = Market.Title;
                DtRef.Columns.Add(Colum);
                Colum = new System.Data.DataColumn();
                Colum.ColumnName = "DateIn";
                Colum.DefaultValue = JDateTime.FarsiDate(this.Date) + " " + DateTime.Now.ToString("HH:MM");
                DtRef.Columns.Add(Colum);
                Colum = new System.Data.DataColumn();
                Colum.ColumnName = "ShiftManger";
                jdb.setQuery("Select * from users Where Code=" + this.HeadShift);
                jdb.Query_DataTable();
                Colum.DefaultValue = jdb.datatable.Rows[0]["username"].ToString();
                DtRef.Columns.Add(Colum);
                Colum = new System.Data.DataColumn();
                Colum.ColumnName = "ActualAmount";
                Colum.DefaultValue = this.AmountKol;
                DtRef.Columns.Add(Colum);
                JBaseShift Shift = new JBaseShift(this.shift);
                Colum = new System.Data.DataColumn();
                Colum.ColumnName = "Shift";
                Colum.DefaultValue = Shift.Name;
                DtRef.Columns.Add(Colum);
                Colum = new System.Data.DataColumn();
                Colum.ColumnName = "UserReg";
                jdb.setQuery("Select * from users Where Code=" + this.HeadShift);
                jdb.Query_DataTable();
                Colum.DefaultValue = jdb.datatable.Rows[0]["username"].ToString();
                DtRef.Columns.Add(Colum);

            }
            catch
            {
            }

        }

        /// <summary>
        ///  مبالغ دستي وارد شده كاربران هر صندوق
        /// </summary>
        public JDayProfile.JDayState DayHasabShift()
        {
            JDayState jdaystate = new JDayState();
            JDataBase DB = new JDataBase();
            try
            {

                DB.setQuery("SELECT ISNull(Sum(Amount),0) AS Amount FROM " + JTableNamesParking.ParkingUser + " WHERE DateShift='" + this.Date.Date.ToString("yyyy/MM/dd") + "' And Market=" + Market.ToString());
                DB.Query_DataSet();
                System.Data.DataTable Dt = DB.DataSet.Tables[0];
                jdaystate.Amount = Convert.ToInt32(DB.DataSet.Tables[0].Rows[0]["Amount"]);
                return jdaystate;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                jdaystate.Amount = 0;
                jdaystate.Count = 0;
                return jdaystate;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["NameShift"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataParking", "Parking.JDayProfile.ShowForm", new object[] { (int)pDR["Code"], (int)pDR["Market"], 0 }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JDayProfile.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "نام گروه " + (char)13 + Node.Name;
            return Node;
        }

    }

    public class JDayProfiles : JParking
    {
        public static System.Data.DataTable GetDataTable(int Pmarket)
        {
            return GetDataTable(0, Pmarket);
        }
        
        public static System.Data.DataTable GetDataTable(int pCode,int Pmarket)
        {
            JDataBase DB = new JDataBase();
            try
            {

                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And Code=" + pCode.ToString();
                if (Pmarket>0)
                    pWhere = pWhere + " And Market=" + Pmarket.ToString();
                DB.setQuery("SELECT Code,NameShift," + JDataBase.SQLMiladiToShamsi("Date", "Date") + ",AmountKol,Market FROM " + JTableNamesParking.DayProfile + pWhere + " And " +
                   JPermission.getObjectSql("Parking.JDayProfiles.GetDataTable", "JDayProfile.Code"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }

        public void ListView(int Pmarket)
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JDayProfile.GetNode");
            Nodes.DataTable = GetDataTable(Pmarket);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JDayProfile", "Parking.JDayProfile.ShowForm", new object[] { 0,Pmarket,0 }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }
       
      
    }
}
