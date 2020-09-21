using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JAssembly : JSystem
    {
        public int Code { get; set; }        
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// تاریخ برگزاری
        /// </summary>
        public DateTime Date{ get; set; }
        /// <summary>
        /// کد شرکت
        /// </summary>
        public int CompanyCode{ get; set; }
        /// <summary>
        /// دستورات جلسه
        /// </summary>
        public string Commands { get; set; }
        
        public JAssembly()
        {
        }
        public JAssembly(int pCode)
        {
            getData(pCode);
        }
        public JNode GetNode(System.Data.DataRow pRow)
        {

            JNode node = new JNode((int)pRow["Code"], "ManagementShares.JAssembly");
            Nodes.hidColumns = "CompanyCode";
            int[] codes = { node.Code };
            int CompanyCode = (int)pRow["CompanyCode"];
            foreach (DataRow row in Nodes.Selected.Rows)
            {
                Array.Resize(ref codes, codes.Length + 1);
                codes[codes.Length - 1] = Convert.ToInt32(row["Code"]);
            }
            /// شمارش آراء
            JAction pollingAction = new JAction("Polling...", "ManagementShares.JAssembly.Polling", null, new object[] { node.Code });
            node.Popup.Insert(pollingAction);
            /// حضور و غیاب
            JAction rollcallAction = new JAction("RollCall...", "ManagementShares.JAssembly.RollCall", null, new object[] { node.Code });
            node.Popup.Insert(rollcallAction);
            node.Popup.Insert("-");
            /// برگزاری مجمع
            JAction runAction = new JAction("RunAssembly...", "ManagementShares.JAssembly.RunAssembly", null, new object[] { node.Code });
            node.Popup.Insert(runAction);
            node.Popup.Insert("-");
            /// حذف 
            JAction delAgentAction = new JAction("Delete...", "ManagementShares.JAssembly.Delete", null, new object[] { node.Code });
            node.Popup.Insert(delAgentAction);
            ///  ویرایش
            JAction editAction = new JAction("Edit...", "ManagementShares.JAssembly.ShowDialog", new object[] { CompanyCode }, new object[] { node.Code });
            node.Popup.Insert(editAction);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// جدید
            JAction newAction = new JAction("New...", "ManagementShares.JAssembly.ShowDialog", new object[] { CompanyCode }, null);
            node.Popup.Insert(newAction);
            return node;
        }

        public bool Exists()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT * FROM ShareAssemblies WHERE Code<> {0} AND CompanyCode={1} AND Title='{2}'", this.Code, this.CompanyCode, this.Title));
                return DB.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                return false;
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert()
        {
            JAssemblyTable companyTable = new JAssemblyTable();
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JAssembly.Insert"))
                {
                    companyTable.SetValueProperty(this);
                    Code = companyTable.Insert();
                    if (Code > 0)
                    {
                        try
                        {
                            Nodes.DataTable.Merge((new JAssemblies(this.CompanyCode)).GetData(this.Code));
                        }
                        catch
                        {
                        }
                        return Code;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        public bool Update(JDataBase pDB)
        {
            JAssemblyTable JUBT = new JAssemblyTable();
            if (JPermission.CheckPermission("ManagementShares.JAssembly.Update"))
            {
                JUBT.SetValueProperty(this);
                if (JUBT.Update(pDB))
                {
                    Nodes.Refreshdata(Nodes.CurrentNode, (new JAssemblies(this.CompanyCode)).GetData(this.Code).Rows[0]);
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public Boolean Delete()
        {
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JAssembly.Delete")
                    && JMessages.Question("آیا میخواهید مجمع مورد نظر حذف شود؟", this.Title) == System.Windows.Forms.DialogResult.Yes)
                {
                    ///
                    JAssemblyTable JPT = new JAssemblyTable();
                    JPT.SetValueProperty(this);
                    if (JPT.Delete())
                    {
                        if (Nodes.CurrentNode != null)
                            Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    
        public void ShowDialog(int pCompanyCode)
        {
            if (this.Code == 0)
            {
                JAssemblyForm form = new JAssemblyForm();
                form.companyCode = pCompanyCode;
                form.State = JFormState.Insert;
                form.ShowDialog();
            }
            else
            {
                JAssemblyForm form = new JAssemblyForm(this.Code);
                form.companyCode = pCompanyCode;
                form.State = JFormState.Update;
                form.ShowDialog();
            }
        }

        public Boolean getData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM ShareAssemblies WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void RollCall()
        {
            if (!(JPermission.CheckPermission("ManagementShares.JAssembly.RollCall")))
                return;
            JAssemblyPresenceForm form = new JAssemblyPresenceForm(this.Code);
            form.ShowDialog();
        }

        public void RunAssembly()
        {
            JRunAssemblyForm form = new JRunAssemblyForm(this.Code);
            form.ShowDialog();
        }

        public void Polling()
        {
            JPollingsListFroms form = new JPollingsListFroms(this.Code);
            form.ShowDialog();
        }
    }

    public class JAssemblies : JSystem
    {
        public int CompanyCode;

        public JAssemblies(int pCompanyCode)
        {
            CompanyCode = pCompanyCode;
        }

        public System.Data.DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = " SELECT Code, Title, (Select Fa_Date FROM StaticDates WHERE En_date = Date) RunDate ,CompanyCode  FROM ShareAssemblies WHERE CompanyCode=" + CompanyCode.ToString();
                if (pCode > 0)
                    query += " AND Code = " + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JAssembly", "ManagementShares.JAssembly.GetNode");
            Nodes.DataTable = GetData(0);

            JAction newAction = new JAction("New...", "ManagementShares.JAssembly.ShowDialog", new object[]{this.CompanyCode}, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);
        }
    }
}
