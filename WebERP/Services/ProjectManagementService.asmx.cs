using System;
using pm = ProjectManagement.Project;
using System.Web.Services;
using ProjectManagement;
using Telerik.Web.UI;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace WebERP.Services
{
    /// <summary>
    /// Summary description for ProjectManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ProjectManagementService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
    {

        [WebMethod(EnableSession = true)]
        public string SaveProject(string code, string name,string totalWeight,string startDate,string endDate,string description,string locationAddress,string templateCode,string templateType)
        {
            int Code = code.ToInt32();
            pm.JProject p = new pm.JProject(Code);

            p.Name = name;
            p.ProjectDescription = description;
            p.LocationAddress = locationAddress;
            p.StartDate = PersianDateControls.Convertor.ToGregorianDate( startDate).Value;
            p.EndDate = PersianDateControls.Convertor.ToGregorianDate(endDate).Value;
            p.templateType = templateType.ToInt32();
            p.templateCode = templateCode.ToInt32();
            p.TotalWeight = totalWeight.ToDecimal();

            bool res;
            if (p.Code == 0) res=( p.Insert()>0);
            else res=p.Update();

            if (res) return "Success";
            return "Failed";
        }

        [WebMethod(EnableSession = true)]
        public string SaveItem(string code,string name,string parentCode,string weight, string projectCode, string description)
        {
            int Code = code.ToInt32();
            ProjectManagement.Item.JItem p = new ProjectManagement.Item.JItem(Code);
            decimal possibleWeight;
            if (parentCode.ToInt32() > -1)
            {
                ProjectManagement.MixedObjects.ItemAndProjectDetails parent = new ProjectManagement.MixedObjects.ItemAndProjectDetails(parentCode.ToInt32(), projectCode.ToInt32());
                if ((possibleWeight = parent.Item.WeightPercentage - (parent.TotalSubItemPercentage - p.WeightPercentage)) < weight.ToDecimal())
                    return "!-" + "وزن آیتم باید کمتر از " + possibleWeight + " باشد. ";
            }
            else
            {
                ProjectManagement.Project.JProject project = new pm.JProject(projectCode.ToInt32());
                if ((possibleWeight =project.TotalWeight- project.GetTotalSubItemsPercentage()) < weight.ToDecimal())
                    return "!-" + "وزن آیتم باید کمتر از " + possibleWeight + " باشد. ";
            }
            p.Name = name;
            p.ItemDescription = description;
            p.ParentItemCode = parentCode.ToInt32();
            p.ProjectCode = projectCode.ToInt32() ;
            p.WeightPercentage = weight.ToDecimal();

            bool res;
            if (p.Code == 0) res = (p.Insert() > 0);
            else res = p.Update();

            if (res) return "عملیات موفق";
            return "!-"+"خطا در  ثبت آیتم.";
        }


        [WebMethod(EnableSession = true)]
        public string SaveItemReport(string code,string itemCode,string improvementPercentage,string reportDesciption,string userCode)
        {
            int Code = code.ToInt32();
            ProjectManagement.ItemReport.JItemReport p = new ProjectManagement.ItemReport.JItemReport(Code);

            p.ItemCode = itemCode.ToInt32();
            p.RegisterDate = DateTime.Now;
            p.ReportDescription =reportDesciption;
            p.UserCode = userCode.ToInt32();
            p.WeightPercentage = improvementPercentage.ToDecimal();

            bool res;
            if (p.Code == 0) res = (p.Insert() > 0);
            else res = p.Update();

            if (res) return "Success";
            return "Failed";
        }




        [WebMethod(EnableSession = true)]
        public string ToolTipInfo(object context)
        {
            var dict = (Dictionary<string, object>)context;
            var data = ProjectManagement.Item.JItems.GetDataTableForTreeMap(WebClassLibrary.SessionManager.Current.Session[WebProjectManagement.Forms.ProjectItemList.SessionNameForShowProjectItems].ToString().ToInt32());
            try
            {
                var dataRow = data.Select("Code =" + dict["Value"].ToString() + "")[0];
                int itemcode = dict["Value"].ToString().ToInt32();
                //[Code],[Name],[ParentItemCode],[WeightPercentage],[ProjectCode],[ItemDescription] 
                int code = dataRow.ItemArray[0].ToString().ToInt32();
                var name = dataRow.ItemArray[1];
                int ParentIdCode = dataRow.ItemArray[2].ToString().ToInt32();
                var WeightPercentage = dataRow.ItemArray[3];
                var ProjectCode = dataRow.ItemArray[4];
                var ItemDescription = dataRow.ItemArray[6];

                string tooltipContent = "<span class='rank'>" +
                            "<span class='rankText'>وزن</span>" +
                            "<span class='rankValue'>" + WeightPercentage + "</span>" +
                        "</span>" +
                        "<div class='content " + ParentIdCode + "'>" + 
                 ((itemcode > -1)?
           string.Format(@"<div style='display:inline;'>
                     <img class='btnAddSubItem' title='افزودن آیتم' alt='افزودن آیتم'  src='/Images/Controls/toolbar_add.png' width='48px' heigh='48px' onClick='selectedItem(""AddSubNode"",{0});'/>
                     <img class='btnEdit' title='ویرایش' alt='ویرایش'  src='/Images/Controls/toolbar_edit.png' width='48px' heigh='48px' onClick='selectedItem(""EditNode"",{0});'/>
                     <img class='btnDeleteAndMoveUp' title='حذف آیتم و انتقال زیرمجموعه ها به رده بالاتر' alt='حذف آیتم و انتقال زیرمجموعه ها به رده بالاتر'  src='/Images/Controls/move-up.png' width='48px' heigh='48px' onClick='selectedItem(""DeleteNodeAndMove"",{0});'/>
                     <img class='btnDeleteAll' title='حذف آیتم و زیرمجموعه ها' alt='حذف آیتم و زیرمجموعه ها'  src='/Images/Controls/toolbar_delete.png' width='48px' heigh='48px' onClick='selectedItem(""DeleteNodeFully"",{0});'/>
                 </div>", itemcode):"")+
                            "<span class='header'>" + name + "</span>" +
                            "<span class='sport'>" + ItemDescription + "</span>" +
                            "<ul class='list'>";

                ProjectManagement.Project.JProject p = new ProjectManagement.Project.JProject(ProjectCode.ToString().ToInt32());

                var listTitle = new[] { "نام پروژه" };
                var listValues = new[] { p.Name };

                for (int i = 0; i < listValues.Length; i++)
                {
                    tooltipContent += "<li>" +
                                        "<span class='listTitle'>" + listTitle[i] + "</span>" +
                                        "<span class='listValue'>" + listValues[i] + "</span>" +
                                    "</li>";
                }

                tooltipContent += "</ul>" + "</div>";

                return tooltipContent;
            }
            catch { return ""; }
        }



        [WebMethod]
        public string GetToken(string username,string pass)
        {
            Globals.JUser jUser = new Globals.JUser();
            int usercode = jUser.CheckUserPass(username, pass);
            if (usercode<1) return "Login Failed";
            ProjectManagement.Token.JTokens.DeleteAll(usercode);
            ProjectManagement.Token.JToken t = new ProjectManagement.Token.JToken();
            t.ExpirationDate = DateTime.Now.AddHours(1);
            t.userCode = usercode;
            t.token = Guid.NewGuid().ToString();
            if (t.Insert(false) > 0) return t.token;
            return "";
        }
        [WebMethod]
        public List<ProjectManagement.Project.JProject> GetProjects(string token)
        {
            ProjectManagement.Token.JToken t = new ProjectManagement.Token.JToken();
            if (!t.CheckToken(token))
                return null;
            DataTable dt=ProjectManagement.Project.JProjects.GetDataTable(false);
            if (dt == null) return null;
            List<ProjectManagement.Project.JProject> projects = new List<ProjectManagement.Project.JProject>();
            foreach(DataRow dr in dt.Rows)
            {
                projects.Add(ProjectManagement.Project.JProject.Extract(dr));
            }
            return projects;
        }
        [WebMethod]
        public List<ProjectManagement.Item.JItem> GetItems(string token,string projectCode)
        {
            ProjectManagement.Token.JToken t = new ProjectManagement.Token.JToken();
            if (!t.CheckToken(token))
                return null;
            DataTable dt = ProjectManagement.Item.JItems.GetLatestChildren(projectCode.ToInt32(),false);
            if (dt == null) return null;
            List<ProjectManagement.Item.JItem> projects = new List<ProjectManagement.Item.JItem>();
            foreach (DataRow dr in dt.Rows)
            {               
                projects.Add(ProjectManagement.Item.JItem.Extract(dr));
            }
            return projects;
        }
        [WebMethod]
        public string SaveReport(string token, string itemCode, string improvementPercentage, string reportDesciption)
        {
            ProjectManagement.Token.JToken t = new ProjectManagement.Token.JToken();
            if (!t.CheckToken(token))
                return null;
            ProjectManagement.ItemReport.JItemReport p = new ProjectManagement.ItemReport.JItemReport();

            p.ItemCode = itemCode.ToInt32();
            p.RegisterDate = DateTime.Now;
            p.ReportDescription = reportDesciption;
            p.UserCode = t.userCode;
            p.WeightPercentage = improvementPercentage.ToInt32();


           int res = p.Insert(false);

            if (res>0) return res.ToString();
            return "0";
        }

        [WebMethod(EnableSession = true)]
        public string DeleteAnItem(string itemCode, string type,string tag)
        {
            if (type.ToInt32() == 1)//project
                return ProjectManagement.Item.JItems.DeleteNodeIncludeSubNodes(itemCode.ToInt32()).ToString();
            else //template
                return ProjectManagement.TemplateItem.JTemplateItems.DeleteItemIncludeSubItems(itemCode.ToInt32()).ToString();
        }
        [WebMethod(EnableSession =true)]
        public string UploadItemReportImage(string token, string itemReportCode, string image)
        {
            ProjectManagement.Token.JToken t = new ProjectManagement.Token.JToken();   
            if (!t.CheckToken(token))
                return "Token is invalid";
            ProjectManagement.ItemReport.JItemReport p = new ProjectManagement.ItemReport.JItemReport(itemReportCode.ToInt32());
            if (p.Code < 0) return "";

            byte[] img = Convert.FromBase64String(image);

            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = img;
                jFile.FileName = p.Code + "-" + DateTime.Now.ToString() + ".jpg";
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
               jFile.FileText = jFile.FileName;
          WebClassLibrary.JMainFrame jMainFrame = new WebClassLibrary.JMainFrame();
                jMainFrame.DomainName = System.Web.HttpContext.Current.Request.Url.Host;
                jMainFrame.Save();
                WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode = t.userCode;
                WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode = 0;
                //  archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر شخص");
                if ( p.HasPic=(archive.ArchiveDocument(jFile, p.GetType().FullName, p.Code,"ItemReportImages", true)<1))
                    return "image failed to save;";

                p.Update(false);
                    
                
            }
            catch(Exception er)
            {
                return "image not saved in database.";
            }
            return "1";
        }


        [WebMethod(EnableSession = true)]
        public string EditItemParentName(string itemCode, string type, string name)
        {
            int Code = itemCode.ToInt32();
            int t = type.ToInt32();
            if (t == 1)//project
            {
                ProjectManagement.Item.JItem p = new ProjectManagement.Item.JItem(Code);
                if (p.Name.Equals(name)) return "";
                p.Name = name;
                if (p.Update()) return p.Name + " ذخیره شد.";
                else return "عملیات ذخیره ناموفق بود.";
            }
            else
            {//template
                ProjectManagement.TemplateItem.JTemplateItem i = new ProjectManagement.TemplateItem.JTemplateItem(Code);
                if (i.Name.Equals(name)) return "";
                i.Name = name;
                if (i.Update()) return i.Name + " ذخیره شد.";
                else return "عملیات ذخیره ناموفق بود.";
            }
        }

        [WebMethod(EnableSession = true)]
        public string EditItemDescription(string itemCode, string type, string description)
        {
            int Code = itemCode.ToInt32();
            int t = type.ToInt32();
            if (t == 1)//project
            {
                ProjectManagement.Item.JItem p = new ProjectManagement.Item.JItem(Code);
                if (!string.IsNullOrEmpty(p.ItemDescription) &&  p.ItemDescription.Equals(description) ) return "";
                p.ItemDescription = description;
                if (p.Update()) return p.Name + " ذخیره شد.";
                else return "عملیات ذخیره ناموفق بود.";
            }
            return "0";
        }
        [WebMethod(EnableSession = true)]
        public string EditItemName(string itemCode,string type,string name)
        {
            int Code = itemCode.ToInt32();
            int t = type.ToInt32();
            if (t == 1)//project
            {
                ProjectManagement.Item.JItem p = new ProjectManagement.Item.JItem(Code);
                if ( p.Name.Equals(name)) return "";
                p.Name = name;
                if (p.Update()) return p.Name + " ذخیره شد.";
                else return "عملیات ذخیره ناموفق بود.";
            }
            else
            {//template
                ProjectManagement.TemplateItem.JTemplateItem i = new ProjectManagement.TemplateItem.JTemplateItem(Code);
                if (i.Name.Equals(name)) return "";
                i.Name = name;
                if (i.Update()) return i.Name + " ذخیره شد.";
                else return "عملیات ذخیره ناموفق بود.";
            }
            return "0";
        }

        [WebMethod(EnableSession = true)]
        public string CheckWeightPercentage(string itemCode, string type, string value)
        {
            int Code = itemCode.ToInt32();
            int t = type.ToInt32();
                decimal maxPossibleWeight=0,minPossibleWeight=0;
            if (t == 1)//project
            {
                ProjectManagement.Item.JItem p = new ProjectManagement.Item.JItem(Code);
                if (value.ContainsNonDigit()) return "فقط عدد وارد کنید. (!!)" + p.WeightPercentage;

                ProjectManagement.MixedObjects.ItemAndProjectDetails parent = new ProjectManagement.MixedObjects.ItemAndProjectDetails(p.ParentItemCode, p.ProjectCode);

                if (p.WeightPercentage == value.ToDecimal()) return "(!!)+" + parent.Project.GetTotalSubItemsPercentage();
                decimal totalweight, filledweight;
                if (p.ParentItemCode == -1)//main item
                {
                    totalweight = parent.Project.TotalWeight;
                    filledweight = parent.Project.GetTotalSubItemsPercentage();

                }
                else//subitem
                {
                    totalweight = parent.Item.WeightPercentage;
                    filledweight = parent.Item.GetTotalSubItemsPercentage();
                }

                maxPossibleWeight = AvailableParentSpace(totalweight, filledweight, p.WeightPercentage);// مقدار فضای ممنک در والد
                minPossibleWeight = p.GetTotalSubItemsPercentage();//مقدار وزن پر شده توسط زیرشاخه ها
                if (maxPossibleWeight < minPossibleWeight) maxPossibleWeight = minPossibleWeight;

                //minPossibleWeight <= value.ToDecimal() <= maxPossibleWeight
                if (value.ToDecimal() > maxPossibleWeight || minPossibleWeight > value.ToDecimal())
                    return //"وزن  " + p.Name + " باید برابر یا کمتر از " + maxPossibleWeight + " و برابر یا بیشتر از " + minPossibleWeight + " باشد. "+
                          "وزن  " + p.Name + " اشتباه است." + "(!!)" + p.WeightPercentage;
                //else if (minPossibleWeight > value.ToDecimal())
                //    return "وزن  " + p.Name + " باید برابر یا کمتر از " + maxPossibleWeight + " و برابر یا بیشتر از " + minPossibleWeight + " باشد. (!!)" + p.WeightPercentage;
                p.WeightPercentage = value.ToDecimal();
                if (p.Update()) return p.Name + " ذخیره شد." + "(!!)+" + parent.Project.GetTotalSubItemsPercentage(); ;
            }
            else
            {//template

                ProjectManagement.TemplateItem.JTemplateItem i = new ProjectManagement.TemplateItem.JTemplateItem(Code);
                if (value.ContainsNonDigit()) return "فقط عدد وارد کنید. (!!)" + i.WeightPercentage;
                ProjectManagement.Template.JTemplate template = new ProjectManagement.Template.JTemplate(i.TemplateCode);
                if (i.WeightPercentage == value.ToDecimal()) return "(!!)+" + template.GetTotalSubItemsPercentage();
                ProjectManagement.TemplateItem.JTemplateItem parent = new ProjectManagement.TemplateItem.JTemplateItem(i.ParentItemCode);
                decimal totalweight, filledweight;
                if (i.ParentItemCode == -1)//main item
                {
                    totalweight = template.TotalWeight;
                    filledweight = template.GetTotalSubItemsPercentage();
                }
                else//subitem
                {
                    totalweight = parent.WeightPercentage;
                    filledweight = parent.GetTotalSubItemsPercentage();

                }

                maxPossibleWeight = AvailableParentSpace(totalweight, filledweight, i.WeightPercentage);// مقدار فضای ممنک در والد
                minPossibleWeight = i.GetTotalSubItemsPercentage();//مقدار وزن پر شده توسط زیرشاخه ها
                if (maxPossibleWeight < minPossibleWeight) maxPossibleWeight = minPossibleWeight;

                //minPossibleWeight <= value.ToDecimal() <= maxPossibleWeight
                if (value.ToDecimal() > maxPossibleWeight || minPossibleWeight > value.ToDecimal())
                    return //"وزن  " + i.Name + " باید برابر یا کمتر از " + maxPossibleWeight + " و برابر یا بیشتر از " + minPossibleWeight + " باشد. " +
                      "وزن  " + i.Name + " اشتباه است."+  "(!!)" + i.WeightPercentage;
                //else if (minPossibleWeight >value.ToDecimal())
                //    return "وزن  " + i.Name + " باید برابر یا کمتر از " + maxPossibleWeight + " و برابر یا بیشتر از " + minPossibleWeight + " باشد. (!!)" + i.WeightPercentage;
                i.WeightPercentage = value.ToDecimal();
                if (i.Update()) return i.Name + " ذخیره شد." + "(!!)+" + template.GetTotalSubItemsPercentage();

            }
            return "";
        }
        private decimal AvailableParentSpace(decimal totalSpace,decimal occupiedSpace,decimal itemCurrentWeight)
        {
            if (totalSpace < occupiedSpace) return 0;
            return totalSpace - (occupiedSpace - itemCurrentWeight);
        }
  
        //[WebMethod(EnableSession = true)]
        //public string query(string q)
        //{
        //    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
        //    try
        //    {
        //        DB.setQuery(q);
        //        return DB.Query_Execute().ToString();


        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}
    }
}
