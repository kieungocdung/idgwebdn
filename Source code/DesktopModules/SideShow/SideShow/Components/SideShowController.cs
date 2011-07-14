using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.SideShow.Components
{
    public class SideShowController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the SideShowInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<SideShowInfo> GetSideShows(int moduleId)
        {
            return CBO.FillCollection<SideShowInfo>(DataProvider.Instance().GetSideShows(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public SideShowInfo GetSideShow(int moduleId, int itemId)
        {
            return (SideShowInfo)CBO.FillObject(DataProvider.Instance().GetSideShow(moduleId, itemId), typeof(SideShowInfo));
        }


        /// <summary>
        /// Adds a new SideShowInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddSideShow(SideShowInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddSideShow(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateSideShow(SideShowInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateSideShow(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteSideShow(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteSideShow(moduleId, itemId);
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

            List<SideShowInfo> infos = GetSideShows(modInfo.ModuleID);

            foreach (SideShowInfo info in infos)
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

            List<SideShowInfo> infos = GetSideShows(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<SideShows>");
                foreach (SideShowInfo info in infos)
                {
                    sb.Append("<SideShow>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</SideShow>");
                }
                sb.Append("</SideShows>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "SideShows");

            foreach (XmlNode info in infos.SelectNodes("SideShow"))
            {
                SideShowInfo SideShowInfo = new SideShowInfo();
                SideShowInfo.ModuleId = ModuleID;
                SideShowInfo.Content = info.SelectSingleNode("content").InnerText;
                SideShowInfo.CreatedByUser = UserID;

                AddSideShow(SideShowInfo);
            }
        }

        #endregion
    }
}
