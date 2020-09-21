using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JEnviromentTable : JTable
    {
        public int CodeEnviroment = 0;
        public int TypeEnviroment = 0;
        public decimal Area = 0;
        public decimal moneyBaseCharge = 0;
        public int Complex = 0;
        public string Address = "";
        public decimal moneyBase = 0;
        public int state = 0;
        public string NameEnviroment = "";
        public bool ISArchive = false;
        public int CodeFloor = 0;
        public int Door = 0;
        public int Tafsili = 0;
        public JEnviromentTable()
            : base(JRETableNames.EnviromentTable)
        {
        }
    }
}
