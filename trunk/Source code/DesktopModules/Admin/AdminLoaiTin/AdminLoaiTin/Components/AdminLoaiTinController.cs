using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace IDG.Dnn.AdminLoaiTin.Components
{
    public class AdminLoaiTinController
    {
        /// <summary>
        /// Gets all the TestInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<AdminLoaiTinInfo> ListAdminLoaiTins()
        {
            return CBO.FillCollection<AdminLoaiTinInfo>(DataProvider.Instance().ListAdminLoaiTin());
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public AdminLoaiTinInfo GetAdminLoaiTins(int id)
        {
            return CBO.FillObject<AdminLoaiTinInfo>(DataProvider.Instance().GetAdminLoaiTins(id));
        }


        /// <summary>
        /// Adds a new TestInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddAdminLoaiTin(AdminLoaiTinInfo info)
        {
           
                DataProvider.Instance().AddAdminLoaiTin(info.Ten, info.Cha, info.ThuTu,info.NgayTao,info.NguonTin,info.Lang,info.TinhTrang);
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateAdminLoaiTin(AdminLoaiTinInfo info)
        {

            DataProvider.Instance().UpdateAdminLoaiTin(info.ID, info.Ten, info.Cha, info.ThuTu, info.NgayTao, info.NguonTin, info.Lang, info.TinhTrang);
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteAdminLoaiTin(int id)
        {
            DataProvider.Instance().DeleteAdminLoaiTin(id);
        }
        
    }
}
