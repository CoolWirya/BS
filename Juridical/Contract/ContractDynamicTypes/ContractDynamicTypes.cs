using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Legal
{
    public class JContractDynamicType : JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// نوع ثبت اموال: انتقال / اجاره / مشارکت / ... ا
        /// </summary>
        public int AssetTransferType { get; set; }
        /// <summary>
        /// انتقال دارایی صورت گیرد یا خیر
        /// </summary>
        public bool TransferAsst { get; set; }
        /// <summary>
        /// فرمهای قابل نمایش در قرارداد
        /// </summary>
        public JContractFormsOrders ContractForms = new JContractFormsOrders();
        /// <summary>
        /// تنظیمات فرمها
        /// </summary>
        public JContractTypeSettings ContractSettings = new JContractTypeSettings();
        /// <summary>
        /// نام کلاس برای ویژگی ها
        /// </summary>
        public string PrtClassName { get; set; }
        /// <summary>
        /// کد شی برای ویژگی ها
        /// </summary>
        public int PrtObjectCode { get; set; }
        /// <summary>
        /// مبلغ کل قرارداد
        /// </summary>
        public decimal AllPrice { get; set; }
        /// <summary>
        /// درصد نقدی
        /// </summary>
        public int  RealPercent{ get; set; }
        /// <summary>
        /// درصد اقساط
        /// </summary>
        public int  InstallmentPercent{ get; set; }
        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int  InstallmentCount{ get; set; }
        /// <summary>
        /// مبلغ پایانی
        /// </summary>
        public int  EndPricePercent{ get; set; }

        #endregion Properties

        #region Constructor
        public JContractDynamicType()
        {
        }

        public JContractDynamicType(int pCode)
        {
            GetData(pCode);
        }
        #endregion Constructor

        #region Methods Insert,Update,delete,GetData

        public static string Query = @" SELECT 
        Code,Title,ClassName,AssetTransferType,TransferAsst,PrtClassName,PrtObjectCode , [AllPrice]
      ,[RealPercent],[InstallmentPercent],[InstallmentCount],[EndPricePercent] FROM " + JTableNamesContracts.ContractDynamicType;

        public bool GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(JContractDynamicType.Query + " WHERE Code = " + pCode.ToString());
                if (db.Query_DataReader())
                {
                    if (db.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, db.DataReader);
                        db.DataReader.Close();
                        /// بازخوانی تنظیمات
                        ContractSettings.LoadAll(pCode);
                        /// بازخوانی فرمها
                        
                        return true;
                    }
                    else return false;
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
                db.Dispose();
            }
        }

        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                JContractDynamicTypeTable table = new JContractDynamicTypeTable();
                table.SetValueProperty(this);
                db.beginTransaction("InsertFormsOrder");
                Code = table.Insert(db);
                if (Code > 0)
                {
                    this.ContractForms.InsertAll(db, Code);
                    this.ContractSettings.InsertAll(db, Code);
                    if (db.Commit())
                    {
                        Nodes.DataTable.Merge(JContractDynamicTypes.GetDataTable(Code));
                        Histroy.Save(this, table, table.Code, "Insert");
                    }
                    else
                    {
                        db.Rollback("InsertFormsOrder");
                        return 0;
                    }
                }
                return Code;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("InsertFormsOrder");
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JContractDynamicTypeTable table = new JContractDynamicTypeTable();
            table.SetValueProperty(this);
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.beginTransaction("UpdateFormsOrder");
                this.ContractForms.UpdateAll(db, Code);
                this.ContractSettings.UpdateAll(db, Code);
                if (table.Update())
                {
                    if (db.Commit())
                    {
                        Histroy.Save(this, table, table.Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, (JContractDynamicTypes.GetDataTable(this.Code)).Rows[0]);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("UpdateFormsOrder");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("", 0, JMainFrame.CurrentPostCode, true))
                return false;
            JContractDynamicTypeTable table = new JContractDynamicTypeTable();
            table.SetValueProperty(this);

            if (JMessages.Question("Do you want delete this Item?", "Question") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase db = JGlobal.MainFrame.GetDBO();
                try
                {
                    db.beginTransaction("DeleteFormsOrder");
                    if (this.ContractForms.DeleteAll(db, this.Code))
                        if (this.ContractSettings.DeleteAll(db, this.Code))
                        if (table.Delete(db))
                        {
                            if (db.Commit())
                            {
                                Nodes.Delete(Nodes.CurrentNode);
                                Histroy.Save(this, table, table.Code, "Delete");
                                return true;
                            }
                        }
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    db.Rollback("DeleteFormsOrder");
                    return false;
                }
                finally
                {
                    db.Dispose();
                }
            }
            return false;
        }

        #endregion Methods

        #region ShowData
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                if (!JPermission.CheckPermission("", 0, JMainFrame.CurrentPostCode, true))
                    return;
                JContractDynamicTypeForm PE = new JContractDynamicTypeForm();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JContractDynamicTypeForm PE = new JContractDynamicTypeForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Legal.JContractDynamicType");
            Node.Icone = JImageIndex.ContractType.GetHashCode();
            Node.Name = pRow["Title"].ToString();
            Node.Hint = pRow["Title"].ToString();
            Nodes.hidColumns = "AssetTransferType,TransferAsst,PrtClassName,PrtObjectCode,ClassName";
            //اکشن جدید
            JAction NewAction = new JAction("new...", "Legal.JContractDynamicType.ShowDialog", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Legal.JContractDynamicType.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "Legal.JContractDynamicType.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;
            //قرارداد جدید
            JAction newContract = new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { Node.Code });

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);
            Node.Popup.Insert("-");
            Node.Popup.Insert(newContract);

            return Node;
        }
        #endregion ShowData
    }

    public class JContractDynamicTypes : JSystem
    {
        /// <summary>
        /// همه انواع قرارداد را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = JContractDynamicType.Query;
                Query = Query + " WHERE " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "legContractDynamicTypes.Code");
                if (pCode != 0)
                    Query = Query + " AND Code = " + pCode.ToString();
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


        public static DataTable GetDataTable(Finance.JOwnershipType pOwnershipType)
        {
            return GetDataTable(pOwnershipType, 0);
        }

        public static DataTable GetDataTable(Finance.JOwnershipType pOwnershipType, int pFinanceCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = JContractDynamicType.Query;
                Query = Query + " WHERE " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "legContractDynamicTypes.Code");
                if (pOwnershipType != 0)
                    Query += " AND AssetTransferType = " + pOwnershipType.GetHashCode().ToString();
                if (pFinanceCode > 0)
                    Query += " AND Code IN (SELECT DynamicCode From legContractTypeGroup WHERE FinanceGroup = " + pFinanceCode.ToString() + ")";
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

        public void ListView()
        {
            ListView(0);
        }

        public void ListView(Finance.JOwnershipType pOwnershipType)
        {
            Nodes.ObjectBase = new JAction("NewNode", "Legal.JContractDynamicType.GetNode");
            Nodes.DataTable = GetDataTable(pOwnershipType);
            
            //اکشن جدید
            JAction newaction = new JAction("new...", "Legal.JContractDynamicType.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);            
        }
    }
}