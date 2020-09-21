using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    public class JNotice : JLegal
    {
        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int PetitionCode { get; set; }
        /// <summary>
        /// کد فرد ارجاع کننده
        /// </summary>
        public int ReferPersonCode { get; set; }
        /// <summary>
        /// تاریخ حضور
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// ساعت حضور
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// علت حضور
        /// </summary>
        public string Reasons { get; set; }
        /// <summary>
        /// نتیجه حضور
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// تاریخ ابلاغ
        /// </summary>
        public DateTime DateNotified { get; set; }
        /// <summary>
        /// حداکثر مهلت )به روز
        /// </summary>
        public int DateMax { get; set; }
        /// <summary>
        /// پایان مهلت
        /// </summary>
        public DateTime DateEnd { get; set; }
        /// <summary>
        /// فیلد مطلع-اخطاریه جهت اطلاع می باشد 
        /// </summary>
        public bool Informed { get; set; }


        #endregion

        #region سازنده

        public JNotice()
        {
        }

        public JNotice(int pCode)
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
            JNoticeTable PDT = new JNoticeTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotice.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JNotices.GetDataTable(Code));
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
        /// 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            try
            {
                JNoticeTable PDT = new JNoticeTable();
                PDT.SetValueProperty(this);
                Code = PDT.Insert();
                if (Code > 0)
                {
                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "Legal.JPetition";
                    tmpJRelation.PrimaryObjectCode = PDT.PetitionCode;
                    tmpJRelation.ForeignClassName = "Legal.JNotice";
                    tmpJRelation.ForeignObjectCode = Code;
                    tmpJRelation.Comment = "برای این دادخواست اخطاریه ثبت شده است";
                    if (!tmpJRelation.Insert())
                        return -1;

                    Nodes.DataTable.Merge(JNotices.GetDataTable(Code));
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
                //DB.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JNoticeTable PDT = new JNoticeTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotice.Update"))
                {
                    PDT.SetValueProperty(this);
                    PDT.SetValueProperty(this);
                    if (PDT.Update())
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JNotices.GetDataTable(Code).Rows[0]);
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
                PDT.Dispose();
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            JNoticeTable PDT = new JNoticeTable();
            JDataBase db = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotice.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete(db))
                    {
                        //Delete Relation
                        JRelation tmpJRelation = new JRelation();
                        if (!tmpJRelation.CheckRelation("Legal.JNotice", Code, db))
                            if (!tmpJRelation.Delete("Legal.JNotice", Code, db))
                                return false;

                        ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                        AD.DeleteArchive("Legal.JNotice", Code, false);
                        Nodes.Delete(Nodes.CurrentNode);
                        Histroy.Save(PDT, Code, "Deleted",db);

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
                PDT.Dispose();
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Notice + " WHERE Code=" + pCode.ToString());
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
        /// جستجو نامه محضر 
        /// </summary>
        /// <returns></returns>
        public DataTable Search(DateTime EndDate)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Exp = "";
                if (JDateTime.FarsiDate(Date) != "") Exp = Exp + " And Date Between @date And @date1 ";
                DB.Params.Add("@date", Date);
                DB.Params.Add("@date1", EndDate);
                if (Result != "") Exp = Exp + " And Result Like '%" + Result + "%'";
                if (Reasons != "") Exp = Exp + " And Like Reasons '%" + Reasons + "%'";
                //if (Subject != "")        Exp = Exp + " And Like Subject '%" + Subject + "%'";
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.Notice + " N inner join legPetition P on P.Code=N.PetitionCode WHERE 1=1 " + Exp);
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
                JNoticeForm PE = new JNoticeForm();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JNoticeForm PE = new JNoticeForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public void SearchDialog()
        {
            if (this.Code == 0)
            {
                JNoticeSearchFrom PE = new JNoticeSearchFrom();
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegAdvocacy.Code.ToString()], "Legal.JNotice");
            node.Icone = JImageIndex.Error.GetHashCode();
            node.Name = pRow[LegNotice.Date.ToString()].ToString();
            node.Hint = JLanguages._Text("Reason:") + " " + pRow[LegNotice.Reasons.ToString()] + "\n" +
                       JLanguages._Text("Date:") + " " + pRow[LegNotice.Date.ToString()] + "\n" +
                       JLanguages._Text("Time:") + " " + pRow[LegNotice.Time.ToString()];
            Nodes.hidColumns = "ReferPersonCode";           
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JNotice.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JNotice.delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JNotice.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion
    }


    public class JNotices : JSystem
    {
        public JNotices[] Items = new JNotices[0];
        //  public String OrderName;
        public JNotices()
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
ReferPersonCode,
(select fa_date from StaticDates where En_Date=Cast(Date as Date)) 'Date',
Time,
Reasons,
Result,
(select fa_date from StaticDates where En_Date=Cast(DateNotified as Date)) 'DateNotified',
DateMax,
(select fa_date from StaticDates where En_Date=Cast(DateEnd as Date)) 'DateEnd',
case Informed
when 0 then 'تشکیل شده'
when 1 then 'تشکیل نشده' end 'Informed'
 from " + JTableNamesLegal.Notice + " Where 1=1" ;
                    //JPermission.getObjectSql("Legal.JNotices.GetDataTable", JTableNamesLegal.Notice + ".Code");
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
            Nodes.ObjectBase = new JAction("GetNotice", "Legal.JNotice.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JNotice.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Legal.JNotice.SearchDialog", null, null);
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
