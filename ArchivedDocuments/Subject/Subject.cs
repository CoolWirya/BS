using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JSubjectTree: JCustomTree
    {
        public JSubjectTree()
            : base("ArchivedSubject","Code","Name","ParentCode")
        {
        }

        public void Show()
        {
            JSubjectForm SF = new JSubjectForm();
            SF.ShowDialog();
        }
        public System.Data.DataTable GetSubjectList(int pCode)        
        {
            JDataBase db = new JDataBase();
            try
            {
                string Where = "";
                if (pCode > 0) Where = " Where Code=" + pCode.ToString();
                db.setQuery("select code , Name as 'name' , AccessCode FROM ArchivedSubject" + Where);//+ '_' + cast(AccessCode as nvarchar(20))
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }
        /// <summary>
        /// کد دسترسی سریع را برمیگرداند
        /// </summary>
        /// <param name="pCode">کد</param>
        /// <returns>int</returns>
        public int GetAccessCode(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select ISNULL(max(AccessCode),-1) FROM ArchivedSubject where code = " + pCode);
                return Convert.ToInt32(db.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return -1;
        }

        public System.Data.DataTable GetSubjectList()
        {
            try
            {
                return GetSubjectList(0);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
        }
        public void ShowForm()
        {
            JSubjectForm p = new JSubjectForm();
            p.ShowDialog();
        }

        public JNode[] TreeView(int pCode)
        {
            JCustomTreeNode[] Childs = GetChilds(pCode);
            JNode[] _Nodes = new JNode[Childs.Length];
            int count = 0;
            foreach (JCustomTreeNode Child in Childs)
            {
                _Nodes[count] = new JNode(Child.Code, Child.GetType().FullName);
                _Nodes[count].Name = (string)Child.FieldsValue["Name"];
                _Nodes[count].ChildsAction = new JAction((string)Child.FieldsValue["Name"], "ArchivedDocuments.JPlacesTree.TreeView", new object[] { Child.Code }, null);
                JAction Click = new JAction(_Nodes[count].Name, "ArchivedDocuments.JArchiveDocuments.ListView", new object[] { 0, Child.Code }, null);
                _Nodes[count].MouseClickAction = Click;
                count++;
            }
            return _Nodes;
        }

    }
}
