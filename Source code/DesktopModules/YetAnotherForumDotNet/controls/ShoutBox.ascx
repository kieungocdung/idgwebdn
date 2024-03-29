<%@ Control Language="C#" AutoEventWireup="True" Inherits="YAF.Controls.ShoutBox" CodeBehind="ShoutBox.ascx.cs" EnableViewState="false" %>
<%@ Import Namespace="YAF.Utils" %>
<script type="text/javascript">
    var lastMessageId = 0;
    var clearOnEndRequest = false;

    function insertsmiley(code, path) {
        InsertSmileyForShoutBox(code, path);
    }
    function InsertSmileyForShoutBox(code, path) {
        InsertStringAtCurrentCursorPositionOrOverwriteSelectedText(document.getElementById('<%=messageTextBox.ClientID %>'), code)
    }
    function InsertStringAtCurrentCursorPositionOrOverwriteSelectedText(control, insertionText) {
        control.focus();
        if (control.value == '') {
            control.value += insertionText;
        }
        else
            control.value += ' ' + insertionText;
    }
    function openShoutBoxWin() {  
        var hostname = window.location.hostname
        window.open("<%=YafForumInfo.ForumClientFileRoot %>popup.aspx?g=shoutbox", "mywindow", "location=0,status=0,scrollbars=0,resizable=1,width=475,height=300");
        return false;
    }

    function refreshShoutBoxFailed(err)
    {
        jQuery('#shoutBoxChatArea').html("Error refreshing chat: " + err);
    }

    function checkForNewMessages() {
        jQuery.PageMethod('<%= YafForumInfo.ForumClientFileRoot %>YafAjax.asmx', 'RefreshShoutBox', refreshShoutBoxPanel, refreshShoutBoxFailed, 'boardId', <%=this.PageContext.PageBoardID %>);

        setTimeout('checkForNewMessages()', 2000);
    }

    function refreshShoutBoxPanel(success) {
        var messageId = parseInt(success.d);

        if ((messageId == 0 && lastMessageId != 0) || lastMessageId < messageId)
        {
            lastMessageId = messageId;

            // refresh update panel
            jQuery('#<%=this.btnRefresh.ClientID %>').click();
        }
    }   

    jQuery(document).ready(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function() {
            if (clearOnEndRequest)
            {
                jQuery('#<%=this.messageTextBox.ClientID %>').val('');
                clearOnEndRequest = false;
            }
        });
        if (<%=this.shoutBoxPanel.Visible ? "true" : "false" %>)
        {
            setTimeout('checkForNewMessages()', 5000);
        }
    });
</script>
<div id="testing1"></div>
<asp:Panel ID="shoutBoxPanel" DefaultButton="btnButton" runat="server" Visible="false">
<%--    <asp:UpdatePanel ID="shoutBoxUpdatePanel" UpdateMode="conditional" runat="server"
        EnableViewState="false">
        <ContentTemplate>--%>
            <table border="0" class="content" cellspacing="1" cellpadding="0" width="100%">
                <tr>
                    <td class="header1" colspan="2">
                        <YAF:CollapsibleImage ID="CollapsibleImageShoutBox" runat="server" BorderWidth="0"
                            Style="vertical-align: middle" DefaultState="Collapsed" PanelID='ShoutBoxPanel'
                            AttachedControlID="shoutBoxPlaceHolder" OnClick="CollapsibleImageShoutBox_Click" />&nbsp;&nbsp;
                        <YAF:LocalizedLabel ID="LocalizedLabel1" runat="server" LocalizedPage="SHOUTBOX"
                            LocalizedTag="TITLE">
                        </YAF:LocalizedLabel>
                    </td>
                </tr>
                <asp:PlaceHolder ID="shoutBoxPlaceHolder" runat="server">
                    <tr>
                        <td class="header2" colspan="2">
                            <span>
                                <YAF:LocalizedLabel ID="lblMemberchat" runat="server" LocalizedPage="SHOUTBOX" LocalizedTag="HEADING">
                                </YAF:LocalizedLabel>
                            </span>
                        </td>    
                    </tr>
                    <tr>
                        <td class="post" style="padding-left: 5px; margin: 0" colspan="2">
                            <div class="post" id="shoutBoxChatArea" style="overflow-y: scroll; height: 150px; width: 100%; padding: 0;
                                margin: 0">
                                <asp:UpdatePanel ID="shoutBoxChatUpdatePanel" UpdateMode="conditional" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnButton" />
                                        <asp:AsyncPostBackTrigger ControlID="btnClear" />
                                        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Repeater ID="shoutBoxRepeater" runat="server">
                                            <ItemTemplate>
                                                <div style="padding: 0; margin: 0">
                                                    <b>
                                                        <YAF:UserLink ID="UserLink1" runat="server" BlankTarget="true" UserID='<%# Convert.ToInt32(((System.Data.DataRow)Container.DataItem)["UserID"]) %>'
                                                            Style='<%# ((System.Data.DataRow)Container.DataItem)["Style"] %>'>
                                                        </YAF:UserLink>
                                                    </b>(<em><YAF:DisplayDateTime ID="PostedDateTime" runat="server" Format="BothTopic"
                                                        DateTime='<%#((System.Data.DataRow)Container.DataItem)["Date"]%>'>
                                                    </YAF:DisplayDateTime>
                                                    </em>):
                                                    <asp:Label ID="messageLabel" runat="server" Text='<%# ((System.Data.DataRow)Container.DataItem)["Message"] %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                    <asp:PlaceHolder ID="phShoutText" runat="server" Visible="true">
                        <tr id="shoutBoxFooter" runat="server">
                            <td class="footer1" style="padding-left: 5px;">
                                <asp:TextBox ID="messageTextBox" Width="99%" MaxLength="150" Visible="true" runat="server"
                                    AutoCompleteType="Disabled" autocomplete="off" />
                            </td>
                            <td class="footer1" style="text-align: center; white-space: nowrap;">
                                <asp:Button ID="btnButton" OnClick="btnButton_Click" CssClass="pbutton" Text="Submit" OnClientClick="clearOnEndRequest = true;"
                                    Visible="true" runat="server" />
                                <asp:Button ID="btnClear" OnClick="btnClear_Click" CssClass="pbutton" Text="Clear"
                                    Visible="false" runat="server" />
                                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" style="display:none;"/>
                            </td>
                        </tr>
                        <tr>
                            <%--<td colspan="2" class="post" style="overflow-y: scroll; height: 10px; width: 99%; padding: 0px 0px 0px 5px; margin: 0;">--%>
                            <td class="post" style="padding-left: 5px; margin: 0;">
                                <asp:Repeater ID="smiliesRepeater" Visible="<%# PageContext.BoardSettings.ShowShoutboxSmiles %>"
                                    runat="server">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" ImageUrl='<%# YafForumInfo.ForumClientFileRoot + YafBoardFolders.Current.Emoticons + "/" + Eval("Icon") %>'
                                            ToolTip='<%# Eval("Code") %>' OnClientClick='<%# FormatSmiliesOnClickString(Eval("Code").ToString(),Eval("Icon").ToString()) %>'
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td class="post" style="text-align: center;">
                                <asp:PlaceHolder ID="FlyOutHolder" runat="server">
                                    <asp:Button ID="btnFlyOut" OnClientClick="openShoutBoxWin(); return false;" CssClass="pbutton" OnClick="btnRefresh_Click"
                                        Text="FlyOut" runat="server" />
                                </asp:PlaceHolder>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                </asp:PlaceHolder>
            </table>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <br />
</asp:Panel>
