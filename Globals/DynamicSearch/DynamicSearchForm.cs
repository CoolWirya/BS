using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;


namespace Globals
{
    public partial class DynamicSearchForm : JBaseForm
    {

        public string[] StringOut=new string[0];
       
            
        DataTable TableFilter;
        private DataTable _DataTable;

        public DynamicSearchForm(DataTable pTable)
        {
            InitializeComponent();
            _DataTable = pTable;
            _FillComboBox(pTable);
            CreatDataTable();
            dgvFilter.DataSource = TableFilter;
            dgvFilter.Columns["Field"].Visible = false;
            dgvFilter.Columns["Operator"].Visible = false;


        }
        private void _FillComboBox(DataTable pTable)
        {
            foreach (DataColumn column in pTable.Columns)
            {
                JField Field = new JField();
                Field.DataType = column.DataType;
                Field.FarsiName = JLanguages._Text(column.ColumnName);
                Field.EnglishName = column.ColumnName;
                cmbListField.Items.Add(Field);
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

        private void AddGride_Click(object sender, EventArgs e)
        {
            DataRow NewRow = TableFilter.NewRow();
            NewRow["Field"] = ((JField)cmbListField.SelectedItem).EnglishName;
            NewRow["FieldName"] = ((JField)cmbListField.SelectedItem).FarsiName;
            NewRow["Operator"] = ((JSqlOperation)cmbOperator.SelectedItem).Operation;
            NewRow["OperatorName"] = ((JSqlOperation)cmbOperator.SelectedItem).Name;
            NewRow["Value"] = cmbValue.Text;
            TableFilter.Rows.Add(NewRow);
            
           
           dgvFilter.Columns["Field"].Visible = false;
           dgvFilter.Columns["Operator"].Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            TableFilter.Rows.RemoveAt(dgvFilter.CurrentRow.Index);          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string temp = "";
            //عنوان گزارش
            string ReportName;
            JReportNameForm ReportNameForm = new JReportNameForm();
            ReportNameForm.ShowDialog();
            ReportName = ReportNameForm.NReprot;
            foreach (DataRow Row in TableFilter.Rows)
            {
                
              
                temp += Row["Field"].ToString() + "####";
                temp += Row["Operator"].ToString() + "####";
                temp += Row["Value"].ToString() + "####";
                temp += Row["FieldName"].ToString() + "####";
                temp += Row["OperatorName"].ToString() + "####";
            }
            
            JDataBase Db = new JDataBase();
            string Qoury =@"DECLARE @Code INT "+
                            
                        JDataBase.GetInsertSQL(JTableNamesGlobal.globalReprot,"1000", true)+

                "insert into " + JTableNamesGlobal.globalReprot + " (Code,ClassName,StringFilter) values (@Code,@ClassName,@StringFilter)";
            try
            {
                Db.setQuery(Qoury);               
                Db.AddParams("ClassName", " myclass");
                Db.AddParams("StringFilter", temp);
                Db.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }

      

        
    }
    
        
}
