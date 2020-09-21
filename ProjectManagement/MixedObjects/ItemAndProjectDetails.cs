using System;
using System.Data;
using pi=ProjectManagement.Item;

namespace ProjectManagement.MixedObjects
{
    public class ItemAndProjectDetails : ClassLibrary.JSystem
    {
        public const String CLASSNAME = "ProjectManagement.MixedObjects.ItemAndProjectDetails";
        public Item.JItem Item { get; set; }
        public Item.JItem ParentItem { get; set; }
        public Project.JProject Project { get; set; }
        public System.Collections.Generic.List<ItemReport.JItemReport> ItemReports { get; set; }

        public decimal TotalReportedPercentage
        {
            get { return this.Item.TotalReportedPercentage(); }
        }
        public decimal TotalSubItemPercentage { get; set; }

        public ItemAndProjectDetails() { }

        public ItemAndProjectDetails(int ItemCode, int projectCode)
        {
            GetData(ItemCode, projectCode, true);

        }

        public bool GetData(int ItemCode, int projectCode, bool checkPermission)
        {
            string query = @"SELECT TOP 1 i.*,
pi.[Name] AS ParentName,pi.[ParentItemCode] AS ParentParentItemCode,pi.[WeightPercentage] AS ParentWeight,pi.[ProjectCode] AS ParentProjectCode,pi.[ItemDescription] AS ParentDescription,
p.[Name] AS ProjectName,p.[StartDate],p.[EndDate],p.[LocationAddress],p.[ProjectDescription] ,p.TotalWeight,
ir.[Code] AS reportCode,ir.[RegisterDate] AS reportRegisterDate,ir.[WeightPercentage] AS reportPercent,ir.[UserCode] AS reportUserCode,ir.[ReportDescription] AS reportDescription,
(select sum(ir2.WeightPercentage*it.WeightPercentage/100) from pmItemReport ir2 inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code={1}) as totalReportedPercent,
(select sum(WeightPercentage) from pmItems where 1=1    AND ProjectCode = {0} AND ParentItemCode={1} ) as totalSubItemPercent
FROM pmItems i 
LEFT JOIN pmItems pi ON pi.Code=i.ParentItemCode
full JOIN pmProjects p ON p.Code=i.ProjectCode 
LEFT JOIN pmItemReport ir ON  ir.ItemCode= i.Code
WHERE  p.Code = {0}  {2}";
            //            string query = @"SELECT TOP 1 i.*,
            //pi.[Name] AS ParentName,pi.[ParentItemCode] AS ParentParentItemCode,pi.[WeightPercentage] AS ParentWeight,pi.[ProjectCode] AS ParentProjectCode,pi.[ItemDescription] AS ParentDescription,
            //p.[Name] AS ProjectName,p.[StartDate],p.[EndDate],p.[LocationAddress],p.[ProjectDescription] ,p.TotalWeight,
            //ir.[Code] AS reportCode,ir.[RegisterDate] AS reportRegisterDate,ir.[WeightPercentage] AS reportPercent,ir.[UserCode] AS reportUserCode,ir.[ReportDescription] AS reportDescription,
            //(select sum(ir2.WeightPercentage*it.WeightPercentage/100) from pmItemReport ir2 inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code={1}) as totalReportedPercent,
            //(select top 1 ir2.WeightPercentage as totalWeight  from pmItemReport ir2 
            //                    inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code in ({1}) order by ir2.Code desc) as totalSubItemPercent
            //FROM pmItems i 
            //LEFT JOIN pmItems pi ON pi.Code=i.ParentItemCode
            //full JOIN pmProjects p ON p.Code=i.ProjectCode 
            //LEFT JOIN pmItemReport ir ON  ir.ItemCode= i.Code
            //WHERE  p.Code = {0}  {2}";

            query = string.Format(query, projectCode, ItemCode, ItemCode > 0 ? " AND i.Code =" + ItemCode : "");


            return this.GetData(query, checkPermission);
        }
        public Boolean GetData(string query, bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetData");
            if (!hasPermission)
                return false;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                if (dt == null || dt.Rows == null || dt.Rows.Count < 1) return false;


                ItemAndProjectDetails p = Extract(dt.Rows[0]);
                this.Item = p.Item;
                this.ParentItem = p.ParentItem;
                this.Project = p.Project;
                //this.TotalReportedPercentage = p.TotalReportedPercentage;
                this.TotalSubItemPercentage = p.TotalSubItemPercentage;
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        private ItemAndProjectDetails Extract(DataRow dr)
        {
            ItemAndProjectDetails i = new ItemAndProjectDetails();
            i.Item = new ProjectManagement.Item.JItem();
            i.ParentItem = new ProjectManagement.Item.JItem();
            i.Project = new ProjectManagement.Project.JProject();
            i.ItemReports = new System.Collections.Generic.List<ItemReport.JItemReport>();
            //Item
            i.Item.Code = dr["Code"].ToString().ToInt32();
            i.Item.ItemDescription = dr["ItemDescription"].ToString();
            i.Item.Name = dr["Name"].ToString();
            i.Item.ParentItemCode = dr["ParentItemCode"].ToString().ToInt32();
            i.Item.ProjectCode = dr["ProjectCode"].ToString().ToInt32();
            i.Item.WeightPercentage = dr["WeightPercentage"].ToString().ToDecimal();
            //ParentItem
            i.ParentItem.Code = dr["ParentItemCode"].ToString().ToInt32();
            i.ParentItem.ItemDescription = dr["ParentDescription"].ToString();
            i.ParentItem.Name = dr["ParentName"].ToString();
            i.ParentItem.ParentItemCode = dr["ParentParentItemCode"].ToString().ToInt32();
            i.ParentItem.ProjectCode = dr["ParentProjectCode"].ToString().ToInt32();
            i.ParentItem.WeightPercentage = dr["ParentWeight"].ToString().ToDecimal();
            //Project Details
            i.Project.Code = dr["ProjectCode"].ToString().ToInt32();
            i.Project.Name = dr["ProjectName"].ToString();
            i.Project.LocationAddress = dr["LocationAddress"].ToString();
            i.Project.ProjectDescription = dr["ProjectDescription"].ToString();
            i.Project.EndDate = dr["EndDate"].ToString().ToDateTime();
            i.Project.StartDate = dr["StartDate"].ToString().ToDateTime();
            i.Project.TotalWeight = dr["TotalWeight"].ToString().ToDecimal();
            //ItemReports
            ItemReport.JItemReport report = new ItemReport.JItemReport();
            report.Code = dr["reportCode"].ToString().ToInt32();
            report.ItemCode = i.Item.Code;
            report.RegisterDate = dr["reportRegisterDate"].ToString().ToDateTime();
            report.ReportDescription = dr["reportDescription"].ToString();
            report.UserCode = dr["reportUserCode"].ToString().ToInt32();
            report.WeightPercentage = dr["reportPercent"].ToString().ToDecimal();
            i.ItemReports.Add(report);
            //TotalReportedPercentage
            //i.TotalReportedPercentage = dr["totalReportedPercent"].ToString().ToDecimal();
            //TotalSubItemPercentage
            i.TotalSubItemPercentage = dr["totalSubItemPercent"].ToString().ToDecimal();
            return i;
        }

    }
}
