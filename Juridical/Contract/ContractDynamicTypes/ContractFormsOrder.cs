using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Legal
{
    public class JContractFormsOrder : JSystem
    {
        #region Prperties
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
        /// نام فرم
        /// </summary>
        public string FormName
        {
            get;
            set;
        }
        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        public int ShowOrder
        {
            get;
            set;
        }
        /// <summary>
        /// نمایش فرم
        /// </summary>
        public bool Show { get; set; }

        #endregion Prperties

        #region Methods

        public override string ToString()
        {
            return JLanguages._Text(FormName);
        }

        public static string Query = " SELECT * FROM " + JTableNamesContracts.ContractFormsOrder;

        public static bool CheckForm(int pContractTypeCode, string pFormName)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"select * from LegContractType T inner join legContractDynamicTypes D on T.ContractType=D.Code inner join legContractFormsOrder F on
F.ContractTypeCode=D.Code WHERE Show=1 And FormName= '" + pFormName + "'  And T.Code = " + pContractTypeCode.ToString());
                DataTable dt = db.Query_DataTable();
                if ((dt == null) || (dt.Rows.Count == 0))
                    return false;
                else
                    return true;
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
        }

        public int Insert(JDataBase pDB)
        {
            JContractFormsOrderTable table = new JContractFormsOrderTable();
            table.SetValueProperty(this);
            int Code = table.Insert(pDB);
            if (Code > 0)
            {
                //Histroy.Save(this, table, table.Code, "Update");
                return Code;
            }
            else
                return -1;

        }

        public bool Update(JDataBase pDB)
        {
            JContractFormsOrderTable table = new JContractFormsOrderTable();
            table.SetValueProperty(this);
            if (this.Code == 0)
                return (table.Insert(pDB) > 0);
            if (table.Update(pDB))
            {
                //Histroy.Save(this, table, table.Code, "Update");
                return true;
            }
            else
                return false;
        }

        public bool Delete(JDataBase pDB)
        {
            JContractFormsOrderTable table = new JContractFormsOrderTable();
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

    public class JContractFormsOrders : JSystem
    {
        public List<JContractFormsOrder> Items = new List<JContractFormsOrder>();

        public bool InsertAll(JDataBase pDB, int pTypeCode)
        {
            try
            {
                foreach (JContractFormsOrder formOrder in Items)
                {
                    formOrder.ContractTypeCode = pTypeCode;
                    formOrder.Insert(pDB);
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

        public bool UpdateAll(JDataBase pDB, int pTypeCode)
        {
            try
            {
                foreach (JContractFormsOrder formOrder in Items)
                {
                    formOrder.ContractTypeCode = pTypeCode;
                    formOrder.Update(pDB);
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

        public bool DeleteAll(JDataBase pDB, int pTypeCode)
        {
            try
            {
                LoadAll(pTypeCode);
                foreach (JContractFormsOrder formOrder in Items)
                {
                    formOrder.ContractTypeCode = pTypeCode;
                    formOrder.Delete(pDB);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// بازخوانی فرمهای یک نوع قرارداد
        /// </summary>
        /// <param name="pCode"></param>
        public void LoadAll(int pTypeCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(JContractFormsOrder.Query + " WHERE " + JContractFormsOrderEnum.ContractTypeCode.ToString() + " = " + pTypeCode.ToString() + " ORDER BY " + JContractFormsOrderEnum.ShowOrder.ToString());
                int count = 0;
                foreach (DataRow row in db.Query_DataTable().Rows)
                {
                    JContractFormsOrder formOrder = new JContractFormsOrder();
                    formOrder.GetData((int)row["Code"], db);
                    bool findform = false;
                    for (int i = 0; i < Items.Count; i++ )
                    {
                        if (Items[i].FormName == formOrder.FormName)
                        {
                            findform = true;
                            Items.RemoveAt(i);
                            Items.Insert(count, formOrder);
                        }
                    }
                    if (!findform)
                        Items.Add(formOrder);
                    count++;
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
        }

    }
}
