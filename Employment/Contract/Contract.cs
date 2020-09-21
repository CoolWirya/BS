using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ClassLibrary;
namespace Employment
{
    public enum JContractState 
    {
        /// <summary>
        /// قرارداد فعال
        /// </summary>
        ActiveContract = 1, 
        /// <summary>
        /// قرارداد غیرفعال
        /// </summary>
        DeactiveContract = 0
    }
    /// <summary>
    /// کلاس قرارداد پرسنل
    /// </summary>
    public class JEContract : JSystem
    {

        #region Cunstractor
        public JEContract()
        {
        }
        public JEContract(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Properties
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// تاریخ استخدام
        /// </summary>
        public DateTime DateEmployee { get; set; }
        /// <summary>
        /// تاریخ قرارداد
        /// </summary>
        public DateTime DateContract { get; set; }
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        public DateTime DateEnd { get; set; }
        /// <summary>
        /// وضعیت قرارداد
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// محل فعالیت که از چارت سازمانی خوانده میشود
        /// </summary>
        public int ChartCode { get; set; }
        /// <summary>
        /// نوع فعالیت که جزو تعاریف اولیه می باشد
        /// </summary>
        public int ActivityType { get; set; }
        /// <summary>
        /// نوع شیفت
        /// </summary>
        public int ShiftCode { get; set; }
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public string ContractNo { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string ContractDesc { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int UserCode { get; set; }

        #endregion

        public int Insert()
        {
            JContractTable JAGsT = new JContractTable();
            try
            {
                if (JPermission.CheckPermission("Employment.JEContract.Insert"))
                {
                    JAGsT.SetValueProperty(this);
                    Code = JAGsT.Insert();
                    if (Code > 0)
                        //Nodes.DataTable.Merge(JEContracts.GetDataTable(Code));
                    return Code;
                }
                return -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }

        public bool Update()
        {
            JContractTable JAGsT = new JContractTable();
            try
            {
                if (JPermission.CheckPermission("Employment.JEContract.Update"))
                {
                    JAGsT.SetValueProperty(this);
                    if (JAGsT.Update())
                    {
                        //Nodes.Refreshdata(Nodes.CurrentNode, JEContracts.GetDataTable(this.Code).Rows[0]);
                        return true;
                    }
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
                JAGsT.Dispose();
            }
        }
        /// <summary>
        /// عقد قرارداد
        /// </summary>
        /// <returns></returns>
        public int NewContract()
        {
            JContractTable table = new JContractTable();
            table.SetValueProperty(this);
            return table.Insert();
        }
        /// <summary>
        /// اتمام قرارداد
        /// </summary>
        /// <returns></returns>
        public bool FinishContract()
        {
            State = JContractState.DeactiveContract.GetHashCode();
            JContractTable table = new JContractTable();
            table.SetValueProperty(this);
            bool update;
            update = table.Update();
            /// غیر فعال کردن پستهای شخص
            JEOrganizationChart chart = new JEOrganizationChart(this.ChartCode);
            chart.DisableUser();
            return update;
        }
        /// <summary>
        /// تمدید قرارداد
        /// </summary>
        /// <returns></returns>
        public int ReNewContract()
        {
            JContractTable table = new JContractTable();
            table.SetValueProperty(this);
            int res = table.Insert();
            return res;
        }
        /// <summary>
        /// حذف قرارداد
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            JContractTable table = new JContractTable();
            try
            {
                if (JPermission.CheckPermission("Employment.JEContract.Delete"))
                {
                    if (!Find(pCode))
                        return false;
                    this.Code = pCode;
                    table.SetValueProperty(this);
                    bool res = table.Delete();
                    Nodes.Delete(Nodes.CurrentNode);
                    //EventManager.JEvents.AfterDeleteContract(pCode);          
                    return res;
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
                table.Dispose();
            }
        }

        public bool Find(int Code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM empcontract WHERE code = " + Code.ToString());
                DB.Query_DataSet();
                return (DB.DataSet.Tables[0].Rows.Count > 0);
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// نمایش فرم قرارداد
        /// </summary>
        //public void ShowForm()
        //{
        //    JEContractForm form = new JEContractForm();
        //    form.ShowDialog();
        //}

        //public JNode GetNode()
        //{
        //    JPerson person= new JPerson(PCode);
        //    return JEStaticNode._Contract(person, this);
        //}

        #region GetData&Showdata&Find
        public bool GetData(int pCode)
        {
            string Qouery = "select * from empcontract where Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
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
                Db.Dispose();
            }
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["code"], "Employment.JEContract");
            Node.Name = pRow["COde"].ToString() + JLanguages._Text("ContractNo: "); //JLanguages._Text("Code: ") + pRow["Code"].ToString() +
            //  "\n" + 
            //Node.Icone = JImageIndex.Default.GetHashCode();
            ////اکشن اضافه
            //JAction newAction = new JAction("new...", "Employment.JEContract.ShowDialog", null, null);
            ////اکشن حذف 
            //JAction delAction = new JAction("delete...", "Employment.JEContract.Delete",  new object[] { Node.Code },null);
            //Node.DeleteClickAction = delAction;
            ////اکشن نمایش
            //JAction ShowAction = new JAction("Edit...", "Employment.JEContract.ShowDialog", null, new object[] { Node.Code });
            //Node.MouseDBClickAction = ShowAction;
            //Node.EnterClickAction = ShowAction;
            //JPopupMenu PMenu = new JPopupMenu("Employment.JEContract", Node.Code);
            //PMenu.Insert(delAction);
            //PMenu.Insert(ShowAction);
            //PMenu.Insert(newAction);
            //Node.Popup = PMenu;
            ////اکشن تمدید قرارداد

            Legal.JSubjectContract contract = new Legal.JSubjectContract(Node.Code);
            Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);

            JPopupMenu pMenu = new JPopupMenu("Employment.JEmployeeInfoForm", Node.Code);

            //  چاپ قرارداد
            JAction ContractPrint = new JAction("چاپ مجدد قرارداد...", "Employment.JEContract.CreateContractPrint", new object[] { pRow }, null);//
            pMenu.Insert(ContractPrint);

            JAction ShowWordCurrentContract = OfficeWord.JWordForm.getAction("Legal.JContractForms", Node.Code, true);
            pMenu.Insert(ShowWordCurrentContract);

            JAction editContract = new JAction("EditContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, Node.Code, false });
            pMenu.Insert(editContract);

            JAction viewContract = new JAction("viewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, Node.Code, true });
            pMenu.Insert(viewContract);

            //int FinanceCode = 0;
            //if (_BuyContractCode != 0)
            //{
            ///// اکشن تائید قرارداد
            //Legal.JSubjectContract SC = new Legal.JSubjectContract(_BuyContractCode);
            //FinanceCode = SC.FinanceCode;
            //JAction confirmAction = new JAction("ConfirmContract...", "Legal.JSubjectContract.ConfirmContract", new object[] { SC.ContractType.Code }, new object[] { _BuyContractCode });
            //pMenu.Insert(confirmAction);
            //SC.Dispose();
            //}
            //else
            //{
            //    JAsset tmpAsset = new JAsset();
            //    tmpAsset.GetData("Estates.JGround", (int)pRow[JGroundSheetEnum.GCode.ToString()]);
            //    FinanceCode = tmpAsset.Code;
            //}

            //pMenu.Insert(splitter);

            //List<JAction> actions =
            //    CreateActions(_BuyContractCode, _PersonContractCode);
            //foreach (JAction action in actions)
            //{
            //    pMenu.Insert(action);
            //}

            JAction NewContract = new JAction("NewContract...", "");

            Legal.JContractNodes CN = new Legal.JContractNodes();
            ///// در صورتی که نیاز است هر کدام از اراضی به عنوان یک گروه امول تعریف شود(مانند بازار در اعیان) کد اراضی را به عنوان پارامتر این تابع قرار میدهیم. 
            ///// ولی در حال حاضر چون خود زمین به عنوان یک گروه اموال تعریف شده، کد 1 را میفرستیم
            JNode[] _nodes = CN.ContractTree(0);

            foreach (JNode _node in _nodes)
            {
                JAction _AContractType = new JAction(_node.Name, "");
                NewContract.AddChild(_AContractType);
                if (_node.ChildsAction != null)
                {
                    JNode[] _childnodes = (JNode[])_node.ChildsAction.run();
                    foreach (JNode _childnode in _childnodes)
                    {
                        Legal.ArgParameter[] B = new Legal.ArgParameter[1];
                        B[0].Value = pRow["PersonCode"].ToString();
                        B[0].FormName = "JContractEmployeeForm";
                        B[0].PrpertyName = "PCode";

                        JAction _AContract =
                            new JAction(_childnode.Name, "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code,
                                Node.Code, Legal.JBaseContractForm.JStateContractForm.Insert, B
                                 });
                        _AContractType.AddChild(_AContract);
                    }
                }
            }

            pMenu.Insert(NewContract);
            Node.Popup = pMenu;
            return Node;
        }


        public void ShowDialog()
        {
            //if (!JPermission.CheckPermission("RealEstate.JAggregateUnitBuild.ShowDialog"))
            //    return;
            if (this.Code == 0)
            {
                JEContractForm JAF = new JEContractForm();
                JAF.State = JFormState.Insert;
                JAF.ShowDialog();
            }
            else
            {
                JEContractForm JAF = new JEContractForm(Code);
                JAF.State = JFormState.Update;
                JAF.ShowDialog();
            }
        }
        #endregion


        public int CreateContract(DataRow pDr)
        {
            try
            {
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Code", typeof(int));
                dt.Columns.Add("i", typeof(int));

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                Legal.JContractdefine tmpJContractdefine = new Legal.JContractdefine();
                Legal.JGeneralContract tmpGeneralContract = new Legal.JGeneralContract(-2, -2);

                DataRow dr = pDr;
                tmpSubjectContract.GetData(Convert.ToInt32(dr["Code"]));
                if (tmpJContractdefine.Code == 0)
                {
                    tmpJContractdefine.GetData(tmpSubjectContract.Type);
                    tmpGeneralContract.LoadForms(tmpJContractdefine.ContractType, tmpSubjectContract.Code, true);
                }
                tmpGeneralContract.GetData(tmpJContractdefine.ContractType, tmpSubjectContract.Code, 0, true);
                tmpGeneralContract.ContractForms.CreateWordContract();

                i++;
                Nodes.StatusStripMain.Items[0].Text = i.ToString();
                System.Windows.Forms.Application.DoEvents();
                JSystem.FreeObjectsDataReaer();
                return tmpGeneralContract.ContractForms.Contract.FileCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        public void CreateContractPrint()
        {
            try
            {
                //if (!(JPermission.CheckPermission("Estates.JGroundSheet.CreateContractPrint")))
                //    return;

                int _FileCode = 0;

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                OfficeWord.WinWordControl tmpWord = new OfficeWord.WinWordControl();
                foreach (DataRow dr in Nodes.Selected.Rows)// .DefaultView.Rows)
                {
                    //if (ClassLibrary.JAllPerson.CheckCodeMeli(dr["ShMeli"].ToString()))
                    //{
                    tmpSubjectContract.GetData(Convert.ToInt32(dr["Code"]));
                    _FileCode = tmpSubjectContract.FileCode;
                    if (true || _FileCode <= 0)
                    {
                        _FileCode = CreateContract(dr);
                    }

                    tmpWord.GetData(_FileCode);
                    tmpWord.LoadDocument();
                    tmpWord.Print();
                    //}
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void CreateContractPrint(DataRow dr)
        {
            try
            {
                //if (!(JPermission.CheckPermission("Estates.JGroundSheet.CreateContractPrint")))
                //    return;

                int _FileCode = 0;

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                OfficeWord.WinWordControl tmpWord = new OfficeWord.WinWordControl();
                tmpSubjectContract.GetData(Convert.ToInt32(dr["Code"]));
                //_FileCode = tmpSubjectContract.FileCode;
                //if (true || _FileCode <= 0)
                //{
                _FileCode = CreateContract(dr);
                //}

                tmpWord.GetData(_FileCode);
                tmpWord.LoadDocument();
                tmpWord.Print();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void ReportFormOne(int pCompanyCode)
        {
            if (JMainFrame.CurrentUser.code == 1)
                return;

            if (!(JPermission.CheckPermission("Employment.JEContract.ReportForm",false)))
                return;

            JReportForm p = new JReportForm(pCompanyCode);
            p.ShowDialog();
        }

        public void ReportForm(int pCompanyCode)
        {
            if (!(JPermission.CheckPermission("Employment.JEContract.ReportForm")))
                return;

            JReportForm p = new JReportForm(pCompanyCode);
            p.ShowDialog();
        }

        public static DataTable Search(string pWhere)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"select S.Code,
S.Number,(Select Fa_Date From StaticDates Where En_Date=Cast(S.StartDate as Date))StartDate,
 (Select Fa_Date From StaticDates Where En_Date=Cast(S.EndDate as Date))EndDate,
Case [Status]
	                        when 0 then ''
	                        when 1 then N'جاری'
	                        when 2 then N'اتمام'
	                        when 3 then N'فسخ شده'
	                        when 4 then N'غیر فعال'
	                        else '' end StatusTitle,PC.PersonCode ,
(select Name From clsPerson where Code=PC.personcode) Name,
(select Fam From clsPerson where Code=PC.personcode) Fam,
(select PersonNumber from EmpEmployee where pCode=P.id_employee) PersonNumber,
(select PersonCart from EmpEmployee where pCode=P.id_employee) PersonCart,
p.Code EmpCode,
p.workKind,
p.workPlace,
p.workTime,
p.constSallary,
p.maskanRight,
p.kharobarRight,
p.childRight,
p.workPlaceCondition,
p.performanceRight,
p.shiftRight,
p.bonRight,
p.id_employee,
p.protocolKind,
p.ContractCode,
p.cashDec,
p.id_protocolSheet,
p.sarparastyRight,
p.sanavatBase,
p.otherRight,
p.jazbRight,
p.mahroomAzTahsilRight,
p.maz1,
p.maz2,
p.maz3,
p.mazTitle1,
p.mazTitle2,
p.mazTitle3,
p.CalcType,
p.RotbeRight,
p.SakhtiKarRight,
p.JebheRight,
p.MilitryRight,
p.Tafavot,
p.FoghAlade
 from LegSubjectContract S inner join LegPersonContract PC on S.Code=PC.ContractSubjectCode inner join EmpPersonnelContract P on S.Code=P.ContractCode
where 1=1 " + pWhere);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// گزارش تاریخ اتمام افراد تحت تکفل
        /// </summary>
        /// <returns></returns>
        public static DataTable SearchExpireChild(string pWhere, int pCompanyCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"select 
(select (Fam+'-'+Name+'_'+cast(EmpEmployee.PersonNumber as nvarchar)) 'Name' from clsPerson P Where P.Code=EmpEmployee.pCode ) 'Full_Title',
PersonNumber,PersonCart,
(select (Fam) 'Name' from clsPerson P Where P.Code=Fam.pCode ) 'Full_Title_Family',
(select Fa_Date from StaticDates where En_Date=cast(Fam.expireDate as Date)) expireDate,
Case Fam.NesbatType
	                        when 0 then ''
	                        when 1 then N'همسر'
	                        when 2 then N'پسر'
	                        when 3 then N'دختر'
	                        else '' end StatusTitle
from EmpEmployee inner join EmpFamilyInformation Fam on EmpEmployee.Code=Fam.EmployeeCode 
where EmpEmployee.pCode <> " + pCompanyCode + @" And  EmpEmployee.Active=1 
--And Cast(Fam.expireDate as Date) >= cast(GETDATE() as Date) " + pWhere);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// گزارش آمار خانوار پرسنل
        /// </summary>
        /// <returns></returns>
        public static DataTable SearchFamily(string pWhere)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"
select 
(select (Fam+'-'+Name+'_'+cast(EmpEmployee.PersonNumber as nvarchar)) 'Name' from clsPerson P Where P.Code=EmpEmployee.pCode ) 'Full_Title',
PersonNumber,PersonCart,
(select (Fam) 'Name' from clsPerson P Where P.Code=Fam.pCode ) 'Full_Title_Family',
(select Fa_Date from StaticDates where En_Date=cast(Fam.expireDate as Date)) expireDate,
Case Fam.NesbatType
	                        when 0 then ''
	                        when 1 then N'همسر'
	                        when 2 then N'پسر'
	                        when 3 then N'دختر'
	                        else '' end StatusTitle
from EmpEmployee inner join EmpFamilyInformation Fam on EmpEmployee.Code=Fam.EmployeeCode 
where 1=1 " + pWhere);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }

    public class JEContracts : JSystem
    {
        public JEContract[] Items= new JEContract[0];
        public void GetLists(string Where)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + " * FROM empcontract "+ Where );
                DB.Query_DataReader();
                Array.Resize(ref Items, DB.RecordCount);
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    Items[Count] = new JEContract();
                    JTable.SetToClassProperty(Items[Count], DB.DataReader);
                    Count++;
                }
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static DataTable GetDataTable( int pCompanyCode)
        {
            return GetDataTable("", pCompanyCode);
        }

        public static DataTable GetDataTable(string pWhere, int pCompanyCode)
        {            
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            if (pCompanyCode != 0)
                pWhere = pWhere + " And P.id_employee in (Select Code from EmpEmployee where CompanyCode=" + pCompanyCode + " And Active=1)";
            try
            {
//                DB.setQuery(@"Select 
//                                Code,
//                                (Select Name from clsAllPerson where Code=pCode) 'Name',
//                                contractNo,
//                                (Select Fa_Date from StaticDates where En_Date=dateEmployee) 'dateEmployee',
//                                (Select Fa_Date from StaticDates where En_Date=dateContract) 'dateContract',
//                                (Select Fa_Date from StaticDates where En_Date=dateStart) 'dateStart',
//                                (Select Fa_Date from StaticDates where En_Date=dateEnd) 'dateEnd',
//                                (Select Name From subdefine Where Code=Activitytype) 'ActivityName',
//                                (Select Name From subdefine Where Code=ShiftCode) 'ShiftName',
//                                ContractDesc
//                                From EmpContract " + Where);

                DB.setQuery(@"select S.Code,
S.Number,(Select Fa_Date From StaticDates Where En_Date=cast(S.StartDate as Date))StartDate,
 (Select Fa_Date From StaticDates Where En_Date=cast(S.EndDate as Date))EndDate,
Case [Status]
	                        when 0 then ''
	                        when 1 then N'جاری'
	                        when 2 then N'اتمام'
	                        when 3 then N'فسخ شده'
	                        when 4 then N'غیر فعال'
	                        else '' end StatusTitle,PC.PersonCode ,
(select Name From clsPerson where Code=PC.personcode) Name,
(select Fam From clsPerson where Code=PC.personcode) Fam,
(select PersonNumber from EmpEmployee where Code=P.id_employee) PersonNumber,
(select PersonCart from EmpEmployee where Code=P.id_employee) PersonCart,
p.Code EmpCode,
(select name from subdefine where Code=workKind) workKind,
(select name from subdefine where Code=workPlace) workPlace,
(select name from subdefine where Code=protocolKind) protocolKind,
(select name from subdefine where Code=p.workTime) workTime,
(select name from subdefine where Code=CalcType) CalcType,
p.constSallary,
p.maskanRight,
p.kharobarRight,
p.childRight,
p.workPlaceCondition,
p.performanceRight,
p.shiftRight,
p.bonRight,
p.id_employee,
p.ContractCode,
p.cashDec,
p.sarparastyRight,
p.sanavatBase,
p.otherRight,
p.jazbRight,
p.mahroomAzTahsilRight,
p.maz1,
p.maz2,
p.maz3,
p.mazTitle1,
p.mazTitle2,
p.mazTitle3,
p.RotbeRight,
p.SakhtiKarRight,
p.JebheRight,
p.MilitryRight,
p.Tafavot,
p.FoghAlade ,
(select [گروه] from [Propperty_ClassName_Employment.JEmployeeInfoForm_11] Where ObjectCode=P.id_employee) 'گروه کارانه'
 From
EmpPersonnelContract P inner join
LegSubjectContract S on S.Code=P.ContractCode

inner join LegPersonContract PC on S.Code=PC.ContractSubjectCode And (Select pCode from EmpEmployee Where Code=P.id_employee)=PC.PersonCode
 
where PC.personcode <> " + pCompanyCode + pWhere);
//+ @" And [Status]=1 And P.id_employee in (Select Code from EmpEmployee where CompanyCode=  " + pCompanyCode + @" And Active=1)" + pWhere);
//

//from LegSubjectContract S 
//inner join LegPersonContract PC on S.Code=PC.ContractSubjectCode 
//inner join EmpPersonnelContract P on S.Code=P.ContractCode
//where PC.personcode <> " + pCompanyCode + " " + pWhere);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ListView1(int pState, int pCompanyCode)
        {
            Nodes.ObjectBase = new JAction("Contracts", "Employment.JEContract.GetNode");
            if (pState == 0)
                Nodes.DataTable = GetDataTable(" And [Status] <> " + Legal.JContractStatus.Current.GetHashCode() + " And id_employee in (Select Code from EmpEmployee where CompanyCode= " + pCompanyCode + ")", pCompanyCode);
            else
                Nodes.DataTable = GetDataTable(" And [Status]=" + pState + " And id_employee in (Select Code from EmpEmployee where CompanyCode= " + pCompanyCode + ")", pCompanyCode);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ListView(int pCompanyCode)
        {
            Nodes.ObjectBase = new JAction("Contracts", "Employment.JEContract.GetNode");
            Nodes.DataTable = GetDataTable(" And [Status]=1 And id_employee in (Select Code from EmpEmployee where CompanyCode= " + pCompanyCode + ")", pCompanyCode);
            Nodes.hidColumns = "id_employee,PersonCode,ContractCode";

            JAction ActiveContractAction = new JAction("Current...", "Employment.JEContracts.ListView1", new object[] { Legal.JContractStatus.Current.GetHashCode(), pCompanyCode }, null);
            Nodes.GlobalMenuActions.Insert(ActiveContractAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = ActiveContractAction;
            JTN.Icon = JImageIndex.Activity;
            JTN.Hint = " قرارداد  جاری  ";
            Nodes.AddToolbar(JTN);

            JAction DeActiveAction = new JAction("Expired...", "Employment.JEContracts.ListView1", new object[] { Legal.JContractStatus.None.GetHashCode(), pCompanyCode }, null);
            Nodes.GlobalMenuActions.Insert(DeActiveAction);
            JToolbarNode JTN2 = new JToolbarNode();
            JTN2.Click = DeActiveAction;
            JTN2.Icon = JImageIndex.Help;
            JTN2.Hint = " قرارداد اتمام ";
            Nodes.AddToolbar(JTN2);

            //Nodes.Insert(JEStaticNode._RegisterContract());
            
            //GetLists();
            //foreach (JEContract cont in Items)
            //{
            //    Nodes.Insert(cont.GetNode());
            //}
            //Nodes.GlobalMenuActions = new JPopupMenu("Employee.JEContract",0);
            //Nodes.GlobalMenuActions.Insert(JEStaticAction._ContractDBClick());
            //Nodes.AddColumn("PName");
            //Nodes.AddColumn("DateStart");
            //Nodes.AddColumn("DateEnd");
            //GetFilterProperty();
            JAction PrintContractAction = new JAction("ContractPrint...", "Employment.JEContract.CreateContractPrint", null, null);
            JToolbarNode PrintContract = new JToolbarNode();
            PrintContract.Click = PrintContractAction;
            PrintContract.Icon = JImageIndex.Print;
            PrintContract.Hint = " چاپ قرارداد ";
            Nodes.AddToolbar(PrintContract);
        }

    }
    
}
