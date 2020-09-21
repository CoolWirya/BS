using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Bascol
{
    public class JTruck : JBascol
    {
        #region constructor
        public JTruck()
        {

        }
        public JTruck(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate
        {
            get;
            set;
        }
        /// <summary>
        /// نام
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// قیمت
        /// </summary>
        public int Price
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shortcut
        {
            get;
            set;
        }        
        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from bascolTruck where Code=" + pCode + "";
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

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = "select *,Name+' - '+Shortcut as 'FullName' from  bascolTruck Where Cast(StartDate as date) <= Cast(getdate() as Date) And Cast(EndDate as Date) >= cast(getdate() as Date) " + Where;
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
        public static DataTable GetDataTransfer(JDataBase db)
        {
            string Query = "select * from  bascolTruck ";
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
            }
        }
        #endregion

        #region method
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase tempDb)
        {
            try
            {
                JTruckTable JLT = new JTruckTable();
                JLT.SetValueProperty(this);
                Code = JLT.Insert(tempDb);
                if (Code > 0)
                    return Code;
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //tempDb.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(JDataBase tempDb)
        {
            JTruckTable PDT = new JTruckTable();
            try
            {                
                PDT.SetValueProperty(this);
                if (PDT.Delete(tempDb))
                    return true;
                //Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //Db.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase tempDb)
        {
            try
            {
                JTruckTable PDT = new JTruckTable();
                PDT.SetValueProperty(this);
                if (PDT.Update(tempDb))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }

        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Bascol.JTruck");
            Node.Name = pRow["Name"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["Name"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Bascol.JTruck.ShowDialog", null, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "Bascol.JTruck.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Bascol.JTruck.ShowDialog", null, null);
            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            return Node;
        }

        public void ShowDialog()
        {
            if (!(JPermission.CheckPermission("Bascol.JTruck.ShowDialog")))
                return;

            JTruckForm LandForm = new JTruckForm();
            LandForm.State = JFormState.Insert;
            LandForm.ShowDialog();
        }

        #endregion

        public bool Update(DataTable tmpdt)
        {
            JTruckTable PDT = new JTruckTable();
            JDataBase db = new JDataBase();
            try
            {
                if (tmpdt != null)
                {
                    db.beginTransaction("InsertTruck");
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            Name = dr["Name"].ToString();
                            StartDate = Convert.ToDateTime(dr["StartDate"]);
                            EndDate = Convert.ToDateTime(dr["EndDate"]);
                            Price = Convert.ToInt32(dr["Price"]);
                            Shortcut = dr["Shortcut"].ToString();
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Modified)
                        {
                            Name = dr["Name"].ToString();
                            StartDate = JDateTime.GregorianDate(dr["StartDate"].ToString());
                            EndDate = JDateTime.GregorianDate(dr["EndDate"].ToString());
                            Price = Convert.ToInt32(dr["Price"]);
                            Shortcut = dr["Shortcut"].ToString();
                            Code = Convert.ToInt32(dr["Code"]);
                            if (!Update(db))
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!Delete(db))
                                return false;
                            dr.Delete();
                        }
                    }
                    tmpdt.AcceptChanges();
                    if (db.Commit())
                        return true;
                    else
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                db.Rollback("InsertTruck");
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                db.Dispose();
            }
        }
    }

    public class JTrucks : JSystem
    {
        public JTrucks[] Items = new JTrucks[0];
        public JTrucks()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select Code,Name,Price,(select Fa_Date from StaticDates where En_Date=Cast(StartDate as Date)) 'StartDate',
(select Fa_Date from StaticDates where En_Date=Cast(EndDate as Date)) 'EndDate',Shortcut from BascolTruck " + Where;
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

        #endregion GetData

        #region Node
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("Trucks", "Bascol.JTruck.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "Bascol.JTruck.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}
