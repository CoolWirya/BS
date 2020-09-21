using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Bascol
{
    public class JProducts : JSubBaseDefine
    {
        public JProducts()
            : base(JBaseDefine.BascolProduct)
        {
        }
    }
    public class JProductss : JSubBaseDefines
    {
        public JProductss()
            : base(JBaseDefine.BascolProduct)
        {
        }
        public static DataTable GetDataTable()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                return GetDataTable(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        public static DataTable GetDataTable(JDataBase Db)
        {
            //JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery("select * from subdefine where bcode=901 order by Code");
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                //Db.Dispose();
            }
        }
    }
}

