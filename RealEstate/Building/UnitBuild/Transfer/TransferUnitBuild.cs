using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;
namespace RealEstate
{
    public class JTransferUnitBuild : JSystem
    {

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد دارائی 
        /// </summary>
        public int AssetCode { get; set; }
        /// <summary>
        /// شماره درخواست 
        /// </summary>
        public string RequestNumber { get; set; }
        /// <summary>
        ///تاریخ درخواست 
        /// </summary>
        public DateTime RequestDate { get; set; }
        /// <summary>
        /// شماره تایید
        /// </summary>
        public string ConfirmNumber { get; set; }
        /// <summary>
        /// تاریخ تایید
        /// </summary>
        public DateTime ConfirmDate { get; set; }
        /// <summary>
        /// تایید شده /نشده
        /// </summary>
        public bool Confirm { get; set; }
        /// <summary>
        /// توضیحات 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// مبلغ حق انتقال 
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// تایید شده /نشده مدیر
        /// </summary>
        public bool Modir { get; set; }
        /// <summary>
        ///  مالی تایید شده /نشده
        /// </summary>
        public bool Mali { get; set; }
        /// <summary>
        ///  املاک تایید شده /نشده
        /// </summary>
        public bool Amlak { get; set; }
        /// <summary>
        ///  فروشنده تایید شده /نشده
        /// </summary>
        public bool Seller { get; set; }
        /// <summary>
        /// مبلغ فروش 
        /// </summary>
        public string PriceSell { get; set; }
        /// <summary>
        /// نوع قرارداد 
        /// </summary>
        public int RequestType { get; set; }
        #endregion

         #region سازنده

