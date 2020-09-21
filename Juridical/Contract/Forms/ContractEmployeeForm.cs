using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Employment;

namespace Legal
{
    public partial class JContractEmployeeForm : JBaseContractForm
    {
        public int _Code;
        public int _PCode;
        public int _PreContract;

        public JContractEmployeeForm()
        {
            InitializeComponent();
        }

        private JContractTypeSettings _ContractSettings;


        /// <summary>
        /// این تابع برای ساختن و فرستادن فرم بصورت داینامیک استفاده میشود
        /// </summary>
        /// <returns></returns>
        public JContractEmployeeForm MakeForm()
        {
            JContractEmployeeForm form = new JContractEmployeeForm();
            return form;
        }

        #region
        public void Set_Form()
        {
            try
            {
                Employment.JContractEmployee tmpJContractEmployeeTable = new JContractEmployee(ContractForms.Contract.Code);
                _PreContract = ContractForms.Contract.Code;
                if (State == JStateContractForm.Update)
                    _Code = tmpJContractEmployeeTable.Code;
                if (_PCode == 0)
                {
                    Employment.JEmployeeInfo Emp = new JEmployeeInfo(tmpJContractEmployeeTable.id_employee);
                    _PCode = Emp.pCode;
                }
                cmbworkPlace.SelectedValue = tmpJContractEmployeeTable.workPlace;
                cmbActiveType.SelectedValue = tmpJContractEmployeeTable.workKind;
                cmbWorkingTime.SelectedValue = tmpJContractEmployeeTable.workTime;
                txtconstSallary.Text = tmpJContractEmployeeTable.constSallary.ToString();
                txtmaskanRight.Text = tmpJContractEmployeeTable.maskanRight.ToString();
                txtkharobarRight.Text = tmpJContractEmployeeTable.kharobarRight.ToString();
                txtchildRight.Text = tmpJContractEmployeeTable.childRight.ToString();
                txtworkPlaceCondition.Text = tmpJContractEmployeeTable.workPlaceCondition.ToString();
                txtperformanceRight.Text = tmpJContractEmployeeTable.performanceRight.ToString();
                txtshiftRight.Text = tmpJContractEmployeeTable.shiftRight.ToString();
                txtbonRight.Text = tmpJContractEmployeeTable.bonRight.ToString();
                cmbContractEmpType.SelectedValue = tmpJContractEmployeeTable.protocolKind;
                txtcashDec.Text = tmpJContractEmployeeTable.cashDec.ToString();
                txtsarparastyRight.Text = tmpJContractEmployeeTable.sarparastyRight.ToString();
                txtsanavatBase.Text = tmpJContractEmployeeTable.sanavatBase.ToString();
                txtotherRight.Text = tmpJContractEmployeeTable.otherRight.ToString();
                txtjazbRight.Text = tmpJContractEmployeeTable.jazbRight.ToString();
                txtmaz1.Text = tmpJContractEmployeeTable.maz1.ToString();
                txtmaz2.Text = tmpJContractEmployeeTable.maz2.ToString();
                txtmaz3.Text = tmpJContractEmployeeTable.maz3.ToString();
                txtmazTitle1.Text = tmpJContractEmployeeTable.mazTitle1;
                txtmazTitle2.Text = tmpJContractEmployeeTable.mazTitle2;
                txtmazTitle3.Text = tmpJContractEmployeeTable.mazTitle3;
                cmbCalcType.SelectedValue = tmpJContractEmployeeTable.CalcType;

                if (tmpJContractEmployeeTable.Test)
                    chkTest.Checked = true;
                else
                    chkTest.Checked = false;

                txtRotbeRight.Text = tmpJContractEmployeeTable.RotbeRight.ToString();
                txtSakhtiKarRight.Text = tmpJContractEmployeeTable.SakhtiKarRight.ToString();
                txtJebheRight.Text = tmpJContractEmployeeTable.JebheRight.ToString();
                txtMilitryRight.Text = tmpJContractEmployeeTable.MilitryRight.ToString();
                txtTafavot.Text = tmpJContractEmployeeTable.Tafavot.ToString();
                txtFoghAlade.Text = tmpJContractEmployeeTable.FoghAlade.ToString();
                txtCountChild.Text = Employment.JFamilyInfomation.GetCountChild(_PCode).ToString();
                JAllPerson p = new JAllPerson(_PCode);
                groupBox1.Text = p.Name; ;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public override bool SaveBack()
        {
            if (isSave)
            {
                isSave = false;
                State = tempState;
            }
            return true;
        }

        public override bool SavePreview(DataTable pDt)
        {
            return SavePreview(pDt, true, false);
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue)
        {
            return SavePreview(pDt, pSetValue, false);
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue, bool pOffline)
        {
            try
            {
                pDt.Columns.Add("workKind");
                pDt.Columns.Add("workPlace");
                pDt.Columns.Add("workTime");
                pDt.Columns.Add("workPlaceCondition");
                pDt.Columns.Add("protocolKind");
                pDt.Columns.Add("constSallary");
                pDt.Columns.Add("maskanRight");
                pDt.Columns.Add("kharobarRight");
                pDt.Columns.Add("childRight");
                pDt.Columns.Add("performanceRight");
                pDt.Columns.Add("shiftRight");
                pDt.Columns.Add("bonRight");
                pDt.Columns.Add("cashDec");
                pDt.Columns.Add("sarparastyRight");
                pDt.Columns.Add("sanavatBase");
                pDt.Columns.Add("otherRight");
                pDt.Columns.Add("jazbRight");
                pDt.Columns.Add("mahroomAzTahsilRight");
                pDt.Columns.Add("maz1");
                pDt.Columns.Add("maz2");
                pDt.Columns.Add("maz3");
                pDt.Columns.Add("mazTitle1");
                pDt.Columns.Add("mazTitle2");
                pDt.Columns.Add("mazTitle3");
                pDt.Columns.Add("CalcType");
                pDt.Columns.Add("Test");

                pDt.Columns.Add("RotbeRight");
                pDt.Columns.Add("SakhtiKarRight");
                pDt.Columns.Add("JebheRight");
                pDt.Columns.Add("MilitryRight");
                pDt.Columns.Add("Tafavot");
                pDt.Columns.Add("FoghAlade");
                pDt.Columns.Add("TotalPriceSalary");
                pDt.Columns.Add("TotalPriceMazaya");

                //pDt.Columns.Add("JobTitleCode");
                //pDt.Columns.Add("PostTitleCode");
                //pDt.Columns.Add("Group");
                //pDt.Columns.Add("JobTitle");
                //pDt.Columns.Add("PostTitle");

                //pDt.Columns.Add("ShSh");
                //pDt.Columns.Add("ShMeli");
                //pDt.Columns.Add("FatherName");
                //pDt.Columns.Add("Name");
                //pDt.Columns.Add("Fam");
                //pDt.Columns.Add("BthDate");
                //pDt.Columns.Add("BthDatePlace");

                pDt.Columns.Add("constSallaryDaily");
                pDt.Columns.Add("sanavatBaseDaily");
                pDt.Columns.Add("sarparastyRightDaily");
                pDt.Columns.Add("RotbeRightDaily");
                pDt.Columns.Add("SakhtiKarRightDaily");
                pDt.Columns.Add("JebheRightDaily");
                pDt.Columns.Add("MilitryRightDaily");
                pDt.Columns.Add("FoghAladeDaily");
                pDt.Columns.Add("TotalPriceDaily");

                pDt.Columns.Add("DurationMonths");

                DataTable dtEmployeeInfos = Employment.JEmployeeInfos.GetDataTableByPCode(0, "");
                for (int i = 0; i < dtEmployeeInfos.Columns.Count; i++)
                    pDt.Columns.Add(dtEmployeeInfos.Columns[i].Caption);

                if (pSetValue)
                {
                    if (pOffline)
                    {
                        Fill_Data();
                        ApplyData();
                    }
                    dtEmployeeInfos = Employment.JEmployeeInfos.GetDataTableByPCode(_PCode, "");
                    for (int i = 0; i < dtEmployeeInfos.Columns.Count; i++)
                        pDt.Rows[0][dtEmployeeInfos.Columns[i].Caption] = dtEmployeeInfos.Rows[0][dtEmployeeInfos.Columns[i].Caption].ToString();

                    pDt.Rows[0]["BthDate"] = JGeneral.ReverseDate(dtEmployeeInfos.Rows[0]["BthDate"].ToString());
                    pDt.Rows[0]["employeeDate"] = JGeneral.ReverseDate(dtEmployeeInfos.Rows[0]["employeeDate"].ToString());

                    pDt.Rows[0]["workPlace"] = cmbworkPlace.Text;
                    pDt.Rows[0]["workKind"] = cmbActiveType.Text;
                    pDt.Rows[0]["workTime"] = cmbWorkingTime.Text;
                    pDt.Rows[0]["constSallary"] = txtconstSallary.Text;
                    pDt.Rows[0]["maskanRight"] = txtmaskanRight.Text;
                    pDt.Rows[0]["kharobarRight"] = txtkharobarRight.Text;
                    pDt.Rows[0]["childRight"] = txtchildRight.Text;
                    pDt.Rows[0]["workPlaceCondition"] = txtworkPlaceCondition.Text;
                    pDt.Rows[0]["performanceRight"] = txtperformanceRight.Text;
                    pDt.Rows[0]["shiftRight"] = txtshiftRight.Text;
                    pDt.Rows[0]["bonRight"] = txtbonRight.Text;
                    pDt.Rows[0]["protocolKind"] = Convert.ToInt32(cmbContractEmpType.SelectedValue);
                    pDt.Rows[0]["cashDec"] = txtcashDec.Text;
                    pDt.Rows[0]["sarparastyRight"] = txtsarparastyRight.Text;
                    pDt.Rows[0]["sanavatBase"] = txtsanavatBase.Text;
                    pDt.Rows[0]["otherRight"] = txtotherRight.Text;
                    pDt.Rows[0]["jazbRight"] = txtjazbRight.Text;
                    pDt.Rows[0]["maz1"] = txtmaz1.Text;
                    pDt.Rows[0]["maz2"] = txtmaz2.Text;
                    pDt.Rows[0]["maz3"] = txtmaz3.Text;
                    pDt.Rows[0]["mazTitle1"] = txtmazTitle1.Text;
                    pDt.Rows[0]["mazTitle2"] = txtmazTitle2.Text;
                    pDt.Rows[0]["mazTitle3"] = txtmazTitle3.Text;
                    pDt.Rows[0]["CalcType"] = Convert.ToInt32(cmbCalcType.SelectedValue);
                    pDt.Rows[0]["RotbeRight"] = txtRotbeRight.Text;
                    pDt.Rows[0]["SakhtiKarRight"] = txtSakhtiKarRight.Text;
                    pDt.Rows[0]["JebheRight"] = txtJebheRight.Text;
                    pDt.Rows[0]["MilitryRight"] = txtMilitryRight.Text;
                    pDt.Rows[0]["Tafavot"] = txtTafavot.Text;
                    pDt.Rows[0]["FoghAlade"] = txtFoghAlade.Text;

                    SetData();

                    pDt.Rows[0]["constSallaryDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtconstSallary.Text) / 30), 0).ToString());
                    pDt.Rows[0]["sanavatBaseDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtsanavatBase.Text) / 30), 0).ToString());
                    pDt.Rows[0]["sarparastyRightDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtsarparastyRight.Text) / 30), 0).ToString());
                    pDt.Rows[0]["RotbeRightDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtRotbeRight.Text) / 30), 0).ToString());
                    pDt.Rows[0]["SakhtiKarRightDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtSakhtiKarRight.Text) / 30), 0).ToString());
                    pDt.Rows[0]["JebheRightDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtJebheRight.Text) / 30), 0).ToString());
                    pDt.Rows[0]["MilitryRightDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtMilitryRight.Text) / 30), 0).ToString());
                    pDt.Rows[0]["FoghAladeDaily"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtFoghAlade.Text) / 30), 0).ToString());

                    if (chkTest.Checked)
                        pDt.Rows[0]["Test"] = " بصورت آزمایشی";
                    else
                        pDt.Rows[0]["Test"] = "";

                    pDt.Rows[0]["TotalPriceSalary"] = JMoney.StringToMoney(Math.Round((Convert.ToDecimal(txtconstSallary.Text)) +
                                                        (Convert.ToDecimal(txtsanavatBase.Text)) +
                                                        (Convert.ToDecimal(txtsarparastyRight.Text)) +
                                                        (Convert.ToDecimal(txtRotbeRight.Text)) +
                                                        (Convert.ToDecimal(txtSakhtiKarRight.Text)) +
                                                        (Convert.ToDecimal(txtJebheRight.Text)) +
                                                        (Convert.ToDecimal(txtMilitryRight.Text)) +
                                                        (Convert.ToDecimal(txtFoghAlade.Text)), 0).ToString());
                    pDt.Rows[0]["TotalPriceMazaya"] = lblTotal.Text;

                    //JMoney.StringToMoney(Math.Round(
                    //                                (Convert.ToDecimal(txtTafavot.Text)) +
                    //                                (Convert.ToDecimal(txtmaskanRight.Text)) +
                    //                                (Convert.ToDecimal(txtkharobarRight.Text)) +
                    //                                (Convert.ToDecimal(txtchildRight.Text)) +
                    //                                (Convert.ToDecimal(txtperformanceRight.Text)) +
                    //                                (Convert.ToDecimal(txtFoghAlade.Text)), 2).ToString());
                    pDt.Rows[0]["TotalPriceDaily"] = JMoney.StringToMoney(Math.Round(
                                                        (Convert.ToDecimal(txtconstSallary.Text) / 30) +
                                                        (Convert.ToDecimal(txtsanavatBase.Text) / 30) +
                                                        (Convert.ToDecimal(txtsarparastyRight.Text) / 30) +
                                                        (Convert.ToDecimal(txtRotbeRight.Text) / 30) +
                                                        (Convert.ToDecimal(txtSakhtiKarRight.Text) / 30) +
                                                        (Convert.ToDecimal(txtJebheRight.Text) / 30) +
                                                        (Convert.ToDecimal(txtMilitryRight.Text) / 30) +
                                                        (Convert.ToDecimal(txtFoghAlade.Text) / 30), 0).ToString());

                    SetDuration();
                    pDt.Rows[0]["DurationMonths"] = txtDuration;
                    //DataTable dtPerson = JPersons.GetDataTable(_PCode);
                    //JPerson tmpPerson = new JPerson(_PCode);
                    //pDt.Rows[0]["ShSh"] = tmpPerson.ShSh;
                    //pDt.Rows[0]["ShMeli"] = tmpPerson.ShMeli;
                    //pDt.Rows[0]["FatherName"] = tmpPerson.FatherName;
                    //pDt.Rows[0]["Name"] = tmpPerson.Name;
                    //pDt.Rows[0]["Fam"] = tmpPerson.Fam;
                    //if (dtPerson.Rows.Count > 0)
                    //    pDt.Rows[0]["BthDatePlace"] = dtPerson.Rows[0]["Birthplace"].ToString();

                }

                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        string txtDuration = "";
        private void SetDuration()
        {
            if (ContractForms.Contract.StartDate != DateTime.MinValue && ContractForms.Contract.EndDate != DateTime.MinValue)
            {

                TimeSpan TS = ContractForms.Contract.EndDate - ContractForms.Contract.StartDate;

                int M = Convert.ToInt32(Math.Round(TS.Days / 30.0));
                if ((M == 0) && (ContractForms.Contract.EndDate.Year > ContractForms.Contract.StartDate.Year))
                    M = 11 * (ContractForms.Contract.EndDate.Year - ContractForms.Contract.StartDate.Year);
                int D = 0;
                int D1 = Convert.ToInt32(JDateTime.FarsiDate(ContractForms.Contract.StartDate).Substring(8, 2));
                int D2 = Convert.ToInt32(JDateTime.FarsiDate(ContractForms.Contract.EndDate).Substring(8, 2));
                int M2 = Convert.ToInt32(JDateTime.FarsiDate(ContractForms.Contract.EndDate).Substring(5, 2));

                if (D2 < D1)
                {
                    M--;
                    string M1 = JDateTime.FarsiDate(ContractForms.Contract.StartDate).Substring(5, 2);
                    if (Convert.ToInt32(M1) < 7)
                        D1 = 31 - D1;
                    else
                        D1 = 30 - D1;
                    D = D1 + D2 + 1;
                }
                else if (D2 > D1)
                {
                    D = D2 - D1 + 1;
                    //string M1 = JDateTime.FarsiDate(ContractForms.Contract.StartDate).Substring(5, 2);
                    //if(Convert.ToInt32(M1) < 7)
                    //    D = 31 - ContractForms.Contract.EndDate.Day + ContractForms.Contract.StartDate.Day;
                    //else
                    //    D = 30 - ContractForms.Contract.EndDate.Day + ContractForms.Contract.StartDate.Day;
                }
                if ((M2 == 12) && (D == 29))
                {
                    //M++;
                    D = 0;
                }
                else if ((M2 > 6)&&(D >= 30))
                {
                    //M++;
                    D = 0;
                }
                else if ((M2 <= 6) && (D == 31))
                {
                    //M++;
                    D = 0;
                }

                if (M > 0)
                    txtDuration = M + " ماه ";
                if (D > 0)
                    txtDuration = txtDuration + D + " روز ";
                //txtDuration = ((TS.Days + 1) / 30).ToString() + " ماه ";
                //int D = 0;
                //if ((7 - ContractForms.Contract.StartDate.Month) > 0)
                //    if ((ContractForms.Contract.EndDate.Month) > 6)
                //        D = 7 - ContractForms.Contract.StartDate.Month;
                //    else
                //        D = ContractForms.Contract.EndDate.Month - ContractForms.Contract.StartDate.Month - 1;
                //if (D < 0)
                //    D = 0;
                //if (((TS.Days + 1) % 31) != 0)
                //    txtDuration = txtDuration + ((TS.Days + 1) % 30 + D).ToString() + " روز ";
            }
        }

        public void SetData()
        {
            #region CheckData

            if (txtconstSallary.Text == "")
                txtconstSallary.Text = "0";
            if (txtmaskanRight.Text == "")
                txtmaskanRight.Text = "0";
            if (txtkharobarRight.Text == "")
                txtkharobarRight.Text = "0";
            if (txtchildRight.Text == "")
                txtchildRight.Text = "0";
            if (txtchildRight.Text == "")
                txtchildRight.Text = "0";
            if (txtworkPlaceCondition.Text == "")
                txtworkPlaceCondition.Text = "0";
            if (txtperformanceRight.Text == "")
                txtperformanceRight.Text = "0";
            if (txtshiftRight.Text == "")
                txtshiftRight.Text = "0";
            if (txtbonRight.Text == "")
                txtbonRight.Text = "0";
            if (txtcashDec.Text == "")
                txtcashDec.Text = "0";
            if (txtsarparastyRight.Text == "")
                txtsarparastyRight.Text = "0";
            if (txtsanavatBase.Text == "")
                txtsanavatBase.Text = "0";
            if (txtotherRight.Text == "")
                txtotherRight.Text = "0";
            if (txtjazbRight.Text == "")
                txtjazbRight.Text = "0";
            if (txtmaz1.Text == "")
                txtmaz1.Text = "0";
            if (txtmaz2.Text == "")
                txtmaz2.Text = "0";
            if (txtmaz3.Text == "")
                txtmaz3.Text = "0";
            if (txtRotbeRight.Text == "")
                txtRotbeRight.Text = "0";
            if (txtSakhtiKarRight.Text == "")
                txtSakhtiKarRight.Text = "0";
            if (txtJebheRight.Text == "")
                txtJebheRight.Text = "0";
            if (txtMilitryRight.Text == "")
                txtMilitryRight.Text = "0";
            if (txtTafavot.Text == "")
                txtTafavot.Text = "0";
            if (txtFoghAlade.Text == "")
                txtFoghAlade.Text = "0";
            #endregion
        }
        public override bool Save(JDataBase tempdb)
        {
            tempState = State;
            try
            {
                SetData();
                Employment.JContractEmployee tmpJContractEmployeeTable = new JContractEmployee();
                tmpJContractEmployeeTable.workKind = Convert.ToInt32(cmbActiveType.SelectedValue);
                tmpJContractEmployeeTable.workPlace = Convert.ToInt32(cmbworkPlace.SelectedValue);
                tmpJContractEmployeeTable.workTime = Convert.ToInt32(cmbWorkingTime.SelectedValue);
                tmpJContractEmployeeTable.constSallary = Convert.ToDecimal(txtconstSallary.Text);
                tmpJContractEmployeeTable.maskanRight = Convert.ToDecimal(txtmaskanRight.Text);
                tmpJContractEmployeeTable.kharobarRight = Convert.ToDecimal(txtkharobarRight.Text);
                tmpJContractEmployeeTable.childRight = Convert.ToDecimal(txtchildRight.Text);
                tmpJContractEmployeeTable.workPlaceCondition = Convert.ToDecimal(txtworkPlaceCondition.Text);
                tmpJContractEmployeeTable.performanceRight = Convert.ToDecimal(txtperformanceRight.Text);
                tmpJContractEmployeeTable.shiftRight = Convert.ToDecimal(txtshiftRight.Text);
                tmpJContractEmployeeTable.bonRight = Convert.ToDecimal(txtbonRight.Text);

                if (tmpJContractEmployeeTable.id_employee == 0)
                {
                    Employment.JEmployeeInfo Emp = new JEmployeeInfo();
                    Emp.Find(" pCode=" + _PCode);
                    tmpJContractEmployeeTable.id_employee = Emp.Code;
                }
                if (tmpJContractEmployeeTable.id_employee == 0)
                    return false;
                //tmpJContractEmployeeTable.id_employee = _PCode;
                tmpJContractEmployeeTable.protocolKind = Convert.ToInt32(cmbContractEmpType.SelectedValue);
                tmpJContractEmployeeTable.ContractCode = ContractForms.Contract.Code;
                tmpJContractEmployeeTable.cashDec = Convert.ToDecimal(txtcashDec.Text);
                if (chkTest.Checked)
                    tmpJContractEmployeeTable.Test = true;
                else
                    tmpJContractEmployeeTable.Test = false;
                tmpJContractEmployeeTable.sarparastyRight = Convert.ToDecimal(txtsarparastyRight.Text);
                tmpJContractEmployeeTable.sanavatBase = Convert.ToDecimal(txtsanavatBase.Text);
                tmpJContractEmployeeTable.otherRight = Convert.ToDecimal(txtotherRight.Text);
                tmpJContractEmployeeTable.jazbRight = Convert.ToDecimal(txtjazbRight.Text);
                tmpJContractEmployeeTable.maz1 = Convert.ToDecimal(txtmaz1.Text);
                tmpJContractEmployeeTable.maz2 = Convert.ToDecimal(txtmaz2.Text);
                tmpJContractEmployeeTable.maz3 = Convert.ToDecimal(txtmaz3.Text);
                tmpJContractEmployeeTable.mazTitle1 = txtmazTitle1.Text;
                tmpJContractEmployeeTable.mazTitle2 = txtmazTitle2.Text;
                tmpJContractEmployeeTable.mazTitle3 = txtmazTitle3.Text;
                tmpJContractEmployeeTable.CalcType = Convert.ToInt32(cmbCalcType.SelectedValue);

                tmpJContractEmployeeTable.RotbeRight = Convert.ToDecimal(txtRotbeRight.Text);
                tmpJContractEmployeeTable.SakhtiKarRight = Convert.ToDecimal(txtSakhtiKarRight.Text);
                tmpJContractEmployeeTable.JebheRight = Convert.ToDecimal(txtJebheRight.Text);
                tmpJContractEmployeeTable.MilitryRight = Convert.ToDecimal(txtMilitryRight.Text);
                tmpJContractEmployeeTable.Tafavot = Convert.ToDecimal(txtTafavot.Text);
                tmpJContractEmployeeTable.FoghAlade = Convert.ToDecimal(txtFoghAlade.Text);
                isSave = true;

                if (State == JStateContractForm.Update)
                {
                    tmpJContractEmployeeTable.Code = _Code;
                    if (tmpJContractEmployeeTable.Update(tempdb))
                        return true;
                }
                else
                {
                    if ((ContractForms.Contract.PreContract != 0))
                    {
                        JSubjectContract tmp = new JSubjectContract(ContractForms.Contract.PreContract);
                        tmp.Status = JContractStatus.Expired;
                        if (!(tmp.Update(tempdb)))
                            return false;
                    }
                    if (tmpJContractEmployeeTable.Insert(tempdb) > 0)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        #endregion

        #region Events

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                    if (ApplyData())
                        ContractForms.NextForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                ContractForms.BackForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }
        #endregion

        private void Fill_Data()
        {
            JActivityTypes ActivityType = new JActivityTypes();
            ActivityType.SetComboBox(cmbActiveType, -1);

            JWorkTimeTypes WorkTimeType = new JWorkTimeTypes();
            WorkTimeType.SetComboBox(cmbWorkingTime, -1);

            JContractEmployeeTypes ContractEmployeeType = new JContractEmployeeTypes();
            ContractEmployeeType.SetComboBox(cmbContractEmpType, -1);

            JCalcTypes CalcType = new JCalcTypes();
            CalcType.SetComboBox(cmbCalcType, -1);

            JWorkPlaceTypes WorkPlaceType = new JWorkPlaceTypes();
            WorkPlaceType.SetComboBox(cmbworkPlace, -1);
            if (ContractForms.Contract.Code > 0)
                Set_Form();
        }

        int _FinanceCode = 0;
        private void JContractTarefeForm_VisibleChanged(object sender, EventArgs e)
        {
            txtdateStart.Date = ContractForms.Contract.StartDate;
            txtdateEnd.Date = ContractForms.Contract.EndDate;

            if ((ContractForms.B != null) && (ContractForms.B[0].FormName == this.Name)) //"JContractEmployeeForm")
            {
                if (ContractForms.B[0].PrpertyName == "PCode")
                    _PCode = Convert.ToInt32(ContractForms.B[0].Value);
            }
            if ((ContractForms.Contract.T2Person != null) && (ContractForms.Contract.T2Person.Rows.Count > 0))
                _PCode = Convert.ToInt32(ContractForms.Contract.T2Person.Rows[0]["PersonCode"]);

            if (!Visible) return;
            Fill_Data();
        }

        private void JContractEmployeeForm_Load(object sender, EventArgs e)
        {
        }

        private void JContractEmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        private void txtconstSallary_TextChanged(object sender, EventArgs e)
        {
            decimal sum = 0;
            sum = txtbonRight.MoneyValue + txtchildRight.MoneyValue +
                txtconstSallary.MoneyValue + txtjazbRight.MoneyValue +
                txtkharobarRight.MoneyValue + txtmaskanRight.MoneyValue +
                txtmaz1.MoneyValue + txtmaz2.MoneyValue +
                txtmaz3.MoneyValue + txtotherRight.MoneyValue +
                txtperformanceRight.MoneyValue + txtsanavatBase.MoneyValue +
                txtsarparastyRight.MoneyValue + txtshiftRight.MoneyValue +
               txtworkPlaceCondition.MoneyValue + txtTafavot.MoneyValue +
               txtRotbeRight.MoneyValue + txtcashDec.MoneyValue +
               txtSakhtiKarRight.MoneyValue + txtJebheRight.MoneyValue +
               txtMilitryRight.MoneyValue + txtFoghAlade.MoneyValue;

            lblTotal.Text = JMoney.StringToMoney(Math.Round(sum, 0).ToString());
        }

        private void txtCountChild_TextChanged(object sender, EventArgs e)
        {
            //if (txtCountChild.IntValue > 2)
            //    txtchildRight.Text = (2 * 389700).ToString();
            //else
            //    txtchildRight.Text = (txtCountChild.IntValue * 389700).ToString();
        }

        private void txtconstSallaryCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtconstSallaryCalc.Text != "0") && (txtconstSallaryCalc.Text != ""))
                txtconstSallary.Text = JMoney.StringToMoney((Convert.ToDecimal(txtconstSallaryCalc.Text) * 30).ToString());
        }

        private void txtsanavatBaseCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtsanavatBaseCalc.Text != ""))//(txtsanavatBaseCalc.Text != "0") &&
                txtsanavatBase.Text = JMoney.StringToMoney((Convert.ToDecimal(txtsanavatBaseCalc.Text) * 30).ToString());
        }

        private void txtsarparastyRightCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtsarparastyRightCalc.Text != ""))//(txtsarparastyRightCalc.Text != "0") &&
                txtsarparastyRight.Text = JMoney.StringToMoney((Convert.ToDecimal(txtsarparastyRightCalc.Text) * 30).ToString());
        }

        private void txtRotbeRightCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtRotbeRightCalc.Text != ""))//(txtRotbeRightCalc.Text != "0") &&
                txtRotbeRight.Text = JMoney.StringToMoney((Convert.ToDecimal(txtRotbeRightCalc.Text) * 30).ToString());
        }

        private void txtJebheRightCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtJebheRightCalc.Text != ""))//(txtJebheRightCalc.Text != "0") &&
                txtJebheRight.Text = JMoney.StringToMoney((Convert.ToDecimal(txtJebheRightCalc.Text) * 30).ToString());
        }

        private void txtMilitryRightCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtMilitryRightCalc.Text != ""))//(txtMilitryRightCalc.Text != "0") &&
                txtMilitryRight.Text = JMoney.StringToMoney((Convert.ToDecimal(txtMilitryRightCalc.Text) * 30).ToString());
        }

        private void txtFoghAladeCalc_TextChanged(object sender, EventArgs e)
        {
            if ((txtFoghAladeCalc.Text != ""))//(txtFoghAladeCalc.Text != "0") &&
                txtFoghAlade.Text = JMoney.StringToMoney((Convert.ToDecimal(txtFoghAladeCalc.Text) * 30).ToString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Set_Form();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            SetDuration();
            try
            {
                if (cmbCalcType.SelectedValue.ToString() != "System.Data.DataRowView")
                    if (cmbCalcType.SelectedValue != null)
                    {
                        DataTable dtFormula = Employment.JFormula.ExecFormula(Convert.ToInt32(cmbCalcType.SelectedValue), ContractForms.Contract.Code, 0);
                        foreach (DataRow dr in dtFormula.Rows)
                        {

                            Db.setQuery(@" select " + dr["sql"] + @" from  EmpEmployee 
     inner join EmpJobTitle on EmpEmployee.JobTitleCode=EmpJobTitle.Code
     inner join EmpPersonnelContract on EmpPersonnelContract.id_employee=EmpEmployee.Code where ContractCode= " + ContractForms.Contract.Code);
                            decimal Result = (decimal)Db.Query_ExecutSacler();
                            Result = Math.Round(Result, 0);
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "constSallary".ToLower()) == 0)
                                txtconstSallary.Text = JMoney.StringToMoney(Result.ToString());// dr["Result"].ToString();
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "maskanRight".ToLower()) == 0)
                                txtmaskanRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "kharobarRight".ToLower()) == 0)
                                txtkharobarRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "childRight".ToLower()) == 0)
                                txtchildRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "workPlaceCondition".ToLower()) == 0)
                                txtworkPlaceCondition.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "performanceRight".ToLower()) == 0)
                                txtperformanceRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "shiftRight".ToLower()) == 0)
                                txtshiftRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "bonRight".ToLower()) == 0)
                                txtbonRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "cashDec".ToLower()) == 0)
                                txtcashDec.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "sarparastyRight".ToLower()) == 0)
                                txtsarparastyRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "sanavatBase".ToLower()) == 0)
                                txtsanavatBase.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "otherRight".ToLower()) == 0)
                                txtotherRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "jazbRight".ToLower()) == 0)
                                txtjazbRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "maz1".ToLower()) == 0)
                                txtmaz1.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "maz2".ToLower()) == 0)
                                txtmaz2.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "maz3".ToLower()) == 0)
                                txtmaz3.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "mazTitle1".ToLower()) == 0)
                                txtmazTitle1.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "mazTitle2".ToLower()) == 0)
                                txtmazTitle2.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "mazTitle3".ToLower()) == 0)
                                txtmazTitle3.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "RotbeRight".ToLower()) == 0)
                                txtRotbeRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "SakhtiKarRight".ToLower()) == 0)
                                txtSakhtiKarRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "JebheRight".ToLower()) == 0)
                                txtJebheRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "MilitryRight".ToLower()) == 0)
                                txtMilitryRight.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "Tafavot".ToLower()) == 0)
                                txtTafavot.Text = JMoney.StringToMoney(Result.ToString());
                            if (String.Compare(dr["FeildName"].ToString().ToLower(), "FoghAlade".ToLower()) == 0)
                                txtFoghAlade.Text = JMoney.StringToMoney(Result.ToString());
                        }
                    }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}
