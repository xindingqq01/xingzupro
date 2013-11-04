<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataMessages.aspx.cs" Inherits="manage_DataMessages" %>

<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="留言明细"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
<div class="rightcontent">

<table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsName" runat="server" Text="客户名字"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lbllbtnsCompanyName" runat="server" Text="所属公司"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsCompanyName" runat="server"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPhone" runat="server" Text="联系电话"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPhone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPositon" runat="server" Text="职位"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPositon" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsEmail" runat="server" Text="电子邮件"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsWeb" runat="server" Text="网址"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsWeb" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContent" runat="server" Text="留言内容"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsContent" runat="server" Height="181px" TextMode="MultiLine" 
                    Width="669px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                            </td>
                            <td class="SecondCol">
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    Text="返回" onclick="BtnAdd_Click" />
                                <asp:HiddenField ID="hfID" runat="server" />
                            </td>
                        </tr>
                    </table>

                    </div>
</asp:Content>

