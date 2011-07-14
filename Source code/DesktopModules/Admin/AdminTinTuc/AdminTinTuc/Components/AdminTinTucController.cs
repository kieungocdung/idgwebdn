using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace IDG.Dnn.AdminTinTuc.Components
{
    public class AdminTinTucController
    {
        /// <summary>
        /// Gets all the TestInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<AdminTinTucInfo> ListAdminTinTuc()
        {
            return CBO.FillCollection<AdminTinTucInfo>(DataProvider.Instance().ListAdminTinTuc());
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public AdminTinTucInfo GetAdminTinTuc(int id)
        {
            return CBO.FillObject<AdminTinTucInfo>(DataProvider.Instance().GetAdminTinTuc(id));
        }


        /// <summary>
        /// Adds a new TestInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddAdminTinTuc(AdminTinTucInfo info)
        {
            
            DataProvider.Instance().AddAdminTinTuc(info.LoaiTinID, info.TieuDe, info.TomTat, info.NoiDung, info.TacGia, info.NguoiTao, info.Anh,info.NgayTao,info.LuotXem,info.NguonTin,info.NoiBat,info.Lang,info.TinhTrang);
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateAdminTinTuc(AdminTinTucInfo info)
        {

            DataProvider.Instance().UpdateAdminTinTuc(info.ID,info.LoaiTinID, info.TieuDe, info.TomTat, info.NoiDung, info.TacGia, info.NguoiTao, info.Anh, info.NgayTao, info.LuotXem, info.NguonTin, info.NoiBat, info.Lang, info.TinhTrang);
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteAdmiTinTuc(int id)
        {
            DataProvider.Instance().DeleteAdminTinTuc(id);
        }
    }
}
