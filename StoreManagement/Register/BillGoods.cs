using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JBillGoods : JSystem
    {
        #region constructor
        public JBillGoods()
        {
            ListOwner = JBillListGoods.GetDataTable(-1);
            StorageList = JStorageBill.GetDataTable(-1);
            Prepayment = JPrepayment.GetDataTable(-1);
        }
        public JBillGoods(int pCode)
        {
            GetData(pCode);
            ListOwner = JBillListGoods.GetDataTable(pCode);
            StorageList = JStorageBill.GetDataTable(pCode);
            Prepayment = JPrepayment.GetDataTable(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///  سریال
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        ///  تاریخ
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        ///  فروشنده
        /// </summary>
        public int Seller { get; set; }
        /// <summary>
        ///  خریدار
        /// </summary>
        public int Buyer { get; set; }
        /// <summary>
        ///  وضعیت پرداخت
        /// </summary>
        public int StatePay { get; set; }
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  کد تنخواه
        /// </summary>
        public string TankhahCode { get; set; }
        /// <summary>
        ///  تخفیف
        /// </summary>
        public decimal Discount { set; get; }
        /// <summary>
        ///  مالیات و 
        /// </summary>
        //public decimal Tax { set; get; }
        /// <summary>
        ///  عوارض
        /// </summary>
        //public decimal Duty { set; get; }
        /// <summary>
        ///  وضعیت فاکتور
        /// </summary>
        public int State { get; set; }
        /// <summary>
        ///  نوع فاکتور
        /// </summary>
        public int BillType { get; set; }
        /// <summary>
        ///  ایجادکننده
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        ///  تاریخ
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        ///  شماره سند
        /// </summary>
        public int DocNumber { get; set; }
        /// <summary>
        ///  تاریخ
        /// </summary>
        public DateTime DocDate { get; set; }
        /// <summary>
        ///  برگشتی
        /// </summary>
        public bool Returned { get; set; }

        private DataTable _ListOwner;
        public DataTable ListOwner { get; set; }

        private DataTable _StorageList;
        public DataTable StorageList { get; set; }

        private DataTable _Prepayment;
        public DataTable Prepayment { get; set; }

        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from StoreBillGoods where Code=" + pCode + "";
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


        #endregion

        #region Access



        #endregion

        #region method

        public static int GetNumber()
        {
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"select top 1 cast(Number as int)-1  from StoreStorageBill where Number<0 And
date=(select MAX(DATE) from StoreStorageBill where Number<0 )
order by Number desc");
                DataTable dt = Db.Query_DataTable();
                if ((dt != null) && (dt.Rows.Count > 0))
                    return Convert.ToInt32(dt.Rows[0][0]);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public bool Find(string pSerial, decimal pTotalPrice, int pSeller, int pBuyer)
        {
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"select * from StoreBillGoods where Serial=" + pSerial +
                    " And (Select Sum(BL.Price) from StoreBillGoodsList BL Where StoreBillGoods.Code=BL.BillGoodsCode)=" +
                    pTotalPrice.ToString() + " And Seller= " + pSeller + " And Buyer= " + pBuyer);
                DataTable dt = Db.Query_DataTable();
                if ((dt != null) && (dt.Rows.Count > 0))
                    return true;
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
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (!(JPermission.CheckPermission("StoreManagement.JBillGoods.Insert")))
                return -1;

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JBillGoodsTable JLT = new JBillGoodsTable();
            JBillListGoods tmpBillListGoods = new JBillListGoods();
            JPrepayment tmpPrepayment = new JPrepayment();
            JStorageBill tmpStorageBill = new JStorageBill();
            try
            {
                JLT.SetValueProperty(this);
                Db.beginTransaction("InsertBillGoods");

                Code = JLT.Insert(Db);
                if (Code > 0)
                {
                    tmpBillListGoods._Insert = true;
                    if (tmpBillListGoods.Save(Code, ListOwner, Db) && tmpStorageBill.Save(Code, StorageList, Db) && tmpPrepayment.Save(Code, Prepayment, Db))
                    {
                        if (Db.Commit())
                        {
                            Nodes.DataTable.Merge(JBillGoodss.GetDataTable(Code));
                            return Code;
                        }
                        else
                        {
                            Db.Rollback("InsertBillGoods");
                            return 0;
                        }


                    }
                    else
                    {
                        Db.Rollback("InsertBillGoods");
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertBillGoods");
                return 0;
            }
            finally
            {
                JLT.Dispose();
                Db.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            if (!(JPermission.CheckPermission("StoreManagement.JBillGoods.Delete")))
                return false;

            if (!(JMessages.Question("آیا می خواهید آیتم مورد نظر حذف شود ؟", "Confirm?") == System.Windows.Forms.DialogResult.Yes))
                return false;

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JBillGoodsTable PDT = new JBillGoodsTable();
            JBillListGoods tmpBillListGoods = new JBillListGoods();
            JPrepayment tmpJPrepayment = new JPrepayment();
            JStorageBill tmpJStorageBill = new JStorageBill();
            GetData(pCode);
            if (Creator != JMainFrame.CurrentPersonCode)
            {
                JMessages.Error(" فقط شخص ایجاد کننده فاکتور می تواند فاکتور را حذف کند ", "");
                return false;
            }
            try
            {
                Db.beginTransaction("DeleteBillGoods");
                Code = pCode;
                PDT.SetValueProperty(this);
                tmpBillListGoods.Delete(Code, Db);
                tmpJPrepayment.Delete(Code, Db);
                tmpJStorageBill.Delete(Code, Db);
                if (PDT.Delete(Db))
                {
                    if (Db.Commit())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                    {
                        Db.Rollback("DeleteBillGoods");
                        return false;
                    }
                }
                else
                {
                    Db.Rollback("DeleteBillGoods");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Db.Rollback("DeleteBillGoods");
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
                PDT.Dispose();
                tmpBillListGoods.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (!(JPermission.CheckPermission("StoreManagement.JBillGoods.Update")))
                    return false;

                JBillListGoods tmpBillListGoods = new JBillListGoods();
                JBillGoodsTable PDT = new JBillGoodsTable();
                JPrepayment tmpPrepayment = new JPrepayment();
                JStorageBill tmpStorageBill = new JStorageBill();
                PDT.SetValueProperty(this);
                Db.beginTransaction("UpdateBillGoods");
                PDT.Code = Code;
                if (PDT.Update())
                {
                    if (tmpBillListGoods.Save(Code, ListOwner, Db) && tmpStorageBill.Save(Code, StorageList, Db) && tmpPrepayment.Save(Code, Prepayment, Db))
                    {
                        if (Db.Commit())
                        {
                            Nodes.Refreshdata(Nodes.CurrentNode, JBillGoodss.GetDataTable(Code).Rows[0]);
                            return true;
                        }
                        else
                        {
                            Db.Rollback("UpdateBillGoods");
                            return false;
                        }
                    }
                    else
                    {
                        Db.Rollback("UpdateBillGoods");
                        return false;
                    }
                }
                Db.Rollback("UpdateBillGoods");
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

        public void UpdateReturned(int pCode, bool pReturned)
        {
            JBillGoodsTable PDT = new JBillGoodsTable();
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                int Code = pCode;
                if (pReturned == true)
                {
                    JRegisterForm LandForm = new JRegisterForm(pCode);
                    LandForm.State = JFormState.Insert;
                    LandForm.ShowDialog();
                    Code = LandForm._Code;
                    if (LandForm._Code == 0)
                    {
                        JMessages.Error(" خطا در ثبت اطلاعات ", "");
                        return;
                    }
                    //    JBillGoods tmp = new JBillGoods(LandForm._Code);
                    //    for (int i = 0; i < tmp.ListOwner.Rows.Count; i++)
                    //    {
                    //        tmp.ListOwner.Rows[i].SetAdded();
                    //        tmp.ListOwner.Rows[i]["Price"] = Convert.ToDecimal(tmp.ListOwner.Rows[i]["Price"]) * (-1);
                    //    }
                    //    for (int i = 0; i < tmp.Prepayment.Rows.Count; i++)
                    //        tmp.Prepayment.Rows[i].SetAdded();
                    //    for (int i = 0; i < tmp.StorageList.Rows.Count; i++)
                    //        tmp.StorageList.Rows[i].SetAdded();
                    //    tmp.Returned = true;
                    //    tmp.Insert();
                }

                GetData(Code);
                PDT.SetValueProperty(this);
                PDT.Returned = pReturned;
                if (PDT.Update())
                {
                    Nodes.Refreshdata(Nodes.CurrentNode, JBillGoodss.GetDataTable(Code).Rows[0]);
                    //Db.setQuery(@"Update StoreBillGoodsList Set Price=Price*-1 where BillGoodsCode=" + tmp.Code);
                    //if (Db.Query_Execute() > 0)
                    JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                }
                else
                    JMessages.Error(" ویرایش با خطا مواجه شده ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
        }

        public void TotalPrice()
        {
            decimal Sum = 0;

            foreach (DataRow dr in Nodes.CurrentRows)
            {
                Sum = Sum + Convert.ToDecimal(dr["TotalPriceTax"]);
            }
            JMessages.Information(JGeneral.MoneyStr(Math.Round(Sum, 0).ToString()), " جمع کل ");
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode(Convert.ToInt32(pRow["Code"]), "StoreManagement.JBillGoods");
            Node.Name = pRow["Serial"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["Serial"].ToString();
            //اکشن جمع کل
            JAction TotalAction = new JAction("TatalPrice", "StoreManagement.JBillGoods.TotalPrice", null, null);
            Node.MouseClickAction = TotalAction;
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "StoreManagement.JBillGoods.ShowDialog", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "StoreManagement.JBillGoods.Delete", new object[] { Node.Code }, null);
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "StoreManagement.JBillGoods.ShowDialog", null, null);
            JAction ReturnedAction;
            if (pRow["Returned"].ToString() == "True")
                ReturnedAction = new JAction("Active...", "StoreManagement.JBillGoods.UpdateReturned", new object[] { Node.Code, false }, null);
            else
                ReturnedAction = new JAction("Returned...", "StoreManagement.JBillGoods.UpdateReturned", new object[] { Node.Code, true }, null);
            Node.Popup.Insert(TotalAction);
            Node.Popup.Insert(ReturnedAction);
            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            return Node;
        }

        public void ShowDialog(int pCode)
        {
            if (pCode == 0)
            {
                JRegisterForm LandForm = new JRegisterForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JRegisterForm LandForm = new JRegisterForm(pCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        public void ShowDialogReg()
        {
            RegForm LandForm = new RegForm();
            LandForm.State = JFormState.Insert;
            LandForm.ShowDialog();
        }

        public static decimal GetTax(int pYear)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(" Select Tax from BascolTaxFormula Where Year=" + pYear);
                return Convert.ToDecimal(Db.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static decimal GetDuty(int pYear)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(" Select Duty from BascolTaxFormula Where Year=" + pYear);
                return Convert.ToDecimal(Db.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }
        #endregion
    }

    public class JBillGoodss : JStoreManagment
    {
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JBillGoods", "StoreManagement.JBillGoods.GetNode");
            //Nodes.hidColumns = "Status";
            Nodes.DataTable = GetDataTable(0);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JBillGoods", "StoreManagement.JBillGoods.ShowDialog", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;
            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert(new JAction("new...", "StoreManagement.JBillGoods.ShowDialog", new object[] { 0 }, null));

            JToolbarNode Tn1 = new JToolbarNode();
            Tn1.Click = new JAction("JBillGoods", "StoreManagement.JBillGoods.ShowDialogReg", null, null);
            Tn1.Icon = JImageIndex.ExMail;
            Nodes.AddToolbar(Tn1);
            Nodes.GlobalMenuActions.Insert(new JAction("newReg...", "StoreManagement.JBillGoods.ShowDialogReg", null, null));
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = " WHERE 1=1 ";
            try
            {
                if (pCode > 0)
                    Where = Where + "  And StoreBillGoods.Code=" + pCode;
                Db.setQuery(@" Select StoreBillGoods.Code,Cast(Serial as bigint) Serial,TankhahCode,
(select Fa_Date from StaticDates where En_Date=cast(regdate as date)) 'RegDateFactor',
(Select Name From clsAllPerson Where seller=Code) 'Seller',
(Select Name From clsAllPerson Where Buyer=Code) 'Buyer',
case statepay when 1 then 'نقدی' when 0 then ' غیرنقدی ' when 2 then 'نقدی/غیرنقدی' end 'StatePay',
Description,cast(Discount as int) Discount,

cast(SUM(BL.[COUNT]*BL.Price) as decimal(18,0)) TotalPrice,
cast(SUM(BL.Tax) as int) Tax,
cast(SUM(BL.Duty) as int) Duty,
sum(BL.[COUNT]*BL.Price+BL.Tax+BL.Duty)-Discount 'TotalPriceTax',
 
 case State when 0 then 'تایید نشده مالی' when 1 then 'تایید شده مالی' end 'State',
(Select Name From subdefine Where Code=BillType) 'BillType',
(select name from clsAllPerson where Code=Creator) 'Creator',
(select Fa_Date from StaticDates where En_Date=cast(CreateDate as DATE)) 'RegisterDate',Returned 
,DocNumber,(select Fa_Date from StaticDates where En_Date=cast(DocDate as date)) 'DocDate',
(SELECT     STUFF ((SELECT     ' - ' + StoreStorageBill.Number  
      FROM          StoreStorageBill   
      WHERE      StoreBillGoods.Code=BillGoodsCode FOR XML PATH('')), 1, 2, '')) NumberAnbar, 
(Select top 1 Cast(StoreStorageBill.Number as int) From StoreStorageBill WHERE StoreBillGoods.Code=BillGoodsCode)  NumberAnbar1

from StoreBillGoods inner join StoreBillGoodsList BL on StoreBillGoods.Code=BL.BillGoodsCode 
" + Where + @"
group by  StoreBillGoods.Code,Serial,regdate,seller,Buyer,Description
,tankhahcode,Discount,statepay,State,BillType,Creator,CreateDate,Returned,DocNumber,DocDate ");
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

        public static DataTable CreatorsBill()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" Select distinct Creator 'Code',(Select Name From clsAllPerson Where StoreBillGoods.Creator=Code) 'Name'
  from StoreBillGoods 
union select -1,'--------'");
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

        public static DataTable SearchTadarokat(string pStr)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@"
select A.Number,A.RegDate,Sum(A.TotalPriceTax)TotalPriceTax,Sum(A.TotalPrice)TotalPrice,
Sum(A.TotalPriceDiscount)TotalPriceDiscount,Sum(A.Tax)Tax,Sum(A.Duty)Duty,A.TankhahCode,A.DescriptionS, '' Returned From 
(
Select 
distinct
(SELECT     STUFF ((SELECT     ' - ' + StoreStorageBill.Number  
      FROM          StoreStorageBill   
      WHERE      StoreStorageBill.BillGoodsCode = S.BillGoodsCode FOR XML PATH('')), 1, 2, '')) As Number,
--S.Number,
--(SELECT     STUFF ((SELECT     ' - ' + (select Fa_Date from StaticDates where En_Date=Cast(S.Date as date))  
--      FROM          StoreStorageBill   
--      WHERE  S.Description <> '' And StoreStorageBill.BillGoodsCode = S.BillGoodsCode FOR XML PATH('')), 1, 2, '')) As RegDate,

(select Fa_Date from StaticDates where En_Date=Cast(S.Date as date) And S.Description <> '') 'RegDate',
case Returned when 0 then
Round(SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax +StoreBillGoodsList.Duty)-StoreBillGoods.Discount,0,0) 
when 1 then
Round(SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax +StoreBillGoodsList.Duty)-StoreBillGoods.Discount,0,0)*-1
end TotalPriceTax,

case Returned when 0 then
Cast(SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price)as int) 
when 1 then
Cast(SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price)as int) * -1
end TotalPrice,
case Returned when 0 then
Cast(SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price-StoreBillGoods.Discount)as int) 
when 1 then
Cast(SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price-StoreBillGoods.Discount)as int) *-1
end TotalPriceDiscount,

Cast(SUM(StoreBillGoodsList.Tax)as int)  Tax,
Cast(SUM(StoreBillGoodsList.Duty)as int) Duty,
StoreBillGoods.TankhahCode,

(SELECT     STUFF ((SELECT     ' - ' + StoreStorageBill.Description  
      FROM          StoreStorageBill   
      WHERE  StoreStorageBill.BillGoodsCode in (Select Code from StoreBillGoods Where 1=1 " + pStr + @")
        And  
      StoreStorageBill.Number = S.Number FOR XML PATH('')), 1, 2, '')) As DescriptionS, '' Returned
      
from StoreStorageBill S 
inner join StoreBillGoods on S.BillGoodsCode=StoreBillGoods.Code
inner join StoreBillGoodsList on StoreBillGoodsList.BillGoodsCode=StoreBillGoods.Code
Where 1=1 And S.Description <> '' " + pStr + @" Group by S.Number,StoreBillGoods.TankhahCode,S.BillGoodsCode,S.Date,S.Description
,StoreBillGoods.Discount,Returned,RegDate,Creator
) A Group by A.Number,A.RegDate,A.TankhahCode,A.DescriptionS order by A.RegDate");
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

        public static DataTable Search(string pStr)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" Select Code,Serial,TankhahCode,
(select Fa_Date from StaticDates where En_Date=Cast(regdate as date)) 'RegDate',
case State when 0 then 'تایید نشده' when 1 then 'تایید شده مالی' end 'State',
(Select Name From subdefine Where Code=BillType) 'BillType' ,

(Select Name From clsAllPerson Where seller=Code) 'Seller',
(Select Name From clsAllPerson Where Buyer=Code) 'Buyer',

(Select sum(Tax) From StoreBillGoodsList where StoreBillGoods.Code=BillGoodsCode) 'Tax',
(Select sum(Duty) From StoreBillGoodsList where StoreBillGoods.Code=BillGoodsCode) 'Duty',

(Select sum([COUNT]*Price) From StoreBillGoodsList where StoreBillGoods.Code=BillGoodsCode) TotalPrice,
(Select sum([COUNT]*Price) From StoreBillGoodsList where StoreBillGoods.Code=BillGoodsCode)-Discount TotalPriceDiscount,
(Select cast(sum([COUNT]*Price+Tax+Duty) as int) From StoreBillGoodsList where StoreBillGoods.Code=BillGoodsCode) 'TotalPriceTax',
case statepay when 1 then 'نقدی' when 0 then ' غیرنقدی ' when 2 then 'نقدی/غیرنقدی' end 'StatePay',
Description,Discount,

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Seller)
end 
end 'TelSeller',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'AddressSeller',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PostalCodeSeller',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'CitySeller',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PreNumberCitySeller',

(select RegisterNo from organization Where Code=Seller) 'RegisterNoSeller',
(select CommercialCode from organization Where Code=Seller) 'CommercialCodeSeller',
(select ShMeli from clsPerson Where Code=Seller) 'SellerMeli',

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'TelBuyer',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'AddressBuyer',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PostalCodeBuyer',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'CityBuyer',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PreNumberCityBuyer',

(select RegisterNo from organization Where Code=Buyer) 'RegisterNoBuyer',
(select CommercialCode from organization Where Code=Buyer) 'CommercialCodeBuyer',
(select ShMeli from clsPerson Where Code=Buyer) 'BuyerMeli',

case Returned When 1 then '*'
else '' end 'Returned'

from StoreBillGoods Where 1=1 " + pStr);
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

        public static DataTable SearchTotal(string pStr, string pStrHaving)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" 
Select 
Seller as 'SellerCode',Buyer as 'BuyerCode',
(Select Name From subdefine Where Code=BillType) BillType,
--(select Fa_Date from StaticDates where En_Date=Cast(regdate as date)) 'RegDate',
'' 'RegDate',

(Select Name From clsAllPerson Where seller=Code) 'Seller',
(Select Name From clsAllPerson Where Buyer=Code) 'Buyer',
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax+StoreBillGoodsList.Duty) TotalPriceTax,
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price) TotalPrice,
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price-Discount) TotalPriceDiscount,
SUM(StoreBillGoodsList.Tax)  Tax,
SUM(StoreBillGoodsList.Duty) Duty,

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Seller)
end 
end 'TelSeller',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'AddressSeller',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PostalCodeSeller',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'CitySeller',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PreNumberCitySeller',

(select RegisterNo from organization Where Code=Seller) 'RegisterNoSeller',
(select CommercialCode from organization Where Code=Seller) 'CommercialCodeSeller',
(select ShMeli from clsPerson Where Code=Seller) 'SellerMeli',

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'TelBuyer',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'AddressBuyer',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PostalCodeBuyer',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'CityBuyer',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PreNumberCityBuyer',

case Returned When 1 then '*'
else '' end 'Returned',

(select RegisterNo from organization Where Code=Buyer) 'RegisterNoBuyer',
(select CommercialCode from organization Where Code=Buyer) 'CommercialCodeBuyer',
(select ShMeli from clsPerson Where Code=Buyer) 'BuyerMeli'

from StoreBillGoods inner join StoreBillGoodsList on StoreBillGoodsList.BillGoodsCode=StoreBillGoods.Code
Where 1=1 " + pStr + " Group by Seller ,Buyer,BillType,Returned " + pStrHaving);
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

        public static DataTable SearchEmtena(string pStr, string pStrHaving)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" 
  Select A.*,
(SELECT     STUFF ((SELECT     ' - ' + Name  
      FROM          subdefine   
      WHERE      Code in (Select BillType From StoreBillGoods Where StoreBillGoods.Seller=A.SellerCode And StoreBillGoods.Buyer=A.BuyerCode " + pStr + @") FOR XML PATH('')), 1, 2, '')) BillType
 From  
( 

Select 
Seller as 'SellerCode',Buyer as 'BuyerCode',
--(Select Name From subdefine Where Code=BillType) BillType,
--(select Fa_Date from StaticDates where En_Date=Cast(regdate as date)) 'RegDate',
'' 'RegDate',

(Select Name From clsAllPerson Where seller=Code) 'Seller',
(Select Name From clsAllPerson Where Buyer=Code) 'Buyer',
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax+StoreBillGoodsList.Duty) TotalPriceTax,
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price) TotalPrice,
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price-Discount) TotalPriceDiscount,
SUM(StoreBillGoodsList.Tax)  Tax,
SUM(StoreBillGoodsList.Duty) Duty,

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Seller)
end 
end 'TelSeller',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'AddressSeller',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PostalCodeSeller',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'CitySeller',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PreNumberCitySeller',

(select RegisterNo from organization Where Code=Seller) 'RegisterNoSeller',
(select CommercialCode from organization Where Code=Seller) 'CommercialCodeSeller',
(select ShMeli from clsPerson Where Code=Seller) 'SellerMeli',

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer)

