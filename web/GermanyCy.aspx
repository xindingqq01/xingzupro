<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GermanyCy.aspx.cs" Inherits="GermanyCy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="style/onelan.css" rel="stylesheet" type="text/css" />
    <link href="style/ListView.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/ShowMessage.css" rel="stylesheet" type="text/css" />
    <link href="style/gridview.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/Button.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background: #ccc; height: 20px; width: 100%">
    </div>
    <div class="top">
        <div class="toptitle">
            <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div  class="divCenterOne">
        <asp:Label ID="lbltemp" runat="server" Text="Label"></asp:Label>
    

</div>
</asp:Content>

