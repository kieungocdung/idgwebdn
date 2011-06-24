using System;
using System.Data;
using System.Data.OleDb;
namespace QUANLYHOCSINHCAP3.HOCKY
{
	/// <summary>
	/// Summary description for HocKyData.
	/// </summary>
	public class HocKyData
	{
		private QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
		public HocKyData()
		{
			//
			// TODO: Add constructor logic here
			//
			_provider.connect();
		}
		public DataTable GetDanhSachHocKi(string strsql)
		{
				
			OleDbDataAdapter adapter = new OleDbDataAdapter(strsql, QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
			DataSet dsHocKi= new DataSet();
			adapter.Fill(dsHocKi);
			return dsHocKi.Tables[0];
			
		}

	}
}
