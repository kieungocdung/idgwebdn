using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.LienKet.Components
{
    public class LienKetController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the LienKetInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<LienKetInfo> GetLienKets(int moduleId)
        {
            return CBO.FillCollection<LienKetInfo>(DataProvider.Instance().GetLienKets(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public LienKetInfo GetLienKet(int moduleId, int itemId)
        {
            return (LienKetInfo)CBO.FillObject(DataProvider.Instance().GetLienKet(moduleId, itemId), typeof(LienKetInfo));
        }


        /// <summary>
        /// Adds a new LienKetInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddLienKet(LienKetInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddLienKet(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateLienKet(LienKetInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateLienKet(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteLienKet(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteLienKet(moduleId, itemId);
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

            List<LienKetInfo> infos = GetLienKets(modInfo.ModuleID);

            foreach (LienKetInfo info in infos)
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

            List<LienKetInfo> infos = GetLienKets(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<LienKets>");
                foreach (LienKetInfo info in infos)
                {
                    sb.Append("<LienKet>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</LienKet>");
                }
                sb.Append("</LienKets>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "LienKets");

            foreach (XmlNode info in infos.SelectNodes("LienKet"))
            {
                LienKetInfo LienKetInfo = new LienKetInfo();
                LienKetInfo.ModuleId = ModuleID;
                LienKetInfo.Content = info.SelectSingleNode("content").InnerText;
                LienKetInfo.CreatedByUser = UserID;

                AddLienKet(LienKetInfo);
            }
        }

        #endregion
    }
}
