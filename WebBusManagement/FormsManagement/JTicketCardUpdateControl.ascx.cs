using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JTicketCardUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
            if (!IsPostBack)
            {
                LoadCardType();
            }
        }

        public void LoadCardType()
        {
            DataTable DtCardType = new DataTable();
            DtCardType = BusManagment.Card.JCards.GetDataTable(0);
            cmbCardType.DataSource = DtCardType;
            cmbCardType.DataTextField = "Type";
            cmbCardType.DataValueField = "Type";
            cmbCardType.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                SmartCard.JCards Cards = new SmartCard.JCards();
                Cards.GetData(Code);
                txtRFIDNumber.Text = Cards.RfidNumber.ToString();
                txtDiscription.Text = Cards.Description;
                chkStatus.Checked = Cards.Status;
                cmbCardType.SelectedValue = Cards.PassengerCardType.ToString();
                txtSerialNumber.Text = Cards.CardCode.ToString();
                if (Cards.pCode != null && Cards.pCode > 0)
                {
                    ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Cards.pCode;
                }
            }
        }

        public bool Save()
        {
            SmartCard.JCards Cards = new SmartCard.JCards();
            Cards.Code = Code;
            Cards.RfidNumber =  Convert.ToInt64(txtRFIDNumber.Text);
            Cards.Description = txtDiscription.Text;
            Cards.Status = chkStatus.Checked;
            Cards.PassengerCardType = Convert.ToInt32(cmbCardType.SelectedValue);
            Cards.CardType = Convert.ToInt32(cmbCardType.SelectedValue);
            Cards.pCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            Cards.CardCode = Convert.ToInt32(txtSerialNumber.Text);
            if (Code > 0)
                return Cards.Update(true);
            else
                return Cards.Insert(true, true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SmartCard.JCards Cards = new SmartCard.JCards();
            Cards.Code = Code;
            if (Cards.Delete(true))
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}