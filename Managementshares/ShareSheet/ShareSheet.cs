using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
using Finance;

namespace ManagementShares
{
    public enum JSheetStatus
    {
        All = -1,
        Deactive = 0,
        Active = 1,
        //Divided = 2,
        //Transfered = 2,
        //Joined = 4
    }

    public enum JSheetAgentStatus
    {
        All = 0,
        HasAgent = 1,
        HasNotAgent = 2
    }

    public enum JShareOperations
    {
        Transfer = 1,
        Divide = 2,
        Join = 3,
        IncreaseShare = 4,
        BreakeShare = 5
    }

    public enum JSheetPrintStatus
    {
        NotPrinted = 0,
        Printed = 1,
        All = 100
    }

    public enum JTransferStatus
    {
        All = 0,
        HasTransfer = 1,
        HasNotTransfer = 2
    }

    /// <summary>
    /// کلاس برگه سهم
    /// </summary>
    public class JShareSheet : JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد شرکت 
        /// </summary>
        public int CompanyCode { get; set; }
        /// <summary>
        /// از
        /// </summary>
        public int Az { get; set; }
        /// <summary>
        /// الی
        /// </summary>
        public int Ela { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// کد وکیل
        /// </summary>
        public int ACode { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// کد دوره افزایش سرمایه
        /// </summary>
        public int CourseCode { get; set; }
        /// <summary>
        /// تعداد دفعات چاپ
        /// </summary>
        public int NumPrint { get; set; }
        /// <summary>
        /// تعدا سهم
        /// </summary>
        public int ShareCount { get; set; }
        /// <summary>
        /// دوره
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// کد پدر، هنگام کپی و تقسیم سهم درج میشود
        /// </summary>
        public int ParentCode { get; set; }
        #endregion Properties

        public JShareSheet()
        {
        }
        public JShareSheet(int SCode)
        {
            GetData(SCode);
        }

        public int Insert(JDataBase pDB, int TransferParentCode, int TransferObjectCode, int ShareParentCode)
        {
            JShareSheetTable sheetTable = new JShareSheetTable();
            try
            {
                sheetTable.Set_ComplexInsert(false);
                sheetTable.SetValueProperty(this);
                Code = sheetTable.Insert(pDB);
                if (Code > 0)
                {
                    //// Asset 
                    Finance.JAsset asset = new Finance.JAsset();
                    asset.ClassName = "ManagementShares.JShareSheet";
                    asset.ObjectCode = Code;
                    asset.CreatorPostCode = JMainFrame.CurrentPostCode;
                    asset.CreatorUserCode = JMainFrame.CurrentUserCode;
                    asset.Comment = "برگه شماره " + Code;
                    asset.Status = Finance.JStatusType.Active;
                    asset.DivideType = Finance.JDivideType.IntegerDivide;
                    asset.GroupCode = 2;
                    if (asset.Insert(pDB) <= 0)
                        throw new Exception();
                    /// Asset Transfer
                    JAssetTransfer assetTransfer = new JAssetTransfer();
                    assetTransfer.ACode = asset.Code;
                    assetTransfer.ClassName = "ManagementShares.JDivideSheet";
                    assetTransfer.ParentCode = TransferParentCode;
                    assetTransfer.OwnershipType = JOwnershipType.Definitive;
                    assetTransfer.Comment = "";
                    assetTransfer.ObjectCode = TransferObjectCode;
                    if (!assetTransfer.Insert(pDB))
                        throw new Exception();
                    /// AssetShare
                    JAssetShare assetShare = new JAssetShare();
                    assetShare.ParentCode = ShareParentCode;
                    assetShare.PersonCode = this.PCode;
                    assetShare.Share = this.ShareCount;
                    assetShare.Status = JStatusType.Active;
                    assetShare.ACode = asset.Code;
                    assetShare.TCode = assetTransfer.Code;
                    if (assetShare.Insert(pDB) <= 0)
                        throw new Exception();
                    if (pDB == null)
                        Nodes.DataTable.Merge(JShareSheets.GetDataTable(0, Code));
                    /// Web Log
                    JShareWebLog.Insert(pDB, "ShareSheet", Code, 'i');
                }
                return Code;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        public bool Update(JDataBase pDB)
        {
            JShareSheetTable sheetTable = new JShareSheetTable();
            try
            {
                sheetTable.SetValueProperty(this);
                if (sheetTable.Update(pDB))
                {
                    /// Web Log
                    //  JShareWebLog.Insert(pDB, "ShareSheet", Code, 'u');
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
                //       Db.Dispose();
            }
        }
        public void GetData(int SCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT * From ShareSheet WHERE Code = " + SCode);
                DataTable sheet = db.Query_DataTable();
                if (sheet.Rows.Count > 0)
                    JTable.SetToClassProperty(this, sheet.Rows[0]);
            }
            finally
            {
                db.DisConnect();
            }
        }

		public void GetDataByPerson(int PCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery(" SELECT * From ShareSheet WHERE PCode = " + PCode);
				DataTable sheet = db.Query_DataTable();
				if (sheet.Rows.Count > 0)
					JTable.SetToClassProperty(this, sheet.Rows[0]);
			}
			finally
			{
				db.DisConnect();
			}
		}

        /// <summary>
        /// حذف وکیل
        /// </summary>
        public void DeleteAgent(JNode node)
        {
            if (JMessages.Question("آیا میحواهید وکیل برگه حذف شود؟", "حذف وکیل") == System.Windows.Forms.DialogResult.Yes)
            {
                JShareAgentHistory aHistory = new JShareAgentHistory();
                aHistory.ACode = 0;
                this.ACode = 0;
                aHistory.ChangeDate = DateTime.Now;
                aHistory.SCode = this.Code;
                JShareAgentHistoryTable historyTable = new JShareAgentHistoryTable();
                historyTable.SetValueProperty(aHistory);
                JDataBase db = new JDataBase();
                try
                {
                    db.beginTransaction("Agent");
                    historyTable.Insert(db);
                    this.Update(db);
                    db.Commit();
                }
                finally
                {
                    db.DisConnect();
                }
                if (node != null)
                {
                    DataTable result = JShareSheet.GetSheets(node.Code);
                    Nodes.Refreshdata(node, result.Rows[0]);
                }
            }
        }

        /// <summary>
        /// انتخاب وکیل
        /// </summary>
        /// <param name="node"></param>
        public void SelectAgent(JNode node)
        {
            JSelectAgentForm form = new JSelectAgentForm(CompanyCode);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ACode = form.SelectedCode;
                JShareAgentHistory aHistory = new JShareAgentHistory();
                aHistory.ACode = form.SelectedCode;
                aHistory.ChangeDate = form.SelectedDate;
                aHistory.SCode = this.Code;
                JShareAgentHistoryTable historyTable = new JShareAgentHistoryTable();
                historyTable.SetValueProperty(aHistory);
                JDataBase db = new JDataBase();
                try
                {
                    db.beginTransaction("Agent");
                    historyTable.Insert(db);
                    this.Update(db);
                    db.Commit();
                }
                finally
                {
                    db.DisConnect();
                }
                if (node != null)
                {
                    DataTable result = JShareSheet.GetSheets(node.Code);
                    Nodes.Refreshdata(node, result.Rows[0]);
                }
            }
        }
        /// <summary>
        /// نمایش سابقه برگه سهم
        /// </summary>
        public void ShowHistory()
        {
            DataTable loggs = JSharePersonLogger.GetSheetLog(this.Code);
            JSheetHistoryForm form = new JSheetHistoryForm(loggs);
            form.ShowDialog();
        }

        /// <summary>
        /// نمایش فرم پرونده سهامداران
        /// </summary>
        public void DocumentSahamdar(int pPCOde)
        {
            JDocumentSahamdarForm form = new JDocumentSahamdarForm(pPCOde);
            form.ShowDialog();
        }

        public JNode GetNode(DataRow pRow)
        {


            JNode node = new JNode((int)pRow["Code"], "ManagementShares.JShareSheet");
            Nodes.hidColumns = "SCode";
            bool distrainted = false;
            bool delivery = false;
            int PCode = 0;
            try
            {
                Int32.TryParse(pRow["PCode"].ToString(),out PCode);
                Boolean.TryParse(pRow["Distrainted"].ToString(), out distrainted);
                Boolean.TryParse(pRow["deliverStatus"].ToString(), out delivery);
            }
            catch { }
            int[] codes = { node.Code };
            foreach (DataRow row in Nodes.Selected.Rows)
            {
				try
				{
					if (row.Table.Columns.IndexOf("Code") > -1)
					{
						Array.Resize(ref codes, codes.Length + 1);
						codes[codes.Length - 1] = Convert.ToInt32(row["Code"]);
					}
				}
				catch
				{
				}
            }
            if (!distrainted)
            {
                ///توقیف برگه سهم
                JAction distraintSheet = new JAction("DistraintSheet...", "Legal.JDistraint.ShowDialog", new object[] { Legal.JDistraintSubjectEnum.Asset, "ManagementShares.JShareSheet", node.Code, PCode, true }, null);
                node.Popup.Insert(distraintSheet);
            }
            else
            {
                /// رفع توقیف برگه سهم
                int distraintCode = (int)pRow["DistraintCode"];
                JAction distraintSheet = new JAction("UnDistraintSheet...", "Legal.JDistraint.ShowDialog", new object[] { false }, new object[] { distraintCode });
                node.Popup.Insert(distraintSheet);
            }
            /// سابقه
			JAction historyAction = new JAction("SheetHistory...", "ManagementShares.JShareSheet.ShowHistory", null, new object[] { (int)pRow["Code"] });
            node.Popup.Insert(historyAction);

            /// اکشن ویرایش
            JAction editAction = new JAction("PersonInfo...", "ClassLibrary.JAllPerson.ShowDialog", null, new object[] { PCode });
            node.Popup.Insert(editAction);
            node.MouseDBClickAction = editAction;
			//node.AutoRefreshAfterMouseDoubleClick = true;
            node.EnterClickAction = editAction;
            node.Popup.Insert("-");
            /// حذف وکیل
            JAction delAgentAction = new JAction("DeleteAgent...", "ManagementShares.JShareSheet.DeleteAgent", new object[] { node }, new object[] { node.Code });
            node.Popup.Insert(delAgentAction);
            /// انتخاب وکیل
            JAction agentAction = new JAction("SelectAgent...", "ManagementShares.JShareSheet.SelectAgent", new object[] { node }, new object[] { node.Code });
            node.Popup.Insert(agentAction);
            node.Popup.Insert("-");
            /// اکشن تقسیم
            JAction splitAction = new JAction("Divide...", "ManagementShares.JShareSheet.ShowDivideForm", new object[] { node }, null);
            splitAction.Enabled = !distrainted && delivery;
            node.Popup.Insert(splitAction);
            /// اکشن انتقال
            JAction transferAction = new JAction("Transfer...", "ManagementShares.JShareSheet.ShowTransferForm", new object[] { codes, node }, null);
            transferAction.Enabled = !distrainted && delivery;
            node.Popup.Insert(transferAction);
            node.Popup.Insert("-");
            /// اکشن چاپ برگه سهم

			/// اکشن قرارداد
            /// اکشن مشاهده
			/// 			

			if (pRow["LSCType"].ToString().Length > 0 && (int)pRow["LSCCode"].ToString().Length > 0)
			{
				JAction viewAction = new JAction("View Contract...", "Legal.JGeneralContract.ShowForms", null, new object[] { (int)pRow["LSCType"], (int)pRow["LSCCode"], true });
				node.Popup.Insert(viewAction);
			}
			/// اکشن چاپ برگه سهم
			
			JAction printAction = new JAction("PrintShareSheet...", "ManagementShares.JShareSheets.PrintShareSheet", new object[] { Nodes.Selected }, null);
            printAction.Enabled = !distrainted;
            node.Popup.Insert(printAction);

			Nodes.AutoRefreshAction = new JAction("SharePrice", "ManagementShares.JShareSheets.GetDataTable", new object[] { CompanyCode, node.Code }, null);

            return node;
        }

        public JNode GetDeActiveNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "ManagementShares.JShareSheet");
            int PCode = (int)pRow["PCode"];
            int[] codes = { node.Code };
            foreach (DataRow row in Nodes.Selected.Rows)
            {
                Array.Resize(ref codes, codes.Length + 1);
                codes[codes.Length - 1] = Convert.ToInt32(row["Code"]);
            }
            return node;
        }

