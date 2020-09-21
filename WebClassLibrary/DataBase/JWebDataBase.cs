using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace WebClassLibrary
{
    public class JWebDataBase
    {
        public static DataTable GetDataTable(string query, bool convertDate = true, ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {
            if (query == null || query.Length == 0) return null;
            ClassLibrary.JDataBase _db = db;
            try
            {
                string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);

                if (_sql.Length == 2)
                {
                    _db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                    query = _sql[1];
                }

                if (_db == null) _db = new ClassLibrary.JDataBase();

                _db.setQuery(query);
                if (convertDate)
                    return ConvertDateTimeColumns(_db.Query_DataTable());
                return _db.Query_DataTable();
            }
            finally
            {
                if (db == null) _db.Dispose();
            }
        }

        public static DataTable ConvertDateTimeColumns(DataTable dt, bool includeTime = true)
        {
            if (dt == null) return dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType == typeof(DateTime))
                {
                    string oldColName = dt.Columns[i].ColumnName;
                    int oridinal = dt.Columns[oldColName].Ordinal;
                    string newColName = dt.Columns[i].ColumnName + "_tempColumnName";
                    dt.Columns.Add(newColName);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DateTime date;
                        try
                        {
                            if (dt.Rows[j][oldColName] is DateTime)
                            {
                                date = (DateTime)dt.Rows[j][oldColName];
                                if (!includeTime)
                                    date = DateTime.Parse(date.ToString("yyyy-MM-dd 00:00:00"));
                                dt.Rows[j][newColName] = ClassLibrary.JDateTime.FarsiDate(date);
                            }
                            else
                                dt.Rows[j][newColName] = "";
                        }
                        catch
                        {
                            dt.Rows[j][newColName] = "";
                        }
                    }
                    dt.Columns.Remove(oldColName);
                    dt.Columns[newColName].SetOrdinal(oridinal);
                    dt.Columns[newColName].ColumnName = oldColName;
                }
            }
            return dt;
        }

        public static DataTable TranslateColumns(DataTable dt, string ColumnsToTranslate)
        {
            if (ColumnsToTranslate.Trim().Length > 0)
            {
                foreach (string column in ColumnsToTranslate.Split(','))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][column] = ClassLibrary.JLanguages._Text(dt.Rows[i][column].ToString());
                    }
                }
            }
            return dt;
        }

        public static int GetPageCount(string query, ClassLibrary.JDataBase db = null, string className = "" , string objectCode ="")
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }

            DataTable dt = GetDataTable("Select Count(*) from (" + query + ") tbl", false, db, className, objectCode);
            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            return 0;
        }

        public static int GetPageCount(string query, string where, ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }
            DataTable dt = GetDataTable("Select Count(*) from (" + query + ") tbl where " + where, false, db, className, objectCode);
            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            return 0;
        }

        public static DataTable GetDataTableStructure(string query, ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }
            DataTable dt = GetDataTable("Select TOP 0 * from (" + query + ") tbl ", false, db, className, objectCode);
            if (dt == null)
            {
                if (query.IndexOf("where") > 0)
                    dt = GetDataTable(query.Replace("where", "where 1<>0 and "), false, db, className, objectCode);
                else
                    dt = GetDataTable(query.Replace("order by", " where 1<>0 order by "), false, db, className, objectCode);
            }
            return dt;
        }

        public static JDataBase RunPreviuseTempTable(string query, string className = "", string objectCode = "", JDataBase pdb = null)
        {
            if (className == "")
                className = query.Replace(" ", "");
            if (objectCode == "")
                objectCode = "0";

            string SessionName = "WebClassLibrary.JWebDataBase.GetPagerData." + className + "." + objectCode.ToString();
            if (pdb != null)
            {

                SessionManager.Current.Session.Remove(SessionName + ".DB");
                SessionManager.Current.Session.Add(SessionName + ".DB", pdb);
            }
            else
            {
                if (SessionManager.Current.Session[SessionName + ".DB"] == null)
                {
                    SessionManager.Current.Session.Add(SessionName + ".DB", new JDataBase());
                }
            }
            JDataBase db = (JDataBase)SessionManager.Current.Session[SessionName + ".DB"];
            string OldSql = (string)SessionManager.Current.Session[SessionName + ".oldSQL"];
            if (!db.RunTempPrviuseTable || OldSql != query)
            {
                SessionManager.Current.Session.Remove(SessionName + ".oldSQL");
                SessionManager.Current.Session.Add(SessionName + ".oldSQL", query);
                db.RunTempPrviuseTable = true;
                db.setQuery(query);
                DataTable DT =  db.Query_DataTable();
            }
            return db;
        }

        public static DataTable GetPage(string query, int pageNum, int pageCount, string OrderBy = "Code", string where = "", string PreQuery = "", ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }

            if (OrderBy == null || OrderBy == "") OrderBy = "Code";
            DataTable dt = GetDataTable(PreQuery + " Select TOP 100 percent * From(Select TOP 100 percent DataBaseTableRowNum = ROW_NUMBER() OVER (Order by " + OrderBy + "), tbl.* from (" + query + ") tbl" + (where == "" ? "" : " where " + where) + " ) tbl2 Where DataBaseTableRowNum > " + ((pageNum - 1) * pageCount).ToString() + " AND DataBaseTableRowNum <= " + (pageNum * pageCount).ToString(), true, db, className, objectCode);

            return dt;
        }





        public static DataTable GetPageWithSum(string query, int pageNum, int pageCount, Dictionary<string, double> SumFields, string OrderBy = "Code", string where = "", ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }

            string SumFieldsQuery = string.Empty;
            string BuildQuery = string.Empty;

            if (SumFields != null)
                foreach (string Key in SumFields.Keys)
                {
                    if (!string.IsNullOrEmpty(SumFieldsQuery))
                        SumFieldsQuery += ",";
                    SumFieldsQuery += "SUM(CAST(" + Key + " as FLOAT(53))) As " + Key;
                }
            if (SumFieldsQuery != string.Empty)
                SumFieldsQuery += ",";

            if (OrderBy == null || OrderBy == "") OrderBy = "Code";
            DataTable dt = GetDataTable("Select TOP 100 percent " + SumFieldsQuery + " * From(Select TOP 100 percent DataBaseTableRowNum = ROW_NUMBER() OVER (Order by " + OrderBy + "), tbl.* from (" + query + ") tbl) tbl2 Where DataBaseTableRowNum > " + ((pageNum - 1) * pageCount).ToString() + " AND DataBaseTableRowNum <= " + (pageNum * pageCount).ToString() + (where == "" ? "" : " AND (" + where + ")"), true, db, className, objectCode);
            if (dt != null && dt.Rows.Count > 0 && SumFields.Count > 0)
                foreach (DataColumn Dc in dt.Columns)
                {
                    if (SumFields != null && !string.IsNullOrEmpty(dt.Rows[0][Dc.ColumnName].ToString()) && SumFields[Dc.ColumnName] != null)
                        SumFields[Dc.ColumnName] = (double)dt.Rows[0][Dc.ColumnName];
                }
            if (SumFields != null && dt != null)
                foreach (string Key in SumFields.Keys)
                {
                    dt.Columns.Remove(Key);
                }

            //if (dt != null)
            //    dt.Columns.Remove("DataBaseTableRowNum");
            return dt;
        }

        public static DataTable GetDataSource(string query, string className = "", string objectCode = "", string OrderBy = "Code", string where = "", ClassLibrary.JDataBase db = null)
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }

            if (OrderBy == null || OrderBy == "") OrderBy = "Code";
            query = "select top 50 * from (" + query + ") as tbl ";
            if (where != string.Empty)
                query += " where " + where;
            if (OrderBy != string.Empty)
                query += " Order By " + OrderBy;
            DataTable dt = GetDataTable(query, true, db, className, objectCode);
            //DataTable dt = GetDataTable("Select  * From ((" + query + ") tbl)  Where  " + (where == "" ? "" : " AND (" + where + ") OrderBy " + OrderBy), true, db);


            return dt;
        }

        public static Dictionary<string, double> GetSumOfFields(Dictionary<string, double> SumFields, string query, bool convertDate = true, string where = "", ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {

            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }

            if (SumFields == null || SumFields.Keys.Count == 0)
                return SumFields;
            ///Initilization & Declaration
            string SumFieldsQuery = string.Empty;
            string BuildQuery = string.Empty;

            ///Sum Fields
            foreach (string Key in SumFields.Keys)
            {
                if (!string.IsNullOrEmpty(SumFieldsQuery))
                    SumFieldsQuery += ",";
                SumFieldsQuery += "SUM(CAST(" + Key + " as FLOAT(53))) As " + Key;
            }

            ///Build Query
            if (where != string.Empty)
                BuildQuery = "Select " + SumFieldsQuery + " from (" + query + ") tbl where " + where;
            else
                BuildQuery = "Select " + SumFieldsQuery + " from (" + query + ") tbl";

            ///Execute Query
            DataTable dt = GetDataTable(BuildQuery, false, db, className, objectCode);
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataColumn Dc in dt.Columns)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0][Dc.ColumnName].ToString()))
                        SumFields[Dc.ColumnName] = (double)dt.Rows[0][Dc.ColumnName];
                }
            return SumFields;
        }

        public static Dictionary<string, double> GetSumOfFieldsPage(Dictionary<string, double> SumFields, string query, int pageNum, int pageCount, string OrderBy = "Code", bool convertDate = true, string where = "", ClassLibrary.JDataBase db = null, string className = "", string objectCode = "")
        {
            string[] _sql = query.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
            if (_sql.Length == 2)
            {
                db = RunPreviuseTempTable(_sql[0], className, objectCode, db);
                query = _sql[1];
            }
            ///Initilization & Declaration
            string SumFieldsQuery = string.Empty;
            string BuildQuery = string.Empty;

            ///Sum Fields
            foreach (string Key in SumFields.Keys)
            {
                if (!string.IsNullOrEmpty(SumFieldsQuery))
                    SumFieldsQuery += ",";
                SumFieldsQuery += "SUM(CAST(" + Key + " as FLOAT(53))) As " + Key;
            }

            ///Build Query
            if (OrderBy == null || OrderBy == "") OrderBy = "Code";
            BuildQuery = "Select TOP 100 percent " + SumFieldsQuery + " From(Select TOP 100 percent DataBaseTableRowNum = ROW_NUMBER() OVER (Order by " + OrderBy + "), tbl.* from (" + query + ") tbl) tbl2 Where DataBaseTableRowNum > " + ((pageNum - 1) * pageCount).ToString() + " AND DataBaseTableRowNum <= " + (pageNum * pageCount).ToString() + (where == "" ? "" : " AND (" + where + ")");

            ///Execute Query
            DataTable dt = GetDataTable(BuildQuery, true, db, className, objectCode);
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataColumn Dc in dt.Columns)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0][Dc.ColumnName].ToString()))
                        SumFields[Dc.ColumnName] = (double)dt.Rows[0][Dc.ColumnName];
                }
            return SumFields;
        }


        public static int ExecuteQuery(string query)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }


        public static string CreateTempTable(ref JDataBase pDB, string className, string objectCode, SqlCommand cmd, string sql, int pageIndex, int pageSize, string filterItems, string sumFields, string rowColors = null, string sortField = "", string sortMode = "", string whereClause = "")
        {
            if (className == "")
                className = sql.Replace(" ", "");
            if (objectCode == "")
                objectCode = "0";
            string SessionName = "WebClassLibrary.JWebDataBase.GetPagerData." + className + "." + objectCode.ToString();
            JDataBase DB;
            string TempTableName = "";
            if (
                    SessionManager.Current.Session[SessionName + ".sortField"] != sortField ||
                    SessionManager.Current.Session[SessionName + ".whereClause"] != whereClause ||
                    SessionManager.Current.Session[SessionName + ".DB"] == null ||
                    (SessionManager.Current.Session[SessionName + ".TempTableName"] != null &&
                    !JDataBase.isTempTable(SessionManager.Current.Session[SessionName + ".TempTableName"].ToString(), (JDataBase)SessionManager.Current.Session[SessionName + ".DB"]))
                )
            {
                if (SessionManager.Current.Session[SessionName + ".DB"] == null)
                {
                    SessionManager.Current.Session.Add(SessionName + ".DB", new JDataBase());
                }
                DB = (JDataBase)SessionManager.Current.Session[SessionName + ".DB"];

                if (SessionManager.Current.Session[SessionName + ".TempTableName"] != null)
                {
                    DB.setQuery("IF OBJECT_ID('tempdb.." + SessionManager.Current.Session[SessionName + ".TempTableName"].ToString() + "') IS NOT NULL DROP TABLE " + SessionManager.Current.Session[SessionName + ".TempTableName"].ToString());
                    DB.Query_Execute();
                }
                TempTableName = "[#T" + Guid.NewGuid().ToString() + ']';
                SessionManager.Current.Session.Add(SessionName + ".TempTableName", TempTableName);


                string[] _sql = sql.Split(new string[] { "<#PreviusSQL#>" }, StringSplitOptions.None);
                if (_sql.Length == 2)
                {
                    DB = RunPreviuseTempTable(_sql[0], className, objectCode, DB);
                    sql = _sql[1];
                }


                string viewSqlTemp = "SELECT ROW_NUMBER() OVER(ORDER BY " + sortField + " " + sortMode + " )AS rownumber ,* into " + TempTableName + " FROM (SELECT * FROM (" + sql.Replace("\r\n", " ").Replace("\n\r", " ").Replace("\r", " ").Replace("\n", " ") + ") t1 WHERE 1 = 1 " + whereClause + ")t2 ORDER BY " + sortField + " " + sortMode + "";
                DB.setQuery(viewSqlTemp);
                DB.Query_DataTable();

            }
            else
            {
                DB = (JDataBase)SessionManager.Current.Session[SessionName + ".DB"];
                TempTableName = SessionManager.Current.Session[SessionName + ".TempTableName"].ToString();
            }
            SessionManager.Current.Session[SessionName + ".sortField"] = sortField;
            SessionManager.Current.Session[SessionName + ".whereClause"] = whereClause;

            pDB = DB;
            return TempTableName;
        }
        public static DataSet GetPagerData(string className , string objectCode , SqlCommand cmd, string sql, int pageIndex, int pageSize, string filterItems, string sumFields, string rowColors = null, string sortField = "", string sortMode = "", string whereClause = "")
        {
            JDataBase DB = null;
            string TempTableName = "";
            TempTableName = CreateTempTable(ref DB, className, objectCode, cmd, sql, pageIndex, pageSize, filterItems, sumFields, rowColors, sortField, sortMode, whereClause);
            try
            {
                {
                    string viewSql = "(SELECT * FROM " + TempTableName + " )t3 ";


                    string str = "SELECT *" + (string.IsNullOrWhiteSpace(rowColors) ? "" : rowColors) + " FROM " + viewSql + " WHERE RowNumber BETWEEN(" + pageIndex + " -1) * " + pageSize + " + 1 AND(((" + pageIndex + " -1) * " + pageSize + " + 1) + " + pageSize + ") - 1  ORDER BY " + sortField + " " + sortMode + "";
                    DataTable mainDT = GetDataTable(str, true, DB, className, objectCode);
                    if (mainDT != null)
                    {
                        for (int i = 0; i < mainDT.Columns.Count; i++)
                        {
                            int ColumnName = 0;
                            if (Int32.TryParse(mainDT.Columns[i].ColumnName, out ColumnName))
                                mainDT.Columns[i].ColumnName = "col-" + mainDT.Columns[i].ColumnName;
                            else
                                continue;
                        }
                    }
                    try
                    {
                        using (DataSet ds = new DataSet())
                        {
                            //sda.Fill(ds, "datatable");
                            ds.Tables.Add(mainDT);
                            DataTable dt = new DataTable("Pager");
                            dt.Columns.Add("PageIndex");
                            dt.Columns.Add("PageSize");
                            dt.Columns.Add("RecordCount");
                            dt.Rows.Add();
                            dt.Rows[0]["PageIndex"] = pageIndex;
                            dt.Rows[0]["PageSize"] = pageSize;
                            //DB.setQuery("SELECT COUNT(*) FROM v" + cmd.Parameters["@GUID"].Value + "Temp WHERE 1 = 1");
                            DB.setQuery("SELECT COUNT(*) FROM " + viewSql + " WHERE 1 = 1 ");
                            try
                            {
                                dt.Rows[0]["RecordCount"] = int.Parse(DB.Query_DataTable().Rows[0][0].ToString());
                            }
                            catch
                            {
                                dt.Rows[0]["RecordCount"] = 0;
                            }
                            //cmd.Parameters["@RecordCount"].Value;
                            ds.Tables.Add(dt);
                            if (!string.IsNullOrWhiteSpace(sumFields))
                            {
                                DataTable sumFieldsDT = new DataTable("sumfields");
                                sumFieldsDT.Columns.Add("field");
                                sumFieldsDT.Columns.Add("page_sum");
                                sumFieldsDT.Columns.Add("total_sum");
                                sumFieldsDT.Columns.Add("date");
                                sumFieldsDT.Columns.Add("time");
                                //string[] sfs = sumFields.Split(',');
                                //for (int i = 0; i < sfs.Length; i++)
                                //{
                                //	sumFieldsDT.Columns.Add(sfs[i] + "_page_sum");
                                //	sumFieldsDT.Columns.Add(sfs[i] + "_total_sum");
                                //}

                                //string[] SumFieldsResult = cmd.Parameters["@SumFieldsResult"].Value.ToString().Split(',');
                                string date = JDateTime.FarsiDate(JDateTime.Now()).Substring(0, 10);
                                string time = JDateTime.Now().ToString("HH:mm:ss");
                                //for (int i = 0; i < SumFieldsResult.Length; i++)
                                string[] sfs = sumFields.Split(',');
                                for (int i = 0; i < sfs.Length; i++)
                                {
                                    sumFieldsDT.Rows.Add();
                                    //string[] sfr = SumFieldsResult[i].Split(':');
                                    //sumFieldsDT.Rows[i]["field"] = sfr[0];
                                    //sumFieldsDT.Rows[i]["page_sum"] = sfr[1];
                                    //sumFieldsDT.Rows[i]["total_sum"] = sfr[2];

                                    sumFieldsDT.Rows[i]["field"] = sfs[i];
                                    //DB.setQuery("SELECT SUM(ISNULL(" + sfs[i] + ",0)) page_sum FROM v" + cmd.Parameters["@GUID"].Value + "Temp WHERE RowNumber BETWEEN(" + pageIndex + " -1) * " + pageSize + " + 1 AND(((" + pageIndex + " -1) * " + pageSize + " + 1) + " + pageSize + ") - 1");
                                    DB.setQuery("SELECT SUM(CAST(ISNULL(" + sfs[i] + ",0) AS BIGINT)) page_sum FROM " + viewSql + " WHERE RowNumber BETWEEN(" + pageIndex + " -1) * " + pageSize + " + 1 AND(((" + pageIndex + " -1) * " + pageSize + " + 1) + " + pageSize + ") - 1");
                                    try
                                    {
                                        sumFieldsDT.Rows[i]["page_sum"] = Int64.Parse(DB.Query_DataTable().Rows[0][0].ToString());
                                    }
                                    catch
                                    {
                                        sumFieldsDT.Rows[i]["page_sum"] = 0;
                                    }
                                    //sumFieldsDT.Rows[i]["page_sum"] = DB.Query_ExecutSacler();
                                    //DB.setQuery("SELECT SUM(ISNULL(" + sfs[i] + ",0)) total_sum FROM v" + cmd.Parameters["@GUID"].Value + "Temp WHERE 1 = 1");
                                    DB.setQuery("SELECT SUM(CAST(ISNULL(" + sfs[i] + ",0) AS BIGINT)) total_sum FROM " + viewSql + " WHERE 1 = 1 ");
                                    try
                                    {
                                        sumFieldsDT.Rows[i]["total_sum"] = Int64.Parse(DB.Query_DataTable().Rows[0][0].ToString());
                                    }
                                    catch
                                    {
                                        sumFieldsDT.Rows[i]["total_sum"] = 0;
                                    }
                                    sumFieldsDT.Rows[i]["date"] = date;
                                    sumFieldsDT.Rows[i]["time"] = time;
                                }
                                ds.Tables.Add(sumFieldsDT);
                            }

                            //DB.setQuery("DROP VIEW v" + cmd.Parameters["@GUID"].Value + "Temp");
                            //DB.Query_Execute();

                            return ds;
                        }
                    }
                    catch
                    {
                        //DB.setQuery("DROP VIEW v" + cmd.Parameters["@GUID"].Value + "Temp");
                        //DB.Query_Execute();
                        return null;
                    }

                    // }
                }
            }
            finally
            {
                //DB.Dispose();
                cmd.Dispose();
            }


        }
    }

}
