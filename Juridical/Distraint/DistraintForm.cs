using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Finance;

namespace Legal
{
    public partial class JDistraintForm : ClassLibrary.JBaseForm
    {
        JDistraint Distraint;
        bool IsDistraint;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsDistraint">توقیف یا رفع توقیف</param>
        public JDistraintForm(bool pIsDistraint)
        {
            InitializeComponent();
            IsDistraint = pIsDistraint;
            radPerson_CheckedChanged(null, null);
            Distraint = new JDistraint();

            jArchiveList.ClassName = "Legal.JDistraint";
            jArchiveList.ObjectCode = 0;
            jArchiveList.PlaceCode = 0;
            jArchiveList.SubjectCode = 0;

        }
        /// <summary>
        /// ایجاد فرم توقیف 
        /// </summary>
        /// <param name="DistrantType">نوع توقیف</param>
        /// <param name="pClassName"></param>
        /// <param name="pObjectCode"></param>
        /// <param name="pPCode">کد شخص</param>
        /// <param name="pIsDistraint">توقیف/ رفع توقیف</param>
        public JDistraintForm(JDistraintSubjectEnum DistrantType, string pClassName , int pObjectCode, int pPCode,bool pIsDistraint )
        {
            InitializeComponent();
            if (DistrantType == JDistraintSubjectEnum.Asset)
            {
                Distraint = new JDistraint();

                IsDistraint = pIsDistraint;
                radAsset.Checked = true;
                radPerson.Enabled = false;
                radPartAsset.Enabled = false;
                btmSearchAsset.Enabled = false;
                btnDelAsset.Enabled = false;
                txtAssetType.ReadOnly = true;
                JAsset asset = new JAsset(pClassName, pObjectCode);
                txtAssetCode.Text = asset.Code.ToString();
                ShowAssetData(asset.Code);
            }
            if (DistrantType == JDistraintSubjectEnum.AssetShare)
            {
                radPartAsset.Checked = true;
            }
            if (DistrantType == JDistraintSubjectEnum.Person)
            {
                radPerson.Checked = true;
            }
            radPerson_CheckedChanged(null, null);

        }
        public JDistraintForm(int pCode, bool pIsDistraint)
        {
            InitializeComponent();
            Distraint = new JDistraint(pCode);
            if (!pIsDistraint || !Distraint.Active)
                IsDistraint = false;
            else
                IsDistraint = true;
            
            jArchiveList.ClassName = "Legal.JDistraint";
            jArchiveList.ObjectCode = pCode;
            jArchiveList.PlaceCode = 0;
            jArchiveList.SubjectCode = 0;

            ShowData();
        }

