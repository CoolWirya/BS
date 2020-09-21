using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JLegCommission : JSystem
    {
        #region constructor
        public JLegCommission()
        {

        }
        public JLegCommission(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// کد کمیسیون
        /// </summary>
        public int CommissionCode
        {
            get;
            set;
        }
        /// <summary>
        /// گروه مصوبه
        /// </summary>
        public int LegislationGroup
        {
            get;
            set;
        }
        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesMeeting.MetLegCommission + " where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }


        #endregion

        #region method
        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable tmpdt, int pCommission_Code, JDataBase db)
        {
            JLegCommissionTable PDT = new JLegCommissionTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            CommissionCode = pCommission_Code;
                            LegislationGroup = Convert.ToInt32(dr["LegislationGroup"]);
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!delete(db))
                                return false;
                            dr.Delete();
                        }
                    }
                tmpdt.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                db.Dispose();
            }
        }

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase tempDb)
        {
            try
            {
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.Insert"))
                //{
                JLegCommissionTable JLT = new JLegCommissionTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JCommissionPersonss.GetDataTable(Code));
                        return Code;
                    }
                    return 0;
                //}
                //else
                //    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //tempDb.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool delete(JDataBase DB)
        {
            JLegCommissionTable PDT = new JLegCommissionTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.Delete"))
                //{
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(DB))
                        return true;
                    //Nodes.Delete(Nodes.CurrentNode);
                    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual(int pCode)
        {
            JLegCommissionTable PDT = new JLegCommissionTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.DeleteManual"))
                //{                    
                    PDT.SetValueProperty(this);
                    if (PDT.DeleteManual(" CommissionCode = " + pCode.ToString()))
                        return true;
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JLegCommissionTable PDT = new JLegCommissionTable();
            try
            {                
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.Update"))
                //{
                    PDT.SetValueProperty(this);
                    PDT.Update();
                    //Nodes.Refreshdata(Nodes.CurrentNode, GetDataTable(Code).Rows[0]);
                    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }

        }

        public static DataTable GetDataTable(int pCommissionCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Where = "";
                if (pCommissionCode != 0)
                    Where = " WHERE CommissionCode=" + pCommissionCode.ToString();
                DB.setQuery(@"SELECT A.Code,A.LegislationGroup,P.Name FROM " + JTableNamesMeeting.MetLegCommission
                    + " A inner join subdefine P on A.LegislationGroup=P.Code " + Where);
                return DB.Query_DataTable();
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

        #endregion
    }
}
