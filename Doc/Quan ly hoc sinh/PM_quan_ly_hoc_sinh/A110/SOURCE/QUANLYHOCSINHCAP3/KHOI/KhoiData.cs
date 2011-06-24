using System;
using System.Data;
using System.Data.OleDb;
namespace QUANLYHOCSINHCAP3.KHOI
{
	/// <summary>
	/// Summary description for KhoiData.
	/// </summary>
	public class KhoiData
	{
		private QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();

		public KhoiData()
		{
			//
			// TODO: Add constructor logic here
			//
			_provider.connect();
		}
		public DataTable GetDanhSachKhoi(string strSql)
		{
			OleDbDataAdapter adapter=new OleDbDataAdapter(strSql,QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
			DataSet dsKhoi= new DataSet();
			adapter.Fill(dsKhoi);
			return dsKhoi.Tables[0];
			
		}
	}
}
