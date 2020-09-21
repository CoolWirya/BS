using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JSCStorage : JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// نوع: سالن/سکو/محوطه
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// تعداد باکس
        /// </summary>
        public int BoxCount { get; set; }
        /// <summary>
        /// متراژ هر باکس
        /// </summary>
        public int BoxMeter { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion
        public JSCStorage()
        {
        }
        public JSCStorage(int pCode)
        {
            this.GetData(pCode);
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "StoreComplex.JSCStorage");
            Nodes.hidColumns = "";

            /// اکشن جدید
            JAction newAction = new JAction("New...", "StoreComplex.JSCStorage.ShowDialog", new object[] { 0 }, null);
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "StoreComplex.JSCStorage.ShowDialog", new object[] { node.Code }, null);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;

            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "StoreComplex.JSCStorage.Delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);
            return node;
        }
        public int Insert()
        {
            JSCStorageTable table = new JSCStorageTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCStorage.Insert"))
                {

                    table.SetValueProperty(this);
                    int Code = table.Insert();
                    if (Code > 0)
                    {
                        Histroy.Save(this, table, table.Code, "Insert");
                        Nodes.DataTable.Merge(JSCStorages.GetDatatable(Code));
                        return Code;
                    }
                    else
                        return 0;
                }
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
                table.Dispose();
            }
        }

        public bool Delete()
        {
            JSCStorageTable table = new JSCStorageTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCStorage.Delete"))
                {
                    table.SetValueProperty(this);
                    if (table.Delete())
                    {
                        Histroy.Save(this, table, table.Code, "Delete");
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                        return false;
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
                table.Dispose();
            }

        }

        public bool Update()
        {

            JSCStorageTable table = new JSCStorageTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCStorage.Update"))
                {
                    table.SetValueProperty(this);
                    if (table.Update())
                    {
                        Histroy.Save(this, table, table.Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JSCStorages.GetDatatable(Code).Rows[0]);
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
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                table.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM SCStorage WHERE Code=" + pCode.ToString());
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

        public void ShowDialog(int StorageCode)
        {
            JStorageForm form = new JStorageForm(StorageCode);
            form.ShowDialog();
        }
    
    }

    public class JSCStorages : JSystem
    {
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("NewNode", "StoreComplex.JSCStorage.GetNode");
            Nodes.DataTable = GetDatatable(0);

            //اکشن جدید
            JAction newaction = new JAction("new...", "StoreComplex.JSCStorage.ShowDialog", new object[] { 0 },null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }

        public static DataTable GetDatatable(int pCode)
        {
            string SelectQouery = @" SELECT  * FROM SCStorage ";
            string where = " Where 1=1 ";
            if (pCode > 0)
                where = where + " And Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery + where);
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
