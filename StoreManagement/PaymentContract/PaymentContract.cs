using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JPaymentContract: JSystem
    
    {
        #region constructor
        public JPaymentContract()
        {

        }
        public JPaymentContract(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد   
        /// </summary>
        public int Code { get; set; }              
        /// <summary>
        /// کد قرارداد 
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime PayDate { get; set; }
        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Pay { get; set; }
        /// <summary>
        ///  مالیات 
        /// </summary>
        public decimal Tax { set; get; }
        /// <summary>
        ///  عوارض
        /// </summary>
        public decimal Duty { set; get; }
        /// <summary>
        ///  مالیت مکسوره
        /// </summary>
        public decimal TaxMaksore { set; get; }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from StorePaymentContract where Code=" + pCode + "";
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

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (JPermission.CheckPermission("StoreManagement.JPaymentContract.Insert"))
            {
                JPaymentContractTable JLT = new JPaymentContractTable();
                        try
                        {
                            JLT.SetValueProperty(this);
                            Code = JLT.Insert();
                            if (Code > 0)
                                {
                                    Nodes.DataTable.Merge(JServicess.GetDataTable(Code));
                                    return Code;
                                }
                                else
                                    return 0;

                            return 0;
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                            return 0;
                        }
                        finally
                        {
                            JLT.Dispose();
                        }
           }
            return 0;
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (JPermission.CheckPermission("StoreManagement.JPaymentContract.Delete"))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                JPaymentContractTable PDT = new JPaymentContractTable();
                try
                {
                    PDT.SetValueProperty(this);

                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (tmpJRelation.CheckRelation("StoreManagement.JPaymentContract", Code, DB))
                    {
                        JMessages.Error(" برای این کالا فاکتور ثبت شده و امکان حذف وجود ندارد ", "");
                        return false;
                    }

                    
                    if (PDT.Delete())
                    {
                        //Nodes.Delete(Nodes.CurrentNode);
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
                    DB.Dispose();
                    PDT.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = new JDataBase();
            return Update(Db);
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db)
        {
            if (JPermission.CheckPermission("StoreManagement.JPaymentContract.Update"))
            {
                JPaymentContractTable PDT = new JPaymentContractTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        Nodes.DataTable.Merge(JPaymentContracts.GetDataTable(Code));
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
                    PDT.Dispose();
                }
            }
            return false;
        }

        public void ShowForm()
        {
            ShowForm(0);
        }
        public void ShowForm(int pContractCode)
        {
            if (pContractCode == 0)
            {
                JPaymentContractForm LandForm = new JPaymentContractForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JPaymentContractForm LandForm = new JPaymentContractForm(pContractCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        public static DataTable GetDataTableByContract(int pContractCode)
        {
            string Where = " where 1=1 ";
            if (pContractCode != 0)
                Where = Where + " And ContractCode=" + pContractCode;
            string Query = @"select Code,contractcode,Pay,
         (Select Fa_Date FROM StaticDates Where EN_Date = Cast(PAYDate as date)) as PAYDate,description,TaxMaksore  
            from  StorePaymentContract " + Where;
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

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "StoreManagement.JPaymentContract");
            Node.Name = pRow["ContractNo"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            //Node.Hint = pRow["Date"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("پیش پرداخت...", "StoreManagement.JPaymentContract.ShowForm", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;            
            //اکشن جدید
            JAction newAction = new JAction("New...", "StoreManagement.JPaymentContract.ShowForm", null, null);

            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);

            JAction NewContract = new JAction("NewContract...", "");

            Legal.JContractNodes CN = new Legal.JContractNodes();
            /// در صورتی که نیاز است هر کدام از اراضی به عنوان یک گروه امول تعریف شود(مانند بازار در اعیان) کد اراضی را به عنوان پارامتر این تابع قرار میدهیم. 
            /// ولی در حال حاضر چون خود زمین به عنوان یک گروه اموال تعریف شده، کد 1 را میفرستیم
            JNode[] _nodes = CN.ContractTree(Finance.JAssetGroup.ShareGroupCode);

            foreach (JNode _node in _nodes)
            {
                JAction _AContractType = new JAction(_node.Name, "");
                NewContract.AddChild(_AContractType);
                if (_node.ChildsAction != null)
                {
                    JNode[] _childnodes = (JNode[])_node.ChildsAction.run();
                    foreach (JNode _childnode in _childnodes)
                    {
                        JAction _AContract =
                            new JAction(_childnode.Name, "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code, 0, 0, false, Node.Code });
                        _AContractType.AddChild(_AContract);
                    }
                }
            }

            Node.Popup.Insert(NewContract);


            List<JAction> actions =
    CreateActions(Convert.ToInt32(pRow["Code"]), Convert.ToInt32(pRow["PersonCode"]));
            foreach (JAction action in actions)
            {
                Node.Popup.Insert(action);
            }

            return Node;
        }

        private List<JAction> CreateActions(int pContractCode, int pPersonCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);

                JAction splitter = new JAction("-", "");

                if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", contractDefine.ContractType, JMainFrame.CurrentPostCode, false))
                {
                    JAction ShowWordCurrentContract = OfficeWord.JWordForm.getAction("Legal.JContractForms", pContractCode, true);
                    actions.Add(ShowWordCurrentContract);
                }
                JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
                actions.Add(CancelAction);

                JAction editContract = new JAction("EditContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                actions.Add(editContract);

                JAction viewContract = new JAction("viewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, true });
                actions.Add(viewContract);

                actions.Add(splitter);

                actions.Add(splitter);
            }
            ///  مشخصات شخص
            int pCode = pPersonCode;
            JAction personAction = new JAction();
            JAllPerson allPerson = new JAllPerson(pCode);
            if (allPerson.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { pCode });
            else if (allPerson.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { pCode });
            actions.Add(personAction);
            return actions;
        }

    }
    public class JPaymentContracts : JSystem
    {
        public JPaymentContracts[] Items = new JPaymentContracts[0];
        public JPaymentContracts()
        {
            //GetData();
        }

        #region GetData
        //public DataTable GetDataTable()
        //{
        //    return GetDataTable(0);
        //}

//        public static DataTable GetDataTable(int pCode)
//        {
//            string Where = " 1=1 ";
//            if (pCode != 0)
//                Where = Where + " And Code=" + pCode;
//            string Query = @"select *,
//Description,
//(Select Fa_Date From StaticDates Where En_Date=PayDate) 'PayDate',
//Price
// from StorePaymentContract  Where " + Where;
//            JDataBase db = new JDataBase();
//            try
//            {
//                db.setQuery(Query);
//                return db.Query_DataTable();
//            }
//            catch (Exception ex)
//            {
//                JSystem.Except.AddException(ex);
//                return null;
//            }
//            finally
//            {
//                db.Dispose();
//            }
//        }

        public static DataTable Find(string pWhere )
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = @"Select S.Code, Number ContractNo ,ContractTitle, S.Description, Price, PriceMonth, TotalPrice, 

(select top 1 (Select Name From ClsallPerson Where Code=LegPersonContract.PersonCode) 
from LegPersonContract where Type=7 and ContractSubjectCode=S.Code) Seller,

(select top 1 (Select Name From ClsallPerson Where Code=LegPersonContract.PersonCode) 
from LegPersonContract where Type=9 and ContractSubjectCode=S.Code) Buyer,

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
end 
end 'TelSeller',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
end end 'AddressSeller',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
end end 'PostalCodeSeller',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
end end 'CitySeller',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code))
end end 'PreNumberCitySeller',

(select RegisterNo from organization Where Code=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)) 'RegisterNoSeller',
(select CommercialCode from organization Where Code=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)) 'CommercialCodeSeller',
(select ShMeli from clsPerson Where Code=(select top 1 PersonCode from LegPersonContract where Type =7 and ContractSubjectCode=S.Code)) 'SellerMeli',

--Buyer
case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
end 
end 'TelBuyer',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
end end 'AddressBuyer',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
end end 'PostalCodeBuyer',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> '' 
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where City <>0 And AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
end end 'CityBuyer',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> '' 
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=2 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=1 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where City <>0 And AddressType=0 And PCode=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code))
end end 'PreNumberCityBuyer',

