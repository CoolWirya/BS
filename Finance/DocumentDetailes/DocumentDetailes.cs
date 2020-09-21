using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JDocumentDetailes : JSystem
    {
        public int Code { get; set; }
        public int DocCode { get; set; }
        public DateTime DateSave { get; set; }
        public DateTime DateModifie { get; set; }
        public int GroupCode { get; set; }
        public int KolCode { get; set; }
        public int MoeinCode { get; set; }
        public int TafziliCode1 { get; set; }
        public int TafziliCode2 { get; set; }
        public int TafziliCode3 { get; set; }
        public int TafziliCode4 { get; set; }
        public int TafziliCode5 { get; set; }
        public decimal BedPrice { get; set; }
        public decimal BesPrice { get; set; }
        public string Description { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }

        public JDocumentDetailes()
        {
        }
        public JDocumentDetailes(int PersonCode)
        {
            if (PersonCode > 0)
                GetData(PersonCode);
        }
        public int Insert()
        {
            JDocumentDetailesTable AT = new JDocumentDetailesTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public static int InsertFullDocument(int UserCode, int PostCode, string Description, int Group1, int Kol1, int Moein1, int Tafzili11, int Tafzili12, decimal Bed1, decimal Bes1, int Group2, int Kol2, int Moein2, int Tafzili21, int Tafzili22, decimal Bed2, decimal Bes2, int Code = 0)
        {
            //JDocument Document = new JDocument();
            //Document.Date = DateTime.Now;
            //Document.DateModifie = DateTime.Now;
            //Document.DateSave = DateTime.Now;
            //Document.Description = Description;
            //Document.PostCode = PostCode;
            //Document.UserCode = UserCode;
            //int DocCode = Document.Insert();
            ClassLibrary.JDataBase db = new JDataBase();
            db.setQuery(@"INSERT INTO [dbo].[FinDocument]
                           ([Code]
                           ,[DateSave]
                           ,[DateModifie]
                           ,[UserCode]
                           ,[PostCode]
                           ,[Description]
                           ,[Date]
                           ,[IsOk])
                     VALUES
                           (" + Code + @"
                           ,'" + DateTime.Now + @"'
                           ,'" + DateTime.Now + @"'
                           ," + UserCode + @"
                           ," + PostCode + @"
                           ,N'" + Description + @"'
                           ,'" + DateTime.Now + @"'
                           ,1)");

            if (db.Query_Execute() >= 0)
            {
                JDocumentDetailes DocumentDetailes = new JDocumentDetailes();
                DocumentDetailes.BedPrice = Bed1;
                DocumentDetailes.BesPrice = Bes1;
                DocumentDetailes.ClassName = "";
                DocumentDetailes.DateModifie = DateTime.Now;
                DocumentDetailes.DateSave = DateTime.Now;
                DocumentDetailes.Description = Description;
                DocumentDetailes.DocCode = Code;
                DocumentDetailes.GroupCode = Group1;
                DocumentDetailes.KolCode = Kol1;
                DocumentDetailes.MoeinCode = Moein1;
                DocumentDetailes.ObjectCode = 0;
                DocumentDetailes.TafziliCode1 = Tafzili11;
                DocumentDetailes.TafziliCode2 = Tafzili12;
                DocumentDetailes.Insert();

                DocumentDetailes.BedPrice = Bed2;
                DocumentDetailes.BesPrice = Bes2;
                DocumentDetailes.ClassName = "";
                DocumentDetailes.DateModifie = DateTime.Now;
                DocumentDetailes.DateSave = DateTime.Now;
                DocumentDetailes.Description = Description;
                DocumentDetailes.DocCode = Code;
                DocumentDetailes.GroupCode = Group2;
                DocumentDetailes.KolCode = Kol2;
                DocumentDetailes.MoeinCode = Moein2;
                DocumentDetailes.ObjectCode = 0;
                DocumentDetailes.TafziliCode1 = Tafzili21;
                DocumentDetailes.TafziliCode2 = Tafzili22;
                DocumentDetailes.Insert();
            }
            return Code;
        }

        public bool Delete(bool IsWeb = false)
        {
            JDocumentDetailesTable AT = new JDocumentDetailesTable();
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
            JDocumentDetailesTable AT = new JDocumentDetailesTable();
            AT.SetValueProperty(this);
            return (AT.Update());
        }

        public bool GetData(int DocCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //// آخرین شماره حساب شخص که در سیستم ثبت شده لود میشود
                DB.setQuery("select Top 1 * from FinDocumentDetails where DocCode=" + DocCode.ToString() + " ORDER BY Code Desc ");
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
                DB.setQuery("select * from FinDocumentDetails where Code=" + Code.ToString() + "");
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
            return @"SELECT TOP 1000 [Code]
                      ,[DocCode]
                      ,[DateSave]
                      ,[DateModifie]
                      ,[GroupCode]
                      ,[KolCode]
                      ,[MoeinCode]
                      ,[TafziliCode1]
                      ,[TafziliCode2]
                      ,[TafziliCode3]
                      ,[TafziliCode4]
                      ,[TafziliCOde5]
                      ,[BedPrice]
                      ,[BesPrice]
                      ,[Description]
                      ,[ClassName]
                      ,[ObjectCode]
                  FROM [dbo].[FinDocumentDetails]";
        }

    }
}
