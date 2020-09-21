using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Estates;

namespace RealEstate
{
    public partial class JConstructionForm : Globals.JBaseForm
    {

        DataTable _dtUsage = new DataTable();
        DataTable _dtFloor = new DataTable();
        DataTable _dtFaz = new DataTable();
        DataTable _dtLocation = new DataTable();
        DataTable _GoodwillTable = new DataTable();
        jMarket tmpjMarket = new jMarket();

        public JConstructionForm(int pCode)
        {
            InitializeComponent();
            if (pCode > 0)
            {
                tmpjMarket.GetData(pCode);
                ArchiveListMarket.ObjectCode = pCode;
                jDefinePropertyUserControl.ObjectCode = pCode;
                PrEnviroment.ObjectCode = pCode;
                //
                //jPropertyValueUserControl1.Property = new Globals.Property.JProperty("RealEstate.jMarket", pCode);
            }
            PatternDt();
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListMarket.ClassName = "RealEstate.jMarket";
            ArchiveListMarket.SubjectCode = 0;
            ArchiveListMarket.PlaceCode = 0;

            //
            jDefinePropertyUserControl.ClassName = "RealEstate.jMarket";

            PrEnviroment.ClassName = "RealEstate.JEnviroment";


        }

        #region Methods

        private void PatternDt()
        {
            try
            {
                jMarketFloors tmpjMarketFloors = new jMarketFloors();
                _dtFloor = tmpjMarketFloors.GetDataByMarketCode(0);

                JMarketFaz tmpjMarketFaz = new JMarketFaz();
                _dtFaz = tmpjMarketFaz.GetDataByMarketCode(0);

                jMarketUsage tmpjMarketUsage = new jMarketUsage();
                _dtUsage = tmpjMarketUsage.GetDataByMarketCode(0);           
                
                jMarketLocation tmpjMarketLocation = new jMarketLocation();
                _dtLocation = tmpjMarketLocation.GetDataByMarketCode(0);


                _GoodwillTable = JMarketGoodwill.GetDataByMarketCode(0);
                grdGoodwill.DataSource = _GoodwillTable;
                grdGoodwill.Columns[0].Visible = false;
                grdGoodwill.Columns[JMarketGoodwillEnum.FromDate.ToString()].Visible = false;
                grdGoodwill.Columns[JMarketGoodwillEnum.ToDate.ToString()].Visible = false;
                grdGoodwill.Columns["FromDateF"].DefaultCellStyle.Format = "0000/00/00";
                grdGoodwill.Columns["ToDateF"].DefaultCellStyle.Format = "0000/00/00";

            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
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
            //--------اطلاعات فاز مجتمع
            JMarketFaz tmpjMarketFaz = new JMarketFaz();
            _dtFaz = tmpjMarketFaz.GetDataByMarketCode(tmpjMarket.Code);
            //dgvFaz.DataSource = _dtFaz;
            //dgvFaz.Columns[0].Visible = false;
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
            
            //--------اطلاعات موقعیت مجتمع
            //JMarketGoodwill tmpGoodwill = new JMarketGoodwill();
            _GoodwillTable = JMarketGoodwill.GetDataByMarketCode(tmpjMarket.Code);
            grdGoodwill.DataSource = _GoodwillTable;
            grdGoodwill.Columns[0].Visible = false;
            grdGoodwill.Columns[JMarketGoodwillEnum.FromDate.ToString()].Visible = false;
            grdGoodwill.Columns[JMarketGoodwillEnum.ToDate.ToString()].Visible = false;
            
            //--------اطلاعات مجتمع
            //jMarket tmpjMarket = new jMarket();
            tmpjMarket.GetData(tmpjMarket.Code);
            txtMarketCode.Text = tmpjMarket.Code.ToString();
            txtManagerName.Text = tmpjMarket.ManagerName;
            txtPermitBuild.Text = tmpjMarket.PermitBuilding;
            txtPermitResult.Text = tmpjMarket.PermitResult;
            deStartProject.Text = JDateTime.FarsiDate(tmpjMarket.StartBuilding);
            deEndProject.Text = JDateTime.FarsiDate(tmpjMarket.EndBuilding);
            txtTitleMarket.Text = tmpjMarket.Title;
            txtInfraMarket.Text = tmpjMarket.Infrastructure.ToString();
            txtDescMarket.Text = tmpjMarket.Description;
            btnSave.Enabled = false;

            GetExcessinfrastructure();
            GetAreadgvFloors();
            //GetAreadgvFaz();

            dgvFloors.Columns[estMarketFloors.Number.ToString()].ReadOnly = true;
            dgvUsage.Columns[estMarketUsage.UsageCode.ToString()].Visible = false;
            dgvUsage.Columns["Name"].ReadOnly = true;
            /// تمام ستونهای جدول زمین بجز متراژ سطح اشغال فقط خواندنی میشود
            for (int i = 0; i < dgvLocation.ColumnCount ; i++)
            {
                if (dgvLocation.Columns[i].Name != estMarketLocation.occupancy.ToString())
                    dgvLocation.Columns[i].ReadOnly = true;
                else dgvLocation.Columns[i].ReadOnly = false;
            }

        }
        /// <summary>
        /// پر کردن لیست کاربری ها
        /// </summary>
        private void Fill_cmb()
        {
            JDefineMarketUsages Usages = new JDefineMarketUsages();
            cmbUsage.Items.Clear();
            Usages.SetComboBox(cmbUsage);
            //foreach (JSubBaseDefine Usage in Usages.Items)
            //    cmbUsage.Items.Add(Usage);
        }

        /// <summary>
        /// ذخیره
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Save()
        {
            if (txtInfraMarket.DecimalValue == 0)
            {
                string[] parameters = { "@Value" };
                string[] values = { "متراژ زیر بنا" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtInfraMarket.Focus();
                return false;
            }
            
            GetExcessinfrastructure();

            #region Chack Values
            if (GetAreadgvUsage() < txtInfraMarket.DecimalValue)
            {
                string msg = "مجموع متراژ کاربری نباید کمتر از متراژ زیربنا باشد";
                JMessages.Error(msg, "Error");
                return false;
            }
            if (GetAreadgvFloors() < txtInfraMarket.DecimalValue)
            {
                string msg = "مجموع متراژ طبقات نباید کمتر از متراژ زیربنا باشد";
                JMessages.Error(msg, "Error");
                return false;
            }
            if (GetAreadgvFloors() != GetAreadgvUsage())
            {
                string msg = "مساحت طبقات باید با مساحت کابریها برابر باشد";
                JMessages.Error(msg, "Error");
                return false;
            }
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

            tmpjMarket.Description = txtDescMarket.Text.Trim();
            //tmpjMarket.MarketNumber = txtMarketCode.IntValue;
            tmpjMarket.ManagerName = txtManagerName.Text;
            tmpjMarket.PermitBuilding = txtPermitBuild.Text;
            tmpjMarket.PermitResult = txtPermitResult.Text;
            tmpjMarket.StartBuilding = deStartProject.Date;
            tmpjMarket.EndBuilding = deEndProject.Date;
            tmpjMarket.Title = txtTitleMarket.Text;
            tmpjMarket.Infrastructure = Convert.ToDecimal(txtInfraMarket.Text);
            //-----------اطلاعات آرشیو------------
            ArchiveListMarket.ClassName = "RealEstate.jMarket";
            ArchiveListMarket.PlaceCode = 0;
            ArchiveListMarket.SubjectCode = 0;
            //---------ویرایش------------
            if (State == JFormState.Update)
            {
                //----------Update Archive------------
                tmpjMarket.Code = tmpjMarket.Code;
                ArchiveListMarket.ObjectCode = tmpjMarket.Code;
                ArchiveListMarket.ArchiveList();
                if (tmpjMarket.Update(_dtFloor, _dtFaz , _dtUsage, _dtLocation, _GoodwillTable))
                {
                    jDefinePropertyUserControl.AcceptChanges();
                    PrEnviroment.AcceptChanges();
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
                int ManualCode = 0;
                if (txtNumber.Text.Length > 0)
                    int.TryParse(txtNumber.Text, out ManualCode);
                if (tmpjMarket.Insert(_dtFloor,_dtFaz ,_dtUsage, _dtLocation, _GoodwillTable, ManualCode))
                {
                    ArchiveListMarket.ObjectCode = tmpjMarket.Code;
                    ArchiveListMarket.ArchiveList();

                    jDefinePropertyUserControl.ObjectCode = tmpjMarket.Code;
                    jDefinePropertyUserControl.AcceptChanges();
                   PrEnviroment.ObjectCode = tmpjMarket.Code;
                   PrEnviroment.AcceptChanges();
                    //JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    return true;
                    //this.Dispose();
                }
                else
                    JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
            }
            return false;
        }

        #endregion

        /// <summary>
        /// اضافه کردن طبقه به لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFloor_Click(object sender, EventArgs e)
        {
            if (txtFloorCode.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "FloorCode" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtFloorCode.Focus();
                return;
            }

            if (txtInfra.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Infra" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtInfra.Focus();
                return;
            }

            if (txtNameFloor.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "FloorName" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtNameFloor.Focus();
                return;
            }            
                //----------------چک کردن وجود سطر تکراری
                if ((_dtFloor.Rows.Count > 0) && _dtFloor.Select(estMarketFloors.Number.ToString() + "=" + txtFloorCode.Text).Length > 0)
                {
                    JMessages.Error("FloorNumberExists", "Error");
                    return;
                }

                //if (((_dtFloor.Rows.Count > 0) && (_dtFloor.Select(estMarketFloors.Number.ToString() + "=" + txtFloorCode.Text).Length < 1)) || (_dtFloor.Rows.Count == 0))
                {
                    DataRow dr = _dtFloor.NewRow();
                    dr[estMarketFloors.Number.ToString()] = txtFloorCode.Text;
                    dr[estMarketFloors.Name.ToString()] = txtNameFloor.Text;
                    dr[estMarketFloors.Infrastructure.ToString()] = txtInfra.DecimalValue;
                    dr[estMarketFloors.Description.ToString()] = txtDesc.Text;
                    _dtFloor.Rows.Add(dr);
                    dgvFloors.DataSource = _dtFloor;
                    btnSave.Enabled = true;
                    dgvFloors.Columns[0].Visible = false;
                    //پاک کردن اطلاعات textBoxها
                    txtDesc.Clear();
                    txtInfra.Clear();
                    txtNameFloor.Clear();
                    txtFloorCode.Clear();
                    GetAreadgvFloors();
                    txtFloorCode.Focus();
                }
        }
        /// <summary>
        /// اضافه کردن زمین به لیست
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtGroundCode.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Ground" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtGroundCode.Focus();
                return;
            }

            if (txtInfraLand.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Infra" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtInfraLand.Focus();
                return;
            }

            if ((_dtLocation.Rows.Count > 0) && (_dtLocation.Select(estMarketLocation.GroundCode.ToString() + "=" + txtGroundCode.Text).Length >= 1))
            {
                JMessages.Error("این زمین قبلاً وارد شده است.", "Error");
                return;
            }

            if ((txtGroundCode.Text.Trim() != "") && (txtInfraLand.Text.Trim() != ""))
            {
                //----------------چک کردن وجود سطر تکراری
                if (((_dtLocation.Rows.Count > 0) && (_dtLocation.Select(estMarketLocation.GroundCode.ToString() + "=" + txtGroundCode.Text).Length < 1)) || (_dtLocation.Rows.Count == 0))
                {
                    DataRow dr = _dtLocation.NewRow();
                    JGround tmpJGround = new JGround();
                    tmpJGround.GetData(Convert.ToInt32(txtGroundCode.Text), null);
                    if (tmpJGround.Code != 0)
                    {
                        dr[estMarketLocation.GroundCode.ToString()] = tmpJGround.Code;
                        dr[JGroundTableEnum.BlockNum.ToString()] = tmpJGround.BlockNum;
                        dr[JGroundTableEnum.PartNum.ToString()] = tmpJGround.PartNum;
                        dr["Pelak"] = tmpJGround.MainAve + tmpJGround.SubNo;
                        dr[estMarketLocation.occupancy.ToString()] = txtInfraLand.DecimalValue;
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
            if (cmbUsage.SelectedIndex == -1)
            {
                string[] parameters = { "@Value" };
                string[] values = { "Usage" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                cmbUsage.Focus();
                return;
            }

            if (txtInfraUsage.FloatValue == 0)
            {
                string[] parameters = { "@Value" };
                string[] values = { "Infra" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtInfraUsage.Focus();
                return;
            }
            if ((_dtUsage.Rows.Count > 0) && (_dtUsage.Select(estMarketUsage.UsageCode.ToString() + "=" + cmbUsage.SelectedValue.ToString()).Length) >= 1)
            {
                JMessages.Error("این نوع کاربری قبلاً اضافه شده است.", "Error");
                return;
            }

            //----------------چک کردن وجود سطر تکراری
            if (((_dtUsage.Rows.Count > 0) && (_dtUsage.Select(estMarketUsage.UsageCode.ToString() + "=" + (Convert.ToInt32(cmbUsage.SelectedValue)).ToString()).Length < 1)) || (_dtUsage.Rows.Count == 0))
            {
                DataRow dr = _dtUsage.NewRow();
                dr[estMarketUsage.UsageCode.ToString()] = Convert.ToInt32(cmbUsage.SelectedValue);
                dr["Name"] = cmbUsage.Text;
                dr[estMarketUsage.Infrastructure.ToString()] = txtInfraUsage.DecimalValue;
                _dtUsage.Rows.Add(dr);
                dgvUsage.DataSource = _dtUsage;
                
                btnSave.Enabled = true;
                dgvUsage.Columns[0].Visible = false;
                GetAreadgvUsage();
                GetExcessinfrastructure();
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

        #region "Events"

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                State = JFormState.Update;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                Close();
            }
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
                GetAreadgvUsage();
                GetExcessinfrastructure(); 
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
            if (dgvFloors.CurrentRow == null)
                return;
            
            if ((dgvFloors.CurrentRow.Cells["Code"].Value.ToString() != "") && (JUnitBuilds.GetDataTable(0, tmpjMarket.Code, Convert.ToInt32(dgvFloors.CurrentRow.Cells["Code"].Value)).Rows.Count > 0))
            {
                JMessages.Error("در این طبقه، اعیان ثبت شده است. حذف امکانپذیر نیست.", "Error");
                return;
            }
            if (JMessages.Question("آیا میخواهید طبقه انتخاب شده حذف شود؟", "تائید") == DialogResult.Yes)
            {
                if (dgvFloors.CurrentRow != null)
                {
                    dgvFloors.Rows.Remove(dgvFloors.CurrentRow);
                    GetAreadgvFloors();
                    btnSave.Enabled = true;
                }
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
            GetExcessinfrastructure();
            btnSave.Enabled = true;
        }


        private void JConstructionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult result = JMessages.Confirm("DoYouWantTotSaveChanges?", "SaveChanges");
                if (result == DialogResult.Yes)
                {
                    if (Save())
                        e.Cancel = false;
                        //Close();
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

        private void txtDescMarket_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        #endregion "Events"

        private void btnAddGoodwill_Click(object sender, EventArgs e)
        {
            #region Check Controls
            if (txtFromDateGoodwill.Date == DateTime.MinValue)
            {
                string[] parameters = { "@Value" };
                string[] values = { "FromDate" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtFromDateGoodwill.Focus();
                return;
            }
            if (txtToDateGoodwill.Date == DateTime.MinValue)
            {
                string[] parameters = { "@Value" };
                string[] values = { "ToDate" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtToDateGoodwill.Focus();
                return;
            }
            if (txtPercentGoodwill.FloatValue < 0)
            {
                string[] parameters = { "@Value" };
                string[] values = { "Percent" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtPercentGoodwill.Focus();
                return;
            }
            if (txtFromDateGoodwill.Date > txtToDateGoodwill.Date)
            {
                string msg = JLanguages._Text("StartDateBiggerThanEndDate");
                JMessages.Error(msg, "Error");
                txtToDateGoodwill.Focus();
                return;
            }

            if (_GoodwillTable.Rows.Count > 0)
            {
                DataRow row = _GoodwillTable.NewRow();
                /// بدست آوردن آخرین سطر حذف نشده
                for (int i = _GoodwillTable.Rows.Count - 1; i >= 0; i--)
                {
                    if (_GoodwillTable.Rows[i].RowState != DataRowState.Deleted)
                    {
                        row = _GoodwillTable.Rows[i];
                        DateTime lastDate = Convert.ToDateTime(_GoodwillTable.Rows[_GoodwillTable.Rows.Count - 1][JMarketGoodwillEnum.ToDate.ToString()]);
                        lastDate = lastDate.AddDays(1);
                        if (lastDate != txtFromDateGoodwill.Date)
                        {
                            JMessages.Error("NextFromDateMustBePreToDate", "Error");
                            return;
                        }
                        break;
                    }
                }
            }

            #endregion CheckControls

            DataRow dr = _GoodwillTable.NewRow();
            dr[JMarketGoodwillEnum.FromDate.ToString()] = txtFromDateGoodwill.Date;
            dr[JMarketGoodwillEnum.ToDate.ToString()] = txtToDateGoodwill.Date;
            dr[JMarketGoodwillEnum.FromDateF.ToString()] = txtFromDateGoodwill.Text;
            dr[JMarketGoodwillEnum.ToDateF.ToString()] = txtToDateGoodwill.Text;
            dr[JMarketGoodwillEnum.IncreasePercent.ToString()] = txtPercentGoodwill.FloatValue;
            //grdGoodwill.DataSource = _GoodwillTable;
            _GoodwillTable.Rows.Add(dr);
            grdGoodwill.Columns["FromDateF"].DefaultCellStyle.Format = "0000/00/00";
            grdGoodwill.Columns["ToDateF"].DefaultCellStyle.Format = "0000/00/00";
            btnSave.Enabled = true;

            #region Delete Controls
            txtFromDateGoodwill.Text = "";
            txtToDateGoodwill.Text = "";
            txtPercentGoodwill.Text = "";
            txtFromDateGoodwill.Focus();
            #endregion Delete Controls

        }

        private void btnDelGoodwill_Click(object sender, EventArgs e)
        {
            if (grdGoodwill.CurrentRow != null)
            {
                grdGoodwill.Rows.Remove(grdGoodwill.CurrentRow);
                btnSave.Enabled = true;
            }
        }

        /// <summary>
        /// مساحت کاربریها
        /// </summary>
        /// <returns></returns>
        private decimal GetAreadgvUsage()
        {
            try
            {
                decimal Area = 0;
                DataTable DT = (DataTable)dgvUsage.DataSource;
                foreach (DataRow DR in DT.Rows)
                {
                    if (DR.RowState != DataRowState.Deleted)
                        Area += decimal.Parse(DR["Infrastructure"].ToString());
                }
                lbSumUsage.Text = Area.ToString();
                return Area;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// محاسبه متراژ طبقات
        /// </summary>
        /// <returns></returns>
        private decimal GetAreadgvFloors()
        {
            try
            {
                decimal Area = 0;
                DataTable DT = (DataTable)dgvFloors.DataSource;
                foreach (DataRow DR in DT.Rows)
                {
                    if (DR.RowState != DataRowState.Deleted)
                        Area += decimal.Parse(DR["Infrastructure"].ToString());
                }
                lbSumFloors.Text = Area.ToString();
                return Area;
            }
            catch
            {
                return 0;
            }
        }
     
        /// <summary>
        /// اختلاف مساحت کاربریها با مترازکل مازاد زیربنا
        /// </summary>
        /// <returns></returns>
        private decimal GetExcessinfrastructure()
        {
            try
            {
                decimal AreaUsage = GetAreadgvUsage();
                decimal InfraMarket = decimal.Parse(txtInfraMarket.Text);
                txtExcessinfrastructure.Text = "0";
                if (AreaUsage > InfraMarket)
                {
                    txtExcessinfrastructure.Text = (AreaUsage - InfraMarket).ToString();
                    return AreaUsage - InfraMarket;
                }
                txtExcessinfrastructure.Text = "";
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void dgvUsage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetAreadgvUsage();
            GetExcessinfrastructure();
            btnSave.Enabled = true;
        }

        private void dgvFloors_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetAreadgvFloors();
            btnSave.Enabled = true;
        }

        private void dgvLocation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }    

        private void PrEnviroment_AfterPropertyAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            txtToDateGoodwill.Text = JDateTime.AddMonthFarsi(txtFromDateGoodwill.Text, txtMonth.IntValue);
            txtToDateGoodwill.Date = txtToDateGoodwill.Date.AddDays(-1);
        }
    }
}
