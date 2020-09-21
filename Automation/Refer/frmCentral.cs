using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Employment;
using Communication;
using Globals;
namespace Automation
{
    public partial class JCentral : Globals.JBaseForm
    {
        /// <summary>
        /// انتخاب شده ها
        /// </summary>
        public DataRow SelectedItem;
        private int _user_post_code;
        private int _user_code;
        DataTable dtdg = new DataTable();
        int _Post_SelCode;
        string _exp = "";

        public JCentral()
        {
            InitializeComponent();
            _user_post_code = JMainFrame.CurrentPostCode;
            _user_code = JMainFrame.CurrentUserCode;
            dgCentral.Bind(GetDataTablePatern(), JJanusGrid.JSettingKeys.Central);
            dtdg = GetDataTablePatern();
            dgCentral.HidColumns("Object_Code;Parent_code;task_code;refertype;sender_post_code;sender_code;secret_level;urgency;massage;message_secret;send_type;response;response_secret;Description;objecttype;action;externalcode");
        }

        #region "Methods"
        /// <summary>
        /// تعریف ستون گرید
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTablePatern()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Code");
            dt.Columns.Add("title");
            dt.Columns.Add("Object_Code");
            dt.Columns.Add("Parent_code");
            dt.Columns.Add("task_code");
            dt.Columns.Add("refertype");
            dt.Columns.Add("refertype_Title");
            dt.Columns.Add("sender_post_code");
            dt.Columns.Add("sender_code");
            dt.Columns.Add("sender_full_title");
            dt.Columns.Add("secret_level");
            dt.Columns.Add("secret_level_Title");
            dt.Columns.Add("response_date_time");
            dt.Columns.Add("respite_date_time");
            dt.Columns.Add("urgency");
            dt.Columns.Add("urgency_title");
            dt.Columns.Add("message");
            dt.Columns.Add("message_secret");
            //dt.Columns.Add("send_type");
            //dt.Columns.Add("send_type_title");
            dt.Columns.Add("response");
            dt.Columns.Add("response_secret");
            dt.Columns.Add("Description");
            dt.Columns.Add("objecttype");
            dt.Columns.Add("action");
            dt.Columns.Add("externalcode");            
            return dt;
        }
        /// <summary>
        /// پر کردن جدول مربوط به گرید
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable Filldt(DataTable dt)
        {
            dtdg.Clear();
            int i = 0;
            DataRow tmpdr ;            
            foreach(DataRow dr in dt.Rows)
            {
                tmpdr = dtdg.NewRow();
                tmpdr["Code"] = dr["Code"];
                tmpdr["Object_Code"] = dr["Object_Code"];
                tmpdr["Parent_code"] = dr["Parent_code"];
                tmpdr["task_code"] = dr["task_code"];
                tmpdr["refertype"] = dr["refertype"];
                tmpdr["sender_post_code"] = dr["sender_post_code"];
                tmpdr["sender_code"] = dr["sender_code"];
                tmpdr["sender_full_title"] = dr["sender_full_title"];
                tmpdr["secret_level"] = dr["secret_level"];
                tmpdr["response_date_time"] =dr["response_date_time"];
                tmpdr["respite_date_time"] = dr["respite_date_time"];
                tmpdr["urgency"] = dr["urgency"];
                tmpdr["message"] =dr["message"];
                tmpdr["message_secret"] = dr["message_secret"];
                //tmpdr["send_type"] = dr["send_type"];
                //tmpdr["send_type_title"] = dr["send_type_title"];
                tmpdr["response"] = dr["response"];
                tmpdr["response_secret"] = dr["response_secret"];
                tmpdr["Description"] = dr["Description"];
                tmpdr["objecttype"] = dr["objecttype"];
                tmpdr["action"] = dr["action"];
                tmpdr["externalcode"] = dr["externalcode"];
                tmpdr["title"] = dr["title"];

                //---------------------secret_level Type--------------------------
                if (Convert.ToInt32(dt.Rows[i]["secret_level"]) == ClassLibrary.Domains.JGlobal.JPrivacy.Normal)
                {
                    tmpdr["secret_level_Title"] = JLanguages._Text("Normal");
                }
                else if (Convert.ToInt32(dt.Rows[i]["secret_level"]) == ClassLibrary.Domains.JGlobal.JPrivacy.Secure)
                {
                    tmpdr["secret_level_Title"] = JLanguages._Text("Secure");
                }
                else if (Convert.ToInt32(dt.Rows[i]["secret_level"]) == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure)
                {
                    tmpdr["secret_level_Title"] = JLanguages._Text("VerySecure");
                }
                //---------------------Refer Type--------------------------
                if (Convert.ToInt32(dt.Rows[i]["refertype"]) == ClassLibrary.Domains.JAutomation.JReferType.Internal)
                {
                    tmpdr["refertype_Title"] = JLanguages._Text("Internal");
                }
                else if (Convert.ToInt32(dt.Rows[i]["refertype"]) == ClassLibrary.Domains.JAutomation.JReferType.External)
                {
                    tmpdr["refertype_Title"] = JLanguages._Text("External");
                }
                else if (Convert.ToInt32(dt.Rows[i]["refertype"]) == ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries)
                {
                    tmpdr["refertype_Title"] = JLanguages._Text("Subsidiaries");
                }
                //---------------------Urgency Type--------------------------
                if (Convert.ToInt32(dt.Rows[i]["urgency"]) == ClassLibrary.Domains.JGlobal.JUrgency.Normal)
                {
                    tmpdr["urgency_title"] = JLanguages._Text("Normal");
                }
                else if (Convert.ToInt32(dt.Rows[i]["urgency"]) == ClassLibrary.Domains.JGlobal.JUrgency.Quick)
                {
                    tmpdr["urgency_title"] = JLanguages._Text("Quick");
                }
                else if (Convert.ToInt32(dt.Rows[i]["urgency"]) == ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick)
                {
                    tmpdr["urgency_title"] = JLanguages._Text("VeryQuick");
                }
                dtdg.Rows.Add(tmpdr);
            }
            return dtdg;
        }

