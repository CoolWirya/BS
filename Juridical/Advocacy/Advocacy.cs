using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;
namespace Legal
{
    /// <summary>
    /// موضوعات وکالت
    /// </summary>
    public enum JAdvocacySubjects
    {
        /// <summary>
        /// انتقال قطعی، وکالت طرف اول
        /// </summary>
        DefinitiveContractAT1 = 1,
        /// <summary>
        /// انتقال قطعی، وکالت طرف دوم
        /// </summary>
        DefinitiveContractAT2 = 2,
        /// <summary>
        /// انتقال سرقفلی، وکالت طرف اول
        /// </summary>
        GoodwillContractAT1 = 3,
        /// <summary>
        /// انتقال سرقفلی، وکالت طرف دوم
        /// </summary>
        GoodwillContractAT2 = 4,
        /// <summary>
        /// اجاره صلح سرقفلی
        /// </summary>
        RentGoodwillContract = 5,
        /// <summary>
        /// اجاره، وکالت موجر
        /// </summary>
        RentContractAT1 = 6,
        /// <summary>
        /// اجاره، وکالت مستاجر
        /// </summary>
        RentContractAT2 = 7,
        /// <summary>
        /// مشارکت
        /// </summary>
        Contribute = 8,
        /// <summary>
        /// اجاره مشاعات
        /// </summary>
        RentEnviroments = 9,
        /// <summary>
        /// دادخواست و شکوائیه
        /// </summary>
        Petition = 10,
        /// <summary>
        /// غیره
        /// </summary>
        AllSubjects = 100,
    }
    /// <summary>
    /// وکالت
    /// </summary>
    public class JAdvocacy : JSystem
    {
        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد موکل
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// تاریخ شروع وکالت
        /// </summary>
        public DateTime StartDate{ get; set; }
        /// <summary>
        /// تاریخ پایان وکالت
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// کد نامه محضر
        /// </summary>
        public int NotaryCode { get; set; }
        /// <summary>
        /// توضیحات اختیارات
        /// </summary>
        public string Description{ get; set; }
        /// <summary>
        /// نوع انحلال
        /// </summary>
        public int Breakup_Type{ get; set; }
        /// <summary>
        /// تاریخ انحلال
        /// </summary>
        public DateTime BreakupDate{ get; set; }
        /// <summary>
        /// کد نامه انحلال از محضر
        /// </summary>
        public int Breakup_Notary{ get; set; }
        /// <summary>
        /// کد نامه انحلال از دادگاه
        /// </summary>
        public int Breakup_tribunal{ get; set; }
        /// <summary>
        /// توضیح انحلال
        /// </summary>
        public string BreakupDesc{ get; set; }
        /// <summary>
        /// وضعیت وکالت
        /// </summary>
        public Boolean State{ get; set; }
        /// <summary>
        /// نوع وکالت
        /// </summary>
        public int Type{ get; set; }
        /// <summary>
        /// تایید شده توسط واحد حقوقی
        /// </summary>
        public Boolean Confirm { get; set; }
        /// <summary>
        /// کد اموال
        /// </summary>
        //public int FinanceCode { get; set; }
        /// <summary>
        /// کد حکم انحلال وکالت از دادگاه
        /// </summary>
        public int DesionCode { get; set; }
        /// <summary>
        /// شماره دفتر
        /// </summary>
        public int NotaryOffice { get; set; }
        /// <summary>
        /// شماره وکالت نامه
        /// </summary>
        public string LetterNo { get; set; }
        /// <summary>
        /// تاریخ وکالت نامه 
        /// </summary>
        public DateTime LetterDate { get; set; }
        /// <summary>
        /// موضوع وکالت نامه
        /// </summary>
        public string LetterSubject { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string LetterDesc{ get; set; }
        /// <summary>
        /// وکالت تمام دارایی ها
        /// </summary>
        public bool AllAssets { get; set; }


        #endregion

        #region سازنده

        public JAdvocacy()
        {
        }
        public JAdvocacy(int pCode)
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
            JAdvocacyTable PDT = new JAdvocacyTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JAdvocacy.Insert"))
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
            JAdvocacyTable PDT = new JAdvocacyTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JAdvocacy.Update"))
                {

                    PDT.SetValueProperty(this);
                    if (PDT.Update(db))
                    {
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
        public bool delete(JDataBase pDB)
        {
            JAdvocacyTable PDT = new JAdvocacyTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JAdvocacy.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                    {
                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JAdvocacy", Code, false);
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
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.AdvocacyTable + " WHERE Code=" + pCode.ToString());
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual()
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                {
                    tempdb.beginTransaction("DeleteAdvocacy");
                    JVicarious tmpJVicarious = new JVicarious();
                    JAdvocate tmpJAdvocate = new JAdvocate();
                    JSubjectAdvocacy tmpJSubjectAdvocacy = new JSubjectAdvocacy();
                    //JNotaryLetter tmpJNotaryLetter = new JNotaryLetter();
                    //----------حذف موضوعات-----------
                    tmpJSubjectAdvocacy.Advocacy_Code = Code;
                    if (!tmpJSubjectAdvocacy.DeleteManual(" Advocacy_Code=" + Code, tempdb))
                    {
                        tempdb.Rollback("DeleteAdvocacy");
                        return false;
                    }
                    //----------حذف اموال-----------
                    JAdvocacyFinance tmpJFinanceAdvocacy = new JAdvocacyFinance();
                    tmpJFinanceAdvocacy.Advocacy_Code = Code;
                    if (!tmpJFinanceAdvocacy.DeleteManual(" Advocacy_Code=" + Code, tempdb))
                    {
                        tempdb.Rollback("DeleteAdvocacy");
                        return false;
                    } 
                    //----------حذف موکل-----------
                    if (!tmpJVicarious.DeleteManual(" Advocacy_Code=" + Code,Code, tempdb))
                    {
                        tempdb.Rollback("DeleteAdvocacy");
                        return false;
                    }
                    //----------حذف وکیل-----------
                    tmpJAdvocate.Advocacy_Code = Code;
                    if (!tmpJAdvocate.DeleteManual(" Advocacy_Code=" + Code, tempdb))
                    {
                        tempdb.Rollback("DeleteAdvocacy");
                        return false;
                    }
                    //------------------------------
                    if (!delete(tempdb))
                    {
                        tempdb.Rollback("DeleteAdvocacy");
                        return false;
                    }
                    if (tempdb.Commit())
                    {
                        JArchiveDocument AD = new JArchiveDocument();
                        AD.DeleteArchive("Legal.JAdvocacy", Code, false);
                        Nodes.Delete(Nodes.CurrentNode);
                        //Histroy.Save(tmpJSubjectAdvocacy, Code, "Delete");
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
                tempdb.Rollback("InsertAdvocacy");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SubjectAdvocacy"></param>
        /// <param name="tmpJNotaryLetterTable"></param>
        /// <param name="dtVicarious"></param>
        /// <param name="dtAdvocate"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        public int Insert(List<int> SubjectAdvocacy, List<int> AssetFinance, DataTable dtVicarious, DataTable dtAdvocate, DateTime StartDate)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("InsertAdvocacy");
                Code = Insert(tempdb);
                if (Code > 0)
                {                    
                    JVicarious tmpJVicarious = new JVicarious();
                    JAdvocate tmpJAdvocate = new JAdvocate();
                    JSubjectAdvocacy tmpJSubjectAdvocacy = new JSubjectAdvocacy();
                    //----------درج موضوعات-----------
                    if (!tmpJSubjectAdvocacy.Save(SubjectAdvocacy,null,Code,tempdb))
                    {
                        tempdb.Rollback("InsertAdvocacy");
                        return 0;
                    }
                    //----------درج اموال-----------
                    JAdvocacyFinance tmpJFinanceAdvocacy = new JAdvocacyFinance();
                    if (!tmpJFinanceAdvocacy.Save(AssetFinance, null, Code, tempdb))
                    {
                        tempdb.Rollback("InsertAdvocacy");
                        return 0;
                    }  
                    //----------درج موکل-----------
                    tmpJVicarious.Advocacy_Code = Code;                   
                    if (!tmpJVicarious.Update(dtVicarious,Code,tempdb))
                        {
                            tempdb.Rollback("InsertAdvocacy");
                            return 0;
                        }
                    //}
                    //----------درج وکیل-----------
                    tmpJAdvocate.Advocacy_Code = Code;  
                    if (!tmpJAdvocate.Update(dtAdvocate, Code, tempdb))
                        {
                            tempdb.Rollback("InsertAdvocacy");
                            return 0;
                        }
                    //}
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.DataTable.Merge(JAdvocacys.GetDataTable(Code));
                        //Histroy.Save(PDT, Code, "Insert");
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                {
                    tempdb.Rollback("InsertAdvocacy");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("InsertAdvocacy");
                return 0;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        public bool Update(List<int> SubjectAdvocacy,List<int> SubjectAdvocacyDelete, List<int> AssetFinance, List<int> DeleteAssetFinance ,DataTable dtVicarious, DataTable dtAdvocate, DateTime StartDate)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            try
            {
                tempdb.beginTransaction("UpdateAdvocacy");
                //---------------اگر گزینه فوت انتخاب شود باید عزل شود------------
                if (Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.Die)
                    State = true;
                if (Update(tempdb))
                {
                    JVicarious tmpJVicarious = new JVicarious();
                    JAdvocate tmpJAdvocate = new JAdvocate();
                    JSubjectAdvocacy tmpJSubjectAdvocacy = new JSubjectAdvocacy();
                    //----------درج موضوعات-----------
                    tmpJSubjectAdvocacy.Advocacy_Code = Code;
                    if (!tmpJSubjectAdvocacy.Save(SubjectAdvocacy, SubjectAdvocacyDelete,Code,tempdb))
                    {
                        tempdb.Rollback("UpdateAdvocacy");
                        return false;
                    }
                    //----------درج اموال-----------
                    JAdvocacyFinance tmpJFinanceAdvocacy = new JAdvocacyFinance();
                    //if(DeleteAssetFinance == null)
                    //    tmpJFinanceAdvocacy.DeleteManual(" Code=" + Code.ToString() ,tempdb );
                    if (!tmpJFinanceAdvocacy.Save(AssetFinance, DeleteAssetFinance, Code, tempdb))
                    {
                        tempdb.Rollback("UpdateAdvocacy");
                        return false;
                    }
                    //----------درج نامه های محضر-----------
                    //tmpJNotaryLetterTable.Advocacy_Code = Code;
                    //if (tmpJNotaryLetterTable.Update(tempdb) < 1)
                    //{
                    //    tempdb.Rollback("UpdateAdvocacy");
                    //    return false;
                    //}
                    //----------ویرایش موکل-----------
                    //tmpJVicarious.DeleteManual(" Advocacy_Code=" + Code.ToString(), tempdb);
                    if (!tmpJVicarious.Update(dtVicarious,Code, tempdb))
                     {
                       tempdb.Rollback("UpdateAdvocacy");
                       return false;
                     }
                    //----------ویرایش وکیل-----------                   
                    if (!tmpJAdvocate.Update(dtAdvocate,Code, tempdb))
                        {
                            tempdb.Rollback("UpdateAdvocacy");
                            return false;
                        }
                    //------------------------------
                    if (tempdb.Commit())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JAdvocacys.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tempdb.Rollback("UpdateAdvocacy");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempdb.Rollback("UpdateAdvocacy");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        /// <summary>
        /// انحلال وکالت در صورت فوت وکیل
        /// </summary>
        /// <returns></returns>
        public static bool UpdateDieAdvocacy(int pPersonCode,JDataBase DB)
        {
            DataTable dt=new DataTable();
            try
            {
                DB.setQuery("select Advocacy_Code from " + JTableNamesLegal.AdvocateTable + " Where Person_Code=" + pPersonCode);
                dt = DB.Query_DataTable();
                foreach(DataRow dr in dt.Rows)
                {
                    JAdvocacy Advocacy = new JAdvocacy();
                    Advocacy.GetData(Convert.ToInt32(dr["Advocacy_Code"]));
                    Advocacy.State = true;
                    Advocacy.Breakup_Type = ClassLibrary.Domains.Legal.JBreakupType.Die;
                    if(!Advocacy.Update(DB))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
           
        }
        /// <summary>
        /// انحلا ل وکالت در صورت فوت موکل
        /// </summary>
        /// <param name="pPersonCode"></param>
        /// <param name="DB"></param>
        /// <returns></returns>

        public static bool UpdateDieVicarious(int pPersonCode, JDataBase DB)
        {
            DataTable dt = new DataTable();
            try
            {
                DB.setQuery("select Advocacy_Code from " + JTableNamesLegal.LegVicariousTable + " Where Person_Code=" + pPersonCode);
                dt = DB.Query_DataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    JAdvocacy Advocacy = new JAdvocacy();
                    Advocacy.GetData(Convert.ToInt32(dr["Advocacy_Code"]));
                    Advocacy.Breakup_Type = ClassLibrary.Domains.Legal.JBreakupType.Die;
                    Advocacy.State = true;
                    if (!Advocacy.Update(DB))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
           

        }



        //public DataTable AdvocasyList(int  )
        //{

        //}
        #endregion

        public DataTable ListAdvocacy(int pAssetCode, JAdvocacySubjects pSubject)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("Select Ad.* from " + JTableNamesLegal.AdvocacyTable + " A inner join LegSubject S on A.Code=S.Advocacy_Code inner join LegAdvocate Ad on Ad.Advocacy_Code= A.Code Where FinanceCode=" + pAssetCode.ToString() + " And S.SubjectCode = " + pSubject.ToString());
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

        public DataTable ListVicarious(int pSubject, int pAssetCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(
@"Select Ad.*,P.Name from " + JTableNamesLegal.AdvocacyTable + " A inner join LegSubject S on A.Code=S.Advocacy_Code inner join LegVicarious Ad on Ad.Advocacy_Code= A.Code inner join clsAllPerson P on P.code=Ad.Person_Code Where FinanceCode=" + pAssetCode.ToString() + " And S.SubjectCode = " + pSubject.ToString());
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

        #region Nodes

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JAdvocacyForm PE = new JAdvocacyForm(0);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JAdvocacyForm PE = new JAdvocacyForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegAdvocacy.Code.ToString()], "Legal.JAdvocacy");
            node.Icone = JImageIndex.advocacy.GetHashCode();
            node.Name = pRow["AdvocerName"].ToString();

            //string str = "";
            //if (pRow[LegAdvocacy.Confirm.ToString()] == "False")
            //    str = JLanguages._Text("Confirm"); 
            //else
            //    str = JLanguages._Text("Not Confirm");

            node.Hint = JLanguages._Text("State:") + " " + pRow["Breakup_Type"] + "\n" +
                //JLanguages._Text("Type:") + " " + pRow[LegAdvocacy.Type.ToString()] + "\n" +
                       JLanguages._Text("StartDate:") + " " + 
                       JDateTime.FarsiDate(Convert.ToDateTime(pRow[LegAdvocacy.StartDate.ToString()]));
                       //JLanguages._Text("Confirm:") + " " + str;
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JAdvocacy.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JAdvocacy.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JAdvocacy.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion
    }


    public class JAdvocacys : JSystem
    {
        public JAdvocacys[] Items = new JAdvocacys[0];
        //  public String OrderName;
        public JAdvocacys()
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
                string WHERE = @"select Code, LetterNo AdvLetterNo, 
(Select Name From clsAllPerson Where Code = PersonCode) AdvocerName,
(select fa_date from StaticDates where En_Date=Cast(LetterDate as Date)) 'LetterDate',
(select fa_date from StaticDates where En_Date=Cast(StartDate as Date)) 'StartDate',
(select fa_date from StaticDates where En_Date=Cast(EndDate as Date)) 'EndDate',
(select HeadOffice from legNotary where Code=Cast(NotaryCode as Date)) 'NotaryName' ,
Description,
(case Breakup_Type 
when 0 then N'فعال'
when 1 then N'ارائه گواهی عزل از محضر'
when 2 then N'انجام امور توسط موکل'
when 3 then N'فوت (حجر)وکیل یا موکل'
when 4 then N'حکم دادگاه'
when 5 then N'عزل شده'
end) 'Breakup_Type',
--(select fa_date from StaticDates where En_Date=Cast(BreakupDate as Date)) 'BreakupDate',
--(select LetterNumber from LegNotaryLetter where Code=Breakup_Notary) 'Breakup_Notary',
--(select LetterNumber from LegNotaryLetter where Code=Breakup_tribunal) 'Breakup_tribunal',
(case Type
when 1 then N'اداری'
when 2 then N'بلاعزل' End) 'Type',
BreakupDesc

 from " + JTableNamesLegal.AdvocacyTable + " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JAdvocacys.GetDataTable", JTableNamesLegal.AdvocacyTable + ".Code");
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
            Nodes.ObjectBase = new JAction("GetAdvocacy", "Legal.JAdvocacy.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JAdvocacy.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }

        

        public static DataTable GetAdvocacy(string Codes)
        {
            JDataBase db = new JDataBase();
            try
            {
                string _Query = @"
                Select DISTINCT AT.Person_Code PCode  ,AT.Person_Code PersonCode
                    ,(Select Name From clsAllPerson Where  Code = AT.Person_Code) AttorneyName
                    ,(select fa_date from StaticDates where En_Date=Cast(StartDate as Date)) 'StartDate',
                    (select fa_date from StaticDates where En_Date=Cast(EndDate as Date)) 'EndDate',
                    (case Type
                    when 1 then 'اداری'
                    when 2 then 'بلاعزل' End) 'Type'
                    , (Select Name From clsAllPerson Where  Code = Ad.PersonCode) AdvocerName
                    from legAdvocacy Ad inner join LegAdvocate AT on Ad.Code = AT.Advocacy_Code
                    left join LegSubject LS on Ad.Code = LS.Advocacy_Code
                    left join LegAdvocacyFinance AF on Ad.Code = AF.Advocacy_Code ";
                
                _Query = _Query + " where  Code IN ( " + Codes + ")";
                db.setQuery(_Query);
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


        /// <summary>
        /// لیست وکلای یک شخص 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAdvocacy(int pPCode)
        {
            return GetAdvocacy(pPCode, DateTime.Now, JAdvocacySubjects.AllSubjects, 0);
        }
        public static DataTable GetAdvocacy(int pPCode, DateTime pDate)
        {
            return GetAdvocacy(pPCode, pDate, JAdvocacySubjects.AllSubjects, 0);
        }
        public static DataTable GetAdvocacy(int pPCode, DateTime pDate, JAdvocacySubjects pSubject)
        {
            return GetAdvocacy(pPCode, pDate, pSubject, 0);
        }
        public static DataTable GetAdvocacy(int pPCode, DateTime pDate, JAdvocacySubjects pSubject, int pAssetCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string _Query = @"
                Select DISTINCT Null Code, AT.Person_Code PCode , AT.Person_Code PersonCode
                    ,(Select Name From clsAllPerson Where  Code = AT.Person_Code) AttorneyName
                    ,(select fa_date from StaticDates where En_Date=Cast(StartDate as Date)) 'StartDate',
                    (select fa_date from StaticDates where En_Date=Cast(EndDate as Date)) 'EndDate',
                    (case Type
                    when 1 then 'اداری'
                    when 2 then 'بلاعزل' End) 'Type'
                    , (Select Name From clsAllPerson Where  Code = Ad.PersonCode) AdvocerName
                    from legAdvocacy Ad inner join LegAdvocate AT on Ad.Code = AT.Advocacy_Code
                    left join LegSubject LS on Ad.Code = LS.Advocacy_Code
                    left join LegAdvocacyFinance AF on Ad.Code = AF.Advocacy_Code ";

                /// وکالتهایی که مورد تائید واحد حقوقی هستند و منحل نشده اند
                _Query = _Query + " where  Ad.PersonCode = " + pPCode + @" and Breakup_Type = 0 AND Confirm = 1 ";

                /// تاریخ وکالت
                if (pDate != DateTime.MinValue)
                    _Query = _Query + " and StartDate<= " + JDataBase.Quote(pDate.ToString("yyyy/MM/dd"), false) +
                                    " and EndDate>= " + JDataBase.Quote(pDate.ToString("yyyy/MM/dd"),false);

                //موضوع وکالت
                _Query = _Query + " AND  LS.SubjectCode IN (" + JAdvocacySubjects.AllSubjects.GetHashCode() + ", " +
                    pSubject.GetHashCode() + ")";

                /// دارایی ها
                if (pAssetCode > 0)
                {
                    _Query = _Query + "AND (Ad.AllAssets = 1 OR AF.FinanceCode = " + pAssetCode +
                       " OR  LS.SubjectCode IN (" + JAdvocacySubjects.AllSubjects.GetHashCode() + ", " +
                     JAdvocacySubjects.RentContractAT2.GetHashCode() + ", " +
                     JAdvocacySubjects.DefinitiveContractAT2.GetHashCode() + ", " +
                     JAdvocacySubjects.GoodwillContractAT2.GetHashCode() + ", " +
                     JAdvocacySubjects.DefinitiveContractAT2.GetHashCode() + "))";
                }

                db.setQuery(_Query);
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
