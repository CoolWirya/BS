using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Entertainment
{
    public partial class BulletinAddForm : JBaseForm
    {
        public BulletinAddForm()
        {
            InitializeComponent();
            ArchiveList.ClassName = "Entertainment.BulletinAddForm";
            ArchiveList.ObjectCode =0;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ArchiveList.ClassName = "Entertainment.BulletinAddForm." + cmbFeild.Text.ToString();
            ArchiveList.ObjectCode = Convert.ToInt32(cmbFeild.SelectedValue);
            if (!(ArchiveList.ArchiveList()))
                JMessages.Error(" خطا ","");
        }

        private void BulletinAddForm_Load(object sender, EventArgs e)
        {
            cmbFeild.DisplayMember = "Name";
            cmbFeild.ValueMember = "Code";
            cmbFeild.DataSource = JBulletin.GetDataTableBulletinType(0);
        }

        private void cmbFeild_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArchiveList.ClassName = "Entertainment.BulletinAddForm." + cmbFeild.Text.ToString();
            ArchiveList.ObjectCode = Convert.ToInt32(cmbFeild.SelectedValue);
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            ArchiveList.LoadList();
        }
    }
}
