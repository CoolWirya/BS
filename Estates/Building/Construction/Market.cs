using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Estates
{
    public class jMarket : JSystem
    {


        #region Property

        public int Code { get; set; }
        /// <summary>
        /// شماره مجتمع
        /// </summary>
        public int MarketNumber { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// زیربنا
        /// </summary>
        public string Infrastructure { get; set; }
        /// <summary>
        /// تاریخ شروع ساخت
        /// </summary>
        public DateTime StartBuilding { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndBuilding { get; set; }
        /// <summary>
        /// پروانه ساخت
        /// </summary>
        public string PermitBuilding { get; set; }
        /// <summary>
        /// پروانه بهره برداری
        /// </summary>
        public string PermitResult { get; set; }
        /// <summary>
        /// نام مدیریت
        /// </summary>
        public string ManagerName { get; set; }

        #endregion

        #region سازنده

        public jMarket()
        {
        }
        public jMarket(int pCode)
        {
            Code=pCode;
            if (Code > 0)
                GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JMarketTable PDT = new JMarketTable();
            try
            {
                if (!Find(MarketNumber))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    return Code;
                }
                else
                {
                    JMessages.Message("کد مجتمع تکراری است", "خطا", JMessageType.Error);
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
            JMarketTable PDT = new JMarketTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Update();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            JMarketTable PDT = new JMarketTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Delete(pDB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
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
                DB.setQuery("SELECT * FROM " + JTableNamesEstate.Market + " WHERE " + estMarket.Code + "=" + pCode.ToString());
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
        public bool Find(int pMarketNumber)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesEstate.Market + " WHERE " + estMarket.MarketNumber + "=" + JDataBase.Quote(pMarketNumber.ToString()));
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public override string ToString()
        //{
        //    return JLanguages._Text(Name);
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="dtfloors"></param>
        /// <param name="dtUsage"></param>
        /// <param name="dtLocation"></param>
        /// <returns></returns>
        public bool Insert(DataTable dtfloors, DataTable dtUsage,DataTable dtLocation)
        {
          JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("InsertMarket");
                //JMarketTable PDT = new JMarketTable();           
                //PDT.SetValueProperty(this);
                //Code = PDT.Insert(tempdb);
                Code = Insert(tempdb);
                //Histroy.Save(JMarketTable , Code, "Insert");
                if(Code > 0)
                {
                    //----------درج طبقات-----------
                    jMarketFloors tmpjMarketFloors = new jMarketFloors();
                    if (!tmpjMarketFloors.Insert(dtfloors, Code, tempdb))
                    {
                        tempdb.Rollback("InsertMarket");
                        return false;
                    }
                    //----------درج موقعیت-----------
                    jMarketLocation tmpjMarketLocation = new jMarketLocation();
                    if (!tmpjMarketLocation.Insert(dtLocation, Code, tempdb))
                    {
                        tempdb.Rollback("InsertMarket");
                        return false;
                    }
                    //----------درج کاربری-----------
                    jMarketUsage tmpjMarketUsage = new jMarketUsage();
                    if (!tmpjMarketUsage.Insert(dtUsage, Code, tempdb))
                    {
                        tempdb.Rollback("InsertMarket");
                        return false;
                    }
                    if (tempdb.Commit())
                    {
                        Nodes.DataTable.Merge(jMarkets.GetDataTable(Code));
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("InsertMarket");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertMarket");
                return false;
            }
        }

        /// <summary>
        ///  ویرایش اطلاعات کلی مجتمع
        /// </summary>
        /// <param name="dtfloors"></param>
        /// <param name="dtUsage"></param>
        /// <param name="dtLocation"></param>
        /// <returns></returns>
        public bool Update(DataTable dtfloors, DataTable dtUsage, DataTable dtLocation)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("UpdateMarket");
                JMarketTable PDT = new JMarketTable();
                PDT.SetValueProperty(this);
                if (PDT.Update(tempdb))
                {
                    //----------درج و حذف طبقات-----------
                    jMarketFloors tmpjMarketFloors = new jMarketFloors();
                    //tmpjMarketFloors.delete(0, estMarketFloors.MarketCode.ToString() + "=" + Code.ToString(), tempdb);
                    if (!tmpjMarketFloors.Insert(dtfloors, Code, tempdb))
                    {
                        tempdb.Rollback("UpdateMarket");
                        return false;
                    }
                    //----------درج و حذف موقعیت-----------
                    jMarketLocation tmpjMarketLocation = new jMarketLocation();
                    //tmpjMarketLocation.delete(0, estMarketLocation.MarketCode.ToString() + "=" + Code.ToString(), tempdb);
                    if ((!tmpjMarketLocation.Insert(dtLocation, Code, tempdb))&&(!tmpjMarketLocation.delete(0, estMarketLocation.MarketCode.ToString() + "=" + Code.ToString(), tempdb)))
                    {
                        tempdb.Rollback("UpdateMarket");
                        return false;
                    }
                    //----------درج و حذف کاربری-----------
                    jMarketUsage tmpjMarketUsage = new jMarketUsage();
                    //tmpjMarketUsage.delete(0, estMarketUsage.MarketCode.ToString() + "=" + Code.ToString(), tempdb);
                    if (!tmpjMarketUsage.Insert(dtUsage, Code, tempdb))
                    {
                        tempdb.Rollback("UpdateMarket");
                        return false;
                    }
                    if (tempdb.Commit())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, jMarkets.GetDataTable(Code).Rows[0]);
                        Histroy.Save(PDT, Code, "Update");
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("UpdateMarket");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertMarket");
                return false;
            }
        }
        /// <summary>
        /// خذف کلی اطلاعات مجتمع
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                //tempdb.beginTransaction("DeleteMarket");
                //JMarketTable PDT = new JMarketTable();
                //PDT.SetValueProperty(this);
                //if (PDT.Delete(tempdb))
                //{
                    //----------حذف آرشیو-----------
                    JArchiveDocument tmp = new JArchiveDocument();
                    if(!tmp.DeleteArchive("Estates.jMarket", Code, false))
                    {
                        tempdb.Rollback("DeleteMarket");
                        return false;
                    }
                    //----------حذف طبقات-----------
                    jMarketFloors tmpjMarketFloors = new jMarketFloors();
                    if (!tmpjMarketFloors.delete(0, estMarketFloors.MarketCode.ToString() + "=" + Code.ToString(), tempdb))
                    {
                        tempdb.Rollback("DeleteMarket");
                        return false;
                    }
                    //---------- حذف موقعیت-----------
                    jMarketLocation tmpjMarketLocation = new jMarketLocation();
                    if (!tmpjMarketLocation.delete(0, estMarketLocation.MarketCode.ToString() + "=" + Code.ToString(), tempdb))
                    {
                        tempdb.Rollback("DeleteMarket");
                        return false;
                    }
                    //---------- حذف کاربری-----------
                    jMarketUsage tmpjMarketUsage = new jMarketUsage();
                    if (!tmpjMarketUsage.delete(0, estMarketUsage.MarketCode.ToString() + "=" + Code.ToString(), tempdb))
                    {
                        tempdb.Rollback("DeleteMarket");
                        return false;
                    }
                    if (!delete(tempdb))
                    {
                        tempdb.Rollback("DeleteMarket");
                        return false;
                    }
                    if (tempdb.Commit())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                        return false;
                //}
                //else
                //{
                //    tempdb.Rollback("DeleteMarket");
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertMarket");
                return false;
            }
        }
        #endregion

        #region Nodes
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JConstructionForm PE = new JConstructionForm(0);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JConstructionForm PE = new JConstructionForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[estMarket.Code.ToString()], "Estates.jMarket");
            node.Icone = JImageIndex.building.GetHashCode();
            node.Name = pRow[estMarket.Title.ToString()] + " - " + pRow[estMarket.MarketNumber.ToString()];                              
            node.Hint = JLanguages._Text("Infrastructure:") + " " + pRow[estMarket.Infrastructure.ToString()] + "\n" +
                       JLanguages._Text("ManagerName:") + " " + pRow[estMarket.ManagerName.ToString()] + "\n" +
                       JLanguages._Text("StartBuilding:") + " " + pRow[estMarket.StartBuilding.ToString()] + "\n" +
                       JLanguages._Text("EndBuilding:") + " " + pRow[estMarket.EndBuilding.ToString()];
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Estates.jMarket.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Estates.jMarket.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Estates.jMarket.ShowDialog", null, null);

            //// در صورتیکه شخص متوفی باشد آیتمهای منو متفاوت است            
                node.Popup.Insert(deleteAction);
                node.Popup.Insert(editAction);
                node.Popup.Insert(newAction);
            
            return node;
        }
        #endregion

    }

    public class jMarkets : JSystem
    {
        public jMarkets[] Items = new jMarkets[0];
      //  public String OrderName;
        public jMarkets()
        {
           // OrderName = "Fam";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE =  "select * from " + JTableNamesEstate.Market ;
                if (pCode != 0)
                    WHERE =WHERE+" WHERE Code = " + pCode;
                DB.setQuery(WHERE);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetMarket", "Estates.jMarket.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Estates.jMarket.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }
    }
}