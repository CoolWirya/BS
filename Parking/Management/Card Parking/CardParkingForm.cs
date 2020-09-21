using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using SmartCards;
using TCCORFID;
using Legal;

namespace Parking
{
    public partial class JCardParkingForm : Globals.JBaseForm
    {
        private JCardParking ParkingService;
        string CardRfidstr = "";
        int stage;
        int _Market;
        byte[] ID;
        JElectronicCard El;
        JSellerCard CardSeller;
        JCustomerCard Custromercard;
        JPersonalCard CardPerson;
        string IP = "";

        public void FillComboBox(int Market)
        {
            JGroupCard Group = new JGroupCard();
            cmbGroupCard.DataSource = Group.ShowData("", Market);
            cmbGroupCard.DisplayMember = "TypeGroup";
            cmbGroupCard.ValueMember = "Code";
            cmbGroupCard.Text = "";
            _Market=Market;
            JDueToInactivity due = new JDueToInactivity();
            due.SetComboBox(cmbDeactive);
        }

        public JCardParkingForm(int Code, int Market)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            JCardParking Par = new JCardParking();
            FillComboBox(Market);
            El = new JElectronicCard(Code);

            if (El.Code > 0)
            {
                ChkElectronicState();
                Par.GetDataId(Code);
            }
            else
            {
                JMessages.Error("Please Define ElectronicCard", "Error");
                this.Close();
            }
            ParkingService = Par;
            if (ParkingService.Code > 0)
            {
                State = JFormState.Update;
                btnDefineCar.Enabled = true;
                Display();
            }
            else
            {
                ParkingService = new JCardParking();

                State = JFormState.Insert;
                chkEnableService.Checked = false;

            }
        }

