using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDG.Dnn.AdminLoaiTin.Components;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Framework.Providers;

namespace IDG.Dnn.AdminLoaiTin
{
    public partial class Edit : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }
        public void LoadData()
        {
            if (Request["action"] != null)
            {
                AdminLoaiTinController control = new AdminLoaiTinController();
                AdminLoaiTinInfo cv = control.GetAdminLoaiTins(int.Parse(Request["action"]));
                this.tbxTieuDe.Text = cv.Ten;
                this.tbxCha.Text = cv.Cha.ToString();
                this.tbxThuTu.Text = cv.ThuTu.ToString();
                this.ddlNguonTin.SelectedValue = cv.NguonTin.ToString();
                this.ddlNgonNgu.SelectedValue = cv.Lang;
                this.cbxTinhTrang.Checked = cv.TinhTrang;
            }
        }
        protected void lbtnGhiLai_Click(object sender, EventArgs e)
        {
            AdminLoaiTinController control = new AdminLoaiTinController();
            // UPDATE
            if (Request["action"] != null)
            {
                AdminLoaiTinInfo cv = control.GetAdminLoaiTins(int.Parse(Request["action"]));

                cv.Ten = this.tbxTieuDe.Text.Trim();
                cv.Cha =Convert.ToInt32(this.tbxCha.Text.Trim());
                cv.ThuTu =Convert.ToInt32(this.tbxThuTu.Text.Trim());
                cv.NgayTao = DateTime.Now;
                cv.NguonTin =Convert.ToInt32(this.ddlNguonTin.SelectedValue.Trim());
                cv.Lang = this.ddlNgonNgu.SelectedValue.Trim();
                cv.TinhTrang = this.cbxTinhTrang.Checked;

                try
                {
                    control.UpdateAdminLoaiTin(cv);
                    this.lblThongBao.Text = "Ghi lại thành công";
                }
                catch (Exception ex)
                {
                    this.lblThongBao.Text = "Có lỗi: " + ex.ToString();
                }
            }
            else // INSERT
            {
                AdminLoaiTinInfo cv = new AdminLoaiTinInfo();

                cv.Ten = this.tbxTieuDe.Text.Trim();
                cv.Cha = Convert.ToInt32(this.tbxCha.Text.Trim());
                cv.ThuTu = Convert.ToInt32(this.tbxThuTu.Text.Trim());
                cv.NgayTao = DateTime.Now;
                cv.NguonTin = Convert.ToInt32(this.ddlNguonTin.SelectedValue.Trim());
                cv.Lang = this.ddlNgonNgu.SelectedValue.Trim();
                cv.TinhTrang = this.cbxTinhTrang.Checked;
                try
                {
                    control.AddAdminLoaiTin(cv);
                    this.lblThongBao.Text = "Ghi lại thành công";
                }
                catch (Exception ex)
                {
                    this.lblThongBao.Text = "Có lỗi: " + ex.ToString();
                }
            }

        }

        protected void lbtnDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Globals.NavigateURL(this.TabId));
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }
    }
}