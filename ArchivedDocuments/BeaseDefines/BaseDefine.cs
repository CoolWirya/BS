using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    class JABaseDefine : JBaseDefine
    {
        #region View
        public void ListView()
        {

            Nodes.AddColumn("Name");
            Nodes.Insert(GetNode(FileType));

        }

        public JNode[] TreeView()
        {

            JNode[] N = new JNode[1];
            N[0] = GetNode(FileType);

            return N;
        }
        #endregion View

    }

}
