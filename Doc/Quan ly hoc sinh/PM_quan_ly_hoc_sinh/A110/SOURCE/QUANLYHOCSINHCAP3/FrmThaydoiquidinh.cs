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
	/// Summary description for FrmThaydoiquidinh.
	/// </summary>
	public class FrmThaydoiquidinh : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnCapnhat;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtMaso;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataDS;
		private System.Windows.Forms.TextBox txtTenThamSo;
		private System.Windows.Forms.TextBox txtGiaTri;
		private System.Windows.Forms.TextBox txtGhichu;
		private System.Windows.Forms.Button btnThemmoi;
		int sots;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmThaydoiquidinh()
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
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnCapnhat = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtMaso = new System.Windows.Forms.TextBox();
			this.txtTenThamSo = new System.Windows.Forms.TextBox();
			this.txtGiaTri = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtGhichu = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataDS = new System.Windows.Forms.DataGrid();
			this.btnThemmoi = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataDS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Crimson;
			this.label1.Location = new System.Drawing.Point(-14, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(572, 45);
			this.label1.TabIndex = 19;
			this.label1.Text = "Thay đổi qui định";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox1.Location = new System.Drawing.Point(-20, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(572, 8);
			this.pictureBox1.TabIndex = 18;
			this.pictureBox1.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(-18, 304);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(570, 8);
			this.label5.TabIndex = 26;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox2.Location = new System.Drawing.Point(-22, 308);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(574, 8);
			this.pictureBox2.TabIndex = 25;
			this.pictureBox2.TabStop = false;
			// 
			// btnThoat
			// 
			this.btnThoat.BackColor = System.Drawing.Color.Gray;
			this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThoat.ForeColor = System.Drawing.Color.White;
			this.btnThoat.Location = new System.Drawing.Point(360, 328);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(88, 27);
			this.btnThoat.TabIndex = 30;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnCapnhat
			// 
			this.btnCapnhat.BackColor = System.Drawing.Color.Gray;
			this.btnCapnhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCapnhat.ForeColor = System.Drawing.Color.White;
			this.btnCapnhat.Location = new System.Drawing.Point(272, 328);
			this.btnCapnhat.Name = "btnCapnhat";
			this.btnCapnhat.Size = new System.Drawing.Size(88, 27);
			this.btnCapnhat.TabIndex = 29;
			this.btnCapnhat.Text = "Cập nhật";
			this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
			// 
			// btnThem
			// 
			this.btnThem.BackColor = System.Drawing.Color.Gray;
			this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThem.ForeColor = System.Drawing.Color.White;
			this.btnThem.Location = new System.Drawing.Point(96, 328);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 27);
			this.btnThem.TabIndex = 27;
			this.btnThem.Text = "Lưu";
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtMaso);
			this.groupBox2.Controls.Add(this.txtTenThamSo);
			this.groupBox2.Controls.Add(this.txtGiaTri);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.txtGhichu);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.DeepPink;
			this.groupBox2.Location = new System.Drawing.Point(248, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(288, 240);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin tham số";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã tham số";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label6.Location = new System.Drawing.Point(8, 83);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Tên tham số";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label9.Location = new System.Drawing.Point(8, 142);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "Giá trị";
			// 
			// txtMaso
			// 
			this.txtMaso.Enabled = false;
			this.txtMaso.Location = new System.Drawing.Point(104, 24);
			this.txtMaso.Name = "txtMaso";
			this.txtMaso.Size = new System.Drawing.Size(176, 26);
			this.txtMaso.TabIndex = 4;
			this.txtMaso.Text = "";
			// 
			// txtTenThamSo
			// 
			this.txtTenThamSo.Location = new System.Drawing.Point(104, 83);
			this.txtTenThamSo.Name = "txtTenThamSo";
			this.txtTenThamSo.Size = new System.Drawing.Size(176, 26);
			this.txtTenThamSo.TabIndex = 5;
			this.txtTenThamSo.Text = "";
			this.txtTenThamSo.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
			// 
			// txtGiaTri
			// 
			this.txtGiaTri.Location = new System.Drawing.Point(104, 142);
			this.txtGiaTri.Name = "txtGiaTri";
			this.txtGiaTri.Size = new System.Drawing.Size(176, 26);
			this.txtGiaTri.TabIndex = 8;
			this.txtGiaTri.Text = "";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label10.Location = new System.Drawing.Point(8, 201);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Ghi chú";
			// 
			// txtGhichu
			// 
			this.txtGhichu.Location = new System.Drawing.Point(104, 201);
			this.txtGhichu.Name = "txtGhichu";
			this.txtGhichu.Size = new System.Drawing.Size(176, 26);
			this.txtGhichu.TabIndex = 9;
			this.txtGhichu.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataDS);
			this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.SeaGreen;
			this.groupBox1.Location = new System.Drawing.Point(8, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 241);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Danh sách tham số";
			// 
			// dataDS
			// 
			this.dataDS.DataMember = "";
			this.dataDS.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataDS.Location = new System.Drawing.Point(6, 24);
			this.dataDS.Name = "dataDS";
			this.dataDS.Size = new System.Drawing.Size(218, 208);
			this.dataDS.TabIndex = 0;
			this.dataDS.Click += new System.EventHandler(this.dataDS_Click);
			// 
			// btnThemmoi
			// 
			this.btnThemmoi.BackColor = System.Drawing.Color.Gray;
			this.btnThemmoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThemmoi.ForeColor = System.Drawing.Color.White;
			this.btnThemmoi.Location = new System.Drawing.Point(184, 328);
			this.btnThemmoi.Name = "btnThemmoi";
			this.btnThemmoi.Size = new System.Drawing.Size(88, 27);
			this.btnThemmoi.TabIndex = 33;
			this.btnThemmoi.Text = "Thêm mới";
			this.btnThemmoi.Click += new System.EventHandler(this.btnThemmoi_Click);
			// 
			// FrmThaydoiquidinh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.ClientSize = new System.Drawing.Size(544, 358);
			this.Controls.Add(this.btnThemmoi);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnCapnhat);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmThaydoiquidinh";
			this.Text = "Thay doi qui dinh";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmThaydoiquidinh_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataDS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnThoat_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtHoTen_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		private void GetDanhSachThamSo()
		{
			DataTable dsTS=new DataTable();
			string sSql;
			sSql = "select mathamso as MATS,tenthamso AS TENTS from thamso";
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsTS=provider.LayDanhSach(sSql);
			dataDS.DataSource =dsTS;
			sots=dsTS.DefaultView.Count+1;
			txtMaso.Text="TS"+ sots.ToString();
		}
		private int kiemtra()
		{
		
			if(txtTenThamSo.Text=="")
			{
				MessageBox.Show("Tên tham số không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtTenThamSo.Focus();
				return 0;
			}
			if(txtGiaTri.Text=="")
			{
				MessageBox.Show("Giá trị tham số không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtGiaTri.Focus();
				return 0;
			}
			if(txtGhichu.Text=="")
			{
				MessageBox.Show("Ghi chú tham số không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtGhichu.Focus();
				return 0;
			}
			return 1;
		}
		private void Luu()
		{
			QUANLYHOCSINHCAP3.THAMSO.ThamSoCtl thamsoCtl = new QUANLYHOCSINHCAP3.THAMSO.ThamSoCtl();
			thamsoCtl.ThamSo.MaTS = txtMaso.Text;
			thamsoCtl.ThamSo.TenTS = txtTenThamSo.Text;
			thamsoCtl.ThamSo.GiaTri = Convert.ToInt32(txtGiaTri.Text); 
			thamsoCtl.ThamSo.GhiChu = txtGhichu.Text; 
			//int i,j;
			//for( i=0;i<sots;i++)
			//{
			//	for(j=0;j<3;j++)
			//	{
					//dataDS[0,0]="";
					//dataDS[0,1]="";
			//	}
			//}
			thamsoCtl.insert();
			
			MessageBox.Show("Thông tin đã được lưu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.None);
			GetDanhSachThamSo();
			
		}
		
		private void btnThem_Click(object sender, System.EventArgs e)
		{
			if(kiemtra()==1)
			{
				Luu();
				khoitao_textbox();
			}
			
		}

		private void FrmThaydoiquidinh_Load(object sender, System.EventArgs e)
		{
			GetDanhSachThamSo();
			btnCapnhat.Enabled=false;
			btnThem.Enabled=true;
		}

		private void dataDS_Click(object sender, System.EventArgs e)
		{
			btnCapnhat.Enabled=true;
			btnThem.Enabled=false;
			string sSql;
			string MaTS=dataDS[dataDS.CurrentCell.RowNumber,0].ToString();
			sSql = "select * from thamso where mathamso='"+MaTS+"'";
			DataTable dsTS=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsTS=provider.LayDanhSach(sSql);
			//gan du lieu vao cac textbox
			txtMaso.Text=dsTS.Rows[0]["MATHAMSO"].ToString();
			txtTenThamSo.Text=dsTS.Rows[0]["TENTHAMSO"].ToString();
			txtGiaTri.Text=dsTS.Rows[0]["GIATRI"].ToString();
			txtGhichu.Text=dsTS.Rows[0]["GHICHU"].ToString();
			
		}

		private void CapNhat()
		{
			QUANLYHOCSINHCAP3.THAMSO.ThamSoCtl thamsoCtl = new QUANLYHOCSINHCAP3.THAMSO.ThamSoCtl();
			thamsoCtl.ThamSo.MaTS = txtMaso.Text;
			thamsoCtl.ThamSo.TenTS = txtTenThamSo.Text;
			thamsoCtl.ThamSo.GiaTri = Convert.ToInt32(txtGiaTri.Text); 
			thamsoCtl.ThamSo.GhiChu = txtGhichu.Text; 
			thamsoCtl.update();
			GetDanhSachThamSo();
			
		}
		private void btnCapnhat_Click(object sender, System.EventArgs e)
		{
			if(kiemtra()==1)
				CapNhat();
			MessageBox.Show("Thông tin đã được cập nhật","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.None);

		}
		private void khoitao_textbox()
		{
			txtGhichu.Text="";
			txtGiaTri.Text="";
			txtTenThamSo.Text="";
		}
		private void btnThemmoi_Click(object sender, System.EventArgs e)
		{
			khoitao_textbox();
			GetDanhSachThamSo();
			btnCapnhat.Enabled=false;
			btnThem.Enabled=true;
		}
	}
}
