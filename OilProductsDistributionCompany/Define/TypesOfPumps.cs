using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilProductsDistributionCompany.Define
{
    public class JTypesOfPump : ClassLibrary.JSubBaseDefine
    {

        public int Code { get; set; }
        public string Name { get; set; }
        public int NumberOfNozzles { get; set; }

        public JTypesOfPump()
            : base(JDefine.TypeOfPumps)
        {
        }


    }


    public class JTypesOfPumps : ClassLibrary.JSubBaseDefines
    {
        public JTypesOfPumps()
            : base(JDefine.TypeOfPumps)
        {
        }
    }


}
