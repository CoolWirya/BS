using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{

    public class JFinAssetLog
    {
        public int Code { get; set; }
        public int ACode { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public JOwnershipType Type { get; set; }
        public string Comment { get; set; }

        public JFinAssetLog(int pACode,string pClassName, int pObjectCode, JOwnershipType pType, JDataBase pDB)
        {
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            ACode = pACode;
            this.Type = pType;
            SetData(pDB);
        }

        public void SetData(JDataBase pDB)
        {
            JDataBase DB;
            if (pDB == null)
                DB = new JDataBase();
            else
                DB = pDB;
            try
            {
                DB.setQuery("select COUNT(*) C from FinAssetLog");
                if (int.Parse(DB.Query_DataTable().Rows[0][0].ToString()) == 0)
                {
                    RefreshData(pDB);
                }
            }
            catch
            {
            }
            finally
            {
                if(pDB == null)
                    DB.Dispose();
            }
        }

        public void RefreshData(JDataBase pDB)
        {
            JDataBase DB;
            if (pDB == null)
                DB = new JDataBase();
            else
                DB = pDB;
            try
            {
                DB.setQuery(@"

delete from FinAssetLog
INSERT INTO FinAssetLog
select ROW_NUMBER() OVER(ORDER BY ClassName,ObjectCode DESC) AS Row ,* from
(
select ClassName,ObjectCode,2 as type,GWOwners,Code from vFinAsset_Low
where GWOwners is not null
union
select ClassName,ObjectCode,1,DFOwners,Code from vFinAsset_Low where ClassName in (N'RealEstate.JUnitBuild',N'RealEstate.JEnviroment',N'Estates.JGround') and DFOwners is not null
UNION
select ClassName,ObjectCode,3,REOwners,Code from vFinAsset_Low
where REOwners is not null
UNION
select N'Estates.JGround',ObjectCode,4,Name,Code from VGroundAsset_Low
)
 as a
");
                DB.Query_Execute();

            }
            catch
            {
            }
            finally
            {
                if (pDB == null)
                    DB.Dispose();
            }
        }


        public string getComment(JDataBase pDB)
        {
            JDataBase DB = pDB;
            try
            {
                DB.setQuery(@"
select top 1 a.GWOwners comment from
(
select ClassName,ObjectCode,2 as type,GWOwners from vFinAsset_Low
where GWOwners is not null
union
select ClassName,ObjectCode,1,DFOwners from vFinAsset_Low where ClassName in (N'RealEstate.JUnitBuild',N'RealEstate.JEnviroment',N'Estates.JGround') and DFOwners is not null
UNION
select ClassName,ObjectCode,3,REOwners from vFinAsset_Low
where REOwners is not null
UNION
select N'Estates.JGround',ObjectCode,4,Name from VGroundAsset_Low
) as a where 
a.ClassName=N'" + ClassName + @"'AND 
a.ObjectCode=" + ObjectCode.ToString() + @" AND 
type=" + this.Type.GetHashCode());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return DB.DataReader["comment"].ToString();
                }
                return "";

            }
            catch
            {
                return "";
            }
            finally
            {
            }
        }

        public int save(JDataBase pDB)
        {
            Comment = getComment(pDB);
            if (Find(pDB))
            {
                if (Update(pDB))
                    return Code;
                else
                    return 0;
            }
            else
            {
                return insert(pDB);
            }
        }

        private bool Find(JDataBase pDB)
        {
            JDataBase DB = pDB;
            try
            {
                DB.setQuery(@"
select * from finassetlog a
where 
a.ClassName=N'" + ClassName + @"'AND 
a.ObjectCode=" + ObjectCode.ToString() + @" AND 
type=" + this.Type.GetHashCode());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    Code = int.Parse(DB.DataReader["Code"].ToString());
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }

        private int insert(JDataBase pDB)
        {
            JAssetLogTable AsTable = new JAssetLogTable();
            AsTable.SetValueProperty(this);
            return AsTable.Insert(pDB);
        }

        private bool Update(JDataBase pDB)
        {
            JAssetLogTable AsTable = new JAssetLogTable();
            AsTable.SetValueProperty(this);
            return AsTable.Update(pDB);
        }

        private bool Delete(JDataBase pDB)
        {
            JAssetLogTable AsTable = new JAssetLogTable();
            AsTable.SetValueProperty(this);
            return AsTable.Delete(pDB);
        }

        public static string GetSQLFields(string pClassName, string pObjectCodename)
        {
            string SQL = "";
            string _Com = "";

            JOwnershipType _Type = JOwnershipType.Definitive;
            string[] EnumNames = Enum.GetNames(_Type.GetType());
            int[] EnumValues = Enum.GetValues(_Type.GetType()).Cast<int>().ToArray();


            for (int i = 0; i < EnumValues.Count(); i++)
            {
                SQL = SQL + _Com + "(SELECT Comment FROM FinASSETlOG WHERE ClassName='" + pClassName + "' AND ObjectCode=" + pObjectCodename + " AND Type='" + EnumValues[i].ToString() + "') AS FLog" + EnumNames[i];
                _Com = ",";
            }
            return SQL;
        }


    }
}
