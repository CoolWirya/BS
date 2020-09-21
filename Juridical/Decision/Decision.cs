using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;


namespace Legal
{
    public enum JAgainstCompanyType
    {
        AgainstCompany=1,
        Benefit=2,
        None=3,


    }

    public class JDecision :JLegal
    {
        #region Property

        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کددادخواست
        /// </summary>
        public int PetitionCode { get; set; }
        /// <summary>
        /// تاریخ رای
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// شماره دادنامه
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// بر علیه شرکت
        /// </summary>
        public JAgainstCompanyType AgainstCompany { get; set; }
        /// <summary>
        /// نوع آرا / قرار
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// قطعی
        /// </summary>
        public bool Conclusive { get; set; }
        /// <summary>
        /// توضیحات رای
        /// </summary>
        public string DecisionDesc { get; set; }
        /// <summary>
        /// غیبت خوانده در دادگاه
        /// </summary>
        public bool AbsencePerson{get;set;}

        #endregion

        #region سازنده

        public JDecision()
        {
        }
        public JDecision(int pCode)
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
            JDecisionTable PDT = new JDecisionTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JDecision.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                    {
                        //Add Relation
                        JRelation tmpJRelation = new JRelation();
                        tmpJRelation.PrimaryClassName = "Legal.JPetition";
                        tmpJRelation.PrimaryObjectCode = PDT.PetitionCode;
                        tmpJRelation.ForeignClassName = "Legal.JDecision";
                        tmpJRelation.ForeignObjectCode = Code;
                        tmpJRelation.Comment = "برای این دادخواست رای ثبت شده است";
                        if (!tmpJRelation.Insert(pDB))
                            return -1;

                        Histroy.Save(this, PDT, Code, "Insert");
                        return Code;
                    }
                    else
                        return -1;
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
            JDecisionTable PDT = new JDecisionTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JDecision.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(db))
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        return true;
                    }
                    return false;
                }
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
            try
            {
                if (JPermission.CheckPermission("Legal.JDecision.Delete"))
                {
                    JDecisionTable PDT = new JDecisionTable();
                    PDT.SetValueProperty(this);
                    {
                        //Delete Relation
                        JRelation tmpJRelation = new JRelation();
                        if (!tmpJRelation.CheckRelation("Legal.JDecision", Code, pDB))
                            if (!tmpJRelation.Delete("Legal.JDecision", Code, pDB))
                                return false;

                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JDecision", Code, false);
                        Histroy.Save(this, PDT, Code, "Delete");
                        PDT.Delete(pDB);
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
                //PDT.Dispose();
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Decision + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Decision + " WHERE Code=" + pCode.ToString());
                return DB.Query_DataTable();
                //if (DB.DataReader.Read())
                //{
                //    JTable.SetToClassProperty(this, DB.DataReader);
                //    return true;
                //}
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
        /// حذف رای دادگاه به همراه همگی جداول مرتبط آن
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual()
        {
            if (JMessages.Question("Are You Sure?", "Delete") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("DeleteDecision");
                //----------حذف انواع رای-----------
                JDecisionType tmpDecisionType = new JDecisionType();
                tmpDecisionType.DecisionCode = Code;
                tmpDecisionType.DeleteManual(" DecisionCode=" + Code, tempdb);
                //----------حذف اموال-----------
                JFinanceDecision tmpFinance = new JFinanceDecision();
                tmpFinance.DeleteManual(Code, tempdb);
                //------------------------------
                if (!delete(tempdb))
                {
                    tempdb.Rollback("DeleteDecision");
                    return false;
                }
                if (tempdb.Commit())
                {
                    JArchiveDocument AD = new JArchiveDocument();
                    AD.DeleteArchive("Legal.JDecision", Code, false);
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("DeleteDecision");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }

        }
        /// <summary>
        /// درج رای دادگاه به همراه همگی جداول مرتبط آن
        /// </summary>
        /// <param name="SubjectAdvocacy"></param>
        /// <param name="tmpJNotaryLetterTable"></param>
        /// <param name="dtVicarious"></param>
        /// <param name="dtAdvocate"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        public int Insert(List<int> SubjectAdvocacy, DataTable _dtAsset)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("InsertDecision");
                Code = Insert(tempdb);                
                if (Code > 0)
                {
                    //----------درج موضوعات-----------
                    JDecisionType tmpDecisionType = new JDecisionType();
                    if (!tmpDecisionType.Save(SubjectAdvocacy, null, Code, tempdb))
                    {
                        tempdb.Rollback("InsertDecision");
                        return 0;
                    }
                    //----------درج اموال-----------
                    JFinanceDecision tmpFinance = new JFinanceDecision();
                    if (!tmpFinance.Insert(_dtAsset, Code, tempdb))
                    {
                        tempdb.Rollback("InsertPetition");
                        return 0;
                    }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        try
                        {
                            Nodes.DataTable.Merge(JDecisions.GetDataTable(Code));
                        }
                        catch
                        {
                        }
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                {
                    tempdb.Rollback("InsertDecision");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertDecision");
                return 0;
            }
            finally
            {
                tempdb.Dispose();
            }
        }
        /// <summary>
        /// ویرایش رای دادگاه به همراه همگی جداول مرتبط آن
        /// </summary>
        /// <param name="SubjectAdvocacy"></param>
        /// <param name="SubjectAdvocacyDelete"></param>
        /// <returns></returns>
        public bool Update(List<int> SubjectAdvocacy,List<int> SubjectAdvocacyDelete,DataTable _dtAsset)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("UpdateDecision");
                if (Update(tempdb))
                {
                    //----------درج موضوعات-----------
                    JDecisionType tmpDecisionType = new JDecisionType();
                    tmpDecisionType.DecisionCode = Code;
                    if (!tmpDecisionType.Save(SubjectAdvocacy, SubjectAdvocacyDelete, Code, tempdb))
                    {
                        tempdb.Rollback("UpdateDecision");
                        return false;
                    }
                    JFinanceDecision tmpFinance = new JFinanceDecision();
                    if (!tmpFinance.Update(_dtAsset, Code, tempdb))
                    {
                        tempdb.Rollback("UpdateDecision");
                        return false;
                    }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JDecisions.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("UpdateDecision");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("UpdateDecision");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        /// <summary>
        /// جستجو رای دادگاه 
        /// </summary>
        /// <returns></returns>
        public DataTable Search(string strType,DateTime EndDate,int pAgainstCompany,int pConclusive,int pType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Exp = "";
                if (JDateTime.FarsiDate(Date) != "") Exp = Exp + " And Date Between @date And @date1 ";
                DB.Params.Add("@date", Date);
                DB.Params.Add("@date1", EndDate);
                if (number != "") Exp = Exp + " And Number Like '%" + number + "%'";
                if (pConclusive != -1) Exp = Exp + " And Conclusive = '" + Conclusive + "'";
                if (pType != -1) Exp = Exp + " And Type ='" + Type + "'";
                if (pAgainstCompany != -1) Exp = Exp + " And AgainstCompany = '" + AgainstCompany + "'";
                if (DecisionDesc != "") Exp = Exp + " And DecisionDesc Like '%" + DecisionDesc + "%'";
                if (strType != "0")
                {
                    Exp = Exp + " And DT.Type in (" + strType + ")";
                    DB.setQuery("SELECT * FROM " + JTableNamesLegal.Decision + " D Right join LegDecisionType DT On D.Code=DT.DecisionCode WHERE 1=1 " + Exp);
                }
                else
                    DB.setQuery("SELECT * FROM " + JTableNamesLegal.Decision + " WHERE 1=1 " + Exp);
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

        #region Nodes

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JDecisionForm PE = new JDecisionForm();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JDecisionForm PE = new JDecisionForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public void SearchDialog()
        {
            if (this.Code == 0)
            {
                JDecisionSearchForm PE = new JDecisionSearchForm();
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegDecision.Code.ToString()], "Legal.JDecision");
            node.Icone = JImageIndex.Vote.GetHashCode();
            node.Name = pRow[LegDecision.number.ToString()].ToString();
            node.Hint = JLanguages._Text("number:") + " " + pRow[LegDecision.number.ToString()] + "\n" +
                       JLanguages._Text("Date:") + " " + pRow[LegDecision.Date.ToString()] + "\n" +
                       JLanguages._Text("Description:") + " " + pRow[LegDecision.DecisionDesc.ToString()];
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JDecision.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JDecision.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JDecision.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion
    }

    public class JDecisions : JSystem 
    {
        public JDecisions[] Items = new JDecisions[0];
        //  public String OrderName;
        public JDecisions()
        {
            // OrderName = "Fam";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = @"select Code,
(Select Number from LegPetition where Code=PetitionCode) 'PetitionNumber',
(select fa_date from StaticDates where En_Date=Cast(Date as Date)) 'Date',
number,
case AgainstCompany
when 1 then 'علیه شرکت'
when 2 then 'به نفع شرکت'
when 3 then 'نامشخص' end 'AgainstCompany',
case Type
when 0 then 'رای'
when 1 then 'قرار' end 'Type',
case Conclusive
when 0 then 'قطعی'
when 1 then 'غیرقطعی' end 'Conclusive',
DecisionDesc,
AbsencePerson from " + JTableNamesLegal.Decision + " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JDecisions.GetDataTable", JTableNamesLegal.Decision + ".Code");
                if (pCode != 0)
                    WHERE = WHERE + " And Code = " + pCode;
                DB.setQuery(WHERE);
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

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetDecision", "Legal.JDecision.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JDecision.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Legal.JDecision.SearchDialog", null, null);
            Nodes.GlobalMenuActions.Insert(SearchAction);
            JToolbarNode TNS = new JToolbarNode();
            TNS.Icon = JImageIndex.Search;
            TNS.Hint = "Search...";
            TNS.Click = SearchAction;
            Nodes.AddToolbar(TNS);
            //ListView(OrderName, "");
        }
    }
}
