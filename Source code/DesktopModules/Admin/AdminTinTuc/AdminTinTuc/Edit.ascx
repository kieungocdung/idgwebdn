<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="IDG.Dnn.AdminTinTuc.Edit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<fieldset class="fieldset">
    <legend>Chi tiết tin tức</legend>
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
                Tác giả:
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxtacgia" Width="50%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                Người tạo
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxNguoiTao" Width="50%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ảnh
            </td>
            <td colspan="3">
                <asp:FileUpload ID="fulAnh" runat="server" Width="459px" />
                <asp:Image ID="imgImage" runat="server" Width="100px" />
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
                <label>
                    Loại Tin</label>
            </td>
            <td>
                <asp:DropDownList ID="ddlLoaiTin" runat="server" Width="180px">
                </asp:DropDownList>
            </td>
            <td class="style4">
                Lượt xem
            </td>
            <td>
                <asp:Label ID="lblLuotXem" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Tình trạng:
            </td>
            <td>
                <asp:CheckBox runat="server" ID="cbxTinhTrang" Text="Hoạt động" />
            </td>
            <td>
                Nổi Bật:
            </td>
            <td>
                <asp:CheckBox runat="server" ID="cbNoiBat" Text="Hoạt động" />
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    Tóm Tắt
                </label>
            </td>
            <td colspan="3">
                &nbsp;<fckeditorv2:fckeditor id="txtTomTat" runat="server" width="80%" height="300px"
                    basepath="~/fckeditor/" defaultlanguage="vi" autodetectlanguage="True" linkbrowserurl="aspx"
                    imagebrowserurl="aspx">
                                    </fckeditorv2:fckeditor>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    Nội Dung</label>
            </td>
            <td colspan="3">
                &nbsp;<fckeditorv2:fckeditor id="txtNoiDung" runat="server" width="80%" height="500px"
                    basepath="~/fckeditor/">
                                    </fckeditorv2:fckeditor>
                <br />
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
