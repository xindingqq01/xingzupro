<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataListProduct.aspx.cs" Inherits="manage_DataListProduct" %>



<%@ Register src="../usercontrol/ddlProductCateTreelist2.ascx" tagname="ddlProductCateTreelist2" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">
                    <table style="width: 100%;">
                    <tr>
                        <td>
                           所属产品类型:
                        <uc1:ddlProductCateTreelist2 ID="ddlProductCateTreelist21" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="关键字"></asp:Label>   <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                        
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btnOrange" Height="24px" 
                    onclick="btnSearch_Click" Text="Search" />
                        </td>
                    </tr>
                   </table>
    <asp:ListView ID="lvProduct" runat="server" 
        onselectedindexchanging="lvProduct_SelectedIndexChanging" 
        onitemdatabound="lvProduct_ItemDataBound" 
        onitemdeleting="lvProduct_ItemDeleting" 
        onpagepropertieschanged="lvProduct_PagePropertiesChanged" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnProductID" runat="server" CommandArgument="nProductID" 
                                CommandName="Sorting" Text="产品编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsProductNameCN" runat="server" Text="产品名称(中文)"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsProductNameEN" runat="server" Text="产品名称(英文)"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsUpdatedByTitle" runat="server" Text="更新者"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtndUpdatedTimetitle" runat="server" 
                                CommandArgument="dUpdatedTime" CommandName="Sorting" Text="更新时间"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:Label ID="lblOpera" runat="server" Text="操作"></asp:Label>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="ListViewRow">
                <td>
                   <asp:Label ID="lblnProductID" runat="server" Text='<%#Bind("nProductID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsProductNameCN" runat="server" Text='<%#Bind("sProductNameCN") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsProductNameEN" runat="server" Text='<%#Bind("sProductNameEN") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsUpdatedBy" runat="server" Text='<%#Bind("sUpdatedBy") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbldUpdatedTimee" runat="server" 
                        Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="select" 
                        CssClass="btnOrange" Text="更新" />
                    <asp:Button ID="btnDelete" runat="server" CommandName="delete" 
                        CssClass="btnGreen" Text="删除" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvProduct">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

