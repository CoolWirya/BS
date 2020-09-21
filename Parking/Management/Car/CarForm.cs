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
    public partial class JCarForm :Globals.JBaseForm
    {
        private JCar _JCar;
        private JCardParking Card;

        public JCarForm(JCar Car)
        {
            InitializeComponent();
         

           

            _JCar = Car;

            Card = new JCardParking();
            Card.GetData(Car.IDCardParking);
            if (Card.Code <= 0)
            {
                JMessages.Error("ابتدا بايد كارت پاركينگ خوئرو مشخص گردد","هشدار");
                this.Close();
            }
           
            this.State = JFormState.Update;
            Grdkhodro.DataSource = _JCar.GetkhodrosOFCard(Card.Code);
           

        }
        public JCarForm(int pIDCardParking)
        {
            InitializeComponent();

            _JCar = new JCar();


            Card = new JCardParking();
            Card.GetData(pIDCardParking);
            _JCar.GetDataByIDCard(Card.Code);




            Grdkhodro.DataSource = _JCar.GetkhodrosOFCard(pIDCardParking);

        }
        private void FillGrid(int pIDCardParking)
        {
             Grdkhodro.DataSource = _JCar.GetkhodrosOFCard(pIDCardParking);
            if (Grdkhodro.Rows.Count > 0)
            {

              _JCar.GetData(Convert.ToInt32(Grdkhodro["Code", 0].Value));
               
                
            }
            
        }
        
       
       
      
       

        
        private void JCarForm_Load(object sender, EventArgs e)
        {
            this.Text = "كارت شماره :" + Card.IDCardParking.ToString();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(Grdkhodro["Code", Grdkhodro.CurrentRow.Index].Value);
            JCar Car = new JCar();
            if (Car.GetData(i))
            {

                if (Car.Delete(Car.Code))
                {
                    FillGrid(Card.Code);
                    Car = new JCar();
                }

            }
        


        }

        private void BtnDefult_Click(object sender, EventArgs e)
        {
            
        }

      
       

        private void BtnNew_Click(object sender, EventArgs e)
        {
           
            JCar car = new JCar();
            OprateCarForm opr = new OprateCarForm(car,Card.Code);
            opr.ShowDialog();

            Grdkhodro.DataSource = _JCar.GetkhodrosOFCard(Card.Code);
        }

        private void Grdkhodro_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(Grdkhodro["Code", Grdkhodro.CurrentRow.Index].Value);
                if (_JCar.GetData(i))
                {
                    OprateCarForm opr = new OprateCarForm(_JCar, Card.Code);
                    opr.ShowDialog();
                }
            }
            catch
            {

            }
        }
        
       
        

        

        

       
    }
}
