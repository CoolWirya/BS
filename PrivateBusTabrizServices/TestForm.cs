using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateBusTabrizServices
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        Timer t = new Timer();
        AVLService S = new AVLService();
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            t.Tick += new EventHandler(TimerProcess);
            t.Interval = 1000;
            t.Start();
            AVLService S = new AVLService();
            S.Start();
        }

        private void TimerProcess(object sender, EventArgs e)
        {
            try
            {
                label1.Text =
                    "Socket Check Data AVL Thread:" + BusManagment.Transaction.JTransactions.SocketCheckDataAVLThread.ToString() +
                    Environment.NewLine +
                    "Open DataBase:" + ClassLibrary.JDataBase.dbsOpen.Count.ToString() +
                    Environment.NewLine +
                    "Open MySql DataBase:" + ClassLibrary.JMySQLDataBase.Counter.ToString() +
                    Environment.NewLine +
                    "MySql Packet inProcess:" + BusManagment.Transaction.JTransactions.MySQLCounter.ToString() +
                    Environment.NewLine +
                    "DelayMessageUpdate:" + BusManagment.Transaction.JTransactions.DelayMessageUpdate +
                    Environment.NewLine +
                    "DelayMessageProcess:" + BusManagment.Transaction.JTransactions.DelayMessageProcess +
                    Environment.NewLine +
                    "DelayMessageSaveAVL:" + BusManagment.Transaction.JTransactions.DelayMessageSaveAVL
                    ;
            }catch(Exception ex)
            {
            }
        }

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            S.Stop();
            button2.Enabled = false;
            button1.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
