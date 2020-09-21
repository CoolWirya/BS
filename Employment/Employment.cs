using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JEmployment: JSystem
    {
        public void ListView()
        {
            //if (CheckPermissionMenu())
            //{
                Nodes.Insert(JEStaticNode._BaseDefineNode(JCompanyEmployee.CurrentCompany()));
                //Nodes.Insert(JEStaticNode._PersonOrganizationPost());
                //Nodes.Insert(JEStaticNode._Contracts());
                //Nodes.Insert(JEStaticNode._EmployeeInfo());
                //Nodes.Insert(JEStaticNode._JobTitleInfo());
                //Nodes.Insert(JEStaticNode._PostTitleInfo());
                Nodes.Insert(JEStaticNode._VacationPermissions());
                //Nodes.Insert(JEStaticNode._Report());
                //Nodes.Insert(JEStaticNode._ReportDetail());
            //}                
            //Nodes.Insert(JEStaticNode.JVacations());
            Nodes.Insert(JEStaticNode._Help());

        }

        public JNode[] TreeView()
        {
            JNode[] nodes = new JNode[0];
            //if (CheckPermissionMenu())
            //{
                nodes = JEStaticNode._ShareComanies();
                //N[0] = JEStaticNode._BaseDefineNode();
                ////N[1] = JEStaticNode._PersonOrganizationPost();
                //N[1] = JEStaticNode._Contracts();                
                //N[3] = JEStaticNode._EmployeeInfo();
                //N[4] = JEStaticNode._JobTitleInfo();
                //N[5] = JEStaticNode._PostTitleInfo();
                //N[6] = JEStaticNode._VacationPermissions();
                //N[7] = JEStaticNode._Report();
                //N[9] = JEStaticNode._ReportDetail();
            //}
            //Array.Resize(ref nodes, nodes.Length + 1);
            //nodes[nodes.Length - 1] = JEStaticNode.JVacations();

            Array.Resize(ref nodes, nodes.Length + 1);
            nodes[nodes.Length - 1] = JEStaticNode._Help();

            //nodes[2] = JEStaticNode.JVacations();
            //nodes[8] = JEStaticNode._Help();

            //tmp.Dispose();

            return nodes;
        }
    }
}
