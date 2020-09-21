
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using SmartCards;
using TCCORFID;
using System.Threading;

namespace Parking
{
    public class JCardParking : JParking
    {
        #region Property

        public int Code { get; set; }
        /// <summary>
        /// شماره کارت پارکینگ
        /// </summary>
        public int IDCardParking { get; set; }
        
                  
        /// <summary>
        /// فعال غير فعال
        /// </summary>
        public bool StatusParking { get; set; }
        /// <summary>
        /// علت غير فعال بودن
        /// </summary>
        public int InactiveDue { get; set; }
        /// <summary>
        /// مبلغ شارژ الكترونيك
        /// </summary>
        public DateTime DateExpire { get; set; }
         /// <summary>
        /// تاريخ صدور
        /// </summary>
        public DateTime DateActive { get; set; }
        /// <summary>
        ///گروه كارت
        /// </summary>
        public int CodeGroup { get; set; }
        
        #endregion

        #region method

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
                if (JPermission.CheckPermission("Parking.JCardParking.Insert"))
                {
                    JCardParkingTable JCPT = new JCardParkingTable();
                    JCPT.SetValueProperty(this);
                    Code = JCPT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JCardParkings.GetDataTable(Code));
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
            if (JPermission.CheckPermission("Parking.JCardParking.Update"))
            {
                JCardParkingTable JCPT = new JCardParkingTable();
                JCPT.SetValueProperty(this);
                return JCPT.Update();
            }
            else
                return false;
        }
        public bool Update(bool Permit)
        {
           
                JCardParkingTable JCPT = new JCardParkingTable();
                JCPT.SetValueProperty(this);
                return JCPT.Update();
            
            
        }
        public bool Update(JDataBase jdb)
        {
            if (JPermission.CheckPermission("Parking.JCardParking.Update"))
            {
                JCardParkingTable JCPT = new JCardParkingTable();
                JCPT.SetValueProperty(this);
                return JCPT.Update(jdb);
            }
            else
                return false;
        }
        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JCardParking.Delete"))
            {
                Code = pCode;
                JCardParkingTable JCPT = new JCardParkingTable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.CardParking + " WHERE Code=" + pCode.ToString());
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
        /// <summary>
        ///گرفتن اطلاعات ركورد پاركينگ بر اساس شماره كارت الكترونيك
        /// </summary>
        public bool GetDataId(int IDCardParking)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.CardParking + " WHERE IDCardParking=" + IDCardParking.ToString());
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
        private DateTime PersianDateToDateTime(string pdate)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int year = Convert.ToInt32(pdate.Substring(0, 4));
            int month = Convert.ToInt32(pdate.Substring(5, 2));
            int day = Convert.ToInt32(pdate.Substring(8, 2));
            int hour, minute, second;
            hour = minute = second = 0;
            if (pdate.Length > 10)
            {
                hour = Convert.ToInt32(pdate.Substring(11, 2));
                minute = Convert.ToInt32(pdate.Substring(14, 2));
                if (pdate.Length > 16)
                    second = Convert.ToInt32(pdate.Substring(17, 2));
            }

            return pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        public Boolean UpdateSellerExpireDateinDb(string pCode,DateTime DtUpdate)
        {
            JDataBase jdbu = new JDataBase();
            try
            {
               

                    jdbu.setQuery("UPDATE SmElectronicCard SET  [DateExpire] ='" + DtUpdate.ToString("yyyy/MM/dd") + "'  WHERE Code=" + pCode);
                    int j = jdbu.Query_Execute();
                    if (j > 0) return true; else return false;
                
               
            }
            catch
            {

                return false;
            }
            finally
            {
                jdbu.Dispose();
            }
        }
      
        public System.Data.DataTable ShowparkingData(int IDCardParking,int Market)
        {
            TypeCard TypeCard;
            JElectronicCard El = new JElectronicCard();
            JDataBase Jdb = new JDataBase();
            try
            {
              
                   El.GetDataId(IDCardParking,Market);

                switch (El.TypeCard)
                {
                    case (int)TypeCard.Persons:
                        TypeCard = TypeCard.Persons;
                        Jdb.setQuery("SELECT     dbo.SmElectronicCard.Code, dbo.SmElectronicCard.IDCardParking, dbo.SmElectronicCard.DateExpire, dbo.SmElectronicCard.StatusCard,dbo.SmElectronicCard.Market, dbo.SmElectronicCard.TypeCard, dbo.PrkCardParking.Code AS CodeParking, "+
                      "dbo.PrkCardParking.DateExpire AS DateExpireParking, dbo.PrkCardParking.StatusParking, dbo.PrkCardParking.InactiveDue AS InactiveDueParking,dbo.PrkCardParking.DateActive AS ACtiveParkingService, dbo.PrkCardParking.CodeGroup, dbo.subdefine.name AS ParkingInactiveDue, "+
                      "subdefine_3.name AS ElInactiveDuo, dbo.SmElectronicCard.InactiveDue, dbo.SmPersonalCard.EndDateContract, dbo.SmPersonalCard.PersonalCode, "+
                      "dbo.SmPersonalCard.Post, dbo.SmPersonalCard.CodeBaseCard, dbo.SmPersonalCard.IdPerson, dbo.SmElectronicCard.DateActive, "+
                      "ISNULL(dbo.clsPerson.Name, '---') AS Name, ISNULL(dbo.clsPerson.Fam, '---') AS Fam, dbo.clsAllPerson.Code AS PersonnelCode, "+
                      "dbo.clsAllPerson.Name AS FullName  "+
                      "FROM         dbo.SmElectronicCard INNER JOIN "+
                      "dbo.subdefine AS subdefine_3 ON dbo.SmElectronicCard.InactiveDue = subdefine_3.Code INNER JOIN "+
                      "dbo.PrkCardParking INNER JOIN "+
                      "dbo.subdefine ON dbo.PrkCardParking.InactiveDue = dbo.subdefine.Code ON "+
                      "dbo.SmElectronicCard.Code = dbo.PrkCardParking.IDCardParking INNER JOIN "+
                      "dbo.SmPersonalCard ON dbo.SmElectronicCard.Code = dbo.SmPersonalCard.CodeBaseCard INNER JOIN "+
                      "dbo.clsAllPerson ON dbo.SmPersonalCard.IdPerson = dbo.clsAllPerson.Code LEFT OUTER JOIN "+
                      "dbo.clsPerson ON dbo.clsAllPerson.Code = dbo.clsPerson.Code  Where dbo.SmElectronicCard.IDCardParking='" + IDCardParking + "' and dbo.SmElectronicCard.Market='"+Market+"'");
                        break;
                    case (int)TypeCard.Custromers:
                        TypeCard = TypeCard.Custromers;
                        Jdb.setQuery("SELECT     dbo.SmElectronicCard.Code, dbo.SmElectronicCard.DateExpire, dbo.SmElectronicCard.StatusCard, dbo.SmElectronicCard.InactiveDue,dbo.SmElectronicCard.TypeCard, dbo.SmElectronicCard.IDCardParking, dbo.PrkCardParking.DateExpire AS DateExpireParking,dbo.PrkCardParking.StatusParking, dbo.PrkCardParking.InactiveDue AS InactiveDueParking, "+
                        "dbo.PrkCardParking.CodeGroup,dbo.SmCustromerCard.Code AS CodeCustromer, dbo.PrkCardParking.Code AS CodeParking, dbo.SmElectronicCard.Market,dbo.PrkCardParking.DateActive "+
"FROM         dbo.PrkCardParking INNER JOIN "+
                      "dbo.SmCustromerCard ON dbo.PrkCardParking.IDCardParking = dbo.SmCustromerCard.CodeBaseCard INNER JOIN "+
                      "dbo.SmElectronicCard ON dbo.SmCustromerCard.CodeBaseCard = dbo.SmElectronicCard.Code Where dbo.SmElectronicCard.IDCardParking='"+IDCardParking+"' and dbo.SmElectronicCard.Market='"+Market+"'");
                        break;
                    case (int)TypeCard.Sellers:
                        TypeCard = TypeCard.Sellers;
                        Jdb.setQuery("SELECT  dbo.SmElectronicCard.Code, dbo.SmElectronicCard.IDCardParking, dbo.SmElectronicCard.DateExpire, dbo.SmElectronicCard.StatusCard, "+
                     " dbo.SmElectronicCard.Market, dbo.SmElectronicCard.TypeCard, dbo.SmSellers.IDContract, dbo.SmSellers.IdPerson, dbo.SmSellers.IDAsset, "+
                      "dbo.SmSellers.EndDateContract, dbo.SmSellers.DateActive, dbo.SmSellers.Code AS CodeSellerCard, dbo.finAsset.Comment, " +
                      "dbo.PrkCardParking.Code AS CodeParking, dbo.PrkCardParking.DateExpire AS DateExpireParking, dbo.PrkCardParking.StatusParking, "+
                      "dbo.PrkCardParking.InactiveDue AS InactiveDueParking, dbo.PrkCardParking.DateActive AS ACtiveParkingService, dbo.PrkCardParking.CodeGroup, "+
                      "ISNULL(dbo.PrkCar.Plaque, 'پلاك') AS Plaque, dbo.PrkCar.StatusCard AS StatusCar, ISNULL(dbo.PrkCar.CarOwner, 'نا معلوم') AS OwnerCar, "+
                      "dbo.PrkCar.Defult, ISNULL(subdefine_2.name, 'نا معلوم') AS Color, ISNULL(subdefine_1.name, 'نا معلوم') AS TypeKhodro, dbo.clsPerson.Name, "+ 
                      "dbo.clsPerson.Fam, dbo.subdefine.name AS ParkingInactiveDue, subdefine_3.name AS ElInactiveDuo, dbo.SmElectronicCard.InactiveDue "+
"FROM         dbo.PrkCardParking INNER JOIN "+
                      "dbo.SmElectronicCard INNER JOIN "+
                      "dbo.SmSellers ON dbo.SmElectronicCard.Code = dbo.SmSellers.CodeBaseCard INNER JOIN "+
                      "dbo.finAsset ON dbo.SmSellers.IDAsset = dbo.finAsset.Code INNER JOIN "+
                      "dbo.clsPerson ON dbo.SmSellers.IdPerson = dbo.clsPerson.Code ON dbo.PrkCardParking.IDCardParking = dbo.SmSellers.CodeBaseCard INNER JOIN "+
                      "dbo.subdefine ON dbo.PrkCardParking.InactiveDue = dbo.subdefine.Code INNER JOIN "+
                      "dbo.subdefine AS subdefine_3 ON dbo.SmElectronicCard.InactiveDue = subdefine_3.Code LEFT OUTER JOIN "+
                      "dbo.subdefine AS subdefine_2 INNER JOIN "+
                      "dbo.PrkCar ON subdefine_2.Code = dbo.PrkCar.CarColor INNER JOIN "+
                      "dbo.subdefine AS subdefine_1 ON dbo.PrkCar.TypeCar = subdefine_1.Code ON dbo.PrkCardParking.Code = dbo.PrkCar.IDCardParking AND  "+
                      "dbo.PrkCar.Defult = 'True' " +
 "Where dbo.SmElectronicCard.IDCardParking='" + IDCardParking + "' and dbo.SmElectronicCard.Market='"+Market+"'");
                        break;
                    case (int)TypeCard.Masters:
                        TypeCard = TypeCard.Masters;
                        Jdb.setQuery("");
                        break;
                }

                return Jdb.Query_DataTable();

               
            }
            catch
            {
                return null;
            }


        }
           
        public  bool GetBusinesUnit(int pCode)
        {
            
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.CardParking + " WHERE IDBusinessUnit=" + pCode.ToString());
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

        public void ShowForm(int pCode, int Market)
        {
            JCardParkingForm JCPF = new JCardParkingForm(pCode, Market);
            JCPF.ShowDialog();
        }
        
        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["IDCardParking"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataParking", "Parking.JCardParking.ShowForm", new object[] { (int)pDR["Code"], (int)pDR["Market"] }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JCardParking.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "شماره واحد تجاری " + (char)13 + Node.Name;
            return Node;
        }
        

       


        #endregion

    }

    public class JCardParkings : JParking
    {
        public static System.Data.DataTable GetDataTable(int PMarketCode)
        {
            return GetDataTable(0,PMarketCode);
        }

        public static System.Data.DataTable GetDataTable(int pCode, int PMarketCode)
        {
            JDataBase DB = new JDataBase();

            try
            {
                string pWhere = " WHERE dbo.SmElectronicCard.DateActive is not null";
                if (pCode > 0)
                    pWhere = pWhere + " And dbo.SmElectronicCard.Code=" + pCode.ToString();
                if (PMarketCode > 0)
                    pWhere = pWhere + " And dbo.SmElectronicCard.Market=" + PMarketCode.ToString();
                DB.setQuery("SELECT     dbo.SmElectronicCard.Code, dbo.SmElectronicCard.IDCardParking,dbo.SmElectronicCard.RfidNumber," + JDataBase.SQLMiladiToShamsi("dbo.SmElectronicCard.DateExpire", "DateExpire") + ", dbo.SmElectronicCard.StatusCard,dbo.SmElectronicCard.SerialCard," + JDataBase.SQLMiladiToShamsi("dbo.SmElectronicCard.DateActive", "DateActive") +
                      ",dbo.estMarket.Title, dbo.SmTypeCard.Name As TypeCard, dbo.subdefine.name AS InactiveDue, dbo.SmElectronicCard.Market, " +
                      "+dbo.SmElectronicCard.TypeCard " +
        "FROM         dbo.SmElectronicCard INNER JOIN " +
                      "dbo.estMarket ON dbo.SmElectronicCard.Market = dbo.estMarket.Code INNER JOIN " +
                      "dbo.SmTypeCard ON dbo.SmElectronicCard.TypeCard = dbo.SmTypeCard.Code INNER JOIN " +
                      "dbo.subdefine ON dbo.SmElectronicCard.InactiveDue = dbo.subdefine.Code " +
        pWhere);
                //JPermission.getObjectSql("SmartCards.JElectronicCard.GetDataTable", JTableNamesSmartCards.ElectronicCard + ".Code"));
                return DB.Query_DataTable();

            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }

        public void ListView(int Pmarket)
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JCardParking.GetNode");
            Nodes.DataTable = GetDataTable(0, Pmarket);

            //JToolbarNode Tn = new JToolbarNode();
            //Tn.Click = new JAction("CardParking", "Parking.JCardParking.ShowForm", new object[] { 0, Pmarket }, null);
            //Tn.Icon = JImageIndex.Add;
            //Nodes.AddToolbar(Tn);
        }
       
    }
}
