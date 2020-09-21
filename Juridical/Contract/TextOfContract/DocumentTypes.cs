using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JDocumentType : JLegal
    {

        #region Properties
        
        public int Code { get; set; }
        /// <summary>
        /// عنوان سند
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region سازنده


        public JDocumentType()
        {
        }

        public JDocumentType(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDocumentTypesTable PDT = new JDocumentTypesTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert();
                Histroy.Save(PDT, Code, "Insert");
                Nodes.DataTable.Merge(GetAllData(Code));
                return Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDocumentTypesTable PDT = new JDocumentTypesTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Update();
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
         /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            return delete(pDB, -1);
        }
        public bool delete(JDataBase pDB, int pCode)
        {
            if (pCode > 0)
            {
                GetData(pCode);
            }
            JDocumentTypesTable PDT = new JDocumentTypesTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
            return false;
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JDocumentTypesTable PDT = new JDocumentTypesTable();
            try
            {
                return PDT.DeleteManual(exp, pDB);
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
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM legdocumenttype WHERE Code=" + pCode.ToString());
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
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pCode==0)
                    DB.setQuery("SELECT * FROM legdocumenttype");
                else
                    DB.setQuery("SELECT * FROM legdocumenttype where Code=" + pCode);
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

        public static DataTable GetAllData()
        {
            return GetAllData(0);
        }

         #endregion

        #region ShowData

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JDocumentTypeForm JNF = new JDocumentTypeForm();
                JNF.State = JBaseContractForm.JStateContractForm.Insert;
                JNF.ShowDialog();
            }
            else
            {
                JDocumentTypeForm JNF = new JDocumentTypeForm(this.Code);
                JNF.State = JBaseContractForm.JStateContractForm.Update;
                JNF.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JNotaryTableEnum.Code.ToString()], "Legal.JDocumentType");
            Node.Icone = JImageIndex.testimonial.GetHashCode();
            Node.Name = pRow["Title"].ToString();
            Node.Hint = pRow["Title"].ToString();

            //اکشن جدید
            JAction NewAction = new JAction("new...", "Legal.JDocumentType.ShowDialog", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Legal.JDocumentType.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "Legal.JDocumentType.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);

            return Node;
        }


        #endregion
    }

    class JDocumentTypes : JSystem
    {
        public JDocumentTypes[] Items = new JDocumentTypes[0];
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = "select * from legDocumentType";
            if (pCode > 0)
            {
                Where = " where " + JTableNamesLegal.NotaryTable + ".Code=" + pCode;
            }

            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(Where);
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

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("NewNode", "Legal.JDocumentType.GetNode");
            Nodes.DataTable = GetDataTable();
            //اکشن جدید
            JAction newaction = new JAction("new...", "Legal.JDocumentType.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }
}
