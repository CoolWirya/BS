using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL
{
	/// <summary>
	/// Specify an id for properties.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class FormatIDAttribute:Attribute
	{
		public byte ID { get; set; }
		public FormatIDAttribute(byte ID)
		{            
			this.ID = ID;
		}
	}
}
