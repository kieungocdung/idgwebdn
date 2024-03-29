using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace IDG.Dnn.GioiThieuIDG.Components
{
    public class GioiThieuIDGController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the GioiThieuIDGInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<GioiThieuIDGInfo> GetGioiThieuIDGs(int moduleId)
        {
            return CBO.FillCollection<GioiThieuIDGInfo>(DataProvider.Instance().GetGioiThieuIDGs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public GioiThieuIDGInfo GetGioiThieuIDG(int moduleId, int itemId)
        {
            return (GioiThieuIDGInfo)CBO.FillObject(DataProvider.Instance().GetGioiThieuIDG(moduleId, itemId), typeof(GioiThieuIDGInfo));
        }


        /// <summary>
        /// Adds a new GioiThieuIDGInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddGioiThieuIDG(GioiThieuIDGInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddGioiThieuIDG(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateGioiThieuIDG(GioiThieuIDGInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateGioiThieuIDG(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteGioiThieuIDG(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteGioiThieuIDG(moduleId, itemId);
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

            List<GioiThieuIDGInfo> infos = GetGioiThieuIDGs(modInfo.ModuleID);

            foreach (GioiThieuIDGInfo info in infos)
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

            List<GioiThieuIDGInfo> infos = GetGioiThieuIDGs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<GioiThieuIDGs>");
                foreach (GioiThieuIDGInfo info in infos)
                {
                    sb.Append("<GioiThieuIDG>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</GioiThieuIDG>");
                }
                sb.Append("</GioiThieuIDGs>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "GioiThieuIDGs");

            foreach (XmlNode info in infos.SelectNodes("GioiThieuIDG"))
            {
                GioiThieuIDGInfo GioiThieuIDGInfo = new GioiThieuIDGInfo();
                GioiThieuIDGInfo.ModuleId = ModuleID;
                GioiThieuIDGInfo.Content = info.SelectSingleNode("content").InnerText;
                GioiThieuIDGInfo.CreatedByUser = UserID;

                AddGioiThieuIDG(GioiThieuIDGInfo);
            }
        }

        #endregion
    }
}
