using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using IDG.Dnn.AdminLoaiTin.Components;
using DotNetNuke.Services.Exceptions;

namespace IDG.Dnn.AdminLoaiTin
{
    public partial class View : PortalModuleBase
    {
        #region "Properties"
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] != null)
                    return int.Parse(ViewState["CurrentPage"].ToString());
                return 0;
            }
            set { ViewState["CurrentPage"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadList();
            }
        }
        #region Loadlist
        private void LoadList()
        {
            AdminLoaiTinController control = new AdminLoaiTinController();
            List<AdminLoaiTinInfo> list = control.ListAdminLoaiTins();
            if (list != null && list.Count > 0)
            {
                this.gvAdminLoaiTin.DataSource = list;
                int rowsCount = list.Count, pageSize = 10;
                int pagesCount = (int)Math.Ceiling((double)rowsCount / (double)pageSize);
                this.ddlChuyenToiTrang.Items.Clear();
                for (int i = 1; i <= pagesCount; i++)
                    this.ddlChuyenToiTrang.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.ddlChuyenToiTrang.SelectedIndex = this.CurrentPage - 1;
            }
            this.gvAdminLoaiTin.DataBind();
        }
        

        public string TinhTrang(bool b)
        {
            if (b == true)
                return "Hoạt động";
            return "Không hoạt động";
        }


        protected void ddlChuyenToiTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentPage = int.Parse(this.ddlChuyenToiTrang.SelectedItem.Value);
            this.gvAdminLoaiTin.PageIndex = this.CurrentPage - 1;
            LoadList();
        }
        protected void gvAdminLoaiTin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteLoaiTin")
            {
                int loaitinid = Convert.ToInt32(e.CommandArgument);
                AdminLoaiTinController control = new AdminLoaiTinController();
                AdminLoaiTinInfo loaitin = control.GetAdminLoaiTins(loaitinid);
                if (loaitin != null)
                {
                    try
                    {
                        control.DeleteAdminLoaiTin(loaitinid);
                        this.lblThongBao.Text = "Loại tin đã xóa thành công.";
                        LoadList();
                    }
                    catch (Exception ex)
                    {
                        Exceptions.ProcessModuleLoadException(this, ex);
                        this.lblThongBao.Text = "Loại tin đã xóa không thành công.";

                    }
                }

            }
        }
        #endregion

        protected void lbtnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(EditUrl("Edit"));
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}