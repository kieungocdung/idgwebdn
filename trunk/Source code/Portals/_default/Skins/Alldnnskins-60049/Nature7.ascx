<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTMENU" Src="~/Admin/Skins/SolPartMenu.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<link href="<%= SkinPath %>Nature7.css" rel="stylesheet" type="text/css" />
<table width="80%" border="0" cellspacing="0" cellpadding="0" height="95%" align="center">
  <tr>
    <td align="left" valign="top" height="108"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" background="<%= SkinPath %>images/7topmiddle.jpg" style="background-repeat:repeat-x; background-position:left top">
      <tr>
        <td width="25" align="left" valign="top"><img src="<%= SkinPath %>images/7topleft.jpg" width="25" height="108"></td>
        <td align="left" valign="middle" style="padding-top:15px; padding-left:10px"><dnn:LOGO runat="server" id="dnnLOGO" /></td>
        <td width="297" align="left" valign="top"><img src="<%= SkinPath %>images/7topright.jpg" width="297" height="108"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="53" align="left" valign="top" background="<%= SkinPath %>images/4melomiddle.jpg" style="background-repeat:repeat-x; background-position:left top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
      <tr>
        <td width="23" align="left" valign="top"><img src="<%= SkinPath %>images/7meloleft.jpg" width="23" height="53"></td>
        <td align="left" valign="top" height="53"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
          <tr>
            <td align="center" valign="middle" height="23"><table width="60%" border="0" cellspacing="0" cellpadding="0" height="23"  background="<%= SkinPath %>images/menumiddle.jpg" style="background-repeat:repeat-x; background-position:left top">
              <tr>
                <td width="11" align="left" valign="top"><img src="<%= SkinPath %>images/menuleft.jpg" width="11" height="23" /></td>
                <td align="left" valign="middle" style="padding-left:10px"><dnn:SOLPARTMENU runat="server" id="dnnSOLPARTMENU" rightseparatoractive="<img src=&quot;images/7menubgright.jpg&quot; >" leftseparatoractive="<img src=&quot;images/7menubgleft.jpg&quot; >" rightseparatorbreadcrumb="<img src=&quot;images/7menubgright.jpg&quot;>" leftseparatorbreadcrumb="<img src=&quot;images/7menubgleft.jpg&quot; >" usearrows="false" userootbreadcrumbarrow="false" rootmenuitemcssclass="MainMenu_TabRootMenuItem" rootmenuitembreadcrumbcssclass="MainMenu_TabRootMenuItemSel" rootmenuitemselectedcssclass="MainMenu_TabMenuItemHover" Rootmenuitemactivecssclass="MainMenu_TabMenuItemSelHover" menuitemselcssclass="MainMenu_MenuItemSel" submenucssclass="submenu" submenuitemselectedcssclass="submenuitemselected" submenuitembreadcrumbcssclass="submenuitembreadcrumb" /></td>
                <td width="12" align="right" valign="top"><img src="<%= SkinPath %>images/menuright.jpg" width="12" height="23" /></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td align="left" valign="top" height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%" style="padding-bottom:9px">
              <tr>
                <td align="left" valign="top" style="padding-left:10px"><dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" cssclass="topcss" Separator="&nbsp;&nbsp;>&nbsp;&nbsp;" RootLevel="0" /></td>
                <td align="right" valign="top" style="padding-right:10px"><dnn:USER runat="server" id="dnnUSER" cssclass="usercss" />&nbsp;&nbsp;<dnn:LOGIN runat="server" id="dnnLOGIN" cssclass="usercss" /></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
        <td width="24" align="left" valign="top"><img src="<%= SkinPath %>images/7meloright.jpg" width="24" height="53"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td align="left" valign="top" height="100%"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
      <tr>
        <td width="16" align="left" valign="top" background="<%= SkinPath %>images/7pleft.jpg" style="background-repeat:repeat-y; background-position:left top"></td>
        <td height="100%" align="left" valign="top" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="3" cellpadding="0" height="100%">
          <tr>
            <td colspan="3" align="left" valign="top" class="toppane" id="TopPane" runat="server"></td>
            </tr>
          <tr>
            <td align="left" valign="top" class="leftpane" id="LeftPane" runat="server"></td>
            <td align="left" valign="top" class="contentpane" id="ContentPane" runat="server" width="100%"></td>
            <td align="left" valign="top" class="rightpane" id="RightPane" runat="server"></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" class="bottompane" id="BottomPane" runat="server"></td>
            </tr>
        </table></td>
        <td width="18" align="right" valign="top" background="<%= SkinPath %>images/7pright.jpg" style="background-repeat:repeat-y; background-position:left top"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="72" align="left" valign="top" background="<%= SkinPath %>images/7bottommiddle.jpg" style="background-repeat:repeat-x; background-position:left top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
      <tr>

        <td width="23" align="left" valign="top"><img src="<%= SkinPath %>images/7bottomleft.jpg" width="23" height="72" /></td>
        <td align="center" valign="middle" style="padding-top:23px; padding-bottom:8px" class="bottomcss"><dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" cssclass="bottomcss" />&nbsp;&nbsp;|&nbsp;&nbsp;<dnn:PRIVACY runat="server" id="dnnPRIVACY" cssclass="bottomcss" />&nbsp;&nbsp;|&nbsp;&nbsp;<dnn:TERMS runat="server" id="dnnTERMS" cssclass="bottomcss" />&nbsp;&nbsp;Skin designed by <a href="http://www.alldnnskins.com" class="bottomcss">Alldnnskins.com</a></td>
        <td width="25" align="right" valign="top"><img src="<%= SkinPath %>images/7bottomright.jpg" width="25" height="72" /></td>
      </tr>
    </table></td>
  </tr>
</table>

