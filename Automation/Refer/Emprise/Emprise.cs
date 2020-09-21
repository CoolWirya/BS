using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Employment;


namespace Automation
{
    public class JAEmprise : JAutomation
    {
        #region Properties

        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        public int User_post_code { get; set; }
        public string Description { get; set; }

        #endregion

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JAEmprise()
        {
        }
        #endregion

        // Insert , Update , Delete
        #region BaseFunctions
        public int Insert()
        {
            JAEmpriseTable ActionTable = new JAEmpriseTable();
            ActionTable.SetValueProperty(this);
            Code = ActionTable.Insert();
            if (Code > 0)
            {
            }
            return Code;
        }

        public bool Delete(int pCode)
        {
            JAEmpriseTable ActionTable = new JAEmpriseTable();
            ActionTable.Code = pCode;
            return ActionTable.Delete();
        }

        public bool Update()
        {
            JAEmpriseTable ActionTable = new JAEmpriseTable();
            ActionTable.SetValueProperty(this);
            return ActionTable.Update();
        }

        #endregion BaseFunctions

        //Forms
        #region Forms
        public void showDialog()
        {
            showDialog(0);
        }

        public void showDialog(int pCode)
        {
            //JfrmDefineKartabl frmK = new JfrmDefineKartabl(pCode, 0);
            //frmK.ShowDialog();
        }

        public JAEmprise[] Items;

        /// <summary>
        /// اطلاعات 
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public void GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                if (pCode == 0)
                    db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise );
                else
                    db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise + " WHERE " + Emprise.Code + "=" + pCode.ToString());

                db.Query_DataReader();
                Items = new JAEmprise[db.RecordCount];
                int count = 0;
                if (db.DataReader.Read())
                {
                    Items[count] = new JAEmprise();
                    JTable.SetToClassProperty(Items[count], db.DataReader);
                    count++;
                }                
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetDataByCode(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pCode != 0)
                    db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise + " WHERE " + Emprise.Code + "=" + pCode.ToString());
                else
                    db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise);// +
                //" WHERE " + Emprise.Code + " IS NULL OR" + Emprise.Code + "=0 OR " +
                // Emprise.Code + "=" + JMainFrame.CurrentPostCode.ToString());

                //db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise + " WHERE " + Emprise.Code + " IS NULL OR" + Emprise.Code + "=0");
                return db.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion Forms
    }
    public class JAEmprises : JAutomation
    {

        //public DataTable GetData()
        //{
        //    return GetData(0);
        //}
        public DataTable GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pCode != 0)
                    db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise + " WHERE " + Emprise.Code + "=" + pCode.ToString());
                else
                    db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise);// +
                //" WHERE " + Emprise.Code + " IS NULL OR" + Emprise.Code + "=0 OR " +
                // Emprise.Code + "=" + JMainFrame.CurrentPostCode.ToString());

                //db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Emprise + " WHERE " + Emprise.Code + " IS NULL OR" + Emprise.Code + "=0");
                return db.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
