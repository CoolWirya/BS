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
    public partial class JConfirmWorkFrom : Globals.JBaseForm
    {
        int _Code;
        int _Status;
        int _Refer_Code;
        int _NextStatus;

        public JConfirmWorkFrom()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Employment.JConfirmWorkFrom";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JConfirmWorkFrom(int pCode, int pRefer_Code)
        {
            InitializeComponent();
            try
            {
                _Code = pCode;
                _Refer_Code = pRefer_Code;
                if (_Refer_Code == 0) _Refer_Code = JVacationHour.FindObjectReferByExternalcode(ClassLibrary.Domains.JAutomation.JObjectTypes.ConfirmWork, _Code);

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Employment.JConfirmWorkFrom";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;
                JArchive.ObjectCode = _Code;
            }
            catch { }
            finally { }
        }

        private void Set_Form()
        {
            try
            {
                JConfirmWork tmpConfirmWork = new JConfirmWork(_Code);
                cmbRequester.Text = tmpConfirmWork.User_Full_Title;
                txtDate.Date = tmpConfirmWork.Date;
                txtStartTime.Text = tmpConfirmWork.StartTime;
                txtEndTime.Text = tmpConfirmWork.EndTime;
                txtDesc.Text = tmpConfirmWork.Description;
                _Status = tmpConfirmWork.Status;
                if (tmpConfirmWork.NoAbsent)
                    chkNoAbsent.Checked = true;
                else
                    chkNoAbsent.Checked = false;
                if (tmpConfirmWork.OverTime)
                    chkOverTime.Checked = true;
                else
                    chkOverTime.Checked = false;

                groupBox2.Enabled = false;
                calcTime();
                if (JVacationHour.CheckConfirm(tmpConfirmWork.User_Post_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Request)
                {
                    gbConfirm.Enabled = true;
                    gbConfirm.Visible = true;
                    btnSave.Text = "تایید";

                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                    btnBack.Visible = true;
                }
                ////////  اگر مسقیم از فرم باز کند
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                    _Refer_Code = JVacationHour.FindObjectReferByExternalcode(ClassLibrary.Domains.JAutomation.JObjectTypes.ConfirmWork, _Code);
                ////////////
                if (JConfirmWork.CheckConfirmFinal(_Refer_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                {
                    lblStatus.SingleText = "درخواست کارکرد تایید شده است.";
                    lblStatus.ForeColor = Color.Green;
                    gbConfirm.Enabled = true;
                    gbConfirm.Visible = true;
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                    btnBack.Visible = true;
                    btnSave.Text = "تایید";

                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                    btnBack.Visible = true;
                }
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm)
                {
                    lblStatus.SingleText = "درخواست کارکرد تایید نشده است. از 'ارجاعات' پیگیری کنید.";
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
                    lblStatus.SingleText = "درخواست کارکرد هنوز بررسی نشده است.";
                    lblStatus.ForeColor = Color.Brown;
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
                    lblStatus.SingleText = "درخواست کارکرد تایید شده است.";
                    lblStatus.ForeColor = Color.Green;
                    btnSave.Text = "تایید";
                    if (gbConfirm.Enabled == false)
                    {
                        btnSave.Enabled = false;
                    }
                }
                else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)
                {
                    lblStatus.SingleText = "درخواست کارکرد توسط کارگزینی تایید شده است.";
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
                    gbConfirm.Visible = false;
                    gbConfirm.Enabled = false;
                    btnSave.Enabled = true;
                }

                //juC_ReferHistory.SetData(_Code, ClassLibrary.Domains.JAutomation.JObjectType.ConfirmWork);
                //juC_ReferHistory.ReferGroup = new int[] { 1, 2, 3 };
                refersText.LoadRefer(_Refer_Code);

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
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
                JConfirmWork tmpConfirmWork = new JConfirmWork(_Code);
                tmpConfirmWork.Status = ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm;
                if (tmpConfirmWork.Update(false))
                    this.Close();
            }
        }

        private bool Save()
        {
            try
            {
                #region CheckData
                //if (!((chkNoAbsent.Checked) || (chkOverTime.Checked)))
                //{
                //    JMessages.Message(" لطفا یک گزینه رفع غیبت یا محاسبه اضافه کاری را انتخاب کنید ", "", JMessageType.Error);
                //    return false;
                //}
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Message("لطفا تاریخ را وارد کنید ", "", JMessageType.Error);
                    return false;
                }

                #endregion
                JConfirmWork tmpConfirmWork = new JConfirmWork();
                tmpConfirmWork.pCode = Convert.ToInt32(cmbRequester.SelectedValue);
                int pc = Convert.ToInt32(cmbRequester.Text.Substring(cmbRequester.Text.LastIndexOf('_') + 1));
                SqlDataReader dr = (new JOrganization()).GetUserData(Convert.ToInt32(cmbRequester.Text.Substring(cmbRequester.Text.LastIndexOf('_') + 1)));
                if (dr == null) return false;
                tmpConfirmWork.User_Post_Code = (int)dr["Post_Code"];
                tmpConfirmWork.User_Code = (int)dr["User_Code"];
                dr.Close();
                tmpConfirmWork.User_Full_Title = cmbRequester.Text;
                tmpConfirmWork.Register_Post_Code = JMainFrame.CurrentPostCode;
                tmpConfirmWork.Register_Full_Title = JMainFrame.CurrentPostTitle;
                tmpConfirmWork.Register_User_Code = JMainFrame.CurrentUserCode;
                tmpConfirmWork.Date = txtDate.Date;
                tmpConfirmWork.StartTime = txtStartTime.Text;
                tmpConfirmWork.EndTime = txtEndTime.Text;
                tmpConfirmWork.Description = txtDesc.Text;
                if (chkNoAbsent.Checked)
                    tmpConfirmWork.NoAbsent = true;
                else
                    tmpConfirmWork.NoAbsent = false;
                if (chkOverTime.Checked)
                    tmpConfirmWork.OverTime = true;
                else
                    tmpConfirmWork.OverTime = false;

                if (State == JFormState.Update)
                    tmpConfirmWork.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                else
                    tmpConfirmWork.Status = _Status;
                JArchive.ClassName = "Employment.JConfirmWorkFrom";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------           
                if (State == JFormState.Update)
                {
                    if ((tmpConfirmWork.Status == ClassLibrary.Domains.Employment.JVacationStatus.Request) || (_Status == 0))
                    {
                        //----------Update Archive------------
                        tmpConfirmWork.Code = _Code;
                        if (_Refer_Code > 0)
                            tmpConfirmWork._Refer_Code = _Refer_Code;
                        if (tmpConfirmWork.Update(true))
                        {
                            JArchive.ObjectCode = _Code;
                            JArchive.ArchiveList();
                            JMessages.Information("Update Successfuly ", "");
                            return true;
                        }
                        else
                            JMessages.Error("Update Not Successfuly ", "");
                    }
                    else
                        JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Error);
                }
                else
                {
                    tmpConfirmWork.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                    _Code = tmpConfirmWork.Insert();
                    if (_Code > 0)
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Information("Insert Successfuly ", "");
                        return true;
                    }
                    else
                        JMessages.Error(" Insert Not Successfuly ", "");
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                        JConfirmWork tmpConfirmWork = new JConfirmWork(_Code);
                        tmpConfirmWork.Status = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                        tmpConfirmWork.Confirm_Full_Title = JMainFrame.CurrentPostTitle;
                        tmpConfirmWork.Confirm_Post_Code = JMainFrame.CurrentPostCode;
                        tmpConfirmWork.Confirm_User_Code = JMainFrame.CurrentUserCode;

                        JArchive.ClassName = "Employment.JConfirmWorkFrom";
                        JArchive.SubjectCode = 0;
                        JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                        tmpConfirmWork.Code = _Code;
                        if (tmpConfirmWork.SendConfirmFinal(_Refer_Code))
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
                JSystem.Except.AddException(ex);
            }
        }

        private void btnConfirmFinal()
        {
            try
            {
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)
                {
                    JMessages.Message(" قبلا تایید کارگزینی شده است ", "", JMessageType.Error);
                    return;
                }
                JConfirmWork tmpConfirmWork = new JConfirmWork();
                if (State == JFormState.Update)
                {
                    if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                    {
                        tmpConfirmWork.GetData(_Code);
                        tmpConfirmWork.Status = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                        tmpConfirmWork.ConfirmVacation_Full_Title = JMainFrame.CurrentPostTitle;
                        tmpConfirmWork.ConfirmVacation_Post_Code = JMainFrame.CurrentPostCode;
                        tmpConfirmWork.ConfirmVacation_User_Code = JMainFrame.CurrentUserCode;

                        JArchive.ClassName = "Employment.JConfirmWorkFrom";
                        JArchive.SubjectCode = 0;
                        JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                        tmpConfirmWork.Code = _Code;
                        if (tmpConfirmWork.Update(false))
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
                JSystem.Except.AddException(ex);
            }
        }

        private void calcTime()
        {
            try
            {
                string[] strS = txtStartTime.Lines[0].Split(':');
                string[] strE = txtEndTime.Lines[0].Split(':');

                #region CheckData
                if ((txtStartTime.Lines[0].Contains('_')))
                {
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtStartTime.Focus();
                    return;
                }
                if ((txtEndTime.Lines[0].Contains('_')))
                {
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtEndTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strS[0].Trim()) > 25)
                {
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtStartTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strE[0].Trim()) > 25)
                {
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtEndTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strS[1].Trim()) > 61)
                {
                    JMessages.Message(" لطفا ساعت را درست وارد کنید", "", JMessageType.Error);
                    txtStartTime.Focus();
                    return;
                }
                if (Convert.ToDecimal(strE[1].Trim()) > 61)
                {
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("Back ConfirmWork");
                if (_Refer_Code > 0 && _Code > 0)
                {
                    JTextInputDialogForm Tdialog = new JTextInputDialogForm("Refer", "Back...");
                    Tdialog.ShowDialog();
                    if (Tdialog.DialogResult == DialogResult.OK)
                    {

                        JConfirmWork tmpConfirmWork = new JConfirmWork(_Code);

                        Automation.JARefer _temprefer = new Automation.JARefer(_Refer_Code);
                        Automation.JARefer refer = new Automation.JARefer();

                        refer.register_user_code = _temprefer.register_user_code;
                        refer.register_Date_Time = _temprefer.register_Date_Time;

                        refer.receiver_code = tmpConfirmWork.Register_User_Code;
                        refer.receiver_full_title = tmpConfirmWork.Register_Full_Title;
                        refer.receiver_post_code = tmpConfirmWork.Register_Post_Code;

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

                        tmpConfirmWork.Status = 0;// ClassLibrary.Domains.Employment.JVacationStatus.Request;
                        if (tmpConfirmWork.Update(db, false))
                        {
                            db.Commit();
                            db.beginTransaction("Back ConfirmWork");
                            if (refer.Send(db) > 0)
                            {
                                db.Commit();
                                this.Close();
                                return;
                            }
                            else
                            {
                                db.Rollback("Back ConfirmWork");
                            }
                        }
                        else
                        {
                            db.Rollback("Back ConfirmWork");
                        }
                    }
                }
                db.Rollback("Back ConfirmWork");
            }
            catch (Exception ex)
            {
                db.Rollback("Back ConfirmWork");
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        private void JConfirmWorkFrom_Load(object sender, EventArgs e)
        {
            lblStatus.SingleText = "ثبت کارکرد";
            try
            {
                cmbRequester.DisplayMember = "Name";
                cmbRequester.ValueMember = "Code";
                cmbRequester.DataSource = JVacationHour.GetUser();

                if (State == JFormState.Update)
                    Set_Form();
                else
                    cmbRequester.SelectedValue = JMainFrame.CurrentPersonCode;
                if (gbConfirm.Visible == false)
                    Height = 390;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
