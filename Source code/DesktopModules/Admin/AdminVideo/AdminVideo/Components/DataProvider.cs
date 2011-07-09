using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace IDG.Dnn.AdminVideo.Components
{
    public abstract class DataProvider
    {

        #region common methods

        /// <summary>
        /// var that is returned in the this singleton
        /// pattern
        /// </summary>
        private static DataProvider instance = null;

        /// <summary>
        /// private static cstor that is used to init an
        /// instance of this class as a singleton
        /// </summary>
        static DataProvider()
        {
            instance = (DataProvider)Reflection.CreateObject("data", "IDG.Dnn.AdminVideo.Components", "");
        }

        /// <summary>
        /// Exposes the singleton object used to access the database with
        /// the conrete dataprovider
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return instance;
        }

        #endregion

        #region Abstract methods
        public abstract IDataReader Get_IDGAdminVideo(int id);
        public abstract IDataReader List_IDGAdminVideo();
        //public abstract IDataReader List_IDGAdminVideo(int id);
        public abstract int Add_IDGAdminVideo(int Id, string tenVideo, string mota, bool trangThai, string videoPath);
        public abstract void Update_IDGAdminVideo(int Id, string tenVideo, string mota, bool trangThai, string videoPath);
        public abstract void Delete_IDGAdminVideo(int id);
        //public abstract void Bindata(ref System.Web.UI.WebControls.SqlDataSource sqlData, int donViId, long AdminVideoId, int nhanVienId, int phuCapId, int thang, int nam, decimal giaTri);
        //public abstract IDataReader ListIDGAdminVideo(int AdminVideoId, int thang, int nam, string soDanhBo, string tenNhanVien, int donViId);
        #endregion


    }



}
