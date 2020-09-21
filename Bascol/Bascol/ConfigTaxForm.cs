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
    public partial class JConfigTaxForm : JBaseForm
    {
        public JConfigTaxForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (JPermission.CheckPermission("Bascol.ConfigTaxForm.btnSave_Click"))
            {
                //string Query = @" Update BascolTaxFormula set Tax=" + txtTax.Text + " , Duty=" + txtDuty.Text;
                //JDataBase db = new JDataBase();
                //try
                //{
                //    db.setQuery(Query);
                //    db.Query_Execute();
                //}
                //catch (Exception ex)
                //{
                //    JSystem.Except.AddException(ex);
                //}
                //finally
                //{
                //    db.Dispose();
                //}
            }
        }

        private void ConfigTaxForm_Load(object sender, EventArgs e)
        {
            string Query = @" Select * From BascolTaxFormula ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                txtTax.Text = dt.Rows[0]["Tax"].ToString();
                txtDuty.Text = dt.Rows[0]["Duty"].ToString();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
