using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;
using Finance;


namespace RealEstate
{
    public enum UnitBuildStatus
    {
        /// <summary>
        /// فعال
        /// </summary>
        Active = 1,
        /// <summary>
        ///غیر فعال  
        /// </summary>
        NonActive = 2,
        /// <summary>
        /// تجمیع
        /// </summary>
        Aggregate = 3,
        /// <summary>
        /// تفکیک
        /// </summary>
        BreakDown = 4,
    }
    /// <summary>
    /// کلاس مربوط به یک واحد از مستغلات
    /// </summary>
    public class JUnitBuild:JRealEstate
    {
        #region Constructor
        public JUnitBuild()
        {
             PrimeryOwner = JPrimaryOwnerBuilds.GetDataTable(-1);
        }
        public JUnitBuild(int pCode)
        {
            GetData(pCode);
            PrimeryOwner = JPrimaryOwnerBuilds.GetDataTable(pCode);
        }

        #endregion

        public static int MaxShareCount = 6;

        #region property
        /// <summary>
        /// کد واحد ساختمان
        /// </summary>
        public int Code
        {
            set;
            get;
        }
        /// <summary>
        /// کد پدر
        /// </summary>
        public int ParentCode
        {
            set;
            get;
        }        
        /// <summary>
        /// کد نوع واحد
        /// </summary>
        public int TypeCode
        {
            get;
            set;
        }
        /// <summary>
        /// کد ساختمانی که واحد در آن مستقر شده است
        /// </summary>
        public int MarketCode
        {
            get;
            set;
        }
        /// <summary>
        /// شماره شناسایی
        /// </summary>
        public string Plaque
        {
            get;
            set;
        }
        /// <summary>
        /// طبقه ای که واحد در آن مستقر است
        /// </summary>
        public int FloorCode
        {
            get;
            set;
        }
        /// <summary>
        /// شماره واحد 
        /// </summary>
        public string Number
        {
            get;
            set;
        }
        /// <summary>
        /// مساحت واحد مربوطه
        /// </summary>
        public double Area
        {
            get;
            set;
        }
        /// <summary>
        /// کاربری
        /// </summary>
        public int UsageCode
        {
            get;
            set;
        }
        /// <summary>
        /// پلاک ثبتی
        /// </summary>
        public string  PlaqueRegistration
        {
            get;
            set;
        }
        /// <summary>
        /// شغل
        /// </summary>
        public int UnitJob { get; set; }
        /// <summary>
        /// قیمت اولیه
        /// </summary>
        public double Price
        {
            get;
            set;
        }
        private DataTable _PrimeryOwner;
        public DataTable PrimeryOwner
        {
            get;
            set;
        }
        /// <summary>
        /// اجاره اولیه
        /// </summary>


        public decimal InitialRental
        {
            get;
            set;
        }
        /// <summary>
        /// مساحت اولیه
        /// </summary>
        public double InitialArea
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime DeliveryDate
        {
            get;
            set;
        }
        /// <summary>
        /// کد زمین
        /// </summary>
        public int GroundCode
        {
            get;
            set;
        }
        public string MarketName
        {
            get
            {
                jMarket market = new jMarket(this.MarketCode);
                return market.Title;
            }
        }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string UDesc
        {
            get;
            set;
        }
        /// <summary>
        /// بالکن
        /// </summary>
        public decimal Balcon
        {
            get;
            set;
        }
        /// <summary>
        /// فازی ای که واحد در آن مستقر است
        /// </summary>
        public int Faz
        {
            get;
            set;
        }
        /// <summary>
        ///کد تفضیلی س÷اد
        /// </summary>
        public int Tafsili1
        {
            get;
            set;
        }
        /// <summary>
        ///کد تفضیلی بازارها
        /// </summary>
        public int Tafsili2
        {
            get;
            set;
        }
        /// <summary>
        /// کد وضعیت
        /// </summary>
        public UnitBuildStatus Status
        {
            get;
            set;
        }
        #endregion

        #region SearchMethod

        public override string ToString()
        {
            return " شماره واحد :" + this.Number + " شماره شناسایی: " + this.Plaque + " واقع در " + this.MarketName;
        }

        public static string Query = "select UB.Code,"
                + JTableNamesClassLibrary.SubBaseDefine + ".name Type," + JTableNamesEstate.Market +
                ".Title Market,UB.MarketCode ,Plaque," + JTableNamesEstate.MarketFloors + ".Name Floor," +
                @"UB.Number,Area , InitialArea,Balcon ,Usage.name Usage,PlaqueRegistration,UB.Status,UDesc,FA.Code FinAssetCode, FA.GWOwners,FA.DFOwners,FA.REOwners,
(Select Fa_Date FROM StaticDates WHERE EN_Date = (Select Top 1 Date  From LegSubjectContract WHERE LegSubjectContract.FinanceCode  = FA.Code AND Type IN
                (Select Code  from legContractType WHERE ContractType IN (Select Code FROM legContractDynamicTypes WHERE AssetTransferType = 2 )) ORDER By LegSubjectContract .Date ) ) FirstTransferDate,    
case UB.Status
                when 1 then N'فعال'
                when 2 then N'غیر فعال'
                when 3 then N'تجمیع در: ' +(Select N'شماره واحد ' + Number+ N' شماره شناسایی '+Plaque   from estUnitBuild Where Code = UB.ParentCode )
                when 4 then N'تفکیک شده' end 'StatusTitle',
                Isnull((select Number from estUnitBuild where Code=UB.ParentCode),'') 'NumberNewUnitBuild',
                (Select Fa_Date From StaticDates WHERE EN_Date = (select Top 1 StartDate from estAnnualRental Where BuildingCode = UB.Code  order by startdate Desc)) StartDateAnnualRental,
                (Select Fa_Date From StaticDates WHERE EN_Date = (select Top 1 EndDate from estAnnualRental Where BuildingCode = UB.Code order by startdate Desc)) EndDateAnnualRental,
                (select Top 1 Price from estAnnualRental Where BuildingCode = UB.Code order by startdate Desc) PriceAnnualRental
                ,PTable.*,UB.Tafsili2
                
