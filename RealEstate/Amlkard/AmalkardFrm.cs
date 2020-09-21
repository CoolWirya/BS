using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Security;

namespace RealEstate
{
    public partial class AmalkardFrm : JBaseForm
    {
        private Security.JWrittencommitment Wr;
        private Security.JSecService Ser;
        
        int _BuildCode;
        int _marketcode;

        // None=0,
        // /// <summary>
        // /// جاری
        // /// </summary>
        //Current = 1,
        ///// <summary>
        ///// اتمام
        ///// </summary>
        //Expired = 2,
        ///// <summary>
        ///// فسخ شده
        ///// </summary>
        //Canceled = 3,
        ///// <summary>
        ///// غیر فعال
        ///// </summary>
        //Disabled=4,

        public AmalkardFrm(int Code, int Market)
        {
            InitializeComponent();
            Wr = new Security.JWrittencommitment();
            Ser = new JSecService();
            _BuildCode = Code;
            _marketcode = Market;
            JUnitBuild Build = new JUnitBuild();
            Build.GetData(Code);
            this.Text = " فرم عملكرد واحد : " + Build.Number.ToString();
        }

        private void Bind(int Status)
        {
            grdTahod.bind(Security.JWrittencommitments.GetTableAssetwr(_BuildCode, _marketcode, Status));
            grdwarning.bind(JWrittencommitments.GetTableAssetwa(_BuildCode, _marketcode, Status));
            grdSer.bind(JSecServices.GetTableAss(_BuildCode, _marketcode, Status));
        }

        private void AmalkardFrm_Load(object sender, EventArgs e)
        {
            Bind(1);
        }

        private void grdKhadmat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdwarning_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                DataRow _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
                int Pcode = (Convert.ToInt32(_DR["Code"]));
                JWrittencommitment Wr = new JWrittencommitment();
                Wr.GetData(Pcode);
                Wr.ShowFormWarning(Pcode, _marketcode);
            }
            catch
            {
            }
        }

        private void grdTahod_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                DataRow _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
                int Pcode = (Convert.ToInt32(_DR["Code"]));
                JWrittencommitment Wr = new JWrittencommitment();
                Wr.GetData(Pcode);
                Wr.ShowFormWritble(Pcode, _marketcode);

            }
            catch
            {
            }
        }

        private void BtnNewWarning_Click(object sender, EventArgs e)
        {
            try
            {
                JWrittencommitment Wr = new JWrittencommitment();
                Wr.ShowFormWarning(0, _marketcode);
                if (checkBox1.Checked == true)
                {
                    Bind(2);
                }
                else
                {
                    Bind(1);
                }
            }
            catch
            {
            }
        }

        private void BtnNewWritable_Click(object sender, EventArgs e)
        {
            try
            {
                JWrittencommitment Wr = new JWrittencommitment();
                Wr.ShowFormWritble(0, _marketcode);
                if (checkBox1.Checked == true)
                {
                    Bind(2);
                }
                else
                {
                    Bind(1);
                }

            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Bind(0);
            }
            else
            {
                Bind(1);
            }
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            Security.JSecService Ser = new JSecService();
            Ser.ShowForm(0);
        }

    }
}
