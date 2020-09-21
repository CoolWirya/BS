using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Automation
{
    class JAExternalRefer : JAutomation
    {
        #region Properties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public int Refer_Code { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public int receiver_external_code { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public string receiver_full_title { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public int Send_Type { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public DateTime Send_Date { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public bool ConfirmReceiver { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public string Description { get; set; }
        #endregion

                // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JAExternalRefer()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JAExternalRefer(int pCode)
        {
            GetData(pCode);
        }

        #endregion

        // Insert , Update , Delete
        #region BaseFunctions
        public int Insert()
        {
            JExternalReferTable ActionTable = new JExternalReferTable();
            ActionTable.SetValueProperty(this);
            Code = ActionTable.Insert();
            if (Code > 0)
            {
            }
            return Code;
        }

        public bool Delete(int pCode)
        {
            JExternalReferTable ActionTable = new JExternalReferTable();
            ActionTable.Code = pCode;
            return ActionTable.Delete();
        }

        public bool Update()
        {
            JExternalReferTable ActionTable = new JExternalReferTable();
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
            //JExternalRefer frmK = new JExternalRefer(pCode, 0);
            //frmK.ShowDialog();
        }
        #endregion Forms


        // GetInfo
        #region GetInfo
        /// <summary>
        /// لیست کلیه ارجاعات
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetList(string Expression)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if(Expression != "")
                    db.setQuery(@"select * from " + JTableNamesAutomation.ExternalRefer + " EF left join " + JTableNamesClassLibrary.LegalPerson + " Org on Org.Code=EF. " + ExternalRefer.receiver_full_title +" where 1=1 " + Expression);
                else
                    db.setQuery(@"select * from " + JTableNamesAutomation.ExternalRefer + " EF left join " + JTableNamesClassLibrary.LegalPerson + " Org on Org.Code=EF.receiver_external_Code ");
                return db.Query_DataTable();                
                return null;
            }
            finally
            {
                db.Dispose();
            } 
        }

        /// <summary>
        /// اطلاعات 
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.ExternalRefer + " WHERE " + ExternalRefer.Code + "=" + JDataBase.Quote(pCode.ToString()));
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
        #endregion GetInfo
    }
}
