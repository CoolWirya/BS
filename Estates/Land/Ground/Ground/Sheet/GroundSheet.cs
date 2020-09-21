using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Land.Ground.Ground.Sheet
{
    public class JGroundSheet
    {
        public int Code { get; set; }
        /// <summary>
        /// Ground Code
        /// </summary>
        public int GCode { get; set; }
        /// <summary>
        /// PersonCode
        /// </summary>
        public int PCode { get; set; }
        public float Area { get; set; }
        public DateTime CreateDate { get; set; }
        public int Creator { get; set; }
        public int NumPrint { get; set; }
        public int State { get; set; }
        public int DeActive { get; set; }
        public int Parent { get; set; }
        public int ContractCode { get; set; }
        public int PersonContractCode { get; set; }
    }
}
