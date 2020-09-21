using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.IO;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Security.AccessControl;

namespace ERP
{
	public partial class JMappingForm : Form
	{
		public JMappingForm()
		{
			InitializeComponent();
		}

		//public void AddDirectorySecurity(string FileName, string Account = @"tarrahanzarrin\mohseni", FileSystemRights Rights = FileSystemRights.FullControl, AccessControlType ControlType = AccessControlType.Allow)
		//{
		//	// Create a new DirectoryInfo object.
		//	DirectoryInfo dInfo = new DirectoryInfo(FileName);

		//	// Get a DirectorySecurity object that represents the  
		//	// current security settings.
		//	DirectorySecurity dSecurity = dInfo.GetAccessControl();

		//	// Add the FileSystemAccessRule to the security settings. 
		//	dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
		//													Rights,
		//													ControlType));

		//	// Set the new access settings.
		//	dInfo.SetAccessControl(dSecurity);

		//}
		const string PropertyTrailer = " { get; set; }";
		const string FieldTrailer = ";";
		string GetPropertiesString(DataTable dt, bool isProperty = true)
		{
			string str = "#region " + (isProperty ? "Properties" : "Fields");
			for (int i = 0; i < dt.Rows.Count; i++)
				if (!isProperty && dt.Rows[i][1].ToString().ToLower() == "code")
					continue;
				else
					str += "\r\npublic " + GetSystemType(dt.Rows[i][2].ToString()) + dt.Rows[i][1].ToString() + (isProperty ? PropertyTrailer : FieldTrailer);
			return str + "#endregion";
		}