        public void ShowData()
        {
            /// اگر رفع توقیف  باشد سایر تبها غیرفعال میشود
            if (!IsDistraint || !Distraint.Active)
            {
                foreach (Control control in grpDistType.Controls)
                {
                    control.Enabled = false;
                }

                foreach (Control control in tabDistratint.Controls)
                {
                    control.Enabled = false;
                }
                foreach (Control control in tabPerson.Controls)
                {
                    control.Enabled = false;
                }

                foreach (Control control in tabAsset.Controls)
                {
                    control.Enabled = false;
                }
                foreach (Control control in tabAssetShare.Controls)
                {
                    control.Enabled = false;
                }
                foreach (Control control in TabDistDesc.Controls)
                {
                    control.Enabled = false;
                }
                grpDistType.Text = @"وضعیت - رفع توقیف";
            }
            else
            {
                grpDistType.Text = "وضعیت - توقیف";

            }
            //مشخص کردن موضوع در فرم   
            ///توقیف دارایی
            JDecision Decision = new JDecision(Distraint.Committal);
            if (Distraint.Subject == Convert.ToInt32(JDistraintSubjectEnum.Asset))
            {
                radAsset.Checked = true;
                radPerson_CheckedChanged(null, null);
            }
            /// توقیف شخص
            else if (Distraint.Subject == Convert.ToInt32(JDistraintSubjectEnum.Person))
            {
                radPerson.Checked = true;
                radPerson_CheckedChanged(null, null);
            }
            /// توقیف بخشی از دارایی
            else if (Distraint.Subject == Convert.ToInt32(JDistraintSubjectEnum.AssetShare))
            {
                radPartAsset.Checked = true;
                radPerson_CheckedChanged(null, null);
            }
            // حکم دادگاه
            //مشخص کردن حکم و مشخصات آن در فرم
            txtAssetCode.Text = Distraint.Asset.ToString();
            ShowAssetData(Distraint.Asset);
            lbAssetDesc.Text = (new JAsset(Distraint.Asset)).Comment;
            FindPerson.SelectedCode = Distraint.Person;
            FindPerson2.SelectedCode = Distraint.AssetSharePerson;
            txtCommittalCode.Text = Distraint.Committal.ToString();
            txtSummaryJudgement.Text = Decision.DecisionDesc;
            txtOrderSender.Text = Distraint.OrderSender;
            txtOrderComment.Text = Distraint.OrderComment;
            txtComment.Text = Distraint.Comment;
            txtDate.Date = Distraint.DistDate;

            txtDateUn.Date = Distraint.UnDistDate;
            if (Distraint.UnDistNotCommittal == 1)
                rbUnOrder.Checked = true;
            else
                rbUnDecision.Checked = true;
            txtUnDecisionCode.Text = Distraint.UnDistCommittal.ToString();
            //txtUnDecisionDesc.Text = Distraint.UnDistComment;
            txtUnDesc.Text = Distraint.UnDistComment;
            txtUnOrderDesc.Text = Distraint.OrderCommentUnDist;
            txtUnOrderSender.Text = Distraint.UnDistOrderSender;
            if (Distraint.ArrestType == JArrestType.Decision)
            {

                radDecision.Checked = true;
                gbxDesion.Visible = true;
                gbxOrder.Visible = false;
                radDecision.Checked = true;
            }
            ///دستور
            else if (Distraint.ArrestType == JArrestType.Order)
            {
                radOrder.Checked = true;
                gbxOrder.Visible = true;
                gbxDesion.Visible = false;
                radOrder.Checked = true;

            }
        }

        private bool save()
        {
            #region CheckData
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ توقیف را وارد کنید", "خطا در ورود اطلاعات");
                tabTotal.SelectedTab = tabDistratint;
                txtDate.Focus();
                return false;
            }
            if (Distraint.AssetShareTable != null)
                foreach (DataRow row in Distraint.AssetShareTable.Rows)
                {
                    if (row["Distrainted"].ToString() != "")
                        if (Convert.ToDecimal(row["Share"]) < Convert.ToDecimal(row["Distrainted"]))
                        {
                            JMessages.Error("تعداد سهم توقیفی از سهم اصلی بیشتر است. ", "خطا در ورود اطلاعات");
                            return false;
                        }
                }
            if (radAsset.Checked == true)
            {
                if (txtAssetCode.Text == "")
                {
                    JMessages.Error("دارایی را مشخص کنید", "خطا در ورود اطلاعات");
                    return false;
                }
            }
            else if (radPerson.Checked == true)
            {
                if (FindPerson.SelectedCode == 0)
                {
                    JMessages.Error("شخص  را مشخص کنید", "خطا در ورود اطلاعات");
                    return false;

                }
            }
            else if (radPartAsset.Checked == true)
            {
                if (FindPerson2.SelectedCode == 0)
                {
                    JMessages.Error("دارایی یک شخص را مشخص کنید.", "خطا در ورود اطلاعات");
                    return false;

                }
                
            }

            if (radDecision.Checked == true)
            {
                if (txtCommittalCode.Text == "")
                {
                    JMessages.Error("لطفا رای دادگاه را مشخص کنید.", "Error");
                    txtCommittalCode.Focus();
                    return false;
                }
                
            }
            if (Distraint.Subject == 3 && Distraint.AssetShareTable.Rows.Count == 0)
            {
                JMessages.Error("هیچ دارایی مشخص نشده است.", "خطا");
                return false;
            }
            #endregion CheckData

            #region SET DATA
            if(radPerson.Checked)
                Distraint.Subject = Convert.ToInt32(JDistraintSubjectEnum.Person);
            if (radAsset.Checked)
                Distraint.Subject = Convert.ToInt32(JDistraintSubjectEnum.Asset);
            if (radPartAsset.Checked)
                Distraint.Subject = Convert.ToInt32(JDistraintSubjectEnum.AssetShare);
            
