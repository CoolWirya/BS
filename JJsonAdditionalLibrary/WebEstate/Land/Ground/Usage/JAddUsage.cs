using Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJsonAdditionalLibrary.WebEstate.Land.Ground.Usage
{
	public class JAddUsage
	{
		private JUsageGround _newUsage;

		#region Properties
		public string Name { get; set; }
		public string Density { get; set; }
		public int Percent { get; set; }
		public string Parking { get; set; }
		public string Access { get; set; }
		public string Comment { get; set; }
		public int Code { get; set; }
		#endregion

		public bool Insert()
		{
			_newUsage = new JUsageGround();
			_newUsage.Name = Name;
			_newUsage.Density = Density;
			_newUsage.Persent = Percent;
			_newUsage.Parking = Parking;
			_newUsage.Access = Access;
			_newUsage.Comment = Comment;
			if (Code != 0)
			{
				_newUsage.Code = Code;
				return _newUsage.Update();
			}
			else
				return _newUsage.Insert();
		}
	}
}