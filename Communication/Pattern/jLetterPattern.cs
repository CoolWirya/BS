using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Communication
{
    public enum jLetterBasePattern
    {
        Sender,
        Reciver,
        Date,
        Subject,
        Force,
        Content,
        Copy,
        Refer,
    }

    public class jLetterPattern
    {
        public int Code { get; set; }
        public string Pattern { get; set; }

        public void Save()
        {
            JLetterPatternTable PT = new JLetterPatternTable();
            PT.Pattern = Pattern;
            if (Code > 0)
            {
                PT.Code = Code;
                PT.Update();
            }
            else
            {
                Code = PT.Insert();
            }
        }

        public void Get()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM letterpattern");
                DataTable DT = DB.Query_DataTable();
                if (DT!=null && DT.Rows.Count == 1)
                {
                    Code = int.Parse(DT.Rows[0]["Code"].ToString());
                    Pattern = DT.Rows[0]["Pattern"].ToString();
                }

            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void Replace(DataTable DT)
        {
            ClassLibrary.Controllers.Editor.JEditorDataTable Edit = new ClassLibrary.Controllers.Editor.JEditorDataTable();
            Edit.Replace(DT);
        }

        public DataTable GetStructLetter()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(jLetterBasePattern.Sender.ToString());
            DT.Columns.Add(jLetterBasePattern.Reciver.ToString());
            DT.Columns.Add(jLetterBasePattern.Date.ToString());
            DT.Columns.Add(jLetterBasePattern.Subject.ToString());
            DT.Columns.Add(jLetterBasePattern.Force.ToString());
            DT.Columns.Add(jLetterBasePattern.Content.ToString());
            DT.Columns.Add(jLetterBasePattern.Copy.ToString());
            DT.Columns.Add(jLetterBasePattern.Refer.ToString());
            return DT;
        }

    }
}
