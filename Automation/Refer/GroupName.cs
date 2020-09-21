using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Refer
{
    public class JGroupName
    {
        public int Code { get; set; }
        public int PostCode { get; set; }
        public string GroupName { get; set; }
        public int PostCodeGuest { get; set; }
        public int Insert()
        {
            JGroupNameTable GNT = new JGroupNameTable();
            GNT.SetValueProperty(this);
            return GNT.Insert();
        }

        public bool Delete()
        {
            JGroupNameTable GNT = new JGroupNameTable();
            GNT.SetValueProperty(this);
            return GNT.Delete();
        }

        public bool Update()
        {
            JGroupNameTable GNT = new JGroupNameTable();
            GNT.SetValueProperty(this);
            return GNT.Update();
        }

        public static void DeleteByGroupName(int pPostCode,string pGroupName)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("delete from refGroupname where postCode="+pPostCode+" and Groupname=N'"+pGroupName+"'");
                DB.Query_Execute();
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
