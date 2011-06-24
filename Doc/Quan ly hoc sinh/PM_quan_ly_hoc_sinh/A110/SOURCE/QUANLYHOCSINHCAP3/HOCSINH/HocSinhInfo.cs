using System;
using System.Data;
namespace QUANLYHOCSINHCAP3.HOCSINH
{
	/// <summary>
	/// Summary description for HocSinhInfo.
	/// </summary>
	public class HocSinhInfo
	{
		private string _maHS; 
		private string _tenHS;
		private string _phai;
		private string _diachi;
		private DateTime _ngaysinh;
		private string _maLop;
		private string _email;
		private int _siso;

		public HocSinhInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string MaHS
		{
			get{return _maHS;}
			set
			{
				if (value == null)
					throw new Exception("Ma hoc sinh khong duoc rong");
				_maHS = value;
			}
		}
		public string TenHS
		{
			get{return _tenHS;}
			set
			{
				if (value == null)
						throw new Exception("Ten hoc sinh khong duoc rong");
				_tenHS = value;
				
			}
		}
		public string DiaChi
		{
			get{return _diachi;}
			set
			{
				if (value == null)
					throw new Exception("Dia chi khong duoc rong");
				_diachi = value;
			}
		}
		public string Phai
		{
			get{return _phai;}
			set
			{
				if (value == null)
					throw new Exception("Phai khong duoc rong");
				_phai = value;
			}
		}
		public string Email
		 {
			 get{return _email;}
			 set
			 {
				 if (value == null)
					 throw new Exception("email khong duoc rong");
				 _email = value;
			 }
		 }
		public string MaLop
		{
			get{return _maLop;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_maLop = value;
			}
		}
		public DateTime NgaySinh
		{
			get{return _ngaysinh;}
			set
			{
				if (value.ToString() == null)
					throw new Exception("Ngay sinh HS khong duoc rong");
				_ngaysinh = value;
			}
		}
		public int Siso
		{
			get{return _siso;}
			set
			{
				if (value <0)
					throw new Exception("Si so khong duoc rong");
				_siso = value;
			}
		}
		
		
	}
}
