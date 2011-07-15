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
namespace YAF.Core.Services
{
  #region Using

  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;
  using System.Web;
  using System.Web.Caching;

  using YAF.Core;
  using YAF.Types.Flags;
  using YAF.Types.Interfaces; using YAF.Types.Constants;
  using YAF.Classes.Data;
  using YAF.Utils;
  using YAF.Utils.Helpers;
  using YAF.Types;
  using YAF.Types.Constants;
  using YAF.Types.Interfaces;
  using YAF.Types.Objects;

  #endregion

  /// <summary>
  /// Class used for multi-step DB operations so they can be cached, etc.
  /// </summary>
  public class YafDBBroker : IDBBroker, IHaveServiceLocator
  {
    public IServiceLocator ServiceLocator { get; set; }

    public HttpSessionStateBase HttpSessionState { get; set; }

    public IDataCache DataCache { get; set; }

    public YafDBBroker(IServiceLocator serviceLocator, HttpSessionStateBase httpSessionState, IDataCache dataCache)
    {
      ServiceLocator = serviceLocator;
      HttpSessionState = httpSessionState;
      DataCache = dataCache;
    }

    #region Public Methods

    /// <summary>
    /// The get custom bb code.
    /// </summary>
    /// <returns>
    /// </returns>
    public IEnumerable<TypedBBCode> GetCustomBBCode()
    {
      return this.DataCache.GetOrSet(
        Constants.Cache.CustomBBCode, () => LegacyDb.BBCodeList(YafContext.Current.PageBoardID, null).ToList());
    }

    public IEnumerable<DataRow> GetShoutBoxMessages(int boardId)
    {
      return this.DataCache.GetOrSet(Constants.Cache.Shoutbox,() =>
        {
          var messages = LegacyDb.shoutbox_getmessages(
            boardId,
            YafContext.Current.BoardSettings.ShoutboxShowMessageCount,
            YafContext.Current.BoardSettings.UseStyledNicks);

          // Set colorOnly parameter to false, as we get all color info from data base
          if (YafContext.Current.BoardSettings.UseStyledNicks)
          {
            this.Get<IStyleTransform>().DecodeStyleByTable(ref messages, false);
          }

          var flags = new MessageFlags { IsBBCode = true, IsHtml = false };

          foreach (var row in messages.AsEnumerable())
          {
            string formattedMessage = this.Get<IFormatMessage>().FormatMessage(row.Field<string>("Message"), flags);

            // Extra Formating not needed already done tru this.Get<IFormatMessage>().FormatMessage
            // formattedMessage = FormatHyperLink(formattedMessage);
            row["Message"] = formattedMessage;
          }

          return messages;
        }, TimeSpan.FromMilliseconds((double)30000)).AsEnumerable();
    }

    /// <summary>
    /// The user lazy data.
    /// </summary>
    /// <param name="userId">
    /// The user ID.
    /// </param>
    /// <returns>
    /// </returns>
    public DataRow ActiveUserLazyData(int userId)
    {
      // get a row with user lazy data...
      return
        this.DataCache.GetOrSet(
          Constants.Cache.ActiveUserLazyData.FormatWith(userId),
          () =>
          LegacyDb.user_lazydata(
            userId,
            YafContext.Current.PageBoardID,
            YafContext.Current.BoardSettings.AllowEmailSending,
            YafContext.Current.BoardSettings.EnableBuddyList,
            YafContext.Current.BoardSettings.AllowPrivateMessages,
            YafContext.Current.BoardSettings.EnableAlbum,
            YafContext.Current.BoardSettings.UseStyledNicks).Table,
          TimeSpan.FromMinutes(YafContext.Current.BoardSettings.ActiveUserLazyDataCacheTimeout)).Rows[0];
    }

