using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDG.Dnn.AdminTinTuc.Components;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using IDG.Dnn.AdminLoaiTin.Components;

namespace IDG.Dnn.AdminTinTuc
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
                //load dropdownloadlist
                //InsertParentItem();
                LoadList();
            }
        }
      
        #region Loadlist
        private void LoadList()
        {
            AdminTinTucController control = new AdminTinTucController();
            List<AdminTinTucInfo> list = control.ListAdminTinTuc();
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
                int tinid = Convert.ToInt32(e.CommandArgument);
                AdminTinTucController control = new AdminTinTucController();
                AdminTinTucInfo tintuc = control.GetAdminTinTuc(tinid);
                if (tinid != null)
                {
                    try
                    {
                        control.DeleteAdmiTinTuc(tinid);
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