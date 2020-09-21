using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JBankAccount : JSystem
    {
        public int Code { get; set; }
        public int PCode { get; set; }
        public int BankCode { get; set; }
        public string Branch { get; set; }
        public int AccountType { get; set; }
        public string AccountNo { get; set; }
        public string SHEBA { get; set; }
        public string CardNo { get; set; }

        public JBankAccount()
        {
        }
        public JBankAccount(int PersonCode)
        {
            if (PersonCode > 0)
                GetData(PersonCode);
        }
        public int Insert()
        {
            JBankAccountTable AT = new JBankAccountTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Delete(bool IsWeb = false)
        {
            JBankAccountTable AT = new JBankAccountTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!IsWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            else return false;
        }
        public bool Update()
        {
            JBankAccountTable AT = new JBankAccountTable();
            AT.SetValueProperty(this);
            return (AT.Update());
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //// آخرین شماره حساب شخص که در سیستم ثبت شده لود میشود
                DB.setQuery("select Top 1 * from finBankAccount where PCode=" + pCode.ToString() + " ORDER BY Code Desc ");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetDataWithCode(int Code)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from finBankAccount where Code=" + Code.ToString() + "");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"select top 100 percent Cap.[Code]
                      ,Cap.[Name]
                      ,FBA.[BankCode]
                      ,FBA.[Branch]
                      ,FBA.[AccountType]
                      ,FBA.[AccountNo] from finBankAccount FBA
                       left join ClsAllPerson Cap on Cap.Code = FBA.PCode";
        }

    }
}
