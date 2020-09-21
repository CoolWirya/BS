using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebWarehouseManagement.Forms
{
    public class JBillOfGoods
    {
        public string WareHouseCode { get; set; }
        public bool Kind { get; set; }
        public string FromSerial { get; set; }
        public string ToSerial { get; set; }
        public string Count { get; set; }

        public string GetCountOfGoods()//string warehousecode, string kind, string fromserial, string toserial, string count)
        {
            //string warehousecode = string.Empty;
            DataTable dt = new DataTable();
            string Query = string.Empty;
            switch (Kind)
            {
                //Count
                case true:
                    if (string.IsNullOrEmpty(FromSerial))
                    {
                        Query = @" SELECT TOP " + Count + @" Serial FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode;
                        dt = WebClassLibrary.JWebDataBase.GetDataTable(Query);
                    }
                    else
                    {
                        Query = @" SELECT TOP " + Count + @" Serial FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode + " AND Serial >= " + FromSerial;
                        dt = WebClassLibrary.JWebDataBase.GetDataTable(Query);
                    }
                    break;
                case false:
                    if (string.IsNullOrEmpty(ToSerial) && !string.IsNullOrEmpty(Count) && !string.IsNullOrEmpty(FromSerial))
                    {
                        Query = @" SELECT TOP " + Count + @" Serial FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode + " AND Serial >= " + FromSerial;
                    }
                    else if (string.IsNullOrEmpty(ToSerial) && !string.IsNullOrEmpty(Count) && string.IsNullOrEmpty(FromSerial))
                    {
                        Query = @" SELECT TOP " + Count + @" Serial FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode;
                    }
                    else if (!string.IsNullOrEmpty(ToSerial) && string.IsNullOrEmpty(Count) && string.IsNullOrEmpty(FromSerial))
                    {
                        Query = @" SELECT  Count(*) AS Count , Serial  FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode + " AND Serial <= " + ToSerial + " ORDER BY  Serial ASC ";
                    }
                    else if (!string.IsNullOrEmpty(ToSerial) && string.IsNullOrEmpty(Count) && !string.IsNullOrEmpty(FromSerial))
                    {
                        Query = @" SELECT Count(*) AS Count  FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode + " AND Serial Between " + FromSerial + " AND " + ToSerial;
                    }
                    else if (string.IsNullOrEmpty(ToSerial) && string.IsNullOrEmpty(Count) && !string.IsNullOrEmpty(FromSerial))
                    {
                        Query = @" SELECT Count(*) ,Serial AS Count  FROM WarGoods  WG
													LEFT JOIN WarWarehouse WW ON(WW.Code = WG.WarehouseCode)
													WHERE WW.Code = " + WareHouseCode + " AND Serial >= " + FromSerial;
                    }
                    dt = WebClassLibrary.JWebDataBase.GetDataTable(Query);
                    break;
            }

            if (dt != null && dt.Rows.Count > 0)
                return "count:" + dt.Rows.Count + "?!?fromserial:" + dt.Rows[0]["Serial"].ToString() + "?!?toserial:" + dt.Rows[dt.Rows.Count - 1]["Serial"].ToString();
            return "undefined";
        }
    }
}