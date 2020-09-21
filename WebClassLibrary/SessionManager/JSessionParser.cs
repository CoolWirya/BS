using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace WebClassLibrary
{
	public class JSessionParser
	{

		#region properties

		private static SessionItemCollection Items = new SessionItemCollection();

		private static BinaryReader _br;

		#endregion

		public static SessionItemCollection ParseSession(string sessionId)
		{
			DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT ISNULL(SessionItemShort,SessionItemLong) FROM [ASPState].[dbo].[ASPStateTempSessions],(select top(1) RIGHT(master.dbo.fn_varbintohexstr(AppId),8) appid from [ASPState].[dbo].ASPStateTempApplications where RIGHT(RTRIM(AppName),5)='/root') app WHERE SessionId = '" + sessionId + "' + app.appid", false);// ORDER BY DATALENGTH(ISNULL(SessionItemShort,ISNULL(SessionItemLong,CAST(0 as varbinary)))) desc
			if (dt == null || dt.Rows.Count < 1)
				return null;
			object session = dt.Rows[0][0];
			if (session.GetType() == typeof(DBNull) || session == null)
				return null;
			MemoryStream ms = new MemoryStream((byte[])session);
			Decode(ms);
			return Items;
		}

		private static void Decode(MemoryStream ms)
		{

			using (BinaryReader br = new BinaryReader(ms))
			{

				int timeout = br.ReadInt32(); // session timeout (i think)

				bool state = br.ReadBoolean(); // we'll be using this

				bool _static = br.ReadBoolean(); // don't need this

				if (state)
				{

					DecodeStateItems(br);

				}

			}

		}

		private static void DecodeStateItems(BinaryReader br)
		{

			int items = br.ReadInt32(); // items in session

			if (items > 0)
			{

				int num2 = br.ReadInt32(); // another check flag

				int currentItem = 0;

				while (currentItem < items) // loop through each item
				{

					string key;

					if (currentItem == num2) { key = null; }

					else // found the key
					{

						key = br.ReadString();

						Items.Add(new SessionItem(currentItem, 0, key, null)); // add it to our collection

					}

					currentItem++;

				}

				// need this loop so we can find the seek position

				for (currentItem = 0; currentItem < items; currentItem++)
				{

					if (currentItem != 0)
					{
						//if (br.PeekChar() != -1)
						Items.FindBy(currentItem).SeekPosition = br.ReadInt32(); // seek to so we can find the value

					}

				}

				int lastOffset = br.ReadInt32();

				byte[] buffer = new byte[lastOffset];

				int length = br.BaseStream.Read(buffer, 0, lastOffset);

				using (MemoryStream ms = new MemoryStream(buffer))
				{

					_br = new BinaryReader(ms);

					SetValues();

				}

			}

		}

		enum DataType : byte
		{

			// Fields

			Boolean = 3,

			Byte = 6,

			Char = 7,

			DateTime = 4,

			Decimal = 5,

			Double = 9,

			Guid = 0x11,

			Int16 = 11,

			Int32 = 2,

			Int64 = 12,

			IntPtr = 0x12,

			Null = 0x15,

			Object = 20,

			SByte = 10,

			Single = 8,

			String = 1,

			TimeSpan = 0x10,

			UInt16 = 13,

			UInt32 = 14,

			UInt64 = 15,

			UIntPtr = 0x13

		}

		private static void SetValues()
		{

			for (int i = 0; i < Items.Count; i++)
			{

				_br.BaseStream.Seek((long)Items[i].SeekPosition, SeekOrigin.Begin);

				Items[i].Value = ReadValueFromStream();

			}

			_br.Close();

		}

		private static object ReadValueFromStream()
		{

			object obj1 = null;

			int[] numArray1;

			int num1;

			switch (((DataType)_br.ReadByte()))
			{

				case DataType.String:
					{

						return _br.ReadString();

					}

				case DataType.Int32:
					{

						return _br.ReadInt32();

					}

				case DataType.Boolean:
					{

						return _br.ReadBoolean();

					}

				case DataType.DateTime:
					{

						return new DateTime(_br.ReadInt64());

					}

				case DataType.Decimal:
					{

						numArray1 = new int[4];

						num1 = 0;

						goto Label_00CA;

					}

				case DataType.Byte:
					{

						return _br.ReadByte();

					}

				case DataType.Char:
					{

						return _br.ReadChar();

					}

				case DataType.Single:
					{

						return _br.ReadSingle();

					}

				case DataType.Double:
					{

						return _br.ReadDouble();

					}

				case DataType.SByte:
					{

						return _br.ReadSByte();

					}

				case DataType.Int16:
					{

						return _br.ReadInt16();

					}

				case DataType.Int64:
					{

						return _br.ReadInt64();

					}

				case DataType.UInt16:
					{

						return _br.ReadUInt16();

					}

				case DataType.UInt32:
					{

						return _br.ReadUInt32();

					}

				case DataType.UInt64:
					{

						return _br.ReadUInt64();

					}

				case DataType.TimeSpan:
					{

						return new TimeSpan(_br.ReadInt64());

					}

				case DataType.Guid:
					{

						byte[] buffer1 = _br.ReadBytes(0x10);

						return new Guid(buffer1);

					}

				case DataType.IntPtr:
					{

						if (IntPtr.Size == 4)
						{

							return new IntPtr(_br.ReadInt32());

						}

						return new IntPtr(_br.ReadInt64());

					}

				case DataType.UIntPtr:
					{

						if (UIntPtr.Size == 4)
						{

							return new UIntPtr(_br.ReadUInt32());

						}

						return new UIntPtr(_br.ReadUInt64());

					}

				case DataType.Object:
					{

						BinaryFormatter formatter1 = new BinaryFormatter();
						byte[] buf = new byte[_br.BaseStream.Length];
						_br.BaseStream.Read(buf, 0, buf.Length);
						MemoryStream ms = new MemoryStream(buf);
						//ms.Position = 0;
						ms.Flush();
						return formatter1.Deserialize(ms);
						ms.Close();

					}

				case DataType.Null:
					{

						return null;

					}

				default:
					{

						return obj1;

					}

			}

		Label_00CA:

			if (num1 >= 4)
			{

				return new decimal(numArray1);

			}

			numArray1[num1] = _br.ReadInt32();

			num1++;

			goto Label_00CA;

		}

	}
	public class SessionCollection : CollectionBase
	{

		public JSessionParser this[int index]
		{

			get { return (JSessionParser)List[index]; }

			set { List[index] = value; }

		}

		public int Add(JSessionParser value)
		{

			return List.Add(value);

		}

	}

	public class SessionItem
	{

		#region properties

		private int _seekPosition;

		public int SeekPosition
		{

			get { return _seekPosition; }

			set { _seekPosition = value; }

		}

		private int _index;

		public int Index
		{

			get { return _index; }

			set { _index = value; }

		}

		private string _key;

		public string Key
		{

			get { return _key; }

			set { _key = value; }

		}

		private object _value;

		public object Value
		{

			get { return _value; }

			set { _value = value; }

		}

		#endregion

		public SessionItem() { }

		public SessionItem(int index, int seekPosition, string key, object value)
		{

			Index = index;

			SeekPosition = seekPosition;

			Key = key;

			Value = value;

		}

	}

	public class SessionItemCollection : CollectionBase
	{

		public SessionItem this[int index]
		{

			get { return (SessionItem)List[index]; }

			set { List[index] = value; }

		}

		public int Add(SessionItem value)
		{

			return List.Add(value);

		}

		public SessionItem this[string key]
		{

			get
			{

				for (int i = 0; i < this.Count; i++)
				{

					if (this[i].Key.Equals(key))
					{

						return this[i];

					}

				}

				return null;

			}

			set
			{

				for (int i = 0; i < this.Count; i++)
				{

					if (this[i].Key.Equals(key))
					{

						this[i] = value;

						break;

					}

				}

			}

		}

		public SessionItem FindBy(int index)
		{

			for (int i = 0; i < this.Count; i++)
			{

				if (this[i].Index == index)
				{

					return this[i];

				}

			}

			return null;

		}

	}
}