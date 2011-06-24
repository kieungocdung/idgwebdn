using System;
using System.Data;
using System.Data.OleDb;

namespace QUANLYHOCSINHCAP3.MONHOC
{
	/// <summary>
	/// Summary description for MonHocData.
	/// </summary>
	public class MonHocData
	{
		private QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
		public MonHocData()
		{
			//
			// TODO: Add constructor logic here
			//
			_provider.connect();
		}
		public DataTable GetDanhSachMonHoc(string strsql)
		{
				
			OleDbDataAdapter adapter = new OleDbDataAdapter(strsql, QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
			DataSet dsMonHoc= new DataSet();
			adapter.Fill(dsMonHoc);
			return dsMonHoc.Tables[0];
			
		}
	}
}
