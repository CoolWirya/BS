using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.Namaad
{
    public class JNamaad
    {

        public static System.Data.DataTable GetDataTable_Trs_View_FormConcern()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from [Trs_View_FormConcern]");
                return DB.Query_DataTable();
            }
            catch
            {

            }
            finally
            {

            }
            return null;
        }


        public static System.Data.DataTable GetDataTable_Trs_View_PersonGroup()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from [Trs_View_PersonGroup]");
                return DB.Query_DataTable();
            }
            catch
            {

            }
            finally
            {

            }
            return null;
        }

        public static System.Data.DataTable GetDataTable_Trs_View_Persons()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from [Trs_View_Persons]");
                return DB.Query_DataTable();
            }
            catch
            {

            }
            finally
            {

            }
            return null;
        }

    }


}