    /// <summary>
    /// Adds the Thanks info to a dataTable
    /// </summary>
    /// <param name="dataRows">
    /// </param>
    public void AddThanksInfo(IEnumerable<DataRow> dataRows)
    {
      var messageIds = dataRows.Select(x => x.Field<int>("MessageID"));

      // Initialize the "IsthankedByUser" column.
      dataRows.ForEach(x => x["IsThankedByUser"] = false);

      // Initialize the "Thank Info" column.
      dataRows.ForEach(x => x["ThanksInfo"] = String.Empty);

      // Iterate through all the thanks relating to this topic and make appropriate
      // changes in columns.
      var allThanks = LegacyDb.MessageGetAllThanks(StringExtensions.ToDelimitedString(messageIds, ","));

      foreach (var f in
          allThanks.Where(t => t.FromUserID != null && t.FromUserID == YafContext.Current.PageUserID).SelectMany(thanks => dataRows.Where(x => x.Field<int>("MessageID") == thanks.MessageID)))
      {
          f["IsThankedByUser"] = "true";
          f.AcceptChanges();
      }

      var thanksFieldNames = new[] { "ThanksFromUserNumber", "ThanksToUserNumber", "ThanksToUserPostsNumber" };

      foreach (DataRow postRow in dataRows)
      {
        var messageId = postRow.Field<int>("MessageID");

        postRow["MessageThanksNumber"] = allThanks.Where(t => t.FromUserID != null && t.MessageID == messageId).Count();

        var thanksFiltered = allThanks.Where(t => t.MessageID == messageId);

        if (thanksFiltered.Any())
        {
          var thanksItem = thanksFiltered.First();

          postRow["ThanksFromUserNumber"] = thanksItem.ThanksFromUserNumber ?? 0;
          postRow["ThanksToUserNumber"] = thanksItem.ThanksToUserNumber ?? 0;
          postRow["ThanksToUserPostsNumber"] = thanksItem.ThanksToUserPostsNumber ?? 0;
        }
        else
        {
            DataRow row = postRow;
            thanksFieldNames.ForEach(f => row[f] = 0);
        }

          // load all all thanks info into a special column...
        postRow["ThanksInfo"] =
          StringExtensions.ToDelimitedString<string>(thanksFiltered.Where(t => t.FromUserID != null).Select(
              x => "{0}|{1}".FormatWith(x.FromUserID.Value, x.ThanksDate)), ",");

        postRow.AcceptChanges();
      }
    }

    /// <summary>
    /// The get smilies.
    /// </summary>
    /// <returns>
    /// Table with list of smiles
    /// </returns>
    public IEnumerable<TypedSmileyList> GetSmilies()
    {
      return this.DataCache.GetOrSet(
        Constants.Cache.Smilies,
        () => LegacyDb.SmileyList(YafContext.Current.PageBoardID, null).ToList(),
        TimeSpan.FromMinutes(60));
    }

