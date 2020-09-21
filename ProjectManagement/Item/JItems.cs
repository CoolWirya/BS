using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Item
{
   public  class JItems : ClassLibrary.JSystem
    {
        public const String CLASSNAME = "ProjectManagement.Item.JItems";
        public static System.Data.DataTable GetDataTable(int projectCode,int parentCode=-10,bool checkPermission=true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT [Code],[Name],[ParentItemCode],[WeightPercentage],[ProjectCode],[ItemDescription],CONVERT(varchar(50), Code) as id 
                    FROM pmItems WHERE ProjectCode=" + projectCode;
                if (parentCode != -10) query += " AND ParentItemCode=" + parentCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static System.Data.DataTable GetDataTableWithFillField(int projectCode, int parentCode = -10, bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT i.[Code],i.[Name],i.[ParentItemCode],i.[WeightPercentage],i.[ProjectCode],i.[ItemDescription],CONVERT(varchar(50), i.Code) as id ,
(CASE WHEN SUM(i2.WeightPercentage)>=i.[WeightPercentage] OR SUM(i2.WeightPercentage) is null THEN 'TRUE' ELSE 'FALSE' END) as isFilled

                    FROM pmItems i LEFT JOIN pmItems i2 ON i.Code=i2.ParentItemCode 
    WHERE i.ProjectCode=" + projectCode;
                if (parentCode != -10) query += " AND i.ParentItemCode=" + parentCode;
                query += " GROUP BY i.[Code],i.[Name],i.[ParentItemCode],i.[WeightPercentage],i.[ProjectCode],i.[ItemDescription]";
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static System.Data.DataTable GetDataTable( int parentCode , bool checkPermission )
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT [Code],[Name],[ParentItemCode],[WeightPercentage],[ProjectCode],[ItemDescription],CONVERT(varchar(50), Code) as id 
                    FROM pmItems WHERE ParentItemCode=" + parentCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static System.Data.DataTable GetDataTableRootNodes(int projectCode, int parentCode = -1)
        {
            if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTableRootNodes"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = "SELECT * FROM pmItems WHERE (ParentItemCode IS NULL OR ParentItemCode<=0) AND  ProjectCode=" + projectCode;
                if (parentCode > 0) query += " ParentItemCode=" + parentCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool Move(int itemCode, int newParentCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".MoveUp"))
                return false;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                bool res;
                string query =string.Format(@"  UPDATE pmItems set ParentItemCode={0}
  WHERE ParentItemCode = {1} ", 
newParentCode,itemCode);

                DB.setQuery(query);
                  return  DB.Query_Execute()>0;
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



        public static bool DeleteNodeIncludeSubNodes(int Code)
        {
                if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".DeleteNode"))
                    return false;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(
//                    @"declare @pcode int,@tempPCode int,@res int
//set @pcode={0}
//declare @parentCodes table(pcode int)
//insert into  @parentCodes values (@pcode)
//insert into @parentCodes select Code from pmItems where ParentItemCode=@pcode
	
//while(1=1)
//begin
//	Set @tempPCode = (select top 1 pcode from @parentCodes )
//	Insert into @parentCodes  select Code from pmItems where ParentItemCode=@tempPCode
//	select * from @parentCodes
//	IF (SCOPE_IDENTITY() is null)
//	begin
//		delete from @parentCodes where pcode=@tempPCode
//		delete from pmItems where Code=@tempPCode
//	end
//	if((select * from @parentCodes) is null)
//	break;
//end "
@"DELETE FROM pmItemReport WHERE ItemCode={0};
DELETE FROM pmItems WHERE ParentItemCode={0};
DELETE FROM pmItems WHERE Code={0}"
, Code);

                DB.setQuery(query);
                return DB.Query_Execute() >= 0;

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

        public static System.Data.DataTable GetLatestChildren(int projectCode=-1,bool checkPermission=true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetLatestChildren");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                //                string query = string.Format(@"  declare @TEMPitems table(code int)
                // insert into @TEMPitems select Code from pmItems
                //  select 1 as code into #Temp 
                // declare  @temp int, @tempcode int
                //while (1 = 1)
                //                begin
                //                    set @tempcode = (select top 1 code from @TEMPitems)
                //	set @temp = (select top 1 code from pmItems where ParentItemCode = @tempcode)
                //	if (@temp IS NULL)
                //		insert into #Temp values (@tempcode)
                //	DELETE FROM @TEMPitems WHERE code = @tempcode

                //    if ((select count(code) from @TEMPitems) < 1)
                //		break;
                //            end
                //select * from pmItems where Code in (select code from #Temp)");
                string query = @"select * from pmItems i
where Code not in (select ParentItemCode from pmItems) ";
                if (projectCode > 0) query += " AND ProjectCode = " + projectCode;

                DB.setQuery(query);
                    return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static System.Data.DataTable GetDataTableForTreeMap(int projectCode)
        {
            string rootName = new ProjectManagement.Project.JProject(projectCode).Name;
           System.Data. DataTable dt = GetDataTable(projectCode);
            //[Code],[Name],[ParentItemCode],[WeightPercentage],[ProjectCode],[ItemDescription],id
            dt.Rows.Add(-1, rootName, null, 100, -1, -1, rootName,"-1");
            return dt;
        }
    }
}
