using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JPlacesTree : JCustomTree
    {
        public JPlacesTree()
            : base("ArchivePlaces","Code","Name","ParentCode")
        {
        }
        public void Show()
        {
            JPlacesForm form = new JPlacesForm();
            form.ShowDialog();
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
                JAction Click = new JAction(_Nodes[count].Name, "ArchivedDocuments.JArchiveDocuments.ListView", new object[] { Child.Code, 0 }, null);
                _Nodes[count].MouseClickAction = Click;
                count++;
            }
            return _Nodes;
        }


    }

    public class JPlaceTrees : JSystem
    {
    }
}
