using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JSharePrice : JSystem
    {
        #region constructor
        public JSharePrice()
        {
        }
        public JSharePrice(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region property
        /// <summary>
        ///  
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime ChangeDate { set; get; }
        /// <summary>
        ///    
        /// </summary>
        public decimal Price { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int CompanyCode { set; get; }

        #endregion

        public int insert()
        {
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            try
            {
                return insert(pDb);
            }
            finally
            {
                pDb.Dispose();
            }
        }

        #region Method
        public int insert(JDataBase pDb)
        {
            JSharePriceTable JPOT = new JSharePriceTable();
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
                if (Code > 0)
                    return Code;
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
                JPOT.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            //if (JPermission.CheckPermission("Employment.JEmployeeInfo.Delete"))
            //{
            if (JMessages.Question("آیا میخواهید گزینه انتخاب شده حذف شود؟", "حذف ") != System.Windows.Forms.DialogResult.Yes)
                return false;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JSharePriceTable PDT = new JSharePriceTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
                PDT.Dispose();
            }
            //}
            return false;
        }

        public bool Update(int pCompanyCode)
        {
            JSharePriceTable JPOT = new JSharePriceTable();
            try
            {
                JPOT.SetValueProperty(this);
                if (JPOT.Update())
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
            finally
            {
                JPOT.Dispose();
            }
        }

        #endregion

        public static DataTable GetDataTable(int pCode, int pCompanyCode)
        {
            string Where = " 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            if (pCompanyCode != 0)
                Where = Where + " And CompanyCode=" + pCompanyCode;

            string Query = @"select Code,
(select Fa_Date From StaticDates where EN_Date=ChangeDate) ChangeDate,Price,CompanyCode from SharePrice Where " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SharePrice where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public void ShowForm(int pCompanyCode)
        {
            JSharePriceForm LandForm = new JSharePriceForm(pCompanyCode);
            LandForm.State = JFormState.Insert;
            LandForm.ShowDialog();
        }
    }

    public class JSharePrices
    {
        public static DataTable LastSharePrice()
        {
            return LastSharePrice(1);
        }

        public static DataTable LastSharePrice(int pCount)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select TOP " + pCount + " * from SharePrice Order By ChangeDate DESC";
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }

    public class JSharePriceTable : JTable
    {
        public JSharePriceTable()
            : base("SharePrice")
        {
        }
        /// <summary>
        ///  
        /// </summary>
        public DateTime ChangeDate;
        /// <summary>
        ///    
        /// </summary>
        public decimal Price;
        /// <summary>
        ///  
        /// </summary>
        public int CompanyCode;
    }
}

