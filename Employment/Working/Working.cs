using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JWorking : JEmployment
    {
        public void ShowDialogFormObjects(int pEmpCode)
        {
            ClassLibrary.JFormObjectsForm p = new JFormObjectsForm("Employment.JEmployeeInfos.ListView", pEmpCode);
            p.ShowDialog();
        }

        public void WorkingForm(int pPersonCard)
        {
            //if (!(JPermission.CheckPermission("Employment.JEContract.ReportForm")))
            //    return;

            JWorkingForm p = new JWorkingForm(pPersonCard);
            p.ShowDialog();
        }

        public void ListForm(string pSQL, int pFormCode, int pEmp_Card, string pTime, string pDate)
        {
            JListForm p = new JListForm(pSQL, pFormCode, pEmp_Card, pTime, pDate);
            p.ShowDialog();
        }

        public static DataTable GetDataTableEMPForm()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select *,(select FormName from forms where CodeForm=Code) FormName from empform");
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