        private void ChkElectronicState()
        {
            txtIDCardParking.Text = El.IDCardParking.ToString();
            if ((Int32)SmartCards.TypeCard.Sellers == El.TypeCard)
            {
                CardSeller = new JSellerCard();
                if (!CardSeller.GetDataId(El.Code))
                {
                    JMessages.Error("Please Define Sellers Records", "Error");
                    this.Close();
                }
            }
            if ((Int32)SmartCards.TypeCard.Custromers == El.TypeCard)
            {
                Custromercard = new JCustomerCard();
                if (!Custromercard.GetDataId(El.Code))
                {
                    JMessages.Error("Please Define Custromer Records", "Error");
                    this.Close();
                }
                grpDetail.Visible = false;
            }
            if ((Int32)SmartCards.TypeCard.Persons == El.TypeCard)
            {
                CardPerson= new JPersonalCard();
                if (!CardPerson.GetDataId(El.Code))
                {
                    JMessages.Error("Please Define Person Records", "Error");
                    this.Close();
                }
         
            }
        }
        private void Display()
        {
            chkEnableService.Checked = true;
            cmbDeactive.SelectedValue = Convert.ToInt32(ParkingService.InactiveDue);
            chkStatus.Checked = !ParkingService.StatusParking;
            cmbGroupCard.SelectedValue = Convert.ToInt32(ParkingService.CodeGroup);
        }
        private  bool FormatCard(Segments Seg)
        {
            try
            {
                #region This region added at 1390/10/05 to rigster ID,FName & LAname to parcking card
                {
                    Seg.AddFieldWithValue("ID", Segments.FieldType.UInt32, 0); //4
                    Seg.AddFieldWithValue("FName", Segments.FieldType.String, "کارت", 20); //20
                    Seg.AddFieldWithValue("LName", Segments.FieldType.String, "پارکینگ", 24);//24
                }
                #endregion
                Seg.AddField("GroupNo", Segments.FieldType.Byte);
                Seg.AddField("EnterParkingNo", Segments.FieldType.UInt16);
                Seg.AddField("ExitParkingNo", Segments.FieldType.UInt16);
                Seg.AddField("EnterDateY", Segments.FieldType.Byte);
                Seg.AddField("EnterDateM", Segments.FieldType.Byte);
                Seg.AddField("EnterDateD", Segments.FieldType.Byte);
                Seg.AddField("EnterTimeH", Segments.FieldType.Byte);
                Seg.AddField("EnterTimeM", Segments.FieldType.Byte);
                Seg.AddField("EnterTimeS", Segments.FieldType.Byte);
                Seg.AddField("ExitDateY", Segments.FieldType.Byte);
                Seg.AddField("ExitDateM", Segments.FieldType.Byte);
                Seg.AddField("ExitDateD", Segments.FieldType.Byte);
                Seg.AddField("ExitTimeH", Segments.FieldType.Byte);
                Seg.AddField("ExitTimeM", Segments.FieldType.Byte);
                Seg.AddField("ParkingCost", Segments.FieldType.UInt32);
                Seg.AddField("Charge", Segments.FieldType.Charge);
                Seg.AddField("IsCarInParking", Segments.FieldType.Boolean);
                Seg.AddField("ExpireDateY", Segments.FieldType.Byte);
                Seg.AddField("ExpireDateM", Segments.FieldType.Byte);
                Seg.AddField("ExpireDateD", Segments.FieldType.Byte);
                Seg.AddField("TreatyExpireDateY", Segments.FieldType.Byte);
                Seg.AddField("TreatyExpireDateM", Segments.FieldType.Byte);
                Seg.AddField("TreatyExpireDateD", Segments.FieldType.Byte);
                Seg.AddField("IsCardActive", Segments.FieldType.Boolean);

                Seg.AddField("PersonnelCode", Segments.FieldType.UInt32);
                Seg.AddField("AssetCode", Segments.FieldType.UInt32);
                Seg.AddField("TreatyCode", Segments.FieldType.UInt32);
                Seg.AddField("IsManager", Segments.FieldType.Boolean);
                Seg.AddField("Password", Segments.FieldType.UInt16);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private void JCardParkingForm_Load(object sender, EventArgs e)
        {
            tccoRFID.Start();
            grpDetail.Enabled = true;
            JAllPerson person;
           
            switch (El.TypeCard)
            {
                case (Int32)TypeCard.Sellers:
                    grpDetail.Enabled = true;
                    person = new JAllPerson(CardSeller.IdPerson);
                    Finance.JAsset Asset = new Finance.JAsset(CardSeller.IDAsset);
                    LblAsset.Text = LblAsset.Text + Asset.Comment;
                    lblPerson.Text = lblPerson.Text + person.Name;
                    txtExpireDate.Text = JDateTime.FarsiDate(CardSeller.EndDateContract);
                    
                    if (txtExpireDate.Text == "    /  /") txtExpireDate.Text = JDateTime.FarsiDate(El.DateExpire);
                       
                   
                    break;

                case (Int32)TypeCard.Custromers:
                      txtExpireDate.Text = JDateTime.FarsiDate(El.DateExpire);
                    break; 
                case (Int32)TypeCard.Persons:
                      txtExpireDate.Text = JDateTime.FarsiDate(CardPerson.EndDateContract);
                       person = new JAllPerson(CardPerson.IdPerson);
                       lblPerson.Text = lblPerson.Text + person.Name + " " + person.Name;
                       LblAsset.Text = CardPerson.Post;
                    break;
                    
            }
           
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbDeactive.Enabled = chkStatus.Checked;
            cmbDeactive.SelectedValue = 0;
        }
        private Boolean Save()
        {
            try
            {
               
               ParkingService.CodeGroup = Convert.ToInt32(cmbGroupCard.SelectedValue);
               JDataBase jdbtIME=new JDataBase();
               ParkingService.DateActive = jdbtIME.GetCurrentDateTime();

               ParkingService.DateExpire = txtExpireDate.Date;
               ParkingService.IDCardParking = El.Code;
               ParkingService.InactiveDue = Convert.ToInt32(cmbDeactive.SelectedValue);
               ParkingService.StatusParking = !chkStatus.Checked;
               if (State == JFormState.Insert)
               {
                   int Code = ParkingService.Insert();
                   if (Code > 0)
                   {
                     
                       JServicesCard Card = new JServicesCard();
                       Card.AddServiceToCard(ParkingService.IDCardParking, ParkingService.DateExpire, ServiceType.Parking, "فعال سازي خدمات پاركينگ");
                   }
                   else
                   {
                       JMessages.Information("Insert Not Succefully", "Alert");
                   }
               }
               else
               {
                   if (ParkingService.Update())
                   {
                       JMessages.Information("Update Succefully", "Alert");
                       JServicesCard Card = new JServicesCard();
                       Card.AddServiceToCard(ParkingService.IDCardParking, ParkingService.DateExpire, ServiceType.Parking, "تغيير در اطلاعات خدمات پاركينگ");
                   }
                   else
                   {
                       JMessages.Information("Update Not Succefully", "Alert");
                   }
               }
               return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
       

        private void BtnApplay_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                JServicesCard Card = new JServicesCard();
                if (Card.AddServiceToCard(ParkingService.IDCardParking, ParkingService.DateExpire, ServiceType.Parking, ""))
                    btnWrite.Enabled = true;
                
            }
            
        }

        private void btnDefineCar_Click(object sender, EventArgs e)
        {
            JCarForm Cars = new JCarForm(ParkingService.Code);
            Cars.ShowDialog();
        }

        private void chkEnableService_CheckedChanged(object sender, EventArgs e)
        {
            GrpParking.Enabled = chkEnableService.Checked;
        }

        private void BtnShowTraffic_Click(object sender, EventArgs e)
        {
            JcardHistory Prk = new JcardHistory(Convert.ToInt64(El.RfidNumber));
            Prk.ShowDialog();

            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void SaveParkingCardInfo()
        {
            try
            {
                string deviceIP = IP;
                JElectronicCard ElCard = new JElectronicCard();
              
                System.Data.DataTable DtParking = ParkingService.ShowparkingData(El.IDCardParking,_Market);
                ElCard.GetData(Convert.ToInt32(DtParking.Rows[0]["Code"]));
                JGroupCard Grp = new JGroupCard(Convert.ToInt32(DtParking.Rows[0]["CodeGroup"]));
                DateTime dt;
               
                UInt32 idcard=Convert.ToUInt32(DtParking.Rows[0]["IDCardParking"]);
                ID=BitConverter.GetBytes((UInt32)idcard);

                switch (Convert.ToInt32(DtParking.Rows[0]["TypeCard"].ToString()))
                {
                    case (Int32)TypeCard.Custromers:
                        {
                            tccoRFID.CardReaders[deviceIP].Segments.SetByteData(ID, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString("کارت", 4, 16);
                            tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString("پارکینگ", 20, 21);
                            tccoRFID.CardReaders[deviceIP].Segments[0].ForWrite = true;
                            tccoRFID.CardReaders[deviceIP].Segments[1].ForWrite = true;
                            tccoRFID.CardReaders[deviceIP].Segments[2].ForWrite = true;

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("GroupNo", Segments.FieldType.Byte, Convert.ToDecimal(Grp.GroupNumber));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterParkingNo", Segments.FieldType.UInt16, Convert.ToDecimal(DtParking.Rows[0]["Market"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitParkingNo", Segments.FieldType.UInt16, Convert.ToDecimal(DtParking.Rows[0]["Market"]));
                            dt = DateTime.Now.Date;
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateD", Segments.FieldType.Byte, dt.Day);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeH", Segments.FieldType.Byte, dt.Hour);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeM", Segments.FieldType.Byte, dt.Minute);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeS", Segments.FieldType.Byte, dt.Second);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateD", Segments.FieldType.Byte, dt.Day);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeH", Segments.FieldType.Byte, dt.Hour);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeM", Segments.FieldType.Byte, dt.Minute);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ParkingCost", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCarInParking", Segments.FieldType.Boolean, false);


                            dt = Convert.ToDateTime(DtParking.Rows[0]["DateExpire"]);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateD", Segments.FieldType.Byte, dt.Day);

                            // تاريخ اتمام قرارداد
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateD", Segments.FieldType.Byte, dt.Day);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCardActive", Segments.FieldType.Boolean, Convert.ToBoolean(DtParking.Rows[0]["StatusParking"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("PersonnelCode", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("AssetCode", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyCode", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsManager", Segments.FieldType.Boolean, false);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("Password", Segments.FieldType.UInt16, 0);
                            break;
                        }

                    case (Int32)TypeCard.Masters:
                        break;

                    case (Int32)TypeCard.Persons:
                        {
                            tccoRFID.CardReaders[deviceIP].Segments.SetByteData(ID, 0);

                            if (DtParking.Rows[0]["Name"].ToString() != "---")
                            {
                                tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString(DtParking.Rows[0]["Name"].ToString(), 4, 16);
                                tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString(DtParking.Rows[0]["Fam"].ToString(), 20, 21);
                            }
                            else
                            {
                                tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString("شركت", 4, 16);
                                tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString(DtParking.Rows[0]["FullName"].ToString(), 20, 21);
                            }
                            tccoRFID.CardReaders[deviceIP].Segments[0].ForWrite = true;
                            tccoRFID.CardReaders[deviceIP].Segments[1].ForWrite = true;
                            tccoRFID.CardReaders[deviceIP].Segments[2].ForWrite = true;

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("GroupNo", Segments.FieldType.Byte, Convert.ToDecimal(Grp.GroupNumber));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterParkingNo", Segments.FieldType.UInt16, Convert.ToDecimal(DtParking.Rows[0]["Market"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitParkingNo", Segments.FieldType.UInt16, Convert.ToDecimal(DtParking.Rows[0]["Market"]));

                            dt = DateTime.Now.Date;
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateD", Segments.FieldType.Byte, dt.Day);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeH", Segments.FieldType.Byte, dt.Hour);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeM", Segments.FieldType.Byte, dt.Minute);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeS", Segments.FieldType.Byte, dt.Second);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateD", Segments.FieldType.Byte, dt.Day);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeH", Segments.FieldType.Byte, dt.Hour);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeM", Segments.FieldType.Byte, dt.Minute);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ParkingCost", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCarInParking", Segments.FieldType.Boolean, false);


                            dt = Convert.ToDateTime(DtParking.Rows[0]["DateExpire"]);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateD", Segments.FieldType.Byte, dt.Day);

                            // تاريخ اتمام قرارداد
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateD", Segments.FieldType.Byte, dt.Day);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCardActive", Segments.FieldType.Boolean, Convert.ToBoolean(DtParking.Rows[0]["StatusParking"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("PersonnelCode", Segments.FieldType.UInt32, Convert.ToDecimal(DtParking.Rows[0]["idPerson"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("AssetCode", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyCode", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsManager", Segments.FieldType.Boolean, false);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("Password", Segments.FieldType.UInt16, 0);
                            break;
                        }

                    case (Int32)TypeCard.Sellers:
                        {
                            tccoRFID.CardReaders[deviceIP].Segments.SetByteData(ID, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString(DtParking.Rows[0]["Name"].ToString(), 4, 16);
                            tccoRFID.CardReaders[deviceIP].Segments.SetUnicodeString(DtParking.Rows[0]["Fam"].ToString(), 20, 21);

                            tccoRFID.CardReaders[deviceIP].Segments[0].ForWrite = true;
                            tccoRFID.CardReaders[deviceIP].Segments[1].ForWrite = true;
                            tccoRFID.CardReaders[deviceIP].Segments[2].ForWrite = true;

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("GroupNo", Segments.FieldType.Byte, Convert.ToDecimal(Grp.GroupNumber));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterParkingNo", Segments.FieldType.UInt16, Convert.ToDecimal(DtParking.Rows[0]["Market"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitParkingNo", Segments.FieldType.UInt16, Convert.ToDecimal(DtParking.Rows[0]["Market"]));

                            dt = DateTime.Now.Date;
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateD", Segments.FieldType.Byte, dt.Day);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeH", Segments.FieldType.Byte, dt.Hour);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeM", Segments.FieldType.Byte, dt.Minute);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeS", Segments.FieldType.Byte, dt.Second);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateD", Segments.FieldType.Byte, dt.Day);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeH", Segments.FieldType.Byte, dt.Hour);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeM", Segments.FieldType.Byte, dt.Minute);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ParkingCost", Segments.FieldType.UInt32, 0);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCarInParking", Segments.FieldType.Boolean, false);

                            object value = DtParking.Rows[0]["EndDateContract"];
                           
                           
                            if (value != DBNull.Value)
                            {
                                dt = Convert.ToDateTime(DtParking.Rows[0]["EndDateContract"]);
                                
                                
                            }
                            else
                            {
                                dt = Convert.ToDateTime(DtParking.Rows[0]["DateExpire"]);

                            }
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateD", Segments.FieldType.Byte, dt.Day);

                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateM", Segments.FieldType.Byte, dt.Month);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateD", Segments.FieldType.Byte, dt.Day);
                            ElCard.DateExpire = dt;
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCardActive", Segments.FieldType.Boolean, Convert.ToBoolean(DtParking.Rows[0]["StatusParking"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("PersonnelCode", Segments.FieldType.UInt32, Convert.ToDecimal(DtParking.Rows[0]["idPerson"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("AssetCode", Segments.FieldType.UInt32, Convert.ToDecimal(DtParking.Rows[0]["IDAsset"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyCode", Segments.FieldType.UInt32, Convert.ToDecimal(DtParking.Rows[0]["IDContract"]));
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsManager", Segments.FieldType.Boolean, false);
                            tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("Password", Segments.FieldType.UInt16, 0);
                            break;
                        }
                }
                if (tccoRFID.WriteData(deviceIP))
                {
                    ElCard.RfidNumber = CardRfidstr;
                    ElCard.Update();
                }
            }
            catch
            {
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                JServicesCard Card = new JServicesCard();
                if (Card.AddServiceToCard(ParkingService.IDCardParking, ParkingService.DateExpire, ServiceType.Parking, ""))
                    SaveParkingCardInfo();
                else
                    SaveParkingCardInfo();
                JMessages.Information("Insert Succefully", "Alert");
            }
            
        }

        private void tccoRFID_OnDeviceConnect(string deviceIP)
        {
            IP = deviceIP;
           LblDevice.Text = deviceIP;
        }

        private uint byteArray2Int(byte[] bytes)
        {
            return BitConverter.ToUInt32(bytes, 0); 
        }

        private void tccoRFID_OnReceiveCard(string deviceIP, byte[] cardRFID)
        {
            FormatCard(tccoRFID.CardReaders[deviceIP].Segments);
            tccoRFID.ReadData(deviceIP);
            CardRfidstr = byteArray2Int(cardRFID).ToString();
        }

        private string BytesToHexString(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
                str += Add0(Convert.ToString(bytes[i], 16), 2) + " ";
            return str.ToUpper();
        }

        private string Add0(string str, int length)
        {
            while (str.Length < length) str = "0" + str;
            return str;
        }

        private void tccoRFID_OnReceiveCardData(string deviceIP, Segments segments)
        {
            stage++;
            //if (State == JFormState.Update) btnWrite.Enabled = true;
            btnWrite.Enabled = true;
        }

        private void tccoRFID_OnWriteDataSuccessfullyFinish(string deviceIP, Segments segments)
        {
            tccoRFID.EndSession(IP);
            btnWrite.Enabled = false;
        }

        private void JCardParkingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           tccoRFID.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tccoRFID.EndSession(IP);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tccoRFID.Disconnect();
            FrmSetDeviceCaed Frm = new FrmSetDeviceCaed();
           
            Frm.ShowDialog();
            Frm.Dispose();
            tccoRFID.Start();
        }

        private void grpdevice_Enter(object sender, EventArgs e)
        {

        }
        
    }
    
}
