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

namespace Automation
{
    public partial class JReferMain : Globals.JBaseForm
    {

        private int _ReferCode;
        private JARefer _Refer;
        private int _AutomationObjectCode;
        private int _ExternalObjectCode;
        private DataTable _dt;
        private bool _StatePersons;
        private bool _Single = false;
        private string _ClassName;
        private ClassLibrary.Domains.JAutomation.JObjectType _ObjectType;
        private string _Description;
        private string _Title;
        public bool isSendRefer = false;

        public bool Single
        {
            get
            {
                return _Single;
            }
            set
            {
                _Single = value;
                _dt.Rows.Clear();
            }
        }

        public JReferMain(int pReferCode,  DataTable dtPerson, bool StatePersons)
        {
            InitializeComponent();
            _StatePersons = StatePersons;
            _ReferCode = pReferCode;
            _Refer = new JARefer(_ReferCode);
            _AutomationObjectCode = _Refer.object_code;
            _SetInterface();
            GetPattern();
            if ((dtPerson != null) && (dtPerson.Rows.Count > 0))
                _FillPerson(dtPerson);

            jArchiveList1.ClassName = "Automation.JARefer";
            jArchiveList1.ObjectCode = pReferCode;
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.PlaceCode = 0;
            //if (pReferCode == 0)
            //    btnReturn.Enabled = false;
        }

        public JReferMain(string pClassName,
        int pExternalObject_Code, ClassLibrary.Domains.JAutomation.JObjectType pObjectType,
        string pDescription, string pTitle, DataTable dtPerson, bool StatePersons)
        {
            InitializeComponent();
            _StatePersons = StatePersons;
            if (pExternalObject_Code < 1)
                Close();

            _ClassName = pClassName;
            _ExternalObjectCode = pExternalObject_Code;
            _ObjectType = pObjectType;
            _Description =ClassLibrary.JLanguages._Text(pDescription);
            _Title = ClassLibrary.JLanguages._Text(pTitle);

            _Refer = new JARefer();
            _SetInterface();
            GetPattern();
            if ((dtPerson != null) && (dtPerson.Rows.Count > 0))
                _FillPerson(dtPerson);

            jArchiveList1.ClassName = "Automation.JARefer";
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.PlaceCode = 0;
        }

