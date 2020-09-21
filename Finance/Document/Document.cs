using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JDocument : JSystem
    {
        public int Code { get; set; }
        public DateTime DateSave { get; set; }
        public DateTime DateModifie { get; set; }
        public int UserCode { get; set; }
        public int PostCode { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public JDocument()
        {
        }
        public JDocument(int PersonCode)
        {
            if (PersonCode > 0)
                GetData(PersonCode);
        }
        public int Insert()
        {
            JDocumentTable AT = new JDocumentTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Delete(bool IsWeb = false)
        {
            JDocumentTable AT = new JDocumentTable();
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
            JDocumentTable AT = new JDocumentTable();
            AT.SetValueProperty(this);
            return (AT.Update());
        }

        public bool GetData(int UserCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //// آخرین شماره حساب شخص که در سیستم ثبت شده لود میشود
                DB.setQuery("select Top 1 * from FinDocument where UserCode=" + UserCode.ToString() + " ORDER BY Code Desc ");
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
                DB.setQuery("select * from FinDocument where Code=" + Code.ToString() + "");
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
            return @"SELECT TOP 100 Percent [Code]
                          ,[DateSave]
                          ,[DateModifie]
                          ,[UserCode]
                          ,[PostCode]
                          ,[Description]
                          ,[Date]
                      FROM [dbo].[FinDocument]";
        }

    }
}
