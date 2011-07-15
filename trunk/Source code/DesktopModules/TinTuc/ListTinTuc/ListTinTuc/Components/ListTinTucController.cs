using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.ListTinTuc.Components
{
    public class ListTinTucController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the ListTinTucInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<ListTinTucInfo> GetListTinTucs(int moduleId)
        {
            return CBO.FillCollection<ListTinTucInfo>(DataProvider.Instance().GetListTinTucs(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public ListTinTucInfo GetListTinTuc(int moduleId, int itemId)
        {
            return (ListTinTucInfo)CBO.FillObject(DataProvider.Instance().GetListTinTuc(moduleId, itemId), typeof(ListTinTucInfo));
        }


        /// <summary>
        /// Adds a new ListTinTucInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddListTinTuc(ListTinTucInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddListTinTuc(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateListTinTuc(ListTinTucInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateListTinTuc(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteListTinTuc(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteListTinTuc(moduleId, itemId);
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

            List<ListTinTucInfo> infos = GetListTinTucs(modInfo.ModuleID);

            foreach (ListTinTucInfo info in infos)
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

            List<ListTinTucInfo> infos = GetListTinTucs(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<ListTinTucs>");
                foreach (ListTinTucInfo info in infos)
                {
                    sb.Append("<ListTinTuc>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</ListTinTuc>");
                }
                sb.Append("</ListTinTucs>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "ListTinTucs");

            foreach (XmlNode info in infos.SelectNodes("ListTinTuc"))
            {
                ListTinTucInfo ListTinTucInfo = new ListTinTucInfo();
                ListTinTucInfo.ModuleId = ModuleID;
                ListTinTucInfo.Content = info.SelectSingleNode("content").InnerText;
                ListTinTucInfo.CreatedByUser = UserID;

                AddListTinTuc(ListTinTucInfo);
            }
        }

        #endregion
    }
}
