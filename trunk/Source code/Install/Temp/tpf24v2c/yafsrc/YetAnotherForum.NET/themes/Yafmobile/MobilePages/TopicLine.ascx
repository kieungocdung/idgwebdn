<%@ Control Language="c#" CodeBehind="../../../controls/TopicLine.ascx.cs" AutoEventWireup="True" Inherits="YAF.Controls.TopicLine" %>
<%@ Import Namespace="YAF.Core.Services" %>
<%@ Import Namespace="YAF.Utils.Helpers" %>
<%@ Import Namespace="YAF.Controls" %>
<%@ Import Namespace="YAF.Core" %>
<%@ Import Namespace="YAF.Types.Interfaces" %>
<%@ Import Namespace="YAF.Utils" %>
<%@ Import Namespace="YAF.Types.Constants" %>
<tr class="<%=this.IsAlt ? "topicRow_Alt post_alt" : "topicRow post" %>">
     <asp:PlaceHolder ID="SelectionHolder" runat="server" Visible="false">
        <td>
            <asp:CheckBox ID="chkSelected" runat="server" />
        </td>
    </asp:PlaceHolder>
    <td class="topicImage">
        <%  string imgTitle = string.Empty;
            string imgSrc = this.GetTopicImage(this.TopicRow, ref imgTitle);
        %>
        <img src="<%=imgSrc%>" alt="<%=imgTitle%>" title="<%=imgTitle%>" />
    </td>
    <td class="topicMain">
        <%
            string priorityMessage = this.GetPriorityMessage(this.TopicRow);
            if (priorityMessage.IsSet())
            {
        %>
        <span class="post_priority">
            <%=priorityMessage %></span>
        <%
            }
            
        %>

        <a href="<%=YafBuildLink.GetLink(ForumPages.posts, "m={0}&find=unread", this.TopicRow["LastMessageID"])%>"
            class="post_link" title="<%=this.Get<IFormatMessage>().GetCleanedTopicMessage(this.TopicRow["FirstMessage"], this.TopicRow["LinkTopicID"]).MessageTruncated%>">
            <%=this.Get<IBadWordReplace>().Replace(Convert.ToString(this.HtmlEncode(this.TopicRow["Subject"]).ToString()))%></a>
        <%
            var favoriteCount = this.Get<IFavoriteTopic>().FavoriteTopicCount((int)this.TopicRow["LinkTopicID"]);
            
            if (favoriteCount > 0)
            {
        %>
        <span class="topicFavoriteCount">[+<%=favoriteCount%>]</span>
        <%
            }
        
      %>            
        <br />
        <span class="topicStarter">
            <%= new UserLink
        {
          ID = "topicStarterLink",
          UserID = this.TopicRow["UserID"].ToType<int>(),
          Style = this.TopicRow["StarterStyle"].ToString()
        }.RenderToString() %>
        </span>
        <%    
            if (this.ShowTopicPosted)
            {
        %>
        <span class="topicPosted">,
            <%= new DisplayDateTime() { Format = DateTimeFormat.BothTopic, DateTime = this.TopicRow["Posted"] }.RenderToString()%>
        </span>            
        <%
            }
    
            int actualPostCount = this.TopicRow["Replies"].ToType<int>() + 1;

            if (this.PageContext.BoardSettings.ShowDeletedMessages)
            {
                // add deleted posts not included in replies...
                actualPostCount += this.TopicRow["NumPostsDeleted"].ToType<int>();
            }     

      string tPager = this.CreatePostPager(
        actualPostCount, this.PageContext.BoardSettings.PostsPerPage, this.TopicRow["LinkTopicID"].ToType<int>());

      if (tPager != String.Empty)
      {
        %>
        <span class="topicPager smallfont">-
            <%=this.GetText("GOTO_POST_PAGER").FormatWith(tPager) %></span>
        <%
      }      
        %>
    </td>
</tr>