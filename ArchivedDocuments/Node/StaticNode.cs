using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JAStaticNode : JStaticNode
    {

        #region BaseDefine
        public JAStaticNode()
        {
        }


        public static JNode _BaseDefinesNode()
        {
            JNode Node = new JNode(0, "ArchivedDocuments.JABaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "ArchivedDocuments.JABaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "ArchivedDocuments.JABaseDefine.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }
        public static JNode _BaseDefineNode(JBaseDefine pBaseDefine)
        {
            JNode Node = new JNode(pBaseDefine.Code, "ArchivedDocuments.JABaseDefine");
            Node.Name = pBaseDefine.Name;

            JAction EditAction = new JAction("Edit...", "ArchivedDocuments.JABaseDefine.UpdateForm", new object[] { pBaseDefine.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "ArchivedDocuments.JABaseDefine.Delete", new object[] { pBaseDefine.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "ArchivedDocuments.JABaseDefine.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }

        public static JNode _ArchiveSubjectNode()
        {
            JAction DBAction = new JAction("ArchivedSubject", "ArchivedDocuments.JSubjectTree.Show", null, null);
            JNode Node = new JNode(0, "ArchivedDocuments.JArchivedDocuments");
            Node.Name = "ArchiveSubject";
            Node.MouseDBClickAction = DBAction;
            Node.MouseClickAction = DBAction;
            return Node;
        }
        public static JNode _ArchivePlaceNode()
        {
            JAction ActionPlacesShow = new JAction("ArchivePlaces", "ArchivedDocuments.JPlacesTree.Show", null, null);
            JNode PlacesNode = new JNode(0, "ArchivedDocuments.JArchivedDocuments");
            PlacesNode.Name = "ArchivePlaces";
            PlacesNode.MouseDBClickAction = ActionPlacesShow;
            PlacesNode.MouseClickAction = ActionPlacesShow;
            return PlacesNode;
        }

        public static JNode _RequestArchiveFile()
        {
            JNode Node = new JNode(0, "ArchivedDocuments.JRequestArchiveFile");
            Node.Name = "RequestArchiveFile";
            Node.Hint = "RequestArchiveFile";
            JAction Ac = new JAction("RequestArchiveFile", "ArchivedDocuments.JRequestArchiveFiles.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _ArchiveDocuments()
        {
            JAction ActionArchiveDocuments = new JAction("ArchivePlaces", "ArchivedDocuments.JArchiveDocuments.ListView", null, null);
            JNode ArchiveDocuments = new JNode(0, "ArchivedDocuments.JArchivedDocuments");
            ArchiveDocuments.Name = "ArchiveDocuments";
            ArchiveDocuments.MouseDBClickAction = ActionArchiveDocuments;
            ArchiveDocuments.MouseClickAction = ActionArchiveDocuments;
            ArchiveDocuments.ChildsAction = new JAction("", "ArchivedDocuments.JAStaticNode._ArchiveDocumentssub");
            return ArchiveDocuments;
        }

        public JNode[] _ArchiveDocumentssub()
        {
            JNode[] _Node = new JNode[2];

            _Node[0] = new JNode(0, "ArchivedDocuments.JPlacesTree");
            _Node[0].Name = "ArchivePlaces";
            _Node[0].ChildsAction = new JAction("", "ArchivedDocuments.JPlacesTree.TreeView", new object[] { 0 }, null);

            _Node[1] = new JNode(0, "ArchivedDocuments.JSubjectTree");
            _Node[1].Name = "ArchiveSubject";
            _Node[1].ChildsAction = new JAction("", "ArchivedDocuments.JSubjectTree.TreeView", new object[] { 0 }, null);
            
            return _Node;
        }

        #endregion BaseDefine
    }


}
