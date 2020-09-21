using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal.Contract
{
    /// <summary>
    ///  انواع قرارداد
    /// </summary>
    enum JContractType
    {
    }

    /// <summary>
    /// طرفین
    /// </summary>
    public class JParties :JLegal
    {
        int User1;
        int Organization1;

        int User2;
        int Organization2;
    }

}