    /// <summary>
    /// Returns the layout of the board
    /// </summary>
    /// <param name="boardID">
    /// BoardID
    /// </param>
    /// <param name="userID">
    /// UserID
    /// </param>
    /// <param name="categoryID">
    /// CategoryID
    /// </param>
    /// <param name="parentID">
    /// ParentID
    /// </param>
    /// <returns>
    /// Returns board layout
    /// </returns>
    public DataSet BoardLayout(int boardID, int userID, int? categoryID, int? parentID)
    {
      if (categoryID.HasValue && categoryID == 0)
      {
        categoryID = null;
      }

      using (var ds = new DataSet())
      {
        // get the cached version of forum moderators if it's valid
        var moderator = this.DataCache.GetOrSet(
          Constants.Cache.ForumModerators,
          this.GetModerators,
          TimeSpan.FromMinutes(YafContext.Current.BoardSettings.BoardModeratorsCacheTimeout));

        // insert it into this DataSet
        ds.Tables.Add(moderator.Copy());

        // get the Category Table
        DataTable category = this.DataCache.GetOrSet(
          Constants.Cache.ForumCategory,
          () =>
            {
              var catDt = LegacyDb.category_list(boardID, null);
              catDt.TableName = MsSqlDbAccess.GetObjectName("Category");
              return catDt;
            },
          TimeSpan.FromMinutes(YafContext.Current.BoardSettings.BoardCategoriesCacheTimeout));

        // add it to this dataset				
        ds.Tables.Add(category.Copy());

        DataTable categoryTable = ds.Tables[MsSqlDbAccess.GetObjectName("Category")];

        if (categoryID.HasValue)
        {
          // make sure this only has the category desired in the dataset
          foreach (DataRow row in
            categoryTable.AsEnumerable().Where(row => row.Field<int>("CategoryID") != categoryID))
          {
            // delete it...
            row.Delete();
          }

          categoryTable.AcceptChanges();
        }

        DataTable forum = LegacyDb.forum_listread(boardID, userID, categoryID, parentID, YafContext.Current.BoardSettings.UseStyledNicks);
        forum.TableName = MsSqlDbAccess.GetObjectName("Forum");
        ds.Tables.Add(forum.Copy());

        ds.Relations.Add(
          "FK_Forum_Category", 
          categoryTable.Columns["CategoryID"], 
          ds.Tables[MsSqlDbAccess.GetObjectName("Forum")].Columns["CategoryID"], 
          false);
        ds.Relations.Add(
          "FK_Moderator_Forum", 
          ds.Tables[MsSqlDbAccess.GetObjectName("Forum")].Columns["ForumID"], 
          ds.Tables[MsSqlDbAccess.GetObjectName("Moderator")].Columns["ForumID"], 
          false);

        bool deletedCategory = false;

        // remove empty categories...
        foreach (DataRow row in
          categoryTable.SelectTypedList(
            row => new { row, childRows = row.GetChildRows("FK_Forum_Category") }).Where(@t => !@t.childRows.Any())
            .Select(@t => @t.row))
        {
          // remove this category...
          row.Delete();
          deletedCategory = true;
        }

        if (deletedCategory)
        {
          categoryTable.AcceptChanges();
        }

        return ds;
      }
    }

    /// <summary>
    /// The favorite topic list.
    /// </summary>
    /// <param name="userID">
    /// The user ID.
    /// </param>
    /// <returns>
    /// </returns>
    public List<int> FavoriteTopicList(int userID)
    {
      string key = this.Get<ITreatCacheKey>().Treat(Constants.Cache.FavoriteTopicList.FormatWith(userID));

      // stored in the user session...
      var favoriteTopicList = this.HttpSessionState[key] as List<int>;

      // was it in the cache?
      if (favoriteTopicList == null)
      {
        // get fresh values
        DataTable favoriteTopicListDt = LegacyDb.topic_favorite_list(userID);

        // convert to list...
        favoriteTopicList = favoriteTopicListDt.GetColumnAsList<int>("TopicID");

        // store it in the user session...
        this.HttpSessionState.Add(key, favoriteTopicList);
      }

      return favoriteTopicList;
    }


    /// <summary>
    /// The get active list.
    /// </summary>
    /// <param name="guests">
    /// The guests.
    /// </param>
    /// <param name="bots">
    /// The bots.
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable GetActiveList(bool guests, bool crawlers)
    {
        return this.GetActiveList(YafContext.Current.BoardSettings.ActiveListTime, guests, crawlers);
    }

    /// <summary>
    /// The get active list.
    /// </summary>
    /// <param name="activeTime">
    /// The active time.
    /// </param>
    /// <param name="guests">
    /// The guests.
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable GetActiveList(int activeTime, bool guests, bool crawlers)
    {
      return
        this.StyleTransformDataTable(
          LegacyDb.active_list(
            YafContext.Current.PageBoardID, guests, crawlers, activeTime, YafContext.Current.BoardSettings.UseStyledNicks));
    }

    /// <summary>
    /// The get all moderators.
    /// </summary>
    /// <returns>
    /// </returns>
    public List<SimpleModerator> GetAllModerators()
    {
      // get the cached version of forum moderators if it's valid

      var moderator = this.DataCache.GetOrSet(
        Constants.Cache.ForumModerators,
        this.GetModerators,
        TimeSpan.FromMinutes(YafContext.Current.BoardSettings.BoardModeratorsCacheTimeout));

      if (YafContext.Current.BoardSettings.UseStyledNicks)
      {
          this.Get<IStyleTransform>().DecodeStyleByTable(ref moderator, false);
      }
      return
        moderator.SelectTypedList(
          row =>
          new SimpleModerator(
            row.Field<int>("ForumID"),
            row.Field<int>("ModeratorID"),
            row.Field<string>("ModeratorName"),
            row.Field<string>("Style"),
            SqlDataLayerConverter.VerifyBool(row["IsGroup"]))).ToList();
    }

