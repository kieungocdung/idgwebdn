using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;




namespace QUANLYHOCSINHCAP3
{
	/// <summary>
	/// Summary description for FrmDangNhap.
	/// </summary>
	public class FrmDangNhap : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnDangNhap;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPasswd;
		private System.Windows.Forms.TextBox txtService;
		private System.Windows.Forms.TextBox txtUsername;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmDangNhap()
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
			this.txtPasswd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtService = new System.Windows.Forms.TextBox();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label1.Location = new System.Drawing.Point(24, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txtPasswd
			// 
			this.txtPasswd.Location = new System.Drawing.Point(120, 56);
			this.txtPasswd.Name = "txtPasswd";
			this.txtPasswd.PasswordChar = '*';
			this.txtPasswd.Size = new System.Drawing.Size(120, 26);
			this.txtPasswd.TabIndex = 2;
			this.txtPasswd.Text = "manager";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label2.Location = new System.Drawing.Point(23, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 22);
			this.label2.TabIndex = 0;
			this.label2.Text = "Password";
			// 
			// txtService
			// 
			this.txtService.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtService.Location = new System.Drawing.Point(120, 96);
			this.txtService.Name = "txtService";
			this.txtService.Size = new System.Drawing.Size(120, 26);
			this.txtService.TabIndex = 3;
			this.txtService.Text = "system";
			this.txtService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
			this.txtService.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDangNhap.ForeColor = System.Drawing.Color.Cornsilk;
			this.btnDangNhap.Location = new System.Drawing.Point(26, 138);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(96, 24);
			this.btnDangNhap.TabIndex = 4;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			this.btnDangNhap.Enter += new System.EventHandler(this.btnDangNhap_Enter);
			this.btnDangNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDangNhap_KeyDown);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.btnExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.ForeColor = System.Drawing.Color.Cornsilk;
			this.btnExit.Location = new System.Drawing.Point(138, 138);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(96, 24);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "Thoát";
			this.btnExit.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label3.Location = new System.Drawing.Point(24, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 22);
			this.label3.TabIndex = 3;
			this.label3.Text = "Service";
			// 
			// txtUsername
			// 
			this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtUsername.Location = new System.Drawing.Point(120, 16);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(120, 26);
			this.txtUsername.TabIndex = 1;
			this.txtUsername.Text = "system";
			// 
			// FrmDangNhap
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
			this.BackColor = System.Drawing.Color.LightSeaGreen;
			this.ClientSize = new System.Drawing.Size(272, 182);
			this.ControlBox = false;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnDangNhap);
			this.Controls.Add(this.txtPasswd);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtService);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.txtUsername);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmDangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dang Nhap";
			this.Load += new System.EventHandler(this.FrmDangNhap_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void FrmDangNhap_Load(object sender, System.EventArgs e)
		{
			
		}

		

		private void txtMatKhau_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		
		private void button2_Click(object sender, System.EventArgs e)
		{
			((Form1)MdiParent).ShowMenu(false);
			this.Close();
		}
		private void DangNhap()
		{
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider.Username=txtUsername.Text;
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider.Password=txtPasswd.Text;
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider.Service=txtService.Text;
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider _provider= new QUANLYHOCSINHCAP3.KNCSDL.DataProvider();
			string path = "Provider=MSDAORA.1;Data Source= "+txtService.Text+";User ID="+txtUsername.Text+";Password="+txtPasswd.Text+";Persist Security Info=True";
			QUANLYHOCSINHCAP3.KNCSDL.DataProvider.ConnectionString=path;
			_provider.connect();
			if(_provider.flag==1)
			{
				((Form1)MdiParent).ShowMenu(true);
				this.Close();
			}
			else
			{
				MessageBox.Show("Không kết nối Oracle được !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtUsername.Text="";
				txtUsername.Focus();
				return;
			}
		/*	if(txtMatKhau.Text=="")
			{
				
				MessageBox.Show("Bạn phải nhập mật khẩu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtMatKhau.Focus();
				return;
			}
			else
			{
				if(txtMatKhau.Text!="123")
				{
					MessageBox.Show("Bạn nhập sai mật khẩu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
					txtMatKhau.Text="";
					txtMatKhau.Focus();
					return;
				}
				else
				{
					((Form1)MdiParent).ShowMenu(true);
					this.Close();	
				}
			}*/

		}
		private void btnDangNhap_Click(object sender, System.EventArgs e)
		{
			
			DangNhap();		
			
		}

		private void btnDangNhap_Enter(object sender, System.EventArgs e)
		{
			/*if(e.GetType()=="13")	
				DangNhap();*/
		}

		private void btnDangNhap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
		}

		private void txtMatKhau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue==13)
				DangNhap();
		}
	}
}
