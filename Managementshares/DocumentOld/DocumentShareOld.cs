using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JDocumentShareOld : JSystem
    {
        #region constructor
        public JDocumentShareOld()
        {
        }
        public JDocumentShareOld(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region property
        /// <summary>
        ///  
        /// </summary>
        public int Code { set; get; }        
        /// <summary>
        ///  
        /// </summary>
        public int PCode { set; get; }

        /// <summary>
        ///    
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public int CompanyCode { set; get; }
        
        #endregion

        public int insert()
        {
            JDataBase pDb = JGlobal.MainFrame.GetDBO();
            try
            {                
                return insert(pDb);
            }
            finally
            {
                pDb.Dispose();
            }
        }

        #region Method
        public int insert(JDataBase pDb)
        {
            JDocumentShareOldTable JPOT = new JDocumentShareOldTable();
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
                if (Code > 0)
                    return Code;
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
                JPOT.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            //if (JPermission.CheckPermission("Employment.JEmployeeInfo.Delete"))
            //{
            if (JMessages.Question("آیا میخواهید پرسنل انتخاب شده حذف شود؟", "حذف پرسنل") != System.Windows.Forms.DialogResult.Yes)
                return false;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JDocumentShareOldTable PDT = new JDocumentShareOldTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                {
                    ArchivedDocuments.JArchiveDocument p = new ArchivedDocuments.JArchiveDocument();
                    p.DeleteArchive("ManagementShares.JDocumentShareOldForm", PDT.Code, true);
                    Nodes.Delete(Nodes.CurrentNode);
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
                DB.Dispose();
                PDT.Dispose();
            }
            //}
            return false;
        }

        public bool Update(int pCompanyCode)
        {
            JDocumentShareOldTable JPOT = new JDocumentShareOldTable();
            try
            {
                JPOT.SetValueProperty(this);
                if (JPOT.Update())
                {
                    Nodes.Refreshdata(Nodes.CurrentNode, JDocumentShareOlds.GetDataTable(this.Code, pCompanyCode).Rows[0]);
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
                JPOT.Dispose();
            }
        }

        #endregion

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ManagementShares.JDocumentShareOld");
            Node.Name = pRow["Code"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ManagementShares.JDocumentShareOld.ShowForm", new object[] { Node.Code, pRow["Companycode"] }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "ManagementShares.JDocumentShareOld.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            //JAction newAction = new JAction("New...", "Employment.JJobTitle.ShowForm", null, null);            
            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            //Node.Popup.Insert(newAction);

            return Node;
        }

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from ShareDocumentShareOld where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
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

        public void ShowForm(int pCompanyCode)
        {
            ShowForm(0, pCompanyCode);
        }
        public void ShowForm(int pCode, int pCompanyCode)
        {
            if (pCode == 0)
            {
                JDocumentShareOldForm LandForm = new JDocumentShareOldForm(pCompanyCode);
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JDocumentShareOldForm LandForm = new JDocumentShareOldForm(pCode, pCompanyCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

    }

    public class JDocumentShareOlds : JSystem
    {

        public JDocumentShareOlds[] Items = new JDocumentShareOlds[0];
        public JDocumentShareOlds()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable(int pCompanyCode)
        {
            return GetDataTable(0, pCompanyCode);
        }
        public static DataTable GetDataTable(int pCode, int pCompanyCode)
        {
            string Where = " 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            if (pCompanyCode != 0)
                Where = Where + " And CompanyCode=" + pCompanyCode;

            string Query = @"select Code,
(select Name From ClsAllPerson where Code=PCode) Name,Description,CompanyCode from ShareDocumentShareOld Where " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
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
        
        #endregion GetData

        #region Node
        public void ListView(int pCompanyCode)
        {
            Nodes.ObjectBase = new JAction("DocumentShareOld", "ManagementShares.JDocumentShareOld.GetNode");
            Nodes.DataTable = GetDataTable(pCompanyCode);
            JAction newAction = new JAction("New...", "ManagementShares.JDocumentShareOld.ShowForm", new object[] { pCompanyCode }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }

    public class JDocumentShareOldTable : JTable
    {
        public JDocumentShareOldTable()
            : base("ShareDocumentShareOld")
        {
        }       
        /// <summary>
        ///  
        /// </summary>
        public int PCode;        
        /// <summary>
        ///    
        /// </summary>
        public string Description;
        /// <summary>
        ///  
        /// </summary>
        public int CompanyCode;
    }
}
