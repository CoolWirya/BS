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
    public partial class JTrafficForm : Globals.JBaseForm
    {
       

        public JTrafficForm(int Market)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public JTrafficForm()
        {
            InitializeComponent();
        }




        public void ShowForm()
        {
           // if (JPermission.CheckPermission("Parking.JTrafficForm.ShowForm"))
                ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if ( _JTraffic.TestCommunication() )
                Save();
        }

        private void Save()
        {
            //String _SendFormError = "";
            //AfterDisplayClean();
            //JDataBase db = new JDataBase();
            //_JTraffic.IDCard = 431;
            //int innum = _JTraffic.InsertManualByParkingCard(_JTraffic.IDCard,ref _SendFormError);
             
            //if (innum != 0)
            //{
            //    lblMessage.Text += "  عملیات با موفقیت به انجام رسید ";
            //    lblMessage.Text += _SendFormError;
            //}
            //else
            //{
            //    lblMessage.Text += " عملیات ناموفق "+ _SendFormError;
            //}

            //DisplayAfterOperate(innum,TypeGate);

            //if (!DisplayCardParking(_JTraffic.IDCard))
            //{
            //    lblMessage.Text += "این کارت متعلق به این پارکینگ نمی باشد";
            //}
           
        }

        private void JTrafficForm_Load(object sender, EventArgs e)
        {
            DisplayPofileParking();
            pctcpClient.Connect("192.168.0.1", 1200);
        }

        /// <summary>
        /// تمامی آیتم ها را قبل از عملیات حدف می کند
        /// </summary>
        /// <returns></returns>
        private bool AfterDisplayClean()
        {
            txtCard.Text = "";
            txtDateIn.Text = "";
            txtTimeIn.Text = "";
            TyperCard.Text = "";
            txtDateOut.Text = "";
            txtTimeOut.Text = "";
            txtDuration.Text = "";
            txtAmount.Text = "";
            txtUnitNumber.Text = "";
            txtOwnerCard.Text = "";
            txtDate.Text = "";
            txtCardElectonic.Text = "";
            txtDateCard.Text = "";
            txtTypeCar.Text = "";
            txtCarColor.Text = "";
            txtStatusCard.Text = "";
            lblMessage.Text = "-";
            txtDuInactive.Text = "-";
            return true;
        }
        
        /// <summary>
        /// در فرو ترافیک وضعیت تردد را نمایش می دهد
        /// </summary>
        /// <param name="_Code"></param>
        /// <param name="_StatusGate"></param>
        /// <returns></returns>
        private bool DisplayAfterOperate(int _Code,int _StatusGate)
        {
            //JDataBase db = new JDataBase();
            //try
            //{
            //    db.setQuery("select * from " + JTableNamesParking.Traffic + " where Code=" + JDataBase.Quote(_Code.ToString()));
            //    db.Query_DataSet();
            //    // ورودی
            //    if (_StatusGate == (int)ParkingEnum.Input)
            //    {
            //        txtCard.Text = (db.DataSet.Tables[0].Rows[0]["IDCard"]).ToString(); 

            //        txtDateIn.Text= JDateTime.FarsiDate(Convert.ToDateTime(db.DataSet.Tables[0].Rows[0]["DateIn"]));
            //        txtTimeIn.Text= (db.DataSet.Tables[0].Rows[0]["TimeIn"]).ToString();
            //        TyperCard.Text = _JTraffic.ReturnGroupName( Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["GroupCard"]) );

            //        txtDateOut.Text = " نامعلوم ";
            //        txtTimeOut.Text = " نامعلوم ";
            //        txtDuration.Text = " نامعلوم ";
            //        txtAmount.Text = "نا معلوم";
                   
            //    }
            //    else if (_StatusGate == (int)ParkingEnum.OutPut)
            //    {
            //        txtCard.Text = (db.DataSet.Tables[0].Rows[0]["IDCard"]).ToString();

            //        txtDateIn.Text = JDateTime.FarsiDate(Convert.ToDateTime(db.DataSet.Tables[0].Rows[0]["DateIn"]));
            //        txtTimeIn.Text = (db.DataSet.Tables[0].Rows[0]["TimeIn"]).ToString();
            //        TyperCard.Text = _JTraffic.ReturnGroupName(Convert.ToInt32(db.DataSet.Tables[0].Rows[0]["GroupCard"]));

            //        txtDateOut.Text = JDateTime.FarsiDate(Convert.ToDateTime(db.DataSet.Tables[0].Rows[0]["DateOut"]));
            //        txtTimeOut.Text = (db.DataSet.Tables[0].Rows[0]["TimeOut"]).ToString();
            //        txtDuration.Text = (db.DataSet.Tables[0].Rows[0]["DurationStayParking"]).ToString();
            //        txtAmount.Text = (db.DataSet.Tables[0].Rows[0]["Amount"]).ToString();
            //    }

                
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    DisplayPofileParking();

            //}

            return false;
        }

        /// <summary>
        /// پروفایل پارکینگ را در فرم نمایش می دهد
        /// </summary>
        /// <returns></returns>
        private bool DisplayPofileParking()
        {
            //JDataBase db = new JDataBase();
            //try
            //{
            //    txtParkingName.Text = Properties.Settings.Default.Complex.ToString();
            //    txtDateToday.Text = JDateTime.FarsiDate(db.GetCurrentDateTime());
            //    txtTime.Text = db.GetCurrentDateTime().ToString("HH:mm");
            //    string _query = " Datein='" + db.GetCurrentDateTime().ToString("yyyy/MM/dd") + "' and Amount is null";
            //    txtCountCarIn.Text = _JTraffic.ReturnTrafficQuery(_query, "count(*)").ToString();
            //    txtCountCar.Text = _JTraffic.ReturnTrafficQuery(" Datein='" + db.GetCurrentDateTime().ToString("yyyy/MM/dd") + "'", "count(*)").ToString();

            //    db.setQuery("SELECT  Count(*) as CountCard,Sum(dbo.PrkTraffic.Amount) As Amount " +
            //    " FROM  " + JTableNamesParking.Traffic +
            //    " WHERE   (dbo.PrkTraffic.GateIn = " + Properties.Settings.Default.Gate.ToString() + " or GateOut=" + Properties.Settings.Default.Gate.ToString() +
            //        ") and (dbo.PrkTraffic.DateIn = '" + db.GetCurrentDateTime().ToString("yyyy/MM/dd") + "' or dbo.PrkTraffic.DateOut = '" +
            //        db.GetCurrentDateTime().ToString("yyyy/MM/dd") + "')");
            //    db.Query_DataSet();

            //    txtFundAmount.Text = db.DataSet.Tables[0].Rows[0]["Amount"].ToString();

            //    JPerson person = new JPerson(JMainFrame.CurrentPersonCode);
            //    txtUser.Text = person.Name + " " + person.Fam;

            //    txtCountUserCar.Text = db.DataSet.Tables[0].Rows[0]["CountCard"].ToString();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            //finally
            //{
            //    db.Dispose();
            //}
            return false;
        }

        /// <summary>
        /// اطلاعات مربوط به کارت پارکینگ را نمایش می دهد
        /// </summary>
        /// <param name="CardNumber"></param>
        /// <returns></returns>
        private bool DisplayCardParking(int CardNumber)
        {
            //JDataBase db = new JDataBase();
            //string pelak;
            //bool state;
            //try
            //{
            //    db.setQuery("SELECT     dbo.PrkCardParking.IDCardParking, dbo.PrkCardParking.Number, dbo.PrkCardParking.DateExpire, dbo.PrkCardParking.ElectronicPay, subdefine_1.name AS TypeCar,"+ 
            //                    " dbo.subdefine.name AS ColorCar, dbo.PrkCar.Plaque, dbo.PrkCar.CarOwner, dbo.PrkCardParking.EndDateContract, dbo.PrkCardParking.StatusCard,subdefine_2.name AS InActiveDue"+
            //                " FROM         dbo.subdefine AS subdefine_2 INNER JOIN"+
            //                    " dbo.PrkCardParking ON subdefine_2.Code = dbo.PrkCardParking.InactiveDue INNER JOIN"+
            //                    " dbo.PrkCar INNER JOIN"+
            //                    " dbo.subdefine AS subdefine_1 ON dbo.PrkCar.TypeCar = subdefine_1.Code INNER JOIN"+
            //                    " dbo.subdefine ON dbo.PrkCar.CarColor = dbo.subdefine.Code ON dbo.PrkCardParking.IDCardParking = dbo.PrkCar.CardNumber"+
            //                " WHERE (dbo.PrkCardParking.IDCardParking ="+ JDataBase.Quote(CardNumber.ToString()) +" AND (dbo.PrkCar.Defult = 'True'))");
            //    db.Query_DataSet();

            //    txtCardNum.Text = db.DataSet.Tables[0].Rows[0]["IDCardParking"].ToString();
            //    txtUnitNumber.Text= db.DataSet.Tables[0].Rows[0]["Number"].ToString();
            //    txtOwnerCard.Text=db.DataSet.Tables[0].Rows[0]["CarOwner"].ToString();
            //    txtDate.Text = JDateTime.FarsiDate(Convert.ToDateTime(db.DataSet.Tables[0].Rows[0]["EndDateContract"]));
            //    txtCardElectonic.Text = db.DataSet.Tables[0].Rows[0]["ElectronicPay"].ToString();
            //    txtDateCard.Text = JDateTime.FarsiDate(Convert.ToDateTime(db.DataSet.Tables[0].Rows[0]["DateExpire"]));
            //    txtTypeCar.Text = db.DataSet.Tables[0].Rows[0]["TypeCar"].ToString();
            //    txtCarColor.Text = db.DataSet.Tables[0].Rows[0]["ColorCar"].ToString();
            //    txtStatusCard.Text = db.DataSet.Tables[0].Rows[0]["StatusCard"].ToString();
            //    txtDuInactive.Text = db.DataSet.Tables[0].Rows[0]["InactiveDue"].ToString();
            //    pelak = db.DataSet.Tables[0].Rows[0]["Plaque"].ToString();
            //    txtp1.Text = pelak[0].ToString() + pelak[1].ToString();
            //    txtp2.Text = pelak[2].ToString();
            //    txtp3.Text = pelak[3].ToString() + pelak[4].ToString() + pelak[5].ToString();
            //    txtp4.Text = pelak[7].ToString() + pelak[8].ToString();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            //finally
            //{
            //    db.Dispose();
            //}
            return false;
        }

        private void btnManualAdd_Click(object sender, EventArgs e)
        {
            //if (txtIDCardParking.Text.Trim() == "" && txtNumber.Text.Trim() == "")
            //{
            //    MessageBox.Show("لطفا شماره واحد تجاری و یا شماره کارت پارکینگ را ورد نمائید", "خطا");
            //    txtIDCardParking.Text = "";
            //    txtIDCardParking.ReadOnly = false;
            //    txtNumber.Text = "";
            //    txtNumber.ReadOnly = false;
            //}
            //else
            //{
            //    // انجام عملیات درج براساس شماره واحد تجاری
            //    if (txtNumber.Text.Trim() != "" && txtIDCardParking.Text.Trim() == "")
            //    {
            //        int innum = _JTraffic.InsertManualByNumber(txtNumber.IntValue);
            //        // عملیات با موفقیت انجام شده
            //        if (innum > 0)
            //        {
            //            DisplayAfterOperate(innum, JTrafficForm.TypeGate);
            //            txtIDCardParking.Text = "";
            //            txtIDCardParking.ReadOnly = false;
            //            txtNumber.Text = "";
            //            txtNumber.ReadOnly = false;
            //        }
            //    }
            //    // انجام عملیات درج براساس شماره کارت پارکینگ
            //    if (txtIDCardParking.Text.Trim() != "" && txtNumber.Text.Trim() == "")
            //    {
            //        string _SendFormError = "";
            //        int innum = _JTraffic.InsertManualByParkingCard(txtIDCardParking.IntValue,ref _SendFormError);
            //        // عملیات با موفقیت انجام شده
            //        if (innum > 0)
            //        {
            //            DisplayAfterOperate(innum, JTrafficForm.TypeGate);

            //            txtIDCardParking.Text = "";
            //            txtIDCardParking.ReadOnly = false;
            //            txtNumber.Text = "";
            //            txtNumber.ReadOnly = false;
            //        }
            //    }
            //}
        }



        private void pctcpClient_OnConnect(object sender)
        {
            MessageBox.Show("Client Connected");
            pctcpClient.SendData("hellp");

        }

        private void pctcpClient_OnDisconnect(object sender)
        {
            MessageBox.Show("Client DisConnected");

        }

        private void pctcpClient_OnError(object sender, Exception exception)
        {

        }

        private void pctcpClient_OnReceiveData(object sender, byte[] bytes, string data)
        {
            // 0=tf.IDCard , 1=tf.GroupCard , 2=tf.DateIn , 3=tf.TimeIn , 4=tf.GateIn , 5=tf.UserIn , 6=tf.ShiftIn 
            // 7=tf.DateOut , 8=tf.TimeOut , 9=tf.GateOut , 10=tf.UserOut , 11=tf.ShiftOut , 12=tf.Amount

            string[] Records = data.Split(',');

            txtCard.Text = Records[0];
            txtgroup.Text = Records[1];
            txtDateIn.Text = Records[2];
            txtTimeIn.Text = Records[3];
            // txtIDCardParking.Text = Records[4];
            // txtIDCardParking.Text = Records[5];
            // txtIDCardParking.Text = Records[6];
            txtDateOut.Text = Records[7];
            txtTimeOut.Text = Records[8];
            // txtIDCardParking.Text = Records[9];
            // txtIDCardParking.Text = Records[10];
            // txtIDCardParking.Text = Records[11];
            txtAmount.Text = Records[12];
        }

        private void JTrafficForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pctcpClient.Disconnect();
        }

    }

    public class JTrafficForms : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JParkingStaticNodes._ShowTrafficFormNode());
        }
    }
}
