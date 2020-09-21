using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassLibrary;
using Globals;

namespace Globals
{
    /// <summary>
    /// 
    /// </summary>
    public class JPermission : JSystem
    {
        /// <summary>
        /// 
        /// </summary>
        public JPermission()
        {

        }

        public int SetAccess(string pClassName, string pDecissionName, int pObjectCode, int pUserPostCode)
        {
            return SetAccess(pClassName, pDecissionName, pObjectCode, pUserPostCode, DateTime.MinValue, DateTime.MinValue);
        }
        public int SetAccess(string pClassName, string pDecissionName, int pObjectCode, int pUserPostCode, DateTime pStartDate, DateTime pEndDate)
        {
            JPermissionDefineClass PDC = new JPermissionDefineClass(pClassName);
            JPermissionDecision PD = new JPermissionDecision();
            JPermissionUser PU = new JPermissionUser();
            try
            {
                PD.GetData(PDC.Code, pDecissionName);
                //PU.DefineClassCode = PDC.Code;
                PU.DecisionCode = PD.Code;
                PU.ObjectCode = pObjectCode;
                PU.User_Post_Code = pUserPostCode;
                if (pStartDate != DateTime.MinValue)
                    PU.Start_Date = pStartDate;
                if (pEndDate != DateTime.MinValue)
                    PU.End_Date = pEndDate;
                PU.HasPermission = true;
                return PU.Insert();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                PDC.Dispose();
                PD.Dispose();
                PU.Dispose();
            }
            return 0;
        }

        public void ListView()
        {
            Nodes.Insert(JStaticNode._PermissionDefineForm());
            Nodes.Insert(JStaticNode._PermissionSet(JMainFrame.CurrentUserCode));
        }

        public JNode[] TreeView()
        {
            JNode[] TNode = new JNode[0];
            return TNode;
        }

        public static bool ChackPermission(string pClassName, int pObjectCode)
        {
            return ChackPermission(pClassName, pObjectCode, JMainFrame.CurrentPostCode);
        }

        public static bool ChackPermission(string pClassName)
        {
            return ChackPermission(pClassName, 0, JMainFrame.CurrentPostCode);
        }

        public static bool ChackPermission(string pClassName, int pObjectCode, int pPostCode)
        {
            return ChackPermission(pClassName, pObjectCode, pPostCode, true);
        }
        public static bool ChackPermission(string pClassName, int pObjectCode, int pPostCode, bool pShowMessgae)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string QueryDecisions = JDataBase.GetInSQLClause(JPermissionControl.GetDecisions(pClassName));
                string Query = " SELECT COUNT(*) FROM " + JTableNamesPermission.PermissionUser +
                    " Where " + PermissionUser.User_post_Code + "= " + pPostCode.ToString();
                if (QueryDecisions != "")
                    Query = Query + " AND " + QueryDecisions;
                else
                    return false;
                Query = Query + " AND " + PermissionUser.HasPermission.ToString() + " = 'TRUE'";

                if (pObjectCode != 0)
                    Query = Query + " AND " + PermissionUser.ObjectCode + "=" + pObjectCode.ToString();

                DB.setQuery(Query);
                bool HasPermission = Convert.ToInt32(DB.Query_ExecutSacler()) > 0;

                if (pShowMessgae && !HasPermission)
                    ClassLibrary.JMessages.Error("YouDontHavePermission", "AccessDenied");
                return HasPermission;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }


    }

}

