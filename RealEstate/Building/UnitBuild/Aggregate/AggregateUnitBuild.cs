using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace RealEstate
{
    public class JAggregateUnitBuild : JSystem
    {
        #region Cunstractor
        public JAggregateUnitBuild()
        {           
        }
        public JAggregateUnitBuild(int pCode)
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
        
        public DataTable UnitBuildsAggregate;

        #endregion
      
        #region Method

        public int Insert(DataTable _dt, JUnitBuild tmpJUnitBuild)
        {
            int Code;
            JDataBase Db = new JDataBase();
            JAggregateUnitBuildTable JAGT = new JAggregateUnitBuildTable();
            JAggregateUnitBuilds JAGTs = new JAggregateUnitBuilds();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JAggregateUnitBuild.Insert"))
                {
                    Db.beginTransaction("InsertAgrrateUnitBuild");
                    //درج اعیان جدید
                    int NewUnitBuildCode = tmpJUnitBuild.Insert(Db, false);
                    if (NewUnitBuildCode > 0)
                    {
                        this.UnitBuildCode = NewUnitBuildCode;
                        JAGT.SetValueProperty(this);
                        //JAGT.UnitBuildCode = NewUnitBuildCode;
                        //JAGT.Description = Description;
                        //JAGT.Date = Date;
                        //درج اعیان تجمیع شده
                        Code = JAGT.Insert(Db);
                        if (Code > 0)
                        {
                            //درج اعیان های قبلی
                            if (JAGTs.Update(_dt, Code, NewUnitBuildCode, Db))
                            {
                                //آپدیت AssetTransferمربوط به تجمیع
                                JAsset Asset = new JAsset("RealEstate.JUnitBuild", NewUnitBuildCode, Db);                                
                                JAssetTransfer AssetTransfer = new JAssetTransfer(Asset.Code, JOwnershipType.Definitive, Db);
                                AssetTransfer.ObjectCode = Code;
                                AssetTransfer.Update(Db);
                                if (Db.Commit())
                                {
                                    Nodes.DataTable.Merge(JAggregateUnitBuildss.GetDataTable(Code));
                                    return Code;
                                }
                                else
                                {
                                    Db.Rollback("InsertAgrrateUnitBuild");
                                    return 0;
                                }
                            }
                            else
                            {
                                Db.Rollback("InsertAgrrateUnitBuild");
                                return 0;
                            }
                        }
                        else
                        {
                            Db.Rollback("InsertAgrrateUnitBuild");
                            return 0;
                        }
                    }
                    else
                    {
                        Db.Rollback("InsertAgrrateUnitBuild");
                        return 0;
                    }
                }
                return 0;                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertAgrrateUnitBuild");
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }

        private bool SetPrimaryOwners = false;

        //public void SumPrimeryOwnerNewGround()
        //{
        //    int GroundCode;
        //    int CountGround = GroundsAggregationby.Rows.Count;
        //    if (SetPrimaryOwners)
        //        return;
        //    try
        //    {
        //        this.GroundAggregationby.PrimeryOwners.Rows.Clear();
        //        GroundCode = Convert.ToInt32(GroundsAggregationby.Rows[0][JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
        //        JGround Ground = new JGround();
        //        JAsset Asset = new JAsset();
        //        Asset.GetData("Estates.JGround", GroundCode);
        //        DataTable PrimararyOwnerGrounrd = JAssetShares.GetDataTableAssetShareOwner(Asset.Code, JOwnershipType.Definitive);
        //        PrimararyOwnerGrounrd.Columns.Remove("Share");
        //        PrimararyOwnerGrounrd.Columns["PersonShare"].ColumnName = "Share";
        //        this.GroundAggregationby.PrimeryOwners = PrimararyOwnerGrounrd;
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //        SetPrimaryOwners = false;
        //    }
                
        //    GroundsAggregationby.AcceptChanges();

           
        //}

        public bool Update()
        {
            JAggregateUnitBuildTable JAGT = new JAggregateUnitBuildTable();
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
            JAggregateUnitBuildTable JAGT = new JAggregateUnitBuildTable();
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
            JAggregateUnitBuilds AUBS = new JAggregateUnitBuilds();
            JUnitBuild tmpUnitBuild = new JUnitBuild();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JAggregateUnitBuild.Delete"))
                {
                    Db.beginTransaction("DeleteAgrrateUnitBuild");
                    if (AUBS.DeleteManual(Code, Db))
                    {
                        tmpUnitBuild.Code = UnitBuildCode;
                        if ((Delete(Db)) && (tmpUnitBuild.Delete(Db, false)))
                        {
                            if (Db.Commit())
                                return true;
                            else
                                return false;
                        }
                        else
                            Db.Rollback("DeleteAgrrateUnitBuild");
                        return false;
                    }
                    else
                        Db.Rollback("DeleteAgrrateUnitBuild");
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("DeleteAgrrateUnitBuild");
                return false;
            }          
        }
       
        #endregion

        #region GetData&Showdata&Find
        public bool GetData(int pCode)
        {
            string Qouery = "select * from " + JRETableNames.RestAggregateUnitBuild + " where Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    UnitBuildsAggregate = JAggregateUnitBuilds.GetDataTable(this.Code);
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
            JNode Node = new JNode((int)pRow["code"], "RealEstate.JAggregateUnitBuild");
            Node.Name = pRow["Number"].ToString() + JLanguages._Text("Number: "); //JLanguages._Text("Code: ") + pRow["Code"].ToString() +
              //  "\n" + 
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن اضافه
            JAction newAction = new JAction("new...", "RealEstate.JAggregateUnitBuild.ShowDialog", null, null);
            //اکشن حذف 
            JAction delAction = new JAction("delete...", "RealEstate.JAggregateUnitBuild.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delAction;
            //اکشن نمایش
            JAction ShowAction = new JAction("Edit...", "RealEstate.JAggregateUnitBuild.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = ShowAction;
            Node.EnterClickAction = ShowAction;
            JPopupMenu PMenu = new JPopupMenu("RealEstate.JAggregateUnitBuild", Node.Code);
            PMenu.Insert(delAction);
            PMenu.Insert(ShowAction);
            PMenu.Insert(newAction);
            Node.Popup = PMenu;

            return Node;
        }


        public void ShowDialog()
        {
            if (!JPermission.CheckPermission("RealEstate.JAggregateUnitBuild.ShowDialog"))
                return;
            if (this.Code == 0)
            {
                JAggregateForm JAF = new JAggregateForm();
                JAF.State = JFormState.Insert;
                JAF.ShowDialog();
            }
            else
            {
                JAggregateForm JAF = new JAggregateForm(Code);
                JAF.State = JFormState.Update;
                JAF.ShowDialog();
            }

        }

        //public bool FindGroundAggregate(int pCode)
        //{
        //    return GroundsAggregationby.Select("GroundsAggregationbyCode=" + pCode.ToString()).Count() > 0;

        //}
        ///// <summary>
        ///// چک کردن برابر بودن مالکین اولیه و سهام آن ها برای تجمیع
        ///// </summary>
        ///// <param name="pCode"></param>
        ///// <returns></returns>
        //public bool CheckSharePrimaryOwner(int pCode)
        //{
        //    if (GroundsAggregationby.Rows.Count > 0)
        //    {
        //        JAsset FirstGroundAsset = new JAsset("Estates.JGround", (int)GroundsAggregationby.Rows[0]["GroundsAggregationbyCode"]);
        //        DataTable FirstGroundTable = JAssetShares.GetDataTableAssetShareOwner(FirstGroundAsset.Code, JOwnershipType.Definitive);
        //        JAsset SecondGroundAsset = new JAsset("Estates.JGround", pCode);
        //        DataTable SecondGroundTable = JAssetShares.GetDataTableAssetShareOwner(SecondGroundAsset.Code, JOwnershipType.Definitive);
        //        if (FirstGroundTable.Rows.Count != SecondGroundTable.Rows.Count)
        //        {
        //            JMessages.Error("تعداد مالکین  زمین ها یکی نیست", "error");
        //            return false;
        //        }
        //        foreach (DataRow RowFirst in FirstGroundTable.Rows)
        //        {
        //            bool flage = false;
        //            foreach (DataRow RowSecond in SecondGroundTable.Rows)
        //            {
        //                if (((int)RowFirst["pCode"] == (int)RowSecond["pCode"]) && Convert.ToDouble(RowFirst["PersonShare"]) == (Double)RowSecond["PersonShare"])
        //                    flage = true;


        //            }
        //            if (!flage)
        //            {
        //                JMessages.Error("مالکین اولیه یا سهام آنها یکی نیست.","erroe");
        //                return false;
        //            }                    

        //        }
        //        return true;


        //    }
        //    else
        //        return true;                     
        //}

        #endregion
    }

    public class JAggregateUnitBuildss : JSystem
    {
        public JAggregateUnitBuildss[] Items = new JAggregateUnitBuildss[0];
        public JAggregateUnitBuildss()
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
                Where = Where + " And " + JRETableNames.RestAggregateUnitBuild + ".Code=" + pCode;
            string Query = "select Code,dbo.MiladiTOShamsi(Date) 'Date',(select number from estUnitBuild where Code = UnitBuildCode) 'Number' from "
                + JRETableNames.RestAggregateUnitBuild + Where +
                " And " + JPermission.getObjectSql("RealEstate.JAggregateUnitBuild.GetDataTable", JRETableNames.RestAggregateUnitBuild + ".Code");
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
            Nodes.ObjectBase = new JAction("JAggregate", "RealEstate.JAggregateUnitBuild.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "RealEstate.JAggregateUnitBuild.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }

}
