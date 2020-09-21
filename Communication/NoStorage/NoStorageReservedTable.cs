using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication
{
	public class JNoStorageReservedTable:ClassLibrary.JTable
	{
		public int NoStorageCode;
		public int Number;

		public JNoStorageReservedTable()
			: base("NoStorageReservationNumber")
		{
		}
	}
}
