<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataListNews.aspx.cs" Inherits="manage_DataListNews" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">

    
    <asp:ListView ID="lvNews" runat="server" 
        onselectedindexchanging="lvNews_SelectedIndexChanging" 
        onitemdatabound="lvNews_ItemDataBound" 
        onitemdeleting="lvNews_ItemDeleting" 
        onpagepropertieschanged="lvNews_PagePropertiesChanged" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnNewsID" runat="server" CommandArgument="nNewsID" 
                                CommandName="Sorting" Text="新闻编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsTitle" runat="server" Text="标题"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsAuthor" runat="server" Text="作者"></asp:LinkButton>
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
                   <asp:Label ID="lblnNewsID" runat="server" Text='<%#Bind("nNewsID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsTitle" runat="server" Text='<%#Bind("sTitle") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsAuthor" runat="server" Text='<%#Bind("sAuthor") %>'></asp:Label>
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
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvNews">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

