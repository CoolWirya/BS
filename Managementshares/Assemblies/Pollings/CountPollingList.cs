using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JCountPollingList : JBaseForm
    {
        int _PollingCountCode;
        int _AssemblyCode;
		int _CompanyCode;
        public JCountPollingList(int PollingCode, int assempbyCode, int pCompanyCode)
        {
            InitializeComponent();
			_CompanyCode = pCompanyCode;
            _PollingCountCode = PollingCode;
            _AssemblyCode = assempbyCode;
            LoadData();
        }
        public void LoadData()
        {
            JCountPollings pollings = new JCountPollings(_PollingCountCode,_CompanyCode);
            grdCountedList.DataSource = pollings.GetCountedVotes();
            grdResult.DataSource = pollings.GetPollingResult();

            JAssemblyPresences presenceInfo = new JAssemblyPresences(_AssemblyCode,_CompanyCode);
            int numberOfExisting = presenceInfo.GetNumberOfExistingRights();
            lbPresence.Text = numberOfExisting.ToString();
            int countedVotes = pollings.GetCountedSum();
            lbCounted.Text = countedVotes.ToString();

            if (numberOfExisting < countedVotes)
                lbError.Visible = true;
            else
                lbError.Visible = false;

            #region initial grids
            grdCountedList.Columns["Code"].Visible = false;
            grdCountedList.Columns["PollingCode"].Visible = false;
            grdResult.ShowNavigator = false;
            grdCountedList.ShowNavigator = false;
            grdResult.ShowToolbar = false;
            grdCountedList.ShowToolbar = false;
            grdCountedList.gridEX1.GroupByBoxVisible = false;
            grdResult.gridEX1.GroupByBoxVisible = false;
            grdResult.Columns["Title"].Width = 300;
            grdResult.Columns["Rowno"].Width = 60;
            #endregion initial grids
        }
        private void btnNewVote_Click(object sender, EventArgs e)
        {
            JCountPollingForm form = new JCountPollingForm(_PollingCountCode, _AssemblyCode,_CompanyCode);
            if (form.ShowDialog() == DialogResult.Retry)
            {
                form.Dispose();
                if (chAutoUpdate.Checked)
                    LoadData();
                btnNewVote.PerformClick();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (grdCountedList.SelectedRow != null)
            {
                int code = Convert.ToInt32(grdCountedList.SelectedRow["Code"]);                
                JCountPollingForm form = new JCountPollingForm(code,_CompanyCode,"");
                form._AssemblyCode = _AssemblyCode;
                form.State = JFormState.Update;
                form.ShowDialog();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdCountedList.SelectedRow != null)
            {
                if (JMessages.Question("آیا میخواهید برگه انتخاب شده حذف شود؟", "") == DialogResult.Yes)
                {
                    int code = Convert.ToInt32(grdCountedList.SelectedRow["Code"]);
                    JCountPolling countPolling = new JCountPolling(code,_CompanyCode);
                    if (countPolling.Delete())
                        LoadData();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
        {
            JCountPollings pollingCount = new JCountPollings(_PollingCountCode,_CompanyCode);
            DataTable resultTable = pollingCount.GetPollingResult();
            JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Sheet.GetHashCode());
            DRF.Add(resultTable);
            DataTable dt = grdCountedList.DataSource;
            dt.TableName = "Vote";
            DRF.Add(dt);
            DataTable dtChoice = grdCountedList.DataSource;
            dtChoice.TableName = "Choice";
            DRF.Add(dtChoice);
            DRF.ShowDialog();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
            if (grdCountedList.SelectedRow != null)
            {
                int code = Convert.ToInt32(grdCountedList.SelectedRow["Code"]);
                JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Sheet.GetHashCode());
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Vote");
                dt.Rows.Add(grdCountedList.SelectedRow["Name"], grdCountedList.SelectedRow["RightCount"]);
                dt.TableName = "Vote";
                DRF.Add(dt);
                JCountPolling count = new JCountPolling(code,_CompanyCode);
                DataTable dtChoice = count.GetSelectedChoice();
                dtChoice.TableName = "Choice";
                DRF.Add(dtChoice);

                DB.setQuery(@"select 
ShareAssemblyPollingCountChoice.PollingCountCode,
 ShareAssemblyPollingCountChoice.ChoiceCode SelectedCode,
                        ISNULL( clsAllPerson.Name, ShareAssemblyPollingCandida.Title) Title from ShareAssemblyPollingCountChoice 
	                    Inner Join ShareAssemblyPollingCandida ON ShareAssemblyPollingCandida.Code = ShareAssemblyPollingCountChoice .ChoiceCode
	                    Left Join clsAllPerson ON ShareAssemblyPollingCandida.PCode = clsAllperson.Code 
WHERE [PollingCode] =" + _PollingCountCode);

                DataTable dtChoiceDetail = DB.Query_DataTable();
                dtChoiceDetail.TableName = "ChoiceDetail";
                DRF.Add(dtChoiceDetail);

                //C inner join ShareAssemblyPollingCountChoice CC on C.Code=CC.PollingCountCode
                DB.setQuery(@"select * FROM ShareAssemblyPollingCount 
                WHERE [PollingCode] =" + _PollingCountCode);
                DataTable dtKol = DB.Query_DataTable();
                dtKol.TableName = "Koli";
                DRF.Add(dtKol);

                DRF.ShowDialog();                
            }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
         
    }
}
