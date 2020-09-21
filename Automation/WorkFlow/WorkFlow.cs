using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Automation
{
    public enum JNodeType
    {
        Start = 1,//شروع
        End = 2,//پایان
        NonEmployment = 3,//بر اساس چارت
        Employment = 4,//یک یا چند پست مشخص همه در یک رکورد
        EmploymentManager = 5,//مدیر پست فعال
        PreviousEmployment = 6,// پست قبلی ارسال کننده
        FirstEmployment = 7,//اولین ارجا دهنده
        FlowEmployment = 8,//افرادی که در گردش بوده اند
        Trash = 9,//سطل زباله
        Chart = 10,//همه چارت
        SQL = 11,//SQL Query
		SepratedEmployment = 12,//یک یا چند پست مشخص هر کدام در یک رکورد مجزا
		NonEmploymentWithOutUnit = 13,//بر اساس چارت بدون واحد

    }

    public class JWorkFlow : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public JNodeType NodeType { get; set; }
        public int Ordered { get; set; }
        public string PostCode { get; set; }
        public string ClassName { get; set; }
        public int DynamicClassCode { get; set; }
        public string Condition { get; set; }
        public string NextNodes { get; set; }
        public string SQL { get; set; }
        public string Action { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int ReferCode;

        public DataTable _PublicDataRow;

        public JWorkFlow()
        {
        }

        public JWorkFlow(DataTable pDataRow, int pReferCode)
        {
            if (pDataRow != null)
            {
                DataTable _DT = pDataRow.Copy();
                if (_DT.Columns.IndexOf("WorkFlowCondition") >= 0)
                    _DT.Columns.Remove("WorkFlowCondition");
                _PublicDataRow = _DT;
            }
            ReferCode = pReferCode;
        }

        public int Insert()
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            WT.SetValueProperty(this);
            Code = WT.Insert();
            return Code;
        }

        public bool Update()
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            WT.SetValueProperty(this);
            return WT.Update();
        }

        public bool Delete()
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            WT.SetValueProperty(this);
            return WT.Delete();
        }

        public bool GetData(int pCode, string pClassName, int pDynamicClassCode, int Ordered = 0)
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            string SQL = "";
            if (pCode != 0)
            {
                SQL = WT.CreateQuery(" AND Code = " + pCode.ToString());
            }
            else
            {
                SQL = WT.CreateQuery(
        " AND ClassName = " + JDataBase.Quote(pClassName) +
        " AND DynamicClassCode = " + JDataBase.Quote(pDynamicClassCode.ToString()) +
        " AND Ordered = " + Ordered);
            }

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(SQL);
                DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count > 0)
                {
                    jWorkFlowTable.SetToClassProperty(this, DT.Rows[0]);
                }
                return true;
            }
            catch (Exception ex)
            {
                //JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void SetWorkFlowCondition()
        {
            try
            {
                DataColumn DC = new DataColumn("WorkFlowCondition");
                DC.Expression = ClassLibrary.JGeneral.ConvertToPersian(Condition);
                _PublicDataRow.Columns.Add(DC);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
        }

        private string GetPostCode(string pPostCode)
        {
			string PostsTemp = "";
            string[] Posts = pPostCode.Split(new char[] { ';', ',' });

            int Num;
            for (int i = 0; i < Posts.Length; i++)
            {
                if (int.TryParse(Posts[i], out Num))
                {
                }
                else
                {
                    try
                    {
						if (_PublicDataRow.Rows[0][Posts[i]].ToString().Trim().Length > 0)
							Posts[i] = _PublicDataRow.Rows[0][Posts[i]].ToString();
						else
							Posts[i] = "0";
                    }
                    catch
                    {
                        Posts[i] = "0";
                    }
                }
            }
            return string.Join(";", Posts).Replace(";", ",");
        }

        public DataTable GetPosts()
        {
            int CurrentPostCode = 0;
            if (ReferCode == 0 && _PublicDataRow.Columns.IndexOf("PostCode") != -1 && _PublicDataRow.Rows.Count > 0)
                CurrentPostCode = int.Parse(_PublicDataRow.Rows[0]["PostCode"].ToString());
            else
                CurrentPostCode = ClassLibrary.JMainFrame.CurrentPostCode;
            Employment.JEOrganizationChart OC = new Employment.JEOrganizationChart();
            switch (NodeType)
            {
                case JNodeType.Employment:
                    DataTable DT = Employment.JEOrganizationChart.GetPost(GetPostCode(PostCode), false);
                    JDataTable _DT = new JDataTable();

                    _DT.Columns.Add("Job");
                    _DT.Columns.Add("Code");
                    _DT.Columns.Add("Full_Title");
                    _DT.Columns.Add("Ordered");
                    DataRow _DR = _DT.NewRow();
                    string Semi = "";
                    foreach (DataRow DR in DT.Rows)
                    {
                        _DR["Job"] += Semi + DR["Job"].ToString();
                        _DR["Code"] += Semi + DR["Code"].ToString();
                        _DR["Full_Title"] += Semi + DR["Full_Title"].ToString();
                        Semi = ";";
                    }
                    _DT.Rows.Add(_DR);
                    _DT.AcceptChanges();
                    return _DT;
                    break;
                case JNodeType.SepratedEmployment:
                    DataTable DT2 = Employment.JEOrganizationChart.GetPost(GetPostCode(PostCode), false);
                    JDataTable _DT2 = new JDataTable();

                    _DT2.Columns.Add("Job");
                    _DT2.Columns.Add("Code");
                    _DT2.Columns.Add("Full_Title");
                    foreach (DataRow DR2 in DT2.Rows)
                    {
                        DataRow _DR2 = _DT2.NewRow();
                        _DR2["Job"] = DR2["Job"].ToString();
                        _DR2["Code"] = DR2["Code"].ToString();
                        _DR2["Full_Title"] = DR2["Full_Title"].ToString();
                        _DT2.Rows.Add(_DR2);
                    }
                    _DT2.AcceptChanges();
                    return _DT2;
                    break;
                case JNodeType.EmploymentManager:
                    return Employment.JEOrganizationChart.GetPost(CurrentPostCode, true);
                    break;
                case JNodeType.End:
                    return Employment.JEOrganizationChart.GetPost(PostCode, false);
                    break;
				case JNodeType.NonEmployment:
					return OC.GetChart(CurrentPostCode, 1);
					break;

				case JNodeType.NonEmploymentWithOutUnit:
					return OC.GetChart(CurrentPostCode, 1,false);
					break;
				
				case JNodeType.Start:
                    return null;
                    break;
                case JNodeType.FirstEmployment:
                    JARefer Ref = JARefer.FirstRefer(ReferCode);
                    return Employment.JEOrganizationChart.GetPost(Ref.sender_post_code, false);
                    break;
                case JNodeType.FlowEmployment:
                    break;
                case JNodeType.PreviousEmployment:
                    JARefer _Refer = new JARefer(ReferCode);
                    return Employment.JEOrganizationChart.GetPost(_Refer.sender_post_code, false);
                    break;
                case JNodeType.Trash:
                    return Employment.JEOrganizationChart.GetPost(PostCode, false);
                    break;
                case JNodeType.Chart:
                    return Employment.JEOrganizationChart.GetAllData();
                    break;
                case JNodeType.SQL:
                    string sql = PostCode; // in this state PostCode is used for SQL Query
                    JDataBase db = new JDataBase();
                    try
                    {
                        db.setQuery(sql);
                        if (_PublicDataRow != null && _PublicDataRow.Rows.Count > 0)
                            foreach (DataColumn col in _PublicDataRow.Columns)
                            {
                                db.AddParams(col.ColumnName, _PublicDataRow.Rows[0][col.ColumnName].ToString()); 
                            }
                        return db.Query_DataTable();
                    }
                    finally
                    {
                        db.Dispose();
                    }
                    break;
            }
            return null;
        }

        public void GetFirst()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM WorkFlowNode WHERE ClassName='" + ClassName + "' AND DynamicClassCode='" + DynamicClassCode.ToString() + "' AND Ordered in(0)");
                DataTable _DT = DB.Query_DataTable();
                JTable.SetToClassProperty(this, _DT.Rows[0]);
            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        public JWorkFlow[] GetNextNodes()
        {
            return GetNextNodes(true);
        }

        public JWorkFlow[] GetNextNodes(bool pCheckCon)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM WorkFlowNode WHERE ClassName='" + ClassName + "' AND DynamicClassCode='" + DynamicClassCode.ToString() + "' AND Ordered in(" + NextNodes + ")");
                DataTable _DT = DB.Query_DataTable();

                JWorkFlow[] WF = new JWorkFlow[0];

                foreach (DataRow _DR in _DT.Rows)
                {
                    JWorkFlow tempWF = new JWorkFlow(_PublicDataRow, ReferCode);
                    JTable.SetToClassProperty(tempWF, _DR);
                    tempWF.SetWorkFlowCondition();
                    if (!pCheckCon || tempWF.CheckCondition())
                    {
                        Array.Resize(ref WF, WF.Length + 1);
                        WF[WF.Length - 1] = tempWF;
                    }
                }
                return WF;
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static JWorkFlow[] GetAllNodes(string pClassName, int pDynamicClassCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM WorkFlowNode WHERE ClassName='" + pClassName + "' AND DynamicClassCode=" + pDynamicClassCode.ToString());
                DataTable _DT = DB.Query_DataTable();

                List<JWorkFlow> WF = new List<JWorkFlow>();

                foreach (DataRow _DR in _DT.Rows)
                {
                    JWorkFlow tempWF = new JWorkFlow();
                    JTable.SetToClassProperty(tempWF, _DR);
                    WF.Add(tempWF);

                }
                return WF.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool CheckCondition()
        {
            try
            {
                foreach (DataRow _DR in _PublicDataRow.Rows)
                {
                    if (_DR["WorkFlowCondition"].ToString().Length == 0 ||
                       bool.Parse(_DR["WorkFlowCondition"].ToString()))
                    {
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public void RUNACTION()
        {
            JAction jAction = new JAction("RunAction", Action, new object[] { _PublicDataRow }, null);
            jAction.run();
        }
        public void RUNSQL()
        {
            string _SQL = SQL;
            JDataBase DB = new JDataBase();
            DB.beginTransaction("Transaction");
            try
            {
                if (SQL != null && _PublicDataRow != null && SQL.Length > 5)
                {
                    foreach (DataRow _DR in _PublicDataRow.Rows)
                    {
                        _SQL = SQL;
                        foreach (DataColumn _DC in _PublicDataRow.Columns)
                        {
                            _SQL = _SQL.Replace("@" + _DC.ColumnName, JDataBase.Quote(_DR[_DC].ToString()));
                        }
                    }
                    DB.setQuery(_SQL);
                    DB.Query_Execute();
                    DB.Commit();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                DB.Rollback("Transaction");
            }
            finally
            {
                DB.Dispose();
            }
        }


        public static bool AutoGoToNextNode(string pClassName, int pObjectCode, int pDynamicClassCode, DataTable pDataTable, JNodeType pGoNode)
        {
            JARefer Refer = new JARefer();
            int _refCode = Refer.FindReferByExternalcode(pClassName, pObjectCode, pDynamicClassCode);
            Refer.GetData(_refCode);
            if (_refCode == 0) return false;

            JWorkFlow workflow = new JWorkFlow(pDataTable, _refCode);
            workflow.GetData(Refer.WorkFlowCode, pClassName, pDynamicClassCode);
            JWorkFlow[] workflows = workflow.GetNextNodes(true);
            foreach (JWorkFlow _wf in workflows)
            {
                if (_wf.NodeType == pGoNode)
                {
                    int[] RefCode = Refer.Send(
                        _wf.PostCode.ToString().Split(new char[] { ';' })
                        , "",
                        _wf.Code,
                        pObjectCode,
                        "",
                        pClassName,
                        pDynamicClassCode,
                        pDataTable
                        );
                    return RefCode.Length > 0;
                }
            }
            return false;
        }
    }

    public class JFromManagerWorkFlows
    {

        public JFromManagerWorkFlows()
        {
        }
    }
}
