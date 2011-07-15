using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace YourCompany.BaiVietModule.Components
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
            instance = (DataProvider)Reflection.CreateObject("data", "YourCompany.BaiVietModule.Components", "");
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

        public abstract IDataReader GetBaiVietModules(int moduleId);
        public abstract IDataReader GetBaiVietModule(int moduleId, int itemId);
        public abstract void AddBaiVietModule(int moduleId, string content, int userId);
        public abstract void UpdateBaiVietModule(int moduleId, int itemId, string content, int userId);
        public abstract void DeleteBaiVietModule(int moduleId, int itemId);

        #endregion

    }



}
