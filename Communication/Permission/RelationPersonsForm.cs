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
using Employment;

namespace Communication
{
    public partial class JRelationPersonsForm : Globals.JBaseForm
    {
        public JRelationPersonsForm()
        {
            InitializeComponent();
        }
        DataTable _DTPersonCode;
        ///// <summary>
        ///// انتخاب شده
        ///// </summary>
        //public DataRow SelectedItem
        //{
        //    get
        //    {
        //        if (dtvOrganizatinChart.SelectedItem != null)
        //            return (DataRow)(((System.Windows.Forms.TreeNode)dtvOrganizatinChart.SelectedItem).Tag);
        //        return null;
        //    }
        //}
        ///// <summary>
        ///// انتخاب شده ها
        ///// </summary>
        //public DataRow[] SelectedItems
        //{
        //    get
        //    {
        //        if (dtvOrganizatinChart.TreeView.Nodes.Count > 0)
        //            return dtvOrganizatinChart.SelectedItems(dtvOrganizatinChart.TreeView.Nodes[0]);
        //        return null;
        //    }
        //}

        private void Fill_Combo()
        {
            //  ---------------------- Set ComboBox Sender --------------------------
            cdbSender.TitleFieldName = "full_title";
            cdbSender.AccessCodeFieldName = "accesscode";
            cdbSender.CodeFieldName = "code";
            cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
            cdbSender.SetComboBox();
        }

        private void JRelationPersonsForm_Load(object sender, EventArgs e)
        {
            Fill_Combo();
            RefreshTree();
        }

        private void RefreshTree()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (new JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                if (dt != null)
                {
                    dtvOrganizatinChart.dtTree = dt.Copy();
                    dtvOrganizatinChart.Title = "full_title";
                    dtvOrganizatinChart.Code = "code";
                    dtvOrganizatinChart.ParentCode = "parentcode";
                    //dtvOrganizatinChart.CheckBox = CheckBoxMode;
                    //dtvOrganizatinChart.CMenu = Menu_TreeNodes;
                    dtvOrganizatinChart.Refresh();
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void Fill_ListBox()
        {
            try
            {
                //DecissionlistBox.Items.Clear();
                //DataTable DT = new DataTable();
                //DT = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0", true);
                //foreach (DataRow DR in DT.Rows)
                //{
                //    JRelationPersons PD = new JRelationPersons();
                //    JTable.SetToClassProperty(PD, DR);
                //    DecissionlistBox.DisplayMember = "Full_Title";
                //    DecissionlistBox.ValueMember = "Code";
                //    DecissionlistBox.DataSource = DT;
                //    //int index = DecissionlistBox.Items.Add(DR);
                //}
                //if (cdbSender.SelectedItem > 0)
                //{                
                _DTPersonCode = JRelationPersons.GetAllData(Convert.ToInt32(cdbSender.SelectedItem["Code"]), 0);
                DecissionlistBox.DisplayMember = "Title";
                DecissionlistBox.ValueMember = "Code";
                DecissionlistBox.DataSource = _DTPersonCode;
                //if (_DTPersonCode.Rows.Count > 0)
                //{
                //    foreach (DataRow DR in _DTPersonCode.Rows)
                //    {
                //        JRelationPersons PD = new JRelationPersons();
                //        JTable.SetToClassProperty(PD, DR);
                //        int index = DecissionlistBox.Items.Add(PD);
                //    }
                //}
                //} 
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void cdbSender_Leave(object sender, EventArgs e)
        {
            Fill_ListBox();   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cdbSender.SelectedItem["Code"]) == 0)
                    JMessages.Message(" فرستنده را انتخاب کنید ", "", JMessageType.Error);
                if (DecissionlistBox.SelectedItem == null)
                    JMessages.Message("گیرنده را انتخاب کنید", "", JMessageType.Error);

                foreach (object Item in DecissionlistBox.SelectedItems)
                {

                    JRelationPersons RP = new JRelationPersons();
                    RP.Code = Convert.ToInt32(((System.Data.DataRowView)(Item)).Row.ItemArray[0]);
                    //RP.Sender_Post_Code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                    //RP.Receiver_Post_Code = Convert.ToInt32(((System.Data.DataRowView)(Item)).Row.ItemArray[2]);                
                    if (RP.delete())
                        JMessages.Message(" Deleted Successfuly ", "", JMessageType.Error);
                    else
                        JMessages.Message(" Deleted Not Successfuly ", "", JMessageType.Error);
                }
                cdbSender_Leave(null, null);
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private bool CheckData()
        {
            try
            {
                if (Convert.ToInt32(cdbSender.SelectedItem["Code"]) == 0)
                {
                    JMessages.Message(" فرستنده را انتخاب کنید ", "", JMessageType.Error);
                    return false;
                }
                if (Convert.ToInt32(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"]) <= 0)
                {
                    JMessages.Message("گیرنده را انتخاب کنید", "", JMessageType.Error);
                    return false;
                }

                //for (int i = 0; i < DecissionlistBox.SelectedItems.Count; i++)
                //{
                //    JRelationPersons PU = (JRelationPersons)DecissionlistBox.SelectedItems[i];
                //    if (PU != null)
                //    {
                //        if (Convert.ToInt32(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"]) == PU.Code)
                //        {
                //            JMessages.Message(" فرد مورد نظر قبلا انتخاب شده است ", "", JMessageType.Error);
                //            return false;
                //        }
                //    }
                //}

                DataTable DT = new DataTable();
                DT = (new Employment.JEOrganizationChart()).GetOrgChart_User(Convert.ToInt32(cdbSender.SelectedItem["Code"]), "0", true);
                if (DT.Select(" Code=" + Convert.ToString(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"])).Length > 0)
                {
                    JMessages.Message(" فرد مورد نظر قبلا انتخاب شده است ", "", JMessageType.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData())                
                    return;                
                //if (dtvOrganizatinChart.SelectedItem == null)
                //    return;
                JRelationPersons RP = new JRelationPersons();
                RP.Sender_Post_Code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                RP.Receiver_Post_Code = Convert.ToInt32(((DataRow)(((System.Windows.Forms.TreeNode)(dtvOrganizatinChart.SelectedItem)).Tag))["code"]);
                if (RP.Insert() <= 0)
                    //JMessages.Message(" Save is Successfuly ", "", JMessageType.Information);
                //else
                    JMessages.Message(" Save Not successfuly ", "", JMessageType.Error);
                Fill_ListBox();
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