        public JNode GetPersonNode(DataRow pRow)
        {
			
            JNode node = new JNode((int)pRow[JPersonTableEnum.Code.ToString()], "ClassLibrary.JPerson");
            Nodes.hidColumns = "companyCode";
			int codes =  node.Code ;
			int PCode = (int)pRow["Code"];
			int CompanyCode = (int)pRow["companyCode"];
			//bool distrainted = (bool)pRow["Distrainted"];
            JAction seperator = new JAction("-", "");
            //HassanZadeh
            /// اکشن چاپ کارت سهامداری
            JAction CardAction = new JAction("CardSahamdari...", "SmartCardSepad.JCardDefine.ShowDialogPerson", new object[] { 0, node.Code }, null);
            /// اکشن مشاهده سابقه نقل و انتقالات
            int companyCode = Convert.ToInt32(pRow["companyCode"]);
            JAction transferActionHitory = new JAction("TransferHistory...", "ManagementShares.JSharePersonLoggers.ShowPersonHistory", new object[] { node.Code, companyCode }, null);

            /// مدارک سهامدار اسکن شده
            JAction DocumentsAction = new JAction("DocumentsSahamdar...", "ManagementShares.JShareSheet.DocumentSahamdar", new object[] { pRow["SharePCode"] }, null);
            node.Popup.Insert(DocumentsAction);

            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ClassLibrary.JAllPerson.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;

			/// اکشن انتقال
			JAction transferAction = new JAction("Transfer...", "ManagementShares.JShareSheet.ShowTransferFormByPerson", new object[] { codes, CompanyCode, node }, null);
			transferAction.Enabled =true;
			node.Popup.Insert(transferAction);
			node.Popup.Insert("-");

            /// اکشن مشاهده
            //  JAction viewAction = new JAction("View...", "ClassLibrary.JAllPerson.ShowDialog", new object[] { true }, new object[] { node.Code });
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete", "ClassLibrary.JPerson.Delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "ClassLibrary.JPerson.ShowDialog", null, null);

