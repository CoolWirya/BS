using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL
{
	/// <summary>
	/// Type of sending data.
	/// </summary>
	public enum  SendType:byte
	{
		/// <summary>
		/// Send data through socket.
		/// </summary>
		Socket = 0,
		/// <summary>
		/// Send data to a webservice.
		/// </summary>
		WebService=1,
		/// <summary>
		/// Direct to database.
		/// </summary>
		Direct=2,
		/// <summary>
		/// Send data to a page as request.
		/// </summary>
		Page=3
	}
}
