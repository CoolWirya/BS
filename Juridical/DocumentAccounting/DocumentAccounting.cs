using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal.DocumentAccounting
{
    public class JDocumentAccounting
    {

        public JDocumentAccounting()
        {

        }

        public void GetDocument(string pClassName, int pObjectCode)
        {
            JDocumentType document = new JDocumentType();
            document.ClassName = pClassName;
            JDocumentContract doc = new JDocumentContract();
            doc.ObjectCode = pObjectCode;
            doc.ClassName = pClassName;
            doc = document.EditItem(doc, "JDocumentContract" + 1);
            if (doc != null)
            {
            }
        }
        public JNode GetNode(System.Data.DataRow pDR)
        {
            JNode N = new JNode(0, "");
            N.MouseDBClickAction = new JAction("Edit...", "Legal.DocumentAccounting.JDocumentAccounting.GetDocument", new object[] { pDR["ClassName"].ToString(),int.Parse(pDR["ObjectCode"].ToString()) }, null);
            return N;
        }
    }

    public class JDocumentAccountings
    {

        public System.Data.DataTable GetDataTable(int pCode)
        {
            return JDocumentsContract.GetAllData(pCode);
        }
        public void ListView()
        {
            ClassLibrary.JSystem.Nodes.ObjectBase = new JAction("DocumentAccountings", "Legal.DocumentAccounting.JDocumentAccounting.GetNode");
            ClassLibrary.JSystem.Nodes.DataTable = GetDataTable(-1);
        }
    }
}
