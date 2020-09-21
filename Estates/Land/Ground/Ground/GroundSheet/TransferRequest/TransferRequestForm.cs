using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JTransferRequestForm : JBaseForm
    {

        private int _Code;
        private int _SheetCode;

        public JTransferRequestForm()
        {
            InitializeComponent();

            ArchiveList.ClassName = "Estates.JTransferRequestForm";            
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }

        public JTransferRequestForm(int pCode , int pSheetCode)
        {
            InitializeComponent();
            _Code = pCode;
            _SheetCode = pSheetCode;
            if (pCode != 0)
                State = JFormState.Update;
            else
                State = JFormState.Insert;

            ArchiveList.ClassName = "RealEstate.JTransferRequestForm";
            ArchiveList.ObjectCode = pCode;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }

        private void Set_From()
        {
            JRequestTransferSheet tmp = new JRequestTransferSheet(_Code);
            _SheetCode = tmp.SheetCode;
            jucBuyer.SelectedCode = tmp.BuyerCode;
            jucSeller.SelectedCode = tmp.SellerCode;
            txtDate.Date = tmp.RequestDate;
            txtDesc.Text = tmp.Description;
            txtPrice.Text = tmp.Price.ToString();
            if (tmp.Responsible)
                chkRespon.Checked = true;
            else
                chkRespon.Checked = false;
            if (tmp.ManagerSaham)
                chkManagerSaham.Checked = true;
            else
                chkManagerSaham.Checked = false;
            if (tmp.Manager)
                chkManager.Checked = true;
            else
                chkManager.Checked = false;
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            JRequestTransferSheet tmp = new JRequestTransferSheet();
            if (_SheetCode <= 0)
            {
                JMessages.Error(" ثبت اطلاعات با خطا مواجه شده ", "کد برگه تعرفه");
                return;
            }
            if ((State == JFormState.Update) && (chkManager.Checked) && (chkManagerSaham.Checked) && (chkRespon.Checked))
            {
                if (jucBuyer.SelectedCode == 0)
                {
                    JMessages.Error(" خریدار را مشخص کنید ", "کد برگه تعرفه");
                    return;
                }                
            }
            tmp.SheetCode = _SheetCode;
            tmp.BuyerCode = jucBuyer.SelectedCode;
            tmp.SellerCode = jucSeller.SelectedCode;
            tmp.RequestDate = txtDate.Date;
            tmp.Description = txtDesc.Text;
            if (txtPrice.Text != "")
                tmp.Price = Convert.ToInt32(txtPrice.Text.Replace(".","").Replace("/","").Replace(",",""));
            if (chkRespon.Checked)
                tmp.Responsible = true;
            else
                tmp.Responsible = false;
            if (chkManagerSaham.Checked)
                tmp.ManagerSaham = true;
            else
                tmp.ManagerSaham = false;
            if (chkManager.Checked)
                tmp.Manager = true;
            else
                tmp.Manager = false;
            if (State == JFormState.Insert)
            {
                _Code = tmp.Insert();
                if (_Code > 0)
                {
                    ArchiveList.ObjectCode = _Code;
                    ArchiveList.ArchiveList();
                    JMessages.Message(" با موفقیت ثبت شد ", "", JMessageType.Information);
                }
                else
                    JMessages.Error(" ثبت اطلاعات با خطا مواجه شده ", "");
            }
            else if (State == JFormState.Update)
            {
                tmp.Code = _Code;
                if (tmp.Update())
                {
                    ArchiveList.ArchiveList();
                    JMessages.Message(" با ویرایش ثبت شد ", "", JMessageType.Information);
                }
                else
                    JMessages.Error(" ویرایش اطلاعات با خطا مواجه شده ", "");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnSabt_Click(null, null);
            if (_Code <= 0)
            {
                return;
            }
            JRequestTransferSheet RTS = new JRequestTransferSheet(_Code);
            RTS.PrintRequerst();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TransferRequestForm_Load(object sender, EventArgs e)
        {
            txtDate.Date = DateTime.Now;
            if (_Code != 0)
                Set_From();
            else if (_SheetCode != 0)
            {
                JGroundSheet tmp = new JGroundSheet(_SheetCode);
                jucSeller.SelectedCode = tmp.PCode;

            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            DataTable _DT = JRequestTransferSheets.GetWordPrintData(_Code);
            JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.RequestTransferSheet.GetHashCode());
            DRF.Add(_DT);
            DRF.ShowDialog();
        }
    }
}
