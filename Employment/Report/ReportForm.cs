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
    public partial class JReportForm : JBaseForm
    {
        int _CompanyCode;

        public JReportForm(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode = pCompanyCode;
        }

        string Where = " ";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Where = " ";
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void JReportForm_Load(object sender, EventArgs e)
        {
            txtEndDate.Date = DateTime.Now;
            txtEndDate1.Date = DateTime.Now.AddDays(20);

            txtDateExpire.Date = DateTime.Now;
            txtDateExpire1.Date = DateTime.Now.AddDays(10);

            //پرکردن کمبو فعالیت
            JActivityTypes JAc = new JActivityTypes();
            JAc.SetComboBox(cmbActivity, -1);

            //chkFamRelation.DisplayMember = "FarsiName";
            //chkFamRelation.ValueMember = "value";
            //chkFamRelation.DataSource = ClassLibrary.Domains.JGlobal.JFamily.GetData();

            DataTable _dtCreator = ClassLibrary.Domains.JGlobal.JFamily.GetData();
            JKeyValue[] L = new JKeyValue[_dtCreator.Rows.Count];
            int count = 0;
            foreach (DataRow dr in _dtCreator.Rows)
            {
                L[count] = new JKeyValue();
                L[count].Key = dr["FarsiName"].ToString();
                L[count].Value = dr["value"];
                count++;
            }
            chkFamRelation.Items.AddRange(L);


            tabControl1_SelectedIndexChanged(null, null);
            //Where = Where + " And [Status]=2 ";
            //jdgvMonfaselin.DataSource = JEContract.Search(Where);
            jdgvMonfaselin.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Where = " ";
            if (tabControl1.SelectedTab == tbExpireChild)
            {
                if (rbActive.Checked)
                    Where = Where + " And id_employee in (select Code from EmpEmployee where Active=1 And CompanyCode= " + _CompanyCode + ")";
                else
                    Where = Where + " And id_employee in (select Code from EmpEmployee where Active=0 And CompanyCode= " + _CompanyCode + ")";

                if (txtEndDate.Date != DateTime.MinValue)
                    Where = Where + " And ExpireDate >= '" + txtEndDate.Date.ToString("yyyy/MM/dd") + "'";
                if (txtEndDate1.Date != DateTime.MinValue)
                    Where = Where + " And ExpireDate <= '" + txtEndDate1.Date.ToString("yyyy/MM/dd") + "'";
                jdgvExpireChild.DataSource = JEContract.SearchExpireChild(Where, _CompanyCode);
            }
            if (tabControl1.SelectedTab == tnMonfaselin)
            {
                if (rbActive.Checked)
                    Where = Where + " And S.Status=1 And (select Active from EmpEmployee where pCode=PC.PersonCode And CompanyCode= " + _CompanyCode + ") = 1 ";
                else
                    Where = Where + " And S.Status<>1 And (select Active from EmpEmployee where pCode=PC.PersonCode And CompanyCode= " + _CompanyCode + ") = 0 ";

                if (txtStartDate.Date != DateTime.MinValue)
                    Where = Where + " And StartDate >= '" + txtStartDate.Date.ToString("yyyy/MM/dd") + "'";
                if (txtStartDate1.Date != DateTime.MinValue)
                    Where = Where + " And StartDate <= '" + txtStartDate1.Date.ToString("yyyy/MM/dd") + "'";
                if (txtEndDate.Date != DateTime.MinValue)
                    Where = Where + " And EndDate >= '" + txtEndDate.Date.ToString("yyyy/MM/dd") + "'";
                else
                    Where = Where + " And  DATEDIFF(DAY, cast(EndDate as date),cast(GETDATE() as Date)) between 1 and 15";

                if (txtEndDate1.Date != DateTime.MinValue)
                    Where = Where + " And EndDate <= '" + txtEndDate1.Date.ToString("yyyy/MM/dd") + "'";
                jdgvMonfaselin.DataSource = JEContract.Search(Where);
            }
            if (tabControl1.SelectedTab == tbFamily)
            {
                if (chkFamRelation.CheckedItems.Count > 0)
                {
                    if (rbActive.Checked)
                        Where = Where + " And EmpEmployee.Code in (select Code from EmpEmployee where Active=1 And CompanyCode= " + _CompanyCode + ")";
                    else
                        Where = Where + " And EmpEmployee.Code in (select Code from EmpEmployee where Active=0 And CompanyCode= " + _CompanyCode + ")";

                    string CodeGH = "";
                    for (int i = 0; i < chkFamRelation.Items.Count; i++)
                        if (chkFamRelation.GetItemChecked(i))
                            if (((ClassLibrary.JKeyValue)(chkFamRelation.Items[i])).Value.ToString() != "-1")
                                CodeGH = CodeGH + ((ClassLibrary.JKeyValue)(chkFamRelation.Items[i])).Value.ToString() + ",";
                    if (CodeGH != "")
                        Where = Where + " And Fam.NesbatType in (" + CodeGH + "0)";
                }
                if (Convert.ToInt32(Convert.ToInt32(cmbActivity.SelectedValue)) != -1)
                    Where = Where + " And Activity = " + Convert.ToInt32(cmbActivity.SelectedValue);
                jdgvFamily.DataSource = JEContract.SearchFamily(Where);
            }
            if ((tabControl1.SelectedTab == tbChild) || (tabControl1.SelectedTab == tbSanavat))
            {
                if (rbActive.Checked)
                    Where = Where + " And Code in (select Code from EmpEmployee where Active=1 And CompanyCode= " + _CompanyCode + ")";
                else
                    Where = Where + " And Code in (select Code from EmpEmployee where Active=0 And CompanyCode= " + _CompanyCode + ")";

                if (DateEmployeeStart.Date != DateTime.MinValue)
                    Where = Where + " And EmployeeDate >= '" + DateEmployeeStart.Date.ToString("yyyy/MM/dd") + "'";
                else
                {
                    if (tabControl1.SelectedTab == tbChild)
                        Where = Where + " And  DATEDIFF(DAY, cast(EmployeeDate as date),cast(GETDATE() as Date)) between 730 and 745";
                    else
                        Where = Where + " And DATEDIFF(DAY, cast(EmployeeDate as date),cast(GETDATE() as Date)) between 366 and 380";
                }
                if (DateEmployeeEnd.Date != DateTime.MinValue)
                    Where = Where + " And EmployeeDate <= '" + DateEmployeeEnd.Date.ToString("yyyy/MM/dd") + "'";
                if (tabControl1.SelectedTab == tbChild)
                    jdgvChildRight.DataSource = JEmployeeInfos.GetDataTable(0, Where);
                else
                    jdgvSanavat.DataSource = JEmployeeInfos.GetDataTable(0, Where);
            }
        }
    }
}
