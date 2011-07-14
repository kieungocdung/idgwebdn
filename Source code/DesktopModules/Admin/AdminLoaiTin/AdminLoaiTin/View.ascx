<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="IDG.Dnn.AdminLoaiTin.View" %>
<fieldset class="fieldset">
    <legend>Tìm kiếm</legend>
    <table width="100%">
        <tr>
            <td>
                Tiêu đề:
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxTieuDe" Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nguồn tin
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlNguonTin">
                    <asp:ListItem Text="--Tất cả--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Nội bộ" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Công nghệ" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Hiển thị
            </td>
            <td>
                <asp:DropDownList runat="server" ID="DropDownList1">
                    <asp:ListItem Text="--Tất cả--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Hiển thị" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Không hiển thị" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <div class="buttons" style="padding-top: 5px;">
                    <asp:LinkButton runat="server" ID="lbtnTimKiem" ValidationGroup="G" >
                <img src="/DesktopModules/QuanLyKho/XuatKho/Style/find.png" alt="" /> Tìm kiếm
                    </asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
</fieldset>
<br />
<br />
<asp:GridView CssClass="gridview" runat="server" OnRowCommand="gvAdminLoaiTin_RowCommand"
    ID="gvAdminLoaiTin" EmptyDataText="Không có dữ liệu" AutoGenerateColumns="false"
    PagerSettings-Visible="false" AllowPaging="true">
    <FooterStyle CssClass="GridViewFooterStyle" />
    <RowStyle CssClass="GridViewRowStyle" />
    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
    <PagerStyle CssClass="GridViewPagerStyle" />
    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
    <HeaderStyle CssClass="GridViewHeaderStyle" />
    <Columns>
        <asp:TemplateField HeaderText="Tiêu đề" HeaderStyle-Width="25%">
            <ItemTemplate>
                <%#Eval("Ten") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Thứ tự" HeaderStyle-Width="10%">
            <ItemTemplate>
                <%#Eval("ThuTu") %>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hiển thị" HeaderStyle-Width="20%">
            <ItemTemplate>
                <%#Eval("TinhTrang") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="5%">
            <ItemTemplate>
                <asp:HyperLink ID="hplEdit" runat="server" NavigateUrl='<%#  EditUrl("action",Eval("ID").ToString(),"Edit") %>'>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/DesktopModules/QuanLyKho/XuatKho/Style/application_form_edit.png"
                        AlternateText="Hiệu chỉnh" /></asp:HyperLink>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="5%">
            <ItemTemplate>
                <asp:ImageButton ID="ibtn" OnClientClick="javascript:return confirm('Bạn thực sự muốn xóa Loại tin đã chọn?');"
                    CommandName="DeleteLoaiTin" CommandArgument='<%# Eval("ID") %>'
                    runat="server" ImageUrl="/DesktopModules/ChamCong/BaoCaoSauCa/Style/delete.png"
                    AlternateText="Xóa" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="color: Red; padding: 5px 0px 5px 0px;">
    <asp:Label runat="server" ID="lblThongBao"></asp:Label></div>
<div class="buttons" style="padding-top: 5px;">
    <asp:LinkButton runat="server" ID="lbtnThemMoi" OnClick="lbtnThemMoi_Click">
                <img src="/DesktopModules/QuanLyKho/XuatKho/Style/add.png" alt="" /> Thêm mới
    </asp:LinkButton>
</div>
<div style="float: right; padding-top: 5px;">
    Chuyển tới trang:
    <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlChuyenToiTrang" OnSelectedIndexChanged="ddlChuyenToiTrang_SelectedIndexChanged">
    </asp:DropDownList>
</div>
