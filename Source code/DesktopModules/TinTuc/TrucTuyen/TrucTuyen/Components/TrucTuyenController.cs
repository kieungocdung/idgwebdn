using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.TrucTuyen.Components
{
    public class TrucTuyenController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the TrucTuyenInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<TrucTuyenInfo> GetTrucTuyens(int moduleId)
        {
            return CBO.FillCollection<TrucTuyenInfo>(DataProvider.Instance().GetTrucTuyens(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public TrucTuyenInfo GetTrucTuyen(int moduleId, int itemId)
        {
            return (TrucTuyenInfo)CBO.FillObject(DataProvider.Instance().GetTrucTuyen(moduleId, itemId), typeof(TrucTuyenInfo));
        }


        /// <summary>
        /// Adds a new TrucTuyenInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddTrucTuyen(TrucTuyenInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddTrucTuyen(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateTrucTuyen(TrucTuyenInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateTrucTuyen(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteTrucTuyen(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteTrucTuyen(moduleId, itemId);
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

            List<TrucTuyenInfo> infos = GetTrucTuyens(modInfo.ModuleID);

            foreach (TrucTuyenInfo info in infos)
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

            List<TrucTuyenInfo> infos = GetTrucTuyens(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<TrucTuyens>");
                foreach (TrucTuyenInfo info in infos)
                {
                    sb.Append("<TrucTuyen>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</TrucTuyen>");
                }
                sb.Append("</TrucTuyens>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "TrucTuyens");

            foreach (XmlNode info in infos.SelectNodes("TrucTuyen"))
            {
                TrucTuyenInfo TrucTuyenInfo = new TrucTuyenInfo();
                TrucTuyenInfo.ModuleId = ModuleID;
                TrucTuyenInfo.Content = info.SelectSingleNode("content").InnerText;
                TrucTuyenInfo.CreatedByUser = UserID;

                AddTrucTuyen(TrucTuyenInfo);
            }
        }

        #endregion
    }
}
