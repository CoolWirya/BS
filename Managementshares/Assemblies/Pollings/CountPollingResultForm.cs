using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using ArchivedDocuments;

namespace ManagementShares
{
    public partial class JCountPollingResultForm : ClassLibrary.JBaseForm
    {
        int _AssemblyCode;
		int _CompanyCode;
        public JCountPollingResultForm(int pAssemblyCode,int pCompanyCode)
        {
            InitializeComponent();
			_CompanyCode = pCompanyCode;
            _AssemblyCode = pAssemblyCode;
            LoadData();
        }
        private void LoadData()
        {
            JPollings pollings = new JPollings (_AssemblyCode);
            DataTable pollingsTable  = pollings.GetData(0);
            lstPollings.Items.Clear();
            foreach (DataRow row in pollingsTable.Rows)
            {
                ListViewItem pollingItem =  new ListViewItem(row["Title"].ToString(), row["Code"].ToString());
                lstPollings.Items.Add(pollingItem);
            }
            //if (cmbChartTypes.Items.Count > 0)
            //    cmbChartTypes.SelectedIndex = 0;
            if (lstPollings.Items.Count > 0)
                lstPollings.Select();
            //{
            //    lstPollings.Items[0].Selected = true;
            //    lstPollings.Focus();
            //    lstPollings.Items[0].Checked = true;
            //    LoadChart(Convert.ToInt32(lstPollings.SelectedItems[0].ImageKey));
            //}
            
        }
        private void LoadChart(int pPollingCode)
		{        
			
			JCountPollings pollingCount = new JCountPollings(pPollingCode, _CompanyCode);
            DataTable resultTable = pollingCount.GetPollingResult();
            Int64 sumPolling = pollingCount.GetCountedSum();
            //if (cmbChartTypes.SelectedIndex == 0)
            {
              //  Chart1.Visible = true;
              //  chartPie.Visible = false;
              //  pnlList.Visible = false;
                Chart1.DataSource = resultTable;
                Chart1.Series["Default"].XValueMember = "Title";
                Chart1.Series["Default"].YValueMembers = "VoteCount";
                Chart1.Titles[0].Text = lstPollings.SelectedItems[0].Text;
 
            }

            //else   if (cmbChartTypes.SelectedIndex == 1)
            //{
            //    Chart1.Visible = false;
            //    chartPie.Visible = true;
            //    pnlList.Visible = false;
            //    chartPie.DataSource = resultTable;
            //    chartPie.Series["Default"].XValueMember = "Title";
            //    chartPie.Series["Default"].YValueMembers = "VoteCount";
            //    chartPie.Titles[0].Text = lstPollings.SelectedItems[0].Text;
            //}
            //else if (cmbChartTypes.SelectedIndex == 2)
            {
               // Chart1.Visible = false;
               // chartPie.Visible = false;
               // pnlList.Visible = true;
                lstCandidas.Items.Clear();
                imgListAgents.Images.Clear();
                int imageIndex = 0;
                foreach (DataRow row in resultTable.Rows)
                {
                    int personCode = Convert.ToInt32(row["PCode"]);
                    JPerson _Person = new JPerson(personCode);
                    ListViewItem item = new ListViewItem(row["Rowno"] + "- " + row["Title"].ToString());
                    ListViewItem subItem = new ListViewItem("تعداد آرای کسب شده: " + row["VoteCount"].ToString());
                    item.SubItems.Add("تعداد آرای کسب شده: " + row["VoteCount"].ToString()+ " - " + row["Percent"].ToString() + " %");
                    //item.SubItems.Add(row["Percent"].ToString()+" %");
                    JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                    try
                    {
                        if (archive.Retrieve(_Person.PersonImageCode))
                        {
                            JFile file = archive.Content;
                            if (file != null)
                            {
                                imgListAgents.Images.Add(System.Drawing.Image.FromStream(file.Stream));
                                item.ImageIndex = imageIndex;
                                imageIndex++;
                            }
                        }
                        lstCandidas.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                        archive.Dispose();
                    }
                }
              //  lbListTitle.Text = lstPollings.SelectedItems[0].Text;
            }
        }

        private void lstPollings_DoubleClick(object sender, EventArgs e)
        {
            if (lstPollings.SelectedItems != null)
            {
                LoadChart(Convert.ToInt32(lstPollings.SelectedItems[0].ImageKey));
            }
        }

        private void cmbChartTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPollings.Select();
            if (lstPollings.SelectedItems != null && lstPollings.SelectedItems.Count>0)
            {
                LoadChart(Convert.ToInt32(lstPollings.SelectedItems[0].ImageKey));
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmbChartTypes_SelectedIndexChanged(null, null);
        }
    }
}
