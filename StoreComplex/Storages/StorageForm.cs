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
    public partial class JStorageForm : Globals.JBaseForm
    {
        JSCStorage storage;
        public JStorageForm()
        {
            InitializeComponent();
            storage = new JSCStorage();
        }
        int StorageCode;
        public JStorageForm(int storageCode)
        {
            InitializeComponent();
            StorageCode = storageCode;
            if (storageCode > 0)
            {
                storage = new JSCStorage(storageCode);
                ShowData();
            }
            else
            {
                storage = new JSCStorage();
            }
        }

        private void ShowData()
        {
            JSCStorage storage = new JSCStorage(StorageCode);
            txtBoxCount.Text = storage.BoxCount.ToString();
            txtBoxMeter.Text = storage.BoxMeter.ToString();
            txtTitle.Text = storage.Title;
            txtDesc.Text = storage.Description;
            cmbType.SelectedIndex = storage.Type;
            this.State = JFormState.Update;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                ClassLibrary.JMessages.Error("لطفا عنوان را وارد کنید.", "");
                return;
            }
            if (cmbType.SelectedIndex == -1)
            {
                ClassLibrary.JMessages.Error("لطفا نوع انبار را انتخاب کنید.", "");
                return;
            }
            storage.Title = txtTitle.Text;
            storage.Type = cmbType.SelectedIndex;
            storage.Description = txtDesc.Text;
            storage.BoxMeter = txtBoxMeter.IntValue;
            storage.BoxCount = txtBoxCount.IntValue;
            bool error=false;
            if (this.State == JFormState.Insert)
            {
                if (storage.Insert() > 0)
                {
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
                else
                    error = true;
            }
            else if (this.State == JFormState.Update)
            {
                if (storage.Update())
                {
                    btnSave.Enabled = false;
                }
                else
                    error = true;
            }
            if (error)
            {
                JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
