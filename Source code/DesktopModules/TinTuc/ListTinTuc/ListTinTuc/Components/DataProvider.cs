using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace YourCompany.ListTinTuc.Components
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
            instance = (DataProvider)Reflection.CreateObject("data", "YourCompany.ListTinTuc.Components", "");
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

        public abstract IDataReader GetListTinTucs(int moduleId);
        public abstract IDataReader GetListTinTuc(int moduleId, int itemId);
        public abstract void AddListTinTuc(int moduleId, string content, int userId);
        public abstract void UpdateListTinTuc(int moduleId, int itemId, string content, int userId);
        public abstract void DeleteListTinTuc(int moduleId, int itemId);

        #endregion

    }



}
