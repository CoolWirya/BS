using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTOMOBILE.AutomobileDefine
{
    public class JMakerCompany : ClassLibrary.JSubBaseDefine
    {
        public JMakerCompany()
            : base(ClassLibrary.JBaseDefine.MakerCompany)
        {
        }
    }


    public class JMakerCompanies : ClassLibrary.JSubBaseDefines
    {
        public JMakerCompanies()
            : base(ClassLibrary.JBaseDefine.MakerCompany)
        {
        }
    }
}
