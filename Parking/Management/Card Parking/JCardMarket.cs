using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
  public  class JCardMarket :JParking
    {
        /// <summary>
        /// كد كارت
        /// </summary>
        public int Code { get; set; }
       /// <summary>
       /// شماره كارت
       /// </summary>
        public int ID_Card { get; set; }
       /// <summary>
       /// مجتمع/بازار
       /// </summary>
        public int MarketCode { get; set; }
       /// <summary>
       /// تاریخ انقضاء کارت
       /// </summary>
        public DateTime ExpireDate { get; set; }
       /// <summary>
       /// وضعیت کارت
       /// </summary>
        public int StatusCard { get; set; }
       /// <summary>
       /// فعال ،غير فعال
       /// </summary>
        public bool Publish { get; set; }
       /// <summary>
       /// گروه کارت
       /// </summary>
        public int GroupCard { get; set; }
        /// <summary>
        /// شماره كارت
        /// </summary>
        public int CardNumber { get; set; }
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
        /// <summary>
        /// ليست غرفه هاي بازار
        /// </summary>
        
        public int Insert(JDataBase pDB)
        {
            try
            {
                if (JPermission.CheckPermission("Parking.JCardMarket.Insert"))
                {
                    JCardMarketTable JCPT = new JCardMarketTable();
                    JCPT.SetValueProperty(this);
                    Code = JCPT.Insert(pDB);
                    if (Code > 0)
                    {
                        return Code;
                    }
                    else
                    {
                        return -1;
                    }
                   
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
            if (JPermission.CheckPermission("Parking.JCardMarket.Update"))
            {
                JCardMarketTable JCPT = new JCardMarketTable();
                JCPT.SetValueProperty(this);
                return JCPT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JCardMarket.Delete"))
            {
                Code = pCode;
                JCardMarketTable JCPT = new JCardMarketTable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.ParkingMarket + " WHERE Code=" + pCode.ToString());
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
        public bool GetDataByID(int IDCard)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.ParkingMarket + " WHERE ID_Card=" + IDCard.ToString());
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
        public int  FindMarketCard(int pCode,int MarketCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT Count(Code) FROM " + JTableNamesParking.ParkingMarket + " WHERE [ID_Card]=" + pCode.ToString() + "And  [MarketCode]=" + MarketCode.ToString());
                return Convert.ToInt32(DB.Query_ExecutSacler());

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
        public System.Data.DataTable GetMarketCard(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT    dbo.PrkMarketCard.Code, dbo.estMarket.Title, dbo.subdefine.name, dbo.PrkGroups.TypeGroup, dbo.PrkMarketCard.ExpireDate, dbo.PrkMarketCard.Publish " +
"FROM         dbo.PrkMarketCard INNER JOIN "+
                      "dbo.estMarket ON dbo.PrkMarketCard.MarketCode = dbo.estMarket.Code INNER JOIN "+
                      "dbo.subdefine ON dbo.PrkMarketCard.StatusCard = dbo.subdefine.Code LEFT OUTER JOIN "+
                      "dbo.PrkGroups ON dbo.PrkMarketCard.GroupCard = dbo.PrkGroups.Code "+
"WHERE     (dbo.PrkMarketCard.ID_Card = "+pCode.ToString()+")");
              return  DB.Query_DataTable();
                
            }

            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