        public JTransferUnitBuild()
        {
        }
        public JTransferUnitBuild(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

       #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(DataTable dtSeller,DataTable dtBuyer)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JTransferUnitBuildTable PDT = new JTransferUnitBuildTable();
            //JTranferPerson PDTP = new JTranferPerson();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JTransferUnitBuild.Insert"))
                {
                    Db.beginTransaction("InsertTransferUnitBuild");
                    Finance.JAsset t = new Finance.JAsset(AssetCode);
                    if (t.State == Finance.JAssetState.General)
                    {
                        PDT.SetValueProperty(this);
                        Code = PDT.Insert(Db);
                        if (Code > 0)
                            if (JTranferPerson.Update(dtSeller, Code, TransferPersonType.Seller.GetHashCode(), Db))
                                if (JTranferPerson.Update(dtBuyer, Code, TransferPersonType.Buyer.GetHashCode(), Db))
                                {
                                    if (t.ChangeState(Finance.JAssetState.Request, Db))
                                    {
                                        if (Db.Commit())
                                        {
                                            Histroy.Save(this, PDT, Code, "Insert");
                                            return Code;
                                        }
                                        else
                                        {
                                            Db.Rollback("InsertTransferUnitBuild");
                                            return 0;
                                        }
                                    }
                                    else
                                    {
                                        Db.Rollback("InsertTransferUnitBuild");
                                        return 0;
                                    }
                                }
                                else
                                {
                                    Db.Rollback("InsertTransferUnitBuild");
                                    return 0;
                                }
                            else
                            {
                                Db.Rollback("InsertTransferUnitBuild");
                                return 0;
                            }
                        else
                        {
                            Db.Rollback("InsertTransferUnitBuild");
                            return 0;
                        }
                    }
                    else
                        JMessages.Information(" این دارائی در وضعیت عادی نمی باشد", "");
                }                
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                Db.Rollback("DeleteTransferUnitBuild");
                return -1;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
        }

        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable dtSeller, DataTable dtBuyer)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JTransferUnitBuildTable PDT = new JTransferUnitBuildTable();
            //JTranferPerson PDTP = new JTranferPerson();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JTransferUnitBuild.Update"))
                {
                    Db.beginTransaction("UpdateTransferUnitBuild");
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        if (JTranferPerson.Update(dtSeller, Code, TransferPersonType.Seller.GetHashCode(), Db))
                            if (JTranferPerson.Update(dtBuyer, Code, TransferPersonType.Buyer.GetHashCode(), Db))
                            {
                                Finance.JAsset t = new Finance.JAsset(AssetCode);
                                if (t.ChangeState(Finance.JAssetState.Request, Db))
                                {
                                    if (Db.Commit())
                                    {
                                        Histroy.Save(this, PDT, Code, "Update");
                                        return true;
                                    }
                                    else
                                    {
                                        Db.Rollback("UpdateTransferUnitBuild");
                                        return false;
                                    }
                                }
                                else
                                {
                                    Db.Rollback("UpdateTransferUnitBuild");
                                    return false;
                                }
                            }
                            else
                            {
                                Db.Rollback("UpdateTransferUnitBuild");
                                return false;
                            }
                        else
                        {
                            Db.Rollback("UpdateTransferUnitBuild");
                            return false;
                        }
                    }
                    else
                    {
                        Db.Rollback("UpdateTransferUnitBuild");
                        return false;
                    }                       
                    return false;
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
                PDT.Dispose();
                Db.Dispose();
            }
        }

        public bool CheckRequestType()
        {
            if (RequestType.ToString() != "")
            {
                if (JPermission.CheckPermission("RealEstate.JTransferUnitBuild.CheckRequestType", RequestType))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool UpdateConfirm()
        {
            JTransferUnitBuildTable PDT = new JTransferUnitBuildTable();
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JTransferUnitBuild.UpdateConfirm"))
                {                     
                    Db.beginTransaction("UpdateTransferUnitBuild");
                    PDT.SetValueProperty(this);
                    //Check RequestType
                    if (!(CheckRequestType()))
                    {
                        Db.Rollback("UpdateTransferUnitBuild");
                        JMessages.Error(" مجوز تایید این نوع درخواست را ندارید ","");
                        return false;
                    }

                    Finance.JAsset t = new Finance.JAsset(PDT.AssetCode);
                    if (t.State != Finance.JAssetState.General)
                    {
                        if ((PDT.Amlak == true) && (PDT.Mali == true) && (PDT.Modir == true) && (PDT.Seller == true) && (PDT.ConfirmDate != DateTime.MinValue) && (PDT.ConfirmNumber != ""))
                        {
                            PDT.Confirm = true;
                            if (!t.ChangeState(Finance.JAssetState.Reply, Db))
                            {
                                Db.Rollback("UpdateTransferUnitBuild");
                                return false;
                            }
                        }
                        else
                            PDT.Confirm = false;
                        if (PDT.Update(Db))
                        {

                            if (Db.Commit())
                            {
                                Histroy.Save(this, PDT, Code, "Update");
                                return true;
                            }
                            else
                            {
                                Db.Rollback("UpdateTransferUnitBuild");
                                return false;
                            }
                        }
                        else
                        {
                            Db.Rollback("UpdateTransferUnitBuild");
                            return false;
                        }
                    }
                    else
                    {
                        Db.Rollback("UpdateTransferUnitBuild");
                        JMessages.Error(" این دارائی در وضعیت عادی می باشد و امکان حذف تایید انتقال نمی باشد", "");
                        return false;
                    }
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
                PDT.Dispose();
                Db.Dispose();
            }
        }
        /// <summary>
        ///حذف تایید   
        /// </summary>
        /// <returns></returns>
        public bool DeleteConfirm()
        {
            JTransferUnitBuildTable PDT = new JTransferUnitBuildTable();
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JTransferUnitBuild.DeleteConfirm"))
                {
                    Db.beginTransaction("DeleteConfirmTransferUnitBuild");
                    PDT.SetValueProperty(this);
                    Finance.JAsset t = new Finance.JAsset(PDT.AssetCode);
                    if (t.State != Finance.JAssetState.General)
                    {
                        if (PDT.Update(Db))
                        {
                            if ((PDT.Amlak == true) && (PDT.Mali == true) && (PDT.Modir == true) && (PDT.Seller == true))                            
                                if (!t.ChangeState(Finance.JAssetState.Request, Db))
                                {
                                    Db.Rollback("DeleteConfirmTransferUnitBuild");
                                    return false;
                                }                            
                            if (Db.Commit())
                            {
                                Histroy.Save(this, PDT, Code, "DeleteConfirmTransferUnitBuild");
                                return true;
                            }
                            else
                            {
                                Db.Rollback("DeleteConfirmTransferUnitBuild");
                                return false;
                            }
                        }
                        else
                        {
                            Db.Rollback("DeleteConfirmTransferUnitBuild");
                            return false;
                        }
                    }
                    else
                    {
                        Db.Rollback("DeleteConfirmTransferUnitBuild");
                        JMessages.Error(" این دارائی در وضعیت عادی می باشد و امکان حذف تایید انتقال نمی باشد", "");
                        return false;
                    }
                    return false;
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
                PDT.Dispose();
                Db.Dispose();
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            JTransferUnitBuildTable PDT = new JTransferUnitBuildTable();
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JTranferPerson tmpJTranferPerson = new JTranferPerson();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JTransferUnitBuild.Delete"))
                {
                    PDT.SetValueProperty(this);

                    if (tmpJTranferPerson.DeleteManual(" TransferCode=" + Code.ToString(), DB))
                    if (PDT.Delete(DB))
                    {
                        Finance.JAsset t = new Finance.JAsset(PDT.AssetCode);
                        if (t.ChangeState(Finance.JAssetState.General, DB))
                        {
                            Histroy.Save(this, PDT, Code, "Delete");
                            JArchiveDocument AD = new JArchiveDocument();
                            AD.DeleteArchive("Legal.JTransferUnitBuild", Code, false);
                            return true;
                        }
                    }
                    return false;
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
                PDT.Dispose();
                DB.Dispose();
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
                DB.setQuery("SELECT * FROM " + JRETableNames.RestTransferUnitBuild + " WHERE Code=" + pCode.ToString());
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
        public DataTable GetAllData(int pCode, int pAssetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " Where 1=1 ";
                if (pCode > 0)
                    Where = Where + " And Code=" + pCode.ToString();
                if (pAssetCode > 0)
                    Where = Where + " And AssetCode=" + pAssetCode.ToString();
                DB.setQuery(@"SELECT Code,
                                AssetCode,
                                RequestNumber,
                                ( select Fa_Date from StaticDates where  En_Date= Cast(RequestDate as date)) 'RequestDate',
                                ConfirmNumber,
                                (select Fa_Date from StaticDates where  En_Date= Cast(ConfirmDate as date)) 'ConfirmDate',
                                [Confirm],
                                Description,
                                Price 'Cost',
                                Modir,
                                Mali,
                                Amlak,
                                Seller
 FROM " + JRETableNames.RestTransferUnitBuild + Where);
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
        /// <summary>
        /// اطلاعات قرارداد 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetContract(int pCode, int pAssetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {                
                DB.setQuery(@"select top 1 SC.Number from LegSubjectContract SC 
inner join LegContractType ST on SC.Type=ST.Code
inner join legContractDynamicTypes SL on SL.Code=ST.ContractType and SL.AssetTransferType=2
 where SC.FinanceCode=" + pAssetCode.ToString() + " order by SC.Date Asc");
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

        /// <summary>
        /// اطلاعات قرارداد 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetUnitBuild(int pCode, int pAssetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " Where 1=1 ";
                if (pCode > 0)
                    Where = Where + " And T.Code=" + pCode.ToString();
                if (pAssetCode > 0)
                    Where = Where + " And T.AssetCode=" + pAssetCode.ToString();
                DB.setQuery(@"SELECT 
T.Code,
AssetCode,
RequestNumber,
(select Title from estMarket where Code=MarketCode) 'MarketName',
( select Fa_Date from StaticDates where  En_Date=Cast(RequestDate as date)) 'RequestDate',
ConfirmNumber,
(select Fa_Date from StaticDates where  En_Date= Cast(ConfirmDate as date)) 'ConfirmDate',
[Confirm],
Description,
T.Price,
T.PriceSell,
Modir,
Mali,
Amlak,
Seller,
UB.Number,
UB.Area,
(Select NAme From subdefine where Code = UB.UnitJob) 'JobTitle',
(Select Name From estMarketFloors where code = UB.FloorCode) 'Floor',Plaque 
FROM REstTransferUnitBuild T
inner join finAsset A on A.Code = T.AssetCode And A.ClassName='RealEstate.JUnitBuild'
inner join estUnitBuild UB on UB.Code= A.ObjectCode " + Where);
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
       #endregion
    }
}
