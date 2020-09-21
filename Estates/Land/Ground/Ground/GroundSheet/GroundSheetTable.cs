using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates
{
    public class JGroundSheetTable: ClassLibrary.JTable
    {
        public int GCode;
        public int PCode;
        public int ContractCodeSell;
        public int ContractCodeBuy;
        public float Area;
        public DateTime CreateDate;
        public DateTime DeliveryDate;
        public int Creator;
        public int NumPrint;
        public int State;
        public int DeActive;
        public int Parent;
        public float Share;
        public decimal NewContractPrice;
        public JGroundSheetTable()
            : base("estSheet")
        {
            
        }
    }
    enum JGroundSheetEnum
    {
        Code,
        GCode,
        PCode,
        ContractCodeSell,
        ContractCodeBuy,
        Area,
        CreateDate,
        DeliveryDate,
        Creator,
        NumPrint,
        State,
        DeActive,
        Parent,
        Share,
        NewContractPrice,
    }
}
