using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace IDG.Dnn.AdminTinTuc.Components
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
            instance = (DataProvider)Reflection.CreateObject("data", "IDG.Dnn.AdminTinTuc.Components", "");
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

        public abstract IDataReader GetAdminTinTuc(int id);
        public abstract IDataReader ListAdminTinTuc();
        public abstract void AddAdminTinTuc(int loaiTinId,string tieuDe,string tomTat,string noiDung,string tacGia,string nguoiTao,string anh,DateTime ngayTao,int luotXem,string NguonTin,bool noiBat,string lang,bool tinhTrang);
        public abstract void UpdateAdminTinTuc(int id,int loaiTinId, string tieuDe, string tomTat, string noiDung, string tacGia, string nguoiTao, string anh, DateTime ngayTao, int luotXem, string NguonTin, bool noiBat, string lang, bool tinhTrang);
        public abstract void DeleteAdminTinTuc(int id);

        #endregion

    }



}
