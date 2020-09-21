using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Factor.FactorItem
{
    public class JFactorItem : ClassLibrary.JSystem
    {
        public string parameter { get; set; }
        public int Code { get; set; }
        public int Row { get; set; }
        public string describe { get; set; }
        public int count { get; set; }
        public decimal unitPrice { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public int product { get; set; }
        public int FactorCode { get; set; }

        public JFactorItem()
        {

        }

        public JFactorItem(int pFactorCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AccFactorItem where Factorcode=" + pFactorCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                }
            }
            finally
            {
                DB.Dispose();
            }

        }
        public bool Update()
        {
            if (!ClassLibrary.JPermission.CheckPermission("Accounting.Factor.FactorItem.JFactorItm.Update"))
                return false;
            JFactorItemTable AT = new JFactorItemTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }
        public bool Delete()
        {
            if (!ClassLibrary.JPermission.CheckPermission("Accounting.Factor.FactorItem.JFactorItem.Insert"))
                return false;
            JFactorItemTable AT = new JFactorItemTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public int Insert()
        {
            if (!ClassLibrary.JPermission.CheckPermission("Accounting.Factor.FactorItem.JFactorItem.Insert"))
                return 0;
            JFactorItemTable AT = new JFactorItemTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }
    }
}
