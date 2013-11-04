<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="manage_ContactUs" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="联系我们/ContactUs"></asp:Label>
    <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
<div class="rightcontent">

<table class="TableList">
                        
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameCN" runat="server" Text="联系我们(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" 
                                    AutoGrowMinHeight="400" Font-Names="微软雅黑" Height="400px"></CKEditor:CKEditorControl></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameEN" runat="server" Text="联系我们(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" 
                                    AutoGrowMinHeight="400" Font-Names="微软雅黑" Height="400px"></CKEditor:CKEditorControl></td>
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

