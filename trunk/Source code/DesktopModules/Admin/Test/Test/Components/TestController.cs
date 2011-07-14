using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace YourCompany.Test.Components
{
    public class TestController : ISearchable, IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the TestInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<TestInfo> GetTests(int moduleId)
        {
            return CBO.FillCollection<TestInfo>(DataProvider.Instance().GetTests(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public TestInfo GetTest(int moduleId, int itemId)
        {
            return (TestInfo)CBO.FillObject(DataProvider.Instance().GetTest(moduleId, itemId), typeof(TestInfo));
        }


        /// <summary>
        /// Adds a new TestInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddTest(TestInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddTest(info.ModuleId, info.Content, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateTest(TestInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdateTest(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteTest(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteTest(moduleId, itemId);
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

            List<TestInfo> infos = GetTests(modInfo.ModuleID);

            foreach (TestInfo info in infos)
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

            List<TestInfo> infos = GetTests(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<Tests>");
                foreach (TestInfo info in infos)
                {
                    sb.Append("<Test>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</Test>");
                }
                sb.Append("</Tests>");
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
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "Tests");

            foreach (XmlNode info in infos.SelectNodes("Test"))
            {
                TestInfo TestInfo = new TestInfo();
                TestInfo.ModuleId = ModuleID;
                TestInfo.Content = info.SelectSingleNode("content").InnerText;
                TestInfo.CreatedByUser = UserID;

                AddTest(TestInfo);
            }
        }

        #endregion
    }
}
