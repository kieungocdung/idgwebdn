using System;
using System.Data;
using System.Data.OleDb;

namespace QUANLYHOCSINHCAP3.THAMSO
{
	/// <summary>
	/// Summary description for ThamSoData.
	/// </summary>
	public class ThamSoData
	{
		QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
		OleDbParameter p= new OleDbParameter();
		public ThamSoData()
		{
			//
			// TODO: Add constructor logic here
			//
			_provider.command= new OleDbCommand ();
			//_provider.command.Connection =_provider.connection ;
			_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
			_provider.connect();
		}
		
		
		public void insert(string maTS, string tenTS,int GiaTri, string Ghichu)
		{
			//string insertCommand = "INSERT INTO thamso VALUES('" + maTS + "', '" +	tenTS + "'," + GiaTri + ",'" + Ghichu + "')";				
			//_provider.executeNonQuery(insertCommand);
			_provider.command.Connection =_provider.connection ;
			_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
			_provider.command.CommandText="them_thamso";
			
			//MATS
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
			p.Value=maTS;
			_provider.command.Parameters.Add(p);
			//tenTS
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
			p.Value=tenTS;
			_provider.command.Parameters.Add(p);
			//giatri
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.Integer  ;
			p.Value=GiaTri;
			_provider.command.Parameters.Add(p);
			//ghi chu
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
			p.Value=Ghichu;
			_provider.command.Parameters.Add(p);
			_provider.command.ExecuteNonQuery();


		}
		public void update(string maTS, string tenTS,int GiaTri, string Ghichu)
		{
			
			//string updateCommand="update thamso set tenthamso='"+tenTS+"',giatri='"+GiaTri+"',ghichu='"+Ghichu+"' where mathamso='"+maTS+"'";
			//_provider.executeNonQuery(updateCommand);
			_provider.command.Connection =_provider.connection ;
			_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
			_provider.command.CommandText="capnhat_thamso";
			
			//MATS
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
			p.Value=maTS;
			_provider.command.Parameters.Add(p);
			//tenTS
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
			p.Value=tenTS;
			_provider.command.Parameters.Add(p);
			//giatri
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.Integer  ;
			p.Value=GiaTri;
			_provider.command.Parameters.Add(p);
			//ghi chu
			p= new OleDbParameter();						
			p.Direction=System.Data.ParameterDirection.Input ;
			p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
			p.Value=Ghichu;
			_provider.command.Parameters.Add(p);
			_provider.command.ExecuteNonQuery();

		}
	}
}
