using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls.Help
{
    public class JHelp
    {
        #region Properties
        public int Code { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public string Text { get; set; }
        public DateTime ModifiedDate { get; set; }
        #endregion

        public bool Save()
        {
            if (Code == 0)
                Code = FindHelp(ClassName, ObjectCode);
            JHelpTable jHelpTable = new JHelpTable();
            jHelpTable.SetValueProperty(this);
            if (Code == 0)
            {
                Code = jHelpTable.Insert();
                if (Code > 0) return true;
            }
            else
                if (jHelpTable.Update()) return true;
            return false;
        }

        public int FindHelp(string className, int objectCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select Code From erpHelp Where ClassName=N'" + className + "' AND ObjectCode=" + objectCode);
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["Code"]);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void GetData(string className, int objectCode)
        {
            Code = FindHelp(className, objectCode);
            if (Code == 0) return;
            GetData(Code);
        }

        public void GetData(int pCode)
        {
            Code = pCode;
            JHelpTable jHelpTable = new JHelpTable();
            jHelpTable.GetData(this, Code);
        }
    }

    public class JHelps
    {
        public static bool CanEditHelp()
        {
            return ClassLibrary.JPermission.CheckPermission("WebControllers.MainControls.Help.JHelps.CanEditHelp", false);
        }

        public static void ShowHelp(string ClassName, int ObjectCode)
        {
            WebClassLibrary.JWebManager.LoadControl("erpHelp"
                , "~/WebControllers/MainControls/Help/JHelpControl.ascx"
                , "Help"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("ClassName", ClassName), new Tuple<string, string>("ObjectCode", ObjectCode.ToString()) }
                , WebClassLibrary.WindowTarget.NewWindow
                , true
                , false
                , true
                , 500, 400, true);
        }
    }

    public class JHelpTable : ClassLibrary.JTable
    {
        public string Name;
        public string ClassName;
        public int ObjectCode;
        public string Text;
        public DateTime ModifiedDate;

        public JHelpTable() : base("erpHelp") { }
    }
}