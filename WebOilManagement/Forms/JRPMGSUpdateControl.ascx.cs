using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
	public partial class JRPMGSUpdateControl : System.Web.UI.UserControl
	{
		int Code;
		int ReferCode;

		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request["Code"], out Code);
			int.TryParse(Request["ReferCode"], out ReferCode);
			if (ReferCode == 0 && Code > 0)
				ReferCode = (new Automation.JARefer()).FindRefer(JWebOilManagement._ConstClassName, Code, 0);
			_SetForm();
		}

		public void _SetForm()
		{
			if (Code > 0)
			{
				OilProductsDistributionCompany.RPM.JOilRPMGS JOilRPMGS = new OilProductsDistributionCompany.RPM.JOilRPMGS();
				JOilRPMGS.GetData(Code);
				txtVersion.Text = JOilRPMGS.Version;
				((WebControllers.MainControls.Date.JDateControl)jDateRegister).SetDate(JOilRPMGS.DateIns);
				txtComment.Text = JOilRPMGS.Comment;
				txtStation.Text = JOilRPMGS.GasStationCode;
				txtStatus.Text = JOilRPMGS.StatusofGsRPM;
				txtPCode.Text = JOilRPMGS.PCode.ToString();
				txtHour.Text = JOilRPMGS.Time.ToString();
			}
		}

		public bool Save()
		{
			OilProductsDistributionCompany.RPM.JOilRPMGS JOilRPMGS = new OilProductsDistributionCompany.RPM.JOilRPMGS();
			if (Code > 0) JOilRPMGS.GetData(Code);
			bool result = false;
			try
			{

				JOilRPMGS.Version = txtVersion.Text;
				JOilRPMGS.DateIns = ((WebControllers.MainControls.Date.JDateControl)jDateRegister).GetDate();
				JOilRPMGS.Comment = txtComment.Text;
				JOilRPMGS.GasStationCode = txtStation.Text;
				JOilRPMGS.StatusofGsRPM = txtStatus.Text;
				JOilRPMGS.PCode = Convert.ToInt32(txtPCode.Text);
				JOilRPMGS.Time = txtHour.Text;

				if (Code > 0)
					result = JOilRPMGS.Update();
				else
					result = JOilRPMGS.Insert() > 0 ? true : false;

			}
			catch (Exception ex)
			{

			}
			return result;
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Save())
				WebClassLibrary.JWebManager.CloseAndRefresh();
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			OilProductsDistributionCompany.RPM.JOilRPMGS JOilRPMGS = new OilProductsDistributionCompany.RPM.JOilRPMGS();
			JOilRPMGS.Code = Code;
			if (JOilRPMGS.Delete())
				WebClassLibrary.JWebManager.CloseAndRefresh();
		}

		protected void btnRefer_Click(object sender, EventArgs e)
		{
			WebControllers.Automation.JAutomationRefer.ShowRefer(JWebOilManagement._ConstClassName, 0, Code, OilProductsDistributionCompany.RPM.JOilRPMGSes.GetDataTable(Code), ReferCode, "ارجاع RPM");
		}

	}
}