    /// <summary>
    /// Get a simple forum/topic listing.
    /// </summary>
    /// <param name="boardId">
    /// The board Id.
    /// </param>
    /// <param name="userId">
    /// The user Id.
    /// </param>
    /// <returns>
    /// </returns>
    public List<SimpleForum> GetSimpleForumTopic(int boardId, int userId, DateTime timeFrame, int maxCount)
    {
      var forumData =
        LegacyDb.forum_listall(boardId, userId).SelectTypedList(x => new SimpleForum() { ForumID = x.Field<int>("ForumID"), Name = x.Field<string>("Forum") }).ToList();

      // get topics for all forums...
      foreach (var forum in forumData)
      {
        // add topics
        var topics =
          LegacyDb.topic_list(forum.ForumID, userId, -1, timeFrame, 0, maxCount, false, false).SelectTypedList(
            x => this.LoadSimpleTopic(x, forum)).Where(x => x.LastPostDate >= timeFrame).ToList();

        forum.Topics = topics;
      }

      return forumData;
    }

    /// <summary>
    /// </summary>
    /// Creates a Simple Topic item.
    /// <param name="row">
    /// The row.
    /// </param>
    /// <param name="forum">
    /// The forum.
    /// </param>
    /// <returns>
    /// </returns>
    [NotNull]
    private SimpleTopic LoadSimpleTopic([NotNull] DataRow row, [NotNull] SimpleForum forum)
    {
      CodeContracts.ArgumentNotNull(row, "row");
      CodeContracts.ArgumentNotNull(forum, "forum");

      return new SimpleTopic()
        {
          TopicID = row.Field<int>("TopicID"),
          CreatedDate = row.Field<DateTime>("Posted"),
          Subject = row.Field<string>("Subject"),
          StartedUserID = row.Field<int>("UserID"),
          StartedUserName = UserMembershipHelper.GetDisplayNameFromID(row.Field<int>("UserID")),
          Replies = row.Field<int>("Replies"),
          LastPostDate = row.Field<DateTime>("LastPosted"),
          LastUserID = row.Field<int>("LastUserID"),
          LastUserName = UserMembershipHelper.GetDisplayNameFromID(row.Field<int>("LastUserID")),
          LastMessageID = row.Field<int>("LastMessageID"),
          FirstMessage = row.Field<string>("FirstMessage"),
          LastMessage = LegacyDb.MessageList(row.Field<int>("LastMessageID")).First().Message,
          Forum = forum
        };
    }

    /// <summary>
    /// The get latest topics.
    /// </summary>
    /// <param name="numberOfPosts">
    /// The number of posts.
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable GetLatestTopics(int numberOfPosts)
    {
      return this.GetLatestTopics(numberOfPosts, YafContext.Current.PageUserID);
    }

    /// <summary>
    /// The get latest topics.
    /// </summary>
    /// <param name="numberOfPosts">
    /// The number of posts.
    /// </param>
    /// <param name="userId">
    /// The user id.
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable GetLatestTopics(int numberOfPosts, int userId)
    {
      return this.GetLatestTopics(numberOfPosts, userId, "Style");
    }

    /// <summary>
    /// The get latest topics.
    /// </summary>
    /// <param name="numberOfPosts">
    /// The number of posts.
    /// </param>
    /// <param name="userId">
    /// The user id.
    /// </param>
    /// <param name="styleColumnNames">
    /// The style Column Names.
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable GetLatestTopics(int numberOfPosts, int userId, params string[] styleColumnNames)
    {
      return
        this.StyleTransformDataTable(
          LegacyDb.topic_latest(
            YafContext.Current.PageBoardID, 
            numberOfPosts, 
            userId, 
            YafContext.Current.BoardSettings.UseStyledNicks, 
            YafContext.Current.BoardSettings.NoCountForumsInActiveDiscussions), 
          styleColumnNames);
    }

