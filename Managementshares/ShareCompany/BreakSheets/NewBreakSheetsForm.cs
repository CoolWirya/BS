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
    public partial class JNewBreakSheetsForm : ClassLibrary.JBaseForm
    {
        JShareCompany shareCompany;
        decimal currentShareCount;
        decimal currentShareCost;
        public JNewBreakSheetsForm(int CompanyCode)
        {
            InitializeComponent();
            shareCompany = new JShareCompany(CompanyCode);
            ShowInfo();
        }

        private void ShowInfo()
        {
            person.SelectedCode = shareCompany.PCode;
            txtDate.Date = DateTime.Today;
            lbCost.Text = ClassLibrary.JGeneral.MoneyStr(shareCompany.CurrentShareCost.ToString());
            lbShareCount.Text = shareCompany.CurrentShareCount.ToString();
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
            if (txtShareCount.IntValue == 0)
            {
                JMessages.Error("لطفا تعداد سهم را وارد کنید.", "");
                return;
            }

            if (JMessages.Question("همه برگه ها باطل شده و برگه جدید صادر خواهد شد. آیا از افزایش سرمایه اطمینان دارید؟", "تائید") != DialogResult.Yes)
                return;
            if (JMessages.Question("آیا از شکستن برگه سهم ها اطمینان دارید؟", "تائید") != DialogResult.Yes)
                return;
            JIncreaseShare incerase = new JIncreaseShare();
            incerase.IncDate = txtDate.Date;
            incerase.ShareCount = shareCompany.CurrentShareCount * txtShareCount.IntValue;
            incerase.Cost  = shareCompany.CurrentShareCost / txtShareCount.IntValue;
            incerase.Comment = txtComment.Text;
            incerase.CompanyCode = shareCompany.Code;
            incerase.BreakCount = txtShareCount.IntValue;
            incerase.Action = JCompanyActions.BreakSheets.GetHashCode();
            if (shareCompany.BreakSheets(incerase))
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
                lbShareCount.Text = (txtShareCount.IntValue * shareCompany.CurrentShareCount).ToString();
                lbCost.Text = JGeneral.MoneyStr((shareCompany.CurrentShareCost / txtShareCount.IntValue).ToString());
            }
            catch
            {
                lbCost.Text = "";
            }
        }

        private void JNewBreakSheetsForm_Shown(object sender, EventArgs e)
        {
            txtDate.Text = JDateTime.FarsiDate(DateTime.Today);
        }
    }
}
