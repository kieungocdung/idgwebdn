<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON1" Src="~/Admin/Containers/ActionButton.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON2" Src="~/Admin/Containers/ActionButton.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON3" Src="~/Admin/Containers/ActionButton.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON4" Src="~/Admin/Containers/ActionButton.ascx" %>
<link href='<%= SkinPath %>container.css' rel="stylesheet" type="text/css" />
<div class="TUB_c" id="TUBhead">
   <div class="ABvsTitle"><dnn:ACTIONS runat="server" id="dnnACTIONS" ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" /> &nbsp; <dnn:TITLE runat="server" id="dnnTITLE" CssClass="TUB_Ctitle" /></div>
</div>
<div class="TUB_content">
   <div id="ContentPane" runat="server" class="TUB_contentpane">
   </div>
</div>
<div class="TUB_c Cfooter">
   <dnn:ACTIONBUTTON1 runat="server" id="dnnACTIONBUTTON1" CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" />
            <dnn:ACTIONBUTTON2 runat="server" id="dnnACTIONBUTTON2" CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" />
            <dnn:ACTIONBUTTON3 runat="server" id="dnnACTIONBUTTON3" CommandName="PrintModule.Action" DisplayIcon="True" DisplayLink="False" />
            <dnn:ACTIONBUTTON4 runat="server" id="dnnACTIONBUTTON4" CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="False" /> 
</div>
