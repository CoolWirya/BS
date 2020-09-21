using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JbreakupOrg: JLegal
    {
        #region سازنده

        public JbreakupOrg()
        {
        }
        public JbreakupOrg(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }
        #endregion

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد شرکت 
        /// </summary>
        public int OrgCode { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }        
        #endregion

        #region method

        public int Insert()
        {
            JDataBase tempDb = new JDataBase();
            try
            {
                return Insert(tempDb);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                tempDb.Dispose();
            }
        }
        private bool CheckOrg()
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesPetition.BreakupOrg + " where OrgCode=" + OrgCode.ToString();
                Db.setQuery(Query);
                if(Db.Query_DataTable().Rows.Count > 0)
                    return true;
                else
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
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase tempDb)
        {
            if (!JPermission.CheckPermission("Legal.JbreakupOrg.Insert", true))
                return 0; 
            JbreakupOrgTable JLT = new JbreakupOrgTable();
            try
            {
                if (!(CheckOrg()))
                {
                    tempDb.beginTransaction("InsertBreakupOrg");
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        if (UpdateState(false, OrgCode, tempDb))
                            if (tempDb.Commit())
                            {
                                Histroy.Save(this, JLT, Code, "Insert");
                                Nodes.DataTable.Merge(JbreakupOrgs.GetDataTable(Code));
                                return Code;
                            }
                        tempDb.Rollback("InsertBreakupOrg");
                        return 0;
                    }
                    else
                        return 0;
                }
                else
                {
                    JMessages.Error(" انحلال برای این شرکت قبلا ثبت شده است ","");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempDb.Rollback("InsertBreakupOrg");
                return 0;
            }
            finally
            {
                //tempDb.Dispose();
                JLT.Dispose();
            }
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (!JPermission.CheckPermission("Legal.JbreakupOrg.Update", true))            
                return false;            
            JDataBase Db = new JDataBase();
            JbreakupOrgTable PDT = new JbreakupOrgTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                {
                    Histroy.Save(this, PDT, Code, "Update");
                    Nodes.Refreshdata(Nodes.CurrentNode, JbreakupOrgs.GetDataTable(this.Code).Rows[0]);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
            return false;
        }

        /// <summary>
        /// حذف 
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode, int pOrgCode)
        {
            if (!JPermission.CheckPermission("Legal.JbreakupOrg.Delete", true))
                return false; 
            JDataBase Db = new JDataBase();
            JbreakupOrgTable PDT = new JbreakupOrgTable();
            try
            {
                Code = pCode;
                Db.beginTransaction("DeleteBreakupOrg");
                PDT.SetValueProperty(this);
                if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete(Db))
                    if (UpdateState(true, pOrgCode, Db))
                        if (Db.Commit())
                        {
                            Histroy.Save(this, PDT, Code, "Delete");
                            JArchiveDocument AD = new JArchiveDocument();
                            AD.DeleteArchive("Legal.JbreakupOrg", Code, false);
                            Nodes.Delete(Nodes.CurrentNode);
                            return true;
                        }
                    Db.Rollback("DeleteBreakupOrg");
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("DeleteBreakupOrg");
                return false;
            }
            finally
            {
                PDT.Dispose();
                Db.Dispose();
            }
        }
        #endregion

        #region GetData

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesPetition.BreakupOrg + " where Code=" + pCode + "";
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

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesPetition.BreakupOrg + " where Code=" + pCode;
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

        public static bool UpdateState(bool Flag, long orgCode, JDataBase Db)
        {
            try
            {
                string Status;
                string Active;
                if (Flag)
                {
                    Status = JCompanyStatuses.Active.GetHashCode().ToString();
                    Active = "1";
                }
                else
                {
                    Status = JCompanyStatuses.Dissolved.GetHashCode().ToString();
                    Active = "0";
                }
                string Query = @"
                update organization set Status = " + Status + @" 
                where Code =" + orgCode.ToString() + @" 
                update clsAllPerson set Active = " + Active + @" 
                where Code =" + orgCode.ToString();
                Db.setQuery(Query);
                if (Db.Query_Execute() >= 0)
                    return true;
                else
                    return false;
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

        #endregion

        #region Nodes

        public void ShowDialog(int pOrgCode)
        {
            ShowDialog(0, pOrgCode);
        }

        public void ShowDialog()
        {
            ShowDialog(0,0);
        }
        public void ShowDialog(int pCode, int pOrgCode)
        {
            if (pCode == 0)
            {
                JbreakupOrgForm PE = new JbreakupOrgForm(0, pOrgCode);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JbreakupOrgForm PE = new JbreakupOrgForm(pCode,0);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "Legal.JbreakupOrg");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = pRow["Date"].ToString();
            Nodes.hidColumns = "OrgCode";
            //node.Hint = JLanguages._Text("Date:") + " " + pRow[LegPetition.Date.ToString()];// + "\n" +          
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JbreakupOrg.ShowDialog", new object[] { node.Code },null);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JbreakupOrg.Delete", new object[] { node.Code, (int)pRow["OrgCode"] }, null);
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JbreakupOrg.ShowDialog", new object[] { 0 }, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion
    }

    public class JbreakupOrgs : JSystem
    {
        public JbreakupOrgs[] Items = new JbreakupOrgs[0];
        //  public String OrderName;
        public JbreakupOrgs()
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
                OrgCode,
                (Select name From organization where Code =OrgCode) 'Name',
                (select fa_date from StaticDates where En_Date=Date) 'Date',
                Description from " + JTableNamesPetition.BreakupOrg + " Where 1=1 ";
                //JPermission.getObjectSql("Legal.JAssertions.GetDataTable", JTableNamesPetition.Assertion + ".Code");
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
            Nodes.ObjectBase = new JAction("GetBreakup", "Legal.JbreakupOrg.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JbreakupOrg.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //JAction SearchAction = new JAction("Search...", "Legal.JbreakupOrg.SearchDialog", null, null);
            //Nodes.GlobalMenuActions.Insert(SearchAction);
            //JToolbarNode TNS = new JToolbarNode();
            //TNS.Icon = JImageIndex.Search;
            //TNS.Hint = "Search...";
            //TNS.Click = SearchAction;
            //Nodes.AddToolbar(TNS);
            //ListView(OrderName, "");
        }
    }
}
