using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ClassLibrary;
using ManagementShares;

namespace ShareProfit
{
	public partial class JPaymentForm : JBaseForm
	{

		private int CourseCode;
		private int DocCode;
		private int pSheetNo;
		private int pCompanyCode;
		private DataTable psharesheet, pPeyment, PProperty;
		public JPaymentForm(int pCourseCode)
		{
			InitializeComponent();
            return;
			CourseCode = pCourseCode;
			jArchiveList1.ClassName = "ShareProfit.JPaymentForm";
			jPropertyValueUserControl1.ClassName = "ManagementShares.JCourseForm";
			jPropertyValueUserControl1.ObjectCode = CourseCode;
			
			

			JCourse C = new JCourse(CourseCode);
			LBCaptionCourse.Text = C.Title;

			dateEditPayDate.Date = DateTime.Now;
		}

		public JPaymentForm(int pCourseCode, int pDocCode, int pSheetNos, int pPCode)
		{
			InitializeComponent();
			CourseCode = pCourseCode;
			DocCode = pDocCode;
			pSheetNo = pSheetNos;
			jucPerson.txtExportCode.Text = pPCode.ToString();
			jucPerson_AfterCodeSelected(null, null);
			txtSheetNo_Leave(null, null);
			jDataGridSheets_SelectionChanged(null, null);
			//button1_Click(null,null);
			


			jArchiveList1.ClassName = "ShareProfit.JPaymentForm";
			jArchiveList1.ObjectCode = pDocCode;
			jPropertyValueUserControl1.ClassName = "ManagementShares.JCourseForm";
			jPropertyValueUserControl1.ObjectCode = CourseCode;
			jPropertyValueUserControl1.ValueObjectCode = pDocCode;

			

			btnSave.Enabled = false;
			txtSheetNo_OLD.Enabled = false;
			dateEditPayDate.Enabled = false;

			JCourse C = new JCourse(CourseCode);
			LBCaptionCourse.Text = C.Title;

		}

		private void LoadData()
		{
			JPayment P = new JPayment();
			DataTable DT = P.GetByDocCode(DocCode);
			txtSheetNo_OLD.Text = DT.Rows[0]["SheetNo"].ToString();
			if (DT.Rows[0]["PayDate"] != null)
				dateEditPayDate.Text = DT.Rows[0]["PayDate"].ToString();

			jDataGridPayment.DataSource = DT;
			for (int i = 0; i < jDataGridPayment.Columns.Count; i++)
			{
				jDataGridPayment.Columns[i].ReadOnly = true;
			}

		}

		private void txtSheetNo_Leave(object sender, EventArgs e)
		{
			if (jDataGridPayment.DataSource != null)
				(jDataGridPayment.DataSource as DataTable).Clear();
			jDataGridPayment.DataSource = null;
			try
			{
				int SheetCode=0;
				if(txtSheetNo_OLD.Text=="")
					SheetCode = pSheetNo;
				else
					SheetCode= Convert.ToInt32(txtSheetNo_OLD.Text);
				
					
				JShareSheet S = new JShareSheet(SheetCode);
				

				JCourse C = new JCourse(CourseCode);
				if (C.OnlinePayment && C.ShareCount != S.SharePeriodCount())
				{
					ClassLibrary.JMessages.Error("تعداد سهام موجود در سهام در شرکت در زمان پرداخت سود با تعداد سهام دوره این برگه سهم برابر نمیباشد", "خطا");
				}
				else
				{
					DataTable dt= JPayment.SelectPayDetails(S.Code, CourseCode, S.CompanyCode, C.SheetTable);
					jDataGridPayment.DataSource = dt;
					pPeyment = dt;
					for (int i = 0; i <= jDataGridPayment.Columns.Count; i++)
					{
						jDataGridPayment.Columns[i].ReadOnly = true;
					}
					//jDataGridPayment.Columns["remained"].ReadOnly = false;
					jDataGridPayment.Refresh();
				}
			}
			catch
			{
			}
			finally
			{
			}
		}

		
		
