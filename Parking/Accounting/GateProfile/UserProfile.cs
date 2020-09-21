using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Parking
{
  public   class JUserProfile:JParking
    {
        /// <summary>
        ///   كد كاربر
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///   تاريخ تشكيل
        /// </summary>
        public DateTime DateShift { get; set; }
        /// <summary>
        ///  ساعت تشكيل
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// شماره گيت
        /// </summary>
        public int Gate { get; set; }
        /// <summary>
        /// توضيحات
        /// </summary>
        public string Hint { get; set; }
        /// <summary>
        /// كاربر
        /// </summary>
        public int Oprator { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// مجتمع
        /// </summary>
        public int Market { get; set; }
        /// <summary>
        /// شيفت
        /// </summary>
        public int Shift { get; set; }
        public int Insert(JDataBase pDB)
        {
            try
            {
                
                    JUserProfileTable JGCT = new JUserProfileTable();
                    JGCT.SetValueProperty(this);
                    pDB.setQuery("Select Max(Code) from [dbo].[PrkProfileUser]");
                    int _Code = Convert.ToInt32(pDB.Query_ExecutSacler()) + 1;
                    pDB.setQuery("INSERT INTO [dbo].[PrkProfileUser] ([Code],[DateShift],[Time],[Gate],[Hint],[Oprator],[Shift],[Market],[Amount])    VALUES  ('" + _Code + "','" + DateShift + "','" + Time + "','" + Gate + "','" + Hint + "','" + Oprator + "','" + Shift + "','" + Market + "','" + Amount + "')");
                    Code = JGCT.Insert(pDB);
                    return _Code;
               
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }
        public int CreateProfile()
        {
            JDataBase Jdb = new JDataBase();
            try
            {
              
                DateTime DYear = Jdb.GetCurrentDateTime().Date;
                int Market = Properties.Settings.Default.Complex;
                int gate=Properties.Settings.Default.Gate;
                int Shift = JBaseShift.GetShiftOfTime();
                Jdb.setQuery("Select Code from " + JTableNamesParking.ParkingUser +
                              " Where DateShift=" + JDataBase.Quote(DYear.ToString("yyyy/MM/dd")) + " And Shift=" + Shift.ToString() + " And Market=" + Market.ToString()+" And Gate="+gate.ToString());
                return Convert.ToInt32(Jdb.Query_ExecutSacler());
                   

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
        public int CreateProfile(int _Gate)
        {
            JDataBase Jdb = new JDataBase();
            try
            {

                DateTime DYear = Jdb.GetCurrentDateTime().Date;
                int Market = Properties.Settings.Default.Complex;
                int gate = _Gate;
                int Shift = JBaseShift.GetShiftOfTime();
                Jdb.setQuery("Select Code from " + JTableNamesParking.ParkingUser +
                              " Where DateShift=" + JDataBase.Quote(DYear.ToString("yyyy/MM/dd")) + " And Shift=" + Shift.ToString() + " And Market=" + Market.ToString() + " And Gate=" + gate.ToString());
                return Convert.ToInt32(Jdb.Query_ExecutSacler());


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
        public bool Update()
        {
            if (JPermission.CheckPermission("Parking.JUserProfile.Update"))
            {
                JUserProfileTable JGCT = new JUserProfileTable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.ParkingUser + " WHERE Code=" + pCode.ToString());
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
        public Boolean ISCloseHasab(int MarketGate)
        {
         int Code = CreateProfile(MarketGate);
         return   GetData(Code);
        }
        public void ShowForm(int _Gate)
        {
           int Code=CreateProfile();
           UserProfile(Code);
           JGateProfileForm Gate = new JGateProfileForm(this,_Gate);
           Gate.ShowDialog();


        }

        private void UserProfile(int Code)
        {
           
        }
        public int Countkhodro()
        {
          
            JDataBase DB = new JDataBase();
            try
            {

                DB.setQuery("SELECT  COUNT(Code) FROM " + JTableNamesParking.Traffic + " WHERE  (DateIn='" + this.DateShift.ToString("yyyy/MM/dd") + "' or DateOut='" + this.DateShift.ToString("yyyy/MM/dd") + "') and (UserIn=" + this.Oprator.ToString() + " or UserOut=" + this.Oprator.ToString() + ") and MarketCode=" + this.Market.ToString());
              int Code=Convert.ToInt32(DB.Query_ExecutSacler());
              return Code;
            }
            catch (Exception ex)
            {
               
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public int Amountkhodro()
        {

            JDataBase DB = new JDataBase();
            try
            {

                DB.setQuery("SELECT  Sum(Amount) FROM " + JTableNamesParking.Traffic + " WHERE  (DateIn='" + this.DateShift.ToString("yyyy/MM/dd") + "' or DateOut='" + this.DateShift.ToString("yyyy/MM/dd") + "') and (UserIn=" + this.Oprator.ToString() + " or UserOut=" + this.Oprator.ToString() + ") and MarketCode=" + this.Market.ToString()+" and GateAmount="+this.Gate.ToString());
                int Code = Convert.ToInt32(DB.Query_ExecutSacler());
                return Code;
            }
            catch (Exception ex)
            {

                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
