using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;
using Finance;

namespace RealEstate
{
    public class JAnnualRental : JRealEstate
    {
        #region Property

        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BuildingCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region سازنده

        public JAnnualRental()
        {
        }
        public JAnnualRental(int pCode)
        {
            Code = pCode;
            if (Code > 0)
                GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        public int Insert()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                return Insert(DB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {

            JAnnualRentalTable PDT = new JAnnualRentalTable();
            try
            {
                //if (!(JPermission.CheckPermission("RealEstate.JAnnualRental.Insert")))
                //    return -1;
                if (!Find())
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    return Code;
                }
                else
                {
                    JMessages.Message("نام مجتمع تکراری است", "خطا", JMessageType.Error);
                    return -2;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
            return 0;
        }
        /// <summary>
        ///بروزرسانی فقط مجتمع  
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JAnnualRentalTable PDT = new JAnnualRentalTable();
            try
            {
                //if (JPermission.CheckPermission("RealEstate.JAnnualRental.Update"))
                //{
                PDT.SetValueProperty(this);
                return PDT.Update();
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        public bool delete(int pBuildingCode, DateTime pStartDate)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                return delete(pBuildingCode, pStartDate, DB);
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
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(int pBuildingCode, DateTime pStartDate, JDataBase DB)
        {
            try
            {
                //if (JPermission.CheckPermission("RealEstate.JAnnualRental.Delete"))
                //{
                DB.setQuery("Delete FROM estAnnualRental WHERE BuildingCode = " + pBuildingCode + " And Cast(StartDate as Date)= '" + pStartDate.Date.ToString("yyyy/MM/dd") + "'");
                return DB.Query_Execute() >= 0;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                //DB.Dispose();
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            JAnnualRentalTable PDT = new JAnnualRentalTable();
            try
            {
                //if (JPermission.CheckPermission("RealEstate.JAnnualRental.Delete"))
                //{
                PDT.SetValueProperty(this);
                return PDT.Delete(pDB);
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM estAnnualRental WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Find()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM estAnnualRental WHERE Cast(StartDate as Date) <= '" + StartDate.Date.ToString("yyyy/MM/dd") + "'"
                    + " And Cast(enddate as Date) >= '" + StartDate.Date.ToString("yyyy/MM/dd") + "' And BuildingCode=" + BuildingCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        #endregion

        public static DataTable GetDataTable(int pBuildingCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" select Code,buildingCode,(select Fa_Date From StaticDates where StartDate=En_Date) StartDate, 
(select Fa_Date From StaticDates where EndDate=En_Date) EndDate ,price as priceAnnualRental,[Description]
from estAnnualRental Where BuildingCode=" + pBuildingCode);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pBuildingCode, DateTime pStartDate)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pStartDate.Date != DateTime.MinValue)
                    Where = " And Cast(StartDate as date) <= cast('" + pStartDate.ToString("yyyy/MM/dd") + "' as Date) And  Cast(EndDate as date) >= cast('" + pStartDate.ToString("yyyy/MM/dd") + "' as Date) ";
                Db.setQuery(@" select Code,buildingCode,(select Fa_Date From StaticDates where StartDate=En_Date) StartDate, 
(select Fa_Date From StaticDates where EndDate=En_Date) EndDate ,price as priceAnnualRental,[Description]
from estAnnualRental Where BuildingCode=" + pBuildingCode + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public void ShowDialog(int pBuildingCode)
        {
            if (!(JPermission.CheckPermission("RealEstate.JAnnualRental.ShowDialog")))
                return;
            JAnnualRentalForm PE = new JAnnualRentalForm(pBuildingCode);
            PE.State = JFormState.Insert;
            PE.ShowDialog();
        }

    }

    class JAnnualRentalTable : JTable
    {
        public JAnnualRentalTable()
            : base("estAnnualRental")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public int BuildingCode;
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// 
        /// </summary>
        public decimal Price;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
    }
}