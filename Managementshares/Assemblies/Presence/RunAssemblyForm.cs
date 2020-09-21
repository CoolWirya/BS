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
using System.Windows.Forms.DataVisualization.Charting;

namespace ManagementShares
{
	public partial class JRunAssemblyForm : ClassLibrary.JBaseForm
	{
		Timer timer = null;
		JAssembly _Assembly;
		int _CompanyCode;
		static int lastSelectedIndex;
		public JRunAssemblyForm(int AssemblyCode)
		{
			InitializeComponent();
			_Assembly = new JAssembly(AssemblyCode);
			_CompanyCode = _Assembly.CompanyCode;
			lastSelectedIndex = 0;
			//timer = new Timer();
			//timer.Interval = 10000;
			//timer.Tick += timer_Tick;
			_Assembly = new JAssembly(AssemblyCode);
			lbTitle.Text = _Assembly.Title;
			RefreshAll();
			timer1.Enabled = true;
		}

		//void timer_Tick(object sender, EventArgs e)
		//{
		//	tsLabel.Location = new Point(tsLabel.Location.X + 1, tsLabel.Location.Y);
		//	if (tsLabel.Location.X >= panel2.Width)
		//		tsLabel.Location = new Point(-tsLabel.Width, tsLabel.Location.Y);
		//}

		private void UpdateChart(decimal percent)
		{
			chart1.Series[0].Points.Clear();
			chart1.Series[0].Points.AddXY("تعداد حاضرین", percent);
			chart1.Series[0].Points.AddXY("تعداد کل نفرات", 100 - percent);
			chart1.Series[0].Points[1].Color = Color.SeaGreen;
			chart1.Series[0].Points[0].Color = Color.LightSkyBlue;
			chart1.Series[0].IsValueShownAsLabel = true;
			chart1.Titles[0].Text = "درصد حضور اعضاء: " + percent.ToString("0.0") + " درصد";
		}

		private void RefreshAll()
		{
			/// آمار بالای فرم
			//lstPresents.Focus();
			JAssemblyPresences presenceInfo = new JAssemblyPresences(_Assembly.Code,_CompanyCode);
			//presenceInfo.RemoveAllFromList();
			lbPresentCount.Text = presenceInfo.GetNumberOfExistingAgents().ToString() + " نفر ";
			int rightCount = presenceInfo.GetNumberOfExistingRights();
			lbRightCount.Text = rightCount.ToString();
			JShareCompany company = new JShareCompany(_Assembly.CompanyCode);
			lbPercent.Text = (rightCount / company.CurrentShareCount * 100).ToString() + " درصد ";
			UpdateChart(rightCount / company.CurrentShareCount * 100);



			/// لیست اشخاص
			//lstPresents.Items.Clear();
			//imgListAgents.Images.Clear();
			//DataTable presents = (new JAssemblyPresences(_Assembly.Code)).GetData(0, false);
			//int imageIndex = 0;
			//foreach (DataRow presentRow in presents.Rows)
			//{
			//	int personCode = Convert.ToInt32(presentRow["AgentPCode"]);
			//	JPerson _Person = new JPerson(personCode);
			//	ListViewItem presentItem = new ListViewItem(lstPresents.Groups["listGrpPresents"]);
			//	presentItem.Text = presentRow["Name"].ToString();
			//	presentItem.Tag = presentRow["AgentPCode"].ToString();
			//	if (chkShowAra.Checked)
			//		presentItem.Text += "(حق رأی: " + presentRow["VoteRight"].ToString() + ")";
			//	//presentItem.SubItems.Add("تعداد حق رأی: " + presentRow["VoteRight"].ToString());
			//	this.lstPresents.Items.Add(presentItem);
			//	ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
			//	try
			//	{
			//		if (archive.Retrieve(_Person.PersonImageCode))
			//		{
			//			JFile file = archive.Content;
			//			if (file != null)
			//			{
			//				imgListAgents.Images.Add(System.Drawing.Image.FromStream(file.Stream));
			//				presentItem.ImageIndex = imageIndex;
			//			}
			//		}
			//		else
			//		{
			//			imgListAgents.Images.Add(JImageIcon.getImage(JImageIndex.User));
			//			presentItem.ImageIndex = imageIndex;
			//		}
			//		imageIndex++;
			//		presenceInfo.AddAllToList();
			//	}
			//	catch (Exception ex)
			//	{
			//		JSystem.Except.AddException(ex);
			//	}
			//	finally
			//	{
			//		archive.Dispose();
			//	}
			//}
			//lbCommands.Text = "دستورات جلسه:\r\n" + _Assembly.Commands;
			timer1.Enabled = true;
		}

