using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using YourCompany.test.Components;

namespace YourCompany.Modules.test
{
    public partial class Viewtest : PortalModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<testInfo> items;
                    testController controller = new testController();

                    items = controller.Gettests(this.ModuleId);

                    //check if we have some content to display, otherwise
                    //display a sample default conent from the resource
                    //settings
                    if (items.Count == 0)
                    {
                        testInfo item = new testInfo();
                        item.ModuleId = this.ModuleId;
                        item.CreatedByUser = this.UserId;
                        item.Content = Localization.GetString("DefaultContent", LocalResourceFile);

                        items.Add(item);
                    }

                    //bind the data
                    lstContent.DataSource = items;
                    lstContent.DataBind();
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #region IActionable Members

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                     true, false);

                return actions;
            }
        }

        #endregion


        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lstContent_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            Label content = (Label)e.Item.FindControl("lblContent");
            string contentValue = string.Empty;

            if (Settings["template"] != null)
            {
                //apply the content to the template
                ArrayList propInfos = CBO.GetPropertyInfo(typeof(testInfo));
                contentValue = Settings["template"].ToString();

                if (contentValue.Length != 0)
                {
                    foreach (PropertyInfo propInfo in propInfos)
                    {
                        object propertyValue = DataBinder.Eval(e.Item.DataItem, propInfo.Name);
                        if (propertyValue != null)
                        {
                            contentValue = contentValue.Replace("[" + propInfo.Name.ToUpper() + "]",
                                            Server.HtmlDecode(propertyValue.ToString()));
                        }
                    }
                }
                else
                    //blank template so just set the content to the value
                    contentValue = Server.HtmlDecode(DataBinder.Eval(e.Item.DataItem, "Content").ToString());
            }
            else
            {
                //no template so just set the content to the value
                contentValue = Server.HtmlDecode(DataBinder.Eval(e.Item.DataItem, "Content").ToString());
            }

            content.Text = contentValue;
        }

    }
}