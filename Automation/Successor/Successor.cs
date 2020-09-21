using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    public class JSuccessor : JAutomation
    {
        #region Properties

        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد پست 
        /// </summary>      
        public int Person_post_code { get; set; }
        /// <summary>
        /// کد پست جانشین
        /// </summary>      
        public int Successer_post_code { get; set; }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime Start_date_time { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime End_date_time { get; set; }

        #endregion

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JSuccessor()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JSuccessor(int pCode)
        {
            if (pCode > 0)
                GetData(pCode);
        }
        #endregion

        #region GetInfo

        /// <summary>
        /// تنظیم مقادیر کلاس
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "Select * AutoSuccessor from  where Code=" + pCode + "";
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

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase Db = new JDataBase();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JLegislation.Insert"))
                //{
                JSuccessorTable JLT = new JSuccessorTable();
                JLT.SetValueProperty(this);
                Code = JLT.Insert(Db);
                if (Code > 0)
                {
                    //Nodes.DataTable.Merge(JCommissions.GetDataTable(Code));
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
                Db.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JDataBase Db = new JDataBase();
            JSuccessorTable PDT = new JSuccessorTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JLegislation.Delete"))
                //{
                PDT.SetValueProperty(this);
                if (PDT.Delete(Db))
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
                Db.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db)
        {
            try
            {
                JSuccessorTable PDT = new JSuccessorTable();
                //if (JPermission.CheckPermission("Meeting.JLegislation.Update"))
                //{
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                {
                    //Nodes.Refreshdata(Nodes.CurrentNode, JLegislations.GetDataTable(Code).Rows[0]);
                    return true;
                }
                return false;
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
                Db.Dispose();
            }

        }

        #endregion

        //Forms
        #region Forms
        public void ShowForm()
        {
            JSuccessorForm PE = new JSuccessorForm();
            PE.ShowDialog();
        }

        #endregion

        /// <summary>
        /// تنظیم مقادیر کلاس
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Where = "";
                if (pCode != 0)
                    Where = " And Code=" + pCode.ToString();
                string Query = @"select 
code,
(select full_title from VOrganizationChart where Code=Successer_post_code) 'Successer_post_code',
(select Fa_Date from StaticDates where En_Date=Start_date_time) 'Start_date_time',
(select Fa_Date from StaticDates where En_Date=End_date_time) 'End_date_time'
 from AutoSuccessor where Person_post_code=" + JMainFrame.CurrentPostCode + Where;
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}
