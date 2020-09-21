using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JCar : JParking
    {
        #region Property
        
        public int Code { get; set; }
        
        
        /// <summary>
        /// کد کارت پارکینگ
        /// </summary>
        public int IDCardParking { get; set; }
        /// <summary>
        /// نوع خودرو
        /// </summary>
        public int TypeCar { get; set; }
        /// <summary>
        /// شماره پلاک خودرو
        /// </summary>
        public string Plaque { get; set; }
        /// <summary>
        /// رنگ خودرو
        /// </summary>
        public int CarColor { get; set; }
        /// <summary>
        /// وضعیت کارت
        /// </summary>
        public bool StatusCard { get; set; }
        /// <summary>
        /// صاحب خودرو
        /// </summary>
        public string CarOwner { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// پيش فرض
        /// </summary>
        public bool Defult { get; set; }
        /// <summary>
        /// شماره كارت
        /// </summary>
        public int CardNumber { get; set; }
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
                if (JPermission.CheckPermission("Parking.JCar.Insert"))
                {
                    JCarTable JCT = new JCarTable();
                    JCT.SetValueProperty(this);
                    Code = JCT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JCars.GetDataTable(Code));
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
            if (JPermission.CheckPermission("Parking.JCar.Update"))
            {
                JCarTable JCT = new JCarTable();
                JCT.SetValueProperty(this);
                return JCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JCar.Delete"))
            {
                Code = pCode;
                JCarTable JCT = new JCarTable();
                JCT.SetValueProperty(this);
                if (JCT.Delete())
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Car + " WHERE Code=" + pCode.ToString());
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
        public bool GetDataByIDCard(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Car + " WHERE IDCardParking=" + pCode.ToString());
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
        public Boolean FindPlaque(string Plaque)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Car + " WHERE Plaque="+JDataBase.Quote(Plaque));
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
        public void ClearDefult(int CarID)
        {
            JDataBase Jdb = new JDataBase();
            try
            {
                if (JMessages.Confirm("ايا از پيش فرض شدن خودروي " + Plaque.ToString() + "مطمئن هستيد", "هشدار") == System.Windows.Forms.DialogResult.Yes)
                {


                    Jdb.beginTransaction("SetDefultCar");

                    Jdb.setQuery("UPDATE [dbo].[PrkCar]  SET [Defult] = 'False'  WHERE [IDCardParking]=" + CarID.ToString());
                    Jdb.Query_Execute();
                       
                    
                    Jdb.Commit();
                }

            }
            catch
            {
                Jdb.Rollback("SetDefultCar");
            }
            finally
            {
                Jdb.Dispose();
            }
        }
       
        public System.Data.DataTable GetkhodrosOFCard(int CardCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT     dbo.PrkCar.Code, dbo.PrkCar.IDCardParking, dbo.PrkCar.Plaque, dbo.subdefine.name, subdefine_1.name AS Color, subdefine_2.name AS Status, " +
                      "dbo.PrkCar.CarOwner, dbo.PrkCar.Description, dbo.PrkCar.Defult "+
"FROM         dbo.PrkCar INNER JOIN "+
                      "dbo.subdefine ON dbo.PrkCar.TypeCar = dbo.subdefine.Code INNER JOIN "+
                      "dbo.subdefine AS subdefine_1 ON dbo.PrkCar.CarColor = subdefine_1.Code INNER JOIN "+
                      "dbo.subdefine AS subdefine_2 ON dbo.PrkCar.StatusCard = subdefine_2.Code "+
"WHERE     (dbo.PrkCar.IDCardParking ='" + CardCode + "')");
                return DB.Query_DataTable();
               
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
        public void ShowForm(int pCode)
        {
            
                GetData(pCode);
                OprateCarForm JCF = new OprateCarForm(this);
                JCF.State = JFormState.Update;
                JCF.ShowDialog();
            
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["CarOwner"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataParking", "Parking.JCar.ShowForm", new object[] { (int)pDR["Code"] }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JCar.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "name is " + (char)13 + Node.Name;
            return Node;
        }


        #endregion
    }

    public class JCars : JParking
    {
        public static System.Data.DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static System.Data.DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And Code=" + pCode.ToString();
                DB.setQuery("SELECT     dbo.PrkCar.Code, dbo.SmElectronicCard.IDCardParking, dbo.subdefine.name, subdefine_1.name AS Color, dbo.PrkCar.CarOwner, dbo.PrkCar.Plaque,dbo.PrkCar.Defult, dbo.PrkCar.StatusCard, dbo.PrkCar.CardNumber "+
"FROM         dbo.PrkCar INNER JOIN   dbo.SmElectronicCard ON dbo.PrkCar.IDCardParking = dbo.SmElectronicCard.Code LEFT OUTER JOIN dbo.subdefine ON dbo.PrkCar.CarColor = dbo.subdefine.Code LEFT OUTER JOIN "+
                      "dbo.subdefine AS subdefine_1 ON dbo.PrkCar.TypeCar = subdefine_1.Code " + pWhere);
                  
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
            return GetDataTable();
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JCar.GetNode");
            Nodes.DataTable = GetDataTable();

           
        }

    }
}
