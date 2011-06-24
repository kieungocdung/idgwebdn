using System;
using System.Data;
using System.Data.OleDb;

namespace QUANLYHOCSINHCAP3.KNCSDL
{
	/// <summary>
	/// Summary description for DataProvider.
	/// </summary>
	public class DataProvider
	{
		protected static string _connectionString;
		public int flag;
		protected static string _username;
		protected static string _password;
		protected static string _service;
		protected static string _malop;
		public OleDbConnection connection;
		protected OleDbDataAdapter adapter;
		public OleDbCommand command;
		public static string ConnectionString
		{
			get
			{
				return _connectionString;
			}
			set
			{
				_connectionString=value;
			}
		}
		public static string MaLop
		{
			get{return _malop;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_malop=value;
						 
			}
		}
		
		public static string Username
		{
			get{return _username;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_username=value;
						 
			}
		}
		public static string Password
		{
			get{return _password;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_password=value;
						 
			}
		}
		public static string Service
		{
			get{return _service;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				_service=value;
						 
			}
		}
		//ham ket noi CSDL
		
		public void connect()
		{
			flag=0;
			connection=new OleDbConnection();
			connection.ConnectionString=ConnectionString;
			try
			{
				//mo ket noi co so du lieu
				connection.Open();
				//in thong bao mo ket noi thanh cong
				Console.WriteLine("Mở kết nối thành công !!!!");
				flag=1;
			}
			catch (Exception e)
			{
				Console.Write(e.ToString()); 
			}
		}
		//ham ngat ket noi
		public void Disconnect()
		{
			connection=new OleDbConnection();
			connection.ConnectionString=ConnectionString;
			connection.Close();
		}
		public DataTable LayDanhSach(string strsql)
		{
				
			adapter = new OleDbDataAdapter(strsql, ConnectionString);
			DataSet danhsach = new DataSet();
			adapter.Fill(danhsach);
			Disconnect();
			return danhsach.Tables[0];
		}
		public IDataReader executeQuery(string sqlString)
		{
			command=new OleDbCommand(sqlString,connection);
			return command.ExecuteReader();
		}
		public void executeNonQuery(string sqlString)//Tra ve nhieu dong
		{
			command = new OleDbCommand(sqlString, connection);
			command.ExecuteNonQuery();
		}
		public object executeScalar(string sqlString)// Su dung cho tra ve mot gia tri (vi du : select max(cot))  
		{
			command = new OleDbCommand(sqlString, connection);
			return command.ExecuteScalar();
		}
		public DataProvider()
		{
			//
			// TODO: Add constructor logic here
			//
			//string file=System.IO.Directory.GetCurrentDirectory();
			//file=file+"\\QUANLYHOCSINH.mdb";
			
			//string path = "Provider=MSDAORA.1;Data Source="+Service+" ;User ID="+Username+";Password="+Password+";Persist Security Info=True";
			//string path = "Provider=MSDAORA.1;Data Source= ora;User ID=thanh;Password=thanh;Persist Security Info=True";
			//ConnectionString=Path;
			
		}
	}
}