		private void submit_Click_1(object sender, EventArgs e)
		{
			//string tableName = table.Text;
			string assembly = Assembly.Text;
			string query = "SELECT TABLE_NAME tbl,COLUMN_NAME col,DATA_TYPE type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + table.Text + "'";
			//List<string> columns = new List<string>();
			JDataBase db = new JDataBase();
			db.setQuery(query);
			//db.Connect();
			//db.Query_DataReader();
			//SqlDataReader dr = db.DataReader;
			DataTable dt = db.Query_DataTable();
			//if (dr.Read())
			//{

			//	string lstrOldTableName = string.Empty;
			//	StreamWriter sw = null;
			//	System.Text.StringBuilder sb = null;
			//	System.Text.StringBuilder sbAttr = null;

			//	while (dr.Read())
			//	{
			//		string lstrTableName = dr.GetString(2);
			//		string lstrAttributeName = dr.GetString(3);
			//		string lstrAttributeType = GetSystemType(dr.GetString(7));
			//		if (lstrOldTableName != lstrTableName)
			//		{
			//			if (sw != null)
			//			{
			//				this.CreateClassBottom(sw, sb.ToString().TrimEnd(
			//						   new char[] { ',', ' ', '\r', '\t', '\n' }),
			//						   sbAttr.ToString());
			//				sw.Close();
			//			}
			//			sb = new System.Text.StringBuilder(lstrTableName);
			//			sb.Append(".cs");
			//			FileInfo lobjFileInfo = new FileInfo(sb.ToString());
			//			sw = lobjFileInfo.CreateText();
			//			this.CreateClassTop(sw, lstrTableName);
			//			sb = new System.Text.StringBuilder("\r\n\t/// \r\n\t" +
			//				 "/// User defined Contructor\r\n\t/// \r\n\tpublic ");
			//			sbAttr = new System.Text.StringBuilder();
			//			sb.Append(lstrTableName);
			//			sb.Append("() {}");
			//			sb.Append(new System.Text.StringBuilder("\r\n\t/// \r\n\t" +
			//				 "/// User defined Contructor\r\n\t/// \r\n\tpublic "));
			//			sb.Append(lstrTableName);
			//			sb.Append("(int pcode){Code = pCode; if (Code > 0) GetData(Code);}");
			//		}
			//		else
			//		{
			//			this.CreateClassBody(sw, lstrAttributeType, lstrAttributeName); ///*************ra
			//			sb.AppendFormat("{0} {1}, \r\n\t\t",
			//			   new object[] { lstrAttributeType, lstrAttributeName });
			//			sbAttr.AppendFormat("\r\n\t\tthis._{0} = {0};",
			//			   new object[] { lstrAttributeName });
			//		}
			//		lstrOldTableName = lstrTableName;
			//		//System.IO.TextWriter w = new System.IO.StreamWriter(destination.Text);
			//		//w.Write(sb.ToString());
			//		//w.Flush();
			//		//w.Close();
			//	}
			////File.SetAttributes(destination.Text, FileAttributes.Normal);
			////AddDirectorySecurity(destination.Text);
			////File.WriteAllText(destination.Text, sb.ToString());
			//richTextBox1.Text = sb.ToString();
			//}
			if (dt == null || dt.Rows.Count <= 0)
				return;
			string tableName = dt.Rows[0][0].ToString();
			string usingStr = @"using ClassLibrary;
								using System;
								using System.Collections.Generic;
								using System.Data;
								using System.Linq;
								using System.Text;

								namespace " + assembly + @"
								{
									public class J" + tableName +
									"{";
			string props = GetPropertiesString(dt);
			string bodyStr = @"			#region Constructors
										public JSLADefine()
										{
										}

										public J" + tableName + @"(int pCode)
										{
											Code = pCode;
											if (Code > 0)
												GetData(Code);
										}

										#endregion

										#region Methods

										public int Insert(JDataBase db = null)
										{
											J" + tableName + @"Table ST = new J" + tableName + @"Table();
											ST.SetValueProperty(this);
											if (db == null)
												Code = ST.Insert();
											else
												Code = ST.Insert(db);
											return Code;
										}
										public bool Delete()
										{
											J" + tableName + @"Table ST = new J" + tableName + @"Table();
											ST.SetValueProperty(this);
											return ST.Delete();
										}
										public bool Update()
										{
											J" + tableName + @"Table ST = new J" + tableName + @"Table();
											ST.SetValueProperty(this);
											return ST.Update();
										}

										public bool GetData(int pCode)
										{
											JDataBase DB = new JDataBase();
											try
											{
												DB.setQuery(" + "\"SELECT * FROM " + tableName + " WHERE Code = \"" + @" + pCode.ToString());
												DB.Query_DataReader();
												if (DB.DataReader.Read())
												{
													JTable.SetToClassProperty(this, DB.DataReader);
													return true;
												}
												return false;
											}
											finally
											{
												DB.Dispose();
											}
										}

										#endregion
									}

									public class J" + tableName + @"s
									{
										public static DataTable GetDataTable()
										{
											JDataBase DB = new JDataBase();
											try
											{
												DB.setQuery(" + "\"SELECT * FROM " + tableName + "\"" + @");
												return DB.Query_DataTable();
											}
											finally
											{
												DB.Dispose();
											}
										}
									}\r\n}";
			string table1Class = usingStr + props + bodyStr;
			string table2Class = usingStr + @"  public class J" + tableName + @"Table : JTable
									{
										public J" + tableName + @"Table()
											: base(" + "\"" + tableName + "\"" + @")
										{
										}" +
										  GetPropertiesString(dt, false)
										  + @"
									}\r\n}";
			richTextBox1.Text = table1Class;
			richTextBox2.Text = table2Class;
			tabPage2.Select();
		}

		//private void CreateClassTop(StreamWriter sw, string tstrClassName)
		//{
		//	System.Text.StringBuilder sb = new System.Text.StringBuilder("public class ");
		//	sb.Append(tstrClassName);
		//	sb.Append("\r\n{\r\n\t/// <summary>\r\n\t/// Default Contructor\r\n\t/// <summary>\r\n\tpublic ");
		//	sb.Append(tstrClassName);
		//	sb.Append("()\r\n\t{}");
		//	sw.WriteLine(sb.ToString());
		//}

		///// <summary>
		///// Create the Bottom part of the current file
		///// </summary>
		///// <param name="sw">Stream Writer of the current file</param>
		///// <param name="tstrAttrbuteList">List of variables to be used with the user defined contructor</param>
		//private void CreateClassBottom(StreamWriter sw, string tstrAttrbuteList, string tstrVariableList)
		//{
		//	sw.WriteLine(tstrAttrbuteList + ")\r\n\t{" + tstrVariableList + "\r\n\t}");
		//	sw.WriteLine("}");
		//}

		//private void CreateClassBody(StreamWriter sw, string tstrAttributeType, string tstrAttributeName)
		//{
		//	System.Text.StringBuilder sb = new System.Text.StringBuilder("\r\n");
		//	sb.AppendFormat("\r\n\tpublic {0} {1}\r\n\t{2} \r\n\t\tget {2} return _{1}; {3}\r\n\t\tset {2} _{1} = value; {3}\r\n\t{3}\r\n\tprivate {0} _{1};", new object[] { tstrAttributeType, tstrAttributeName, "{", "}" });
		//	sw.WriteLine(sb.ToString());
		//}

		private string GetSystemType(string tstrSqlType)
		{
			string _Type = string.Empty;

			switch (tstrSqlType)
			{
				case "biginit":
					{
						_Type = "long ";
					} break;
				case "smallint":
					{
						_Type = "short ";
					} break;
				case "tinyint":
					{
						_Type = "byte ";
					} break;
				case "int":
					{
						_Type = "int ";
					} break;
				case "bit":
					{
						_Type = "bool ";
					} break;
				case "decimal":
				case "numeric":
					{
						_Type = "decimal ";
					} break;
				case "money":
				case "smallmoney":
					{
						_Type = "decimal ";
					} break;
				case "float":
				case "real":
					{
						_Type = "float ";
					} break;
				case "datetime":
				case "smalldatetime":
					{
						_Type = "System.DateTime ";
					} break;
				case "char":
					{
						_Type = "char ";
					} break;
				case "sql_variant":
					{
						_Type = "object ";
					} break;
				case "varchar":
				case "text":
				case "nchar":
				case "nvarchar":
				case "ntext":
					{
						_Type = "string ";
					} break;
				case "binary":
				case "varbinary":
					{
						_Type = "byte[] ";
					} break;
				case "image":
					{
						_Type = "System.Drawing.Image ";
					} break;
				case "timestamp":
				case "uniqueidentifier":
					{
						_Type = "string ";
					} break;
				default:
					{
						_Type = "void ";
					} break;
			}
			return _Type;
		}


		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				//
				// The user selected a folder and pressed the OK button.
				// We print the number of files found.
				//
				//string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
				//MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
				destination.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		//private void submit_Click_1(object sender, EventArgs e)
		//{

		//}

	}
}
