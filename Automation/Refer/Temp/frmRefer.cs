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
    public partial class JUC_Refer : UserControl
    {
        private DataTable _dtReferTemp;
        public JUC_Refer()
        {
            InitializeComponent();
            JARefer refer = new JARefer();
            //_dtReferTemp = refer.GetDataTablePatern().Copy();
            grdRefers.Bind(_dtReferTemp.Copy(), "Refer");
            _SetComboBoxs();
        }

        //public void frmRefer_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    {
        //        tbcReferType.SelectedTab = tbpInternalrefer;
        //    }
        //    else if (e.KeyCode == Keys.F2)
        //    {
        //        tbcReferType.SelectedTab = tbpExternalrefer;
        //    }
        //    else if (e.KeyCode == Keys.F3)
        //    {
        //        tbcReferType.SelectedTab = tbpSubsidiariesRefer;
        //    }

        //}
        private void _SetComboBoxs()
        {
            //-------------- ارجاعات داخل سازمانی ----------
            cdbReferInternal.TitleFieldName = "full_title";
            cdbReferInternal.AccessCodeFieldName = "accesscode";
            cdbReferInternal.CodeFieldName = "code";
            cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, 5);
            cdbReferInternal.SetComboBox();
            //-------------- ارجاعات خارج از سازمان ---------------
            cdbReferExternal.TitleFieldName = "full_title";
            cdbReferExternal.AccessCodeFieldName = "access_code";
            cdbReferExternal.CodeFieldName = "code";
            cdbReferExternal.dataTable = (new ClassLibrary.JOrganizations()).GetOrganization(0); ;
            cdbReferExternal.SetComboBox();
            //-------------- ارجاعات به شرکت های اقماری ---------------
            cdbReferSubsidiaries.TitleFieldName = "full_title";
            cdbReferSubsidiaries.AccessCodeFieldName = "access_code";
            cdbReferSubsidiaries.CodeFieldName = "code";
            cdbReferSubsidiaries.dataTable = (new JASubsidiariess()).GetAllSubsidiaries();
            cdbReferSubsidiaries.SetComboBox();
            //----------------- انواع ارسال برای گیرنده سازمان خارج از لیست-----------------
            cmbSendTypeExternal.DisplayMember = "name";
            cmbSendTypeExternal.ValueMember = "value";
            cmbSendTypeExternal.DataSource = ClassLibrary.Domains.JCommunication.JSendType.GetData();            
            cmbSendTypeExternal.SelectedValue = ClassLibrary.Domains.JCommunication.JSendType.Email;
            //----------------- انواع ارسال برای گیرنده شرکت اقماری-----------------
            cmbSendTypeSubsidiaries.DisplayMember = "name";
            cmbSendTypeSubsidiaries.ValueMember = "value";
            cmbSendTypeSubsidiaries.DataSource = ClassLibrary.Domains.JCommunication.JSendType.GetData();
            cmbSendTypeSubsidiaries.SelectedValue = ClassLibrary.Domains.JCommunication.JSendType.Email;
            //----------------- انواع فوریت-----------------
            cmbUrgency.DisplayMember = "name";
            cmbUrgency.ValueMember = "value";
            cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
            cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
            Org.ViewMode = true;
            Org.CheckBoxMode = true;
            if (Org.ShowDialog() == DialogResult.OK)
            {
                //-------------- ارجاعات داخل سازمانی ----------
                cdbReferInternal.TitleFieldName = "full_title";
                cdbReferInternal.AccessCodeFieldName = "accesscode";
                cdbReferInternal.CodeFieldName = "code";
                cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, 5);
                cdbReferInternal.SetComboBox();
                if (Org.SelectedItem == null)
                {
                    lblGroupRefer.Text = JLanguages._Text("Group Refer Is Active");
                    for (int i = 0; i < Org.SelectedItems.Length; i++)
                    {
                        _dtReferTemp = ReferAdd(_dtReferTemp, Convert.ToInt32(Org.SelectedItems[i]["code"]),
                                                 ClassLibrary.Domains.JAutomation.JReferType.Internal,
                                                 Convert.ToInt32(cmbUrgency.SelectedValue),
                                                 Org.SelectedItems[i]["full_title"].ToString(),
                                                 nedPersuit.Text,
                                                 txtNormalEmperise.Text.Trim(),
                                                 txtSecretEmperise.Text.Trim(),
                                                 ClassLibrary.Domains.JCommunication.JSendType.Automation
                                               );
                    }
                }
                else
                {
                    _dtReferTemp = ReferAdd(_dtReferTemp, Convert.ToInt32(Org.SelectedItem["code"]),
                                             ClassLibrary.Domains.JAutomation.JReferType.Internal,
                                             Convert.ToInt32(cmbUrgency.SelectedValue),
                                             Org.SelectedItem["full_title"].ToString(),
                                             nedPersuit.Text,
                                             txtNormalEmperise.Text.Trim(),
                                             txtSecretEmperise.Text.Trim(),
                                             ClassLibrary.Domains.JCommunication.JSendType.Automation
                                           );
                    cdbReferInternal.SetValue(Org.SelectedItem["accesscode"]);
                }
            }
            Org.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             JfrmOrganizatins jorg = new JfrmOrganizatins();
             jorg.MultiSelect = true;
            if (jorg.ShowDialog() == DialogResult.OK)
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbReferExternal.AccessCodeFieldName = "access_code";
                cdbReferExternal.TitleFieldName = "full_title";
                cdbReferExternal.CodeFieldName = "code";
                cdbReferExternal.dataTable = (new JOrganizations()).GetOrganization(0);
                cdbReferExternal.SetComboBox();
                if (jorg.SelectedRows != null)
                {
                    for (int i = 0; i < jorg.SelectedRows.Count; i++)
                    {
                        _dtReferTemp = ReferAdd(_dtReferTemp, Convert.ToInt32(jorg.SelectedRows[i].Cells["code"]),
                                                 ClassLibrary.Domains.JAutomation.JReferType.External,
                                                 Convert.ToInt32(cmbUrgency.SelectedValue),
                                                 jorg.SelectedRows[i].Cells["full_title"].ToString(),
                                                 nedPersuit.Text,
                                                 txtNormalEmperise.Text.Trim(),
                                                 txtSecretEmperise.Text.Trim(),
                                                 ClassLibrary.Domains.JCommunication.JSendType.Automation
                                               );
                    }
                }
                if ( jorg.SelectedRow != null)
                   cdbReferExternal.SetValue(jorg.SelectedRow.Cells["access_code"]);

            }
            jorg.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersuit.Checked)
            {
                nedPersuit.Enabled = true;
                nedPersuit.Focus();
            }
            else
            {
                nedPersuit.Text = "";
                nedPersuit.Enabled = false;
            }
        }



        private void btnReferAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (tbcReferType.TabPages[tbcReferType.SelectedIndex].Name == "tbpInternalrefer")
            {
                if (_dtReferTemp != null && _dtReferTemp.Rows.Count > 0)
                {
                    dt = _dtReferTemp.Copy();
                    dt.Merge(grdRefers.DataSource);
                    grdRefers.Bind(dt.Copy(), "Refer");
                    _dtReferTemp.Rows.Clear();
                }

                dt.Rows.Clear();
                if (cdbReferInternal.SelectedItem != null)
                {
                    dt = ReferAdd( grdRefers.DataSource,
                                   Convert.ToInt32(cdbReferInternal.SelectedItem["code"]),
                                   ClassLibrary.Domains.JAutomation.JReferType.Internal,
                                   Convert.ToInt32(cmbUrgency.SelectedValue),
                                   cdbReferInternal.SelectedItem["full_title"].ToString(),
                                   nedPersuit.Text,
                                   txtNormalEmperise.Text.Trim(),
                                   txtSecretEmperise.Text.Trim(),
                                   ClassLibrary.Domains.JCommunication.JSendType.Automation
                            );
                    grdRefers.Bind(dt.Copy(), "Refer");
                    
                }

            }
            else if (tbcReferType.TabPages[tbcReferType.SelectedIndex].Name == "tbpExternalrefer")
            {
                if (_dtReferTemp != null && _dtReferTemp.Rows.Count > 0)
                {
                    dt = _dtReferTemp.Copy();
                    dt.Merge(grdRefers.DataSource);
                    grdRefers.Bind(dt.Copy(), "Refer");
                    _dtReferTemp.Rows.Clear();
                }
                dt.Rows.Clear();
                if (cdbReferExternal.SelectedItem != null)
                {
                    dt = ReferAdd(grdRefers.DataSource,
                                   Convert.ToInt32(cdbReferExternal.SelectedItem["code"]),
                                   ClassLibrary.Domains.JAutomation.JReferType.External,
                                   Convert.ToInt32(cmbUrgency.SelectedValue),
                                   cdbReferExternal.SelectedItem["full_title"].ToString(),
                                   nedPersuit.Text,
                                   txtNormalEmperise.Text.Trim(),
                                   txtSecretEmperise.Text.Trim(),
                                   Convert.ToInt32(cmbSendTypeExternal.SelectedValue)
                            );
                    grdRefers.Bind(dt.Copy(), "Refer");
                    
                }
            }
            else if (tbcReferType.TabPages[tbcReferType.SelectedIndex].Name == "tbpSubsidiariesRefer")
            {
                dt.Rows.Clear();
                if (cdbReferSubsidiaries.SelectedItem != null)
                {
                    dt = ReferAdd(grdRefers.DataSource,
                                   Convert.ToInt32(cdbReferSubsidiaries.SelectedItem["code"]),
                                   ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries,
                                   Convert.ToInt32(cmbUrgency.SelectedValue),
                                   cdbReferSubsidiaries.SelectedItem["full_title"].ToString(),
                                   nedPersuit.Text,
                                   txtNormalEmperise.Text.Trim(),
                                   txtSecretEmperise.Text.Trim(),
                                   Convert.ToInt32(cmbSendTypeSubsidiaries.SelectedValue)
                            );
                    grdRefers.Bind(dt.Copy(), "Refer");
                    
                }
            }
        }

        private DataTable ReferAdd( DataTable pDT,
                                    int pReceiverCode ,
                                    int pReferType,
                                    int pUrgency,
                                    string pReceiverFullTitle,
                                    string pPersuit,
                                    string pNormalEmperise,
                                    string pSecretEmperise,
                                    int pSendType
                             )
        {
            DataRow dr;
            DataTable dt = new DataTable();
            dt = grdRefers.DataSource.Copy();
            dt.Merge(pDT.Copy());
            int MaxCode = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["code"]) > MaxCode)
                {
                    MaxCode = Convert.ToInt32(dt.Rows[i]["code"]);
                }
            }
            dr = pDT.NewRow();
            dr["code"] = (MaxCode+1);
            dr["receiver_code"] = pReceiverCode;
            dr["refer_type"] = pReferType;
            dr["urgency"] = pUrgency;
            dr["receiver_full_title"] = pReceiverFullTitle;
            dr["persuit"] = pPersuit;
            dr["normal_emprise"] = pNormalEmperise;
            dr["secret_emprise"] = pSecretEmperise;
            dr["send_type"] = pSendType;
            dr["refer_date_time"] = JMainFrame.GlobalDataBase.GetCurrentDateTime();
            //---------------------Refer Type--------------------------
            if (pReferType == ClassLibrary.Domains.JAutomation.JReferType.Internal)
            {
                dr["refer_type_title"] =  JLanguages._Text("Internal");
            }
            else if (pReferType == ClassLibrary.Domains.JAutomation.JReferType.External)
            {
                dr["refer_type_title"] = JLanguages._Text("External");
            }
            else if (pReferType == ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries)
            {
                dr["refer_type_title"] = JLanguages._Text("Subsidiaries");
            }
            //---------------------Urgency Type--------------------------
            if (pUrgency == ClassLibrary.Domains.JGlobal.JUrgency.Normal)
            {
                    dr["urgency_title"] = JLanguages._Text("Normal");
            }
            else if (pUrgency == ClassLibrary.Domains.JGlobal.JUrgency.Quick)
            {
                    dr["urgency_title"] = JLanguages._Text("Quick");                   
            }
            else if (pUrgency == ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick)
            {
                    dr["urgency_title"] = JLanguages._Text("VeryQuick");
            }
            //------------------- Send Type ------------------------------
            if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.Automation)
            {
                dr["send_type_title"] = JLanguages._Text("Automation");
            }
            else if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.Email)
            {
                dr["send_type_title"] = JLanguages._Text("Email");
            }
            else if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.ECE)
            {
                dr["send_type_title"] = JLanguages._Text("ECE");
            }
            else if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.Fax)
            {
                dr["send_type_title"] = JLanguages._Text("Fax");
            }
            else if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.Messenger)
            {
                dr["send_type_title"] = JLanguages._Text("Messenger");
            }
            else if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.Server)
            {
                dr["send_type_title"] = JLanguages._Text("Server");
            }
            else if (pSendType == ClassLibrary.Domains.JCommunication.JSendType.SMS)
            {
                dr["send_type_title"] = JLanguages._Text("SMS");
            }

            pDT.Rows.Add(dr);
            return pDT;
        }

        private void grdRefers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRefers.SelectedRow != null)
                {

                    if (tbcReferType.TabPages[tbcReferType.TabIndex].Name == "tbpInternalrefer")
                    {
                         _dtReferTemp.Rows.Clear();
                        cdbReferInternal.SetValue(grdRefers.SelectedRow.Cells["code"].Value);
                    }
                    else if (tbcReferType.TabPages[tbcReferType.TabIndex].Name == "tbpExternalrefer")
                    {
                        _dtReferTemp.Rows.Clear();
                        cdbReferExternal.SetValue(grdRefers.SelectedRow.Cells["code"].Value);
                    }
                    else if (tbcReferType.TabPages[tbcReferType.TabIndex].Name == "tbpSubsidiariesRefer")
                    {
                        cdbReferSubsidiaries.SetValue(grdRefers.SelectedRow.Cells["code"].Value);                   
                    }

                    txtNormalEmperise.Text = grdRefers.SelectedRow.Cells["normal_emprise"].ToString();
                    txtSecretEmperise.Text = grdRefers.SelectedRow.Cells["secret_emprise"].ToString();
                    if (grdRefers.SelectedRow.Cells["persuit"].ToString() != null && grdRefers.SelectedRow.Cells["persuit"].ToString() != "")
                    {
                        chkPersuit.Checked = true;
                        nedPersuit.Text = grdRefers.SelectedRow.Cells["persuit"].ToString();
                    }
                    else
                    {
                        chkPersuit.Checked = false;
                        nedPersuit.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnReferRemove_Click(object sender, EventArgs e)
        {
            grdRefers.RemoveSelectedRows();
        }
    }
}
