using System;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    /// <summary>
    /// سرویس انبارداری
    /// </summary>
    public class JSCService : JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// رسید/حواله/مجوز
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد  رسید/حواله/مجوز
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// نوع سرویس
        /// </summary>
        public int ServiceType { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description{ get; set; }
        /// <summary>
        /// هزینه سرویس
        /// </summary>
        public decimal ServiceCost { get; set; }
        #endregion Properties

        public int Insert()
        {
            JSCServiceTable serviceTable = new JSCServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCService.Insert"))
                {

                    serviceTable.SetValueProperty(this);
                    int Code = serviceTable.Insert();
                    if (Code > 0)
                    {
                       // Nodes.DataTable.Merge(JSCServices.GetDatatable(Code));
                        Histroy.Save(this, serviceTable, serviceTable.Code, "Insert");
                        return Code;
                    }
                    else
                        return 0;
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
                serviceTable.Dispose();
            }
        }

        public bool Delete()
        {
            JSCServiceTable serviceTable = new JSCServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCService.Delete"))
                {
                    serviceTable.SetValueProperty(this);
                    if (serviceTable.Delete())
                    {
                        Histroy.Save(this, serviceTable, serviceTable.Code, "Delete");
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                        return false;
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
                serviceTable.Dispose();
            }

        }

        public bool Update()
        {

            JSCServiceTable serviceTable = new JSCServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCService.Update"))
                {
                    serviceTable.SetValueProperty(this);
                    if (serviceTable.Update())
                    {
                        Histroy.Save(this, serviceTable, serviceTable.Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JSCServices.GetDatatable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                serviceTable.Dispose();
            }
        }
       
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM SCService WHERE Code=" + pCode.ToString());
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

        public void ShowDialog(int ContractCode, int ServiceCode)
        {
            JServiceForm form = new JServiceForm(ContractCode, ServiceCode);
            form.ShowDialog();
        }
    
    }

    public class JSCServices : JSystem
    {
        public static DataTable GetDatatable(int pCode)
        {
            string SelectQouery = @" SELECT * FROM SCService";
            string where = " Where 1=1 ";
            if (pCode > 0)
                where = where + " And code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery + where);
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
    }

}
