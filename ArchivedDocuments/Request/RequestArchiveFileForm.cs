using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Automation;

namespace ArchivedDocuments
{
    public partial class JRequestArchiveFileForm : JBaseForm
    {

        int _Code;
        int _Status;
        int _Refer_Code;
        int _NextStatus;
        int _ArchiveCode;
        DataTable _ArchiveList;

        public JRequestArchiveFileForm()
        {
            InitializeComponent();
        }

        public JRequestArchiveFileForm(int pCode,int pArchiveCode, int pRefer_Code)
        {
            InitializeComponent();
            _Code = pCode;
            _Refer_Code = pRefer_Code;
            _ArchiveCode = pArchiveCode;
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.DataPropertyName = "Status";
                column.HeaderText = "Status";
                column.DropDownWidth = 200;
                column.Width = 150;
                column.MaxDropDownItems = 100;
                column.FlatStyle = FlatStyle.System;
            }
            return column;
        }

        private void Set_Form()
        {
            try
            {
                JRequestArchiveFile tmpRequestArchiveFile = new JRequestArchiveFile(_Code);
                lblRequester.Text = tmpRequestArchiveFile.Requester_Full_Title;
                txtRequestDate.Date = tmpRequestArchiveFile.RequestDate;
                //_Status = tmpRequestArchiveFile.Status;
                
                groupBox2.Enabled = true;
                if (JRequestArchiveFile.CheckConfirm(tmpRequestArchiveFile.Requester_Post_Code)) //&& _Status == ClassLibrary.Domains.Employment.JVacationStatus.Request)
                {
                    //gbConfirm.Enabled = true;
                    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                    //btnBack.Visible = true;

                    DataGridViewComboBoxColumn comboboxColumn;
                    comboboxColumn = CreateComboBoxColumn();
                    comboboxColumn.DataSource = ClassLibrary.Domains.JGlobal.JStatusArchive.GetData();
                    comboboxColumn.DisplayMember = "FarsiName";
                    comboboxColumn.ValueMember = "Value";
                    //comboboxColumn.Name = "Status";                    
                    jdgRequestList.Columns.Insert(0, comboboxColumn);
                    btnSave.Text = "تایید";
                    //_ArchiveList = JRequestArchiveFile.GetDataTableArchiveFile(0, _Code);
                    //jdgRequestList.DataSource = _ArchiveList;
                    string[] row0 = { "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    int count = 0;
                    foreach (DataRow dr in JRequestArchiveFile.GetDataTableArchiveFile(0, _Code).Rows)
                    {
                        row0[0] = dr["Status"].ToString();
                        row0[1] = dr["RegisterDate"].ToString();
                        row0[2] = dr["Subject"].ToString();
                        row0[3] = dr["ArchiveFileDesc"].ToString();
                        row0[4] = dr["Code"].ToString();
                        row0[5] = dr["RequestCode"].ToString();
                        row0[6] = dr["Confirm_Post_Code"].ToString();
                        row0[7] = dr["Confirm_Full_Title"].ToString();
                        row0[8] = dr["Confirm_User_Code"].ToString();
                        row0[9] = dr["StartDate"].ToString();
                        row0[10] = dr["EndDate"].ToString();
                        row0[11] = dr["Description"].ToString();
                        row0[12] = dr["ArchiveCode"].ToString();                         
                        jdgRequestList.Rows.Add(row0);
                        //jdgRequestList.Rows[count].Cells[0].Value = Convert.ToInt32(dr["Status"].ToString());                        
                        count++;
                    }
                    //_ArchiveList =  jdgRequestList.DataSource;
                }
                else
                {
                    btnSave.Enabled = false;
                    jdgRequestList.Columns.Clear();
                    _ArchiveList = JRequestArchiveFile.GetDataTableArchiveFile(0, _Code);
                    jdgRequestList.DataSource = _ArchiveList;
                }
                //if (tmpRequestArchiveFile.CheckConfirmFinal(_Refer_Code) && _Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                //{
                //    gbConfirm.Enabled = true;
                //    _NextStatus = ClassLibrary.Domains.Employment.JVacationStatus.Personnel;
                //    btnBack.Visible = true;
                //}
                //if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm)
                //    lblStatus.Text = "وضعیت " + " عدم تایید ";
                if ((_Status == ClassLibrary.Domains.Employment.JVacationStatus.Request) || (_Status == 0))
                {
                    //lblStatus.Text = "وضعیت " + " درخواست ";
                    if ((tmpRequestArchiveFile.Requester_Post_Code == JMainFrame.CurrentPostCode) && (_Refer_Code > 0))
                    {
                        Automation.JARefer tmpRefer = new Automation.JARefer(_Refer_Code);
                        if (tmpRefer.receiver_post_code == JMainFrame.CurrentPostCode)
                        {
                            groupBox2.Enabled = true;
                            btnSave.Enabled = true;
                        }
                        else
                            btnSave.Enabled = false;
                    }
                    else
                    {
                        //if (gbConfirm.Enabled == false)
                        //    btnSave.Enabled = false;
                         //btnSave.Text = "تایید";
                    }
                }
                else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Confirm)
                {
                    //lblStatus.Text = "وضعیت " + " تایید ";
                    btnSave.Text = "تایید";
                    //if (gbConfirm.Enabled == false)
                    //    btnSave.Enabled = false;
                }
                //else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Personnel)
                //{
                //    lblStatus.Text = "وضعیت " + " تایید کارگزینی ";
                //    btnSave.Text = "تایید";
                //    btnSave.Enabled = false;
                //    gbConfirm.Enabled = false;
                //}
                else if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm)
                {
                    //rbNoConfirm.Checked = true;
                    btnSave.Enabled = false;
                }
                else if (_Status == 0)
                {
                    groupBox2.Enabled = true;
                    btnSave.Enabled = true;
                }

                //juC_ReferHistory.SetData(_Code, ClassLibrary.Domains.JAutomation.JObjectType.ArchiveRequest);
                //juC_ReferHistory.ReferGroup = new int[] { 1, 2, 3 };
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
                if (jdgRequestList.Rows.Count < 1)
                {
                    JMessages.Message(" لطفا فایل آرشیو را انتخاب کنید ", "", JMessageType.Error);
                    return false;
                }
                #endregion

                JRequestArchiveFile tmpRequestArchiveFile = new JRequestArchiveFile();
                tmpRequestArchiveFile.Requester_Post_Code = JMainFrame.CurrentPostCode;
                tmpRequestArchiveFile.Requester_Full_Title = JMainFrame.CurrentPostTitle;
                tmpRequestArchiveFile.Requester_User_Code = JMainFrame.CurrentUserCode;
                tmpRequestArchiveFile.RequestDate = txtRequestDate.Date;
                //if (State == JFormState.Update)
                //    tmpRequestArchiveFile.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                //else
                //    tmpRequestArchiveFile.Status = _Status;
                //JArchive.ClassName = "ArchivedDocuments.JRequestArchiveFileForm";
                //JArchive.SubjectCode = 0;
                //JArchive.PlaceCode = 0;

                //---------ویرایش------------           
                if (State == JFormState.Update)
                {
                    //if ((tmpRequestArchiveFile.Status == ClassLibrary.Domains.Employment.JVacationStatus.Request) || (_Status == 0))
                    //{
                        //----------Update Archive------------
                        tmpRequestArchiveFile.Code = _Code;
                        if (_Refer_Code > 0)
                            tmpRequestArchiveFile._Refer_Code = _Refer_Code;
                        if (tmpRequestArchiveFile.Update(_ArchiveList))
                        {
                            //JArchive.ObjectCode = _Code;
                            //JArchive.ArchiveList();
                            JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message("Update Not Successfuly ", "", JMessageType.Error);
                    //}
                    //else
                    //    JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Error);
                }
                else
                {
                    //tmpRequestArchiveFile.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;
                    _Code = tmpRequestArchiveFile.Insert(_ArchiveList);
                    if (_Code > 0)
                    {
                        //JArchive.ObjectCode = _Code;
                        //JArchive.ArchiveList();
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
            else if ((_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Confirm))// && (rbConfirm.Checked) && (gbConfirm.Enabled == true))
                btnConfirm();
            //else if ((_NextStatus == ClassLibrary.Domains.Employment.JVacationStatus.Personnel) && (rbConfirm.Checked) && (gbConfirm.Enabled == true))
            //    btnConfirmFinal();
            //else if (rbConfirm.Checked == false)
            //{
            //    JRequestArchiveFile tmpRequestArchiveFile = new JRequestArchiveFile(_Code);
            //    tmpRequestArchiveFile.Status = ClassLibrary.Domains.Employment.JVacationStatus.NotConfirm;
            //    if (tmpRequestArchiveFile.Update(_ArchiveList))
            //        this.Close();
            //}
        }

        private void btnConfirm()
        {
            try
            {
                //if (JPermission.CheckPermission("Employment.JVacationHourForm.Confirm"))
                //{
                if (State == JFormState.Update)
                {
                    //if (_Status == ClassLibrary.Domains.Employment.JVacationStatus.Request)
                    //{
                        JRequestArchiveList tmpRequestArchiveList = new JRequestArchiveList();
                        for (int i = 0; i < jdgRequestList.Rows.Count; i++)
                        {
                            tmpRequestArchiveList.GetData(Convert.ToInt32(jdgRequestList.Rows[i].Cells["Code"].Value));
                            tmpRequestArchiveList.Status = Convert.ToInt32(jdgRequestList.Rows[i].Cells[0].Value);// ClassLibrary.Domains.Employment.JVacationStatus.Confirm;
                            if (jdgRequestList.Rows[i].Cells["StartDate"].Value.ToString() != "")
                                tmpRequestArchiveList.StartDate = Convert.ToDateTime(jdgRequestList.Rows[i].Cells["StartDate"].Value);
                            if (jdgRequestList.Rows[i].Cells["EndDate"].Value.ToString() != "")
                                tmpRequestArchiveList.EndDate = Convert.ToDateTime(jdgRequestList.Rows[i].Cells["EndDate"].Value);
                            tmpRequestArchiveList.Description = jdgRequestList.Rows[i].Cells["Description"].Value.ToString();
                            tmpRequestArchiveList.Confirm_Full_Title = JMainFrame.CurrentPostTitle;
                            tmpRequestArchiveList.Confirm_Post_Code = JMainFrame.CurrentPostCode;
                            tmpRequestArchiveList.Confirm_User_Code = JMainFrame.CurrentUserCode;
                            if (!(tmpRequestArchiveList.Update()))
                            {
                                JMessages.Message("تایید با خطا مواجه شده  ", "", JMessageType.Error);
                                return;
                            }
                        }
                        //JArchive.ClassName = "ArchivedDocuments.JRequestArchiveFileForm";
                        //JArchive.SubjectCode = 0;
                        //JArchive.PlaceCode = 0;

                        //----------Update Archive------------
                    //    tmpRequestArchiveList.Code = _Code;
                    //    if (tmpRequestArchiveList.Update())//_ArchiveList
                    //    //if (tmpRequestArchiveFile.SendConfirmFinal(_Refer_Code))
                    //    {
                    //        //JArchive.ObjectCode = _Code;
                    //        //JArchive.ArchiveList();
                    //        JMessages.Message("تایید با موفقیت انجام گردید ", "", JMessageType.Information);
                    //        this.Close();
                    //    }
                    //    else
                    //        JMessages.Message("تایید با خطا مواجه شده  ", "", JMessageType.Error);
                    //}
                    //else
                    //    JMessages.Message("درخواست تایید شده قابل ویرایش نیست ", "", JMessageType.Information);
                }
                else
                    JMessages.Message(" ابتدا درخواست را ثبت کنید ", "", JMessageType.Error);
                //}
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("Back ArchiveFile");
                if (_Refer_Code > 0 && _Code > 0)
                {
                    JTextInputDialogForm Tdialog = new JTextInputDialogForm("Refer", "Back...");
                    Tdialog.ShowDialog();
                    if (Tdialog.DialogResult == DialogResult.OK)
                    {
                        JRequestArchiveFile tmpRequestArchiveFile = new JRequestArchiveFile(_Code);

                        Automation.JARefer _temprefer = new Automation.JARefer(_Refer_Code);
                        Automation.JARefer refer = new Automation.JARefer();
                        refer.receiver_code = tmpRequestArchiveFile.Requester_User_Code;
                        refer.receiver_full_title = tmpRequestArchiveFile.Requester_Full_Title;
                        refer.receiver_post_code = tmpRequestArchiveFile.Requester_Post_Code;

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

                        //tmpRequestArchiveFile.Status = 0;// ClassLibrary.Domains.Employment.JVacationStatus.Request;
                        if (tmpRequestArchiveFile.Update(db, false))
                        {
                            db.Commit();
                            db.beginTransaction("Back ArchiveFile");
                            if (refer.Send(db) > 0)
                            {
                                db.Commit();
                                this.Close();
                                return;
                            }
                            else
                            {
                                db.Rollback("Back ArchiveFile");
                            }
                        }
                        else
                        {
                            db.Rollback("Back ArchiveFile");
                        }
                    }

                }
                db.Rollback("Back ArchiveFile");
            }
            catch
            {
                db.Rollback("Back ArchiveFile");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void JRequestArchiveFileForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (State == JFormState.Update)
                    Set_Form();
                else
                {
                    jdgRequestList.Columns.Clear();
                    lblRequester.Text = JMainFrame.BaseCurrentPostTitle;
                    _ArchiveList = JRequestArchiveFile.GetDataTableArchiveFile(_ArchiveCode,0);
                    jdgRequestList.DataSource = _ArchiveList;
                    txtRequestDate.Date = JDateTime.Now();
                }
                jdgRequestList.Columns["Code"].Visible = false;
                jdgRequestList.Columns["RequestCode"].Visible = false;
                jdgRequestList.Columns["ArchiveCode"].Visible = false;
                jdgRequestList.Columns["Confirm_Post_Code"].Visible = false;
                jdgRequestList.Columns["Confirm_User_Code"].Visible = false;
                jdgRequestList.Columns["status"].Visible = false;
                jdgRequestList.Columns["Status"].ReadOnly = true;
                jdgRequestList.Columns["RegisterDate"].ReadOnly = true;
                jdgRequestList.Columns["Subject"].ReadOnly = true;
                jdgRequestList.Columns["ArchiveFileDesc"].ReadOnly = true;
                jdgRequestList.Columns["Confirm_Full_Title"].ReadOnly = true;                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgRequestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jdgRequestList.SelectedRows.Count == 0)
                return;
            JFile content;
            try
            {
                int Status = 0;
                if (this.State == JFormState.Update)
                    if (jdgRequestList.DataSource == null)
                        Status = Convert.ToInt32(jdgRequestList[0, jdgRequestList.SelectedRows[0].Index].Value);
                    else
                       Status = Convert.ToInt32(jdgRequestList.CurrentRow.Cells["Status"].Value);
                if (ClassLibrary.Domains.Employment.JVacationStatus.Confirm == Status)//
                {
                    /// در صورتی که فایل جدیداً به لیست اضافه شده، بازیابی نمیشود، بلکه محتوای فایل از دیتاتیبل خوانده میشود
                    //if (e.RowIndex != -1)
                    /// کد آرشیو انتخاب شده در گرید
                    int Code = Convert.ToInt32(jdgRequestList[JArchiveFields.ArchiveCode.ToString(), jdgRequestList.SelectedRows[0].Index].Value);
                    JArchiveDocument archive = new JArchiveDocument();
                    archive.GetData(Code);
                    try
                    {
                        //// بازیابی محتوای آرشیو
                        content = archive._RetrieveContent(archive.ArchiveCode);
                        content.Open();
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                        archive.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
