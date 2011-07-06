using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.TinTuc.Components
{
    public class TinTucController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the TinTucInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<TinTucInfo> GetTinTucs(int moduleId)
        {
            return CBO.FillCollection<TinTucInfo>(DataProvider.Instance().GetTinTucs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public TinTucInfo GetTinTuc(int moduleId, int itemId)
        {
            return (TinTucInfo)CBO.FillObject(DataProvider.Instance().GetTinTuc(moduleId, itemId), typeof(TinTucInfo));
        }


        /// <summary>
        /// Adds a new TinTucInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddTinTuc(TinTucInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddTinTuc(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateTinTuc(TinTucInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateTinTuc(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteTinTuc(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteTinTuc(moduleId, itemId);
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

            List<TinTucInfo> infos = GetTinTucs(modInfo.ModuleID);

            foreach (TinTucInfo info in infos)
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

            List<TinTucInfo> infos = GetTinTucs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<TinTucs>");
                foreach (TinTucInfo info in infos)
                {
                    sb.Append("<TinTuc>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</TinTuc>");
                }
                sb.Append("</TinTucs>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "TinTucs");

            foreach (XmlNode info in infos.SelectNodes("TinTuc"))
            {
                TinTucInfo TinTucInfo = new TinTucInfo();
                TinTucInfo.ModuleId = ModuleID;
                TinTucInfo.Content = info.SelectSingleNode("content").InnerText;
                TinTucInfo.CreatedByUser = UserID;

                AddTinTuc(TinTucInfo);
            }
        }

        #endregion
    }
}
