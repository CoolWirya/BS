using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice
{
    public class JRegisterDevices:ClassLibrary.JSystem
    {

        public static System.Data.DataTable GetDistinctDataTable(int pCode,string DistinctColumn)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDeivce.JRegisterDevices.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT Distinct "+DistinctColumn+",Count(Code) as count FROM AVLDevice";
                if (pCode > 0)
                    query += " where personCode=" + pCode;
                query += " group by " + DistinctColumn;
                DB.setQuery(query);
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

        public static System.Data.DataTable GetDataTable(int pCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDeivce.JRegisterDevices.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLDevice";
                if (pCode > 0)
                    query += " where personCode=" + pCode;
                // + " WHERE " + ClassLibrary.JPermission.getObjectSql("AVL.RegisterDeivce.JRegisterDevices.GetDataTable", "AVLRegisterDevice.Code");


                DB.setQuery(query);
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

        public static Int64 GetOneDayPrice(int pCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDeivce.JRegisterDevices.GetDataTable"))
                return 0;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT isnull(ADM.UnitPrice*(count(AD.Code)-1),0) FROM AVLDevice AD 
inner join AVLDeviceModel ADM on AD.DeviceType=ADM.Code
Inner join AVLJoinDevice j on j.parentDeviceCode=AD.Code ";
                if (pCode > 0)
                    query += " where AD.personCode=" + pCode;
                query += " group by UnitPrice,AD.Code";

                DB.setQuery(query);
                System.Data.DataTable dt = DB.Query_DataTable();
                if (dt != null && dt.Rows.Count == 1)
                    return Int64.Parse(dt.Rows[0][0].ToString());
                else
                    return 1;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static System.Data.DataTable GetAllJoinData(int deviceCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                //both
                string query = "";
                if (deviceCode != 0)
                    query = string.Format(@"select * from AVLDevice where code in (SELECT ad.Code  FROM AVLJoinDevice ajd inner join AVLDevice ad on (ad.Code =ajd.[parentDeviceCode] or ad.Code=ajd.childDeviceCode )where [childDeviceCode]={0} or [parentDeviceCode]={0})

", deviceCode);
                else
                    return null;
                DB.setQuery(query);
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
        public static System.Data.DataTable GetDataTable(bool checkpermission, string pParameters, int pCode = 0)
        {
            bool haspermission = true;
            if(checkpermission)
                haspermission=ClassLibrary.JPermission.CheckPermission("AVL.RegisterDeivce.JRegisterDevices.GetDataTable");
            if (!haspermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
			string parameters = "";
			try
			{
				parameters = pParameters;
			}
			catch { parameters = ""; }
            try
            {
                string query = string.Format(@"SELECT * FROM AVLDevice WHERE 1=1 {0} " , parameters);
                if (pCode > 0)
                    query += " AND personCode=" + pCode;
                // + " WHERE " + ClassLibrary.JPermission.getObjectSql("AVL.RegisterDeivce.JRegisterDevices.GetDataTable", "AVLRegisterDevice.Code");


                DB.setQuery(query);
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

        public static System.Data.DataTable GetUserAllDevices(string imei)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"SELECT *  FROM [AVLDB].[dbo].[AVLDevice] where personCode=(select top 1 personCode from AVLDevice WHERE IMEI='"+imei+"')");
                DB.setQuery(query);
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
}
