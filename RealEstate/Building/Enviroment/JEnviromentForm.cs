using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Estates;

namespace RealEstate
{
    public partial class JEnviromentForm : ClassLibrary.JBaseForm
    {
        private JEnviroment _JEnviroment;
        private JDataBase _DataBase;
        int _Code;

        public JEnviromentForm(JDataBase pDB)
            : this(0, 0, pDB)
        {

        }

        public JEnviromentForm()
            : this(0, 0, null)
        {

        }

        public JEnviromentForm(int code)
            : this(code, 0, null)
        {

        }

        public JEnviromentForm(int code, JDataBase pDB)
            : this(code, 0, pDB)
        {

        }

        public JEnviromentForm(int code, int pMCode, JDataBase pDB)
        {
            InitializeComponent();
            _DataBase = pDB;
            _JEnviroment = new JEnviroment();
            _FillComboBox();
            /// مقداردهی پراپرتی ها
            ArchiveList.ClassName = "RealEstate.JEnviroment";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            ArchiveList.ObjectCode = 0;
           
            //if (pMCode > 0)
            //{
            //    cmbComplex.SelectedValue = pMCode;
            //    cmbComplex.Enabled = false;
            //}

            if (code == 0)
            {
                State = JFormState.Insert;
                cmbComplex.SelectedValue = pMCode;
                // پرکردن طبقات مجتمع
                cmbComplex_SelectedIndexChanged(null, null);
            }
            else
            {
                ArchiveList.ObjectCode = code;
                _JEnviroment.GetData(code);
                cmbComplex.SelectedValue = _JEnviroment.Complex;
                // پرکردن طبقات مجتمع
                cmbComplex_SelectedIndexChanged(null, null);

                DisplayData();
                DefineProperty.ValueObjectCode = code;                
                State = JFormState.Update;
                _Code = code;
            }
            cmbComplex.Enabled = false;
        }
        public Boolean DisplayData()
        {
            txtCodeEnv.Text = _JEnviroment.Code.ToString();
            txtmoneyBase.Text = _JEnviroment.moneyBase.ToString();
            txtNameEnv.Text = _JEnviroment.NameEnviroment;
            txtnumArea.Text = _JEnviroment.Area.ToString();
            cmbComplex.SelectedValue = Convert.ToInt32(_JEnviroment.Complex);
            cmbState.SelectedIndex = _JEnviroment.state;
            cmbTypeEnviroment.SelectedValue = Convert.ToInt32(_JEnviroment.TypeEnviroment);
            txtAddress.Text = _JEnviroment.Address;
            txtCharge.Text = _JEnviroment.moneyBaseCharge.ToString();
            cmbFloor.SelectedValue = Convert.ToInt32(_JEnviroment.CodeFloor);
            CmbInput.SelectedValue = _JEnviroment.Door;
         
            txtTafsili.Text =_JEnviroment.Tafsili.ToString();
            /// مقداردهی پراپرتی ها

            return true;
        }

        public void _FillComboBox()
        {

            // پر كردن نام مجتمع / بازارها
            cmbComplex.DisplayMember = estMarket.Title.ToString();
            cmbComplex.ValueMember = estMarket.Code.ToString();
            cmbComplex.DataSource = jMarkets.GetDataTable(0);

           
            // پر كردن عنوان محيط
            cmbTypeEnviroment.Items.Clear();
            cmbTypeEnviroment.DataSource = JJoints.GetDataTable(0);
            cmbTypeEnviroment.ValueMember = "Code";
            cmbTypeEnviroment.DisplayMember = "Type";
            JDoorBuildings Door = new JDoorBuildings();
            Door.SetComboBox(CmbInput);

            // پرکردن طبقات مجتمع
            cmbComplex_SelectedIndexChanged(null, null);
         

        }

