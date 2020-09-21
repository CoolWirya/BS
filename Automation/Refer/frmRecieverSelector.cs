using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ClassLibrary;

namespace Automation.Refer
{
    public partial class frmRecieverSelector : ClassLibrary.JBaseForm
    {
        DataTable dtDescription;
        public const string _ConstClassName = "Automation.Refer.frmRecieverSelector";
        private DataTable _PostCodes;
        private string _title;
        private int _ParentRefer;
        private string _ClassName;
        private int _DynamicClassName;
        private int _ObjectCode;
        private int _workFlowCode;
        private DataTable _PublicDataRow;

        private int _ReferCode;
        public int ReferCode
        {
            get
            {
                return _ReferCode;
            }
        }

        public frmRecieverSelector(DataTable pDataRow, DataTable pPostCodes, string pClassName, int pDynamicClassName, int pObjectCode, string pTitle, int pParentRefer)
        {
            InitializeComponent();
            _PostCodes = pPostCodes;
            _title = pTitle;
            _ParentRefer = pParentRefer;
            _ObjectCode = pObjectCode;
            _ClassName = pClassName;
            _DynamicClassName = pDynamicClassName;
            _PublicDataRow = pDataRow;
            jArchiveList1.ClassName = _ConstClassName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Error = false;
            if (chbUsers.CheckedItems.Count == 0)
                return;
            if (chbUsers.CheckedItems.Count > 1)
            {
                if (JMessages.Warning("تعداد " + chbUsers.CheckedItems.Count.ToString() + " نفر جهت ارجاع انتخاب شده است. آیا مطمئن هستید؟", "ارجاع به چند نفر") != DialogResult.OK)
                    return;
            }
            List<string> Recivers = new List<string>();
            for (int i = 0; i < chbUsers.CheckedItems.Count; i++)
            {
                Recivers.AddRange((chbUsers.CheckedItems[i] as JKeyValue).Value.ToString().Split(';'));
            }

            JDataBase db = new JDataBase();
            try
            {
                foreach (string Reciver in Recivers)
                {
                    int d;
                    if (int.TryParse(Reciver, out d))
                    {
                        Employment.JEOrganizationChart jeoc = new Employment.JEOrganizationChart(d);

                        Automation.JARefer tmprefer = new Automation.JARefer();
                        tmprefer.send_date_time = JDateTime.Now();

                        tmprefer.sender_code = JMainFrame.CurrentUserCode;
                        tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;
                        tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
                        tmprefer.receiver_code = Convert.ToInt32(jeoc.user_code);
                        tmprefer.receiver_full_title = jeoc.full_Name;
                        tmprefer.receiver_post_code = d;
                        tmprefer.register_user_code = JMainFrame.CurrentUserCode;
                        tmprefer.register_Date_Time = JDateTime.Now();
                        tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                        tmprefer.is_active = true;
                        tmprefer.ReferGroup = 1;
                        tmprefer.parent_code = _ParentRefer;
                        tmprefer.description = txtComment.Text;
                        tmprefer.WorkFlowCode = ((JWorkFlow)cmbNextNodes.SelectedItem).Code;

                        tmprefer.object_code = tmprefer.SendToAutomation(_ObjectCode,
                                                                        "", _title, _ClassName, _DynamicClassName, db,
                                                                        JMainFrame.CurrentPostTitle, JMainFrame.CurrentPostCode,
                                                                        JMainFrame.CurrentUserCode, false);
                        if (tmprefer.Send(db, true) > 0)
                        {
                            ((JWorkFlow)cmbNextNodes.SelectedItem).RUNSQL();
                            ((JWorkFlow)cmbNextNodes.SelectedItem).RUNACTION();
                            _ReferCode = tmprefer.Code;
                            if (_ParentRefer > 0)
                            {
                                jArchiveList1.ObjectCode = _ParentRefer;
                                jArchiveList1.ArchiveList();
                            }
                        }
                        else
                        {
                            Error = true;
                            JMessages.Error("اتوماسیون با خطا مواجه شد.", "اتوماسیون");
                        }
                    }

                }
                if (!Error)
                {
                    JMessages.Information("با موفقیت ارجاع داده شد.", "اتوماسیون");
                    this.Close();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            finally
            {
                db.Dispose();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmRecieverSelector_Load(object sender, EventArgs e)
        {
            // Add old descriptions
            dtDescription = JARefers.GetDescriptionByPostCode(JMainFrame.CurrentPostCode);
            dgrDescription.DataSource = dtDescription;
            dgrDescription.Columns[0].Width = dgrDescription.Width * 80 / 100;
            dgrDescription.Columns[1].Width = dgrDescription.Width * 20 / 100;
            // --------------------
            int _ReferCode = 0;
            _workFlowCode = 0;
            if (_ParentRefer > 0)
            {
                JARefer Refer = new JARefer(_ParentRefer);
                _workFlowCode = Refer.WorkFlowCode;
                _ReferCode = Refer.Code;
            }
            else
                tabControl1.TabPages.RemoveAt(1);
            JWorkFlow WorkFlow = new JWorkFlow(_PublicDataRow, _ReferCode);
            WorkFlow.GetData(_workFlowCode, _ClassName, _DynamicClassName);

            if (WorkFlow.NodeType == JNodeType.PreviousEmployment)
            {
                JARefer _R = new JARefer(_ParentRefer);
                _R.GetData(_R.parent_code);
                if (_R.parent_code != 0)
                {
                    _R.GetData(_R.parent_code);
                    WorkFlow.GetData(_R.WorkFlowCode, "", 0);
                }
                else
                {
                    WorkFlow.GetFirst();
                }
            }

            JWorkFlow[] NextNodes = WorkFlow.GetNextNodes();
            if (NextNodes == null)
                JMessages.Error(" مرحله بعدی برای این وضعیت تعریف نشده است ", "");
            else
                cmbNextNodes.Items.AddRange(NextNodes);

            if (cmbNextNodes.Items.Count > 0)
                cmbNextNodes.SelectedIndex = 0;
        }


        public void Tidy(DataTable DT, string colName, string NewcolName, int Len)
        {
            try
            {
                if (DT.Columns.IndexOf(NewcolName) < 0)
                {
                    DT.Columns.Add(NewcolName);
                }
                foreach (System.Data.DataRow drow in DT.Rows)
                {
                    if (drow[colName].ToString().Length > Len)
                        drow[NewcolName] = drow[colName].ToString().Remove(Len, drow[colName].ToString().Length - Len) + "...";
                    else
                        drow[NewcolName] = drow[colName].ToString();

                }
            }
            catch
            {
            }
            DT.AcceptChanges();
        }

        private void cmbNextNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            JWorkFlow NextNode = (JWorkFlow)cmbNextNodes.SelectedItem;
            DataTable DT = NextNode.GetPosts();
            if (DT == null)
                return;
            DataColumn DC = new DataColumn("OrderedPosts", typeof(int));
            DT.Columns.Add(DC);
            JReferOrderUser RO = new JReferOrderUser();
            int Count = 0;
            foreach (DataRow DR in DT.Rows)
            {
                int i = 0;
                int.TryParse(DR["Code"].ToString().Trim(), out i);
                if (i > 0)
                {

                    try
                    {
                        if (RO.Find(i, true))
                        {
                            DR["OrderedPosts"] = RO.Ordered;
                            Count = RO.Ordered;
                        }
                        else
                        {
                            RO.PostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                            RO.PostCodeUser = (int)DR["Code"];
                            RO.Ordered = ++Count;
                            RO.Insert();
                        }
                    }
                    catch
                    {
                    }
                }
            }
            DT.AcceptChanges();

            DataView dv = DT.DefaultView;
            dv.Sort = "OrderedPosts";
            DT = dv.ToTable();

            try
            {
                DT.Merge(_PostCodes);
            }
            catch
            {
            }

            Tidy(DT, "Full_Title", "Full_Title_Slim", 45);
            chbUsers.Items.Clear();
            foreach (DataRow dr in DT.Rows)
            {
                JKeyValue jKeyValue = new JKeyValue();
                jKeyValue.Value = dr["Code"];
                jKeyValue.Key = dr["Full_Title_Slim"].ToString();
                chbUsers.Items.Add(jKeyValue);
            }
        }

        private void dgrDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgrDescription.SelectedRows.Count > 0)
                txtComment.Text = dgrDescription.SelectedRows[0].Cells["Title"].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chbUsers.Items.Count; i++)
            {
                if ((chbUsers.Items[i] as JKeyValue).Key.IndexOf(txtSearch.Text) >= 0)
                {
                    chbUsers.SetSelected(i, true);
                    return;
                }
            }
        }

