using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automation.Refer
{
    public partial class JReferGroupForm : ClassLibrary.JBaseForm
    {

        private object _SelectedItem;
        public JReferGroupForm()
        {
            InitializeComponent();
            _SetForm();
        }

        public void _SetForm()
        {
            DataTable DT = Employment.JEOrganizationChart.GetAllData();
            chkUsers.Items.Clear();
            foreach (DataRow dr in DT.Rows)
            {
                ClassLibrary.JKeyValue jKeyValue = new ClassLibrary.JKeyValue();
                jKeyValue.Value = dr["Code"];
                jKeyValue.Key = dr["Full_Title"].ToString();
                chkUsers.Items.Add(jKeyValue);
            }

            lbGroup.Items.Clear();
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try {
                DB.setQuery("select GroupName from refGroupName where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " group by GroupName order by GroupName");
                DT = DB.Query_DataTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ClassLibrary.JKeyValue jKeyValue = new ClassLibrary.JKeyValue();
                    jKeyValue.Value = dr["GroupName"].ToString();
                    jKeyValue.Key = dr["GroupName"].ToString();
                    lbGroup.Items.Add(jKeyValue);
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

        public void _t()
        {

        }

        private void lbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _SelectedItem = lbGroup.SelectedItem;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from refGroupName where PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " and groupName=N'" + (_SelectedItem as ClassLibrary.JKeyValue).Value + "' order by GroupName");
                DataTable DT = DB.Query_DataTable();
                for (int i = 0; i < chkUsers.Items.Count; i++)
                {
                    chkUsers.SetItemChecked(i, false);
                }
                foreach (DataRow dr in DT.Rows)
                {
                    for (int i = 0; i < chkUsers.Items.Count; i++)
                    {
                        if ((chkUsers.Items[i] as ClassLibrary.JKeyValue).Value.ToString() == dr["PostCodeGuest"].ToString())
                        {
                            chkUsers.SetItemChecked(i, true);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _SelectedItem = null;
            for (int i = 0; i < chkUsers.Items.Count; i++)
            {
                chkUsers.SetItemChecked(i, false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string _text = "";
            if (_SelectedItem == null)
            {
                _text = tbGroupName.Text;
            }
            else
            {
                _text = (_SelectedItem as ClassLibrary.JKeyValue).Value.ToString();
            }
            if(_text.Length > 0)
            {
                JGroupName.DeleteByGroupName(ClassLibrary.JMainFrame.CurrentPostCode,_text);
                foreach (object d in chkUsers.CheckedItems)
                {
                    int PostCodeGuest = ((int)(d as ClassLibrary.JKeyValue).Value);
                    JGroupName G = new JGroupName();
                    G.GroupName = _text;
                    G.PostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                    G.PostCodeGuest = PostCodeGuest;
                    G.Insert();
                }
                _SetForm();
                _SelectedItem = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (lbGroup.SelectedItem != null)
            {
                JGroupName.DeleteByGroupName(ClassLibrary.JMainFrame.CurrentPostCode, (lbGroup.SelectedItem as ClassLibrary.JKeyValue).Value.ToString());
                _SetForm();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
