using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Communication
{
    public class JPatternFile:JSystem
    {
        #region Properties
        public int Code { get; set; }
        public string Name { get; set; }
        public int  Type { get; set; }
        public string Pattern  { get; set; }
        public int User_Code { get; set; }

        public JPatternFile()
            : this(0)
        {
        }
        public JPatternFile(int pCode)
        {
            if (pCode > 0)
                GetData(pCode);
        }
        public static string PatternQuery = " SELECT * FROM patternfile ";
        #endregion Properties

        #region Functions
        /// <summary>
        /// درج
        /// </summary>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public int Insert()
        {
            JPatternFileTable table = new JPatternFileTable();
            table.SetValueProperty(this);
            Code = table.Insert();
            Nodes.DataTable.Merge(JPatternFiles.GetDataTable(Code));
            return Code;

        }
        /// <summary>
        /// ویراش
        /// </summary>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public bool Update()
        {
            JPatternFileTable table = new JPatternFileTable();
            table.SetValueProperty(this);
            if (table.Update())
            {
                Nodes.Refreshdata(Nodes.CurrentNode, JPatternFiles.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// حذف
        /// </summary>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public bool Delete()
        {
            if (JMessages.Question("آیا میخواهید الگوی انتخاب شده حذف شود؟", "حذف الگو") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    JPatternFileTable table = new JPatternFileTable();
                    table.SetValueProperty(this);
                    DB.beginTransaction("DelPattern");
                    if (table.Delete(DB))
                    {
                        
                        OfficeWord.JOfficeWord Office = new OfficeWord.JOfficeWord();
                        Office.GetData("Communication.JPatternFile", this.Code, DB);
                        if (Office.Delete(DB))
                        {
                            try
                            {
                                DB.Commit();
                            }
                            catch
                            {
                                DB.Rollback("DelPattern");
                                return false;
                            }
                            Nodes.Delete(Nodes.CurrentNode);
                            return true;
                        }
                        else return false;
                    }
                }
                finally
                {
                    DB.Dispose();
                }
            }
            return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB;
            DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(" SELECT *  FROM patternfile WHERE Code=" + pCode.ToString());
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
/// 
/// </summary>
/// <param name="pRow"></param>
/// <returns></returns>
        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "Communication.JPatternFile");
            //node.Icone = JImageIndex.p.GetHashCode();
            node.Name = pRow["Name"].ToString();
            node.Hint = JLanguages._Text("Name:") ;

            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Communication.JPatternFile.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete", "Communication.JPatternFile.Delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Communication.JPatternFile.ShowDialog", null, new object[] { 0 });

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);
            Nodes.hidColumns = "type,pattern,user_code";
            return node;
        }
        /// <summary>
        /// نمایش فرم
        /// </summary>
        public void ShowDialog()
        {
            if (this.Code > 0)
                if (!JPermission.CheckPermission("Communication.JPatternFile.Update"))
                    return;
            if (this.Code == 0)
                if (!JPermission.CheckPermission("Communication.JPatternFile.Insert"))
                    return;
            JPatternForm form = new JPatternForm(this.Code);
            form.ShowDialog();
        }

        #endregion Functions
    }

    public class JPatternFiles : JSystem
    {
        public DataTable GetDataTable()
        {
            //if (JPermission.CheckPermission("Communication.JPatternFiles.GetDataTable"))
                return GetDataTable(0);
            //else
              //  return null;
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
                string WHERE = " ";
                if (pCode != 0)
                    WHERE = " WHERE " + "Code = " + pCode;
                DB.setQuery(JPatternFile.PatternQuery + WHERE);
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
            Nodes.ObjectBase = new JAction("GetPerson", "Communication.JPatternFile.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Communication.JPatternFile.ShowDialog", null, new object[] { 0 });
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }
        public JNode[] TreeView()
        {
            return null;
        }
    }
}
