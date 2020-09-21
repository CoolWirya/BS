using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication
{
	public partial class NoStorageForm : ClassLibrary.JBaseForm
	{

		public String ClassName;
		public int ObjectCode;
		public int SecretariatCode;
		public int NoStorageNumber;
		public NoStorageForm(string pClassName, int pObjectCode , bool CanGetNumber = true)
		{
			InitializeComponent();
			ClassName = pClassName;
			ObjectCode = pObjectCode;
            if (!CanGetNumber)
                btnGetNumber.Enabled = false;
            lbFormName.Text = ClassLibrary.JLanguages._Text(pClassName);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(ClassName,ObjectCode,Year);
			lbLastNumber.Text = "آخرین شماره (" + NS.GetNextNumberWithoutUpdate().ToString() +")"; 
			lbReserverTo.Text = "از شماره("+ NS.GetNextNumberWithoutUpdate().ToString()+")رزرو تا شماره("+txtReservNumber.Text+"):";
		}

		private void lbReservList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbReservList.SelectedItem != null)
				txtNumber.Text = lbReservList.SelectedValue.ToString();
		}

		private void btnGetNumber_Click(object sender, EventArgs e)
		{
			int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(ClassName, ObjectCode, Year);
			if (txtNumber.Text.Length == 0)
			{
				txtNumber.Text = NS.GetNextNumber().ToString();
			}
			this.NoStorageNumber = int.Parse(txtNumber.Text);
			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			NSR.Delete(this.NoStorageNumber);

			this.Close();
		}

		private void btnReservNumber_Click(object sender, EventArgs e)
		{
			int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(ClassName,ObjectCode,Year);

			if (NS.GetNextNumberWithoutUpdate() > int.Parse(txtReservNumber.Text))
			{
				return;
			}
			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			NSR.ReserveTo(int.Parse(txtReservNumber.Text));
			NoStorageForm_Load(sender, e);
		}

		private void btnDeleteReservNumber_Click(object sender, EventArgs e)
		{
			if (lbReservEditList.SelectedValue != null)
			{
				lbReservEditList.Items.Remove(lbReservEditList.SelectedValue);
				int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
				NoStorage NS = new NoStorage(ClassName, ObjectCode, Year);

				JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
				NSR.Delete((int)lbReservEditList.SelectedValue);
			}
		}

		private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void txtNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				txtNumber.Clear();
			}

		}

		private void NoStorageForm_Load(object sender, EventArgs e)
		{
			int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(ClassName, ObjectCode, Year);

			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			lbReservEditList.DisplayMember = "Number";
			lbReservEditList.ValueMember = "Number";
			lbReservEditList.DataSource = NSR.GetData();

			lbReservList.DisplayMember = "Number";
			lbReservList.ValueMember = "Number";
			lbReservList.DataSource = NSR.GetData();

		}
	}
}
