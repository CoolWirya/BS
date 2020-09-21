using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;
using ClassLibrary;
using Globals;

namespace Estates
{
    public class JGroundSheet : JSystem
    {

        #region Constractor
        public JGroundSheet()
        {
        }

        public JGroundSheet(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Properties


        public int Code { get; set; }
        /// <summary>
        /// Ground Code
        /// </summary>
        public int GCode { get; set; }
        /// <summary>
        /// PersonCode
        /// </summary>
        public int PCode { get; set; }
        public float Area { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Creator { get; set; }
        public int NumPrint { get; set; }
        public int State { get; set; }
        public int DeActive { get; set; }
        public int Parent { get; set; }
        public int ContractCodeSell { get; set; }
        public int ContractCodeBuy { get; set; }
        public float Share { get; set; }
        public decimal NewContractPrice { get; set; }
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
            string Qouery = "select * from estSheet where Code=" + JDataBase.Quote(pCode.ToString());
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

        public DataTable ListTarefe(int pCode, int pGCode, int pContractCodeSell, int pContractCodeBuy, int DeActive)
        {
            JDataBase db = new JDataBase();
            try
            {
                return ListTarefe(pCode, pGCode, pContractCodeSell, pContractCodeBuy, DeActive, db);
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable ListTarefe(int pCode, int pGCode, int pContractCodeSell, int pContractCodeBuy, int DeActive, JDataBase db)
        {
            string Where = " ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            if (pGCode != 0)
                Where = Where + " And GCode=" + pGCode;
            if (pContractCodeSell != 0)
                Where = Where + " And ContractCodeSell=" + pContractCodeSell;
            if (pContractCodeBuy != 0)
                Where = Where + " And ContractCodeBuy=" + pContractCodeBuy;

            string Query = @"Select *,(Select Name from clsAllPerson Where Code=PCode) 'Name'
,(Select Name from clsAllPerson Where Code=PCode)+ ' مساحت ' + cast(cast(Area as decimal(18,4)) as varchar) 'FullName' 
 from estsheet where DeActive=" + DeActive + Where;
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                //db.Dispose();
            }
            return null;
        }

        public DataTable ListTarefe(int pContractCodeSell, int pGCode)
        {
            JDataBase db = new JDataBase();
            string Query = @"Select *,(Select Name from clsAllPerson Where Code=PCode) 'Name'
,' کد تعرفه ' + cast(Code as varchar) + (Select Name from clsAllPerson Where Code=PCode)+ '   مساحت ' + cast(Area as varchar) 'FullName' 
,cast(Code as varchar) + ' ' + (Select Name from clsAllPerson Where Code=PCode) 'FullName1' 
 from estsheet where (DeActive=0 or (DeActive=1 And ContractCodeSell=" + pContractCodeSell + ")) And GCode=" + pGCode;
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }


        public static DataTable ListShoraka(int pGCode)
        {

            JDataBase db = new JDataBase();
            string Query = @"        select *,(Select Name from clsAllPerson Where Code=PCode) 'Name',
(Select ShSh from clsPerson Where Code=PCode) 'ShSh',
(Select ShMeli from clsPerson Where Code=PCode) 'ShMeli'
 from LotteryResault";
            try
            {
                string Where = " Where ";
                if (pGCode != 0)
                    Where = Where + " GCode=" + pGCode;
                db.setQuery(Query + Where);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }

        public bool GetDataByGroundCode(int pGCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qouery = "select * from estSheet where DeActive=0 And GCode=" + JDataBase.Quote(pGCode.ToString());
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    this.Code = pGCode;
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

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JGroundSheetTable PDT = new JGroundSheetTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundSheet.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
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
            JDataBase db = new JDataBase();
            try
            {
                return Update(db);
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool UpdateSheet(int pContractCode, JDataBase pDB)
        {
            //JDataBase pDB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundSheet.UpdateSheet"))
                {
                    pDB.setQuery("Update estSheet Set DeActive = 1 Where ContractCodeBuy=" + pContractCode
                        + " Update estSheet Set DeActive = 0,ContractCodeSell=0 Where ContractCodeSell=" + pContractCode);
                    if (pDB.Query_Execute() >= 0)
                        return true;
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
                //pDB.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public static DataTable HistorySheet(string pStrCode)
        {
            JDataBase pDB = JGlobal.MainFrame.GetDBO();
            try
            {
                    pDB.setQuery(@" select Code,PCode,(Select Name From clsPerson Where Code=PCode) +' ' +(Select Fam From clsPerson Where Code=PCode) Name,
ContractCodeBuy,ContractCodeSell,(Select Fa_Date From StaticDates where En_Date=Cast(DeliveryDate as Date)) DeliveryDate
from estSheet Where Code in " + pStrCode + " order by CreateDate ");
                    return pDB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                pDB.Dispose();
            }
        }

        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JGroundSheetTable PDT = new JGroundSheetTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundSheet.Update"))
                {
                    //PDT.SetValueProperty(this);
                    PDT.SetValueProperty(this);
                    if (PDT.Update(pDB) || pDB.RecordCount == 0)
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        //Nodes.Refreshdata(Nodes.CurrentNode, JGroundSheets.GetDataTable(Code).Rows[0]);
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
        public bool delete(int pCode)
        {
            JGroundSheetTable PDT = new JGroundSheetTable();
            JDataBase db = new JDataBase();
            try
            {
                if (!(JPermission.CheckPermission("Estates.JGroundSheet.Delete")))
                    return false;

                if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                {
                    GetData(pCode);
                    if (DeActive == 1)
                    {
                        JMessages.Error(" تعرفه غیر فعال قابل حذف می باشد ", "");
                        return false;
                    }
                    PDT.SetValueProperty(this);
                    db.beginTransaction("DeleteSheet");

                    //فعال کردن تعرفه قبلی
                    
                    if (PDT.Parent > 0)
                    {
                        JGroundSheet tmpSheetParent = new JGroundSheet(PDT.Parent);                        
                        tmpSheetParent.DeActive = 0;
                        tmpSheetParent.ContractCodeSell = 0;
                        if (!(tmpSheetParent.Update(db)))
                        {
                            db.Rollback("DeleteSheet");
                            JMessages.Error(" خطا در حذف تعرفه قبلی ","");
                            return false;
                        }
                    }
                    // حذف تعرفه فعلی
                    if (!(PDT.Delete(db)))
                    {
                        db.Rollback("DeleteSheet");
                        JMessages.Error(" خطا در حذف تعرفه فعلی ", "");
                        return false; 
                    }

                    Legal.JSubjectContract tmpContract = new Legal.JSubjectContract(PDT.ContractCodeBuy);

                    //  حذف از AssetTransfer
                    Finance.JAssetTransfer tmpTransfer = new JAssetTransfer(tmpContract.TransferCode, db);
                    int AssetTransferCodeOld = tmpTransfer.ParentCode;
                    if (!tmpTransfer.Delete(db))
                    {
                        db.Rollback("DeleteSheet");
                        JMessages.Error("کد مالی وجود ندارد TransferCode امکان حذف تعرفه نمی باشد ", "");
                        return false;
                    }
                    // خذف از AssetShare
                    //Finance.JAssetShare tmpShare = new JAssetShare(tmpTransfer.ACode, tmpContract.TransferCode, db);
                    //if (!tmpShare.Delete(db))
                    //{
                    //    db.Rollback("DeleteSheet");
                    //    return false;
                    //}
                    // فعال کردن مالک قبلی AssetShare
                    Finance.JAssetShare tmpShare2 = new JAssetShare(tmpTransfer.ACode, AssetTransferCodeOld, db);
                    //tmpShare2.GetData(tmpShare.ParentCode);
                    tmpShare2.Status = JStatusType.Active;
                    if (!tmpShare2.Update(db))
                    {
                        db.Rollback("DeleteSheet");
                        JMessages.Error(" خطا در حذف مالک قبلی ", "");
                        return false;
                    }
                    // حذف قرارداد
                    if (!tmpContract.delete(true, db))
                    {
                        db.Rollback("DeleteSheet");
                        JMessages.Error(" خطا در حذف قرارداد ", "");
                        return false;
                    }

                    ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                    AD.DeleteArchive("Legal.JNotice", Code, false);
                    Nodes.Delete(Nodes.CurrentNode);
                    if (Histroy.Save(PDT, Code, "Deleted", db))
                        if (db.Commit())
                        {
                            return true;
                        }

                    db.Rollback("DeleteSheet");
                    return false;
                }
                else
                {
                    //db.Rollback("DeleteSheet");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                db.Rollback("DeleteSheet");
                return false;
            }
            finally
            {
                PDT.Dispose();
                db.Dispose();
            }
        }

        #endregion

        #region Show&GetNode
        public void ShowDialog()
        {
            if (!(JPermission.CheckPermission("Estates.JGroundSheet.ShowDialog")))
                return;
            if (this.Code == 0)
            {
                JSheetGroundForm JGBDF = new JSheetGroundForm();
                JGBDF.State = JFormState.Insert;
                JGBDF.ShowDialog();
            }
            else
            {
                JSheetGroundForm JGBDF = new JSheetGroundForm(this.Code);
                JGBDF.State = JFormState.ReadOnly;
                JGBDF.ShowDialog();

            }
        }

        public void CreateContract()
        {
            try
            {
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Code", typeof(int));
                dt.Columns.Add("i", typeof(int));

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                Legal.JContractdefine tmpJContractdefine = new Legal.JContractdefine();
                Legal.JGeneralContract tmpGeneralContract = new Legal.JGeneralContract(-1, -1);

                foreach (DataRow dr in Nodes.DefaultView.Rows)
                {
                    //if (ClassLibrary.JAllPerson.CheckCodeMeli("0945076053"))
                    //{
                        tmpSubjectContract.GetData(Convert.ToInt32(dr["ContractCodeBuy"]));//Code
                        if (tmpJContractdefine.Code == 0)
                        {
                            tmpJContractdefine.GetData(tmpSubjectContract.Type);
                            tmpGeneralContract.LoadForms(tmpJContractdefine.ContractType, tmpSubjectContract.Code, true);
                        }
                        tmpGeneralContract.GetData(tmpJContractdefine.ContractType, tmpSubjectContract.Code, 0, true);
                        tmpGeneralContract.ContractForms.CreateWordContract();
                        //dt.Rows.Add(Convert.ToInt32(dr["Code"]), i);
                        i++;
                        Nodes.StatusStripMain.Items[0].Text = i.ToString();
                        System.Windows.Forms.Application.DoEvents();
                        JSystem.FreeObjectsDataReaer();
                    //}
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public int CreateContract(DataRow pDr)
        {
            try
            {
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Code", typeof(int));
                dt.Columns.Add("i", typeof(int));

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                Legal.JContractdefine tmpJContractdefine = new Legal.JContractdefine();
                Legal.JGeneralContract tmpGeneralContract = new Legal.JGeneralContract(-2, -2);

                DataRow dr = pDr;
                //if (ClassLibrary.JAllPerson.CheckCodeMeli("0945076053"))
                //{
                tmpSubjectContract.GetData(Convert.ToInt32(dr["ContractCodeBuy"]));//Code
                if (tmpJContractdefine.Code == 0)
                {
                    tmpJContractdefine.GetData(tmpSubjectContract.Type);
                    tmpGeneralContract.LoadForms(tmpJContractdefine.ContractType, tmpSubjectContract.Code, true);
                }
                tmpGeneralContract.GetData(tmpJContractdefine.ContractType, tmpSubjectContract.Code, 0, true);
                tmpGeneralContract.ContractForms.CreateWordContract();
                //dt.Rows.Add(Convert.ToInt32(dr["Code"]), i);
                i++;
                Nodes.StatusStripMain.Items[0].Text = i.ToString();
                System.Windows.Forms.Application.DoEvents();
                JSystem.FreeObjectsDataReaer();
                return tmpGeneralContract.ContractForms.Contract.FileCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        public void CreateContractPrint()
        {
            try
            {
                //if (!(JPermission.CheckPermission("Estates.JGroundSheet.CreateContractPrint")))
                //    return;

                int _FileCode = 0;

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                OfficeWord.WinWordControl tmpWord = new OfficeWord.WinWordControl();
                foreach (DataRow dr in Nodes.CurrentRows)
                {
                    //if (ClassLibrary.JAllPerson.CheckCodeMeli(dr["ShMeli"].ToString()))
                    //{
                        tmpSubjectContract.GetData(Convert.ToInt32(dr["ContractCodeBuy"]));
                        _FileCode = tmpSubjectContract.FileCode;
                        if (true || _FileCode <= 0)
                        {
                            _FileCode = CreateContract(dr);
                        }

                        tmpWord.GetData(_FileCode);
                        tmpWord.LoadDocument();
                        tmpWord.Print();
                    //}
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void CreateContractPrint(DataRow pDr)
        {
            //if (!(JPermission.CheckPermission("Estates.JGroundSheet.CreateContractPrint")))
            //    return;

            try
            {
                int _FileCode = 0;
                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                OfficeWord.WinWordControl tmpWord = new OfficeWord.WinWordControl();
                DataRow dr = pDr;
                //if (ClassLibrary.JAllPerson.CheckCodeMeli(dr["ShMeli"].ToString()))
                //{
                    tmpSubjectContract.GetData(Convert.ToInt32(dr["ContractCodeBuy"]));
                    _FileCode = tmpSubjectContract.FileCode;
                    if (_FileCode <= 0)
                    {
                        _FileCode = CreateContract(dr);
                    }

                    tmpWord.GetData(_FileCode);
                    tmpWord.LoadDocument();

                    tmpWord.Print();
                    tmpWord.Print();

                    tmpWord.Dispose();
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            int _SellContractCode = 0;
            int _BuyContractCode = 0;
            int _PersonContractCode = 0;

            JAction splitter = new JAction("-", "");

            try
            {
                _SellContractCode = (int)pRow[JGroundSheetEnum.ContractCodeSell.ToString()];
            }
            catch
            {
            }

            try
            {
                if (pRow[JGroundSheetEnum.ContractCodeBuy.ToString()].ToString() != "")
                    _BuyContractCode = (int)pRow[JGroundSheetEnum.ContractCodeBuy.ToString()];
            }
            catch
            {
            }

            try
            {
                _PersonContractCode = (int)pRow[JGroundSheetEnum.PCode.ToString()];
            }
            catch
            {
            }

            JNode Node = new JNode((int)pRow[JGroundSheetEnum.Code.ToString()], "Estates.JGroundSheet");
            Node.Name = JLanguages._Text("Area ") + " " + pRow["Area"];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن نمایش
            JAction ViewAction = new JAction("Show...", "Estates.JGroundSheet.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = ViewAction;
            //Node.EnterClickAction = ViewAction;

            JPopupMenu pMenu = new JPopupMenu("Estates.JGroundSheet", Node.Code);
            pMenu.Insert(ViewAction);

            //اکشن حذف
            JAction deleteAction = new JAction("Delete", "Estates.JGroundSheet.delete", new object[] { Node.Code } ,null);
            Node.DeleteClickAction = deleteAction;

            //  چاپ قرارداد
            JAction ContractPrint = new JAction("ContractPrint...", "Estates.JGroundSheet.CreateContractPrint",new object[] { pRow } , null);//

            //  چاپ تعرفه
            JAction SheetPrint = new JAction("SheetPrint...", "Estates.JGroundSheet.PrintSheet", null, new object[] { Node.Code });//
            
            //  چاپ شرکا
            JAction SharePersonPrint = new JAction("SharePersonPrint...", "Estates.JGroundSheet.SharePersonPrint", new object[] { Node.Code,pRow["GCode"] }, null);//

            //  درخواست انتقال            
            JAction RequestTransferSheet = new JAction("RequestTransferSheet...", "Estates.JRequestTransferSheet.ShowDialog", new object[] { 0,Node.Code }, null);//
            //Node.EnterClickAction = RequestTransferSheet;

            pMenu.Insert(deleteAction);
            pMenu.Insert(RequestTransferSheet);
            pMenu.Insert(ContractPrint);
            pMenu.Insert(SheetPrint);
            pMenu.Insert(SharePersonPrint);

            int FinanceCode = 0;
            if (_BuyContractCode != 0)
            {
                /// اکشن تائید قرارداد
                Legal.JSubjectContract SC = new Legal.JSubjectContract(_BuyContractCode);
                FinanceCode = SC.FinanceCode;
                JAction confirmAction = new JAction("ConfirmContract...", "Legal.JSubjectContract.ConfirmContract", new object[] { SC.ContractType.Code }, new object[] { _BuyContractCode });
                pMenu.Insert(confirmAction);
                SC.Dispose();
            }
            else
            {
                JAsset tmpAsset = new JAsset();
                tmpAsset.GetData("Estates.JGround", (int)pRow[JGroundSheetEnum.GCode.ToString()]);
                FinanceCode = tmpAsset.Code;
            }

            pMenu.Insert(splitter);

            List<JAction> actions =
                CreateActions(_BuyContractCode, _PersonContractCode);
            foreach (JAction action in actions)
            {
                pMenu.Insert(action);
            }

            if (pRow["وضعیت"].ToString() == "فعال")
            {
                JAction NewContract = new JAction("NewContract...", "");

                Legal.JContractNodes CN = new Legal.JContractNodes();
                /// در صورتی که نیاز است هر کدام از اراضی به عنوان یک گروه امول تعریف شود(مانند بازار در اعیان) کد اراضی را به عنوان پارامتر این تابع قرار میدهیم. 
                /// ولی در حال حاضر چون خود زمین به عنوان یک گروه اموال تعریف شده، کد 1 را میفرستیم
                JNode[] _nodes = CN.ContractTree(Finance.JAssetGroup.GroundGroupCode);

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
                                new JAction(_childnode.Name, "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code, 0, FinanceCode, false, Node.Code });
                            _AContractType.AddChild(_AContract);
                        }
                    }
                }

                pMenu.Insert(NewContract);
            }
            Node.Popup = pMenu;
            return Node;
        }
        #endregion


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

        private List<JAction> CreateOwnersActions(int pContractCode, int pPersonCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);
                JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                actions.Add(viewContract);
            }
            /// اکشن فسخ قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);
                JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
                actions.Add(CancelAction);
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
            ///  مشخصات تعرفه
            if (pContractCode > 0)
            {
                //JAction viewContract = new JAction("TarefeInformation...", "Estates.JSheetGroundForm.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                //actions.Add(viewContract);
            }
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
                         " فرزند " + Person.FatherName +
                    " به شماره شناسنامه " + Person.ShSh +
                        " و کد ملی " + Person.ShMeli +                           
                                " صادره از " + Person.SaderText +
                                   " متولد " + JDateTime.FarsiDate(Person.BthDate).Split('/')[0];
                    return strPerson;
                }
            return "";
        }

        public void PrintSheet()
        {
            if (this.DeliveryDate < DateTime.Parse("2012/01/01"))
            {
                this.DeliveryDate = JDateTime.Now();
            }
            this.NumPrint++;
            this.Update();

            DataTable _DT = JGroundSheets.GetWordPrintData(Code);
            JDynamicReports DRC = new JDynamicReports(JReportDesignCodes.SheetGround.GetHashCode());
            DRC.Add(_DT);

            //Globals.Property.JPropertyValueUserControl t = new Globals.Property.JPropertyValueUserControl();
            //t.ClassName = "Estates.JSheetGroundForm";
            //t.ObjectCode = 10;
            //t.ValueObjectCode = Code;
            //t.GetDataRowValue();

            //DataTable Dt = new DataTable(); ;
            //DataRow DR = t.GetDataRowValue();
            //foreach (DataColumn DC in DR.Table.Columns)
            //{
            //    Dt.Columns.Add(DC.Caption);
            //    if (Dt.Rows.Count == 0)
            //        Dt.Rows.Add(0);
            //    Dt.Rows[0][DC.Caption] = DR[DC.Caption];
            //}
            Globals.Property.JPropertyTables tmpProperty = new Globals.Property.JPropertyTables("Estates.JSheetGroundForm", ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode());
            DataTable DtProperty = new DataTable();
            DtProperty = tmpProperty.GetData(Code);
            DtProperty.TableName = "ویژگی تعرفه";
            DRC.Add(DtProperty);
            //DRC.PrintDefault();
            DRC.PrintDefault();
        }

        public void PrintKorooki()
        {
            DataTable _DT = JGroundSheets.GetWordPrintData(Code);
            JDynamicReports DRC = new JDynamicReports(JReportDesignCodes.SheetGround.GetHashCode());
            DRC.Add(_DT);

            JGroundSheet GS = new JGroundSheet(Code);
            DataTable _Korooki = JGroundSheets.Korooki(GS.GCode);
            DRC.Add(_Korooki);

            DataTable _SharePerson = JGroundSheets.GetSharePersonGroundData(GS.GCode);
            _SharePerson.TableName = "SharePerson";
            DRC.Add(_SharePerson);

            DRC.Print("کروکی", false, false);
        }

        public void SharePersonPrint(int pCode,int pGCode)
        {
            DataTable _DTGround = JGroundSheets.GetWordPrintData(pCode);

            DataTable _DT = JGroundSheets.GetSharePersonGroundData(pGCode);
            JDynamicReports DRC = new JDynamicReports(JReportDesignCodes.SheetGround.GetHashCode());

            DataTable _Korooki = JGroundSheets.Korooki(pGCode);
            DRC.Add(_Korooki);

            DRC.Add(_DT);
            DRC.Add(_DTGround);
            DRC.Print("شرکا", false, false);
        }

    }
    public class JGroundSheets : JSystem
    {
        public JGroundSheets[] Items = new JGroundSheets[0];
        //  public String OrderName;
        public JGroundSheets()
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
            return GetDataTable(pCode,"");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode,string pWhere)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.Paging = true;
            try
            {
                Globals.Property.JPropertyTables tmpProperty = new Globals.Property.JPropertyTables("Estates.JSheetGroundForm", ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode());
                string propSQL = tmpProperty.getSQL();

                string WHERE = @"select ESS.Code,PCode,GCode,
(select Name from estUsageGround Where Code=(Select Usage From estground Where Code=GCode)) 'Usage',
(Select MainAve from estground Where Code=GCode) 'MainAve',
(Select SubNo from estground Where Code=GCode) 'SubNo',
(Select BlockNum from estground Where Code=GCode) 'BlockNum',
(Select PartNum from estground Where Code=GCode) 'PartNum',
(Select Area from estground Where Code=GCode) 'AreaGround',
(Select Name from clsAllPerson Where Code=PCode) 'Full_Name',
(Select Name from clsPerson Where Code=PCode) 'Name',
(Select Fam from clsPerson Where Code=PCode) 'Fam',
(Select sd.name from clsPerson p INNER JOIN subdefine sd ON p.sader = sd.Code Where p.Code = PCode) 'Sader',

(Select ShSh from clsPerson Where Code=PCode) 'ShSh',
(Select ShMeli from clsPerson Where Code=PCode) 'ShMeli',
(
	Select top 1 (select Name from subdefine SUB where SUB.Code=PA.City) from clsPersonAddress PA
	Where AddressType = 1 And PA.Code=ESS.PCode order by PA.Code desc
	) 'City',

ContractCodeSell,
ContractCodeBuy ,
cast(Area as decimal(18,4)) Area,
(Select Fa_Date from StaticDates where  En_Date = cast(CreateDate as date)) 'CreateDate',
Creator,
(Select Fa_Date from StaticDates where  En_Date = cast(DeliveryDate as date)) 'DeliveryDate',
NumPrint,
case deactive when 1 then 'غیر فعال' 
when 0 then 'فعال' end 'وضعیت',
Share ,
(select ROUND(EG.TotalShare*ESS.Area/EG.Area,3,0) from dbo.estGround EG Where ESS.GCode= EG.Code) 'Sahm',
(Select top 1 case [Action] when 1 then 'تفکیک شده' when 2 then 'تجمیع شده' end 
from estSheetLog inner join estSheetLogDetails on estSheetLogDetails.SheetLogCode=estSheetLog.Code 
Where estSheetLogDetails.SheetCodeDetails=ESS.Code or estSheetLog.SheetCode = ESS.Code) [Action],
(Select top 1 estSheetLog.SheetCode 
from estSheetLog 
inner join estSheetLogDetails on estSheetLogDetails.SheetLogCode=estSheetLog.Code 
Where estSheetLogDetails.SheetCodeDetails=ESS.Code or estSheetLog.SheetCode = ESS.Code) HistorySheetCode,
ESS.AreaNew 'AreaNew',OldContractPrice,NewContractPrice" +
String.Join(",",tmpProperty.getFeildsName(false))               +@"
 From estSheet ESS
left join (" + propSQL + ") AS prop ON prop.objectcode = ESS.Code" +
@"
Where 1=1 ";
                
                if (pCode != 0)
                    WHERE = WHERE + " And Code = " + pCode;
                DB.setQuery(WHERE + pWhere);
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

        public static DataTable Korooki(int pGCode)
        {
            DataTable _temp;
            ArchivedDocuments.JArchiveDocument tmpArchive = new ArchivedDocuments.JArchiveDocument();
            DataTable dtArchive = tmpArchive.Retrieve("JGroundForm.Koroki", pGCode);
            if ((dtArchive != null) && (dtArchive.Rows.Count > 0))
                _temp = JGrounds.FindKoroki(Convert.ToInt32(dtArchive.Rows[0]["ArchiveCode"]));
            else
                _temp = JGrounds.FindKoroki(0);
            if (_temp != null)
                _temp.TableName = "Korooki";
            return _temp;
        }

        public static DataTable GetSharePersonGroundData(int pGCode)
        {
            JDataBase _DB = new JDataBase();
            try
            {

                _DB.setQuery(@"select *,(Select Name From clsAllPerson where PCode=Code) Name,

(select STUFF((select (Name+ '  ' + (Select top 1 (Tel+'-'+Mobile) From clsPersonAddress Where clsAllPerson.Code=PCode) +
'- گروه  '+isnull((select Name From LotteryGroup Where Header=PCode),'')
) 
From clsAllPerson 
where Code in (
Select (select  Header From LotteryGroup Where Header=PCode) From estSheet Where GCode=" + pGCode + @"
and (select  Header From LotteryGroup Where Header=PCode) > 0)  FOR XML PATH('')), 1, 0, '' ) AS 'Header')
+(select (Select Name From LotteryGroup Where Code=R.GroupCode) From LotterySahamdar R where R.SahamCode=estSheet.PCode)
'Header',
(SELECT ROUND(EG.TotalShare*estSheet.Area/EG.Area,3,0) FROM estGround EG WHERE EG.Code= estSheet.GCode) 'SahmRound',
(select (Select Name From LotteryGroup Where Code=R.GroupCode) From LotterySahamdar R where R.SahamCode=estSheet.PCode) 'GroupName',

(select STUFF((Select top 1 (Tel+'-'+Mobile) From clsPersonAddress Where clsPersonAddress.PCode=estSheet.PCode
 FOR XML PATH('')), 1, 0, '' ) AS 'Tel') 'Tel',

(Select Top 1 Address From clsPersonAddress Where clsPersonAddress.PCode=estSheet.PCode And AddressType=1) 'Address',

(Select name From subdefine Where Code=(select top 1 City from clsPersonAddress where PCode=estSheet.PCode And AddressType=1)) 'City',
(select TotalShare from estGround where Code=Gcode) TotalShare

from estSheet Where DeActive=0 And GCode=" + pGCode);
                return _DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                _DB.Dispose();
            }
        }

        public static DataTable GetWordPrintData(int pCode)
        {
            JGroundSheet GS = new JGroundSheet(pCode);

            JDataBase _DB = new JDataBase();
            try
            {
                string _Where = "";
                string _Name = "NULL";
                if (pCode > 0)
                {
                    _Where = " WHERE ES.Code = " + pCode.ToString();
                    _Name = JGroundSheet.GetPersonContractText(GS.PCode, JDateTime.Now().ToString());
                }
                _DB.setQuery(@"select "
+ JDataBase.Quote(_Name) +
@" Name,
ES.Code,
ES.PCode,
EG.BlockNum,
EG.PartNum,
CAST(round(ES.Area,3) as varchar) Area,
CAST(round(ES.Area,3) as varchar) BaseArea,
CAST(round(EG.Area,3) as varchar) AllArea,
CAST(round(EG.Area,3) as varchar) BaseAllArea,
(select Name from estUsageGround where Code = EG.Usage ) AS Usage,
(select SD.Fa_Date from dbo.StaticDates SD where SD.En_Date =  Cast(ES.DeliveryDate as date)) BaseDeliveryDate,
(select SD.Fa_Date from dbo.StaticDates SD where SD.En_Date =  Cast(ES.DeliveryDate as date)) DeliveryDate,
EG.TotalShare*ES.Area/EG.Area 'Sahm',ROUND(EG.TotalShare*ES.Area/EG.Area,3,0) 'SahmRound',
EG.Cost,
(select Fam from clsPerson where Code = ES.PCode)Fam,
(select Name from clsPerson where Code = ES.PCode)FirstName,
(select Name from clsPerson where Code = ES.PCode)+' '+(select Fam from clsPerson where Code = ES.PCode)FullName,
(select FatherName from clsPerson where Code = ES.PCode)FatherName,
(select ShSh from clsPerson where Code = ES.PCode)ShSh,
(select ShMeli from clsPerson where Code = ES.PCode)ShMeli,
(select (select Name from subdefine Where Code = sader) from clsperson where Code = ES.PCode)Sader
FROM estSheet ES
INNER join estGround EG
ON ES.GCode = EG.Code " + _Where);
                DataTable _DT = _DB.Query_DataTable();
                if (_DT.Rows.Count > 0)
                {
                    _DT.Rows[0]["DeliveryDate"] = JGeneral.ReverseDate(_DT.Rows[0]["DeliveryDate"].ToString());
                    //JGeneral.ReverseDate()
                    _DT.Rows[0]["Area"] = JGeneral.ReverseNumber(_DT.Rows[0]["Area"].ToString().Replace('.', '/'), '/');
                    _DT.Rows[0]["AllArea"] = JGeneral.ReverseNumber(_DT.Rows[0]["AllArea"].ToString().Replace('.', '/'),'/');
// 
                    _DT.Rows[0]["BaseArea"] = (_DT.Rows[0]["BaseArea"].ToString().Replace('.', '/'));
                    _DT.Rows[0]["BaseAllArea"] = (_DT.Rows[0]["BaseAllArea"].ToString().Replace('.', '/'));
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
            }
            return null;
        }
        public void ListView1(int pState)
        {
            Nodes.ObjectBase = new JAction("GetGroundSheet", "Estates.JGroundSheet.GetNode");
            Nodes.DataTable = GetDataTable(0, " And DeActive=" + pState);
        }

        public void ListView()
        {
            JRowStyles p = new JRowStyles();

            JRowStyle R = new JRowStyle();
            R.Expression = " AreaNew is not null ";
            Janus.Windows.GridEX.GridEXFormatStyle JanusRowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
            JanusRowStyle.BackColor = System.Drawing.Color.Red;
            R.JanusRowStyle = JanusRowStyle;

            p.Add(R);
            Nodes.RowStyles = p;

            Nodes.ObjectBase = new JAction("GetGroundSheet", "Estates.JGroundSheet.GetNode");
            Nodes.DataTable = GetDataTable();
            

            JAction ActiveContractAction = new JAction("New...", "Estates.JGroundSheets.ListView1", new object[] { 0 }, null);
            Nodes.GlobalMenuActions.Insert(ActiveContractAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = ActiveContractAction;
            JTN.Icon = JImageIndex.Activity;
            JTN.Hint = " تعرفه  فعال  ";
            Nodes.AddToolbar(JTN);

            JAction DeActiveAction = new JAction("New...", "Estates.JGroundSheets.ListView1", new object[] { 1 }, null);
            Nodes.GlobalMenuActions.Insert(DeActiveAction);
            JToolbarNode JTN2 = new JToolbarNode();
            JTN2.Click = DeActiveAction;
            JTN2.Icon = JImageIndex.Help;
            JTN2.Hint = " تعرفه غیرفعال ";
            Nodes.AddToolbar(JTN2);

            JAction PrintContractAction = new JAction("ContractPrint...", "Estates.JGroundSheet.CreateContractPrint", null, null);
            JToolbarNode PrintContract = new JToolbarNode();
            PrintContract.Click = PrintContractAction;
            PrintContract.Icon = JImageIndex.Print;
            PrintContract.Hint = " چاپ قرارداد ";
            Nodes.AddToolbar(PrintContract);

            JAction PrintSheetAction = new JAction("SheetPrint...", "Estates.JGroundSheets.SheetsPrint", null, null);
            JToolbarNode PrintSheetNode = new JToolbarNode();
            PrintSheetNode.Click = PrintSheetAction;
            PrintSheetNode.Icon = JImageIndex.Printer;
            PrintSheetNode.Hint = " چاپ تعرفه ";
            Nodes.AddToolbar(PrintSheetNode);

            JAction PrintKorookiAction = new JAction("SheetPrint...", "Estates.JGroundSheets.SheetsKorooki", null, null);
            JToolbarNode PrintKorookiNode = new JToolbarNode();
            PrintKorookiNode.Click = PrintKorookiAction;
            PrintKorookiNode.Icon = JImageIndex.Contract;
            PrintKorookiNode.Hint = " چاپ کروکی ";
            Nodes.AddToolbar(PrintKorookiNode);

            JAction ReportAction = new JAction("SheetPrint...", "Estates.JGroundSheets.ShowReport", null, null);
            JToolbarNode ReportNode = new JToolbarNode();
            ReportNode.Click = ReportAction;
            ReportNode.Icon = JImageIndex.Contract;
            ReportNode.Hint = " گزارش تعرفه ";
            Nodes.AddToolbar(ReportNode);
        }

        public void ShowReport()
        {
            ReportSheetForm p = new ReportSheetForm();
            p.ShowDialog();
        }

        public static void SheetsPrint()
        {
            try
            {
                if (!(JPermission.CheckPermission("Estates.JGroundSheets.SheetsPrint")))
                    return;

                JGroundSheet GS = new JGroundSheet();
                foreach (DataRow dr in Nodes.DefaultView.Rows)
                {
                    GS.GetData((int)dr["Code"]);
                    GS.PrintSheet();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public static void SheetsKorooki()
        {
            try
            {
                if (!(JPermission.CheckPermission("Estates.JGroundSheets.SheetsKorooki")))
                    return;

                JGroundSheet GS = new JGroundSheet();
                foreach (DataRow dr in Nodes.DefaultView.Rows)
                {
                    GS.GetData((int)dr["Code"]);
                    GS.PrintKorooki();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
