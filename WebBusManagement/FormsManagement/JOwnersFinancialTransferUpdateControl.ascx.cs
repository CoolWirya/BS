using BusManagment.Bus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JOwnersFinancialTransferUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        public Int64 MovablePrice;
        protected void Page_Load(object sender, EventArgs e)
        {
            Code = 0;
            int.TryParse(Request["Code"], out Code);
            if (Code > 0)
            {
                LoadOwners();
                //GetMovablePrice();
            }

        }
//        void GetMovablePrice()
//        {
//            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
//            db.setQuery(@"select 
//                10 * sum(cast(isnull(BedPrice,0) as bigint)) - 10 * sum(cast(isnull(BesPrice,0) as bigint))
//                from FinDocumentDetails 
//                where 
//                DocCode = 120160534
//				and MoeinCode = 3
//                and TafziliCode1 =" + Code);
//            try
//            {
//                MovablePrice = Math.Abs(Int64.Parse(db.Query_DataTable().Rows[0][0].ToString()));
//            }
//            catch (Exception ex)
//            {
//                ClassLibrary.JSystem.Except.AddException(ex);
//            }
//            finally
//            {
//                db.Dispose();
//            }
//        }
        public void LoadOwners()
        {
            DataTable BusOwners = JBusOwners.GetBusOwners();
            this.lblSenderOwner.Text = BusOwners.Select("Code = " + Code).First()[1].ToString();
            this.cmbReceiverOwner.DataSource = BusOwners;
            this.cmbReceiverOwner.DataTextField = "Name";
            this.cmbReceiverOwner.DataValueField = "Code";
            this.cmbReceiverOwner.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Int64 Price;
            //if (Int64.TryParse(txtPrice.Text.Trim(), out Price) && Price / 10 > 0)
            //{
                //if (Price <= MovablePrice)
                //{
                    if (Save())//Price
                        Page.ClientScript.RegisterStartupScript(GetType(), "success", "alert('عملیات با موفقیت انجام شد.');", true);
                    else
                        Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('دوباره تلاش کنید.');", true);
                //}
                //else
                //    Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('مبلغ از مبلغ قابل انتقال بیشتر است.');", true);
            //}
            //else
            //    Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('لطفا مبلغ را انتخاب کنید.');", true);
        }
        bool Save()//Int64 Price
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            try
            {
                string[] Param = new string[2] { "@Sender", "@Reciver" };//, "@price"
                DataTable dt = Db.ExecuteProcedure_Query("[dbo].[SP_TasvieHesab]", Param, new string[2] 
                    { 
                        Code.ToString(),
                        cmbReceiverOwner.SelectedValue,
                        //(Price / 10).ToString()
                    });
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}