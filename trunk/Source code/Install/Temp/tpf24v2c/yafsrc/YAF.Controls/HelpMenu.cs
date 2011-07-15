/* Yet Another Forum.NET
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

  using System.Text;
  using System.Web.UI;

  using YAF.Classes;
  using YAF.Core; using YAF.Types.Interfaces; using YAF.Types.Constants;
  using YAF.Utils;
  using YAF.Types;
  using YAF.Types.Constants;

  #endregion

  /// <summary>
  /// Summary description for HelpMenu.
  /// </summary>
  public class HelpMenu : BasePanel
  {
    #region Methods

    /// <summary>
    /// The render.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    protected override void Render([NotNull] HtmlTextWriter writer)
    {
      var html = new StringBuilder(2000);

      html.Append(@"<table cellspacing=""0"" cellpadding=""0"" class=""content"" id=""yafhelpmenu"">");

      html.Append(
        @"<tr><td class=""header1"">{0}</td></tr>".FormatWith(
          this.GetText("HELP_INDEX", "NAVIGATION")));

      html.Append(
        @"<tr class=""header2""><td>{0}</td></tr>".FormatWith(this.GetText("HELP_INDEX", "INDEX")));

      html.AppendFormat(@"<tr><td class=""post""><ul id=""yafhelpindex"">");

      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=index"), 
        this.GetText("HELP_INDEX", "SEARCHHELP"));

      html.AppendFormat(@"</ul></td></tr>");

      ///////////////
      html.AppendFormat(
        @"<tr class=""header2""><td>{0}</td></tr>", this.GetText("HELP_INDEX", "GENERALTOPICS"));

      html.AppendFormat(@"<tr><td class=""post""><ul id=""yafhelpgeneral"">");

      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=forums"), 
        this.GetText("HELP_INDEX", "FORUMSTITLE"));

      if (!this.PageContext.BoardSettings.DisableRegistrations && !Config.IsAnyPortal)
      {
        html.AppendFormat(
          @"<li><a href=""{0}"">{1}</a></li>", 
          YafBuildLink.GetLink(ForumPages.help_index, "faq=registration"), 
          this.GetText("HELP_INDEX", "REGISTRATIONTITLE"));
      }

      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=searching"), 
        this.GetText("HELP_INDEX", "SEARCHINGTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=anounce"), 
        this.GetText("HELP_INDEX", "ANOUNCETITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=display"), 
        this.GetText("HELP_INDEX", "DISPLAYTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=newposts"), 
        this.GetText("HELP_INDEX", "NEWPOSTSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=threadopt"), 
        this.GetText("HELP_INDEX", "THREADOPTTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=recover"), 
        this.GetText("HELP_INDEX", "RECOVERTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=memberslist"), 
        this.GetText("HELP_INDEX", "MEMBERSLISTTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=popups"), 
        this.GetText("HELP_INDEX", "POPUPSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=pm"), 
        this.GetText("HELP_INDEX", "PMTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=rss"), 
        this.GetText("HELP_INDEX", "RSSTITLE"));

      html.AppendFormat(@"</ul></td></tr>");

      ///////////////
      html.AppendFormat(
        @"<tr class=""header2""><td>{0}</td></tr>", this.GetText("HELP_INDEX", "PROFILETOPICS"));

      html.AppendFormat(@"<tr><td class=""post""><ul id=""yafhelpsettings"">");

      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=mysettings"), 
        this.GetText("HELP_INDEX", "MYSETTINGSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=messenger"), 
        this.GetText("HELP_INDEX", "MESSENGERTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=publicprofile"), 
        this.GetText("HELP_INDEX", "PUBLICPROFILETITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=editprofile"), 
        this.GetText("HELP_INDEX", "EDITPROFILETITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=thanks"), 
        this.GetText("HELP_INDEX", "THANKSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=buddies"), 
        this.GetText("HELP_INDEX", "BUDDIESTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=myalbums"), 
        this.GetText("HELP_INDEX", "MYALBUMSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=mypics"), 
        this.GetText("HELP_INDEX", "MYPICSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=mailsettings"), 
        this.GetText("HELP_INDEX", "MAILSETTINGSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=subscriptions"), 
        this.GetText("HELP_INDEX", "SUBSCRIPTIONSTITLE"));

      html.AppendFormat(@"</ul></td></tr>");

      //////////////
      html.AppendFormat(
        @"<tr class=""header2""><td>{0}</td></tr>", this.GetText("HELP_INDEX", "READPOSTTOPICS"));

      html.AppendFormat(@"<tr><td class=""post""><ul id=""yafhelpreading"">");

      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=posting"), 
        this.GetText("HELP_INDEX", "POSTINGTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=replying"), 
        this.GetText("HELP_INDEX", "REPLYINGTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=editdelete"), 
        this.GetText("HELP_INDEX", "EDITDELETETITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=polls"), 
        this.GetText("HELP_INDEX", "POLLSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=attachments"), 
        this.GetText("HELP_INDEX", "ATTACHMENTSTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=smilies"), 
        this.GetText("HELP_INDEX", "SMILIESTITLE"));
      html.AppendFormat(
        @"<li><a href=""{0}"">{1}</a></li>", 
        YafBuildLink.GetLink(ForumPages.help_index, "faq=modsadmins"), 
        this.GetText("HELP_INDEX", "MODSADMINSTITLE"));

      html.AppendFormat(@"</ul></td></tr>");

      //////////////
      html.AppendFormat(@"</ul></td></tr>");
      html.Append(@"</table>");

      writer.BeginRender();

      // render the contents of the help menu....
      writer.WriteLine(@"<div id=""{0}"">".FormatWith(this.ClientID));
      writer.WriteLine(@"<table class=""adminContainer""><tr>");
      writer.WriteLine(@"<td class=""adminMenu"" valign=""top"">");

      writer.Write(html.ToString());

      writer.WriteLine(@"</td>");

      // contents of the help pages...
      writer.WriteLine(@"<td class=""adminContent"" valign=""top"">");

      this.RenderChildren(writer);

      writer.WriteLine(@"</td></tr></table>");
      writer.WriteLine("</div>");

      writer.EndRender();
    }

    #endregion
  }
}