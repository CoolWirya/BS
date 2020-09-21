using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;

namespace Automation
{
    public partial class JFoldersListForm : JBaseForm
    {
        int _FolderType;
        public JFoldersListForm(int pFolderType)
        {
            InitializeComponent();
            _FolderType = pFolderType;
            GetData();
        }
        public int CodeSelect = 0;
        private void GetData()
        {
            JAFolders Kart = new JAFolders();
            System.Data.DataTable FolderData = Kart.GetDataTable(_FolderType);
            cmbFolders.DataSource = FolderData;
            cmbFolders.DisplayMember = "Name";
            cmbFolders.ValueMember = "Code";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbFolders.SelectedIndex > -1)
            {
                this.DialogResult = DialogResult.OK;
                CodeSelect = (int)cmbFolders.SelectedValue;
            }
            Close();
        }
    }
}
