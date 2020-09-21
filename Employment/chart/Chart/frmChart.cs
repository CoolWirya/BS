using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JfrmChart : JBaseForm
    {
        private JEChart _JChart;
        public JfrmChart(JEChart jclass)
        {
            InitializeComponent();
          
            if (jclass != null)
            {
                _JChart = jclass;
                txtChartTitle.Text = _JChart.Title;
                rdoActive.Checked = _JChart.is_active;
                rdoDisactive.Checked = (!_JChart.is_active);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {                
                if (txtChartTitle.Text.Trim() == "")
                {
                    //JMessages.Message("لطفا عنوان چارت را وارد کنید", "خطا", JMessageType.Error);
                    string msg = JLanguages._Text("Please Enter Title OF Chart");
                    JMessages.Message(msg, "", JMessageType.Error);
                    txtChartTitle.Focus();
                    return;
                }

                int ActiveChart = (new JECharts()).GetActiveChartCode();

                if (State == JFormState.Insert)
                {
                    if (rdoActive.Checked && ActiveChart != 0)
                    {
                        // چارت فعال وجود دارد و نمی توانید این چارت را بعنوان چارت فعال معرفی کنید؟
                        string msg = JLanguages._Text("Active Chart Exist?");
                        JMessages.Message(msg, "", JMessageType.Error);
                        return;
                    }
                    JEChart tmpJChart = new JEChart();
                    //tmpJChart.Nodes = _JChart.Nodes;
                    tmpJChart.Title = txtChartTitle.Text;
                    if (rdoActive.Checked)
                    {
                        tmpJChart.is_active = true;
                    }
                    else
                    {
                        tmpJChart.is_active = false;
                    }
                    tmpJChart.Insert();

                    DialogResult = DialogResult.OK;
                    this.Close();
                    this.Dispose();
                }
                else if (State == JFormState.Update)
                {
                    if (rdoActive.Checked && ActiveChart != 0 && ActiveChart != _JChart.Code)
                    {
                        // چارت فعال وجود دارد و نمی توانید این چارت را بعنوان چارت فعال معرفی کنید؟
                        string msg = JLanguages._Text("Active Chart Exist?");
                        JMessages.Message(msg, "", JMessageType.Error);
                        return;
                    }

                    _JChart.Title = txtChartTitle.Text.Trim();
                    if (rdoActive.Checked)
                    {
                        _JChart.is_active = true;
                    }
                    else
                    {
                        _JChart.is_active = false;
                    }
                    _JChart.Update();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JfrmChart_Load(object sender, EventArgs e)
        {
            if (State == ClassLibrary.JFormState.Insert)
            {
                btnAction.Text = JLanguages._Text("Insert");
            }
            else
            {
                btnAction.Text = JLanguages._Text("Update");
            }
        }
    }
}
