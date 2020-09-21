using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finance.FinanceDocuments.Cheques
{
    public partial class JSelectAccForm : ClassLibrary.JBaseForm
    {
        int _Year;
        int _ClassCode;
        public int ReturnValue;
        public JSelectAccForm(int pYear,int pClassCode)
        {
            InitializeComponent();

            _Year = pYear;
            _ClassCode = pClassCode;

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select DtlCode,DtlDesc from dbo.acc_dtlInclass(" + _Year + "," + _ClassCode + ") order by dtlDesc");
                DataTable DT = DB.Query_DataTable();

                lbList.DataSource = DT;
                lbList.DisplayMember = "DtlDesc";
                lbList.ValueMember = "dtlCode";
            }
            finally
            {
                DB.Dispose();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnValue  = (int)lbList.SelectedValue;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lbList.Items.AddRange((lbList.DataSource as DataTable).AsEnumerable().ToList().Where(i => string.IsNullOrEmpty(txtSearch.Text) || i.ItemArray[0].ToString().StartsWith(txtSearch.Text))
                        .Select(c => c.Table).ToArray());
        }
    }
}
