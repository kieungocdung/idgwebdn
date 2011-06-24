using System;
using System.Data;

namespace QUANLYHOCSINHCAP3.THAMSO
{
	/// <summary>
	/// Summary description for ThamSoInfo.
	/// </summary>
	public class ThamSoInfo
	{
		private string _maTS; 
		private string _tenTS;
		private int _giatri;
		private string _ghichu;
		
		public string MaTS
		{
			get{return _maTS;}
			set
			{
				if (value == null)
					throw new Exception("Ma tham so khong duoc rong");
				_maTS = value;
			}
		}
		public string TenTS
		{
			get{return _tenTS;}
			set
			{
				if (value == null)
					throw new Exception("Ten tham so khong duoc rong");
				_tenTS = value;
			}
		}
		public int GiaTri
		{
			get{return _giatri;}
			set
			{
				if (value <0)
					throw new Exception("Gia tri tham so khong duoc rong");
				_giatri = value;
			}
		}
		public string GhiChu
		{
			get{return _ghichu;}
			set
			{
				if (value == null)
					throw new Exception("Ghi chu tham so khong duoc rong");
				_ghichu = value;
			}
		}
		public ThamSoInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
