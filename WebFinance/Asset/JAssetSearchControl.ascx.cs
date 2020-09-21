using ClassLibrary;
using Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebFinance.Asset
{
	public partial class JAssetSearchControl : System.Web.UI.UserControl
	{
		public int _Code;
		public string _ClassName;
		private int _ContractTypeCode = 0;

		#region Constructor

		private bool CheckActiveAssetShares;
        public JAssetSearchControl()
            : this(false, "",0)
        {
        }

        public JAssetSearchControl(bool pCheckActiveAssetShares)
            : this(pCheckActiveAssetShares, "",0)
        {

        }

        public JAssetSearchControl(string pClassName)
            : this(false, pClassName,0)
        {
        }
        /// <summary>
        /// در صورتی که فرم با این پارامتر ساخته شود و مقدارش صحیح باشد، فعال بودن همه سهمهای دارایی انتخاب شده چک میشود
        /// </summary>
        /// <param name="pCheckActiveAssetShares"></param>
        public JAssetSearchControl(bool pCheckActiveAssetShares, string pClassName)
            : this(pCheckActiveAssetShares, pClassName, 0)
        {
        }

		public JAssetSearchControl(bool pCheckActiveAssetShares, string pClassName, int pContractTypeCode)
        {

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
        }

		private void cmbAssetLoad()
		{
			cmbAssetType.DataSource = JAsset.GetAssetType();
			cmbAssetType.DataTextField = "FarsiName";
			cmbAssetType.DataValueField = "ClassName";
			cmbAssetType.DataBind();
		}

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			Telerik.Web.UI.RadAjaxManager manager = Telerik.Web.UI.RadAjaxManager.GetCurrent(Page);
			manager.AjaxRequest += manager_AjaxRequest;
			cmbAssetLoad();
		}
		void manager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
		{
		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			if (cmbAssetType.SelectedItem == null)
			{
				WebClassLibrary.JWebManager.ShowMessage("لطفا نوع دارایی را انتخاب کنید", WebClassLibrary.MessageType.Error);
				return;
			}
			JAsset tmp = new JAsset();
			tmp.Comment = txtComment.Text.Trim();
			tmp.ClassName = cmbAssetType.SelectedValue;
			gvAssets.DataSource = tmp.Find(_ContractTypeCode);
			gvAssets.DataBind();
		}
	}
}