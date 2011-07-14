using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace IDG.Dnn.AdminLoaiTin.Components
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
            instance = (DataProvider)Reflection.CreateObject("data", "IDG.Dnn.AdminLoaiTin.Components", "");
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

        public abstract IDataReader GetAdminLoaiTins(int id);
        public abstract IDataReader ListAdminLoaiTin();
        public abstract void AddAdminLoaiTin( string ten , int cha,int thuTu,DateTime ngayTao,int nguonTin,string lang,bool tinhTrang);
        public abstract void UpdateAdminLoaiTin(int id, string ten, int cha, int thuTu, DateTime ngayTao, int nguonTin, string lang, bool tinhTrang);
        public abstract void DeleteAdminLoaiTin(int id);

        #endregion

    }



}
