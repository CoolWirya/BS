using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{ 
    public class JAssertion : JLegal
    {

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// شماره 
        /// </summary>
        public string Number{ get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date{ get; set; }
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject{ get; set; }
        /// <summary>
        /// خلاصه اظهارات
        /// </summary>
        public string AssertionDescription{ get; set; }
        /// <summary>
        /// خلاصه جواب
        /// </summary>
        public string AnswerDescription{ get; set; }

        #endregion

         #region سازنده

        public JAssertion()
        {
        }
        public JAssertion(int pCode)
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
            JAssertionTable PDT = new JAssertionTable();
            try
            {
                if (JPermission.CheckPermission( "Legal.JAssertion.Insert"))
                {

                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
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
            JAssertionTable PDT = new JAssertionTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JAssertion.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(db))
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JAssertions.GetDataTable(Code).Rows[0]);
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
            JAssertionTable PDT = new JAssertionTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JAssertion.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                    {
                        Histroy.Save(this, PDT, Code, "Delete");
                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JAssertion", Code, false);
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
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.Assertion + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesPetition.Assertion + " WHERE Code=" + pCode.ToString());
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
        /// خذف دادخواست با شرط
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                {
                    tempdb.beginTransaction("DeleteAssertion");
                    JPersonAssertion tmpJPersonPetition = new JPersonAssertion();
                    if (!tmpJPersonPetition.DeleteManual(" AssertionCode=" + Code, tempdb))
                    {
                        tempdb.Rollback("DeleteAssertion");
                        return false;
                    }
                    //------------------------------
                    if (!delete(tempdb))
                    {
                        tempdb.Rollback("DeleteAssertion");
                        return false;
                    }
                    if (tempdb.Commit())
                    {
                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JAssertion", Code, false);
                        Nodes.Delete(Nodes.CurrentNode);
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
                JSystem.Except.AddException(ex);
                tempdb.Rollback("DeleteAssertion");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }

        }
        /// <summary>
        /// درج دادخواست با کلیه جداول مربوطه
        /// </summary>
        /// <param name="SubjectAdvocacy"></param>
        /// <param name="tmpJNotaryLetterTable"></param>
        /// <param name="dtVicarious"></param>
        /// <param name="dtAdvocate"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        public int Insert(DataTable _dtPetition, DataTable _dtPetition1, DataTable _dtFey, DataTable _dtFey1)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("InsertAssertion");
                Code = Insert(tempdb);
                if (Code > 0)
                {
                    JPersonAssertion tmpJPersonPetition = new JPersonAssertion();
                    if (!tmpJPersonPetition.Update(_dtPetition, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.Petition, tempdb))
                    {
                        tempdb.Rollback("InsertAssertion");
                        return 0;
                    }
                    if (!tmpJPersonPetition.Update(_dtPetition1, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionAdvocate, tempdb))
                    {
                        tempdb.Rollback("InsertAssertion");
                        return 0;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey, tempdb))
                    {
                        tempdb.Rollback("InsertAssertion");
                        return 0;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey1, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.FeyAdvocate, tempdb))
                    {
                        tempdb.Rollback("InsertAssertion");
                        return 0;
                    }
                    if (tempdb.Commit())
                    {
                        Nodes.DataTable.Merge(JAssertions.GetDataTable(Code));
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                {
                    tempdb.Rollback("InsertAssertion");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertAssertion");
                return 0;
            }
            finally
            {
                tempdb.Dispose();
            }
        }
        /// <summary>
        /// ویرایش دادخواست با کلیهجداول مربوطه
        /// </summary>
        /// <param name="_dtPetition"></param>
        /// <param name="_dtPetition1"></param>
        /// <param name="_dtFey"></param>
        /// <param name="_dtFey1"></param>
        /// <returns></returns>
        public bool Update(DataTable _dtPetition, DataTable _dtPetition1, DataTable _dtFey, DataTable _dtFey1)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("UpdateAssertion");                
                if (Update(tempdb))
                {
                    JPersonAssertion tmpJPersonPetition = new JPersonAssertion();
                    if (!tmpJPersonPetition.Update(_dtPetition, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Petition, tempdb))
                    {
                        tempdb.Rollback("UpdateAssertion");
                        return false;
                    }
                    if (!tmpJPersonPetition.Update(_dtPetition1, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionAdvocate, tempdb))
                    {
                        tempdb.Rollback("UpdateAssertion");
                        return false;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.Fey, tempdb))
                    {
                        tempdb.Rollback("UpdateAssertion");
                        return false;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey1, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.FeyAdvocate, tempdb))
                    {
                        tempdb.Rollback("UpdateAssertion");
                        return false;
                    }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JAssertions.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("UpdateAssertion");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("UpdateAssertion");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }
        }                

        #endregion

        #region Nodes

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JAssertionForm PE = new JAssertionForm(0);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JAssertionForm PE = new JAssertionForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegPetition.Code.ToString()], "Legal.JAssertion");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = pRow[LegPetition.Number.ToString()].ToString();

            node.Hint = JLanguages._Text("Date:") + " " + pRow[LegPetition.Date.ToString()];// + "\n" +
                //JLanguages._Text("Type:") + " " + pRow[LegAdvocacy.Type.ToString()] + "\n" +
                //       JLanguages._Text("Description:") + " " + pRow[LegPetition.Description.ToString()] + "\n" +
                 //      JLanguages._Text("Confirm:") + " " + str;
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JAssertion.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JAssertion.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JAssertion.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion

    }


    public class JAssertions : JSystem
    {
        public JAssertions[] Items = new JAssertions[0];
        //  public String OrderName;
        public JAssertions()
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
Number,
(select fa_date from StaticDates where En_Date=Cast([Date] as Date)) 'Date',
Subject,
AssertionDescription,
AnswerDescription from " + JTableNamesPetition.Assertion + " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JAssertions.GetDataTable", JTableNamesPetition.Assertion + ".Code");
                if (pCode != 0)
                    WHERE = WHERE + " And Code = " + pCode;
                DB.setQuery(WHERE);
                return DB.Query_DataTable();
                //DB.setQuery(WHERE);
                //DB.Query_DataSet();
                //System.Data.DataTable tblResult = DB.DataSet.Tables[0];
                //return tblResult;
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
            Nodes.ObjectBase = new JAction("GetAssertion", "Legal.JAssertion.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JAssertion.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Legal.JAssertion.SearchDialog", null, null);
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
