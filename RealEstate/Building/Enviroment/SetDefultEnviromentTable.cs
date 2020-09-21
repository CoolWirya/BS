using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class JSetDefultEnviromentTable : JTable
    {
       
        /// <summary>11212
        /// كد مجتمع
        /// </summary>
        public int MarketCode = 0;
        /// <summary>11212
        /// كد نماينده
        /// </summary>
        public int Person = 0;
        /// <summary>11212
        /// نماينده قرارداد
        /// </summary>
        public int PrimaryOwnerPerson = 0;

        public JSetDefultEnviromentTable()
            : base(JRETableNames.EnviromentOwner)
        {
        }
    }
}
