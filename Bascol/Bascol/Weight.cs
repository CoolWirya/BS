using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Bascol
{
    public class JWeight : JBascol
    {

        #region constructor
        public JWeight()
        {

        }
        public JWeight(long pCode)
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
        ///  شماره باسکول
        /// </summary>
        public int BascoolCode { get; set; }
        /// <summary>
        ///  تاریخ توزین
        /// </summary>
        public DateTime WDate { get; set; }
        /// <summary>
        ///  ساعت توزین
        /// </summary>
        public string WTime { get; set; }
        /// <summary>
        ///  شماره پلاک
        /// </summary>
        public string PlokNo { get; set; }
        /// <summary>
        ///  آیدی محصول
        /// </summary>
        public int ProductCode { get; set; }
        /// <summary>
        ///  وزن
        /// </summary>
        public int Weights { get; set; }
        /// <summary>
        ///  آیدی ماشین
        /// </summary>
        public int TruckCode { get; set; }
        /// <summary>
        ///  وضعیت خالی بار بودن
        /// </summary>
        public int FullW { get; set; }
        /// <summary>
        ///  تعداد پرینت
        /// </summary>
        public int PrintNo { get; set; }
        /// <summary>
        ///  تعداد همراه
        /// </summary>
        public int hamrahno { get; set; }
        /// <summary>
        ///  حذف توزین
        /// </summary>
        public bool dele { get; set; }
        /// <summary>
        ///  تایید توزین توسط مالی
        /// </summary>
        public bool verify { get; set; }
        /// <summary>
        ///  هزینه توزین
        /// </summary>
        public int pay { get; set; }
        /// <summary>
        ///  مبلغ پرداخت شده
        /// </summary>
        public int pay_h { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public decimal Duty { get; set; }
        /// <summary>
        ///  مالیات
        /// </summary>
        public decimal Tax { get; set; }
        /// <summary>
        ///  کد کاربر
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        ///  کد پست کاربر
        /// </summary>
        public int UserPostCode { get; set; }
        /// <summary>
        ///  کد بانکlocal
        /// </summary>
        public int BascoolID { get; set; }

        #endregion

        #region search method

        public bool GetData(long pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from BascolWeights where Code=" + pCode + "";
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

        #region method

        public int Insert()
        {
            JDataBase Db = new JDataBase();
            try
            {
                return Insert(Db);
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
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase Db)
        {
            JWeightTable JLT = new JWeightTable();
            try
            {
                JLT.SetValueProperty(this);
                Code = JLT.Insert(Db);
                if (Code > 0)
                {
                    Db.setQuery(" Update BascoolCounter Set Counter=Counter+1 ");
                    Db.Query_Execute();
                    Nodes.DataTable.Merge(JWeights.GetDataTable(Code));
                    return Code;
                }
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

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool DeleteTransfer(int pCode, JDataBase Db)
        {
            try
            {
                JWeightTable JLT = new JWeightTable();
                JLT.Code = pCode;
                if (JLT.Delete(Db))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            try
            {
                GetData(pCode);
                if (PersonCode != JMainFrame.CurrentPersonCode)
                {
                    JMessages.Error(" فقط شخص ثبت کننده می تواند توزین حذف کند ", "");
                    return false;
                }
                if (verify == true)
                {
                    JMessages.Error(" این توزین تایید مالی شده است و قابل حذف نمی باشد ", "");
                    return false;
                }
                dele = true;
                if (Update())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                return Update(db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            try
            {
                JWeightTable PDT = new JWeightTable();
                PDT.SetValueProperty(this);
                PDT.Code = Code;
                if (PDT.Update(db))
                {
                    //Nodes.Refreshdata(Nodes.CurrentNode, JWeights.GetDataTable(Code).Rows[0]);
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
            }
        }

        public void TotalPrice()
        {
            int Sum = 0;
            foreach (DataRow dr in Nodes.CurrentRows)
                Sum = Sum + Convert.ToInt32(dr["Pay"]);
            JMessages.Information(JGeneral.MoneyStr(Sum.ToString()) + "  ریال  ", " جمع کل ");
        }

        public void AddBlackList(int pBascoolID)
        {
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            try
            {
                dbMain.setQuery(" Insert into bascoolblacklist values(" + pBascoolID + ")");
                if (dbMain.Query_Execute() > 0)
                    JMessages.Information(" ماشین در لیست سیاه قرار گرفت ", "");
                else
                    JMessages.Error(" خطا در ثبت ", "");
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        public void DelBlackList(int pBascoolID)
        {
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            try
            {
                dbMain.setQuery(" Delete From bascoolblacklist Where BascoolID=" + pBascoolID);
                if (dbMain.Query_Execute() > 0)
                    JMessages.Information(" ماشین از لیست سیاه حذف شد ", "");
                else
                    JMessages.Error(" خطا در ثبت ", "");
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode(Convert.ToInt32(pRow["Code"]), "Bascol.JWeight");
            Nodes.hidColumns = "dele,verify,FullW,PrintNo,pay_h,Duty,Tax,ProductCode,FirstWeight,Khales,PostName,Code,p1,p2,p3,p4,UserPostCode,TruckCode,PersonCode";
            Node.Name = pRow["PlokNo"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["PlokNo"].ToString();
            //اکشن جمع کل
            JAction TotalAction = new JAction("TatalPrice", "Bascol.JWeight.TotalPrice", null, null);
            Node.MouseClickAction = TotalAction;
            //اکشن لیست سیاه
            JAction BlackListAction = new JAction("BlackList", "Bascol.JWeight.AddBlackList", new object[] { Convert.ToInt32(pRow["BascoolID"]) }, null);
            Node.MouseClickAction = BlackListAction;
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Bascol.JWeight.ShowDialog", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            //JAction DeleteAction = new JAction("Delete", "Bascol.JWeight.Delete", new object[] { Node.Code }, null);
            //Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Bascol.JWeight.ShowDialog", new object[] { 0 }, null);
            Node.Popup.Insert(BlackListAction);
            Node.Popup.Insert(TotalAction);
            //Node.Popup.Insert(DeleteAction);
            //Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            return Node;
        }

        public static JWeightForm LandForm;

        public void ShowDialog(int pCode)
        {
            try
            {
                if ((LandForm == null) || (LandForm.IsDisposed))
                    LandForm = new JWeightForm();
                if (pCode == 0)
                {
                    LandForm.State = JFormState.Insert;
                    LandForm.Show();
                    LandForm.Activate();
                }
                else
                {
                    //JWeightForm LandForm = new JWeightForm(pCode);
                    //LandForm.State = JFormState.Update;
                    //LandForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #endregion

        public static int GetPlak(string pPlokno)
        {
            int TruckCode = 0;
            string Where = " where 1=1 ";
            if (pPlokno != "")
                Where = Where + " And PlokNo='" + pPlokno + "'";
            string Query = @"select TruckCode from BascolPlakTruck " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                TruckCode = Convert.ToInt32(db.Query_ExecutSacler());
                return TruckCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int GetBedehi(string pPlokno, int pTruckCode)
        {
            int Bedehi = 0;
            string Where = " where 1=1 ";
            if (pPlokno != "")
                Where = Where + " And PlokNo=N'" + pPlokno + "'";
            //if (pTruckCode != 0)
            //    Where = Where + " And TruckCode=" + pTruckCode;
            string Query = @"select isnull(sum(pay) - Sum(pay_h),0) from BascolWeights " + Where;
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                Bedehi = Convert.ToInt32(db.Query_ExecutSacler());
                if (dbMain != null)
                {
                    dbMain.setQuery(Query);
                    dbMain.CommandTimeout = 3;
                    object tmp = dbMain.Query_ExecutSacler();
                    if (tmp != null)
                        Bedehi = Bedehi + Convert.ToInt32(tmp);
                }
                return Bedehi;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
                if (dbMain != null)
                    dbMain.Dispose();
            }
        }

        public static string GetBedehiName(string pPlokno)
        {
            string Bedehi = "";
            string Where = " ";
            if (pPlokno != "")
                Where = Where + " And PlokNo=N'" + pPlokno + "'";
            string Query = @"Select ISNULL(STUFF((select '  و  ' + (Select fam From clsPerson Where Code=A.personcode)
  From
(
  SELECT personcode,
  (case  When (SUM(pay) - SUM(pay_h))>0 Then Sum(pay)-SUM(pay_h) ELSE 0 end)as debit,
  (case  When (SUM(pay) - SUM(pay_h)) < 0 Then SUM(pay_h) - SUM(pay) ELSE 0 end)as crdit,PlokNo  
  FROM BascolWeights  WHERE pay_h != pay And dele = 0 
  " + Where + @"
  GROUP BY PlokNo,personcode
   ) A Where (A.crdit <> A.debit )  FOR XML PATH('')), 1, 1, '' ),'') AS 'ListBedehkari'   ";
            JDataBase db = new JDataBase();
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            try
            {
                db.setQuery(Query);
                if (db.Query_ExecutSacler() != null)
                    Bedehi = db.Query_ExecutSacler().ToString();
                if ((dbMain != null) && (Bedehi == ""))
                {
                    dbMain.setQuery(Query);
                    dbMain.CommandTimeout = 3;
                    object tmp = dbMain.Query_ExecutSacler();
                    if (tmp != null)
                        Bedehi = Bedehi + tmp.ToString();
                }
                return Bedehi;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
            finally
            {
                db.Dispose();
                dbMain.Dispose();
            }
        }
    }

    public class JWeights : JSystem
    {
        public JWeights[] Items = new JWeights[0];
        public JWeights()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(long pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select  Code,
BascoolID,
(select Fam from clsperson where Code=PersonCode) 'PersonName',
BascoolCode,
(select Fa_Date from StaticDates where En_Date=Cast(WDate as Date)) 'WDate',
WTime,
Substring(PlokNo,0,3) +
case 
when (PlokNo like '%ا%' ) then Substring(PlokNo,3,3) else Substring(PlokNo,3,1) end +
case
when (PlokNo like '%ا%' ) then Substring(PlokNo,6,3) else Substring(PlokNo,4,3) end +
case
when (PlokNo like '%ا%' ) then +'-'+Substring(PlokNo,10,2) else '-'+Substring(PlokNo,8,2) end  PlokNo,
(select Name from Subdefine where code=ProductCode) 'ProductName',
(select Name from BascolTruck where code=TruckCode) 'TruckName',
Weights,
pay,
hamrahno,
dele,
verify,
FullW,
PrintNo,
pay_h,
Duty,
Tax,
ProductCode,UserPostCode,TruckCode,PersonCode 
from BascolWeights " + Where + "    order by BascoolID desc ";
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
                //MyDB.Dispose();
            }
        }

        public static DataTable GetDataTableAll(long pCode, bool Conn)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select  Code,
BascoolID,
(select Fam from clsperson where Code=PersonCode) 'PersonName',
BascoolCode,
(select Fa_Date from StaticDates where En_Date=Cast(WDate as Date)) 'WDate',
WTime,
Substring(PlokNo,0,3) +
case 
when (PlokNo like '%ا%' ) then Substring(PlokNo,3,3) else Substring(PlokNo,3,1) end +
case
when (PlokNo like '%ا%' ) then Substring(PlokNo,6,3) else Substring(PlokNo,4,3) end +
case
when (PlokNo like '%ا%' ) then +'-'+Substring(PlokNo,10,2) else '-'+Substring(PlokNo,8,2) end  PlokNo,
(select Name from Subdefine where code=ProductCode) 'ProductName',
(select Name from BascolTruck where code=TruckCode) 'TruckName',
Weights,
pay,
hamrahno,
dele,
verify,
FullW,
PrintNo,
pay_h,
Duty,
Tax,
ProductCode,
isnull(cast((Select top 1  EmptyWeight from BascolEmptyWeights Where BascoolID=WeightID) as nvarchar),'') FirstWeight,
isnull(cast(ABS(Weights - (Select top 1  EmptyWeight from BascolEmptyWeights Where BascoolID=WeightID)) as nvarchar),'') Khales,
--(Select title from organizationchart where Code=UserPostCode) PostName, 
'' PostName, 
Substring(PlokNo,0,3) p1,
case 
when (PlokNo like '%ا%' ) then Substring(PlokNo,3,3) else Substring(PlokNo,3,1) end p2,
case
when (PlokNo like '%ا%' ) then Substring(PlokNo,6,3) else Substring(PlokNo,4,3) end p3,
case
when (PlokNo like '%ا%' ) then +'-'+Substring(PlokNo,10,2) else '-'+Substring(PlokNo,8,2) end p4,
UserPostCode,TruckCode,PersonCode 
from BascolWeights " + Where + "    order by BascoolID desc ";
            JDataBase db = new JDataBase();
            try
            {
                if (Conn)
                {
                    JTransferData tmpTransferData = new JTransferData();
                    JDataBase MyDB = tmpTransferData.CreateConMainServer(true);
                    try
                    {
                        MyDB.setQuery(Query);
                        return MyDB.Query_DataTable();
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        return null;
                    }
                    finally
                    {
                        db.Dispose();
                        MyDB.Dispose();
                    }
                }
                else
                {
                    db.setQuery(Query);
                    return db.Query_DataTable();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
                //MyDB.Dispose();
            }
        }

        public static DataTable GetLastDataTable()
        {
            string Query = @"
declare  @Code int
select @Code = (select Max(Code) from BascolWeights Where cast(WDate as DATE)=cast(GetDate() as date) And PersonCode=" + JMainFrame.CurrentPersonCode + @")
select  Code,
BascoolCode,
(select Fa_Date from StaticDates where En_Date=cast(WDate as Date)) 'WDate',
WTime,
PlokNo,
(Select name From subdefine Where Code=ProductCode) 'ProductName',
Weights,
(select Name from BascolTruck where code=TruckCode) 'TruckName',
FullW,
PrintNo,
hamrahno,
dele,
verify,
pay,
pay_h,
Duty,
Tax,BascoolID,
(Select EmptyWeight from BascolEmptyWeights Where BascoolID=WeightID) FirstWeight,
Weights - (Select EmptyWeight from BascolEmptyWeights Where BascoolID=WeightID) Khales,
(select Name from clsallperson where Code=PersonCode) 'PersonName',
(Select title from organizationchart where Code=UserPostCode) 'PostName' from BascolWeights Where Code=@Code ";
            //JTransferData tmpTransferData = new JTransferData();
            //JDataBase MyDB = tmpTransferData.CreateConMainServer(true);
            JDataBase MyDB = new JDataBase();
            try
            {
                //if (MyDB == null) return null;
                MyDB.setQuery(Query);
                return MyDB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                MyDB.Dispose();
            }
        }

        #endregion GetData

        #region Access

        public static DataTable GetLastDataTableAccess()
        {
            JDataBase MyDB = new JDataBase();
            try
            {
                MyDB.setQuery(" Select top 1 * From Weight order by Code");
                return MyDB.Query_DataTable();
            }
            finally
            {
                MyDB.Dispose();
            }
        }

        public static int GetCounter()
        {
            JDataBase MyDB = new JDataBase();
            try
            {
                MyDB.setQuery(" Select Counter From BascoolCounter ");
                DataTable dt = MyDB.Query_DataTable();
                int Counter;
                if (dt.Rows.Count == 0)
                {
                    if (Globals.JRegistry.Read("BascolNum").ToString() == "")
                        return 0;
                    Counter = 1000000 * JReport.GetBascoolNumber();//Globals.JRegistry.Read("BascolNum").ToString()
                    MyDB.setQuery(" Insert Into BascoolCounter Values( " + Counter + ")");
                    if (MyDB.Query_Execute() <= 0)
                        Counter = 0;
                }
                else
                    Counter = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                return Counter;
            }
            finally
            {
                MyDB.Dispose();
            }
        }

        //public static DataTable GetLastDataTableAccess()
        //{
        //    ClassLibrary.JOLeDbDataBase MyDB = new ClassLibrary.JOLeDbDataBase();
        //    try
        //    {
        //        MyDB.setQuery(" Select top 1 * From Weight order by Code");
        //        return MyDB.Query_DataTable();
        //    }
        //    finally
        //    {
        //        MyDB.Dispose();
        //    }
        //}

        public static DataTable GetData()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" Select * From BascolWeights ");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        #region Node
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("Weights", "Bascol.JWeight.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "Bascol.JWeight.ShowDialog", new object[] { 0 }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}
