using System;

namespace QUANLYHOCSINHCAP3.BANGDIEM
{
	/// <summary>
	/// Summary description for BangDiemInfo.
	/// </summary>
	public class BangDiemInfo
	{
		//private string _maChiTietDiem; 
		private int _maDiemMon; 
		private string _maMH; 
		private string _maHK;
		private string _maHS;
		private int _maLoaiKT;
		private double _diem;
		private double _diem1;
		private double _diem2;
		private double _diem3;
		private double _trungbinh;
		
		public BangDiemInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/*public string MaChiTietDiem
		{
			get{return _maChiTietDiem;}
			set
			{
				if (value == null)
					throw new Exception("Ma chi tiet diem khong duoc rong");
				_maChiTietDiem = value;
			}
		}*/
		
		public int MaDiemMon
		{
			get{return _maDiemMon;}
			set
			{
				if (value <0)
					throw new Exception("Ma diem mon khong duoc rong");
				_maDiemMon = value;
			}
		}
		public double TrungBinh
		{
			get{return _trungbinh;}
			set
			{
				if (value <0)
					throw new Exception("Diem mon hoc khong duoc am");
				_trungbinh = value;
			}
		}
		public Double Diem
		{
			get{return _diem;}
			set
			{
				if (value < 0 )
					
					throw new Exception("Diem mon hoc khong duoc am");
				_diem = value;
			}
		}
		
		public Double Diem1
		{
			get{return _diem1;}
			set
			{
				if (value < 0 )
					throw new Exception("Ma mon hoc khong duoc am");
				_diem1 = value;
			}
		}
		public Double Diem2
		{
			get{return _diem2;}
			set
			{
				if (value < 0 )
					throw new Exception("Ma mon hoc khong duoc am");
				_diem2 = value;
			}
		}
		public Double Diem3
		{
			get{return _diem3;}
			set
			{
				if (value < 0 )
					throw new Exception("Ma mon hoc khong duoc am");
				_diem3 = value;
			}
		}

		
		public int MaLoaiKT
		{
			get{return _maLoaiKT;}
			set
			{
				if (value <=0)
					throw new Exception("Loai kiem tra khong duoc rong");
				_maLoaiKT = value;
			}
		}
		public string MaHK
		{
			get{return _maHK;}
			set
			{
				if (value == null)
					throw new Exception("Ma mon hoc khong duoc rong");
				_maHK = value;
			}
		}
		public string MaMH
		{
			get{return _maMH;}
			set
			{
				if (value == null)
					throw new Exception("Ma mon hoc khong duoc rong");
				_maMH = value;
			}
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
		
	}
}
