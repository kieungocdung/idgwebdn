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
	/// Summary description for FrmDanhSachLop.
	/// </summary>
	public class FrmDanhSachLop : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public int nflag;
		private string malop;
		private string username;
		private string password;
		private System.Windows.Forms.Label lblMaHS;
		private System.Windows.Forms.Label lblMon;
		private System.Windows.Forms.ComboBox cboMon;
		private System.Windows.Forms.ComboBox cboHocky;
		private System.Windows.Forms.Label lblHK;
		private System.Windows.Forms.TextBox txtMaHS;
		private System.Windows.Forms.Button btnBaoCao;
		private System.Windows.Forms.ComboBox cboLop;
		private string service;
		public string UserName
		{
			get{return username;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				username=value;
						 
			}
		}
		public string Password
		{
			get{return password;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				password=value;
						 
			}
		}
		public string Service
		{
			get{return service;}
			set
			{
				if (value == null)
					throw new Exception("Ma lop khong duoc rong");
				service=value;
						 
			}
		}
		public FrmDanhSachLop()
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
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.lblMaHS = new System.Windows.Forms.Label();
			this.lblMon = new System.Windows.Forms.Label();
			this.txtMaHS = new System.Windows.Forms.TextBox();
			this.cboMon = new System.Windows.Forms.ComboBox();
			this.cboHocky = new System.Windows.Forms.ComboBox();
			this.lblHK = new System.Windows.Forms.Label();
			this.btnBaoCao = new System.Windows.Forms.Button();
			this.cboLop = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 144);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(544, 288);
			this.crystalReportViewer1.TabIndex = 0;
			this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
			// 
			// lblMaHS
			// 
			this.lblMaHS.Location = new System.Drawing.Point(272, 16);
			this.lblMaHS.Name = "lblMaHS";
			this.lblMaHS.Size = new System.Drawing.Size(88, 24);
			this.lblMaHS.TabIndex = 1;
			this.lblMaHS.Text = "Mã học sinh";
			this.lblMaHS.Visible = false;
			// 
			// lblMon
			// 
			this.lblMon.Location = new System.Drawing.Point(96, 16);
			this.lblMon.Name = "lblMon";
			this.lblMon.Size = new System.Drawing.Size(56, 24);
			this.lblMon.TabIndex = 1;
			this.lblMon.Text = "Môn";
			this.lblMon.Visible = false;
			// 
			// txtMaHS
			// 
			this.txtMaHS.Location = new System.Drawing.Point(376, 16);
			this.txtMaHS.Name = "txtMaHS";
			this.txtMaHS.Size = new System.Drawing.Size(72, 26);
			this.txtMaHS.TabIndex = 2;
			this.txtMaHS.Text = "";
			this.txtMaHS.Visible = false;
			// 
			// cboMon
			// 
			this.cboMon.Location = new System.Drawing.Point(184, 16);
			this.cboMon.Name = "cboMon";
			this.cboMon.Size = new System.Drawing.Size(72, 27);
			this.cboMon.TabIndex = 3;
			this.cboMon.Visible = false;
			// 
			// cboHocky
			// 
			this.cboHocky.Location = new System.Drawing.Point(376, 16);
			this.cboHocky.Name = "cboHocky";
			this.cboHocky.Size = new System.Drawing.Size(72, 27);
			this.cboHocky.TabIndex = 5;
			this.cboHocky.Visible = false;
			this.cboHocky.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// lblHK
			// 
			this.lblHK.Location = new System.Drawing.Point(288, 16);
			this.lblHK.Name = "lblHK";
			this.lblHK.Size = new System.Drawing.Size(56, 24);
			this.lblHK.TabIndex = 4;
			this.lblHK.Text = "Học kỳ";
			this.lblHK.Visible = false;
			// 
			// btnBaoCao
			// 
			this.btnBaoCao.Location = new System.Drawing.Point(258, 56);
			this.btnBaoCao.Name = "btnBaoCao";
			this.btnBaoCao.Size = new System.Drawing.Size(88, 24);
			this.btnBaoCao.TabIndex = 6;
			this.btnBaoCao.Text = "Báo cáo";
			this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
			// 
			// cboLop
			// 
			this.cboLop.Location = new System.Drawing.Point(359, 16);
			this.cboLop.Name = "cboLop";
			this.cboLop.Size = new System.Drawing.Size(64, 27);
			this.cboLop.TabIndex = 7;
			this.cboLop.Visible = false;
			this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
			// 
			// FrmDanhSachLop
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.ClientSize = new System.Drawing.Size(544, 382);
			this.Controls.Add(this.cboLop);
			this.Controls.Add(this.btnBaoCao);
			this.Controls.Add(this.cboHocky);
			this.Controls.Add(this.lblHK);
			this.Controls.Add(this.cboMon);
			this.Controls.Add(this.txtMaHS);
			this.Controls.Add(this.lblMaHS);
			this.Controls.Add(this.crystalReportViewer1);
			this.Controls.Add(this.lblMon);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.Name = "FrmDanhSachLop";
			this.Text = "Báo cáo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Resize += new System.EventHandler(this.FrmDanhSachLop_Resize);
			this.Load += new System.EventHandler(this.FrmDanhSachLop_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmDanhSachLop_Load(object sender, System.EventArgs e)
		{
			username=QUANLYHOCSINHCAP3.KNCSDL.DataProvider.Username;
			password=QUANLYHOCSINHCAP3.KNCSDL.DataProvider.Password;
			service=QUANLYHOCSINHCAP3.KNCSDL.DataProvider.Service;
			string malop;
			malop=QUANLYHOCSINHCAP3.KNCSDL.DataProvider.MaLop;
			
			
			if (nflag==3)
			{
				btnBaoCao.Visible=true;
				RptTemp  rpt=new RptTemp();
				rpt.SetDatabaseLogon(username , password);
				rpt.SetParameterValue("pMaLop",malop);
				crystalReportViewer1.ReportSource = rpt;
			}
			if(nflag==2)
			{
				GetDanhSachHocKi();
				lblHK.Visible=true;
				cboHocky.Visible=true;
				
			}
			if(nflag==1)
			{
				lblMaHS.Visible=true;
				txtMaHS.Visible=true;
			}
			if(nflag==0)
			{
				GetDanhSachMonHoc();
				Getdanhsachlop();
				lblMon.Visible=true;
				cboMon.Visible=true;
				lblMaHS.Text="Mã lớp";	
				lblMaHS.Visible=true;
				cboLop.Visible	=true;
				
			}
			if(nflag==4)
			{
				GetDanhSachMonHoc();
				GetDanhSachHocKi();
				lblHK.Visible=true;
				cboHocky.Visible=true;
				lblMon.Visible=true;
				cboMon.Visible=true;
			}
			
		}
		
	private void GetDanhSachHocKi()
	{
			string strSql="select * from hocki ";
			//QUANLYHOCSINHCAP3.HOCKY.HocKyData hocki = new QUANLYHOCSINHCAP3.HOCKY.HocKyData();
			//cboHocky.DataSource = hocki.GetDanhSachHocKi(strSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboHocky.DataSource=provider.LayDanhSach(strSql);
			cboHocky.DisplayMember ="MAHOCKI"; 
			cboHocky.ValueMember =  "MAHOCKI"; 
			//LayBaoCaoMon();
	}
		private void Getdanhsachlop()
		{
			string strSql="select * from lop ";
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboLop.DataSource=provider.LayDanhSach(strSql);
			cboLop.DisplayMember = "TENLOP"; 
			cboLop.ValueMember = "MALOP";	
		}
	private void GetDanhSachMonHoc()
	{
			string strSql="select * from monhoc ";
			//QUANLYHOCSINHCAP3.MONHOC.MonHocData monhoc = new QUANLYHOCSINHCAP3.MONHOC.MonHocData();
			//cboMon.DataSource = monhoc.GetDanhSachMonHoc(strSql);
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			cboMon.DataSource=provider.LayDanhSach(strSql);
					
			cboMon.DisplayMember = "TENMON"; 
			cboMon.ValueMember = "MAMON";	
	}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		
		private void crystalReportViewer1_Load(object sender, System.EventArgs e)
		{
			

		}

		
		

		private void FrmDanhSachLop_Resize(object sender, System.EventArgs e)
		{		
			crystalReportViewer1.Height= 
				this.Bottom - crystalReportViewer1.Top;
			crystalReportViewer1.Width = 
				this.Right - crystalReportViewer1.Left; 

		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnBaoCao_Click(object sender, System.EventArgs e)
		{
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider=new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			
			if (nflag==1)
			{
				BANGDIEM.RptBangDiemHS  rpt=new QUANLYHOCSINHCAP3.BANGDIEM.RptBangDiemHS ();
				rpt.SetDatabaseLogon(username , password);
				rpt.SetParameterValue("pMaHS",txtMaHS.Text);
				crystalReportViewer1.ReportSource = rpt;
			}
			if (nflag==0)
			{
				BANGDIEM.RptDSHS rpt=new QUANLYHOCSINHCAP3.BANGDIEM.RptDSHS();
				rpt.SetDatabaseLogon(username , password);
				rpt.SetParameterValue("pLop",(string)cboLop.SelectedValue);
				rpt.SetParameterValue("pMamon",(string)cboMon.SelectedValue);
				crystalReportViewer1.ReportSource = rpt;
			}
			if (nflag==2)
			{
				string MaHK=(string)cboHocky.SelectedValue;
				RptBaocaoHocki  rpt=new RptBaocaoHocki ();
				rpt.SetDatabaseLogon(username , password);
				rpt.SetParameterValue("pMaHK",MaHK);
				crystalReportViewer1.ReportSource = rpt;
			}
			if (nflag==4)
			{
				BaoCaoTheoMon  rpt=new BaoCaoTheoMon();
				rpt.SetDatabaseLogon(username , password);
				rpt.SetParameterValue("pMaHK",(string)cboHocky.SelectedValue);
				rpt.SetParameterValue("pMaMon",(string)cboMon.SelectedValue);
				crystalReportViewer1.ReportSource = rpt;
				
			}
			//CACH EXPORT VO WORD
			/*SaveFileDialog dlg = new SaveFileDialog ();
			if (dlg.ShowDialog()==DialogResult.OK)
				rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows,dlg.FileName) ;*/	
		}

		private void cboLop_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
