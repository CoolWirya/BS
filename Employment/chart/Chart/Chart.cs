using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    /// <summary>
    /// عناوین شغلی
    /// </summary>
    public class JEChart : JEmployment
    {
        // سازنده ها
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JEChart()
        {
        }
        public JEChart(int Code)
        {
            GetData(Code);
        }
        #endregion Constructors
        // Peroperties
        #region Peroperties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// عنوان چارت
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public bool is_active { get; set; }
        #endregion Peroperties
        // Insert , Update , Delete
        #region BaseFunctions
        /// <summary>
        /// درج چارت جدید در بانک اطلاعاتی
        /// </summary>
        /// <returns>بر می گرداند True در صورت درج صحیح مقدار</returns>
        public bool Insert()
        {
            if (Find(Code) || Find(Title))
                return false;
            JDataBase db = new JDataBase();
            Employment.JEChartTable JCT = new Employment.JEChartTable();
            JCT.SetValueProperty(this);
            int mCode = JCT.Insert(db);
            db.setQuery("Insert into charts VALUES((Select Max(Code)+1 From charts), N'" + JCT.Title + "', 0)");
            int result = db.Query_Execute();
            if (result > 0)
                return true;
            //if (mCode != 0)
            //{
            //    Code = mCode;
            //    Nodes.Insert(GetNode());
            //    db.Dispose();
            //    return true;
            //}
            db.Dispose();
            return false;
        }
        /// <summary>
        /// ویرایش چارت
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (Find(Code))
            {
                JEChartTable JCT = new JEChartTable();
                JCT.SetValueProperty(this);
                //JST.
                Nodes.Refresh(GetNode());
                return JCT.Update();
            }
            return false;
        }
        /// <summary>
        /// حذف چارت از بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            if (Find(pCode))
            {
                GetData(pCode);
                string msg = "";
                if (this.is_active == true)
                {
                    // امکان حذف چارت فعال نمی باشد
                    msg = JLanguages._Text("Can not Remove Active Chart");
                    if (JMessages.Message(msg, "!", JMessageType.Error) != System.Windows.Forms.DialogResult.Yes)
                        return false;
                }
                msg = JLanguages._Text("Remove This Chart?");
                if (JMessages.Message(msg, "!", JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
                    return false;
                GetData(pCode);
                Employment.JEChartTable JCT = new Employment.JEChartTable();
                JCT.SetValueProperty(this);
                if (JCT.Delete())
                {
                    //Nodes.Delete(GetNode());
                    return true;
                }
            }
            return false;
        }

        public void MakeActiveChart(int _Code)
        {
            JDataBase db = new JDataBase();
            db.setQuery("Update charts SET is_active = 0");
            db.Query_Execute();
            db.setQuery("Update charts SET is_active = 1 WHERE Code = " + _Code);
            db.Query_Execute();
            db.Dispose();
        }
        #endregion BaseFunctions
        // GetInfo
        #region GetInfo
        /// <summary>
        /// جستجوی  چارت
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM charts WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجوی  چارت
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string strSQL = "SELECT * FROM charts WHERE 1=1 ";
            if (Code != null) strSQL += " AND Code = " + Code.ToString();
            if (Title != null) strSQL += " AND title = '" + Title + "'";

            try
            {
                db.setQuery(strSQL);
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Find(string PTitle)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM charts WHERE [title]=" + JDataBase.Quote(PTitle));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM charts WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
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
        /// لیست چارت ها
        /// </summary>
        public string ListView()
        {
            return null;
        }

        #endregion GetInfo
        //Forms
        #region Forms
        /// <summary>
        /// نمایش فرم چارت برای ویرایش اطلاعات یک چارت
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool UpdateForm(int Code)
        {
            if (GetData(Code))
            {
                JfrmChart jc = new JfrmChart(this);
                jc.State = JFormState.Update;
                jc.ShowDialog();
            }
            return true;
        }

        public bool InsertForm()
        {
            JfrmChart jc = new JfrmChart(this);
            jc.State = JFormState.Insert;
            jc.ShowDialog();
            return true;
        }

        #endregion Forms
        // Node
        #region Node
        public JNode GetNode()
        {
            return JEStaticNode._ChartNode(this);
            //return null;
        }
        #endregion Node
    }

    public class JECharts : JEmployment
    {

        //properties
        #region Properties
        private string _SQL = "SELECT [Code],[title], CASE WHEN [is_active] = 1 THEN N'فعال' ELSE '' END as [is_active] FROM charts %WHERE% ORDER BY [is_active] desc";
        public static int ActiveChartCode;
        private JEChart[] _Items;
        public JEChart[] Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion properties
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public JECharts()
            : this("")
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        public JECharts(string where)
        {
            if (where.Length > 0)
                where = "AND" + where;
            _SQL = _SQL.Replace("%WHERE%", "WHERE 1=1 " + where);
            _getItems();
        }
        #endregion Constructors
        // GetInfo
        #region GetInfo
        /// <summary>
        /// جستجوی  چارت فعال
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public int FindActiveChart()
        {
            return FindActiveChart(0);
        }

        public int FindActiveChart(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string strSQL = "SELECT * FROM charts ";
            strSQL += " WHERE is_active = 'True'";
            if (pCode > 0)
                strSQL += " AND Code = " + pCode.ToString();

            try
            {
                db.setQuery(strSQL);
                db.Query_DataReader();
                if (!db.DataReader.HasRows)
                {
                    return -1;
                }
                else
                {
                    if (db.DataReader.Read())
                    {
                        return int.Parse((db.DataReader.GetValue(0).ToString()));
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return -1;
        }
        /// <summary>
        /// خواندن اطلاعات چارت ها از بانک اطلاعاتی و و قرار دادن در متغیر 
        /// </summary>
        private void _getItems()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(_SQL);
                DB.Query_DataSet();
                _Items = new JEChart[DB.DataSet.Tables[0].Rows.Count];
                int count = 0;
                foreach (DataRow DR in DB.DataSet.Tables[0].Rows)
                {
                    Items[count] = new JEChart();
                    Items[count].GetData(int.Parse(DR["Code"].ToString()));
                    count++;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// کد چارت فعال را بر میگرداند ، در صورت عدم وجود چارت فعال صفر بر میگردد
        /// </summary>
        /// <returns></returns>
        public int GetActiveChartCode()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("Select ISNULL(MAX(Code),0) From charts where is_active = 'True'");
                return Convert.ToInt32(DB.Query_ExecutSacler());
            }
            finally
            {
                DB.Dispose();
            }

        }
        /// <summary>
        /// لیست چارت ها را بر میگرداند
        /// </summary>
        /// <returns>اطلاعات چارت</returns>        
        public DataTable GetSecretariat()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery(_SQL);
            return DB.Query_DataTable();
            DB.Dispose();
        }
        #endregion GetInfo
        // View Nodes
        #region View
        public void ListView()
        {
            JEOrganizationChartForm jeOrganizationChartForm = new JEOrganizationChartForm();
            jeOrganizationChartForm.ShowDialog();
            /*
            JAction InsertAction = new JAction("New", "Employment.JEChart.InsertForm");
            Nodes.GlobalMenuActions = new JPopupMenu("Employment.JEChart",0);
            Nodes.GlobalMenuActions.Insert(InsertAction);
            
            foreach (JEChart Sec in Items)
            {
                Nodes.Insert(Sec.GetNode());
            }
             */
        }

        public JNode[] TreeView()
        {
            return null;
        }
        #endregion View
    }
}
