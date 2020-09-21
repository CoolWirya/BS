using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JProgram : JMeeting
    {
        #region constructor
        public JProgram()
        {

        }
        public JProgram(int pCode)
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
            /// توضیحات
            /// </summary>
            public string Description
            {
                get;
                set;
            }
            /// <summary>
            /// کد 
            /// </summary>
            public int MeetingCode
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
                string Query = "select * from " + JTableNamesMeeting.MetProgram + " where Code=" + pCode + "";
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
        public bool Update(DataTable tmpdt, int pMeeting_Code, JDataBase db)
        {
            JProgramTable PDT = new JProgramTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            MeetingCode = pMeeting_Code;
                            Description = dr["Description"].ToString();
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Modified)
                        {
                            MeetingCode = pMeeting_Code;
                            Description = dr["Description"].ToString();
                            Code = Convert.ToInt32(dr["Code"]);
                            if (!Update(db))
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!Delete(db))
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
                JProgramTable JLT = new JProgramTable();
                JLT.SetValueProperty(this);
                Code = JLT.Insert(tempDb);
                if (Code > 0)
                    return Code;
                return 0;
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
        public bool Delete(JDataBase Db)
        {
            JProgramTable PDT = new JProgramTable();
            try
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                    return true;
                Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //Db.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual(int pCode, JDataBase Db)
        {
            JProgramTable PDT = new JProgramTable();
            try
            {
                if (PDT.DeleteManual(" MeetingCode=" + pCode.ToString(), Db))
                    return true;
                Nodes.Delete(Nodes.CurrentNode);
                return true;
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
                JProgramTable PDT = new JProgramTable();
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                    return true;
                return false;
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

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JLegMeetingForm LandForm = new JLegMeetingForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JLegMeetingForm LandForm = new JLegMeetingForm(Code);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        #endregion

        public static DataTable GetDataTable(int pMeetingCode)
        {
            string Where = " where 1=1 ";
            if (pMeetingCode != 0)
                Where = Where + " And " + JTableNamesMeeting.MetProgram + ".MeetingCode=" + pMeetingCode;
            string Query = @"select * from " + JTableNamesMeeting.MetProgram + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
