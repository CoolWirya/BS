using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public class JReferOrderUser
    {
        public int Code { get; set; }
        public int PostCode { get; set; }
        public int PostCodeUser { get; set; }
        public int Ordered { get; set; }

        public int Insert()
        {
            JReferOrderUserTable RT = new JReferOrderUserTable();
            RT.SetValueProperty(this);
            return RT.Insert();
        }

        public bool Update()
        {
            JReferOrderUserTable RT = new JReferOrderUserTable();
            RT.SetValueProperty(this);
            return RT.Update();
        }

        public bool Delete()
        {
            JReferOrderUserTable RT = new JReferOrderUserTable();
            RT.SetValueProperty(this);
            return RT.Delete();
        }

        public bool Find(int pCode,bool pSetDate = false)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from ReferOrderUsers  where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode + " and PostCodeUser=" + pCode);
                System.Data.DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count == 1)
                {
                    if (pSetDate)
                        ClassLibrary.JTable.SetToClassProperty(this, DT.Rows[0]);
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool OrderUP(int pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("update ReferOrderUsers set Orderd=Orderd+1 where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode + " and PostCodeUser=" + pCode);
                return DB.Query_Execute() >= 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool OrderDown(int pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("update ReferOrderUsers set Orderd=Orderd-1 where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode + " and PostCodeUser=" + pCode);
                return DB.Query_Execute() >= 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }


    public class JReferOrderUserTable:ClassLibrary.JTable
    {
        public int PostCode;
        public int PostCodeUser;
        public int Ordered;

        public JReferOrderUserTable()
            : base("ReferOrderUsers")
        {
        }

    }

}
