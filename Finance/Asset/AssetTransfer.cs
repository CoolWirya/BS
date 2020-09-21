using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Finance
{
    public class JAssetTransfer: JFinance
    {
        public int Code { get; set; }
        /// <summary>
        /// کد دارای
        /// </summary>
        public int ACode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ParentCode { get; set; }
        /// <summary>
        /// نوع مالکیت
        /// </summary>
        public JOwnershipType OwnershipType { get; set; }
        /// <summary>
        /// نام کلاس انتقال
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد شی انتقال
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment { get; set; }

        public JAssetShare[] Items;

        public JAssetTransfer()
        {
            Items = new JAssetShare[0];
        }
        #region Constructor

        public JAssetTransfer(int pCode, JDataBase pDB)
        {
            if (pCode > 0)
            {
                GetData(pCode);
                GetItems(pCode, pDB);
            }
        }

        public JAssetTransfer(int pACode, JOwnershipType pOwnershipType)
            : this(pACode, pOwnershipType, null)
        {
            Items = new JAssetShare[0];
        }

        public JAssetTransfer(int pACode, JOwnershipType pOwnershipType, string pClassName, int pObjectCode)
            : this(pACode, pOwnershipType,pClassName,pObjectCode, null)
        {
            Items = new JAssetShare[0];
        }

        public JAssetTransfer(int pACode, JOwnershipType pOwnershipType, JDataBase pDB)
        {
            Items = new JAssetShare[0];
            if (pACode > 0)
            {
                ACode = pACode;
                OwnershipType = pOwnershipType;
                Code = GetLastTransfer(pACode, pOwnershipType, "", 0, pDB);
                GetItems(Code, pDB);
            }
        }

        public JAssetTransfer(int pACode, JOwnershipType pOwnershipType, string pClassName, int pObjectCode, JDataBase pDB)
        {
            Items = new JAssetShare[0];
            if (pACode > 0)
            {
                ACode = pACode;
                OwnershipType = pOwnershipType;
                Code = GetLastTransfer(pACode, pOwnershipType,pClassName,pObjectCode, pDB);
                GetItems(Code, pDB);
            }
        }

        public JAssetTransfer(string pClassName, int pObjectCode, JOwnershipType pOwnershipType)
            : this(pClassName, pObjectCode, pOwnershipType, null)
        {
            Items = new JAssetShare[0];
        }

        public JAssetTransfer(string pAssetClassName, int pAssetObjectCode, JOwnershipType pOwnershipType, JDataBase pDB)
        {
            Items = new JAssetShare[0];
            OwnershipType = pOwnershipType;
            JAsset Asset = new JAsset(pAssetClassName, pAssetObjectCode);
            ACode = Asset.Code;
            Code = GetLastTransfer(ACode, pOwnershipType,"",0, pDB);
            GetItems(Code, pDB);
        }

        #endregion


        //private void GetItems(int pCode)
        //{
        //    GetItems(pCode,null);
        //}
        public void GetItems(int pCode, JDataBase pDB)
        {
            Code = pCode;
            System.Data.DataTable DT = GetDataAssetShare(pCode, pDB);
            Items = new JAssetShare[DT.Rows.Count];
            int Count=0;
            foreach (System.Data.DataRow DR in DT.Rows)
            {
                Items[Count] = new JAssetShare();
                JTable.SetToClassProperty(Items[Count], DR);
                Items[Count].NewShare = Items[Count].Share;
                Count++;
            }
        }

        #region ActiveALL
        public void DeActiveAll(JDataBase pDB)
        {
            foreach (JAssetShare AS in Items)
            {
                AS.Status = JStatusType.Inactive;
                AS.Update(pDB);
            }
        }

        public void DeleteAllShare(JDataBase pDB)
        {
            foreach (JAssetShare AS in Items)
            {
                AS.Delete(pDB);
            }
        }

        public void ActiveAll(JDataBase pDB)
        {
            foreach (JAssetShare AS in Items)
            {
                AS.Status = JStatusType.Active;
                AS.Update(pDB);
            }
        }

        public void BloackAll(JDataBase pDB)
        {
            foreach (JAssetShare AS in Items)
            {
                AS.Status = JStatusType.Block;
                AS.Update(pDB);
            }
        }

        #endregion

        public int AddItems(JAssetShare pAS)
        {
            if (FindItem(pAS.PersonCode) == null)
            {
                Array.Resize(ref Items, Items.Length + 1);
                Items[Items.Length - 1] = pAS;
                return Items.Length - 1;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode">Person Code</param>
        /// <param name="pShare"></param>
        /// <returns></returns>
        public bool ChangeItemShare(int pCode, float pShare)
        {
            JAssetShare _Ashare = FindItem(pCode);
            if (_Ashare != null)
            {
                _Ashare.NewShare = pShare;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode">Person Code</param>
        public JAssetShare FindItem(int pCode)
        {
            if (Items == null) return null;
            foreach (JAssetShare AS in Items)
            {
                if (AS.PersonCode == pCode)
                    return AS;
            }
            return null;
        }

        public bool Insert(JDataBase pDB)
        {
            if (Code > 0)
                ParentCode = Code;
            else
                ParentCode = 0;
            JAssetTransferTable ATT = new JAssetTransferTable();
            ATT.SetValueProperty(this);
            Code = ATT.Insert(pDB);
            if (Code > 0)
            {
                foreach (JAssetShare AS in Items)
                {
                    if (ParentCode == 0 || AS.Code == 0)
                    {
                        AS.TCode = Code;
                        AS.ACode = ACode; 
                        AS.Insert(pDB);
                    }

                    else
                        if (AS.Share == -1)
                            AS.Delete(pDB);
                        else
                        {
                            JAssetShare newShare = new JAssetShare();
                            newShare.Share = AS.NewShare;
                            newShare.ACode = AS.ACode;
                            newShare.TCode = Code;
                            newShare.PersonCode = AS.PersonCode;
                            //if (AS.NewShare == 0)
                                //newShare.Status = JStatusType.Inactive;
                            //else
                                newShare.Status = JStatusType.Active;
                            newShare.ParentCode = AS.Code;
                            AS.ChangeShare(pDB, newShare);
                        }
                }
                return true;
            }
            return false;
        }

        public bool UpdateInsert(JDataBase pDB)
        {
            if (Code > 0)
                ParentCode = Code;
            else
                ParentCode = 0;
            JAssetTransferTable ATT = new JAssetTransferTable();
            ATT.SetValueProperty(this);
            
            if (ATT.Update(pDB))
            {
                foreach (JAssetShare AS in Items)
                {
                    if (ParentCode == 0 || AS.Code == 0)
                    {
                        AS.TCode = Code;
                        AS.ACode = ACode;
                        AS.Insert(pDB);
                    }

                    else
                        if (AS.Share == -1)
                            AS.Delete(pDB);
                        else
                        {
                            JAssetShare newShare = new JAssetShare();
                            newShare.Share = AS.NewShare;
                            newShare.ACode = AS.ACode;
                            newShare.TCode = Code;
                            newShare.PersonCode = AS.PersonCode;
                            newShare.Status = JStatusType.Active;
                            newShare.ParentCode = AS.Code;
                            AS.ChangeShare(pDB, newShare);
                        }
                }
                return true;
            }
            return false;
        }

        public bool Update(JDataBase pDB)
        {
            JAssetTransferTable ATT = new JAssetTransferTable();
            ATT.SetValueProperty(this);
            if (ATT.Update(pDB))
            {
                foreach (JAssetShare AS in Items)
                {
                    if (AS.Code == 0 && AS.Share > 0)
                    {
                        AS.TCode = Code;
                        AS.ACode = ACode;
                        AS.Insert(pDB);
                    }
                    else
                        if (AS.Share == -1)
                            AS.Delete(pDB);
                        else
                        {
                            if (AS.NewShare > 0)
                            {
                                AS.Status = JStatusType.Active;
                                AS.Share = AS.NewShare;
                            }
                            AS.Update(pDB);
                        }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// حذف همه ترانسفرهای یک Asset
        /// </summary>
        /// <param name="pACode"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public bool DeleteAll(int pACode, JDataBase pDB)
        {
            JDataBase db;
            if (pDB == null)
                db = JGlobal.MainFrame.GetDBO();
            else
                db = pDB;

            try
            {
                db.setQuery("SELECT * FROM finAssetTransfer WHERE ACode=" + pACode.ToString());
                //db.Query_DataReader();
                //if (db.DataReader.Read())
                System.Data.DataTable transfer = db.Query_DataTable();
                foreach (DataRow row in transfer.Rows)
                {
                    JTable.SetToClassProperty(this, row);
                    this.Delete(this.Code, db);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            if (pDB == null)
                db.Dispose();
            }

        }
        public bool Delete( JDataBase pDB)
        {
            return Delete(Code, pDB);
        }

        public bool Delete(int pCode, JDataBase pDB)
        {
            GetData(pCode);
            GetItems(pCode, pDB);
            foreach (JAssetShare AS in Items)
            {
                AS.Delete(pDB);
            }
            int pParentCode = ParentCode;
            JAssetTransferTable ATT = new JAssetTransferTable();
            ATT.SetValueProperty(this);
            if (ATT.Delete(pDB))
            {
                if (pParentCode > 0)
                {
                    GetData(pParentCode);
                    GetItems(pParentCode, pDB);
                    ActiveAll(pDB);
                }
                return true;
            }
            return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM finAssetTransfer WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        private int GetLastTransfer(int pACode, JOwnershipType pOwnershipType,string pClassName,int pObjectCode, JDataBase pDB)
        {
            try
            {
                string Where = " ";
                if ((pClassName != "") && (pObjectCode != 0))
                    Where = Where + " And ClassName='" + pClassName + "'";
                if (pObjectCode != 0)
                    Where = Where + " And ObjectCode=" + pObjectCode;
                if (pACode != 0)
                    Where = Where + " And FAT.ACode=" + pACode.ToString();

                //Hassanzadeh
                pDB.setQuery(@"select FAT.* from finAssetShare FAS inner join finAssetTransfer FAT on FAS.TCode=FAT.Code 
                                And FAS.Status=1
                                Where OwnershipType=" + pOwnershipType.GetHashCode().ToString() + Where);

                //pDB.setQuery("SELECT * FROM finAssetTransfer WHERE ACode=" + pACode.ToString() + " AND OwnershipType=" + pOwnershipType.GetHashCode().ToString()
                //    + " ORDER BY Code DESC");
                pDB.Query_DataReader();
                //if (pDB.RecordCount > 1)
                    //return 0;

                if (pDB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, pDB.DataReader);
                    return (int)pDB.DataReader["Code"];
                }
                else
                {
                    pDB.setQuery(@"select FAT.* from finAssetShare FAS inner join finAssetTransfer FAT on FAS.TCode=FAT.Code 
                        And FAS.Status=0
                        Where OwnershipType=" + pOwnershipType.GetHashCode().ToString() + Where);
                    pDB.Query_DataReader();
                    if (pDB.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, pDB.DataReader);
                        return (int)pDB.DataReader["Code"];
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        public System.Data.DataTable GetDataAssetShare(int pCode, JDataBase pDB)
        {
            return  JAssetShares.GetDataTableAssetShareTransfer(pCode, pDB);
        }

        public static bool HaveGoodWill(int pACode)
        {
            JDataBase pDB = new JDataBase();
            try
            {
                string Query = @" SELECT finAssetTransfer.* FROM finAssetTransfer  
                    inner join [finAssetShare] on finAssetShare.TCode = finAssetTransfer.Code And finAssetShare.Status<>0
                    WHere  finAssetTransfer.ACode = " + pACode.ToString() +
                   " AND OwnershipType=" + JOwnershipType.Goodwill.GetHashCode().ToString();
                pDB.setQuery(Query);
                pDB.Query_DataReader();
                return pDB.DataReader.HasRows;
            }
            finally
            {
                pDB.DisConnect();
            }
        }

        public static System.Data.DataTable GetAssetShare(int pObjectCode,string pClassName,JOwnershipType pOwnerShipType)
        {
            JDataBase db = new JDataBase();
            try
            {

                string query = "";
                if (pClassName == "Estates.JGround")
                {
                    query = @"Select * ,(
                    Select Title from vContracts WHERE Code = ContractCode  )ContractType
                    from(
                        select fas.PersonCode PCode ,cap.Name,PA.Address, PA.Tel, case fat.ClassName when 'Legal.JSubjectContract' then fat.ObjectCode else  0 end ContractCode 
                        , fas.Share, ROUND(G.Area/6 *fas.Share, 2) AreaShare , ROUND(ISNull(G.TotalShare,0) /6 *fas.Share, 2) SharesShare from finAssetShare fas
                        inner join finAssetTransfer fat on fas.TCode = fat.Code
                        inner join finAsset fa on fa.Code = fat.ACode and fa.Code=fas.ACode
                        left join clsAllPerson cap on cap.code=fas.PersonCode
                        left join PersonAddressView PA on cap.Code = PA.Code
                        inner join estGround G on G.Code = fa.ObjectCode 
                        where fas.Status<>0 and fa.ObjectCode=" + pObjectCode.ToString() + " and OwnershipType=" + pOwnerShipType.GetHashCode().ToString() +
                        " AND fa.ClassName = " + JDataBase.Quote(pClassName) + ")A";
                }
                else
                {
                    query =
                    @"Select * ,(
                    Select Title from vContracts WHERE Code = ContractCode  )ContractType
                    from(
                        select fas.PersonCode PCode ,cap.Name,PA.Address, PA.Tel, case fat.ClassName when 'Legal.JSubjectContract' then fat.ObjectCode else  0 end ContractCode 
                        , fas.Share from finAssetShare fas
                        inner join finAssetTransfer fat on fas.TCode = fat.Code
                        inner join finAsset fa on fa.Code = fat.ACode and fa.Code=fas.ACode
                        left join clsAllPerson cap on cap.code=fas.PersonCode
                        left join PersonAddressView PA on cap.Code = PA.Code
                        where fas.Status<>0 and fa.ObjectCode=" + pObjectCode.ToString() + " and OwnershipType=" + pOwnerShipType.GetHashCode().ToString() +
                        " AND fa.ClassName = " + JDataBase.Quote(pClassName) + ")A";
                }
                db.setQuery(query);
                return db.Query_DataTable();
                
            }
            finally
            {
                db.Dispose();                
            }
        }
    }

    public class JAssetTransfers : JFinance
    {

    }
}
