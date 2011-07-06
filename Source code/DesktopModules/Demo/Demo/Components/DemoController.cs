using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.Demo.Components
{
    public class DemoController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the DemoInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<DemoInfo> GetDemos(int moduleId)
        {
            return CBO.FillCollection<DemoInfo>(DataProvider.Instance().GetDemos(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public DemoInfo GetDemo(int moduleId, int itemId)
        {
            return (DemoInfo)CBO.FillObject(DataProvider.Instance().GetDemo(moduleId, itemId), typeof(DemoInfo));
        }


        /// <summary>
        /// Adds a new DemoInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddDemo(DemoInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddDemo(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateDemo(DemoInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateDemo(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteDemo(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteDemo(moduleId, itemId);
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

            List<DemoInfo> infos = GetDemos(modInfo.ModuleID);

            foreach (DemoInfo info in infos)
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

            List<DemoInfo> infos = GetDemos(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<Demos>");
                foreach (DemoInfo info in infos)
                {
                    sb.Append("<Demo>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</Demo>");
                }
                sb.Append("</Demos>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "Demos");

            foreach (XmlNode info in infos.SelectNodes("Demo"))
            {
                DemoInfo DemoInfo = new DemoInfo();
                DemoInfo.ModuleId = ModuleID;
                DemoInfo.Content = info.SelectSingleNode("content").InnerText;
                DemoInfo.CreatedByUser = UserID;

                AddDemo(DemoInfo);
            }
        }

        #endregion
    }
}