else
case when (select persontype from clsAllPerson Where Code=Buyer) = 3
then
(select Phone from ClsOtherPerson where Code=Buyer)

else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end end 'TelBuyer',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
case when (select persontype from clsAllPerson Where Code=Buyer) = 3
then
(select [Address] from ClsOtherPerson where Code=Buyer)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end end 'AddressBuyer',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PostalCodeBuyer',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'CityBuyer',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PreNumberCityBuyer',

case Returned When 1 then '*'
else '' end 'Returned',

(select RegisterNo from organization Where Code=Buyer) 'RegisterNoBuyer',
(select CommercialCode from organization Where Code=Buyer) 'CommercialCodeBuyer',
(select ShenaseMeli from organization Where Code=Buyer) 'ShenaseMeliBuyer',
(select ShMeli from clsPerson Where Code=Buyer) 'BuyerMeli'

from StoreBillGoods inner join StoreBillGoodsList on StoreBillGoodsList.BillGoodsCode=StoreBillGoods.Code
Where 1=1 " + pStr + " Group by Seller ,Buyer,Returned " + pStrHaving
            + " ) A ");
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

        public static DataTable SearchTotalDetails(string pStr)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" 
 
Select 
 StoreBillGoods.Code,Serial,TankhahCode,
(Select SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax+StoreBillGoodsList.Duty) From StoreBillGoodsList Where BillGoodsCode=StoreBillGoods.Code)-StoreBillGoods.Discount TotalPriceFactor,
(select Fa_Date from StaticDates where En_Date=Cast(regdate as date)) 'RegDate',
case State when 0 then 'تایید نشده' when 1 then 'تایید شده مالی' end 'State',
(Select Name From subdefine Where Code=BillType) 'BillType' ,

