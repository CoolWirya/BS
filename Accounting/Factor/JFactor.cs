using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Factor
{
    public class JFactor
    {
        public int Code { get; set; }
        public long Number { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool payState{get;set;}
        public int userCode { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public JFactor()
        {
        }

        public JFactor(int Code)
        {
            GetData(Code);
        }

        public bool Update()
        {
            if (!ClassLibrary.JPermission.CheckPermission("Accounting.Factor.JFactor.Update"))
                return false;
            JFactorTable AT = new JFactorTable();
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
            if (!ClassLibrary.JPermission.CheckPermission("Accounting.Factor.JFactor.Insert"))
                return false;
            JFactorTable AT = new JFactorTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public int Insert()
        {
            if (!ClassLibrary.JPermission.CheckPermission("Accounting.Factor.JFactor.Insert"))
                return 0;
            JFactorTable AT = new JFactorTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }
        public bool GetData(int Code, int userCode=-1)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AccFactor where Code=" + Code + " AND userCode=" + userCode);
                if (userCode == -1)
                    DB.setQuery("select top 1 * from AccFactor where Code=" + Code);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
