using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JExpertise:JSystem
    {
        public JExpertise()
        {
        }

        public JExpertise(int pCode)
        {
            getData(pCode);
        }

        #region property
        public int Code { get; set; }
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int PetitionCode { get; set; }
        /// <summary>
        ///نظر کارشناسی 
        /// </summary>
        public string Comment { get; set; }
        #endregion

        #region Method

        public bool getData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qoury = "select * from " + JTableNameLegal.Expertise ;
                if (pCode > 0)
                    Qoury = Qoury + " WHERE  Code= " + pCode.ToString();
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
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
        public int Insert()
        {
            JExpertiseTable ExTable = new JExpertiseTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JExpertise.Insert"))
                {

                    ExTable.SetValueProperty(this);
                    int Code = ExTable.Insert();
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JExpertises.GetDatatable(Code));
                        Histroy.Save(this, ExTable, ExTable.Code, "Insert");
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                ExTable.Dispose();
            }
        }

        public bool Delete()
        {

            JExpertiseTable ExTable = new JExpertiseTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JExpertise.Delete"))
                {
                    ExTable.SetValueProperty(this);
                    if (ExTable.Delete())
                    {
                        Histroy.Save(this, ExTable, ExTable.Code, "Delete");
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                        return false;
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
                ExTable.Dispose();
            }

        }

        public bool upDate()
        {

            JExpertiseTable ExTable = new JExpertiseTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JExpertise.Update"))
                {
                    ExTable.SetValueProperty(this);
                    if (ExTable.Update())
                    {
                        Histroy.Save(this, ExTable, ExTable.Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JExpertises.GetDatatable(Code).Rows[0]);
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
                return false;
            }
            finally
            {
                ExTable.Dispose();
            }
        }
        #endregion
        #region Showdata&Node
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JExpertiseForm ExForm = new JExpertiseForm();
                ExForm.State = JFormState.Insert;
                ExForm.ShowDialog();
            }
            else
            {
                JExpertiseForm ExForm = new JExpertiseForm(Code);
                ExForm.State = JFormState.Update;
                ExForm.ShowDialog();
            }
        }


        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Legal.JExpertise");
            Node.Icone = JImageIndex.Default.GetHashCode();
            Node.Name = JLanguages._Text("کد دادخواست:") + pRow["PetitionNumber"];
            Node.Hint = JLanguages._Text("نظر کارشناسی:") + pRow["Comment"];
            //اکشن جدید
            JAction NewAction=new JAction("new...","Legal.JExpertise.ShowDialog",null,null);
            //اکشن ویرایش
            JAction editAction=new JAction("edit...","Legal.JExpertise.ShowDialog",null,new object []{Node.Code});
            Node.MouseDBClickAction=editAction;
            Node.EnterClickAction=editAction;
            //اکشن حذف
            JAction delAction=new JAction("del...","Legal.JExpertise.Delete",null,new object []{Node.Code});
            Node.DeleteClickAction=delAction;
            Node.Popup.Insert(delAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(NewAction);
            return Node;


        }

        #endregion


    }

    public class JExpertises:JSystem
    {
        
        public static DataTable GetDatatable(int pCode)
        {
            string SelectQouery = @"select code,(Select Number from LegPetition where Code=PetitionCode) 'PetitionNumber'
,Comment from "+JTableNameLegal.Expertise;
            string where = " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JExpertises.GetDataTable", JTableNameLegal.Expertise + ".Code");
            if (pCode > 0)
                where = where + " And code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery+where);
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

        public  DataTable  GetDatatable()
        {
            return GetDatatable(0);

        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetExpertise", "Legal.JExpertise.GetNode");
            Nodes.DataTable = GetDatatable();

            JAction NewAction = new JAction("new...", "Legal.JExpertise.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(NewAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = NewAction;
            Nodes.AddToolbar(TN);

            //Nodes.ObjectBase = new JAction("GetExpertise", Legal.JExpertise.GetNode);
            //Nodes.DataTable = GetDataTable();

            //JAction newAction = new JAction("New...", "Legal.JNotice.ShowDialog", null, null);
            //Nodes.GlobalMenuActions.Insert(newAction);
            //JToolbarNode TN = new JToolbarNode();
            //TN.Icon = JImageIndex.Add;
            //TN.Hint = "New...";
            //TN.Click = newAction;
            //Nodes.AddToolbar(TN);

           
        }
    }

}
