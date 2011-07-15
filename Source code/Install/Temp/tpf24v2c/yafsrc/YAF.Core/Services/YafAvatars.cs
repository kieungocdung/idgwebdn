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

  using System.Web;

  using YAF.Core; using YAF.Types.Interfaces; using YAF.Types.Constants;
  using YAF.Utils;
  using YAF.Utils.Helpers.StringUtils;
  using YAF.Types;
  using YAF.Types.Interfaces;

  #endregion

  /// <summary>
  /// The yaf avatars.
  /// </summary>
  public class YafAvatars : IAvatars
  {
    #region Public Methods

    /// <summary>
    /// The get avatar url for current user.
    /// </summary>
    /// <returns>
    /// The get avatar url for current user.
    /// </returns>
    public string GetAvatarUrlForCurrentUser()
    {
      return this.GetAvatarUrlForUser(YafContext.Current.CurrentUserData);
    }

    /// <summary>
    /// The get avatar url for user.
    /// </summary>
    /// <param name="userId">
    /// The user id.
    /// </param>
    /// <returns>
    /// The get avatar url for user.
    /// </returns>
    public string GetAvatarUrlForUser(int userId)
    {
      var userData = new CombinedUserDataHelper(userId);

      return this.GetAvatarUrlForUser(userData);
    }

    /// <summary>
    /// The get avatar url for user.
    /// </summary>
    /// <param name="userData">
    /// The user data.
    /// </param>
    /// <returns>
    /// The get avatar url for user.
    /// </returns>
    public string GetAvatarUrlForUser([NotNull] IUserData userData)
    {
      CodeContracts.ArgumentNotNull(userData, "userData");

      string avatarUrl = string.Empty;

      if (YafContext.Current.BoardSettings.AvatarUpload && userData.HasAvatarImage)
      {
        avatarUrl = "{0}resource.ashx?u={1}".FormatWith(YafForumInfo.ForumClientFileRoot, userData.UserID);
      }
      else if (userData.Avatar.IsSet())
      {
        // Took out PageContext.BoardSettings.AvatarRemote
        avatarUrl =
          "{3}resource.ashx?url={0}&width={1}&height={2}".FormatWith(
            HttpContext.Current.Server.UrlEncode(userData.Avatar), 
            YafContext.Current.BoardSettings.AvatarWidth, 
            YafContext.Current.BoardSettings.AvatarHeight, 
            YafForumInfo.ForumClientFileRoot);
      }
      else if (YafContext.Current.BoardSettings.AvatarGravatar && userData.Email.IsSet())
      {
        // JoeOuts added 8/17/09 for Gravatar use

        // string noAvatarGraphicUrl = HttpContext.Current.Server.UrlEncode( string.Format( "{0}/images/avatars/{1}", YafForumInfo.ForumBaseUrl, "NoAvatar.gif" ) );
        string gravatarUrl =
          @"http://www.gravatar.com/avatar/{0}.jpg?r={1}".FormatWith(
            StringExtensions.StringToHexBytes(userData.Email), YafContext.Current.BoardSettings.GravatarRating);

        avatarUrl =
          @"{3}resource.ashx?url={0}&width={1}&height={2}".FormatWith(
            HttpContext.Current.Server.UrlEncode(gravatarUrl), 
            YafContext.Current.BoardSettings.AvatarWidth, 
            YafContext.Current.BoardSettings.AvatarHeight, 
            YafForumInfo.ForumClientFileRoot);
      }

      return avatarUrl;
    }

    #endregion
  }
}