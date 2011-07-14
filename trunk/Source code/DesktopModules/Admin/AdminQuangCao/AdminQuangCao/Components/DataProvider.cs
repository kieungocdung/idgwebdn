using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace IDG.Dnn.AdminQuangCao.Components
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
            instance = (DataProvider)Reflection.CreateObject("data", "YourCompany.AdminQuangCao.Components", "");
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

        /* implement the methods that the dataprovider should */

        public abstract IDataReader GetAdminQuangCao(int id);
        public abstract IDataReader ListAdminQuangCao();
        public abstract void AddAdminQuangCao(string tieuDe, string moTa, string url_Image, string link, int thuTu, DateTime ngayKetThuc, int vung, bool tinhTrang);
        public abstract void UpdateAdminQuangCao(int id, string tieuDe, string moTa, string url_Image, string link, int thuTu, DateTime ngayKetThuc, int vung, bool tinhTrang);
        public abstract void DeleteAdminQuangCao(int id);

        #endregion

    }



}
