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

namespace Globals
{
    public partial class JPermissionSetUserForm : JBaseForm
    {
        private int _UserPostCode;
        private int _ObjectCode = 0;
        public JPermissionSetUserForm(int pUserPostCode)
        {
            _UserPostCode = pUserPostCode;
            InitializeComponent();

            JPermissionsDefineClass Per = new JPermissionsDefineClass();
            Per.GetData();
            DefineClassListBox.Items.AddRange(Per.Items);

            JPermissionsUser PerUser = new JPermissionsUser(_UserPostCode);
            PerUser.GetData();
            PermissionUserlistBox.Items.AddRange(PerUser.Items);
        }

        public void SetUsers(int pCode)
        {
            _UserPostCode = pCode;
        }

        private void DefineClasslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DecissionlistBox.Items.Clear();
            ObjectlistBox.Items.Clear();
            _ObjectCode = 0;
            JPermissionDefineClass PerDefine = (JPermissionDefineClass)DefineClassListBox.SelectedItem;
            if (PerDefine != null)
            {
                if (PerDefine.SQL.Length < 1)
                {
                    GetDecision();
                }
                else
                {
                    IDictionary<string, object> Objs = PerDefine.GetObjectList();
                    foreach (KeyValuePair<string, object> Obj in Objs)
                    {
                        ObjectlistBox.Items.Add(Obj);
                    }
                }
            }
        }

        private void ObjectlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectlistBox.SelectedItems.Count == 1)
            {
                if (ObjectlistBox.SelectedItem != null)
                {
                    _ObjectCode = Int32.Parse(((KeyValuePair<string, object>)ObjectlistBox.SelectedItem).Key);
                    GetDecision();
                }
            }
        }

        private void GetDecision()
        {
            DecissionlistBox.Items.Clear();
            DataTable DT = JPermissionDecisions.GetDataTable(((JPermissionDefineClass)DefineClassListBox.SelectedItem).Code);
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow DR in DT.Rows)
                {
                    JPermissionDecision PD = new JPermissionDecision();
                    JTable.SetToClassProperty(PD, DR);
                    int index = DecissionlistBox.Items.Add(PD);
                }
            }
        }

        private void Insertbutton_Click(object sender, EventArgs e)
        {
            if (DefineClassListBox.SelectedIndex >= 0 && DecissionlistBox.SelectedIndex >= 0)
            {
                JPermissionDefineClass PDC = (JPermissionDefineClass)DefineClassListBox.SelectedItem;
                JPermissionDecision PD = (JPermissionDecision)DecissionlistBox.SelectedItem;

                KeyValuePair<string, object> Obj = new KeyValuePair<string,object>("",0);
                if (ObjectlistBox.SelectedIndex >= 0)
                {
                   Obj = (KeyValuePair<string, object>)ObjectlistBox.SelectedItem;
                }

                JPermissionUser PU = new JPermissionUser();
                PU.User_Post_Code = _UserPostCode;
                if (Obj.Key != "")
                    PU.ObjectCode = Int32.Parse(Obj.Key);
                PU.DecisionCode = PD.Code;
                PU.HasPermission = true;
                int Code = PU.Insert();
                if (Code > 0)
                {
                    PermissionUserlistBox.Items.Add(PU);
                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            JPermissionUser PU = (JPermissionUser)PermissionUserlistBox.SelectedItem;
            if (PU != null)
            {
                if (PU.delete())
                {
                    PermissionUserlistBox.Items.Remove(PU);
                }
            }
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DecissionlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectlistBox.SelectedItem != null)
            {
                _ObjectCode = Int32.Parse(((KeyValuePair<string, object>)ObjectlistBox.SelectedItem).Key);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for(int Count=0;Count<ObjectlistBox.Items.Count;Count++)
            {
                ObjectlistBox.SetSelected(Count, checkBoxAll.Checked);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNone.Checked)
            {
                _ObjectCode = 0;
                GetDecision();
                ObjectlistBox.Enabled = false;
            }
            else
            {
                ObjectlistBox.Enabled = true;
            }
        }

    }
}
