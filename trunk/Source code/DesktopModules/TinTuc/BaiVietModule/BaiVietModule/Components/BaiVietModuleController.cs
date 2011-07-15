using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.BaiVietModule.Components
{
    public class BaiVietModuleController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the BaiVietModuleInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<BaiVietModuleInfo> GetBaiVietModules(int moduleId)
        {
            return CBO.FillCollection<BaiVietModuleInfo>(DataProvider.Instance().GetBaiVietModules(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public BaiVietModuleInfo GetBaiVietModule(int moduleId, int itemId)
        {
            return (BaiVietModuleInfo)CBO.FillObject(DataProvider.Instance().GetBaiVietModule(moduleId, itemId), typeof(BaiVietModuleInfo));
        }


        /// <summary>
        /// Adds a new BaiVietModuleInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddBaiVietModule(BaiVietModuleInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddBaiVietModule(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateBaiVietModule(BaiVietModuleInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateBaiVietModule(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteBaiVietModule(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteBaiVietModule(moduleId, itemId);
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

            List<BaiVietModuleInfo> infos = GetBaiVietModules(modInfo.ModuleID);

            foreach (BaiVietModuleInfo info in infos)
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

            List<BaiVietModuleInfo> infos = GetBaiVietModules(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<BaiVietModules>");
                foreach (BaiVietModuleInfo info in infos)
                {
                    sb.Append("<BaiVietModule>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</BaiVietModule>");
                }
                sb.Append("</BaiVietModules>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "BaiVietModules");

            foreach (XmlNode info in infos.SelectNodes("BaiVietModule"))
            {
                BaiVietModuleInfo BaiVietModuleInfo = new BaiVietModuleInfo();
                BaiVietModuleInfo.ModuleId = ModuleID;
                BaiVietModuleInfo.Content = info.SelectSingleNode("content").InnerText;
                BaiVietModuleInfo.CreatedByUser = UserID;

                AddBaiVietModule(BaiVietModuleInfo);
            }
        }

        #endregion
    }
}
