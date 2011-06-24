using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
namespace QUANLYHOCSINHCAP3
{
	/// <summary>
	/// Summary description for FrmBangDiemMon.
	/// </summary>
	public class FrmBangDiemMon : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboLop;
		private System.Windows.Forms.ComboBox cboMon;
		private System.Windows.Forms.ComboBox cboHocky;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Button btnCapNhat;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.DataGrid dataBD;
		private int sohocsinh;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmBangDiemMon()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboLop = new System.Windows.Forms.ComboBox();
			this.cboMon = new System.Windows.Forms.ComboBox();
			this.cboHocky = new System.Windows.Forms.ComboBox();
			this.dataBD = new System.Windows.Forms.DataGrid();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnCapNhat = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataBD)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Crimson;
			this.label1.Location = new System.Drawing.Point(0, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(560, 45);
			this.label1.TabIndex = 9;
			this.label1.Text = "Bảng Điểm Môn Học ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox1.Location = new System.Drawing.Point(0, 41);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(560, 8);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(70, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 22);
			this.label2.TabIndex = 10;
			this.label2.Text = "Lớp";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(199, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 22);
			this.label3.TabIndex = 10;
			this.label3.Text = "Môn";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(347, 61);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 22);
			this.label4.TabIndex = 10;
			this.label4.Text = "Học kỳ";
			// 
			// cboLop
			// 
			this.cboLop.Location = new System.Drawing.Point(111, 59);
			this.cboLop.Name = "cboLop";
			this.cboLop.Size = new System.Drawing.Size(81, 27);
			this.cboLop.TabIndex = 11;
			this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
			// 
			// cboMon
			// 
			this.cboMon.Location = new System.Drawing.Point(245, 59);
			this.cboMon.Name = "cboMon";
			this.cboMon.Size = new System.Drawing.Size(91, 27);
			this.cboMon.TabIndex = 11;
			this.cboMon.SelectedIndexChanged += new System.EventHandler(this.cboMon_SelectedIndexChanged);
			// 
			// cboHocky
			// 
			this.cboHocky.Location = new System.Drawing.Point(411, 59);
			this.cboHocky.Name = "cboHocky";
			this.cboHocky.Size = new System.Drawing.Size(72, 27);
			this.cboHocky.TabIndex = 11;
			this.cboHocky.SelectedIndexChanged += new System.EventHandler(this.cboHocky_SelectedIndexChanged);
			// 
			// dataBD
			// 
			this.dataBD.DataMember = "";
			this.dataBD.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataBD.Location = new System.Drawing.Point(2, 96);
			this.dataBD.Name = "dataBD";
			this.dataBD.Size = new System.Drawing.Size(542, 224);
			this.dataBD.TabIndex = 12;
			this.dataBD.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataBD_Navigate);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox2.Location = new System.Drawing.Point(0, 326);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(560, 8);
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 322);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(560, 8);
			this.label5.TabIndex = 13;
			// 
			// btnThoat
			// 
			this.btnThoat.BackColor = System.Drawing.Color.Gray;
			this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThoat.ForeColor = System.Drawing.Color.White;
			this.btnThoat.Location = new System.Drawing.Point(352, 342);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.TabIndex = 15;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnLuu
			// 
			this.btnLuu.BackColor = System.Drawing.Color.Gray;
			this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLuu.ForeColor = System.Drawing.Color.White;
			this.btnLuu.Location = new System.Drawing.Point(125, 342);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(72, 23);
			this.btnLuu.TabIndex = 14;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// btnCapNhat
			// 
			this.btnCapNhat.BackColor = System.Drawing.Color.Gray;
			this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCapNhat.ForeColor = System.Drawing.Color.White;
			this.btnCapNhat.Location = new System.Drawing.Point(197, 342);
			this.btnCapNhat.Name = "btnCapNhat";
			this.btnCapNhat.Size = new System.Drawing.Size(80, 23);
			this.btnCapNhat.TabIndex = 14;
			this.btnCapNhat.Text = "Cập nhật";
			this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.BackColor = System.Drawing.Color.Gray;
			this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnXoa.ForeColor = System.Drawing.Color.White;
			this.btnXoa.Location = new System.Drawing.Point(277, 342);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.TabIndex = 14;
			this.btnXoa.Text = "Xoá";
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// FrmBangDiemMon
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.ClientSize = new System.Drawing.Size(552, 382);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dataBD);
			this.Controls.Add(this.cboLop);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cboMon);
			this.Controls.Add(this.cboHocky);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.btnLuu);
			this.Controls.Add(this.btnCapNhat);
			this.Controls.Add(this.btnXoa);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmBangDiemMon";
			this.Text = "FrmBangDiemMon";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmBangDiemMon_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataBD)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmBangDiemMon_Load(object sender, System.EventArgs e)
		{
			GetDanhSachMonHoc();
			Getdanhsachlop();
			GetDanhSachHocKi();
		
			LayBangDiem();
			
		}
		private void GetDanhSachHocKi()
		{
			string strSql="select * from hocki ";
			//QUANLYHOCSINHCAP3.HOCKY.HocKyData hocki = new QUANLYHOCSINHCAP3.HOCKY.HocKyData();
						
			//cboHocky.DataSource = hocki.GetDanhSachHocKi(strSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboHocky.DataSource=provider.LayDanhSach(strSql);
			cboHocky.DisplayMember = "MAHOCKI"; 
			cboHocky.ValueMember = "MAHOCKI";  
		}
		private void GetDanhSachMonHoc()
		{
			//string strSql="select * from monhoc where mamon not in(select mamonhoc from diemmon d,hocsinh h where h.mahs=d.mahocsinh and h.malop='"+cboLop.SelectedValue+"'and d.mahocky='"+cboHocky.SelectedValue+"' ) ";
			//QUANLYHOCSINHCAP3.MONHOC.MonHocData monhoc = new QUANLYHOCSINHCAP3.MONHOC.MonHocData();
			//cboMon.DataSource = monhoc.GetDanhSachMonHoc(strSql);
			string strSql="select * from monhoc  ";
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboMon.DataSource=provider.LayDanhSach(strSql);
			cboMon.DisplayMember = "TENMON"; 
			cboMon.ValueMember = "MAMON";	
			/*if(cboMon.Text=="")
			{
				btnLuu.Enabled=false;
				strSql="select * from monhoc";
				cboMon.DataSource=provider.LayDanhSach(strSql);
				cboMon.DisplayMember = "TENMON"; 
				cboMon.ValueMember = "MAMON";	
				btnCapNhat.Enabled=true;
				btnXoa.Enabled=true;
			}
			else
			{
				btnLuu.Enabled=true;
				btnCapNhat.Enabled=false;
				btnXoa.Enabled=false;
			}*/
		}	
		private void Getdanhsachlop()
		{
			string strSql="select * from lop ";
			//QUANLYHOCSINHCAP3.LOPHOC.LopHocData lop = new QUANLYHOCSINHCAP3.LOPHOC.LopHocData();
			//cboLop.DataSource = lop.Getdanhsachlop(strSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboLop.DataSource=provider.LayDanhSach(strSql);
			cboLop.DisplayMember = "TENLOP"; 
			cboLop.ValueMember = "MALOP";	
			

		}
		private void LayBangDiem()
		{
			DataColumn cot ;
			DataTable dsHS=new DataTable();
			string sSql;
			sSql = "select MAHS from hocsinh where MALOP='" + cboLop.SelectedValue + "'";
			//QUANLYHOCSINHCAP3.HOCSINH.HocSinhData HSData=new QUANLYHOCSINHCAP3.HOCSINH.HocSinhData();
			//dsHS= HSData.GetDanhSachHocSinh(sSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsHS=provider.LayDanhSach(sSql);
			sohocsinh=dsHS.DefaultView.Count;
			//tao cot Điểm 15 phút
			cot = new DataColumn();
			cot.ColumnName="Điểm 15 phút";
			cot.DataType=Type.GetType("System.Double");
			dsHS.Columns.Add(cot);
			//tao cot Điểm 1tiet
			cot = new DataColumn();
			cot.ColumnName="Điểm 1 tiết";
			cot.DataType=Type.GetType("System.Double");
			dsHS.Columns.Add(cot);
			//tao cot Điểm 1tiet
			cot = new DataColumn();
			cot.ColumnName="Điểm cuối HK";
			cot.DataType=Type.GetType("System.Double");
			dsHS.Columns.Add(cot);
			dataBD.DataSource =dsHS;
			khoitao();
			
		}
		private void btnThoat_Click(object sender, System.EventArgs e)
		{
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			provider.Disconnect();			
			this.Close();
		}

		private void cboLop_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetDanhSachMonHoc();
			LayBangDiem();
		}
		private int kiemtra()
		{
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select * from thamso ";
			dsTam=provider.LayDanhSach(sSql);
			int diemtoithieu=0,diemtoida=0,giatri=0;
			string mathamso;
			int i,j;
			for(i=0;i<dsTam.DefaultView.Count;i++)
			{
				mathamso=dsTam.DefaultView[i].Row["mathamso"].ToString();
				giatri=Convert.ToInt32(dsTam.DefaultView[i].Row["giatri"].ToString());
				if(mathamso=="TS4")
					diemtoithieu=giatri;
				if(mathamso=="TS5")
					diemtoida=giatri;
			}
			
			for(i=0;i<sohocsinh;i++)
			{
				
				for(j=1;j<4;j++)
					if(Convert.ToInt32(dataBD[i,j])<diemtoithieu ||Convert.ToInt32(dataBD[i,j])>diemtoida)
						return 0;
			}
			return 1;
		}
		private void khoitao()
		{
			int i,j;
			for(i=0;i<sohocsinh;i++)
				for(j=1;j<4;j++)
					dataBD[i,j]=0.0;
						
		}
		private int Tao_MaDiemMon()
		{
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select madiemmon from diemmon order by madiemmon asc";
			
			dsTam=provider.LayDanhSach(sSql);
			int madiemmon =0;
			int s=0;
			for(int i=0;i<dsTam.DefaultView.Count;i++)
			{
				madiemmon=Convert.ToInt32(dsTam.DefaultView[i].Row["madiemmon"].ToString());
				if(madiemmon ==(s+1))
					s=madiemmon;
				else
				{
					s=s+1;
					break;
				}
			}	
	
			if(s==0)
				s=s+1;
	
			else if(s == madiemmon)		
				s=s+1;
			return s;
			
		}
		private void luu_bangdiem(int i)
		{
			QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl bdcl = new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl();
			int sodiemmon=Tao_MaDiemMon();
			bdcl.BangDiem.MaDiemMon=sodiemmon;
			bdcl.BangDiem.MaHK = cboHocky.Text;
			bdcl.BangDiem.MaMH=(string)cboMon.SelectedValue;	
			bdcl.BangDiem.MaHS=(string)dataBD[i,0];
			bdcl.tinhDTB(Convert.ToDouble(dataBD[i,1]),Convert.ToDouble(dataBD[i,2]),Convert.ToDouble(dataBD[i,3]));
			bdcl.BangDiem.Diem1=Convert.ToDouble(dataBD[i,1]);
			bdcl.BangDiem.Diem2=Convert.ToDouble(dataBD[i,2]);
			bdcl.BangDiem.Diem3=Convert.ToDouble(dataBD[i,3]);
			bdcl.insert_diemmon();
			/*for (int j=1;j<4;j++)
			{
					bdcl.BangDiem.Diem=Convert.ToDouble(dataBD[i,j]);
					bdcl.BangDiem.MaLoaiKT=j;
					bdcl.insert_CTDiem();
			}*/	
		}
		private void btnLuu_Click(object sender, System.EventArgs e)
		{
			
			if(sohocsinh==0)
				MessageBox.Show("Không tồn tại học sinh nào trong lớp "+cboLop.Text+".Không thể nhập bảng điểm  cho lớp !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				if(kiemtra()==1)
				{
					QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl bdcl = new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl();
					DialogResult nut;
					int sodiemmon;
					int i;
					for (i=0;i<sohocsinh;i++)
					{
						sodiemmon=Lay_MaDiemMon(Convert.ToString(dataBD[i,0]),Convert.ToString(cboHocky.SelectedValue),Convert.ToString(cboMon.SelectedValue));
						if(sodiemmon==0)
						{
							/*sodiemmon=Tao_MaDiemMon();
							bdcl.BangDiem.MaDiemMon=sodiemmon;
							bdcl.BangDiem.MaHK = cboHocky.Text;
							bdcl.BangDiem.MaMH=(string)cboMon.SelectedValue;	
							bdcl.BangDiem.MaHS=(string)dataBD[i,0];
							bdcl.tinhDTB(Convert.ToDouble(dataBD[i,1]),Convert.ToDouble(dataBD[i,2]),Convert.ToDouble(dataBD[i,3]));
							bdcl.BangDiem.Diem1=Convert.ToDouble(dataBD[i,1]);
							bdcl.BangDiem.Diem2=Convert.ToDouble(dataBD[i,2]);
							bdcl.BangDiem.Diem3=Convert.ToDouble(dataBD[i,3]);
							bdcl.insert_diemmon();
							for (j=1;j<4;j++)
							{
								bdcl.BangDiem.Diem=Convert.ToDouble(dataBD[i,j]);
								bdcl.BangDiem.MaLoaiKT=j;
								bdcl.insert_CTDiem();
							}	*/
							luu_bangdiem(i);
						}
						else
						{
							nut=MessageBox.Show("Điểm môn "+cboMon.Text+" đã nhập cho học sinh "+dataBD[i,0]+" . Bạn có muốn cập nhật điểm cho học sinh này không ??? ","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
							if(nut==DialogResult.Yes)
								capnhat_bangdiem(i,sodiemmon);
						}
					}
					
					MessageBox.Show("Lưu thành công ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
				
						MessageBox.Show("Điểm bạn nhập không thỏa qui định !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}	
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cboHocky_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetDanhSachMonHoc();
		}
		private int Lay_MaDiemMon(string mahs,string mahocky,string mamon)
		{
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select madiemmon from diemmon where mahocsinh='"+mahs+"' and mahocky='"+mahocky+"' and mamonhoc='"+mamon+"'";
			dsTam=provider.LayDanhSach(sSql);
			int madiemmon =0;
			if(dsTam.DefaultView.Count!=0)
				madiemmon=Convert.ToInt32(dsTam.DefaultView[0].Row["madiemmon"].ToString());
			return madiemmon;
		}
		private void btnXoa_Click(object sender, System.EventArgs e)
		{
			
			int madiemmon ,i;
			DialogResult nut;
			QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl BDCtl=new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl();
			if(sohocsinh!=0)
			{
				i=dataBD.CurrentCell.RowNumber;
				madiemmon=Lay_MaDiemMon(Convert.ToString(dataBD[i,0]),Convert.ToString(cboHocky.SelectedValue),Convert.ToString(cboMon.SelectedValue));
				if(madiemmon!=0)	
				{
					nut=MessageBox.Show("Bạn có muốn xoá điểm môn "+ cboMon.Text+" của học sinh "+dataBD[i,0]+" ? ","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
					if(nut==DialogResult.Yes)
					{
						
						BDCtl.BangDiem.MaDiemMon=madiemmon;
						BDCtl.delete_diemmon();
						MessageBox.Show("Xoá thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
				else
					MessageBox.Show("Điểm môn "+ cboMon.Text+" của học sinh "+dataBD[i,0]+" chưa tồn tại . Không thể xoá ??? ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else

				MessageBox.Show("Không tồn tại học sinh nào trong lớp "+cboLop.Text+".Không thể xoá điểm  của lớp !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			

		}
		private void capnhat_bangdiem(int i,int madiemmon)
		{
				QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl bdcl = new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl();
				bdcl.BangDiem.MaDiemMon=madiemmon;
				bdcl.BangDiem.MaHK = cboHocky.Text;
				bdcl.BangDiem.MaMH=(string)cboMon.SelectedValue;	
				bdcl.BangDiem.MaHS=(string)dataBD[i,0];
				bdcl.tinhDTB(Convert.ToDouble(dataBD[i,1]),Convert.ToDouble(dataBD[i,2]),Convert.ToDouble(dataBD[i,3]));
				bdcl.BangDiem.Diem1=Convert.ToDouble(dataBD[i,1]);
				bdcl.BangDiem.Diem2=Convert.ToDouble(dataBD[i,2]);
				bdcl.BangDiem.Diem3=Convert.ToDouble(dataBD[i,3]);
				/*for (int j=1;j<4;j++)
				{
					bdcl.BangDiem.Diem=Convert.ToDouble(dataBD[i,j]);
					bdcl.BangDiem.MaLoaiKT=j;
					bdcl.update_CTDiem();
				}*/	
				bdcl.update_diemmon();
				MessageBox.Show("Cập nhật thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
							
					
			/*if(kiemtra()==1)
			{
				QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl bdcl = new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl();
				DialogResult nut;
				int sodiemmon;
				int i,j;
				//int i;
				//for (i=0;i<sohocsinh;i++)
				//{
				i=dataBD.CurrentCell.RowNumber;
				
				sodiemmon=Lay_MaDiemMon(Convert.ToString(dataBD[dataBD.CurrentCell.RowNumber,0]),Convert.ToString(cboHocky.SelectedValue),Convert.ToString(cboMon.SelectedValue));
				//sodiemmon=Lay_MaDiemMon(Convert.ToString(dataBD[i,0]),Convert.ToString(cboHocky.SelectedValue),Convert.ToString(cboMon.SelectedValue));
				if(sodiemmon!=0)
				{
						
					nut=MessageBox.Show("Bạn có muốn cập nhật điểm "+ cboMon.Text+" cho học sinh "+dataBD[i,0]+" ? ","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
					if(nut==DialogResult.Yes)
					{
						
						bdcl.BangDiem.MaDiemMon=sodiemmon;
						bdcl.BangDiem.MaHK = cboHocky.Text;
						bdcl.BangDiem.MaMH=(string)cboMon.SelectedValue;	
						bdcl.BangDiem.MaHS=(string)dataBD[i,0];
						bdcl.tinhDTB(Convert.ToDouble(dataBD[i,1]),Convert.ToDouble(dataBD[i,2]),Convert.ToDouble(dataBD[i,3]));
						bdcl.BangDiem.Diem1=Convert.ToDouble(dataBD[i,1]);
						bdcl.BangDiem.Diem2=Convert.ToDouble(dataBD[i,2]);
						bdcl.BangDiem.Diem3=Convert.ToDouble(dataBD[i,3]);
						
						for (j=1;j<4;j++)
						{
							bdcl.BangDiem.Diem=Convert.ToDouble(dataBD[i,j]);
							bdcl.BangDiem.MaLoaiKT=j;
							bdcl.update_CTDiem();
						}	
						bdcl.update_diemmon();
						MessageBox.Show("Cập nhật thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
							
					}
				}
				else
					MessageBox.Show("Điểm "+ cboMon.SelectedValue+" chưa nhập cho hoc sinh có mã số "+dataBD[i,0]+"","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				//}
				//MessageBox.Show("Cập nhật thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				//GetDanhSachMonHoc();
			}
			else
				MessageBox.Show("Điểm bạn nhập không thỏa qui định !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);*/
		}
			
		private void btnCapNhat_Click(object sender, System.EventArgs e)
		{
			
			if(sohocsinh==0)
				MessageBox.Show("Không tồn tại học sinh nào trong lớp "+cboLop.Text+".Không thể cập nhập bảng điểm  cho lớp !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				if(kiemtra()==1)
				{
					QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl bdcl = new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemCtl();
					DialogResult nut;
					int sodiemmon , i;
					i=dataBD.CurrentCell.RowNumber;
					sodiemmon=Lay_MaDiemMon(Convert.ToString(dataBD[i,0]),Convert.ToString(cboHocky.SelectedValue),Convert.ToString(cboMon.SelectedValue));
					if(sodiemmon!=0)
					{
						nut=MessageBox.Show("Bạn có muốn cập nhật điểm "+ cboMon.Text+" cho học sinh "+dataBD[i,0]+" ? ","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if(nut==DialogResult.Yes)
							capnhat_bangdiem(i,sodiemmon);
					}
					else
					{
						nut=MessageBox.Show("Điểm môn "+ cboMon.SelectedValue+" chưa nhập cho hoc sinh có mã số "+dataBD[i,0]+".Bạn có muốn lưu điểm môn cho học sinh này không ???","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
						if(nut==DialogResult.Yes)
						{
							luu_bangdiem(i);
							MessageBox.Show("Lưu thành công ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
					}				
				}
				else
					MessageBox.Show("Điểm bạn nhập không thỏa qui định !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void cboMon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dataBD_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

	}
}
