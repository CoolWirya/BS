using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareholdersAssembly
    {
        public int Code { get; set; }
        public int pCode { get; set; }
        public int CCode { get; set; }
        public int Share { get; set; }
        public bool PrintVote { get; set; }
        public bool present { get; set; }
        public DateTime PresentDate { get; set; }
        public int id { get; set; }

        public JShareholdersAssembly(int pCode)
        {
            if (pCode > 0)
                GetData(pCode);
        }

        public int GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from ShareholdersAssembly where Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return 1;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return 0;
        }

        public int Insert()
        {
            JShareholdersAssemblyTable ST = new JShareholdersAssemblyTable();
            ST.SetValueProperty(this);
            return ST.Insert();
        }

        public bool Update()
        {
            JShareholdersAssemblyTable ST = new JShareholdersAssemblyTable();
            ST.SetValueProperty(this);
            return ST.Update();
        }

        public bool delete()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("delete from ShareholdersAssembly where Code=" + pCode.ToString());
                DB.Query_Execute();
                return true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return false;
        }
    }
}
