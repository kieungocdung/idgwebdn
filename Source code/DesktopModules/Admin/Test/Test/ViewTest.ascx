<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewTest.ascx.cs" Inherits="YourCompany.Modules.Test.ViewTest" %>
<asp:datalist id="lstContent" datakeyfield="ItemID" runat="server" cellpadding="4" OnItemDataBound="lstContent_ItemDataBound">
  <itemtemplate>
    <table cellpadding="4" width="100%">
      <tr>
        <td valign="top" width="100%" align="left">
          <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# EditUrl("ItemId",DataBinder.Eval(Container.DataItem,"ItemId").ToString()) %>' Visible="<%# IsEditable %>" runat="server">
            <asp:Image ID="Image1" Runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%#IsEditable%>" resourcekey="Edit"/>
          </asp:HyperLink>
          <asp:Label ID="lblContent" runat="server" CssClass="Normal"/>
        </td>
      </tr>
    </table>
  </itemtemplate>
</asp:datalist>