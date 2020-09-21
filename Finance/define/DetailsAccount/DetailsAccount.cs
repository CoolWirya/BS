using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.define.DetailsAccount
{

	/// <summary>
	/// کد های تفضیلی
	/// </summary>
	public class DetailsAccount
	{
		public int Code { get; set; }
		public String ClassName { get; set; }
		public int ObjectCode { get; set; }
		public string Title { get; set; }
		public string Description{get;set;}

		public int FinAssetCode { get; set; }

		public int Insert(ClassLibrary.JDataBase pDB)
		{
			return 0;
		}

		public bool Delete(ClassLibrary.JDataBase pDB)
		{
			return false;
		}

		public bool Update(ClassLibrary.JDataBase pDB)
		{
			return false;
		}

	}
}
