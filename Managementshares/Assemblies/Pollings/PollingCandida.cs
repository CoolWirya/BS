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
        public string Title { get; set; }

        public JPollingCandida()
        {
        }
        public JPollingCandida(int pCode)
        {
            this.getData(pCode);
        }

        public Boolean getData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM ShareAssemblyPollingCandida WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool Exists()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string sql = "";
                if (PCode > 0)
                    sql = string.Format("SELECT Code FROM ShareAssemblyPollingCandida WHERE Code<> {0}  AND PCode <>0 AND PCode={1} ", this.Code, this.PCode + " And PollingCode=" + PollingCode);
                else
                    sql = string.Format("SELECT Code FROM ShareAssemblyPollingCandida WHERE Title <>'' AND Title = N'{0}' ", this.Title + " And PollingCode=" + PollingCode);
                DB.setQuery(sql);
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
                    return (JPT.Delete());
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
        public System.Data.DataTable GetData(int pollingCode , int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //(select ISNULL(RightCount, 0) from ShareAssemblyPollingCount Where PollingCode=" + pollingCode.ToString()                
            string query = @" SELECT Row_Number() OVER (ORDER BY clsAllPerson.Name, ShareAssemblyPollingCandida.Title) RowNo, ShareAssemblyPollingCandida.Code, ShareAssemblyPollingCandida.PCode, PollingCode 
                      ,ISNULL(Name,  ShareAssemblyPollingCandida.Title ) Title
,ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where Status = 1 AND ACode = (Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code)), 0) VoteRight 
                     FROM [ShareAssemblyPollingCandida]
                      Left Join clsAllPerson ON PCode = clsAllPerson.Code
                      WHERE PollingCode=" + pollingCode.ToString();
                if (pCode > 0)
                    query += " AND ShareAssemblyPollingCandida.Code = " + pCode;
                DB.setQuery(query + " ORDER BY clsAllPerson.Name, ShareAssemblyPollingCandida.Title  ");
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

        public System.Data.DataTable GetDataCounter(int pollingCode, int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" SELECT Row_Number() OVER (ORDER BY clsAllPerson.Name, ShareAssemblyPollingCandida.Title) RowNo, ShareAssemblyPollingCandida.Code, ShareAssemblyPollingCandida.PCode, PollingCode 
                      ,ISNULL(Name,  ShareAssemblyPollingCandida.Title ) Title
(
select 
RightCount*(select mainmembers from ShareAssemblyPolling where Code=PollingCode)/(select count(Code) from ShareAssemblyPollingCountChoice where PollingCountCode=ShareAssemblyPollingCount.Code)
from ShareAssemblyPollingCount
where Code in (select pollingcountcode from ShareAssemblyPollingCountChoice where ChoiceCode=clsAllPerson.Code)
and PollingCode=ShareAssemblyPollingCandida.PollingCode)

FROM [ShareAssemblyPollingCandida]
                      Left Join clsAllPerson ON PCode = clsAllPerson.Code
                      WHERE PollingCode=" + pollingCode.ToString();
                if (pCode > 0)
                    query += " AND ShareAssemblyPollingCandida.Code = " + pCode;
                DB.setQuery(query + " ORDER BY clsAllPerson.Name, ShareAssemblyPollingCandida.Title  ");
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
