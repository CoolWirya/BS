using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using System.Windows.Forms;

namespace Globals.Property
{
    public enum JSQLDataType
    {
        عدد,
        اعشار,
        رشته,
        پول,
        تاریخ,
        تصمیم,
        اس_کیو_ال,
        زمان,
        رشته_چند_خطی,
    }

    public enum JProppertyListType
    {
        متغیر,//متغیر
        لیست_ثابت,//لیست ثابت
        //SQLList,//لیست متغیر
    }

    public class JProperty : JGlobals
    {
        #region Propperty
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام فیلد
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// عنوان کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// كد شی
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// نوع
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// نوع لیست
        /// </summary>
        public string ListType { get; set; }
        /// <summary>
        /// مقدار پیش فرض
        /// </summary>
        public object DefaultValue { get; set; }
        /// <summary>
        /// ترتیب
        /// </summary>
        public int Ordered { get; set; }
        /// <summary>
        /// فعال
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// لیست
        /// </summary>
        public string List { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ListCanView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ListCanEdit { get; set; }
        #endregion

        #region Fields
        private string _SQLCommand;
        public JPropertyTables PropTables;

        #endregion

        #region Constructor
        public JProperty()
        {
        }

        public JProperty(string pClassName, int pObjectCode)
        {
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            PropTables = new JPropertyTables(pClassName, pObjectCode);
        }

        #endregion

        #region Insert,Delete,Update
        public int Insert()
        {
            JPropertyTable PT = new JPropertyTable();
            PT.SetValueProperty(this);
            Code = PT.Insert();
            if (Code > 0)
            {
                if (!PropTables.FindTable())
                    PropTables.CreateTable();
                _SQLCommand = " ADD	[" + Name.Replace(" ", "__") + "] " + GetDataType(DataType) + " NULL";
                PropTables.ChangeTable(_SQLCommand);
            }
            return Code;
        }

        public bool InsertData(JDataBase pdb, DataGridView dataGridView, DataTable dataTableFormat, string className, int objectCode, int valueObjectCode)
        {
            JDataBase db;
            if (pdb == null) db = new JDataBase();
            else db = pdb;
            try
            {
                string query = "";
                int TotalColumns = dataGridView.Columns.Count;
                for (int i = 0; i < TotalColumns; i++)
                {
                    query += ", [" + dataTableFormat.Columns[i].Caption + "]";
                }
                JProperties jProperties = new JProperties(className, objectCode);
                query = "INSERT INTO " + jProperties.TableName + "(" + query.Substring(1) + ") VALUES ";
                string result = "";
                string values = "";
                foreach (DataGridViewRow DR in dataGridView.Rows)
                {
                    if (dataGridView.AllowUserToAddRows == true && DR.Index == dataGridView.Rows.Count - 1) break;
                    values = " ( ";
                    string data = "(Select ISNULL(MAX(Code), 0) + 1 From " + jProperties.TableName + "), " + valueObjectCode.ToString();
                    foreach (DataGridViewColumn DC in dataGridView.Columns)
                    {
                        if (DC.Index == 10)
                            JMessages.Error("", "");
                        if (DC.Index < 2) continue;
                        Type columnType = dataTableFormat.Columns[DC.Index].DataType;
                        if (columnType == typeof(string))
                            data += ",N'" + DR.Cells[DC.Index].Value.ToString().Replace("'", "''") + "'";
                        else if (columnType == typeof(DateTime))
                        {
                            DateTime datetime;
                            if (DR.Cells[DC.Index].Value == null) datetime = DateTime.MinValue;
                            else
                                datetime = JDateTime.GregorianDate(DR.Cells[DC.Index].Value.ToString());
                            data += ",CAST('" + datetime.ToString("yyyy-MM-dd HH:mm:ss") + "' AS date)";
                        }
                        else if (columnType == typeof(int) || columnType == typeof(decimal) || columnType == typeof(float) || columnType == typeof(double))
                            data += "," + ((DR.Cells[DC.Index].Value == null || DR.Cells[DC.Index].Value.ToString().Trim().Length == 0) ? "0" : DR.Cells[DC.Index].Value.ToString().Replace("'", "''"));
                        else if (columnType == typeof(bool))
                            data += "," + ((DR.Cells[DC.Index].Value == null) ? "0" : ((DR.Cells[DC.Index].Value.ToString() == "") ? "0" : (Convert.ToBoolean(DR.Cells[DC.Index].Value) == true ? "1" : "0")));
                    }
                    values += data + ")";
                    result += query + values;
                }

                db.setQuery(result);
                if (db.Query_Execute() >= 0) return true;
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pdb == null) db.Dispose();
            }
        }

