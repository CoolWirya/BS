using System;
using pm = ProjectManagement.Project;
using System.Web.Services;

namespace WebProjectManagement.Services
{
    /// <summary>
    /// Summary description for ProjectManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ProjectManagementService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string SaveProject(string code, string name,string startDate,string endDate,string description,string locationAddress)
        {
            int Code;
            int.TryParse(code, out Code);
            pm.JProject p = new pm.JProject(Code);

            p.Name = name;
            p.ProjectDescription = description;
            p.LocationAddress = locationAddress;
            p.StartDate = DateTime.Parse(startDate);
            p.EndDate = DateTime.Parse(endDate);

            bool res;
            if (p.Code == 0) res= p.Insert()>0;
            else res=p.Update();

            if (res) return "Success";
            return "Failed";
        }



    }
}
