using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace RealEstate
{
    public class JBreakDownUnitBuild : JSystem
    {
        #region Cunstractor
        public JBreakDownUnitBuild()
        {           
        }
        public JBreakDownUnitBuild(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد اعیان جدید
        /// </summary>
        public int UnitBuildCode { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// اعیان های حاصل از تفکیک
        /// </summary>
        public JUnitBuild[] UnitBuildsBreakdown;

        #endregion
      
        #region Method

        public int Insert()
        {
            int Code;
            JDataBase Db = new JDataBase();
            JBreakDownUnitBuildTable JAGT = new JBreakDownUnitBuildTable();
            JBreakDownUnitBuilds JAGTs = new JBreakDownUnitBuilds();
            JUnitBuild tmpOldUnitBuild = new JUnitBuild();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JBreakDownUnitBuild.Insert"))
                {
                    Db.beginTransaction("InsertBreakDownUnitBuild");
                    JAGT.SetValueProperty(this);                                          
                        //درج اعیان تفکیک شده
                        Code = JAGT.Insert(Db);
                        if (Code > 0)
                        {
                            tmpOldUnitBuild.GetData(UnitBuildCode);
                            tmpOldUnitBuild.Status = UnitBuildStatus.BreakDown;
                            //tmpOldUnitBuild.ParentCode = pNewUnitBuildCode;
                            tmpOldUnitBuild.Update(Db, false);
                            //درج اعیان های جدید
                            foreach (JUnitBuild NewUnitBuild in this.UnitBuildsBreakdown)
                            {
                                NewUnitBuild.ParentCode = UnitBuildCode;
                                NewUnitBuild.Code = NewUnitBuild.Insert(Db, false);
                                JAGTs.BreakDownCode = Code;
                                JAGTs.UnitBuildCode = NewUnitBuild.Code;
                                if (JAGTs.insert(Db) > 0)//(UnitBuildsBreakdown, Code, UnitBuildCode, Db))
                                {
                                    //آپدیت AssetTransferمربوط به تفکیک  
                                    JAsset Asset = new JAsset("RealEstate.JUnitBuild", JAGTs.UnitBuildCode, Db);
                                    JAssetTransfer AssetTransfer = new JAssetTransfer(Asset.Code, JOwnershipType.Definitive, Db);
                                    AssetTransfer.ObjectCode = Code;
                                    AssetTransfer.Update(Db);
                                }
                                else
                                {
                                    Db.Rollback("InsertBreakDownUnitBuild");
                                    return 0;
                                }
                            }
                            if (Db.Commit())
                            {
                                Nodes.DataTable.Merge(JBreakDownUnitBuildss.GetDataTable(Code));
                                return Code;
                            }
                            else
                            {
                                Db.Rollback("InsertBreakDownUnitBuild");
                                return 0;
                            }
                        }
                        else
                        {
                            Db.Rollback("InsertBreakDownUnitBuild");
                            return 0;
                        }                    
                }
                return 0;                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertBreakDownUnitBuild");
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }

        private bool SetPrimaryOwners = false;

        public bool Update()
        {
            JBreakDownUnitBuildTable JAGT = new JBreakDownUnitBuildTable();
            try
            {
                JAGT.SetValueProperty(this);
                if (JAGT.Update())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete(JDataBase Db)
        {
            JBreakDownUnitBuildTable JAGT = new JBreakDownUnitBuildTable();
            try
            {
                JAGT.SetValueProperty(this);
                if (JAGT.Delete(Db))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }    
        }
        public bool Delete()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            GetData(Code);
            JBreakDownUnitBuilds AUBS = new JBreakDownUnitBuilds();
            JUnitBuild tmpUnitBuild = new JUnitBuild();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JBreakDownUnitBuild.Delete"))
                {
                    Db.beginTransaction("DeleteBreakDownUnitBuild");
                    if (AUBS.DeleteManual(Code, Db))
                    {
                        tmpUnitBuild.Code = UnitBuildCode;
                        if ((Delete(Db)) && (tmpUnitBuild.Delete(Db)))
                        {
                            if (Db.Commit())
                                return true;
                            else
                                return false;
                        }
                        else
                            Db.Rollback("DeleteBreakDownUnitBuild");
                        return false;
                    }
                    else
                        Db.Rollback("DeleteBreakDownUnitBuild");
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("DeleteBreakDownUnitBuild");
                return false;
            }          
        }
       
        #endregion

        #region GetData&Showdata&Find
        public bool GetData(int pCode)
        {
            string Qouery = "select * from " + JRETableNames.RestBreakDownUnitBuild + " where Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    JBreakDownUnitBuilds.GetUnitBuildsBreakDown(ref this.UnitBuildsBreakdown, this.Code);
                    return true;
                }
                else
                    return false;
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
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["code"], "RealEstate.JBreakDownUnitBuild");
            Node.Name = pRow["Number"].ToString() + JLanguages._Text("Number: "); //JLanguages._Text("Code: ") + pRow["Code"].ToString() +
              //  "\n" + 
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن اضافه
            JAction newAction = new JAction("new...", "RealEstate.JBreakDownUnitBuild.ShowDialog", null, null);
            //اکشن حذف 
            JAction delAction = new JAction("delete...", "RealEstate.JBreakDownUnitBuild.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delAction;
            //اکشن نمایش
            JAction ShowAction = new JAction("Edit...", "RealEstate.JBreakDownUnitBuild.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = ShowAction;
            Node.EnterClickAction = ShowAction;
            JPopupMenu PMenu = new JPopupMenu("RealEstate.JBreakDownUnitBuild", Node.Code);
            PMenu.Insert(delAction);
            PMenu.Insert(ShowAction);
            PMenu.Insert(newAction);
            Node.Popup = PMenu;

            return Node;
        }


        public void ShowDialog()
        {
            if (!JPermission.CheckPermission("RealEstate.JBreakDownUnitBuild.ShowDialog"))
                return;
            if (this.Code == 0)
            {
                JBreakDownForm JAF = new JBreakDownForm();
                JAF.State = JFormState.Insert;
                JAF.ShowDialog();
            }
            else
            {
                JBreakDownForm JAF = new JBreakDownForm(Code);
                JAF.State = JFormState.Update;
                JAF.ShowDialog();
            }

        }

        #endregion
    }

    public class JBreakDownUnitBuildss : JSystem
    {
        public JBreakDownUnitBuildss[] Items = new JBreakDownUnitBuildss[0];
        public JBreakDownUnitBuildss()
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
                Where = Where + " And " + JRETableNames.RestBreakDownUnitBuild + ".Code=" + pCode;
            string Query = "select Code,dbo.MiladiTOShamsi(Date) 'Date',(select number from estUnitBuild where Code = UnitBuildCode) 'Number' from "
                + JRETableNames.RestBreakDownUnitBuild + Where +
                " And " + JPermission.getObjectSql("RealEstate.JAggregateUnitBuild.GetDataTable", JRETableNames.RestBreakDownUnitBuild + ".Code");
            //Meeting.JMeetingss.GetDataTable   JTableNamesMeeting.MetMeeting
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
            Nodes.ObjectBase = new JAction("JBreakDown", "RealEstate.JBreakDownUnitBuild.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "RealEstate.JBreakDownUnitBuild.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}
