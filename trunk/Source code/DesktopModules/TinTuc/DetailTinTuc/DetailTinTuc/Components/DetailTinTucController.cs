using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.DetailTinTuc.Components
{
    public class DetailTinTucController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the DetailTinTucInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<DetailTinTucInfo> GetDetailTinTucs(int moduleId)
        {
            return CBO.FillCollection<DetailTinTucInfo>(DataProvider.Instance().GetDetailTinTucs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public DetailTinTucInfo GetDetailTinTuc(int moduleId, int itemId)
        {
            return (DetailTinTucInfo)CBO.FillObject(DataProvider.Instance().GetDetailTinTuc(moduleId, itemId), typeof(DetailTinTucInfo));
        }


        /// <summary>
        /// Adds a new DetailTinTucInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddDetailTinTuc(DetailTinTucInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddDetailTinTuc(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateDetailTinTuc(DetailTinTucInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateDetailTinTuc(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteDetailTinTuc(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteDetailTinTuc(moduleId, itemId);
        }


        #endregion

        #region ISearchable Members

        /// <summary>
        /// Implements the search interface required to allow DNN to index/search the content of your
        /// module
        /// </summary>
        /// <param name="modInfo"></param>
        /// <returns></returns>
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        {
            SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

            List<DetailTinTucInfo> infos = GetDetailTinTucs(modInfo.ModuleID);

            foreach (DetailTinTucInfo info in infos)
            {
                SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.Content, info.CreatedByUser, info.CreatedDate,
                                                    modInfo.ModuleID, info.ItemId.ToString(), info.Content, "Item=" + info.ItemId.ToString());
                searchItems.Add(searchInfo);
            }

            return searchItems;
        }

        #endregion

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            List<DetailTinTucInfo> infos = GetDetailTinTucs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<DetailTinTucs>");
                foreach (DetailTinTucInfo info in infos)
                {
                    sb.Append("<DetailTinTuc>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</DetailTinTuc>");
                }
                sb.Append("</DetailTinTucs>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "DetailTinTucs");

            foreach (XmlNode info in infos.SelectNodes("DetailTinTuc"))
            {
                DetailTinTucInfo DetailTinTucInfo = new DetailTinTucInfo();
                DetailTinTucInfo.ModuleId = ModuleID;
                DetailTinTucInfo.Content = info.SelectSingleNode("content").InnerText;
                DetailTinTucInfo.CreatedByUser = UserID;

                AddDetailTinTuc(DetailTinTucInfo);
            }
        }

        #endregion
    }
}
