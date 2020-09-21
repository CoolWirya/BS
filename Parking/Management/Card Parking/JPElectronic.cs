using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    class JPElectronic: JParking
    {
        /// <summary>
        /// كد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره کارت پارکینگ
        /// </summary>
        public int CardId { get; set; }
        /// <summary>
        /// مبلغ شارژ
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// وضعيت انتقال
        ///  </summary>
        public Boolean Statustransfer { get; set; }
        /// <summary>
        /// تاريخ  اتمام اعتبار
        /// </summary>
        public DateTime DateExpire { get; set; }
        /// <summary>
        /// تاريخ ايجاد
        ///  </summary>
        public DateTime DateCreate { get; set; }
        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return Insert(DB);
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
      
        public static int UseKolAmount(int CodeCard)
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT     Sum(Amount)   FROM " + JTableNamesParking.Traffic + " WHERE     (PayStatus = 1) AND (IDCard = " + CodeCard.ToString() + ")");
                return Convert.ToInt32(DB.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;

            }
            finally
            {
                DB.Dispose();
            }


        }
        /// <summary>
        /// ليست غرفه هاي بازار
        /// </summary>
        public static System.Data.DataTable UseAmount(int CodeCard)
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT     Amount, TimeIn, DateIn, TimeOut, DateOut, DurationStayParking   FROM         PrkTraffic  WHERE     (PayStatus = 1) AND (IDCard = " + CodeCard + ")");
                return DB.Query_DataTable();
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
        /// <summary>
        /// ليست غرفه هاي بازار
        /// </summary>
        public static System.Data.DataTable GetListOfCharje(int CodeCard)
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT [Code] ,[Amount]," + JDataBase.SQLMiladiToShamsi("DateExpire", "'تاريخ اتمام اعتبار'") + "," + JDataBase.SQLMiladiToShamsi("DateCreate", "'تاريخ ثبت'") + " FROM [PrkElectronicCharje] Where CardId=" + CodeCard.ToString());
                return DB.Query_DataTable();
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
        public int Insert(JDataBase pDB)
        {
            try
            {
                if (JPermission.CheckPermission("Parking.JPElectronic.Insert"))
                {
                    JPElectronicTable JCPT = new JPElectronicTable();
                    JCPT.SetValueProperty(this);
                    Code = JCPT.Insert(pDB);
                    if (Code > 0)
                    {
                       
                    }
                    return Code;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }

        public bool Update()
        {
            if (JPermission.CheckPermission("Parking.JPElectronic.Update"))
            {
                JPElectronicTable JCPT = new JPElectronicTable();
                JCPT.SetValueProperty(this);
                return JCPT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JPElectronic.Delete"))
            {
                Code = pCode;
                JPElectronicTable JCPT = new JPElectronicTable();
                JCPT.SetValueProperty(this);
                if (JCPT.Delete())
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.PrkElectronic + " WHERE Code=" + pCode.ToString());
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
       
      
        public void ShowForm(int pCode)
        {
            if (pCode == 0)
            {
                SaveElectronicCharje JCPF = new SaveElectronicCharje(0);
                JCPF.State = JFormState.Insert;
                JCPF.ShowDialog();
            }
            else
            {
             
                SaveElectronicCharje JCPF = new SaveElectronicCharje(pCode);
                JCPF.State = JFormState.Update;
                JCPF.ShowDialog();
            }
        }

       
    }
}
