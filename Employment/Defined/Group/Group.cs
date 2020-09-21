using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employment.Defined.Group
{
    class JGroup
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public JGroup()
        {
        }

        public int Insert()
        {
            return 0;
        }

        public bool Update()
        {
            return false;
        }

        public bool Delete()
        {
            return false;
        }

        public bool GetDate(int pCode)
        {
            return false;
        }

        public System.Data.DataTable GetGroupPosts()
        {
            return null;
        }

        public int InsertGroupPosts()
        {
            return 0;
        }

        public bool DeleteGroupPosts()
        {
            return false;
        }

        public ClassLibrary.JNode GetNode(System.Data.DataRow pDR)
        {
            return null;
        }


    }

    public class JGroups
    {
        public void ListView()
        {
        }

        public ClassLibrary.JNode[] TreeView()
        {
            return null;
        }
    }
}
