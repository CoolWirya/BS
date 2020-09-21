using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JDocumentContractTable : JTable
    {
        #region Properties
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractSubjectCode;
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName;
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode;

        public int State;
        public DateTime LastChangeDate;
        public string Description;
        public int CancellationType;
        public int CancellationCode;
        #endregion

        public JDocumentContractTable()
            : base(JTableNamesLegal.DocumentContract, "")
        {
        }

        public override int Insert(int pCancellationCode = 0)
        {
            CancellationCode = pCancellationCode;
            if (pCancellationCode == 0)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    DB.setQuery("select isnull(MAX(Code),0) MCode from LegDocumentContract where ContractSubjectCode=" + ContractSubjectCode.ToString());
                    System.Data.DataTable DT = DB.Query_DataTable();
                    if (DT != null && DT.Rows.Count == 1)
                        CancellationCode = int.Parse(DT.Rows[0]["CancellationCode"].ToString()) + 1;
                    else
                        CancellationCode = 1;
                }
                finally
                {
                    DB.Dispose();
                }
            }
            return base.Insert();
        }
    }
}
