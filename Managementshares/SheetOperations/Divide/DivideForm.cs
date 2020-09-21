using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Finance;

namespace ManagementShares
{
    public partial class JDivideForm : JBaseForm
    {
        int SheetCode;
        public int[] ResultSheets = new int[0];
        public JDivideForm(int pSheetCode)
        {
            InitializeComponent();
            SheetCode = pSheetCode;
            DataTable sheets = JShareSheet.GetSheets(new int[] { pSheetCode });
            grdSheets.DataSource = sheets;
        }
     
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((DataTable)grdSheets.DataSource).Rows.Count > 0)
            {
                DataRow sheetRow = ((DataTable)grdSheets.DataSource).Rows[0];
                int az = Convert.ToInt32(sheetRow["Az"]);
                int ela = Convert.ToInt32(sheetRow["Ela"]);
                int shareCount = ela - az + 1;
                int divideCount = txtDivideCount.IntValue;
                if (divideCount > shareCount)
                {
                    JMessages.Error("تعداد تقسیمات باید کمتر از تعداد سهم باشد", "خطا در ورود اطلاعات");
                    return;
                }
                DataTable divideSheets = new DataTable();
                //divideSheets.Columns.Add("Az");
                //divideSheets.Columns.Add("Ela");
                int eachShare = shareCount/ divideCount;
                int remain = shareCount % divideCount;
                divideSheets.Columns.Add("ShareCount", typeof(int));
                for (int i = 0; i < divideCount; i++)
                {
                    DataRow divideRow = divideSheets.NewRow();
                    divideRow["ShareCount"] = eachShare;
                    divideSheets.Rows.Add(divideRow);
                }
                if (divideSheets.Rows.Count > 0)
                    divideSheets.Rows[divideSheets.Rows.Count - 1]["ShareCount"] = Convert.ToInt32(divideSheets.Rows[divideSheets.Rows.Count - 1]["ShareCount"]) + remain;
                grddividedSheets.DataSource = divideSheets;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDivideCount.IntValue == 0)
            {
                JMessages.Error("لطفا تعداد تقسیمات را وارد کنید", "خطا");
                return;
            }
            int sumShares = Convert.ToInt32(((DataTable)grddividedSheets.DataSource).Compute("SUM(ShareCount)", ""));
            int divideCount = grddividedSheets.Rows.Count;
            if (sumShares != Convert.ToInt32(((DataTable)grdSheets.DataSource).Rows[0]["ShareCount"]))
            {
                JMessages.Error("مجموع سهام تقسیم شده با تعداد سهم برابر نیست", "خطا");
                return;
            }
            int[] sharesCount = new int[divideCount];
            JShareSheet sheet = new JShareSheet(SheetCode);
            for (int i = 0; i < divideCount; i++)
            {
                sharesCount[i] = Convert.ToInt32(grddividedSheets.Rows[i].Cells["ShareCount"].Value);
            }

           


            JDataBase db = new JDataBase();
            JAsset oldAsset = new JAsset("ManagementShares.JShareSheet", sheet.Code, db);
            JAssetTransfer oldTransfer = new JAssetTransfer(oldAsset.Code, JOwnershipType.Definitive, db);
            JAssetShare oldShares = new JAssetShare(oldAsset.Code, oldTransfer.Code, db);
           List<JShareSheet> list = new List<JShareSheet>();
            try
            {
                /// انجام تقسیم
                db.beginTransaction("Divide");
                if (sheet.DivideSheet(sharesCount, DateTime.Now, db, ref  list))
                {
                    foreach (JShareSheet resultSheet in list)
                    {
                        Array.Resize(ref  ResultSheets, ResultSheets.Length + 1);
                        ResultSheets[ResultSheets.Length - 1] = resultSheet.Code;
                    }
                    JMessages.Information("عملیات تقسیم برگه با موفقیت انجام شد.", "");
                    DialogResult = DialogResult.OK;
                }
                else
                    throw new Exception();
            }
            catch
            {
                JMessages.Error("عملیات تقسیم با مشکل مواجه شده است.", "خطا");
            }
            finally
            {
                db.DisConnect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
