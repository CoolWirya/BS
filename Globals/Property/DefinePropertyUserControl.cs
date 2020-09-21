using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals.Property
{
    public partial class JDefinePropertyUserControl : UserControl
    {
        #region Propperties

        private System.Data.DataTable _datatable;
        private string _ClassName;
        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                if (_ClassName != value)
                {
                    _ClassName = value;
                    if (_ObjectCode > 0)
                        refreshDataTable();
                }
            }
        }
        public int PropertyCount
        {
            get { return dataGridView.RowCount; }
        }
        private int _ObjectCode;
        public int ObjectCode
        {
            get
            {
                return _ObjectCode;
            }
            set
            {
                _ObjectCode = value;
                if (_ClassName!=null && _ClassName.Length > 0)
                    refreshDataTable();
            }
        }
        #endregion

        /// <summary>
        /// رویداد پس از افزودن ویژگی
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void PropertyAdded(object Sender, EventArgs e);
        public event PropertyAdded AfterPropertyAdded;

        /// <summary>
        /// رویداد پس از حذف ویژگی
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void PropertyDeleted(object Sender, EventArgs e);
        public event PropertyDeleted AfterPropertyDeleted;

        /// <summary>
        /// رویداد قبل از حذف ویژگی
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void PropertyDelete(object Sender, EventArgs e);
        public event PropertyDelete BeforPropertyDeleted;

        
        public JDefinePropertyUserControl()
        {
            InitializeComponent();
        }

        #region function
        public void refreshDataTable()
        {
            if (this.DesignMode)
                return;
            if (_datatable != null)
                _datatable.Dispose();
            JProperties PropTB = new JProperties(_ClassName, ObjectCode);
            _datatable = PropTB.GetDataTable();
            dataGridView.DataSource = _datatable;
            dataGridView.Columns["ClassName"].Visible = false;
            dataGridView.Columns["Code"].Visible = false;
            dataGridView.Columns["DefaultValue"].Visible = false;
            dataGridView.Columns["ObjectCode"].Visible = false;
            dataGridView.Columns["List"].HeaderText = "ValueList";

        }
        #endregion

        private void AddtoolStripButton_Click(object sender, EventArgs e)
        {
            JPropertyForm PF = new JPropertyForm(_ClassName,ObjectCode,0);
            PF.State = ClassLibrary.JFormState.Insert;
            if (PF.ShowDialog() == DialogResult.OK)
            {
                if (_datatable == null)
                    return;
                DataRow DR = _datatable.NewRow();

                DR["Name"] = PF.Property.Name.Replace("__", " ");
                DR["Active"] = PF.Property.Active;
                DR["ClassName"] = PF.Property.ClassName;
                DR["Code"] = PF.Property.Code;
                DR["DataType"] = PF.Property.DataType;
                DR["DefaultValue"] = PF.Property.DefaultValue;
                DR["List"] = PF.Property.List;
                DR["ListType"] = PF.Property.ListType;
                DR["Ordered"] = PF.Property.Ordered;
                DR["ObjectCode"] = PF.Property.ObjectCode;
                DR["ListCanView"] = PF.Property.ListCanView;
                DR["ListCanEdit"] = PF.Property.ListCanEdit;

                _datatable.Rows.Add(DR);

                if (AfterPropertyAdded != null)
                    AfterPropertyAdded(sender, e);
            }
        }

        private void DeletetoolStripButton_Click(object sender, EventArgs e)
        {
            if (BeforPropertyDeleted != null)
                BeforPropertyDeleted(sender, e);

            dataGridView.Rows.Remove(dataGridView.CurrentRow);

            if (AfterPropertyDeleted != null)
                AfterPropertyDeleted(sender, e);

        }

        private void dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                DataGridViewRow DR = dataGridView.CurrentRow;

                JProperty P = new JProperty(ClassName,ObjectCode);
                P.SetDataRow(DR);

                JPropertyForm PF = new JPropertyForm(P);
                PF.State = ClassLibrary.JFormState.Update;

                if (PF.ShowDialog() == DialogResult.OK)
                {
                    DR.Cells["Name"].Value = PF.Property.Name.Replace("__", " ");
                    DR.Cells["Active"].Value = PF.Property.Active;
                    DR.Cells["ClassName"].Value = PF.Property.ClassName;
                    DR.Cells["Code"].Value = PF.Property.Code;
                    DR.Cells["DataType"].Value = PF.Property.DataType;
                    DR.Cells["DefaultValue"].Value = PF.Property.DefaultValue;
                    DR.Cells["List"].Value = PF.Property.List;
                    DR.Cells["ListType"].Value = PF.Property.ListType;
                    DR.Cells["Ordered"].Value = PF.Property.Ordered;
                    DR.Cells["ListCanView"].Value = PF.Property.ListCanView;
                    DR.Cells["ListCanEdit"].Value = PF.Property.ListCanEdit;
                }
            }

        }
        public bool AcceptChanges()
        {
            JProperty Pr = new JProperty(ClassName, ObjectCode);
            if (_datatable == null)
                return false;
            foreach (DataRow DR in _datatable.Rows)
            {
                try
                {
                    if (DR.RowState == DataRowState.Added)
                    {
                        Pr.SetDataRow(DR);
                        Pr.Insert();
                        DR["Code"] = Pr.Code;
                    }
                    else
                        if (DR.RowState == DataRowState.Deleted)
                        {
                            DR.RejectChanges();
                            Pr.SetDataRow(DR);
                            Pr.Delete();
                            DR.Delete();
                        }
                        else
                            if (DR.RowState == DataRowState.Modified)
                            {
                                Pr.SetDataRow(DR);
                                Pr.Update();
                            }
                }
                catch(Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                    return false;
                }
            }
            _datatable.AcceptChanges();
            return true;
        }
    }
}