                from "
                + JTableNamesEstate.UnitBuild + " UB left outer join " + JTableNamesClassLibrary.SubBaseDefine +
                " on " + JTableNamesClassLibrary.SubBaseDefine + ".Code=" +
                "UB.TypeCode inner join " + JTableNamesEstate.Market + " on " + JTableNamesEstate.Market +
                ".Code=UB.MarketCode inner join " + JTableNamesEstate.MarketFloors +
                " on " + JTableNamesEstate.MarketFloors + ".Code=UB.FloorCode " +
                " inner join estMarketUsage MarketUsage on MarketUsage.Code = UB.UsageCode " +
                " left outer join subdefine  Usage on Usage.Code=MarketUsage.UsageCode  " +
                " LEFT JOIN vfinAsset FA ON UB.Code = Fa.ObjectCode AND FA.ClassName = 'RealEstate.JUnitBuild' ";

        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoury = " select * from " + JTableNamesEstate.UnitBuild + " where Code=" + pCode;
            try
            {
                Db.setQuery(Qoury + " ORDER BY Plaque ");
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
            return false;
        }

        public bool Find(string PlaqueRegister, int marketCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {                
                return Find(PlaqueRegister, marketCode, Db);
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
        /// <summary>
        /// جستجو بر اساس نام مجتمع و پلاک واحد
        /// </summary>
        /// <returns></returns>
        public bool Find(string PlaqueRegister, int marketCode, JDataBase Db)
        {
            string Qoury = "select * from " + JTableNamesEstate.UnitBuild + " where PlaqueRegistration='" + PlaqueRegister + "'and MarketCode=" + JDataBase.Quote(marketCode.ToString());
            //JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    return true;
                }
                return false;
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


        #endregion

        #region Method

        //public override string ToString()
        //{
        //    /// نام مجتمع و شماره شناسایی (شماره پلاک) را به عنوان نام و توضیحات کلاس برمیگرداند. برای درج در توضیحات دارایی ها
        //    return "شماره واحد: " + this.Number + " - شماره شناسایی: " + this.Plaque + " واقع در " + this.MarketName;
        //}

        /// <summary>
        /// توضیحات مربوط به دارایی را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public string GetAssetDesc()
        {
            return this.ToString();
        }
        /// <summary>
        /// درج اعیان
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            return Insert(Db);
        }
        /// <summary>
        /// درج اعیان
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase Db)
        {
            return Insert(Db, true);
        }
        public int Insert(JDataBase Db, bool Transaction)
        {
            int DefaultCode = 999999;            
            JUnitBuildTable JUBT = new JUnitBuildTable();
            JPrimaryOwnerBuild tmp = new JPrimaryOwnerBuild();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JUnitBuild.Insert",this.MarketCode))
                {
                    if (Find(this.PlaqueRegistration, this.MarketCode,Db))
                    {
                        JMessages.Error("این واحد قبلا ثبت شده است", "خطا در ثبت اطلاعات");
                        return 0;
                    }
                    if (Transaction)
                        Db.beginTransaction("InsertPrimeryOwner");

                    JUBT.SetValueProperty(this);
                    JUBT.Status = UnitBuildStatus.Active;
                    Code = JUBT.Insert(Db);
                    if (Code > 0)
                    {
                        //ذخیره اعیان در جدول دارایی
                        JAsset Asset = new JAsset();
                        Asset.ClassName = this.GetType().FullName; //JAssetType.Estates_JUnitBuild;
                        Asset.ObjectCode = Code;
                        Asset.Comment = this.ToString();
                        Asset.Status = JStatusType.Active;
                        Asset.MaxCount = MaxShareCount;
                        Asset.DivideType = JDivideType.DecimalDivide;
                        Asset.GroupCode = this.MarketCode;
                        /// ارزش دارایی
                        Asset.Value = Convert.ToDecimal(this.Price * this.Area);

                        int Assetcode = Asset.Insert(Db);
                        if (Assetcode < 1)
                        {
                            if (Transaction)
                                Db.Rollback("InsertPrimeryOwner");
                            return 0;
                        }
                        //asset
                        JAssetTransfer AssetTransfer = new JAssetTransfer(Assetcode, JOwnershipType.Definitive, Db);
                        if (AssetTransfer.Code == 0)
                        {
                            AssetTransfer.ClassName = "RealEstate.JPrimaryOwnerBuild";
                            AssetTransfer.ObjectCode = this.Code;
                            AssetTransfer.ACode = Assetcode;
                            AssetTransfer.Comment = JLanguages._Text("PrimaryOwnersOfUnitBuildPlaque:") + this.Number;
                        }

                        JAssetTransfer AssetTransferGW = new JAssetTransfer(Assetcode, JOwnershipType.Goodwill, Db);
                        if (AssetTransferGW.Code == 0)
                        {
                            AssetTransferGW.ClassName = "RealEstate.JPrimaryOwnerBuild";
                            AssetTransferGW.ObjectCode = this.Code;
                            AssetTransferGW.ACode = Assetcode;
                            AssetTransferGW.Comment = JLanguages._Text("PrimaryGoodWillOwnersOfUnitBuildPlaque:") + this.Number;
                        }
                        //-----
                        //Add Relation
                        JRelation tmpJRelation = new JRelation();
                        tmpJRelation.PrimaryClassName = "RealEstate.JUnitBuild";
                        tmpJRelation.PrimaryObjectCode = Code;
                        tmpJRelation.ForeignClassName = "ClassLibrary.Asset";
                        tmpJRelation.ForeignObjectCode = Assetcode;
                        tmpJRelation.Comment = "برای این اعیان دارائی ثبت شده است";
                        if (!tmpJRelation.Insert(Db))
                            return -1;

                        if (tmp.Save(Code,this.PrimeryOwner, Db, AssetTransfer, AssetTransferGW))
                        {
                            if (!AssetTransfer.Insert(Db) || !AssetTransferGW.Insert(Db))
                            {
                                if (Transaction)
                                    Db.Rollback("InsertPrimeryOwner");
                                return 0;
                            }
                            Histroy.Save(this, JUBT, Code, "Insert");
                            if (Transaction)
                                if (Db.Commit())
                                    try
                                    {
                                        Nodes.DataTable.Merge(JUnitBuilds.GetDataTable(Code));
                                    }
                                    catch
                                    {
                                    }

                            return Code;
                        }
                        if (Transaction)
                            Db.Rollback("InsertPrimeryOwner");
                        return 0;
                    }
                    if (Transaction)
                        Db.Rollback("InsertPrimeryOwner");
                    return 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                if (Transaction)
                    Db.Rollback("InsertPrimeryOwner");
                return 0;
            }
            finally
            {
                if (Transaction)
                    Db.Dispose();
            }           
        }

