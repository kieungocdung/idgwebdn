using System;

namespace QUANLYHOCSINHCAP3.HOCSINH
{
	/// <summary>
	/// Summary description for HocSinhCtl.
	/// </summary>
	public class HocSinhCtl
	{
		private HocSinhInfo info = new HocSinhInfo();
		private HocSinhData data = new HocSinhData();

		public HocSinhInfo HocSinh
		{
			get
			{
				return info;
			}
			set
			{
				info = value;
			}
		}
		
		public void insert()
		{			
			data.insert(info.MaHS, info.TenHS, info.Phai,info.NgaySinh, info.DiaChi,info.MaLop,info.Email,info.Siso);
		}

		public void delete()
		{
			data.delete(info.MaHS,info.MaLop,info.Siso);
		}

		public void update()
		{
			data.update(info.MaHS, info.TenHS, info.Phai,info.NgaySinh, info.DiaChi,info.MaLop,info.Email);
		}


		public HocSinhCtl()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
