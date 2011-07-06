using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace YourCompany.BaiGiang.Components
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
            instance = (DataProvider)Reflection.CreateObject("data", "YourCompany.BaiGiang.Components", "");
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

        public abstract IDataReader GetBaiGiangs(int moduleId);
        public abstract IDataReader GetBaiGiang(int moduleId, int itemId);
        public abstract void AddBaiGiang(int moduleId, string content, int userId);
        public abstract void UpdateBaiGiang(int moduleId, int itemId, string content, int userId);
        public abstract void DeleteBaiGiang(int moduleId, int itemId);

        #endregion

    }



}
