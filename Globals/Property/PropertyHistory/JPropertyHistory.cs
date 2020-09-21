using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Globals.Property
{
    public class JPropertyHistory
    {
        #region Constructor
        public JPropertyHistory()
        {
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public int TableCode { get; set; }
        public int TableObjectCode { get; set; }
        public int UserCode { get; set; }
        public int UserPostCode { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Date { get; set; }
        #endregion

        #region Method
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                JPropertyHistoryTable jPropertyHistoryTable = new JPropertyHistoryTable();
                jPropertyHistoryTable.SetValueProperty(this);
                return jPropertyHistoryTable.Insert();
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                JPropertyHistoryTable jPropertyHistoryTable = new JPropertyHistoryTable();
                jPropertyHistoryTable.SetValueProperty(this);
                return jPropertyHistoryTable.Delete();
            }
            finally
            {
                db.Dispose();
            }
        }

        public void SaveChanges(DataTable OldData, DataTable NewData, string ClassName, int ObjectCode)
        {
            if (OldData != null)
                for (int i = 0; i < OldData.Rows.Count; i++)
                {
                    int k = 0;
                    for (; k < NewData.Rows.Count; k++)
                    {
                        if (Convert.ToInt32(OldData.Rows[i][0]) == Convert.ToInt32(NewData.Rows[k][0])) // row found. check columns for any changes
                        {
                            for (int j = 0; j < OldData.Columns.Count; j++)
                            {
                                if (OldData.Rows[i][j].ToString() != NewData.Rows[k][j].ToString()) // columns are not equal
                                {
                                    JPropertyHistory jPropertyHistory = new JPropertyHistory();
                                    jPropertyHistory.ClassName = ClassName;
                                    jPropertyHistory.ObjectCode = ObjectCode;
                                    jPropertyHistory.TableCode = Convert.ToInt32(OldData.Rows[i][0]);
                                    jPropertyHistory.TableObjectCode = Convert.ToInt32(OldData.Rows[i][1]);
                                    jPropertyHistory.UserCode = JMainFrame.CurrentUserCode;
                                    jPropertyHistory.UserPostCode = JMainFrame.CurrentPostCode;
                                    jPropertyHistory.FieldName = OldData.Columns[j].Caption;
                                    jPropertyHistory.OldValue = OldData.Rows[i][j].ToString();
                                    jPropertyHistory.NewValue = NewData.Rows[k][j].ToString();
                                    jPropertyHistory.Date = DateTime.Now;
                                    jPropertyHistory.Insert();
                                }
                            }
                            break;
                        }
                    }
                    if (k == NewData.Rows.Count) // The row has deleted (row not found in new data)
                    {
                        for (int m = 0; m < NewData.Columns.Count; m++)
                        {
                            JPropertyHistory jPropertyHistory = new JPropertyHistory();
                            jPropertyHistory.ClassName = ClassName;
                            jPropertyHistory.ObjectCode = ObjectCode;
                            jPropertyHistory.TableCode = Convert.ToInt32(OldData.Rows[i][0]);
                            jPropertyHistory.TableObjectCode = Convert.ToInt32(OldData.Rows[i][1]);
                            jPropertyHistory.UserCode = JMainFrame.CurrentUserCode;
                            jPropertyHistory.FieldName = OldData.Columns[m].Caption;
                            jPropertyHistory.OldValue = OldData.Rows[i][m].ToString();
                            jPropertyHistory.NewValue = "{Deleted}";
                            jPropertyHistory.Date = DateTime.Now;
                            jPropertyHistory.Insert();
                        }
                    }
                }

            // Checking new rows added by user
            if (NewData != null)
                for (int i = 0; i < NewData.Rows.Count; i++)
                {
                    int j = 0;
                    if (OldData != null)
                        for (; j < OldData.Rows.Count; j++)
                        {
                            if (NewData.Rows[i][0].ToString() == OldData.Rows[j][0].ToString())
                                break;
                        }
                    if (OldData==null || j == OldData.Rows.Count) // New row has added (row not found in old data)
                    {
                        for (int m = 0; m < NewData.Columns.Count; m++)
                        {
                            JPropertyHistory jPropertyHistory = new JPropertyHistory();
                            jPropertyHistory.ClassName = ClassName;
                            jPropertyHistory.ObjectCode = ObjectCode;
                            jPropertyHistory.TableCode = Convert.ToInt32(NewData.Rows[i][0]);
                            jPropertyHistory.TableObjectCode = Convert.ToInt32(NewData.Rows[i][1]);
                            jPropertyHistory.UserCode = JMainFrame.CurrentUserCode;
                            jPropertyHistory.FieldName = NewData.Columns[m].Caption;
                            jPropertyHistory.OldValue = "{Added}";
                            jPropertyHistory.NewValue = NewData.Rows[i][m].ToString();
                            jPropertyHistory.Date = DateTime.Now;
                            jPropertyHistory.Insert();
                        }
                    }
                }

        }
        #endregion

        #region GetData
        public DataTable GetChangeset(string ClassName, int ObjectCode, int TableObjectCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"select distinct(ph.Date), ph.UserCode, (select Fa_Date from StaticDates where En_Date = CAST([Date] as date)) as Fa_Date, CAST(DATEPART(HH, Date) AS VARCHAR) + ':' + CAST(DATEPART(MINUTE, Date) AS VARCHAR) + ':' + CAST(DATEPART(SS, Date) AS VARCHAR) as [Time], ph.Title from
                                (select CAST(DATEPART(YYYY, Date) AS VARCHAR) + '-' + CAST(DATEPART(MM, Date) AS VARCHAR) + '-' +CAST(DATEPART(DD, Date) AS VARCHAR) + ' ' +CAST(DATEPART(HH, Date) AS VARCHAR) + ':' + CAST(DATEPART(MINUTE, Date) AS VARCHAR) + ':' + CAST(DATEPART(SS, Date) AS VARCHAR) as [Date], (Select clsPerson.Fam + ' ' + clsPerson.Name from clsPerson inner join users on clsPerson.Code = users.pcode where users.code = PropertyHistory.UserCode) as [Title], UserCode from PropertyHistory
                                where PropertyHistory.ClassName = N'{CLASSNAME}' AND PropertyHistory.ObjectCode = {OBJECTCODE} AND PropertyHistory.TableObjectCode = {TABLEOBJECTCODE}) as ph";
                db.setQuery(query.Replace("{CLASSNAME}", ClassName).Replace("{OBJECTCODE}", ObjectCode.ToString()).Replace("{TABLEOBJECTCODE}", TableObjectCode.ToString()));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetChangesetDetails(string ClassName, int ObjectCode, int TableObjectCode, int UserCode, DateTime Date)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"select TableCode, FieldName, OldValue, NewValue from PropertyHistory
                                    where CAST(CAST(DATEPART(YYYY, Date) AS VARCHAR) + '-' + CAST(DATEPART(MM, Date) AS VARCHAR) + '-' +CAST(DATEPART(DD, Date) AS VARCHAR) + ' ' +CAST(DATEPART(HH, Date) AS VARCHAR) + ':' + CAST(DATEPART(MINUTE, Date) AS VARCHAR) + ':' + CAST(DATEPART(SS, Date) AS VARCHAR) as datetime) = CAST('{DATE}' as datetime)
                                    AND PropertyHistory.ClassName = N'{CLASSNAME}' AND PropertyHistory.ObjectCode = {OBJECTCODE} AND PropertyHistory.TableObjectCode = {TABLEOBJECTCODE} AND PropertyHistory.UserCode = {USERCODE}
                                    order by TableCode";
                db.setQuery(query.Replace("{CLASSNAME}", ClassName).Replace("{OBJECTCODE}", ObjectCode.ToString()).Replace("{TABLEOBJECTCODE}", TableObjectCode.ToString()).Replace("{USERCODE}", UserCode.ToString()).Replace("{DATE}", Date.ToString("yyyy-MM-dd HH:mm:ss")));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public DataTable GetFiledLastChangesetDetails(string ClassName, int ObjectCode, int TableObjectCode, int UserCode, string FieldName)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"select * from PropertyHistory
                                    where PropertyHistory.ClassName = N'{CLASSNAME}' AND PropertyHistory.ObjectCode = {OBJECTCODE} AND PropertyHistory.TableObjectCode = {TABLEOBJECTCODE} AND PropertyHistory.FieldName = N'{FIELDNAME}'
                                    order by [Date] desc";
                db.setQuery(query.Replace("{CLASSNAME}", ClassName).Replace("{OBJECTCODE}", ObjectCode.ToString()).Replace("{TABLEOBJECTCODE}", TableObjectCode.ToString()).Replace("{USERCODE}", UserCode.ToString()).Replace("{FIELDNAME}", FieldName));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion
    }
}
