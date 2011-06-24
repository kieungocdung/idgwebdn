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
	/// Summary description for Tiepnhanhocsinh.
	/// </summary>
	public class Tiepnhanhocsinh : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMaso;
		private System.Windows.Forms.ComboBox cboKhoi;
		private System.Windows.Forms.DateTimePicker dtpNgaySinh;
		private System.Windows.Forms.ComboBox cboLop;
		private System.Windows.Forms.TextBox txtHoTen;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtSiSo;
		private System.Windows.Forms.Button btnTiepNhan;
		private System.Windows.Forms.ComboBox cboGioiTinh;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnTimkiem;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.DataGrid dataDS;
		private int sohs;
		private System.Windows.Forms.Button btnCapNhat;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Tiepnhanhocsinh()
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
			this.txtMaso = new System.Windows.Forms.TextBox();
			this.cboKhoi = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtHoTen = new System.Windows.Forms.TextBox();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.cboGioiTinh = new System.Windows.Forms.ComboBox();
			this.btnTiepNhan = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cboLop = new System.Windows.Forms.ComboBox();
			this.txtSiSo = new System.Windows.Forms.TextBox();
			this.btnThoat = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnTimkiem = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataDS = new System.Windows.Forms.DataGrid();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btnCapNhat = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataDS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Cornsilk;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Crimson;
			this.label1.Location = new System.Drawing.Point(0, -1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(544, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tiếp nhận học sinh";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txtMaso
			// 
			this.txtMaso.Enabled = false;
			this.txtMaso.Location = new System.Drawing.Point(80, 24);
			this.txtMaso.Name = "txtMaso";
			this.txtMaso.Size = new System.Drawing.Size(128, 26);
			this.txtMaso.TabIndex = 4;
			this.txtMaso.Text = "";
			this.txtMaso.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// cboKhoi
			// 
			this.cboKhoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboKhoi.Location = new System.Drawing.Point(154, 63);
			this.cboKhoi.Name = "cboKhoi";
			this.cboKhoi.Size = new System.Drawing.Size(48, 27);
			this.cboKhoi.TabIndex = 1;
			this.cboKhoi.SelectedIndexChanged += new System.EventHandler(this.cboKhoi_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtpNgaySinh);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtMaso);
			this.groupBox1.Controls.Add(this.txtHoTen);
			this.groupBox1.Controls.Add(this.txtDiaChi);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.txtEmail);
			this.groupBox1.Controls.Add(this.cboGioiTinh);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.DeepPink;
			this.groupBox1.Location = new System.Drawing.Point(206, 109);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 184);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin học sinh";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// dtpNgaySinh
			// 
			this.dtpNgaySinh.Location = new System.Drawing.Point(80, 84);
			this.dtpNgaySinh.Name = "dtpNgaySinh";
			this.dtpNgaySinh.Size = new System.Drawing.Size(88, 26);
			this.dtpNgaySinh.TabIndex = 6;
			this.dtpNgaySinh.ValueChanged += new System.EventHandler(this.dtpNgaySinh_ValueChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Mã số";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label6.Location = new System.Drawing.Point(8, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Họ Tên";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label7.Location = new System.Drawing.Point(8, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 23);
			this.label7.TabIndex = 0;
			this.label7.Text = "Ngày sinh";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label8.Location = new System.Drawing.Point(176, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "Giới tính";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label9.Location = new System.Drawing.Point(8, 120);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "Địa chỉ";
			// 
			// txtHoTen
			// 
			this.txtHoTen.Location = new System.Drawing.Point(80, 54);
			this.txtHoTen.Name = "txtHoTen";
			this.txtHoTen.Size = new System.Drawing.Size(240, 26);
			this.txtHoTen.TabIndex = 5;
			this.txtHoTen.Text = "";
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Location = new System.Drawing.Point(80, 119);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(240, 26);
			this.txtDiaChi.TabIndex = 8;
			this.txtDiaChi.Text = "";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label10.Location = new System.Drawing.Point(8, 151);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Email";
			this.label10.Click += new System.EventHandler(this.label10_Click);
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(80, 149);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(240, 26);
			this.txtEmail.TabIndex = 9;
			this.txtEmail.Text = "";
			// 
			// cboGioiTinh
			// 
			this.cboGioiTinh.DisplayMember = "Nam";
			this.cboGioiTinh.Location = new System.Drawing.Point(256, 88);
			this.cboGioiTinh.Name = "cboGioiTinh";
			this.cboGioiTinh.Size = new System.Drawing.Size(64, 27);
			this.cboGioiTinh.TabIndex = 7;
			// 
			// btnTiepNhan
			// 
			this.btnTiepNhan.BackColor = System.Drawing.Color.Gray;
			this.btnTiepNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTiepNhan.ForeColor = System.Drawing.Color.White;
			this.btnTiepNhan.Location = new System.Drawing.Point(20, 336);
			this.btnTiepNhan.Name = "btnTiepNhan";
			this.btnTiepNhan.Size = new System.Drawing.Size(88, 27);
			this.btnTiepNhan.TabIndex = 10;
			this.btnTiepNhan.Text = "Tiếp nhận";
			this.btnTiepNhan.Click += new System.EventHandler(this.btnTiepNhan_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(95, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Khối";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(213, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Lớp";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(343, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Sỉ số";
			// 
			// cboLop
			// 
			this.cboLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboLop.Location = new System.Drawing.Point(258, 63);
			this.cboLop.Name = "cboLop";
			this.cboLop.Size = new System.Drawing.Size(72, 27);
			this.cboLop.TabIndex = 2;
			this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
			// 
			// txtSiSo
			// 
			this.txtSiSo.Enabled = false;
			this.txtSiSo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSiSo.Location = new System.Drawing.Point(402, 63);
			this.txtSiSo.Name = "txtSiSo";
			this.txtSiSo.Size = new System.Drawing.Size(40, 26);
			this.txtSiSo.TabIndex = 3;
			this.txtSiSo.Text = "";
			// 
			// btnThoat
			// 
			this.btnThoat.BackColor = System.Drawing.Color.Gray;
			this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThoat.ForeColor = System.Drawing.Color.White;
			this.btnThoat.Location = new System.Drawing.Point(458, 336);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(68, 27);
			this.btnThoat.TabIndex = 14;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(0, 293);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(488, 8);
			this.label11.TabIndex = 6;
			// 
			// btnXoa
			// 
			this.btnXoa.BackColor = System.Drawing.Color.Gray;
			this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnXoa.ForeColor = System.Drawing.Color.White;
			this.btnXoa.Location = new System.Drawing.Point(196, 336);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(66, 27);
			this.btnXoa.TabIndex = 12;
			this.btnXoa.Text = "Xoá";
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnTimkiem
			// 
			this.btnTimkiem.BackColor = System.Drawing.Color.Gray;
			this.btnTimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTimkiem.ForeColor = System.Drawing.Color.White;
			this.btnTimkiem.Location = new System.Drawing.Point(342, 336);
			this.btnTimkiem.Name = "btnTimkiem";
			this.btnTimkiem.Size = new System.Drawing.Size(116, 27);
			this.btnTimkiem.TabIndex = 13;
			this.btnTimkiem.Text = "Danh sách HS";
			this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
			// 
			// btnThem
			// 
			this.btnThem.BackColor = System.Drawing.Color.Gray;
			this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThem.ForeColor = System.Drawing.Color.White;
			this.btnThem.Location = new System.Drawing.Point(108, 336);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 27);
			this.btnThem.TabIndex = 11;
			this.btnThem.Text = "Thêm mới";
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox2.Location = new System.Drawing.Point(0, 34);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(544, 8);
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dataDS);
			this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.SeaGreen;
			this.groupBox2.Location = new System.Drawing.Point(4, 109);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 184);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh sách học sinh";
			// 
			// dataDS
			// 
			this.dataDS.DataMember = "";
			this.dataDS.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataDS.Location = new System.Drawing.Point(8, 24);
			this.dataDS.Name = "dataDS";
			this.dataDS.Size = new System.Drawing.Size(184, 152);
			this.dataDS.TabIndex = 0;
			this.dataDS.Click += new System.EventHandler(this.dataDS_Click);
			this.dataDS.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataDS_Navigate);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox1.Location = new System.Drawing.Point(0, 312);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(544, 8);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(0, 308);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(544, 8);
			this.label12.TabIndex = 8;
			// 
			// btnCapNhat
			// 
			this.btnCapNhat.BackColor = System.Drawing.Color.Gray;
			this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCapNhat.ForeColor = System.Drawing.Color.White;
			this.btnCapNhat.Location = new System.Drawing.Point(262, 336);
			this.btnCapNhat.Name = "btnCapNhat";
			this.btnCapNhat.Size = new System.Drawing.Size(80, 27);
			this.btnCapNhat.TabIndex = 15;
			this.btnCapNhat.Text = "Cập nhật";
			this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
			// 
			// Tiepnhanhocsinh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.ClientSize = new System.Drawing.Size(536, 382);
			this.ControlBox = false;
			this.Controls.Add(this.btnCapNhat);
			this.Controls.Add(this.btnTiepNhan);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnTimkiem);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cboKhoi);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cboLop);
			this.Controls.Add(this.txtSiSo);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Tiepnhanhocsinh";
			this.Text = "Tiep nhan hoc sinh";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Tiepnhanhocsinh_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataDS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Tiepnhanhocsinh_Load(object sender, System.EventArgs e)
		{
			GetDanhSachKhoi();	
			cboGioiTinh.Items.Add("Nam");
			cboGioiTinh.Items.Add("Nu");
			cboGioiTinh.SelectedIndex=0;
			
		}
		private void GetDanhSachKhoi()
		{
			string strSql="select * from KHOI";
			//QUANLYHOCSINHCAP3.KHOI.KhoiData khoi=new QUANLYHOCSINHCAP3.KHOI.KhoiData();
			//cboKhoi.DataSource=khoi.GetDanhSachKhoi(strSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboKhoi.DataSource=provider.LayDanhSach(strSql);
			cboKhoi.ValueMember="MAKHOI";
			cboKhoi.DisplayMember="TENKHOI ";
			
		}
		private void LaySiSoLop()
		{

			string strSql="select Siso from lop where malop='"+cboLop.SelectedValue+"'";
			DataTable dsHS=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsHS=provider.LayDanhSach(strSql);
			txtSiSo.Text="";
			txtSiSo.Text=dsHS.Rows[0]["Siso"].ToString();
		}
		private void Getdanhsachlop(string ma_khoi)
		{
			string strSql="select * from lop where makhoi='"+ma_khoi+"'";
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboLop.DataSource=provider.LayDanhSach(strSql);
			cboLop.DisplayMember = "TENLOP"; 
			cboLop.ValueMember = "MALOP";	
		}
		private void GetDanhSachHocSinh()
		{
			DataTable dsHS=new DataTable();
			string sSql;
			sSql = "select MAHS , HOTEN from hocsinh where MALOP='" + cboLop.SelectedValue + "'";
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsHS=provider.LayDanhSach(sSql);
			dataDS.DataSource =dsHS;
			sohs=dsHS.DefaultView.Count+1;
			txtMaso.Text=Tao_MaHS();
			
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label10_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnXoa_Click(object sender, System.EventArgs e)
		{
			
			QUANLYHOCSINHCAP3.HOCSINH.HocSinhCtl HSCtl=new QUANLYHOCSINHCAP3.HOCSINH.HocSinhCtl();
			HSCtl.HocSinh.MaHS=Convert.ToString(dataDS[dataDS.CurrentCell.RowNumber,0]);
			HSCtl.HocSinh.Siso=Convert.ToInt32(txtSiSo.Text)-1;
			HSCtl.HocSinh.MaLop=(string)cboLop.SelectedValue;
			HSCtl.delete();
			MessageBox.Show("Thông tin đã được xoá","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.None);
			GetDanhSachHocSinh();
			khoitao_textbox();
			HienThi_Nut();
		}
		private int Kiemtra_Thoat()
		{
			if(txtDiaChi.Text!="")
				return 0;
			if(txtEmail.Text!="")
				return 0;
			if(txtHoTen.Text!="")
				return 0;
			return 1;
		}
		private void btnThoat_Click(object sender, System.EventArgs e)
		{
			DialogResult nut;
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			if(Kiemtra_Thoat()==1)
			{
				provider.Disconnect();
				this.Close();
			}
			else
			{
					
					nut=MessageBox.Show("Bạn có muốn lưu trước khi thoát không ? ","Thông báo",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
					if(nut==DialogResult.Yes)
					{
				
						if(btnTiepNhan.Enabled==false)
						{
							if(btnCapNhat.Enabled==true)
							{
								if(kiemtra()==1)
								{
									CapNhat();
									provider.Disconnect();
									this.Close();
								}
							}
						}
						else
						{
							if(kiemtra()==1)
							{
								Luu();
								provider.Disconnect();
								this.Close();
							}
						}
					}
					if(nut==DialogResult.No)
					{
						provider.Disconnect();
						this.Close();
					}
			}
		}

		private void label13_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cboKhoi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ma_khoi=cboKhoi.Text;
			Getdanhsachlop(ma_khoi);
		}
		private	void khoitao_textbox()
		{
			txtEmail.Text="";
			txtHoTen.Text="";
			txtDiaChi.Text="";
			
		}
		private void btnThem_Click(object sender, System.EventArgs e)
		{
			HienThi_Nut();
			khoitao_textbox();
			GetDanhSachHocSinh();
			
		}

		private void btnTimkiem_Click(object sender, System.EventArgs e)
		{
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider.MaLop=(string)cboLop.SelectedValue;
			FrmDanhSachLop frmDSLop=new FrmDanhSachLop();
			frmDSLop.nflag=3;
			frmDSLop.Show();

		}
		private string Tao_MaHS()
		{
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select mahs from hocsinh where malop='"+cboLop.SelectedValue+"' order by mahs asc";
			dsTam=provider.LayDanhSach(sSql);
			string mahs ,s,tam;
			s=cboLop.SelectedValue.ToString();
			tam=s;
			int j=1,i;
			for( i=0;i<dsTam.DefaultView.Count;i++)
			{
				
				mahs=dsTam.DefaultView[i].Row["mahs"].ToString();
				if(mahs ==(tam+"_"+j.ToString()))
				{
					s=mahs;
					
				}
				else
				{
					s=tam+"_"+j.ToString();
					//s=s+1;
						
					break;
				}
				j++;
			}	
			i=j-1;
			if(s==cboLop.SelectedValue.ToString())
				s=s+"_1";

			else if(s==tam+"_"+i.ToString())	
			{
				
				s=tam+"_"+j.ToString();
			}
			return s;
			
		}
		private void Luu()
		{
				QUANLYHOCSINHCAP3.HOCSINH.HocSinhCtl hscl = new QUANLYHOCSINHCAP3.HOCSINH.HocSinhCtl(); 
				hscl.HocSinh.MaHS = txtMaso.Text;
				hscl.HocSinh.TenHS = txtHoTen.Text;
				hscl.HocSinh.Phai = cboGioiTinh.Text;
				hscl.HocSinh.NgaySinh = dtpNgaySinh.Value;
				hscl.HocSinh.DiaChi = txtDiaChi.Text; 
				hscl.HocSinh.Email = txtEmail.Text; 
				hscl.HocSinh.MaLop =  (string)cboLop.SelectedValue;
				hscl.HocSinh.Siso=Convert.ToInt32(txtSiSo.Text)+1;
				hscl.insert();
						//MessageBox.Show("hien thi danh sach");
				MessageBox.Show("Thông tin đã được lưu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.None);
				GetDanhSachHocSinh();
				
		}
		private void btnTiepNhan_Click(object sender, System.EventArgs e)
		{
			if(kiemtra()==1)
			{
				Luu();
				khoitao_textbox();
				HienThi_Nut();
			}
		}
		private void HienThi_Nut()
		{
			LaySiSoLop();
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select * from thamso where mathamso='TS3' ";
			dsTam=provider.LayDanhSach(sSql);
			int sohs_toida;
			sohs_toida=Convert.ToInt32(dsTam.DefaultView[0].Row["giatri"].ToString());
			int so=sohs-1;
			if(so>=sohs_toida)
			{
				btnTiepNhan.Enabled=false;
				btnXoa.Enabled=false;
				btnCapNhat.Enabled=false;
			
			}
			else
			{
				btnTiepNhan.Enabled=true;
				btnXoa.Enabled=false;
				btnCapNhat.Enabled=false;
			}
			
		}
		private void cboLop_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetDanhSachHocSinh();
			HienThi_Nut();
			khoitao_textbox();
		}

		private void dataDS_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
			
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}
		private int kiemtra_ngaysinh()
		{
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select * from thamso ";
			dsTam=provider.LayDanhSach(sSql);
			int tuoitoithieu=0,tuoitoida=0,giatri=0;
			string mathamso;
			for(int i=0;i<dsTam.DefaultView.Count;i++)
			{
				mathamso=dsTam.DefaultView[i].Row["mathamso"].ToString();
				giatri=Convert.ToInt32(dsTam.DefaultView[i].Row["giatri"].ToString());
				if(mathamso=="TS1")
					tuoitoithieu=giatri;
				if(mathamso=="TS2")
					tuoitoida=giatri;
			}
			int tuoi=DateTime.Now.Year-dtpNgaySinh.Value.Year;
			if(	tuoi<tuoitoithieu || tuoi>tuoitoida)
			{
				MessageBox.Show("Học sinh "+tuoi+" tuổi . Không thoả qui định !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return 0;
			}
			return 1;
		}
		private int kiemtra()
		{
		
			if(txtHoTen.Text=="")
			{
				MessageBox.Show("Họ tên học sinh không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtHoTen.Focus();
				return 0;
			}
			if(txtDiaChi.Text=="")
			{
				MessageBox.Show("Địa chỉ học sinh không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtDiaChi.Focus();
				return 0;
			}
			if( txtEmail.Text=="")
			{
				MessageBox.Show("Email học sinh không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtEmail.Focus();
				return 0;
			}
			if(	kiemtra_ngaysinh()==0)
			{
				return 0;
			}
			
			return 1;
		}

		private void dtpNgaySinh_ValueChanged(object sender, System.EventArgs e)
		{
		}

		private void dataDS_Click(object sender, System.EventArgs e)
		{
			btnXoa.Enabled=true;
			btnCapNhat.Enabled=true;
			btnTiepNhan.Enabled=false;
			khoitao_textbox();
			txtMaso.Text="";
			cboGioiTinh.Text="";
			string sSql;
			string sMaHS=dataDS[dataDS.CurrentCell.RowNumber,0].ToString();
			sSql = "select * from hocsinh where MAHS='" + sMaHS + "'";
			DataTable dsHS=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsHS=provider.LayDanhSach(sSql);
			//gan du lieu vao cac textbox
			txtMaso.Text=dsHS.Rows[0]["MAHS"].ToString();
			txtDiaChi.Text=dsHS.Rows[0]["DIACHI"].ToString();
			txtEmail.Text=dsHS.Rows[0]["EMAIL"].ToString();
			txtHoTen.Text=dsHS.Rows[0]["HOTEN"].ToString();
			cboGioiTinh.SelectedText=dsHS.Rows[0]["PHAI"].ToString();
			dtpNgaySinh.Value=Convert.ToDateTime(dsHS.Rows[0]["NGAYSINH"].ToString());
			HienThi_Nut();
			btnCapNhat.Enabled=true;
			btnXoa.Enabled=true;
			btnTiepNhan.Enabled=false;
			//MessageBox.Show("'"+dataDS[dataDS.CurrentCell.RowNumber,0]+"'");
		}
		private void CapNhat()
		{
			
				QUANLYHOCSINHCAP3.HOCSINH.HocSinhCtl hscl = new QUANLYHOCSINHCAP3.HOCSINH.HocSinhCtl(); 
				hscl.HocSinh.MaHS = txtMaso.Text;
				hscl.HocSinh.TenHS = txtHoTen.Text;
				hscl.HocSinh.Phai = cboGioiTinh.Text;
				hscl.HocSinh.NgaySinh = dtpNgaySinh.Value;
				hscl.HocSinh.DiaChi = txtDiaChi.Text; 
				hscl.HocSinh.Email = txtEmail.Text; 
				hscl.HocSinh.MaLop =  (string)cboLop.SelectedValue;
				hscl.update();
				MessageBox.Show("Thông tin đã được cập nhật","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.None);
				GetDanhSachHocSinh();
				khoitao_textbox();
		
		}
		private void btnCapNhat_Click(object sender, System.EventArgs e)
		{
			if(kiemtra()==1)
				CapNhat();
		}
	
	}
}
