using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.test.Components
{
    public class testController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the testInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<testInfo> Gettests(int moduleId)
        {
            return CBO.FillCollection<testInfo>(DataProvider.Instance().Gettests(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public testInfo Gettest(int moduleId, int itemId)
        {
            return (testInfo)CBO.FillObject(DataProvider.Instance().Gettest(moduleId, itemId), typeof(testInfo));
        }


        /// <summary>
        /// Adds a new testInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void Addtest(testInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().Addtest(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void Updatetest(testInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().Updatetest(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void Deletetest(int moduleId, int itemId)
        {
            DataProvider.Instance().Deletetest(moduleId, itemId);
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

            List<testInfo> infos = Gettests(modInfo.ModuleID);

            foreach (testInfo info in infos)
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

            List<testInfo> infos = Gettests(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<tests>");
                foreach (testInfo info in infos)
                {
                    sb.Append("<test>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</test>");
                }
                sb.Append("</tests>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "tests");

            foreach (XmlNode info in infos.SelectNodes("test"))
            {
                testInfo testInfo = new testInfo();
                testInfo.ModuleId = ModuleID;
                testInfo.Content = info.SelectSingleNode("content").InnerText;
                testInfo.CreatedByUser = UserID;

                Addtest(testInfo);
            }
        }

        #endregion
    }
}
