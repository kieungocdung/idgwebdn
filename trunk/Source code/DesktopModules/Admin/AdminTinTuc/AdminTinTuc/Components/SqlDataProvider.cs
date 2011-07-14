using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace IDG.Dnn.AdminTinTuc.Components
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

        public override IDataReader GetAdminTinTuc(int id)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("tblTinTuc_SelectByID"), id);
        }

        public override IDataReader ListAdminTinTuc()
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("tblTinTuc_SelectAll"));
        }

        public override void AddAdminTinTuc(int loaiTinId, string tieuDe, string tomTat, string noiDung, string tacGia, string nguoiTao, string anh, DateTime ngayTao, int luotXem, string NguonTin, bool noiBat, string lang, bool tinhTrang)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblTinTuc_Insert"), loaiTinId, tieuDe, tomTat, noiDung, tacGia, nguoiTao, anh, ngayTao, luotXem, NguonTin, noiBat, lang, tinhTrang);
        }

        public override void UpdateAdminTinTuc(int id, int loaiTinId, string tieuDe, string tomTat, string noiDung, string tacGia, string nguoiTao, string anh, DateTime ngayTao, int luotXem, string NguonTin, bool noiBat, string lang, bool tinhTrang)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblTinTuc_Update"), id, loaiTinId, tieuDe, tomTat, noiDung, tacGia, nguoiTao,anh,ngayTao,luotXem,NguonTin,noiBat,lang,tinhTrang );
        }

        public override void DeleteAdminTinTuc(int id)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("tblTinTuc_Delete"), id);
        }

        #endregion
    }
}
