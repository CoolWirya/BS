using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    class JExecutive : JLegal
    {
        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد رای
        /// </summary>
        public int DecisionCode { get; set; }
        /// <summary>
        /// تاریخ اجرائیه
        /// </summary>
        public DateTime ExecuteDate { get; set; }
        /// <summary>
        /// شماره کلاسه اجرائی
        /// </summary>
        public string ExecuteNum { get; set; }
        /// <summary>
        /// توضیحات اجرائیه
        /// </summary>
        public string ExeDesc { get; set; }
        /// <summary>
        /// شماره کلاسه اجرای احکام
        /// </summary>
        public string ExeNum { get; set; }

        #endregion

        #region سازنده

        public JExecutive()
        {
        }
        public JExecutive(int pCode)
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
            JExecutiveTable PDT = new JExecutiveTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JExecutive.Insert"))
                {
                    //if (!Find(MarketNumber))
                    //{
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                    {
                        //Add Relation
                        JRelation tmpJRelation = new JRelation();
                        tmpJRelation.PrimaryClassName = "Legal.JDecision";
                        tmpJRelation.PrimaryObjectCode = PDT.DecisionCode;
                        tmpJRelation.ForeignClassName = "Legal.JExecutive";
                        tmpJRelation.ForeignObjectCode = Code;
                        tmpJRelation.Comment = "برای این رای اجرائیه ثبت شده است";
                        if (!tmpJRelation.Insert(pDB))
                            return -1;

                        Histroy.Save(this, PDT, Code, "Insert");
                        return Code;
                    }
                    else
                        return -1;
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
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            JExecutiveTable PDT = new JExecutiveTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JExecutive.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(db))
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JExecutives.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    else
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
        public bool delete(JDataBase pDB)
        {
            JExecutiveTable PDT = new JExecutiveTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JExecutive.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete(pDB))
                    {
                        //Delete Relation
                        JRelation tmpJRelation = new JRelation();
                        if (!tmpJRelation.CheckRelation("Legal.JExecutive", Code, pDB))
                            if (!tmpJRelation.Delete("Legal.JExecutive", Code, pDB))
                                return false;

                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JExecute", Code, false);
                        Histroy.Save(this, PDT, Code, "Delete");
                        return true;
                    }
                    else
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Executive + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Executive + " WHERE Code=" + pCode.ToString());
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
        /// حذف اجرائیه به همراه همگی جداول مرتبط آن 
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("DeleteExecutive");
                JPersonExecutive tmpJPersonExecutive = new JPersonExecutive();
                if (!tmpJPersonExecutive.DeleteManual(" ExecutiveCode =" + Code, tempdb))
                {
                    tempdb.Rollback("DeleteExecutive");
                    return false;
                }
                //----------حذف اموال-----------
                JFinanceExecute tmpFinance = new JFinanceExecute();
                if (!tmpFinance.DeleteManual(Code, tempdb))
                {
                    tempdb.Rollback("InsertPetition");
                    return false;
                }
                //------------------------------
                if (!delete(tempdb))
                {
                    tempdb.Rollback("DeleteExecutive");
                    return false;
                }

                if (tempdb.Commit())
                {
                    JArchiveDocument AD = new JArchiveDocument();
                    AD.DeleteArchive("Legal.JExecutive", Code, false);
                    Nodes.Delete(Nodes.CurrentNode);
                    Nodes.DataTable.Merge(JExecutives.GetDataTable(Code));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("DeleteExecutive");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }

        }
        /// <summary>
        /// درج اجرائیه به همراه همگی جداول مرتبط آن 
        /// </summary>
        /// <param name="SubjectAdvocacy"></param>
        /// <param name="tmpJNotaryLetterTable"></param>
        /// <param name="dtVicarious"></param>
        /// <param name="dtAdvocate"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        public int Insert(DataTable _dtPetition, DataTable _dtFey ,DataTable _dtAsset)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("InsertExecutive");
                Code = Insert(tempdb);
                //Histroy.Save(JAdvocacyTable , Code, "Insert");
                if (Code > 0)
                {
                    JPersonExecutive tmpJPersonExecutive = new JPersonExecutive();
                    if (!tmpJPersonExecutive.Insert(_dtPetition, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionExecute, tempdb))
                    {
                        tempdb.Rollback("InsertExecutive");
                        return 0;
                    }
                    if (!tmpJPersonExecutive.Insert(_dtFey, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.FeyExecute, tempdb))
                    {
                        tempdb.Rollback("InsertExecutive");
                        return 0;
                    }
                    JFinanceExecute tmpFinance = new JFinanceExecute();
                    if (!tmpFinance.Update(_dtAsset, Code, tempdb))
                    {
                        tempdb.Rollback("InsertExecutive");
                        return 0;
                    }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.DataTable.Merge(JExecutives.GetDataTable((Code)));
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                {
                    tempdb.Rollback("InsertExecutive");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertExecutive");
                return 0;
            }
            finally
            {
                tempdb.Dispose();
            }
        }
        /// <summary>
        /// ویرایش اجرائیه به همراه همگی جداول مرتبط آن 
        /// </summary>
        /// <param name="_dtPetition"></param>
        /// <param name="_dtFey"></param>
        /// <returns></returns>
        public bool Update(DataTable _dtPetition, DataTable _dtFey, DataTable _dtAsset)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("UpdatePetition");
                //Histroy.Save(JAdvocacyTable, Code, "Update");
                if (Update(tempdb))
                {
                    JPersonExecutive tmpJPersonExecutive = new JPersonExecutive();
                    if (!tmpJPersonExecutive.Update(_dtPetition, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionExecute, tempdb))
                    {
                        tempdb.Rollback("UpdateExeutive");
                        return false;
                    }
                    if (!tmpJPersonExecutive.Update(_dtFey, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.FeyExecute, tempdb))
                    {
                        tempdb.Rollback("UpdateExeutive");
                        return false;
                    }
                    JFinanceExecute tmpFinance = new JFinanceExecute();
                    if (!tmpFinance.Update(_dtAsset, Code, tempdb))
                    {
                        tempdb.Rollback("UpdateExeutive");
                        return false;
                    }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JExecutives.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("UpdateExeutive");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("UpdateExeutive");
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
        public DataTable Search(DateTime EndDate)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Exp = "";
                if (JDateTime.FarsiDate(ExecuteDate) != "") Exp = Exp + " And ExecuteDate Between @date And @date1 ";
                DB.Params.Add("@date", ExecuteDate);
                DB.Params.Add("@date1", EndDate);
                if (DecisionCode != 0) Exp = Exp + " And DecisionCode =" + DecisionCode;
                if (ExecuteNum != "") Exp = Exp + " And ExecuteNum Like '%" + ExecuteNum + "%'";
                if (ExeNum != "") Exp = Exp + " And ExeNum Like '%" + ExeNum + "%'";
                if (ExeDesc != "") Exp = Exp + " And ExeDesc Like '%" + ExeDesc + "%'";
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Executive + " WHERE 1=1 " + Exp);
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
                JExecutiveForm PE = new JExecutiveForm(0);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JExecutiveForm PE = new JExecutiveForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public void SearchDialog()
        {
            if (this.Code == 0)
            {
                JExecutiveSearchForm PE = new JExecutiveSearchForm();
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegExecute.Code.ToString()], "Legal.JExecutive");
            node.Icone = JImageIndex.Tribunal.GetHashCode();
            node.Name = pRow[LegExecute.ExecuteNum.ToString()].ToString();

            node.Hint = JLanguages._Text("ExecuteNum:") + " " + pRow[LegExecute.ExecuteDate.ToString()] + "\n" +
                       JLanguages._Text("ExeNum:") + " " + pRow[LegExecute.ExeNum.ToString()] + "\n" +
                       JLanguages._Text("Description:") + " " + pRow[LegExecute.ExeDesc.ToString()];
                       
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JExecutive.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JExecutive.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JExecutive.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion

    }

    public class JExecutives : JSystem
    {
        public JExecutives[] Items = new JExecutives[0];
        //  public String OrderName;
        public JExecutives()
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
(select number from LegDecision where Code = DecisionCode )  'DecisionNumber',
(select fa_date from StaticDates where En_Date=Cast(ExecuteDate as Date)) 'ExecuteDate',
ExecuteNum,
ExeDesc,
ExeNum from " + JTableNamesLegal.Executive + " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JExecutives.GetDataTable", JTableNamesLegal.Executive + ".Code");
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
            Nodes.ObjectBase = new JAction("GetExecutive", "Legal.JExecutive.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JExecutive.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Legal.JExecutive.SearchDialog", null, null);
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
