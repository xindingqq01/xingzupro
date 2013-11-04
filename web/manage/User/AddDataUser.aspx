<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddDataUser.aspx.cs" Inherits="manage_AddDataUser" %>

<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

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
                                <asp:Label ID="lblnUserType" runat="server" Text="用户角色"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">普通用户</asp:ListItem>
                                    <asp:ListItem Value="1">管理员</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUsername" runat="server" Text="用户名称"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUsername" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPassword0" runat="server" Text="用户密码"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPassword0" runat="server" TextMode="Password"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPassword1" runat="server" Text="密码确认"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPassword1" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsRealName" runat="server" Text="真实姓名"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsRealName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnUserSex" runat="server" Text="性别"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                                    <asp:ListItem Value="1">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserQQ" runat="server" Text="用户QQ"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserQQ" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserMSN" runat="server" Text="用户MSN"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserMSN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserPhone" runat="server" Text="用户电话"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserPhone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserEmail" runat="server" Text="用户EMAIL"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserEmail" runat="server"></asp:TextBox>
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

