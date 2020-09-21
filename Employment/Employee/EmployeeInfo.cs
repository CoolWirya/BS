using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JEmployeeInfo : JEmployment
    {

        #region constructor
        public JEmployeeInfo()
        {
            ListFamily = JFamilyInfomation.GetDataTable(-1);
        }
        public JEmployeeInfo(int pCode)
        {
            GetData(pCode);
            ListFamily = JFamilyInfomation.GetDataTable(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد عنوان شغلی
        /// </summary>
        public int JobTitleCode { get; set; }
        /// <summary>
        /// کد عنوان پست
        /// </summary>
        public int PostTitleCode { get; set; }
        /// <summary>
        /// کد شخص 
        /// </summary>
        public int pCode { get; set; }
        /// <summary>
        /// شماره پرسنلی 
        /// </summary>
        public int PersonNumber { get; set; }
        /// <summary>
        /// شماره کارت 
        /// </summary>
        public int PersonCart { get; set; }
        /// <summary>
        /// فعال 
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// نوع فعالیت
        /// </summary>
        public int Activity { get; set; }
        /// <summary>
        /// بخش
        /// </summary>
        public int Sector { get; set; }
        /// <summary>
        /// مدرک
        /// </summary>
        public int id_maghta { get; set; }
        /// <summary>
        /// رشته
        /// </summary>
        public int id_cource { get; set; }
        /// <summary>
        /// محل دریافت
        /// </summary>
        public string graduatedPlace { get; set; }
        /// <summary>
        /// تاریخ دریافت
        /// </summary>
        public DateTime graduatedDate { get; set; }
        /// <summary>
        /// گواینامه پایه 1
        /// </summary>
        public bool firstDrivingCard { get; set; }
        /// <summary>
        /// گواینامه پایه 2
        /// </summary>
        public bool secondDrivingCard { get; set; }
        /// <summary>
        /// گواینامه موتور
        /// </summary>
        public bool motorCard { get; set; }
        /// <summary>
        /// سربازی
        /// </summary>
        public int id_militay { get; set; }
        /// <summary>
        /// علت معافیت
        /// </summary>
        public string moafReson { get; set; }
        /// <summary>
        /// محل خدمت
        /// </summary>
        public string servicePlace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ServiceStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ServiceEnd { get; set; }
        /// <summary>
        /// سابقه جبهه
        /// </summary>
        public string warExpereience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string basigmembership { get; set; }
        /// <summary>
        /// خانواده شهید
        /// </summary>
        public bool ShahidFamily { get; set; }
        /// <summary>
        /// نوع جانبازی
        /// </summary>
        public string janbazikind { get; set; }
        /// <summary>
        /// درصد جانبازی
        /// </summary>
        public decimal janbazPercent { get; set; }
        /// <summary>
        /// وضعیت مسکن
        /// </summary>
        public int id_maskan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool azadefamily { get; set; }
        /// <summary>
        /// جانبازی
        /// </summary>
        public bool janbaz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int nesbatShahid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int nesbatJanbaz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int nesbatAzade { get; set; }
        /// <summary>
        /// شماره بیمه
        /// </summary>
        public string bimeNom { get; set; }
        /// <summary>
        /// شماره گواهینامه
        /// </summary>
        public string drivingcartNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastSanavet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime employeeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id_delayGroup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountnumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id_bank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id_parvandeh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode { get; set; }

        private DataTable _ListFamily;
        public DataTable ListFamily { get; set; }

        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpEmployee where Code=" + pCode + "";
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
        #endregion

        public bool Find(string pWhere)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpEmployee where " + pWhere;
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


        public int Insert(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.Line.JLine.Insert"))
            //    return 0;
            JEmployeeInfoTable AT = new JEmployeeInfoTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            //  if (Code > 0 && !isWeb)
            //  Nodes.DataTable.Merge(JEmployeeInfos.GetDataTable(Code));
            //ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            //jHistory.Save("BusManagment.JLine", Code, 0, 0, 0, "ثبت خطوط", "", 0);
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.Line.JLine.Update"))
            //    return false;
            JEmployeeInfoTable AT = new JEmployeeInfoTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                // if (!isWeb)
                //    Nodes.Refreshdata(Nodes.CurrentNode, JLineServicess.GetDataTable(Code).Rows[0]);
                /// ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                //jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "ویرایش خطوط", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {

            JDataBase DB = JGlobal.MainFrame.GetDBO();
            JEmployeeInfoTable PDT = new JEmployeeInfoTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                {
                    //Nodes.Delete(Nodes.CurrentNode);
                    return true;
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
                DB.Dispose();
                PDT.Dispose();
            }

            return false;
        }


        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (JPermission.CheckPermission("Employment.JEmployeeInfo.Insert"))
            {
                if (!(Find(" pCode=" + pCode)))
                {
                    if (!(Find(" PersonNumber=" + PersonNumber)))
                    {
                        JDataBase tempDb = new JDataBase();
                        JEmployeeInfoTable JLT = new JEmployeeInfoTable();
                        JFamilyInfomation tmpFamilyInfomation = new JFamilyInfomation();
                        try
                        {
                            tempDb.beginTransaction("EmployeeInfo");
                            JLT.SetValueProperty(this);
                            Code = JLT.Insert(tempDb);
                            if (Code > 0)
                            {
                                if (tmpFamilyInfomation.Save(Code, ListFamily, tempDb))
                                {
                                    if (tempDb.Commit())
                                    {
                                        Nodes.DataTable.Merge(JEmployeeInfos.GetDataTable(Code, ""));
                                        return Code;
                                    }
                                    else
                                    {
                                        tempDb.Rollback("EmployeeInfo");
                                        return 0;
                                    }
                                }
                                else
                                {
                                    tempDb.Rollback("EmployeeInfo");
                                    return 0;
                                }
                            }
                            tempDb.Rollback("EmployeeInfo");
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                            tempDb.Rollback("EmployeeInfo");
                            return 0;
                        }
                        finally
                        {
                            tempDb.Dispose();
                            JLT.Dispose();
                            tmpFamilyInfomation.Dispose();
                        }
                    }
                    else
                        JMessages.Message(" شماره پرسنلی تکراری است ", "", JMessageType.Error);
                }
                else
                    JMessages.Message(" شماره پرسنلی برای این شخص قبلا ثبت شده است ", "", JMessageType.Error);
            }
            return 0;
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (JPermission.CheckPermission("Employment.JEmployeeInfo.Delete"))
            {
                if (JMessages.Question("آیا میخواهید پرسنل انتخاب شده حذف شود؟", "حذف پرسنل") != System.Windows.Forms.DialogResult.Yes)
                    return false;
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                JEmployeeInfoTable PDT = new JEmployeeInfoTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
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
                    DB.Dispose();
                    PDT.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
                return Update(Db);
            }
            finally
            {
                Db.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db)
        {
            if (!(JPermission.CheckPermission("Employment.JEmployeeInfo.Update")))
                return false;
            JDataBase tempDb = new JDataBase();
            JEmployeeInfoTable JLT = new JEmployeeInfoTable();
            JFamilyInfomation tmpFamilyInfomation = new JFamilyInfomation();
            try
            {
                tempDb.beginTransaction("EmployeeInfo");
                JLT.SetValueProperty(this);
                if (JLT.Update(tempDb))
                {
                    if (tmpFamilyInfomation.Save(Code, ListFamily, tempDb))
                    {
                        if (tempDb.Commit())
                        {
                            Nodes.Refreshdata(Nodes.CurrentNode, JEmployeeInfos.GetDataTable(this.Code, "").Rows[0]);
                            return true;
                        }
                        else
                        {
                            tempDb.Rollback("EmployeeInfo");
                            return false;
                        }
                    }
                    else
                    {
                        tempDb.Rollback("EmployeeInfo");
                        return false;
                    }
                }
                tempDb.Rollback("EmployeeInfo");
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempDb.Rollback("EmployeeInfo");
                return false;
            }
            finally
            {
                tempDb.Dispose();
                JLT.Dispose();
                tmpFamilyInfomation.Dispose();
            }
        }

        public void ShowForm()
        {
            ShowForm(0, 0, 0);
        }
        public void ShowForm(int pCode, int pOrgCode, int pComanycode)
        {
            if (pCode == 0)
            {
                JEmployeeInfoForm LandForm = new JEmployeeInfoForm(pComanycode);
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JEmployeeInfoForm LandForm = new JEmployeeInfoForm(pCode, 0);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }


        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @" select * from EmpEmployee " + Where; // EmpVacationHour 
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void UpdateActive(int pCode, bool pReturned)
        {
            JEmployeeInfoTable JLT = new JEmployeeInfoTable();
            try
            {
                GetData(pCode);
                JLT.SetValueProperty(this);
                JLT.Active = pReturned;
                if (JLT.Update())
                    Nodes.Refreshdata(Nodes.CurrentNode, JEmployeeInfos.GetDataTable(this.Code, "").Rows[0]);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                JLT.Dispose();
            }
        }

        public void UpdateContractDeActive(int pCode, Legal.JContractStatus pStatus)
        {
            if (JMessages.Question(" برای انجام عملیات مطمئن هستید ؟ ", "") != System.Windows.Forms.DialogResult.Yes)
                return;
            Legal.JSubjectContract JLT = new Legal.JSubjectContract(pCode);
            try
            {
                JLT.Status = pStatus;
                //if (pStatus == Legal.JContractStatus.Current.GetHashCode())
                //    JLT.Status = Legal.JContractStatus.Current;
                //else if (pStatus == Legal.JContractStatus.Expired.GetHashCode())
                //    JLT.Status = Legal.JContractStatus.Expired;

                if (JLT.Update())
                    JMessages.Message(" عملیات با موفقیت انجام شد ", "", JMessageType.Information);
                else
                    JMessages.Error(" عملیات با خطا مواجه شده ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                JLT.Dispose();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Employment.JEmployeeInfo");
            Node.Name = pRow["Full_Title"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            int activity = (pRow["Activity"].ToString() == "" ? 0 : (int)pRow["Activity"]);
            //Node.Hint = pRow["Date"].ToString();

            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Employment.JEmployeeInfo.ShowForm", new object[] { Node.Code, activity, pRow["CompanyCode"] }, null);
            Node.MouseDBClickAction = editAction;
            //اطلاعات کارکرد
            JAction WorkingAction = new JAction("Working...", "Employment.JWorking.WorkingForm", new object[] { Node.Code }, null);// Convert.ToInt32(pRow["PersonCart"])
            Node.MouseClickAction = WorkingAction;

            if (JPermission.CheckPermission("Employment.JEStaticNode.CheckPermissionMenu", false))
            {
                //اطلاعات ریز اکشن ویرایش
                JAction editDetailAction = new JAction("EditDetailInformation...", "ClassLibrary.JPerson.ShowDialog", null, new object[] { Convert.ToInt32(pRow["pCode"]) });
                Node.MouseClickAction = editDetailAction;
                //اکشن حذف
                JAction DeleteAction = new JAction("Delete", "Employment.JEmployeeInfo.Delete", null, new object[] { Node.Code });
                Node.DeleteClickAction = DeleteAction;
                //اکشن جدید
                JAction newAction = new JAction("New...", "Employment.JEmployeeInfo.ShowForm", null, null);
                Nodes.hidColumns = "Activity";
                JAction ReturnedAction;
                if (pRow["Active"].ToString() == "False")
                    ReturnedAction = new JAction("Active...", "Employment.JEmployeeInfo.UpdateActive", new object[] { Node.Code, true }, null);
                else
                    ReturnedAction = new JAction("Deactive...", "Employment.JEmployeeInfo.UpdateActive", new object[] { Node.Code, false }, null);
                Node.Popup.Insert(ReturnedAction);
                Node.Popup.Insert(DeleteAction);

                Node.Popup.Insert(editDetailAction);
                Node.Popup.Insert(newAction);
            }
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(WorkingAction);
            return Node;
        }
    }

    public class JEmployeeInfos : JSystem
    {

        public JEmployeeInfos[] Items = new JEmployeeInfos[0];
        public JEmployeeInfos()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0, "");
        }
        public DataTable GetDataTable(int pCode)
        {
            return GetDataTable(pCode, "");
        }

        //string StrQuery = @"";

        public static DataTable GetDataTable(int pCode, string pWhere)
        {
            string Where = " 1=1 ";
            if (pWhere == "")
                Where = Where + " And Active=1 ";
            else
                Where = Where + pWhere;
            if (pCode != 0)
                Where = Where + " And EmpEmployee.Code=" + pCode;
            //            string Query = @"select code,pCode,
            //(select (Fam+'-'+Name+'_'+cast(EmpEmployee.PersonNumber as nvarchar)) 'Name' from clsPerson P Where P.Code=EmpEmployee.pCode ) 'Full_Title',
            //PersonNumber,PersonCart,(select name from subdefine where Code=Activity) 'Unit' , Activity,Active 
            //from EmpEmployee Where " + Where;// +" And " + JPermission.getObjectSql("Employment.JEmployeeInfos.GetDataTable", "Code");
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select code,pCode,
(select (Fam+'-'+Name) 'Name' from clsPerson P Where P.Code=EmpEmployee.pCode ) 'Full_Title',
PersonNumber,PersonCart,(select name from subdefine where Code=Activity) 'Unit' 
,(select name from subdefine where Code=Sector) 'Sector'
, Activity,Active ,
(Select Name From subdefine Where Code= (select titleCode from EmpJobTitle where Code=JobTitleCode))JobTitleCode,
(select [Group] from EmpJobTitle where Code=JobTitleCode) JobTitleGroup,
(Select Title From EmpPostTitle Where Code=PostTitleCode)PostTitleCode,
(select Name From subdefine where Code=(select Sader from clsPerson where  pcode=Code)) BirthplaceCode,
PersonID,
(Select Name From subdefine Where Code=id_maghta) id_maghta,
(Select Name From subdefine Where Code=id_cource) id_cource,
graduatedPlace,
(Select Fa_date from StaticDates Where En_Date=cast(graduatedDate as Date)) graduatedDate,
firstDrivingCard,
secondDrivingCard,
motorCard,
(Select Name From subdefine Where Code=id_militay)id_militay,
moafReson,
servicePlace,
(Select Fa_date from StaticDates Where En_Date=cast(ServiceStart as Date)) ServiceStart,
(Select Fa_date from StaticDates Where En_Date=cast(ServiceEnd as Date)) ServiceEnd,
warExpereience,
basigmembership,
ShahidFamily,
janbazikind,
janbazPercent,
(Select Name From subdefine Where Code=id_maskan) id_maskan,
azadefamily,
janbaz,
nesbatShahid,
nesbatJanbaz,
nesbatAzade,
married,
bimeNom,
drivingcartNo,
(Select Fa_date from StaticDates Where En_Date=cast(lastSanavet as Date)) lastSanavet,
(Select Fa_date from StaticDates Where En_Date=cast(employeeDate as Date)) employeeDate,
accountnumber,
(Select Name From subdefine Where Code=id_bank)id_bank,
id_parvandeh,
(select Name From clsPerson where Code=pcode) Name,
(select Fam From clsPerson where Code=pcode) Fam,
(select ShSh From clsPerson where Code=pcode) ShSh,
(select FatherName From clsPerson where Code=pcode) FatherName,
(select ShMeli From clsPerson where Code=pcode) ShMeli,
(select [Address] + ' تلفن ' + Tel From clsPersonAddress where clsPersonAddress.pCode=EmpEmployee.pcode and AddressType=1) [Address],
(select Mobile From clsPersonAddress where clsPersonAddress.pCode=EmpEmployee.pcode and AddressType=1) [Mobile],
(select (select Fa_date From StaticDates where cast(BthDate as Date)=En_Date) From clsPerson where Code=pcode) BthDate,
(select [گروه] from [Propperty_ClassName_Employment.JEmployeeInfoForm_11] Where ObjectCode=EmpEmployee.Code) 'گروه کارانه',CompanyCode  
from EmpEmployee Where " + Where + " And " + JPermission.getObjectSql("Employment.JEmployeeInfos.GetDataTable", "Code") + " order by Full_Title ");
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTableByPCode(int pPCode, string pWhere)
        {
            string Where = " 1=1 ";
            if (pPCode != 0)
                Where = Where + " And EmpEmployee.PCode=" + pPCode;
            if (pWhere != "")
                Where = Where + pWhere;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select code,pCode,
(select Name From clsPerson where Code=pcode) Name,
(select Fam From clsPerson where Code=pcode) Fam,
(select ShSh From clsPerson where Code=pcode) ShSh,
(select FatherName From clsPerson where Code=pcode) FatherName,
(select ShMeli From clsPerson where Code=pcode) ShMeli,
(select [Address] + ' تلفن ' + Tel From clsPersonAddress where clsPersonAddress.pCode=EmpEmployee.pcode and AddressType=1) [Address],
(select Name From subdefine where Code=(select Sader from clsPerson where  pcode=Code)) BirthplaceCode,
(select (select Fa_date From StaticDates where cast(BthDate as Date)=En_Date) From clsPerson where Code=pcode) BthDate,
(select (Fam +' '+Name) 'Name' from clsPerson P Where P.Code=EmpEmployee.pCode ) 'Full_Title',
PersonNumber,PersonCart,(select name from subdefine where Code=Activity) 'Unit' , 
(select name from subdefine where Code=Sector) 'Sector' ,
Activity,Active ,
(Select JobCode From EmpJobTitle Where Code= JobTitleCode)JobTitleCode,
(Select postnumber From EmpPostTitle Where Code=PostTitleCode)PostTitleCode,
(Select [Group] From EmpJobTitle Where Code= JobTitleCode)[Group],
(Select Name From subdefine Where Code= (select titlecode from EmpJobTitle where code=JobTitleCode))JobTitle,
(Select Title From EmpPostTitle Where Code=PostTitleCode)PostTitle,
PersonID,
(Select Name From subdefine Where Code=id_maghta) maghta,
(Select Name From subdefine Where Code=id_cource) cource,
graduatedPlace,
(Select Fa_date from StaticDates Where En_Date=cast(graduatedDate as Date)) graduatedDate,
firstDrivingCard,
secondDrivingCard,
motorCard,
(Select Name From subdefine Where Code=id_militay) militay,
moafReson,
servicePlace,
(Select Fa_date from StaticDates Where En_Date=Cast(ServiceStart as Date)) ServiceStart,
(Select Fa_date from StaticDates Where En_Date=Cast(ServiceEnd as Date)) ServiceEnd,
warExpereience,
basigmembership,
ShahidFamily,
janbazikind,
janbazPercent,
(Select Name From subdefine Where Code=id_maskan) maskan,
azadefamily,
janbaz,
nesbatShahid,
nesbatJanbaz,
nesbatAzade,
case (select COUNT(*) from EmpFamilyInformation where NesbatType=1 and EmployeeCode=EmpEmployee.Code) when 1 then 'متاهل' when 0 then 'مجرد' end Married,
bimeNom,
drivingcartNo,
(Select Fa_date from StaticDates Where En_Date= cast(lastSanavet as Date)) lastSanavet,
(Select Fa_date from StaticDates Where En_Date= cast(employeeDate as Date)) employeeDate,
id_delayGroup,
accountnumber,
(Select Name From subdefine Where Code=id_bank) bank,
id_parvandeh,
(select Count(*) from EmpFamilyInformation Where is_finished=0 And NesbatType<>1 And EmployeeCode=EmpEmployee.Code) CountChild
from EmpEmployee
 Where " + Where);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion GetData

        #region Node

        /// <summary>
        /// 
        /// </summary>
        public void ListView1(int pState, int pCompanyCode)
        {
            Nodes.ObjectBase = new JAction("EmployeeInfo", "Employment.JEmployeeInfo.GetNode");
            Nodes.DataTable = GetDataTable(0, " And [Active]=" + pState + " And CompanyCode= " + pCompanyCode);
        }

        public void ListView(int pCompanyCode)
        {
            Nodes.ObjectBase = new JAction("EmployeeInfo", "Employment.JEmployeeInfo.GetNode");
            Nodes.DataTable = GetDataTable(0, " And Active=1 And CompanyCode=" + pCompanyCode);

            if (JPermission.CheckPermission("Employment.JEStaticNode.CheckPermissionMenu", false))
            {
                JAction ActiveContractAction = new JAction("Current...", "Employment.JEmployeeInfos.ListView1", new object[] { 1, pCompanyCode }, null);
                Nodes.GlobalMenuActions.Insert(ActiveContractAction);
                JToolbarNode JTN = new JToolbarNode();
                JTN.Click = ActiveContractAction;
                JTN.Icon = JImageIndex.Activity;
                JTN.Hint = " پرسنل فعال  ";
                Nodes.AddToolbar(JTN);

                JAction DeActiveAction = new JAction("Expired...", "Employment.JEmployeeInfos.ListView1", new object[] { 0, pCompanyCode }, null);
                Nodes.GlobalMenuActions.Insert(DeActiveAction);
                JToolbarNode JTN2 = new JToolbarNode();
                JTN2.Click = DeActiveAction;
                JTN2.Icon = JImageIndex.Help;
                JTN2.Hint = " پرسنل غیر فعال ";
                Nodes.AddToolbar(JTN2);

                Nodes.hidColumns = "code,pCode,PersonID";
                JAction newAction = new JAction("New...", "Employment.JEmployeeInfo.ShowForm", new object[] { 0, 0, pCompanyCode }, null);
                Nodes.GlobalMenuActions.Insert(newAction);
                JToolbarNode JTN1 = new JToolbarNode();
                JTN1.Click = newAction;
                JTN1.Icon = JImageIndex.Add;
                Nodes.AddToolbar(JTN1);
            }
        }

        #endregion Node

    }
}
