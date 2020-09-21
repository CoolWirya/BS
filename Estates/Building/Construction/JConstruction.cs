using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JConstructionForm : Globals.JBaseForm
    {

        DataTable _dtUsage = new DataTable();
        DataTable _dtFloor = new DataTable();
        DataTable _dtLocation = new DataTable();
        jMarket tmpjMarket= new jMarket();

        public JConstructionForm(int pCode)
        {
            InitializeComponent();
            if (pCode > 0)
            {
                tmpjMarket.GetData(pCode);
                ArchiveListMarket.ObjectCode = pCode;
                jDefinePropertyUserControl.ObjectCode = pCode;
                //
                //jPropertyValueUserControl1.Property = new Globals.Property.JProperty("Estates.jMarket", pCode);
            }
            PatternDt();
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListMarket.ClassName = "Estates.jMarket";
            ArchiveListMarket.SubjectCode = 0;
            ArchiveListMarket.PlaceCode = 0;

            //
            jDefinePropertyUserControl.ClassName = "Estates.jMarket";
        }

        private void PatternDt()
        {
            jMarketFloors tmpjMarketFloors = new jMarketFloors();
            _dtFloor = tmpjMarketFloors.GetDataByMarketCode(0);
            //_dtUsage.Columns.Add("Code");
            //_dtUsage.Columns.Add(estMarketUsage.UsageCode.ToString());
            //_dtUsage.Columns.Add("Name");
            //_dtUsage.Columns.Add(estMarketUsage.Infrastructure.ToString());

            jMarketUsage tmpjMarketUsage = new jMarketUsage();
            _dtUsage= tmpjMarketUsage.GetDataByMarketCode(0);
            //_dtFloor.Columns.Add("Code");
            //_dtFloor.Columns.Add(estMarketFloors.Code.ToString());
            //_dtFloor.Columns.Add(estMarketFloors.Number.ToString());
            //_dtFloor.Columns.Add(estMarketFloors.Name.ToString());
            //_dtFloor.Columns.Add(estMarketFloors.Infrastructure.ToString());
            //_dtFloor.Columns.Add(estMarketFloors.Description.ToString());

            jMarketLocation tmpjMarketLocation = new jMarketLocation();
            _dtLocation = tmpjMarketLocation.GetDataByMarketCode(0);
            //_dtLocation.Columns.Add("Code");
            //_dtLocation.Columns.Add(estMarketLocation.GroundCode.ToString());
            //_dtLocation.Columns.Add(JGroundTableEnum.BlockNum.ToString());
            //_dtLocation.Columns.Add(JGroundTableEnum.PartNum.ToString());
            //_dtLocation.Columns.Add("Pelak");
            //_dtLocation.Columns.Add(estMarketLocation.occupancy.ToString());
        }

        private void JConstruction_Load(object sender, EventArgs e)
        {
            Fill_cmb();
            if (State == JFormState.Update)
            {
                txtMarketCode.Enabled = false;
                Set_Form();
            }
        }
        /// <summary>
        /// نمایش اطلاعات
        /// </summary>
        private void Set_Form()
        {
            //--------اطلاعات طبقات مجتمع
            jMarketFloors tmpjMarketFloors = new jMarketFloors();
            _dtFloor = tmpjMarketFloors.GetDataByMarketCode(tmpjMarket.Code);
            dgvFloors.DataSource = _dtFloor;
            dgvFloors.Columns[0].Visible = false;
            //--------اطلاعات کاربری مجتمع
            jMarketUsage tmpjMarketUsage = new jMarketUsage();
            _dtUsage = tmpjMarketUsage.GetDataByMarketCode(tmpjMarket.Code);
            dgvUsage.DataSource = _dtUsage;
            dgvUsage.Columns[0].Visible = false;
            //--------اطلاعات موقعیت مجتمع
            jMarketLocation tmpjMarketLocation = new jMarketLocation();
            _dtLocation = tmpjMarketLocation.GetDataByMarketCode(tmpjMarket.Code);
            dgvLocation.DataSource = _dtLocation;
            dgvLocation.Columns[0].Visible = false;
            //--------اطلاعات مجتمع
            //jMarket tmpjMarket = new jMarket();
            tmpjMarket.GetData(tmpjMarket.Code);
            txtMarketCode.Text = tmpjMarket.MarketNumber.ToString();
            txtManagerName.Text = tmpjMarket.ManagerName;
            txtPermitBuild.Text = tmpjMarket.PermitBuilding;
            txtPermitResult.Text = tmpjMarket.PermitResult;
            deStartProject.Text = JDateTime.FarsiDate(tmpjMarket.StartBuilding);
            deEndProject.Text = JDateTime.FarsiDate(tmpjMarket.EndBuilding);
            txtTitleMarket.Text = tmpjMarket.Title;
            txtInfraMarket.Text = tmpjMarket.Infrastructure;
            btnSave.Enabled = false;
        }
        /// <summary>
        /// پر کردن لیست کاربری ها
        /// </summary>
        private void Fill_cmb()
        {
            JDefineMarketUsages Usages = new JDefineMarketUsages();
            cmbUsage.Items.Clear();
            foreach (JSubBaseDefine Usage in Usages.Items)
                cmbUsage.Items.Add(Usage);
        }
        /// <summary>
        /// اضافه کردن طبقه به لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFloor_Click(object sender, EventArgs e)
        {
            if ((txtFloorCode.Text != "") && (txtInfra.Text != "") && (txtNameFloor.Text != ""))
            {
                //----------------چک کردن وجود سطر تکراری
                if (((_dtFloor.Rows.Count > 0) && (_dtFloor.Select(estMarketFloors.Number.ToString() + "=" + txtFloorCode.Text).Length < 1)) || (_dtFloor.Rows.Count == 0))
                {
                    DataRow dr = _dtFloor.NewRow();
                    dr[estMarketFloors.Number.ToString()] = txtFloorCode.Text;
                    dr[estMarketFloors.Name.ToString()] = txtNameFloor.Text;
                    dr[estMarketFloors.Infrastructure.ToString()] = txtInfra.Text;
                    dr[estMarketFloors.Description.ToString()] = txtDesc.Text;
                    _dtFloor.Rows.Add(dr);
                    dgvFloors.DataSource = _dtFloor;
                    btnSave.Enabled = true;
                    dgvFloors.Columns[0].Visible = false;
                }
            }
            else
                JMessages.Message("Please Insert Data ", "", JMessageType.Information);
        }
        /// <summary>
        /// اضافه کردن زمین به لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if((txtGroundCode.Text.Trim() != "")&&(txtInfraLand.Text.Trim() != ""))
            {
                //----------------چک کردن وجود سطر تکراری
                if (((_dtLocation.Rows.Count > 0) && (_dtLocation.Select(estMarketLocation.GroundCode.ToString() + "=" + txtGroundCode.Text).Length < 1)) || (_dtLocation.Rows.Count == 0))
                {
                    DataRow dr = _dtLocation.NewRow();
                    JGround tmpJGround = new JGround();
                    tmpJGround.GetData(Convert.ToInt32(txtGroundCode.Text));
                    if (tmpJGround.Code != 0)
                    {
                        dr[estMarketLocation.GroundCode.ToString()] = tmpJGround.Code;
                        dr[JGroundTableEnum.BlockNum.ToString()] = tmpJGround.BlockNum;
                        dr[JGroundTableEnum.PartNum.ToString()] = tmpJGround.PartNum;
                        dr["Pelak"] = tmpJGround.MainAve + tmpJGround.SubNo;
                        dr[estMarketLocation.occupancy.ToString()] = txtInfraLand.Text;
                        _dtLocation.Rows.Add(dr);
                        dgvLocation.DataSource = _dtLocation;
                        btnSave.Enabled = true;
                        dgvLocation.Columns[0].Visible = false;
                    }
                    else
                        JMessages.Message("Please Enter Code Corrected ", "", JMessageType.Information);
                }
            }
            else
                JMessages.Message("Please Enter Data ", "", JMessageType.Information);
        }
        /// <summary>
        /// اضافه کردن کاربری به لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUsage_Click(object sender, EventArgs e)
        {
            //----------------چک کردن وجود سطر تکراری
            if (((_dtUsage.Rows.Count > 0) && (_dtUsage.Select(estMarketUsage.UsageCode.ToString() + "=" + ((ClassLibrary.JSubBaseDefine)(cmbUsage.SelectedItem)).Code.ToString()).Length < 1)) || (_dtUsage.Rows.Count == 0))
            {
                DataRow dr = _dtUsage.NewRow();
                dr[estMarketUsage.UsageCode.ToString()] = ((ClassLibrary.JSubBaseDefine)(cmbUsage.SelectedItem)).Code;
                dr["Name"] = cmbUsage.Text;
                dr[estMarketUsage.Infrastructure.ToString()] = txtInfraUsage.Text;
                _dtUsage.Rows.Add(dr);
                dgvUsage.DataSource = _dtUsage;
                btnSave.Enabled = true;
                dgvUsage.Columns[0].Visible = false;
            }
        }
        /// <summary>
        /// فرم جستجوی زمین
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            JSearchGroundForm p = new JSearchGroundForm();
            p.ShowDialog();
            if (p.Code != 0)
                txtGroundCode.Text = p.Code.ToString();
        }
        /// <summary>
        /// ذخیره
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Save()
        {
            #region Chack Values
            if (txtTitleMarket.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Title" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtTitleMarket.Focus();
                return false;
            }
            #endregion

            tmpjMarket.MarketNumber = txtMarketCode.IntValue;
            tmpjMarket.ManagerName = txtManagerName.Text;
            tmpjMarket.PermitBuilding = txtPermitBuild.Text;
            tmpjMarket.PermitResult = txtPermitResult.Text;
            tmpjMarket.StartBuilding = deStartProject.Date;
            tmpjMarket.EndBuilding = deEndProject.Date;
            tmpjMarket.Title = txtTitleMarket.Text;
            tmpjMarket.Infrastructure = txtInfraMarket.Text;
            //-----------اطلاعات آرشیو------------
            ArchiveListMarket.ClassName = "Estates.jMarket";
            ArchiveListMarket.PlaceCode = 0;
            ArchiveListMarket.SubjectCode = 0;
            //---------ویرایش------------
            if (State == JFormState.Update)
            {
                //----------Update Archive------------
                tmpjMarket.Code = tmpjMarket.Code;
                ArchiveListMarket.ObjectCode = tmpjMarket.Code;
                ArchiveListMarket.ArchiveList();
                if (tmpjMarket.Update(_dtFloor, _dtUsage, _dtLocation))
                {
                    jDefinePropertyUserControl.AcceptChanges();
                    //JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                    return true;
                    //this.Dispose();
                }
                else
                    JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                //else
                //    JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
            }
            else
            {
                //---------درج------------
                //----------Insert Archive------------
                if (tmpjMarket.Insert(_dtFloor, _dtUsage, _dtLocation))
                {
                    ArchiveListMarket.ObjectCode = tmpjMarket.Code;
                    ArchiveListMarket.ArchiveList();

                    jDefinePropertyUserControl.ObjectCode = tmpjMarket.Code;
                    jDefinePropertyUserControl.AcceptChanges();

                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    return true;
                    //this.Dispose();
                }
                else
                    JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Save())
                btnSave.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }
        /// <summary>
        /// حذف کاربری از لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelUsage_Click(object sender, EventArgs e)
        {
            if (dgvUsage.CurrentRow != null)
            {
                dgvUsage.Rows.Remove(dgvUsage.CurrentRow);
                btnSave.Enabled = true;
            }
        }
        /// <summary>
        /// حذف طبقه از لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFloor_Click(object sender, EventArgs e)
        {
            if (dgvFloors.CurrentRow != null)
            {
                dgvFloors.Rows.Remove(dgvFloors.CurrentRow);
                btnSave.Enabled = true;
            }
        }
        /// <summary>
        /// حذف موقعیت از لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvLocation.CurrentRow != null)
            {
                dgvLocation.Rows.Remove(dgvLocation.CurrentRow);
                btnSave.Enabled = true;
            }
        }

        private void deStartProject_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void deEndProject_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPermitBuild_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPermitResult_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtManagerName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void ArchiveListMarket_AfterFileAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtMarketCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtTitleMarket_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtInfraMarket_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtMarketCode_Leave(object sender, EventArgs e)
        {
        }

        private void JConstructionForm_FormClosed(object sender, FormClosingEventArgs e)
        {
        }

        private void JConstructionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
          if (btnSave.Enabled)
            {
                DialogResult result = JMessages.Confirm("DoYouWantTotSaveChanges?", "SaveChanges");
                if (result == DialogResult.Yes)
                {
                    btnSaveClose.PerformClick();
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

        private void jDefinePropertyUserControl_AfterPropertyAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

    }
}
