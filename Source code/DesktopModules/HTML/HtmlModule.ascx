<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke.WebControls" %>
<%@ Control language="vb" Inherits="DotNetNuke.Modules.Html.HtmlModule" CodeBehind="HtmlModule.ascx.vb" AutoEventWireup="false" Explicit="True" %>
<dnn:DNNLabelEdit id="lblContent" runat="server" cssclass="Normal" enableviewstate="False" MouseOverCssClass="LabelEditOverClassML"
	LabelEditCssClass="LabelEditTextClass" EditEnabled="False" MultiLine="True" RichTextEnabled="True"
	ToolBarId="tbEIPHTML" RenderAsDiv="True" EventName="none" LostFocusSave="False" CallBackType="Simple" ClientAPIScriptPath="" LabelEditScriptPath="" WorkCssClass=""></dnn:DNNLabelEdit>
<DNN:DNNToolBar id="tbEIPHTML" runat="server" CssClass="eipbackimg" ReuseToolbar="true"
	DefaultButtonCssClass="eipbuttonbackimg" DefaultButtonHoverCssClass="eipborderhover">
	<DNN:DNNToolBarButton ControlAction="edit" ID="tbEdit" ToolTip="Edit" CssClass="eipbutton_edit" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="save" ID="tbSave" ToolTip="Update" CssClass="eipbutton_save" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="cancel" ID="tbCancel" ToolTip="Cancel" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="bold" ID="tbBold" ToolTip="Bold" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="italic" ID="tbItalic" ToolTip="Italic" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="underline" ID="tbUnderline" ToolTip="Underline" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="justifyleft" ID="tbJustifyLeft" ToolTip="Justify Left" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="justifycenter" ID="tbJustifyCenter" ToolTip="Justify Center" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="justifyright" ID="tbJustifyRight" ToolTip="Justify Right" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="insertorderedlist" ID="tbOrderedList" ToolTip="Ordered List" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="insertunorderedlist" ID="tbUnorderedList" ToolTip="Unordered List" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="outdent" ID="tbOutdent" ToolTip="Outdent" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="indent" ID="tbIndent" ToolTip="Indent" runat="server"/>
	<DNN:DNNToolBarButton ControlAction="createlink" ID="tbCreateLink" ToolTip="Create Link" runat="server"/>
</DNN:DNNToolBar>