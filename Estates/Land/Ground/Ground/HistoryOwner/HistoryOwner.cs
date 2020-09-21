using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Estates.Land.Ground.Ground.HistoryOwner
{
    public class JHistoryOwner
    {
        public static DataTable GetPersonHistory(int pContractCode , int pPersonCode)
        {
            string Query = @"
            WITH Owners(ContractCode,ContractNumber,OwnerName,ContractDate, ParentCode, AssetShareCode ,Level)
AS
(

	select LSC.Code ContractCode, LSC.Number ContractNumber,FAS.PersonCode OwnerName,LSC.Date ContractDate, FAT.ParentCode , 
	FAS.Code AssetShareCode,
	 1 Level 
	from FinAssetShare FAS
	inner join FinAssetTransfer FAT on FAS.TCode = FAT.Code
	inner join LegSubjectContract LSC on LSC.Code=FAT.ObjectCode and FAT.ClassName='Legal.JSubjectContract'
	where 
	FAS.PersonCode = {0}
	and 
	LSC.Code={1}
	union ALL
	
	select FAT.ObjectCode ContractCode,
	(select Number from LegSubjectContract lSC where LSC.Code=FAT.ObjectCode and FAT.ClassName='Legal.JSubjectContract' )ContractNumber,
	FAS.PersonCode OwnerName,
	(select Date from LegSubjectContract lSC where LSC.Code=FAT.ObjectCode and FAT.ClassName='Legal.JSubjectContract' ) ContractDate,
	FAS.ParentCode ,
	FAS.Code AssetShareCode,
	Level+1
	from FinAssetShare FAS
	inner join FinAssetTransfer FAT on FAS.TCode = FAT.Code
	inner join Owners O on FAT.Code = O.ParentCode

)
select ContractCode,ContractNumber,OwnerName, ParentCode ,Level
,CP.Name, (Select Fa_date from StaticDates Where En_Date=O.ContractDate) ContractDate
 from Owners O
 inner join clsAllPerson CP
 ON O.OwnerName = CP.Code
 order by Level desc
            ";

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(String.Format(Query, pPersonCode, pContractCode));
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
