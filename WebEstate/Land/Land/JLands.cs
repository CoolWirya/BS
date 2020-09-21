using Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEstate.Land.Land
{
	public class JLands
	{
		JLand NewLand;

		#region Properties
		public int Code { get; set; }
		public string Name { get; set; }
		public double Area { get; set; }
		public string Section { get; set; }
		public string Plaque { get; set; }
		#endregion

		public bool Insert()
		{
			NewLand = new JLand();
			NewLand.Name = Name;
			NewLand.Area = Area;
			NewLand.Plaque = Plaque;
			NewLand.Section = Section;
			if (Code != 0)
			{
				NewLand.Code = Code;
				return NewLand.Update();
			}
			else
				return NewLand.Insert() > 0;
		}
	}
}