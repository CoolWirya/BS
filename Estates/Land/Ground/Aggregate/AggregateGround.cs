using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;
 

namespace Estates
{
    /// <summary>
    /// تجمیع زمین
    /// </summary>
    public class JAggregateGround:JSystem
    {
        #region Property
        public JAggregateGround()
        {
            GroundsAggregationby = JAggregateGroundsAll.GetDataTable(0);
            GroundAggregationby=new JGround();
        }
        public JAggregateGround(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// شماره نامه تجمیع
        /// </summary>
        public string LetterNum { get; set; }
        /// <summary>
        /// تاریخ نامه تجمیع  
        /// </summary>
        public DateTime LetterDate { get; set; }
        /// <summary>
        /// کد زمین حاصل از تجمیع زمین ها
        /// </summary>
        public int GroundAggregationbyCode { get; set; }
        /// <summary>
        ///  زمین حاصل از تجمیع زمین ها
        /// </summary>
        public JGround GroundAggregationby { get; set; }
        /// <summary>
        /// جدول زمین هایی که تجمیع خواهند شده
        /// </summary>
        public DataTable GroundsAggregationby { set; get; }
        /// <summary>
        /// نام اداره مخاطب
        /// </summary>
        public string RegistrationOffice { set; get; }
        /// <summary>
        /// متن درخواست تجمیع
        /// </summary>
        public string TextReuest { set; get; }
        
                      


        #endregion
        #region GetData&Showdata&Find
        public bool GetData(int pCode)
        {
            string Qouery = "select * from "+JTableNamesEstates.AggregateGround+" where Code="+pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    JGround GroundAggregated = new JGround(this.GroundAggregationbyCode);
                    this.GroundAggregationby = GroundAggregated;
                    this.GroundsAggregationby = JAggregateGroundsAll.GetDataTable(this.GroundAggregationbyCode);
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
            JNode Node = new JNode((int)pRow["code"],"Estates.JAggregateGround");
            Node.Name = JLanguages._Text("mainave ") + pRow[JGroundTableEnum.MainAve.ToString()] +
                "\n" + JLanguages._Text("subno ") + pRow[JGroundTableEnum.SubNo.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن اضافه
            JAction newAction = new JAction("new...", "Estates.JAggregateGround.ShowDialog", null, null);
            //اکشن حذف 
            JAction delAction = new JAction("delete...", "Estates.JAggregateGround.Delete", null, new object []{Node.Code});
            Node.DeleteClickAction = delAction;
            //اکشن نمایش
            JAction ShowAction = new JAction("Show...", "Estates.JAggregateGround.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = ShowAction;
            Node.EnterClickAction = ShowAction;
            JPopupMenu PMenu = new JPopupMenu("Estates.JAggregateGround", Node.Code);
            PMenu.Insert(delAction);
            PMenu.Insert(ShowAction);
            PMenu.Insert(newAction);
            Node.Popup = PMenu;

            return Node;
        }


        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JAggregateForm JAF = new JAggregateForm();
                JAF.State = JFormState.Insert;
                JAF.ShowDialog();
            }
            else
            {
                JAggregateForm JAF = new JAggregateForm(Code);
                JAF.State = JFormState.ReadOnly;
                JAF.ShowDialog();
            }

        }

        public bool FindGroundAggregate(int pCode)
        {
            return GroundsAggregationby.Select("GroundsAggregationbyCode=" + pCode.ToString()).Count() > 0;

        }
        /// <summary>
        /// چک کردن برابر بودن مالکین اولیه و سهام آن ها برای تجمیع
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool CheckSharePrimaryOwner(int pCode)
        {
            if (GroundsAggregationby.Rows.Count > 0)
            {
                JAsset FirstGroundAsset = new JAsset("Estates.JGround", (int)GroundsAggregationby.Rows[0]["GroundsAggregationbyCode"]);
                DataTable FirstGroundTable = JAssetShares.GetDataTableAssetShareOwner(FirstGroundAsset.Code, JOwnershipType.Definitive);
                JAsset SecondGroundAsset = new JAsset("Estates.JGround", pCode);
                DataTable SecondGroundTable = JAssetShares.GetDataTableAssetShareOwner(SecondGroundAsset.Code, JOwnershipType.Definitive);
                if (FirstGroundTable.Rows.Count != SecondGroundTable.Rows.Count)
                {
                    JMessages.Error("تعداد مالکین  زمین ها یکی نیست", "error");
                    return false;
                }
                foreach (DataRow RowFirst in FirstGroundTable.Rows)
                {
                    bool flage = false;
                    foreach (DataRow RowSecond in SecondGroundTable.Rows)
                    {
                        if (((int)RowFirst["pCode"] == (int)RowSecond["pCode"]) && Convert.ToDouble(RowFirst["PersonShare"]) == (Double)RowSecond["PersonShare"])
                            flage = true;
                        

                    }
                    if (!flage)
                    {
                        JMessages.Error("مالکین اولیه یا سهام آنها یکی نیست.","erroe");
                        return false;
                    }                    
                    
                }
                return true;


            }
            else
                return true;



            
            
        }

        #endregion
        #region Method
        public int Insert()
        {
            int Code;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JAggregateGroundTable JAGT = new JAggregateGroundTable();
            try
            {

                Db.beginTransaction("InsertAgrrateGround");
                GroundAggregationby.Status = JGroundStatus.Aggregated;
                GroundAggregationby.MakeFromName = "Estates.JAggregateGround";
                GroundAggregationby.MakeFromCode = this.Code;
                int newGroundCode = this.GroundAggregationby.Insert(Db);
                if (newGroundCode > 0)
                {
                    this.GroundAggregationbyCode = newGroundCode;
                    JAGT.SetValueProperty(this);
                    Code = JAGT.Insert(Db);
                    
                    if (Code > 0)
                    {
                        //آپدیت AssetTransferمربوط به تجمیع
                        JAsset Asset = new JAsset("Estates.JGround", newGroundCode,Db);
                        JAssetTransfer AssetTransfer = new JAssetTransfer(Asset.Code, JOwnershipType.Definitive, Db);
                        AssetTransfer.ObjectCode = Code;
                        AssetTransfer.Update(Db);
                        //
                        if (JAggregateGroundsAll.Save(this.GroundsAggregationby, newGroundCode, Db))
                        {
                            if(Db.Commit())
                                Nodes.DataTable.Merge(JAggregateGroundAll.GetDataTable(Code));
                            return Code;
                        }
                        Db.Rollback("InsertAgrrateGround");
                        return 0;
                    }
                    else
                        Db.Rollback("InsertAgrrateGround");
                    return 0;
                }
                else
                    Db.Rollback("InsertAgrrateGround");
                return 0;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertAgrrateGround");
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
           
            

        }
        private bool SetPrimaryOwners = false;
        public void SumPrimeryOwnerNewGround()
        {
            int GroundCode;
            int CountGround = GroundsAggregationby.Rows.Count;
            if (SetPrimaryOwners)
                return;
            try
            {
                this.GroundAggregationby.PrimeryOwners.Rows.Clear();
                GroundCode = Convert.ToInt32(GroundsAggregationby.Rows[0][JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                JGround Ground = new JGround();
                JAsset Asset = new JAsset();
                Asset.GetData("Estates.JGround", GroundCode);
                DataTable PrimararyOwnerGrounrd = JAssetShares.GetDataTableAssetShareOwner(Asset.Code, JOwnershipType.Definitive);
                PrimararyOwnerGrounrd.Columns.Remove("Share");
                PrimararyOwnerGrounrd.Columns["PersonShare"].ColumnName = "Share";
                this.GroundAggregationby.PrimeryOwners = PrimararyOwnerGrounrd;

                #region Old
                
                //foreach (DataRow Row in GroundsAggregationby.Rows)
                //{

                //    if (Row.RowState != DataRowState.Deleted)
                //    {

                //        GroundCode = Convert.ToInt32(Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()]);
                //        JGround Ground = new JGround();
                //        JAsset Asset = new JAsset();
                //        Asset.GetData("Estates.JGround", GroundCode);
                //        DataTable PrimararyOwnerGrounrd = JAssetShares.GetDataTableAssetShareOwner(Asset.Code, JOwnershipType.Definitive);
                //        this.GroundAggregationby.PrimeryOwners.Merge(PrimararyOwnerGrounrd);
                //        foreach(DataRow PrimeryRow1 in this.GroundAggregationby.PrimeryOwners.Rows)
                       

                //        for (int i = 0; i < this.GroundAggregationby.PrimeryOwners.Rows.Count; i++)
                //            for (int j = i + 1; j < this.GroundAggregationby.PrimeryOwners.Rows.Count; j++)
                //                if (this.GroundAggregationby.PrimeryOwners.Rows[i].RowState != DataRowState.Deleted && this.GroundAggregationby.PrimeryOwners.Rows[j].RowState != DataRowState.Deleted)
                //                    if ((int)this.GroundAggregationby.PrimeryOwners.Rows[i][JPrimaryOwnerField.PCode.ToString()] == (int)this.GroundAggregationby.PrimeryOwners.Rows[j][JPrimaryOwnerField.PCode.ToString()])
                //                    {
                //                        this.GroundAggregationby.PrimeryOwners.Rows[j].Delete();
                //                    }
                //        GroundAggregationby.PrimeryOwners.AcceptChanges();
                //        SetPrimaryOwners = true;
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                SetPrimaryOwners = false;
            }
                
            GroundsAggregationby.AcceptChanges();

           
        }
        public bool Delete()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JAggregateGroundTable JAGT = new JAggregateGroundTable();
            try
            {
                Db.beginTransaction("InsertAgrrateGround");
                if(this.GroundAggregationby.Delete(Db))
                {
                    if (JAggregateGroundsAll.Delete(this.GroundsAggregationby, Db))
                    {
                        JAGT.SetValueProperty(this);
                        Db.Commit();
                        return JAGT.Delete(Db);
                        
                    }
                    else
                        Db.Rollback("InsertAgrrateGround");
                    return false;
                }
                else
                    Db.Rollback("InsertAgrrateGround");
                return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertAgrrateGround");
                return false;
            }
           

        }
       
        #endregion


    }

    public class JAggregateGroundAll:JSystem
    {
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode > 0)
                Where = " And estAggregateGround.Code=" + pCode;
            string Qouery = @"select "+JTableNamesEstates.AggregateGround+".Code,LetterNum," +
                "(select fa_date from StaticDates where En_Date=Cast(LetterDate as Date)) 'LetterDate'," + JTableNamesEstate.GroundTable + "."
                + JGroundTableEnum.MainAve + "," + JTableNamesEstate.GroundTable +
                "."+JGroundTableEnum.SubNo+" from "+JTableNamesEstates.AggregateGround+
                " inner join " + JTableNamesEstate.GroundTable + " on "+JTableNamesEstates.AggregateGround+
                ".GroundAggregationbyCode=" + JTableNamesEstate.GroundTable + ".Code";
            JDataBase Db=JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery + Where + " And " +
                JPermission.getObjectSql("Estates.JAggregateGroundAll.GetDataTable",
                JTableNamesEstates.AggregateGround + ".Code"));
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("Aggrate", "Estates.JAggregateGround.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("new...", "Estates.JAggregateGround.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);

        }

    }
    

    
}
