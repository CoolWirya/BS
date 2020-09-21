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

    public partial class JProbateForm : JBaseForm
    {
        JProbate newProbate;
        DataTable _Heirs;
        //کد شخص متوفی
        int DeadPersonCode;


        #region Constructor

        public JProbateForm()
        {
            InitializeComponent();
            newProbate = new JProbate();
            jArchiveList.ClassName = newProbate.GetType().FullName;
            _FillComboBox();
            _LoadEmptyHeirs();
        }

        private void _LoadEmptyHeirs()
        {
            _Heirs = newProbate.GetHeirs(0);
            grdHeirs.DataSource = _Heirs;
            grdHeirs.Columns[JProbateInheritanceTableEnum.Code.ToString()].Visible = false;
            grdHeirs.Columns[JProbateInheritanceTableEnum.CodeProbate.ToString()].Visible = false;
            grdHeirs.Columns[JProbateInheritanceTableEnum.RelationFamily.ToString()].Visible = false;
        }

        public JProbateForm(int pCode)
        {
            InitializeComponent();
            newProbate = new JProbate(pCode);
            jArchiveList.ClassName = newProbate.GetType().FullName;
            jArchiveList.ObjectCode = newProbate.Code;
            _FillComboBox();
            ShowData();
        }
        #endregion

        #region ShowData
        private void _FillComboBox()
        {
            //JJudicialBranches ArrayJBs = new JJudicialBranches();
            //foreach (JJudicialBranch Jb in ArrayJBs.JBs)
            //{
            //    cmbJudicialBranch.Items.Add(Jb);
            //    if (newProbate.JudicialBranchCode != 0 && newProbate.JudicialBranchCode == Jb.Code)
            //        cmbJudicialBranch.SelectedItem = Jb;
            //}
            DataTable dataBranches = JJudicialBranches.GetDataTable(0);
            cmbJudicialBranch.DataSource = dataBranches;
            cmbJudicialBranch.DisplayMember = "FullName";
            cmbJudicialBranch.ValueMember = "Code";
        }
        private void ShowData()
        {
            txtDateIssued.Date = newProbate.Dateissued;

            txtCode.Text = newProbate.Code.ToString();
            //نمایش اطلاعات درخواست کننده گواهی فوت
            JPerson ApplicatorPerson = new JPerson(newProbate.ApplicatorCode);
            txtApplicatorCode.Text = newProbate.ApplicatorCode.ToString();
            labApplicatorName.Text = ApplicatorPerson.Name;
            labApplicatorFan.Text = ApplicatorPerson.Fam;
            labApplicatorNationalCode.Text = ApplicatorPerson.ShMeli;
            //labApplicatorShsh.Text = ApplicatorPerson.ShSh;
            //labApplicatoreDateOfBirth.Text =JDateTime.FarsiDate(ApplicatorPerson.BthDate);
            labApplicatorFatherName.Text = ApplicatorPerson.FatherName;
            //نمایش اطلاعات شخص فوت شده
            JPerson DeadPerson = new JPerson(newProbate.DeadCode);
            txtDeadCode.Text = DeadPerson.Code.ToString();
            labDeadName.Text = DeadPerson.Name;
            labDeadFamily.Text = DeadPerson.Fam;
            labDeadshsh.Text = DeadPerson.ShSh;
            labDeadNationalCode.Text = DeadPerson.ShMeli;
            labDeadDateofbirth.Text =JDateTime.FarsiDate(DeadPerson.BthDate);
            labDeaFatherName.Text = DeadPerson.FatherName;
            _Heirs = newProbate.GetHeirs(newProbate.Code);

            grdHeirs.DataSource = _Heirs;
            grdHeirs.Columns[JProbateInheritanceTableEnum.Code.ToString()].Visible = false;
            grdHeirs.Columns[JProbateInheritanceTableEnum.CodeProbate.ToString()].Visible = false;
            grdHeirs.Columns[JProbateInheritanceTableEnum.RelationFamily.ToString()].Visible = false;
            btnSave.Enabled = false;
            //نمایش اطلاعات گواهی فوت
            JDeadPerson JDP = new JDeadPerson(DeadPerson.Code);
            labDeathCertificateDate.Text =JDateTime.FarsiDate(JDP.DeathCertificateDate);
            labDeadNo.Text = JDP.DieNumber;
            labDeadDate.Text =JDateTime.FarsiDate( JDP.DieDate);

        }
        #endregion

        private void addApplicator_Click(object sender, EventArgs e)
        {
            int ApplicatorCode;
            JFindPersonForm FPF = new JFindPersonForm(JPersonTypes.RealPerson, "Died = 0");
            FPF.ShowDialog();
            if (FPF.SelectedPerson != null)
            {
                ApplicatorCode = FPF.SelectedPerson.Code;
                JPerson JP = new JPerson();
                JP.getData(ApplicatorCode);
                txtApplicatorCode.Text = JP.Code.ToString();
                labApplicatorName.Text = JP.Name.ToString();
                labApplicatorFan.Text = JP.Fam.ToString();
                //labApplicatorShsh.Text = JP.ShSh.ToString();
                labApplicatorFatherName.Text = JP.FatherName.ToString();
                if (JP.ShMeli != null)
                    labApplicatorNationalCode.Text = JP.ShMeli.ToString();
                else
                    labApplicatorNationalCode.Text = "";
                //labApplicatoreDateOfBirth.Text = JP.BthDate.ToString();
            }
        }

       

        private void AddDiePerson_Click(object sender, EventArgs e)
        {

            JFindPersonForm FPF = new JFindPersonForm(JPersonTypes.RealPerson);
            FPF.ShowDialog();
            if (FPF.SelectedPerson != null)
            {
                labDeadDate.Text = "";
                labDeadNo.Text = "";
                labDeathCertificateDate.Text = "";
                DeadPersonCode = FPF.SelectedPerson.Code;
                if (JProbate.FindDead(DeadPersonCode))
                {
                    JMessages.Error("ProbateExists", "Error");
                    return;
                }
                JDeadPerson JDP = new JDeadPerson(DeadPersonCode);
                if (JDP.GetData())
                {
                    _ShowDeadInfo(DeadPersonCode, JDP);
                }
                else
                {

                    if (JMessages.Question(" برای این شخص گواهی فوت ثبت نشده است.آیا می خواهید گواهی فوت را ثبت کنید؟", "خطا ") == DialogResult.Yes)
                    {
                        JDP.DiePerson();
                        labDeadDate.Text = JDateTime.FarsiDate(JDP.DieDate);
                        labDeadNo.Text = JDP.DieNumber;
                        labDeathCertificateDate.Text = JDateTime.FarsiDate(JDP.DeathCertificateDate);
                        _ShowDeadInfo(DeadPersonCode, JDP);
                    }                  
                }
                cmbJudicialBranch.Focus();
            }


        }

        private void _ShowDeadInfo(int pDeadCode,JDeadPerson JDP)
        {
            if (pDeadCode == 0)
                return;
            JPerson JP = new JPerson();
            if (JP.getData(pDeadCode))
            {
                txtDeadCode.Text = JP.Code.ToString();
                labDeadName.Text = JP.Name.ToString();
                labDeadFamily.Text = JP.Fam.ToString();
                labDeadshsh.Text = JP.ShSh.ToString();
                labDeaFatherName.Text = JP.FatherName;
                labDeadNationalCode.Text = JP.ShMeli;
                labDeadDateofbirth.Text =JDateTime.FarsiDate(JP.BthDate);        
                labDeadDate.Text =JDateTime.FarsiDate(JDP.DieDate);
                labDeadNo.Text = JDP.DieNumber;
                labDeathCertificateDate.Text =JDateTime.FarsiDate(JDP.DeathCertificateDate);
            }
            else
                JMessages.Error("PersonCodeNotFound", "Error");
        }

        private void cmbJudicialBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
           // JJudicialComplex JJC = new JJudicialComplex();
           // //JJC.GetData(((JJudicialBranch)cmbJudicialBranch.SelectedItem).JudicialComplex);
           // JJC.GetData((new JJudicialBranch(Convert.ToInt32((((DataRowView)cmbJudicialBranch.SelectedValue)["Code"])))).JudicialComplex);
            // labJudicialComplex.Text =JJC.Name ;
            // labAddressJudicialComplex.Text = (JJC.Address);
            labJudicialComplex.Text = ((System.Data.DataRowView)cmbJudicialBranch.SelectedItem)["JudicialComplex"].ToString();
            labAddressJudicialComplex.Text = ((System.Data.DataRowView)cmbJudicialBranch.SelectedItem)["Address"].ToString();

            btnSave.Enabled = true;

        }

        private bool Save()
        {
            #region Check Controls
            if (cmbJudicialBranch.SelectedItem == null)
            {
                JMessages.Error("PleaseSelectJudicialBranch", "Error");
                cmbJudicialBranch.Focus();
                return false;
            }
            if (txtDateIssued.Date == DateTime.MinValue)
            {
                string[] parameters = { "@Value" };
                string[] values = { "Date" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtDateIssued.Focus();
                return false;
            }
            if (txtDeadCode.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Dead" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtDeadCode.Focus();
                return false;
            }
            if (txtApplicatorCode.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Applicator" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtApplicatorCode.Focus();
                return false;
            }
            if (_Heirs.Rows.Count == 0)
            {
                
                JMessages.Error("Please select Hairs", "Error");
                AddHeirs.Focus();
                return false;
            }
            #endregion
            newProbate.Dateissued = txtDateIssued.Date;
            newProbate.ApplicatorCode = Convert.ToInt32(txtApplicatorCode.Text);
            newProbate.DeadCode = Convert.ToInt32(txtDeadCode.Text);
            newProbate.JudicialBranchCode = Convert.ToInt32(cmbJudicialBranch.SelectedValue);
            newProbate.Heirs = _Heirs;
            if (this.State == JFormState.Insert)
            {
                int code = newProbate.Insert();
                if (code > 0)
                {
                    txtCode.Text = code.ToString();
                    jArchiveList.ObjectCode = newProbate.Code;
                    jArchiveList.ArchiveList();
                    State = JFormState.Update;
                    btnSave.Enabled = false;
                    return true;
                }
            }
            else
            {
                newProbate.Code = Convert.ToInt32(txtCode.Text);
                if (newProbate.Update())
                {
                    jArchiveList.ArchiveList();
                    btnSave.Enabled = false;
                    return true;
                }
            }
            return false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
        }

        private void AddHeirs_Click(object sender, EventArgs e)
        {
            JFindPersonForm FPF = new JFindPersonForm(JPersonTypes.RealPerson, "Died=0");
            FPF.MultiSelect = true;
            FPF.ShowDialog();
            foreach (int _PersonCode in FPF.SelectedPersonsCode)
            {
                DataRow heirRow = _Heirs.NewRow();
                if (_PersonCode != 0)
                {
                    
                    JPerson person = new JPerson(_PersonCode);
                    if (_Heirs.Select(JProbateInheritanceTableEnum.CodePerson + "=" + _PersonCode).Length > 0)
                    {
                        JMessages.Error("PersonExistsInProbate", person.Name + " " + person.Fam);
                        continue;
                        //return;
                    }
                    JInheritForm inheritForm = new JInheritForm(person.Name + " " + person.Fam);
                    inheritForm.ShowDialog();
//                    if (inheritForm.ShowDialog() == DialogResult.OK)
                    {
                        heirRow[JProbateInheritanceTableEnum.CodeProbate.ToString()] = newProbate.Code;
                        heirRow[JProbateInheritanceTableEnum.CodePerson.ToString()] = person.Code;
                        heirRow[JProbateInheritanceTableEnum.Name.ToString()] = person.Name;
                        heirRow[JProbateInheritanceTableEnum.Fam.ToString()] = person.Fam;
                        heirRow[JProbateInheritanceTableEnum.ShSh.ToString()] = person.ShSh;
                        heirRow[JProbateInheritanceTableEnum.inherText.ToString()] = inheritForm.InherText;
                        heirRow[JProbateInheritanceTableEnum.RelationFamily.ToString()] = inheritForm.RelationFamilyCode;
                        heirRow[JProbateInheritanceTableEnum.RelationFamilyName.ToString()] = inheritForm.RelationFamilyName;
                        heirRow["InherDesc"] = inheritForm.InherDesc;

                        _Heirs.Rows.Add(heirRow);
                    }
                    btnSave.Enabled = true;
                }
            }

        }

        private void DelHeirs_Click(object sender, EventArgs e)
        {
            if (_Heirs.Rows.Count == 0)
                return;
            if (grdHeirs.CurrentRow == null)
                return;
            if (JMessages.Question("AreYouSureDeletePersonFromList", "OK") == DialogResult.Yes)
            {
                grdHeirs.Rows.Remove(grdHeirs.CurrentRow);
                btnSave.Enabled = true;
            }
        }


        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                btnSave.Enabled = false;
        }

        private void txtDeadCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtApplicatorCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

        }

        private void jArchiveList1_AfterFileAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;

        }

        private void Parties_Enter(object sender, EventArgs e)
        {
            //InheritorDataTable = JProbate
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)grdHeirs.SelectedRows[0].DataBoundItem).Row;
            int share =Convert.ToInt32(row[JProbateInheritanceTableEnum.inherText.ToString()].ToString().Split('/')[0]);
            int AllShare =Convert.ToInt32(row[JProbateInheritanceTableEnum.inherText.ToString()].ToString().Split('/')[1]);
            int relation = Convert.ToInt32(row[JProbateInheritanceTableEnum.RelationFamily.ToString()]);
            JInheritForm inheritForm = new JInheritForm(row[JProbateInheritanceTableEnum.Name.ToString()].ToString() + " " + row[JProbateInheritanceTableEnum.Fam.ToString()].ToString(), share, AllShare
                , relation, row["InherDesc"].ToString());
            if (inheritForm.ShowDialog() == DialogResult.OK)
            {
                row[JProbateInheritanceTableEnum.inherText.ToString()] = inheritForm.InherText;
                row[JProbateInheritanceTableEnum.RelationFamily.ToString()] = inheritForm.RelationFamilyCode;
                row[JProbateInheritanceTableEnum.RelationFamilyName.ToString()] = inheritForm.RelationFamilyName;
                row["InherDesc"] = inheritForm.InherDesc;
                btnSave.Enabled = true;
            }
        }

        private void txtDeadCode_Leave(object sender, EventArgs e)
        {
            JDeadPerson JDP = new JDeadPerson(txtDeadCode.IntValue);
            if (JDP.GetData())
            {
                _ShowDeadInfo(txtDeadCode.IntValue, JDP);
            }
           

        }

        private void JProbateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (btnSave.Enabled)
            {
                DialogResult result = JMessages.Confirm("DoYouWantTotSaveChanges?", "SaveChanges");
                if (result == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    Close();
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else
                    e.Cancel = false;
            }
        }

       

        private void JProbateForm_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        private void btnCalculateShare_Click(object sender, EventArgs e)
        {
            JCalculateShare CShare = new JCalculateShare();
            if (CShare.ShowDialog() == DialogResult.OK)
            {
                foreach(DataRow row in _Heirs.Rows)
                {
                    foreach (DataRow calcRow in CShare.resultTable.Rows)
                    {
                        if (row["RelationFamilyName"].ToString() == calcRow["FamilyRelation"].ToString())
                        {
                            row["inherText"] = calcRow["inherText"]; 
                        }
                    }
                
                }
            }
        }

        private void grdHeirs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }


             
       
       
       
    }
}
