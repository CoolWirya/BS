using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JUC_ReferHistory : UserControl
    {
        public DataRow SelectedItem;
        private int[] _ReferGroup;
        public int[] ReferGroup
        {
            get
            {
                return _ReferGroup;
            }
            set
            {
                _ReferGroup = value;
                LoadTree();
            }
        }
        private JAObject tmpJAObject = new JAObject();

        public JUC_ReferHistory()
        {
            InitializeComponent();
        }

        private void ReferHistory_Load(object sender, EventArgs e)
        {

        }

        private void LoadTree()
        {
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
            try
            {
                rtbDesc.Text = "";
                Font fnt = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
                rtbDesc.SelectionFont = fnt;
                rtbDesc.SelectionColor = Color.Blue;
                rtbDesc.SelectedText = "----------------------------توضیحات ارجاع----------------------";
                rtbDesc.SelectionColor = Color.Black;
                rtbDesc.SelectedText = Environment.NewLine + " شماره ارجاع :  ";
                rtbDesc.SelectionColor = Color.Red;
                rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["MainCode"].ToString();
                rtbDesc.SelectionColor = Color.Black;
                rtbDesc.SelectedText = Environment.NewLine + " توضیحات :  ";
                rtbDesc.SelectionColor = Color.Red;
                rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["description"].ToString();
                
                rtbDesc.SelectionColor = Color.Blue;
                rtbDesc.SelectedText = Environment.NewLine + "----------------------------تاریخ های ارجاع----------------------";
                rtbDesc.SelectionColor = Color.Red;
                if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["send_date_time"].ToString() != "")
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " تاریخ ارسال :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["send_date_time"].ToString();

                }
                if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["view_date_time"].ToString() != "")
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " تاریخ مشاهده :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["view_date_time"].ToString();
                }
                if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["respite_date_time"].ToString() != "")
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " مهلت پاسخ :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["respite_date_time"].ToString();
                }
                if (((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["response_date_time"].ToString() != "")
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " تاریخ پاسخ :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["response_date_time"].ToString();
                }
                //txtstatus.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[29].ToString();

                rtbDesc.SelectionColor = Color.Blue;
                rtbDesc.SelectedText = Environment.NewLine + "----------------------------پست های ارجاع----------------------";
                rtbDesc.SelectionColor = Color.Black;
                rtbDesc.SelectedText = Environment.NewLine + " پست فرستنده :  ";
                rtbDesc.SelectionColor = Color.Red;
                rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["Sender_full_title"].ToString();
                //rtbDesc.Text = Environment.NewLine + " پست گیرنده : " + ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[4].ToString() + "\n";
                rtbDesc.SelectionColor = Color.Black;
                rtbDesc.SelectedText = Environment.NewLine + " توضیح وضعیت :  ";
                rtbDesc.SelectionColor = Color.Red;
                rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["DescriptionObject"].ToString();

                rtbDesc.SelectionColor = Color.Blue;
                rtbDesc.SelectedText = Environment.NewLine + "----------------------------پیام های ارجاع----------------------";
                rtbDesc.SelectionColor = Color.Black;
                rtbDesc.SelectedText = Environment.NewLine + " پیام :";
                rtbDesc.SelectionColor = Color.Red;
                rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["message"].ToString();
                if (JMainFrame.CurrentPostCode == Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["Mainsender_post_code"].ToString())
                    || (JMainFrame.CurrentPostCode == Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["Mainreceiver_post_code"].ToString())))
                    {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " پیام محرمانه :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["message_secret"].ToString();
                }
                else
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " پیام محرمانه :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = "******";
                }

                //rtbDesc.SelectionColor = Color.Blue;
                //rtbDesc.SelectedText = Environment.NewLine + "----------------------------پاسخهای ارجاع----------------------";
                //rtbDesc.SelectionColor = Color.Black;
                //rtbDesc.SelectedText = Environment.NewLine + " پاسخ عادی :  ";
                //rtbDesc.SelectionColor = Color.Red;
                //rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[11].ToString();
                //if (JMainFrame.CurrentPostCode == Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2].ToString()))
                //{
                //    rtbDesc.SelectionColor = Color.Black;
                //    rtbDesc.SelectedText = Environment.NewLine + " پاسخ محرمانه :  ";
                //    rtbDesc.SelectionColor = Color.Red;
                //    rtbDesc.SelectedText = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[12].ToString();
                //}
                //else
                //{
                //    rtbDesc.SelectionColor = Color.Black;
                //    rtbDesc.SelectedText = Environment.NewLine + " پاسخ محرمانه :  ";
                //    rtbDesc.SelectionColor = Color.Red;
                //    rtbDesc.SelectedText = "******";
                //}

                //txtsecret_level.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[30].ToString();
                //txtsender_full_title.Text = ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[2].ToString();

                rtbDesc.SelectionColor = Color.Blue;
                rtbDesc.SelectedText = Environment.NewLine + "----------------------------محرمانگی ارجاع----------------------";
                if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["secret_level"].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Normal)
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " سطح محرمانگی :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = JLanguages._Text("Normal");
                }
                else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["secret_level"].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Quick)
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " سطح محرمانگی :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = JLanguages._Text("Secure");
                }
                else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["secret_level"].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick)
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " سطح محرمانگی :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = JLanguages._Text("VerySecure");
                }
                if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["urgency"].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Normal)
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " فوریت :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = JLanguages._Text("Normal");
                }
                else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["urgency"].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.Quick)
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " فوریت  :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = JLanguages._Text("Quick");
                }
                else if (Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["urgency"].ToString()) == ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick)
                {
                    rtbDesc.SelectionColor = Color.Black;
                    rtbDesc.SelectedText = Environment.NewLine + " فوریت :  ";
                    rtbDesc.SelectionColor = Color.Red;
                    rtbDesc.SelectedText = JLanguages._Text("VeryQuick");
                }
                //rtbDesc.Text = rtbDesc.Text + ((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[26].ToString() + "\n";

                jArchiveList1.ClearList();
                jArchiveList1.ClassName = "Automation.JARefer";
                jArchiveList1.SubjectCode = 0;
                jArchiveList1.PlaceCode = 0;
                jArchiveList1.ObjectCode = Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag))["MainCode"].ToString());
                jArchiveList1.LoadList();
            }
            catch (Exception ex)
            {
                //JBase.Except.AddException(ex);
				JSystem.Except.AddException(ex);
            }
        }

        public delegate void FillItem(DataRow SelectedItem);

        private void jDataTreeView1_SelectedNodWithMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //JHistoryRefer p = new JHistoryRefer(Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[40]));
        }

        private void jDataTreeView1_MouseClick(object sender, MouseEventArgs e)
        {
            //JHistoryRefer p = new JHistoryRefer(Convert.ToInt32(((System.Data.DataRow)(((System.Windows.Forms.TreeNode)(jDataTreeView1.SelectedItem)).Tag)).ItemArray[40]));
        }


    }
}