			JAction EditUser = new JAction("Edit User", "Globals.JUser.ShowDialog", null, new object[] { node.Code , true });


			JAction EditSharePCode = new JAction("Edit SharePCode", "ManagementShares.ShareCompany.SharePCodeChange.ShowDialog", null, new object[] { CompanyCode, PCode });
			
			//Nodes.WordWrapColumn("HomeAddress", 4);
            //Nodes.WordWrapColumn("WorkAddress", 4);
            //// در صورتیکه شخص متوفی باشد آیتمهای منو متفاوت است
            node.Popup.Insert(CardAction);
            node.Popup.Insert("-");
			node.Popup.Insert(transferActionHitory);
            node.Popup.Insert(transferAction);
            node.Popup.Insert(seperator);
            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
			node.Popup.Insert(EditUser);
			node.Popup.Insert(EditSharePCode);
			//  node.Popup.Insert(viewAction);
            node.Popup.Insert(newAction);
            return node;
        }

        public static DataTable GetSheets(int SCode)
        {
            return GetSheets(new int[] { SCode });
        }

		public static int[] GetCodeSheetPerson(int pCode, int CompanyCode)
		{
			JDataBase db=new JDataBase();
			try
			{
				db.setQuery(" SELECT  * "+ 
							" FROM ShareSheet "+
							" where PCode=" + pCode + " and CompanyCode =" + CompanyCode);
				DataTable dt= db.Query_DataTable();
				int cnt=dt.Rows.Count;
				Int32 [] scodes=new int[cnt];
				if (dt.Rows.Count > 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						scodes[i] = Convert.ToInt32( dt.Rows[i]["Code"]);
					}
					return scodes;
				}

			}
			catch
			{
			}
			finally
			{
				db.Dispose();
			}
			return null;

		}

        public decimal GetPrice(int pCode)
        {
            GetData(pCode);
            JShareCompany SC = new JShareCompany(CompanyCode);
            return ShareCount * SC.CurrentShareCost;
        }

        public static DataTable GetSheets(int SCode, bool pStatus)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(JShareReport.SQLSheet + "  AND  S1.Code = " + SCode.ToString() );
                DataTable sheets = db.Query_DataTable();
                return sheets;
            }
            finally
            {
                db.DisConnect();
            }
        }

        
        public static DataTable GetSheets(int[] SCodes, bool Distraint, bool Delivery)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sTemp = "";
                if(Distraint)
                {
                    sTemp += " AND Convert(bit, Case legDistraint .Active When 1 then 1 else 0 END ) = 0";
                }

                if (Delivery)
                {
                    sTemp += " AND Delivery IS not NULL and Delivery<>0";
                }

                db.setQuery(JShareReport.SQLSheet +
                    "  AND  S1.Code IN " + JDataBase.GetInSQLClause(SCodes) +
                    " AND S1.Status =1 And S1.ShareCount>0"+sTemp);
                DataTable sheets = db.Query_DataTable();
                return sheets;
            }
            finally
            {
                db.DisConnect();
            }
        }

        public static DataTable GetSheets(int[] SCodes)
        {
            return GetSheets(SCodes, false, false);
        }

		public static DataTable GetSheetByPerson(int pCode,int companyCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery(" select  companycode,pcode,sum(ShareCount) as ShareCount "+
								" from ShareSheet "+
								" where PCode="+pCode.ToString()+ " and CompanyCode =" + companyCode.ToString() +
								" group by pcode,companycode ");
				DataTable sheets = db.Query_DataTable();
				return sheets;
			}
			finally
			{
				db.DisConnect();
			}
		}
        /// <summary>
        /// نمایش فرم انتقال
        /// </summary>
        /// <param name="SCodes"></param>
        public void ShowTransferForm(int[] SCodes, JNode pNode)
        {
            JTransferSheetForm form = new JTransferSheetForm(SCodes);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Nodes.Refreshdata(pNode, JShareSheets.GetDataTable(0, form.ResultCode).Rows[0]);
                }
                catch
                {
                }
            }
        }



		/// <summary>
		///  نمایش فرم انتقال بر اساس شخص
		/// </summary>
		/// <param name="SCodes"></param>
		public void ShowTransferFormByPerson(int PCodes, int pCompanyCode, JNode pNode)
		{
			JTransferSheetForm form = new JTransferSheetForm(PCodes, pCompanyCode,"");
			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				try
				{
					Nodes.Refreshdata(pNode, JShareSheets.GetDataTable(0, form.ResultCode).Rows[0]);
				}
				catch
				{
				}
			}
		}

        /// <summary>
        /// نمایش فرم تقسیم
        /// </summary>
        /// <param name="SCodes"></param>
        public void ShowDivideForm(JNode SCode)
        {
            JDivideForm form = new JDivideForm(SCode.Code);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable resultTable = JShareSheet.GetSheets(form.ResultSheets);
                Nodes.DataTable.Merge(resultTable);
                Nodes.Delete(SCode);
            }
        }
        /// <summary>
        /// تابع انتقال برگه سهم
        /// تعداد سهم مشخص از این برگه را به شخص جدید منتقل میکند
        /// کد برگه جدید را برمیگرداند
        /// </summary>
        /// <param name="ShareCount">تعداد سهم از این برگه</param>
        /// <param name="NewPCode"></param>
        /// <returns></returns>
        public int TransferSheet(int pShareCount, Int64 NewPCode, JTransferSheet transferSheet, JDataBase pDB, bool DeActiveOld, ref int pTransferSheetCode)
        {
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else
                db = pDB;

            if (pDB == null)
                db.beginTransaction("Transfer");

            JAsset oldAsset = new JAsset("ManagementShares.JShareSheet", this.Code, db);
            JAssetTransfer oldTransfer = new JAssetTransfer(oldAsset.Code, JOwnershipType.Definitive, db);
            JAssetShare oldShares = new JAssetShare(oldAsset.Code, oldTransfer.Code, db);

            #region Check Block Share
            if (oldShares.Status == JStatusType.Block)
            {
                JMessages.Error("سهام شخص توسط واحد حقوقی توقیف شده است.", "error");
                if (pDB == null)
                    db.Rollback("Transfer");
                return 0;
            }
            #endregion Check Block Share

            JAssetTransfer assetTransfer = new JAssetTransfer();
            assetTransfer.ClassName = "ManagementShares.JTransferSheet";
            assetTransfer.ParentCode = oldTransfer.Code;
            assetTransfer.OwnershipType = JOwnershipType.Definitive;
            assetTransfer.Comment = "";

            JAssetShare assetShare = new JAssetShare();
            assetShare.ParentCode = oldShares.Code;
            assetShare.PersonCode = Convert.ToInt32(NewPCode);
            assetShare.Share = pShareCount;
            assetShare.Status = JStatusType.Active;
            transferSheet.TranSum = pShareCount;

            //JSheetLog sheetLog = new JSheetLog();
            //sheetLog.SCode = Code;
            //sheetLog.PCode = PCode;
            //sheetLog.NewPCode = Convert.ToInt32(NewPCode);
            //sheetLog.Operation = JShareOperations.Transfer.GetHashCode();

            try
            {
                if (pShareCount > this.ShareCount)
                {
                    throw new Exception();
                }

                #region Duplicate & Transfer
                /// ساختن یک کپی از برگه، غیر فعال کردن آن و انتقال برگه جدید
                /// در صورتی که تقسیم نیاز نباشد
                if (DeActiveOld && pShareCount == this.ShareCount)
                {
                    JShareSheet newSheet = new JShareSheet();
                    this.DuplicateSheet(transferSheet.TDate, db, ref newSheet);
                    ///غیر فعال کردن دارایی
                    //if (!oldAsset.DeActive(db, true, true))
                    //    throw new Exception();


					////////////////////////////////    BY MOHSENI	  ///////////////////////////////////
					this.DeActivateSheet(db);
					////////////////////////////////    BY MOHSENI	  ///////////////////////////////////

					
					int Ret = newSheet.TransferSheet(pShareCount, NewPCode, transferSheet, db, false, ref pTransferSheetCode);
					if (pDB == null)
						db.Commit();
					return Ret;
                }
                #endregion Duplicate & Transfer

                #region Divide  & Transfer
                /// در صورتی که تعداد سهم قابل فروش مشخص شود و بخشی از برگه سهم انتقال یابد، برگه تقسیم میشود
                /// تقسیم برگه سهم 
                else if (pShareCount < this.ShareCount)
                {
                    int[] divideSheets = { pShareCount, this.ShareCount - pShareCount };
                    List<JShareSheet> dividedSheets = new List<JShareSheet>();
                    if (!this.DivideSheet(divideSheets, transferSheet.TDate, db, ref dividedSheets))
                        throw new Exception();
                    foreach (JShareSheet sheet in dividedSheets)
                    {
                        if (sheet.ShareCount == pShareCount)
                        {

                            if (sheet.TransferSheet(pShareCount, NewPCode, transferSheet, db, false, ref pTransferSheetCode) == 0)
                                throw new Exception();
                            else
                            {
                                /////غیر فعال کردن دارایی
                                //if (!oldAsset.DeActive(db, true, true))
                                //    throw new Exception();
                                ///////غیر فعال کردن برگه تقسیم شده
                                //this.Status = JSheetStatus.Deactive.GetHashCode();
                                //this.Update(db);
                                this.DeActivateSheet(db);
                                if (pDB == null)
                                    db.Commit();
                                return this.Code;
                            }
                        }
                        else
                        {
                            if (pDB == null)
                                db.Rollback("Transfer");
                            return 0;
                        }
                    }
                    if (pDB == null)
                        db.Rollback("Transfer");
                    return 0;
                }
                #endregion Divide & Transfer

                else
                {
                    ///غیر فعال کردن دارایی
                    if (!oldAsset.DeActive(db, true, false))
                        throw new Exception();

                    /// اطلاعات انتقال ثبت میشود
                    transferSheet.SCode = this.Code;
                    int transferCode = transferSheet.Insert(db);
                    if (transferCode <= 0)
                        throw new Exception();
					pTransferSheetCode = transferCode;
                    /// Person Logger
                    /// فروش
                    JSharePersonLogger logger = new JSharePersonLogger();
                    logger.Az = this.Az;
                    logger.Ela = this.Ela;
                    logger.Cost = (new JShareCompany(this.CompanyCode)).CurrentShareCost;
                    logger.InSum = 0;
                    logger.OutSum = this.ShareCount;
                    logger.OperationCode = transferSheet.Code;
					logger.PCode = transferSheet.FPCode;
					logger.PCode2 = transferSheet.SPCode;
					logger.SCode = this.Code;
                    logger.SheetType = JPersonLoggerTypes.Sell.GetHashCode();
                    logger.TDate = transferSheet.TDate;
                    if (logger.Insert(db) <= 0)
                        throw new Exception();

                    /// Person Logger
                    /// خرید
                    JSharePersonLogger newLogger = new JSharePersonLogger();
                    newLogger.Az = this.Az;
                    newLogger.Ela = this.Ela;
                    newLogger.Cost = (new JShareCompany(this.CompanyCode)).CurrentShareCost;
                    newLogger.InSum = this.ShareCount;
                    newLogger.OutSum = 0;
                    newLogger.OperationCode = transferSheet.Code;
					newLogger.PCode = Convert.ToInt32(transferSheet.SPCode);
					newLogger.PCode2 = transferSheet.FPCode;
					newLogger.SCode = this.Code;
                    newLogger.SheetType = JPersonLoggerTypes.Buy.GetHashCode();
                    newLogger.TDate = transferSheet.TDate;
                    if (newLogger.Insert(db) <= 0)
                        throw new Exception();

                    /// AssetTransfer ثیت 
                    assetTransfer.ObjectCode = transferCode;
                    assetTransfer.ACode = oldAsset.Code;
                    if (!assetTransfer.Insert(db))
                        throw new Exception();

                    /// AssetShare ثبت
                    assetShare.ACode = oldAsset.Code;
                    assetShare.TCode = assetTransfer.Code;
                    if (assetShare.Insert(db) <= 0)
                        throw new Exception();

                    this.PCode = Convert.ToInt32(NewPCode);
                    this.NumPrint = 0;
                    /// انتقال وکالت؟
                    if (!transferSheet.Agent)
                        this.ACode = 0;
                    if (!this.Update(db))
                        throw new Exception();

                    ///  Log ثبت  
                    //sheetLog.NewSCode = this.Code;
                    //sheetLog.OperationCode = transferSheet.Code;
                    //if (sheetLog.Insert(db) <= 0)
                    //    throw new Exception();
                    if (pDB == null)
                        db.Commit();
                    return this.Code;
                }
            }
            catch
            {
                if (pDB == null)
                    db.Rollback("Transfer");
                JMessages.Error("عملیات انتقال سهم با مشکل مواجه شده است.", "Error");
                return 0;
            }
            finally
            {
                if (pDB == null && db.Transaction != null)
                    db.Rollback("Transfer");
                if (pDB == null)
                    db.Dispose();
            }

        }
        /// <summary>
        /// برگشت انتقال
        /// </summary>
        /// <param name="pTransferSheet"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public int ReturnTransfer(JTransferSheet pTransferSheet, bool isWeb = false)
        {
            if (!isWeb && !(JMessages.Question("آیا میخواهید انتقال برگشت شود؟", "برگشت انتقال") == System.Windows.Forms.DialogResult.Yes))
            {
                return 0;
            }
            JDataBase db = new JDataBase();
            ///
            ///1. درج AssetTransfer جدید برای برگشت دارایی
            ///
            JAsset oldAsset = new JAsset("ManagementShares.JShareSheet", this.Code, db);
            JAssetTransfer oldTransfer = new JAssetTransfer(oldAsset.Code, JOwnershipType.Definitive, db);
            JAssetShare oldShares = new JAssetShare(oldAsset.Code, oldTransfer.Code, db);
            ///
            oldTransfer.DeActiveAll(db);

            JAssetTransfer assetTransfer = new JAssetTransfer();
            assetTransfer.ClassName = "ManagementShares.JTransferSheet";
            assetTransfer.ParentCode = oldTransfer.Code;
            assetTransfer.OwnershipType = JOwnershipType.Definitive;
            assetTransfer.Comment = "برگشت انتقال";

            JAssetShare assetShare = new JAssetShare();
            assetShare.ParentCode = oldShares.Code;
            ///
            assetShare.PersonCode = pTransferSheet.FPCode;
            assetShare.Share = pTransferSheet.TranSum;
            assetShare.Status = JStatusType.Active;

            JReturnTransfer returnTransfer = new JReturnTransfer();
            returnTransfer.TransferCode = pTransferSheet.Code;
            ///
            returnTransfer.RDate = db.GetCurrentDateTime();

            JSheetLog sheetLog = new JSheetLog(this.Code, JShareOperations.Transfer, pTransferSheet.Code, db);

            ///2.  Log حذف  
            try
            {
                db.beginTransaction("Transfer");
                //if (!sheetLog.Delete(db))
                //    throw new Exception();

                ///غیر فعال کردن دارایی
                if (!oldAsset.DeActive(db, true, false))
                    throw new Exception();

                if (!pTransferSheet.Delete(db))
                    throw new Exception();

                /// Person Logger
                /// فروش
                JSharePersonLogger logger = new JSharePersonLogger(this.Code, JPersonLoggerTypes.Sell, pTransferSheet.Code, db);
                if (!logger.Delete(db))
                    throw new Exception();
                /// Person Logger
                /// خرید
                JSharePersonLogger loggerBuyer = new JSharePersonLogger(this.Code, JPersonLoggerTypes.Buy, pTransferSheet.Code, db);
                if (!loggerBuyer.Delete(db))
                    throw new Exception();


                ///AssetTransfer ثیت 
                assetTransfer.ObjectCode = returnTransfer.Code;
                assetTransfer.ACode = oldAsset.Code;
                if (!assetTransfer.Insert(db))
                    throw new Exception();

                /// AssetShare ثبت
                assetShare.ACode = oldAsset.Code;
                assetShare.TCode = assetTransfer.Code;
                if (assetShare.Insert(db) <= 0)
                    throw new Exception();

                this.PCode = pTransferSheet.FPCode;
                this.NumPrint = 0;
                if (!this.Update(db))
                    throw new Exception();


				/// Person Logger
				/// برگشت از خریدار
				logger.Az = this.Az;
				logger.Ela = this.Ela;
				logger.Cost = (new JShareCompany(this.CompanyCode)).CurrentShareCost;
				logger.InSum = 0;
				logger.OutSum = this.ShareCount;
				logger.OperationCode = pTransferSheet.Code;
				logger.PCode = pTransferSheet.SPCode;
				logger.PCode2 = pTransferSheet.FPCode;
				logger.SCode = this.Code;
				logger.SheetType = JPersonLoggerTypes.ReturnTransferSheet.GetHashCode();
				logger.TDate = JDateTime.Now();
				if (logger.Insert(db) <= 0)
					throw new Exception();

				/// Person Logger
				/// برگشت از خریدار
				logger.Az = this.Az;
				logger.Ela = this.Ela;
				logger.Cost = (new JShareCompany(this.CompanyCode)).CurrentShareCost;
				logger.InSum = this.ShareCount;
				logger.OutSum = 0;
				logger.OperationCode = pTransferSheet.Code;
				logger.PCode = pTransferSheet.FPCode;
				logger.PCode2 = pTransferSheet.SPCode;
				logger.SCode = this.Code;
				logger.SheetType = JPersonLoggerTypes.ReturnTransferSheet.GetHashCode();
				logger.TDate = JDateTime.Now();
				if (logger.Insert(db) <= 0)
					throw new Exception();

                db.setQuery("delete from [Propperty_ClassName_ManagementShares.JTransferSheetForm_0] where ObjectCode =" + pTransferSheet.Code);
                db.Query_Execute();
				db.Commit();
                return this.Code;
            }
            catch
            {
                db.Rollback("Transfer");
                JMessages.Error("عملیات انتقال سهم با مشکل مواجه شده است.", "Error");
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool JoinSheet(int[] NewShareCounts, DateTime DivideDate, JDataBase pDB)
        {
            return false;
        }
        /// <summary>
        /// تقسیم برگه سهم 
        /// برگه سهم را به تعداد سهم های وارد شده در آرایه تقسیم میکند
        /// </summary>
        /// <param name="NewShareCounts"></param>
        /// <returns></returns>
        public bool DivideSheet(int[] NewShareCounts, DateTime DivideDate, JDataBase pDB, ref List<JShareSheet> ResultSheets)
        {
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else
                db = pDB;

            JAsset oldAsset = new JAsset("ManagementShares.JShareSheet", this.Code, db);
            JAssetTransfer oldTransfer = new JAssetTransfer(oldAsset.Code, JOwnershipType.Definitive, db);
            JAssetShare oldShares = new JAssetShare(oldAsset.Code, oldTransfer.Code, db);
            List<JShareSheet> newSheets = new List<JShareSheet>();
            int counter = this.Az;

            try
            {
                if (pDB == null)
                    db.beginTransaction("Divide");
                ///غیر فعال کردن دارایی
                if (!oldAsset.DeActive(db, true, true))
                    throw new Exception();

                /// Person Logger
                /// ابطال با تقسیم
                JSharePersonLogger logger = new JSharePersonLogger();
                logger.Az = this.Az;
                logger.Ela = this.Ela;
                logger.Cost = (new JShareCompany(this.CompanyCode)).CurrentShareCost;
                logger.InSum = 0;
                logger.OutSum = this.ShareCount;
                ///چون چند رکورد 
                ///Divide
                ///ثبت میشود، 
                ///OperationCode
                ///معنی پیدا نمیکند
                //logger.OperationCode = divide.Code;
                logger.PCode = this.PCode;
                logger.SCode = this.Code;
                logger.SheetType = JPersonLoggerTypes.DeleteByDivide.GetHashCode();
                logger.TDate = DivideDate;
                if (logger.Insert(db) <= 0)
                    throw new Exception();

                foreach (int newShareCount in NewShareCounts)
                {
                    //// ثبت برگه سهمهای جدید
                    JShareSheet sheet = new JShareSheet();
                    sheet.ACode = this.ACode;
                    sheet.Az = counter;
                    sheet.Ela = counter + newShareCount - 1;
                    sheet.ShareCount = sheet.Ela - sheet.Az + 1;
                    sheet.CompanyCode = this.CompanyCode;
                    sheet.CourseCode = this.CourseCode;
                    sheet.PCode = this.PCode;
                    sheet.Status = JSheetStatus.Active.GetHashCode();
                    sheet.NumPrint = 0;
                    sheet.Period = this.Period;
                    sheet.ParentCode = this.Code;
                    newSheets.Add(sheet);
                    counter += newShareCount;
                    /// اطلاعات تقسیم
                    /// به ازای هر برگه جدید یک رکورد درج میشود.
                    JDivideSheet divide = new JDivideSheet();
                    divide.DJDate = DivideDate;
                    divide.IsDivide = true;
                    divide.SCode = this.Code;
                    if (divide.Insert(db) <= 0)
                        throw new Exception();
                    ////
                    int newSheetCode = sheet.Insert(db, oldTransfer.Code, divide.Code, oldShares.Code);
                    if (newSheetCode <= 0)
                        throw new Exception();

                    /////////////// ASSET ////////////
                    ///////////
                    divide.NewCode = newSheetCode;
                    divide.Update(db);
                    ///// Sheet Log
                    //JSheetLog sheetLog = new JSheetLog();
                    //sheetLog.SCode = Code;
                    //sheetLog.NewSCode = sheet.Code;
                    //sheetLog.PCode = sheet.PCode;
                    //sheetLog.NewPCode = sheet.PCode;
                    //sheetLog.Operation = JShareOperations.Divide.GetHashCode();
                    //sheetLog.OperationCode = divide.Code;
                    //if (sheetLog.Insert(db) <= 0)
                    //    throw new Exception();

                    /// PersonLogger
                    /// جدید با تقسیم
                    JSharePersonLogger newLogger = new JSharePersonLogger();
                    newLogger.SCode = sheet.Code;
                    newLogger.Az = sheet.Az;
                    newLogger.Ela = sheet.Ela;
                    newLogger.Cost = (new JShareCompany(sheet.CompanyCode)).CurrentShareCost;
                    newLogger.InSum = sheet.ShareCount;
                    newLogger.OutSum = 0;
                    newLogger.OperationCode = divide.Code;
                    newLogger.PCode = sheet.PCode;
                    newLogger.SheetType = JPersonLoggerTypes.NewByDivide.GetHashCode();
                    newLogger.TDate = divide.DJDate;
                    if (newLogger.Insert(db) <= 0)
                        throw new Exception();
                }
                this.Status = JSheetStatus.Deactive.GetHashCode();
                this.Update(db);
                if (pDB == null)
                    db.Commit();
                ResultSheets = newSheets;
                return true;
            }
            catch
            {
                if (pDB == null)
                    db.Rollback("Divide");
                JMessages.Error("عملیات تقسیم برگه سهم با مشکل مواجه شده است.", "Error");
                return false;
            }
            finally
            {
                if (pDB == null)
                    db.Dispose();
            }
        }

        public int SharePeriodCount()
        {
            return SharePeriodCount(Period);
        }


        public int SharePeriodCount(int pPeriod)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"
                    select MAX(Ela) - MiN(AZ)+1 from shareSheet 
                    where status=1 and companycode=" + CompanyCode.ToString() + " and Period=" + pPeriod.ToString());

                DataTable DT = DB.Query_DataTable();
                if (DT != null)
                    return (int)DT.Rows[0][0];
            }
            finally
            {
                DB.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// یک کپی از برگه میسازد و و آنرا را غیر فعال میکند
        /// ResultShare برگه جدید ایجاد شده و فعال
        /// </summary>
        /// <param name="NewShareCounts"></param>
        /// <param name="DuplicateDate"></param>
        /// <param name="pDB"></param>
        /// <param name="ResultSheet"></param>
        /// <returns></returns>
        public bool DuplicateSheet(DateTime DuplicateDate, JDataBase pDB, ref JShareSheet ResultSheet)
        {
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else
                db = pDB;


            int counter = this.Az;

            try
            {
                if (pDB == null)
                    db.beginTransaction("Duplicate");
                ///غیر فعال کردن برگه سهم 
                this.DeActivateSheet(db);


                //// ثبت برگه سهم جدید
                //JShareSheet newSheet = new JShareSheet();
                JShareSheet sheet = new JShareSheet();
                sheet.ACode = this.ACode;
                sheet.Az = this.Az;
                sheet.Ela = this.Ela;
                sheet.ShareCount = sheet.Ela - sheet.Az + 1;
                sheet.CompanyCode = this.CompanyCode;
                sheet.CourseCode = this.CourseCode;
                sheet.PCode = this.PCode;
                sheet.Status = JSheetStatus.Active.GetHashCode();
                sheet.ParentCode = this.Code;
                sheet.NumPrint = 0;
                ////
                int newSheetCode = sheet.Insert(db, 0, 0, 0);

                ///// Person Logger
                ///// ابطال با فروش 
                JSharePersonLogger logger = new JSharePersonLogger();
                logger.Az = this.Az;
                logger.Ela = this.Ela;
                logger.Cost = (new JShareCompany(this.CompanyCode)).CurrentShareCost;
                logger.InSum = 0;
                logger.OutSum = this.ShareCount;
                ///کد برگه جدید در OperationCode درج میشود
                logger.OperationCode = newSheetCode;
                logger.PCode = this.PCode;
                logger.SCode = this.Code;
                logger.SheetType = JPersonLoggerTypes.Sell.GetHashCode();
                logger.TDate = DuplicateDate;
                if (logger.Insert(db) <= 0)
                    throw new Exception();

                if (pDB == null)
                    db.Commit();
                ResultSheet = sheet;
                return true;
            }
            catch
            {
                if (pDB == null)
                    db.Rollback("Duplicate");
                JMessages.Error("عملیات کپی برگه سهم با مشکل مواجه شده است.", "Error");
                return false;
            }
            finally
            {
                if (pDB == null)
                    db.Dispose();
            }
        }

        /// <summary>
        /// غیر فعال کردن برگه سهم به همراه finAsset ها
        /// </summary>
        /// <param name="DuplicateDate"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public bool DeActivateSheet(JDataBase db)
        {
            try
            {
                JAsset oldAsset = new JAsset("ManagementShares.JShareSheet", this.Code, db);
                JAssetTransfer oldTransfer = new JAssetTransfer(oldAsset.Code, JOwnershipType.Definitive, db);
                JAssetShare oldShares = new JAssetShare(oldAsset.Code, oldTransfer.Code, db);

                if (!oldAsset.DeActive(db, true, true))
                    throw new Exception();
                this.Status = JSheetStatus.Deactive.GetHashCode();
                return this.Update(db);
            }
            catch
            {
                return false;
            }
        }

        public string GetAssetComment(int pCode)
        {
            GetData(pCode);
            ClassLibrary.JAllPerson p = new JAllPerson(this.PCode);
            return "شماره برگه :"+this.Code.ToString() + " از شماره سهم : " +
                this.Az.ToString() + " تا شماره سهم: " +
                this.Ela + " تعداد سهم: " +
                this.ShareCount.ToString() + " به نام: " + 
                p.Name;
        }
    }

    public class JShareSheets :JManagementshares
    {
        public static string Query = @"Select Distinct 
			ShareSheet.Code
			, Az, Ela, ShareCount
			, ShareAgent.PCode AgentCode , A.Name AgentName
                FROM ShareSheet 
                inner Join clsAllPerson P on ShareSheet.PCode = P.Code 
                left Join ShareAgent on  ShareSheet.ACode  = ShareAgent.Code  
                left Join clsAllPerson A on ShareAgent .PCode   = A.Code ";

		public static string QueryOffline = @"select Distinct 
			SahamSheet.Code
			, Az, Ela, ShareCount
			, ShareAgent.PCode AgentCode , A.Name AgentName
                FROM SahamSheet 
                inner Join clsAllPerson P on SahamSheet.PCode = P.Code 
                left Join ShareAgent on  SahamSheet.ACode  = ShareAgent.Code  
                left Join clsAllPerson A on ShareAgent .PCode   = A.Code";

        public static DataTable GetDataTable(int CompanyCode)
        {
            return GetDataTable(CompanyCode, 0);
        }



        public static DataTable GetDataTable(int CompanyCode, int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = JShareReport.SQLSheet + " AND S1.Status = " + JSheetStatus.Active.GetHashCode();
                    //JShareSheets.Query + " WHERE ShareSheet.Status = " + JSheetStatus.Active.GetHashCode();
                if (CompanyCode > 0)
                    sql += " AND S1.CompanyCode = " + CompanyCode;
                if (pCode > 0)
                    sql += " AND S1.Code = " + pCode;
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

		public void ChangePasswords(int CompanyCode)
		{

			ClassLibrary.JPerson P = new JPerson();

			DataTable DT = GetPersonDataTable(CompanyCode);
			Globals.JUser U = new Globals.JUser();


			foreach (DataRow dr in DT.Rows)
			{


				if (P.getData((int)dr["Code"]))
				{
					if (U.GetPersonData(P.Code))
					{
						U.password = P.ShMeli;
						U.Update();
					}
					else
					{
						U.PCode = P.Code;
						U.username = Int64.Parse(dr["SharePCode"].ToString()).ToString();
						U.password = P.ShMeli;
						U.insert();
					}
				}
			}
		}

        public static  DataTable GetDeActiveDataTable(int CompanyCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = @"Select ShareSheet.Code, Az, Ela, ShareCount,ShareSheet.PCode, P.Name, ShareAgent.PCode AgentCode
                 , A.Name AgentName
                   ,N'غیر فعال' as Status
                FROM ShareSheet 
                inner Join clsAllPerson P on ShareSheet.PCode = P.Code 
                left Join ShareAgent on  ShareSheet.ACode  = ShareAgent.Code  
                left Join clsAllPerson A on ShareAgent .PCode   = A.Code   ";

                string sql = Query + " WHERE ShareSheet.Status <> " + JSheetStatus.Active.GetHashCode();
                if (CompanyCode > 0)
                    sql += " AND ShareSheet.CompanyCode = " + CompanyCode;
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetDeactiveSheetsWebQuery(int CompanyCode)
        {
            string Query = @"Select ShareSheet.Code, Az, Ela, ShareCount,ShareSheet.PCode, P.Name, ShareAgent.PCode AgentCode
                 , A.Name AgentName
                   ,N'غیر فعال' as Status
                FROM ShareSheet 
                inner Join clsAllPerson P on ShareSheet.PCode = P.Code 
                left Join ShareAgent on  ShareSheet.ACode  = ShareAgent.Code  
                left Join clsAllPerson A on ShareAgent .PCode   = A.Code   ";

            string sql = Query + " WHERE ShareSheet.Status <> " + JSheetStatus.Active.GetHashCode();
            if (CompanyCode > 0)
                sql += " AND ShareSheet.CompanyCode = " + CompanyCode;
            return Query;
        }

        public static bool AddPrintCount(DataTable sheets)
        {
            string sCodes = "";
            int i=0;
            foreach (DataRow row in sheets.Rows)
            {
                i++;
                sCodes = sCodes + row["SCode"].ToString();
                if (i < sheets.Rows.Count)
                    sCodes += ",";
            }
            string Query = " UPDATE ShareSheet SET NumPrint = NumPrint +1 WHERE Code IN ("+sCodes+")";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_Execute() >= 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetPersonDataTable(int companyCode)
        {
            JDataBase db = new JDataBase();
            try
            {

               string sql =string.Format(@"
              Select P.*,
                  --(select top 1  SharePCode   from SharePCodeSheet where PersonCode = p.code and CompanyCode = {0}) as SharePCode,
                  --(Select Name From subdefine where Code=P.Sader) Sader, P.HomeAddress ,P.WorkAddress ,
                  (Select ISNULL(Sum(ShareCount),0) From ShareSheet Where CompanyCode = {0} AND Status=1 and PCode = P.Code ) ShareCount,
                  (Select COUNT(ShareSheet.Code) from ShareSheet Where  CompanyCode = {0} AND Status=1 And PCode = P.Code ) SheetCount,
                  (select top 1 (select (select SharePCode from SharePCodeSheet where PersonCode=PCode and CompanyCode="+ companyCode.ToString() + @") from ShareAgent where Code=ACode) ACode from ShareSheet where PCode=P.Code And Status=1 and CompanyCode=" + companyCode.ToString() + @") ACode,
                  (select top 1 (select (Select NAme From clsAllPerson where Code=PCode) from ShareAgent where Code=ACode) ACode from ShareSheet where PCode=P.Code And Status=1 and CompanyCode=" + companyCode.ToString() + @") AgentName

                  FROM PersonAddressViewSharePCode P
                    Where 
Code IN (Select PCode From ShareSheet Where CompanyCode = {0}) and CompanyCode = {1}", companyCode,companyCode);
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetPersonWebQuery(int companyCode) 
        {
             //(select top 1  SharePCode   from SharePCodeSheet where PersonCode = p.code and CompanyCode = {0}) as SharePCode2,
            return string.Format(@"
              Select P.*,
                  (Select Name From subdefine where Code=P.Sader) Sader2, P.HomeAddress HomeAddress2 ,P.WorkAddress WorkAddress2 ,
                  (Select ISNULL(Sum(ShareCount),0) From ShareSheet Where CompanyCode = {0} AND Status=1 and PCode = P.Code ) ShareCount,
                  (Select COUNT(ShareSheet.Code) from ShareSheet Where  CompanyCode = {0} AND Status=1 And PCode = P.Code ) SheetCount,
                  (select top 1 (select (select SharePCode from clsAllPerson where code=PCode) from ShareAgent where Code=ACode) ACode from ShareSheet where PCode=P.Code And Status=1) ACode,
                  (select top 1 (select (Select NAme From clsAllPerson where Code=PCode) from ShareAgent where Code=ACode) ACode from ShareSheet where PCode=P.Code And Status=1) AgentName

                  FROM PersonAddressViewSharePCode P
                    Where 
Code IN (Select PCode From ShareSheet Where CompanyCode = {0}) and CompanyCode = {1}", companyCode, companyCode);
        }

        public void ListView(int CompanyCode)
        {

            JToolbarNode Tn1 = new JToolbarNode();
            Tn1.Click = new JAction("SharePrice", "ManagementShares.JSharePrice.ShowForm", new object[] { CompanyCode }, null);
            Tn1.Icon = JImageIndex.Settings;
            Nodes.AddToolbar(Tn1);
            Nodes.GlobalMenuActions.Insert(new JAction("SharePrice...", "ManagementShares.JSharePrice.ShowForm", new object[] { CompanyCode }, null));

			JToolbarNode Tn2 = new JToolbarNode();
			Tn2.Click = new JAction("PasswordChange", "ManagementShares.JShareSheets.ChangePasswords", new object[] { CompanyCode }, null);
			Tn2.Icon = JImageIndex.Changepassword;
			Nodes.AddToolbar(Tn2);
			Nodes.GlobalMenuActions.Insert(new JAction("PasswordChange...", "ManagementShares.JShareSheets.ChangePasswords", new object[] { CompanyCode }, null));


			JRowStyle RSOrange = new JRowStyle();
			RSOrange.Expression = "ShareACount>9900";
			RSOrange.JanusRowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
			RSOrange.JanusRowStyle.BackColor = System.Drawing.Color.Orange;

			JRowStyle RS = new JRowStyle();
			RS.Expression = "ShareACount>10000";
			RS.JanusRowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
			RS.JanusRowStyle.BackColor = System.Drawing.Color.Red;

			JRowStyle RSDistrainted = new JRowStyle();
			RSDistrainted.Expression = "Distrainted=true";
			RSDistrainted.JanusRowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
			RSDistrainted.JanusRowStyle.BackColor = System.Drawing.Color.Gray;


			Nodes.RowStyles.Add(RSOrange);
			Nodes.RowStyles.Add(RS);
			Nodes.RowStyles.Add(RSDistrainted);

			Nodes.ObjectBase = new JAction("JShareCompany", "ManagementShares.JShareSheet.GetNode");
			Nodes.DataTable = GetDataTable(CompanyCode);
		}

        public static DataTable GetSimpleSheet(int pPCode, int pCompanyCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = string.Format(@"
select Code,Az,Ela,ShareCount from sharesheet where 
status=1 and companycode={0} and pcode={1}", pCompanyCode, pPCode);
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }

        }

        public void DeActiveListView(int CompanyCode)
        {
           // Nodes.ObjectBase = new JAction("JShareCompany", "ManagementShares.JShareSheet.GetDeActiveNode");
            Nodes.DataTable = GetDeActiveDataTable(CompanyCode);
        }

        public void PersonListView(int CompanyCode)
        {
            Nodes.ObjectBase = new JAction("JShareCompany", "ManagementShares.JShareSheet.GetPersonNode");
            Nodes.DataTable = GetPersonDataTable(CompanyCode);
        }

        public void PrintShareSheet(DataTable SheetsToPrint)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //string sql = JShareReport.SQL + " AND ShareSheet.Code="+SheetsToPrint.Rows[0]["SCode"].ToString();
                //DB.setQuery(sql);
                DataTable printTable = SheetsToPrint;// DB.Query_DataTable();

                if (printTable.Rows.Count == 0)
                {
                    JMessages.Error("هیچ رکوردی انتخاب نشده است.", "error");
                    return;
                }
                if (JShareSheets.AddPrintCount(printTable))
                {
                    JDynamicReportForm reportForm = new JDynamicReportForm(JReportDesignCodes.Sheet.GetHashCode());
                    reportForm.Add(SheetsToPrint);
                    reportForm.ShowDialog();
                }
                else
                {
                    JMessages.Error("عملیات چاپ برگه سهم با مشکل مواجه شده است.", "خطا");
                }
            }
            catch
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// برگه سهم های شخص را برمیگرداند
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonSheet(int PCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(JShareSheets.Query + " WHERE  ShareSheet.PCode = " + PCode + " AND ShareSheet.Status = " + JSheetStatus.Active.GetHashCode());
                DataTable sheets = db.Query_DataTable();
                return sheets;
            }
            finally
            {
                db.DisConnect();
            }
        }



		/// <summary>
		///  برگه سهم های شخص را برمیگرداند در دوره آفلاین
		/// </summary>
		/// <param name="PCode"></param>
		/// <returns></returns>
		public static DataTable GetPersonSheetOffline(int PCode, int pCourseCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("   SELECT ss.* ,cp.Name,cp.Fam,cp.FatherName,cp.FatherName,cp.shsh,cp.ShMeli,sps.SharePCode  From SahamSheet ss  inner join clsPerson cp on cp.Code=ss.PCode  inner join SharePCodeSheet sps on sps.PersonCode=cp.Code  " + " WHERE  ss.PCode = " + PCode + " AND ss.Status = " + JSheetStatus.Active.GetHashCode() + " and CourseCode=" + pCourseCode.ToString() + " and sps.CompanyCode=ss.CompanyCode ");
				DataTable sheets = db.Query_DataTable();
				return sheets;
			}
			finally
			{
				db.DisConnect();
			}
		}


        /// <summary>
        /// تعداد سهم شخص را برمیگرداند
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static int GetSumPersonSheet(int PCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"Select ISNULL(SUM(ShareCount), 0) ShareCount
                FROM ShareSheet  WHERE  ShareSheet.PCode = " + PCode + " AND ShareSheet.CompanyCode = 1 AND ShareSheet.Status = " + JSheetStatus.Active.GetHashCode());
                DataTable sheets = db.Query_DataTable();
                return Convert.ToInt32(sheets.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.DisConnect();
            }
        }



		


    }
}