(Select Name From clsAllPerson Where seller=Code) 'Seller',
(Select Name From clsAllPerson Where Buyer=Code) 'Buyer',
case statepay when 1 then 'نقدی' when 0 then ' غیرنقدی ' when 2 then 'نقدی/غیرنقدی' end 'StatePay',
Description,Discount,

case StoreBillGoodsList.ClassName when
 'StoreManagement.JGoods' then
(select Name from StoreGoods where Code=StoreBillGoodsList.ObjectCode)
else 
(select Name from StoreServices where Code=StoreBillGoodsList.ObjectCode)
end 'GoodsName',
case StoreBillGoodsList.ClassName when
 'StoreManagement.JGoods' then
(Select (Select Name From subdefine Where Code=Measure) from StoreGoods Where Code=StoreBillGoodsList.ObjectCode)
else 
(Select (Select Name From subdefine Where Code=Measure) from StoreGoods Where Code=StoreBillGoodsList.ObjectCode)
end 'Measure',

StoreBillGoodsList.[Count],
StoreBillGoodsList.Price,

SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax+StoreBillGoodsList.Duty) TotalPriceTax,
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price) TotalPrice,
SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price-Discount) TotalPriceDiscount,
SUM(StoreBillGoodsList.Tax)  Tax,
SUM(StoreBillGoodsList.Duty) Duty,

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Seller)
end 
end 'TelSeller',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'AddressSeller',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PostalCodeSeller',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'CitySeller',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Seller)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Seller)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Seller)
end end 'PreNumberCitySeller',

