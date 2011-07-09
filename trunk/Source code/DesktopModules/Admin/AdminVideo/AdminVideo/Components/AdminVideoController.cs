using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace IDG.Dnn.AdminVideo.Components
{
    public class AdminVideoController 
    {

       #region Constructors
        public AdminVideoController()
        {
        }
        #endregion

        #region public method
        public List<AdminVideoInfo> List()
        {
            return CBO.FillCollection<AdminVideoInfo>(DataProvider.Instance().List_IDGAdminVideo());
        }
        //public List<AdminVideoInfo> List(int id)
        //{
        //    return CBO.FillCollection<AdminVideoInfo>(DataProvider.Instance().List_IDGAdminVideo(id));
        //}
        public AdminVideoInfo Get(int id)
        {
            return CBO.FillObject<AdminVideoInfo>(DataProvider.Instance().Get_IDGAdminVideo(id));
        }
        public void Add(AdminVideoInfo info)
        {
            //check we have some content to store
            DataProvider.Instance().Add_IDGAdminVideo(info.ID, info.TenVideo, info.MoTa, info.TrangThai, info.VideoPath);
        }
        public void Update(AdminVideoInfo info)
        {
            //check we have some content to store
            DataProvider.Instance().Update_IDGAdminVideo(info.ID, info.TenVideo, info.MoTa, info.TrangThai, info.VideoPath);
        }
        public void Delete(int id)
        {
            DataProvider.Instance().Delete_IDGAdminVideo(id);
        }
        //public void Bindata(ref System.Web.UI.WebControls.SqlDataSource sqlData, int donViId, long AdminVideoId, int nhanVienId, int phuCapId, int thang, int nam, decimal giaTri)
        //{
        //    DataProvider.Instance().Bindata(ref sqlData, donViId, AdminVideoId, nhanVienId, phuCapId, thang, nam, giaTri);
        //}
        //public List<AdminVideoInfo> ListIDGAdminVideo(int AdminVideoId, int thang, int nam, string soDanhBo, string tenNhanVien, int donViId)
        //{
        //    return CBO.FillCollection<AdminVideoInfo>(DataProvider.Instance().ListIDGAdminVideo(AdminVideoId, thang, nam, soDanhBo, tenNhanVien, donViId));
        //}
        #endregion
    }
}
