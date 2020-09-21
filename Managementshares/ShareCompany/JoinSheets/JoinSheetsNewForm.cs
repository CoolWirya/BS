using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JoinSheetsNewForm : JBaseForm
    {
        JShareCompany shareCompany;
        decimal currentShareCount;
        decimal currentShareCost;
        public JoinSheetsNewForm(int CompanyCode)
        {
            InitializeComponent();
            shareCompany = new JShareCompany(CompanyCode);
            ShowInfo();
        }

        private void ShowInfo()
        {
            person.SelectedCode = shareCompany.PCode;
            txtDate.Date = DateTime.Today;
            lbSheetsCount.Text = shareCompany.GetSheetsCount().ToString();
            lbPersonSheetsCount.Text = shareCompany.GetPersonSheetsCount().ToString();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ را وارد کنید.", "");
                return;
            }
            if (JMessages.Question("آیا از تجمیع برگه ها اطمینان دارید؟", "تائید") != DialogResult.Yes)
                return;
            if (JMessages.Question("همه برگه ها باطل خواهد شد و برگه های جدید صادر خواهد شد. آیا میخواهید ادامه دهید؟", "تائید") != DialogResult.Yes)
                return;
            JIncreaseShare incerase = new JIncreaseShare();
            incerase.IncDate = txtDate.Date;
            incerase.ShareCount = shareCompany.CurrentShareCount;
            incerase.Comment = txtComment.Text;
            incerase.CompanyCode = shareCompany.Code;
            incerase.Cost = shareCompany.CurrentShareCost;
            incerase.Action = JCompanyActions.JoinAllSheets.GetHashCode();
            if (shareCompany.JoinAllSheets(incerase))
            {
                JMessages.Information("تجمیع برگه ها با موفقیت انجام شد.", "");
                DialogResult = DialogResult.OK;
            }
            else
                JMessages.Error("عملیات تجمیع برگه ها با مشکل مواجه شده است.", "خطا");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
