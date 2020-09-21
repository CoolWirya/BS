using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace Legal
{
    public enum JArrestType
    {
        Decision=1,
        Order=2,
    }
    public class JDistraint:JSystem
    {
        #region Constructor
        public JDistraint()
        {
        }
        public JDistraint(int pCode)
        {
            GetData(pCode);
            //fillDataTable();
        }
        #endregion

        #region Peroperty
        /// <summary>
        /// کدتوقیف اموال
        /// </summary>
        public int Code
        {
            set;
            get;
        }
        /// <summary>
        /// تاریخ توقیف
        /// </summary>
        public DateTime DistDate
        {
            get;
            set;
        }
        
        /// <summary>
        /// موضوع توقیف:1-شخص 2-دارایی 3-بخشی از دارایی
        /// </summary>
        public int Subject
        {
            get;
            set;
        }
        /// <summary>
        /// کدشخص توقیف شده
        /// </summary>
        public int Person
        {
            get;
            set;
        }
        /// <summary>
        /// کددارایی توقیف شده
        /// </summary>
        public int Asset
        {
            set;
            get;

        }
        /// <summary>
        /// کد شخصی که جزئی از دارائی های آن توقیف شده است
        /// </summary>

        public int AssetSharePerson
        {
            set;
            get;
        }
        /// <summary>
        /// جدول جزئی از دارایی توقیف شده
        /// </summary>
        public DataTable AssetShareTable
        {
            set;
            get;
        }
      
        /// <summary>
        /// کد حکم توقیف اموال
        /// </summary>
        public int Committal
        {
            set;
            get;
        }
        /// <summary>
        /// کد حکم رد توقیف اموال
        /// </summary>
        public int NotCommittal
        {
            set;
            get;
        }
        /// <summary>
        /// نوع توقیف-حکم یا دستور
        /// </summary>
        public JArrestType ArrestType
        {
            set;
            get;

        }
        /// <summary>
        /// مقام ارسال کننده دستور
        /// </summary>
        public string OrderSender
        {
            set;
            get;
        }
        /// <summary>
        /// توضیحات مربوط به دستور توقیف
        /// </summary>
        public string OrderComment
        {
            set;
            get;
        }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment
        {
            set;
            get;
        }
        /// <summary>
        /// توقیف فعال
        /// </summary>
        public bool Active
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ رفع توقیف
        /// </summary>
        public DateTime UnDistDate
        {
            get;
            set;
        }
        /// <summary>
        /// شرح رفع توقیف
        /// </summary>
        public string UnDistComment
        {
            get;
            set;
        }
        /// <summary>
        /// حکم رفع توقیف
        /// </summary>
        public int UnDistCommittal
        {
            get;
            set;
        }
        /// <summary>
        /// حکم / دستور رفع توقیف
        /// </summary>
        public int UnDistNotCommittal
        {
            get;
            set;
        }
        /// <summary>
        /// فرستنده دستور رفع توقیف
        /// </summary>
        public string UnDistOrderSender
        {
            get;
            set;
        }
        /// <summary>
        /// دستور رفع توقیف
        /// </summary>
        public string OrderCommentUnDist
        {
            get;
            set;
        }
        
        #endregion

        //private void fillDataTable()
        //{
        //    AssetShareTable=JDistraintAssetShares.GetPersonShares(this.AssetSharePerson);           
        //}
        #region FindMethod
        /// <summary>
        /// جستجو بر اساس کدحکم دادگاه
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool FindDecision(int pCodeDecision)
        {
            string Qoury = "Select * From "+JTableNamesLegal.Distraint + " where Committal=" + pCodeDecision;
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
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
                Db.Dispose();
            }

        }
        public bool GetData(int pCode)
        {
            string Qoury = "Select * From " + JTableNamesLegal.Distraint + " where Code=" + pCode;
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
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
                Db.Dispose();
            }

        }
        #endregion

        #region Method
        public int Insert()
        {
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            JDistraintTable JDT = new JDistraintTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JDistraint.Insert"))
                {
                    //if (FindDecision(this.Committal))
                    //{
                    //    JMessages.Error("این حکم قبلا ثبت شده است", "خطا در ورود اطلاعات");
                    //    return 0;
                    //}
                    pDb.beginTransaction("DistraintAssetShare");
                    int DefaultCode = 999999;
                    JDT.SetValueProperty(this);
                    int DistraintCode = JDT.Insert(DefaultCode, pDb, false);
                    if (DistraintCode > 0)
                    {
                        if (JDT.Subject == Convert.ToInt32(JDistraintSubjectEnum.AssetShare))
                        {
                            JDistraintAssetShares.Save(DistraintCode, this.AssetShareTable, pDb);

                        }
                        else if (JDT.Subject == (int)JDistraintSubjectEnum.Asset)
                        {
                            //توقیف یارد توقیف دارائی در جدول دارائی ها
                            //JAsset Asset = new JAsset(JDT.Asset);
                            //if (this.Committal > 0)
                            //{
                            //    //توقیف                                
                            //    Asset.Status = JStatusType.Block;
                            //    Asset.Update(pDb);                                
                            //}
                            //if (!this.Active)
                            //{
                            //    //رد توقیف
                            //    Asset.Status = JStatusType.Active;
                            //    Asset.Update(pDb);
                            //}

                            //Add Relation
                            JRelation tmpJRelation = new JRelation();
                            tmpJRelation.PrimaryClassName = "ClassLibrary.Asset";
                            tmpJRelation.PrimaryObjectCode = this.Asset;
                            tmpJRelation.ForeignClassName = "Legal.JDistraint";
                            tmpJRelation.ForeignObjectCode = JDT.Code;
                            tmpJRelation.Comment = "برای این دارایی اطلاعات توقیف ثبت شده است";
                            if (!tmpJRelation.Insert(pDb))
                                return -1;

                        }
                        else if (JDT.Subject == (int)JDistraintSubjectEnum.Person)
                        {
                            //توقیف یا رد توقیف شخص در جدول اشخاص
                            //JPerson Person = new JPerson(JDT.Person);
                            //if (this.Committal > 0)
                            //{                                
                            //    Person.Blocked = true;
                            //    Person.Update();
                            //}
                            //else if (this.NotCommittal > 0)
                            //{
                            //    Person.Blocked = false;
                            //    Person.Update();
                            //}
                            //Add Relation
                            JRelation tmpJRelation = new JRelation();
                            tmpJRelation.PrimaryClassName = "ClassLibrary.JPerson";
                            tmpJRelation.PrimaryObjectCode = this.Person;
                            tmpJRelation.ForeignClassName = "Legal.JDistraint";
                            tmpJRelation.ForeignObjectCode = JDT.Code;
                            tmpJRelation.Comment = "برای این شخص اطلاعات توقیف ثبت شده است";
                            if (!tmpJRelation.Insert(pDb))
                                return -1;

                        }
                        else
                        {
                            pDb.Rollback("DistraintAssetShare");
                            return 0;
                        }
                        pDb.Commit();
                        Histroy.Save(this, JDT, JDT.Code, "Insert");
                        Nodes.DataTable.Merge(JDistraints.GetDataTable(DistraintCode));
                        return DistraintCode;
                    }
                    else
                    {
                        pDb.Rollback("DistraintAssetShare");
                        return 0;
                    }
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                pDb.Rollback("DistraintAssetShare");
                return 0;
              
            }
            finally
            {
                JDT.Dispose();
            }
        }

        public bool Update()
        {
            JDistraintTable JDT = new JDistraintTable();
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Legal.JDistraint.Insert"))
                {
                    JDT.SetValueProperty(this);
                    pDb.beginTransaction("DistraintAssetShare");
                    if (JDT.Update(pDb))
                    {
                        if (JDT.Subject == Convert.ToInt32(JDistraintSubjectEnum.AssetShare))
                        {
                            JDistraintAssetShares.Save(this.Code, this.AssetShareTable, pDb);
                        }
                        pDb.Commit();
                        Histroy.Save(this, JDT, JDT.Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JDistraints.GetDataTable(this.Code).Rows[0]);
                        return true;
                    }
                    pDb.Rollback("DistraintAssetShare");
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                pDb.Rollback("DistraintAssetShare");
                return false;
            }
            finally
            {
                JDT.Dispose();
            }
        }

        public bool Delete()
        {
            if (JMessages.Question("آیا میخواهید رفع توقیف انتخاب شده حذف شود؟", "حذف") != System.Windows.Forms.DialogResult.Yes)
                return false;
            JDistraintTable JDT = new JDistraintTable();
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Legal.JDistraint.Insert"))
                {
                    pDb.beginTransaction("DistraintAssetShare");
                    JDT.SetValueProperty(this);
                    if (JDT.Subject == Convert.ToInt32(JDistraintSubjectEnum.AssetShare))
                    {
                        JDistraintAssetShares.DelDistraintAssetShare(this.Code, this.AssetShareTable, pDb);
                    }
                    if (JDT.Delete(pDb))
                    {
                        //Delete Relation
                        JRelation tmpJRelation = new JRelation();
                        if (!tmpJRelation.Delete("Legal.JDistraint", JDT.Code, pDb))
                        {
                            pDb.Rollback("DistraintAssetShare");
                            return false;
                        }

                        pDb.Commit();
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    pDb.Rollback("DistraintAssetShare");
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                pDb.Rollback("DistraintAssetShare");
                return false;
            }
            finally
            {
                JDT.Dispose();
            }
        }

        #endregion

        #region ShowMethod
        
        public void ShowDialog(bool pIsDistraint)
        {
            if (this.Code == 0)
            {
                JDistraintForm JDF = new JDistraintForm(pIsDistraint);
                JDF.State = JFormState.Insert;
                JDF.ShowDialog();
            }
            else if (this.Code > 0)
            {
                JDistraintForm JDF = new JDistraintForm(this.Code, pIsDistraint);
                JDF.State = JFormState.Update;
                JDF.ShowDialog();
            }
        }
        
        public void ShowDialog(JDistraintSubjectEnum DistrantType, string pClassName, int pObjectCode, int pPCode, bool IsDistraint)
        {
            JDistraintForm JDF = new JDistraintForm(DistrantType, pClassName, pObjectCode, pPCode, IsDistraint);
            JDF.State = JFormState.Insert;
            JDF.ShowDialog();
        }
        public JNode GetNode(DataRow pRow)
        {
            int _code=Convert.ToInt32(pRow[JDistraintTableEnum.Code.ToString()]);
            JNode Node = new JNode(Convert.ToInt32(pRow[JDistraintTableEnum.Code.ToString()]), "Legal.JDistraint");
            if (Convert.ToInt32(pRow[JDistraintTableEnum.Subject.ToString()]) == Convert.ToInt32(JDistraintSubjectEnum.Person))
            {
                Node.Name = JLanguages._Text("subject Distraint") +"-"+ JLanguages._Text("Person") + "\n" + JLanguages._Text("name ") +"-"+ pRow[JDistraintTableEnum.Person.ToString()]; 
            }
            else if (Convert.ToInt32(pRow[JDistraintTableEnum.Subject.ToString()]) == Convert.ToInt32(JDistraintSubjectEnum.Asset))
            {
                Node.Name = JLanguages._Text("subject Distraint") +"-"+ JLanguages._Text("Asset") + "\n" + JLanguages._Text("name ") +"-"+ pRow[JDistraintTableEnum.Asset.ToString()]; 
            }
            else if (Convert.ToInt32(pRow[JDistraintTableEnum.Subject.ToString()]) == Convert.ToInt32(JDistraintSubjectEnum.AssetShare))
            {
                Node.Name = JLanguages._Text("subject Distraint") + "-" + JLanguages._Text("AssetShare");// +"\n" + JLanguages._Text("Code ") + JLanguages._Text("Committal ") + pRow[JDistraintTableEnum.Committal.ToString()].ToString(); 
            }

            Nodes.hidColumns = "DistDate, Subject,  Person, Asset, AssetSharePerson, ArrestType ,OrderSender,OrderComment, ArrestType";
            Node.Icone = JImageIndex.Distraint.GetHashCode();
            //اکشن ویرایش
            JAction editeAction = new JAction("edit...", "Legal.JDistraint.ShowDialog", new object[] { true }, new object[] { _code });
            Node.EnterClickAction = editeAction;
            Node.MouseDBClickAction = editeAction;
            //اکشن رفع توقیف
            JAction undistAction = new JAction("UnDistraint...", "Legal.JDistraint.ShowDialog", new object[] { false }, new object[] { _code });
            //اکشن حذف
            JAction DeleteAction = new JAction("delete...", "Legal.JDistraint.Delete", null, new object[] { _code });
            Node.DeleteClickAction = DeleteAction;
            //اشکن جدید
            JAction NewAction = new JAction("new...", "Legal.JDistraint.ShowDialog", new object[] { true }, null);
            JPopupMenu pMenu=new JPopupMenu("Legal.JDistraint",Convert.ToInt32( pRow[JDistraintTableEnum.Code.ToString()]));
            pMenu.Insert(undistAction);
            pMenu.Insert("-");
            pMenu.Insert(DeleteAction);
            pMenu.Insert(editeAction);
            pMenu.Insert(NewAction);
            Node.Popup = pMenu;

            return Node;
        }
        #endregion

        #region CheckDistraint
        /// <summary>
        /// چک میکند آیا یک شخص ممنوع المعامله هست یا خیر
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public static bool CheckPersonIsBlock(int PCode)
        {
            return CheckPersonIsBlock(PCode, DateTime.MinValue);
        }
        public static bool CheckPersonIsBlock(int PCode,DateTime pDate)
        {
            string Query = " SELECT * FROM legDistraint WHERE Active = 1 AND Person = "+PCode;
            if (pDate != DateTime.MinValue)
                Query = Query + " AND DistDate<= " + JDataBase.Quote(pDate.ToString("yyyy/MM/dd"));
            JDataBase db = new JDataBase();

            try
            {
                db.setQuery(Query);
                DataTable DT = db.Query_DataTable();
                return DT.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return true;
        }
        /// <summary>
        /// چک کردن توقیف بودن دارایی
        /// </summary>
        /// <param name="pAssetCode"></param>
        /// <returns></returns>
        public static bool CheckAssetIsBlock(int pAssetCode)
        {
            return CheckAssetIsBlock(pAssetCode, DateTime.MinValue);
        }
        public static bool CheckAssetIsBlock(int pAssetCode, DateTime pDate)
        {
            string Query = " SELECT * FROM legDistraint WHERE Active = 1 AND Asset = " + pAssetCode;
            if (pDate != DateTime.MinValue)
                Query = Query + " AND DistDate<= " + JDataBase.Quote(pDate.ToString("yyyy/MM/dd"));
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                if (db.Query_DataReader())
                    return db.DataReader.Read();
                else return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.DataReader.Close();
                db.Dispose();
            }
            return true;
        }
        /// <summary>
        /// چک کردن جزئی از دارایی شخص
        /// </summary>
        /// <param name="pAssetCode"></param>
        /// <param name="pPersonCode"></param>
        /// <param name="pShare"></param>
        /// <returns></returns>
        public static bool CheckAssetShareIsBlock(int pAssetCode, int pPersonCode, float pShare)
        {
            return CheckAssetShareIsBlock(pAssetCode, pPersonCode, pShare, DateTime.MinValue);
        }
        public static bool CheckAssetShareIsBlock(int pAssetCode, int pPersonCode, float pShare, DateTime pDate)
        {
            string Query = @" SELECT D.* FROM legDistraint D 
            inner join legDistraintAssetShare DA on D.Code = DA.Distraint
            where D.Active = 1 AND  DA.ACode = " + pAssetCode +
            " AND D.AssetSharePerson=" + pPersonCode +
            " AND DA.Distrainted - " + pShare + " <=0";
            if (pDate != DateTime.MinValue)
                Query = Query + " AND DistDate<= " + JDataBase.Quote(pDate.ToString("yyyy/MM/dd"));
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return true;
        }

        #endregion CheckDistraint

    }
    class JDistraints : JSystem
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JDistraints.GetDataTable", JTableNamesLegal.Distraint+".Code");
            if (pCode > 0)
                Where =Where + " And " + JTableNamesLegal.Distraint + ".code=" + pCode;
            string Qoury = @"SELECT (Select Fa_Date From StaticDates WHERE En_Date =  Cast([DistDate] as Date)) DistraintDate
      ,Case Subject When 1 then 'شخص' when 2 then 'دارایی' when 3 then 'جزئی از دارایی' else '' end DistraintSubject
      ,ISNULL ((Select Name from clsAllPerson where Code = [Person]), 
      ISNULL((Select Name from clsAllPerson where Code = [AssetSharePerson]),
      (
      (Select distinct  
               substring((Select ','+(select Name from clsallperson where Code=ST1.PersonCode)  AS [text()]
                From dbo.finassetshare ST1
                Where ST1.ACode = ST2.ACode
                AND acode=Asset and status=1
                ORDER BY ST1.ACode
                For XML PATH ('')),2, 1000) [finassetshare]
         From dbo.finassetshare ST2
         WHERE   status=1 AND acode=Asset))
      )
      ) PersonName
      ,(Select Comment  from  vFinAsset  Where Code = [Asset]) AssetComment
      , Case Active When 1 then 'توقیف' when 0 then 'رفع توقیف' else '' end DistraintStatus
      ,[Comment]
      ,[ArrestType],[OrderSender],[OrderComment]
      ,[Code], [DistDate], Subject,  [Person], [Asset], [AssetSharePerson]
  FROM [legDistraint]" + Where;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qoury);
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
        public void ListView()
        {
            
            Nodes.ObjectBase = new JAction("node", "Legal.JDistraint.GetNode");
            Nodes.DataTable = JDistraints.GetDataTable();
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click=new JAction("new...", "Legal.JDistraint.ShowDialog", new object[] { true }, null);
            JTN.Hint = "New...";
            Nodes.AddToolbar(JTN);
            JAction newAction = new JAction("new...", "Legal.JDistraint.ShowDialog", new object[] { true }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            
            
        }


       
    }
}
