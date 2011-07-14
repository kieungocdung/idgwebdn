<%@ Control Language="c#" AutoEventWireup="True" Inherits="YAF.Pages.team" Codebehind="team.ascx.cs" %>
<%@ Import Namespace="YAF.Types.Constants" %>
<%@ Import Namespace="YAF.Utils" %>
<YAF:PageLinks runat="server" ID="PageLinks" />
<table class="content" width="100%" cellspacing="1" cellpadding="0">
    <tr>
		<td class="header1" colspan="2">
			<YAF:LocalizedLabel ID="LocalizedLabel2" runat="server" LocalizedTag="Admins" LocalizedPage="TEAM" />
		</td>
	</tr>
    <tr>
      <td class="post" style="padding:0;margin:0;">
				<asp:DataGrid ID="AdminsGrid" runat="server"  Width="100%" BorderStyle="None" GridLines="None" BorderWidth="0px" AutoGenerateColumns="False">
    		         <Columns>
             		 	<asp:TemplateColumn HeaderText="User">
			  			    <HeaderStyle HorizontalAlign="Center" CssClass="header2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="post" Width="40px"></ItemStyle>
			  				    <ItemTemplate>
                                    <asp:Image ID="AdminAvatar" runat="server" CssClass="avatarimage" Width="40px" Height="40px" />
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
             		 	<asp:TemplateColumn>
             		 	    <HeaderStyle HorizontalAlign="Center" CssClass="header2"></HeaderStyle>
			  			    <ItemStyle CssClass="post" Width="150px"></ItemStyle>
			  				    <ItemTemplate>
               				        <YAF:UserLink ID="AdminLink" runat="server" UserID='<%# Convert.ToInt32(Eval("UserID")) %>' Style='<%# Eval("Style") %>'  />
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
             		 	<asp:TemplateColumn HeaderText="Forums">
			  			    <HeaderStyle CssClass="header2"></HeaderStyle>
			  			    <ItemStyle CssClass="post" Width="350px"></ItemStyle>
			  				    <ItemTemplate>
               				        <YAF:LocalizedLabel ID="LocalizedLabel3" runat="server" LocalizedTag="FORUMS_ALL" LocalizedPage="TEAM" />
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
                         <asp:TemplateColumn>
			  			    <HeaderStyle CssClass="header2"></HeaderStyle>
			  			    <ItemStyle CssClass="post" HorizontalAlign="Left"></ItemStyle>
			  				    <ItemTemplate>
               				        <YAF:ThemeButton ID="PM" runat="server" CssClass="yafcssimagebutton" Visible="false" TextLocalizedPage="POSTS" TextLocalizedTag="PM" ImageThemeTag="PM" />
			                        <YAF:ThemeButton ID="Email" runat="server" CssClass="yafcssimagebutton" Visible="false" TextLocalizedPage="POSTS" TextLocalizedTag="EMAIL" ImageThemeTag="EMAIL" />
			                        <YAF:ThemeButton ID="AdminUserButton" runat="server" CssClass="yaflittlebutton" Visible="false"
				                     TextLocalizedTag="ADMIN_USER" NavigateUrl='<%# YafBuildLink.GetLinkNotEscaped( ForumPages.admin_edituser,"u={0}", Convert.ToInt32(Eval("UserID")) ) %>'>
			                        </YAF:ThemeButton>
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
    		         </Columns>
			</asp:DataGrid>
		</td>
    </tr>
</table>
<table id="ModsTable" runat="server" class="content" width="100%" cellspacing="1" cellpadding="0">
	<tr>
		<td class="header1" colspan="2">
			<YAF:LocalizedLabel ID="LocalizedLabel1" runat="server" LocalizedTag="MODS" LocalizedPage="TEAM" />
		</td>
	</tr>
    <tr>
      <td class="post" style="padding:0;margin:0;">
				<asp:DataGrid ID="ModeratorsGrid" runat="server"  Width="100%" BorderStyle="None" GridLines="None" BorderWidth="0px" AutoGenerateColumns="False">
    		         <Columns>
             		 	<asp:TemplateColumn HeaderText="User">
			  			    <HeaderStyle HorizontalAlign="Center" CssClass="header2"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="post" Width="40px"></ItemStyle>
			  				    <ItemTemplate>
                                    <asp:Image ID="ModAvatar" runat="server" CssClass="avatarimage" Width="40px" Height="40px" />
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
             		 	<asp:TemplateColumn>
             		 	    <HeaderStyle HorizontalAlign="Center" CssClass="header2"></HeaderStyle>
			  			    <ItemStyle CssClass="post" Width="150px"></ItemStyle>
			  				    <ItemTemplate>
               				        <YAF:UserLink ID="ModLink" runat="server" UserID='<%# Convert.ToInt32(Eval("ModeratorID")) %>' Style='<%# Eval("Style") %>'  />
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
             		 	<asp:TemplateColumn HeaderText="Forums">
			  			    <HeaderStyle CssClass="header2"></HeaderStyle>
			  			    <ItemStyle CssClass="post" Width="350px"></ItemStyle>
			  				    <ItemTemplate>
               				        <asp:DropDownList ID="ModForums" runat="server">
               				        </asp:DropDownList>
                                     <YAF:ThemeButton ID="GoToForumButton" runat="server" CssClass="yaflittlebutton" TextLocalizedTag="GO" OnClick="GoToForum"></YAF:ThemeButton>
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
                        <asp:TemplateColumn>
			  			    <HeaderStyle CssClass="header2"></HeaderStyle>
			  			    <ItemStyle CssClass="post" HorizontalAlign="Left"></ItemStyle>
			  				    <ItemTemplate>
               				        <YAF:ThemeButton ID="PM" runat="server" CssClass="yafcssimagebutton" Visible="false" TextLocalizedPage="POSTS" TextLocalizedTag="PM" ImageThemeTag="PM" />
			                        <YAF:ThemeButton ID="Email" runat="server" CssClass="yafcssimagebutton" Visible="false" TextLocalizedPage="POSTS" TextLocalizedTag="EMAIL" ImageThemeTag="EMAIL" />
			                        <YAF:ThemeButton ID="AdminUserButton" runat="server" CssClass="yaflittlebutton" Visible="false"
				                     TextLocalizedTag="ADMIN_USER" NavigateUrl='<%# YafBuildLink.GetLinkNotEscaped( ForumPages.admin_edituser,"u={0}", Convert.ToInt32(Eval("ModeratorID")) ) %>'>
			                        </YAF:ThemeButton>
			  				    </ItemTemplate>
             		 	</asp:TemplateColumn>
    		         </Columns>
			</asp:DataGrid>
		</td>
    </tr>
</table>
<div id="DivSmartScroller">
	<YAF:SmartScroller ID="SmartScroller1" runat="server" />
</div>
