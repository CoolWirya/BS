using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JJobTitle : JEmployment
    {

        #region constructor
        public JJobTitle()
        {
        }
        public JJobTitle(int pCode)
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
        /// کد شغل 
        /// </summary>
        public int JobCode { get; set; }
        /// <summary>
        /// عنوان شغلی کد
        /// </summary>
        public int TitleCode { get; set; }
        /// <summary>
        /// سطح 
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// گروه 
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// نوع مدرک
        /// </summary>
        public int DegreeCode { get; set; }
        /// <summary>
        /// تجربه
        /// </summary>
        public int Expreince { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode { get; set; }
        #endregion

        #region search method

        public DataTable GetList()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("select EmpJobTitle.*, (Select [name] from subdefine where subdefine.Code = EmpJobTitle.TitleCode) as [name] from EmpJobTitle");
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }


        }

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpJobTitle where Code=" + pCode + "";
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

        public bool Find(string pWhere)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpJobTitle where " + pWhere;
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
                JobTitleTable PDT = new JobTitleTable();
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
            JobTitleTable PDT = new JobTitleTable();
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

        public void ShowForm(int pCompanyCode)
        {
            ShowForm(0, pCompanyCode);
        }
        public void ShowForm(int pCode,int pCompanyCode)
        {
            if (pCode == 0)
            {
                JTitleJobForm LandForm = new JTitleJobForm(pCompanyCode);
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JTitleJobForm LandForm = new JTitleJobForm(pCode, pCompanyCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }


        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @" select * from EmpEmployee " + Where; // EmpVacationHour 
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

        public int Insert(int pCompanyCode)
        {
            JobTitleTable JLT = new JobTitleTable();
            try
            {
                JLT.SetValueProperty(this);
                if ((Find(" JobCode= " + JobCode)))
                {
                    JMessages.Error(" کد شغل تکراری است " ,"");
                    return 0;
                }
                Code = JLT.Insert();
                if (Code > 0)
                {
                    Nodes.DataTable.Merge(JJobTitles.GetDataTable(Code,pCompanyCode));
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
            JNode Node = new JNode((int)pRow["Code"], "Employment.JJobTitle");
            Node.Name = pRow["Code"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Employment.JJobTitle.ShowForm", new object[] { Node.Code, pRow["Companycode"]}, null);
            Node.MouseDBClickAction = editAction;            
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "Employment.JJobTitle.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            //JAction newAction = new JAction("New...", "Employment.JJobTitle.ShowForm", null, null);            
            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            //Node.Popup.Insert(newAction);

            return Node;
        }
    }

    public class JJobTitles : JSystem
    {

        public JJobTitles[] Items = new JJobTitles[0];
        public JJobTitles()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable(int pCompanyCode)
        {
            return GetDataTable(0, pCompanyCode);
        }
        public static DataTable GetDataTable(int pCode,int pCompanyCode)
        {
            string Where = " 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            if (pCompanyCode != 0)
                Where = Where + " And CompanyCode=" + pCompanyCode;

            string Query = @"select Code,JobCode,(select Name From subdefine where Code=TitleCode)TitleCode,[Level],[Group],
(select Name From subdefine where Code=DegreeCode)DegreeCode,expreince,
(select Name From subdefine where Code=TitleCode)+ ' - '+cast ([Level] as nvarchar)+ ' - '+cast ([Group] as nvarchar)  TitleCodeLevel
 from EmpJobTitle Where " + Where;
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
            Nodes.ObjectBase = new JAction("EmployeeInfo", "Employment.JJobTitle.GetNode");
            Nodes.DataTable = GetDataTable(pCompanyCode);
            JAction newAction = new JAction("New...", "Employment.JJobTitle.ShowForm", new object[] { pCompanyCode }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }
}
