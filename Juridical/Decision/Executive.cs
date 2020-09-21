using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JExecutiveForm : ClassLibrary.JBaseForm
    {

        int _Code;
        int _DecisionCode;
        DataTable _dtPetition = new DataTable();
        DataTable _dtFey = new DataTable();
        DataTable _dtAsset = new DataTable();

        public JExecutiveForm(int pCode)
        {
            InitializeComponent();

            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveExe.ClassName = "Legal.JExecutive";
            jArchiveExe.SubjectCode = 0;
            jArchiveExe.PlaceCode = 0;
            jArchiveExe.ObjectCode = _Code;            
        }

        private void JExecutiveForm_Load(object sender, EventArgs e)
        {
            PatternDt();
            if (State == JFormState.Update)
                Set_Form();
        }

        #region Methods

        private void PatternDt()
        {
            _dtPetition = JPersonPetition.GetAllData(-1);
            _dtFey = JPersonPetition.GetAllData(-1);
            _dtAsset = JFinanceExecute.GetAllByExecute(0);
        }

        private void Set_Form()
        {
           JExecutive tmpExecutive = new JExecutive(_Code);
           _DecisionCode =tmpExecutive.DecisionCode;
           txtDate.Date =tmpExecutive.ExecuteDate;
           txtNumClase.Text= tmpExecutive.ExecuteNum;
           txtDesc.Text = tmpExecutive.ExeDesc;
           txtNumClase2.Text = tmpExecutive.ExeNum;

           //-----------پر کردن اطلاعات خوامده خواهان
           _dtPetition = JPersonExecutive.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionExecute);
           _dtFey = JPersonExecutive.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.FeyExecute);
           jdgvWinner.DataSource = _dtPetition;
           jdgvFey.DataSource = _dtFey;
           _dtFey = JPersonPetition.GetAllData(_Code);
           _dtAsset = JFinanceExecute.GetAllSubject(_Code);
           jDGlistAsset.DataSource = _dtAsset;
           JDecision tmp = new JDecision(_DecisionCode);
           txtNumber.Text = tmp.number;
           btnSave.Enabled = false;
        }

        private bool Save()
        {
            #region CheckData

                if (_DecisionCode == 0)
                {
                    JMessages.Error(".رای دادگاه را انتخاب کنید.", "error");
                    return false;
                }
                if (txtNumClase2.Text.Trim() == "")
                {
                    JMessages.Error(".شماره کلاسه اجرائی را انتخاب کنید.", "error");
                    return false;
                }
                if (txtNumClase.Text.Trim() == "")
                {
                    JMessages.Error(".شماره کلاسه اجرا احکام را انتخاب کنید.", "error");
                    return false;
                }
                if (txtDate.Date == DateTime.MinValue )
                {
                    JMessages.Error(".تاریخ اجراء را انتخاب کنید.", "error");
                    return false;
                }
                if (jdgvFey.RowCount <= 0)
                {
                    JMessages.Error(". محکوم له را انتخاب کنید.", "error");
                    return false;
                }
                if (jdgvWinner.RowCount <= 0)
                {
                    JMessages.Error(". محکوم علیه  را انتخاب کنید.", "error");
                    return false;
                }
            
            #endregion
            
            JExecutive tmpExecutive = new JExecutive();            
            tmpExecutive.DecisionCode = _DecisionCode;
            tmpExecutive.ExecuteDate = txtDate.Date;
            tmpExecutive.ExecuteNum = txtNumClase.Text;
            tmpExecutive.ExeDesc = txtDesc.Text;
            tmpExecutive.ExeNum = txtNumClase2.Text;

                jArchiveExe.ClassName = "Legal.JExecutive";
                jArchiveExe.SubjectCode = 0;
                jArchiveExe.PlaceCode = 0;

                //---------ویرایش------------
                if (State == JFormState.Update)
                {
                    //----------Update Archive------------
                    tmpExecutive.Code = _Code;
                    jArchiveExe.ObjectCode = _Code;
                    jArchiveExe.ArchiveList();
                    if (tmpExecutive.Update(_dtPetition, _dtFey, _dtAsset))
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                }
                else
                {
                    _Code = tmpExecutive.Insert(_dtPetition, _dtFey, _dtAsset);
                    if (_Code>0)
                    {
                        jArchiveExe.ObjectCode = tmpExecutive.Code;
                        jArchiveExe.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
               }
            return false;
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
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

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtNumClase_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtNumClase2_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnAddWinner_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text != "")
                {
                    ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                    p.ShowDialog();
                    if (p.SelectedPerson != null)
                    {
                        if ((((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0)) &&
                        (((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)))
                        {
                            DataRow dr = _dtPetition.NewRow();
                            dr["PersonCode"] = p.SelectedPerson.Code;
                            dr["Name"] = p.SelectedPerson.Name;
                            dr["Type"] = p.SelectedPerson.PersonType;
                            _dtPetition.Rows.Add(dr);
                            jdgvWinner.DataSource = _dtPetition;
                            btnSave.Enabled = true;
                        }
                        else
                            JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                    }
                }
                else
                    JMessages.Message("ابتدا رای دادگاه را انتخاب کنید ", "", JMessageType.Information);
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
                if (txtNumber.Text != "")
                {
                    ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                    p.ShowDialog();
                    if (p.SelectedPerson != null)
                    {
                        if ((((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)) &&
                            (((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0)))
                        {
                            DataRow dr = _dtFey.NewRow();
                            dr["PersonCode"] = p.SelectedPerson.Code;
                            dr["Name"] = p.SelectedPerson.Name;
                            dr["Type"] = p.SelectedPerson.PersonType;
                            _dtFey.Rows.Add(dr);
                            jdgvFey.DataSource = _dtFey;
                            btnSave.Enabled = true;
                        }
                        else
                            JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                    }
                }
                else
                    JMessages.Message("ابتدا رای دادگاه را انتخاب کنید ", "", JMessageType.Information);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btndelWinner_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvWinner.CurrentRow != null)
                {
                    jdgvWinner.Rows.Remove(jdgvWinner.CurrentRow);
                    btnSave.Enabled = true;
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
                if (jdgvFey.CurrentRow != null)
                {
                    jdgvFey.Rows.Remove(jdgvFey.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSearchPetition_Click(object sender, EventArgs e)
        {
            JDecisionSearchForm p = new JDecisionSearchForm();
            p.ShowDialog();
            _DecisionCode = p._Code;
            JDecision tmp = new JDecision(_DecisionCode);
            txtNumber.Text = tmp.number;
            _dtPetition = JPersonPetition.GetAllDataType(tmp.PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);
            _dtFey = JPersonPetition.GetAllDataType(tmp.PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Petition);
            jdgvWinner.DataSource = _dtPetition;
            jdgvFey.DataSource = _dtFey;
        }
        #endregion

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            try
            {
                Finance.JAssetSearchForm p = new Finance.JAssetSearchForm();
                if (p.ShowDialog() != DialogResult.OK)
                    return;
                Finance.JAsset tmp = new Finance.JAsset(p._Code);
                if (tmp.Code > 0)
                {
                    if (((_dtAsset.Rows.Count > 0) && (_dtAsset.Select("FinanceCode=" + p._Code.ToString()).Length < 1)) || (_dtAsset.Rows.Count == 0))
                    {
                        DataRow dr = _dtAsset.NewRow();
                        dr["FinanceCode"] = p._Code.ToString();
                        dr["Comment"] = SetCommentText(tmp.ClassName, tmp.ObjectCode);
                        _dtAsset.Rows.Add(dr);
                        jDGlistAsset.DataSource = _dtAsset;
                        btnSave.Enabled = true;
                    }
                    else
                        JMessages.Message("Asset is Repeated ", "", JMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAssetCode"></param>
        private string SetCommentText(string pClassName, int pObjectCode)
        {
            JAction CommentAction = new JAction("GetAssetType", pClassName + ".GetAssetComment", new object[] { pObjectCode }, null);
            string Comment = (string)CommentAction.run();

            JAction unitAction = new JAction("GetAssetType", pClassName + ".GetAssetUnit");
            string unit = (string)unitAction.run();

            return Comment;
        }

        private void btnDelAsset_Click(object sender, EventArgs e)
        {
            try
            {
                if (jDGlistAsset.CurrentRow != null)
                {
                    jDGlistAsset.Rows.Remove(jDGlistAsset.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

    }
}
