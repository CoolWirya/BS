using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;

namespace RealEstate
{
    public class JReportUnitBuild : JSystem
    {
        public JReportUnitBuild()
        {
             //PrimeryOwner = JPrimaryOwnerBuilds.GetDataTable(-1);
            //ShowForm();
        }
        public void ShowForm()
        {
            JReportContractFrom tmp = new JReportContractFrom();
            tmp.ShowDialog();
        }
    }

    public class JReportUnitBuilds : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JREsStaticNode._ReportUnitBuild());
        }
    }
}
