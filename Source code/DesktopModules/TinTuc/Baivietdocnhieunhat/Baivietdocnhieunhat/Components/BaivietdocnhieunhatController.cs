using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.Baivietdocnhieunhat.Components
{
    public class BaivietdocnhieunhatController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the BaivietdocnhieunhatInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<BaivietdocnhieunhatInfo> GetBaivietdocnhieunhats(int moduleId)
        {
            return CBO.FillCollection<BaivietdocnhieunhatInfo>(DataProvider.Instance().GetBaivietdocnhieunhats(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public BaivietdocnhieunhatInfo GetBaivietdocnhieunhat(int moduleId, int itemId)
        {
            return (BaivietdocnhieunhatInfo)CBO.FillObject(DataProvider.Instance().GetBaivietdocnhieunhat(moduleId, itemId), typeof(BaivietdocnhieunhatInfo));
        }


        /// <summary>
        /// Adds a new BaivietdocnhieunhatInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddBaivietdocnhieunhat(BaivietdocnhieunhatInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddBaivietdocnhieunhat(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateBaivietdocnhieunhat(BaivietdocnhieunhatInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateBaivietdocnhieunhat(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteBaivietdocnhieunhat(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteBaivietdocnhieunhat(moduleId, itemId);
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

            List<BaivietdocnhieunhatInfo> infos = GetBaivietdocnhieunhats(modInfo.ModuleID);

            foreach (BaivietdocnhieunhatInfo info in infos)
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

            List<BaivietdocnhieunhatInfo> infos = GetBaivietdocnhieunhats(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<Baivietdocnhieunhats>");
                foreach (BaivietdocnhieunhatInfo info in infos)
                {
                    sb.Append("<Baivietdocnhieunhat>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</Baivietdocnhieunhat>");
                }
                sb.Append("</Baivietdocnhieunhats>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "Baivietdocnhieunhats");

            foreach (XmlNode info in infos.SelectNodes("Baivietdocnhieunhat"))
            {
                BaivietdocnhieunhatInfo BaivietdocnhieunhatInfo = new BaivietdocnhieunhatInfo();
                BaivietdocnhieunhatInfo.ModuleId = ModuleID;
                BaivietdocnhieunhatInfo.Content = info.SelectSingleNode("content").InnerText;
                BaivietdocnhieunhatInfo.CreatedByUser = UserID;

                AddBaivietdocnhieunhat(BaivietdocnhieunhatInfo);
            }
        }

        #endregion
    }
}
