using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class ConvertForm : Form
    {
        public ConvertForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                JEmployeeInfo tmpEmployeeInfo = new JEmployeeInfo();
                JFamilyInfomation tmpJFamilyInfomation = new JFamilyInfomation();
                JPerson tmpPerson = new JPerson();

                Db.setQuery(@" select 
id,
name,
family,
fullname,
tell,
address,
code,
fname,
id_no,
burthDate,
sodorPlace,
(Select code from subdefine where TempCode=id_maghta and bcode<>304) id_maghta,
(Select code from subdefine where TempCode=id_cource and bcode<>304) id_cource,
graduatedPlace,
graduatedDate,
firstDrivingCard,
secondDrivingCard,
motorCard,
(Select code from subdefine where TempCode=id_militay and bcode<>304) id_militay,
moafReson,
servicePlace,
ServiceStart,
ServiceEnd,
warExpereience,
basigmembership,
ShahidFamily,
janbazikind,
janbazPercent,
(Select code from subdefine where TempCode=id_maskan and bcode<>304) id_maskan,
username,
password,
azadefamily,
janbaz,
nesbatShahid,
nesbatJanbaz,
nesbatAzade,
pic,
married,
bimeNom,
cartno,
sex,
melliNo,
drivingcartNo,
id_department,
lastSanavet,
mobile,
semat,
employeeDate,
kind,
bimeDate,
PostalCode,
childNo,
burthPlace,
ReversFullname,
id_shift,
begin_extraWork,
head_extraWork,
vecation_ExtraWork,
nightWork,
id_delayGroup,
accountnumber,
(Select code from subdefine where TempCode=id_bank and bcode<>304) id_bank,
bankdepartment,
id_parvandeh
from employeetb
 ");
                DataTable dtEmployeeTB = Db.Query_DataTable();
                foreach (DataRow dr in dtEmployeeTB.Rows)
                {
                    Db.setQuery(@" select * from EmpEmployee Where PersonNumber='" + dr["Code"]+"'");
                    if (Db.Query_DataTable().Rows.Count > 0)
                    {
                        tmpEmployeeInfo.GetData(Convert.ToInt32(Db.Query_DataTable().Rows[0]["Code"]));
                        if (dr["id_maghta"].ToString() != "")
                            tmpEmployeeInfo.id_maghta = Convert.ToInt32(dr["id_maghta"]);
                        if (dr["id_cource"].ToString() != "")
                            tmpEmployeeInfo.id_cource = Convert.ToInt32(dr["id_cource"]);
                        tmpEmployeeInfo.graduatedPlace = dr["graduatedPlace"].ToString();
                        if (dr["graduatedDate"].ToString() != "")
                            tmpEmployeeInfo.graduatedDate = Convert.ToDateTime(JDateTime.GregorianDate(dr["graduatedDate"].ToString()));
                        if (dr["firstDrivingCard"].ToString() != "")
                            tmpEmployeeInfo.firstDrivingCard = Convert.ToBoolean(dr["firstDrivingCard"].ToString());
                        if (dr["secondDrivingCard"].ToString() != "")
                            tmpEmployeeInfo.secondDrivingCard = Convert.ToBoolean(dr["secondDrivingCard"].ToString());
                        if (dr["motorCard"].ToString() != "")
                            tmpEmployeeInfo.motorCard = Convert.ToBoolean(dr["motorCard"]);
                        if (dr["id_militay"].ToString() != "")
                            tmpEmployeeInfo.id_militay = Convert.ToInt32(dr["id_militay"]);
                        tmpEmployeeInfo.moafReson = dr["moafReson"].ToString();
                        tmpEmployeeInfo.servicePlace = dr["servicePlace"].ToString();
                        if (dr["ServiceStart"].ToString() != "")
                            tmpEmployeeInfo.ServiceStart = Convert.ToDateTime(JDateTime.GregorianDate(dr["ServiceStart"].ToString()));
                        if (dr["ServiceEnd"].ToString() != "")
                            tmpEmployeeInfo.ServiceEnd = Convert.ToDateTime(JDateTime.GregorianDate(dr["ServiceEnd"].ToString()));
                        tmpEmployeeInfo.warExpereience = dr["warExpereience"].ToString();
                        tmpEmployeeInfo.basigmembership = dr["basigmembership"].ToString();
                        if (dr["ShahidFamily"].ToString() != "")
                            tmpEmployeeInfo.ShahidFamily = Convert.ToBoolean(dr["ShahidFamily"].ToString());
                        tmpEmployeeInfo.janbazikind = dr["janbazikind"].ToString();
                        if (dr["janbazPercent"].ToString() != "")
                            tmpEmployeeInfo.janbazPercent = Convert.ToDecimal(dr["janbazPercent"]);
                        if (dr["id_maskan"].ToString() != "")
                            tmpEmployeeInfo.id_maskan = Convert.ToInt32(dr["id_maskan"]);
                        if (dr["azadefamily"].ToString() != "")
                            tmpEmployeeInfo.azadefamily = Convert.ToBoolean(dr["azadefamily"]);
                        if (dr["janbaz"].ToString() != "")
                            tmpEmployeeInfo.janbaz = Convert.ToBoolean(dr["janbaz"]);
                        if (dr["nesbatShahid"].ToString() != "")
                            tmpEmployeeInfo.nesbatShahid = Convert.ToInt32(dr["nesbatShahid"]);
                        if (dr["nesbatJanbaz"].ToString() != "")
                            tmpEmployeeInfo.nesbatJanbaz = Convert.ToInt32(dr["nesbatJanbaz"]);
                        if (dr["nesbatAzade"].ToString() != "")
                            tmpEmployeeInfo.nesbatAzade = Convert.ToInt32(dr["nesbatAzade"]);
                        tmpEmployeeInfo.bimeNom = dr["bimeNom"].ToString();
                        tmpEmployeeInfo.drivingcartNo = dr["drivingcartNo"].ToString();
                        if (dr["lastSanavet"].ToString() != "")
                            tmpEmployeeInfo.lastSanavet = Convert.ToDateTime(JDateTime.GregorianDate(dr["lastSanavet"].ToString()));
                        if (dr["employeeDate"].ToString() != "")
                            tmpEmployeeInfo.employeeDate = Convert.ToDateTime(JDateTime.GregorianDate(dr["employeeDate"].ToString()));
                        tmpEmployeeInfo.accountnumber = dr["accountnumber"].ToString();
                        if (dr["id_bank"].ToString() != "")
                            tmpEmployeeInfo.id_bank = Convert.ToInt32(dr["id_bank"]);
                        tmpEmployeeInfo.id_parvandeh = dr["id_parvandeh"].ToString();
                        if (tmpEmployeeInfo.Update())
                        {
                            Db.setQuery(@" select * from famillyinformation Where id_employee=" + dr["id"].ToString());
                            DataTable dtFamily = Db.Query_DataTable();
                            int PCode = 0;
                            foreach (DataRow drFam in dtFamily.Rows)
                            {
                                tmpPerson.Name = drFam["fullname"].ToString();
                                tmpPerson.Fam = drFam["fullname"].ToString();
                                //tmpPerson.FatherName = dr["Fam"].ToString();
                                if (drFam["BurthDate"].ToString() != "")
                                tmpPerson.BthDate = Convert.ToDateTime(JDateTime.GregorianDate(drFam["BurthDate"].ToString())); ;
                                if (drFam["ShMelli"].ToString() != "")
                                tmpPerson.ShMeli = drFam["ShMelli"].ToString();
                                if (drFam["id_No"].ToString() != "")
                                tmpPerson.ShSh = drFam["id_No"].ToString();
                                tmpPerson.PDesc = drFam["job"].ToString() + "  " + drFam["description"].ToString();

                                string dtPcode = "";
                                Db.setQuery(@" select isnull(Code,'') from clsperson Where Name=N'" + drFam["fullname"].ToString() + "'");
                                if (Db.Query_ExecutSacler() != null)
                                    dtPcode = Db.Query_ExecutSacler().ToString();
                                if (dtPcode == "")
                                    PCode = tmpPerson.insert();
                                else
                                    PCode = Convert.ToInt32(dtPcode);
                                if (PCode > 0)
                                {
                                    tmpJFamilyInfomation.EmployeeCode = tmpEmployeeInfo.Code;
                                    tmpJFamilyInfomation.PCode = PCode;
                                    tmpJFamilyInfomation.NesbatType = Convert.ToInt32(drFam["id_Nesbat"]);
                                    if (drFam["expireDate"].ToString() != "")
                                        tmpJFamilyInfomation.expireDate = Convert.ToDateTime(JDateTime.GregorianDate(drFam["expireDate"].ToString()));
                                    if (drFam["is_finished"].ToString() != "")
                                        tmpJFamilyInfomation.is_finished = Convert.ToBoolean(drFam["is_finished"]);
                                    else
                                        tmpJFamilyInfomation.is_finished = false;
                                    tmpJFamilyInfomation.Description = drFam["job"].ToString() + "  " + drFam["Description"].ToString();
                                    if(tmpJFamilyInfomation.insert() > 0)
                                        PCode = 0;
                                }
                                else
                                    JMessages.Error(" Family ", "");
                            }
                        }
                    }
                    else
                    {
                    }// JMessages.Error("  ", "");
                }
            }
            catch
            {
                JMessages.Error("  EE ", "");
            }
            finally
            {
                Db.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Legal.JSubjectContract tmpContract = new Legal.JSubjectContract();
                Legal.JPersonContract tmpPersonContract = new Legal.JPersonContract();
                Employment.JContractEmployee tmpContractEmployee = new JContractEmployee();
                JPerson tmpPerson = new JPerson();

                int ContractCode=0;
                Db.setQuery(@" select 
isnull(id,0) id,					
isnull(sDate,'')sDate,				
isnull(eDate,'')eDate,				
isnull(duration,0)duration,					
isnull((select Code from subdefine Where workKind=TempCode and bcode=203),0) workKind,
isnull((select Code from subdefine Where workPlace=TempCode and bcode=211),0) workPlace,
isnull((select Code from subdefine Where workTime=TempCode and bcode=210),0) workTime,
isnull(constSallary,0)constSallary,
isnull(maskanRight,0)maskanRight,
isnull(kharobarRight,0)kharobarRight,
isnull(childRight,0)childRight,
isnull(workPlaceCondition,0)workPlaceCondition,
isnull(performanceRight,0)performanceRight,
isnull(shiftRight,0)shiftRight,
isnull(bonRight,0)bonRight,
(select EmpEmployee.pCode from employeeTB inner join EmpEmployee on employeeTB.code=EmpEmployee.PersonNumber where employeeTB.id=id_employee)id_employee,
(select Code from subdefine Where protocolKind=TempCode And bcode=209) protocolKind,
isnull(registerDate,0)registerDate,
isnull(protocolNumber,0)protocolNumber,
isnull(cashDec,0)cashDec,
--isnull(protocolDoc,0),
isnull(id_protocolSheet,0)id_protocolSheet,
isnull(workDescription,0)workDescription,
isnull(has_doc,0)has_doc,
isnull(is_active,0)is_active,
isnull(checked,0)checked,
isnull(revokeType,0)revokeType,
isnull(revokeDate,0)revokeDate,
isnull(revokeDescription,0)revokeDescription,
isnull(sarparastyRight,0)sarparastyRight,
isnull(sanavatBase,0)sanavatBase,
isnull(otherRight,0)otherRight,
isnull(jazbRight,0)jazbRight,
isnull(mahroomAzTahsilRight,0)mahroomAzTahsilRight,
isnull(is_interim,0)is_interim,
isnull(ChangeReason,'')ChangeReason,
isnull(moreDetails,'')moreDetails,
isnull(maz1,0)maz1,
isnull(maz2,0)maz2,
isnull(maz3,0)maz3,
isnull(mazTitle1,'')mazTitle1,
isnull(mazTitle2,'')mazTitle2,
isnull(mazTitle3,'')mazTitle3,
isnull(CalcType,0)CalcType
From protocol 
Where 
id_employee in (select id from employeeTB where cartno in (4058))
--(select EmpEmployee.pCode from employeeTB inner join EmpEmployee on employeeTB.code=EmpEmployee.PersonNumber where employeeTB.id=id_employee) is not null
");
                DataTable dtprotocol = Db.Query_DataTable();
                foreach (DataRow dr in dtprotocol.Rows)
                {
                    tmpContract.Number = dr["protocolNumber"].ToString();
                    tmpContract.Type = 1000018;
                    tmpContract.ContractTitle = dr["WorkDescription"].ToString();
                    tmpContract.Description = dr["ChangeReason"].ToString();
                    tmpContract.Location = 210001;
                    tmpContract.StartDate = Convert.ToDateTime(JDateTime.GregorianDate(dr["SDate"].ToString()));
                    tmpContract.EndDate = Convert.ToDateTime(JDateTime.GregorianDate(dr["EDate"].ToString()));
                    ContractCode = tmpContract.Insert(Db);
                    if (ContractCode > 0)
                    {
                        tmpPersonContract.ContractSubjectCode = ContractCode;
                        tmpPersonContract.PersonCode = 120000000;
                        tmpPersonContract.Type = 7;
                        tmpPersonContract.Insert(Db);
                        tmpPersonContract.PersonCode = Convert.ToInt32(dr["id_employee"].ToString());
                        tmpPersonContract.Type = 9;
                        tmpPersonContract.Insert(Db);

                        tmpContractEmployee.workKind = Convert.ToInt32(dr["workKind"].ToString());
                        tmpContractEmployee.workPlace = Convert.ToInt32(dr["workPlace"].ToString());
                        tmpContractEmployee.workTime = Convert.ToInt32(dr["workTime"].ToString());
                        tmpContractEmployee.constSallary = Convert.ToDecimal(dr["constSallary"].ToString());
                        tmpContractEmployee.maskanRight = Convert.ToDecimal(dr["maskanRight"].ToString());
                        tmpContractEmployee.kharobarRight = Convert.ToDecimal(dr["kharobarRight"].ToString());
                        tmpContractEmployee.childRight = Convert.ToDecimal(dr["childRight"].ToString());
                        tmpContractEmployee.workPlaceCondition = Convert.ToDecimal(dr["workPlaceCondition"].ToString());
                        tmpContractEmployee.performanceRight = Convert.ToDecimal(dr["performanceRight"].ToString());
                        tmpContractEmployee.shiftRight = Convert.ToDecimal(dr["shiftRight"].ToString());
                        tmpContractEmployee.bonRight = Convert.ToDecimal(dr["bonRight"].ToString());
                        tmpContractEmployee.id_employee = Convert.ToInt32(dr["id_employee"].ToString());
                        tmpContractEmployee.protocolKind = Convert.ToInt32(dr["protocolKind"].ToString());
                        tmpContractEmployee.ContractCode = ContractCode;
                        tmpContractEmployee.cashDec = Convert.ToDecimal(dr["cashDec"].ToString());
                        tmpContractEmployee.id_protocolSheet = Convert.ToInt32(dr["id_protocolSheet"].ToString());
                        tmpContractEmployee.sarparastyRight = Convert.ToDecimal(dr["sarparastyRight"].ToString());
                        tmpContractEmployee.sanavatBase = Convert.ToDecimal(dr["sanavatBase"].ToString());
                        tmpContractEmployee.otherRight = Convert.ToDecimal(dr["otherRight"].ToString());
                        tmpContractEmployee.jazbRight = Convert.ToDecimal(dr["jazbRight"].ToString());
                        tmpContractEmployee.maz1 = Convert.ToDecimal(dr["maz1"].ToString());
                        tmpContractEmployee.maz2 = Convert.ToDecimal(dr["maz2"].ToString());
                        tmpContractEmployee.maz3 = Convert.ToDecimal(dr["maz3"].ToString());
                        tmpContractEmployee.mazTitle1 = dr["mazTitle1"].ToString();
                        tmpContractEmployee.mazTitle2 = dr["mazTitle2"].ToString();
                        tmpContractEmployee.mazTitle3 = dr["mazTitle3"].ToString();
                        tmpContractEmployee.CalcType = Convert.ToInt32(dr["CalcType"].ToString());
                        tmpContractEmployee.Insert(Db);
                    }                    
                }
            }
            catch
            {
                JMessages.Error("  EE ", "");
            }
            finally
            {
                Db.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JDataBase DbArchive = JGlobal.MainFrame.GetArchiveDB();
            try
            {
                int Code = 1100168;

                
                JPerson tmpPerson = new JPerson();

                Db.setQuery(@" select employeeTB.PCode,Images.pic from Images inner join employeeTB on employeeTB.id=Images.id_employee
where employeeTB.pcode in (select pcode from EmpEmployee) and Images.kind=37 ");
                DataTable dtprotocol = Db.Query_DataTable();
                foreach (DataRow dr in dtprotocol.Rows)
                {
                    DbArchive.Params["@Pic"] = dr["Pic"];
                    DbArchive.setQuery(@" insert into ERP_Archive.dbo.ArchiveContent values
                    (" + Code + "	,1	,'.jpg' ,@Pic , 0,'2012-11-07',	0,'2012-11-07',1,'') ");

                    if (!(DbArchive.Query_Execute() > 0))
                        JMessages.Error("", "");
                    DbArchive.setQuery(@" insert into ArchiveInterface values
(" + Code + " ," + Code + ",	'ClassLibrary.JPerson',	" + dr["PCode"] + @",	1,	1,	2	, N'تصویر شخص' 
   ,1, NULL,	'2012-11-07',	1,	1)");

                    if (!(DbArchive.Query_Execute() > 0))
                        JMessages.Error("", "");

                    tmpPerson.getData(Convert.ToInt32(dr["PCode"]));
                    tmpPerson.PersonImageCode = Code;
                    if (tmpPerson.Update())
                        Code++;
                    else
                        JMessages.Error("", "");
                }
            }
            catch
            {
                JMessages.Error("  EE ", "");
            }
            finally
            {
                Db.Dispose();
                DbArchive.Dispose();
            }
        }
    }
}