(select RegisterNo from organization Where Code=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)) 'RegisterNoBuyer',
(select CommercialCode from organization Where Code=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)) 'CommercialCodeBuyer',
(select ShMeli from clsPerson Where Code=(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=S.Code)) 'BuyerMeli',

P.Description 'شرح پرداخت',P.Duty,P.Tax,P.TaxMaksore,P.Pay,
                       (Select Fa_Date FROM StaticDates Where EN_Date = Cast(P.PayDate as date)) as PayDate,
                        RealPrice, GoodwillPrice ,Confirmed,
                        case Status
                        when 0 then 'هیچکدام'
						when 1 then 'جاری'
						when 2 then 'اتمام' 
						when 3 then 'فسخ شده'
						when 4 then 'غبر فعال'
						end 'Status'
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(S.Date as date)) as DateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(S.StartDate as date)) as StartDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(S.EndDate as date)) as EndDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(S.StartpaymentDate as date)) as StartpaymentDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(S.EndpaymentDate as date)) as EndPaymentDateFa
                      , datediff(Month,StartDate ,EndDate) 'MonthDuring' 
                      FROM  LegSubjectContract S
                     inner join StorePaymentContract P on S.Code=P.contractCode                                          
WHERE  Type in(
SELECT T.Code FROM legContractDynamicTypes DT inner join legContractType T on T.ContractType=DT.Code
where  " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "DT.Code") + ")" +            
            @" And S.Code in 
