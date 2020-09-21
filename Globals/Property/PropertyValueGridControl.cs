using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals.Property
{
    public partial class PropertyValueGridControl : UserControl
    {
        #region Properties
        private DataTable _DataTableFormat, _OriginalDataTable, _NewDataTable;
        private int currentColumn = 0, currentRow = 0;
        private string _ClassName;
        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
                RefreshAll();
            }
        }

        private int _ObjectCode;
        public int ObjectCode
        {
            get
            {
                return _ObjectCode;
                RefreshAll();

            }
            set
            {
                _ObjectCode = value;
                RefreshAll();
            }
        }
        private int _ValueObjectCode;
        public int ValueObjectCode
        {
            get
            {
                return _ValueObjectCode;
            }
            set
            {
                _ValueObjectCode = value;
                RefreshAll();
            }
        }
        #endregion

        public PropertyValueGridControl()
        {
            InitializeComponent();
        }

        #region Methods

        public void SwitchToViewMode()
        {
            pnlAction.Hide();
        }

        public void SwitchToEditMode()
        {
            pnlAction.Show();
        }

        public bool Save(JDataBase pdb)
        {
            // Save Boolean Fields In DataGridView
            JDataBase db = new JDataBase();
            try
            {
                JProperty jProperty = new JProperty(_ClassName, _ObjectCode);
                db.beginTransaction("FormManagerGridUpdate");
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].ValueType == typeof(bool))
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            int code = (int)dataGridView1.Rows[j].Cells["Code"].Value;
                            string FieldName = dataGridView1.Columns[i].Name;
                            string FieldValue = Convert.ToBoolean(dataGridView1.Rows[j].Cells[i].Value) == true ? "'True'" : "'False'";
                            if (jProperty.UpdateField(code, FieldName, FieldValue) == false)
                            {
                                db.Rollback("FormManagerGridUpdate");
                                return false;
                            }
                        }
                    }
                }
                /*JProperties jProperties = new JProperties(_ClassName, _ObjectCode);
                foreach (DataRow dr in jProperties.GetBaseDataTable().Rows)
                {
                    if (dr["DataType"].ToString() == Globals.Property.JSQLDataType.رشته.ToString() || dr["DataType"].ToString() == Globals.Property.JSQLDataType.عدد.ToString() || dr["DataType"].ToString() == Globals.Property.JSQLDataType.پول.ToString() || dr["DataType"].ToString() == Globals.Property.JSQLDataType.اعشار.ToString())
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            int code = (int)dataGridView1.Rows[j].Cells["Code"].Value;
                            string FieldName = dr["Name"].ToString().Replace(" ", "__");
                            string FieldValue = dataGridView1.Rows[j].Cells[FieldName].Value.ToString();
                            if (dr["DataType"].ToString() == Globals.Property.JSQLDataType.رشته.ToString()) FieldValue = "N'" + FieldValue + "'";
                            if (jProperty.UpdateField(code, FieldName, FieldValue) == false)
                            {
                                db.Rollback("FormManagerGridUpdate");
                                return false;
                            }
                        }
                    }
                }*/
                db.Commit();
                return true;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void SaveFieldsChanges()
        {
            try
            {
                RefreshAll();
                (new JPropertyHistory()).SaveChanges(_OriginalDataTable, _NewDataTable, _ClassName, _ObjectCode);
            }
            catch (Exception ex) { JSystem.Except.AddException(ex); }
            finally { }
        }

        public void RefreshAll()
        {
            if (_ClassName == null || _ClassName.Length <= 0 || _ObjectCode <= 0)
                return;
            JProperties PT = new JProperties(_ClassName, _ObjectCode);
            _DataTableFormat = PT.GetPropertyTableData(_ValueObjectCode);
            _DataTableFormat.Rows.Clear();
            DataTable DTValue = PT.GetPropertyTableDataForPrint(_ValueObjectCode);
            if (_OriginalDataTable == null)
                _OriginalDataTable = DTValue.Copy();
            _NewDataTable = DTValue.Copy();

            // Prepare Unformatted Values In DataGrid Table
            DataTable DTProp = PT.GetBaseDataTable("ASC");
            JProperty TempProp = new JProperty();
            for (int i = 0; i < DTProp.Rows.Count; i++)
            {
                DataRow _DR = DTProp.Rows[i];
                ClassLibrary.JTable.SetToClassProperty(TempProp, _DR);
                if (TempProp.DataType == JSQLDataType.عدد.ToString())
                {
                    // عدد
                }
                else if (TempProp.DataType == JSQLDataType.تاریخ.ToString())
                {
                    /*string OldCol = TempProp.Name.Replace(" ", "__");
                    string NewCol = TempProp.Name.Replace(" ", "__") + "_";
                    DTValue.Columns.Add(NewCol);
                    for (int j = 0; j < DTValue.Rows.Count; j++)
                    {
                        try
                        {
                            DTValue.Rows[j][NewCol] = JDateTime.FarsiDate(DateTime.Parse(DTValue.Rows[j][OldCol].ToString()));
                        }
                        catch { DTValue.Rows[j][NewCol] = ""; }
                        finally { }
                    }
                    DTValue.Columns.Remove(OldCol);*/
                }
                else if (TempProp.DataType == JSQLDataType.اس_کیو_ال.ToString())
                {
                    string _SQL = TempProp.List;
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();

                    try
                    {
                        DB.setQuery(_SQL);
                        DataTable _DataT = DB.Query_DataTable();
                        for (int j = 0; j < DTValue.Rows.Count; j++)
                        {
                            string columnName = TempProp.Name.Replace(" ", "__");
                            for (int k = 0; k < _DataT.Rows.Count; k++)
                            {

                                if (_DataT.Rows[k][0].ToString() == DTValue.Rows[j][columnName].ToString())
                                {
                                    DTValue.Rows[j][columnName] = _DataT.Rows[k][1];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        DB.Dispose();
                    }

                }
                else
                {
                    // Other conditions
                }

                if (TempProp.ListType == JProppertyListType.لیست_ثابت.ToString() &&
                    TempProp.DataType != JSQLDataType.اس_کیو_ال.ToString())
                {
                    //DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                    //char[] newLine = { (char)13, (char)10 };

                    //string[] StrList = TempProp.List.Split(newLine, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                    }
                }

            }


            dataGridView1.DataSource = DTValue;


        }

        public bool HasRows()
        {
            if (dataGridView1.Rows.Count > 0)
                return true;
            return false;
        }
        #endregion

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Hide First Two Columns (Code, ObjectCode)
            if (dataGridView1.Columns.Count > 1)
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
            }
            // Hide Columns Which User Has Not Permission To View Or Edit
            foreach (DataRow cDataRow in (new JProperties(_ClassName, _ObjectCode)).GetDataTable().Rows)
            {
                if (dataGridView1.Columns.Contains(cDataRow["Name"].ToString().Replace(" ", "__")) == true)
                {
                    string[] ListCan = cDataRow["ListCanView"].ToString().Split(',');
                    if (ListCan.Count() > 0 && ListCan[0] != "" && ListCan.Contains(JMainFrame.CurrentPostCode.ToString()) == false)
                        dataGridView1.Columns[cDataRow["Name"].ToString().Replace(" ", "__")].Visible = false;
                    ListCan = cDataRow["ListCanEdit"].ToString().Split(',');
                    if (ListCan.Count() > 0 && ListCan[0] != "" && ListCan.Contains(JMainFrame.CurrentPostCode.ToString()) == false)
                        dataGridView1.Columns[cDataRow["Name"].ToString().Replace(" ", "__")].ReadOnly = true;
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            (new JPropertyValueForm(_ClassName, _ObjectCode, _ValueObjectCode)).ShowDialog();
            RefreshAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (JMessages.Confirm("آیا از حذف این آیتم مطمئین هستید؟", "حذف") == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    JProperty jProperty = new JProperty();
                    if (jProperty.DeleteDataByValueObjectCode(null, _ClassName, _ObjectCode, _ValueObjectCode, (int)dataGridView1.SelectedRows[0].Cells["Code"].Value))
                        RefreshAll();
                    else
                        JMessages.Error("عملیات با خطا مواجه شد.", "حذف آیتم");
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (btnDelete.Visible == false) return;
            int code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Code"].Value);
            (new JPropertyValueForm(_ClassName, _ObjectCode, _ValueObjectCode, code)).ShowDialog();
            RefreshAll();
        }
    }
}
