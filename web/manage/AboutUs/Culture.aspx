<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="Culture.aspx.cs" Inherits="manage_Culture" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="人文/Culture"></asp:Label>
    <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
<div class="rightcontent">

<table class="TableList">
                        
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameCN" runat="server" Text="人文(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="400px"></CKEditor:CKEditorControl></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameEN" runat="server" Text="人文(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" Height="400px"></CKEditor:CKEditorControl></td>
                        </tr>
                        
                        <tr>
                            <td class="FirstCol">
                            </td>
                            <td class="SecondCol">
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    Text="更新" onclick="BtnAdd_Click" />
                            </td>
                        </tr>
                    </table>

                    </div>
</asp:Content>

