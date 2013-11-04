<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataListProductCategory.aspx.cs" Inherits="manage_DataListProductCategory" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">

    
    <asp:ListView ID="lvProductCategory" runat="server" 
        onselectedindexchanging="lvProductCategory_SelectedIndexChanging" 
        onitemdatabound="lvProductCategory_ItemDataBound" 
        onitemdeleting="lvProductCategory_ItemDeleting" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnProductCategoryID" runat="server" CommandArgument="nProductCategoryID" 
                                CommandName="Sorting" Text="产品类别编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsProductCategoryNameCN" runat="server" Text="产品类别(中文)"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsProductCategoryNameEN" runat="server" Text="产品类别(英文)"></asp:LinkButton>
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
                   <asp:Label ID="lblnProductCategoryID" runat="server" Text='<%#Bind("nProductCategoryID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsProductCategoryNameCN" runat="server" Text='<%#Bind("sProductCategoryNameCN") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsProductCategoryNameEN" runat="server" Text='<%#Bind("sProductCategoryNameEN") %>'></asp:Label>
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
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvProductCategory">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

