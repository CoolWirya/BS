using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL
{
	/// <summary>
	/// Format of sending data.
	/// </summary>
	public class JDataFormat
    {
		/// <summary>
		/// Initializing an instance of JDataFormat with default format. 
        /// Any property of JDataFormat or inherited class from JDataFormat should be declared with FormatIDAttribute.
        /// IDs should be unique for each property.
		/// </summary>
		/// <param name="Data"></param>
		public JDataFormat(byte[] Data)
		{
			CreateDataFormat();
		}

		/// <summary>
		/// Initializing an instance of JDataFormat with specified format.
		/// </summary>
		/// <param name="Data"></param>
		/// <param name="Format"></param>
		public JDataFormat(byte[] data,string Format)
		{
			CreateDataFormat();
		}

		private byte[] _data;
		/// <summary>
		/// Original data has been sent from remote ware.
		/// </summary>
		public byte[] Data
		{
			get { return _data; }
			set { _data = value; }
		}

		private long _imei;
		/// <summary>
		/// IMEI number for specified device(object). [ID = 0]
		/// </summary>
		[FormatID(0)]
		public long IMEI
		{
			get { return _imei; }
			set { _imei = value; }
		}

		private System.Drawing.PointF _gpsCoordinates;
		/// <summary>
		/// Coordinates. [ID = 1]
		/// </summary>
		[FormatID(1)]
		public System.Drawing.PointF GPSCoordinates
		{
			get { return _gpsCoordinates; }
			set { _gpsCoordinates = value; }
		}



		private DateTime _dateTime;
		/// <summary>
		/// Data and time. [ID = 2]
		/// </summary>
		[FormatID(2)]
		public DateTime DateTime
		{
			get { return _dateTime; }
			set { _dateTime = value; }
		}


		private int _speed;
		/// <summary>
		/// Speed of moving object. [ID = 3]
		/// </summary>
		[FormatID(3)]
		public int Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}


		private int _direction;
		/// <summary>
		/// movement direction of object. [ID = 4]
		/// </summary>
		[FormatID(4)]
		public int Direction
		{
			get { return _direction; }
			set { _direction = value; }
		}


		private float _height;
		/// <summary>
		/// height of object. [ID = 5]
		/// </summary>
		[FormatID(5)]
		public float Height
		{
			get { return _height; }
			set { _height = value; }
		}

		private string _format = "0:0-5,1:6-8,2:9-12,3:13-5,4:0-5,5:0-5";
		/// <summary>
		/// format of data parts. 
		/// ID : Index of starting byte - Index of ending byte
		/// seprate entries with ,		
		/// example :
		/// 0:0-5,1:6-8,2:9-12,3:13-15,4:16-22,5:23-25
		/// </summary>
		public string Format
		{
			get { return _format; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new NullReferenceException("Format string can not be null or empty");
				_format = value;
			}
		}


        protected virtual void CreateDataFormat()
        {
            byte[] destData = new byte[this.Data.Length];
            string[] entries = this.Format.Split(',');
            string[] sp = null;
            int count = 0;

            if (entries.Length == 0)
                throw new FormatException("You missed ' in the format expression.");
            System.Reflection.PropertyInfo[] pi = typeof(JDataFormat).GetProperties();
            foreach (string entry in entries)
            {
                sp = entry.Split(':');
                if (sp.Length == 0)
                    throw new FormatException("You missed : in one of entries.");
                foreach (System.Reflection.PropertyInfo p in pi)
                    foreach (object o in p.GetCustomAttributes(false))
                        if (o is FormatIDAttribute)
                        {
                            FormatIDAttribute fi = (FormatIDAttribute)o;
                            if (fi.ID == int.Parse(sp[0].Trim()))
                            {
                                count = int.Parse(sp[1].Split('-')[1]) - int.Parse(sp[1].Split('-')[0]);
                                Buffer.BlockCopy(this.Data, 0, destData, int.Parse(sp[1].Split('-')[0]), count);
                                p.SetValue(this, Convert.ChangeType(destData, p.PropertyType), null);
                            }
                        }
            }

        }
	}
}
