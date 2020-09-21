using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
//using Estates;

namespace Finance
{
    public partial class JAssetSearchForm : ClassLibrary.JBaseForm
    {
        public int _Code;
        public string _ClassName;
        private int _ContractTypeCode;

        private bool CheckActiveAssetShares;
        public JAssetSearchForm()
            : this(false, "",0)
        {
        }

        public JAssetSearchForm(bool pCheckActiveAssetShares)
            : this(pCheckActiveAssetShares, "",0)
        {

        }

        public JAssetSearchForm(string pClassName)
            : this(false, pClassName,0)
        {
        }
        /// <summary>
        /// در صورتی که فرم با این پارامتر ساخته شود و مقدارش صحیح باشد، فعال بودن همه سهمهای دارایی انتخاب شده چک میشود
        /// </summary>
        /// <param name="pCheckActiveAssetShares"></param>
        public JAssetSearchForm(bool pCheckActiveAssetShares, string pClassName)
            : this(pCheckActiveAssetShares, pClassName, 0)
        {
        }

        public JAssetSearchForm(bool pCheckActiveAssetShares, string pClassName, int pContractTypeCode)
        {
            InitializeComponent();

            _ContractTypeCode = pContractTypeCode;

            cmbAssetLoad();
            CheckActiveAssetShares = pCheckActiveAssetShares;
            if (pClassName != "")
            {
                //JAssetType assetType = new JAssetType(_ClassName);
                cmbAssetType.Text = JLanguages._Text(pClassName);
                cmbAssetType.Enabled = false;
                _ClassName = pClassName;
            }

			try
			{
				txtComment.Text = ClassLibrary.JMainFrame.GetKeyValue("Finance.JAssetSearchForm.LastSearch").ToString();
			}
			catch
			{
			}

        }

        public void cmbAssetLoad()
        {
            foreach (JAssetType type in JAsset.GetAssetType())
            {
                cmbAssetType.Items.Add(type);
            }
            //cmbAssetType.DisplayMember = "lang";
            //cmbAssetType.ValueMember = "ClassName";
            //cmbAssetType.DataSource = JAsset.GetAssetType();
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAssetType.SelectedItem == null)
                {
                    JMessages.Error("لطفا نوع دارایی را انتخاب کنید", "Error");
                    cmbAssetType.Focus();
                    return;
                }
                JAction Action = new JAction("RunAssetAdvanceSearch", ((JAssetType)cmbAssetType.SelectedItem).ClassName + ".AdvancedSearch", new object[] { true}, null);
                int[] selectedCodes = (int[])Action.run();
                JAsset asset = new JAsset();
                jdgvAsset.DataSource = asset.Search(selectedCodes);
                SetGridColumns();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbAssetType.SelectedItem == null)
            {
                JMessages.Error("لطفا نوع دارایی را انتخاب کنید", "Error");
                cmbAssetType.Focus();
                return;
            }
            JAsset tmp = new JAsset();
            tmp.Comment = txtComment.Text.Trim();
			ClassLibrary.JMainFrame.SetKeyValue("Finance.JAssetSearchForm.LastSearch", txtComment.Text.Trim());
            tmp.ClassName = ((Finance.JAssetType)(cmbAssetType.SelectedItem)).ClassName;
            jdgvAsset.DataSource = tmp.Find(_ContractTypeCode);
            //SetGridColumns();
            jdgvAsset.Focus();
        }

        /// <summary>
        /// مخفی کردن ستونهای گرید
        /// </summary>
        private void SetGridColumns()
        {
            //foreach (DataGridViewColumn column in jdgvAsset.Columns)
            //{
            //    if (column.Name != "AssetType" 
            //        && column.Name != "StatusName" 
            //        && column.Name != "Comment" 
            //        && column.Name != "PrimaryWorth"
            //        && column.Name != "Name")
            //        column.Visible = false;
            //    else
            //        column.Visible = true;
            //}
            //jdgvAsset.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //jdgvAsset.Columns["PrimaryWorth"].DefaultCellStyle.Format = "N0";
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (jdgvAsset.SelectedRow != null)
            {
                _Code = Convert.ToInt32(jdgvAsset.SelectedRow.Row["Code"].ToString());
                JAsset asset = new JAsset(_Code);
                asset.CheckAssetShares = CheckActiveAssetShares;
                if (asset.AllSharesAreActive)
                    DialogResult = DialogResult.OK;
                else
                {
                    JMessages.Error("همه سهم های این دارایی فعال نیستند", "Error");
                    return;
                }
            }
        }

        private void jdgvAsset_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnOK.PerformClick();

        }

        private void cmbAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ClassName = cmbAssetType.SelectedItem.ToString();
        }

        private void jdgvAsset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }


    }
}
