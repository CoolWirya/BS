using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JEBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(GetNode(MetierCode));
            Nodes.Insert(JEStaticNode._WorkShifts());
            Nodes.Insert(JEStaticNode._Activity());
            Nodes.Insert(JEStaticNode._ChartsNodes());
            Nodes.Insert(JEStaticNode._OrganizationChart());
            Nodes.Insert(JEStaticNode._DegreeType());
            Nodes.Insert(JEStaticNode._HouseStateType());
            Nodes.Insert(JEStaticNode._FieldType());
            Nodes.Insert(JEStaticNode._MilitaryType());
            Nodes.Insert(JEStaticNode._WorkTimeType());
            Nodes.Insert(JEStaticNode._PersonelContractType());
            Nodes.Insert(JEStaticNode._WorkPlaceType());
            Nodes.Insert(JEStaticNode._CalcType());
            Nodes.Insert(JEStaticNode._SeparationType());            
        }

        public JNode[] TreeView(int pCompanyCode)
        {
            JNode[] gNodes = new JNode[15];
            gNodes[0] = GetNode(MetierCode);
            gNodes[1] = JEStaticNode._ChartsNodes();
            gNodes[2] = JEStaticNode._OrganizationChart();
            gNodes[3] = JEStaticNode._WorkShifts();
            gNodes[4] = JEStaticNode._Activity();
            gNodes[5] = JEStaticNode._DegreeType();
            gNodes[6] = JEStaticNode._HouseStateType();
            gNodes[7] = JEStaticNode._FieldType();
            gNodes[8] = JEStaticNode._MilitaryType();
            gNodes[9] = JEStaticNode._WorkTimeType();
            gNodes[10] = JEStaticNode._PersonelContractType();
            gNodes[11] = JEStaticNode._WorkPlaceType();
            gNodes[12] = JEStaticNode._CalcType();
            gNodes[13] = JEStaticNode._SeparationType();
            gNodes[14] = JEStaticNode._KaranehRange();
            return gNodes;
        }
    }

    public class JESubBaseDefine : JSubBaseDefine
    {
        public JESubBaseDefine(int pBCode)
            : base(pBCode)
        {
        }
    }

    public class JESubBaseDefines : JSubBaseDefines
    {
        public JESubBaseDefines(int pBCode)
            : base(pBCode)
        {
        }

    }

    public class JVacations : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JEStaticNode._VacationTime());
            Nodes.Insert(JEStaticNode._VacationDaily());
            Nodes.Insert(JEStaticNode._ConfirmWork());
            Nodes.Insert(JEStaticNode._SearchVacationNode());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[4];
            gNodes[0] = JEStaticNode._VacationTime();
            gNodes[1] = JEStaticNode._VacationDaily();
            gNodes[2] = JEStaticNode._ConfirmWork();
            gNodes[3] = JEStaticNode._SearchVacationNode();
            return gNodes;
        }
    }
}
