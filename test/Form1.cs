using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BusManagment.Transaction.JTicketTransactions.ReadDataTableFromFile(new string[] { textBox1.Text },100, true);
            ClassLibrary.JSQLiteDataBase SQLiteDB = null;
            DataTable SQLiteDT = null;
            DataTable TicketDT = null;
            int trueint = 0;
            int falseint = 0;

            ClassLibrary.JConnection C = new ClassLibrary.JConnection();

            SQLiteDB = new ClassLibrary.JSQLiteDataBase(C.GetSQLiteConnection(textBox1.Text));

            SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\" ORDER BY \"index\" desc;");
            SQLiteDT = SQLiteDB.Query_DataTable();

            BusManagment.Transaction.JTransactions.ProcessSqliteDataTable(SQLiteDT, ref TicketDT
                , ref trueint, ref falseint);
        }
    }
}
