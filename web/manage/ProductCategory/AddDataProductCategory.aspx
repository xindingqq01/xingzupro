<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddDataProductCategory.aspx.cs" Inherits="manage_AddDataProductCategory" %>

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
                                <asp:Label ID="lblsProductCategoryNameCN" runat="server" Text="产品类别(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductCategoryNameCN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameEN" runat="server" Text="产品类别(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductCategoryNameEN" runat="server"></asp:TextBox><br />
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

