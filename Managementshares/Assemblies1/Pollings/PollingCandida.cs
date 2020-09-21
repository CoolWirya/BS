using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JPollingCandida :JSystem
    {
        public int Code { get; set; }
        public int PCode { get; set; }
        public int PollingCode { get; set; }

        public JPollingCandida()
        {
        }
        public JPollingCandida(int pCode)
        {
            JPollingCandidas candidas = new JPollingCandidas(PollingCode);
            DataTable table = candidas.GetData(pCode);
            if (table.Rows.Count > 0)
                JTable.SetToDataRow(this, table.Rows[0]);
        }
        public bool Exists()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT Code FROM ShareAssemblyPollingCandida WHERE Code<> {0}  AND PCode={1} ", this.Code, this.PCode));
                return DB.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert()
        {
            JPollingCandidaTable companyTable = new JPollingCandidaTable();
            try
            {
                companyTable.SetValueProperty(this);
                Code = companyTable.Insert();
                if (Code > 0)
                {
                    return Code;
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        public Boolean Delete()
        {
            try
            {
                if (JMessages.Question("آیا میخواهید نماینده مورد نظر از لیست حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    ///
                    JPollingCandidaTable JPT = new JPollingCandidaTable();
                    JPT.SetValueProperty(this);
                    if (JPT.Delete())
                    {
                        if (Nodes.CurrentNode != null)
                            Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class JPollingCandidas : JSystem
    {
          public int PollingCode;

          public JPollingCandidas(int pollingCode)
        {
            PollingCode = pollingCode;
        }
      
        public System.Data.DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" SELECT ShareAssemblyPollingCandida.Code ShareAssemblyPollingCandida.PCode ,Name
              FROM [ShareAssemblyPollingCandida]
              Inner Join clsAllPerson ON PCode = clsAllPerson.Code
               WHERE PollingCode=" + PollingCode.ToString();
                if (pCode > 0)
                    query += " AND Code = " + pCode;
                DB.setQuery(query + " ORDER BY clsAllPerson.Name ");
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }
    }

}
