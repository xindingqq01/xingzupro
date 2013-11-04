<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddData.aspx.cs" Inherits="manage_AddData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="添加数据页"></asp:Label></div>
<div class="rightcontent">

<table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsGroupNameTitle" runat="server" Text="用户组名称"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsGroupName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="Label3" runat="server" Text="部门简介"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsGroupIntro" runat="server" CssClass="TextEditM" TextMode="MultiLine"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="Label5" runat="server" Text="所属部门"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtnDMID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="Label10" runat="server" Text="排序先后 "></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtnSort" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                            </td>
                            <td class="SecondCol">
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    Text="添加" onclick="BtnAdd_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnOrange" 
                                    Text="修改" onclick="btnUpdate_Click" /><asp:Button ID="BtnClear" runat="server" CssClass="btnGreen" Text="清空"
                                        />
                                <asp:HiddenField ID="hfID" runat="server" />
                            </td>
                        </tr>
                    </table>

                    </div>
</asp:Content>

