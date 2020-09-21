using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{ 
    public class JPetition : JLegal
    {

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// شکوائیه / دادخواست
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// شماره دادخواست
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// کد موضوع
        /// </summary>
        public int Subject_Code { get; set; }
        /// <summary>
        /// کد دادگاه
        /// </summary>
        public int judicialCode { get; set; }
        /// <summary>
        /// کد مقام ارجاع کننده
        /// </summary>
        public string PostReferCode { get; set; }
        /// <summary>
        /// توضیحات درخواست
        /// </summary>
        public string RequestDescription { get; set; }
        /// <summary>
        /// دلائل
        /// </summary>
        public string ReasonsDescription { get; set; }

        #endregion

         #region سازنده

        public JPetition()
        {
        }
        public JPetition(int pCode)
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
            JPetitionTable PDT = new JPetitionTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JPetition.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                    {
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
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            JPetitionTable PDT = new JPetitionTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JPetition.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(db))
                    {
                        Histroy.Save(this, PDT, Code, "Update");
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
            JPetitionTable PDT = new JPetitionTable();
            try
            {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                    {
                        Histroy.Save(this, PDT, Code, "Delete");
                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JPetition", Code, false);
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
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Petition + " WHERE Code=" + pCode.ToString());
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
                string Where = "";
                if (pCode > 0)
                   Where = " And Code=" + pCode.ToString();
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Petition + " WHERE 1= 1" +Where);
                   //JPermission.getObjectSql("Legal.JPetition.GetDataTable") + Where);
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
            if (!JPermission.CheckPermission("Legal.JPetition.Delete"))
            {
                return false;
            }

            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.setQuery("Select * from legNotice WHERE PetitionCode = " + Code.ToString());
                if (tempdb.Query_DataTable().Rows.Count > 0)
                {
                    JMessages.Error("این دادخواست در اخطاریه ها استفاده شده است. حذف امکانپذیر نیست.", "خطا در حذف");
                    return false;
                }

                tempdb.setQuery("Select * from LegDecision WHERE PetitionCode = " + Code.ToString());
                if (tempdb.Query_DataTable().Rows.Count > 0)
                {
                    JMessages.Error("برای این دادخواست، رای دادگاه ثبت شده است. حذف امکانپذیر نیست.", "خطا در حذف");
                    return false;
                }

                if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                {
                    tempdb.beginTransaction("DeletePetition");
                    JPersonPetition tmpJPersonPetition = new JPersonPetition();
                    tmpJPersonPetition.PetitionCode = Code;
                    if (!tmpJPersonPetition.DeleteManual(" PetitionCode=" + Code, tempdb))
                    {
                        tempdb.Rollback("DeletePetition");
                        return false;
                    }
                    //------------------------------
                    JFinancePetition tmpFinance = new JFinancePetition();
                    if (!tmpFinance.DeleteManual(Code, tempdb))
                    {
                        tempdb.Rollback("DeletePetition");
                        return false;
                    }

                    if (!delete(tempdb))
                    {
                        tempdb.Rollback("DeletePetition");
                        return false;
                    }
                    if (tempdb.Commit())
                    {
                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JPetition", Code, false);
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
                tempdb.Rollback("DeletePetition");
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
        public int Insert(DataTable _dtPetition, DataTable _dtPetition1, DataTable _dtFey, DataTable _dtFey1, DataTable _dtAsset)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("InsertPetition");
                Code = Insert(tempdb);
                if (Code > 0)
                {
                    JPersonPetition tmpJPersonPetition = new JPersonPetition();
                    if (!tmpJPersonPetition.Update(_dtPetition, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.Petition, tempdb))
                    {
                        tempdb.Rollback("InsertPetition");
                        return 0;
                    }
                    if (!tmpJPersonPetition.Update(_dtPetition1, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionAdvocate, tempdb))
                    {
                        tempdb.Rollback("InsertPetition");
                        return 0;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey, tempdb))
                    {
                        tempdb.Rollback("InsertPetition");
                        return 0;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey1, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.FeyAdvocate, tempdb))
                    {
                        tempdb.Rollback("InsertPetition");
                        return 0;
                    }
                    JFinancePetition tmpFinance = new JFinancePetition();
                    if (!tmpFinance.Insert(_dtAsset, Code, tempdb))
                    {
                        tempdb.Rollback("InsertPetition");
                        return 0;
                    }
                    if (tempdb.Commit())
                    {
                        Nodes.DataTable.Merge(JPetitions.GetDataTable(Code));
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                {
                    tempdb.Rollback("InsertPetition");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertPetition");
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
        public bool Update(DataTable _dtPetition, DataTable _dtPetition1, DataTable _dtFey, DataTable _dtFey1, DataTable _dtAsset)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("UpdatePetition");                
                if (Update(tempdb))
                {
                    JPersonPetition tmpJPersonPetition = new JPersonPetition();
                    if (!tmpJPersonPetition.Update(_dtPetition, Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Petition, tempdb))
                    {
                        tempdb.Rollback("UpdatePetition");
                        return false;
                    }
                    if (!tmpJPersonPetition.Update(_dtPetition1, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionAdvocate, tempdb))
                    {
                        tempdb.Rollback("UpdatePetition");
                        return false;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.Fey, tempdb))
                    {
                        tempdb.Rollback("UpdatePetition");
                        return false;
                    }
                    if (!tmpJPersonPetition.Update(_dtFey1, Code,ClassLibrary.Domains.Legal.JPersonPetitionType.FeyAdvocate, tempdb))
                    {
                        tempdb.Rollback("UpdatePetition");
                        return false;
                    }
                    JFinancePetition tmpFinance = new JFinancePetition();
                    if (!tmpFinance.Update(_dtAsset, Code, tempdb))
                    {
                        tempdb.Rollback("UpdatePetition");
                        return false;
                    }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JPetitions.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("UpdatePetition");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("UpdatePetition");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }
        }        
        /// <summary>
        /// جستجو دادخواست 
        /// </summary>
        /// <returns></returns>
        public DataTable Search(DateTime EndDate)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Exp = "";
                if (JDateTime.FarsiDate(Date) != "") Exp = Exp + " And Date Between @date And @date1 ";
                if (Type != 0) Exp = Exp + " And Type =" + Type;
                if (Number != "") Exp = Exp + " And Number =" + Number;
                if (Subject_Code != 0) Exp = Exp + " And Subject_Code =" + Subject_Code;
                if (judicialCode != 0) Exp = Exp + " And judicialCode =" + judicialCode;
                if (PostReferCode != null) Exp = Exp + " And PostReferCode =" + PostReferCode;
                if (RequestDescription != "") Exp = Exp + " And RequestDescription Like '%" + RequestDescription + "%'";
                if (ReasonsDescription != "") Exp = Exp + " And ReasonsDescription Like '%" + ReasonsDescription + "%'";
                DB.Params.Add("@date", Date);
                DB.Params.Add("@date1", EndDate);
                
                //DB.setQuery("SELECT * FROM " + JTableNamesLegal.Petition + " WHERE 1=1 " + Exp);
                DB.setQuery(@" select Code,
case Type
when 2 then 'شکوائیه'
when 1 then 'دادخواست' end 'Type',
Number,
(select fa_date from StaticDates where En_Date=Cast([Date] as Date)) 'Date',
(select name from subdefine where Code = Subject_Code) 'Subject',
(SELECT Name from legJudicialBranch where Code=judicialCode) 'judicialName',
PostReferCode 'PostReferName',
RequestDescription,
ReasonsDescription from " + JTableNamesLegal.Petition + " WHERE 1=1 " + Exp);

                
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
                JPetitionForm PE = new JPetitionForm(0);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JPetitionForm PE = new JPetitionForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public void SearchDialog()
        {
            if (this.Code == 0)
            {
                JPetitionSearchForm PE = new JPetitionSearchForm();
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegPetition.Code.ToString()], "Legal.JPetition");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = pRow[LegPetition.Number.ToString()].ToString();

            node.Hint = JLanguages._Text("Date:") + " " + JDateTime.FarsiDate(Convert.ToDateTime(pRow[LegPetition.Date.ToString()]));// + "\n" +
                //JLanguages._Text("Type:") + " " + pRow[LegAdvocacy.Type.ToString()] + "\n" +
                //       JLanguages._Text("Description:") + " " + pRow[LegPetition.Description.ToString()] + "\n" +
                 //      JLanguages._Text("Confirm:") + " " + str;
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JPetition.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JPetition.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JPetition.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion

    }


    public class JPetitions : JSystem
    {
        public JPetitions[] Items = new JPetitions[0];
        //  public String OrderName;
        public JPetitions()
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
case Type
when 2 then 'شکوائیه'
when 1 then 'دادخواست' end 'Type',
Number,
(select fa_date from StaticDates where En_Date=Cast([Date] as Date)) 'Date',
(select name from subdefine where Code = Subject_Code) 'Subject',
(SELECT Name from legJudicialBranch where Code=judicialCode) 'judicialName',
PostReferCode 'PostReferName',
RequestDescription,
ReasonsDescription from " + JTableNamesLegal.Petition + " WHERE 1=1";
//JPermission.getObjectSql("Legal.JPetitions.GetDataTable", JTableNamesLegal.Petition + ".Code");
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
            Nodes.ObjectBase = new JAction("GetPetition", "Legal.JPetition.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JPetition.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Legal.JPetition.SearchDialog", null, null);
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
