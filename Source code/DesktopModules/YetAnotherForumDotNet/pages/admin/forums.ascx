<%@ Control Language="c#" AutoEventWireup="True" Inherits="YAF.Pages.Admin.forums" Codebehind="forums.ascx.cs" %>
<%@ Register TagPrefix="YAF" Namespace="YAF.Controls" %>
<YAF:PageLinks runat="server" ID="PageLinks" />
<YAF:AdminMenu runat="server">
	<table class="content" cellspacing="1" cellpadding="0" width="100%">
		<tr>
			<td class="header1" colspan="3">
				<YAF:LocalizedLabel ID="LocalizedLabel1" runat="server" LocalizedTag="FORUMS" LocalizedPage="TEAM" />
			</td>
		</tr>
		<asp:Repeater ID="CategoryList" runat="server">
			<ItemTemplate>
				<tr>
					<td class="header2">
						<%# HtmlEncode(Eval( "Name"))%>
					</td>
					<td class="header2" width="10%" align="center">
						<%# Eval( "SortOrder") %>
					</td>
					<td class="header2" width="15%" style="font-weight: normal">
						<asp:LinkButton runat='server' CommandName='edit' CommandArgument='<%# Eval( "CategoryID") %>'><YAF:LocalizedLabel ID="LocalizedLabel2" runat="server" LocalizedTag="EDIT" /></asp:LinkButton>
						|
						<asp:LinkButton runat='server' OnLoad="DeleteCategory_Load" CommandName='delete'
							CommandArgument='<%# Eval( "CategoryID") %>'><YAF:LocalizedLabel ID="LocalizedLabel3" runat="server" LocalizedTag="DELETE" /></asp:LinkButton>
					</td>
				</tr>
				<asp:Repeater ID="ForumList" OnItemCommand="ForumList_ItemCommand" runat="server"
					DataSource='<%# ((System.Data.DataRowView)Container.DataItem).Row.GetChildRows("FK_Forum_Category") %>'>
					<ItemTemplate>
						<tr class="post">
							<td align="left">
								<strong>
									<%# HtmlEncode(DataBinder.Eval(Container.DataItem, "[\"Name\"]")) %></strong><br />
								<%# HtmlEncode(DataBinder.Eval(Container.DataItem, "[\"Description\"]")) %>
							</td>
							<td align="center">
								<%# DataBinder.Eval(Container.DataItem, "[\"SortOrder\"]") %>
							</td>
							<td>
								<asp:LinkButton ID="btnEdit" runat='server' CommandName='edit' CommandArgument='<%# Eval( "[\"ForumID\"]") %>'><YAF:LocalizedLabel ID="LocalizedLabel4" runat="server" LocalizedTag="EDIT" /></asp:LinkButton>
								|
								<asp:LinkButton ID="btnDuplicate" runat='server' CommandName='copy' CommandArgument='<%# Eval( "[\"ForumID\"]") %>'><YAF:LocalizedLabel ID="LocalizedLabel8" runat="server" LocalizedTag="COPY" /></asp:LinkButton>
								|
								<asp:LinkButton ID="btnDelete" runat='server' OnLoad="DeleteForum_Load" CommandName='delete' CommandArgument='<%# Eval( "[\"ForumID\"]") %>'><YAF:LocalizedLabel ID="LocalizedLabel5" runat="server" LocalizedTag="DELETE" /></asp:LinkButton>
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</ItemTemplate>
		</asp:Repeater>
		<tr>
			<td class="footer1" colspan="3" align="center">
				<asp:Button ID="NewCategory" runat="server" OnClick="NewCategory_Click" CssClass="pbutton"></asp:Button>
				|
				<asp:Button ID="NewForum" runat="server" OnClick="NewForum_Click" CssClass="pbutton"></asp:Button>
			</td>
		</tr>
	</table>
</YAF:AdminMenu>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<asp:Timer ID="UpdateStatusTimer" runat="server" Enabled="false" Interval="4000" OnTick="UpdateStatusTimer_Tick" />
	
	</ContentTemplate>
</asp:UpdatePanel>

<div>
	<div id="DeleteForumMessage" style="display:none" class="ui-overlay">
		<div class="ui-widget ui-widget-content ui-corner-all">
		<h2><YAF:LocalizedLabel ID="LocalizedLabel6" runat="server" LocalizedTag="DELETE_TITLE" LocalizedPage="ADMIN_FORUMS" /></h2>
		<p><YAF:LocalizedLabel ID="LocalizedLabel7" runat="server" LocalizedTag="DELETE_MSG" LocalizedPage="ADMIN_FORUMS" /></p>
		<div align="center">
			<asp:Image ID="LoadingImage" runat="server" alt="Processing..." />
		</div>
		<br />
		</div>
	</div>
</div>

<YAF:SmartScroller ID="SmartScroller1" runat="server" />
