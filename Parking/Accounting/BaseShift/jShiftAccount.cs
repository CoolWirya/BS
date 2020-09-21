using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Parking
{
    class jShiftAccount:JParking
    {
        /// <summary>
        /// كد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// تاريخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// زمان
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// شيفت
        /// </summary>
        public int Shift { get; set; }
        /// <summary>
        /// كاربر
        /// </summary>
        public int UserManager { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// مجتمع ها
        /// </summary>
        public float Market { get; set; }
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

        public int Insert(JDataBase pDB)
        {
            try
            {
                if (JPermission.CheckPermission("Parking.JBaseShift.Insert"))
                {
                    jShiftAccounttable JGCT = new jShiftAccounttable();
                    JGCT.SetValueProperty(this);
                    Code = JGCT.Insert(pDB);
                    
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
            if (JPermission.CheckPermission("Parking.JBaseShift.Update"))
            {
                jShiftAccounttable JGCT = new jShiftAccounttable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JBaseShift.Delete"))
            {
                Code = pCode;
                jShiftAccounttable JGCT = new jShiftAccounttable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.prkdayshift + " WHERE Code=" + pCode.ToString());
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
    }
}
