using System;
using System.Data;

namespace QUANLYHOCSINHCAP3.KHOI
{
	/// <summary>
	/// Summary description for KhoiInfo.
	/// </summary>
	public class KhoiInfo
	{
		private string _makhoi;
		private string _tenkhoi;
		
		public string MaKhoi
		{
			get{return _makhoi;}
			set
			{
				if (value==null)
					
					throw new Exception("Ma khoi khong duoc rong");
				_makhoi=value;
			}
		}
		public string TenKhoi
		{
			get{return _tenkhoi;}
			set
			{
				if(value==null)
					throw new Exception("Ten lop khong duoc rong");
				_tenkhoi=value;
			}
		}
		public KhoiInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
