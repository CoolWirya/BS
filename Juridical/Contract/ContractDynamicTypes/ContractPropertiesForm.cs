using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal
{
    public class JContractPropertiesForm: JLegal
    {
        public int Code { get; set; }
        public int ContractTypeCode { get; set; }
        public string FormName { get; set; }
        public string ProPertiesName { get; set; }
        public bool Value { get; set; }

        public JContractPropertiesForm()
        {
        }

        public int Insert()
        {
            try
            {
                JContractPropertiesFormTable CPF = new JContractPropertiesFormTable();
                CPF.SetValueProperty(this);
                return CPF.Insert();
            }
            catch
            {
                return 0;
            }
        }

        public bool Update()
        {
            try
            {
                JContractPropertiesFormTable CPF = new JContractPropertiesFormTable();
                CPF.SetValueProperty(this);
                return CPF.Update();
            }
            catch
            {
                return false;
            }
        }

        public bool delete()
        {
            try
            {
                JContractPropertiesFormTable CPF = new JContractPropertiesFormTable();
                CPF.SetValueProperty(this);
                return CPF.Delete();
            }
            catch
            {
                return false;
            }
        }

        public bool getDate(int pCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("select * from legContractPropertiesForm where code = " + pCode.ToString());
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void CheckinDataTable(System.Data.DataTable pDataTable, int pDynamicTypeCode)
        {
            try
            {
                foreach (System.Data.DataRow _row in pDataTable.Rows)
                {
                    if (_row.RowState == System.Data.DataRowState.Added)
                    {
                        Code = 0;
                        FormName = Convert.ToString(_row["FormName"]);
                        ProPertiesName = Convert.ToString(_row["ProPertiesName"]);
                        Value = true;
                        ContractTypeCode = pDynamicTypeCode;
                        Insert();
                    }
                    else
                        if (_row.RowState == System.Data.DataRowState.Modified)
                        {
                            Code = Convert.ToInt32(_row["Code"]);
                            FormName = Convert.ToString(_row["FormName"]);
                            ProPertiesName = Convert.ToString(_row["ProPertiesName"]);
                            Value = Convert.ToBoolean(_row["Value"]);
                            ContractTypeCode = pDynamicTypeCode;
                            Update();
                        }
                        else
                            if (_row.RowState == System.Data.DataRowState.Deleted)
                            {
                                Code = Convert.ToInt32(_row["Code"]);
                                delete();
                            }
                }
            }
            catch
            {
            }
        }

        public System.Data.DataTable GetDataTable(int pDynamicTypeCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("select * from legContractPropertiesForm where ContractTypeCode = " + pDynamicTypeCode.ToString());
                return db.Query_DataTable();
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckPrperties(string pFormName, string pProPertiesName, int pContractTypeCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("select * from legContractPropertiesForm where FormName="+ClassLibrary.JDataBase.Quote(pFormName)+
                " AND ProPertiesName=" + ClassLibrary.JDataBase.Quote(pProPertiesName) + " AND ContractTypeCode = " + pContractTypeCode.ToString());
                db.Query_DataReader();
                if (db.DataReader.Read() && Convert.ToBoolean(db.DataReader["Value"]))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
