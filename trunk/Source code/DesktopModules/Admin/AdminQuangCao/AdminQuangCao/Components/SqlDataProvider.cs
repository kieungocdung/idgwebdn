using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace IDG.Dnn.AdminQuangCao.Components
{
    public class SqlDataProvider : DataProvider
    {


        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "YourCompany_";

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

        public override IDataReader GetAdminQuangCao(int id)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("tblQuangCao_SelectByID"), id);
        }

        public override IDataReader ListAdminQuangCao()
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("tblQuangCao_SelectAll"));
        }

        public override void AddAdminQuangCao(string tieuDe, string moTa, string url_Image, string link, int thuTu, DateTime ngayKetThuc, int vung,bool tinhTrang)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblQuangCao_Insert"), tieuDe, moTa, url_Image, link, thuTu, ngayKetThuc,vung, tinhTrang);
        }

        public override void UpdateAdminQuangCao(int id, string tieuDe, string moTa, string url_Image, string link, int thuTu, DateTime ngayKetThuc, int vung, bool tinhTrang)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblQuangCao_Update"), id, tieuDe, moTa, url_Image, link, thuTu, ngayKetThuc, vung, tinhTrang);
        }

        public override void DeleteAdminQuangCao(int id)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblQuangCao_Delete"), id);
        }

        #endregion
    }
}