        private Boolean Validation()
        {
            if (txtNameEnv.Text == "")
            {
                JMessages.Message("لطفا نام محیط را وارد کنید", "نقص در ورود اطلاعات", JMessageType.Information);
                return false;
            }
            
            if (Convert.ToInt32(cmbTypeEnviroment.SelectedValue) == -1 || Convert.ToInt32(cmbTypeEnviroment.SelectedValue) == 0)
            {
                JMessages.Message("لطفا عنوان محیط را وارد کنید", "نقص در ورود اطلاعات", JMessageType.Information);
                return false;
            }

            if (Convert.ToInt32(cmbComplex.SelectedValue) == -1 || Convert.ToInt32(cmbComplex.SelectedValue) == 0)
            {
                JMessages.Message("لطفا نام مجتمع را وارد کنید", "نقص در ورود اطلاعات", JMessageType.Information);
                return false;
            }

            if (txtnumArea.Text == "")
            {
                JMessages.Message("لطفا مساحت را وارد کنید ", "نقص در ورود اطلاعات", JMessageType.Information);
                return false;
            }

            //if (txtCharge.Text == "")
            //{
            //    JMessages.Message("لطفا قیمت شارژ پایه را وارد کنید ", "نقص در ورود اطلاعات", JMessageType.Information);
            //    return false;
            //}

            if (Convert.ToInt32(cmbState.SelectedValue) == -1 )
            {
                JMessages.Message("لطفا وضعیت این موجودیت را وارد کنید", "نقص در ورود اطلاعات", JMessageType.Information);
                return false;
            }

            //if (txtmoneyBase.Text == "")
            //{
            //    JMessages.Message("لطفا قیمت پایه را وارد کنید ", "نقص در ورود اطلاعات", JMessageType.Information);
            //    return false;
            //}

            if (Convert.ToInt32(cmbFloor.SelectedValue) == -1 || Convert.ToInt32(cmbFloor.SelectedValue) == 0)
            {
                JMessages.Message("لطفا وضعیت طبقه را وارد کنید", "نقص در ورود اطلاعات", JMessageType.Information);
                return false;
            }

            //if (Convert.ToInt32(CmbInput.SelectedValue) == -1 || Convert.ToInt32(CmbInput.SelectedValue) == 0)
            //{
            //    JMessages.Message("لطفا موقعیت را وارد کنید", "نقص در ورود اطلاعات", JMessageType.Information);
            //    return false;
            //}

            //if (txtAddress.Text == "")
            //{
            //    JMessages.Message("لطفا آدرس دقیق را وارد کنید ", "نقص در ورود اطلاعات", JMessageType.Information);
            //    return false;
            //}
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region SetValue
            
            //_JEnviroment = new JEnviroment();
            _JEnviroment.TypeEnviroment = (Convert.ToInt32(cmbTypeEnviroment.SelectedValue));
            _JEnviroment.Complex = Convert.ToInt32(cmbComplex.SelectedValue);
            _JEnviroment.Area = txtnumArea.DecimalValue;
            _JEnviroment.Address = txtAddress.Text;
            _JEnviroment.moneyBaseCharge = txtCharge.MoneyValue;
            _JEnviroment.moneyBase = txtmoneyBase.MoneyValue;
            _JEnviroment.NameEnviroment = txtNameEnv.Text;
            _JEnviroment.CodeFloor = Convert.ToInt32(cmbFloor.SelectedValue);
            _JEnviroment.Door = (Convert.ToInt32(CmbInput.SelectedValue));
            _JEnviroment.Tafsili = txtTafsili.IntValue;
            if (State == ClassLibrary.JFormState.Insert)
                _JEnviroment.state = 1;
            else
                _JEnviroment.state = Convert.ToInt32(cmbState.SelectedIndex);

            
            bool StatusSave = Validation();
           
          
            #endregion

            //  ذخيره پراپرتي
            //jDefinePropertyUserControl.ClassName = "RealEstate.JEnviromentForm";

            #region Insert
            if(StatusSave==true)
            {
            if (State == ClassLibrary.JFormState.Insert)
            {
                int _code = _JEnviroment.Insert(_DataBase);

                if (_code > 0)
                {

                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);

                    DisplayData();

                    State = JFormState.Update;
                    DefineProperty.ValueObjectCode = _code;
                    DefineProperty.Save(_DataBase);
                    ArchiveList.ObjectCode = _code;
                    ArchiveList.ArchiveList();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    JMessages.Message("در درج اطلاعات مشکلی بروز کرده است ", "", JMessageType.Information);
                }
            }
            else
            {
                if (_JEnviroment.Update(_DataBase))
                {
                    //JMessages.Message("UpdateSuccessfuly ", "", JMessageType.Information);
                    btnAdd.Enabled = false;
                    DisplayData();
                    DefineProperty.Save(_DataBase);
                    ArchiveList.ArchiveList();
                    DialogResult = DialogResult.OK;
                    
                    //  ذخيره آرشيو
                 
                }
                else
                {
                    JMessages.Message("در درج اطلاعات مشکلی بروز کرده است ", "", JMessageType.Information);
                }
            }
            }
            #endregion        
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btninsert_Click(object sender, EventArgs e)
        {

        }

