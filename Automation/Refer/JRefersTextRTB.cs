using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation.Refer
{
    public partial class JRefersTextRTB : UserControl
    {
        public string Rtf
        {
            get
            {
                richTextBox1.Select(0, richTextBox1.Rtf.Length);
                return richTextBox1.SelectedRtf;

            }
        }

        public string NormalText
        {
            get
            {
                return richTextBox1.Text;
            }
        }

        public JRefersTextRTB()
        {
            InitializeComponent();
        }

        public string LoadReferText(int referCode)
        {
            string retS = "";
            if (referCode == 0) return "";

            List<JARefers.ReferInfo> referInfo = (new JARefers()).GetSpecificReferList(referCode);
            retS += "";
            retS +=  referInfo[0].SenderName;
            for (int i = 0; i < referInfo.Count; i++)
            {
                retS += " ) تاریخ ارجاع : " + ClassLibrary.JDateTime.FarsiDateReverse(referInfo[i].Date) + " ( ";
                retS += (referInfo[i].Description.Trim().Length > 0) ? Environment.NewLine + "  : " + referInfo[i].Description + Environment.NewLine : Environment.NewLine;

                retS += Communication.JLetterForm.Tab(referInfo[i].Level) + "-" + referInfo[i].RecieverName;
                retS += (referInfo[i].isRead == true) ? " ) تاریخ مشاهده : " + ClassLibrary.JDateTime.FarsiDateReverse(referInfo[i].ReadDate) + " ( " : "";
            }
            retS += Environment.NewLine;
            return retS;
        }
        
        public void LoadRefer(int referCode)
        {
            if (referCode == 0) return;
            Font font = new Font("B Traffic", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            Font bfont = new Font("B Traffic", 16, FontStyle.Bold, GraphicsUnit.Pixel);

            List<JARefers.ReferInfo> referInfo = (new JARefers()).GetSpecificReferList(referCode);
            richTextBox1.Text = "";
            richTextBox1.SelectedText = "□ " + referInfo[0].SenderName;
            for (int i = 0; i < referInfo.Count; i++)
            {
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectedText = " (تاریخ ارجاع: " + GetFullDate(referInfo[i].Date) + ")";
                richTextBox1.SelectionColor = Color.DarkGreen;
                richTextBox1.SelectedText = (referInfo[i].Description.Trim().Length > 0) ? "\r\n   : " + referInfo[i].Description + "\r\n" : "\r\n";

                if (referInfo[i].Code == referCode)
                    richTextBox1.SelectionFont = bfont;
                else
                    richTextBox1.SelectionFont = font;

                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionIndent = referInfo[i].Level * 10;
                richTextBox1.SelectedText = /*Spaces(referInfo[i].Level) +*/ "□ " + referInfo[i].RecieverName;
                richTextBox1.SelectionColor = Color.DarkBlue;
                richTextBox1.SelectedText = (referInfo[i].isRead == true) ? " (تاریخ مشاهده: " + GetFullDate(referInfo[i].ReadDate) + ")" : "";
            }
            richTextBox1.SelectedText = "\r\n";

            richTextBox1.SelectAll();
            richTextBox1.SelectionFont = font;
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;
        }

        private string GetFullDate(DateTime date)
        {
            return date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + "  " + JDateTime.FarsiDate(date).Substring(2);
        }

        private string Spaces(int x)
        {
            string s = "";
            for (int i = 0; i < x; i++)
            {
                s += "-";
            }
            return s;
        }
    }
}
