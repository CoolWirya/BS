using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Entertainment
{
    public class JBulletin :JSystem
    {
        public static DataTable GetDataTableBulletinType(int pCode)
        {
            return JSubBaseDefines.GetDataTable(JBaseDefine.BulletinType.GetHashCode(), null, null, "", false , pCode,true , false);
            //string Query = " SELECT Code,name,bcode From [subdefine] WHERE [bcode] = " + JBaseDefine.BulletinType;
            //if (pCode > 0)
            //    Query = Query + " AND Code=" + pCode.ToString();
            //JDataBase pDB = new JDataBase();
            //pDB.setQuery(Query + " And " + JPermission.getObjectSql("Entertainment.JBulletin.GetDataTable", "Code"));
            //try
            //{
            //    DataTable tmp = pDB.Query_DataTable();
            //    return tmp;
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //    return null;
            //}
            //finally
            //{
            //    pDB.Dispose();
            //}
        }
    }
}
