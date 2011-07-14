using System;
using System.Collections.Generic;
using System.Web;

namespace IDG.DNN.AdminTinTuc
{
    public class Constants
    {
        public const string ITEM_DISPLAY_IN_LIST = "ITEM_DISPLAY_IN_LIST";
        public const string AUTO_GET_NEWS = "AUTO_GET_NEWS";
        public const string SUPPORT = "SUPPORT";
        public const string SUPPORT_EN = "SUPPORT_EN";

        public const string FOOTER = "FOOTER";
        public const string FOOTER_EN = "FOOTER_EN";
        #region FOLDER UPLOAD IMAGE

        public const string IMAGE_TINTUC = "/Portals/0/";
        public const string IMAGE_QUANGCAO = "/Images/Upload/QuangCao/";
        public const string IMAGE_DOITAC = "/Images/Upload/DoiTac/";
        public const string IMAGE_SANPHAM = "/Images/Upload/SanPham/";
        public const string IMAGE_USERS = "/Images/Upload/Users/";
        public const string IMAGE_SLIDE = "/Images/Upload/SlideHome/";

        #endregion
        #region FOLDER UPLOAD VIDEO
        public const string VIDEO_HOME = "/Video/";
        #endregion

        #region KEY
        public const string ADMIN_LOGIN = "ADMIN_LOGIN";
        public const string LOGIN_FORUM = "LOGIN_FORUM";
        public const string LANG = "LANG";
        #endregion
    }
    /// <summary>
    /// gán sự kiện lựa chọn trên menu
    /// </summary>
    public class SessionKey
    {
        public const string MENU_ACTIVE = "MENU_ACTIVE";
    }
    public class Menu
    {
        #region Links menu
        public const string LINK1 = "";
        public const string LINK2 = "";
        public const string LINK3 = "";
        public const string LINK4 = "";
        public const string LINK5 = "";
        public const string LINK6 = "";

        #endregion
        #region Name links 
        public const string Ten1 = "";
        public const string Ten2 = "";
        public const string Ten3 = "";
        public const string Ten4 = "";
        public const string Ten5 = "";
        public const string Ten6 = "";
        #endregion
    }
    public static class FormAction
    {
        public const int SEARCH = 0;
        public const int ADD = -1;
        public const int UPDATE = 2;
        public const int DELETE = 3;

    }

    public enum VungQuangCao
    {
        HOME_RIGHT=4,
        NEWS_RIGHT
    }
}