<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="template.aspx.cs" Inherits="manage_Products_template" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
中文  <CKEditor:CKEditorControl ID="CKEditorControlc" runat="server" 
                                    AutoGrowMinHeight="150" Height="350" Width=""></CKEditor:CKEditorControl>
英文  <CKEditor:CKEditorControl ID="CKEditorControle" runat="server" 
                                    AutoGrowMinHeight="150" Height="350" Width=""></CKEditor:CKEditorControl>

    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>