            Distraint.Asset = txtAssetCode.IntValue;
            Distraint.Person = FindPerson.SelectedCode;
            Distraint.AssetSharePerson = Convert.ToInt32(FindPerson2.SelectedCode);
            Distraint.Committal = txtCommittalCode.IntValue;
            Distraint.OrderSender = txtOrderSender.Text;
            Distraint.OrderComment = txtOrderComment.Text;
            Distraint.UnDistCommittal = txtUnDecisionCode.IntValue;
            Distraint.UnDistDate = txtDateUn.Date;

            Distraint.DistDate = txtDate.Date;
            Distraint.Comment = txtComment.Text;

            Distraint.UnDistOrderSender = txtUnOrderSender.Text;
            Distraint.OrderCommentUnDist = txtUnOrderDesc.Text;
            Distraint.Active = true;
            if (radDecision.Checked)
                Distraint.ArrestType = JArrestType.Decision;
            else
                Distraint.ArrestType = JArrestType.Order;

            if (rbUnDecision.Checked)
                Distraint.UnDistNotCommittal = 0;
            else
                Distraint.UnDistNotCommittal = 1;

            /// رفع توقفی
            if (!IsDistraint)
            {
                Distraint.Active = false;
            }


            #endregion SET DATA

            if (this.State == JFormState.Insert)
            {
                int _Code = Distraint.Insert();
                if (_Code > 0)
                {
                    jArchiveList.ObjectCode = _Code;
                    jArchiveList.ArchiveList();
                    return true;
                }
                else
                    return false;

            }
            else if (this.State == JFormState.Update)
            {
                jArchiveList.ArchiveList();
                return Distraint.Update();
            }
            return false;
        }

        private void SaveDistraint_Click(object sender, EventArgs e)
        {
            if (save())
            {
                Close();
            }
            else
            {
                JMessages.Error("اطلاعات در سیستم ذخیره نشد!", "خطا در ورود اطلاعات");
            }
        }

        private void searchPerson_Click(object sender, EventArgs e)
        {
            JFindPersonForm JFPF = new JFindPersonForm();
            
        }

        private void searchPerson_Click_1(object sender, EventArgs e)
        {
            int Code=FindPerson.SelectedCode;
            JAllPerson AllPerson=new JAllPerson(Code);
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            //JFindPersonForm JFPF = new JFindPersonForm();
            //JFPF.ShowDialog();
            //int PersonCode = JFPF.SelectedPersonCode;
            //Distraint.AssetShareTable = JAssetShares.GetDataTableAssetSharePerson(PersonCode);
            //DataColumn col = new DataColumn("IsDistraint",typeof(bool));
            //Distraint.AssetShareTable.Columns.Add(col);

            ////DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            ////column.Name = "IsDistraint";
            ////dgvAssetShare.Columns.Clear();
            ////dgvAssetShare.Columns.Add(column);
            
            //dgvAssetShare.DataSource = Distraint.AssetShareTable;
            //foreach (DataGridViewRow Row in dgvAssetShare.Rows)
            //{
            //    if (Row.Cells["DistraintCode"].Value.ToString()!="")
            //        Row.Cells["IsDistraint"].Value = true;

            //}
            //dgvAssetShare.Columns["Code"].Visible = false;
            //dgvAssetShare.Columns["owner"].Visible = false;
            //dgvAssetShare.Columns["DistraintCode"].Visible = false;
            ////txtPersonAssetShare.Text = PersonCode.ToString();
            //if (Distraint.AssetShareTable.Rows.Count>0)
            //{
            //    //labAssetSharePersonName.Text = Distraint.AssetShareTable.Rows[0]["owner"].ToString();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JDecisionSearchForm JDSF = new JDecisionSearchForm();
            JDSF.ShowDialog();
            int DecisionCode = JDSF._Code;
            JDecision Decision = new JDecision(DecisionCode);
            txtCommittalCode.Text = DecisionCode.ToString();
            txtSummaryJudgement.Text = Decision.DecisionDesc;
            
            
        }
        //private void Visible()
        //{
        //    txtAssetCode.Enabled = false;
        //    btmSearchAsset.Enabled = false;
        //    searchPerson.Enabled = false;
        //    txtPerson.Enabled = false;
        //    txtPersonAssetShare.Enabled = false;
        //    btnSearchPerson.Enabled = false;
        //    gbLegalPerson.Visible = false;
        //    gbRealPerson.Visible = false;
        //}

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btmSearchAsset_Click(object sender, EventArgs e)
        {
            JAssetSearchForm ASF = new JAssetSearchForm();
            ASF.ShowDialog();
            if (ASF.DialogResult == DialogResult.OK)
            {
                ShowAssetData(ASF._Code);
            }
        }

