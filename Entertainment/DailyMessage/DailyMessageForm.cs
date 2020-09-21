using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Entertainment.DailyMessage
{
    public partial class DailyMessageForm : JBaseForm
    {
        int _Code;
        public DailyMessageForm()
        {
            InitializeComponent();
            this.State = JFormState.Insert;
        }

        private void Set_Form()
        {
            State = JFormState.Update;
            btnDelete.Visible = true;
            JDailyMessage jDailyMessage = new JDailyMessage(Convert.ToInt32(dgrMessages.SelectedRow[0]));
            txtText.Text = jDailyMessage.Text;
            txtDate.Date = jDailyMessage.Date;
            _Code = jDailyMessage.Code;
        }

        private void Set_New()
        {
            State = JFormState.Insert;
            btnDelete.Visible = false;
            txtText.Text = "";
        }

        private void RefereshList()
        {
            JDailyMessage jDailyMessage = new JDailyMessage();
            //dgrMessages.DataSource = jDailyMessage.GetList(txtDate.Date);
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            RefereshList();
        }

        private void DailyMessageForm_Load(object sender, EventArgs e)
        {
            dgrMessages.gridEX1.SelectionChanged += new EventHandler(gridEX1_SelectionChanged);

            txtDate.Date = DateTime.Now;
            RefereshList();
        }

        void gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            Set_Form();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (this.State == JFormState.Insert)
            {
                JDailyMessage jDailyMessage = new JDailyMessage();
                jDailyMessage.Date = txtDate.Date;
                jDailyMessage.Text = txtText.Text;
                if (jDailyMessage.Insert() > 0)
                    JMessages.Information("با موفقیت درج شد.", "درج");
                else
                    JMessages.Error("درج با خطا مواجه شد.", "درج");
            }
            else if (this.State == JFormState.Update)
            {
                JDailyMessage jDailyMessage = new JDailyMessage();
                jDailyMessage.Date = txtDate.Date;
                jDailyMessage.Text = txtText.Text;
                jDailyMessage.Code = _Code;
                if (jDailyMessage.Update() == true)
                {
                    JMessages.Information("با موفقیت به ویرایش شد.", "ویرایش");
                }
                else
                    JMessages.Error("ویرایش با خطا مواجه شد.", "ویرایش");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Set_New();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            JDailyMessage jDailyMessage = new JDailyMessage();
            jDailyMessage.Date = txtDate.Date;
            jDailyMessage.Text = txtText.Text;
            jDailyMessage.Code = _Code;
            if (jDailyMessage.Delete() == true)
            {
                JMessages.Information("با موفقیت حذف شد.", "حذف");
            }
            else
                JMessages.Error("حذف با خطا مواجه شد.", "حذف");
            
        }
    }
}