        public bool Delete()
        {
            JPropertyTable PT = new JPropertyTable();
            PT.SetValueProperty(this);
            if (PT.Delete())
            {
                if (!PropTables.FindTable())
                    return false;
                _SQLCommand = " DROP COLUMN [" + Name.Replace(" ", "__") + "]";
                PropTables.ChangeTable(_SQLCommand);
                return true;
            }
            return false;
        }

        public bool DeleteByObjectCode(string className, int objectCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From propertydefinetables WHERE ClassName= '" + className + "' AND ObjectCode = " + objectCode);
                db.Query_Execute();
                db.setQuery("DROP TABLE " + (new JProperties(className, objectCode)).TableName);
                db.Query_Execute();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeleteDataByValueObjectCode(JDataBase pdb, string className, int objectCode, int valueObjectCode)
        {
            JDataBase db;
            if (pdb == null) db = new JDataBase();
            else db = pdb;
            try
            {
                db.setQuery("Delete From " + (new JProperties(className, objectCode)).TableName + " WHERE ObjectCode = " + valueObjectCode);
                db.Query_Execute();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pdb == null) db.Dispose();
            }
        }

        public bool DeleteDataByValueObjectCode(JDataBase pdb, string className, int objectCode, int valueObjectCode, int code)
        {
            JDataBase db;
            if (pdb == null) db = new JDataBase();
            else db = pdb;
            try
            {
                db.setQuery("Delete From " + (new JProperties(className, objectCode)).TableName + " WHERE ObjectCode = " + valueObjectCode + " AND Code = " + code.ToString());
                db.Query_Execute();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pdb == null) db.Dispose();
            }
        }

        public bool Update()
        {
            JPropertyTable PT = new JPropertyTable();
            PT.SetValueProperty(this);
            if (PT.Update())
            {
                if (!PropTables.FindTable())
                    return false;
                return true;
            }
            return false;
        }

