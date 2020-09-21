using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares
{
    /// <summary>
    /// حاضرین در مجمع
    /// </summary>
    public class JShareAssembly
    {
        public int AssemblyCode;

        public JShareAssembly(int pAssemblyCode)
        {
            AssemblyCode = pAssemblyCode;
        }

        public ClassLibrary.JNode GetNode(System.Data.DataRow pRow)
        {
            ClassLibrary.JNode Node = new ClassLibrary.JNode((int)pRow["Code"], "ManagementShares.JShareAssembly");
            Node.MouseDBClickAction = new ClassLibrary.JAction();
            return Node;
        }
    }

    public class JShareAssemblies : ClassLibrary.JSystem
    {
        public int AssemblyCode;

        public JShareAssemblies(int pAssemblyCode)
        {
            AssemblyCode = pAssemblyCode;
        }

        public System.Data.DataTable GetData()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(
                        @"SELECT SHA.Code,CAP.Code PCode,CAP.Name,SHA.PrintVote,SHA.present,SHA.Share,SHA.Id from ShareholdersAssembly SHA
                        inner join clsAllPerson CAP on SHA.PCode = CAP.Code
                        inner join ShareAssemblies SA on SHA.CCode = SA.Code
                        WHERE SA.Code=" + AssemblyCode.ToString()
                    );
                return DB.Query_DataTable();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }

        public void Refresh()
        {
            if (ClassLibrary.JMessages.Confirm("آیا مطمئا هستید", "هشدار") == System.Windows.Forms.DialogResult.OK)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery(
//                            @"delete from ShareholdersAssembly where CCode = " + AssemblyCode.ToString() + 
@"
insert into ShareholdersAssembly
select " + AssemblyCode.ToString() + @"*10000000+ACode,
(select PCode FROM ShareAgent WHERE Code = ACode),
" + AssemblyCode.ToString() + @",
SUM(ShareCount),
0,
0,
(ROW_NUMBER() OVER (order by CP.Name))
from ShareSheet SS
inner join ShareAgent SA on SA.Code = ACode
inner join clsAllPerson CP on SA.PCode = CP.code
where SS.Status=1 AND ACode is not null
group by ACode,CP.Name
order by CP.Name"
                        );
                    DB.Query_Execute();
                    Nodes.DataTable = GetData();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    DB.Dispose();
                }
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = null;
            Nodes.DataTable = GetData();

            ClassLibrary.JToolbarNode TN = new ClassLibrary.JToolbarNode();
            TN.Click = new ClassLibrary.JAction("ShareAssemblies", "ManagementShares.JShareAssemblies.Refresh", null, new object[] { AssemblyCode });
            TN.Icon = ClassLibrary.JImageIndex.Relation;


            ClassLibrary.JToolbarNode TNPresent = new ClassLibrary.JToolbarNode();
            TNPresent.Click = new ClassLibrary.JAction("ShareAssemblies", "ManagementShares.JPresentSetForm.ShowDialog", null, new object[] { AssemblyCode });
            TNPresent.Icon = ClassLibrary.JImageIndex.Activity;

            ClassLibrary.JToolbarNode TNPresentShow = new ClassLibrary.JToolbarNode();
            TNPresentShow.Click = new ClassLibrary.JAction("ShareAssembliesShow", "ManagementShares.JMainAssembliesForm.ShowDialog", null, new object[] { AssemblyCode });
            TNPresentShow.Icon = ClassLibrary.JImageIndex.Activity;


            Nodes.AddToolbar(TN);
            Nodes.AddToolbar(TNPresent);
            Nodes.AddToolbar(TNPresentShow);
            
        }
    }

}
