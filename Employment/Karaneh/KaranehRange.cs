using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JKaranehRange : JEmployment
    {

        #region constructor
        public JKaranehRange()
        {
        }
        public JKaranehRange(int pCode)
        {
            GetData(pCode);
        }
        #endregion
        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }        
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime kDate { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string description { get; set; }        

        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from empkaranehrange where Code=" + pCode + "";
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
        #endregion
        
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            //if (JPermission.CheckPermission("Employment.JEmployeeInfo.Delete"))
            //{
            if (JMessages.Question("آیا میخواهید دوره انتخاب شده حذف شود؟", "حذف دوره") != System.Windows.Forms.DialogResult.Yes)
                return false;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JKaranehRangeTable PDT = new JKaranehRangeTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                {
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

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(int pCompanyCode)
        {
            JKaranehRangeTable PDT = new JKaranehRangeTable();
            JDataBase db = new JDataBase();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(db))
                {
                    Nodes.Refreshdata(Nodes.CurrentNode, JJobTitles.GetDataTable(this.Code, pCompanyCode).Rows[0]);
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                PDT.Dispose();
                db.Dispose();
            }
        }

        public void ShowForm()
        {
            ShowForm(0);
        }
        public void ShowForm(int pCode)
        {
            if (pCode == 0)
            {
                JKaranehRangeForm LandForm = new JKaranehRangeForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JKaranehRangeForm LandForm = new JKaranehRangeForm(pCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        public int Insert(int pCompanyCode)
        {
            JKaranehRangeTable JLT = new JKaranehRangeTable();
            try
            {
                JLT.SetValueProperty(this);
                Code = JLT.Insert();
                if (Code > 0)
                {
                    Nodes.DataTable.Merge(JJobTitles.GetDataTable(Code, pCompanyCode));
                    return Code;
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
                JLT.Dispose();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Employment.JKaranehRange");
            Node.Name = pRow["Code"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Employment.JKaranehRange.ShowForm", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "Employment.JKaranehRange.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Employment.JKaranehRange.ShowForm", null, null);
            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);

            return Node;
        }
    }

    public class JKaranehRanges : JSystem
    {

        public JKaranehRanges[] Items = new JKaranehRanges[0];
        public JKaranehRanges()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = " 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from empkaranehrange Where " + Where + " order by Code Desc ";
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
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("EmployeeInfo", "Employment.JKaranehRange.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "Employment.JKaranehRange.ShowForm", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }

    public class JKaranehRangeTable : JTable
    {
        public JKaranehRangeTable()
            : base("EmpKaranehRange")
        {
        }   
        /// <summary>
        /// 
        /// </summary>
        public string title;
        /// <summary>
        ///  
        /// </summary>
        public DateTime kDate;
        /// <summary>
        ///  
        /// </summary>
        public string description;
    }
}
