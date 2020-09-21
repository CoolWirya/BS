using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JArchivedDocuments: JSystem
    {
        public void ListView()
        {

            //JNode Node = new JNode(0, "ArchivedDocuments.JArchivedDocuments");
            //Node.Name = "ArchiveSubject";
            //Node.MouseDBClickAction = DBAction;
            Nodes.Insert(JAStaticNode._ArchiveSubjectNode());

            //JNode PlacesNode = new JNode(0, "ArchivedDocuments.JArchivedDocuments");
            //PlacesNode.Name = "ArchivePlaces";
            //PlacesNode.MouseDBClickAction = ActionPlacesShow;
            Nodes.Insert(JAStaticNode._ArchivePlaceNode());
            Nodes.Insert(JAStaticNode._RequestArchiveFile());
            //Nodes.Insert(JAStaticNode._BaseDefinesNode());
        }

        public JNode[] TreeView()
        {
            JNode[] T = new JNode[4];
            T[0] = JAStaticNode._ArchivePlaceNode();
            T[1] = JAStaticNode._ArchiveSubjectNode();
            T[2] = JAStaticNode._ArchiveDocuments();
            T[3] = JAStaticNode._RequestArchiveFile();            
            return T;
        }
    }
}
