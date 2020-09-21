using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublicBusTabrizService
{
    public partial class Form1 : Form
    {
        PublicBusTabrizService P = new PublicBusTabrizService();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //(new BusManagment.TransactionPublic.JTransactions()).CheckDataSQLiteTicket();
            P.AVLServiceForm();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            P.AVLServiceForm_FormClosed(P);
        }
    }
}
