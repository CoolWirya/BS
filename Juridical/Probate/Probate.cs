using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JProbate:JSystem
    {
        #region Constructor
        public JProbate()
        {
        }
        public JProbate(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد گواهی حصروراثت
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کدشعبه قضایی صادر کننده حکم
        /// </summary>
        public int JudicialBranchCode { get; set; }
        /// <summary>
        /// کد درخواست کننده گواهی
        /// </summary>
        public int ApplicatorCode { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime Dateissued { get; set; }
        /// <summary>
        /// کدشخص متوفی
        /// </summary>
        public int DeadCode { get; set; }
        /// <summary>
        /// لیست ورثه
        /// </summary>
        public DataTable Heirs { get; set; }

        #endregion

        #region SearchMethod

        /// <summary>
        /// لیست ورثه
        /// </summary>
        public DataTable GetHeirs(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = "SELECT " +
                    JTableNamesLegal.ProbateInheritance + "." + JProbateInheritanceTableEnum.Code.ToString() + ", " +
                    JTableNamesLegal.ProbateInheritance + "." + JProbateInheritanceTableEnum.CodeProbate.ToString() + ", " +
                    JTableNamesLegal.ProbateInheritance + "." + JProbateInheritanceTableEnum.CodePerson.ToString() + ", " +
                    JTableNamesLegal.ProbateInheritance + "." + JProbateInheritanceTableEnum.inherText.ToString() + ", " +
                    JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.Name + ", " +
                    JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.Fam + ", " +
                    JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.ShSh + ", " +
                    JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.FatherName+","+
                    JTableNamesLegal.ProbateInheritance+"."+JProbateInheritanceTableEnum.RelationFamily.ToString()+","+
                    JTableNamesClassLibrary.SubBaseDefine + ".name  " + JProbateInheritanceTableEnum.RelationFamilyName + ", InherDesc"
                    + " FROM " + JTableNamesLegal.ProbateInheritance + " INNER JOIN " + JTableNamesClassLibrary.PersonTable +
                    " ON " + JTableNamesLegal.ProbateInheritance + "." + JProbateInheritanceTableEnum.CodePerson.ToString() + " = " +
                    JTableNamesClassLibrary.PersonTable + "." + JPersonTableEnum.Code+
                    " left outer join "+JTableNamesClassLibrary.SubBaseDefine+" on "+JTableNamesClassLibrary.SubBaseDefine+".Code="+JTableNamesLegal.ProbateInheritance+".RelationFamily"+
                    " WHERE " + JProbateInheritanceTableEnum.CodeProbate.ToString() + " = " + pCode.ToString();
                DB.setQuery(Query);
                if (DB.Query_DataSet())
                    return DB.DataSet.Tables[0];
                else
                    return null;
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

        public void GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoury = "select * from " + JTableNamesLegal.Probate + " where Code=" + pCode;
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }
        /// <summary>
        /// بررسی می کند که برای شخص متوفی گواهی فوت ثبت شده است یا نه
        /// </summary>
        /// <returns></returns>
        public static bool FindDead(int pCode)
        {
            string Qoury = "select code from "+JTableNamesLegal.Probate+" where "+ JProbateTableEnum.DeadCode.ToString() +"="+pCode.ToString();
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataSet();
                if (Db.DataSet.Tables[0].Rows.Count>0)
                {
                    return true;
                }
                else return false;
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
            JProbateTable JPT = new JProbateTable();
            int DefualtCodeProbat=999999;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Legal.JProbate.Insert"))
                {
                    if (FindDead(this.DeadCode))
                    {
                        JMessages.Error("ProbateExists", "Error");
                        return 0;
                    }

                    DB.beginTransaction("InsertProbate");
                    JPT.SetValueProperty(this);

                    Code = JPT.Insert(DefualtCodeProbat, DB, false);
                    if (Code > 0)
                    {
                        if (JProbateInheritances.Insert(
                            Heirs, Code, DB))
                        {
                            DB.Commit();
                            Nodes.DataTable.Merge(JProbates.GetDataTable(Code));
                            Histroy.Save(this, JPT, Code, "Insert");
                            return Code;
                        }
                        else
                        {
                            DB.Rollback("InsertProbate");
                            return 0;
                        }

                    }
                    else
                    {
                        DB.Rollback("InsertProbate");
                        return 0;
                    }
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                DB.Rollback("InsertProbate");
                return 0;
            }
            finally
            {
                JPT.Dispose();
            }
        }

        public bool Update()
        {
            JProbateTable JPT = new JProbateTable();
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Legal.JProbate.Update"))
                {
                    DB.beginTransaction("UpdateProbate");
                    JPT.SetValueProperty(this);
                    if (JPT.Update())
                    {
                        if (JProbateInheritances.Insert(Heirs, Code, DB))
                        {
                            Nodes.Refreshdata(Nodes.CurrentNode, JProbates.GetDataTable(Code).Rows[0]);
                            Histroy.Save(this, JPT, Code, "Update");
                        }
                        else
                        {
                            DB.Rollback("UpdateProbate");
                            return false;
                        }
                        DB.Commit();
                        return true;
                    }
                    DB.Rollback("UpdateProbate");
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                DB.Rollback("UpdateProbate");
                return false;
            }
            finally
            {
                JPT.Dispose();
            }
        }

        public bool Delete()
        {
            if (JMessages.Question("YouWandToDeleteProbate", "OK") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                JProbateTable JPT = new JProbateTable();
                try
                {
                    if (JPermission.CheckPermission("Legal.JProbate.Delete"))
                    {
                        JProbateInheritanceTable inTable = new JProbateInheritanceTable();
                        DB.beginTransaction("DeleteProbate");
                        inTable.DeleteManual(JProbateInheritanceTableEnum.CodeProbate.ToString() + " = " + this.Code, DB);
                        JPT.SetValueProperty(this);
                        if (JPT.Delete(DB))
                        {
                            ArchivedDocuments.JArchiveDocument ad = new ArchivedDocuments.JArchiveDocument();
                            ad.DeleteArchive(this.GetType().FullName, Code, false);
                            Nodes.Delete(Nodes.CurrentNode);
                            Histroy.Save(this, JPT, Code, "Delete");
                            DB.Commit();
                            return true;
                        }
                        DB.Rollback("DeleteProbate");
                    }
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    DB.Rollback("DeleteProbate");
                    return false;
                }
                finally
                {
                    JPT.Dispose();
                }
            }
            return false;
        }


        #endregion

        #region ShowData
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JProbateTableEnum.Code.ToString()], "Legal.JProbate");
            //JPerson newPerson = new JPerson((int)JProbateTableEnum.DeadCode);
            //JJudicialBranch newJudicialBranch = new JJudicialBranch((int)JProbateTableEnum.JudicialBranchCode);
            Node.Hint = JLanguages._Text("DeadPerson:") + pRow[JProbateTableEnum.DeadName.ToString()] + " \n " + JLanguages._Text("JudicialBranch:") + pRow[JProbateTableEnum.JudicialBranch.ToString()];
            Node.Name = pRow[JProbateTableEnum.DeadName.ToString()] + " - " + pRow[JProbateTableEnum.JudicialBranch.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            // اکشن جدید
            JAction newAction = new JAction("new...", "Legal.JProbate.ShowDialog", null, null);
            //اکشن ویرایش
            JAction EditAction = new JAction("edit...", "Legal.JProbate.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = EditAction;
            Node.EnterClickAction = EditAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("delete...", "Legal.JProbate.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            Node.Popup.Insert(newAction);
            Node.Popup.Insert(EditAction);
            Node.Popup.Insert(DeleteAction);

            return Node;

        }
        public void ShowDialog()
        {
            if (this.Code != 0)
            {
                JProbateForm JPF = new JProbateForm(this.Code);
                JPF.State = JFormState.Update;
                JPF.ShowDialog();
            }
            else
            {
                JProbateForm JPF = new JProbateForm();
                JPF.State = JFormState.Insert;
                JPF.ShowDialog();
            }
        }

        #endregion
    }

    class JProbates : JSystem
    {
        public  DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
            
        public static DataTable GetDataTable(int pCode)
        {
            string Qoury = "select "+JTableNamesLegal.Probate+@".Code,legJudicialBranch.Name +' - '+ (Select Name from dbo.legJudicialComplex where Code = legJudicialBranch.JudicialComplex)JudicialBranch ,person.Fam "
                +JProbateTableEnum.Applicator+
                ",(select fa_date from StaticDates where En_Date=Cast(Dateissued as Date)) 'Dateissued',"
                + JProbateTableEnum.DeadCode.ToString()+
                " ,DeadPerson.Name + ' ' + DeadPerson.Fam " + JProbateTableEnum.DeadName.ToString() +
                " from "+JTableNamesLegal.Probate+" inner  join "+JTableNamesLegal.JudicialBranch+" on "+JTableNamesLegal.JudicialBranch+".Code="+JTableNamesLegal.Probate+
                ".JudicialBranchCode inner join "+JTableNamesClassLibrary.PersonTable+" person on "+JTableNamesLegal.Probate+".ApplicatorCode=person.Code "+
                "inner join "+JTableNamesClassLibrary.PersonTable+" DeadPerson on "+JTableNamesLegal.Probate+".DeadCode=DeadPerson.Code";
            string Where = " Where 1=1 ";
                   // JPermission.getObjectSql("Legal.JProbates.GetDataTable",JTableNamesLegal.Probate+".Code");
            JDataBase Db=new JDataBase();
            try
            {
                if (pCode != 0)
                    Where = Where + " And " + JTableNamesLegal.Probate + ".Code=" + pCode;
                Db.setQuery(Qoury + Where);
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
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetProbate", "Legal.JProbate.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("new...", "Legal.JProbate.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);

            JToolbarNode TN = new JToolbarNode();
            TN.Click = newAction;
            TN.Icon = JImageIndex.Add;

            Nodes.AddToolbar(TN);
            
        }
                


        

    }
}