		private void AddNews()
		{
			/// آمار بالای فرم
			JAssemblyPresences presenceInfo = new JAssemblyPresences(_Assembly.Code,_CompanyCode);
			lbPresentCount.Text = presenceInfo.GetNumberOfExistingAgents().ToString() + " نفر ";
			int rightCount = presenceInfo.GetNumberOfExistingRights();
			lbRightCount.Text = rightCount.ToString();
			JShareCompany company = new JShareCompany(_Assembly.CompanyCode);
			lbPercent.Text = (rightCount / company.CurrentShareCount * 100).ToString() + " درصد ";
			UpdateChart(rightCount / company.CurrentShareCount * 100);
			/// فقط اشخاصی انتخاب میشوند که قبلا به لیست اضافه نشده اند
			//DataTable presents = (new JAssemblyPresences(_Assembly.Code)).GetData(0, true);
			//int imageIndex = imgListAgents.Images.Count;
			//foreach (DataRow presentRow in presents.Rows)
			//{
			//	JAssemblyPresence presence = new JAssemblyPresence(Convert.ToInt32(presentRow["AgentPCode"]));
			//	//presence.AddedToList = true;
			//	presence.Update();
			//	int personCode = Convert.ToInt32(presentRow["AgentPCode"]);
			//	JPerson _Person = new JPerson(personCode);
			//	ListViewItem presentItem = new ListViewItem(lstPresents.Groups["listGrpPresents"]);
			//	presentItem.Text = presentRow["Name"].ToString();
			//	presentItem.Tag = presentRow["AgentPCode"].ToString();
			//	if (chkShowAra.Checked)
			//		presentItem.SubItems.Add("تعداد حق رأی: " + presentRow["VoteRight"].ToString());
			//	lblName.Text = presentItem.SubItems[presentItem.SubItems.Count - 1].Text;
			//	this.lstPresents.Items.Add(presentItem);
			//	ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
			//	try
			//	{
			//		if (archive.Retrieve(_Person.PersonImageCode))
			//		{
			//			JFile file = archive.Content;
			//			if (file != null)
			//			{
			//				imgListAgents.Images.Add(System.Drawing.Image.FromStream(file.Stream));
			//				PicPresent.Image = System.Drawing.Image.FromStream(file.Stream);
			//				presentItem.ImageIndex = imageIndex;
			//			}
			//		}
			//		else
			//		{
			//			imgListAgents.Images.Add(JImageIcon.getImage(JImageIndex.User));
			//			PicPresent.Image = JImageIcon.getImage(JImageIndex.User);
			//			presentItem.ImageIndex = imageIndex;
			//		}
			//		imageIndex++;
			//	}
			//	catch (Exception ex)
			//	{
			//		JSystem.Except.AddException(ex);
			//	}
			//	finally
			//	{
			//		archive.Dispose();
			//	}
			//}
		}


		//private void RefreshData()
		//{
		//    /// آمار بالای فرم
		//    // txtCommands.Text = "دستورات جلسه:\r\n" + _Assembly.Commands;
		//    lstPresents.Focus();
		//    JAssemblyPresences presenceInfo = new JAssemblyPresences(_Assembly.Code);
		//    lbPresentCount.Text = presenceInfo.GetNumberOfExistingAgents().ToString();
		//    int rightCount = presenceInfo.GetNumberOfExistingRights();
		//    lbRightCount.Text = rightCount.ToString();
		//    JShareCompany company = new JShareCompany(_Assembly.CompanyCode);
		//    lbPercent.Text = Math.Round((rightCount / company.CurrentShareCount * 100), 0).ToString();
		//    /// لیست اشخاص
		//    lstPresents.Items.Clear();
		//    imgListAgents.Images.Clear();
		//    DataTable presents = (new JAssemblyPresences(_Assembly.Code)).GetData(0);
		//    int imageIndex = 0;
		//    foreach (DataRow presentRow in presents.Rows)
		//    {
		//        int personCode = Convert.ToInt32(presentRow["AgentPCode"]);
		//        JPerson _Person = new JPerson(personCode);
		//        ListViewItem presentItem = new ListViewItem(lstPresents.Groups["listGrpPresents"]);
		//        presentItem.Text = presentRow["Name"].ToString();
		//        presentItem.Tag = presentRow["Code"].ToString();

