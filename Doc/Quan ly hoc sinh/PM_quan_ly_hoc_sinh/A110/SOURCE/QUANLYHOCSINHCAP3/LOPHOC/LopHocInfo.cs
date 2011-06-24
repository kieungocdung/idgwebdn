using System;
using System.Data;

namespace QUANLYHOCSINHCAP3.LOPHOC
{
	/// <summary>
	/// Summary description for LopHocInfo.
	/// </summary>
	public class LopHocInfo
	{
		private string _maLop;
		private string _tenLop;
		private string _siso;
		private string _makhoi;
		
		
		public string MaLop
		{
			get{return _maLop;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_maLop=value;
						 
			}
		}
		public string TenLop
		{
			get{return _tenLop;}
			set
			{
				if (value == null)
					throw new Exception("Ten lop khong duoc rong");
				_tenLop=value;
						 
			}
		}
		public string SiSo
		{
			get{return _siso;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_siso=value;
			}
		}
		public string MaKhoi
		{
			get{return _makhoi;}
			set
			{
				if (value == null)
					throw new Exception("Ma khoi khong duoc rong");
				_makhoi=value;
			}
		}
		public LopHocInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
