<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="IDG.Dnn.AdminLoaiTin.Edit" %>
<fieldset class="fieldset">
    <legend>Chi tiết Loại tin</legend>
    <table width="100%">
        <tr>
            <td style="width: 120px;">
                Tiêu đề: <span style="color: Red">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxTieuDe" Width="50%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfvTieuDe" ControlToValidate="tbxTieuDe"
                    Display="Dynamic" ErrorMessage="Tiêu đề không được bỏ trống" SetFocusOnError="true"
                    ValidationGroup="G"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                Cha:
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxCha" Width="50%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                Thứ tự:
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxThuTu" Width="50%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nguồn tin:
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
                Ngôn ngữ:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlNgonNgu">
                    <asp:ListItem Text="Tiếng Việt" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Tiếng Anh" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Tình trạng:
            </td>
            <td>
                <asp:CheckBox runat="server" ID="cbxTinhTrang" Text="Hoạt động" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <span style="color: red">
                    <asp:Label runat="server" ID="lblThongBao"></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="buttons">
                <asp:LinkButton runat="server" ID="lbtnGhiLai" ValidationGroup="G" OnClick="lbtnGhiLai_Click">
                <img src="/DesktopModules/DanhMuc/DanhMucNhanVien/Style/add.png" alt="" /> Ghi lại
                </asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtnDanhSach" OnClick="lbtnDanhSach_Click">
                <img src="/DesktopModules/DanhMuc/DanhMucNhanVien/Style/application_view_list.png" alt="" /> Danh sách
                </asp:LinkButton>
            </td>
        </tr>
    </table>
</fieldset>
