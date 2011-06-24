using System;
using System.Data;

namespace QUANLYHOCSINHCAP3.MONHOC
{
	/// <summary>
	/// Summary description for MonHocInfo.
	/// </summary>
	public class MonHocInfo
	{
		private string _maMon;
		private string _tenMon;
		public string MaMon
		{
			get{return _maMon;}
			set
			{
				if (value==null)
					
					throw new Exception("Ma mon khong duoc rong");
				_maMon=value;
			}
		}
		public string TenMon
		{
			get{return _tenMon;}
			set
			{
				if(value==null)
					throw new Exception("Ten lop khong duoc rong");
				_tenMon=value;
			}
		}
		
		public MonHocInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
