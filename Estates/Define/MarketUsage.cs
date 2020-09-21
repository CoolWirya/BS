using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JDefineMarketUsage : JSubBaseDefine
    {
        public JDefineMarketUsage()
            : base(JBaseDefine.MarketUsage)
        {
        }
    }

    public class JDefineMarketUsages : JSubBaseDefines
    {
        public JDefineMarketUsages()
            : base(JBaseDefine.MarketUsage)
        {
        }
    }
}
