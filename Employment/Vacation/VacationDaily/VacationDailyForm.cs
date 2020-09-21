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
    public partial class JVacationDailyForm : Globals.JBaseForm
    {
        int _Code;
        int _Status;
        int _Refer_Code;
        int _NextStatus;

        public JVacationDailyForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Employment.JVacationDailyForm";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            gbConfirm.Visible = false;
        }

        public JVacationDailyForm(int pCode, int pRefer_Code)
        {
            InitializeComponent();
            try
            {
                _Code = pCode;
                _Refer_Code = pRefer_Code;
                if (_Refer_Code == 0) _Refer_Code = JVacationHour.FindObjectReferByExternalcode(ClassLibrary.Domains.JAutomation.JObjectTypes.VacationDaily, _Code);

                /// مقداردهی پراپرتی های لیست آرشیو
                JArchive.ClassName = "Employment.JVacationDailyForm";
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
                JVacationDaily tmpVacationDaily = new JVacationDaily(_Code);
                //JEOrganizationChart tmp = new JEOrganizationChart(tmpVacationDaily.User_Post_Code);
                cmbRequester.SelectedValue = tmpVacationDaily.pCode;
                cmbRequester.Text = tmpVacationDaily.User_Full_Title;
                txtStartDate.Date = tmpVacationDaily.StartDate.Date;
                txtEndDate.Date = tmpVacationDaily.EndDate.Date;
                // check Vacation Type
                if (tmpVacationDaily.Type == ClassLibrary.Domains.Employment.JVacationDailyType.Entitlement)
                    rbEsteh.Checked = true;
                else if (tmpVacationDaily.Type == ClassLibrary.Domains.Employment.JVacationDailyType.Sick)
                    rbEstelaji.Checked = true;
                else if (tmpVacationDaily.Type == ClassLibrary.Domains.Employment.JVacationDailyType.NoSalary)
                    rbBedone.Checked = true;
                else if (tmpVacationDaily.Type == ClassLibrary.Domains.Employment.JVacationDailyType.Persuasive)
                    rbTashvighi.Checked = true;
                txtDesc.Text = tmpVacationDaily.Description;
                _Status = tmpVacationDaily.Status;
                groupBox2.Enabled = false;
                calcDate();
                if (JVacationHour.CheckConfirm(tmpVacationDaily.User_Post_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Request)
                {
                    gbConfirm.Visible = true;
                    gbConfirm.Enabled = true;
                    btnSave.Text = "ثبت";
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                    btnBack.Visible = true;
                }
                ////////  اگر مسقیم از فرم باز کند
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                    _Refer_Code = JVacationHour.FindObjectReferByExternalcode(ClassLibrary.Domains.JAutomation.JObjectTypes.VacationDaily, _Code);
                ////////////
                if (JVacationDaily.CheckConfirmFinal(_Refer_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                {
                    lblStatus.SingleText = "درخواست مرخصی تایید شده است.";
                    lblStatus.ForeColor = Color.Green;
                    gbConfirm.Visible = true;
                    gbConfirm.Enabled = true;
                    btnSave.Text = "تایید";
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                    btnBack.Visible = true;
                }
                // --Karamad: lblStatus Text and Color changes in different status
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
                    groupBox2.Enabled = false;
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
                        btnSave.Enabled = false;
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
                //else if (_Status == 0)
                //{
                //    groupBox2.Enabled = true;
                //    btnSave.Enabled = true;
                //}

                //juC_ReferHistory.SetData(_Code, ClassLibrary.Domains.JAutomation.JObjectType.VacationDaily);
                //juC_ReferHistory.ReferGroup = new int[] { 1, 2, 3 };
                refersText.LoadRefer(_Refer_Code);

            }
            // --\\
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
                if (txtStartDate.Date == DateTime.MinValue)
                {
                    JMessages.Message(" تاریخ را وارد کنید ", "", JMessageType.Error);
                    return false;
                }

                #endregion
                JVacationDaily tmpVacationDaily = new JVacationDaily();
                tmpVacationDaily.pCode = Convert.ToInt32(cmbRequester.SelectedValue);
                tmpVacationDaily.User_Full_Title = cmbRequester.Text;
                SqlDataReader dr = (new JOrganization()).GetUserData(Convert.ToInt32(cmbRequester.Text.Substring(cmbRequester.Text.LastIndexOf('_') + 1)));
                if (dr == null) return false;
                tmpVacationDaily.User_Post_Code = (int)dr["Post_Code"];
                tmpVacationDaily.User_Code = (int)dr["User_Code"];
                dr.Close();
                tmpVacationDaily.Register_Post_Code = JMainFrame.CurrentPostCode;
                tmpVacationDaily.Register_Full_Title = JMainFrame.CurrentPostTitle;
                tmpVacationDaily.Register_User_Code = JMainFrame.CurrentUserCode;
                tmpVacationDaily.StartDate = txtStartDate.Date;
                tmpVacationDaily.EndDate = txtEndDate.Date;
                tmpVacationDaily.Description = txtDesc.Text;

                if (rbEsteh.Checked)
                    tmpVacationDaily.Type = ClassLibrary.Domains.Employment.JVacationDailyType.Entitlement;
                else if (rbEstelaji.Checked)
                    tmpVacationDaily.Type = ClassLibrary.Domains.Employment.JVacationDailyType.Sick;
                else if (rbBedone.Checked)
                    tmpVacationDaily.Type = ClassLibrary.Domains.Employment.JVacationDailyType.NoSalary;
                else if (rbTashvighi.Checked)
                    tmpVacationDaily.Type = ClassLibrary.Domains.Employment.JVacationDailyType.Persuasive;
                if (State == JFormState.Update)
                    tmpVacationDaily.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                else
                    tmpVacationDaily.Status = _Status;
                JArchive.ClassName = "Employment.JVacationDailyForm";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------           
                if (State == JFormState.Update)
                {
                    if ((_Status == ClassLibrary.Domains.Employment.JVacationStatus.Request) || (_Status == 0))
                    {
                        //----------Update Archive------------
                        tmpVacationDaily.Code = _Code;
                        if (_Refer_Code > 0)
                            tmpVacationDaily._Refer_Code = _Refer_Code;
                        if (tmpVacationDaily.Update(true))
                        {
                            JArchive.ObjectCode = _Code;
                            JArchive.ArchiveList();
                            JMessages.Message("Update Successfuly", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message("Update Not Successfuly", "", JMessageType.Error);
                    }
                    else
                        JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Error);
                }
                else
                {
                    tmpVacationDaily.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                    _Code = tmpVacationDaily.Insert();
                    if (_Code > 0)
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Insert Successfuly", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Insert Not Successfully", "", JMessageType.Error);
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
            else if (((_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Confirm) || (_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)) && rbConfirm.Checked == false)
            {
                JVacationDaily tmpVacationDaily = new JVacationDaily(_Code);
                tmpVacationDaily.Status = ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm;
                if (tmpVacationDaily.Update(false))
                    this.Close();
            }
        }

        private void JVacationHourForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblStatus.SingleText = "ثبت مرخصی روزانه";
                cmbRequester.DisplayMember = "Name";
                cmbRequester.ValueMember = "Code";
                cmbRequester.DataSource = JVacationHour.GetUser();

                if (State == JFormState.Update)
                    Set_Form();
                if (gbConfirm.Visible == false)
                    Height = 460;

            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
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
                        JVacationDaily tmpVacationDaily = new JVacationDaily(_Code);
                        tmpVacationDaily.Status = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                        tmpVacationDaily.Confirm_Full_Title = JMainFrame.CurrentPostTitle;
                        tmpVacationDaily.Confirm_Post_Code = JMainFrame.CurrentPostCode;
                        tmpVacationDaily.Confirm_User_Code = JMainFrame.CurrentUserCode;

                        JArchive.ClassName = "Employment.JVacationDailyForm";
                        JArchive.SubjectCode = 0;
                        JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                        tmpVacationDaily.Code = _Code;
                        if (tmpVacationDaily.SendConfirmFinal(_Refer_Code))
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

        private void btnConfirmFinal()
        {
            try
            {
                if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)
                {
                    JMessages.Message(" قبلا تایید کارگزینی شده است ", "", JMessageType.Error);
                    return;
                }
                JVacationDaily tmpVacationDaily = new JVacationDaily();
                if (State == JFormState.Update)
                {
                    if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                    {
                        tmpVacationDaily.GetData(_Code);
                        tmpVacationDaily.Status = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                        tmpVacationDaily.ConfirmVacation_Full_Title = JMainFrame.CurrentPostTitle;
                        tmpVacationDaily.ConfirmVacation_Post_Code = JMainFrame.CurrentPostCode;
                        tmpVacationDaily.ConfirmVacation_User_Code = JMainFrame.CurrentUserCode;

                        JArchive.ClassName = "Employment.JVacationDailyForm";
                        JArchive.SubjectCode = 0;
                        JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                        tmpVacationDaily.Code = _Code;
                        if (tmpVacationDaily.Update(false))
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

        private void calcDate()
        {
            if (DateTime.Compare(txtStartDate.Date, txtEndDate.Date) > 0)
            {
                JMessages.Message(" تاریخ پایان نمی تواند از تاریخ شروع کوچکتر باشد ", "", JMessageType.Error);
                txtEndDate.Focus();
                return;
            }
            TimeSpan p = txtEndDate.Date - txtStartDate.Date;
            if (p.Days == 0)
                lblTime.Text = "1" + " روز";

            else
                lblTime.Text = (p.Days + 1).ToString() + " روز";
        }

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            calcDate();
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

                        JVacationDaily tmpVacationDaily = new JVacationDaily(_Code);

                        Automation.JARefer _temprefer = new Automation.JARefer(_Refer_Code);
                        Automation.JARefer refer = new Automation.JARefer();

                        refer.register_user_code = _temprefer.register_user_code;
                        refer.register_Date_Time = _temprefer.register_Date_Time;

                        refer.receiver_code = tmpVacationDaily.Register_User_Code;
                        refer.receiver_full_title = tmpVacationDaily.Register_Full_Title;
                        refer.receiver_post_code = tmpVacationDaily.Register_Post_Code;

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

                        tmpVacationDaily.Status = 0;// ClassLibrary.Domains.Employment.JVacationStatus.Request;
                        if (tmpVacationDaily.Update(db, false))
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

        private void gbConfirm_VisibleChanged(object sender, EventArgs e)
        {
            if (gbConfirm.Visible == false)
                this.Height = 465;
            else
                this.Height = 521;
        }
    }
}
