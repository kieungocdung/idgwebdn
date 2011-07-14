using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace IDG.Dnn.AdminLoaiTin.Components
{
    public class SqlDataProvider : DataProvider
    {


        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "";

        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;

        #endregion

        #region cstor

        /// <summary>
        /// cstor used to create the sqlProvider with required parameters from the configuration
        /// section of web.config file
        /// </summary>
        public SqlDataProvider()
        {
            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];
            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];

            providerPath = provider.Attributes["providerPath"];

            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_"))
                objectQualifier += "_";

            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith("."))
                databaseOwner += ".";
        }

        #endregion

        #region properties

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string ProviderPath
        {
            get { return providerPath; }
        }

        public string ObjectQualifier
        {
            get { return objectQualifier; }
        }


        public string DatabaseOwner
        {
            get { return databaseOwner; }
        }

        #endregion

        #region private methods

        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + moduleQualifier + name;
        }

        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region override methods

        public override IDataReader GetAdminLoaiTins(int id)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("tblLoaiTin_SelectByID"), id);
        }

        public override IDataReader ListAdminLoaiTin()
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("tblLoaiTin_SelectAll"));
        }

        public override void AddAdminLoaiTin(string ten, int cha, int thuTu, DateTime ngayTao, int nguonTin, string lang, bool tinhTrang)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblLoaiTin_Insert"), ten,cha,thuTu,ngayTao,nguonTin,lang,tinhTrang);
        }

        public override void UpdateAdminLoaiTin(int id,string ten, int cha, int thuTu, DateTime ngayTao, int nguonTin, string lang, bool tinhTrang)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblLoaiTin_Update"),id, ten, cha, thuTu, ngayTao, nguonTin, lang, tinhTrang);
        }

        public override void DeleteAdminLoaiTin(int id)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblLoaiTin_Delete"), id);
        }

        #endregion
    }
}