    /// <summary>
    /// The get moderators.
    /// </summary>
    /// <returns>
    /// </returns>
    public DataTable GetModerators()
    {
        DataTable moderator = LegacyDb.forum_moderators(YafContext.Current.BoardSettings.UseStyledNicks);
      moderator.TableName = MsSqlDbAccess.GetObjectName("Moderator");

      return moderator;
    }

    /// <summary>
    /// Loads the message text into the paged data if "Message" and "MessageID" exists.
    /// </summary>
    /// <param name="dataRows">
    /// </param>
    public void LoadMessageText(IEnumerable<DataRow> dataRows)
    {
      var messageIds =
        dataRows.AsEnumerable().Where(x => x.Field<string>("Message").IsNotSet()).Select(x => x.Field<int>("MessageID"));

      var messageTextTable = LegacyDb.message_GetTextByIds(messageIds.ToDelimitedString(","));

      if (messageTextTable == null)
      {
        return;
      }

      // load them into the page data...
      foreach (var dataRow in dataRows)
      {
        // find the message id in the results...
        var message =
          messageTextTable.AsEnumerable().Where(x => x.Field<int>("MessageID") == dataRow.Field<int>("MessageID")).
            FirstOrDefault();

        if (message != null)
        {
          dataRow.BeginEdit();
          dataRow["Message"] = message.Field<string>("Message");
          dataRow.EndEdit();
        }
      }
    }

    /// <summary>
    /// The style transform func wrap.
    /// </summary>
    /// <param name="dt">
    /// The DateTable
    /// </param>
    /// <returns>
    /// The style transform wrap.
    /// </returns>
    public DataTable StyleTransformDataTable(DataTable dt)
    {
      if (YafContext.Current.BoardSettings.UseStyledNicks)
      {
        var styleTransform = this.Get<IStyleTransform>();
        styleTransform.DecodeStyleByTable(ref dt, true);
      }

      return dt;
    }

    /// <summary>
    /// The style transform func wrap.
    /// </summary>
    /// <param name="dt">
    /// The DateTable
    /// </param>
    /// <param name="styleColumns">
    /// Style columns names
    /// </param>
    /// <returns>
    /// The style transform wrap.
    /// </returns>
    public DataTable StyleTransformDataTable(DataTable dt, params string[] styleColumns)
    {
      if (YafContext.Current.BoardSettings.UseStyledNicks)
      {
        var styleTransform = this.Get<IStyleTransform>();
        styleTransform.DecodeStyleByTable(ref dt, true, styleColumns);
      }

      return dt;
    }

    /// <summary>
    /// The Buddy list for the user with the specified UserID.
    /// </summary>
    /// <param name="UserID">
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable UserBuddyList(int UserID)
    {
      return this.DataCache.GetOrSet(
        Constants.Cache.UserBuddies.FormatWith(UserID), () => LegacyDb.buddy_list(UserID), TimeSpan.FromMinutes(10));
    }

    /// <summary>
    /// The user ignored list.
    /// </summary>
    /// <param name="userId">
    /// The user id.
    /// </param>
    /// <returns>
    /// </returns>
    public List<int> UserIgnoredList(int userId)
    {
      string key = Constants.Cache.UserIgnoreList.FormatWith(userId);

      // stored in the user session...
      var userList = this.HttpSessionState[key] as List<int>;

      // was it in the cache?
      if (userList == null)
      {
        // get fresh values
        DataTable userListDt = LegacyDb.user_ignoredlist(userId);

        // convert to list...
        userList = userListDt.GetColumnAsList<int>("IgnoredUserID");

        // store it in the user session...
        this.HttpSessionState.Add(key, userList);
      }

      return userList;
    }

    /// <summary>
    /// The user medals.
    /// </summary>
    /// <param name="userId">
    /// The user id.
    /// </param>
    /// <returns>
    /// </returns>
    public DataTable UserMedals(int userId)
    {
      string key = Constants.Cache.UserMedals.FormatWith(userId);

      // get the medals cached...
      DataTable dt = this.DataCache.GetOrSet(
        key, () => LegacyDb.user_listmedals(userId), TimeSpan.FromMinutes(10));

      return dt;
    }

    #endregion
  }
}