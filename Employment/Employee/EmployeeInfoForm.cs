using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using OfficeWord;
using Finance;

namespace Employment
{
    public partial class JEmployeeInfoForm : JBaseForm
    {
        int _Code;
        int _CompanyCode;

        public JEmployeeInfoForm(int pCompanyCode)
        {
            InitializeComponent(); 
            _Code = 0;
            _CompanyCode = pCompanyCode;
            _dtAll = JEmployeeInfos.GetDataTable(0, "");
            FillArchive();
        }

        DataTable _dtAll;
        int i = 0;
        public JEmployeeInfoForm(int pCode,int pOrgCode)
        {
            try
            {
                InitializeComponent();
                InitGridView();
                _Code = pCode;
                PersonCode.SelectedCode = pOrgCode;
                //if (pCode != 0)
                //    PersonCode.Enabled = false;
                _dtAll = JEmployeeInfos.GetDataTable(0, "");
                DataRow[] dr = _dtAll.Select("pCode=" + _Code);
                i = _dtAll.Rows.IndexOf(dr[0]);
                FillArchive();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void FillArchive()
        {
            jPropertyValueUserControl1.ClassName = "Employment.JEmployeeInfoForm";
            jPropertyValueUserControl1.ObjectCode = ClassLibrary.Domains.JGlobal.JPropertyType.Employment.GetHashCode();
            ArchiveList.ClassName = "Employment.JEmployeeInfoForm";
            ArchiveList.ObjectCode = _Code;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }

        private void Set_Form()
        {
            JEmployeeInfo tmpEmployeeInfo = new JEmployeeInfo(_Code);
            _CompanyCode = tmpEmployeeInfo.CompanyCode;
            imgPicture.Image = null;
            JPerson _Person = new JPerson(tmpEmployeeInfo.pCode);
            JFile _PersonImage;
            ////-------------------- بازیابی تصویر شخص و امضاء از بایگانی اسناد -----------------------///
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                if (archive.Retrieve(_Person.PersonImageCode)) 
                {
                    _PersonImage = archive.Content;
                    archive.Dispose();
                    if (_PersonImage != null)
                        imgPicture.Image = System.Drawing.Image.FromStream(_PersonImage.Stream);
                }

            cmbJobTitle.SelectedValue = tmpEmployeeInfo.JobTitleCode;
            cmbPostTitle.SelectedValue = tmpEmployeeInfo.PostTitleCode;
            _ItemGoods = tmpEmployeeInfo.ListFamily;
            jdgvFam.DataSource = _ItemGoods;

            _dtKaraneh = JKaraneh.GetDataTable(_Code);
            _dtSeperation = JSeparation.GetDataTable(_Code);
            jdgvKaraneh.DataSource = _dtKaraneh;
            jdgvSeperation.DataSource = _dtSeperation;

            txtPersonCart.Text = tmpEmployeeInfo.PersonCart.ToString();
            txtPersonNum.Text = tmpEmployeeInfo.PersonNumber.ToString();
            PersonCode.SelectedCode = tmpEmployeeInfo.pCode;
            chkActive.Checked = tmpEmployeeInfo.Active;
            cmbActivity.SelectedValue = tmpEmployeeInfo.Activity;

            cmbSector.SelectedValue = tmpEmployeeInfo.Sector;

            cmbDegree.SelectedValue = tmpEmployeeInfo.id_maghta;
            cmbFeild.SelectedValue = tmpEmployeeInfo.id_cource;
            txtLocrecive.Text = tmpEmployeeInfo.graduatedPlace;
            DateRecive.Date = tmpEmployeeInfo.graduatedDate;
            if (tmpEmployeeInfo.firstDrivingCard)
                chkfirstDrivingCard.Checked = true;
            else
                chkfirstDrivingCard.Checked = false;
            if (tmpEmployeeInfo.secondDrivingCard)
                chksecondDrivingCard.Checked = true;
            else
                chksecondDrivingCard.Checked = false;
            if (tmpEmployeeInfo.motorCard)
                chkmotorCard.Checked = true;
            else
                chkmotorCard.Checked = false;
            cmbMilitary.SelectedValue = tmpEmployeeInfo.id_militay;
            txtmoafReson.Text = tmpEmployeeInfo.moafReson;
            txtservicePlace.Text = tmpEmployeeInfo.servicePlace;
            DateServiceStart.Date = tmpEmployeeInfo.ServiceStart;
            DateServiceEnd.Date = tmpEmployeeInfo.ServiceEnd;
            txtwarExpereience.Text = tmpEmployeeInfo.warExpereience;
            txtbasigmembership.Text = tmpEmployeeInfo.basigmembership;
            if (tmpEmployeeInfo.ShahidFamily)
                chkShahidFamily.Checked = true;
            else
                chkShahidFamily.Checked = false;
            txtjanbazikind.Text = tmpEmployeeInfo.janbazikind;
            txtjanbazPercent.Text = tmpEmployeeInfo.janbazPercent.ToString();
            cmbHouseStatus.SelectedValue = tmpEmployeeInfo.id_maskan;
            if (tmpEmployeeInfo.azadefamily)
                chkazadefamily.Checked = true;
            else
                chkazadefamily.Checked = false;
            if (tmpEmployeeInfo.janbaz)
                chkjanbaz.Checked = true;
            else
                chkjanbaz.Checked = false;
            cmbFamShahid.SelectedValue = tmpEmployeeInfo.nesbatShahid;
            cmbFamJanbaz.SelectedValue = tmpEmployeeInfo.nesbatJanbaz;
            cmbFamAzade.SelectedValue = tmpEmployeeInfo.nesbatAzade;
            txtbimeNom.Text = tmpEmployeeInfo.bimeNom;
            txtdrivingcartNo.Text = tmpEmployeeInfo.drivingcartNo;
            DateSanavat.Date = tmpEmployeeInfo.lastSanavet;
            DateEmployee.Date = tmpEmployeeInfo.employeeDate;
            //tmpEmployeeInfo.id_delayGroup;
            txtaccountnumber.Text = tmpEmployeeInfo.accountnumber;
            cmbBank.SelectedValue = tmpEmployeeInfo.id_bank;
            txtParvande.Text = tmpEmployeeInfo.id_parvandeh;
            jPropertyValueUserControl1.ObjectCode = 12;

            jPropertyValueUserControl1.ObjectCode = ClassLibrary.Domains.JGlobal.JPropertyType.Employment.GetHashCode(); ;
            jPropertyValueUserControl1.ValueObjectCode = _Code;
            jPropertyValueUserControl1.RefreshFields();
            jPropertyValueUserControl1.RefreshValue();

            groupBox2.Text = PersonCode.lbName.Text + " " + PersonCode.lbLastName.Text;
            lblAddress.Text = PersonCode.lblAddress.Text + " " + PersonCode.lblPhone.Text + " - " + PersonCode.lblMobile.Text + " - ";            
        }

        private bool Save()
        {
            try
            {
                #region CheckData
                if (txtPersonCart.Text == "")
                {
                    JMessages.Message(" لطفا شماره کارت را وارد کنید ", "", JMessageType.Error);
                    return false;
                }

                if (PersonCode.SelectedCode == 0)
                {
                    JMessages.Message(" لطفا شخص را انتخاب کنید ", "", JMessageType.Error);
                    return false;
                }
                #endregion

                JEmployeeInfo tmpEmployeeInfo = new JEmployeeInfo();
                tmpEmployeeInfo.JobTitleCode = Convert.ToInt32(cmbJobTitle.SelectedValue);
                tmpEmployeeInfo.PostTitleCode = Convert.ToInt32(cmbPostTitle.SelectedValue);
                tmpEmployeeInfo.PersonCart = Convert.ToInt32(txtPersonCart.Text);
                tmpEmployeeInfo.PersonNumber = Convert.ToInt32(txtPersonNum.Text);
                tmpEmployeeInfo.pCode = PersonCode.SelectedCode;
                if (chkActive.Checked)
                    tmpEmployeeInfo.Active = true;
                else
                    tmpEmployeeInfo.Active = false;
                if (cmbActivity.SelectedValue != null)
                    tmpEmployeeInfo.Activity = (int)cmbActivity.SelectedValue;
                if (cmbSector.SelectedValue != null)
                    tmpEmployeeInfo.Sector = (int)cmbSector.SelectedValue;

                tmpEmployeeInfo.id_maghta = Convert.ToInt32(cmbDegree.SelectedValue);
                tmpEmployeeInfo.id_cource = Convert.ToInt32(cmbFeild.SelectedValue);
                tmpEmployeeInfo.graduatedPlace = txtLocrecive.Text;
                tmpEmployeeInfo.graduatedDate = DateRecive.Date;
                if (chkfirstDrivingCard.Checked)
                    tmpEmployeeInfo.firstDrivingCard = true;
                else
                    tmpEmployeeInfo.firstDrivingCard = false;
                if (chksecondDrivingCard.Checked)
                    tmpEmployeeInfo.secondDrivingCard = true;
                else
                    tmpEmployeeInfo.secondDrivingCard = false;
                if (chkmotorCard.Checked)
                    tmpEmployeeInfo.motorCard = true;
                else
                    tmpEmployeeInfo.motorCard = false;
                tmpEmployeeInfo.id_militay = Convert.ToInt32(cmbMilitary.SelectedValue);
                tmpEmployeeInfo.moafReson = txtmoafReson.Text;
                tmpEmployeeInfo.servicePlace = txtservicePlace.Text;
                //if (DateServiceStart.Date != DateTime.MinValue)
                tmpEmployeeInfo.ServiceStart = DateServiceStart.Date;
                //if (DateServiceEnd.Date != DateTime.MinValue)
                tmpEmployeeInfo.ServiceEnd = DateServiceEnd.Date;
                tmpEmployeeInfo.warExpereience = txtwarExpereience.Text;
                tmpEmployeeInfo.basigmembership = txtbasigmembership.Text;
                if (chkShahidFamily.Checked)
                    tmpEmployeeInfo.ShahidFamily = true;
                else
                    tmpEmployeeInfo.ShahidFamily = false;
                tmpEmployeeInfo.janbazikind = txtjanbazikind.Text;
                if (txtjanbazPercent.Text != "")
                    tmpEmployeeInfo.janbazPercent = Convert.ToDecimal(txtjanbazPercent.Text);
                tmpEmployeeInfo.id_maskan = Convert.ToInt32(cmbHouseStatus.SelectedValue);
                if (chkazadefamily.Checked)
                    tmpEmployeeInfo.azadefamily = true;
                else
                    tmpEmployeeInfo.azadefamily = false;
                if (chkjanbaz.Checked)
                    tmpEmployeeInfo.janbaz = true;
                else
                    tmpEmployeeInfo.janbaz = false;
                tmpEmployeeInfo.nesbatShahid = Convert.ToInt32(cmbFamShahid.SelectedValue);
                tmpEmployeeInfo.nesbatJanbaz = Convert.ToInt32(cmbFamJanbaz.SelectedValue);
                tmpEmployeeInfo.nesbatAzade = Convert.ToInt32(cmbFamAzade.SelectedValue);
                tmpEmployeeInfo.bimeNom = txtbimeNom.Text;
                tmpEmployeeInfo.drivingcartNo = txtdrivingcartNo.Text;
                tmpEmployeeInfo.lastSanavet = DateSanavat.Date;
                tmpEmployeeInfo.employeeDate = DateEmployee.Date;
                //tmpEmployeeInfo.id_delayGroup;
                tmpEmployeeInfo.accountnumber = txtaccountnumber.Text;
                tmpEmployeeInfo.id_bank = Convert.ToInt32(cmbBank.SelectedValue);
                tmpEmployeeInfo.id_parvandeh = txtParvande.Text;
                tmpEmployeeInfo.ListFamily = _ItemGoods;
                tmpEmployeeInfo.CompanyCode = _CompanyCode;

                if (State == JFormState.Insert)
                {
                    _Code = tmpEmployeeInfo.Insert();
                    if (_Code > 0)
                    {
                        jPropertyValueUserControl1.ValueObjectCode = _Code;
                        jPropertyValueUserControl1.Save();
                        ArchiveList.ObjectCode = _Code;
                        ArchiveList.ArchiveList();
                        JMessages.Message("Insert Successfuly", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Insert Not Successfuly", "", JMessageType.Error);
                }
                else
                {
                    tmpEmployeeInfo.Code = _Code;
                    if (tmpEmployeeInfo.Update())
                    {
                        jPropertyValueUserControl1.ValueObjectCode = _Code;
                        jPropertyValueUserControl1.Save();
                        ArchiveList.ObjectCode = _Code;
                        ArchiveList.ArchiveList();
                        JMessages.Message("Update Successfuly", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Update Not Successfuly", "", JMessageType.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Save();
            //if (Save())
            //    Close();
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

        private void FillCombo()
        {
            //پرکردن کمبو فعالیت
            JActivityTypes JAc = new JActivityTypes();
            JAc.SetComboBox(cmbActivity, -1);

            JAc.SetComboBox(cmbSector, -1);

            JDegreeTypes Degree = new JDegreeTypes();
            Degree.SetComboBox(cmbDegree, -1);

            JFieldTypes Field = new JFieldTypes();
            Field.SetComboBox(cmbFeild, -1);

            JHouseStateTypes HouseState = new JHouseStateTypes();
            HouseState.SetComboBox(cmbHouseStatus, -1);

            JmilitaryTypes Military = new JmilitaryTypes();
            Military.SetComboBox(cmbMilitary, -1);

            JSeparationTypes Separation = new JSeparationTypes();
            Separation.SetComboBox(cmbSeparation, -1);

            ClassLibrary.JFamilyRelationTypes FamilyRelation = new ClassLibrary.JFamilyRelationTypes();
            FamilyRelation.SetComboBox(cmbFamAzade, -1);
            FamilyRelation.SetComboBox(cmbFamShahid, -1);
            FamilyRelation.SetComboBox(cmbFamJanbaz, -1);

            ClassLibrary.JBankTypes Bank = new ClassLibrary.JBankTypes();
            Bank.SetComboBox(cmbBank, -1);

            cmbFamRelation.DisplayMember = "FarsiName";
            cmbFamRelation.ValueMember = "Code";
            cmbFamRelation.DataSource = ClassLibrary.Domains.JGlobal.JFamily.GetData();


            cmbJobTitle.DisplayMember = "TitleCodeLevel";
            cmbJobTitle.ValueMember = "code";
            cmbJobTitle.DataSource = JJobTitles.GetDataTable(0,_CompanyCode);
            cmbJobTitle.SelectedValue = -1;

            cmbPostTitle.DisplayMember = "Title";
            cmbPostTitle.ValueMember = "code";
            cmbPostTitle.DataSource = JPostTitles.GetDataTable(0,_CompanyCode);
            cmbPostTitle.SelectedValue = -1;

            cmbKaranehRange.DisplayMember = "Description";
            cmbKaranehRange.ValueMember = "code";
            cmbKaranehRange.DataSource = JKaranehRanges.GetDataTable(0);            
        }

        private void JEmployeeInfoForm_Load(object sender, EventArgs e)
        {
            if (JPermission.CheckPermission("Employment.JEStaticNode.CheckPermissionMenu", false))
            {
                groupBox8.Visible = true;
                jdgvKaraneh.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Visible = true;
            }
            else
            {
                groupBox8.Visible = false;
                jdgvKaraneh.Visible = false;
                groupBox2.Visible = false;
                groupBox1.Visible = false;
            }

            FillCombo();           
            _ItemGoods = JFamilyInfomation.GetDataTable(-1);
            _dtKaraneh = JKaraneh.GetDataTable(-1);
            _dtSeperation = JSeparation.GetDataTable(-1);
            jdgvKaraneh.DataSource = _dtKaraneh;
            jdgvSeperation.DataSource = _dtSeperation;

            jdgvFam.DataSource = _ItemGoods;
            jdgvFam.Columns["Code"].Visible = false;
            jdgvFam.Columns["PCode"].Visible = false;
            jdgvFam.Columns["NesbatType"].Visible = false;

            jdgvFam.Columns["PCode"].ReadOnly = true;
            jdgvFam.Columns["Name"].ReadOnly = true;
            jdgvFam.Columns["Nesbat"].ReadOnly = true;

            jdgvKaraneh.Columns["id_employee"].Visible = false;
            jdgvKaraneh.Columns["id_karaneRange"].Visible = false;

            if (State == JFormState.Update)
                Set_Form();
            else
                PersonCode.ReadOnly=false;
            FillContract();
        }

        private void FillContract()
        {
            grdContractsRent.DataSource = JContractEmployee.GetListContract(PersonCode.SelectedCode);
            if (grdContractsRent.DataSource != null)
            {
                grdContractsRent.Columns["ContractCode"].Visible = false;
                grdContractsRent.Columns["PersonCode"].Visible = false;
            }
        }

        public void CreateContractPrint(DataRow pDr)
        {
            //if (!(JPermission.CheckPermission("Estates.JGroundSheet.CreateContractPrint")))
            //    return;
            try
            {
                int _FileCode = 0;
                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                OfficeWord.WinWordControl tmpWord = new OfficeWord.WinWordControl();
                DataRow dr = pDr;
                //if (ClassLibrary.JAllPerson.CheckCodeMeli(dr["ShMeli"].ToString()))
                //{
                tmpSubjectContract.GetData(Convert.ToInt32(dr["ContractCode"]));
                _FileCode = tmpSubjectContract.FileCode;
                if (_FileCode <= 0)
                {
                    _FileCode = CreateContract(dr);
                }

                tmpWord.GetData(_FileCode);
                tmpWord.LoadDocument();

                tmpWord.Print();
                //tmpWord.Print();

                tmpWord.Dispose();
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public int CreateContract(DataRow pDr)
        {
            try
            {
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Code", typeof(int));
                dt.Columns.Add("i", typeof(int));

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                Legal.JContractdefine tmpJContractdefine = new Legal.JContractdefine();
                Legal.JGeneralContract tmpGeneralContract = new Legal.JGeneralContract(-2, -2);

                DataRow dr = pDr;
                //if (ClassLibrary.JAllPerson.CheckCodeMeli("0945076053"))
                //{
                tmpSubjectContract.GetData(Convert.ToInt32(dr["ContractCode"]));
                if (tmpJContractdefine.Code == 0)
                {
                    tmpJContractdefine.GetData(tmpSubjectContract.Type);
                    tmpGeneralContract.LoadForms(tmpJContractdefine.ContractType, tmpSubjectContract.Code, true);
                }
                tmpGeneralContract.GetData(tmpJContractdefine.ContractType, tmpSubjectContract.Code, 0, true);
                tmpGeneralContract.ContractForms.CreateWordContract();
                //dt.Rows.Add(Convert.ToInt32(dr["Code"]), i);
                //i++;
                //Nodes.StatusStripMain.Items[0].Text = i.ToString();
                //System.Windows.Forms.Application.DoEvents();
                //JSystem.FreeObjectsDataReaer();
                return tmpGeneralContract.ContractForms.Contract.FileCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        DataTable _ItemGoods;
        DataTable _dtKaraneh;
        DataTable _dtSeperation;

        private void btnAddTaahol_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if ((cmbFamRelation.SelectedItem == null) && (cmbFamRelation.SelectedItem == null))
                {
                    JMessages.Error(" لطفا آیتمی را انتخاب کنید ", "");
                    cmbFamRelation.Focus();
                    return;
                }
                if (jucPersonFamily.SelectedCode == 0)
                {
                    JMessages.Error(" فردی را انتخاب کنید ", "");
                    jucPersonFamily.Focus();
                    return;
                }
                #endregion

                if ((jucPersonFamily.SelectedCode != 0) &&
                    ((_ItemGoods != null) && (_ItemGoods.Select(" PCode=" + jucPersonFamily.SelectedCode).Length == 0)))
                {
                    DataRow dr = _ItemGoods.NewRow();
                    dr["Name"] = jucPersonFamily.lbLastName.Text + jucPersonFamily.lbLName.Text;
                    dr["PCode"] = jucPersonFamily.SelectedCode;
                    dr["NesbatType"] = Convert.ToInt32(((System.Data.DataRowView)(cmbFamRelation.SelectedValue)).Row.ItemArray[1]);
                    dr["Nesbat"] = cmbFamRelation.Text;
                    dr["expireDateTakafol"] = (DateExpire.Text);
                    //is_finished = Convert.ToBoolean(Row["is_finished"]);
                    dr["Description"] = txtDescFam.Text;
                    _ItemGoods.Rows.Add(dr);
                    jdgvFam.DataSource = _ItemGoods;
                }
                else
                {
                    JMessages.Error(" این شخص قبلا ثبت شده است ", "");
                    jucPersonFamily.Focus();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void btnDelTaahod_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvFam.CurrentRow != null)
                {
                    jdgvFam.Rows.Remove(jdgvFam.CurrentRow);
                    btnSave.Enabled = true;
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run();
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            try
            {
                contextMenuStripContract.Items.Clear();
                EventHandler ClickEvent = new EventHandler(run);

                int LastContractCode =  Legal.JSubjectContract.SearchLastContract(PersonCode.SelectedCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer.GetHashCode());
                //Finance.JAsset Asset = new Finance.JAsset(UnitBuild.GetType().FullName, UnitBuild.Code);

                Legal.JContractNodes CN = new Legal.JContractNodes();
                JNode[] _nodes = CN.ContractTree(0);

                foreach (JNode _node in _nodes)
                {
                    ToolStripItem TSI = contextMenuStripContract.Items.Add(_node.Name);
                    if (_node.ChildsAction != null)
                    {
                        JNode[] _childnodes = (JNode[])_node.ChildsAction.run();
                        foreach (JNode _childnode in _childnodes)
                        {
                            Legal.ArgParameter[] B = new Legal.ArgParameter[1];
                            B[0].Value = PersonCode.SelectedCode;
                            B[0].FormName = "JContractEmployeeForm";
                            B[0].PrpertyName = "PCode";

                            ToolStripItem TSIChild = ((ToolStripMenuItem)TSI).DropDownItems.Add(_childnode.Name, null, ClickEvent);
                            TSIChild.Tag =
                                new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code, LastContractCode, Legal.JBaseContractForm.JStateContractForm.Insert, B });
                        }
                    }
                }
                contextMenuStripContract.Show(MousePosition);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((_dtAll != null) && (_dtAll.Rows.Count > i))
            {
                _Code = Convert.ToInt32(_dtAll.Rows[i++]["Code"]);
                JEmployeeInfoForm_Load(null, null);
                //JSystem.Nodes.DefaultView.Rows[0].
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if ((_dtAll != null) && (i > 1))
            {
                _Code = Convert.ToInt32(_dtAll.Rows[i--]["Code"]);
                JEmployeeInfoForm_Load(null, null);
            }
        }

        private void JEmployeeInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                btnNext_Click(null, null);
            if (e.KeyCode == Keys.F8)
                btnBefore_Click(null, null);
            if (e.KeyCode == Keys.F3)
                btnSearch_Click(null, null);
            if (e.KeyCode == Keys.F2)
                btnSaveClose_Click(null, null);
            if (e.KeyCode == Keys.F5)
                btnRefresh_Click(null, null);
            if (e.KeyCode == Keys.F4)
                btnContract_Click(null, null);
        }

        private void btnInfoPerson_Click(object sender, EventArgs e)
        {
            JPerson _Person = new JPerson(PersonCode.SelectedCode);
            JPersonIn p = new JPersonIn(_Person);
            p.State = JFormState.Update;
            p.ShowDialog();
        }

        private void InitGridView()
        {
            grdContractsRent.gridEX1.MouseDown += new MouseEventHandler(grdRentContracs_MouseDown);
        }

        void grdRentContracs_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(JPermission.CheckPermission("Employment.JEStaticNode.CheckPermissionMenu", false)))
                return;
            if (grdContractsRent.gridEX1.CurrentRow == null) return;
            if (grdContractsRent.RowCount > 0)
            {
                grdContractsRent.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(grdContractsRent.gridEX1.CurrentRow.Cells["ContractCode"].Value),
                   Convert.ToInt32(grdContractsRent.gridEX1.CurrentRow.Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    grdContractsRent.AddAction(action);
                }
            }
        }

        private List<JAction> CreateActions(int pContractCode, int pPersonCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);

                JAction splitter = new JAction("-", "");
                //actions.Add(splitter);
                JAction ReapirAction = new JAction("RepairContract...", "Legal.JRepairContractForm.Show", null, new object[] { contract.Code });
                actions.Add(ReapirAction);

                /// تعیین قرارداد جاری
                JAction SetAsCurrentContract = new JAction("SetAsCurrentContract...", "Legal.JSubjectContract.SetAsCurrentContract", new object[] { contract.FinanceCode, contract.Code, DynamicType.AssetTransferType }, null);
                actions.Add(SetAsCurrentContract);

                actions.Add(splitter);

                if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", contractDefine.ContractType, JMainFrame.CurrentPostCode, false))
                {
                    JAction ShowWordCurrentContract = OfficeWord.JWordForm.getAction("Legal.JContractForms", pContractCode, true);
                    actions.Add(ShowWordCurrentContract);
                }
                JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
                actions.Add(CancelAction);

                //Legal.ArgParameter[] B = new Legal.ArgParameter[1];
                //B[0].Value = PersonCode.SelectedCode;
                //B[0].FormName = "JContractEmployeeForm";
                //B[0].PrpertyName = "PCode";

                JAction editContract = new JAction("EditContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                actions.Add(editContract);

                JAction viewContract = new JAction("viewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, true });
                actions.Add(viewContract);

                //  چاپ قرارداد
                JAction ContractPrint = new JAction("ContractPrint...", "Employment.JEmployeeInfoForm.CreateContractPrint", new object[] { grdContractsRent.SelectedRow.Row }, null);
                actions.Add(ContractPrint);

                JAction ContractDeActive;
                //  غیر فعال کردن قرارداد
                if(contract.Status == Legal.JContractStatus.Current)
                    ContractDeActive = new JAction("غیر فعال کردن قرارداد...", "Employment.JEmployeeInfo.UpdateContractDeActive", new object[] { contract.Code, Legal.JContractStatus.Expired }, null);
                else
                    ContractDeActive = new JAction("فعال کردن قرارداد...", "Employment.JEmployeeInfo.UpdateContractDeActive", new object[] { contract.Code, Legal.JContractStatus.Current }, null);
                actions.Add(ContractDeActive);

                actions.Add(splitter);

            }
            ///  مشخصات شخص
            int pCode = pPersonCode;
            JAction personAction = new JAction();
            JAllPerson allPerson = new JAllPerson(pCode);
            if (allPerson.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { pCode });
            else if (allPerson.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { pCode });
            actions.Add(personAction);
            return actions;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillContract();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEmpForm p = new SearchEmpForm();
            p.ShowDialog();
            if (p._Code > 0)
            {
                _Code = p._Code;
                JEmployeeInfoForm_Load(null, null);
            }
        }

        private void txtSearchCart_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCart.Text != "")
            {
                DataTable dt = JEmployeeInfos.GetDataTableByPCode(0, " And PersonCart=" + txtSearchCart.Text);
                if (dt.Rows.Count > 0)
                {
                    _Code = Convert.ToInt32(dt.Rows[0]["Code"]);
                    JEmployeeInfoForm_Load(null, null);
                }
            }
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            if (!(JPermission.CheckPermission("Employment.JEStaticNode.CheckPermissionMenu", true)))
                return;

            JPropertyEmployeeForm p = new JPropertyEmployeeForm();
            p.ShowDialog();
        }

        private void btnAddKaraneh_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtPriceKaraneh.Text == "")
                {
                    JMessages.Error(" لطفا مبلغ را انتخاب کنید ", "");
                    cmbFamRelation.Focus();
                    return;
                }                
                #endregion

                if ((_dtKaraneh != null) && (_dtKaraneh.Select(" id_karaneRange=" + cmbKaranehRange.SelectedValue).Length == 0))
                {
                    DataRow dr = _ItemGoods.NewRow();
                    dr["PCode"] = jucPersonFamily.SelectedCode;
                    dr["Price"] = Convert.ToDecimal(txtPriceKaraneh.Text);
                    dr["id_karaneRange"] = cmbKaranehRange.SelectedValue;
                    dr["score"] = txtScoreKaraneh.Text;                    
                    dr["Description"] = cmbKaranehRange.Text;
                    _dtKaraneh.Rows.Add(dr);
                    jdgvKaraneh.DataSource = _dtKaraneh;
                }
                else
                {
                    JMessages.Error(" این کارانه دوره قبلا ثبت شده است ", "");
                    jucPersonFamily.Focus();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void btnDelKaraneh_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvKaraneh.CurrentRow != null)
                {
                    jdgvKaraneh.Rows.Remove(jdgvKaraneh.CurrentRow);
                    btnSave.Enabled = true;
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddSeperation_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtPriceKaraneh.Text == "")
                {
                    JMessages.Error(" لطفا مبلغ را انتخاب کنید ", "");
                    cmbFamRelation.Focus();
                    return;
                }

                #endregion
                //if ((_dtKaraneh != null) && (_dtKaraneh.Select(" id_karaneRange=" + cmbKaranehRange.SelectedValue).Length == 0))
                //{
                    DataRow dr = _ItemGoods.NewRow();
                    dr["id_employee"] = _Code;
                    dr["id_DischargeType"] = Convert.ToInt32(cmbSeparation.SelectedValue);
                    dr["Ddate"] = txtDateSeperation.Date;
                    dr["Rdate"] = txtDateRetSep.Date;
                    dr["Description"] = txtDescSepration.Text;
                    _dtSeperation.Rows.Add(dr);
                    jdgvSeperation.DataSource = _dtSeperation;
                //}
                //else
                //{
                //    JMessages.Error(" این کارانه دوره قبلا ثبت شده است ", "");
                //    jucPersonFamily.Focus();
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void btnDelSeperation_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvSeperation.CurrentRow != null)
                {
                    jdgvSeperation.Rows.Remove(jdgvSeperation.CurrentRow);
                    btnSave.Enabled = true;
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

    }
}