        private void chbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void chbUsers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int selected = chbUsers.CheckedItems.Count;
            if (e.NewValue == CheckState.Checked) selected++;
            else selected--;
            if (selected == 0)
                label1.Text = "پست سازمانی:";
            else
                label1.Text = "پست سازمانی: (" + selected.ToString() + " نفر انتخاب شده)";

            btnSave.Text = "ارجاع (" + selected.ToString() + ")";
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chbUsers.Items.Count; i++)
                chbUsers.SetItemChecked(i, chbAll.Checked);
        }

        private void txtDescriptionSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtDescription != null)
            {
                DataRow[] drs = dtDescription.Select("Title like '%" + txtDescriptionSearch.Text + "%'");
                dgrDescription.DataSource = null;
                if (drs.Length > 0)
                    dgrDescription.DataSource = drs.CopyToDataTable();

            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void dgrDescription_Click(object sender, EventArgs e)
        {
        }
        private void DeleteCommentHistory(int Code)
        {
        }
        private void dgrDescription_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            btnUp.Enabled = false;
            if (chbUsers.SelectedIndex == 0)
                return;
            if (chbUsers.SelectedItem != null)
            {
                JKeyValue VSelect = (JKeyValue)chbUsers.SelectedItem;
                JReferOrderUser RO = new JReferOrderUser();
                if (RO.Find((int)VSelect.Value))
                    RO.OrderUP((int)VSelect.Value);
                else
                {
                    RO.PostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                    RO.PostCodeUser = (int)VSelect.Value;
                    RO.Ordered = 1;
                    RO.Insert();
                }
            }

            int Index = chbUsers.SelectedIndex;
            chbUsers.Items.Insert(Index - 1, chbUsers.SelectedItem);
            chbUsers.Items.RemoveAt(Index + 1);
            chbUsers.SelectedIndex = Index - 1;

            OrderRefresh();
            btnUp.Enabled = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            btnDown.Enabled = false;
            if (chbUsers.SelectedIndex == chbUsers.Items.Count - 1)
                return;
            if (chbUsers.SelectedItem != null)
            {
                JKeyValue VSelect = (JKeyValue)chbUsers.SelectedItem;
                JReferOrderUser RO = new JReferOrderUser();
                if (RO.Find((int)VSelect.Value))
                    RO.OrderDown((int)VSelect.Value);
                else
                {
                    RO.PostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                    RO.PostCodeUser = (int)VSelect.Value;
                    RO.Ordered = 1;
                    RO.Insert();
                }
            }
            int Index = chbUsers.SelectedIndex;
            chbUsers.Items.Insert(Index + 2, chbUsers.SelectedItem);
            chbUsers.Items.RemoveAt(Index);

            chbUsers.SelectedIndex = Index + 1 ;

            OrderRefresh();
            btnDown.Enabled = true;
        }

        private void OrderRefresh()
        {
            JReferOrderUser RO = new JReferOrderUser();
            int count = 1;
            for (int i = 0; i < chbUsers.Items.Count; i++ )
            {
                JKeyValue KV = (JKeyValue)chbUsers.Items[i];
                if (RO.Find((int)KV.Value, true))
                {
                    RO.Ordered = count++;
                    RO.Update();
                }
                else
                {
                    RO.PostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                    RO.PostCodeUser = (int)KV.Value;
                    RO.Ordered = count++;
                    RO.Insert();
                }
            }
        }

        private void btnGroupForm_Click(object sender, EventArgs e)
        {
            JReferGroupForm RGF = new JReferGroupForm();
            RGF.ShowDialog();
        }

        private void btnSeletGroup_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Items.Clear();
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select GroupName from refGroupName where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " group by GroupName order by GroupName");
                DataTable DT = DB.Query_DataTable();
                foreach (DataRow dr in DT.Rows)
                {
                    contextMenuStrip2.Items.Add(dr["GroupName"].ToString());
                }
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            contextMenuStrip2.Show(btnSeletGroup, new Point(0, 0));
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from refGroupName where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " and groupName=N'" + e.ClickedItem.Text + "' order by GroupName");
                DataTable DT = DB.Query_DataTable();
                foreach (DataRow dr in DT.Rows)
                {
                    for (int i = 0; i < chbUsers.Items.Count; i++)
                    {
                        if ((chbUsers.Items[i] as ClassLibrary.JKeyValue).Value.ToString() == dr["PostCodeGuest"].ToString())
                        {
                            chbUsers.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chbUsers.Items.Count; i++)
            {
                chbUsers.SetItemChecked(i, checkBox1.Checked);
            }

        }
    }
}
