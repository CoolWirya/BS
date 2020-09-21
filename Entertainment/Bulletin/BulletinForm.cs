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
    public partial class BulletinForm : JBaseForm
    {
        public BulletinForm()
        {
            InitializeComponent();
        }

        private void Fill()
        {
            DataTable dt = JSubBaseDefines.GetDataTable(1050, 0);
            ArchivedDocuments.JArchiveList Archive;

            foreach (DataRow dr in dt.Rows)
            {
                TabPage Tp = new TabPage(dr["Name"].ToString());
                tabControl1.TabPages.Add(Tp);

                Archive = new ArchivedDocuments.JArchiveList();
                Archive.Parent = Tp;
                Archive.Dock = System.Windows.Forms.DockStyle.Fill;
                Tp.Controls.Add(Archive);

                Archive.ClassName = "Entertainment.BulletinAddForm." + dr["Name"].ToString();
                Archive.ObjectCode = Convert.ToInt32(dr["Code"].ToString());
                Archive.LoadList();
                Archive.EnabledChange = false;
            }
        }

        private void BulletinForm_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BulletinAddForm p = new BulletinAddForm();
            p.ShowDialog();
            //Fill();
        }

        public void CheckPer()
        {
            if (JPermission.CheckPermission("Entertainment.BulletinForm.CheckPer", false))
                btnAdd.Visible = true;
            else
                btnAdd.Visible = false;
        }
    }
}
