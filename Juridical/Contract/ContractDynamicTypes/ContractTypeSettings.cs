using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Legal
{
    public class JContractTypeSetting : JLegal
    {
        #region Properties
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// کد نوع قرارداد از جدول ContractDynamicTypes
        /// </summary>
        public int ContractTypeCode
        {
            get;
            set;
        }
        /// <summary>
        /// نام تنظیم
        /// </summary>
        public string SettingName
        {
            get;
            set;
        }
        /// <summary>
        /// مقدار تنظیم
        /// </summary>
        public object SettingValue
        {
            get;
            set;
        }

        public static string Query = " SELECT * FROM " + JTableNamesContracts.ContractTypeSettings;
        #endregion

        #region Methods

        public bool GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(Query + " WHERE Code = " + pCode.ToString());
                if (db.Query_DataReader())
                    if (db.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, db.DataReader);
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
                db.Dispose();
            }
        }

        public bool GetData(int pCode, JDataBase pDB)
        {
            try
            {
                pDB.setQuery(Query + " WHERE Code = " + pCode.ToString());
                if (pDB.Query_DataReader())
                    if (pDB.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, pDB.DataReader);
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
            }
        }
        /// <summary>
        /// جستجو بر اساس نوع قرارداد و نام تنظیم
        /// </summary>
        /// <param name="pTypeCode"></param>
        /// <param name="pSettingName"></param>
        /// <returns></returns>
        public bool GetData(int pTypeCode, string pSettingName, JDataBase pDB)
        {
            JDataBase db ;
            if (pDB == null)
                db = JGlobal.MainFrame.GetDBO();
            else
                db = pDB;
            try
            {
                db.setQuery(Query + " WHERE  " + JContractTypeSettingsEnum.ContractTypeCode.ToString() + " = " + pTypeCode.ToString() +
                    " AND " + JContractTypeSettingsEnum.SettingName.ToString() + " = " + JDataBase.Quote(pSettingName));
                if (db.Query_DataReader())
                    if (db.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, db.DataReader);
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
                if (pDB == null)
                    db.Dispose();
            }
        }

        public int Insert(JDataBase pDB)
        {
            JContractTypeSettingsTable table = new JContractTypeSettingsTable();
            table.SetValueProperty(this);
            int Code = table.Insert(pDB);
            if (Code > 0)
            {
                Histroy.Save(this, table, table.Code, "Insert");
                return Code;
            }
            else
                return -1;
        }

        public bool Update(JDataBase pDB)
        {
            JContractTypeSettingsTable table = new JContractTypeSettingsTable();
            table.SetValueProperty(this);
            if (this.Code != 0)
            {
                if (table.Update(pDB))
                {
                    //Histroy.Save(this, table, table.Code, "Update");
                    return true;
                }
            }
            else
                if (table.Code == 0)
                {
                    if (this.Insert(pDB) > 0)
                    {
                        return true;
                    }
                }
            return false;
        }

        public bool Delete(JDataBase pDB)
        {
            JContractTypeSettingsTable table = new JContractTypeSettingsTable();
            table.SetValueProperty(this);
            if (table.Delete(pDB))
            {
                //Histroy.Save(this, table, table.Code, "Delete");
                return true;
            }
            else
                return false;
        }
        #endregion

    }

    public class JContractTypeSettings : JLegal
    {
        public IDictionary<string, object> Items = new Dictionary<string, object>();
        public void InsertAll(JDataBase pDB, int pTypeCode)
        {
            foreach (KeyValuePair<string, object> item in Items)
            {
                JContractTypeSetting setting= new JContractTypeSetting();
                setting.ContractTypeCode=pTypeCode;
                setting.SettingName=item.Key;
                setting.SettingValue=item.Value;
                setting.Insert(pDB);
            }
        }

        public bool UpdateAll(JDataBase pDB, int pTypeCode)
        {
            try
            {
                foreach (KeyValuePair<string, object> item in Items)
                {
                    JContractTypeSetting setting = new JContractTypeSetting();
                    setting.GetData(pTypeCode, item.Key, pDB);
                    setting.SettingName = item.Key;
                    setting.SettingValue = item.Value;
                    setting.ContractTypeCode = pTypeCode;
                    setting.Update(pDB);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        public void LoadAll(int pTypeCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(JContractTypeSetting.Query + " WHERE " + JContractTypeSettingsEnum.ContractTypeCode.ToString() + " = " + pTypeCode.ToString());
                DataTable _DT = db.Query_DataTable();
                foreach (DataRow row in _DT.Rows)
                {
                    //JContractTypeSetting formSetting = new JContractTypeSetting();
                    //formSetting.GetData((int)row["Code"], db);  
                    //KeyValuePair<string, object> item = new KeyValuePair<string, object>();
                    Items[row["SettingName"].ToString()] = row["SettingValue"];
                    //Items[formSetting.SettingName] = formSetting.SettingValue;
                    //item.Value = formSetting.SettingValue;
                    //Items.Add(formOrder);
                }
                _DT.Clear();
                _DT.Dispose();
                _DT = null;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeleteAll(JDataBase pDB, int pTypeCode)
        {
            try
            {
                pDB.setQuery(JContractTypeSetting.Query + " WHERE " + JContractTypeSettingsEnum.ContractTypeCode.ToString() + " = " + pTypeCode.ToString());
                foreach (DataRow row in pDB.Query_DataTable().Rows)
                {
                    JContractTypeSetting setting = new JContractTypeSetting();
                    setting.GetData((int)row["Code"]);
                    setting.Delete(pDB);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
    }

}