		private void btnSave_Click(object sender, EventArgs e)
		{

			if (dateEditPayDate.EmptyDate)
			{
				JMessages.Error("تاریخ پرداخت را دارد کنید", "خطا");
				return;
			}

			//int SheetCode = Convert.ToInt32(txtSheetNo_OLD.Text);

			int doccode = JPayment.GetMaxDocCode();
			DocCode = doccode;
			JPayment P = new JPayment();
			for (int i = 0; i < jDataGridPayment.Rows.Count; i++)
			{

				P.PayDate = dateEditPayDate.Text;
				P.PCode = jucPerson.SelectedCode;
				P.SheetNo = Convert.ToInt32((jDataGridPayment.DataSource as DataTable).Rows[i]["SheetCode"].ToString());
				P.CourseCode = CourseCode;
				P.DocCode = doccode;
				P.erpPCode = 0;
				P.ManagementsharesNo = Convert.ToInt32((jDataGridPayment.DataSource as DataTable).Rows[i]["Code"].ToString());
				P.PayCost = Convert.ToInt32((jDataGridPayment.DataSource as DataTable).Rows[i]["PeymentNow"].ToString());
				P.PayCount = 0;
				P.PayDesc = (jDataGridPayment.DataSource as DataTable).Rows[i]["Description"].ToString();
				P.RegName = JMainFrame.CurrentPostTitle;
				if (P.PayCost > 0)
				{
					try
					{	
						int Code = P.insert();
						jArchiveList1.ObjectCode = Code;
						jArchiveList1.ArchiveList();
						jPropertyValueUserControl1.ValueObjectCode = P.DocCode;
						jPropertyValueUserControl1.Save();
					}
					catch
					{
						MessageBox.Show("عملیات با خطا مواجه شد");
					}
				}

			
				
				//JCourse C = new JCourse(CourseCode);
				//DataTable dtPayment = JPayment.PayDetailsPerson(jucPerson.txtExportCode.IntValue, CourseCode);
				//jDataGridPayment.DataSource = dtPayment;
				Close();

			}
			MessageBox.Show("ثبت با موفقیت انجام گردید");

		}

		private void jucPerson_AfterCodeSelected(object Sender, EventArgs e)
		{

          //if (jucPerson.txtExportCode.IntValue > 999)
	      //{
			    int code = jucPerson.SelectedCode;
				DataTable dt;

				if (code == null || code == 0)
				{
					dt = JPayment.PayDetailsPerson(jucPerson.txtExportCode.IntValue, CourseCode);
				}
				else
				{
					dt = JPayment.PayDetailsPerson(jucPerson.SelectedCode, CourseCode);
				}

				if (dt != null && dt.Rows.Count > 0)
				{
					ShareProfit.JCourse cource = new JCourse(CourseCode);
					if (cource.OnlinePayment == false)
					{
						if (code == null || code == 0)
						{
							DataTable dts= JShareSheets.GetPersonSheetOffline(jucPerson.txtExportCode.IntValue, CourseCode);
							jDataGridSheets.DataSource = dts;
							psharesheet = dts;
						}
						else 
						{
							jDataGridSheets.DataSource = JShareSheets.GetPersonSheetOffline(jucPerson.SelectedCode, CourseCode);
						}
					}
					else
					{
						if (code == null || code == 0)
						{
							jDataGridSheets.DataSource = JShareSheets.GetPersonSheet(jucPerson.txtExportCode.IntValue);
						}
						else
						{
							jDataGridSheets.DataSource = JShareSheets.GetPersonSheet(jucPerson.SelectedCode);
						}
					}

					txtkolsood.Text = dt.Rows[0]["Cost"].ToString();
					txtSoodDaryafti.Text = dt.Rows[0]["PayCost"].ToString();
		 //}
			}
		}