        private void ShowAssetData(int _Code)
        {
            if (_Code > 0)
            {
                DataTable AssetOwner = JAssetShares.GetDataTableAssetShareOwner(_Code, JOwnershipType.None);
                JAsset asset = new JAsset(_Code);
                dgvAssetOwner.DataSource = AssetOwner;
                txtAssetCode.Text = Convert.ToString(_Code);
                txtAssetType.Text = JLanguages._Text(asset.ClassName);
                lbAssetDesc.Text = (new JAsset(_Code)).Comment;
                if (dgvAssetOwner.Columns["Share"] != null)
                    dgvAssetOwner.Columns["Share"].Visible = false;
                dgvAssetOwner.ReadOnly = true;
            }
            else
            {
                dgvAssetOwner.DataSource = null;
                txtAssetCode.Text = "";
                txtAssetType.Text = "";
                lbAssetDesc.Text = "";
            }
        }
        private void radDecision_Click(object sender, EventArgs e)
        {
            gbxDesion.Visible = true;
            gbxOrder.Visible = false;
        }

        private void radOrder_Click(object sender, EventArgs e)
        {
            gbxOrder.Visible = true;
            gbxDesion.Visible = false;
        }

        private void radPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (radPerson.Checked)
            {
                tabTotal.TabPages.Clear();
                if (!IsDistraint)
                    tabTotal.TabPages.Add(tabUnDist);
                tabTotal.TabPages.Add(tabPerson);
                tabTotal.TabPages.Add(tabDistratint);
                tabTotal.TabPages.Add(tabImages);
                tabTotal.TabPages.Add(TabDistDesc);
            }

            else if (radAsset.Checked)
            {
                tabTotal.TabPages.Clear();
                if (!IsDistraint)
                    tabTotal.TabPages.Add(tabUnDist);
                tabTotal.TabPages.Add(tabAsset);
                tabTotal.TabPages.Add(tabDistratint);
                tabTotal.TabPages.Add(tabImages);
                tabTotal.TabPages.Add(TabDistDesc);
            }
            else if (radPartAsset.Checked)
            {
                tabTotal.TabPages.Clear();
                if (!IsDistraint)
                    tabTotal.TabPages.Add(tabUnDist);
                tabTotal.TabPages.Add(tabAssetShare);
                tabTotal.TabPages.Add(tabDistratint);
                tabTotal.TabPages.Add(tabImages);
                tabTotal.TabPages.Add(TabDistDesc);
            }
        }

        private void rbUnDecision_CheckedChanged(object sender, EventArgs e)
        {
            grpUnDecision.Visible = rbUnDecision.Checked;
            grpUnOrder.Visible = !rbUnDecision.Checked;
        }

        private void FindPerson2_AfterCodeSelected(object Sender, EventArgs e)
        {
            try
            {
                Distraint.AssetShareTable = JDistraintAssetShares.GetPersonShares(FindPerson2.SelectedCode, Distraint.Code);
                dgvAssetShare.DataSource = Distraint.AssetShareTable;
                dgvAssetShare.Columns["Code"].ReadOnly = true;
                dgvAssetShare.Columns["ACode"].Visible = false;
                dgvAssetShare.Columns["TransferComment"].ReadOnly = true;
                dgvAssetShare.Columns["Comment"].ReadOnly = true;
                dgvAssetShare.Columns["Share"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                return ;
            }
        }

        private void btnDelAsset_Click(object sender, EventArgs e)
        {
            txtAssetCode.Text = "";
            ShowAssetData(0);
        }

        private void btnUndist_Click(object sender, EventArgs e)
        {
            JDecisionSearchForm JDSF = new JDecisionSearchForm();
            JDSF.ShowDialog();
            int DecisionCode = JDSF._Code;
            JDecision Decision = new JDecision(DecisionCode);
            txtUnDecisionCode.Text = DecisionCode.ToString();
            txtUnDecisionDesc.Text = Decision.DecisionDesc;
        }
      
    }
    
}
