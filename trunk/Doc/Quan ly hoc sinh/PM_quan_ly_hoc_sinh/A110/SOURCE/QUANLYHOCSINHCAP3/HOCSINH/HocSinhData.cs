using System;
using System.Data;
using System.Data.OleDb;

namespace QUANLYHOCSINHCAP3.HOCSINH
{
	/// <summary>
	/// Summary description for HocSinhData.
	/// </summary>
	public class HocSinhData
	{
		QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
		OleDbParameter p= new OleDbParameter();
		public HocSinhData()
		{
			//
			// TODO: Add constructor logic here
			//
			_provider.command= new OleDbCommand ();
			
			_provider.connect();
		}
		public DataTable GetDanhSachHocSinh(string strSql)
		{

			OleDbDataAdapter adapter=new OleDbDataAdapter(strSql,QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString);
			DataSet dsHocSinh=new DataSet();
			adapter.Fill(dsHocSinh);
			return dsHocSinh.Tables[0];
			
		}
		public void insert(string maHS, string tenHS,string phai, DateTime ngaySinh, string diachi, string maLop, string email,int siso)
		{
			//string insertCommand = "INSERT INTO HOCSINH VALUES('" + maHS + "', '" +	tenHS + "','" + phai + "','" + ngaySinh.ToShortDateString() + "','" + diachi + "','"+ maLop +"','"+ email +"')";				
			//string insertCommand = "INSERT INTO HOCSINH(MAHS,hoten,phai,diachi,malop,email) VALUES('" + maHS + "','" +	tenHS + "','" + phai + "','" + diachi + "','"+ maLop +"','"+ email +"')";				
			//_provider.command= new OleDbCommand ();
			String ngay_sinh=ngaySinh.ToShortDateString();
			try
			{
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				_provider.command.CommandText="themhs";
				//			_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				//MAHS
				//OleDbParameter p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maHS;
				_provider.command.Parameters.Add(p);
				//HOTEN
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=tenHS;
				_provider.command.Parameters.Add(p);
			
				//PHAI
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=phai;
				_provider.command.Parameters.Add(p);
				//ngaysinh
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=ngay_sinh;
				_provider.command.Parameters.Add(p);

				//DIACHI
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=diachi;
				_provider.command.Parameters.Add(p);
				//MALOP
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maLop;
				_provider.command.Parameters.Add(p);
				//EMAIL
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=email;
				_provider.command.Parameters.Add(p);
				//SISO
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric  ;
				p.Value=siso;
				_provider.command.Parameters.Add(p);
			
				_provider.command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				throw new Exception(e.ToString());	
			}

			//_provider.executeNonQuery(insertCommand);
		}
		public void update(string maHS, string tenHS,string phai, DateTime ngaySinh, string diachi, string maLop,string email)
		{
			try
			{
				String ngay_sinh=ngaySinh.ToShortDateString();
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				_provider.command.CommandText="CAPNHAT_HOCSINH";
				//_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				//MAHS
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maHS;
				_provider.command.Parameters.Add(p);
				//HOTEN
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=tenHS;
				_provider.command.Parameters.Add(p);
			
				//PHAI
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=phai;
				_provider.command.Parameters.Add(p);
				//ngaysinh
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=ngay_sinh;
				_provider.command.Parameters.Add(p);

				//DIACHI
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=diachi;
				_provider.command.Parameters.Add(p);
				//EMAIL
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=email;
				_provider.command.Parameters.Add(p);
						
				_provider.command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				throw new Exception(e.ToString());	
			}

		}
		public void delete(string maHS,string maLop,int siso)
		{
			//string deleteCommand = "delete from DIEMMON where mahocsinh = '" + maHS + "'";				
			//_provider.executeNonQuery(deleteCommand);
			//string deleteCommand = "delete from HOCSINH where mahs = '" + maHS + "'";
			//_provider.executeNonQuery(deleteCommand);
			try
			{
				_provider.command.Connection =_provider.connection ;
				_provider.command.CommandType=System.Data.CommandType.StoredProcedure;
				_provider.command.CommandText="xoahocsinh";
				//MAHS
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar;
				p.Value=maHS;
				_provider.command.Parameters.Add(p);
				//MALOP
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input ;
				p.OleDbType=System.Data.OleDb.OleDbType.VarChar  ;
				p.Value=maLop;
				_provider.command.Parameters.Add(p);
				//SISO
				p= new OleDbParameter();
				p.Direction=System.Data.ParameterDirection.Input;
				p.OleDbType=System.Data.OleDb.OleDbType.Numeric;
				p.Value=siso;
				_provider.command.Parameters.Add(p);
				_provider.command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				throw new Exception(e.ToString());	
			}
		}
	
	}
}