		private void jDataGridSheets_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (jDataGridSheets.Rows.Count < 1 || jDataGridSheets.CurrentRow == null)
					return;
				nudStartSheetNo.Minimum = decimal.Parse(jDataGridSheets.CurrentRow.Cells["az"].Value.ToString());
				nudStartSheetNo.Maximum = decimal.Parse(jDataGridSheets.CurrentRow.Cells["ela"].Value.ToString());
				nudEndSheetNo.Minimum = nudStartSheetNo.Minimum;
				nudEndSheetNo.Maximum = nudStartSheetNo.Maximum;
				nudStartSheetNo.Value = nudStartSheetNo.Minimum;
				nudEndSheetNo.Value = nudStartSheetNo.Maximum;
			}
			catch
			{
			}
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			if (jDataGridPayment.DataSource != null)
				(jDataGridPayment.DataSource as DataTable).Clear();
			jDataGridPayment.DataSource = null;
			try
			{
				JCourse C = new JCourse(CourseCode);
				JShareSheet S;
				if (C.OnlinePayment == false)
				{
					S = new JShareSheet((int)nudStartSheetNo.Value);
					JDataBase db = new JDataBase();
					int pSCode=0,pCourceCode=0;
					try
					{
						db.setQuery("  SELECT ss.* ,cp.Name,cp.Fam,cp.FatherName,cp.FatherName,cp.shsh,cp.ShMeli,sps.SharePCode " +
						  " From SahamSheet ss "+
						  " inner join clsPerson cp on cp.Code=ss.PCode "+
						  " inner join SharePCodeSheet sps on sps.PersonCode=cp.Code WHERE sps.CompanyCode=ss.CompanyCode and az >= " + nudStartSheetNo.Value.ToString() + " and ela <= " + nudEndSheetNo.Value.ToString() + " and CourseCode=" + CourseCode);
						DataTable dt =  db.Query_DataTable();
						psharesheet = dt;
						if (dt.Rows.Count > 0)
						{
							pSCode = Convert.ToInt32(dt.Rows[0]["Code"]);
							pCourceCode = Convert.ToInt32(dt.Rows[0]["CourseCode"]);
						}
					}
					catch
					{
					}
					finally
					{
						db.Dispose();
					}

					pSheetNo = pSCode;
					DataTable dtPayment = JPayment.SelectPayDetails(pSCode, pCourceCode, S.CompanyCode, C.SheetTable);
					pPeyment = dtPayment;
					jDataGridPayment.DataSource=dtPayment;
					

					
				}
				else
				{
					S = new JShareSheet((int)nudStartSheetNo.Value);
					if (C.OnlinePayment && C.ShareCount != S.SharePeriodCount())
					{
						ClassLibrary.JMessages.Error("تعداد سهام موجود در سهام در شرکت در زمان پرداخت سود با تعداد سهام دوره این برگه سهم برابر نمیباشد", "خطا");
						return;
					}
					DataTable dtPayment = JPayment.SelectPayDetails(S.Code, CourseCode, S.CompanyCode, C.SheetTable);
					pPeyment = dtPayment;
					for (decimal j = nudStartSheetNo.Value + 1; j <= nudEndSheetNo.Value; j++)
					{
						int SheetCode = (int)j;//Convert.ToInt32(txtSheetNo_OLD.Text);
						S = new JShareSheet(SheetCode);

						C = new JCourse(CourseCode);
						if (C.OnlinePayment && C.ShareCount != S.SharePeriodCount())
						{
							ClassLibrary.JMessages.Error("تعداد سهام موجود در سهام در شرکت در زمان پرداخت سود با تعداد سهام دوره این برگه سهم برابر نمیباشد", "خطا");
						}
						else
						{
							dtPayment = dtPayment.AsEnumerable().Union(JPayment.SelectPayDetails(S.Code, CourseCode, S.CompanyCode, C.SheetTable).AsEnumerable()).CopyToDataTable();
						}

					}
					jDataGridPayment.DataSource = dtPayment;
					for (int i = 0; i <= jDataGridPayment.Columns.Count; i++)
					{
						jDataGridPayment.Columns[i].ReadOnly = true;
					}
					//jDataGridPayment.Columns["remained"].ReadOnly = false;
					jDataGridPayment.Refresh();
				}
			}
			catch
			{
			}
			finally
			{
			}
		
		}

		private void jucPerson_Load(object sender, EventArgs e)
		{

		}

		private void JPaymentForm_Load(object sender, EventArgs e)
		{
			
		}

		private void BtnPrint_Click(object sender, EventArgs e)
		{
			PrintShareSheet();
		}

		public void PrintShareSheet()
		{
			try
			{
				JDynamicReportForm reportForm = new JDynamicReportForm(JReportDesignCodes.ShareProfit.GetHashCode());
				Globals.Property.JPropertyTables jpt=new Globals.Property.JPropertyTables("ManagementShares.JCourseForm",CourseCode);
				psharesheet.TableName = "ShareSheet";
				reportForm.Add(psharesheet);
				pPeyment.TableName = "pPeyment";
				reportForm.Add(pPeyment);
				DataTable DT = jpt.GetData(DocCode);
				DT.TableName = "PropPertie";
				reportForm.Add(DT);
				reportForm.ShowDialog();
			}
			catch
			{
				
			}
		}
	}
}
