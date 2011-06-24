using System;

namespace QUANLYHOCSINHCAP3.BANGDIEM
{
	/// <summary>
	/// Summary description for BangDiemCtl.
	/// </summary>
	public class BangDiemCtl
	{
		private BangDiemInfo info=new BangDiemInfo();
		private BangDiemData data = new BangDiemData();

		public BangDiemInfo BangDiem
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
		public void tinhDTB(double D1,double D2,double D3)
		{
			info.TrungBinh = (((D1+D2*2)/3)*2+D3)/3;
		}

		public void insert_diemmon()
		{			
			data.insert_diemmon(info.MaDiemMon, info.MaMH, info.MaHK,info.MaHS,info.Diem1,info.Diem2,info.Diem3, info.TrungBinh);
			
		}
		public void delete_diemmon()
		{			
			data.delete_diemmon(info.MaDiemMon);
			
		}
		public void update_diemmon()
		{			
			data.update_diemmon(info.MaDiemMon ,info.Diem1,info.Diem2,info.Diem3, info.TrungBinh);
			
		}
		public void insert_CTDiem()
		{			
			
			data.insert_CTDiem(info.MaDiemMon,info.MaLoaiKT,info.Diem);
		}
		public void update_CTDiem()
		{			
			
			data.update_CTDiem(info.MaDiemMon,info.MaLoaiKT,info.Diem);
		}
		public void delete_CTDiem()
		{			
			data.delete_CTDiem(info.MaDiemMon);
			
		}
		public BangDiemCtl()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
