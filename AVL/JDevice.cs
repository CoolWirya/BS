
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL
{
	/// <summary>
	/// Device which remote ware installed on it.
	/// </summary>
	public class JDevice
	{

		private int _objectCode;
		/// <summary>
		/// Object code for specified device(object).
		/// </summary>
		public int ObjectCode
		{
			get { return _objectCode; }
			set { _objectCode = value; }
		}

		private int _code;
		/// <summary>
		/// Unique Code.
		/// </summary>
		public int Code
		{
			get { return _code; }
			set { _code = value; }
		}

		private DeviceType _typeOfDevice = DeviceType.Car;
		/// <summary>
		/// Type of device that remote ware installed on it. Default is car.
		/// </summary>
		public DeviceType TypeOfDevice
		{
			get { return _typeOfDevice; }
			set { _typeOfDevice = value; }
		}

		private SendType _typeOfSend = SendType.Socket;
		/// <summary>
		/// Type of sending data from remote ware to application. Default is Socket.
		/// </summary>
		public SendType _TypeOfSend
		{
			get { return _typeOfSend; }
			set { _typeOfSend = value; }
		}

	
	}
}
