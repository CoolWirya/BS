using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Communication
{
    public class JRelationPersons : JSystem
    {
        #region Property
        /// <summary>
        ///  کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// پست کد فرستنده
        /// </summary>
        public int Sender_Post_Code { get; set; }
        /// <summary>
        /// پست کد گیرنده
        /// </summary>
        public int Receiver_Post_Code { get; set; }

        #endregion

        #region سازنده

        public JRelationPersons()
        {
        }
        public JRelationPersons(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase pDB = JGlobal.MainFrame.GetDBO();
            return Insert(pDB);
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JRelationPersonsTable PDT = new JRelationPersonsTable();
            try
            {
                if (JPermission.CheckPermission("Communication.JRelationPersons.Insert"))
                {
                    //if (!Find(MarketNumber))
                    //{
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
                    //}
                    //else
                    //{
                    //    JMessages.Message("کد مجتمع تکراری است", "خطا", JMessageType.Error);
                    //    return -2;
                    //}
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
            return 0;
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            JRelationPersonsTable PDT = new JRelationPersonsTable();
            try
            {
                if (JPermission.CheckPermission("Communication.JRelationPersons.Update"))
                {

                    PDT.SetValueProperty(this);
                    if (PDT.Update(db))
                    {
                        //Nodes.Refreshdata(Nodes.CurrentNode, GetAllData(Code).Rows[0]);
                        Histroy.Save(this, PDT, Code, "Update");
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
                /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            JDataBase pDB = JGlobal.MainFrame.GetDBO();
            return delete(pDB);
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            JRelationPersonsTable PDT = new JRelationPersonsTable();
            try
            {
                if (JPermission.CheckPermission("Communication.JRelationPersons.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                    {
                        Histroy.Save(this, PDT, Code, "Delete");
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM ClsRelationPersons WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetAllData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM ClsRelationPersons WHERE Code=" + pCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pSender_Post_Code, int pReceiver_Post_Code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " Where 1=1 ";
                if (pSender_Post_Code != 0)
                    Where = Where + " And Sender_Post_Code=" + pSender_Post_Code;
                if (pReceiver_Post_Code != 0)
                    Where = Where + " And Receiver_Post_Code=" + pReceiver_Post_Code;
                if (pSender_Post_Code != 0)
                    DB.setQuery("SELECT * FROM ClsRelationPersons RP inner join organizationchart orgchart on orgchart.Code = RP.Receiver_Post_Code " + Where);
                if (pReceiver_Post_Code != 0)
                    DB.setQuery("SELECT * FROM ClsRelationPersons RP inner join organizationchart orgchart on orgchart.Code = RP.Sender_Post_Code " + Where);

                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        } 
        #endregion

        public void ShowForm()
        {
            if (JPermission.CheckPermission("Communication.JRelationPersons.ShowForm"))
            {
                JRelationPersonsForm p = new JRelationPersonsForm();
                p.ShowDialog();
            }
        }

    }
}
