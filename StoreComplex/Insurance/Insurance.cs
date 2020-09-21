using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JInsurance : JStoreComplex
    {
        #region constructor
        public JInsurance()
        {
        }
        public JInsurance(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }          
        /// <summary>
        ///  کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        ///  تاریخ شروع
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime ExpireDate { get; set; }
        /// <summary>
        /// مبلغ بیمه
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// ارزش کالا
        /// </summary>
        public decimal CostGoods { get; set; }        
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }              
        #endregion


        public bool ShowDialog(int ContractCode, int pPCode)
        {
            JInsuranceEditForm form = new JInsuranceEditForm(ContractCode, pPCode);
            return form.ShowDialog() == System.Windows.Forms.DialogResult.OK;
        }
        public void ShowList(int ContractCode)
        {
            JInsuranceList form = new JInsuranceList(ContractCode);
            form.ShowDialog();
        }

        #region Method
        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SCInsurance where Code=" + pCode + "";
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
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JInsuranceTable PDT = new JInsuranceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JInsurance.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert();
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JGroundSheets.GetDataTable(Code));
                        Histroy.Save(this, PDT, Code, "Insert");
                        return Code;
                    }
                    else
                        return -1;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JInsuranceTable PDT = new JInsuranceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JInsurance.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update())
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        //Nodes.Refreshdata(Nodes.CurrentNode, JGroundSheets.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Delete()
        {
            JInsuranceTable table = new JInsuranceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JInsurance.Delete"))
                {
                    table.SetValueProperty(this);
                    if (table.Delete())
                    {
                        Histroy.Save(this, table, table.Code, "Delete");
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
                Except.AddException(ex);
                return false;
            }
            finally
            {
                table.Dispose();
            }
        }

        #endregion

    }

    public class JInsurances : JSystem
    {
        public static DataTable GetDatatable( int pContractCode, int pCode)
        {
            string SelectQouery = @" SELECT [Code]
      ,[ContractCode]
      ,(Select Fa_Date from StaticDates WHERE En_Date = [StartDate] ) [StartDate]
      ,(Select Fa_Date from StaticDates WHERE En_Date = [ExpireDate]) [ExpireDate]
      ,[Price]
      ,[CostGoods]
      ,[Description]
  FROM [SCInsurance] ";
            string where = " Where 1=1 ";
            if (pCode > 0)
                where = where + " And Code=" + pCode;
            if (pContractCode > 0)
                where = where + " And ContractCode=" + pContractCode;

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery + where+" ORDER BY StartDate");
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
