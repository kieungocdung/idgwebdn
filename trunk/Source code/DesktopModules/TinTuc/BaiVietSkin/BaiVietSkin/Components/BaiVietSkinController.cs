using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.BaiVietSkin.Components
{
    public class BaiVietSkinController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the BaiVietSkinInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<BaiVietSkinInfo> GetBaiVietSkins(int moduleId)
        {
            return CBO.FillCollection<BaiVietSkinInfo>(DataProvider.Instance().GetBaiVietSkins(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public BaiVietSkinInfo GetBaiVietSkin(int moduleId, int itemId)
        {
            return (BaiVietSkinInfo)CBO.FillObject(DataProvider.Instance().GetBaiVietSkin(moduleId, itemId), typeof(BaiVietSkinInfo));
        }


        /// <summary>
        /// Adds a new BaiVietSkinInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddBaiVietSkin(BaiVietSkinInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddBaiVietSkin(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateBaiVietSkin(BaiVietSkinInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateBaiVietSkin(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteBaiVietSkin(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteBaiVietSkin(moduleId, itemId);
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

            List<BaiVietSkinInfo> infos = GetBaiVietSkins(modInfo.ModuleID);

            foreach (BaiVietSkinInfo info in infos)
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

            List<BaiVietSkinInfo> infos = GetBaiVietSkins(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<BaiVietSkins>");
                foreach (BaiVietSkinInfo info in infos)
                {
                    sb.Append("<BaiVietSkin>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</BaiVietSkin>");
                }
                sb.Append("</BaiVietSkins>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "BaiVietSkins");

            foreach (XmlNode info in infos.SelectNodes("BaiVietSkin"))
            {
                BaiVietSkinInfo BaiVietSkinInfo = new BaiVietSkinInfo();
                BaiVietSkinInfo.ModuleId = ModuleID;
                BaiVietSkinInfo.Content = info.SelectSingleNode("content").InnerText;
                BaiVietSkinInfo.CreatedByUser = UserID;

                AddBaiVietSkin(BaiVietSkinInfo);
            }
        }

        #endregion
    }
}
