using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Bascol
{
    public partial class JReportManagerForm : JBaseForm
    {
        public int _Code;
        DataTable _dtSearch;
        DataTable _dtTotal;

        public JReportManagerForm()
        {
            InitializeComponent();
        }

        private void FillList()
        {

            DataTable tmpdt = JTruck.GetDataTable(0);
            JKeyValue[] M = new JKeyValue[tmpdt.Rows.Count];
            int count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                M[count] = new JKeyValue();
                M[count].Key = dr["Name"].ToString();
                M[count].Value = dr["Code"];
                count++;
            }
            chklistTrucks.Items.AddRange(M);

            tmpdt = JReport.GetBascols(0);
            JKeyValue[] B = new JKeyValue[tmpdt.Rows.Count];
            count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                B[count] = new JKeyValue();
                B[count].Key = dr["Code"].ToString();
                B[count].Value = dr["Code"];
                count++;
            }
            chkListBascol.Items.AddRange(B);

            tmpdt = JReport.GetUsersBascols(0);
            JKeyValue[] U = new JKeyValue[tmpdt.Rows.Count];
            count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                U[count] = new JKeyValue();
                U[count].Key = dr["Name"].ToString();
                U[count].Value = dr["Code"];
                count++;
            }
            chklistUsers.Items.AddRange(U);
            listUsers.Items.AddRange(U);

            tmpdt = JProductss.GetDataTable();
            JKeyValue[] T = new JKeyValue[tmpdt.Rows.Count];
            count = 0;
            foreach (DataRow dr in tmpdt.Rows)
            {
                T[count] = new JKeyValue();
                T[count].Key = dr["Name"].ToString();
                T[count].Value = dr["Code"];
                count++;
            }
            chklistTozin.Items.AddRange(T);
        }

        private void JReportManagerForm_Load(object sender, EventArgs e)
        {
            txtDate.Date = DateTime.Now;
            txtEndDate.Date = DateTime.Now;
            FillList();
        }

        private string Where()
        {
            string Str = "";

            if (chkListBascol.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chkListBascol.Items.Count; i++)
                    if (chkListBascol.GetItemChecked(i))
                        CodeGH = CodeGH + ((ClassLibrary.JKeyValue)(chkListBascol.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And BascoolCode in (" + CodeGH + "0)";
            }

            if (chklistTozin.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistTozin.Items.Count; i++)
                    if (chklistTozin.GetItemChecked(i))
                        CodeGH = CodeGH + ((ClassLibrary.JKeyValue)(chklistTozin.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And ProductCode in (" + CodeGH + "0)";
            }

            if (chklistTrucks.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistTrucks.Items.Count; i++)
                    if (chklistTrucks.GetItemChecked(i))
                        CodeGH = CodeGH + ((ClassLibrary.JKeyValue)(chklistTrucks.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And TruckCode in (" + CodeGH + "0)";
            }

            //if (chklistUsers.CheckedItems.Count > 0)
            //{
            //    string CodeGH = "";
            //    for (int i = 0; i < chklistUsers.Items.Count; i++)
            //        if (chklistUsers.GetItemChecked(i))
            //            CodeGH = CodeGH + ((ClassLibrary.JKeyValue)(chklistUsers.Items[i])).Value.ToString() + ",";
            //    if (CodeGH != "")
            //        Str = Str + " And PersonCode in (" + CodeGH + "0)";
            //}
            if ((listUsers.SelectedItem != null) && (((ClassLibrary.JKeyValue)(listUsers.SelectedItem)).Value.ToString() != "1"))
                Str = Str + " And PersonCode in (" + ((ClassLibrary.JKeyValue)(listUsers.SelectedItem)).Value.ToString() + ")";

            if (txtDate.Date != DateTime.MinValue)
                Str = Str + " And Cast(WDate as Date) >= '" + txtDate.Date.ToString("yyyy/MM/dd") + "'";

            if (txtEndDate.Date != DateTime.MinValue)
                Str = Str + " And Cast(WDate as Date) <= '" + txtEndDate.Date.ToString("yyyy/MM/dd") + "'";

            if (rbBedehi.Checked)
                Str = Str + " And (pay-pay_h) <> 0 ";
            if (rbReportC.Checked)
            {
            }

            if (chkDelGhabz.Checked)
                Str = Str + " And dele = 1";
            else
                Str = Str + " And dele = 0";
            if (chkNotConfirm.Checked)
                Str = Str + " And verify = 0";

            return Str;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Str = Where();
            _dtSearch = JReport.GetDataManager(Str);
            jJanusGrid1.bind(_dtSearch, "ReportManagerBascolShow");

            _dtTotal = JReport.GetTotalDataManager(Str);
            if (_dtTotal != null)
            {
                lblTotalPay.Text = JMoney.StringToMoney(_dtTotal.Rows[0]["Pay"].ToString());
                lblTotalPay_h.Text = JMoney.StringToMoney(_dtTotal.Rows[0]["Pay_h"].ToString());
                lblTotalTax.Text = JMoney.StringToMoney(_dtTotal.Rows[0]["Tax"].ToString());
                lblTotalDuty.Text = JMoney.StringToMoney(_dtTotal.Rows[0]["Duty"].ToString());
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow == null)
                return;
            _Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"]);
            if (_Code == 0)
            {
                JMessages.Information(" از لیست رکوردی را انتخاب کنید ", "");
                return;
            }
            if (JMessages.Question(" آیا می خواهید حذف شود ؟ ", "") == DialogResult.Yes)
            {
                JWeight tmpWeight = new JWeight(_Code);
                tmpWeight.dele = true;
                if (tmpWeight.Update())
                {
                    JMessages.Information(" ویرایش با موفقیت انجام شد ", "");
                    btnSearch_Click(null, null);
                }
                else
                    JMessages.Error(" ویرایش با خطا مواجه شد ", "");
            }
        }

        private void btnConfirmPay_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow == null)
                return;
            _Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"]);
            if (jJanusGrid1.SelectedRow.Row["verify"] == "1")
            {
                JMessages.Information(" تایید شده است ", "");
                //return;
            }
            if (_Code == 0)
            {
                JMessages.Information(" از لیست رکوردی را انتخاب کنید ", "");
                return;
            }
            if (JMessages.Question(" آیا می خواهید تایید شود ؟ ", "") == DialogResult.Yes)
            {
                JWeight tmpWeight = new JWeight();
                foreach (DataRow dr in jJanusGrid1.DefaultView.Rows)
                {
                    tmpWeight.GetData(Convert.ToInt32(dr["Code"]));
                    tmpWeight.verify = true;
                    if (!(tmpWeight.Update()))
                    {
                        JMessages.Error(" ویرایش با خطا مواجه شد ", "");
                        return;
                    }
                }
                JMessages.Information(" ویرایش با موفقیت انجام شد ", "");
                btnSearch_Click(null, null);
            }
        }

        private void btnback_del_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow == null)
                return;
            _Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"]);
            if (_Code == 0)
            {
                JMessages.Information(" از لیست رکوردی را انتخاب کنید ", "");
                return;
            }
            if (JMessages.Question(" آیا می خواهید عملیات حذف برگشت شود ؟ ", "") == DialogResult.Yes)
            {
                JWeight tmpWeight = new JWeight(_Code);
                tmpWeight.dele = false;
                if (tmpWeight.Update())
                {
                    JMessages.Information(" ویرایش با موفقیت انجام شد ", "");
                    btnSearch_Click(null, null);
                }
                else
                    JMessages.Error(" ویرایش با خطا مواجه شد ", "");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable DtBase = new DataTable();
            DtBase.Columns.Add("StartDate");
            DtBase.Columns.Add("EndDate");
            DtBase.Rows.Add(txtDate.Text, txtEndDate.Text);
            DtBase.TableName = "اطلاعات پایه";

            DataTable _DT = new DataTable();
            _DT.TableName = "اطلاعات";
            _DT = JReport.GetDataMali(Where());
            JDynamicReportForm DRC = new JDynamicReportForm(JReportDesignCodes.Bascool.GetHashCode());
            DRC.Add(_DT);
            DRC.Add(DtBase);
            DRC.ShowDialog();
        }

        private void btnReturnConfirm_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow == null)
                return;
            _Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"]);
            if (_Code == 0)
            {
                JMessages.Information(" از لیست رکوردی را انتخاب کنید ", "");
                return;
            }
            if (JMessages.Question(" آیا می خواهید تایید برگشت شود ؟ ", "") == DialogResult.Yes)
            {
                JWeight tmpWeight = new JWeight();
                foreach (DataRow dr in jJanusGrid1.DefaultView.Rows)
                {
                    tmpWeight.GetData(Convert.ToInt32(dr["Code"]));
                    tmpWeight.verify = false;
                    if (!(tmpWeight.Update()))
                    {
                        JMessages.Error(" ویرایش با خطا مواجه شد ", "");
                        return;
                    }
                }
                JMessages.Information(" ویرایش با موفقیت انجام شد ", "");
                btnSearch_Click(null, null);
            }
        }
    }
}