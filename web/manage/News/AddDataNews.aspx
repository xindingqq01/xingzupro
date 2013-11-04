<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddDataNews.aspx.cs" Inherits="manage_AddDataNews" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<%@ Register src="../../usercontrol/MutileUploaderUserControl4.ascx" tagname="MutileUploaderUserControl4" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="添加数据"></asp:Label>
    <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
<div class="rightcontent">

<table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnLangType" runat="server" Text="语种"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">中文</asp:ListItem>
                                    <asp:ListItem Value="1">英文</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol" style="height: 26px">
                                <asp:Label ID="lblsTitle" runat="server" Text="标题"></asp:Label>
                            </td>
                            <td class="SecondCol" style="height: 26px">
                                <asp:TextBox ID="txtsTitle" runat="server" Width="440px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsAuthor" runat="server" Text="作者"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsAuthor" runat="server"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                        <td class="FirstCol">
                        <asp:Label ID="Label2" runat="server" Text="图片列表"></asp:Label><br />
                            <asp:Button ID="Button1" runat="server" CssClass="btnOrange" Text="清除图片" 
                                onclick="Button1_Click" />
                        </td>
                        <td class="SecondCol">
                           
                            <asp:Image ID="Image3" runat="server" Height="75px" Width="135px" />
                           
                        </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsImagePath" runat="server" Text="图片路径"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <uc2:MutileUploaderUserControl4 ID="MutileUploaderUserControl31" 
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContent" runat="server" Text="内容"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <ckeditor:ckeditorcontrol ID="CKEditorControl1" runat="server"   Height="400px" Width="600px"
                                    ></ckeditor:ckeditorcontrol>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnSorting" runat="server" Text="优先级"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtnSorting" runat="server">1</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                            </td>
                            <td class="SecondCol">
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    Text="添加" onclick="BtnAdd_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnOrange" 
                                    Text="修改" onclick="btnUpdate_Click" /><asp:Button ID="BtnClear" 
                                    runat="server" CssClass="btnGreen" Text="清空" onclick="BtnClear_Click"
                                        />
                                <asp:HiddenField ID="hfID" runat="server" />
                            </td>
                        </tr>
                    </table>

                    </div>
</asp:Content>

