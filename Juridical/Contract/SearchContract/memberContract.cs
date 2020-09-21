using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Security
{
    public class JMemberContract : JSecurity
    {
        /// <summary>
        /// شماره 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// كد شخص
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// كد قرارداد
        /// </summary>
        public int CodeContract { get; set; }
        /// <summary>
        /// تاريخ اتمام
        /// </summary>
        public DateTime Expire_Date { get; set; }
        /// <summary>
        /// سمت
        /// </summary>
        public int JobPostion { get; set; }
        /// <summary>
        /// متن نمايشي
        /// </summary>
        public string Hint { get; set; }
        /// <summary>
        /// وضعيت حراستي
        /// </summary>
        public Boolean Status { get; set; }



        #region method

        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return Insert(DB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert(JDataBase pDB)
        {
            try
            {
                if (JPermission.CheckPermission("Security.JMemberContract.Insert"))
                {
                    JmemberContracttable JCT = new JmemberContracttable();
                    JCT.SetValueProperty(this);
                    Code = JCT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JmemberContracts.GetDataTable(Code));
                    }
                    return Code;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }
       
        public bool Update()
        {
            if (JPermission.CheckPermission("Security.JMemberContract.Update"))
            {
                JmemberContracttable JCT = new JmemberContracttable();
                JCT.SetValueProperty(this);
                return JCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Security.JMemberContract.Delete"))
            {
                Code = pCode;
                JmemberContracttable JCT = new JmemberContracttable();
                if (JCT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTabSecurity.MemberContract + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
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
                DB.Dispose();
            }
        }



        public JMemberContract()
        {
        }

        public JMemberContract(int PCode)
        {
            this.GetData(PCode);
        }

        public void ShowForm(int pCode)
        {
            if (pCode == 0)
            {
                FrmMemberContract JGCF = new FrmMemberContract(this);
                JGCF.State = JFormState.Insert;
                JGCF.ShowDialog();
            }
            else
            {

                GetData(pCode);
                FrmMemberContract JGCF = new FrmMemberContract(this);
                JGCF.State = JFormState.Update;
                JGCF.ShowDialog();
            }
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["Code"].ToString();

            Node.MouseDBClickAction = new JAction("ShowDataSecurity", "Security.JMemberContract.ShowForm", new object[] { (int)pDR["Code"] }, null);

            JAction DeleteAct = new JAction("Delete", "Security.JMemberContract.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            int pCode = Convert.ToInt32(pDR["PersonCode"].ToString());
            JAction personAction = new JAction();
            JAllPerson allPerson = new JAllPerson(pCode);
            if (allPerson.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", null, new object[] { pCode });
            else if (allPerson.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", null, new object[] { pCode });
            Node.Popup.Insert(personAction);
            int pContractCode = Convert.ToInt32(pDR["CodeContract"].ToString());
            Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
            Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
            JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
            Node.Popup.Insert(viewContract);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "نام گروه " + (char)13 + Node.Name;
            return Node;
        }





    }

    public class JmemberContracts : JSecurity
    {
        public static System.Data.DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static System.Data.DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And dbo.SecLinkPerson.Code=" + pCode.ToString();
                DB.setQuery("SELECT     dbo.SecLinkPerson.Code, dbo.vContracts.Asset, dbo.clsAllPerson.Name," + JDataBase.SQLMiladiToShamsi("dbo.SecLinkPerson.Expire_Date", "ExpireDate") + ", " +
                      "dbo.subdefine.name AS JobPostion ,dbo.SecLinkPerson.PersonCode,dbo.SecLinkPerson.CodeContract " +
                "FROM   dbo.SecLinkPerson INNER JOIN dbo.clsAllPerson ON dbo.SecLinkPerson.PersonCode = dbo.clsAllPerson.Code INNER JOIN "+
                      "dbo.subdefine ON dbo.SecLinkPerson.JobPostion = dbo.subdefine.Code INNER JOIN dbo.vContracts ON dbo.SecLinkPerson.CodeContract = dbo.vContracts.Code" + pWhere + " And " +
                   JPermission.getObjectSql("Security.JMemberContract.GetDataTable", "JMemberContract.Code"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return GetDataTable();
        }

        public void ListView()
        {

            Nodes.ObjectBase = new JAction("GetNode", "Security.JMemberContract.GetNode");
            Nodes.DataTable = GetDataTable();

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("SecurityContract", "Security.JMemberContract.ShowForm", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }

    }
        #endregion
}
