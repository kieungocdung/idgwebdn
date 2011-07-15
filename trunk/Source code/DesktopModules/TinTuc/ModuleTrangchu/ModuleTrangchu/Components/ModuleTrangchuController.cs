using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.ModuleTrangchu.Components
{
    public class ModuleTrangchuController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the ModuleTrangchuInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<ModuleTrangchuInfo> GetModuleTrangchus(int moduleId)
        {
            return CBO.FillCollection<ModuleTrangchuInfo>(DataProvider.Instance().GetModuleTrangchus(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public ModuleTrangchuInfo GetModuleTrangchu(int moduleId, int itemId)
        {
            return (ModuleTrangchuInfo)CBO.FillObject(DataProvider.Instance().GetModuleTrangchu(moduleId, itemId), typeof(ModuleTrangchuInfo));
        }


        /// <summary>
        /// Adds a new ModuleTrangchuInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddModuleTrangchu(ModuleTrangchuInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddModuleTrangchu(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateModuleTrangchu(ModuleTrangchuInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateModuleTrangchu(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteModuleTrangchu(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteModuleTrangchu(moduleId, itemId);
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

            List<ModuleTrangchuInfo> infos = GetModuleTrangchus(modInfo.ModuleID);

            foreach (ModuleTrangchuInfo info in infos)
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

            List<ModuleTrangchuInfo> infos = GetModuleTrangchus(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<ModuleTrangchus>");
                foreach (ModuleTrangchuInfo info in infos)
                {
                    sb.Append("<ModuleTrangchu>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</ModuleTrangchu>");
                }
                sb.Append("</ModuleTrangchus>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "ModuleTrangchus");

            foreach (XmlNode info in infos.SelectNodes("ModuleTrangchu"))
            {
                ModuleTrangchuInfo ModuleTrangchuInfo = new ModuleTrangchuInfo();
                ModuleTrangchuInfo.ModuleId = ModuleID;
                ModuleTrangchuInfo.Content = info.SelectSingleNode("content").InnerText;
                ModuleTrangchuInfo.CreatedByUser = UserID;

                AddModuleTrangchu(ModuleTrangchuInfo);
            }
        }

        #endregion
    }
}
