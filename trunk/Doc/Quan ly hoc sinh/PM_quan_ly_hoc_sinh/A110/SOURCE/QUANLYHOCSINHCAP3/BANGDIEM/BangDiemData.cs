using System;
using System.Data;
using System.Data.OleDb;

namespace QUANLYHOCSINHCAP3.BANGDIEM
{
	/// <summary>
	/// Summary description for BangDiemData.
	/// </summary>
	public class BangDiemData
	{
		QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
		OleDbParameter p= new OleDbParameter();
		public BangDiemData()
		{
			//
			// TODO: Add constructor logic here
			//
			_provider.command= new OleDbCommand ();
			_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
			_provider.connect();
			
		}
		public DataTable GetDanhSachDiemMon(string strsql)
		{
				
			OleDbDataAdapter adapter = new OleDbDataAdapter(strsql, QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
			DataSet dsDM = new DataSet();
			adapter.Fill(dsDM);
			return dsDM.Tables[0];
		}
		public DataTable GetDanhSachChiTietDiemMon(string strsql)
		{
				
			OleDbDataAdapter adapter = new OleDbDataAdapter(strsql, QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
			DataSet dsCTDM = new DataSet();
			adapter.Fill(dsCTDM);
			return dsCTDM.Tables[0];
		}
		public void insert_diemmon(int maDM, string maMH,string maHK,string maHS,double diem1,double diem2,double diem3, double TB)
		{
			//string insertCommand = "INSERT INTO DIEMMON VALUES(" + maDM + ", '" +	maMH + "','" + maHK + "','" + maHS + "', "+TB+" )";				
			//_provider.executeNonQuery(insertCommand);

			try
			{
				
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				_provider.command.CommandText="insert_diemmon";
				//maDM
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=maDM;
				_provider.command.Parameters.Add(p);
				//maMH
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maMH;
				_provider.command.Parameters.Add(p);
				//maHK
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maHK;
				_provider.command.Parameters.Add(p);
				//maHS
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maHS;
				_provider.command.Parameters.Add(p);
				//diem1
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem1;
				_provider.command.Parameters.Add(p);
				//diem2
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem2;
				_provider.command.Parameters.Add(p);
				//diem3
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem3;
				_provider.command.Parameters.Add(p);
				
				//TB
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=TB;
				_provider.command.Parameters.Add(p);
				_provider.command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				throw new Exception(e.ToString());	
			}

			
			
		}
		public void delete_diemmon(int maDM)
		{
			//string deleteCommand = "delete from DIEMMON where madiemmon="+maDM+"";				
			//_provider.executeNonQuery(deleteCommand);
			try
			{
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandText="XOA_DIEMMON";
				_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				//madiemmon
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Integer  ;
				p.Value=maDM;
				_provider.command.Parameters.Add(p);
			
				_provider.command.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				
				throw new Exception(e.ToString());	
			}
		}
		public void update_diemmon(int maDM , double diem1,double diem2 , double diem3, double TB)
		{
			//string updateCommand = "update DIEMMON set trungbinh="+TB+" where madiemmon="+maDM+"";				
			//_provider.executeNonQuery(updateCommand);
			try
			{
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandText="CAPNHAT_DIEM";
				_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				//madiemmon
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Integer  ;
				p.Value=maDM;
				_provider.command.Parameters.Add(p);
				//diem1
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem1;
				_provider.command.Parameters.Add(p);
				//diem2
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem2;
				_provider.command.Parameters.Add(p);
				//diem3
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem3;
				_provider.command.Parameters.Add(p);
				//TB
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=TB;
				_provider.command.Parameters.Add(p);

				_provider.command.ExecuteNonQuery();
			}
			catch(Exception e)
            {
				
			 throw new Exception(e.ToString());	
			}
		}
		public void insert_CTDiem(int maDM,int maLoaiKT, double diem)
		{
			
			string insertCommand = "INSERT INTO CHITIETDIEM VALUES(" +	maDM + "," + maLoaiKT + ", "+diem+") ";				
			_provider.executeNonQuery(insertCommand);
			
			/*try
			{
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandText="INSERT_CTDIEM";
				//maDM
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=maDM;
				_provider.command.Parameters.Add(p);
				//maLoaiKT
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=maLoaiKT;
				_provider.command.Parameters.Add(p);
				//diem
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=diem;
				_provider.command.Parameters.Add(p);
				_provider.command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.Write(e); 
			}*/
		}
		public void update_CTDiem(int maDM,int maLoaiKT, double diem)
		{
			string updateCommand = "update chitietdiem set diemso ="+diem+" where madmon=" + maDM + " and maloaikiemtra="+maLoaiKT+"";				
			_provider.executeNonQuery(updateCommand);
		}
		public void delete_CTDiem(int maDM)
		{
			string deleteCommand = "delete from chitietdiem where madmon="+maDM+"";				
			_provider.executeNonQuery(deleteCommand);
		}

	}
}