		//        if (chkShowAra.Checked)
		//            presentItem.SubItems.Add("تعداد حق رأی: " + presentRow["VoteRight"].ToString());
		//        this.lstPresents.Items.Add(presentItem);

		//        ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
		//        try
		//        {
		//            if (archive.Retrieve(_Person.PersonImageCode))
		//            {
		//                JFile file = archive.Content;
		//                if (file != null)
		//                {
		//                    imgListAgents.Images.Add(System.Drawing.Image.FromStream(file.Stream));
		//                    presentItem.ImageIndex = imageIndex;
		//                    imageIndex++;
		//                }
		//            }
		//        }
		//        catch (Exception ex)
		//        {
		//            JSystem.Except.AddException(ex);
		//        }
		//        finally
		//        {
		//            archive.Dispose();
		//        }

		//    }
		//    foreach (ListViewItem item in lstPresents.Items)
		//    {
		//        item.Position = new Point(item.Position.X * 2, item.Position.Y);
		//    }
		//    lstPresents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		//}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//AddNews();
			//DataTable presents = (new JAssemblyPresences(_Assembly.Code)).GetData(0, false);
			//if (imgListAgents.Images.Count != presents.Rows.Count)
			RefreshAll();
		}

		//private void lstPresents_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	if ((lstPresents.SelectedItems != null) && (lstPresents.SelectedItems.Count > 0))
		//	{
		//		PicPresent.Image = imgListAgents.Images[lstPresents.SelectedItems[0].Index];
		//		lblName.Text = lstPresents.SelectedItems[0].Text;
		//	}
		//}

		private void JRunAssemblyForm_Load(object sender, EventArgs e)
		{
			//timer.Start();
			if (_CompanyCode != 0)
			{
				JShareCompany ShareCompany = new JShareCompany(_CompanyCode);
				JOrganization Org = new JOrganization(ShareCompany.PCode);
				ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
				try
				{
					if (archive.Retrieve(Org.ArmArchiveCode))
					{
						JFile file = archive.Content;
						if (file != null)
						{
							Arm.Image = System.Drawing.Image.FromStream(file.Stream);
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

		private void JRunAssemblyForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				CandidListForm p = new CandidListForm(_Assembly.Code,_CompanyCode);
				p.Show();
			}
		}

		private void chkShowAra_CheckedChanged(object sender, EventArgs e)
		{
			RefreshAll();
		}

		private void cmbPresence_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRow dr = (cmbPresence.SelectedItem as DataRowView).Row;
			int personCode = Convert.ToInt32(dr["AgentPCode"]);
			JPerson _Person = new JPerson(personCode);
			lblVoteRightPercent.Text = "درصد حق رای: " + (int.Parse(dr["VoteRight"].ToString()) * 100 / (new JShareCompany(_Assembly.CompanyCode).CurrentShareCount)).ToString("0.00");
			lblPersonName.Text = dr["Name"].ToString();
			ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
			try
			{
				if (archive.Retrieve(_Person.PersonImageCode))
				{
					JFile file = archive.Content;
					if (file != null)
						pictureBox1.Image = (System.Drawing.Image.FromStream(file.Stream));
				}
				//else
					//imgListAgents.Images.Add(JImageIcon.getImage(JImageIndex.User));
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

		private void cmbPresence_SelectionChangeCommitted(object sender, EventArgs e)
		{
			lastSelectedIndex = cmbPresence.SelectedIndex;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable dtPresents = (new JAssemblyPresences(_Assembly.Code,_CompanyCode)).GetData(0, false);
			if (dtPresents == null || dtPresents.Rows.Count <= 0)
				return;
			cmbPresence.DataSource = dtPresents;
			cmbPresence.DisplayMember = "Name";
			cmbPresence.SelectedIndex = lastSelectedIndex;
		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}

	}
}
