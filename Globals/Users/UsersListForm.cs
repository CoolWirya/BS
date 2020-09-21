using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals
{
    public partial class JUsersListForm : JBaseForm
    {
        public string[] SelectUsers;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ns">namespace</param>
        public JUsersListForm(string ns)
        {
            InitializeComponent();

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            SelectUsers = new string[UsersListlistBox.SelectedItems.Count];
            for (int i = 0; i < UsersListlistBox.SelectedItems.Count; i++)
                SelectUsers[i] = UsersListlistBox.SelectedItems[i].ToString();
            Close();
        }

        private void JPersonsListForm_Load(object sender, EventArgs e)
        {

        }

    }
}
