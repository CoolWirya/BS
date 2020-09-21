using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class JSearchJoint : ClassLibrary.JBaseForm
    {
        private JDataBase DB;

        public JSearchJoint()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// جستجوی  محيط
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public DataTable GetSpace(int _Code, string _Name,string _sType,string _eType,string _Complex,string _Address,string _Status )
        {
            JDataBase db = new JDataBase();
            string strSQL = "SELECT * FROM VReEnviromentTable" + " WHERE 1=1 ";
            if (_Code != 0) strSQL += " AND Code = " + _Code;
            if (_Name != null && _Name != "") strSQL += " AND NameEnviroment  like '%" + _Name + "%'";
            if (_sType != null && _sType != "") strSQL += " AND Type  like '%" + _sType + "%'";
            if (_eType != null && _eType != "") strSQL += " AND TypeEnviroment  like '%" + _eType + "%'";
            if (_Complex != null && _Complex != "") strSQL += " AND Complex  like '%" + _Complex + "%'";
            if (_Address != null && _Address != "") strSQL += " AND Address  like '%" + _Address + "%'";
            if (_Status != null && _Status != "") strSQL += " AND state  like '%" + _Status + "%'";

            try
            {
                db.setQuery(strSQL);
                db.Query_DataSet();
                return db.DataSet.Tables[0];
            }
            finally
            {
                db.Dispose();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            JJointSpaceForm.sCode = (Int32)(jDataGrid1["Code", jDataGrid1.CurrentRow.Index].Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numSpace_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void TxtSpaceType_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void JSearchJoint_Load(object sender, EventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void txtTypeSpace_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void txtState_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void txtNameEnviroment_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void txtTypeEnviroment_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void txtAdress_KeyUp(object sender, KeyEventArgs e)
        {
            jDataGrid1.DataSource = GetSpace(txtCodeEnviroment.IntValue, txtNameEnviroment.Text, txtTypeSpace.Text, txtTypeEnviroment.Text, txtComplex.Text, txtAdress.Text, txtState.Text);
        }

        private void jDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            JJointSpaceForm.sCode = (Int32)(jDataGrid1["Code", jDataGrid1.CurrentRow.Index].Value);
            this.Close();   
        }

       

    }
}
