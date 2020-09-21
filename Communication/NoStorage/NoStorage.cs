using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Communication
{
    public class NoStorage : JSystem
    {
        #region Constructor
        public NoStorage(int pCode)
        {
			GetData(pCode);
        }
        public NoStorage(string className, int objectCode, int year)
        {
			GetData(className, objectCode , year);
			if (Code == 0)
			{
				Code = CreateNewNoStorage(className, objectCode, year);
			}
        }

        public NoStorage(string className, int objectCode, int year, int pSecretariatCode)
        {
            GetData(className, objectCode, year, pSecretariatCode);
            if (Code == 0)
            {
                Code = CreateNewNoStorage(className, objectCode, year, pSecretariatCode);
            }
        }
        
        #endregion

        #region Properties
        public int Code { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public int Year { get; set; }
        public int LastNo { get; set; }
        public int Parent { get; set; }
        public string reserve { get; set; }
		public int SecretariatCode { get; set; }

        #endregion

        #region Static Methods
        //public static bool VerifyStorage(string className, int objectCode, int year)
        public static int CreateNewNoStorage(string ClassName, int ObjectCode, int Year)
        {
			Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
			
			NoStorageTable noStorageTable = new NoStorageTable();
            noStorageTable.ClassName = ClassName;
            noStorageTable.ObjectCode = ObjectCode;
            noStorageTable.Year = Year;
            noStorageTable.LastNo = 0;
			noStorageTable.SecretariatCode = EOC.secretariat_code;
            return noStorageTable.Insert();
        }

        public static int CreateNewNoStorage(string ClassName, int ObjectCode, int Year, int pSecretariat_code)
        {
            NoStorageTable noStorageTable = new NoStorageTable();
            noStorageTable.ClassName = ClassName;
            noStorageTable.ObjectCode = ObjectCode;
            noStorageTable.Year = Year;
            noStorageTable.LastNo = 0;
            noStorageTable.SecretariatCode = pSecretariat_code;
            return noStorageTable.Insert();
        }

        public static bool VerifyStorage(string className, int objectCode, int year)
        {
			Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select * From NoStorage Where ClassName = '"
					+ className + "' AND ObjectCode = "
					+ objectCode.ToString() + " AND Year = "
					+ year.ToString() + " AND SecretariatCode = "
					+ EOC.secretariat_code);
				DataTable _DT = db.Query_DataTable();
				if (_DT.Rows.Count > 0)
					return true;
				return false;
			}
			catch
			{
				return false;
			}
            finally
            {
                db.Dispose();

            }
        }

        public bool VerifyStorage(string className, int objectCode)
        {
			Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
			JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From NoStorage Where ClassName = '" 
					+ className + "' AND ObjectCode = "
					+ objectCode.ToString() + " AND SecretariatCode = "
					+ EOC.secretariat_code);
                DataTable _DT = db.Query_DataTable();
                if (_DT.Rows.Count > 0)
                    return true;
                return false;
            }
            finally
            {
                db.Dispose();

            }
        }
        #endregion

        #region GetData
        public void GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From NoStorage Where Code = " + pCode.ToString());
                DataTable _DT = db.Query_DataTable();
                if (_DT.Rows.Count > 0)
                    JTable.SetToClassProperty(this, _DT.Rows[0]);
            }
            finally
            {
                db.Dispose();
            }
        }

        public void GetData(string className, int objectCode, int year)
        {
			Employment.JEOrganizationChart EOC = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select * From NoStorage Where ClassName = N'"
					+ className + "' AND ObjectCode = "
					+ objectCode.ToString() + " AND Year = "
					+ year.ToString() + " AND SecretariatCode = "
					+ EOC.secretariat_code);
				DataTable _DT = db.Query_DataTable();
				if (_DT.Rows.Count > 0)
					JTable.SetToClassProperty(this, _DT.Rows[0]);
			}
			catch
			{
			}
            finally
            {
                db.Dispose();
            }
        }

        public void GetData(string className, int objectCode, int year, int pSecretariat_code)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From NoStorage Where ClassName = '"
                    + className + "' AND ObjectCode = "
                    + objectCode.ToString() + " AND Year = "
                    + year.ToString() + " AND SecretariatCode = "
                    + pSecretariat_code);
                DataTable _DT = db.Query_DataTable();
                if (_DT.Rows.Count > 0)
                    JTable.SetToClassProperty(this, _DT.Rows[0]);
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
        }

        public int GetNextNumber()
        {
            if (Parent > 0)
            {
                NoStorage N = new NoStorage(Parent);
                return N.GetNextNumber();
            }
            else
            {
				GetData(Code);
                if (UpdateNumber(LastNo + 1))
                {
                    LastNo++;
                    return LastNo;
                }
            }
            return 0;
        }

        public int GetNextNumberWithoutUpdate()
        {
            if (Parent > 0)
            {
                NoStorage N = new NoStorage(Parent);
                return N.GetNextNumberWithoutUpdate();
            }
            else
            {
				GetData(Code);
				return LastNo + 1;
            }
        }
        #endregion

        public bool ResetCounter()
        {
            return UpdateNumber(0);
            LastNo = 0;
        }

        public bool SetNumber(int num)
        {
            return UpdateNumber(num);
            LastNo = num;
        }

        public bool UpdateNumber(int lastNo)
        {
			if (Parent > 0)
			{
				NoStorage NS = new NoStorage(Parent);
				return NS.UpdateNumber(lastNo);
			}
            NoStorageTable noStorageTable = new NoStorageTable();
            noStorageTable.SetValueProperty(this);
            noStorageTable.LastNo = lastNo;
            if (noStorageTable.Update() == true)
                return true;
            return false;
        }
    }
}
