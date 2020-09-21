using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ShareProfit
{
	public partial class ShareProfitReportForm : JBaseForm
	{
        public static string SQLSheet = string.Format(@"
select * from
(
select S.Code,(select Name from clsAllPerson where code=(select sc.PCode from ShareCompany sc where code= C.CompanyCode)) CompanyName,S.CompanyCode
,C.title,MIN(S.Az) AZ,MAX(S.Ela) Ela,S.ShareCount,C.cost,C.cost * S.ShareCount AllCost,(select SharePCode from SharePCodeSheet SPS where CompanyCode=S.CompanyCode and SPS.PersonCode=S.pcode) SharePCode,S.pCode,(select name from clsallperson cp where cp.code = s.pcode ) name,S.coursecode,
(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate
,(select isnull(sum(ShareCount),0) from ShareSheet where PCode=S.PCode and CompanyCode=S.CompanyCode and Status=1) ShareCountNow
from SahamSheet S
inner join sahamcourse C ON C.Code=S.coursecode 
group by S.Code,S.pCode,S.coursecode,s.CompanyCode,S.ShareCount,C.cost,C.CompanyCode,c.title
) s where 1=1");


        public ShareProfitReportForm()
		{
			InitializeComponent();
            _FillComboBox();

        }
        private void _FillComboBox()
        {
            cmbCompany.DataSource = ManagementShares.JShareCompanies.GetDataTable();
            cmbCompany.ValueMember = "Code";
            cmbCompany.DisplayMember = "Name";
        }
        private void btnSearch_Click(object sender, EventArgs e)
		{
            JDataBase db = new JDataBase();
            try
            {
                {
                    string SCompany = " 1=1 ";
                    if (cmbCompany.SelectedValue != null)
                        SCompany += " and s.CompanyCode = " + cmbCompany.SelectedValue.ToString();
                    string SCourse = " 1=1 ";
                    if (cmbCourse.SelectedValue != null)
                        SCourse += " and s.coursecode = " + cmbCourse.SelectedValue.ToString();

                    db.setQuery(SQLSheet + " and " + SCompany + " and " + SCourse);
                    grdReport.DataSource = db.Query_DataTable();
                }
            }
            catch
            {

            }
            finally
            {
                db.Dispose();

            }
			
		}

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCourse.DataSource = JCourses.GetCompanyDataTable((int)cmbCompany.SelectedValue);
                cmbCourse.ValueMember = "Code";
                cmbCourse.DisplayMember = "Title";
                cmbCourse.SelectedValue = 1;
            }
            catch
            {

            }
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string S1 = @"
select name,Fam,FatherName,ShSh,ShMeli from clsPerson where code=%Pcode%
";

            string S2 = @"
select S.Code,(select Name from clsAllPerson where code=(select sc.PCode from ShareCompany sc where code= C.CompanyCode)) CompanyName
,C.title,MIN(S.Az) AZ,MAX(S.Ela) Ela,S.ShareCount,C.cost,C.cost * S.ShareCount Cost,(select SharePCode from SharePCodeSheet SPS where CompanyCode=S.CompanyCode and SPS.PersonCode=S.pcode) SharePCode,S.pCode,(select name from clsallperson cp where cp.code = s.pcode ) name,S.coursecode,
(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate
,(select isnull(sum(ShareCount),0) from ShareSheet where PCode=S.PCode and CompanyCode=S.CompanyCode and Status=1) ShareCountNow
from SahamSheet S
inner join sahamcourse C ON C.Code=S.coursecode 
where s.pcode=%Pcode%
group by S.Code,S.pCode,S.coursecode,s.CompanyCode,S.ShareCount,C.cost,C.CompanyCode,c.title
order by C.title
";
            string S3 = @"
select Sheetno,(select Name from clsAllPerson where code=(select sc.PCode from ShareCompany sc where code= C.CompanyCode)) CompanyName
,C.title,MIN(S.Az) AZ,MAX(S.Ela) Ela,S.ShareCount,C.cost,C.cost * S.ShareCount Cost,doccode,(select SharePCode from SharePCodeSheet SPS where CompanyCode=S.CompanyCode and SPS.PersonCode=SP.pcode) SharePCode,SP.pCode,(select name from clsallperson cp where cp.code = sp.pcode ) name,sum(paycost) paycost,paydate,paydesc,regname,SP.coursecode,
(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate
,sp.Bankname,sp.HesabNumber,sp.Description
from sahampayment sp
inner join SahamSheet S on SP.sheetno=S.Code
inner join sahamcourse C ON C.Code=sp.coursecode 
where sp.pcode=%Pcode%
group by Sheetno,SP.pCode,paydate,paydesc,regname,SP.coursecode,doccode,sp.Bankname,sp.HesabNumber,sp.Description,s.CompanyCode,S.ShareCount,C.cost,C.CompanyCode,c.title
order by paydate
";
            int PCode = 0;
            if (grdReport.SelectedRow!= null)
            {
                int.TryParse(grdReport.SelectedRow["pCode"].ToString(), out PCode);
            }
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(S1.Replace("%Pcode%", PCode.ToString()));
                DataTable DT1 = DB.Query_DataTable();
                DT1.TableName = "شخص";
                DB.setQuery(S2.Replace("%Pcode%", PCode.ToString()));
                DataTable DT2 = DB.Query_DataTable();
                DT2.TableName = "سهام";
                DB.setQuery(S3.Replace("%Pcode%", PCode.ToString()));
                DataTable DT3 = DB.Query_DataTable();
                DT3.TableName = "پرداخت";

                ClassLibrary.JDynamicReportForm DF = new JDynamicReportForm("ShareProfit.ShareProfitReportForm.Print".GetHashCode());
                DF.DataTables = new DataTable[] { DT1, DT2, DT3 };
                DF.ShowDialog();

            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
