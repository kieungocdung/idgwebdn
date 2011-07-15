using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.Haynhat.Components
{
    public class HaynhatController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the HaynhatInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<HaynhatInfo> GetHaynhats(int moduleId)
        {
            return CBO.FillCollection<HaynhatInfo>(DataProvider.Instance().GetHaynhats(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public HaynhatInfo GetHaynhat(int moduleId, int itemId)
        {
            return (HaynhatInfo)CBO.FillObject(DataProvider.Instance().GetHaynhat(moduleId, itemId), typeof(HaynhatInfo));
        }


        /// <summary>
        /// Adds a new HaynhatInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddHaynhat(HaynhatInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddHaynhat(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateHaynhat(HaynhatInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateHaynhat(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteHaynhat(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteHaynhat(moduleId, itemId);
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

            List<HaynhatInfo> infos = GetHaynhats(modInfo.ModuleID);

            foreach (HaynhatInfo info in infos)
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

            List<HaynhatInfo> infos = GetHaynhats(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<Haynhats>");
                foreach (HaynhatInfo info in infos)
                {
                    sb.Append("<Haynhat>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</Haynhat>");
                }
                sb.Append("</Haynhats>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "Haynhats");

            foreach (XmlNode info in infos.SelectNodes("Haynhat"))
            {
                HaynhatInfo HaynhatInfo = new HaynhatInfo();
                HaynhatInfo.ModuleId = ModuleID;
                HaynhatInfo.Content = info.SelectSingleNode("content").InnerText;
                HaynhatInfo.CreatedByUser = UserID;

                AddHaynhat(HaynhatInfo);
            }
        }

        #endregion
    }
}