        public bool UpdateField(int code, string FieldName, string FieldValue)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Update " + (new JProperties(ClassName, ObjectCode)).TableName + " SET [" + FieldName + "] = " + FieldValue + " Where Code = " + code.ToString());
                if (db.Query_Execute() >= 0)
                    return true;
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        #region GetDate,Find
        public DataTable GetDataTable(string className)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT distinct(ObjectCode) as ObjectCode FROM propertydefinetables WHERE ClassName = '" + className + "'");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public int GetFreeObjectCode(string className)
        {
            JDataBase db = new JDataBase();
            try
            {
                int objectCode = 0;
                db.setQuery("SELECT MAX(ObjectCode) + 1 FROM propertydefinetables WHERE ClassName = '" + className.ToString() + "'");
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    if (db.DataReader[0] != DBNull.Value)
                        objectCode = Convert.ToInt32(db.DataReader[0]);
                    else
                        objectCode = 1;
                }
                else
                    objectCode = 1;
                return objectCode;
            }
            finally
            {
                db.Dispose();
            }
        }
        public static string GetDataType(string pPropDataType)
        {
            if (pPropDataType == JSQLDataType.رشته.ToString())
                return " NVARCHAR(max)";
            else
                if (pPropDataType == JSQLDataType.عدد.ToString())
                    return " [INT] ";
                else
                    if (pPropDataType == JSQLDataType.اعشار.ToString())
                        return " [FLOAT] ";
                    else
                        if (pPropDataType == JSQLDataType.پول.ToString())
                            return " [decimal](18, 0) ";
                        else
                            if (pPropDataType == JSQLDataType.تاریخ.ToString())
                                return " [DATETIME] ";
                            else
                                if (pPropDataType == JSQLDataType.تصمیم.ToString())
                                    return " [BIT] ";
                                else
                                    if (pPropDataType == JSQLDataType.اس_کیو_ال.ToString())
                                        return " NVARCHAR(max)";
                                    else
                                        if (pPropDataType == JSQLDataType.زمان.ToString())
                                            return " NVARCHAR(max)";
                                        else
                                            if (pPropDataType == JSQLDataType.رشته_چند_خطی.ToString())
                                                return " NVARCHAR(max)";
            return "";
        }

        public bool GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM propertydefinetables WHERE Code = " + pCode.ToString());
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

        public bool Find(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM propertydefinetables WHERE Code = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void SetDataRow(System.Windows.Forms.DataGridViewRow DR)
        {
            Name = DR.Cells["Name"].Value.ToString();
            Active = Boolean.Parse(DR.Cells["Active"].Value.ToString());
            ClassName = DR.Cells["ClassName"].Value.ToString();
            Code = Int32.Parse(DR.Cells["Code"].Value.ToString());
            DataType = DR.Cells["DataType"].Value.ToString();
            DefaultValue = DR.Cells["DefaultValue"].Value.ToString();
            List = DR.Cells["List"].Value.ToString();
            ListType = DR.Cells["ListType"].Value.ToString();
            ObjectCode = Int32.Parse(DR.Cells["ObjectCode"].Value.ToString());
            Ordered = Int32.Parse(DR.Cells["Ordered"].Value.ToString());
            ListCanEdit = DR.Cells["ListCanEdit"].Value.ToString();
            ListCanView = DR.Cells["ListCanView"].Value.ToString();
        }

        public void SetDataRow(System.Data.DataRow DR)
        {
            JTable.SetToClassProperty(this, DR);
            //Name = DR["Name"].ToString();
            //Active = Boolean.Parse(DR["Active"].ToString());
            //ClassName = DR["ClassName"].ToString();
            //Code = Int32.Parse(DR["Code"].ToString());
            //DataType = DR["DataType"].ToString();
            //DefaultValue = DR["DefaultValue"].ToString();
            //List = DR["List"].ToString();
            //ListType = DR["ListType"].ToString();
            //Ordered = Int32.Parse(DR["Ordered"].ToString());
            //ObjectCode = Int32.Parse(DR["ObjectCode"].ToString());
        }

        #endregion

        #region Control
        public System.Windows.Forms.Control CreateControl()
        {
            return null;
        }
        #endregion

    }

    public class JProperties : JGlobals
    {
        #region Fields
        private string _ClassName;
        private int _ObjectCode;
        public string TableName
        {
            get
            {
                return "[Propperty_ClassName_" + _ClassName + "_" + _ObjectCode.ToString() + "]";
            }
        }
        #endregion

        #region Constructor

        public JProperties(string pClassName, int pObjectCode)
        {
            _ClassName = pClassName;
            _ObjectCode = pObjectCode;
        }
        #endregion

        #region GetData
        /// <summary>
        /// کلاسهایی که برای آنها ویژگی تعریف شده را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataTable GetAllProperties()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"Select Distinct IsNull( dic.text,ClassName) FaClassName , ClassName  FROM [dbo].[propertydefinetables] properties
                Left Join dic on properties.ClassName = dic.Name");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public static System.Data.DataTable GetAllObjectCode(string pClassName)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"Select Distinct IsNull( dic.text,ClassName) FaClassName , ClassName, ObjectCode  FROM [dbo].[propertydefinetables] properties
                Left Join dic on properties.ClassName = dic.Name WHERE ClassName = " + JDataBase.Quote(pClassName));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public System.Data.DataTable GetDataTable(bool orderDESC = true)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT [Code] ,Replace([Name], '__', ' ') Name ,[ClassName] ,[ObjectCode] ,[DataType] ,[ListType] ,[DefaultValue]
                            ,[Ordered] ,[Active] ,[List],[ListCanView],[ListCanEdit]   FROM [propertydefinetables] WHERE ClassName=" +
                           JDataBase.Quote(_ClassName) + " AND ObjectCode=" + _ObjectCode.ToString() + " ORDER BY Ordered " + (orderDESC == true ? "DESC" : "ASC"));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public System.Data.DataTable GetBaseDataTable()
        {
            return GetBaseDataTable("DESC");
        }
        public System.Data.DataTable GetBaseDataTable(string OrderType)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT [Code] ,[Name],[ClassName] ,[ObjectCode] ,[DataType] ,[ListType] ,[DefaultValue]
                            ,[Ordered] ,[Active] ,[List],[ListCanView],[ListCanEdit]   FROM [propertydefinetables] WHERE ClassName=" +
                    JDataBase.Quote(_ClassName) + " AND ObjectCode=" + _ObjectCode.ToString() + " ORDER BY Ordered " + OrderType);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<int> GetPropertyTableDataCode(int valueObjectCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = "Select f.[Code] FROM " + TableName + " f WHERE f.ObjectCode = " + valueObjectCode.ToString();
                db.setQuery(query);
                return db.Query_DataTable().AsEnumerable().Select(m => Convert.ToInt32(m["Code"])).ToList();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetPropertyTableData(int valueObjectCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                /*                string query = @"SELECT 
                                                  COLUMN_NAME
                                                  ,DATA_TYPE
                                                FROM   
                                                  INFORMATION_SCHEMA.COLUMNS 
                                                WHERE   
                                                  TABLE_NAME = '{TABLE_NAME}' 
                                                ORDER BY 
                                                  ORDINAL_POSITION ASC; ";
                                query = query.Replace("{TABLE_NAME}", TableName.Replace("[", "").Replace("]", ""));*/
                string query = @"SELECT [Name] as [COLUMN_NAME]
                                      ,[DataType] as [DATA_TYPE]
                                  FROM [propertydefinetables] 
                                  where ClassName = N'{CLASSNAME}' and ObjectCode = {OBJECTCODE}
                                  order by Ordered";
                query = query.Replace("{CLASSNAME}", _ClassName.ToString()).Replace("{OBJECTCODE}", _ObjectCode.ToString());
                db.setQuery(query);
                DataTable tmp = db.Query_DataTable();
                query = "";
                foreach (DataRow dr in tmp.Rows)
                {
                    query += ", f.[" + dr["COLUMN_NAME"].ToString().Replace(" ", "__") + "]";
                }
                query = "Select f.[Code], f.[ObjectCode]" + query + " FROM " + TableName + " f WHERE f.ObjectCode = " + valueObjectCode.ToString();
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetPropertyTableDataForPrint(int valueObjectCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                /*                string query = @"SELECT 
                                                  COLUMN_NAME
                                                  ,DATA_TYPE
                                                FROM   
                                                  INFORMATION_SCHEMA.COLUMNS 
                                                WHERE   
                                                  TABLE_NAME = '{TABLE_NAME}' 
                                                ORDER BY 
                                                  ORDINAL_POSITION ASC; ";
                                query = query.Replace("{TABLE_NAME}", TableName.Replace("[", "").Replace("]", ""));*/
                string query = @"SELECT [Name] as [COLUMN_NAME]
                                      ,[DataType] as [DATA_TYPE]
                                  FROM [propertydefinetables] 
                                  where ClassName = N'{CLASSNAME}' and ObjectCode = {OBJECTCODE}
                                  order by Ordered";
                query = query.Replace("{CLASSNAME}", _ClassName.ToString()).Replace("{OBJECTCODE}", _ObjectCode.ToString());
                db.setQuery(query);
                DataTable tmp = db.Query_DataTable();
                query = "";
                foreach (DataRow dr in tmp.Rows)
                {
                    if (dr["DATA_TYPE"].ToString() == JSQLDataType.تاریخ.ToString())
                        query += ", (Select Fa_Date from StaticDates where En_Date = CAST(f.[" + dr["COLUMN_NAME"].ToString().Replace(" ", "__") + "] as DATE)) as [" + dr["COLUMN_NAME"].ToString() + "]";
                    else
                        query += ", f.[" + dr["COLUMN_NAME"].ToString().Replace(" ", "__") + "]";
                }
                query = "Select f.[Code], f.[ObjectCode]" + query + " FROM " + TableName + " f WHERE f.ObjectCode = " + valueObjectCode.ToString();
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public object GetValue(string pFieldName, int pObjectCode)
        {
            string Query = "SELECT " + pFieldName + " FROM " + TableName + " WHERE ObjectCode=" + pObjectCode.ToString();
            return null;

        }
        #endregion

    }

    public class JPropertyTables : JGlobals
    {
        #region Fields
        private string _ClassName;
        private int _ObjectCode;
        public bool HasTableName;
        public string TableName
        {
            get
            {
                string _tname = "[Propperty_ClassName_" + _ClassName + "_" + _ObjectCode.ToString() + "]";
                JDataBase db = new JDataBase();
                try
                {
                    db.setQuery(@"IF  EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo]." + _tname + @"') AND type in (N'U'))
begin
select 1
end
");
                    DataTable _DT = db.Query_DataTable();
                    if (_DT.Rows.Count == 1)
                    {
                        HasTableName = true;
                        return _tname;
                    }
                    else
                    {
                        HasTableName = false;
                        return _tname;
                    }
                }
                catch
                {
                    HasTableName = false;
                    return _tname;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
        public string FieldNames
        {
            get
            {
                string fn = "";
                string[] fns = getFeildsName();
                for (int i = 2; i < fns.Length; i++)
                {
                    fn += ", PTable." + fns[i];
                }
                return fn;
            }
        }
        #endregion

        #region Constructor
        public JPropertyTables(string pClassName, int pObjectCode)
        {
            _ClassName = pClassName;
            _ObjectCode = pObjectCode;
        }
        #endregion

        #region CreateTable, ChangeTable, DropTable, ReverseTable, FindTable, BackupTable, RestoreTable
        public void CreateTable()
        {
            if (!FindTable())
            {
                JDataBase DB = new JDataBase();
                try
                {
                    DB.setQuery(
                    @"CREATE TABLE [dbo]." + TableName + @"(
            [Code] [int] NOT NULL,
            [ObjectCode] [int] NOT NULL,
            [RegisterPostCode] [int] NOT NULL,
            CONSTRAINT [PK_" + TableName.Replace("[", "").Replace("]", "") + @"] PRIMARY KEY CLUSTERED 
                (
	                [Code] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
            ) ON [PRIMARY]");
                    DB.Query_Execute();
                }
                finally
                {
                    DB.Dispose();
                }
            }
        }

        public void ChangeTable(string pCommand)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("ALTER TABLE [dbo]." + TableName + "" + pCommand);
                DB.Query_Execute();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void DropTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo]." + TableName + @"') AND type in (N'U'))
                            DROP TABLE [dbo]." + TableName);
                DB.Query_Execute();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ReverseTable()
        {
        }
        public bool FindTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo]." + TableName + @"') AND type in (N'U')");
                DB.Query_DataReader();
                return DB.DataReader.HasRows;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void BackupTable()
        {
        }

        public void RestoreTable()
        {
        }

        #endregion

        #region Data
        public System.Data.DataTable GetData(int pValueObjectCode, bool IsWeb = false)
        {
            return GetData(pValueObjectCode, 0, IsWeb);
        }

        public string getSQL(int pValueObjectCode, int TableCode, bool IsWeb)
        {
            string Query = "";
            string FieldsName = "";
            List<string> ColumnsName = new List<string>();
            JProperties Ps = new JProperties(_ClassName, _ObjectCode);

            System.Data.DataTable DT = Ps.GetDataTable();
            if (DT == null || DT.Rows.Count == 0)
                return "";
            FieldsName = "case when P.[Code] is null then F.Code else P.Code end Code,P.[ObjectCode],[RegisterPostCode]";
            ColumnsName.AddRange(new List<string>() { "Code", "ObjectCode", "RegisterPostCode" });
            if (IsWeb)
            {
                foreach (System.Data.DataRow DR in DT.Rows)
                {
                    if (DR["DataType"].ToString().Trim() == "تاریخ")
                    {
                        FieldsName += ",cast(p.[" + DR["Name"].ToString().Replace(" ", "__") + "] as date) [" + DR["Name"].ToString().Replace(" ", "__") + ']';
                    }
                    else
                    {
                        FieldsName += ",p.[" + DR["Name"].ToString().Replace(" ", "__") + ']';
                    }
                    ColumnsName.Add(DR["Name"].ToString().Replace(" ", "__"));
                }
            }
            //else
            //{
            //    foreach (System.Data.DataRow DR in DT.Rows)
            //    {
            //        if (DR["DataType"].ToString().Trim() == "تاریخ")
            //            FieldsName += ",(select top 1 Fa_Date from StaticDates where EN_date=cast([" + DR["Name"].ToString().Replace(" ", "__") + "] as date)) [" + DR["Name"].ToString().Replace(" ", "__") + ']';
            //        else
            //            FieldsName += ",[" + DR["Name"].ToString().Replace(" ", "__") + ']';
            //    }
            //    Query = "select * from (SELECT " + FieldsName + ",(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate FROM " + TableName + " p left join FormObjects F on F.Code=p.ObjectCode) as " + TableName;
            //}
            ColumnsName.Add("Nowdate");

            JForms form = new JForms(_ObjectCode);
            string sql = form.SQL;
            DataTable dt =  WebClassLibrary.JWebDataBase.GetDataTable("Select TOP 0 * from (" + sql.Replace("@ObjectCode", "-1") + ") tbl ", false);

            foreach (DataColumn dc in dt.Columns)
            {
                if (ColumnsName.Contains(dc.ColumnName))
                    FieldsName += ", a.[" + dc.ColumnName + "] " + dc.ColumnName + "1";
                else
                    FieldsName += ", a.[" + dc.ColumnName + "]";
            }

            Query = "SELECT " + FieldsName + ",cast(getdate() as date) Nowdate FROM " + TableName + " p left join FormObjects F on F.Code=p.ObjectCode OUTER APPLY ( " +
                sql.Replace("@ObjectCode", "(select ObjectCode from FormObjects WHERE Code = p.ObjectCode)") + ") as a";
            if (TableCode == 0)
				Query = Query + " WHERE p.ObjectCode=" + pValueObjectCode.ToString();
            else
				Query = Query + " WHERE p.ObjectCode=" + pValueObjectCode.ToString() + " AND Code = " + TableCode.ToString();
            return Query;
        }
        public System.Data.DataTable GetData(int pValueObjectCode, int TableCode, bool IsWeb = false)
        {
            string Query = "";
            Query = getSQL(IsWeb);
			if (Query.Length == 0)
				return null;
            if (TableCode == 0)
				Query = Query + " WHERE ObjectCode=" + pValueObjectCode.ToString();
            else
				Query = Query + " WHERE ObjectCode=" + pValueObjectCode.ToString() + " AND Code = " + TableCode.ToString();

            JDataBase DB = new JDataBase();
            System.Data.DataTable table;
            try
            {
                DB.setQuery(Query);
                table = DB.Query_DataTable();
                return table;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert(System.Data.DataRow pDR, JDataBase pDB)
        {
            try
            {
                if (pDR == null)
                    return 0;
                JDataBase DB;
                if (pDB == null)
                    DB = new JDataBase();
                else
                    DB = pDB;
                try
                {
					foreach (string Field in getFeildsName())
                    {
                        try
                        {
							if (Field.ToLower() != "[code]" && Field.ToLower() != "[registerpostcode]")
                                DB.AddParams(Field.Replace("[", "").Replace("]", ""), pDR[Field.Replace("[", "").Replace("]", "")]);
                        }
                        catch { }
                        finally { }
                    }
					DB.AddParams("RegisterPostCode", JMainFrame.CurrentPostCode);

                    string Fields = String.Join(",", getFeildsName());
                    string Values = String.Join(",", getFeildsParam());

                    DB.setQuery(
                        @"DECLARE @Code INT " +
                        JDataBase.GetInsertSQL(TableName.Replace("[", "").Replace("]", "")) +

                @"insert into " + TableName + " (" + Fields + ") values(" + Values + @")
                SELECT @Code");
                    return (int)DB.Query_ExecutSacler();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (pDB == null)
                        DB.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return 0;
        }

        public bool Update(System.Data.DataRow pDR, JDataBase pDB)
        {
            try
            {
                JDataBase DB = pDB;
				if (pDB == null)
					DB = new JDataBase();
                try
                {
                    foreach (string Field in getFeildsName())
                    {
                        if (Field.ToLower() != "[code]")
                            DB.AddParams(Field.Replace("[", "").Replace("]", ""), pDR[Field.Replace("[", "").Replace("]", "")]);
                    }

                    string Fields = String.Join(",", getFeildsNameParam());

                    DB.setQuery("UPDATE " + TableName + " SET " + Fields + " WHERE Code=" + pDR["Code"].ToString());
                    DB.Query_ExecutSacler();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

                finally
                {
					if (pDB == null)
						DB.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool Delete(int pCode)
        {
            return true;
        }

        #endregion

        #region SQL
        public string getSQL(bool IsWeb = false)
        {
            string FieldsName = "";
            JProperties Ps = new JProperties(_ClassName, _ObjectCode);

            System.Data.DataTable DT = Ps.GetDataTable();
            if (DT == null || DT.Rows.Count == 0)
                return "";
            FieldsName = "case when P.[Code] is null then F.Code else P.Code end Code,P.[ObjectCode],[RegisterPostCode]";
            if (IsWeb)
            {
                foreach (System.Data.DataRow DR in DT.Rows)
                {
                    if (DR["DataType"].ToString().Trim() == "تاریخ")
                        FieldsName += ",cast([" + DR["Name"].ToString().Replace(" ", "__") + "] as date) [" + DR["Name"].ToString().Replace(" ", "__") + ']';
                    else
                    //if (DR["DataType"].ToString().Trim() == "تصمیم")
                    //    FieldsName += ",case ISNULL([" + DR["Name"].ToString().Replace(" ", "__") + "],0) when 1 then N'بلی' else N'خیر' END '" + DR["Name"].ToString().Replace(" ", "__") + "'";
                    //else
                        FieldsName += ",[" + DR["Name"].ToString().Replace(" ", "__") + ']';
                }
                return "select * from (SELECT " + FieldsName + ",cast(getdate() as date) Nowdate FROM " + TableName + " p left join FormObjects F on F.Code=p.ObjectCode) as " + TableName;
            }
            else
            {
                foreach (System.Data.DataRow DR in DT.Rows)
                {
                    if (DR["DataType"].ToString().Trim() == "تاریخ")
                        FieldsName += ",(select top 1 Fa_Date from StaticDates where EN_date=cast([" + DR["Name"].ToString().Replace(" ", "__") + "] as date)) [" + DR["Name"].ToString().Replace(" ", "__") + ']';
                    else
                    //if (DR["DataType"].ToString().Trim() == "تصمیم")
                    //    FieldsName += ",case ISNULL([" + DR["Name"].ToString().Replace(" ", "__") + "],0) when 1 then N'بلی' else N'خیر' END '" + DR["Name"].ToString().Replace(" ", "__") + "'";
                    //else
                        FieldsName += ",[" + DR["Name"].ToString().Replace(" ", "__") + ']';
                }
                return "select * from (SELECT " + FieldsName + ",(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate FROM " + TableName + " p left join FormObjects F on F.Code=p.ObjectCode) as " + TableName;
            }
        }

        public string[] getFeildsName()
        {
            JProperties Ps = new JProperties(_ClassName, _ObjectCode);

            System.Data.DataTable DT = Ps.GetDataTable();
            string[] FieldsName = new string[DT.Rows.Count + 3];
            int i = 3;
            FieldsName[0] = "[Code]";
			FieldsName[1] = "[ObjectCode]";
			FieldsName[2] = "[RegisterPostCode]";
			foreach (System.Data.DataRow DR in DT.Rows)
            {
                FieldsName[i++] = '[' + DR["Name"].ToString().Replace(" ", "__") + ']';
            }
            return FieldsName;
        }

		public string getFieldsNameTable(string pTableName)
		{
			List<string> Res = new List<string>();
			string[] temps = getFeildsName();
			for(int i=2;i<temps.Length;i++)
			{
				Res.Add(pTableName + '.' + temps[i]);
			}
			return string.Join(",", Res.ToArray());
		}
        public string[] getFeildsName(bool pWithCode)
        {
            JProperties Ps = new JProperties(_ClassName, _ObjectCode);

            System.Data.DataTable DT = Ps.GetDataTable();
            string[] FieldsName = new string[DT.Rows.Count + 3];
            int i = 3;
            if (pWithCode)
                FieldsName[0] = "[Code]";
			FieldsName[1] = "[ObjectCode]";
			FieldsName[2] = "[RegisterPostCode]";
			foreach (System.Data.DataRow DR in DT.Rows)
            {
                FieldsName[i++] = '[' + DR["Name"].ToString().Replace(" ", "__") + ']';
            }
            return FieldsName;
        }

        public string[] getFeildsParam()
        {
            JProperties Ps = new JProperties(_ClassName, _ObjectCode);

            System.Data.DataTable DT = Ps.GetDataTable();
            string[] FieldsName = new string[DT.Rows.Count + 3];
            int i = 3;
            FieldsName[0] = "@Code";
			FieldsName[1] = "@ObjectCode";
			FieldsName[2] = "@RegisterPostCode";
			foreach (System.Data.DataRow DR in DT.Rows)
            {
                FieldsName[i++] = "@" + DR["Name"].ToString().Replace(" ", "__") + "";
            }
            return FieldsName;
        }

        public string[] getFeildsNameParam()
        {
            JProperties Ps = new JProperties(_ClassName, _ObjectCode);

            System.Data.DataTable DT = Ps.GetDataTable();
            string[] FieldsName = new string[DT.Rows.Count];
            int i = 0;
            foreach (System.Data.DataRow DR in DT.Rows)
            {
                FieldsName[i++] = '[' + DR["Name"].ToString().Replace(" ", "__") + ']' + " = @" + DR["Name"].ToString().Replace(" ", "__") + "";
            }
            return FieldsName;
        }
        #endregion
    }
}
