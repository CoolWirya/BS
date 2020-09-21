using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legal
{

	public partial class JBaseContractForm : ClassLibrary.JBaseForm
	{
		public Legal.JBaseContractForm.JStateContractForm tempState;
		public Boolean isSave = false;
		public Boolean ApplyDataSet = false;
		public int ContractTypeCode;
        public int GroupCode;
        public int ConcernCode;
        public int SellerTafziliCode;
        public int BuyerTafziliCode;
        public static Int64 TotalPrice;

		public int Index
		{
			get;
			set;
		}
		public enum JStateContractForm
		{
			Insert,
			Update,
			// Change,
			View
		}

		public static int MaxFormNumber = 20;
		/// <summary>
		/// ترتیب ذخیره سازی
		/// </summary>
		public int SaveOrder = MaxFormNumber;
		/// <summary>
		/// وضعیت فرم
		/// </summary>
		public JStateContractForm State { get; set; }

		public JContractForms ContractForms;

		public virtual bool Save(ClassLibrary.JDataBase pDB)
		{
			return true;
		}

		public virtual bool SavePreview(DataTable dt)
		{
			return SavePreview(dt, false, false);
		}
		public virtual bool SavePreview(DataTable dt, bool pSetValue)
		{
			return SavePreview(dt, pSetValue, false);
		}
		public virtual bool SavePreview(DataTable dt, bool pSetValue, bool pOffline)
		{
			return true;
		}

		public virtual bool CheckData()
		{
			return true;
		}

		public virtual bool DeleteContract(ClassLibrary.JDataBase pDB)
		{
			return true;
		}

		public virtual bool SaveBack()
		{
			return true;
		}

		public virtual bool ApplyData()
		{
			return true;
		}

		public void DissolutionDialog()
		{
			JCancelContractForm PE = new JCancelContractForm(ContractForms.Contract.Code);
			PE.ShowDialog();
		}

		public JBaseContractForm()
		{
			InitializeComponent();
		}

		private void TrayBtn_clicked(object sender, EventArgs e)
		{
		}

		private void JBaseContractForm_Load(object sender, EventArgs e)
		{
		}

		private void JBaseContractForm_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		private void JBaseContractForm_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void JBaseContractForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyValue == (int)Keys.K)
			{
				Legal.Contract.Forms.ContractFormsList CL = new Legal.Contract.Forms.ContractFormsList();
				CL.ContractForms = this.ContractForms;
				CL.Show();
				CL.Left = this.Left + this.Width;
			}

		}

		private void JBaseContractForm_MouseClick(object sender, MouseEventArgs e)
		{
			//if (e.Button == MouseButtons.Right)
			//{
			//    ApplyData();
			//}
		}
	}
}
