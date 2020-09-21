using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Communication
{
    public partial class JUC_Copy : UserControl
    {
        #region properties
        private DataTable _dtCopyTemp;
        public int Sender_Post_Code;
        public int Receiver_Post_Code;
        #endregion properties

        #region Constructors
        public JUC_Copy()
        {
            InitializeComponent();
            if (!this.DesignMode && grdCopy.Visible)
            {
            }
        }
        #endregion Constructors

        #region MyFunctions
        /// <summary>
        /// مقدار دهی اولیه لیست های موجود در فرم
        /// </summary>
        public void Initialize()
        {
            JCLetterCopy copy = new JCLetterCopy();
            _dtCopyTemp = copy.GetDataTablePatern().Copy();
            grdCopy.DataSource = _dtCopyTemp.Copy();
            grdCopy.gridEX1.Tables[0].Columns["RecieverText"].Visible = false;
            grdCopy.HidColumns(
                ("Letter_Code;receiver_post_code;receiver_user_code;receiver_external_code;receiver_subsidiaries_code;register_post_code;register_user_code;copy_type;send_type;is_new;register_full_title;is_deleted;deleted_user_post;deleted_user_code;deleted_user_full_title").Split(new char[] { ';' })
                );
            grdCopy.gridEX1.Enabled = false;
            _SetComboBoxs(0, ClassLibrary.Domains.JCommunication.JLetterType.Internal);
        }

        public void _SetComboBoxs(int pCode, int pState)
        {
            if (DesignMode) return;
            //-------------- ارجاعات داخل سازمانی ----------
            cdbCopyInternal.TitleFieldName = "full_title";
            cdbCopyInternal.AccessCodeFieldName = "accesscode";
            cdbCopyInternal.CodeFieldName = "Code";
            //if (pState == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                //cdbCopyInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(pCode, "0");
            //else
            cdbCopyInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
                //(new Employment.JEOrganizationChart()).GetOrganizationCharts(0, new Employment.JECharts().GetActiveChartCode());
            cdbCopyInternal.SetComboBox();

            //-------------- ارجاعات خارج از سازمان ---------------
            //cdbCopyExternal.TitleFieldName = "full_title";
            //cdbCopyExternal.AccessCodeFieldName = "accesscode";
            //cdbCopyExternal.CodeFieldName = "Code";
            //cdbCopyExternal.dataTable = (new ClassLibrary.JOrganizations()).GetOrganization(0); ;
            //cdbCopyExternal.SetComboBox();


            cdbCopyExternal.TitleFieldName = "Full_Title";
            cdbCopyExternal.AccessCodeFieldName = "code";
            cdbCopyExternal.CodeFieldName = "code";
            cdbCopyExternal.dataTable = JAllPerson.GetDataContractPerson(0, "", -1, JPersonTypes.None, "");
            cdbCopyExternal.SetComboBox();
            //----------------- انواع ارسال برای گیرنده سازمان خارج از لیست-----------------
            cmbSendTypeExternal.DisplayMember = "Farsiname";
            cmbSendTypeExternal.ValueMember = "value";
            cmbSendTypeExternal.DataSource = ClassLibrary.Domains.JCommunication.JSendType.GetData();            
            cmbSendTypeExternal.SelectedValue = ClassLibrary.Domains.JCommunication.JSendType.Email;
            //----------------- انواع ارسال برای گیرنده شرکت اقماری-----------------
            txtCopyReasonInternal.DisplayMember = "name";
            txtCopyReasonInternal.ValueMember = "code";
            //dt = (new JRecieveTypeDefine()).GetList();
            //dr = dt.NewRow();
            //dr["code"] = "-1";
            //dr["name"] = "-----------";
            //dt.Rows.InsertAt(dr, 0);
            txtCopyReasonInternal.DataSource = (new JCopyType()).GetList();

            txtCopyReasonExternal.DisplayMember = "name";
            txtCopyReasonExternal.ValueMember = "code";
            txtCopyReasonExternal.DataSource = (new JCopyType()).GetList();             
        }

        /// <summary>
        /// افزودن رونوشت به لیست رونوشت ها
        /// </summary>
        /// <param name="pDT">جدولی که باید به آن اضافه شود</param>
        /// <param name="pReceiverCode">کد گیرنده</param>
        /// <param name="pCopyType">نوع رونوشت  داخلی-خارجی-شرکت اقماری</param>
        /// <param name="pReceiverFullTitle">عنوان گیرنده</param>
        /// <param name="pCopyReason">علت رونوشت</param>
        /// <param name="pSendType">نحوه ارسال</param>
        /// <returns>لیست رونوشت های ثبت شده</returns>
        private DataTable CopyAdd(DataTable pDT, 
                            int pReceiverCode,
                            int pCopyType,
                            string pReceiverFullTitle, string pRecieverText,
                            string pCopyReason,
                            int pSendType,
                            string pRespite_date_time
                     )
        {
            try
            {
                if (DesignMode) return null;
                DataRow dr;
                //pDT = grdCopy.DataSource.Copy();

                int MaxCode = 0;
                for (int i = 0; i < pDT.Rows.Count; i++)
                {
                    if (Convert.ToInt32(pDT.Rows[i]["Code"]) > MaxCode)
                    {
                        MaxCode = Convert.ToInt32(pDT.Rows[i]["Code"]);
                    }
                }
                dr = pDT.NewRow();
                dr["Code"] = (MaxCode + 1);
                if (pCopyType == ClassLibrary.Domains.JAutomation.JReferType.Internal)
                {
                    dr["receiver_post_code"] = pReceiverCode;
                    dr["receiver_user_code"] = (new Employment.JEOrganizationChart(pReceiverCode)).user_code;
                }
                else if (pCopyType == ClassLibrary.Domains.JAutomation.JReferType.External)
                {
                    dr["receiver_external_code"] = pReceiverCode;
                }
                //else if (pCopyType == ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries)
                //{
                //    dr["receiver_subsidiaries_code"] = pReceiverCode;
                //}
                dr["receiver_full_title"] = pReceiverFullTitle;
                dr["RecieverText"] = pRecieverText;
                if (pRespite_date_time != "    /  /")
                {
                    dr["respite_date_time"] = (pRespite_date_time);//JDateTime.GregorianDate
                    //dr["RDate"] = pRespite_date_time;
                }
                dr["copy_type"] = pCopyType;
                dr["copy_reason"] = pCopyReason;
                dr["send_type"] = pSendType;
                //---------------------Copy Type--------------------------
                if (pCopyType == ClassLibrary.Domains.JAutomation.JReferType.Internal)
                {
                    dr["copy_type_title"] = JLanguages._Text("Internal");
                }
                else if (pCopyType == ClassLibrary.Domains.JAutomation.JReferType.External)
                {
                    dr["copy_type_title"] = JLanguages._Text("External");
                }
                //else if (pCopyType == ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries)
                //{
                //    dr["copy_type_title"] = JLanguages._Text("Subsidiaries");
                //}
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
                dr["is_new"] = true;
                pDT.Rows.Add(dr);
                return pDT;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }

        /// <summary>
        /// حذف رونوشت هایی که قبلا وجود داشته و مجدد تقاضای ثبت آنها صادر گردیده است
        /// </summary>
        /// <param name="dtSource">رونشت های ثبت شده</param>
        /// <param name="dtNewAndPreviuse"> رو نوشت هایی متقاضی ثبت و ثبت شده های قبلی</param>
        /// <returns></returns>
        private DataTable RemoveRepeters(DataTable dtSource, DataTable dtNewAndPreviuse)
        {
            if (DesignMode) return null;
            DataTable dt = new DataTable();
            dt = dtSource.Copy();

            try
            {
                 for (int i = 0; i < dtNewAndPreviuse.Rows.Count; i++)
                {
                    bool Exist = false;
                    for (int j = 0; j < dtSource.Rows.Count; j++)
                    {
                        
                        // ---------------------------- بررسی وجود یک رکورد رونوشت در رونوشت های ثبت شده قبلی جهت جلوگیری ار تکرار ثبت رونوشت ------------------
                        if (dtSource.Rows[j]["copy_type"].ToString() == dtNewAndPreviuse.Rows[i]["copy_type"].ToString() )
                        {                            
                            if (Convert.ToInt32(dtSource.Rows[j]["copy_type"]) == ClassLibrary.Domains.JAutomation.JReferType.Internal &&
                                 dtSource.Rows[j]["receiver_user_code"].ToString() == dtNewAndPreviuse.Rows[i]["receiver_user_code"].ToString() &&
                                dtSource.Rows[j]["receiver_post_code"].ToString() == dtNewAndPreviuse.Rows[i]["receiver_post_code"].ToString())
                            {
                                Exist = true;
                                break;
                            }
                            else if (Convert.ToInt32(dtSource.Rows[j]["copy_type"]) == ClassLibrary.Domains.JAutomation.JReferType.External &&
                                 dtSource.Rows[j]["receiver_external_code"].ToString() == dtNewAndPreviuse.Rows[i]["receiver_external_code"].ToString())
                            {
                                Exist = true;
                                break;
                            }
                            else if (Convert.ToInt32(dtSource.Rows[j]["copy_type"]) == ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries &&
                                 dtSource.Rows[j]["receiver_subsidiaries_code"].ToString() == dtNewAndPreviuse.Rows[i]["receiver_subsidiaries_code"].ToString())
                            {
                                Exist = true;
                                break;
                            }
                        }
                    }
                    if (!Exist)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < dr.Table.Columns.Count; j++)
                        {
                            dr[j] = dtNewAndPreviuse.Rows[i][j];
                        }                         
                        dt.Rows.Add(dr);
                    }

                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

            return dt;
        }
        /// <summary>
        /// تنظیم کنترل بر اساس رونوشت هاتی یک نامه خاص
        /// </summary>
        /// <param name="pLetterCode"></param>
        public void SetData(int pLetterCode)
        {
            if (DesignMode) return ;
            JCLetterCopys JLC = new JCLetterCopys();
            DataTable dt = JLC.GetCopys(pLetterCode);
            if (dt != null)
            {
                dt.Columns.Add("is_new", typeof(bool));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["is_new"] = false;
                }
                grdCopy.DataSource = dt;
            }
        }
        #endregion MyFunctions

        /// <summary>
        /// رویداد پس از افزودن رونوشت
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void CopyAdded(object Sender, EventArgs e);
        public event CopyAdded AfterCopyAdded;

        /// <summary>
        /// فرم انتخاب از چارت سازمانی جهت انتخاب بصورت درختی و چند تایی
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
            Org.ViewMode = true;
            Org.CheckBoxMode = true;
            if (_dtCopyTemp != null)
                _dtCopyTemp.Rows.Clear();

            if (grdCopy.DataSource != null)
                _dtCopyTemp = grdCopy.DataSource.Copy();
            
            if (Org.ShowDialog() == DialogResult.OK)
            {
                //-------------- ارجاعات داخل سازمانی ----------
                cdbCopyInternal.TitleFieldName = "full_title";
                cdbCopyInternal.AccessCodeFieldName = "accesscode";
                cdbCopyInternal.CodeFieldName = "Code";
                cdbCopyInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
                    //(new Employment.JEOrganizationChart()).GetOrganizationCharts(0, 5);
                cdbCopyInternal.SetComboBox();
                if (Org.SelectedItem == null)
                {
                    for (int i = 0; i < Org.SelectedItems.Length; i++)
                    {
                        _dtCopyTemp = CopyAdd(_dtCopyTemp,Convert.ToInt32(Org.SelectedItems[i]["Code"]),
                                                 ClassLibrary.Domains.JAutomation.JReferType.Internal,
                                                 Org.SelectedItems[i]["full_title"].ToString(), Org.SelectedItems[i]["RecieverText"].ToString(),
                                                 txtCopyReasonInternal.Text.Trim(),
                                                 ClassLibrary.Domains.JCommunication.JSendType.Automation,
                                                 txtPersuitInternal.Text
                                               );
                    }
                }
                else
                {
                    cdbCopyInternal.SetValue(Org.SelectedItem["accesscode"]);
                }
            }
            Org.Dispose();
        }
        /// <summary>
        /// بر می گرداند datatable این تابع مشخصات رونوشت ها را بصورت  
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetData()
        {
            if (DesignMode) return null;
            return grdCopy.DataSource;
        }
        /// <summary>
        /// فرم انتخاب از سازمان ها جهت انتخاب بصورت جدول و چند تایی
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            if (!(JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirmExports", 0, Sender_Post_Code, true)))
                return;

            JFindPersonForm jorg = new JFindPersonForm();
             //jorg.MultiSelect = true;
             if (_dtCopyTemp != null)
                _dtCopyTemp.Rows.Clear();
            if(grdCopy!=null)
                _dtCopyTemp = grdCopy.DataSource.Copy();

            if (jorg.ShowDialog() == DialogResult.OK)
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbCopyExternal.TitleFieldName = "Full_Title";
                cdbCopyExternal.AccessCodeFieldName = "code";
                cdbCopyExternal.CodeFieldName = "code";

                cdbCopyExternal.dataTable = JAllPerson.GetDataContractPerson(0, "", -1, JPersonTypes.None, "");
                cdbCopyExternal.SetComboBox();

                //cdbCopyExternal.AccessCodeFieldName = "access_code";
                //cdbCopyExternal.TitleFieldName = "full_title";
                //cdbCopyExternal.CodeFieldName = "Code";
                //cdbCopyExternal.dataTable = (new JOrganizations()).GetOrganization(0);
                //cdbCopyExternal.SetComboBox();
                if (jorg.SelectedPerson != null)
                //if (jorg.SelectedRows != null)
                {
                    //for (int i = 0; i < jorg.SelectedRows.Count; i++)
                    {
                        _dtCopyTemp = CopyAdd(_dtCopyTemp, Convert.ToInt32(jorg.SelectedPerson.Code),
                                                 ClassLibrary.Domains.JAutomation.JReferType.External,
                                                 jorg.SelectedPerson.Name,  jorg.SelectedPerson.Name, 
                                                 txtCopyReasonInternal.Text.Trim(),
                                                 ClassLibrary.Domains.JCommunication.JSendType.Automation,
                                                 txtPersuitExternal.Text
                                               );
                    }
                }
                if (jorg.SelectedPerson != null)
                    cdbCopyExternal.SetValue(jorg.SelectedPerson.Code);

            }
            jorg.Dispose();
        }

        /// <summary>
        /// حذف رونوشت های انتخاب شده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferRemove_Click(object sender, EventArgs e)
        {
            grdCopy.RemoveSelectedRows();
        }

         /// <summary>
         ///  مقدار دهی اولیه در هنگام بالا آمدن فرم
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void JUC_Copy_Load(object sender, EventArgs e)
        {
            pnlCopy.Height = 0;
            grdCopy.Visible = true;
            grdCopy.Height = grdCopy.Height + 150 ;
            //grdCopy.DataSource.Columns.Remove("respite_date_time");
        }

        public void Clear()
        {
            //grdCopy.DataSource = null;
            _dtCopyTemp.Rows.Clear();
            grdCopy.DataSource.Rows.Clear();
        }
        /// <summary>
        /// انتخاب داخل سازمان برای رونوشت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void internalCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCopy.Height = 100;
            pnlInternalCrt.Visible = true;
            pnlExternalCtr.Visible = false;
            //pnlSubsidiariesCtr.Visible = false;
        }

        /// <summary>
        /// انتخاب سازمان های خارج از سازمان برای رونوشت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void externalCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirmExports", 0, Sender_Post_Code, true)))
                return;
            pnlCopy.Height = pnlExternalCtr.Height;
            pnlInternalCrt.Visible = false;
            pnlExternalCtr.Visible = true;
            //pnlSubsidiariesCtr.Visible = false;
        }

        /// <summary>
        /// انتخاب شرکت اقماری برای رونوشت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToSubsidiariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pnlCopy.Height = 125;
            //pnlInternalCrt.Visible = false;
            //pnlExternalCtr.Visible = false;
            //pnlSubsidiariesCtr.Visible = true;
        }

        /// <summary>
        /// افزودن رونوشت به افراد موجود در چارت سازمانی که کاربر سیستم هستند
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cdbCopyInternal.SelectedItem["Code"]) == Receiver_Post_Code||
                Convert.ToInt32(this.cdbCopyInternal.SelectedItem["Code"]) == Sender_Post_Code)
            {
                JMessages.Error("گیرنده رونوشت نمیتواند فرستنده یا گیرنده باشد.", "Error");
                cdbCopyInternal.Focus();
                return;
            }

            //-------------------------------------------------------
            if (cdbCopyInternal.SelectedItem == null && (_dtCopyTemp == null || _dtCopyTemp.Rows.Count == 0))
            {
                JMessages.Message(JLanguages._Text("Enter Rceiver of Copy"), JLanguages._Text("Error"), JMessageType.Error);
                cdbCopyInternal.Focus();
                return;
            }

            if (txtCopyReasonInternal.Text.Trim() == "")
            {
                JMessages.Message(JLanguages._Text("Enter Reason of Copy"), JLanguages._Text("Error"), JMessageType.Error);
                txtCopyReasonInternal.Text = "";
                txtCopyReasonInternal.Focus();
                return;
            }
            //------------------------------------------------
            DataTable dt = new DataTable();
            if (_dtCopyTemp != null && _dtCopyTemp.Rows.Count > 0)
            {
                dt = _dtCopyTemp.Copy();
                dt.Merge(grdCopy.DataSource);
                grdCopy.DataSource = RemoveRepeters(grdCopy.DataSource, dt);
                _dtCopyTemp.Rows.Clear();
                cdbCopyInternal.Focus();
            }

            dt.Rows.Clear();
            if (cdbCopyInternal.SelectedItem != null)
            {
                dt = CopyAdd(grdCopy.DataSource.Copy(),
                             Convert.ToInt32(cdbCopyInternal.SelectedItem["Code"]),
                             ClassLibrary.Domains.JAutomation.JReferType.Internal,
                             cdbCopyInternal.SelectedItem["full_title"].ToString(), cdbCopyInternal.SelectedItem["Title"].ToString() + " محترم " + cdbCopyInternal.SelectedItem["Name"].ToString() + " " + txtCopyReasonInternal.Text,
                             txtCopyReasonInternal.Text.Trim(),
                             ClassLibrary.Domains.JCommunication.JSendType.Automation,
                             txtPersuitInternal.Text
                             );

                grdCopy.DataSource = RemoveRepeters(grdCopy.DataSource, dt);
                cdbCopyInternal.Focus();
            }

            if (AfterCopyAdded != null)
                AfterCopyAdded(sender, e);
        }

        /// <summary>
        /// افزودن رونوشت به خارج از سازمان
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (Sender_Post_Code == 0)
            {
                JMessages.Message(" ابتدا فرستنده را انتخاب کنید ", "", JMessageType.Error);
                return;
            }
            if (!(JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirmExports", 0, Sender_Post_Code, true)))
                return;

            //-------------------------------------------------------
            if ((cdbCopyExternal.SelectedItem == null && (_dtCopyTemp == null || _dtCopyTemp.Rows.Count == 0))&& txtCopyExternalFullName.Text.Length <1)
            {
                JMessages.Message(JLanguages._Text("Enter Rceiver of Copy"), JLanguages._Text("Error"), JMessageType.Error);
                cdbCopyExternal.Focus();
                return;
            } 
            
            if (cmbSendTypeExternal.SelectedItem == null)
            {
                JMessages.Message(JLanguages._Text("Enter SendType of Copy"), JLanguages._Text("Error"), JMessageType.Error);
                cmbSendTypeExternal.Focus();
                return;
            }
            
            if (txtCopyReasonExternal.Text.Trim() == "")
            {
                JMessages.Message(JLanguages._Text("Enter Reason of Copy"), JLanguages._Text("Error"), JMessageType.Error);
                txtCopyReasonExternal.Text = "";
                txtCopyReasonExternal.Focus();
                return;
            }
            //------------------------------------------------
            DataTable dt = new DataTable();

            if (_dtCopyTemp != null && _dtCopyTemp.Rows.Count > 0)
            {
                dt = _dtCopyTemp.Copy();
                dt.Merge(grdCopy.DataSource);
                grdCopy.DataSource = RemoveRepeters(grdCopy.DataSource, dt);
                _dtCopyTemp.Rows.Clear();
            }
            dt.Rows.Clear();
            if (cdbCopyExternal.SelectedItem != null)
            {
                dt = CopyAdd(grdCopy.DataSource.Copy(),
                             Convert.ToInt32(cdbCopyExternal.SelectedItem["Code"]),
                             ClassLibrary.Domains.JAutomation.JReferType.External,
                             cdbCopyExternal.SelectedItem["full_title"].ToString(), cdbCopyExternal.SelectedItem["RecieverText"].ToString(), 
                             txtCopyReasonExternal.Text.Trim(),
                             Convert.ToInt32(cmbSendTypeExternal.SelectedValue),
                             txtPersuitExternal.Text);
                grdCopy.DataSource = RemoveRepeters(grdCopy.DataSource, dt);

            }
            else
                if (txtCopyExternalFullName.Text.Length > 0)
                {
                    dt = CopyAdd(grdCopy.DataSource.Copy(),
                                 0,
                                 ClassLibrary.Domains.JAutomation.JReferType.External,
                                 txtCopyExternalFullName.Text, txtCopyExternalFullName.Text,
                                 txtCopyReasonExternal.Text.Trim(),
                                 Convert.ToInt32(cmbSendTypeExternal.SelectedValue),
                                 txtPersuitExternal.Text
                            );
                    grdCopy.DataSource = RemoveRepeters(grdCopy.DataSource, dt);

                }
            if (AfterCopyAdded != null)
                AfterCopyAdded(sender, e);
        }

        /// <summary>
        /// افزودن رونوشت به شرکت اقماری
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------
            //if (cdbCopySubsidiaries.SelectedItem == null)
            //{
            //    JMessages.Message(JLanguages._Text("Enter Rceiver of Copy"), JLanguages._Text("Error"), JMessageType.Error);
            //    cdbCopySubsidiaries.Focus();
            //    return;
            //} 
            
            //if (cmbSendTypeSubsidiaries.SelectedItem == null)
            //{
            //    JMessages.Message(JLanguages._Text("Enter SendType of Copy"), JLanguages._Text("Error"), JMessageType.Error);
            //    cmbSendTypeSubsidiaries.Focus();
            //    return;
            //} 
            
            //if (txtCopyReasonSubsidiries.Text.Trim() == "")
            //{
            //    JMessages.Message(JLanguages._Text("Enter Reason of Copy"), JLanguages._Text("Error"), JMessageType.Error);
            //    txtCopyReasonSubsidiries.Text = "";
            //    txtCopyReasonSubsidiries.Focus();
            //    return;
            //}
            ////------------------------------------------------
            //DataTable dt = new DataTable();
            //dt.Rows.Clear();
            //if (cdbCopySubsidiaries.SelectedItem != null)
            //{
            //    dt = CopyAdd(grdCopy.DataSource.Copy(),  
            //                 Convert.ToInt32(cdbCopySubsidiaries.SelectedItem["Code"]),
            //                 ClassLibrary.Domains.JAutomation.JReferType.Subsidiaries,
            //                 cdbCopySubsidiaries.SelectedItem["full_title"].ToString(),
            //                 txtCopyReasonSubsidiries.Text.Trim(),
            //                 Convert.ToInt32(cmbSendTypeSubsidiaries.SelectedValue)
            //            );
            //    grdCopy.Bind(RemoveRepeters(grdCopy.DataSource, dt), JJanusGrid.JSettingKeys.Copy);

            //}
        }

        /// <summary>
        /// دکمه حذف رونوشت ها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            grdCopy.RemoveSelectedRows();
        }

        private void txtCopyReasonInternal_Leave(object sender, EventArgs e)
        {
            btnInternalAdd.Focus();
        }

        private void txtCopyReasonExternal_Leave(object sender, EventArgs e)
        {
            btnExAdd.Focus();
        }



    }
}
