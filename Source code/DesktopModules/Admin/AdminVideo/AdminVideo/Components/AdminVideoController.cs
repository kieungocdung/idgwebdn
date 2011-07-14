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

        /// <summary>
        /// Gets all the TestInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<AdminVideoInfo> GetAdminVideo()
        {
            return CBO.FillCollection<AdminVideoInfo>(DataProvider.Instance().ListAdminVideo());
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public AdminVideoInfo GetAdminVideo(int id)
        {
            return CBO.FillObject<AdminVideoInfo>(DataProvider.Instance().GetAdminVideo(id));
        }


        /// <summary>
        /// Adds a new TestInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddAdminVideo(AdminVideoInfo info)
        {
            DataProvider.Instance().AddAdminVideo(info.TenVideo, info.MoTa, info.VideoPath, info.TrangThai);
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateAdminVideo(AdminVideoInfo info)
        {

            DataProvider.Instance().UpdateAdminVideo(info.ID, info.TenVideo, info.MoTa, info.VideoPath, info.TrangThai);
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteAdminLoaiTin(int id)
        {
            DataProvider.Instance().DeleteAdminVideo(id);
        }
    }
}
