using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication.Letter
{
    public class JCLetterCopyTable : JTable
    {
        public JCLetterCopyTable()
            : base("LetterCopy")
        {
        }

        public int letter_code;
        public int copy_type;
        public int receiver_post_code;
        public int receiver_user_code;
        public string receiver_full_title;
        public int receiver_external_code;
        public int receiver_subsidiaries_code;
        public string copy_reason;
        public int register_post_code;
        public int register_user_code;
        public string register_full_title;
        public int send_type;
        public DateTime respite_date_time;

    }
}
