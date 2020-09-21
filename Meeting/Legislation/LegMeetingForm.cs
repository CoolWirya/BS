using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Meeting
{
    public partial class JLegMeetingForm : ClassLibrary.JBaseForm
    {
        private int _Code;
        DataTable _dtPerson;
        DataTable _dtLegislation;
        DataTable _dtProgram;

        public JLegMeetingForm()
        {
            InitializeComponent();
            _Code = 0;
            GetPattern();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JMeeting";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JLegMeetingForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "Legal.JMeeting";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;
            //SetForm();
        }
        private void GetPattern()
        {
            try
            {
                _dtPerson = JMeetingPersonss.GetDataTable(_Code);
                jdgvPersons.DataSource = _dtPerson;
                _dtProgram = JProgram.GetDataTable(-1);
                _dtLegislation = JLegislations.GetDataTable(-1);

                //jdgvLegislation.DataSource = _dtLegislation;
                //RemoveColumn();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void RemoveColumn()
        {
            jdgvLegislation.Columns.Remove("LegislationGroup");
            jdgvLegislation.Columns.Remove("Code");
            jdgvLegislation.Columns.Remove("MeetingCode");
            //jdgvLegislation.Columns.Remove("Legislation");
            jdgvLegislation.Columns.Remove("Flow");
            jdgvLegislation.Columns.Remove("Description");
            jdgvLegislation.Columns.Remove("FlowDate");
            jdgvLegislation.Columns.Remove("PersonFlow");
        }

        private void JLegMeetingForm_Load(object sender, EventArgs e)
        {
            DataTable dtCommission = new DataTable();
            dtCommission = JCommissions.GetDataTable(0);
            DataRow dr = dtCommission.NewRow();
            dr["Code"] = -1;
            dr["name"] = "-----------";
            dtCommission.Rows.Add(dr);
            cmbCommission.DisplayMember = "Name";
            cmbCommission.ValueMember = "Code";
            cmbCommission.DataSource = dtCommission;

            if (State == JFormState.Update)
            {
                SetForm();
                btnPrint.Enabled = true;
                //RemoveColumn();
            }
        }

        private void SetForm()
        {
            try
            {
                _dtProgram = JProgram.GetDataTable(_Code);
                jdgvProgram.DataSource = _dtProgram;
                _dtPerson = JMeetingPersonss.GetDataTable(_Code);
                jdgvPersons.DataSource = _dtPerson;
                _dtLegislation = JLegislations.GetDataTable(_Code);
                JMeetings tmp = new JMeetings();
                tmp.GetData(_Code);
                cmbCommission.SelectedValue = tmp.CommissionCode;
                txtDate.Date = tmp.Date;
                txtSubject.Text = tmp.Subject;
                txtTime.Text = tmp.Time;
                txtLocation.Text = tmp.Location;
                jdgvLegislation.DataSource = null;
                jdgvLegislation.DataSource = _dtLegislation;
                RemoveColumn();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }  
        }

        private void btnaddClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbCommission.SelectedValue) == -1)
                    JMessages.Error("کمیسیون را انتخاب کنید", "error");
                else
                {
                    JLegislationForm p = new JLegislationForm();
                    p._CommissionCode = Convert.ToInt32(cmbCommission.SelectedValue);
                    if (p.ShowDialog() == DialogResult.OK)
                    {
                        DataRow dr = _dtLegislation.NewRow();
                        dr["LegislationGroup"] = p.tmpLeg.LegislationGroup;
                        dr["Legislation"] = p.tmpLeg.Legislation;
                        dr["Flow"] = p.tmpLeg.Flow;
                        dr["Description"] = p.tmpLeg.Description;
                        dr["FlowDate"] = p.tmpLeg.FlowDate;
                        dr["PersonFlow"] = p.tmpLeg.PersonFlow;
                        dr["GroupName"] = p._GroupName;
                        _dtLegislation.Rows.Add(dr);
                        jdgvLegislation.DataSource = null;
                        jdgvLegislation.DataSource = _dtLegislation;
                        btnSave.Enabled = true;
                        btnPrint.Enabled = false;
                        RemoveColumn();
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }            
        }

        private void jdgvVicarious_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvLegislation.SelectedRows != null)
                {
                    JLegislationForm p = new JLegislationForm();
                    if (_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index][0].ToString() != "")
                        p.tmpLeg.Code = (int)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index][0];
                    p.tmpLeg.LegislationGroup = (int)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["LegislationGroup"];
                    p.tmpLeg.Legislation = (string)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["Legislation"];
                    p.tmpLeg.Flow = (int)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["Flow"];
                    p.tmpLeg.Description = (string)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["Description"];
                    if (_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["FlowDate"].ToString() != "")
                        p.tmpLeg.FlowDate = (DateTime)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["FlowDate"];
                    if (_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["PersonFlow"].ToString() != "")
                        p.tmpLeg.PersonFlow = (string)_dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["PersonFlow"];
                    if (p.ShowDialog() == DialogResult.OK)
                    {
                        _dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["LegislationGroup"] = p.tmpLeg.LegislationGroup;
                        _dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["Legislation"] = p.tmpLeg.Legislation;
                        _dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["Flow"] = p.tmpLeg.Flow;
                        _dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["Description"] = p.tmpLeg.Description;
                        _dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["FlowDate"] = p.tmpLeg.FlowDate;
                        _dtLegislation.Rows[jdgvLegislation.CurrentRow.Index]["PersonFlow"] = p.tmpLeg.PersonFlow;
                        btnSave.Enabled = true;
                        btnPrint.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private void btndelClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvLegislation.CurrentRow != null)
                {
                    jdgvLegislation.Rows.Remove(jdgvLegislation.CurrentRow);
                    btnSave.Enabled = true;
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddOtherPerson_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm();
                //ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm("Died = 0");
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (((_dtPerson.Rows.Count > 0) && (_dtPerson.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPerson.Rows.Count == 0))
                    {
                        DataRow dr = _dtPerson.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        //dr["PersonType"] = 3;
                        _dtPerson.Rows.Add(dr);
                        jdgvPersons.DataSource = _dtPerson;
                        btnSave.Enabled = true;
                        btnPrint.Enabled = false;
                        //ClassLibrary.JPerson tmp = new ClassLibrary.JPerson(p.SelectedPerson.Code);
                        //if (p.SelectedPerson.PersonType == ClassLibrary.JPersonTypes.LegalPerson)
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(JPersonTypes.RealPerson);                     
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    //if (!((_dtPerson.Rows.Count != 0) && (Convert.ToInt32(_dtPerson.Rows[0]["PersonCode"]) == p.SelectedPerson.Code)))
                    //{
                        //if (_dtPerson.Rows.Count > 0)
                        //    jdgvPersons.Rows.Remove(jdgvPersons.CurrentRow);

                        if ((((_dtPerson.Rows.Count > 0) && (_dtPerson.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPerson.Rows.Count == 0)))
                        {
                            DataRow dr = _dtPerson.NewRow();
                            dr["PersonCode"] = p.SelectedPerson.Code;
                            dr["Name"] = p.SelectedPerson.Name;
                            dr["Signature"] = false;
                            _dtPerson.Rows.Add(dr);
                            jdgvPersons.DataSource = _dtPerson;
                            btnSave.Enabled = true;
                            btnPrint.Enabled = false;
                        }
                        else
                            JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                    //}
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvPersons.CurrentRow != null)
                {
                    jdgvPersons.Rows.Remove(jdgvPersons.CurrentRow);
                    btnSave.Enabled = true;
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
                this.State = JFormState.Update;
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (MessageBox.Show(JLanguages._Text("DoYouWantToSaveChanges"), "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private bool Save()
        {
            try
            {
                #region CheckControl
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ جلسه را وارد است", "error");
                    return false;
                }
                if (txtSubject.Text == "")
                {
                    JMessages.Error("موضوع را وارد کنید", "error");
                    return false;
                }
                if (Convert.ToInt32(cmbCommission.SelectedValue) == -1)
                {
                    JMessages.Error("کمیسیون را انتخاب کنید", "error");
                    return false;
                }
                #endregion

                JMeetings tmpMeetings = new JMeetings();
                tmpMeetings.CommissionCode = Convert.ToInt32(cmbCommission.SelectedValue);
                tmpMeetings.Date = txtDate.Date;
                tmpMeetings.Subject = txtSubject.Text;
                tmpMeetings.Time = txtTime.Text;
                tmpMeetings.Location = txtLocation.Text;

                JArchive.ClassName = "Legal.JMeeting";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------
                if (State != JFormState.Update)
                {

                    //----------Update Archive------------
                    _Code = tmpMeetings.Insert(_dtPerson, _dtLegislation,_dtProgram);
                    if (_Code > 0)
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                    {
                        JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                        return false;
                    }
                }
                else
                {
                    tmpMeetings.Code = _Code;
                    JArchive.ObjectCode = _Code;
                    JArchive.ArchiveList();
                    if (tmpMeetings.Update(_dtPerson, _dtLegislation, _dtProgram))
                    //_Code > 0)
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void cmbCommission_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_dtPerson = JCommissionPersonss.GetDataTable(Convert.ToInt32(cmbCommission.SelectedValue));
            //jdgvPersons.DataSource = _dtPerson;
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void btnAddCommision_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = JCommissionPersonss.GetDataTable(Convert.ToInt32(cmbCommission.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow tmpdr in dt.Rows)
                    {
                        //if (!((_dtPerson.Rows.Count != 0) && (Convert.ToInt32(_dtPerson.Rows[0]["PersonCode"]) == p.SelectedPerson.Code)))
                        //{                           
                            if ((((_dtPerson.Rows.Count > 0) && (_dtPerson.Select("PersonCode=" + tmpdr["PersonCode"].ToString()).Length < 1)) || (_dtPerson.Rows.Count == 0)))
                            {
                                DataRow dr = _dtPerson.NewRow();
                                dr["PersonCode"] = tmpdr["PersonCode"];
                                dr["Name"] = tmpdr["Name"];
                                //dr["PersonType"] = p.SelectedPerson.PersonType;
                                _dtPerson.Rows.Add(dr);
                                jdgvPersons.DataSource = _dtPerson;
                                btnSave.Enabled = true;
                                btnPrint.Enabled = false;
                            }
                            //else
                            //    JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            try
            {
                JProgramForm p = new JProgramForm();
                if (p.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr = _dtProgram.NewRow();
                    dr["Description"] = p._Desc;
                    _dtProgram.Rows.Add(dr);
                    jdgvProgram.DataSource = null;
                    jdgvProgram.DataSource = _dtProgram;
                    btnSave.Enabled = true;
                    btnPrint.Enabled = false;
                    RemoveColumn();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelProgram_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvProgram.CurrentRow != null)
                {
                    jdgvProgram.Rows.Remove(jdgvProgram.CurrentRow);
                    btnSave.Enabled = true;
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvPersons.SelectedRows != null)
                {
                    JOtherPerson tmp = new JOtherPerson(Convert.ToInt32(jdgvPersons.CurrentRow.Cells[1].Value));
                    if (tmp.Code > 0)
                    {
                        ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm(tmp);
                        p.State = JFormState.Update;
                        p.ShowDialog();
                        if (p.SelectedPerson != null)
                        {
                            jdgvPersons.CurrentRow.Cells[2].Value = p.SelectedPerson.Name;                            
                            btnSave.Enabled = true;
                            btnPrint.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvProgram_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvProgram.SelectedRows != null)
                {
                    JProgramForm p = new JProgramForm();
                    p._Desc = (string)_dtProgram.Rows[jdgvProgram.CurrentRow.Index]["Description"];
                    if (p.ShowDialog() == DialogResult.OK)
                    {
                        _dtProgram.Rows[jdgvProgram.CurrentRow.Index]["Description"] = p._Desc;
                        jdgvProgram.DataSource = _dtProgram;
                        btnSave.Enabled = true;
                        btnPrint.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
        }

        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //JSubReport[] SubReports = new JSubReport[4];
            //Array.Resize(ref SubReports, SubReports.Length);
            //SubReports[0] = new JSubReport();
            //SubReports[0].TabTitle = "افراد جلسه";
            //SubReports[0].ReportCode = 11;
            //SubReports[0].DataTable = _dtPerson;
            //_dtPerson.TableName = "افراد جلسه";
            //SubReports[1] = new JSubReport();
            //SubReports[1].TabTitle = "مصوبات";
            //SubReports[1].ReportCode = 11;
            //SubReports[1].DataTable = _dtLegislation;
            //SubReports[2] = new JSubReport();
            //SubReports[2].TabTitle = "دستور کار جلسه";
            //SubReports[2].ReportCode = 11;
            //SubReports[2].DataTable = _dtProgram;
            //SubReports[3] = new JSubReport();
            //SubReports[3].TabTitle = "جلسه";
            //SubReports[3].ReportCode = 11;
            //SubReports[3].DataTable = JMeetingss.GetDataTable(_Code);
            JDynamicReportForm DRF = new JDynamicReportForm(11);
            _dtPerson.TableName = "افراد جلسه";
            DRF.Add(_dtPerson);
            _dtLegislation.TableName = "مصوبات";
            DRF.Add(_dtLegislation);
            _dtProgram.TableName = "دستور کار جلسه";
            DRF.Add(_dtProgram);
            DataTable _Meeting = JMeetingss.GetDataTable(_Code);
            _Meeting.TableName = "جلسه";
            DRF.Add(_Meeting);

            DRF.ShowDialog();
        }
    }
}