        #endregion "Methods"

        /// <summary>
        /// رخدادها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region "Events"

        private void frmCentral_Load(object sender, EventArgs e)
        {
            //-------------- انواع اشیا ---------------
            cmbObjectType.DisplayMember = "name";
            cmbObjectType.ValueMember = "value";
            cmbObjectType.DataSource = ClassLibrary.Domains.JAutomation.JObjectType.GetData();
            cmbObjectType.SelectedValue = ClassLibrary.Domains.JAutomation.JObjectType.Letters;            
            fillGrid();
            FillTree();
            fillpost();             
        }

        private void FillTree()
        {
            JAFolder tmpJKartabl = new JAFolder();
            DataTable dt = new DataTable();
            dt = tmpJKartabl.GetKartablCondition(JMainFrame.CurrentPostCode);
            if (dt != null)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["ID"] = "-1";
                dr["full_title"] = "کارتابل";
                //dr["parentcode"] = "";
                dt.Rows.InsertAt(dr, 0);

                jDataTreeView1.dtTree = dt.Copy();
                jDataTreeView1.Title = "full_title";
                jDataTreeView1.Code = "ID";
                jDataTreeView1.ParentCode = "parentcode";
                jDataTreeView1.CheckBox = false;
                jDataTreeView1.CMenu = null;
                jDataTreeView1.Refresh();
                jDataTreeView1.TreeView.ImageList = JImageIcon.GetImageList(new System.Drawing.Size(24, 24));
                jDataTreeView1.TreeView.ImageIndex = (int)JImageIndex.mail_48;
            }
        }

        private void fillpost()
        {   
            JEOrganizationChart tmpJEOrganizationChart = new JEOrganizationChart();
            LbPost.DisplayMember = "title";
            LbPost.ValueMember = "Code";
            LbPost.DataSource = tmpJEOrganizationChart.GetUserPostsByUser_code(JMainFrame.CurrentPersonCode);
            LbPost.SelectedItem = 1;
        }

        private void  fillGrid()
        {            
            //------------های رخ میداد Thread  فراخوانی تابع افزودن فایل جدید بوسیله دلیگیت ، این کار برای آن صورت گرفته که تداخل   ---------------------
            //AddItem degAddToList = new AddItem(FillPost);
            //this.Invoke(degAddToList);
            JARefer tmprefer=new JARefer();
            dgCentral.Bind(Filldt(tmprefer.FindReferByReceivercodeAndpost(_user_post_code, _user_code, _exp)), JJanusGrid.JSettingKeys.Central);            
        }

        private void FillPost()
        {
            JEOrganizationChart tmpJEOrganizationChart = new JEOrganizationChart();
            LbPost.DisplayMember = "title";
            LbPost.ValueMember = "Code";
            LbPost.DataSource = tmpJEOrganizationChart.GetUserPostsByUser_code(_user_code);
            LbPost.SelectedItem = 1;
            _user_post_code = Convert.ToInt32(((DataRowView)(LbPost.SelectedItem))["code"]);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataRowView dr;
            dr = dgCentral.SelectedRow;
            //Current_Refer_Code = Convert.ToInt32(dr[Refer.Code.ToString()]);
            if (Convert.ToInt32(dr[Objects.objecttype.ToString()]) == ClassLibrary.Domains.JAutomation.JObjectType.Letters)
            {
                JfrmLetterRegisterImport tmpJfrmLetterRegisterImport = new JfrmLetterRegisterImport(0, JFormState.Update, Convert.ToInt32(dr[Objects.externalcode.ToString()]), Convert.ToInt32(dr[Refer.Code.ToString()]));
                tmpJfrmLetterRegisterImport.ShowDialog();
            }
            //fillGrid();
            //LoadAction();
            //DataTable dt = new DataTable();
            //dt=JARefers.GetReferInFolder(1, 1);
            //dt = JARefers.GetReferInInbox(1);
            //dt = JARefers.GetReferSend(1);
        }

        private void LoadAction()
        {
            DataRowView dr;
            dr=dgCentral.SelectedRow;
            //Current_Refer_Code = Convert.ToInt32(dr[Refer.Code.ToString()]);
            if (Convert.ToInt32(dr[Objects.objecttype.ToString()]) == ClassLibrary.Domains.JAutomation.JObjectType.Letters)
            {
                JfrmLetterRegisterImport tmpJfrmLetterRegisterImport = new JfrmLetterRegisterImport(0, 0, Convert.ToInt32(dr[Objects.externalcode.ToString()]), Convert.ToInt32(dr[Refer.Code.ToString()]));
                tmpJfrmLetterRegisterImport.ShowDialog();
            }
            fillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FilldgCentral(string pExp)
        {
            if (jDataTreeView1.TreeView.SelectedNode != null)
                jDataTreeView1.TreeView.SelectedNode.BackColor = Color.Yellow; 

            JARefer tmprefer = new JARefer();
            dgCentral.Bind(tmprefer.FindReferByReceivercodeAndpost(_user_post_code, _user_code, pExp), JJanusGrid.JSettingKeys.Central);
        }

        private void LbPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            JARefer tmprefer = new JARefer();
            if (LbPost.SelectedItem != null)
            {
                _user_post_code = Convert.ToInt32(((DataRowView)(LbPost.SelectedItem))["code"]);
                FillTree();
                FilldgCentral("");
            }
        }

        private void jDataTreeView1_SelectedItemChange(object sender, TreeViewEventArgs e)
        {
            ClearBackColor();            

            _exp = " 1=1 ";
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)jDataTreeView1.SelectedItem).Tag);
            if (SelectedItem != null)
            {
                if ((((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[0] != null) && (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[0].ToString()) != "-1")
                {
                    if ((((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[8] != null) && (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[8].ToString()) != "")
                        _exp = _exp + " And " + JTableNamesAutomation.Objects +"."+ Objects.objecttype + "=" + ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[8].ToString();
                    if ((((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[8] != null) && (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[7].ToString()) != "")
                        _exp =  _exp + " And " + JTableNamesAutomation.Refer +"."+ Refer.sender_post_code + "=" + ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[7].ToString();
                }
            AddItem degAddToList = new AddItem(FilldgCentral);
            this.Invoke(degAddToList,_exp);
                //test();
                //dgCentral.Bind(Filldt(tmprefer.FindReferBycodepostObject(Convert.ToInt32(((DataRowView)(LbPost.SelectedItem))["code"]), _user_code, Convert.ToInt32(cmbObjectType.SelectedValue))), JJanusGrid.JSettingKeys.Central);
            }
        }
        private void cmbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //JARefer tmprefer = new JARefer();
            //if (LbPost.SelectedItem != null)
            //    dgCentral.Bind(Filldt(tmprefer.FindReferBycodepostObject(Convert.ToInt32(((DataRowView)(LbPost.SelectedItem))["code"]), _user_code,Convert.ToInt32(cmbObjectType.SelectedValue))), JJanusGrid.JSettingKeys.Central);
        }

        private void btnrefer_Click(object sender, EventArgs e)
        {
            JReferMain p = new JReferMain(Convert.ToInt32(dgCentral.SelectedRow["Code"]),0);                
            p.ShowDialog();
            fillGrid();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            JReferMain p = new JReferMain(Convert.ToInt32(dgCentral.SelectedRow["Code"]),0);
            p.ShowDialog();
        }

        private void TSMIDefineKartabl_Click(object sender, EventArgs e)
        {
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)jDataTreeView1.SelectedItem).Tag);
            int i = 0;
            if (SelectedItem != null)
            {
                i = Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[0]);
                if (i == -1) i = 0;
                JfrmDefineKartabl tmpJfrmDefineKartabl = new JfrmDefineKartabl(0, i);
                tmpJfrmDefineKartabl.State=JFormState.Confirm;
                tmpJfrmDefineKartabl.ShowDialog();                
                FillTree();
            }
        }
      
        private void TSMIEditKartabl_Click(object sender, EventArgs e)
        {
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)jDataTreeView1.SelectedItem).Tag);
            int i=0,j=0;
            if (SelectedItem != null)
            {
                i= Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[0]);
                j = Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[1]);
                if (i != -1) 
                {
               JfrmDefineKartabl tmpJfrmDefineKartabl = new JfrmDefineKartabl(i,j);
                tmpJfrmDefineKartabl.State=JFormState.Update;
                tmpJfrmDefineKartabl.ShowDialog();
                FillTree();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataRowView dr;
            dr = dgCentral.SelectedRow;
            if (dr != null)
                juC_ReferHistory1.SetData(Convert.ToInt32(dr[Objects.externalcode.ToString()]), Convert.ToInt32(dr[Objects.objecttype.ToString()]));
        }

        private void dgCentral_GridRowDoubleClick(object sender, EventArgs e)
        {
            LoadAction();
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)jDataTreeView1.SelectedItem).Tag);
            JAFolder tmpJKartabls = new JAFolder();
            i = Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[0]);
            if (i != -1) 
            {
            if(tmpJKartabls.Delete(i))            
                FillTree();
            else
                JMessages.Message("Delete Not Completed","Kartabl",JMessageType.Error);
            }
        }  
            public delegate void AddItem(string exp);

            private void jDataTreeView1_Click(object sender, EventArgs e)
            {
                ClearBackColor();
            }

            #region Remove BackColor

            // recursively move through the treeview nodes 
            // and reset backcolors to white 
            private void ClearBackColor()
            {
                //Point p = new Point(0,0);
                TreeNodeCollection nodes = jDataTreeView1.TreeView.Nodes;
                //Control c = new Control();
                //    c=jDataTreeView1.TreeView.GetChildAtPoint(p);
                //TreeNodeCollection nodes = jDataTreeView1.TreeView.GetChildAtPoint(0,0);
                    foreach (TreeNode n in nodes)
                    {
                        ClearRecursive(n);
                    }
            }

            // called by ClearBackColor function 
            private void ClearRecursive(TreeNode treeNode)
            {
                foreach (TreeNode tn in treeNode.Nodes)
                {
                    tn.BackColor = Color.White;
                    ClearRecursive(tn);
                }
            }
            #endregion 

           

            
    }
        #endregion
}
