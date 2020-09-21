using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace WebClassLibrary
{
    public class JApplicationsManager
    {
        public static DataTable GetDataTable(bool ordered = true, bool show = true)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From WebApplications " + (show == true ? "Where show = 1 " : "") + " " + (ordered == true ? "Order by Ordered asc" : ""));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static List<JNode> GetApplicationsNodes()
        {
            List<JNode> jNode = new List<JNode>();
            DataTable dt = GetDataTable();
            if (dt == null) return null;
            foreach (DataRow item in dt.Rows)
            {
                if (!ClassLibrary.JPermission.CheckPermission("WebClassLibrary.JApplicationsManager", (int)item["Code"])) continue;
                JNode node = new JNode();
                node.Name = item["Name"].ToString();
                node.ClassName = "WebClassLibrary.JApplicationsManager";
                node.ObjectCode = (int)item["Code"];
                ClassLibrary.JAction action = new JAction("", item["ClassName"].ToString() + ".GetNodes", null, null);
                object RetObject = action.run();
                if (RetObject != null && RetObject is List<JNode>)
                {
                    try
                    {
                        node._Childs = new List<JNode>((List<JNode>)action.run());

                    }
                    catch
                    {

                    }
                    
                }
                jNode.Add(node);
            }
            return jNode;
        }
    }
}
