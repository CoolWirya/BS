using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JPostList : JBaseForm
    {
        public int Code = 0;
        public string Name = "";

        public JPostList()
        {
            InitializeComponent();
        }

        private void JPostList_Load(object sender, EventArgs e)
        {
            jdgvPostList.DataSource = JEPosts.GetData(0);
        }

        private void jdgvPostList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jdgvPostList.CurrentRow != null)
            {
                Code = Convert.ToInt32(jdgvPostList.Rows[jdgvPostList.CurrentRow.Index].Cells[0].Value);
                Name = jdgvPostList.Rows[jdgvPostList.CurrentRow.Index].Cells[4].Value.ToString() + "-" + jdgvPostList.Rows[jdgvPostList.CurrentRow.Index].Cells[5].Value.ToString();
            }
            this.Close();
        }
    }
}
