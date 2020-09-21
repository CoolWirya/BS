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
    public partial class JTraficForm : ClassLibrary.JBaseForm
    {
        public JTraficForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void ShowForm()
        {
            // if (JPermission.CheckPermission("Parking.JTrafficForm.ShowForm"))
            ShowDialog();
        }

        private void JTraficForm_Load(object sender, EventArgs e)
        {
            pctcpClient.Connect("192.168.0.1", 1200);
        }

        private void pctcpClient_OnConnect(object sender)
        {

        }

        private void pctcpClient_OnDisconnect(object sender)
        {
            pctcpClient.Disconnect();
        }

        private void pctcpClient_OnError(object sender, Exception exception)
        {

        }

        private void pctcpClient_OnReceiveData(object sender, byte[] bytes, string data)
        {
            // 0=tf.IDCard , 1=tf.GroupCard , 2=tf.DateIn , 3=tf.TimeIn , 4=tf.GateIn , 5=tf.UserIn , 6=tf.ShiftIn 
            // 7=tf.DateOut , 8=tf.TimeOut , 9=tf.GateOut , 10=tf.UserOut , 11=tf.ShiftOut , 12=tf.Amount

            string[] Records = data.Split(',');

            //txtCard.Text = Records[0];
            //txtgroup.Text = Records[1];
            //txtDateIn.Text = Records[2];
            //txtTimeIn.Text = Records[3];

                // txtIDCardParking.Text = Records[4];
                // txtIDCardParking.Text = Records[5];
                // txtIDCardParking.Text = Records[6];

            //txtDateOut.Text = Records[7];
            //txtTimeOut.Text = Records[8];

                // txtIDCardParking.Text = Records[9];
                // txtIDCardParking.Text = Records[10];
                // txtIDCardParking.Text = Records[11];
            //txtAmount.Text = Records[12];
        }

    }


    public class JTraficForms : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JParkingStaticNodes._ShowTraficFormNode());
        }
    }

}
