using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.NoiDung.Components
{
    public class NoiDungController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the NoiDungInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<NoiDungInfo> GetNoiDungs(int moduleId)
        {
            return CBO.FillCollection<NoiDungInfo>(DataProvider.Instance().GetNoiDungs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public NoiDungInfo GetNoiDung(int moduleId, int itemId)
        {
            return (NoiDungInfo)CBO.FillObject(DataProvider.Instance().GetNoiDung(moduleId, itemId), typeof(NoiDungInfo));
        }


        /// <summary>
        /// Adds a new NoiDungInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddNoiDung(NoiDungInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddNoiDung(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateNoiDung(NoiDungInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateNoiDung(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteNoiDung(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteNoiDung(moduleId, itemId);
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

            List<NoiDungInfo> infos = GetNoiDungs(modInfo.ModuleID);

            foreach (NoiDungInfo info in infos)
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

            List<NoiDungInfo> infos = GetNoiDungs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<NoiDungs>");
                foreach (NoiDungInfo info in infos)
                {
                    sb.Append("<NoiDung>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</NoiDung>");
                }
                sb.Append("</NoiDungs>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "NoiDungs");

            foreach (XmlNode info in infos.SelectNodes("NoiDung"))
            {
                NoiDungInfo NoiDungInfo = new NoiDungInfo();
                NoiDungInfo.ModuleId = ModuleID;
                NoiDungInfo.Content = info.SelectSingleNode("content").InnerText;
                NoiDungInfo.CreatedByUser = UserID;

                AddNoiDung(NoiDungInfo);
            }
        }

        #endregion
    }
}
