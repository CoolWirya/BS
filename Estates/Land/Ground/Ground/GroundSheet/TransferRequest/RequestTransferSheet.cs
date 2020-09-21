using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;
using ClassLibrary;
using System.Data;

namespace Estates
{
    public class JRequestTransferSheet : JSystem
    {
        #region Constractor
        public JRequestTransferSheet()
        {
        }

        public JRequestTransferSheet(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Properties

        public int Code { get; set; }
        /// <summary>
        /// کد تعرفه
        /// </summary>
        public int SheetCode { get; set; }
        /// <summary>
        /// شماره درخواست
        /// </summary>        
        public string RequestNumber { get; set; }
        /// <summary>
        /// تاریخ درخواست
        /// </summary>
        public DateTime RequestDate { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// قیمت
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// مدیر عامل
        /// </summary>
        public bool Manager { get; set; }
        /// <summary>
        /// مدیر سهام
        /// </summary>
        public bool ManagerSaham { get; set; }
        /// <summary>
        /// مسئول
        /// </summary>
        public bool Responsible { get; set; }
        /// <summary>
        /// کد فروشنده
        /// </summary>
        public int SellerCode { get; set; }
        /// <summary>
        /// کد خریدار
        /// </summary>
        public int BuyerCode { get; set; }

        #endregion

        #region FindMethod

        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                return GetData(pCode, Db);
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

        public bool GetData(int pCode, JDataBase Db)
        {
            string Qouery = "select * from estrequesttransfersheet where Code=" + JDataBase.Quote(pCode.ToString());
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    this.Code = pCode;
                    JTable.SetToClassProperty(this, Db.DataReader);
                    //JGroundsBreakDownAll.GetGroundsBreakDown(ref this.GroundsBreakdown, this.Code);
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


        #region Methods Insert,Update,delete,GetData

        public static bool CheckRequest(int pSheetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = @"select * From estRequestTransferSheet Where SheetCode= " + pSheetCode;
                DB.setQuery(WHERE);
                if (DB.Query_DataTable().Rows.Count > 0)
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
                DB.Dispose();
            }
        }

        public static bool CheckExistRequest(int pSheetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = @"select * From estRequestTransferSheet Where 
 SellerCode <>0 And BuyerCode<>0 And Manager=1 And ManagerSaham=1 And Responsible=1 And SheetCode= " + pSheetCode;
                DB.setQuery(WHERE);
                if (DB.Query_DataTable().Rows.Count > 0)
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
                DB.Dispose();
            }
        }

        public bool CheckNewRequest(int pSheetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = @"select Count(*) From estRequestTransferSheet Where SheetCode= " + pSheetCode;                
                DB.setQuery(WHERE);
                if (DB.Query_DataTable().Rows.Count > 0)
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
                DB.Dispose();
            }
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JRequestTransferSheetTable PDT = new JRequestTransferSheetTable();
            JGroundSheet tmpSheet = new JGroundSheet(SheetCode);
            try
            {
                if (JPermission.CheckPermission("Estates.JRequestTransferSheet.Insert"))
                {                    
                    PDT.SetValueProperty(this);
                    if (tmpSheet.DeliveryDate == DateTime.MinValue)
                    {
                        JMessages.Error(" این تعرفه تاریخ تحویل ندارد ", "");
                        return -1;
                    }
                    if (CheckRequest(SheetCode))
                    {
                        if (!(CheckExistRequest(SheetCode)))
                        {
                            JMessages.Error(" این تعرفه درخواست تایید نشده دارد ","");
                            return -1;
                        }
                    }
                    Code = PDT.Insert();
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JGroundSheets.GetDataTable(Code));
                        Histroy.Save(this, PDT, Code, "Insert");
                        return Code;
                    }
                    else
                        return -1;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JRequestTransferSheetTable PDT = new JRequestTransferSheetTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JRequestTransferSheet.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update())
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JRequestTransferSheets.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
                }
                else
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
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            JRequestTransferSheetTable PDT = new JRequestTransferSheetTable();
            JDataBase db = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Estates.JRequestTransferSheet.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if ((SellerCode != 0) && (BuyerCode != 0) && (Manager == true) && (ManagerSaham == true) && (Responsible == true))
                    {
                        JMessages.Error(" این قرارداد تایید شده و امکان حذف وجود ندارد ","");
                        return false; 
                    }
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete(db))
                    {
                        PDT.Delete(db);
                        ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                        AD.DeleteArchive("Legal.JRequestTransferSheet", Code, false);
                        Nodes.Delete(Nodes.CurrentNode);
                        Histroy.Save(PDT, Code, "Deleted", db);
                        return true;
                    }
                    else
                        return false;
                }
                else
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
            }
        }

        #endregion

        #region Show&GetNode
        public void ShowDialog(int pCode, int pSheetCode)
        {
            if (!(JPermission.CheckPermission("Estates.JRequestTransferSheet.ShowDialog")))
                return;
            JTransferRequestForm JGBDF = new JTransferRequestForm(pCode, pSheetCode);
            JGBDF.ShowDialog();
            //}
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Estates.JRequestTransferSheet");
            Node.Name = pRow["SellerName"].ToString();
            //Node.Icone = JImageIndex.UsageGround.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Estates.JRequestTransferSheet.ShowDialog", new object[] { Node.Code,0 }, null);
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction deleteAction = new JAction("Delete", "Estates.JRequestTransferSheet.delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = deleteAction;
            //اکشن جدید
            //JAction newAction = new JAction("New...", "Estates.JRequestTransferSheet.ShowDialog", null, null);
            //پاپ آپ منو
            JPopupMenu pMenu = new JPopupMenu("Esates.JRequestTransferSheet", Node.Code);
            Array.Resize(ref pMenu.Actions, 2);
            pMenu.Actions[0] = deleteAction;
            //pMenu.Actions[1] = newAction;
            pMenu.Actions[1] = editAction;
            Node.Popup = pMenu;
            return Node;
        }        
        #endregion

        public void PrintRequerst()
        {
            DataTable _DT = JRequestTransferSheets.GetWordPrintData(Code);
            JDynamicReports DRC = new JDynamicReports(JReportDesignCodes.RequestTransferSheet.GetHashCode());
            DRC.Add(_DT);
            DRC.PrintDefault();
        }

        public static string GetPersonContractText(int PCode, string pDate)
        {
            JAllPerson AllPers = new JAllPerson(PCode);
            if (AllPers.PersonType == JPersonTypes.LegalPerson)
            {
                JPersonAddress Address = new JPersonAddress(PCode);
                JOrganization Org = new JOrganization(PCode, pDate);

                return "شرکت " + Org.Name + " ثبت شده به شماره " + Org.RegisterNo + " " + Org.RegisterPlaceText +
                    " به نمایندگی " + String.Join(" و ", Org.SignatureListText.ToArray());
            }
            else
                if (AllPers.PersonType == JPersonTypes.RealPerson)
                {
                    JPerson Person = new JPerson(PCode);
                    JPersonAddress Address = new JPersonAddress(PCode);
                    string strPerson = "";
                    if (Person.Gender)
                        strPerson = "آقای ";
                    else
                        strPerson = "خانم ";
                    strPerson = strPerson + Person.Name + " " + Person.Fam +
                    " به شماره شناسنامه " + Person.ShSh +
                        " و کد ملی " + Person.ShMeli +
                            " فرزند " + Person.FatherName +
                                " صادره از " + Person.SaderText +
                                   " متولد " + JDateTime.FarsiDate(Person.BthDate).Split('/')[0];
                    return strPerson;
                }
                else
                {
                    string strPerson = "";
                    strPerson = "آقای/خانم ";
                    strPerson = strPerson + "-------------------" +
                    " به شماره شناسنامه " + "------------" +
                        " و کد ملی " + "------------" +
                            " فرزند " + "------------" +
                                " صادره از " + "------------" +
                                   " متولد " + "------";
                    return strPerson;
                }
            return "";
        }
    
    }

    public class JRequestTransferSheets : JSystem
    {
        public JRequestTransferSheets[] Items = new JRequestTransferSheets[0];
        //  public String OrderName;
        public JRequestTransferSheets()
        {
            // OrderName = "Fam";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = @"select 

Code,
SheetCode,
(Select Name From ClsAllPerson Where Code=SellerCode) SellerName,
(Select Name From ClsAllPerson Where Code=BuyerCode) BuyerName ,
RequestNumber,
(Select BlockNum from estGround where Code=(Select GCode From estSheet where Code=estRequestTransferSheet.SheetCode)) BlockNum,
(Select PartNum from estGround where Code=(Select GCode From estSheet where Code=estRequestTransferSheet.SheetCode)) PartNum,
(Select Fa_Date from StaticDates where  En_Date = Cast(RequestDate as Date)) 'RequestDate',
Description,
Price,
Manager,
ManagerSaham,
Responsible
    From estRequestTransferSheet Where 1=1 ";
                if (pCode != 0)
                    WHERE = WHERE + " And Code = " + pCode;
                DB.setQuery(WHERE);
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

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("RequestTransferSheet", "Estates.JRequestTransferSheet.GetNode");
            Nodes.DataTable = GetDataTable();

        }

        public static DataTable GetWordPrintData(int pCode)
        {
            JRequestTransferSheet GS = new JRequestTransferSheet(pCode);

            JDataBase _DB = new JDataBase();
            try
            {
                string _Where = "";
                string _SellerName = "NULL";
                string _BuyerName = "NULL";
                if (pCode > 0)
                {
                    _Where = " WHERE ERTS.Code = " + pCode.ToString();
                    _SellerName = JRequestTransferSheet.GetPersonContractText(GS.SellerCode, JDateTime.Now().ToString());
                    _BuyerName = JRequestTransferSheet.GetPersonContractText(GS.BuyerCode, JDateTime.Now().ToString());
                }
                _DB.setQuery(@"select ES.Code,"
+ JDataBase.Quote(_SellerName) + @" SellerName,"
+ JDataBase.Quote(_BuyerName) + @" BuyerName,
    CAST(round(ES.Area,3) as varchar) Area,
    EG.PartNum,
    EG.BlockNum,
    CAST(round(EG.Area,3) as varchar) AllArea,
	(select Name from estUsageGround  where estUsageGround.Code = EG.Usage) Usage,
	CAST(ERTS.Price AS VARCHAR) Price,
	(select Name from clsAllPerson where clsAllPerson.Code = BuyerCode) BuyerTinyName,
	(select Name from clsAllPerson where clsAllPerson.Code = SellerCode) SellerTinyName,
(select Fa_Date from StaticDates  where En_Date=CAST(GETDATE() as DATE)) DateNow 
	FROM estRequestTransferSheet ERTS
inner join estSheet ES on ERTS.SheetCode = ES.Code
inner join estGround EG on EG.Code = ES.GCode
" + _Where);
                DataTable _DT = _DB.Query_DataTable();
                if (_DT.Rows.Count > 0)
                {
                    _DT.Rows[0]["Area"] = JGeneral.ReverseNumber(_DT.Rows[0]["Area"].ToString().Replace('.', '/'), '/');
                    _DT.Rows[0]["AllArea"] = JGeneral.ReverseNumber(_DT.Rows[0]["AllArea"].ToString().Replace('.', '/'), '/');
                    if (_DT.Rows[0]["Price"].ToString() != "0")
                        _DT.Rows[0]["Price"] = JGeneral.MoneyStr(_DT.Rows[0]["Price"].ToString());
                    else
                        _DT.Rows[0]["Price"] = "-----------------";
                    _DT.Rows[0]["DateNow"] = JGeneral.ReverseDate(_DT.Rows[0]["DateNow"].ToString());
                }
                return _DT;
            }
            catch
            {
                return null;
            }
            finally
            {
                _DB.Dispose();
                GS.Dispose();
            }
            return null;
        }
    }

            
}
