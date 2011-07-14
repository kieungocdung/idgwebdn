using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDG.Dnn.AdminTinTuc.Components;
using IDG.DNN.AdminTinTuc;
using DotNetNuke.Common;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using IDG.Dnn.AdminLoaiTin.Components;

namespace IDG.Dnn.AdminTinTuc
{
    public partial class Edit : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InsertParentItem();
                LoadData();
            }
        }
        #region Load List Vao Dropdownlist
        public List<AdminLoaiTinInfo> LoadListData()
        {
            AdminLoaiTinController control = new AdminLoaiTinController();
            return control.ListAdminLoaiTins();
        }

        public void InsertParentItem()
        {
            List<AdminLoaiTinInfo> list = LoadListData();
            this.ddlLoaiTin.Items.Clear();
            if (list != null && list.Count > 0)
            {
                foreach (AdminLoaiTinInfo loaitin in list)
                {
                    if (loaitin.Cha == 0)
                    {
                        ListItem item = new ListItem();
                        item.Value = loaitin.ID.ToString();
                        item.Text = loaitin.Ten;
                        this.ddlLoaiTin.Items.Add(item);
                        InsertChildItem(item, list);
                    }
                }
            }
        }

        public void InsertChildItem(ListItem loaitincha, List<AdminLoaiTinInfo> list)
        {
            AdminLoaiTinController control = new AdminLoaiTinController();
            AdminLoaiTinInfo Info = control.GetAdminLoaiTins(int.Parse(loaitincha.Value));
            string[] s = loaitincha.Text.Split(' ');
            foreach (AdminLoaiTinInfo loaitin in list)
            {
                if (loaitin.Cha != 0)
                {
                    if (loaitin.Cha == int.Parse(loaitincha.Value))
                    {
                        ListItem childNode = new ListItem();
                        childNode.Value = loaitin.ID.ToString();
                        if (Info.Cha != 0)
                            childNode.Text = s[0] + "--- " + loaitin.Ten;
                        else
                            childNode.Text = "--- " + loaitin.Ten;
                        this.ddlLoaiTin.Items.Add(childNode);
                        InsertChildItem(childNode, list);
                    }
                }
            }
        }
        #endregion
        public void LoadData()
        {
            if (Request["action"] != null)
            {
                AdminTinTucController control = new AdminTinTucController();
                AdminTinTucInfo cv = control.GetAdminTinTuc(int.Parse(Request["action"]));
                this.tbxTieuDe.Text = cv.TieuDe;
                this.tbxtacgia.Text = cv.TacGia.ToString();
                this.tbxNguoiTao.Text = cv.NguoiTao.ToString();
                this.txtTomTat.Value = cv.TomTat.ToString();
                this.txtNoiDung.Value = cv.NoiDung.ToString();
                this.cbNoiBat.Checked = cv.NoiBat;
                this.ddlLoaiTin.SelectedValue = cv.LoaiTinID.ToString();
                this.ddlNguonTin.SelectedValue = cv.NguonTin.ToString();
                this.ddlNgonNgu.SelectedValue = cv.Lang;
                this.cbxTinhTrang.Checked = cv.TinhTrang;
                this.imgImage.ImageUrl = cv.Anh;
            }
        }
        protected void lbtnGhiLai_Click(object sender, EventArgs e)
        {
            AdminTinTucController control = new AdminTinTucController();
            // UPDATE
            if (Request["action"] != null)
            {
                AdminTinTucInfo cv = control.GetAdminTinTuc(int.Parse(Request["action"]));

                cv.TieuDe = tbxTieuDe.Text;
                cv.LoaiTinID = Convert.ToInt32(ddlLoaiTin.SelectedValue);
                cv.TomTat = txtTomTat.Value;
                cv.NoiDung = txtNoiDung.Value;
                cv.TacGia = tbxtacgia.Text;
                cv.NguoiTao = tbxNguoiTao.Text;
                //Upload ảnh
                string urlImage = string.Empty;
                if (Common.CheckContainImage(fulAnh))
                {
                    if (Common.UploadImage(fulAnh, Server.MapPath("~/"), Constants.IMAGE_TINTUC, ref urlImage))
                    {
                        cv.Anh = urlImage;
                    }
                }
                cv.NgayTao = DateTime.Now;
                cv.NguonTin = (ddlNguonTin.SelectedValue);
                cv.NoiBat = cbNoiBat.Checked;
                cv.Lang = ddlNgonNgu.SelectedValue;
                cv.TinhTrang = cbxTinhTrang.Checked;

                try
                {
                    control.UpdateAdminTinTuc(cv);
                    this.lblThongBao.Text = "Ghi lại thành công";
                }
                catch (Exception ex)
                {
                    this.lblThongBao.Text = "Có lỗi: " + ex.ToString();
                }
            }
            else // INSERT
            {
                AdminTinTucInfo cv = new AdminTinTucInfo();

                cv.TieuDe = tbxTieuDe.Text;
                cv.LoaiTinID = Convert.ToInt32(ddlLoaiTin.SelectedValue);
                cv.TomTat = txtTomTat.Value;
                cv.NoiDung = txtNoiDung.Value;
                cv.TacGia = tbxtacgia.Text;
                cv.NguoiTao = tbxNguoiTao.Text;
                //Upload ảnh
                string urlImage = string.Empty;
                if (Common.CheckContainImage(fulAnh))
                {
                    if (Common.UploadImage(fulAnh, Server.MapPath("~/"), Constants.IMAGE_TINTUC, ref urlImage))
                    {
                        cv.Anh = urlImage;
                    }
                }
                cv.NgayTao = DateTime.Now;
                cv.NguonTin = (ddlNguonTin.SelectedValue);
                cv.NoiBat = cbNoiBat.Checked;
                cv.Lang = ddlNgonNgu.SelectedValue;
                cv.TinhTrang = cbxTinhTrang.Checked;
                try
                {
                    control.AddAdminTinTuc(cv);
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