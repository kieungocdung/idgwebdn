<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BANNER" Src="~/Admin/Skins/Banner.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="NAV" Src="~/Admin/Skins/Nav.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTMENU" Src="~/Admin/Skins/SolPartMenu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.Skins" Assembly="DotNetNuke" %><head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href='<%= SkinPath %>TUBApp.css' rel="stylesheet" type="text/css" />
</head>
<table width="100%" cellpadding="0" cellspacing="0" align="center" height="155px" id="banner">
     <tr>
        <td background="<%= SkinPath %>imgs/bg_banner-outside-L.jpg">&nbsp;</td>
        <td width="1000px" background="<%= SkinPath %>imgs/bannerTUB.jpg" valign="top"><div style=" width:70%; float:right; text-align:right;"><dnn:LOGIN runat="server" id="dnnLOGIN" cssclass="login"/><font color=#FFFFFF> | </font><dnn:USER runat="server" id="dnnUSER" cssclass="login" /></div></td>
        <td background="<%= SkinPath %>imgs/bg_banner-outside-R.jpg">&nbsp;</td>
     </tr>
  </table>
<table width="100%" cellpadding="0" cellspacing="0" align="center" id="menu" background="<%= SkinPath %>imgs/menu_bg.jpg" height="28px">
       <tr>
          <td>&nbsp;</td>
          <td width="1000px"><dnn:SOLPARTMENU runat="server" leftseparatoractive ="<img src=&quot;imgs/menu_selected_l.png&quot;>" rightseparatoractive="<img src=&quot;imgs/menu_selected_r.png&quot;>" leftseparatorbreadcrumb="<img src=&quot;imgs/menu_selected_l.png&quot;>" rightseparatorbreadcrumb="<img src=&quot;imgs/menu_selected_r.png&quot;>" id="dnnSOLPARTMENU" usearrows="false" userootbreadcrumbarrow="false" rootmenuitemcssclass="MainMenu_TabRootMenuItem" rootmenuitembreadcrumbcssclass="MainMenu_TabRootMenuItemSel" rootmenuitemselectedcssclass="MainMenu_TabMenuItemHover" Rootmenuitemactivecssclass="MainMenu_TabMenuItemSelHover" menuitemselcssclass="MainMenu_MenuItemSel" submenucssclass="submenu" submenuitemselectedcssclass="submenuitemselected" submenuitembreadcrumbcssclass="submenuitembreadcrumb" /></td>
          <td>&nbsp;</td>
       </tr>
  </table>
   <table width="100%" cellpadding="0" cellspacing="0" align="center" class="wrap">
   
       <tr>
          <td>&nbsp;</td>
           <td width="1000px" class="panelBackground">
              <table cellpadding="0" cellspacing="0" width="100%">
                 <tr>
                    <td colspan="3" id="ContentPane" runat="server"></td>
                 </tr>
                 <tr>
                    <td id="leftpane" runat="server"></td>
                    <td id="centerpane" runat="server"></td>
                    <td id="rightpane" runat="server"></td>
                 </tr>
                 <tr>
                    <td colspan="3" id="BottomPane" runat="server"></td>
                 </tr>
              </table>
           </td>
          <td>&nbsp;</td>
       </tr>
  </table>
 <table cellpadding="0" cellspacing="0" width="100%" background="<%= SkinPath %>imgs/footerTUB.jpg">
      <tr>
        <td valign="top">
           <table width="1000px" cellpadding="0" cellspacing="0" align="center">
              <tr>
                 <td style="padding-left:20px;;" width="72px" valign="top"><img src="<%= SkinPath %>imgs/TUBlogo.jpg" width="72" height="114" /></td>
                 <td style="padding-left:15px; padding-top:10px;" class="footer">
                    <div align="left"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="chantrang" /><br />
                    Địa chỉ: phường Trưng Vương - thị xã Uông Bí - tỉnh Quảng Ninh<br />
                    Điện thoại: 0333.854.491 - Fax: 0333.854.115 - Email: ctythanub@vnn.vn - Website: http://www.thanuongbi.vn<br />
                    Thiết kế và phát triển bởi công ty VDC<br />
          </div>
                 </td>
              </tr>
           </table>
        </td>
      </tr>
   </table>
