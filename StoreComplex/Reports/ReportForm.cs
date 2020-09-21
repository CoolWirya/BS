using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JReportForm : Globals.JBaseForm
    {
        public JReportForm()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            ///رسید
            JSCGoods goods = new JSCGoods();
            goods.SetComboBox(cmbReceiptGoodsGroup, 0);
            cmbReceiptGoods.DataSource = StoreManagement.JGoods.GetDataTable(0);
            cmbReceiptGoods.DisplayMember = "Name";
            cmbReceiptGoods.ValueMember = "Code";
            cmbReceiptGoods.SelectedIndex = -1;
            /// حواله
            goods.SetComboBox(cmbTranGoodsGroup, 0);
            cmbTranGoods.DataSource = StoreManagement.JGoods.GetDataTable(0);
            cmbTranGoods.DisplayMember = "Name";
            cmbTranGoods.ValueMember = "Code";
            cmbTranGoods.SelectedIndex = -1;
            ///خدمات
            JVanTypes types = new JVanTypes();
            cmbServiceDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
            types.SetComboBox(cmbServiceDriveTpye, 0);
            
            JServiceTypes services = new JServiceTypes();
            services.SetComboBox(cmbServiceTypes, 0);
            ///انبارها
            cmbStorages.DataSource = StoreComplex.JSCStorages.GetDatatable(0);
            cmbStorages.DisplayMember = "Title";
            cmbStorages.ValueMember = "Code";
            cmbStorages.SelectedIndex = -1;
            ///
            grdContracts.ShowToolbar = true;
            grdGoods.ShowToolbar = true;
            grdPrivateRenew.ShowToolbar = true;
            grdPrivateStorage.ShowToolbar = true;
            grdReceipts.ShowToolbar = true;
            grdRenew.ShowToolbar = true;
            grdServices.ShowToolbar = true;
            grdTransfers.ShowToolbar = true;
            grdConveyService.ShowToolbar = true;
            grdLoadingService.ShowToolbar = true;
        } 

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string contractFilter = "";
            string receiptFilter = "";
            string tranFilter = "";
            string serviceFilter = "";
            string privateStorageFilter = "";
            string title = "";

            #region Contract
            if (personContract.SelectedCode > 0)
            {
                contractFilter += " AND PersonContract.PersonCode = " + personContract.SelectedCode;
                JAllPerson person = new JAllPerson(personContract.SelectedCode);
                title += " طرف قرارداد: " + person.Name;
            }
            if (txtFromDateContract.Date != DateTime.MinValue || txtToDateContract.Date != DateTime.MinValue)
            {
                title += "،تاریخ قرارداد: " + txtFromDateContract.Text;
            }
            if (txtFromDateContract.Date != DateTime.MinValue)
            {
                contractFilter += " AND  Contract.Date >=" + JDataBase.Quote(txtFromDateContract.Date.ToShortDateString());
                title += "، از تاریخ:" + txtFromDateContract.Text;
            }
            if (txtToDateContract.Date != DateTime.MinValue)
            {
                contractFilter += " AND Contract.Date <=" + JDataBase.Quote(txtToDateContract.Date.ToShortDateString());
                title += "، تا تاریخ:" + txtToDateContract.Text;
            }
            if (cmbContractType.SelectedIndex > 0)
            {
                contractFilter += " AND Contract.SCContractType =" + cmbContractType.SelectedIndex;
                title += "، نوع قرارداد:" + cmbContractType.SelectedIndex;
            } 
            if (txtContractSCCode.Text !="")
            {
                contractFilter += " AND Contract.SCCode =" + JDataBase.Quote(txtContractSCCode.Text);
                title += "، کد قرارداد:" + (txtContractSCCode.Text);
            }
            #endregion Contract

            #region Receipt
            if (txtFromDateReceipt.Date != DateTime.MinValue || txtToDateReceipt.Date != DateTime.MinValue)
            {
                title += "،تاریخ رسید: ";
            }
            if (txtFromDateReceipt.Date != DateTime.MinValue)
            {
                receiptFilter += " AND Convert(Date, Receipt.Date) >=  " + JDataBase.Quote(txtFromDateReceipt.Date.ToShortDateString());
                title += "از تاریخ: " + txtFromDateReceipt.Text;
            }
            if (txtToDateReceipt.Date != DateTime.MinValue)
            {
                receiptFilter += " AND Convert(Date, Receipt.Date) <=  " + JDataBase.Quote(txtToDateReceipt.Date.ToShortDateString());
                title += "تا تاریخ: " + txtToDateReceipt.Text;
            }
            if (cmbReceiptGoodsGroup.SelectedValue!= null)
            {
                receiptFilter += " AND RGood.GroupCode =  " + cmbReceiptGoodsGroup.SelectedValue.ToString();
                title += "، گروه کالا:"+cmbReceiptGoodsGroup.Text;
            }

            if (cmbReceiptGoods.SelectedValue != null)
            {
                receiptFilter += " AND ReceiptGood.GoodCode =  " + cmbReceiptGoods.SelectedValue.ToString();
                title += "، نوع کالای رسید:" + cmbReceiptGoods.Text;
            }
            if (txtReceiptDesc.Text.Trim() != string.Empty)
            {
                receiptFilter += " AND ReceiptGood.Description LIKE  N" + JDataBase.Quote("%" + txtReceiptDesc.Text + "%");
                title += "، شرح کالای رسید:" + txtReceiptDesc.Text;
            }
            if (txtFromGoodCountRec.DecimalValue > 0)
            {
                receiptFilter += " AND ReceiptGood.Amount >=" + txtFromGoodCountRec.DecimalValue;
                title += "، تعداد کالای رسید بیشتر از:" + txtFromGoodCountRec.Text;
            }
            if (txtToGoodCountRec.DecimalValue > 0)
            {
                receiptFilter += " AND ReceiptGood.Amount <=" + txtToGoodCountRec.DecimalValue;
                title += "، تعداد کالای رسید کمتر از:" + txtToGoodCountRec.Text;
            }
            if (chCountingReceipt.Checked || chBoxReceipt.Checked || chToneReceipt.Checked || chMeterReceipt.Checked)
            {
                string strStoreType = " AND ReceiptGood.StoreType IN(";
                if (chCountingTran.Checked)
                    strStoreType += JStoreType.Counting.GetHashCode() + ",";
                if (chBoxReceipt.Checked)
                    strStoreType += JStoreType.Box.GetHashCode() + ",";
                if (chMeterReceipt.Checked)
                    strStoreType += JStoreType.Meter.GetHashCode() + ",";
                if (chToneReceipt.Checked)
                    strStoreType += JStoreType.Ton.GetHashCode() + ",";
                receiptFilter += strStoreType.Substring(0, strStoreType.Length - 1)+")";
            }
            if (txtFromSerialReceipt.Text != "")
            {
                receiptFilter += " AND Receipt.Serial >=" + JDataBase.Quote(txtFromSerialReceipt.Text);
                title += "، سریال رسید از:" + txtFromSerialReceipt.Text;
            }
            if (txtToSerialReceipt.Text != "")
            {
                receiptFilter += " AND Receipt.Serial <=" + JDataBase.Quote(txtToSerialReceipt.Text);
                title += "، سریال رسید تا:" + txtToSerialReceipt.Text;
            }
            #endregion Receipt

            #region Transfer
            if (txtFromDateTran.Date != DateTime.MinValue || txtToDateTran.Date != DateTime.MinValue)
            {
                title += "،تاریخ حواله: ";
            }
            if (txtFromDateTran.Date != DateTime.MinValue)
            {
                tranFilter += " AND Convert(Date, Transfer.Date) >=  " + JDataBase.Quote(txtFromDateTran.Date.ToShortDateString());
                title += "از تاریخ: " + txtFromDateTran.Text;
            }
            if (txtToDateTran.Date != DateTime.MinValue)
            {
                tranFilter += " AND Convert(Date, Transfer.Date) <=  " + JDataBase.Quote(txtToDateTran.Date.ToShortDateString());
                title += "تا تاریخ: " + txtToDateTran.Text;
            }
            if (cmbTranGoodsGroup.SelectedValue != null)
            {
                tranFilter += " AND TGood.GroupCode =  " + cmbTranGoodsGroup.SelectedValue.ToString();
                title += "، گروه کالا:" + cmbTranGoodsGroup.Text;
            }

            if (cmbTranGoods.SelectedValue != null)
            {
                tranFilter += " AND TranReceiptGood.GoodCode =  " + cmbTranGoods.SelectedValue.ToString();
                title += "، نوع کالای حواله:" + cmbTranGoods.Text;
            }
            if (txtTranDesc.Text.Trim() != string.Empty)
            {
                tranFilter += " AND TranGood.Description LIKE  N" + JDataBase.Quote("%" + txtTranDesc.Text + "%");
                title += "، شرح کالای حواله:" + txtTranDesc.Text;
            }
            if (txtFromGoodCountRec.DecimalValue > 0)
            {
                tranFilter += " AND TranGood.Amount >=" + txtFromGoodCountRec.DecimalValue;
                title += "، تعداد کالای حواله بیشتر از:" + txtFromGoodCountRec.Text;
            }
            if (txtToGoodCountRec.DecimalValue > 0)
            {
                tranFilter += " AND TranGood.Amount <=" + txtToGoodCountRec.DecimalValue;
                title += "، تعداد کالای حواله کمتر از:" + txtToGoodCountRec.Text;
            }
            if (chCountingTran.Checked || chTranBox.Checked || chTranTone.Checked || chTranMeter.Checked)
            {
                string strStoreType = " AND TranGood.StoreType IN(";
                if (chCountingTran.Checked)
                    strStoreType += JStoreType.Counting.GetHashCode() + ",";
                if (chTranBox.Checked)
                    strStoreType += JStoreType.Box.GetHashCode() + ",";
                if (chMeterReceipt.Checked)
                    strStoreType += JStoreType.Meter.GetHashCode() + ",";
                if (chTranTone.Checked)
                    strStoreType += JStoreType.Ton.GetHashCode() + ",";
                tranFilter += strStoreType.Substring(0, strStoreType.Length - 1)+")";
            }
            #endregion Transfer

            #region Services
            //// سرویس حمل و نقل
            if (txtServiceConveyFromCost.Text != "" || txtServiceConveyToCost.Text != "")
            {
                title += "هزینه سرویس حمل و نقل، ";
            }
            if (txtServiceConveyFromCost.Text != "")
            {
                serviceFilter += " AND ConveyService.Cost >= " + txtServiceConveyFromCost.DecimalValue.ToString();
                title += " بیشتر از:" + txtServiceConveyFromCost.Text;
            }
            if (txtServiceConveyToCost.Text != "")
            {
                serviceFilter += " AND ConveyService.Cost <= " + txtServiceConveyToCost.DecimalValue.ToString();
                title += " کمتر از:" + txtServiceConveyToCost.Text;
            }
            if (cmbServiceDriveTpye.SelectedValue != null)
            {
                serviceFilter += " AND ConveyService.DriveType = " + cmbServiceDriveTpye.SelectedValue.ToString();
                title += "نوع وسیله حمل ونقل: " + cmbServiceDriveTpye.Text;
            }
            /// سرویس تخلیه و بارگیری
            if (txtServiceLoadingFromCost.Text != "" || txtServiceLoadingToCost.Text != "")
            {
                title += "هزینه سرویس تخلیه و بارگیری، ";
            }
            if (txtServiceLoadingFromCost.Text != "")
            {
                serviceFilter += " AND LoadingService.Cost >= " + txtServiceLoadingFromCost.DecimalValue.ToString();
                title += " بیشتر از:" + txtServiceLoadingFromCost.Text;
            }
            if (txtServiceLoadingToCost.Text != "")
            {
                serviceFilter += " AND LoadingService.Cost <= " + txtServiceLoadingToCost.DecimalValue.ToString();
                title += " کمتر از:" + txtServiceLoadingToCost.Text;
            }

            if (txtServiceLoadingFromMinute.Text != "" || txtServiceLoadingToMinute.Text != "")
            {
                title += "زمان سرویس تخلیه و بارگیری (دقیقه)، ";
            }
            if (txtServiceLoadingFromMinute.Text != "")
            {
                serviceFilter += " AND LoadingService.WorkerDuration >= " + txtServiceLoadingFromMinute.DecimalValue.ToString();
                title += " بیشتر از:" + txtServiceLoadingFromMinute.Text;
            }
            if (txtServiceLoadingToMinute.Text != "")
            {
                serviceFilter += " AND LoadingService.WorkerDuration <= " + txtServiceLoadingToMinute.DecimalValue.ToString();
                title += " کمتر از:" + txtServiceLoadingToMinute.Text;
            }

            if (txtServiceLoadingFromWorker.Text != "" || txtServiceLoadingToWorker.Text != "")
            {
                title += "تعداد نیروی تخلیه و بارگیری، ";
            }
            if (txtServiceLoadingFromWorker.Text != "")
            {
                serviceFilter += " AND LoadingService.WorkerCount >= " + txtServiceLoadingFromWorker.DecimalValue.ToString();
                title += " بیشتر از:" + txtServiceLoadingFromWorker.Text;
            }
            if (txtServiceLoadingToWorker.Text != "")
            {
                serviceFilter += " AND LoadingService.WorkerCount <= " + txtServiceLoadingToWorker.DecimalValue.ToString();
                title += " کمتر از:" + txtServiceLoadingToWorker.Text;
            }

            /// سایر خدمات
            if (txtServiceFromCost.Text != "" || txtServiceToCost.Text != "")
            {
                title += "هزینه سایر خدمات، ";
            }
            if (txtServiceFromCost.Text != "")
            {
                serviceFilter += " AND Service.ServiceCost >= " + txtServiceFromCost.DecimalValue.ToString();
                title += " بیشتر از:" + txtServiceFromCost.Text;
            }
            if (txtServiceToCost.Text != "")
            {
                serviceFilter += " AND Service.ServiceCost <= " + txtServiceToCost.DecimalValue.ToString();
                title += " کمتر از:" + txtServiceToCost.Text;
            }

            #endregion Services

            #region PrivateStorage
            if (cmbStorages.SelectedValue != null)
            {
                privateStorageFilter += " AND PrivateStorage.StorageCode = " + cmbStorages.SelectedValue.ToString();
                title += " محل اجاره:" + cmbStorages.Text;
            }
            if (txtPrivateBoxCountFrom.Text != "" || txtPrivateBoxCountTo.Text != "")
            {
                title += "تعداد باکس، ";
            }
            if (txtPrivateBoxCountFrom.Text != "")
            {
                privateStorageFilter += " AND PrivateStorage.BoxCount >= " + txtPrivateBoxCountFrom.DecimalValue.ToString();
                title += " بیشتر از:" + txtPrivateBoxCountFrom.Text;
            }
            if (txtPrivateBoxCountTo.Text != "")
            {
                privateStorageFilter += " AND PrivateStorage.BoxCount <= " + txtPrivateBoxCountTo.DecimalValue.ToString();
                title += " کمتر از:" + txtPrivateBoxCountTo.Text;
            }

            if (txtPrivateStorageCostFrom.Text != "" || txtPrivateStorageCostTo.Text != "")
            {
                title += "هزینه اجاره انبار اختصاصی، ";
            }
            if (txtPrivateStorageCostFrom.Text != "")
            {
                privateStorageFilter += " AND PrivateStorage.Cost >= " + txtPrivateStorageCostFrom.DecimalValue.ToString();
                title += " بیشتر از:" + txtPrivateStorageCostFrom.Text;
            }
            if (txtPrivateStorageCostTo.Text != "")
            {
                privateStorageFilter += " AND PrivateStorage.Cost <= " + txtPrivateStorageCostTo.DecimalValue.ToString();
                title += " کمتر از:" + txtPrivateStorageCostTo.Text;
            }
            #endregion PrivateStorage
            grdContracts.DataSource = JSCReport.SelectContract(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdReceipts.DataSource = JSCReport.SelectReceipt(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdTransfers.DataSource = JSCReport.SelectTransfer(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdConveyService.DataSource = JSCReport.SelectConveyService(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdLoadingService.DataSource = JSCReport.SelectLoadingService(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdServices.DataSource = JSCReport.SelectService(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdPrivateStorage.DataSource = JSCReport.SelectPrivateStorage(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdGoods.DataSource = JSCReport.SelectReceiptGoods(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdRenew.DataSource = JSCReport.SelectRenew(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);
            grdPrivateRenew.DataSource = JSCReport.SelectRenewPrivate(contractFilter, receiptFilter, tranFilter, serviceFilter, privateStorageFilter);

        }
    }
}
