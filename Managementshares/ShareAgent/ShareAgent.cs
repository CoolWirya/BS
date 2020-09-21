using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public enum JAgentStatus
    {
        Disable = 0,
        Enable = 1,
        All = 100,
    }
    public class JShareAgent :JManagementshares
    {
        public int Code { get; set; }
        public int PCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// تاریخ غیر فعال کردن توسط کاربر
        /// </summary>
        public DateTime DeActiveDate { get; set; }
        public int Status { get; set; }
        public bool IsFormal{ get; set; }
        public int CompanyCode { get; set; }

        public JShareAgent(int pCode , int pCompanyCode)
        {
            CompanyCode = pCompanyCode;

            if (pCode > 0)
                this.GetData(pCode);
        }

        public void GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {

                db.setQuery(" SELECT * From ShareAgent WHERE Code = " + pCode);
                DataTable agentTable = db.Query_DataTable();
                if (agentTable.Rows.Count > 0)
                    JTable.SetToClassProperty(this, agentTable.Rows[0]);
            }
            finally
            {
                db.DisConnect();
            }
        }

        public int Insert()
        {
            JShareAgentTable agentTable = new JShareAgentTable();
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JShareAgent.Insert"))
                {
                    agentTable.SetValueProperty(this);
                    Code = agentTable.Insert();
                    if (Code > 0)
                    {
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

        public bool Update()
        {
            JShareAgentTable JUBT = new JShareAgentTable();
            if (JPermission.CheckPermission("ManagementShares.JShareAgent.Update"))
            {
                JUBT.SetValueProperty(this);
                return JUBT.Update();
            }
            return false;
        }

        public void ShowDialog(int pCode, JNode pNode)
        {
            JNewAgentForm form = new JNewAgentForm(pCode,CompanyCode);
            if(form.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                Nodes.Refreshdata(pNode, JShareAgents.GetDataTable(JAgentStatus.All, pNode.Code, CompanyCode).Rows[0]);
            }
        }
        public static bool CheckExist(Int64 pPCode, int pCompanyCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(JShareAgents.Query + " WHERE ShareAgent.PCode = " + pPCode + " and P.CompanyCode=" + pCompanyCode);
                DataTable agentTable = db.Query_DataTable();
                return (agentTable.Rows.Count > 0);
            }
            finally
            {
                db.DisConnect();
            }
        }
        /// <summary>
        /// تعداد سهام مورد وکالت وکیل
        /// </summary>
        /// <returns></returns>
        public int GetShareCount()
        {
            string sql = " Select IsNull(SUM(ShareCount),0) from ShareSheet Where ShareSheet.Status = " + JSheetStatus.Active.GetHashCode() + " and ACode = " + this.Code + " AND CompanyCode=" + this.CompanyCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(sql);
                return Convert.ToInt32(db.Query_DataTable().Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// تعداد اشخاص مورد وکالت
        /// </summary>
        /// <returns></returns>
        public int GetPersonCount()
        {
            string sql = " Select COUNT (*) from( Select ShareSheet .PCode from ShareSheet Where ShareSheet.Status = " + JSheetStatus.Active.GetHashCode() + " and ACode = " + this.Code + " AND CompanyCode=" + this.CompanyCode + " group by ShareSheet.PCode ) as a";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(sql);
                return Convert.ToInt32(db.Query_DataTable().Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }
        public void ChangeState( JAgentStatus pStatus, JNode node)
        {
            if(pStatus== JAgentStatus.Disable)
            {
                if (JMessages.Question("آیا میخواهید وضعیت وکیل به غیر فعال تغییر یابد؟", "تائید") == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Status = JAgentStatus.Disable.GetHashCode();
                   if( this.Update())
                       Nodes.Refreshdata(node, JShareAgents.GetDataTable(JAgentStatus.All, node.Code,CompanyCode).Rows[0]);
                }
            }
            if (pStatus == JAgentStatus.Enable)
            {
                if (JMessages.Question("آیا میخواهید وضعیت وکیل به فعال برگردد؟", "تائید") == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Status = JAgentStatus.Enable.GetHashCode();
                    if(this.Update())
                        Nodes.Refreshdata(node, JShareAgents.GetDataTable(JAgentStatus.All, node.Code, CompanyCode).Rows[0]);
                }
            }
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "ManagementShares.JShareAgent");
            int pCode = (int)pRow["PCode"];
            JAction editAction = new JAction("AgentInfo...", "ClassLibrary.JPerson.ShowDialog", null, new object[] { pCode });
            node.Popup.Insert(editAction);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            node.Popup.Insert("-");
            if ((int)pRow["Status"] == JAgentStatus.Enable.GetHashCode())
            {
                /// ابطال وکالت
				JAction disableAction = new JAction("DisableAgent...", "ManagementShares.JShareAgent.ChangeState", new object[] { JAgentStatus.Disable, node }, new object[] { node.Code, CompanyCode });
                node.Popup.Insert(disableAction);
            }
            if ((int)pRow["Status"] == JAgentStatus.Disable.GetHashCode())
            {
                /// برگشت به حالت فعال
				JAction enableAction = new JAction("EnableAgent...", "ManagementShares.JShareAgent.ChangeState", new object[] { JAgentStatus.Enable, node }, new object[] { node.Code, CompanyCode });
                node.Popup.Insert(enableAction);
            }
            node.Popup.Insert("-");
            /// ویرایش
            int code = node.Code;
            JAction EditAction = new JAction("Edit...", "ManagementShares.JShareAgent.ShowDialog", new object[] { code , node}, new object[] { node.Code, CompanyCode });
            node.Popup.Insert(EditAction);
            node.EnterClickAction = EditAction;
            node.MouseDBClickAction= EditAction;
            /// جدید
            JAction newAction = new JAction("New...", "ManagementShares.JShareAgent.ShowDialog", new object[] { 0, node }, new object[] { node.Code, CompanyCode });
            node.Popup.Insert(newAction);     
            return node;
        }
    }

    public class JShareAgents : JSystem
    {
        public void ListView(int pCompanyCode )
        {
			Nodes.ObjectBase = new JAction("JShareCompany", "ManagementShares.JShareAgent.GetNode", null, new object[] { 0,pCompanyCode });
            Nodes.DataTable = GetDataTable(JAgentStatus.All, 0 , pCompanyCode);
        }
        public static string Query = @"SELECT ShareAgent.Code , PCode,P.SharePCode,P.Name AgentName
                    ,(Select Fa_Date  From StaticDates Where En_Date = StartDate ) StartDate
                    ,(Select Fa_Date From StaticDates Where En_Date = EndDate) EndDate
                    ,Case Status 
	                    When 1 then N'فعال'
	                    When 0 then N'غیر فعال' end StatusTitle, Status 
                    ,Case IsFormal
	                    When 1 then N'رسمی'
	                    When 0 then N'غیر رسمی' end Formal_NotFormal
                     --   , (Select COUNT(Code )  from ShareSheet Where ShareSheet.Status = 1 and ACode = ShareAgent.Code ) SheetsCount
                        , (Select COUNT (*) from( Select ShareSheet .PCode from ShareSheet Where ShareSheet.Status = 1 and ACode = ShareAgent.Code  group by ShareSheet.PCode ) A) PersonToAgentCount
                        , (Select IsNull(SUM(ShareCount),0) from ShareSheet Where ShareSheet.Status = 1 and ACode = ShareAgent.Code  and CompanyCode = P.CompanyCode) SharesCount 
					, P.IDNo  , P.FatherName , P.NationalCode_CommercialCode NationalCode
					, P.HomeAddress ,  P.HomeTel , P.HomePostCode ,P.Mobile ,P.WorkAddress , P.WorkPostCode , P.WorkTel,P.HomeCity  
                     From ShareAgent 
                    INNER JOIN PersonAddressViewSharePCode P ON P.Code = ShareAgent.PCode and
					P.CompanyCode=ShareAgent.CompanyCode ";

        public static string GetQuery(JAgentStatus Status, int pCode, int pCompanyCode)
        {
            string _query = Query;
            if (Status != JAgentStatus.All)
                _query += " WHERE Status = " + Status.GetHashCode();
            if (pCode > 0)
                _query += " AND ShareAgent.Code = " + pCode;
            if (pCompanyCode > 0)
                _query += " AND ShareAgent.CompanyCode = " + pCompanyCode;
            return _query;
        }
        public static DataTable GetDataTable(JAgentStatus Status, int pCode, int pCompanyCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = GetQuery(Status, pCode, pCompanyCode);
                db.setQuery(sql + " ORDER BY Status DESC, P.Code DESC  ");
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
        /// لیست وکلای  یک شخص
        /// </summary>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonSheetAgents(int personCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = @"Select   ShareSheet .Code , ShareSheet.Az , ShareSheet .Ela 
,clsAllPerson .Code AgentPCode, clsAllPerson .Name AgentName, ShareSheet.ACode
            		,(Select Top 1 Mobile FROM clsPersonAddress Where PCode = clsAllPerson .Code) Mobile
                     from ShareSheet
	                    INNER JOIN ShareAgent ON ShareSheet .ACode = ShareAgent.Code  AND ShareAgent .Status = 1
	                    INNER JOIN clsAllPerson ON clsAllPerson.Code = ShareAgent.PCode 
	                    Where ShareSheet .Status = 1 AND ShareSheet.PCode = " + personCode;
                db.setQuery(sql);
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
        /// لیست وکلای  یک شخص
        /// </summary>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonAgents(int personCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = @"Select   distinct 
                    clsAllPerson.Code Code
                    ,clsAllPerson .Name AgentName
            		,(Select Top 1 Mobile FROM clsPersonAddress Where PCode = clsAllPerson .Code) Mobile
                     from ShareSheet
	                    INNER JOIN ShareAgent ON ShareSheet .ACode = ShareAgent.Code  AND ShareAgent .Status = 1
	                    INNER JOIN clsAllPerson ON clsAllPerson.Code = ShareAgent.PCode 
	                    Where ShareSheet .Status = 1 AND ShareSheet.PCode = " + personCode;
                db.setQuery(sql);
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
