/* Yet Another Forum.net
 * Copyright (C) 2006-2011 Jaben Cargman
 * http://www.yetanotherforum.net/
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 */
namespace YAF.Controls
{
  #region Using

  using System;
  using System.Data;
  using System.Linq;
  using System.Web.UI;

  using YAF.Core; using YAF.Types.Interfaces; using YAF.Types.Constants;
  using YAF.Utils;
  using YAF.Utils.Helpers;
  using YAF.Types;
  using YAF.Types.Interfaces;

  #endregion

  /// <summary>
  /// Control displaying list of user currently active on a forum.
  /// </summary>
  public class ActiveUsers : BaseControl
  {
    // data about active users
    #region Constants and Fields

    /// <summary>
    ///   The _active user table.
    /// </summary>
    private DataTable _activeUserTable;

    #endregion

    #region Properties

    /// <summary>
    ///   Gets or sets list of users to display in control.
    /// </summary>
    [CanBeNull]
    public DataTable ActiveUserTable
    {
      get
      {
        if (this._activeUserTable == null)
        {
          // read there data from viewstate
          if (this.ViewState["ActiveUserTable"] != null)
          {
            // cast it
            this._activeUserTable = this.ViewState["ActiveUserTable"] as DataTable;
          }
        }

        // return datatable
        return this._activeUserTable;
      }

      set
      {
        // save it to viewstate
        this.ViewState["ActiveUserTable"] = value;

        // save it also to local variable to avoid repetitive casting from viewstate in getter
        this._activeUserTable = value;
      }
    }

    /// <summary>
    ///   Gets or sets whether treat displaying of guest users same way as that of hidden users.
    /// </summary>
    public bool TreatGuestAsHidden
    {
      get
      {
        if (this.ViewState["TreatGuestAsHidden"] != null)
        {
          return Convert.ToBoolean(this.ViewState["TreatGuestAsHidden"]);
        }

        return false;
      }

      set
      {
        this.ViewState["TreatGuestAsHidden"] = value;
      }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Raises PreRender event and prepares control for rendering by creating links to active users.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    protected override void OnPreRender([NotNull] EventArgs e)
    {
      // IMPORTANT : call base implementation, raises PreRender event
      base.OnPreRender(e);

      // we shall continue only if there are active user data available
      if (this.ActiveUserTable != null)
      {
        // add style column if there is no such column in the table
        // style column defines how concrete user's link should be styled
        if (!this.ActiveUserTable.Columns.Contains("Style"))
        {
          this.ActiveUserTable.Columns.Add("Style", typeof(string));
          this.ActiveUserTable.AcceptChanges();
        }

        // go through the table and process each row
        foreach (DataRow row in this.ActiveUserTable.Rows)
        {
          UserLink userLink;

          // indicates whether user link should be added or not
          bool addControl = true;
          bool isCrawler = Convert.ToInt32(row["IsCrawler"]) > 0;

          // create new link and set its parameters
          if (isCrawler)
          {
            userLink = new UserLink
              {
                ReplaceName = row["Browser"].ToString(), 
                UserID = Convert.ToInt32(row["UserID"]), 
                Style =
                  this.PageContext.BoardSettings.UseStyledNicks
                    ? this.Get<IStyleTransform>().DecodeStyleByString(row["Style"].ToString(), false)
                    : string.Empty
              };
          }
          else
          {
            userLink = new UserLink
              {
                UserID = Convert.ToInt32(row["UserID"]), 
                Style =
                  this.PageContext.BoardSettings.UseStyledNicks
                    ? this.Get<IStyleTransform>().DecodeStyleByString(row["Style"].ToString(), false)
                    : string.Empty
              };
          }

          
          if (!isCrawler)
          {
              userLink.ID = "UserLink" + userLink.UserID;
          }
          else
          {
            userLink.ID += userLink.ReplaceName;
          }

          // how many users of this type is present (valid for guests, others have it 1)
          int userCount = Convert.ToInt32(row["UserCount"]);

          if (userCount > 1)
          {
            // add postfix if there is more the one user of this name
            userLink.PostfixText = " ({0})".FormatWith(userCount);
          }

          // we might not want to add this user link if user is marked as hidden
          if (Convert.ToBoolean(row["IsHidden"]) || // or if user is guest and guest should be hidden
              (this.TreatGuestAsHidden && Convert.ToBoolean(row["IsGuest"])))
          {
            // hidden user are always visible to admin and himself)
            if (this.PageContext.IsAdmin || userLink.UserID == this.PageContext.PageUserID)
            {
              // show regardless...
              addControl = true;

              // but use css style to distinguish such users
              userLink.CssClass = "active_hidden";

              // and also add postfix
              userLink.PostfixText = " ({0})".FormatWith(this.GetText("HIDDEN"));
            }
            else
            {
              // user is hidden from this user...
              addControl = false;
            }
          }

          // add user link if it's not supressed
          if (addControl)
          {
            // vzrus: if guests or crawlers there can be a control with the same id. 
            var ul = this.FindControlRecursiveAs<UserLink>(userLink.ID);
            if (ul != null)
            {
              this.Controls.Remove(ul);
            }

            this.Controls.Add(userLink);
          }
        }
      }
    }

    /// <summary>
    /// Implements rendering of control to the client through use of <see cref="HtmlTextWriter"/>.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    protected override void Render([NotNull] HtmlTextWriter writer)
    {
      // writes starting tag
      writer.WriteLine(@"<div class=""yafactiveusers"" id=""{0}"">".FormatWith(this.ClientID));

      // indicates whether we are processing first active user
      bool isFirst = true;

      // cycle through active user links contained within this control (see OnPreRender where this links are added)
      foreach (Control control in this.Controls.Cast<Control>().Where(control => control is UserLink && control.Visible)
        )
      {
        // control is visible UserLink
        // if we are rendering other then first UserLink, write down separator first to divide it from previus link
        if (!isFirst)
        {
          writer.WriteLine(", ");
        }
        else
        {
          // we are past first link
          isFirst = false;
        }

        // render UserLink
        control.RenderControl(writer);
      }

      // write ending tag
      writer.WriteLine("</div>");
    }

    #endregion
  }
}