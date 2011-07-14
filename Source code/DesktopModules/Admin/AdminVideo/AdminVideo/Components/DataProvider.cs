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
        public abstract IDataReader GetAdminVideo(int id);
        public abstract IDataReader ListAdminVideo();
        public abstract void AddAdminVideo(string tenVideo, string moTa,string videoPath,bool tinhTrang);
        public abstract void UpdateAdminVideo(int id,string tenVideo, string moTa, string videoPath, bool tinhTrang);
        public abstract void DeleteAdminVideo(int id);
        #endregion


    }



}
