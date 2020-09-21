using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilChangeManagment.RequestChangeOfFuelTank
{
    /// <summary>
    /// درخواست تغییر سوخت مخزن
    /// </summary>
    public class JRequestChangeOfFuelTank
    {
        public int Code { get; set; }
        public DateTime RequestDate { get; set; }
        public int GazStationID { get; set; }
        public int FuleTankID { get; set; }
        /// <summary>
        /// نوع سوخت
        /// </summary>
        public int TypeOfProductID { get; set; }

        public int Insert()
        {
            JRequestChangeOfFuelTankTable RC = new JRequestChangeOfFuelTankTable();
            RC.SetValueProperty(this);
            return RC.Insert();
        }

        public bool Update()
        {
            JRequestChangeOfFuelTankTable RC = new JRequestChangeOfFuelTankTable();
            RC.SetValueProperty(this);
            return RC.Update();
        }

        public bool Delete()
        {
            JRequestChangeOfFuelTankTable RC = new JRequestChangeOfFuelTankTable();
            RC.SetValueProperty(this);
            return RC.Delete();
        }

        public static bool Find(int pCode)
        {
            JRequestChangeOfFuelTankTable RC = new JRequestChangeOfFuelTankTable();
            return RC.Find(pCode);
        }


        public bool GetData(int pCode)
        {
            JRequestChangeOfFuelTankTable RC = new JRequestChangeOfFuelTankTable();
            return RC.GetData(this, pCode);
        }
    }

    public class JRequestChangeOfFuelTanks
    {
        public String GetWebQuery()
        {
            string SQL = @"select * from RequestChangeOfFuelTank";
            return SQL;
        }

        
        public System.Data.DataTable GetDataTable()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(GetWebQuery());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }

    public class JRequestChangeOfFuelTankTable : ClassLibrary.JTable
    {
        public DateTime RequestDate;
        public int GazStationID;
        public int FuleTankID;
        /// <summary>
        /// نوع سوخت
        /// </summary>
        public int TypeOfProductID;

        public JRequestChangeOfFuelTankTable()
            : base("RequestChangeOfFuelTank")
        {
        }
    }
}