        private void GetPattern()
        {
            try
            {
                _dt = new DataTable();
                _dt.Columns.Add("receiver_post_code");
                _dt.Columns.Add("receiver_code");
                _dt.Columns.Add("receiver_full_title");
                _dt.Columns.Add("refertype");
                _dt.Columns.Add("refertype_Name");
                _dt.Columns.Add("respite_date_time");                
                _dt.Columns.Add("secret_level");
                _dt.Columns.Add("secret_level_Name");
                _dt.Columns.Add("urgency");
                _dt.Columns.Add("urgency_Name");
                _dt.Columns.Add("message");
                _dt.Columns.Add("message_secret");
                _dt.Columns.Add("description");

                jdgvRefer.DataSource = _dt;
                jdgvRefer.Columns["receiver_post_code"].Visible = false;
                jdgvRefer.Columns["receiver_code"].Visible = false;
                jdgvRefer.Columns["refertype"].Visible = false;
                jdgvRefer.Columns["secret_level"].Visible = false;
                jdgvRefer.Columns["urgency"].Visible = false;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private int RegisterArshive(int pReferCode)
        {
            try
            {
                jArchiveList1.ClassName = "Automation.JARefer";
                jArchiveList1.ObjectCode = pReferCode;
                jArchiveList1.SubjectCode = 0;
                jArchiveList1.PlaceCode = 0;
                return 1;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return 0;
            }
        }
        private void _FillPerson(DataTable dt)
        {
            try
            {
                //-------------- ارجاعات داخل سازمانی ----------
                cdbReferInternal.TitleFieldName = "full_title";
                cdbReferInternal.AccessCodeFieldName = "accesscode";
                cdbReferInternal.CodeFieldName = "code";
                cdbReferInternal.dataTable = dt;
                cdbReferInternal.SetComboBox();

                foreach (DataRow dr in dt.Rows)
                {
                    cdbReferInternal.cmbTitles.SelectedValue = Convert.ToInt32(dr["accesscode"].ToString());
                    //cdbReferInternal.txtCode.Text =  dr["Code"].ToString();
                    //if (Convert.ToInt32(dr["accesscode"].ToString()) != -1)
                    //    btnAddRefer_Click(null, null);
                }
                cdbReferInternal.cmbTitles.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }
        private void _SetInterface()
        {
            try
            {
                //-------------- ارجاعات داخل سازمانی ----------
                cdbReferInternal.TitleFieldName = "full_title";
                cdbReferInternal.AccessCodeFieldName = "accesscode";
                cdbReferInternal.CodeFieldName = "code";
                cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0", _StatePersons);
                //cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationChartsUser(0, JMainFrame.GetActiveChartCode());
                cdbReferInternal.SetComboBox();
                //-------------- ارجاعات خارج از سازمان ---------------
                cdbReferExternal.TitleFieldName = "full_title";
                cdbReferExternal.AccessCodeFieldName = "accesscode";
                cdbReferExternal.CodeFieldName = "code";
                cdbReferExternal.dataTable = (new ClassLibrary.JOrganizations()).GetOrganization(0); ;
                cdbReferExternal.SetComboBox();
                //----------------- انواع فوریت-----------------
                cmbUrgency.DisplayMember = "Farsiname";
                cmbUrgency.ValueMember = "value";
                cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;
                //----------------- انواع سطح محرمانگی-----------------
                cmbsecuritylevel.DisplayMember = "Farsiname";
                cmbsecuritylevel.ValueMember = "value";
                cmbsecuritylevel.DataSource = ClassLibrary.Domains.JGlobal.JPrivacy.GetData();
                cmbsecuritylevel.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;
                //----------------ارجاعات گذشته------------------------------
                //rchReferHistory.Lines = JARefers.GetReferTextHistory(_ReferCode).Split((char)13);
                //if (_ReferCode > 0)
                //    refersText1.LoadRefer(_ReferCode);
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void Btnsend_Click(object sender, EventArgs e)
        {
            SendRefer();
        }

        /// <summary>
        ///برای ارجاعات ارسالی کد ارجاع دریافتی را بر می گرداند
        /// </summary>
        /// <returns></returns>
        private int GetMainReferCode(int pReferCode)
        {
            JARefer _R = new JARefer(pReferCode);
            if (_R.GetData(_R.parent_code))
            {
                if (_R.receiver_post_code == JMainFrame.CurrentPostCode)
                {
                    return _R.Code;
                }
                else
                    if (_R.parent_code != 0)
                    {
                        GetMainReferCode(_R.parent_code);
                    }
            }
            return _ReferCode;
        }

        private void SendRefer()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {

                if (_dt.Rows.Count == 0)
                {
                    if ((cdbReferInternal.SelectedValue != null) && (Convert.ToInt32(cdbReferInternal.SelectedValue) != -1))
                    {
                        if (rchDesc.Text.Trim() == "")
                        {
                            JMessages.Error("لطفا توضیحات را وارد کنید.", "Error");
                            return;
                        }
                        btnAddRefer_Click(null, null);
                    }
                    else
                    {
                        JMessages.Error("Please Add One Refer", "Error");
                        return;
                    }
                }

                JARefer tmprefer = new JARefer();
                if (_AutomationObjectCode == 0)
                    _AutomationObjectCode = tmprefer.SendToAutomation(_ExternalObjectCode, _ObjectType, _Description, _Title, _ClassName, db,
                        JMainFrame.CurrentPostTitle,JMainFrame.CurrentPostCode,JMainFrame.CurrentUserCode,false);
                int Code = 0;
                tmprefer.parent_code = GetMainReferCode(_ReferCode);
                // در صورتیکه اولین بار ارجاع شود
                if (_Refer.object_code != 0)
                    tmprefer.object_code = _Refer.object_code;
                else
                    tmprefer.object_code = _AutomationObjectCode;
                //btnAddRefer_Click(null, null);
                foreach (DataRow dr in _dt.Rows)
                {
                    db.beginTransaction("ReferRegister");
                    //ارسال به داخل سازمان
                    //if (tbcReferType.TabPages[tbcReferType.SelectedIndex].Name == "tbpInternalrefer")
                    //{
                    tmprefer.receiver_post_code = Convert.ToInt32(dr["receiver_post_code"]);//Convert.ToInt32(cdbReferInternal.SelectedItem["code"]);
                    tmprefer.receiver_code = Convert.ToInt32(dr["receiver_code"]);//Convert.ToInt32(cdbReferInternal.SelectedItem["user_code"]);
                    tmprefer.receiver_full_title = dr["receiver_full_title"].ToString();//cdbReferInternal.SelectedItem["full_title"].ToString();
                    tmprefer.refertype = Convert.ToInt32(dr["refertype"]);//ClassLibrary.Domains.JAutomation.JReferType.Internal;
                    //}
                    //ارسال به خارج از سازمان
                    //else
                    //{
                    //    tmprefer.receiver_post_code = Convert.ToInt32(cdbReferExternal.SelectedItem["code"]);
                    //    tmprefer.receiver_code = Convert.ToInt32(cdbReferExternal.SelectedItem["user_code"]);
                    //    tmprefer.receiver_full_title = cdbReferExternal.SelectedItem["full_title"].ToString();
                    //    tmprefer.refertype = ClassLibrary.Domains.JAutomation.JReferType.External;
                    //}

                    tmprefer.task_code = 0;
                    // ارسال کننده
                    JUser user = new JUser(JMainFrame.CurrentUserCode);
                    tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
                    tmprefer.sender_code = JMainFrame.CurrentUserCode;
                    tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;

                    tmprefer.send_date_time = JMainFrame.GlobalDataBase.GetCurrentDateTime();
                    tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                    tmprefer.secret_level = Convert.ToInt32(dr["secret_level"]);//Convert.ToInt32(cmbsecuritylevel.SelectedValue);
                    tmprefer.is_active = true;

                    if ((dr["respite_date_time"] != "") && (Convert.ToDateTime(dr["respite_date_time"]) != DateTime.MinValue))
                        tmprefer.respite_date_time = JDateTime.GregorianDate(dr["respite_date_time"].ToString());
                    //if (!nedPersuit.EmptyDate)
                    //    tmprefer.respite_date_time = Convert.ToDateTime(nedPersuit.Text);

                    tmprefer.urgency = Convert.ToInt32(dr["urgency"]);//Convert.ToInt32(cmbUrgency.SelectedValue);
                    tmprefer.message = dr["message"].ToString();//txtNormalEmperise.Text.Trim();
                    tmprefer.message_secret = dr["message_secret"].ToString(); //txtSecretEmperise.Text.Trim();
                    tmprefer.description = dr["description"].ToString(); //rchDesc.Text;

                    tmprefer.register_user_code = JMainFrame.CurrentUserCode;
                    tmprefer.register_Date_Time = JMainFrame.GlobalDataBase.GetCurrentDateTime();

                    Code = tmprefer.Send(db);
                    if (Code > 0)
                    {
                        if (_ReferCode > 0)
                        {
                            _Refer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Sent;
                            if (_Refer.Save(db))
                            {
                                if (db.Commit())
                                {
                                    isSendRefer = true;
                                    jArchiveList1.ClassName = "Automation.JARefer";
                                    jArchiveList1.SubjectCode = 0;
                                    jArchiveList1.ObjectCode = Code;
                                    jArchiveList1.ArchiveList();

                                    JMessages.Message(JLanguages._Text("Send With Number ") + "  " + Code.ToString() + " " + JLanguages._Text("Successfuly"), "Send", JMessageType.Information);

                                    if ((JSystem.Nodes.CurrentNode != null) && (JSystem.Nodes.CurrentNode.ClassName == "Automation.JKartable"))
                                    {
                                        JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
                                    }


                                    //----Refresh Kartabl
                                    //JKartable tmp = new JKartable();
                                    //tmp.GetInBoxRefer();
                                }
                                else
                                {
                                    db.Rollback(db.TransactionName);
                                    JMessages.Message("Send Not Successfully", "", JMessageType.Error);
                                }
                            }
                            else
                            {
                                db.Rollback(db.TransactionName);
                                JMessages.Message("Send Not Successfully", "", JMessageType.Error);
                            }
                        }
                        else
                            if ((_ReferCode < 0) && (_AutomationObjectCode < 0))
                            {
                                db.Rollback(db.TransactionName);
                                JMessages.Message("Send Not Successfully", "", JMessageType.Information);
                            }
                            else
                                if (db.Commit())
                                {
                                    isSendRefer = true;
                                    jArchiveList1.ClassName = "Automation.JARefer";
                                    jArchiveList1.SubjectCode = 0;
                                    jArchiveList1.ObjectCode = Code;
                                    jArchiveList1.ArchiveList();

                                    JMessages.Message(JLanguages._Text("Send With Number ") + "  " + Code.ToString() + " " + JLanguages._Text("Successfuly"), "Send", JMessageType.Information);

                                    if ((JSystem.Nodes.CurrentNode != null) && (JSystem.Nodes.CurrentNode.ClassName == "Automation.JKartable"))
                                    {
                                        JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
                                    }
                                    //----Refresh Kartabl
                                    //JKartable tmp = new JKartable();
                                    //tmp.GetInBoxRefer();
                                }
                                else
                                    JMessages.Message("Send Not Successfully", "", JMessageType.Information);
                    }
                    else
                    {
                        db.Rollback(db.TransactionName);
                        JMessages.Message("Send Not Successfully", "", JMessageType.Information);
                    }
                }
                if (jdgvRefer.Rows.Count > 0)
                    this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }


        private void JReferMain_Load(object sender, EventArgs e)
        {
            try
            {
                JAEmprises tmp = new JAEmprises();
                //----------------- انواع ارسال برای گیرنده شرکت اقماری-----------------
                cmbEmprise.DisplayMember = "Description";
                cmbEmprise.ValueMember = "Code";
                cmbEmprise.DataSource = tmp.GetData(0);
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void cmbEmprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            rchDesc.Text = rchDesc.Text + cmbEmprise.SelectedText;
        }

        private void btnAddRefer_Click(object sender, EventArgs e)
        {
            if (rchDesc.Text.Trim() == "")
            {
                JMessages.Error("لطفا توضیحات را وارد کنید.", "Error");
                return;
            } 
            if (Single && _dt.Rows.Count == 1)
            {
                JMessages.Message("امکان ارسال پیشنویس به چند نفر وجود ندارد.", "Single Send", JMessageType.Error);
                return;
            }
            try
            {
                if ((cdbReferInternal.SelectedItem != null) || (cdbReferExternal.SelectedItem != null))
                {
                    if ((_dt.Rows.Count == 0) || ((_dt.Rows.Count > 0) && (_dt.Select("Receiver_Post_Code=" + cdbReferInternal.SelectedItem["code"].ToString()).Length < 1)))
                    {
                        DataRow dr = _dt.NewRow();
                        dr["receiver_post_code"] = Convert.ToInt32(cdbReferInternal.SelectedItem["code"]);
                        dr["receiver_code"] = Convert.ToInt32(cdbReferInternal.SelectedItem["user_code"]);
                        dr["receiver_full_title"] = cdbReferInternal.SelectedItem["full_title"].ToString();
                        dr["refertype"] = ClassLibrary.Domains.JAutomation.JReferType.Internal;
                        dr["refertype_Name"] = "داخلی";
                        dr["respite_date_time"] = JDateTime.FarsiDate(nedPersuit.Date);
                        dr["secret_level"] = Convert.ToInt32(cmbsecuritylevel.SelectedValue);
                        dr["secret_level_Name"] = cmbsecuritylevel.Text;
                        dr["urgency"] = Convert.ToInt32(cmbUrgency.SelectedValue);
                        dr["urgency_Name"] = cmbUrgency.Text;
                        dr["message"] = txtNormalEmperise.Text.Trim();
                        dr["message_secret"] = txtSecretEmperise.Text.Trim();
                        dr["description"] = rchDesc.Text;
                        _dt.Rows.Add(dr);
                        jdgvRefer.DataSource = _dt;
                    }
                }
                else
                    JMessages.Message("Please Select Person", "", JMessageType.Information);
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void btnDelRefer_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvRefer.CurrentRow != null)
                    jdgvRefer.Rows.Remove(jdgvRefer.CurrentRow);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (jdgvRefer.Rows.Count > 0)
            //    this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEmprise_Click(object sender, EventArgs e)
        {
            JEmpriseForm p = new JEmpriseForm();
            if (p.ShowDialog() == DialogResult.Yes)            
                txtSecretEmperise.Text = p._Title;            
        }

        private void btnEmprise1_Click(object sender, EventArgs e)
        {
            JEmpriseForm p = new JEmpriseForm();
            if (p.ShowDialog() == DialogResult.Yes)
                txtNormalEmperise.Text = p._Title;
        }

        private void JReferMain_Shown(object sender, EventArgs e)
        {
            cdbReferInternal.Focus();
        }
    }
}
