using System;

namespace QUANLYHOCSINHCAP3.THAMSO
{
	/// <summary>
	/// Summary description for ThamSoCtl.
	/// </summary>
	public class ThamSoCtl
	{
		private ThamSoInfo info = new  ThamSoInfo();
		private ThamSoData data = new ThamSoData();

		public ThamSoInfo ThamSo
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
			data.insert(info.MaTS, info.TenTS, info.GiaTri,info.GhiChu);
		}

		public void update()
		{
			data.update(info.MaTS, info.TenTS, info.GiaTri,info.GhiChu);
		}


		public ThamSoCtl()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
