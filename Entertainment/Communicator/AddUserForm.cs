using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace Entertainment
{
    public partial class JAddUserForm : ClassLibrary.JBaseForm
    {
        private JUser _user;
        public JAddUserForm()
        {
            InitializeComponent();
        }

        private void _FillComboBox()
        {
            ClassLibrary.GetInfoActiveDirectory usersDomain = new GetInfoActiveDirectory();
            System.Collections.Generic.SortedList<string, string> ListUsers;
            ListUsers = usersDomain.GetUsersInGroup();
            for (int i = 0; i < ListUsers.Count - 1; i++)
            {
                //cmbDomainName.Items.Add(ListUsers.Keys[i]);
                chkListAllUser.Items.Add(ListUsers.Keys[i]);
                //if (_user != null && _user.domainName != null && ListUsers.Keys[i] == _user.domainName)
                //    cmbDomainName.SelectedItem = ListUsers.Keys[i];

            }
        }

        private void JAddUserForm_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListAllUser.Items.Count - 1; i++)
            {
                if (chkListAllUser.Items[i].ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                    chkListAllUser.SetItemChecked(i, true);
                else
                    chkListAllUser.SetItemChecked(i, false);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
            JConnection conn = new JConnection();
            SqlBuilder = conn.GetSQlServerConnection("Communication", 0);
            JUser tmpUser = new JUser(JMainFrame.CurrentPersonCode);
            
            JDataBase MyDB = new JDataBase(SqlBuilder);
                try
                {
                    for (int i = 0; i < chkListAllUser.Items.Count - 1; i++)
                    {
                        if (chkListAllUser.GetSelected(i))
                        {
                            
                            MyDB.setQuery(@" 
            declare @OwnerId    ResourceId,
            @BuddyId    ResourceId,
            @Status     int,
            @Count      int,
            @Adding     bit,
            @Error      int,
            @RowCount   int,
		    @_VersionContact    int
		    declare @Continue bit; 
    select @OwnerId = r.ResourceId, @Continue = ~hr.Unavailable from dbo.Resource as r inner join dbo.HomedResource as hr on (hr.ResourceId = r.ResourceId) where r.UserAtHost = N'" +tmpUser.domainName+ @"' 
    
   select @_VersionContact = VersionContact from  dbo.HomedResource
         where ResourceId = @OwnerId

exec dbo.RtcSetContact N'" + tmpUser.domainName + "',N'" + chkListAllUser.SelectedItem.ToString() + "',@_VersionContact,0x,1,'1 ',0x,NULL,150 ");
                            MyDB.Query_Execute();
                            //if (!(MyDB.Query_Execute() >= 0))
                            //    JMessages.Error("", "");
                        }
                    }
                }
                finally
                {
                    MyDB.Dispose();
                }
        }
    }
}
