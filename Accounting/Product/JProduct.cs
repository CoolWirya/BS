using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Product
{
   public class JProduct : ClassLibrary.JSystem
    {
       public int code { get; set; }
      public string ClassName { get; set; }
     public string Name { get; set; }

        public JProduct()
        {

        }
        public JProduct(int code)
        {
            GetData(code);
        }
        public bool GetData(int Code)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AccProduct where code=" + Code );
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
