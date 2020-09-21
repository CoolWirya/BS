using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Project
{
    public class JProject : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.Project.JProject";
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationAddress { get; set; }
        public string ProjectDescription { get; set; }

        public int templateCode { get; set; }
        public int templateType { get; set; }
        public decimal TotalWeight { get; set; }

        public JProject()
        {
        }
        public JProject(int Code)
        {
            this.GetData("SELECT TOP 1 * FROM pmProjects WHERE Code=" + Code.ToString());
        }

        public Boolean GetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }


        public int Insert(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME+".Insert");
            if (!hasPermission)
                return 0;
            JProjectTable AT = new JProjectTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0,true);

            if (Code > 0 && templateType > 0)
                ImportTemplateItems();

            return Code;
        }

        public bool Delete(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Delete");
            if (!hasPermission)
                return false;

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            string query = "DELETE FROM pmItemReport WHERE ItemCode in (SELECT Code FROM pmItems WHERE ProjectCode=" + this.Code + ")";
            DB.setQuery(query);
            DB.Query_Execute();
            query = "DELETE FROM pmItems WHERE ProjectCode=" + this.Code;
            DB.setQuery(query);
            DB.Query_Execute();
            JProjectTable AT = new JProjectTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        private void CopyItems(int parentCode,int newParentCode)
        {
            int insertedCode;
            System.Data.DataTable dt;
            if (templateType == 1)
            {
                dt = TemplateItem.JTemplateItems.GetDataTable(templateCode, parentCode);
            }
            else if (templateType == 2)//copy items from project
            {
                dt = Item.JItems.GetDataTable(templateCode, parentCode);
            }
            else return;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                Item.JItem i = new Item.JItem();
                ClassLibrary.JTable.SetToClassProperty(i, dr);
                i.ParentItemCode = newParentCode;
                i.ProjectCode = this.Code;
                insertedCode = i.Insert();
                CopyItems(dr[0].ToString().ToInt32(),insertedCode);
            }            
        }
        public void ImportTemplateItems()
        {
        //    if (templateType == 2)//copy items from project
         //   {
                CopyItems(-1, -1);
          //  }
           
        }


        public bool Update(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Update");
            if (!hasPermission)
                return false;
            JProjectTable AT = new JProjectTable();
            AT.SetValueProperty(this);
            if (AT.Update())
                return true;
            else
                return false;
        }

        public decimal GetTotalReportedWeight()
        {           
            
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                //                string query = string.Format(@"SELECT
                //(SELECT SUM(CASE WHEN (ir.WeightPercentage IS NULL OR i.WeightPercentage IS NULL) THEN 0  ELSE ir.WeightPercentage*i.WeightPercentage/100 end )  FROM pmItemReport ir
                // full join pmItems i on i.Code=ir.ItemCode 
                //WHERE ProjectCode=p.Code AND 
                //ir.ItemCode in (select Code from pmItems where Code not in (select ParentItemCode from pmItems) AND i.ProjectCode=p.Code)) as improvement  
                //FROM pmProjects p where p.Code={0}", this.Code);
                string query = string.Format(@"SELECT  
		SUM(CASE WHEN (ir.WeightPercentage IS NULL OR i.WeightPercentage IS NULL) THEN 0  ELSE ir.WeightPercentage*i.WeightPercentage/100 end ) 
FROM	pmItemReport ir 
		INNER join 
		(SELECT  ItemCode,
				 Max(RegisterDate) maxDate
		 FROM	pmItemReport 
		 group by ItemCode) a 
		 ON a.ItemCode=ir.ItemCode
		 INNER join pmItems i on i.Code=ir.ItemCode  
WHERE	 ProjectCode={0} AND ir.RegisterDate=a.maxDate", this.Code);

                DB.setQuery(query);
                decimal res = DB.Query_DataTable().Rows[0][0].ToString().ToDecimal();
                return res;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static JProject Extract(System.Data.DataRow dr)
        {
            JProject p = new JProject();
            if (ClassLibrary.JTable.SetToClassProperty(p, dr))
                return p;
            return null;
        }

    }
}
