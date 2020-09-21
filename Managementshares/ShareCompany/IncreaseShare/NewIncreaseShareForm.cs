using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JNewIncreaseShareForm : ClassLibrary.JBaseForm
    {
        JShareCompany shareCompany;
        decimal currentShareCount;
        decimal currentShareCost;
        public JNewIncreaseShareForm(int CompanyCode)
        {
            InitializeComponent();
            shareCompany = new JShareCompany(CompanyCode);
            ShowInfo();
        }

        private void ShowInfo()
        {
            person.SelectedCode = shareCompany.PCode;
            txtDate.Date = DateTime.Today;
            txtShareCost.Text = ClassLibrary.JGeneral.MoneyStr(shareCompany.CurrentShareCost.ToString());
            txtShareCount.Text = shareCompany.CurrentShareCount.ToString();
            currentShareCount = txtShareCount.DecimalValue;
            currentShareCost = txtShareCost.MoneyValue;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ را وارد کنید.", "");
                return;
            }
            if (txtShareCost.MoneyValue  == 0)
            {
                JMessages.Error("لطفا مبلغ هر سهم را وارد کنید.", "");
                return;
            }
            if (txtShareCount.IntValue == 0)
            {
                JMessages.Error("لطفا تعداد سهم را وارد کنید.", "");
                return;
            }
            if (currentShareCount > txtShareCount.DecimalValue)
            {
                JMessages.Error("تعداد سهم جدید نمیتواند کمتر از تعداد جاری باشد.", "error");
                return;
            }
            if (currentShareCount >= txtShareCount.DecimalValue && currentShareCost >= txtShareCost.MoneyValue)
            {
                JMessages.Error("تعداد سهم جدید باید بیشتر از تعداد جاری باشد.", "error");
                return;
            }
            if (currentShareCost > txtShareCost.MoneyValue)
            {
                JMessages.Error("مبلغ سهم جدید نمیتواند کمتر از مبلغ جاری باشد.", "error");
                return;
            }
            bool DeActiveAll=false;
            if (currentShareCost < txtShareCost.MoneyValue)
            {
                if (JMessages.Question("مبلغ سهم جدید بیشتر از مبلغ جاری میباشد. آیا میخواهید برگه های جاری باطل شود و برگه جدید صادر شود؟", "تائید") == DialogResult.Yes)
                {
                    DeActiveAll = true;
                }
                else
                    return;
            }
            
            if (JMessages.Question("آیا از افزایش سرمایه اطمینان دارید؟", "تائید") != DialogResult.Yes)
                return;
            JIncreaseShare incerase = new JIncreaseShare();
            incerase.IncDate = txtDate.Date;
            incerase.ShareCount = txtShareCount.IntValue;
            incerase.Comment = txtComment.Text;
            incerase.CompanyCode = shareCompany.Code;
            incerase.Cost = txtShareCost.DecimalValue;
            incerase.Action = JCompanyActions.IncreaseShare.GetHashCode();
            if (shareCompany.IncreaseShare(incerase, DeActiveAll))
            {
                JMessages.Information("افزایش سرمایه با موفقیت انجام شد.", "");
                DialogResult = DialogResult.OK;
            }
            else
                JMessages.Error("عملیات افزایش سرمایه با مشکل مواجه شده است.", "خطا");
        }

        private void txtShareCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbAllCost.Text = JGeneral.MoneyStr((txtShareCount.IntValue * txtShareCost.MoneyValue).ToString());
            }
            catch
            {
                lbAllCost.Text = "";
            }
        }

        private void JNewIncreaseShareForm_Shown(object sender, EventArgs e)
        {
            txtDate.Text = JDateTime.FarsiDate(DateTime.Today);
        }
    }
}
