using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JSahamCity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return City;
        }
        public static string Query = " SELECT Code, "+JDataBase.ReplaceUnicodes("City") +"  FROM " + JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + JGlobal.MainFrame.GetConfig().CitiesTableName +" ORDER BY City ";
    }
    public class JSahamCities
    {
        public JSahamCity[] CityItems = new JSahamCity[0];
        public void GetData()
        {
            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
            try
            {
                DB.setQuery(JSahamCity.Query, false);
                if (DB.Query_DataReader())
                {
                    int i = 0;
                    while (DB.DataReader.Read())
                    {
                        JSahamCity city = new JSahamCity();
                        JTable.SetToClassProperty(city, DB.DataReader);
                        Array.Resize(ref CityItems, i + 1);
                        CityItems[i] = city;
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
