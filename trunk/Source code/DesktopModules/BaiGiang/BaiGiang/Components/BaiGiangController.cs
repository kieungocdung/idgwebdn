using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.BaiGiang.Components
{
    public class BaiGiangController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the BaiGiangInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<BaiGiangInfo> GetBaiGiangs(int moduleId)
        {
            return CBO.FillCollection<BaiGiangInfo>(DataProvider.Instance().GetBaiGiangs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public BaiGiangInfo GetBaiGiang(int moduleId, int itemId)
        {
            return (BaiGiangInfo)CBO.FillObject(DataProvider.Instance().GetBaiGiang(moduleId, itemId), typeof(BaiGiangInfo));
        }


        /// <summary>
        /// Adds a new BaiGiangInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddBaiGiang(BaiGiangInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddBaiGiang(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateBaiGiang(BaiGiangInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateBaiGiang(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteBaiGiang(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteBaiGiang(moduleId, itemId);
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

            List<BaiGiangInfo> infos = GetBaiGiangs(modInfo.ModuleID);

            foreach (BaiGiangInfo info in infos)
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

            List<BaiGiangInfo> infos = GetBaiGiangs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<BaiGiangs>");
                foreach (BaiGiangInfo info in infos)
                {
                    sb.Append("<BaiGiang>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</BaiGiang>");
                }
                sb.Append("</BaiGiangs>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "BaiGiangs");

            foreach (XmlNode info in infos.SelectNodes("BaiGiang"))
            {
                BaiGiangInfo BaiGiangInfo = new BaiGiangInfo();
                BaiGiangInfo.ModuleId = ModuleID;
                BaiGiangInfo.Content = info.SelectSingleNode("content").InnerText;
                BaiGiangInfo.CreatedByUser = UserID;

                AddBaiGiang(BaiGiangInfo);
            }
        }

        #endregion
    }
}
