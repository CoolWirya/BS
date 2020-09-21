using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    public class JAdvocacyFinance : JSystem
    {

      #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد وکالت
            /// </summary>
            public int Advocacy_Code { get; set; }
            /// <summary>
            /// کد اموال
            /// </summary>
            public int FinanceCode { get; set; }

        #endregion


        #region سازنده

        public JAdvocacyFinance()
        {
        }
        public JAdvocacyFinance(int pCode)
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
        public int Insert(JDataBase pDB)
        {
            JAdvocacyFinanceTable PDT = new JAdvocacyFinanceTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                if (Code > 0)
                {
                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.AssetShare";
                    tmpJRelation.PrimaryObjectCode = PDT.FinanceCode;
                    tmpJRelation.ForeignClassName = "Legal.JAdvocacyFinance";
                    tmpJRelation.ForeignObjectCode = PDT.Code;
                    tmpJRelation.Comment = "برای این اموال وکیل ثبت شده است";
                    if (!tmpJRelation.Insert(pDB))
                        return -1;

                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
                }
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
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JAdvocacyFinanceTable PDT = new JAdvocacyFinanceTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update())
                {
                    Histroy.Save(this, PDT, Code, "Update");
                    return true;
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
        public bool delete(JDataBase pDB)
        {
            JAdvocacyFinanceTable PDT = new JAdvocacyFinanceTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB) || PDT.GetDeleteCount() >= 0)
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("Legal.JAdvocacyFinance", Code, pDB))
                        if (!tmpJRelation.Delete("Legal.JAdvocacyFinance", Code, pDB))
                            return false;

                    Histroy.Save(this, PDT, Code, "Delete");
                    return true;
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
        public bool DeleteManual(string exp,JDataBase pDB)
        {
            JAdvocacyFinanceTable PDT = new JAdvocacyFinanceTable();
            try
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.AdvocacyFinance + " WHERE "
                    + exp.ToString());
                foreach (DataRow dr in DB.Query_DataTable().Rows)
                {
                    Code = Convert.ToInt32(dr["Code"]);
                    if (!delete(pDB))
                        return false;
                }
                //Delete Relation
                //if (PDT.DeleteManual(exp, pDB) || PDT.GetDeleteCount() >= 0)
                //{
                //    JRelation tmpJRelation = new JRelation();
                //    if (!tmpJRelation.CheckRelation("Legal.JAdvocacyFinance", Code))
                //        if (!tmpJRelation.Delete("Legal.JAdvocacyFinance", Code, pDB))
                //            return false;
                return true;
                //}
                //else
                //    return false;
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
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.AdvocacyFinance + " WHERE Code=" + pCode.ToString());
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
        /// موضوعات وکالتی خاص
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllSubject(int pAdvocacy_Code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.AdvocacyFinance + " WHERE  Advocacy_Code=" + pAdvocacy_Code.ToString());
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
        /// ذخیره 
        /// </summary>
        /// <returns></returns>
        public bool Save(List<int> SubjectAdd,List<int> SubjectDelete,int pAdvocacy_Code, JDataBase pDB)
        {
            try
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.AdvocacyFinance + " WHERE "
                    + " Advocacy_Code= " + pAdvocacy_Code.ToString());
                DataTable dt=new DataTable();
                dt = DB.Query_DataTable();
                Advocacy_Code = pAdvocacy_Code;
                    for (int i = 0; i < SubjectAdd.Count; i++)
                    {
                        if (dt.Select(" FinanceCode = " + SubjectAdd[i].ToString()).Length == 0)
                        {                            
                            FinanceCode = SubjectAdd[i];
                            if (Insert(pDB) < 1)
                                return false;
                        }
                    }
                    if (SubjectDelete != null)
                        for (int i = 0; i < SubjectDelete.Count; i++)
                        {
                            if (dt.Select(" FinanceCode = " + SubjectDelete[i].ToString()).Length > 0)
                            {
                                Code = (int)dt.Select(" FinanceCode = " + SubjectDelete[i].ToString())[0].ItemArray[0];
                                FinanceCode = SubjectDelete[i];
                                if (!delete(pDB))
                                    return false;
                            }
                        }
                    //PDT.DeleteManual("Advocacy_Code= " + pAdvocacy_Code + " And FinanceCode=" + SubjectDelete[i], pDB);
                    return true;                
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
        #endregion

    }
}
