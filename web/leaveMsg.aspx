<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="leaveMsg.aspx.cs" Inherits="leaveMsg" %>

<%@ Register src="manage/usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="style/onelan.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/Button.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/ShowMessage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style=" background:#ccc; height:20px; width:100%"></div>
<div class="top">
<div class="toptitle">
    <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label></div>
</div>

<div  class="divCenterOne" style=" background-color:#EEEEEF; width:100%; padding-top:30px;padding-bottom:30px;">
    <table  class="leavetable">
        <tr>
            <td class="titletd">
               
                <asp:Label ID="lblsName" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
               
                <asp:TextBox ID="txtsName" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="titletd">
                <asp:Label ID="lblsCompanyName" runat="server" Text="Label"></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtsCompanyName" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="titletd">
               
                <asp:Label ID="lblsPhone" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
               
                <asp:TextBox ID="txtsPhone" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="titletd">
                <asp:Label ID="lblsJob" runat="server" Text="Label"></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtsJob" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="titletd">
               
                <asp:Label ID="lblsEmail" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
               
                <asp:TextBox ID="txtsEmail" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="titletd">
                <asp:Label ID="lblsWeb" runat="server" Text="Label"></asp:Label>
               
            </td>
            <td>
               
                <asp:TextBox ID="txtsWeb" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="titletd">
               
                <asp:Label ID="lblsContent" runat="server" Text="Label"></asp:Label>
            </td>
            <td colspan="3">
               
                <asp:TextBox ID="txtsContent" runat="server" Height="154px" TextMode="MultiLine" 
                    Width="708px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
        
        <td class="titletd">
               
                &nbsp;</td>
            <td colspan="3">
               
                <asp:TextBox ID="txtsVali" runat="server"   
                   ></asp:TextBox><img src="ValidateCode.aspx" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style=" text-align:center">
              
                <asp:Button ID="btnSubmit" runat="server" Text="Button"  CssClass="btndarkRed"
                    onclick="btnSubmit_Click" />
                <uc1:ShowMsg ID="ShowMsg1" runat="server" />
            </td>
        </tr>
    </table>








</div>



</asp:Content>

