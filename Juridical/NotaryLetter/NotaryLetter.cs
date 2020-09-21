using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    
    public class JNotaryLetter : JSystem
    {


      #region Property

            public int Code { get; set; }
            /// <summary>
            /// کد محضر
            /// </summary>
            public int Notary_Code { get; set; }
            /// <summary>
            /// کد وکالت
            /// </summary>
            public int Advocacy_Code { get; set; }
            /// <summary>
            /// شماره نامه
            /// </summary>
            public string LetterNumber { get; set; }
            /// <summary>
            /// تاریخ نامه
            /// </summary>
            public DateTime Date { get; set; }
            /// <summary>
            /// موضوع
            /// </summary>
            public int Subject { get; set; }
            /// <summary>
            /// توضیحات
            /// </summary>
            public string Description { get; set; }
        /// <summary>
        /// نامه-ارسالی یا دریافتی
        /// </summary>
            public bool Sended { get; set; }


        #endregion

        #region سازنده

        public JNotaryLetter()
        {
        }

        public JNotaryLetter(int pCode)
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
            JNotaryLetterTable PDT = new JNotaryLetterTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotaryLetter.Insert"))
                {

                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JNotaryLetters.GetDataTable(Code));
                        Histroy.Save(this, PDT, Code, "Insert");
                        return Code;
                    }
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
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                Code = Insert(DB);
                if (Code > 0)                
                    return Code;
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
        ///بروزرسانی فقط مجتمع  
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JNotaryLetterTable PDT = new JNotaryLetterTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotaryLetter.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update())
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JNotaryLetters.GetDataTable(Code).Rows[0]);
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
            JNotaryLetterTable PDT = new JNotaryLetterTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotaryLetter.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (JMessages.Question("آیا میخواهید نامه مورد نظر حذف گردد؟", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete())
                    {
                        ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                        AD.DeleteArchive("Legal.JNotaryLetter", Code, false);
                        Nodes.Delete(Nodes.CurrentNode);
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.LegNotaryLetterTable + " WHERE Code=" + pCode.ToString());
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
                if (JDateTime.FarsiDate(Date) != "") Exp = Exp + " And Date Between('" + JDateTime.FarsiDate(Date) + "','" + JDateTime.FarsiDate(EndDate) + "')";
                if (Description != "")    Exp = Exp + " And Description Like '%" + Description + "%'";
                if (LetterNumber != "")   Exp = Exp + " And Like LetterNumber '%" + LetterNumber + "%'";
                if (Subject != 0)        Exp = Exp + " And Like Subject '%" + Subject + "%'";
                DB.setQuery("SELECT *,N.City,N.NumNotary FROM " + JTableNamesLegal.LegNotaryLetterTable + " NL inner join legNotary N on N.Code=NL.Notary_Code WHERE 1=1 " + Exp);
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
                JNotaryLetterForm PE = new JNotaryLetterForm();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JNotaryLetterForm PE = new JNotaryLetterForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            try
            {
                JNode node = new JNode((int)pRow[LegAdvocacy.Code.ToString()], "Legal.JNotaryLetter");
                node.Icone = JImageIndex.mail.GetHashCode();
                node.Name = JLanguages._Text("LetterNumber ") + pRow[NotaryLetter.LetterNumber.ToString()] + "\n";
                JNotary TmpNotary = new JNotary((int)pRow[NotaryLetter.Notary_Code.ToString()]);
                node.Name += JLanguages._Text("NotaryNumber ") + TmpNotary.NumNotary;
                node.Hint = JLanguages._Text("LetterNumber:") + " " + pRow[NotaryLetter.LetterNumber.ToString()] + "\n" +
                           JLanguages._Text("Date:") + " " + JDateTime.FarsiDate(Convert.ToDateTime(pRow[NotaryLetter.Date.ToString()])) + "\n" +
                           JLanguages._Text("Description:") + " " + pRow[NotaryLetter.Description.ToString()];
                Nodes.hidColumns = "Notary_Code,Subject";
                /// اکشن ویرایش
                JAction editAction = new JAction("Edit...", "Legal.JNotaryLetter.ShowDialog", null, new object[] { node.Code });
                node.MouseDBClickAction = editAction;
                node.EnterClickAction = editAction;
                /// اکشن حذف
                JAction deleteAction = new JAction("Delete...", "Legal.JNotaryLetter.delete", null, new object[] { node.Code });
                node.DeleteClickAction = deleteAction;
                //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
                /// اکشن جدید
                JAction newAction = new JAction("New...", "Legal.JNotaryLetter.ShowDialog", null, null);

                node.Popup.Insert(deleteAction);
                node.Popup.Insert(editAction);
                node.Popup.Insert(newAction);

                return node;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }
        #endregion

    }

    public class JNotaryLetters : JSystem
    {
        public JNotaryLetters[] Items = new JNotaryLetters[0];
        //  public String OrderName;
        public JNotaryLetters()
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
                string WHERE = @"select                  
                                Code,
                                Notary_Code,
                                LetterNumber,
                                (select fa_date from StaticDates where En_Date=Cast([Date] as Date)) 'Date',
                                (Select Name From subdefine WHERE Code = Subject) SubjectTitle,
                                Subject,
                                Description,
                                Sended
                from " + JTableNamesLegal.LegNotaryLetterTable + " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JNotaryLetters.GetDataTable",JTableNamesLegal.LegNotaryLetterTable + ".Code");
                if (pCode != 0)
                    WHERE = WHERE + " And Code = " + pCode;
                DB.setQuery(WHERE);
                return  DB.Query_DataTable();
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
            Nodes.ObjectBase = new JAction("GetAdvocacy", "Legal.JNotaryLetter.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JNotaryLetter.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }
    }
}
