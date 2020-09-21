using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Parking
{
    public partial class OprateCarForm :JBaseForm
    {
        private JCar _JCar;
        private JCardParking Card;
        public int IDCard = 0;
        public bool DisplayData()
        {
            try
            {


                cmbCarColor.SelectedValue = (Convert.ToInt32(_JCar.CarColor));
                txtCarOwner.Text = _JCar.CarOwner;

               
                cmbTypeCar.SelectedValue = (Convert.ToInt32(_JCar.TypeCar));
                txtDescription.Text = _JCar.Description;
                txtp1.Text = _JCar.Plaque[0].ToString() + _JCar.Plaque[1].ToString();
                txtp2.Text = _JCar.Plaque[2].ToString();
                txtp3.Text = _JCar.Plaque[3].ToString() + _JCar.Plaque[4].ToString() + _JCar.Plaque[5].ToString();
                txtp4.Text = _JCar.Plaque[7].ToString() + _JCar.Plaque[8].ToString();
                chkDefult.Checked = _JCar.StatusCard;
                ArchiveList.ObjectCode = _JCar.Code;
                ArchiveList.ArchiveList();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void _FillComboBox()
        {
            try
            {
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                // پر كردن نام مجتمع / بازارها

                // پرکردن پروتکل ارتباطی دستگاه
                JStatus JS = new JStatus();


                // پرکردن نوع خودرو
                JTypeCar JTC = new JTypeCar();
                cmbTypeCar.Items.Clear();
                JTC.SetComboBox(cmbTypeCar);

                // پرکردن نوع خودرو
                JColorCar JCC = new JColorCar();
                cmbCarColor.Items.Clear();
                JCC.SetComboBox(cmbCarColor);

               
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }
       
        public OprateCarForm(JCar Car)
        {
            InitializeComponent();
            _FillComboBox();
            
            ArchiveList.ClassName = "RealEstate.JCar";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            ArchiveList.ObjectCode = 0;

            _JCar = Car;
            if (_JCar.Code > 0)
            {
                _JCar.GetData(_JCar.IDCardParking);
                DisplayData();
                this.State = JFormState.Update;

                ArchiveList.ObjectCode = _JCar.Code;
                
            }
            else
            {
                Car = new JCar();
                this.State = JFormState.Insert;
                btnSave.Enabled = false;
            }
        }
        public OprateCarForm(JCar Car,int CodeCard)
        {
            InitializeComponent();
            _FillComboBox();

            ArchiveList.ClassName = "RealEstate.JCar";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            ArchiveList.ObjectCode = 0;

            _JCar = Car;
            Card = new JCardParking();
            Card.GetData(CodeCard);
            if (_JCar.Code > 0)
            {
               
                DisplayData();
                this.State = JFormState.Update;

                ArchiveList.ObjectCode = _JCar.Code;

            }
            else
            {
                Car = new JCar();
                this.State = JFormState.Insert;
                btnSave.Enabled = false;
            }
        }
        private void OprateCarForm_Load(object sender, EventArgs e)
        {

        }
        private Boolean Valdtion()
        {
            if (Convert.ToInt32(cmbCarColor.SelectedValue) == 0 || Convert.ToInt32(cmbCarColor.SelectedValue) == -1)
            {
                string msg = "لطفا رنگ خودرو را مشخص نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            if (txtCarOwner.Text.Trim() == "")
            {
                string msg = "لطفا مالک خودرو را مشخص نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }



            if (txtp1.Text.Trim() == "" && txtp2.Text.Trim() == "" && txtp3.Text.Trim() == "" && txtp4.Text.Trim() == "")
            {
                string msg = "لطفا تمامی چهار قسمت تشکیل دهنده پلاک خودرو را وارد نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }


            if (Convert.ToInt32(cmbTypeCar.SelectedValue) == 0 || Convert.ToInt32(cmbTypeCar.SelectedValue) == -1)
            {
                string msg = "لطفا نوع خودرو را مشخص نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            return true;
        }
        private void SetData()
        {
            _JCar.CarColor = (Convert.ToInt32(cmbCarColor.SelectedValue));
            _JCar.CarOwner = txtCarOwner.Text;
            _JCar.IDCardParking = Card.Code;
           
            _JCar.Plaque = txtp1.Text + txtp2.Text + txtp3.Text +"-"+ txtp4.Text;
            _JCar.Defult = chkDefult.Checked;
            _JCar.TypeCar = (Convert.ToInt32(cmbTypeCar.SelectedValue));
            _JCar.Description = txtDescription.Text;
            _JCar.StatusCard = chkDefult.Checked;
            _JCar.CardNumber = Card.IDCardParking;
        }
        private void Save()
        {
            SetData();
            if (Valdtion())
            {
                if (chkDefult.Checked == true)
                {
                    _JCar.ClearDefult(_JCar.IDCardParking);
                }
                //---------ویرایش------------
                if (State == JFormState.Insert)
                {
                    if (_JCar.FindPlaque(_JCar.Plaque))
                    {
                        string msg = "پلاك وارد شده تكراري است";
                        JMessages.Error(msg, "Error");

                        return;
                    }
                    _JCar.Insert();
                    if (_JCar.Code > 0)
                    {
                        JMessages.Message("InsertSuccessfuly ", "", JMessageType.Information);
                        State = JFormState.Update;
                        ArchiveList.ObjectCode = _JCar.Code;
                        ArchiveList.ArchiveList();
                        this.Close();

                    }
                    else
                    {
                        JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);

                    }
                }
                else
                {
                    if (_JCar.Update())
                    {
                        JMessages.Message("UpdateSuccessfuly ", "", JMessageType.Information);


                        ArchiveList.ArchiveList();
                        IDCard = Card.Code;
                        this.Close();
                    }
                    else
                    {
                        JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);

                    }
                }

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                Save();
                this.Close();

              
            }
            catch (Exception Ex)
            {
                JMessages.Error("در اجراي عمليات مشكلي بروز كرده است " + Ex.Message, "خطا");
            }
                
        }

        private void btnApplay_Click(object sender, EventArgs e)
        {
            Save();
        }
    
    }
}
