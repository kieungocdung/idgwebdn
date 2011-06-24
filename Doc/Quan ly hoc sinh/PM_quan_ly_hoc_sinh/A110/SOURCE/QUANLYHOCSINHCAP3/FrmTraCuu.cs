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
	/// Summary description for FrmTraCuu.
	/// </summary>
	public class FrmTraCuu : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMaHS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnTracuu;
		private System.Windows.Forms.DataGrid dataThongTinHocSinh;
		private System.Windows.Forms.DataGrid dataBDiem;
		private DataTable dsBDiem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmTraCuu()
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
			this.txtMaHS = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataThongTinHocSinh = new System.Windows.Forms.DataGrid();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataBDiem = new System.Windows.Forms.DataGrid();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnTracuu = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataThongTinHocSinh)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataBDiem)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Crimson;
			this.label1.Location = new System.Drawing.Point(-4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(548, 45);
			this.label1.TabIndex = 11;
			this.label1.Text = "Tra cứu học sinh";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox1.Location = new System.Drawing.Point(-4, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(548, 8);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
			this.label2.Location = new System.Drawing.Point(150, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 22);
			this.label2.TabIndex = 12;
			this.label2.Text = "Mã học sinh";
			// 
			// txtMaHS
			// 
			this.txtMaHS.Location = new System.Drawing.Point(270, 64);
			this.txtMaHS.Name = "txtMaHS";
			this.txtMaHS.TabIndex = 13;
			this.txtMaHS.Text = "";
			this.txtMaHS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaHS_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataThongTinHocSinh);
			this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.HotPink;
			this.groupBox1.Location = new System.Drawing.Point(5, 95);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(531, 121);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin học sinh";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// dataThongTinHocSinh
			// 
			this.dataThongTinHocSinh.DataMember = "";
			this.dataThongTinHocSinh.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataThongTinHocSinh.Location = new System.Drawing.Point(5, 20);
			this.dataThongTinHocSinh.Name = "dataThongTinHocSinh";
			this.dataThongTinHocSinh.Size = new System.Drawing.Size(523, 92);
			this.dataThongTinHocSinh.TabIndex = 0;
			this.dataThongTinHocSinh.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dataBDiem);
			this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.groupBox2.Location = new System.Drawing.Point(5, 215);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(531, 112);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bảng điểm các môn học";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// dataBDiem
			// 
			this.dataBDiem.DataMember = "";
			this.dataBDiem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataBDiem.Location = new System.Drawing.Point(5, 20);
			this.dataBDiem.Name = "dataBDiem";
			this.dataBDiem.Size = new System.Drawing.Size(523, 84);
			this.dataBDiem.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 327);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(568, 8);
			this.label5.TabIndex = 16;
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Maroon;
			this.pictureBox2.Location = new System.Drawing.Point(-7, 331);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(564, 8);
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// btnThoat
			// 
			this.btnThoat.BackColor = System.Drawing.Color.Gray;
			this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnThoat.ForeColor = System.Drawing.Color.White;
			this.btnThoat.Location = new System.Drawing.Point(276, 344);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(75, 26);
			this.btnThoat.TabIndex = 19;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnTracuu
			// 
			this.btnTracuu.BackColor = System.Drawing.Color.Gray;
			this.btnTracuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTracuu.ForeColor = System.Drawing.Color.White;
			this.btnTracuu.Location = new System.Drawing.Point(201, 344);
			this.btnTracuu.Name = "btnTracuu";
			this.btnTracuu.Size = new System.Drawing.Size(75, 26);
			this.btnTracuu.TabIndex = 17;
			this.btnTracuu.Text = "Tra cứu";
			this.btnTracuu.Click += new System.EventHandler(this.btnTracuu_Click);
			// 
			// FrmTraCuu
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.ClientSize = new System.Drawing.Size(552, 390);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnTracuu);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtMaHS);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmTraCuu";
			this.Text = "FrmTraCuu";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmTraCuu_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataThongTinHocSinh)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataBDiem)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void FrmTraCuu_Load(object sender, System.EventArgs e)
		{

		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
		
		}
		private string LayTrungBinhMon(string mamon,string hocky)
		{
			/*dsBDiem=new DataTable();
			string sSql,trungbinh;
			sSql = "select trungbinh from diemmon where mamonhoc='"+mamon+"' and mahocky='"+hocky+"' and mahocsinh='"+txtMaHS.Text+"'";
			QUANLYHOCSINHCAP3.BANGDIEM.BangDiemData BDiemData=new QUANLYHOCSINHCAP3.BANGDIEM.BangDiemData();
			dsBDiem= BDiemData.GetDanhSachDiemMon(sSql);
				
			trungbinh=dsBDiem.Rows[0][0].ToString();*/
			DataTable dsTam=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string sSql;
			sSql = "select trungbinh from diemmon where mamonhoc='"+mamon+"' and mahocky='"+hocky+"' and mahocsinh='"+txtMaHS.Text+"'";
			dsTam=provider.LayDanhSach(sSql);
			string trungbinh="0.0";
			if(dsTam.DefaultView.Count!=0)
				trungbinh=dsTam.DefaultView[0].Row["trungbinh"].ToString();
			return trungbinh;
			
			
			
		}
		private void LayBangDiem()
		{
			DataColumn cot ;
			DataTable dsBangDiem=new DataTable();
			string sSql;
			sSql = "select * from monhoc ";
			//QUANLYHOCSINHCAP3.MONHOC.MonHocData Monhoc_Data=new QUANLYHOCSINHCAP3.MONHOC.MonHocData();
			//dsBangDiem= Monhoc_Data.GetDanhSachMonHoc(sSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsBangDiem=provider.LayDanhSach(sSql);
			int soluongmon=dsBangDiem.DefaultView.Count;
			/*//tao cot HK 
			cot = new DataColumn();
			cot.ColumnName=" Học Kỳ";
			cot.DataType=Type.GetType("System.String");
			dsLop.Columns.Add(cot);*/
			//tao cot TBHK1
			cot = new DataColumn();
			cot.ColumnName="TBHK1";
			
			cot.DataType=Type.GetType("System.String");
			dsBangDiem.Columns.Add(cot);
			//tao cot TBHK2'
			cot = new DataColumn();
			cot.ColumnName="TBHK2";
			
			cot.DataType=Type.GetType("System.String");
			dsBangDiem.Columns.Add(cot);
			dataBDiem.DataSource =dsBangDiem;
			int i;
			string ma_mon,trungbinh;
				
			for(i=0;i<soluongmon;i++)
			{
				ma_mon=dsBangDiem.Rows[i][0].ToString();
				trungbinh=LayTrungBinhMon(ma_mon,"HK1");
				dataBDiem[i,2]=trungbinh.ToString();
				trungbinh=LayTrungBinhMon(ma_mon,"HK2");
				dataBDiem[i,3]=trungbinh.ToString();
				
			}
			
		}
		private void Tracuu()
		{
			
			string sSql;
			string sMaHS=txtMaHS.Text;
			sSql = "select * from hocsinh where MAHS='" + sMaHS + "'";
			DataTable dsHS=new DataTable();
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			dsHS=provider.LayDanhSach(sSql);
			dataThongTinHocSinh.DataSource = dsHS;
			LayBangDiem();

		}
		private void btnTracuu_Click(object sender, System.EventArgs e)
		{
			if(txtMaHS.Text=="")
				MessageBox.Show("MaHS không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			else
				Tracuu();
		}
		
		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void btnIn_Click(object sender, System.EventArgs e)
		{
			
			
		

		}

		private void btnThoat_Click(object sender, System.EventArgs e)
		{
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			//cboKhoi.DataSource=provider.LayDanhSach(strSql);
			provider.Disconnect();
			this.Close();
		}

		private void txtMaHS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue==13)
			{
				if(txtMaHS.Text=="")
					MessageBox.Show("MaHS không được rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				else
					Tracuu();
			}
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}
	}
}
