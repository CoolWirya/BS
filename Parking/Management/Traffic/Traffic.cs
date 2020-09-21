using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public  class JTraffic:JParking
    {

        string _error = "";

        #region property

        public int Code { get; set; }
        /// <summary>
        /// کدد مجتمع یا بازار
        /// </summary>
        public int MarketCode { get; set; }  
        /// <summary>
        /// عنوان گیت ورودی
        /// </summary>
        public int GateIn { get; set; }
        /// <summary>
        /// عنوان گیت خروجی
        /// </summary>
        public int GateOut { get; set; }
        /// <summary>
        /// شماره کارت
        /// </summary>
        public int IDCard { get; set; }
        /// <summary>
        /// گروه کارت
        /// </summary>
        public int GroupCard { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        ///شیفت ورودی
        /// </summary>
        public int ShiftIn { get; set; }
        /// <summary>
        /// تصویر ورود
        /// </summary>
        public string PicIn { get; set; }
        /// <summary>
        /// تاریخ ورود
        /// </summary>
        public DateTime DateIn { get; set; }
        /// <summary>
        ///ساعت ورود
        /// </summary>
        public string TimeIn { get; set; } 
        /// <summary>
        ///کاربر ورودی
        /// </summary>
        public int UserIn { get; set; }
        /// <summary>
        ///شیفت خروجی
        /// </summary>
        public int ShiftOut { get; set; }
        /// <summary>
        /// تاریخ خروج
        /// </summary>
        public DateTime DateOut { get; set; }
        /// <summary>
        ///ساعت خروج
        /// </summary>
        public string TimeOut { get; set; }
        /// <summary>
        /// کاربر خروجی
        /// </summary>
        public int UserOut { get; set; }
        /// <summary>
        /// مدت زمان حضور در پارکینگ
        /// </summary>
        public decimal DurationStayParking { get; set; }
        /// <summary>
        ///کد کنترل
        /// </summary>
        public int CodeControl { get; set; }
        /// <summary>
        ///گیتی که در آن مبلغ اخذ می گردد
        /// </summary>
        public int GateAmount { get; set; }
        /// <summary>
        ///نحوه پرداخت
        /// </summary>
        public int PayStatus { get; set; }
        

        #endregion Property

        #region Method

        private List<string> Feild = new List<string>();
        private List<string> Value = new List<string>();

        public enum ParkingEnum
        {
            Input=1,
            OutPut=2,
            InOut=3
        }

        /// <summary>
        /// تابع درج
        /// </summary>
        /// <param name="pFeild"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public int Insert(List<string> pFeild, List<string> pValue, string otherQuery)
        {
            string sF="", sV="";
            bool flag = true;
            foreach (string sFeild in pFeild)
            {
                if (flag)
                {
                    sF = sF + sFeild;
                    flag = false;
                }
                else
                    sF = sF+","+sFeild;
            }

            flag = true;
            foreach (string sValue in pValue)
            {
                if (flag)
                {
                    sV = sV + "'" + sValue + "'";
                    flag = false;
                }
                else
                    sV = sV + ",'" + sValue+"'";
            }
            
            JDataBase DB = new JDataBase();
            try
            {
                DB.beginTransaction("t1");
                DB.setQuery("DECLARE @Code INT " +
                    " SET @Code = ISNULL((SELECT MAX(Code) FROM " + JTableNamesParking.Traffic + "),0)+1 " +
                    " insert into " + JTableNamesParking.Traffic + " (" + sF + " ,Code )" + " Values(" + sV + ",@Code" + ") " +
                    " \r\n"+ otherQuery+
                    " SELECT @Code");
                int res=Convert.ToInt32(DB.Query_ExecutSacler());
                DB.Commit();
                return res;

            }
            catch
            {
                DB.Rollback("t1");
            }
            finally
            {
                DB.Dispose();
            }
            return 0;
            
        }
         
        /// <summary>
        /// تابع ویرایش
        /// </summary>
        /// <param name="pFeild"></param>
        /// <param name="pValue"></param>
        /// <param name="NumberOfFeild"></param>
        /// <param name="_Where"></param>
        /// <returns></returns>
        public int Update(List<string> pFeild, List<string> pValue,int NumberOfFeild,string _Where,string otherQuery)
        {
            string Feild_Value = "";

            for (int i = 0; i <= NumberOfFeild-1; i++)
            {
                if (i == NumberOfFeild - 1)
                    Feild_Value = Feild_Value + pFeild[i] + "='" + pValue[i] + "'";
                else
                    Feild_Value = Feild_Value + pFeild[i] + "='" + pValue[i] + "',";
            }
            JDataBase DB = new JDataBase();
            try
            {
                int result;
                DB.beginTransaction("t2");
                DB.setQuery("UPDATE " + JTableNamesParking.Traffic +
                                " SET " + Feild_Value +
                                " Where " + _Where +"\r\n"+ otherQuery);
                result = DB.Query_Execute();
                DB.Commit();
                if (result != -1)
                {
                    return 1;
                }
            }
            catch
            {
                DB.Rollback("t2");
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
            return 0;
        }

        private bool Validation(int _CardParking, ref int _ElectronicWallet, ref string _Message)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT *  FROM " + JTableNamesParking.CardParking + " where IDCardParking=" + JDataBase.Quote(_CardParking.ToString()));
                DB.Query_DataSet();

                int EndContratcDate = String.Compare(Convert.ToDateTime(DB.DataSet.Tables[0].Rows[0]["EndDateContract"]).ToString("yyyy/MM/dd"), DB.GetCurrentDateTime().ToString("yyyy/MM/dd"));
                int CardExpiryDate = String.Compare(Convert.ToDateTime(DB.DataSet.Tables[0].Rows[0]["DateExpire"]).ToString("yyyy/MM/dd"), DB.GetCurrentDateTime().ToString("yyyy/MM/dd"));
                int Status = Convert.ToInt32(DB.DataSet.Tables[0].Rows[0]["StatusCard"]);
                int ElectronicWallet = Convert.ToInt32(DB.DataSet.Tables[0].Rows[0]["ElectronicPay"]);


                if ( (EndContratcDate == 0 || EndContratcDate > 0) && (CardExpiryDate == 0 || CardExpiryDate > 0) && Status==1)
                {
                    _ElectronicWallet = ElectronicWallet;
                    return true;
                }
                else
                {
                    _Message = "تاریخ قرارداد و یا انقضا کارت فرا رسیده . یا کارت غیر فعال می باشد";
                    return false;
                }

            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// تابع اصلی جهت انجام عملیات
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public int Operations(int flag,ref string _error)
        {
            JDataBase DB = new JDataBase();
            int retCode;
            string otherQuery = "";

            try
            {
                // کارت در وضعیت ورودی قرار دارد
                if (flag == (int)ParkingEnum.Input)
                {
                    Feild.Clear();
                    Value.Clear();

                    #region SetFeild
                    Feild.Add("[MarketCode]");
                    Value.Add(MarketCode.ToString());
                    Feild.Add("[GateIn]");
                    Value.Add(GateIn.ToString());
                    Feild.Add("[IDCard]");
                    Value.Add(IDCard.ToString());
                    Feild.Add("[GroupCard]");
                    Value.Add(GroupCard.ToString());
                    Feild.Add("[PicIn]");
                    Value.Add(PicIn.ToString());
                    Feild.Add("[DateIn]");
                    Value.Add(DateIn.ToString("yyyy/MM/dd"));
                    Feild.Add("[TimeIn]");
                    Value.Add(TimeIn.ToString());
                    Feild.Add("[UserIn]");
                    Value.Add(UserIn.ToString());
                    Feild.Add("[ShiftIn]");
                    Value.Add(ShiftIn.ToString());
                    Feild.Add("[CodeControl]");
                    Value.Add(CodeControl.ToString());
                    #endregion SetFeild

                    return Insert(Feild, Value,otherQuery);
                }

                string _query = " IDCard='" + IDCard.ToString() + "' and Datein='" + DB.GetCurrentDateTime().ToString("yyyy/MM/dd") + "' and Amount is null";
                bool state;

                // کارت در وضعیت خروجی قرار دارد
                if (flag == (int)ParkingEnum.OutPut)
                {
                    //
                    retCode = ReturnTrafficQuery(_query, "count(*)"); ;
                    // یعنی زمانی که این کارت ورودی ندارد ولی اطلاعات در کارت موجود است
                    if (retCode == 0 && ReadDataFromCard())
                    {
                        Feild.Clear();
                        Value.Clear();

                        #region SetFeild
                        Feild.Add("[MarketCode]");
                        Value.Add(MarketCode.ToString());
                        Feild.Add("[GateIn]");
                        Value.Add(GateIn.ToString());
                        Feild.Add("[GateOut]");
                        Value.Add(GateOut.ToString());
                        Feild.Add("[IDCard]");
                        Value.Add(IDCard.ToString());
                        Feild.Add("[GroupCard]");
                        Value.Add(GroupCard.ToString());
                        Feild.Add("[Amount]");
                        Value.Add(Amount.ToString());
                        Feild.Add("[PicIn]");
                        Value.Add(PicIn.ToString());
                        Feild.Add("[DateIn]");
                        Value.Add(DateIn.ToString("yyyy/MM/dd"));
                        Feild.Add("[TimeIn]");
                        Value.Add(TimeIn.ToString());
                        Feild.Add("[UserIn]");
                        Value.Add(UserIn.ToString());
                        Feild.Add("[DateOut]");
                        Value.Add(DateOut.ToString("yyyy/MM/dd"));
                        Feild.Add("[TimeOut]");
                        Feild.Add("[ShiftIn]");
                        Value.Add(ShiftIn.ToString());
                        Feild.Add("[ShiftOut]");
                        Value.Add(ShiftOut.ToString());
                        Value.Add(TimeOut.ToString());
                        Feild.Add("[DurationStayParking]");
                        Value.Add(DurationStayParking.ToString());
                        Feild.Add("[CodeControl]");
                        Value.Add(CodeControl.ToString());
                        #endregion SetFeild

                        return Insert(Feild, Value,otherQuery);
                       
                    }
                    
                    //  یعنی کارت ورودی ندارد و اطلاعات در کارت هم موجود نیست ولی اطلاعات توسط اپراتور وارد می شود
                    else if (retCode == 0 && !ReadDataFromCard())
                    {
                        JTrafficManualForm JTMF = new JTrafficManualForm(this, 1);
                        JTMF.ShowDialog();

                        Feild.Clear();
                        Value.Clear();

                        int day = 0, hour = 0, minute = 0, _PStatus = 0, _AmountRecive = 0;
                        state=CalculatedForPresence(DateIn, DateOut, TimeIn, TimeOut, ref day, ref hour, ref minute);
                        if (state==false)
                        {
                            _error = "ساعت ورودی نمی تواند از ساعت خروجی بزرگتر باشد";
                            return 0;
                        }
                        Amount = CalculationAmount(day, hour, minute, GroupCard, Properties.Settings.Default.Complex, ref _PStatus, ref _AmountRecive);
                        DurationStayParking = (day * 12 * 60) + (hour * 60) + minute;

                        if (_PStatus == 1)
                        {
                            //JMessages.Error("نحوه پرداخت الکترونیک می باشد", "خطا");
                            string _Message = "";
                            int _ElectronicWallet = 0;
                            if (Validation(IDCard, ref _ElectronicWallet, ref _Message))
                            {
                                if (_ElectronicWallet >= Amount)
                                {
                                    //پرداخت بوسیله کیف پول الکترونیک
                                    PayStatus = 1;
                                    Feild.Add("[PayStatus]");
                                    Value.Add(PayStatus.ToString());

                                    otherQuery = "UPDATE " + JTableNamesParking.CardParking +
                                                    " SET [ElectronicPay] = " + JDataBase.Quote((_ElectronicWallet - (int)Amount).ToString()) +
                                                    " where [IDCardParking]=" + JDataBase.Quote(IDCard.ToString());
                                }
                                else
                                {
                                    //پرداخت  نقدی
                                    PayStatus = 0;
                                    Feild.Add("[PayStatus]");
                                    Value.Add(PayStatus.ToString());
                                    _error = "بدلیل کافی نبودن موجودی کیف پول الکترونیک مبلغ به صورت نقدی محاسبه گردید";
                                }
                            }
                            else
                            {
                                // ارسال پیغام خطا
                                _error = _Message;
                                return 0;
                            }
                        }

                        //if (GateForm.TypeGate(Properties.Settings.Default.Gate) == _AmountRecive)
                        //{
                        //    Feild.Add("[GateAmount]");
                        //    Value.Add(_AmountRecive.ToString());
                        //}

                        #region SetFeild
                        Feild.Add("[MarketCode]");
                        Value.Add(MarketCode.ToString());
                        Feild.Add("[GateOut]");
                        Value.Add(GateOut.ToString());
                        Feild.Add("[IDCard]");
                        Value.Add(IDCard.ToString());
                        Feild.Add("[GroupCard]");
                        Value.Add(GroupCard.ToString());
                        Feild.Add("[Amount]");
                        Value.Add(Amount.ToString());
                        Feild.Add("[DateIn]");
                        Value.Add(DateIn.ToString("yyyy/MM/dd"));
                        Feild.Add("[TimeIn]");
                        Value.Add(TimeIn.ToString());
                        Feild.Add("[DateOut]");
                        Value.Add(DateOut.ToString("yyyy/MM/dd"));
                        Feild.Add("[TimeOut]");
                        Value.Add(TimeOut.ToString());
                        Feild.Add("[UserOut]");
                        Value.Add(UserOut.ToString());
                        Feild.Add("[DurationStayParking]");
                        Value.Add(DurationStayParking.ToString());
                        Feild.Add("[CodeControl]");
                        Value.Add(CodeControl.ToString());
                        #endregion SetFeild

                        return Insert(Feild, Value,otherQuery);
                    }

                    
                    // دراین حالت ورودی دارد و باید خروجی ان درج گردد
                    if(retCode==1)
                    {
                        Feild.Clear();
                        Value.Clear();

                        int tCode = ReturnTrafficQuery(_query, "Max(Code)");
                        DB.setQuery("select DateIn,TimeIn from " + JTableNamesParking.Traffic + " where Code='" + tCode.ToString() + "'");
                        DB.Query_DataSet();

                        DateIn = Convert.ToDateTime(DB.DataSet.Tables[0].Rows[0]["DateIn"]);
                        TimeIn = (DB.DataSet.Tables[0].Rows[0]["TimeIn"]).ToString();
                        int day=0, hour=0, minute=0,_PStatus=0,_AmountRecive=0;
                        state=CalculatedForPresence(DateIn, DateOut, TimeIn, TimeOut,ref day,ref hour,ref minute);
                        if (!state)
                        {
                            _error = "ساعت ورودی نمی تواند از ساعت خروجی بزرگتر باشد";
                            return 0;
                        }
                        Amount = CalculationAmount(day, hour, minute, GroupCard, Properties.Settings.Default.Complex, ref _PStatus,ref _AmountRecive);
                        DurationStayParking = (day * 12 * 60) + (hour * 60) + minute;

                        if (_PStatus == 1)
                        {
                            //JMessages.Error("نحوه پرداخت الکترونیک می باشد", "خطا");
                            string _Message="";
                            int _ElectronicWallet=0;
                            if (Validation(IDCard, ref _ElectronicWallet,ref _Message))
                            {
                                if (_ElectronicWallet >= Amount)
                                {
                                    //پرداخت بوسیله کیف پول الکترونیک
                                    PayStatus = 1;
                                    Feild.Add("[PayStatus]");
                                    Value.Add(PayStatus.ToString());

                                    otherQuery = "UPDATE " + JTableNamesParking.CardParking +
                                                    " SET [ElectronicPay] = " + JDataBase.Quote( (_ElectronicWallet-(int)Amount).ToString()) +
                                                    " where [IDCardParking]=" + JDataBase.Quote(IDCard.ToString());
                                }
                                else
                                {
                                    //پرداخت  نقدی
                                    PayStatus = 0;
                                    Feild.Add("[PayStatus]");
                                    Value.Add(PayStatus.ToString());
                                    // ارسال پیغام خطا
                                    _error = _Message;
                                }
                            }
                        }

                        //if (GateForm.TypeGate(Properties.Settings.Default.Gate) == _AmountRecive)
                        //{
                        //    Feild.Add("[GateAmount]");
                        //    Value.Add(_AmountRecive.ToString());
                        //}

                        #region SetFeild

                        Feild.Add("[GateOut]");
                        Value.Add(GateOut.ToString());
                        Feild.Add("[Amount]");
                        Value.Add(Amount.ToString());
                        Feild.Add("[DateOut]");
                        Value.Add(DateOut.ToString("yyyy/MM/dd"));
                        Feild.Add("[TimeOut]");
                        Value.Add(TimeOut.ToString());
                        Feild.Add("[UserOut]");
                        Value.Add(UserOut.ToString());
                        Feild.Add("[ShiftOut]");
                        Value.Add(ShiftOut.ToString());
                        Feild.Add("[DurationStayParking]");
                        Value.Add(DurationStayParking.ToString());
                        Feild.Add("[CodeControl]");
                        Value.Add(CodeControl.ToString());

                        #endregion SetFeild


                        int result = Update(Feild, Value, 7, _query, otherQuery);
                        if (result != -1)
                        {
                            return tCode;
                        }
                        else
                            return -1;
                            
                    }
                    // در این حالت چند خروجی دارد که باید اخرین مورد بسته شود
                    if (retCode > 1)
                    {
                        int tCode = ReturnTrafficQuery(_query, "Max(Code)");

                        Feild.Clear();
                        Value.Clear();

                        DB.setQuery("select DateIn,TimeIn from " + JTableNamesParking.Traffic + " where Code='" + tCode.ToString() + "'");
                        DB.Query_DataSet();

                        DateIn = Convert.ToDateTime(DB.DataSet.Tables[0].Rows[0]["DateIn"]);
                        TimeIn = (DB.DataSet.Tables[0].Rows[0]["TimeIn"]).ToString();
                        int day = 0, hour = 0, minute = 0, _PStatus = 0, _AmountRecive = 0;
                        state=CalculatedForPresence(DateIn, DateOut, TimeIn, TimeOut, ref day, ref hour, ref minute);
                        if (!state)
                        {
                            _error = "ساعت ورودی نمی تواند از ساعت خروجی بزرگتر باشد";
                            return 0;
                        }
                        DurationStayParking = (day * 12 * 60) + (hour * 60) + minute;
                        Amount = CalculationAmount(day, hour, minute, GroupCard, Properties.Settings.Default.Complex, ref _PStatus, ref  _AmountRecive);

                        if (_PStatus == 1)
                        {
                            //JMessages.Error("نحوه پرداخت الکترونیک می باشد", "خطا");
                            string _Message = "";
                            int _ElectronicWallet = 0;
                            if (Validation(IDCard, ref _ElectronicWallet, ref _Message))
                            {
                                if (_ElectronicWallet >= Amount)
                                {
                                    //پرداخت بوسیله کیف پول الکترونیک
                                    PayStatus = 1;
                                    Feild.Add("[PayStatus]");
                                    Value.Add(PayStatus.ToString());

                                    otherQuery = "UPDATE " + JTableNamesParking.CardParking +
                                                    " SET [ElectronicPay] = " + JDataBase.Quote((_ElectronicWallet - (int)Amount).ToString()) +
                                                    " where [IDCardParking]=" + JDataBase.Quote(IDCard.ToString());
                                }
                                else
                                {
                                    //پرداخت  نقدی
                                    PayStatus = 0;
                                    Feild.Add("[PayStatus]");
                                    Value.Add(PayStatus.ToString());
                                }
                            }
                        }

                        //if (GateForm.TypeGate(Properties.Settings.Default.Gate) == _AmountRecive)
                        //{
                        //    Feild.Add("[GateAmount]");
                        //    Value.Add(_AmountRecive.ToString());
                        //}
                        #region SetFeild

                        Feild.Add("[Amount]");
                        Value.Add(Amount.ToString());
                        Feild.Add("[DateOut]");
                        Value.Add(DateOut.ToString("yyyy/MM/dd"));
                        Feild.Add("[TimeOut]");
                        Value.Add(TimeOut.ToString());
                        Feild.Add("[UserOut]");
                        Value.Add(UserOut.ToString());
                        Feild.Add("[ShiftOut]");
                        Value.Add(ShiftOut.ToString());
                        Feild.Add("[DurationStayParking]");
                        Value.Add(DurationStayParking.ToString());
                        Feild.Add("[CodeControl]");
                        Value.Add(CodeControl.ToString());

                        #endregion SetFeild

                        string _qury=" Code='" +tCode.ToString()+"'";
                        int result = Update(Feild, Value, 7, _qury, otherQuery);
                        if (result != -1)
                        {
                            return tCode;
                        }
                        else
                            return -1;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// عملیات درج براساس شماره واحد تجاری
        /// </summary>
        /// <param name="pNumber"></param>
        /// <returns></returns>
        public int InsertManualByNumber(int pNumber)
        {
        //    JDataBase db =new JDataBase();
            
        //    int CardNo=GetIdCardParking(pNumber);

        //    // ورودی
        //    if (JTrafficForm.TypeGate == (int)ParkingEnum.Input)
        //    {
        //        if (CardNo != 0)
        //        {
        //            MarketCode = Properties.Settings.Default.Complex;
        //            GateIn = Properties.Settings.Default.Gate;
        //            IDCard = CardNo;
        //            GroupCard = GetGroupCard(IDCard);
        //            PicIn = "NotSet";
        //            DateIn = db.GetCurrentDateTime().Date;
        //            TimeIn = db.GetCurrentDateTime().ToString("HH:mm");
        //            UserIn = JMainFrame.CurrentUserCode;
        //            ShiftIn = JBaseShift.GetShiftOfTime();
        //            CodeControl = 100;

        //            int res = Operations((int)ParkingEnum.Input,ref _error);
        //            if (res != 0)
        //            {
        //                JMessages.Error("عملیات با موفقیت انجام شد", "Error");
        //                return res;
        //            }
        //            return res;
        //        }
        //    }
        //    // خروجی
        //    if (JTrafficForm.TypeGate == (int)ParkingEnum.OutPut)
        //    {
        //        if (CardNo != 0)
        //        {
        //            MarketCode = Properties.Settings.Default.Complex;
        //            GateOut = Properties.Settings.Default.Gate;
        //            IDCard = CardNo;
        //            GroupCard = GetGroupCard(IDCard);
        //            DateOut = db.GetCurrentDateTime().Date;
        //            TimeOut = db.GetCurrentDateTime().ToString("HH:mm");
        //            UserOut = JMainFrame.CurrentUserCode;
        //            ShiftOut = JBaseShift.GetShiftOfTime();
        //            CodeControl = 100;

        //            int res = Operations((int)ParkingEnum.OutPut,ref _error);
        //            if (res != 0)
        //            {
        //                JMessages.Error("عملیات با موفقیت انجام شد", "Error");
        //                return res;
        //            }
        //            return res;
        //        }
        //    }
        //    return 0;
        //}

        ///// <summary>
        ///// عملیات درج بر اساس شماره کارت پارکینگ
        ///// </summary>
        ///// <param name="pCardParking"></param>
        ///// <returns></returns>
        //public int InsertManualByParkingCard(int pCardParking,ref string _pError)
        //{
        //    JDataBase db = new JDataBase();

        //    // ورودی
        //    if (JTrafficForm.TypeGate == (int)ParkingEnum.Input)
        //    {
        //        if (pCardParking != 0)
        //        {
        //            MarketCode = Properties.Settings.Default.Complex;
        //            GateIn = Properties.Settings.Default.Gate;
        //            IDCard = pCardParking;
        //            GroupCard = GetGroupCard(pCardParking);
        //            PicIn = "NotSet";
        //            DateIn = db.GetCurrentDateTime().Date;
        //            TimeIn = db.GetCurrentDateTime().ToString("HH:mm");
        //            UserIn = JMainFrame.CurrentUserCode;
        //            ShiftIn = JBaseShift.GetShiftOfTime();

                    
        //            CodeControl = 100;
                    
                   
        //            int res = Operations((int)ParkingEnum.Input,ref _error);
                    
        //            if (res != 0)
        //            {
        //                //JMessages.Error("عملیات با موفقیت انجام شد", "Error");
        //                return res;
        //            }
        //            return res;
        //        }
        //    }
        //    // خروجی
        //    if (JTrafficForm.TypeGate == (int)ParkingEnum.OutPut)
        //    {
        //        if (pCardParking != 0)
        //        {
        //            MarketCode = Properties.Settings.Default.Complex;
        //            GateOut = Properties.Settings.Default.Gate;
        //            IDCard = pCardParking;
        //            GroupCard = GetGroupCard(pCardParking);
        //            DateOut = db.GetCurrentDateTime().Date;
        //            TimeOut = db.GetCurrentDateTime().ToString("HH:mm");
        //            UserOut = JMainFrame.CurrentUserCode;
        //            ShiftOut = JBaseShift.GetShiftOfTime();
        //            CodeControl = 100;

        //            int res = Operations((int)ParkingEnum.OutPut,ref _error);
        //            if (res != 0)
        //            {
        //                // ارسال پیغام خطا
        //                _pError = _error;

        //                return res;
        //            }
        //            // ارسال پیغام خطا
        //            _pError = _error;
        //            return res;
        //        }
        //    }
            return 0;
        }

        /// <summary>
        /// جستجو گروه براساس شماره واحد تجاری
        /// </summary>
        /// <param name="pNumber"></param>
        /// <returns></returns>
        public int GetIdCardParking(int pNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                int IdCard;
                DB.setQuery("SELECT IDCardParking FROM " + JTableNamesParking.CardParking + " WHERE StatusSave =0 and Number=" + pNumber.ToString());
                IdCard= Convert.ToInt32(DB.Query_ExecutSacler());
                return IdCard;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// جستجو گروه براساس شماره کارت پارکینگ
        /// </summary>
        /// <param name="pIDCard"></param>
        /// <returns></returns>
        public int GetGroupCard(int pIDCard)
        {
            JDataBase DB = new JDataBase();
            try
            {
                int GrCard;
                DB.setQuery("SELECT GroupCard FROM " + JTableNamesParking.ParkingMarket + " WHERE Publish=1 and CardNumber=" + pIDCard.ToString());
                GrCard = Convert.ToInt32(DB.Query_ExecutSacler());
                return GrCard;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Traffic + " WHERE Code=" + pCode.ToString());
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

        public JTraffic()
        {
        }

        public JTraffic(int PCode)
        {
            this.GetData(PCode);
        }

        /// <summary>
        /// تابع بازیابی اطلاعات از جدول ترافیک
        /// </summary>
        public int ReturnTrafficQuery(string _query,string ret)
        {
            JDataBase db = new JDataBase();

            try
            {
                db.setQuery("Select "+ ret + " from " + JTableNamesParking.Traffic + " Where "+_query);
                return Convert.ToInt32(db.Query_ExecutSacler());
            }
            catch
            {
                
            }

            finally
            {
                db.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// تابع محاسبه مدت زمان حضور در پارکینگ
        /// </summary>
        public Boolean CalculatedForPresence(DateTime _DateIn, DateTime _DateOut, string _TimeIn, string _TimeOut,ref int _day,ref int _hour,ref int _minute)
        {
            string Din,Dout;
            //int res,rin,rout;
            Din = _DateIn.Date.ToString();
            Dout = _DateOut.Date.ToString();
            
            int Result = string.Compare(Din, Dout);
            if (Result == 0)
            {
                DateTime Tin, Tout;
                Tin = Convert.ToDateTime(_TimeIn);
                Tout = Convert.ToDateTime(_TimeOut);
                TimeSpan span = Tout.Subtract(Tin);
                _day = span.Days;
                _hour = span.Hours;
                _minute = span.Minutes;

                // یعنی ساعت ورودی بزرگتر از خروجی است
                if ((_hour < 0) || (_minute < 0) || (_day < 0) )
                    return false;

                return true;
            }
            else if (Result > 0)
            {
                // این حالت وچود ندارد
                return false;
            }
            else if(Result < 0)
            {
                DateTime Tin, Tout;
                Tin = Convert.ToDateTime(_TimeIn);
                Tout = Convert.ToDateTime(_TimeOut);
                
                TimeSpan span1 = Tout.Subtract(Tin);
                _hour = span1.Hours;
                _minute = span1.Minutes;

                TimeSpan span = _DateIn.Date.Subtract(_DateOut.Date);
                _day = span.Days;

                // یعنی ساعت ورودی بزرگتر از خروجی است
                if ((_hour < 0) || (_minute < 0) || (_day < 0))
                    return false;

                return true;
            }
            return false;
        }

        /// <summary>
        /// محاسبه مبلغ
        /// </summary>
        public decimal CalculationAmount(int _day, int _hour, int _minute, int GroupCard, int MarketCode, ref int _PayStatus, ref int _AmountReceived)
        {
            string _TypeGroup="";
            decimal _FirstAmount,_SecondAmount;
            int _Offers, _Round, _Abate, _Count;
            decimal _Amount;
            Boolean _PayByMinute;

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select * from " + JTableNamesParking.GroupCard + " where Code='" + GroupCard.ToString() + "' and MarketCode='" + MarketCode.ToString() + "'");
                db.Query_DataSet();

                // عنوان گروه
                _TypeGroup = db.DataSet.Tables[0].Rows[0]["TypeGroup"].ToString();
                // مبلغ اولیه
                _FirstAmount = Convert.ToDecimal(db.DataSet.Tables[0].Rows[0]["FirstAmount"]);
                // مبلغ ساعت اول به بعد
                _SecondAmount = Convert.ToDecimal(db.DataSet.Tables[0].Rows[0]["SecondAmount"]);
                // اخذ مبلغ در
                _AmountReceived = Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["AmountReceived"]);
                // میزان دقیقه رایگان
                _Offers = Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["Offers"]);
                // تعداد ارقامی که رند شود
                _Round = Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["Round"]);
                // تخفیف
                _Abate = Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["Abate"]);
                // تعداد دفعات ورود
                _Count = Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["Count"]);
                // مبنای محاسبه بر اساس دقیقه
                _PayByMinute = Convert.ToBoolean(db.DataSet.Tables[0].Rows[0]["PayByMinute"]);
                // نحوه پرداخت
                _PayStatus = Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["PayIsElectronic"]);
               
               
           

            // محاسبه افر
            if (_Offers > 0)
            {
                if (_minute >= _Offers)
                {
                    _minute -= _Offers;
                }
                else if (_minute <= _Offers)
                {
                    if (_hour >= 1)
                    {
                        _hour -= 1;
                        _minute = (_minute + 60) - _Offers;
                    }
                    else
                    {
                        if(_day>=0)
                        {
                            _hour+=23;
                            _minute = (_minute + 60) - _Offers;
                        }
                        else
                        // میزان کارکرد ار افر کمتر است
                        return 0;
                    }
                }
            }



            // محاسبه مبلغ
            // دقیقه ای
            if (_PayByMinute == true)
            {
                _Amount = _FirstAmount + ((_hour - 1) * _SecondAmount);
                if(_minute>0)
                    _Amount += (_SecondAmount*_minute)/60;
            }
            // ساعتی
            else
            {
                _Amount = _FirstAmount + ((_hour - 1) * _SecondAmount) + _SecondAmount ;
            }

            // اعمال تخفیف
            if (_Abate >= 0)
            {
                _Amount = _Amount - ((_Amount * _Abate) / 100);
            }

            // رند کردن مبلغ
            if (_Round >= 0 && _Amount.ToString().Length > _Round)
            {
                // برداشتن اعشار مبلغ
                _Amount = decimal.Truncate(_Amount);
                string str_Amount = _Amount.ToString();
                if (str_Amount.Length > _Round)
                {
                    str_Amount = str_Amount.Remove(str_Amount.Length - _Round, _Round);
                    for (int i = 1; i <= _Round; i++)
                    {
                        str_Amount = str_Amount + "0";
                    }

                    return Convert.ToDecimal(str_Amount);
                }
            }
            else
                // قابل رند کردن نیست
                return _Amount;
            }
            catch
            {
                return 0;

            }


            return 0;
        }

        /// <summary>
        /// تست برقراری ارتباط با دستگاه
        /// </summary>
        public Boolean TestCommunication()
        {
            return false;
        }

        /// <summary>
        /// خواندن اطلاعات از کارت
        /// </summary>
        /// <returns></returns>
        public Boolean ReadDataFromCard()
        {
            JDataBase db = new JDataBase();
            if (TestCommunication())
            {
                // باید چک شود که این اطلاعات در کارت موجود است و در صورت وجود فیلدهای کلاس پر شود
                if (true)
                {
                    IDCard = 1;
                    GroupCard = 1;
                    PicIn = "";
                    DateIn = DateTime.Now;
                    TimeIn = "1";
                    UserIn = 1;
                    GateIn = 1;
                    return true;
                }
                else
                    return false;
                
            }
            else
             return false;
        }

        public void ReplacePropertyData(JTraffic JT)
        {
            DateIn = JT.DateIn;
            TimeIn = JT.TimeIn;
        }

        /// <summary>
        /// نوع گیت به لحاظ ورودی و خروجی را بر می گرداند
        /// </summary>
        /// <param name="_Gate"></param>
        /// <returns></returns>
        public int ReturnTypeGate(int _Gate)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select TypeGate from " + JTableNamesParking.Gate + " where Code=" + JDataBase.Quote(_Gate.ToString()));
                db.Query_DataSet();
                return Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["TypeGate"]);
            }
            catch
            {

            }
            finally 
            {
                db.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// برگرداندن نام گروه
        /// </summary>
        /// <param name="_CodeGroup"></param>
        /// <returns></returns>
        public string ReturnGroupName(int _CodeGroup)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select * from " + JTableNamesParking.GroupCard + " where Code=" + JDataBase.Quote(_CodeGroup.ToString()));
                db.Query_DataSet();
                return (db.DataSet.Tables[0].Rows[0]["TypeGroup"]).ToString();
            }
            catch
            {

            }
            finally
            {
                db.Dispose();
            }
            return "0";
            
        }
   

        #endregion Method

    }

    public class JTraffics : JSystem
    {
        public void ListView()
        {
            //Nodes.Insert(JParkingStaticNodes._ShowTrafficFormNode());
        }
    }
   
}
