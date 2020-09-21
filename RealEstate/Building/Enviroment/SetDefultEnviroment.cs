using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class JSetDefultEnviroment
    {
        public int Code { get; set; }
        /// <summary>11212
        /// عنوان فضا
        /// </summary>
        public int MarketCode { get; set; }
        /// <summary>11212
        /// عنوان فضا
        /// </summary>
        public int Person { get; set; }
        /// <summary>11212
        /// عنوان فضا
        /// </summary>
        public int PrimaryOwnerPerson { get; set; }

        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                JSetDefultEnviromentTable JSE = new JSetDefultEnviromentTable();
                JSE.SetValueProperty(this);
                return JSE.Insert(DB);
            }
            catch (Exception ex)
            {
               JBase.Except.AddException(ex);
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
                if (JPermission.CheckPermission("RealEstate.JSetDefultEnviroment.Insert"))
                {
                    JSetDefultEnviromentTable JSE = new JSetDefultEnviromentTable();
                    JSE.SetValueProperty(this);
                    Code = JSE.Insert(pDB);
                    
                    return Code;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return 0;
            }
        }
        public bool Update()
        {
            if (JPermission.CheckPermission("RealEstate.JSetDefultEnviroment.Update"))
            {
                JSetDefultEnviromentTable JSE = new JSetDefultEnviromentTable();
                JSE.SetValueProperty(this);
                return JSE.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("RealEstate.JSetDefultEnviroment.Delete"))
            {
                Code = pCode;
                JSetDefultEnviromentTable JSE = new JSetDefultEnviromentTable();
                JSE.SetValueProperty(this);
                
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
                DB.setQuery("SELECT * FROM ReEnviromentOwner WHERE MarketCode=" + pCode.ToString());
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
                JBase.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public  int GetPrimaryOwner(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM ReEnviromentOwner WHERE MarketCode=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return PrimaryOwnerPerson;
                }
                return 0;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        
    }
}