        private void btndel_Click(object sender, EventArgs e)
        {

        }

        private void JEnviromentForm_Load(object sender, EventArgs e)
        {
            if(_JEnviroment.Code==0)
                cmbComplex_SelectedIndexChanged(null, null);

            Finance.JAsset Asset = new Finance.JAsset("RealEstate.JEnviroment", _Code);
            jJanusGrid1.DataSource = Legal.JSubjectContracts.ContractHistory(Asset.Code, Finance.JOwnershipType.Rentals);
            jJanusGrid1.Columns["TotalPrice"].Visible = false;
            jJanusGrid1.Columns["GoodwillPrice"].Visible = false;
            jJanusGrid1.Columns["Share"].Visible = false;
        }

        private void cmbComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
            jMarketFloors Floor = new jMarketFloors();
            DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);

            cmbFloor.DataSource = TableFloor;
            cmbFloor.DisplayMember = estMarketFloors.Name.ToString();
            cmbFloor.ValueMember = estMarketFloors.Code.ToString();
            cmbFloor.Text = "";
            //نمایش کاربری های  مجتمع بر اساس مجتمع انتخاب شده
            if (_JEnviroment.Complex == 0 || Convert.ToInt32(cmbComplex.SelectedValue) == _JEnviroment.Complex)
            {
                DefineProperty.ClassName = "RealEstate.JEnviroment";
                DefineProperty.ObjectCode = Convert.ToInt32(cmbComplex.SelectedValue);
            }
        }

        private void txtNameEnv_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }

        private void ArchiveList_Load(object sender, EventArgs e)
        {

        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Code == 0)
                return;
            contextMenuStripContract.Items.Clear();
            EventHandler ClickEvent = new EventHandler(run);

            Finance.JAsset Asset = new Finance.JAsset("RealEstate.JEnviroment", _Code);

            Legal.JContractNodes CN = new Legal.JContractNodes();
            JNode[] _nodes = CN.ContractTree(_JEnviroment.Complex);

            foreach (JNode _node in _nodes)
            {
                ToolStripItem TSI = contextMenuStripContract.Items.Add(_node.Name);
                if (_node.ChildsAction != null)
                {
                    JNode[] _childnodes = (JNode[])_node.ChildsAction.run();
                    foreach (JNode _childnode in _childnodes)
                    {
                        ToolStripItem TSIChild = ((ToolStripMenuItem)TSI).DropDownItems.Add(_childnode.Name, null, ClickEvent);
                        TSIChild.Tag =
                            new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code, 0, Asset.Code, false });
                    }
                }
            }

            //contextMenuStripContract.Show(this.Left+ ((Button)sender).Left + ((Button)sender).Width / 2,this.Top+ ((Button)sender).Top + ((Button)sender).Height / 2);
            contextMenuStripContract.Show(MousePosition);
        }
    }
}
