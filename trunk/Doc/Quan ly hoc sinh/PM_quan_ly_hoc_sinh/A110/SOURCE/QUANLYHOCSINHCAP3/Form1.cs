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
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem mnHeThong;
		private System.Windows.Forms.MenuItem mnDangNhap;
		private System.Windows.Forms.MenuItem mnThoat;
		private System.Windows.Forms.MenuItem mnLuuTru;
		private System.Windows.Forms.MenuItem mnTiepNhanHocSinh;
		private System.Windows.Forms.MenuItem mnNhapBangDiemMon;
		private System.Windows.Forms.MenuItem mnThayDoiQuiDinh;
		private System.Windows.Forms.MenuItem mnTimKiem;
		private System.Windows.Forms.MenuItem mnTraCuuHocSinh;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnBaobieu;
		FrmDangNhap frmDNhap = new FrmDangNhap();
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
		/// 
		
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.mnHeThong = new System.Windows.Forms.MenuItem();
			this.mnDangNhap = new System.Windows.Forms.MenuItem();
			this.mnThoat = new System.Windows.Forms.MenuItem();
			this.mnLuuTru = new System.Windows.Forms.MenuItem();
			this.mnTiepNhanHocSinh = new System.Windows.Forms.MenuItem();
			this.mnNhapBangDiemMon = new System.Windows.Forms.MenuItem();
			this.mnThayDoiQuiDinh = new System.Windows.Forms.MenuItem();
			this.mnTimKiem = new System.Windows.Forms.MenuItem();
			this.mnTraCuuHocSinh = new System.Windows.Forms.MenuItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnBaobieu = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			// 
			// mnHeThong
			// 
			this.mnHeThong.Index = 0;
			this.mnHeThong.MdiList = true;
			this.mnHeThong.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnDangNhap,
																					  this.mnThoat});
			this.mnHeThong.Text = "Hệ thống";
			this.mnHeThong.Click += new System.EventHandler(this.mnHeThong_Click);
			// 
			// mnDangNhap
			// 
			this.mnDangNhap.Index = 0;
			this.mnDangNhap.Text = "Đăng nhập";
			this.mnDangNhap.Click += new System.EventHandler(this.mnDangNhap_Click);
			// 
			// mnThoat
			// 
			this.mnThoat.Index = 1;
			this.mnThoat.Text = "Thoát";
			this.mnThoat.Click += new System.EventHandler(this.mnThoat_Click);
			// 
			// mnLuuTru
			// 
			this.mnLuuTru.Index = 1;
			this.mnLuuTru.MdiList = true;
			this.mnLuuTru.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnTiepNhanHocSinh,
																					 this.mnNhapBangDiemMon,
																					 this.mnThayDoiQuiDinh});
			this.mnLuuTru.Text = "Lưu trữ";
			// 
			// mnTiepNhanHocSinh
			// 
			this.mnTiepNhanHocSinh.Index = 0;
			this.mnTiepNhanHocSinh.MdiList = true;
			this.mnTiepNhanHocSinh.Text = "&Tiếp nhận học sinh";
			this.mnTiepNhanHocSinh.Click += new System.EventHandler(this.mnTiepNhanHocSinh_Click);
			// 
			// mnNhapBangDiemMon
			// 
			this.mnNhapBangDiemMon.Index = 1;
			this.mnNhapBangDiemMon.MdiList = true;
			this.mnNhapBangDiemMon.Text = "Nhập bảng điểm môn";
			this.mnNhapBangDiemMon.Click += new System.EventHandler(this.mnNhapBangDiemMon_Click);
			// 
			// mnThayDoiQuiDinh
			// 
			this.mnThayDoiQuiDinh.Index = 2;
			this.mnThayDoiQuiDinh.MdiList = true;
			this.mnThayDoiQuiDinh.Text = "Thay đổi qui định";
			this.mnThayDoiQuiDinh.Click += new System.EventHandler(this.mnThayDoiQuiDinh_Click);
			// 
			// mnTimKiem
			// 
			this.mnTimKiem.Index = 2;
			this.mnTimKiem.MdiList = true;
			this.mnTimKiem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnTraCuuHocSinh});
			this.mnTimKiem.Text = "Tìm kiếm";
			this.mnTimKiem.Click += new System.EventHandler(this.mnTimKiem_Click);
			// 
			// mnTraCuuHocSinh
			// 
			this.mnTraCuuHocSinh.Index = 0;
			this.mnTraCuuHocSinh.MdiList = true;
			this.mnTraCuuHocSinh.Text = "Tra cứu học sinh";
			this.mnTraCuuHocSinh.Click += new System.EventHandler(this.mnTraCuuHocSinh_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnHeThong,
																					  this.mnLuuTru,
																					  this.mnTimKiem,
																					  this.mnBaobieu});
			// 
			// mnBaobieu
			// 
			this.mnBaobieu.Index = 3;
			this.mnBaobieu.MdiList = true;
			this.mnBaobieu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			this.mnBaobieu.Text = "Báo biểu";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Bảng điểm lớp theo môn";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Bảng điểm học sinh";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Báo cáo theo học kỳ";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Báo cáo theo môn";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(544, 375);
			this.IsMdiContainer = true;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quan lý hoc sinh cap 3";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
			ShowMenu(false);
			FrmDangNhap frmDNhap = new FrmDangNhap();
			frmDNhap.MdiParent=this;
			
			frmDNhap.Show();
			
			

		}
		public void ShowMenu(bool show)
		{
			mnBaobieu.Enabled=show;
			mnTimKiem.Enabled=show;
			mnLuuTru.Enabled=show;
			
		}
		private void mnTiepNhanHocSinh_Click(object sender, System.EventArgs e)
		{
			Tiepnhanhocsinh frmTiepnhanHocsinh=new Tiepnhanhocsinh();
			frmTiepnhanHocsinh.MdiParent=this;
			frmTiepnhanHocsinh.Show();
		}

		private void mnHeThong_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mnBaoBieu_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mnTimKiem_Click(object sender, System.EventArgs e)
		{
			
		}

		private void mnNhapBangDiemMon_Click(object sender, System.EventArgs e)
		{
			FrmBangDiemMon frmBDMon=new FrmBangDiemMon();
			frmBDMon.MdiParent=this;
			frmBDMon.Show();
		}

		private void mnTraCuuHocSinh_Click(object sender, System.EventArgs e)
		{
			FrmTraCuu frmTracuu=new FrmTraCuu();
			frmTracuu.MdiParent=this;
			frmTracuu.Show();
		}

		private void mnTraCuuTheoLop_Click(object sender, System.EventArgs e)
		{
			FrmDanhSachLop frmDSLop=new FrmDanhSachLop();
			frmDSLop.MdiParent=this;
			frmDSLop.Show();
		}

		private void mnBaocaotongket_Click(object sender, System.EventArgs e)
		{
			/*FrmBaoCaoTongKetMon frmBCao=new FrmBaoCaoTongKetMon();
			frmBCao.MdiParent=this;
			frmBCao.Show();*/
		}

		private void mnThayDoiQuiDinh_Click(object sender, System.EventArgs e)
		{
			FrmThaydoiquidinh frmTDQDinh=new FrmThaydoiquidinh();
			frmTDQDinh.MdiParent=this;
			frmTDQDinh.Show();
		}

		private void mnThoat_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void mnDangNhap_Click(object sender, System.EventArgs e)
		{
			ShowMenu(false);
			FrmDangNhap frmDNhap = new FrmDangNhap();
			frmDNhap.MdiParent=this;
			frmDNhap.Show();

		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			FrmDanhSachLop frmDSLop=new FrmDanhSachLop();
			frmDSLop.nflag =0;
			frmDSLop.Show();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			FrmDanhSachLop frmDSLop=new FrmDanhSachLop();
			frmDSLop.nflag =1;
			frmDSLop.Show();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			FrmDanhSachLop frmDSLop=new FrmDanhSachLop();
			frmDSLop.nflag =2;
			frmDSLop.Show();		
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			FrmDanhSachLop frmDSLop=new FrmDanhSachLop();
			frmDSLop.nflag =4;
			frmDSLop.Show();	
		}

	}
}
