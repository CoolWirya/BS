using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Finance
{
    public class JAssetShare : JFinance
    {
        #region Constructor
        public JAssetShare()
        {
        }
        public JAssetShare(int pCode)
        {
            GetData(pCode);
        }
        public JAssetShare(int pCode, JStatusType pStatus, JDataBase pDB)
        {
            GetData(pCode, pStatus, pDB);
        }        

        public JAssetShare(string pClassName, int pObjectCode)
            : this(pClassName, pObjectCode, null)
        {
        }
        /// <summary>
        /// برای استفاده از ترانزکشن باید دیتابیس هم پاس داده شود
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pObjectCode"></param>
        /// <param name="pDB"></param>
        public JAssetShare(string pClassName, int pObjectCode, JDataBase pDB)
        {
            GetData(pClassName, pObjectCode, pDB);
        }
        public JAssetShare(int ACode, int TCode)
            : this(ACode, TCode, null)
        {
        }
        public JAssetShare(int ACode, int TCode, JDataBase pDB)
        {
            GetData(ACode, TCode, pDB);
        }
        #endregion Constructor

        #region Property

        /// <summary>
        /// کد مالکیت
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///کد مالکیت قبلی 
        /// </summary>
        public int ParentCode { get; set; }
        /// <summary>
        /// کد دارائی
        /// </summary>
        public int ACode { get; set; }
        /// <summary>
        /// کد انتقال
        /// </summary>
        public int TCode { get; set; }
        /// <summary>
        /// کد مالک
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        ///درصد مالکیت
        /// </summary>
        public float Share { get; set; }
        /// <summary>
        /// سهم جدید
        /// </summary>
        public float NewShare { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public JStatusType Status { get; set; }
        /// <summary>
        /// شرح دارایی جزء بر اساس شرح دارایی کل
        /// </summary>
        public string Comment { get; set; }
        #endregion

        #region Insert Delete Update

        public int Insert(JDataBase Db)
        {
            JAssetShareTable ASt = new JAssetShareTable();
            ASt.SetValueProperty(this);
            Code = ASt.Insert(Db);
            return Code;
        }

        public bool Update(JDataBase Db)
        {
            JAssetShareTable ASt = new JAssetShareTable();
            ASt.SetValueProperty(this);
            return ASt.Update(Db);
        }

        public bool Delete(JDataBase pDB)
        {
            return Delete(pDB, true);
        }

        public bool Delete(JDataBase pDB, bool CheckChild)
        {
            /// درصورتیکه دارایی فرزند داشته باشد، حذف ممکن نیست
            if (CheckChild && HasChild(pDB))
                return false;
            JAssetShareTable ASt = new JAssetShareTable();
            ASt.SetValueProperty(this);
            if (ASt.Delete(pDB))
            {
                Code = 0;
                return true;
            }
            return false;
        }       

        public int SaveNew(JDataBase DB, string pClassName, int pObjectCode, int pPersonCode, int pShare, JOwnershipType pOwnershipType, string pShareClassName, int pShareObjectCode)
        {
            bool nullDB = false;
            if (DB == null)
            {
                DB = new JDataBase();
                DB.beginTransaction("Asset");
                nullDB = true;
            }
            JAsset Asset = new JAsset();
            Asset.ClassName = pClassName;
            Asset.ObjectCode = pObjectCode;
            ACode = Asset.Insert(DB);
            if (ACode > 0)
            {
                PersonCode = pPersonCode;
                Share = pShare;
                int ret = Insert(DB);
                if (ret > 0)
                {
                    if (nullDB)
                        DB.Commit();
                    return ret;

                }
            }
            if (nullDB)
                DB.Rollback("Asset");
            return 0;
        }

        /// <summary>
        /// تغییر سهم 
        /// /// </summary>
        /// <param name="pDB"></param>
        /// <param name="pCode">assetshare code</param>
        /// <param name="pNewShare"> new share</param>
        /// <returns>-1 is error. 0 is share - newshare=0. >0 is new share</returns>
        public int ChangeShare(JDataBase pDB,JAssetShare pNewShare)
        {
            try
            {
                if (pNewShare.Share > 0) ///Share != pNewShare.Share &&
                {
                    Status = JStatusType.Inactive;
                    Update(pDB);
                    pNewShare.ParentCode = Code;
                    this.Code = pNewShare.Insert(pDB);
                    this.ACode = pNewShare.ACode;
                    this.Comment = pNewShare.Comment;
                    this.NewShare = pNewShare.NewShare;
                    this.ParentCode = pNewShare.ParentCode;
                    this.PersonCode = pNewShare.PersonCode;
                    this.Share = pNewShare.Share;
                    this.Status = pNewShare.Status;
                    this.TCode = pNewShare.TCode;
                    return Code;
                }
                else
                {
                    Status = JStatusType.Inactive;
                    Update(pDB);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
        }
        #endregion

        #region Data

        public static string Query = " SELECT " + JTableNamesFinance.AssetShare + ".* , " + JTableNamesFinance.Asset + "." + finAsset.Comment
            + " FROM " + JTableNamesFinance.AssetShare + " INNER JOIN " + JTableNamesFinance.Asset
            + " ON " + JTableNamesFinance.Asset + ".Code=" + JTableNamesFinance.AssetShare + "." + finAssetShare.ACode.ToString();
        
        public override string ToString()
        {
            return Share.ToString() + " سهم " + "" + JLanguages._Text("From") + " " + this.Comment;
        }
        /// <summary>
        /// جستجو بر اساس کد دارایی جزء
        /// </summary>
        /// <param name="pCode"></param>
        public bool GetData(int pCode)
        {
            return GetData(pCode, null);
        }
        public bool GetData(int pCode, JDataBase pDB)
        {
            return GetData(pCode, JStatusType.Active, pDB);
        }
        public bool GetData(int pCode, JStatusType pStatus, JDataBase pDB)
        {
            string Qouery = JAssetShare.Query + " where "+JTableNamesFinance.AssetShare+".code= " + JDataBase.Quote(pCode.ToString())+
                " AND " +JTableNamesFinance.AssetShare+"."+ finAssetShare.Status.ToString() + "=" + pStatus.GetHashCode().ToString();

            JDataBase Db;
            if (pDB == null)
                Db = JGlobal.MainFrame.GetDBO();
            else
                Db = pDB;
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
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
                if (pDB == null)
                    Db.Dispose();
            }
        }

        public bool GetDataBase(int pCode, JDataBase pDB)
        {
            string Qouery = JAssetShare.Query + " where " + JTableNamesFinance.AssetShare + ".code= " + JDataBase.Quote(pCode.ToString());

            JDataBase Db;
            if (pDB == null)
                Db = JGlobal.MainFrame.GetDBO();
            else
                Db = pDB;
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
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
                Db.Dispose();
            }
        }

        public bool GetData(int pPersonCode,int pTCode, int pACode, JDataBase pDB)
        {
            string Qouery = JAssetShare.Query + " where " +
                JTableNamesFinance.AssetShare + "." + finAssetShare.PersonCode + "= " + pPersonCode.ToString() +
                " AND " +
                JTableNamesFinance.AssetShare + "." + finAssetShare.ACode + "= " + pACode.ToString() +
                " AND " +
                JTableNamesFinance.AssetShare + "." + finAssetShare.TCode + "= " + pTCode.ToString();

            JDataBase Db;
            if (pDB == null)
                Db = JGlobal.MainFrame.GetDBO();
            else
                Db = pDB;
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
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
                Db.Dispose();
            }
        }

        public void GetData(int ACode, int TCode)
        {
            GetData(ACode, TCode, null);
        }
        public void GetData(int ACode, int TCode, JDataBase pDB)
        {
            string Qouery = " SELECT * FROM finAssetShare " +
                " WHERE ACode =" + ACode + " AND TCode = " + TCode +
             " AND " + finAssetShare.Status.ToString() + "=" + JStatusType.Active.GetHashCode().ToString();
            try
            {
                JDataBase db;
                if (pDB == null)
                    db = new JDataBase();
                else
                    db = pDB;
                db.setQuery(Qouery);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// جستجو بر اساس نام کلاس و کد شیء
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pObjectCode"></param>
        public void GetData(string pClassName, int pObjectCode, JDataBase pDB)
        {
            string Qouery = JAssetShare.Query + 
                " WHERE " + finAssetShare.Status.ToString() + "=" + JStatusType.Active.GetHashCode().ToString() +
                " AND " + finAssetShare.ClassName.ToString() + "=" + ClassLibrary.JDataBase.Quote(pClassName) +
                " AND " + finAssetShare.ObjectCode.ToString() + "=" + pObjectCode.ToString();
            try
            {
                pDB.setQuery(Qouery);
                pDB.Query_DataReader();
                if (pDB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, pDB.DataReader);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool Find(int pCode)
        {
            JAssetShareTable ASt = new JAssetShareTable();
            System.Data.DataTable DT = ASt.Query("Code=" + pCode.ToString());
            if (DT.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// بررسی اینکه این دارایی فرزند دارد یا نه
        /// </summary>
        /// <returns></returns>
        private bool HasChild(JDataBase pDB)
        {
            JAssetShareTable ASt = new JAssetShareTable();
            System.Data.DataTable DT = ASt.Query(finAssetShare.Status.ToString() + "=" + JStatusType.Active.GetHashCode().ToString() +
                " AND " + finAssetShare.ACode.ToString() + "=" + this.ACode.ToString() +
                " AND " + finAssetShare.ParentCode.ToString() + "=" + this.Code.ToString(), pDB);
            if (DT.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        #endregion

        #region Nodes

        public void ShowDialog()
        {
            //if (this.Code == 0)
            //{
            JAssetSearchForm PE = new JAssetSearchForm();
            //PE.State = JFormState.Insert;
            PE.ShowDialog();
            //}
            //else
            //{
            //    JAssetSearchForm PE = new JAssetSearchForm(this.Code);
            //    PE.State = JFormState.Update;
            //    PE.ShowDialog();
            //}
        }

        public void SearchDialog()
        {
            if (this.Code == 0)
            {
                JAssetSearchForm PE = new JAssetSearchForm();
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[finAsset.Code.ToString()], "Finance.JAssetShare");
            node.Icone = JImageIndex.DollarCoin.GetHashCode();
            node.Name = pRow[finAsset.Comment.ToString()].ToString();
            node.Hint = JLanguages._Text("ClassName:") + " " + pRow[finAsset.ClassName.ToString()] + "\n" +
                JLanguages._Text("Comment:") + " " + pRow[finAsset.Comment.ToString()];// + "\n" +
            //      JLanguages._Text("Description:") + " " + pRow[LegDecision.DecisionDesc.ToString()];
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Finance.JAssetShare.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Finance.JAssetShare.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Finance.JAssetShare.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }

        
        #endregion

    }

    public class JAssetShares : JFinance
    {
        public List<JAssetShare> Items = new List<JAssetShare>();
        public static DataTable GetDataTable()
        {
            string Query = JAssetShare.Query;
            Query = Query + " And " + JPermission.getObjectSql("Finance.JAsset.Find", "GroupCode");
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
        /// <summary>
        /// سهمهای غیر فعال یک دارایی خاص را برمیگرداند
        /// </summary>
        /// <param name="pACode"></param>
        /// <returns></returns>
        public static DataTable GetInActiveShares(int pACode)
        {
            string Query = JAssetShare.Query + " WHERE ACode = " + pACode.ToString() + " AND " + JTableNamesFinance.AssetShare + "." + finAssetShare.Status.ToString() + " <> " + JStatusType.Active.GetHashCode().ToString();
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }


        /// <summary>
        /// حذف تمام دارایی های جزء یک دارایی کل
        /// </summary>
        /// <param name="pACode"></param>
        /// <returns></returns>
        public static bool DeleteAll(JDataBase pDB, int pACode)
        {
            JAssetShareTable shareTable = new JAssetShareTable();
            return shareTable.DeleteManual(Finance.finAssetShare.ACode.ToString() + " = " + pACode.ToString(), pDB);
        }
        /// <summary>
        /// دارایی های جزئی یک شخص را بر می گرداند
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        public static DataTable GetDataTableAssetSharePerson(int PersonCode)
        {
            JFreeClass.RUN(new JAction("GetDocumant", "ClassLibrary.JMainFrame.Check"));
            string Qouery = "select finAssetShare.Code,finAsset.Comment Title,"
                + JTableNamesClassLibrary.AllPerson + ".Name owner,Share ,legDistraintAssetShare.Code DistraintCode from finAssetShare inner join finAsset on finAssetShare.Acode=finAsset.Code inner join "
                + JTableNamesClassLibrary.AllPerson + " on " + JTableNamesClassLibrary.AllPerson +
                ".Code=finAssetShare.PersonCode left outer join legDistraintAssetShare on finAssetShare.Code=legDistraintAssetShare.AssetShareCode where PersonCode=" + JDataBase.Quote(PersonCode.ToString()) + "and (finAssetShare.status=1 or finAssetShare.status=2) ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Qouery);
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

        /// <summary>
        /// مالکین یک دارایی را بر می گرداند
        /// </summary>
        public static DataTable GetDataTableAssetShareOwner(int pCode, JOwnershipType pOwnerShip)
        {
            string Qouery = @"select fAS.Code,PersonCode PCode,Share as PersonShare 
                ,0 as Share,clsAllPerson.Name ,
                (Select TypeName from finOwnershipTypes where Code = FT.OwnershipType) OwnershipType
                 from finAssetShare fAS 
                INNER JOIN clsAllPerson ON clsAllPerson.Code =fAS.PersonCode  
                INNER JOIN finAssetTransfer FT ON FT.Code =fAS.TCode
                where fAS.Acode=" + pCode + " And fas.Status = 1 ";
     
            if (pOwnerShip != JOwnershipType.None)
                Qouery = Qouery + " AND OwnershipType = " + pOwnerShip.GetHashCode().ToString();
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
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

        /// <summary>
        ///  یک دارایی را بر می گرداند
        /// </summary>
        public static DataTable GetDataTableAssetShareTransfer(int pTCode, JDataBase pDB)
        {
            string Qouery = "select *  from finAssetShare fAS WHERE TCode =" + pTCode;// +" AND Status<>0 ";
            try
            {
                pDB.setQuery(Qouery);
                return pDB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }

        /// <summary>
        /// لیست دارایی های یک شخص را بصورت آیتم برمیگرداند
        /// </summary>
        /// <param name="pCode"></param>
        public void GetPersonAssetShares(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            db.setQuery(JAssetShare.Query + " WHERE " + finAssetShare.PersonCode.ToString() + "=" + pCode.ToString());
            DataTable shares = db.Query_DataTable();
            try
            {
                foreach (DataRow row in shares.Rows)
                {
                    JAssetShare assetSahre = new JAssetShare((int)row["Code"]);
                    JTable.SetToClassProperty(assetSahre, row);
                    Items.Add(assetSahre);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetAsset", "Finance.JAssetShare.GetNode");
            Nodes.DataTable = GetDataTable();

            //JAction newAction = new JAction("New...", "Finance.JAssetShare.ShowDialog", null, null);
            //Nodes.GlobalMenuActions.Insert(newAction);
            //JToolbarNode TN = new JToolbarNode();
            //TN.Icon = JImageIndex.Add;
            //TN.Hint = "New...";
            //TN.Click = newAction;
            //Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Finance.JAssetShare.SearchDialog", null, null);
            Nodes.GlobalMenuActions.Insert(SearchAction);
            JToolbarNode TNS = new JToolbarNode();
            TNS.Icon = JImageIndex.Search;
            TNS.Hint = "Search...";
            TNS.Click = SearchAction;
            Nodes.AddToolbar(TNS);
            //ListView(OrderName, "");
        }

        /// <summary>
        /// چک میکند که مالک قطعی همان مالک سرقفلی است یا خیر
        /// </summary>
        /// <param name="pAsset"></param>
        /// <returns></returns>
        public static bool CheckDifinitIsGoodwill(int pAsset)
        {
            string Query = @" Select * from 
                (SELECT S.* FROM finAssetTransfer T
                inner join finAssetShare S   on T.Code = S.TCode 
                Where S.ACode  = "+pAsset+@" AND T.OwnershipType = 1 and Status = 1 ) A
                Inner join 
                (SELECT S.* FROM finAssetTransfer T
                inner join finAssetShare S   on T.Code = S.TCode 
                Where S.ACode  = "+pAsset+@" AND T.OwnershipType = 2 and Status = 1 ) B
                on A.PersonCode = B.PersonCode ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                db.Query_DataReader();
                return db.DataReader.Read();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.DataReader.Close();
                db.Dispose();
            }
        }
    }
}
