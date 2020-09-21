using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ArchivedDocuments;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JRunAssemblyForm : Globals.JBaseForm
    {
        JAssembly _Assembly;
        public JRunAssemblyForm(int AssemblyCode)
        {
            InitializeComponent();
            _Assembly = new JAssembly(AssemblyCode);
            lbTitle.Text = _Assembly.Title;
            RefreshData();
            timer1.Enabled = true;
        }

        private void RefreshData()
        {
            /// آمار بالای فرم
           // txtCommands.Text = "دستورات جلسه:\r\n" + _Assembly.Commands;
            lstPresents.Focus();
            JAssemblyPresences presenceInfo = new JAssemblyPresences(_Assembly.Code);
            lbPresentCount.Text = presenceInfo.GetNumberOfExistingAgents().ToString();
            int rightCount = presenceInfo.GetNumberOfExistingRights();
            lbRightCount.Text = rightCount.ToString();
            JShareCompany company = new JShareCompany(_Assembly.CompanyCode);
            lbPercent.Text = (rightCount / company.CurrentShareCount * 100).ToString();
            /// لیست اشخاص
            lstPresents.Items.Clear();
            imgListAgents.Images.Clear();
            DataTable presents = (new JAssemblyPresences(_Assembly.Code)).GetData(0);
            foreach (DataRow presentRow in presents.Rows)
            {
                int personCode = Convert.ToInt32(presentRow["AgentPCode"]);
                JPerson _Person = new JPerson(personCode);
                ListViewItem presentItem = new ListViewItem(lstPresents.Groups["listGrpPresents"]);
                presentItem.Text = presentRow["Name"].ToString();
                presentItem.SubItems.Add("تعداد حق رأی: " + presentRow["VoteRight"].ToString());
                this.lstPresents.Items.Add(presentItem);
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                int imageIndex = 0;
                try
                {
                    if (archive.Retrieve(_Person.PersonImageCode))
                    {
                        JFile file = archive.Content;
                        if (file != null)
                        {
                            imgListAgents.Images.Add(System.Drawing.Image.FromStream(file.Stream));
                            presentItem.ImageIndex = imageIndex;
                            imageIndex++;
                        }
                    }
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
