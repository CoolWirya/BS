using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Microsoft.Win32;

namespace Globals
{
    public partial class JDQuickSearch : JBaseForm
    {
        public string[] StringOut=new string[0];
       
            
        DataTable TableFilter;
        private DataTable _DataTable;

        public JDQuickSearch(DataTable pTable)
        {
            InitializeComponent();
            _DataTable = pTable;
            _FillComboBox(pTable);
            CreatDataTable();
        }
        string uniqString = "";
        private void _FillComboBox(DataTable pTable)
        {
            uniqString = "";
            foreach (DataColumn column in pTable.Columns)
            {
                JField Field = new JField();
                Field.DataType = column.DataType;
                Field.FarsiName = JLanguages._Text(column.ColumnName);
                Field.EnglishName = column.ColumnName;
                cmbListField.Items.Add(Field);
                //if (uniqString.Length < 200)
                uniqString = uniqString + column.ColumnName;
            }
            JSqlOperations SqlOperations = new JSqlOperations();
            foreach (JSqlOperation Opration in SqlOperations.Opertions)
            {
                cmbOperator.Items.Add(Opration);
            }

        }
        private void CreatDataTable()
        {
            TableFilter = new DataTable();
            TableFilter.Columns.Add("Field");
            TableFilter.Columns.Add("FieldName");
            TableFilter.Columns.Add("Operator");
            TableFilter.Columns.Add("OperatorName");
            TableFilter.Columns.Add("Value");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "")
            {
                _DataTable.DefaultView.RowFilter = "";
                Close();
                return;
            }
            if (cmbListField.SelectedItem == null)
            {
                cmbListField.Focus();
                return;
            }
            if (cmbOperator.SelectedItem == null)
            {
                cmbOperator.Focus();
                return;
            }

            DataRow NewRow = TableFilter.NewRow();
            NewRow["Field"] = ((JField)cmbListField.SelectedItem).EnglishName;
            NewRow["FieldName"] = ((JField)cmbListField.SelectedItem).FarsiName;
            NewRow["Operator"] = ((JSqlOperation)cmbOperator.SelectedItem).Operation;
            NewRow["OperatorName"] = ((JSqlOperation)cmbOperator.SelectedItem).Name;
            NewRow["Value"] = txtValue.Text;
            TableFilter.Rows.Clear();
            TableFilter.Rows.Add(NewRow);

            #region SaveRegistry
            //if (JSystem.Nodes.Items.Count() > 0)
            {
                JRegistry.Write(uniqString + ".SearchFieldName", cmbListField.Text);
                JRegistry.Write(uniqString + ".SearchFieldOperator", cmbOperator.Text);
            }
            #endregion

            int i=0;
            Array.Resize(ref StringOut, TableFilter.Rows.Count);
            foreach (DataRow Row in TableFilter.Rows)
            {
                string Filter = "";
                Filter = Row["Field"].ToString();
                Filter +=  Row["Operator"].ToString();
                if (Row["Operator"].ToString() == " like " || Row["Operator"].ToString() == " Not Like ")
                {
                    Filter += "'%" + (Row["Value"].ToString()) + "%'";
                }
                else
                {
                    Filter += "'" + (Row["Value"].ToString()) + "'";
                }
              
                StringOut[i++] = Filter;
            }
            try
            {
                _DataTable.DefaultView.RowFilter = String.Join(" AND ", StringOut);
                Close();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JDQuickSearch_Shown(object sender, EventArgs e)
        {
            /// خواندن نام فیلد و عملوند جستجو از رجیستری
            //if (JSystem.Nodes.Items.Count() > 0)
            {
                object FieldName = JRegistry.Read(uniqString + ".SearchFieldName");
                object Operator = JRegistry.Read(uniqString + ".SearchFieldOperator");
                if (FieldName != null)
                {
                    cmbListField.Text = FieldName.ToString();
                    cmbOperator.Focus();
                }
                if (Operator != null)
                {
                    cmbOperator.Text = Operator.ToString();
                    txtValue.Focus();
                }
            }
        }
      
    }
}
