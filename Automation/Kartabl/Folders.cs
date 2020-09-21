using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Automation
{
    public class JAFolder : JAutomation
    {

       #region Properties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///کد پست کاربر 
        /// </summary>
        public int User_post_code { get; set; }
        /// <summary>
        ///کد پدر
        /// </summary>
        public int parent_code { get; set; }
        /// <summary>
        ///نام کارتابل 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// نوع شاخه
        /// </summary>
        public int FolderType { get; set; }
        /// <summary>
        ///  تاریخ ایجاد 
        /// </summary>
        public DateTime Create_Date_Time { get; set; }
        /// <summary>
        ///کد پست کاربر
        /// </summary>
        public int Sender_User_post_code { get; set; }
        /// <summary>
        /// نوع شی
        /// </summary>
        public string Object_type { get; set; }
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// حذف از کارتابل
        /// </summary>
        public bool DeleteFromKartable { get; set; }
       #endregion

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JAFolder()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JAFolder(int pCode)
        {
            GetData(pCode);
        }

        #endregion

        // Insert , Update , Delete
        #region BaseFunctions
        public int Insert()
        {
            Create_Date_Time = DateTime.Now;
            User_post_code = JMainFrame.CurrentPostCode;

            JFolderTable ActionTable = new JFolderTable();
            ActionTable.SetValueProperty(this);
            Code = ActionTable.Insert();
            Nodes.InsertInTreeView(GetNode());
            if (Code > 0)
            {
                Histroy.Save(this, ActionTable, Code, "Insert");
                return Code;
            }
            else
                return 0;
        }


        public bool Delete(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JMessages.Question(" آیا می خواهید حذف شود ؟ ", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (GetChildsNode(pCode).Length == 0)
                    {
                        JFolderTable ActionTable = new JFolderTable();
                        JReferFolder tmpJReferFolder = new JReferFolder();
                        ActionTable.Code = pCode;
                        db.beginTransaction("DeleteFolder");
                        if (ActionTable.Delete(db))
                        {
                            if (tmpJReferFolder.Delete(pCode, db) >= 0)
                            {
                                if (db.Commit())
                                {
                                    Histroy.Save(this, ActionTable, Code, "Delete");
                                    //Nodes.DeleteNodeInTreeView(Nodes.TreeNodes.CurrentNode);
                                    return true;
                                }
                                else
                                {
                                    db.Rollback("DeleteFolder");
                                    return false;
                                }
                            }
                            else
                            {
                                db.Rollback("DeleteFolder");
                                return false;
                            }
                        }
                        else
                        {
                            db.Rollback("DeleteFolder");
                            return false;
                        }
                    }
                    else
                        JMessages.Error(" ابتدا پوشه های داخلی را حذف کنید ", "");
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Message("Delete Not Successfully", "Kartabl", JMessageType.Information);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JFolderTable ActionTable = new JFolderTable();
            ActionTable.SetValueProperty(this);
            return ActionTable.Update();
        }

        #endregion BaseFunctions

        //Forms
        #region Forms

        public void showDialog(int pFolderType, int pParentCode)
        {
            showDialog(0, pParentCode, pFolderType);
        }
        public void showDialog(int pCode, int pParentCode, int pFolderType)
        {
            JfrmDefineKartabl frmK = new JfrmDefineKartabl(pCode, pParentCode, pFolderType);
            frmK.ShowDialog();
        }
        #endregion Forms

        // GetInfo
        #region GetInfo

        /// <summary>
        /// اطلاعات یک کارتابل
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {

                db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Folders + " WHERE " + Folder.Code + "=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
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

        /// <summary>
        /// لیست کارتابل های کاربری خاص به همراه شرط های آن  
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public DataTable GetKartablCondition(int pUser_post_code)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
//                db.setQuery(@"select k." + Folder.Code + " as 'ID' , k." + Folder.parent_code + " as 'parentcode',k." + Folder.User_post_code + ",k." + Folder.Name + " as 'full_title',k." + Folder.Create_Date_Time + @",dk.* 
//     from " + JTableNamesAutomation.Folders + " K inner join " + JTableNamesAutomation.DynamicKartabl + " dk on k." + Folder.Code + "=" + Dynamickartabl.Kartabl_code + " Where k." + Folder.User_post_code + "=" + pUser_post_code);
                return db.Query_DataTable();                
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// لیست کارتابل های کاربری خاص به همراه شرط های آن  
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        //public int InsertKartablCondition( tmpJDynamicKartabl)
        //{
        //    int code = 0;
        //    JDataBase db = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        JKartablTable JST = new JKartablTable();
        //        JST.SetValueProperty(this);
        //        // -----------------  ثبت اطلاعات نامه  -------------------
        //        Code = JST.Insert(db);

        //        if (Code > 0)
        //        {
        //            tmpJDynamicKartabl.Kartabl_code = Code;
        //            JDynamicFolders JDK = new JDynamicFolders();
        //            tmpJDynamicKartabl.Kartabl_code = Code;
        //            if (JDK.Insert(tmpJDynamicKartabl,db)  < 0)
        //            {
        //                db.Rollback(db.TransactionName);
        //                return -1;
        //            }
        //        }
        //        else
        //            return -1;
        //        return -1;
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}

        #endregion GetInfo

        // Node
        #region Node
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParentCode"></param>
        /// <returns></returns>
        public JNode[] GetChildsNode(int pParentCode)
        {
            JNode[] N = new JNode[0];
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + ClassLibrary.JTableNamesAutomation.Folders + " WHERE parent_Code = " + pParentCode.ToString());
                DB.Query_DataReader();
                Array.Resize(ref N, DB.RecordCount);
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    N[Count++] = GetNode();
                }
                return N;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JNode GetNode()
        {
            try
            {
                JNode Node = new JNode(Code, this);
                Node.Name = Name;
                Node.MouseClickAction = new ClassLibrary.JAction(Name, "Automation.JKartable.GetFolderRefer", new object[] { Code }, null);

                Node.Popup.Insert(new ClassLibrary.JAction("New Folder", "Automation.JAFolder.showDialog", new object[] { FolderType, Code }, null));
                Node.Popup.Insert(new ClassLibrary.JAction("Delete", "Automation.JAFolder.Delete", new object[] { Code }, null));
                Node.Popup.Insert(new ClassLibrary.JAction("Edit", "Automation.JAFolder.showDialog", new object[] { Code,0,FolderType }, null));
                Node.ChildsAction = new JAction("GetChildNode", "Automation.JAFolder.GetChildsNode", new object[] { Code }, null);
                return Node;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Message("Update Not Successfully", "Kartabl", JMessageType.Information);
                return null;
            }
        }
        #endregion Node        
    }


    public class JAFolders : JAutomation
    {

        public JAFolder[] GetMainFolders(int pFolderType)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + ClassLibrary.JTableNamesAutomation.Folders + " WHERE user_post_code=" + JMainFrame.CurrentPostCode.ToString()
                    + " AND foldertype = " + pFolderType.ToString() + " AND (" + Folder.parent_code + "<1 OR " + Folder.parent_code + " IS NULL)");
                DB.Query_DataReader();
                JAFolder[] Folders = new JAFolder[0];
                Array.Resize(ref Folders, DB.RecordCount);
                int count = 0;
                while (DB.DataReader.Read())
                {
                    JAFolder folder = new JAFolder();
                    JTable.SetToClassProperty(folder, DB.DataReader);
                    Folders[count++] = folder;
                }
                return Folders;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable(int FolderType)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + ClassLibrary.JTableNamesAutomation.Folders +
                    " WHERE user_post_code=" + JMainFrame.CurrentPostCode.ToString() +
                    " AND FolderType=" + FolderType);
                return DB.Query_DataTable();
            }

            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetFolderByInsert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + ClassLibrary.JTableNamesAutomation.Folders + " WHERE user_post_code=" + JMainFrame.CurrentPostCode.ToString()
                    + " order by Object_type desc ,Sender_User_post_code desc ");
                return DB.Query_DataTable();
            }

            finally
            {
                DB.Dispose();
            }
        }
    }
}
