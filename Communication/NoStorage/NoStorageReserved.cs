using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
	public class JNoStorageReserved
	{

		public int Code { get; set; }
		public int NoStorageCode { get; set; }
		public int Number { get; set; }

		public JNoStorageReserved(int pNoStorageCode)
		{
			NoStorage NS = new NoStorage(pNoStorageCode);
			if (NS.Parent > 0)
				NoStorageCode = NS.Parent;
			else
				NoStorageCode = pNoStorageCode;
		}
		public int Reserve(int pNumber)
		{
			Number = pNumber;
			if (!Find())
			{
				JNoStorageReservedTable NRT = new JNoStorageReservedTable();
				NRT.SetValueProperty(this);
				Code = NRT.Insert();

				NoStorage NS = new NoStorage(NoStorageCode);
				NS.UpdateNumber(pNumber);
			}
			return 0;
		}

		public void ReserveTo(int pNumber)
		{
			NoStorage NS = new NoStorage(NoStorageCode);
			for (int i = NS.GetNextNumberWithoutUpdate(); i <= pNumber; i++)
			{
				Reserve(i);
			}
		}

		public bool Find()
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select * From NoStorageReservationNumber Where NoStorageCode = '"
					+ NoStorageCode.ToString() + "' AND Number = "
					+ Number.ToString());

				return db.Query_DataTable().Rows.Count > 0;
			}
			finally
			{
				db.Dispose();
			}
		}

		public System.Data.DataTable GetData()
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select * From NoStorageReservationNumber where NoStorageCode = " + NoStorageCode
					+" order by number");
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

		public bool Delete(int pNumber)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("delete From NoStorageReservationNumber where NoStorageCode = " + NoStorageCode
					+ " and  Number = " + pNumber.ToString());
				return db.Query_Execute() >= 0 ;
			}
			finally
			{
				db.Dispose();
			}
		}
	
	}
}
