using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace QUANLYHOCSINHCAP3.LOPHOC
	{
		/// <summary>
		/// Summary description for LopHocData.
		/// </summary>
		/// 
		
		public class LopHocData
		{
			private QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			
			public LopHocData()
			{
				//
				// TODO: Add constructor logic here
				//
				_provider.connect();
			}
			public DataTable Getdanhsachlop(string strsql)
			{
				
				OleDbDataAdapter adapter = new OleDbDataAdapter(strsql, QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
				DataSet dsLop = new DataSet();
				adapter.Fill(dsLop);
				return dsLop.Tables[0];
			}
		}
	}

