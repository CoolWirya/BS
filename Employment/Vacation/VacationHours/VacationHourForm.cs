using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Data.SqlClient;

namespace Employment
{
    public partial class JVacationHourForm : Globals.JBaseForm
    {
        int _Code;
        int _Status;
        int _Refer_Code;
        int _NextStatus;

        public JVacationHourForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Employment.JVacationHourForm";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            gbConfirm.Visible = false;
        }

        public JVacationHourForm(int pCode, int pRefer_Code)
        {
            InitializeComponent();
            try
            {
                _Code = pCode;
                _Refer_Code = pRefer_Code;
                if (_Refer_Code == 0) _Refer_Code = JVacationHour.FindObjectReferByExternalcode(ClassLibrary.Domains.JAutomation.JObjectTypes.VacationTime, _Code);

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Employment.JVacationHourForm";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;
                JArchive.ObjectCode = _Code;
                gbConfirm.Visible = false;
            }
            catch { }
            finally { }
        }

        private void Set_Form()
        {
            try
            {
                JVacationHour tmpVacationHour = new JVacationHour(_Code);
                cmbRequester.Text = tmpVacationHour.User_Full_Title;
                txtDate.Date = tmpVacationHour.Date;
                txtStartTime.Text = tmpVacationHour.StartTime;
                txtEndTime.Text = tmpVacationHour.EndTime;
                txtDesc.Text = tmpVacationHour.Description;
                _Status = tmpVacationHour.Status;
                groupBox2.Enabled = false;
                calcTime();
                if (JVacationHour.CheckConfirm(tmpVacationHour.User_Post_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Request)
                {
                    gbConfirm.Enabled = true;
                    gbConfirm.Visible = true;
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                    btnBack.Visible = true;
                }
                ////////  اگر مسقیم از فرم باز کند
                if ((_NextStatus >= ClassLibrary.Domains.Employment.JVacationStatus.Confirm) && (_Refer_Code == 0))
                    _Refer_Code = JVacationHour.FindObjectReferByExternalcode(ClassLibrary.Domains.JAutomation.JObjectTypes.VacationTime, _Code);
                ////////////
                if (JVacationHour.CheckConfirmFinal(_Refer_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                {
                    gbConfirm.Enabled = true;
                    gbConfirm.Visible = true;
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                    btnBack.Visible = true;
                }
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm)
                {
                    lblStatus.SingleText = "درخواست مرخصی تایید نشده است. از 'ارجاعات' پیگیری کنید.";
                    lblStatus.ForeColor = Color.Red;
                }
                if (_Status == 0)
                {
                    Automation.JARefer refer = new Automation.JARefer(_Refer_Code);
                    Employment.JEOrganizationChart jeorg = new JEOrganizationChart(refer.sender_post_code);
                    Globals.JUser juser = new Globals.JUser(jeorg.user_code);
                    JPerson jperson = new JPerson(juser.PCode);
                    lblStatus.TextList = new string[] { "مرخصی توسط (" + jperson.Fam + "، " + jperson.Name + ") برگشت داده شده است.", "علت: " + refer.description.Trim().Replace("\r", "").Replace("\n", "") };
                    lblStatus.ForeColor = Color.Brown;
                    groupBox2.Enabled = true;
                    cmbRequester.Enabled = false;
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Request;

                }
                if ((_Status == ClassLibrary.Domains.Employment.JVacationStatus.Request))
                {
                    lblStatus.SingleText = "درخواست مرخصی هنوز بررسی نشده است.";
                    lblStatus.ForeColor = Color.Brown;
                    //if ((tmpVacationHour.Confirm_Post_Code == JMainFrame.CurrentPostCode) && (_Refer_Code > 0))
                    if (_Refer_Code > 0)
                    {
                        Automation.JARefer tmpRefer = new Automation.JARefer(_Refer_Code);
                        if (tmpRefer.receiver_post_code == JMainFrame.CurrentPostCode)
                        {
                            _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                            gbConfirm.Enabled = true;
                            gbConfirm.Visible = true;
                            btnSave.Enabled = true;
                            btnSave.Text = "تایید";
                        }
                        else
                            btnSave.Enabled = false;
                    }
                    else
                    {
                        if (gbConfirm.Enabled == false)
                            btnSave.Enabled = false;
                        btnSave.Text = "تایید";
                    }
                }
                else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                {
                    lblStatus.SingleText = "درخواست مرخصی تایید شده است.";
                    lblStatus.ForeColor = Color.Green;
                    btnSave.Text = "تایید";
                    if (gbConfirm.Enabled == false)
                    {
                        btnSave.Enabled = false;
                        gbConfirm.Visible = false;
                    }
                }
                else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)
                {
                    lblStatus.SingleText = "درخواست مرخصی توسط کارگزینی تایید شده است.";
                    lblStatus.ForeColor = Color.Blue;
                    btnSave.Text = "تایید";
                    btnSave.Enabled = false;
                    gbConfirm.Enabled = false;
                    gbConfirm.Visible = false;
                }
                else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm)
                {
                    rbNoConfirm.Checked = true;
                    btnSave.Enabled = false;
                }
                else if (_Status == 0)
                {
                    groupBox2.Enabled = true;
                    btnSave.Enabled = true;
                }

                //juC_ReferHistory.SetData(_Code, ClassLibrary.Domains.JAutomation.JObjectType.VacationTime);
                //juC_ReferHistory.ReferGroup = new int[] { 1, 2, 3 };
                refersText.LoadRefer(_Refer_Code);

                if (gbConfirm.Visible == false)
                    Height = 420;

            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Save()
        {
            try
            {
                #region CheckData
                //if (cdbRequester.SelectedCode < 1)
                //{
                //    JMessages.Message(" فرستنده را انتخاب کنید ", "", JMessageType.Error);
                //    return false;
                //}
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Message(" تاریخ را وارد کنید ", "", JMessageType.Error);
                    return false;
                }

                #endregion
                JVacationHour tmpVacationHour = new JVacationHour();
                tmpVacationHour.pCode = Convert.ToInt32(cmbRequester.SelectedValue);
                tmpVacationHour.User_Full_Title = cmbRequester.Text;
                SqlDataReader dr = (new JOrganization()).GetUserData(Convert.ToInt32(cmbRequester.Text.Substring(cmbRequester.Text.LastIndexOf('_') + 1)));
                tmpVacationHour.User_Code = (int)dr["User_Code"];
                tmpVacationHour.User_Post_Code = (int)dr["Post_Code"];
                dr.Close();
                tmpVacationHour.Register_Post_Code = JMainFrame.CurrentPostCode;
                tmpVacationHour.Register_Full_Title = JMainFrame.CurrentPostTitle;
                tmpVacationHour.Register_User_Code = JMainFrame.CurrentUserCode;
                tmpVacationHour.Date = txtDate.Date;
                tmpVacationHour.StartTime = txtStartTime.Text;
                tmpVacationHour.EndTime = txtEndTime.Text;
                tmpVacationHour.Description = txtDesc.Text;
                if (State == JFormState.Update)
                    tmpVacationHour.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                else
                    tmpVacationHour.Status = _Status;
                JArchive.ClassName = "Employment.JVacationHourForm";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------           
                if (State == JFormState.Update)
                {
                    if ((tmpVacationHour.Status == ClassLibrary.Domains.Employment.JVacationStatus.Request) || (_Status == 0))
                    {
                        //----------Update Archive------------
                        tmpVacationHour.Code = _Code;
                        if (_Refer_Code > 0)
                            tmpVacationHour._Refer_Code = _Refer_Code;
                        if (tmpVacationHour.Update(true))
                        {
                            JArchive.ObjectCode = _Code;
                            JArchive.ArchiveList();
                            JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message("Update Not Successfuly ", "", JMessageType.Error);
                    }
                    else
                        JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Error);
                }
                else
                {
                    tmpVacationHour.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                    _Code = tmpVacationHour.Insert();
                    if (_Code > 0)
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message(" Insert Not Successfuly ", "", JMessageType.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((_NextStatus == 0) && (State == JFormState.Update))
            {
                if (Save())
                {
                    this.State = JFormState.Update;
                    this.Close();
                }
            }
            if ((_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Request) || (State == JFormState.Insert))
            {
                if (Save())
                {
                    this.State = JFormState.Update;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else if ((_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Confirm) && (rbConfirm.Checked) && (gbConfirm.Enabled == true))
                btnConfirm();
            else if ((_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Personnel) && (rbConfirm.Checked) && (gbConfirm.Enabled == true))
                btnConfirmFinal();
            else if (rbConfirm.Checked == false)
            {
                JVacationHour tmpVacationHour = new JVacationHour(_Code);
                tmpVacationHour.Status = ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm;
                if (tmpVacationHour.Update(false))
                    this.Close();
            }
        }

        private void JVacationHourForm_Load(object sender, EventArgs e)
        {
            lblStatus.SingleText = "ثبت مرخصی ساعتی";
            try
            {
                txtDate.Date = DateTime.Now;
                cmbRequester.DisplayMember = "Name";
                cmbRequester.ValueMember = "Code";
                cmbRequester.DataSource = JVacationHour.GetUser();

                if (State == JFormState.Update)
                    Set_Form();
                if (gbConfirm.Visible == false)
                    Height = 420;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally { }
        }

        //private void btnConfirm_Click(object sender, EventArgs e)
        private void btnConfirm()
        {
            try
            {
                //if (JPermission.CheckPermission("Employment.JVacationHourForm.Confirm"))
                //{
                if (State == JFormState.Update)
                {
                    if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Request)
                    {
                        JVacationHour tmpVacationHour = new JVacationHour(_Code);
                        tmpVacationHour.Status = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                        tmpVacationHour.Confirm_Full_Title = JMainFrame.CurrentPostTitle;
                        tmpVacationHour.Confirm_Post_Code = JMainFrame.CurrentPostCode;
                        tmpVacationHour.Confirm_User_Code = JMainFrame.CurrentUserCode;

                        JArchive.ClassName = "Employment.JVacationHourForm";
                        JArchive.SubjectCode = 0;
                        JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                        tmpVacationHour.Code = _Code;
                        if (tmpVacationHour.SendConfirmFinal(_Refer_Code))
                        {
                            JArchive.ObjectCode = _Code;
                            JArchive.ArchiveList();
                            JMessages.Message("تایید با موفقیت انجام گردید ", "", JMessageType.Information);
                            this.Close();
                        }
                        else
                            JMessages.Message("تایید با خطا مواجه شده  ", "", JMessageType.Error);
                    }
                    else
                        JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Information);
                }
                else
                    JMessages.Message(" ابتدا مرخصی را ثبت کنید ", "", JMessageType.Error);
                //}
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        //private void btnConfirmFinal_Click(object sender, EventArgs e)
        private void btnConfirmFinal()
        {
            try
            {
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)
                {
                    JMessages.Message(" قبلا تایید کارگزینی شده است ", "", JMessageType.Error);
                    return;
                }
                JVacationHour tmpVacationHour = new JVacationHour();
                if (State == JFormState.Update)
                {
                    if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                    {
                        tmpVacationHour.GetData(_Code);
                        tmpVacationHour.Status = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                        tmpVacationHour.ConfirmVacation_Full_Title = JMainFrame.CurrentPostTitle;
                        tmpVacationHour.ConfirmVacation_Post_Code = JMainFrame.CurrentPostCode;
                        tmpVacationHour.ConfirmVacation_User_Code = JMainFrame.CurrentUserCode;

                        JArchive.ClassName = "Employment.JVacationHourForm";
                        JArchive.SubjectCode = 0;
                        JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                        tmpVacationHour.Code = _Code;
                        if (tmpVacationHour.Update(false))
                        {
                            JArchive.ObjectCode = _Code;
                            JArchive.ArchiveList();
                            JMessages.Message("تایید با موفقیت انجام گردید ", "", JMessageType.Information);
                            this.Close();
                        }
                        else
                            JMessages.Message("تایید با خطا مواجه شده  ", "", JMessageType.Error);
                    }
                    else
                        JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Information);
                }
                else
                    JMessages.Message(" ابتدا مرخصی را ثبت کنید ", "", JMessageType.Error);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void calcTime()
        {
            try
            {
                string[] strS = txtStartTime.Lines[0].Split(':');
                string[] strE = txtEndTime.Lines[0].Split(':');

                txtStartTime.BackColor = Color.Empty;
                txtEndTime.BackColor = Color.Empty;

                #region CheckData
                if (txtStartTime.Text == "  :")
                {
                    return;
                }
                if (txtEndTime.Text == "  :")
                {
                    return;
                }

                if ((txtStartTime.Lines[0].Contains('_')))
                {
                    txtStartTime.BackColor = Color.Red;
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtStartTime.Focus();
                    return;
                }
                if ((txtEndTime.Lines[0].Contains('_')))
                {
                    txtEndTime.BackColor = Color.Red;
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtEndTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strS[0].Trim()) > 25)
                {
                    txtStartTime.BackColor = Color.Red;
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtStartTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strE[0].Trim()) > 25)
                {
                    txtEndTime.BackColor = Color.Red;
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtEndTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strS[1].Trim()) > 61)
                {
                    txtStartTime.BackColor = Color.Red;
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtStartTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strE[1].Trim()) > 61)
                {
                    txtEndTime.BackColor = Color.Red;
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtEndTime.Focus();
                    return;
                }
                #endregion

                Decimal Hour;
                Decimal Min;
                if ((strS[0].Trim() != "") && (strE[0].Trim() != ""))
                {
                    Hour = Convert.ToInt32(strE[0]) - Convert.ToInt32(strS[0]);
                    if ((Convert.ToDecimal(strS[1]) > Convert.ToDecimal(strE[1])) && Hour < 1)
                    {
                        JMessages.Message(" ساعت شروع نمی تواند از ساعت پایان بیشتر باشد", "", JMessageType.Error);
                        txtEndTime.Focus();
                        return;
                    }
                    if ((Convert.ToDecimal(txtStartTime.Text.Replace(":", "")) > Convert.ToDecimal(txtEndTime.Text.Replace(":", ""))))
                    {
                        JMessages.Message(" ساعت شروع نمی تواند از ساعت پایان بیشتر باشد", "", JMessageType.Error);
                        txtEndTime.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(strS[1]) > Convert.ToDecimal(strE[1]))
                    {
                        Hour--;
                        Min = (60 - (Convert.ToDecimal(strS[1]) - Convert.ToDecimal(strE[1])));
                    }
                    else
                        Min = Convert.ToDecimal(strE[1]) - Convert.ToDecimal(strS[1]);
                    if ((Hour > 0) || (Min > 0))
                        lblTime.Text = Hour.ToString() + ":" + Min.ToString();
                    else
                    {
                        txtEndTime.BackColor = Color.Red;
                        JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                        txtEndTime.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void txtEndTime_Leave(object sender, EventArgs e)
        {
            calcTime();
        }

        private void cdbRequester_Leave(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("Back Vacation");
                if (_Refer_Code > 0 && _Code > 0)
                {
                    JTextInputDialogForm Tdialog = new JTextInputDialogForm("Refer", "Back...");
                    Tdialog.ShowDialog();
                    if (Tdialog.DialogResult == DialogResult.OK)
                    {

                        JVacationHour tmpVacationHour = new JVacationHour(_Code);

                        Automation.JARefer _temprefer = new Automation.JARefer(_Refer_Code);
                        Automation.JARefer refer = new Automation.JARefer();

                        refer.register_user_code = _temprefer.register_user_code;
                        refer.register_Date_Time = _temprefer.register_Date_Time;
                        
                        refer.receiver_code = tmpVacationHour.Register_User_Code;
                        refer.receiver_full_title = tmpVacationHour.Register_Full_Title;
                        refer.receiver_post_code = tmpVacationHour.Register_Post_Code;

                        refer.description = Tdialog.Text;

                        refer.sender_code = JMainFrame.CurrentUserCode;
                        refer.sender_full_title = JMainFrame.CurrentPostTitle;
                        refer.sender_post_code = JMainFrame.CurrentPostCode;

                        refer.object_code = _temprefer.object_code;
                        refer.ReferLevel = _temprefer.ReferLevel + 1;
                        refer.parent_code = _temprefer.Code;
                        refer.ReferGroup = _temprefer.ReferGroup;

                        refer.refertype = ClassLibrary.Domains.JAutomation.JReferType.Internal;
                        refer.send_date_time = (new JDataBase().GetCurrentDateTime());
                        refer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                        refer.is_active = true;

                        tmpVacationHour.Status = 0;// ClassLibrary.Domains.Employment.JVacationStatus.Request;
                        if (tmpVacationHour.Update(db, false))
                        {
                            db.Commit();
                            db.beginTransaction("Back Vacation");
                            if (refer.Send(db) > 0)
                            {
                                db.Commit();
                                this.Close();
                                return;
                            }
                            else
                            {
                                db.Rollback("Back Vacation");
                            }
                        }
                        else
                        {
                            db.Rollback("Back Vacation");
                        }
                    }

                }
                db.Rollback("Back Vacation");
            }
            catch
            {
                db.Rollback("Back Vacation");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void txtStartTime_Enter(object sender, EventArgs e)
        {
            txtStartTime.SelectAll();
        }

        private void txtEndTime_Enter(object sender, EventArgs e)
        {
            txtStartTime.SelectAll();
        }

        private void txtStartTime_Leave(object sender, EventArgs e)
        {
            calcTime();

        }
    }
}
