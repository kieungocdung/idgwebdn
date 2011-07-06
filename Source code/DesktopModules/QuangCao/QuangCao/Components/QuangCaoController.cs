using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.QuangCao.Components
{
    public class QuangCaoController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the QuangCaoInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<QuangCaoInfo> GetQuangCaos(int moduleId)
        {
            return CBO.FillCollection<QuangCaoInfo>(DataProvider.Instance().GetQuangCaos(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public QuangCaoInfo GetQuangCao(int moduleId, int itemId)
        {
            return (QuangCaoInfo)CBO.FillObject(DataProvider.Instance().GetQuangCao(moduleId, itemId), typeof(QuangCaoInfo));
        }


        /// <summary>
        /// Adds a new QuangCaoInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddQuangCao(QuangCaoInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddQuangCao(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateQuangCao(QuangCaoInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateQuangCao(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteQuangCao(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteQuangCao(moduleId, itemId);
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

            List<QuangCaoInfo> infos = GetQuangCaos(modInfo.ModuleID);

            foreach (QuangCaoInfo info in infos)
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

            List<QuangCaoInfo> infos = GetQuangCaos(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<QuangCaos>");
                foreach (QuangCaoInfo info in infos)
                {
                    sb.Append("<QuangCao>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</QuangCao>");
                }
                sb.Append("</QuangCaos>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "QuangCaos");

            foreach (XmlNode info in infos.SelectNodes("QuangCao"))
            {
                QuangCaoInfo QuangCaoInfo = new QuangCaoInfo();
                QuangCaoInfo.ModuleId = ModuleID;
                QuangCaoInfo.Content = info.SelectSingleNode("content").InnerText;
                QuangCaoInfo.CreatedByUser = UserID;

                AddQuangCao(QuangCaoInfo);
            }
        }

        #endregion
    }
}