(select RegisterNo from organization Where Code=Seller) 'RegisterNoSeller',
(select CommercialCode from organization Where Code=Seller) 'CommercialCodeSeller',
(select ShMeli from clsPerson Where Code=Seller) 'SellerMeli',

case when  isnull((select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select Tel from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select Tel from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'TelBuyer',

case when  isnull((select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select [Address] from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select [Address] from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'AddressBuyer',

case when  isnull((select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select PostalCode from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select PostalCode from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PostalCodeBuyer',

case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (Select Name From subdefine Where Code=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'CityBuyer',

case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=2 And PCode=Buyer)
else
case when  isnull((select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer),'') <> ''
then
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=1 And PCode=Buyer)
else
(select (select PreNumber from ClsCity where CityCode=City) from clsPersonAddress Where AddressType=0 And PCode=Buyer)
end end 'PreNumberCityBuyer',

(select RegisterNo from organization Where Code=Buyer) 'RegisterNoBuyer',
(select CommercialCode from organization Where Code=Buyer) 'CommercialCodeBuyer',
(select ShMeli from clsPerson Where Code=Buyer) 'BuyerMeli'

from StoreBillGoods inner join StoreBillGoodsList on StoreBillGoodsList.BillGoodsCode=StoreBillGoods.Code
Where 1=1  " + pStr + @" 

Group by Seller ,Buyer,BillType,regdate , StoreBillGoods.Code,Serial,TankhahCode,State,statepay,Description,Discount,
StoreBillGoodsList.ObjectCode,StoreBillGoodsList.[COUNT],StoreBillGoodsList.Price,ClassName ");
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
    }
}