        /// <summary>
        /// در لیست مالکین اولیه شخص خاصی را جستجو میکند
        /// </summary>
        /// <param name="pPCode">کد شخص</param>
        /// <returns></returns>
        public bool FindPrimaryOwner(int pPCode)
        {
            return PrimeryOwner.Select(" PCode = " + pPCode.ToString()).Count() > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Db"></param>
        /// <returns></returns>
        //public bool Update(JDataBase Db)
        //{
        //    JUnitBuildTable JAGsT = new JUnitBuildTable();
        //    try
        //    {
        //        JAGsT.SetValueProperty(this);
        //        return JAGsT.Update(Db);
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        JAGsT.Dispose();
        //    }
        //}

        /// <summary>
        /// ویرایش اعیان
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return Update(null);
        }
        public bool Update(JDataBase pDB)
        {
            return Update(pDB, true);
        }
        public bool Update(JDataBase pDB, bool Transaction)
        {
            //if (Find(this.Plaque, this.MarketCode))
            //{
             //   JMessages.Error("این واحد قبلا ثبت شده است", "خطا در ثبت اطلاعات");
            //    return false;
            //}
            JUnitBuildTable JUBT = new JUnitBuildTable();
            JPrimaryOwnerBuild tmp = new JPrimaryOwnerBuild();

            JDataBase Db;
            if (pDB == null)
                Db = JGlobal.MainFrame.GetDBO();
            else
                Db = pDB;
            try
            {
                if (JPermission.CheckPermission("RealEstate.JUnitBuild.Update", this.MarketCode))
                {
                    if (Transaction)
                        Db.beginTransaction("UpdateBuild");

                    JUBT.SetValueProperty(this);
                    if (JUBT.Update(Db))
                    {
                        JAsset asset = new JAsset(this.GetType().FullName, this.Code, Db);
                        asset.Value = Convert.ToDecimal(this.Price * this.Area);
                        asset.Comment = this.ToString();
                        if (asset.Update(Db))
                        {
                            //asset
                            JAssetTransfer AssetTransfer = new JAssetTransfer(asset.Code, JOwnershipType.Definitive, Db);
                            if (AssetTransfer.Code == 0)
                            {
                                AssetTransfer.ClassName = "RealEstate.JPrimaryOwnerBuild";
                                AssetTransfer.ObjectCode = this.Code;
                                AssetTransfer.ACode = asset.Code;
                                AssetTransfer.Comment = JLanguages._Text("PrimaryOwnersOfUnitBuildPlaque:") + this.Number;
                            }
                            JAssetTransfer AssetTransferGW = new JAssetTransfer(asset.Code, JOwnershipType.Definitive, Db);
                            if (AssetTransfer.Code == 0)
                            {
                                AssetTransferGW.ClassName = "RealEstate.JPrimaryOwnerBuild";
                                AssetTransferGW.ObjectCode = this.Code;
                                AssetTransferGW.ACode = asset.Code;
                                AssetTransferGW.Comment = JLanguages._Text("PrimaryOwnersOfUnitBuildPlaque:") + this.Number;
                            }
                            //----- Hassanzadeh
                            bool flag=false;
                            foreach (DataRow Row in this.PrimeryOwner.Rows)                            
                                if ((Row.RowState == DataRowState.Added) || (Row.RowState == DataRowState.Deleted) || (Row.RowState == DataRowState.Modified))
                                    flag = true;                            
                            if(flag)
                            if (tmp.Save(this.Code, this.PrimeryOwner, Db, AssetTransfer, AssetTransferGW))
                            {
                                //Hassanzadeh
                                if (AssetTransfer.Code == 0)
                                {
                                    if (!AssetTransfer.Insert(Db))
                                    {
                                        if (Transaction)
                                            Db.Rollback("UpdateBuild");
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (!AssetTransfer.Update(Db))
                                    {
                                        if (Transaction)
                                            Db.Rollback("UpdateBuild");
                                        return false;
                                    }
                                }
                                if (AssetTransferGW.Code == 0)
                                {
                                    if (!AssetTransferGW.Insert(Db))
                                    {
                                        if (Transaction)
                                            Db.Rollback("UpdateBuild");
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (!AssetTransferGW.Update(Db))
                                    {
                                        if (Transaction)
                                            Db.Rollback("UpdateBuild");
                                        return false;
                                    }
                                }
                                //if (!AssetTransfer.Update(Db) ||!AssetTransferGW.Update(Db))
                                //{
                                //    if (Transaction)
                                //        Db.Rollback("UpdateBuild");
                                //    return false;
                                //}
                            }
                            else
                            {
                                if (Transaction)
                                    Db.Rollback("UpdateBuild");
                                return false;
                            }


                                Histroy.Save(this, JUBT, Code, "Update");
                                if (Transaction)
                                    Db.Commit();
                                try
                                {
                                    if (Nodes.CurrentNode != null && Transaction)
                                        Nodes.Refreshdata(Nodes.CurrentNode, JUnitBuilds.GetDataTable(this.Code).Rows[0]);
                                }
                                catch
                                {
                                }
                                return true;
                            //}
                            //else
                            //{
                            //    if (Transaction)
                            //        Db.Rollback("UpdateBuild");
                            //    return false;
                            //}
                        }
                        else
                        {
                            if (Transaction)
                                Db.Rollback("UpdateBuild");
                            return false;
                        }
                    }
                    else
                    {
                        if (Transaction)
                            Db.Rollback("UpdateBuild");
                        return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                if (Transaction)
                    Db.Rollback("UpdateBuild");
                return false;
            }
            finally
            {
                if (Transaction)
                    Db.Dispose();
            }
            
        }

        /// <summary>
        /// حذف اعیان
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            return Delete(Db);
        }
        /// <summary>
        /// حذف اعیان
        /// </summary>
        /// <returns></returns>
        public bool Delete(JDataBase Db)
        {
            return Delete(Db, true);
        }
        public bool Delete(JDataBase Db, bool Transaction)
        {
            //JDataBase Db = JGlobal.MainFrame.GetDBO();
            string[] parameters = { "@Item" };
            string[] values = { "UnitBuild" };
            string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
            if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            } 
            
                JUnitBuildTable JUBT = new JUnitBuildTable();
                
                try
                {
                    if (JPermission.CheckPermission("RealEstate.JUnitBuild.Delete", this.MarketCode))
                    {
                        if (Transaction)
                            Db.beginTransaction("DeleteBuild");

                        JPrimaryOwnerBuild tmp = new JPrimaryOwnerBuild();
                        tmp.DeleteRelation(Db,Code);
                        //JPrimaryOwnerBuildTable JPOBT = new JPrimaryOwnerBuildTable();
                        //JPOBT.DeleteManual(JPrimaryOwnerBuildTableEnum.BuildCode.ToString() + "=" + this.Code, Db);

                        JUBT.SetValueProperty(this);
                        if (JUBT.Delete(Db))
                        {
                            //حذف اعیان از جدول دارایی ها
                            JAsset Asset = new JAsset(this.GetType().FullName, this.Code, Db);
                            if (Asset.Delete(Db))
                            {
                                ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                                AD.DeleteArchive(this.GetType().FullName, Code, true);
                                Nodes.Delete(Nodes.CurrentNode);

                                //Delete Relation
                                Asset.GetData("RealEstate.JUnitBuild", JUBT.Code, Db);
                                JRelation tmpJRelation = new JRelation();
                                if (!tmpJRelation.Delete("ClassLibrary.Asset", Asset.Code, Db))
                                {
                                    if (Transaction)
                                        Db.Rollback("DeleteBuild");
                                    return false;
                                }

                                if (Transaction)
                                    Db.Commit();
                                return true;
                            }
                            else
                            {
                                if (Transaction)
                                    Db.Rollback("DeleteBuild");
                                return false;

                            }
                        }
                        else
                        {
                            if (Transaction)
                                Db.Rollback("DeleteBuild");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    if (Transaction)
                        Db.Rollback("DeleteBuild");
                }
                finally
                {
                    if (Transaction)
                        Db.Dispose();
                }
            return false;
        }
        

        #endregion

        #region Node
        public JNode GetNode(DataRow DR)
        {
            int _code = int.Parse(DR["Code"].ToString());
            JNode Node = new JNode(_code, this);
            Node.Name = DR[JUnitBuildTableEnum.Plaque.ToString()].ToString() +
                "\n"+ DR[JUnitBuildTableEnum.Market.ToString()].ToString();
            Node.Hint = "شماره شناسایی: " + DR[JUnitBuildTableEnum.Plaque.ToString()].ToString() + "\n" +
                "شماره واحد: " + DR[JUnitBuildTableEnum.Number.ToString()].ToString();

            //if (DR["Status"].ToString() == "1")
            Node.Icone = JImageIndex.unitbuild.GetHashCode();
            if ((DR["Status"].ToString() != "") && Convert.ToInt32(DR["Status"].ToString()) > 1)
                Node.Icone = JImageIndex.lock_48.GetHashCode();

            //اکشن جدید
            JAction newAction = new JAction("new...", "RealEstate.JUnitBuild.ShowDialog", new object[] { 0, (int)DR["MarketCode"] }, null);           
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "RealEstate.JUnitBuild.ShowDialog", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction DelAction = new JAction("delete...", "RealEstate.JUnitBuild.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DelAction;
            //اکشن اطلاعات
            JAction InformationAction = new JAction("Information UnitBuild...", "RealEstate.JUnitBuild.ShowInformationDialog", new object[] { Node.Code }, null);
            //اکشن انتقال
            JAction TransferAction = null;
            int i = 0;
            if (DR["FinAssetCode"] != null && int.TryParse(DR["FinAssetCode"].ToString(), out i))
                TransferAction = new JAction("Transfer UnitBuild...", "RealEstate.JUnitBuild.ShowTransferDialog", new object[] { (int)DR["FinAssetCode"] }, null);

            JAction BillAction = new JAction("PrintBill...", "RealEstate.JChargeBuild.Show", new object[] { Node.Code }, null);

            JAction ConvertEnvAction = new JAction("Convert To Enviroment", "RealEstate.JUnitBuild.ConvertToEnviroment", new object[] { Node.Code, (int)DR["MarketCode"] }, null);

            JAction Service = new JAction("Services...", "RealEstate.JUnitBuild.GetService", new object[] { Node.Code, (int)DR["MarketCode"] }, null);

            JPopupMenu pMenu = new JPopupMenu("RealEstate.JUnitBuild", Node.Code);

            JAction AnnualRental = new JAction("AnnualRental...", "RealEstate.JAnnualRental.ShowDialog", new object[] { Node.Code }, null);

            JAction DeleteAllContract = new JAction("DeleteAllContract...", "RealEstate.JUnitBuild.DeleteAllContract", new object[] { Node.Code }, null);

            if (ClassLibrary.JMainFrame.IsAdmin)
                pMenu.Insert(DeleteAllContract);
            pMenu.Insert(AnnualRental);
            pMenu.Insert(Service);
            pMenu.Insert(ConvertEnvAction);
            pMenu.Insert(BillAction);
            pMenu.Insert(InformationAction);
            pMenu.Insert(TransferAction);
            pMenu.Insert("-");
            pMenu.Insert(DelAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);
            Node.Popup = pMenu;
            return Node;
        }
        public  void GetService(int SCode,int SMarket)
        {
            AmalkardFrm frm = new AmalkardFrm(SCode, SMarket);
             frm.ShowDialog();
        }

        public void DeleteAllContract(int SCode)
        {
            if (!ClassLibrary.JMainFrame.IsAdmin)
                return;
            if (JMessages.Confirm("حذف کل قراردادهای واحد", "آیا مطما هستید؟") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    DB.setQuery("exec DeleteAllShopContract " + SCode);
                    DB.Query_Execute();
                    JMessages.Message("کل قراردادها حذف شد", "کل قراردادها حذف شد", JMessageType.Information);
                }
                catch
                {

                }
                finally
                {
                    DB.Dispose();
                }
            }
        }
        public void ShowDialog()
        {
            JUnitBuildForm UBf = new JUnitBuildForm();
            UBf.State = JFormState.Insert;
            UBf.ShowDialog();
            if (UBf.DialogResult == System.Windows.Forms.DialogResult.Retry)
                ShowDialog();
        }

        public void ShowDialog(int TempCode, int pConstructionCode)
        {
           // if (JPermission.CheckPermission("RealEstate.JUnitBuild.Insert", pConstructionCode))
            {

                JUnitBuildForm UBf = new JUnitBuildForm(TempCode, pConstructionCode);
                UBf.State = JFormState.Insert;
                UBf.ShowDialog();
                if (UBf.DialogResult == System.Windows.Forms.DialogResult.Retry)
                    ShowDialog();
            }
        }

        public void ShowDialog(int pCode)
        {            
            JUnitBuildForm UBf = new JUnitBuildForm(pCode);
            UBf.State = JFormState.Update;
            UBf.ShowDialog();
            if (UBf.DialogResult == System.Windows.Forms.DialogResult.Retry)
                ShowDialog();
        }

        public void ShowTransferDialog(int pCode)
        {
            JTransferForm p = new JTransferForm(pCode);
            //p.State = JFormState.Update;
            p.ShowDialog();
        }

        public void ShowInformationDialog(int pCode)
        {
                JInformationUnitBuildForm p = new JInformationUnitBuildForm(pCode);
                p.State = JFormState.Update;
                p.ShowDialog();
        }

        public int[] AdvancedSearch()
        {
            return AdvancedSearch(false);
        }
        public int[] AdvancedSearch(bool pMultiSelect)
        {
            JSearchUnitForm searchForm = new JSearchUnitForm();
            searchForm.MultiSelect = pMultiSelect;
            if (searchForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return searchForm.SelectedCodes;
            }
            return null;
        }

        public static bool FindGround(int pGroundCode, int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pCode != 0)
                    Where = " And Code <> " + pCode.ToString();
                Db.setQuery("Select * from " + JTableNamesEstate.UnitBuild + " Where GroundCode = " + pGroundCode + Where);
                if (Db.Query_DataTable().Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion

        #region Asset

        public string GetAssetComment(int Code)
        {
            GetData(Code);
            string Seperator=" ";
            return "شماره واحد: " + Number + " - شماره شناسایی: " + Plaque + " واقع در " + MarketName + "\r\n" + "پلاک ثبتی: " + PlaqueRegistration.ToString() + Seperator + Seperator + "متراژ: " + Area + "\r\n" + "قیمت هر متر مربع در زمان واگذاری: " + JMoney.StringToMoney(Price.ToString()) + Seperator + "اجاره اولیه:" + JMoney.StringToMoney(InitialRental.ToString());
                //Plaque.ToString() + "پلاک واحد" + Number.ToString() + "شماره واحد" + Area.ToString() + "مساحت" + Price.ToString() + "قیمت اولیه";
        }

        public string GetAssetUnit()
        {
            return "Area";
        }
        /// <summary>
        /// فیلدهای این دارایی را با توجه به فیلدهایی که برای قرارداد داریم برمیگرداند
        /// </summary>
        /// <returns></returns>
        public DataTable FieldList()
        {
            return FieldList("", 0);
        }
        public DataTable FieldList(string pClassName, int pObjectCode)
        {
            //try
            {
                DataTable tmpdt = GetContractData(0, pClassName, pObjectCode);
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("text");
                for (int i = 0; i < tmpdt.Columns.Count; i++)
                {
                    if (tmpdt.Columns[i].ColumnName != "ClassName" && tmpdt.Columns[i].ColumnName != "ObjectCode"
                        && tmpdt.Columns[i].ColumnName != "نام کلاس" && tmpdt.Columns[i].ColumnName != "کد شی" && tmpdt.Columns[i].ColumnName != "کد")
                    {
                        DataRow dr = dt.NewRow();
                        dr["name"] = tmpdt.Columns[i].Caption;
                        dr["text"] = JLanguages._Text(tmpdt.Columns[i].Caption);
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //    return null;
            //}
        }
        /// <summary>
        /// اطلاعاتی را که برای قرارداد احتیاج داریم را برمیگرداند
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetContractData(int pCode)
        {
            return GetContractData(pCode, "", 0);
        }
        public DataTable GetContractData(int pCode, string pClassName, int pObjectCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                int MarketCode = (new JUnitBuild(pCode)).MarketCode;
                string PrtTable = (new Globals.Property.JProperties(pClassName, pObjectCode).TableName);

                string Query = "select "
               + JTableNamesClassLibrary.SubBaseDefine + ".name as 'Build.Type'," + JTableNamesEstate.Market +
               ".Title as 'Build.Market',estUnitBuild.Number 'Build.Plaque'," + JTableNamesEstate.MarketFloors + ".Name as 'Build.Floor',"
               + JTableNamesEstate.UnitBuild + @".Plaque  as 'Build.Number',Area as 'Build.Area',InitialArea as 'Build.InitialArea',Usage.name as 'Build.Usage', 
                Jobs.Name 'Build.Job', PlaqueRegistration as 'Build.PlaqueRegistration', Balcon as 'Build.Balcon' "
               + @",cast(estUnitBuild.Price as varchar) 'Build.Price'
                  ,cast(cast(estUnitBuild.Price*estUnitBuild.Area as bigint) as varchar) 'Build.AreaPrice'
                  ,cast(cast(estUnitBuild.Price*estUnitBuild.InitialArea as bigint) as varchar) 'Build.InitialAreaPrice'";

                if (pClassName != "" && pObjectCode != 0)
                    Query = Query + ",PRT.* ";
                Query = Query + " from "
               + JTableNamesEstate.UnitBuild + " left outer join " + JTableNamesClassLibrary.SubBaseDefine +
               " on " + JTableNamesClassLibrary.SubBaseDefine + ".Code=" + JTableNamesEstate.UnitBuild +
               ".TypeCode inner join " + JTableNamesEstate.Market + " on " + JTableNamesEstate.Market +
               ".Code=" + JTableNamesEstate.UnitBuild + ".MarketCode inner join " + JTableNamesEstate.MarketFloors +
               " on " + JTableNamesEstate.MarketFloors + ".Code=" + JTableNamesEstate.UnitBuild + ".FloorCode " +
                    //" left join " + JTableNamesClassLibrary.SubBaseDefine + " Usage on Usage.Code=" + JTableNamesEstate.UnitBuild + ".UsageCode "+
               @" left join estMarketUsage on  estUnitBuild.UsageCode  = estMarketUsage.Code   
                 left join subdefine Usage on estMarketUsage.UsageCode = Usage.Code 
                left join " + JTableNamesClassLibrary.SubBaseDefine + " Jobs on Jobs.Code=" + JTableNamesEstate.UnitBuild + ".UnitJob ";
                if (pClassName != "" && pObjectCode != 0)
                    Query = Query + " LEFT JOIN " + PrtTable + " PRT ON PRT.ObjectCode = estUnitBuild.Code";
                Db.setQuery(Query + " Where " + JTableNamesEstate.UnitBuild + ".Code=" + pCode);
                DataTable tmpdt = Db.Query_DataTable();
                if (tmpdt.Rows.Count == 1)
                {
                    tmpdt.Rows[0]["Build.Price"]=JMoney.StringToMoney(tmpdt.Rows[0]["Build.Price"].ToString());
                    tmpdt.Rows[0]["Build.AreaPrice"]=JMoney.StringToMoney(tmpdt.Rows[0]["Build.AreaPrice"].ToString());
                    tmpdt.Rows[0]["Build.InitialAreaPrice"] = JMoney.StringToMoney(tmpdt.Rows[0]["Build.InitialAreaPrice"].ToString());
                    tmpdt.AcceptChanges();
                }
                if (pClassName != "" && pObjectCode != 0)
                {
                    Query = @"select pf.name prtName, cols.name  from sys.columns cols  inner Join propertydefinetables pf on REPLACE(cols.name , '__', ' ')= pf.Name
                    And pf.ObjectCode=" + pObjectCode + " And ClassName='" + pClassName + @"' 
                    where object_id = object_id(" + JDataBase.Quote(PrtTable) + ") and pf.DataType = N'تصمیم'";
                    Db.setQuery(Query);
                    DataTable prtBitsValues = Db.Query_DataTable();
                    foreach (DataRow row in prtBitsValues.Rows)
                    {
                        tmpdt.Columns.Add("عنوان " + row["name"].ToString());
                        if (tmpdt.Rows.Count >0 && tmpdt.Rows[0][row["name"].ToString()].ToString() == "True")
                        {
                            tmpdt.Rows[0]["عنوان " + row["name"].ToString()] = row["prtName"].ToString();
                        }
                    }
                }
                /// تلفنهای اعیان
                tmpdt.Columns.Add("Build.Tel");
                Db.setQuery(@" SELECT  STUFF   ( (   
                    SELECT ', ' + Tel 
                    FROM estUnitBuildTels  where  UnitBuildCode  = " + pCode.ToString() +
                   @" FOR XML PATH ('')),1,1,'' ) AS 'Build.Tel' ");

                DataTable tels = Db.Query_DataTable();
                if (tmpdt.Rows.Count > 0)
                    tmpdt.Rows[0]["Build.Tel"] = tels.Rows[0][0];
                //tmpdt.Merge(tels);
                foreach (DataColumn DC in tmpdt.Columns)
                {
                    DC.Caption = JLanguages._Text(DC.Caption);
                    DC.ColumnName = JLanguages._Text(DC.Caption);
                }
                return tmpdt;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null; ;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion


        public void ConvertToEnviroment(int pUnitCode, int pMarkCode)
        {

            if (!JPermission.CheckPermission("RealEstate.JUnitBuild.ConvertToEnviroment", pMarkCode))
                return;
            if (JMessages.Question("Are You Sure?", "Convert To Envirment") != System.Windows.Forms.DialogResult.Yes)
                return;

            string _Query = @"

declare @UnitBuildCode int
declare @MarkCode int
declare @MaxCode int

set @UnitBuildCode = pUnitCode
set @MarkCode = pMarkCode
---------------------------------------
set @MaxCode = (select MAX(Code) from ReEnviromentTable)+1
Insert Into ReEnviromentTable 
(Code,Area,moneyBaseCharge,Complex,Address,moneyBase,state,CodeEnviroment,TypeEnviroment,NameEnviroment,CodeFloor,Door,ISArchive,Tafsili) 
(select @MaxCode,Area,0,@MarkCode,'',0,1,0,(SELECT MIN(Code)FROM [ReJointTable]),Plaque,FloorCode,0,0,null from estUnitBuild where Code = @UnitBuildCode)
---------------------------------------
update finAsset set ClassName = 'RealEstate.JEnviroment' , ObjectCode =@MaxCode  where ClassName = 'RealEstate.JUnitBuild' and ObjectCode = @UnitBuildCode
update finAssetTransfer Set ClassName='RealEstate.JPrimaryOwnerEnviroment' Where ACode IN
(
select Code from finAsset where ClassName = 'RealEstate.JEnviroment' AND ObjectCode =@MaxCode
)
---------------------------------------
delete estPrimaryOwnerBuild where estPrimaryOwnerBuild.BuildCode = @UnitBuildCode
delete estUnitBuild where Code = @UnitBuildCode
---------------------------------------
SELECT @MaxCode";
            _Query = _Query.Replace("pUnitCode", pUnitCode.ToString());
            _Query = _Query.Replace("pMarkCode", pMarkCode.ToString());

            JDataBase db = new JDataBase();
            db.beginTransaction("ConvertEnv");
            try
            {
                db.setQuery(_Query);
                int EnvCode = int.Parse(db.Query_ExecutSacler().ToString());
                if (EnvCode > 0)
                {
                    db.Commit();
                    JEnviroment Env = new JEnviroment();
                    if (Env.ShowForm(EnvCode))
                    {
                    }
                }
                else
                {
                    db.Rollback("ConvertEnv");
                }
            }
            finally
            {
                db.DisConnect();
            }
        }

        public double GetPrice(int pCode)
        {
            GetData(pCode);
            return Price * Area;
        }
    }

    public class JUnitBuilds : JRealEstate
    {

        public void ListView()
        {
            ListView(0);
        }

        public void ListView(int pMCode)
        {
            Nodes.ObjectBase = new JAction("JUnitBuild", "RealEstate.JUnitBuild.GetNode");
            Nodes.hidColumns = "Status";
            Nodes.DataTable = GetDataTable(0, pMCode);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JUnitBuild", "RealEstate.JUnitBuild.ShowDialog", new object[] { 0, pMCode }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert(new JAction("new...", "RealEstate.JUnitBuild.ShowDialog", new object[] { 0, pMCode }, null)); 
        }

        public static DataTable GetDataTable(int pCode)
        {
            return GetDataTable(pCode, 0);
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0, 0);
        }

        /// <summary>
        /// لیست اعیان واقع در یک مجتمع 
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pMCode"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode, int pMCode)
        {
            return GetDataTable(pCode, pMCode, 0);
        }
        /// <summary>
        /// لیست اعیان واقع در یک مجتمع در یک طبقه خاص
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pMCode"></param>
        /// <param name="pFloorCode"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode, int pMCode, int pFloorCode)
        {
            string Qouery = JUnitBuild.Query;
            Globals.Property.JPropertyTables PT = new Globals.Property.JPropertyTables("RealEstate.jMarket", pMCode);
            if (PT.TableName != null && PT.HasTableName)
            {
                Qouery += " Left join " + PT.TableName + " PTable on PTable.ObjectCode = UB.Code";
                Qouery = Qouery.Replace(",PTable.*", PT.FieldNames);
            }
            else
            {
                Qouery = Qouery.Replace(",PTable.*", "");
            }
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = " WHERE 1=1 ";
            try
            {
                if (pCode > 0)
                    Where = Where + " AND UB.Code=" + pCode;
                if (pMCode > 0)
                    Where = Where + " AND UB.MarketCode=" + pMCode;
                if (pFloorCode> 0)
                    Where = Where + " And UB.FloorCode=" + pFloorCode;
                Db.setQuery(Qouery + Where + 
                    " And " + JPermission.getObjectSql("RealEstate.JUnitBuilds.GetDataTable" ,  "UB.MarketCode") + 
                    //" And " + JPermission.getObjectSql("RealEstate.jMarkets.GetDataTable",JTableNamesEstate.Market + ".Code") +
                    " ORDER BY " +
                    JUnitBuildTableEnum.Market.ToString() + ",UB.Number, Plaque");
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
      
        public static DataTable Search(int pCode, int pTypeCode, int pMarketCode, string pPlaque, string pNumber, int pFloorCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = JUnitBuild.Query + " WHERE (UB.Status = 1) And 1=1 ";
                if (pCode > 0)
                    Query = Query + " AND Code = " + pCode;
                if (pTypeCode > 0)
                    Query = Query + " AND " + JUnitBuildTableEnum.TypeCode.ToString() + "=" + pTypeCode.ToString();
                if (pMarketCode > 0)
                    Query = Query + " AND UB." + JUnitBuildTableEnum.MarketCode.ToString() + "=" + pMarketCode.ToString();
                if (pPlaque != "")
                    Query = Query + " AND " + JUnitBuildTableEnum.Plaque.ToString() + "=" +JDataBase.Quote(pPlaque.ToString());
                if (pFloorCode > 0)
                    Query = Query + " AND " + JUnitBuildTableEnum.FloorCode.ToString() + "=" + pFloorCode.ToString();
                if (pNumber != "")
                    Query = Query + " AND UB." +JUnitBuildTableEnum.Number.ToString() + "=" + JDataBase.Quote(pNumber.ToString());
                if (pMarketCode != 0)
                {
                    Globals.Property.JPropertyTables PT = new Globals.Property.JPropertyTables("RealEstate.jMarket", pMarketCode);
                    if (PT.TableName != null && PT.HasTableName)
                    {
                        Query += " Left join " + PT.TableName + " PTable on PTable.ObjectCode = UB.Code";
                        Query = Query.Replace(",PTable.*", PT.FieldNames);
                    }
                    else
                    {
                        Query = Query.Replace(",PTable.*", "");
                    }
                }
                else
                {
                    Query = Query.Replace(",PTable.*", "");
                }
                DB.setQuery(Query);
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

    }
}
