using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JContractTypeGroup
    {
        public int Code { get; set; }
        public int DynamicCode { get; set; }
        public int FinanceGroup { get; set; }

        public int Insert(JDataBase pDB)
        {
            JContractTypeGroupTable CTGT = new JContractTypeGroupTable();
            CTGT.SetValueProperty(this);
            return CTGT.Insert(pDB);
        }

        public bool Update(JDataBase pDB)
        {
            return false;
        }

        public bool Delete(JDataBase pDB)
        {
            return false;
        }

    }

    class JContractTypeGroups
    {

        private int _DynamicCode;

        public JContractTypeGroups(int pDynamicCode)
        {
            _DynamicCode = pDynamicCode;
        }

        public void Save(int[] pFinanceGroups, JDataBase pDB)
        {
            DeleteAll(pDB);
            JContractTypeGroup CTG = new JContractTypeGroup();
            foreach (int _Code in pFinanceGroups)
            {
                CTG.FinanceGroup = _Code;
                CTG.DynamicCode = _DynamicCode;
                CTG.Insert(pDB);
            }
        }

        public void DeleteAll(JDataBase pDB)
        {
            JDataBase Db = pDB;
            try
            {
                Db.setQuery("Delete FROM legContractTypeGroup WHERE DynamicCode = " + _DynamicCode.ToString());
                Db.Query_Execute();
            }
            catch
            {
            }
            finally
            {
            }
        }

        public System.Data.DataTable GetData(JDataBase pDB)
        {
            JDataBase Db = pDB;
            if (pDB == null)
                Db = new JDataBase();
            try
            {
                Db.setQuery("SELECT * FROM legContractTypeGroup WHERE DynamicCode = " + _DynamicCode.ToString());
                return Db.Query_DataTable();
            }
            catch
            {
            }
            finally
            {
                if (pDB == null)
                    Db.Dispose();
            }
            return null;
        }

        public JContractTypeGroup[] GetItems(JDataBase pDB)
        {
            System.Data.DataTable _DT = GetData(pDB);
            JContractTypeGroup[] CTG = new JContractTypeGroup[_DT.Rows.Count];
            int Count = 0;
            foreach (System.Data.DataRow _DR in _DT.Rows)
            {
                CTG[Count] = new JContractTypeGroup();
                JTable.SetToClassField(CTG[Count], _DR);
                Count++;
            }
            return null;
        }
    }
}
