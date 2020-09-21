using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ClassLibrary;

namespace Globals.Property
{
    public partial class JPropertyValueUserControl : UserControl
    {
        #region Property
        private DataTable _OriginalDataTable, _NewDataTable;
        private int CountFields = 0;
        private string _ClassName;
        private int _State;
        public bool isMultiple;
        public int TableCode;
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
                    string OldClassName = _ClassName;
                    _ClassName = value;
                    if (OldClassName != ClassName && ObjectCode > -1)
                    {
                        RefreshFields();
                        pRefresh();
                    }
                }
            }
        }
        private int _ObjectCode = -1;
        public int ObjectCode
        {
            get
            {
                return _ObjectCode;
            }
            set
            {
                int OldObjectCode = _ObjectCode;
                _ObjectCode = value;
                if (OldObjectCode != _ObjectCode && ClassName != null)
                {
                    RefreshFields();
                    pRefresh();
                }
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
                int OldValueObjectCode = _ValueObjectCode;
                _ValueObjectCode = value;
                if (OldValueObjectCode != _ValueObjectCode && OldValueObjectCode == 0 && _State == 0)
                    pRefresh();
            }
        }

		public int RegisterPostCode;

        private DataTable _DT;

        private int _Code = 0;
        #endregion

        public JPropertyValueUserControl()
        {
            InitializeComponent();
        }

        public void SaveFieldsChanges()
        {
            try
            {
                GetVAlues(_ValueObjectCode);
                if (_DT != null) _NewDataTable = _DT.Copy();
                (new JPropertyHistory()).SaveChanges(_OriginalDataTable, _NewDataTable, _ClassName, _ObjectCode);
            }
            catch (Exception ex) { JSystem.Except.AddException(ex); }
            finally { }
        }

        /// <summary>
        /// رویداد پس از تغییر ویژگی
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void PropertyChanged(object Sender, EventArgs e);
        public event PropertyChanged AfterPropertyChanged;

		protected virtual void OnChanged(EventArgs e)
		{
			if (AfterPropertyChanged != null)
				AfterPropertyChanged(this, e);
		}

        //if (AfterPropertyChanged != null)
        //  AfterPropertyChanged(sender, e);

        public void NewRecord()
        {
            _Code = 0;
        }

        public void GetVAlues(int pValueObjectCode)
        {
            if (_DT != null)
                _DT.Dispose();
            JPropertyTables PTs = new JPropertyTables(ClassName, ObjectCode);
            if (isMultiple)
                _DT = PTs.GetData(pValueObjectCode, TableCode);
            else
                _DT = PTs.GetData(pValueObjectCode);
        }

        public void pRefresh()
        {
            if (isMultiple == true && TableCode == 0) return;
            if (CountFields > 0 && _ValueObjectCode > 0 && (_ClassName != null && _ClassName.Length > 0 ))
            {
                GetVAlues(_ValueObjectCode);
                RefreshValue();
                if (_OriginalDataTable == null && _DT != null) _OriginalDataTable = _DT.Copy();
            }
        }
        public void ClearValues()
        {
            GetVAlues(-1);
            Type type = this.GetType();
            foreach (DataColumn DC in _DT.Columns)
            {
                try
                {
                    Control Contr = FindControlRecursive(splitContainer1.Panel2, "Prop_" + DC.ColumnName);
                    if (Contr != null)
                    {
                        //object Obj = Finfo[count].GetValue(this);
                        if (Contr is ClassLibrary.DateEdit)
                        {
                            ((ClassLibrary.DateEdit)Contr).Text = "";
                        }
                        if (Contr is ClassLibrary.TimeEdit)
                        {
                            ((ClassLibrary.TimeEdit)Contr).Text = "";
                        }
                        if (Contr is ClassLibrary.TextEdit)
                        {
                            ((ClassLibrary.TextEdit)Contr).Text = "";
                        }
                        if (Contr is CheckBox)
                        {
                            ((CheckBox)Contr).Checked = false;
                        }
                        //if (Contr is JUIComboBox)
                        //{
                        //    ((JUIComboBox)Contr).Text = "";
                        //}
                    }
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }

        }

        #region FindControlRecursive
        /// <summary>
        /// Finds a Control recursively. Note finds the first match and exists
        /// </summary>
        /// <param name="container">The container to search for the control passed. Remember
        /// all controls (Panel, GroupBox, Form, etc are all containsers for controls
        /// </param>
        /// <param name="name">Name of the control to look for</param>
        /// <returns></returns>
        /// 
        public Control FindControlRecursive(Control container, string name)
        {
            if (container.Name == name)
                return container;

            foreach (Control ctrl in container.Controls)
            {
                Control foundCtrl = FindControlRecursive(ctrl, name);
                if (foundCtrl != null)
                    return foundCtrl;
            }
            return null;
        }

        public void ClearControlRecursive(Control container)
        {
            if (container.Controls.Count == 0)
                return;
            while (container.Controls.Count > 0)
            {
                ClearControlRecursive(container.Controls[0]);
                container.Controls[0].Dispose();
            }

            return;
        }

        #endregion


        public void RefreshValue()
        {
            _Code = 0;
            if (_DT != null && _DT.Rows.Count > 0)
            {
                _Code = (int)_DT.Rows[0]["Code"];
                System.Data.DataRow _DR = _DT.Rows[0];
                Type type = this.GetType();
                foreach (DataColumn DC in _DT.Columns)
                {
                    try
                    {
                        Control Contr = FindControlRecursive(splitContainer1.Panel2, "Prop_" + DC.ColumnName);
                        if (Contr != null)
                        {
                            if (Contr is ClassLibrary.DateEdit)
                            {
                                ((ClassLibrary.DateEdit)Contr).Text = _DR[((ClassLibrary.DateEdit)Contr).Name.Replace("Prop_", "")].ToString();
                            }
                            if (Contr is ClassLibrary.TimeEdit)
                            {
                                ((ClassLibrary.TimeEdit)Contr).Text = _DR[((ClassLibrary.TimeEdit)Contr).Name.Replace("Prop_", "")].ToString();
                            }
                            if (Contr is ClassLibrary.TextEdit)
                            {
                                ((ClassLibrary.TextEdit)Contr).Text = _DR[((ClassLibrary.TextEdit)Contr).Name.Replace("Prop_", "")].ToString();

                            }
                            if (Contr is CheckBox)
                            {
                                if (_DR[((CheckBox)Contr).Name.Replace("Prop_", "")].ToString() == "خیر")
                                    ((CheckBox)Contr).Checked = false;
                                else
                                if (_DR[((CheckBox)Contr).Name.Replace("Prop_", "")].ToString() == "بلی")
                                    ((CheckBox)Contr).Checked = true;
                                else
                                    ((CheckBox)Contr).Checked = (bool)_DR[((CheckBox)Contr).Name.Replace("Prop_", "")];
                            }
                            if (Contr is JUIComboBox)
                            {
                                if (((JUIComboBox)Contr).DataSource != null)
                                {
									
                                    int Value = 0;
									int.TryParse(_DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")].ToString(), out Value);
                                    JUIComboBox tempcmb = (Contr as JUIComboBox);

                                    tempcmb.SelectedValue = Value;
                                }
                                else
                                {
                                    ((JUIComboBox)Contr).Text = _DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
                    }
                }
            }

        }

        public DataRow GetDataRowValue()
        {
            return GetDataRowValue(null);
        }

        public DataRow GetDataRowValue(DataRow pDR)
        {
            if (_DT == null)
            {
                JPropertyTables PTs = new JPropertyTables(ClassName, ObjectCode);
                _DT = PTs.GetData(0);
                if (_DT == null)
                {
                    return null;
                }
            }
            System.Data.DataRow _DR;
            if (pDR == null)
                _DR = _DT.NewRow();
            else
                _DR = pDR;

            foreach (DataColumn DC in _DT.Columns)
            {
                try
                {
                    Control Contr = FindControlRecursive(splitContainer1.Panel2, "Prop_" + DC.ColumnName);
                    if (Contr != null)
                    {
                        if (Contr is ClassLibrary.DateEdit)
                        {
							if (((ClassLibrary.DateEdit)Contr).Date.Year == 1)
								_DR[((ClassLibrary.DateEdit)Contr).Name.Replace("Prop_", "")] = DBNull.Value;
							else
								_DR[((ClassLibrary.DateEdit)Contr).Name.Replace("Prop_", "")] = ((ClassLibrary.DateEdit)Contr).Date.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        if (Contr is ClassLibrary.TimeEdit)
                        {
                            _DR[((ClassLibrary.TimeEdit)Contr).Name.Replace("Prop_", "")] = ((ClassLibrary.TimeEdit)Contr).Text;
                        }
                        if (Contr is ClassLibrary.TextEdit)
                        {
                            if (
                                //((ClassLibrary.TextEdit)Contr).TextMode == TextModes.Integer
                                //||
                                //((ClassLibrary.TextEdit)Contr).TextMode == TextModes.Long
                                //||
                                ((ClassLibrary.TextEdit)Contr).TextMode == TextModes.Money
                                ||
                                ((ClassLibrary.TextEdit)Contr).TextMode == TextModes.Real
                                )
                                _DR[((ClassLibrary.TextEdit)Contr).Name.Replace("Prop_", "")] = ((ClassLibrary.TextEdit)Contr).DecimalValue;
                            else
                                _DR[((ClassLibrary.TextEdit)Contr).Name.Replace("Prop_", "")] = ((ClassLibrary.TextEdit)Contr).Text;
                        }
                        if (Contr is CheckBox)
                        {
                            _DR[((CheckBox)Contr).Name.Replace("Prop_", "")] = ((CheckBox)Contr).Checked;
                        }
                        if (Contr is JUIComboBox)
                        {
                            //if (((JUIComboBox)Contr).DataSource != null) 
                            //{
                            if (((JUIComboBox)Contr).Items[((JUIComboBox)Contr).SelectedValue] != null)
                            {
								if (((JUIComboBox)Contr).SelectedValue != null)
									_DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = ((JUIComboBox)Contr).SelectedValue.ToString();
								else
									_DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = "";
							}
                            else
                            {
                                //JMessages.Error("در انتخاب آیتم-----  "+
                                //    ((JUIComboBox)Contr).Name.Replace("Prop_", "") +
                                //    "-----از لیست های کشویی دقت فرمائید. در صورت ادامه بدون اصلاح، اطلاعات به صورت ناقص ثبت خواهد شد.", "لیست های کشویی");پ
								if (((JUIComboBox)Contr).SelectedValue != null)
									_DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = ((JUIComboBox)Contr).SelectedValue.ToString();
								else
									_DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = "";

                            }
                            //}
                            //else
                            //{
                            //    if (((JUIComboBox)Contr).Items.Count > 0)
                            //        _DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = ((JUIComboBox)Contr).Text;
                            //    else
                            //_DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = ((JUIComboBox)Contr).Text;
                            //    _DR[((JUIComboBox)Contr).Name.Replace("Prop_", "")] = "";
                            //}
                        }
                    }
                    else
                    {
						_DR["ObjectCode"] = ValueObjectCode;
						_DR["RegisterPostCode"] = ClassLibrary.JMainFrame.CurrentPostCode;
						_DR["Code"] = _Code;
                    }

                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            return _DR;
        }

        //Hassanzadeh
        public bool Save()
        {
            ClassLibrary.JDataBase pDB = new ClassLibrary.JDataBase();
            try
            {
                return Save(pDB);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                return false;
            }
            finally
            {
                pDB.Dispose();
            }
        }

        public bool Save(ClassLibrary.JDataBase pDB)
        {
			JDataBase _DB = pDB;
			try
			{
				if (pDB == null)
				{
					_DB = new JDataBase();
				}
				if (CountFields > 0)
				{
					JPropertyTables PropTables = new JPropertyTables(ClassName, ObjectCode);
					if (_Code == 0)
					{
						_Code = PropTables.Insert(GetDataRowValue(), _DB);
						return _Code > 0;
					}
					else
					{
						return PropTables.Update(GetDataRowValue(), _DB);
					}
				}
				return true;
			}
			finally
			{
				if (pDB == null)
					_DB.Dispose();
			}
        }

        public void RefreshFields()
        {
			if (_DT == null)
				GetVAlues(ValueObjectCode);
            if (_DT != null && _DT.Rows.Count == 1)
            {
                try
                {
                    RegisterPostCode = (int)_DT.Rows[0]["RegisterPostCode"];
                }
                catch
                {

                    RegisterPostCode = JMainFrame.CurrentPersonCode;                }
            }
            CountFields = 0;
            ClearControlRecursive(splitContainer1.Panel1);
            ClearControlRecursive(splitContainer1.Panel2);
            JProperties Ps = new JProperties(ClassName, ObjectCode);
            System.Data.DataTable DT = Ps.GetDataTable();
            int Count = DT.Rows.Count - 1;
            splitContainer1.Height = DT.Rows.Count * 20;
            int Height = 0;
            foreach (System.Data.DataRow DR in DT.Rows)
            {
                Panel p1 = new Panel();
                p1.Parent = this.splitContainer1.Panel1;
                p1.Dock = DockStyle.Top;
                p1.Height = 20;
                p1.BackColor = Color.LightGray;

                Panel p2 = new Panel();
                p2.Parent = this.splitContainer1.Panel2;
                p2.Dock = DockStyle.Top;
                p2.Height = 20;
                p2.BackColor = Color.LightGray;


                TextBox TBLabel = new TextBox();
                TBLabel.Parent = p1;
                TBLabel.Dock = DockStyle.Fill;
                TBLabel.Text = DR["Name"].ToString().Replace("__", " ");
                TBLabel.ReadOnly = true;
                TBLabel.BackColor = Color.LightGray;

                string DType = DR["DataType"].ToString();
                string LType = DR["ListType"].ToString();

                Control TBValue;
                CountFields++;

                if (LType == JProppertyListType.لیست_ثابت.ToString())
                {
                    //TBValue = new ComboBox();
                    TBValue = new JUIComboBox();
                    char[] newLine = { (char)13, (char)10 };

                    if (DType == JSQLDataType.اس_کیو_ال.ToString())
                    {
                        string _SQL = DR["List"].ToString();
                        ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                        try
                        {
                            DB.setQuery(_SQL);
                            ClassLibrary.JDataTable _DataT = (ClassLibrary.JDataTable)DB.Query_DataTable();
                            _DataT.Tidy(_DataT.Columns[1].ColumnName, _DataT.Columns[1].ColumnName + "_Small", 40);


                            JUIComboBox TempCB = ((JUIComboBox)TBValue);
                            TempCB.BindingContext = new BindingContext();
                            TempCB.DisplayMember = _DataT.Columns[1].ColumnName + "_Small";
                            TempCB.ValueMember = _DataT.Columns[0].ColumnName;
                            TempCB.DataSource = _DataT;
							TempCB.SelectedIndexChanged += new EventHandler(JPropertyValueUserControl_SelectedValueChanged);

                        }
                        catch
                        {
                        }
                        finally
                        {
                            DB.Dispose();
                        }
                    }
                    else
                    {
                        foreach (string item in DR["List"].ToString().Split(newLine))
                        {
                            if (item != "")
                                ((JUIComboBox)TBValue).Items.Add(item);
                        }
                    }
                    ((JUIComboBox)TBValue).SelectedValueChanged += new EventHandler(JPropertyValueUserControl_SelectedValueChanged);
                }
                else
                    if (DType == JSQLDataType.عدد.ToString())
                    {
                        TBValue = new ClassLibrary.TextEdit();
                        ((ClassLibrary.TextEdit)TBValue).TextMode = ClassLibrary.TextModes.Integer;
                        TBValue.Text = (string)Ps.GetValue(TBLabel.Text.Replace(" ", "__"), 0);
                        ((ClassLibrary.TextEdit)TBValue).TextChanged += new EventHandler(JPropertyValueUserControl_TextChanged);
                    }
                    else
                        if (DType == JSQLDataType.اعشار.ToString())
                        {
                            TBValue = new ClassLibrary.TextEdit();
                            ((ClassLibrary.TextEdit)TBValue).TextMode = ClassLibrary.TextModes.Real;
                            ((ClassLibrary.TextEdit)TBValue).TextChanged += new EventHandler(JPropertyValueUserControl_TextChanged);
                        }
                        else
                            if (DType == JSQLDataType.رشته.ToString() || DType == JSQLDataType.رشته_چند_خطی.ToString())
                            {
                                TBValue = new ClassLibrary.TextEdit();
                                ((ClassLibrary.TextEdit)TBValue).TextMode = ClassLibrary.TextModes.Text;
                                if (DType == JSQLDataType.رشته_چند_خطی.ToString())
                                {
                                    ((ClassLibrary.TextEdit)TBValue).Multiline = true;
                                    ((ClassLibrary.TextEdit)TBValue).Height = 200;
                                    ((ClassLibrary.TextEdit)TBValue).ScrollBars = ScrollBars.Vertical;
                                    ((Panel)p2).Height = 200;
                                }
                                string SQLResault = "";
                                string _SQL = DR["List"].ToString();
                                if (_SQL != null && _SQL.Length > 4)
                                {
                                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                                    try
                                    {
                                        DB.setQuery(_SQL);
                                        DataTable _DataT = DB.Query_DataTable();
                                        if (_DataT.Rows.Count > 1)
                                        {
                                            SQLResault = "Error! Resault is more than one";
                                        }
                                        else
                                        {
                                            if (_DataT.Rows.Count == 1)
                                            {
                                                SQLResault = _DataT.Rows[0][0].ToString();
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    finally
                                    {
                                        DB.Dispose();
                                    }

                                    ((ClassLibrary.TextEdit)TBValue).Text = SQLResault;
                                }
                                ((ClassLibrary.TextEdit)TBValue).TextChanged += new EventHandler(JPropertyValueUserControl_TextChanged);
                            }
                            else
                                if (DType == JSQLDataType.پول.ToString())
                                {
                                    TBValue = new ClassLibrary.TextEdit();
                                    ((ClassLibrary.TextEdit)TBValue).TextMode = ClassLibrary.TextModes.Money;
                                    ((ClassLibrary.TextEdit)TBValue).TextChanged += new EventHandler(JPropertyValueUserControl_TextChanged);
                                }
                                else
                                    if (DType == JSQLDataType.تصمیم.ToString())
                                    {
                                        TBValue = new CheckBox();
                                        ((CheckBox)TBValue).CheckedChanged += new EventHandler(JPropertyValueUserControl_CheckedChanged);
                                    }
                                    else
                                        if (DType == JSQLDataType.تاریخ.ToString())
                                        {
                                            TBValue = new ClassLibrary.DateEdit();
                                            ((ClassLibrary.DateEdit)TBValue).TextChanged += new EventHandler(JPropertyValueUserControl_TextChanged);
                                        }
                                        else
                                            if (DType == JSQLDataType.زمان.ToString())
                                            {
                                                TBValue = new ClassLibrary.TimeEdit();
                                                ((ClassLibrary.TimeEdit)TBValue).TextChanged += new EventHandler(JPropertyValueUserControl_TextChanged);
                                            }
                                            else
                                            {
                                                TBValue = new Control();
                                            }

                p2.Controls.Add(TBValue);
                TBValue.Dock = DockStyle.Fill;
                TBValue.Name = "Prop_" + TBLabel.Text.Replace(" ", "__");
                TBValue.TabStop = true;
                TBValue.TabIndex = Count--;
                if (DType != JSQLDataType.رشته_چند_خطی.ToString())
                    TBValue.KeyUp += new KeyEventHandler(TBValue_KeyUp);
                TBValue.KeyPress += new KeyPressEventHandler(TBValue_KeyPress);
                TBValue.Enter += new EventHandler(TBValue_Enter);
                TBValue.Leave += new EventHandler(TBValue_Leave);
                try
                {
                    string ListCanView = DR["ListCanView"].ToString();
                    if (ListCanView.Length > 0)
                    {
                        TBValue.Visible = false;
                        string[] Values = ListCanView.Split(new char[] { ',' });
                        for (int i = 0; i < Values.Length; i++)
                        {
							if ((int.Parse(Values[i]) == ClassLibrary.JMainFrame.CurrentPostCode)
								||
								(int.Parse(Values[i]) == -1 && (RegisterPostCode==0 ||RegisterPostCode == ClassLibrary.JMainFrame.CurrentPostCode))
								)
							{
                                TBValue.Visible = true;
                                break;
                            }
                        }
                    }

                    string ListCanEdit = DR["ListCanEdit"].ToString();
                    if (ListCanEdit.Length > 0)
                    {
                        if (TBValue.GetType() != typeof(ClassLibrary.TextEdit))
                            TBValue.Enabled = false;
                        else
                            ((ClassLibrary.TextEdit)TBValue).ReadOnly = true;

                        string[] Values = ListCanEdit.Split(new char[] { ',' });
						for (int i = 0; i < Values.Length; i++)
						{
							if ((int.Parse(Values[i]) == ClassLibrary.JMainFrame.CurrentPostCode)
								||
								(int.Parse(Values[i]) == -1 && (RegisterPostCode==0 || RegisterPostCode == ClassLibrary.JMainFrame.CurrentPostCode))
								)
							{
								if (TBValue.GetType() != typeof(ClassLibrary.TextEdit))
									TBValue.Enabled = true;
								else
									((ClassLibrary.TextEdit)TBValue).ReadOnly = false;
								break;
							}
						}
                    }
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
        }

        void TBValue_Leave(object sender, EventArgs e)
        {
            this.ParentForm.KeyPreview = true;
        }

        void TBValue_Enter(object sender, EventArgs e)
        {
            this.ParentForm.KeyPreview = false;
        }

        void TBValue_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        void TBValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 || (e.Alt && e.KeyValue == 40))
            {
                try
                {
                    Control A = (sender as Control);
                    this.SelectNextControl(A, false, true, true, true);
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            else
            {
            }
        }

        void JPropertyValueUserControl_CheckedChanged(object sender, EventArgs e)
        {
            _State = 1;
			OnChanged(EventArgs.Empty);
		}

        void JPropertyValueUserControl_TextChanged(object sender, EventArgs e)
        {
            _State = 1;
			OnChanged(EventArgs.Empty);
		}

        void JPropertyValueUserControl_SelectedValueChanged(object sender, EventArgs e)
        {
            _State = 1;
			OnChanged(EventArgs.Empty);
		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            JDefinePropertyForm DPF = new JDefinePropertyForm(ClassName, ObjectCode);
            DPF.ShowDialog();
        }

        private void splitContainer1_Panel2_Scroll(object sender, ScrollEventArgs e)
        {
            splitContainer1.Panel2.VerticalScroll.Value = splitContainer1.Panel1.VerticalScroll.Value;
        }

        private void splitContainer1_Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            splitContainer1.Panel1.VerticalScroll.Value = splitContainer1.Panel2.VerticalScroll.Value;
        }

        private void JPropertyValueUserControl_Load(object sender, EventArgs e)
        {
            _State = 0;
			if (ClassLibrary.JMainFrame.CurrentPostCode == 1)
				toolStripButton1.Enabled = true;
        }
    }

}
