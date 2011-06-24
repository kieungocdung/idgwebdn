using System;
using System.Data;
namespace QUANLYHOCSINHCAP3.HOCKY
{
	/// <summary>
	/// Summary description for HocKyInfo.
	/// </summary>
	public class HocKyInfo
	{
		private string _maHocKi;
		private string _tenHocKi;
		public string MaHocKy
		{
			get{return _maHocKi;}
			set
			{
				if (value==null)
					
					throw new Exception("Ma mon khong duoc rong");
				_maHocKi=value;
			}
		}
		public string TenHocKy
		{
			get{return _tenHocKi;}
			set
			{
				if(value==null)
					throw new Exception("Ten lop khong duoc rong");
				_tenHocKi=value;
			}
		}
		public HocKyInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
