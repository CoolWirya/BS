using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JorgChart : JEmployment
    {
        #region Properties
                
        public int Code
        {
            get;
            set;
        }

        public int PostCode
        {
            get;
            set;
        }

        public int ParentCode
        {
            get;
            set;
        }
        #endregion

        #region Methods
                
        public int Insert()
        {
            JTableOrgChart PDT = new JTableOrgChart();
            try
            {
                if (JPermission.CheckPermission("Employment.JorgChart.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert();
                    if (Code > 0)
                    {
                        Histroy.Save(this, PDT, Code, "Insert");
                        //Nodes.Refreshdata(Nodes.CurrentNode, GetAllData(Code).Rows[0]);
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
            }
        }

        public bool Update()
        {
            JTableOrgChart PDT = new JTableOrgChart();
            try
            {
                if (JPermission.CheckPermission("Employment.JorgChart.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update())
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        //Nodes.Refreshdata(Nodes.CurrentNode, GetAllData(Code).Rows[0]);
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

        public bool Delete()
        {
            JTableOrgChart PDT = new JTableOrgChart();
            try
            {
                if (JPermission.CheckPermission("Employment.JorgChart.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                        if (PDT.Delete())
                        {
                            PDT.DeleteManual(" ParentCode= " + PDT.Code.ToString());
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

        public bool getData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM OrgChart WHERE Code=" + pCode.ToString());
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

        public DataTable FindParent(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM OrgChart WHERE ParentCode Is Null ");// + pCode.ToString());
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

        public void getData(ref int pCode,ref DataTable ChartTable)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pCode == 0)
                    DB.setQuery("SELECT * FROM OrgChart WHERE ParentCode Is Null ");
                else
                {
                    DB.setQuery("SELECT * FROM OrgChart WHERE ParentCode=" + pCode.ToString());
                    ChartTable = DB.Query_DataTable();
                    DB.setQuery("SELECT * FROM OrgChart WHERE Code=" + pCode.ToString());
                    pCode = (int)DB.Query_DataTable().Rows[0]["ParentCode"];
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
        }

        #endregion

        #region Nodes
                
        public void ShowDialog()
        {
                JfrmDefineChart JEPF = new JfrmDefineChart();
                JEPF.State = JFormState.Insert;
                JEPF.ShowDialog();            
        }

        public bool ShowForm()
        {
            return ShowForm(0);
        }

        public bool ShowForm(int pCode)
        {
            Employment.JfrmDefineChart form = new JfrmDefineChart();
            form.ShowDialog();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDR"></param>
        /// <returns></returns>
        public JNode GetNode(System.Data.DataRow pDR)
        {
            JNode node = new JNode((int)pDR["Code"], "Employment.JorgChart");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = pDR["ParentCode"].ToString();

            node.Hint = JLanguages._Text("Date:") + " " + pDR[LegPetition.Date.ToString()];// + "\n" +

            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Employment.JorgChart.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Employment.JorgChart.Delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Employment.JorgChart.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }

        #endregion
    }

    public class JorgCharts : JEmployment
    {
        public JorgChart[] Items = new JorgChart[0];
        public JorgCharts()
        {

        }

        public static DataTable GetAllData(int pCode)
        {
            string Where = "";
            if (pCode > 0)
                Where = " where code=" + pCode;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM OrgChart " + Where);               
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetDataByExp(string exp)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM OrgChart " + exp);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetAllDataWithFullTitle(int pCode)
        {
            string Where = "";
            if (pCode > 0)
                Where = " where OrgChart.code=" + pCode;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT OrgChart.Code,units.name +'-'+ metiers.name As 'full_title',OrgChart.ParentCode FROM OrgChart                 
                    inner Join empposts posts On posts.Code = OrgChart.PostCode
                    left outer join subdefine units on units.code = posts.unitcode
                    left outer join subdefine metiers on metiers.code = posts.metiercode
                    " + Where);               
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
        public DataTable getData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pCode == -1)
                    DB.setQuery("SELECT * FROM OrgChart");
                else if (pCode == 0)
                    DB.setQuery("SELECT * FROM OrgChart WHERE ParentCode = 0 ");
                else
                    DB.setQuery("SELECT * FROM OrgChart WHERE ParentCode=" + pCode.ToString());

                DB.Query_DataReader();
                Items = new JorgChart[DB.RecordCount];
                int count = 0;
                while (DB.DataReader.Read())
                {
                    Items[count] = new JorgChart();
                    JTable.SetToClassProperty(Items[count], DB.DataReader);
                    count++;
                }

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

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetNode", "Employment.JorgChart.GetNode");
            Nodes.DataTable = GetAllData(0);
            JAction newAction = new JAction("New...", "Employment.JorgChart.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);
        }
    }
}
