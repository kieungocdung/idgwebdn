using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace IDG.Dnn.AdminVideo.Components
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

        #region IDGAdminVideo method
        public override IDataReader Get_IDGAdminVideo(int id)
        {
            return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("tblVideo_SelectByID"), id);
        }

        public override IDataReader List_IDGAdminVideo()
        {
            return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("tblVideo_SelectAll"));
        }

        //public override IDataReader List_IDGAdminVideo(int id)
        //{
        //    return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("IDG_IDGAdminVideo_GET"), -1, "-1", nhanVienId, phuCapId, "-1", "-1", "-1");
        //}

        public override int Add_IDGAdminVideo(int ID, string TenVideo, string MoTa, bool TrangThai, string VideoPath)
        {
            return int.Parse(SqlHelper.ExecuteScalar(ConnectionString, GetFullyQualifiedName("tblVideo_Insert"), GetNull(ID), GetNull(TenVideo), GetNull(MoTa), GetNull(TrangThai), GetNull(VideoPath)).ToString());
        }

        public override void Update_IDGAdminVideo(int ID, string TenVideo, string MoTa, bool TrangThai, string VideoPath)
        {
            //check we have some content to store
            SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("tblVideo_Update"), ID, TenVideo, MoTa, TrangThai, VideoPath);
        }

        public override void Delete_IDGAdminVideo(int id)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("tblVideo_Delete"), id);
        }

        //public override void Bindata(ref System.Web.UI.WebControls.SqlDataSource sqlData, int donViId, long AdminVideoId, int nhanVienId, int phuCapId, int thang, int nam, decimal giaTri)
        //{
        //    sqlData.SelectCommandType = System.Web.UI.WebControls.SqlDataSourceCommandType.StoredProcedure;
        //    sqlData.SelectCommand = "IDG_IDGAdminVideo_GET";
        //    sqlData.SelectParameters.Clear();
        //    sqlData.SelectParameters.Add("DonViId", donViId.ToString());
        //    sqlData.SelectParameters.Add("AdminVideoId", AdminVideoId.ToString());
        //    sqlData.SelectParameters.Add("NhanVienId", nhanVienId.ToString());
        //    sqlData.SelectParameters.Add("PhuCapId", phuCapId.ToString());
        //    sqlData.SelectParameters.Add("Thang", thang.ToString());
        //    sqlData.SelectParameters.Add("Nam", nam.ToString());
        //    sqlData.SelectParameters.Add("GiaTri", giaTri.ToString());
        //}

        //public override IDataReader ListIDGAdminVideo(int AdminVideoId, int thang, int nam, string soDanhBo, string tenNhanVien, int donViId)
        //{
        //    return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("IDGListAdminVideo"), AdminVideoId, thang, nam, soDanhBo, tenNhanVien, donViId);
        //}
        #endregion
    }
}
