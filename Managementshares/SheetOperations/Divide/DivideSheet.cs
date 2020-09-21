using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JDivideSheet:JSystem
    {
        public int Code { get; set; }
        /// <summary>
        /// کد برگه
        /// </summary>
        public int SCode { get; set; }
        /// <summary>
        /// کد برگه ایجاد شده جدید
        /// </summary>
        public int NewCode { get; set; }
        /// <summary>
        /// تقسیم
        /// </summary>
        public bool IsDivide{ get; set; }
        /// <summary>
        /// تاریخ تقسیم
        /// </summary>
        public DateTime DJDate { get; set; }

        public JDivideSheet()
        {
        }

        public JDivideSheet(int pCode)
        {
            GetData(pCode);
        }

        public void GetData(int SCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT * From ShareDivideJoin WHERE Code = " + SCode);
                DataTable divide = db.Query_DataTable();
                if (divide.Rows.Count > 0)
                    JTable.SetToClassProperty(this, divide.Rows[0]);
            }
            finally
            {
                db.DisConnect();
            }
        }

        public int Insert(JDataBase pDB)
        {
            JDivideSheetTable divideTable = new JDivideSheetTable();
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JDivideSheet.Insert"))
                {
                    divideTable.SetValueProperty(this);
                    divideTable.Set_ComplexInsert(false);
                    Code = divideTable.Insert(pDB);
                    if (Code > 0)
                    {
                        return Code;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        public bool Update(JDataBase pDB)
        {
            JDivideSheetTable divideTable = new JDivideSheetTable();
            try
            {
                divideTable.SetValueProperty(this);
                return divideTable.Update(pDB);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //       Db.Dispose();
            }
        }
    }
}
