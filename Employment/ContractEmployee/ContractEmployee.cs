using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Employment
{
    public class JContractEmployee : JEmployment
    {

        #region constructor
        public JContractEmployee()
        {
        }
        public JContractEmployee(int pContractCode)
        {
            GetData(pContractCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }               
        /// <summary>
        ///  نوع فعالیت
        /// </summary>
        public int workKind { get; set; }
        /// <summary>
        ///  مکان فعالیت
        /// </summary>
        public int workPlace { get; set; }
        /// <summary>
        /// ساعت کاری
        /// </summary>
        public int workTime { get; set; }
        /// <summary>
        /// مزد ثابت
        /// </summary>
        public decimal constSallary { get; set; }
        /// <summary>
        /// حق مسکن
        /// </summary>
        public decimal maskanRight { get; set; }        
        /// <summary>
        /// حق خواروبار
        /// </summary>
        public decimal kharobarRight { get; set; }
        /// <summary>
        /// حق اولاد
        /// </summary>
        public decimal childRight { get; set; }
        /// <summary>
        /// حق ایاب و ذهاب
        /// </summary>
        public decimal workPlaceCondition { get; set; }
        /// <summary>
        ///  حق کارایی
        /// </summary>
        public decimal performanceRight { get; set; }
        /// <summary>
        /// نوبت کاری
        /// </summary>
        public decimal shiftRight { get; set; }
        /// <summary>
        /// بن
        /// </summary>
        public decimal bonRight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id_employee { get; set; }
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public int protocolKind { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        /// کسر صندوق
        /// </summary>
        public decimal cashDec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id_protocolSheet { get; set; }
        /// <summary>
        /// حق سرپرستی
        /// </summary>
        public decimal sarparastyRight { get; set; }
        /// <summary>
        /// پایه سنواتی
        /// </summary>
        public decimal sanavatBase { get; set; }
        /// <summary>
        /// سایر مزایا
        /// </summary>
        public decimal otherRight { get; set; }
        /// <summary>
        /// حق جذب
        /// </summary>
        public decimal jazbRight { get; set; }             
        /// <summary>
        /// مزایا 1
        /// </summary>
        public decimal maz1 { get; set; }
        /// <summary>
        /// مزایا 2
        /// </summary>
        public decimal maz2 { get; set; }
        /// <summary>
        /// مزایا 3
        /// </summary>
        public decimal maz3 { get; set; }
        /// <summary>
        /// عنوان مزایا 1
        /// </summary>
        public string mazTitle1 { get; set; }
        /// <summary>
        /// عنوان مزایا 2
        /// </summary>
        public string mazTitle2 { get; set; }        
        /// <summary>
        /// عنوان مزایا 3
        /// </summary>
        public string mazTitle3 { get; set; }
        /// <summary>
        /// نوع محاسبه
        /// </summary>
        public int CalcType { get; set; }       
        /// <summary>
        /// مزد رتبه
        /// </summary>
        public decimal RotbeRight { get; set; }
        /// <summary>
        /// مزد سختی کار
        /// </summary>
        public decimal SakhtiKarRight { get; set; }
        /// <summary>
        /// مزد جبهه
        /// </summary>
        public decimal JebheRight { get; set; }
        /// <summary>
        /// مزد سربازی
        /// </summary>
        public decimal MilitryRight { get; set; }
        /// <summary>
        /// تفاوت تطبیق
        /// </summary>
        public decimal Tafavot { get; set; }
        /// <summary>
        /// فوق العاده شغل
        /// </summary>
        public decimal FoghAlade { get; set; }
        /// <summary>
        /// آزمایشی
        /// </summary>
        public bool Test { get; set; }
        #endregion

        #region search method

        public bool GetData(int pContractCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpPersonnelContract where ContractCode=" + pContractCode + "";
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

        public static DataTable GetListContract(int pPCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                //Legal.JContractDynamicType dynamicType = new Legal.JContractDynamicType(Finance.JOwnershipType.Personel.GetHashCode());
                //string AssetSQL = Finance.JAssetType.GetAssetSQL(dynamicType.ClassName);

                string Where = "";
                if (pPCode != 0)
                    Where = "  PC.PersonCode=" + pPCode;
                Db.setQuery(@" select S.Code ContractCode,S.Number,(Select Fa_Date From StaticDates Where En_Date=cast(S.StartDate as Date))StartDate,
 (Select Fa_Date From StaticDates Where En_Date=cast(S.EndDate as Date))EndDate,
Case [Status]
	                        when 0 then ''
	                        when 1 then N'جاری'
	                        when 2 then N'اتمام'
	                        when 3 then N'فسخ شده'
	                        when 4 then N'غیر فعال'
	                        else '' end StatusTitle,PC.PersonCode 

From EmpPersonnelContract P inner join LegSubjectContract S on S.Code=P.ContractCode inner join LegPersonContract PC on S.Code=PC.ContractSubjectCode      
 Where S.FinanceCode=0  And " + Where + " order by EndDate ");
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

        #endregion

        #region Method
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JContractEmployeeTable PDT = new JContractEmployeeTable();
            try
            {
                //if (JPermission.CheckPermission("Employment.JContractEmployee.Insert"))
                //{
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JGroundSheets.GetDataTable(Code));
                        Histroy.Save(this, PDT, Code, "Insert");
                        return Code;
                    }
                    else
                        return -1;
                //}
                //else
                //    return -1;
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
            JDataBase db = new JDataBase();
            try
            {
                return Update(db);
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JContractEmployeeTable PDT = new JContractEmployeeTable();
            try
            {
                //if (JPermission.CheckPermission("Employment.JContractEmployee.Update"))
                //{
                    //PDT.SetValueProperty(this);
                    PDT.SetValueProperty(this);
                    if (PDT.Update(pDB) || pDB.RecordCount == 0)
                    {
                        Histroy.Save(this, PDT, Code, "Update");
                        //Nodes.Refreshdata(Nodes.CurrentNode, JGroundSheets.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
                //}
                //else
                //    return false;
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
        public bool delete()
        {
            JContractEmployeeTable PDT = new JContractEmployeeTable();
            JDataBase db = new JDataBase();
            try
            {
                //if (JPermission.CheckPermission("Employment.JContractEmployee.Delete"))
                //{
                    PDT.SetValueProperty(this);
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete(db))
                    {
                        ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                        AD.DeleteArchive("Legal.JNotice", Code, false);
                        Nodes.Delete(Nodes.CurrentNode);
                        Histroy.Save(PDT, Code, "Deleted", db);
                        return true;
                    }
                    else
                        return false;
                //}
                //else
                //    return false;
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

        #endregion
    }
}
