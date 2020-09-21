using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    public class JDeadPerson: JSystem
    {
        #region Properties
        /// <summary>
        /// کد شخص
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره گواهی فوت
        /// </summary>
        public string DieNumber { get; set; }
        /// <summary>
        /// تاریخ فوت
        /// </summary>
        public DateTime DieDate { get; set; }
        /// <summary>
        /// تاریخ گواهی فوت
        /// </summary>
        public DateTime DeathCertificateDate { get; set; }

        #endregion

           private JPerson _Person;

           public JDeadPerson(int pPersonCode)
           {
               if (pPersonCode != 0)
                   _Person = new JPerson(pPersonCode);
               Code = pPersonCode;
           }
           public void ShowDialog()
           {
               if (Code == 0)
               {
                   JDeadForm DeadForm = new JDeadForm();
                   DeadForm.State = JFormState.Insert;
                   DeadForm.ShowDialog();
               }
               else
               {
                   JDeadForm DeadForm = new JDeadForm(Code);
                   //DeadForm.State = JFormState.Update;
                   DeadForm.ShowDialog();
               }
           }

        /// <summary>
        /// حذف گواهی فوت
        /// </summary>
        public void DelDie()
        {
            /// بررسی اینکه حصر وراثت برای این گواهی فوت ثبت نشده باشد
            JDataBase tempdb = new JDataBase();
            tempdb.setQuery(" SELECT Count(*) FROM " + JTableNamesLegal.Probate + " WHERE " + JProbateTableEnum.DeadCode.ToString() + " = " + this.Code.ToString());
            if ((int)tempdb.Query_ExecutSacler() > 0)
            {
                JMessages.Error("ProbateExistsForDead", "Error");
                return;
            }
            if (JMessages.Question("YouWantToDeleteDieLette?", "OK") == System.Windows.Forms.DialogResult.Yes)
            {
                tempdb.setQuery("delete clsDeadPerson where (Code=" + _Person.Code + ")");
                _Person.Died = false;
                try
                {
                    tempdb.beginTransaction("DelDie");
                    tempdb.Query_Execute();
                    if (_Person.Update())
                    {
                        ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                        if (AD.DeleteArchive(this.GetType().FullName, Code, false))
                        {
                            //در صورتیکه شخص وکیل یا موکل باشد وکالت فعال شود

                            tempdb.Commit();
                            return;
                        }
                    }
                    tempdb.Rollback("DelDie");
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    tempdb.Rollback("DelDie");
                }
                finally
                {
                    tempdb.Dispose();
                }
            }
        }
        /// <summary>
        /// درج
        /// </summary>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase pDB = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Legal.JDeadPerson.Insert"))
                {
                    /// DeadPerson
                    JDeadPersonTable dTable = new JDeadPersonTable();
                    dTable.SetValueProperty(this);
                    /// Person
                    _Person.Died = true;
                    JPersonTable pTable = new JPersonTable();
                    pTable.SetValueProperty(_Person);

                    pDB.beginTransaction("InsertDie");
                    pTable.Update(pDB);
                    int result = dTable.Insert(Code, pDB, false,false,true);
                    //در صورتیکه شخص فوت شده وکیل باشد وکالت  منحل می شود
                    #region
                    if (!JAdvocacy.UpdateDieAdvocacy(_Person.Code, pDB))
                    {
                        pDB.Rollback("InsertDie");
                        return 0;

                    }
                    //درصورتیکه شخص فوت شده موکل باشد وکالت منحل مش یود
                    if (!JAdvocacy.UpdateDieVicarious(_Person.Code, pDB))
                    {
                        pDB.Rollback("InsertDie");
                        return 0;

                    }
                    #endregion
                    pDB.Commit();
                    Histroy.Save(this, dTable, Code, "Insert");
                    return result;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                pDB.Rollback("InsertDie");
                return 0;

            }
            finally
            {
                pDB.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase pDB = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Legal.JDeadPerson.Update"))
                {
                    /// DeadPerson
                    JDeadPersonTable dTable = new JDeadPersonTable();
                    dTable.SetValueProperty(this);

                    pDB.beginTransaction("UpdateDie");
                    dTable.Update(pDB);
                    if (pDB.Commit())
                    {
                        Histroy.Save(this, dTable, Code, "Update");
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
                pDB.Rollback("UpdateDie");
                return false;
            }
            finally
            {
                pDB.Dispose();
            }
        }

        /// <summary>
        /// ثبت گواهی فوت
        /// </summary>
        /// <returns></returns>
        public bool DiePerson(JDeadPerson pDeadPerson, JDataBase pDB)
        {
            return false;
        }
        public bool DiePerson()
        {
            JDataBase tempdb = new JDataBase();
            try
            {
                GetData();
                JDeadForm deadForm = new JDeadForm(this.Code);
                deadForm.ShowDialog();
                //if ( == System.Windows.Forms.DialogResult.OK)
                //{
                //    tempdb.beginTransaction("DiePerson");
                //    if (_Person.Died)
                //        tempdb.setQuery("UPDATE clsDeadPerson SET DieNumber = @Number, DieDate = @Date , DeathCertificateDate=@DeathCertificateDate WHERE Code = @Code ");
                //    else
                //        tempdb.setQuery("insert into clsDeadPerson(Code, DieNumber,DieDate,DeathCertificateDate)values(@Code,@Number,@Date,@DeathCertificateDate)");
                //    tempdb.AddParams("Code", _Person.Code);
                //    tempdb.AddParams("Number", DieNumber);
                //    tempdb.AddParams("Date", DieDate);
                //    tempdb.AddParams("DeathCertificateDate", DeathCertificateDate);
                //    tempdb.Query_Execute();
                    
                //    _Person.Died = true;
                //    JPersonTable table = new JPersonTable();
                //    table.SetValueProperty(_Person);
                //    if (table.Update(tempdb))
                //    {
                //        Histroy.Save(this, table, Code, "Update");
                //        //در صورتیکه شخص فوت شده وکیل باشد وکالت  منحل می شود
                //        #region
                //        if (!JAdvocacy.UpdateDieAdvocacy(_Person.Code, tempdb))
                //        {
                //            tempdb.Rollback("DiePerson");
                //            return false;
                //        }
                //        //درصورتیکه شخص فوت شده موکل باشد وکالت منحل مش یود
                //        if (!JAdvocacy.UpdateDieVicarious(_Person.Code, tempdb))
                //        {
                //            tempdb.Rollback("DiePerson");
                //            return false;
                //        }
                //        #endregion

                //        if (tempdb.Commit())
                //            deadForm.jArchiveList1.ArchiveList();
                //    }
                //    else
                //    {
                //        tempdb.Rollback("DiePerson");
                //        return false;
                //    }
                //    tempdb.Rollback("DiePerson");
                //    return true;
                //}
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
               // tempdb.Rollback("DiePerson");
                return false;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        public Boolean GetData()
        {
            JDataBase db = new JDataBase();
            db.setQuery("select * from clsDeadPerson where (Code=" + this.Code + ")");
            db.Query_DataReader();
            try
            {
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }
        public JNode GetNode(DataRow pRow)
        {
           JNode Node=new JNode((int)pRow[JDeadPersonTableEnum.Code.ToString()],"Legal.JDeadPerson");
           Node.Name = pRow[JDeadPersonTableEnum.Code.ToString()].ToString();
           Node.Icone = JImageIndex.Default.GetHashCode();
           JAction editAction = new JAction("edit...", "Legal.JDeadPerson.ShowDialog", null, new object[] { this._Person, this });
           JAction Delete = new JAction("delete...", "Legal.JDeadPerson.DelDie", null, null);
           Node.MouseDBClickAction = editAction;
           JPopupMenu pMenu = new JPopupMenu();
           pMenu.Insert(editAction);
           pMenu.Insert(Delete);
           Node.Popup = pMenu;
           return Node;



        }
    }
}
    public class JDeadPersons:JSystem
    {
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }  
    

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JDeadPersons.GetDataTable", JTableNamesClassLibrary.DeadPerson + ".Code");
            if (pCode > 0)
                Where = " And " + JTableNamesClassLibrary.DeadPerson + ".Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoury = "select "+JTableNamesClassLibrary.DeadPerson+".Code,"+JTableNamesClassLibrary.PersonTable+
                ".Name Name,"+JTableNamesClassLibrary.PersonTable+".Fam Fam,DieDate,DieNumber,DeathCertificateDate,Comment from "
                +JTableNamesClassLibrary.DeadPerson+" left  Join "+JTableNamesClassLibrary.PersonTable+" on "
                +JTableNamesClassLibrary.PersonTable+".Code="+JTableNamesClassLibrary.DeadPerson+".Code";
            try
            {
                Db.setQuery(Qoury+Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
            return null;

        }
    }
    public enum JDeadPersonTableEnum
    {
        Code,
        DieNumber,
        DieDate,
        DeathCertificateDate,
    }


