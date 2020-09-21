using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JHistoryRefer : JBaseForm
    {
        private int _Object_Code;
        public DataRow SelectedItem;

        public JHistoryRefer(int Object_Code)
        {
            InitializeComponent();
            _Object_Code = Object_Code;
            cmbObjectType.Enabled = false;
            txtCode.Enabled = false;
        }

        private void frmHistoryRefer_Load(object sender, EventArgs e)
        {
            //-------------- انواع اشیا ---------------
            cmbObjectType.DisplayMember = "FarsiName";
            cmbObjectType.ValueMember = "value";
            //cmbObjectType.DataSource = ClassLibrary.Domains.JAutomation.JObjectType.GetData();

            if (_Object_Code != 0)
            {
                JAObject tmpJAObject = new JAObject(_Object_Code);
                cmbObjectType.SelectedValue = ClassLibrary.Domains.JAutomation.JObjectType.Letters;
                Search();
            }
        } 

        private void Search()
        {
            JAObject tmpJAObject = new JAObject();
            DataTable dt = new DataTable();
            dt = tmpJAObject.FindObjectReferByCode(_Object_Code, new int[] { 0 });

            if (dt != null)
            {
                jDataTreeView1.dtTree = dt.Copy();
                jDataTreeView1.Title = "full_title";
                jDataTreeView1.Code = "ID";
                jDataTreeView1.ParentCode = "parentcode";
                jDataTreeView1.CheckBox = false;
                jDataTreeView1.CMenu = null;
               // jDataTreeView1.TreeView.
                jDataTreeView1.Refresh();
            }
            jDataTreeView1.TreeView.ExpandAll();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Object_Code = Convert.ToInt32(txtCode.Text);
            Search();
        }

        private void jDataTreeView1_SelectedItemChange(object sender, TreeViewEventArgs e)
        {
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)jDataTreeView1.SelectedItem).Tag);
            //if ((((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2] != null) && (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2].ToString() != ""))
            //    _Decesion_Code = Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2]);

            FillItem degAddToList = new FillItem(Filltxt);
            this.Invoke(degAddToList, SelectedItem);
        }

        private void Filltxt(DataRow SelectedItem)
        {
            txtdescription.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[40].ToString();
            txtmessage.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[36].ToString();
            txtmessage_secret.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[37].ToString();
            txtreceiver_full_title.Text = JDateTime.FarsiDate(Convert.ToDateTime(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[24].ToString()));
            txtreceiver_post.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2].ToString();

            txtrefertype.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[17].ToString();
            if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[34].ToString() != "")
                txtrespite_date_time.Text = JDateTime.FarsiDate(Convert.ToDateTime(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[34].ToString()));
            txtsender_post.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[9].ToString();
            txtresponse.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[38].ToString();
            txtresponse_secret.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[39].ToString();
            //txtsecret_level.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[30].ToString();
            //txtsender_full_title.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2].ToString();
            if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[31].ToString() != "")
                txtrespnse_date_time.Text = JDateTime.FarsiDate(Convert.ToDateTime(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[31].ToString()));
            //txtstatus.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[29].ToString();
            if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[32].ToString() != "")
                txtview_date_time.Text = JDateTime.FarsiDate(Convert.ToDateTime(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[32].ToString()));

            if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[30].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Normal)
                txtsecret_level.Text = JLanguages._Text("Normal");
            else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[30].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Quick)
                txtsecret_level.Text = JLanguages._Text("Secure");
            else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[30].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick)
                txtsecret_level.Text = JLanguages._Text("VerySecure");
            if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[35].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Normal)
                txturgency.Text = JLanguages._Text("Normal");
            else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[35].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Quick)
                txturgency.Text = JLanguages._Text("Quick");
            else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[35].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick)
                txturgency.Text = JLanguages._Text("VeryQuick");

            txtview_date_time.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[25].ToString();
        }

        public delegate void FillItem(DataRow SelectedItem);

        private void txtCode_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
                Search();
        }

    }
}
