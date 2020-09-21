using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Bascol
{
    public class JEmptyWeightTable : JTable
    {
        public JEmptyWeightTable()
            : base("BascolEmptyWeights")
        {
        }
        #region Property
        /// <summary>
        /// شماره باسکول توزین فعلی 
        /// </summary>
        public int BascoolNo;
        /// <summary>
        /// شماره سریال توزین فعلی 
        /// </summary>
        public int WeightID;
        /// <summary>
        /// شماره باسکول توزین قبلی 
        /// </summary>
        public int EmptyBascoolNo;
        /// <summary>
        /// شماره سریال توزین قبلی 
        /// </summary>
        public int WeightSerial;
        /// <summary>
        /// تاریخ توزین 
        /// </summary>
        public DateTime DateWeight;
        /// <summary>
        /// وزن  
        /// </summary>
        public decimal EmptyWeight;
        /// <summary>
        ///  
        /// </summary>
        public int EmptyID;
        #endregion
    }
}