(Select LegSubjectContract.Code from LegSubjectContract inner join LegPersonContract on LegSubjectContract.Code=LegPersonContract.ContractSubjectCode
Where 1=1 " + pWhere + ") ";
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

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
              string Where = " ";           
                if (pCode > 0)
                    Where = Where + "  And DT.Code=" + pCode;
            try
            {
                string Query = @"Select Code, Number ContractNo , Description, Price, PriceMonth, TotalPrice, 

(select top 1 (Select Name From ClsallPerson Where Code=LegPersonContract.PersonCode) 
from LegPersonContract where Type =9 and ContractSubjectCode=LegSubjectContract.Code) 'طرف دوم',
(select top 1 PersonCode from LegPersonContract where Type =9 and ContractSubjectCode=LegSubjectContract.Code) 'PersonCode',

                        RealPrice, GoodwillPrice ,Confirmed,
                        case Status
                        when 0 then 'هیچکدام'
						when 1 then 'جاری'
						when 2 then 'اتمام' 
						when 3 then 'فسخ شده'
						when 4 then 'غبر فعال'
						end 'Status'
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(Date as date)) as DateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(StartDate as date)) as StartDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(EndDate as date)) as EndDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(StartpaymentDate as date)) as StartpaymentDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(EndpaymentDate as date)) as EndPaymentDateFa
                      , datediff(Month,StartDate ,EndDate) 'MonthDuring' 
                      FROM  LegSubjectContract
                      WHERE  Type in(
SELECT T.Code FROM legContractDynamicTypes DT inner join legContractType T on T.ContractType=DT.Code
where " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "DT.Code") + ")" + Where;
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
            Nodes.ObjectBase = new JAction("StoreManagement", "StoreManagement.JPaymentContract.GetNode");
            Nodes.DataTable = GetDataTable(0);
            JAction newAction = new JAction("New...", "StoreManagement.JPaymentContract.ShowForm", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            //Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }
}
