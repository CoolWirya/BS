using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JAssemblyPresence : JSystem
    {
        public int Code { get; set; }
        /// <summary>
        /// کد مجمع
        /// </summary>
        public int ACode { get; set; }
        /// <summary>
        /// کد وکیل )کد شخص(
        /// </summary>
        public int AgentPCode { get; set; }
        /// <summary>
        /// زمان حضور
        /// </summary>
        public DateTime PresenceTime { get; set; }

        public bool Exists()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT Code FROM ShareAssemblyPresence WHERE Code<> {0} AND ACode = {2} AND AgentPCode={1} ", this.Code, this.AgentPCode, this.ACode ));
                return DB.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert()
        {
            JAssemblyPresenceTable companyTable = new JAssemblyPresenceTable();
            try
            {
                    companyTable.SetValueProperty(this);
                    Code = companyTable.Insert();
                    if (Code > 0)
                    {
                        return Code;
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

        public Boolean Delete()
        {
            try
            {
                if (JMessages.Question("آیا میخواهید نماینده مورد نظر از لیست حاضرین حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    ///
                    JAssemblyPresenceTable JPT = new JAssemblyPresenceTable();
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

    }

    public class JAssemblyPresences :JSystem
    {
         public int AssemblyCode;

         public JAssemblyPresences(int pAssemblyCode)
        {
            AssemblyCode = pAssemblyCode;
        }
        /// <summary>
        /// حاضرین در مجمع
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public System.Data.DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
				string query = @" SELECT AgentPCode ,Name
                  ,Cast (Cast ([PresenceTime] As Time) AS varchar(5)) PresenceTime
                  ,ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where Status = 1 AND ACode = (Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code)), 0) +
                  ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where Status = 1 AND ACode is null AND pCode = A.AgentPCode), 0) VoteRight
              FROM [ShareAssemblyPresence] A
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code
               WHERE ACode=" + AssemblyCode.ToString();
                if (pCode > 0)
                    query += " AND Code = " + pCode;
                DB.setQuery(query + " ORDER BY PresenceTime ");
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
        /// <summary>
        /// تعداد اشخاص حاضر
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfExistingAgents()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"  SELECT Count( AgentPCode )  FROM [ShareAssemblyPresence]
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code WHERE ACode = " + AssemblyCode.ToString();
                DB.setQuery(query);
                return Convert.ToInt32(DB.Query_DataTable().Rows[0][0]);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// تعداد رای حاضر
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfExistingRights()
        {
            JDataBase DB = new JDataBase();
            try
            {
				string query = @" Select ISNULL( Sum(VoteRight), 0) from
              (
				SELECT ACode,  
					(
						isnull((Select SUM(ShareCount) FROM ShareSheet Where Status = 1 AND 
							ACode = (
								Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code
								)
						),0)
						+
						isnull((Select SUM(ShareCount) FROM ShareSheet Where Status = 1 AND ACode is null AND
							PCode = B.AgentPCode
							),0)

					)
				 VoteRight
              FROM [ShareAssemblyPresence] B
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code) A
              WHERE ACode=" + AssemblyCode.ToString();
                DB.setQuery(query);
                return Convert.ToInt32(DB.Query_DataTable().Rows[0][0]);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public JNode[] TreeView()
        {
            return null;
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JAssembly", "ManagementShares.JAssembly.GetNode");
            Nodes.DataTable = GetData(0);

            JAction newAction = new JAction("New...", "ManagementShares.JAssembly.ShowDialog", new object[]{this.AssemblyCode}, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);
        }
    }
}
