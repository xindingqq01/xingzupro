<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataListUser.aspx.cs" Inherits="manage_DataListUser" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">

    
    <asp:ListView ID="lvUser" runat="server" 
        onselectedindexchanging="lvUser_SelectedIndexChanging" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnUserID" runat="server" CommandArgument="nUserID" 
                                CommandName="Sorting" Text="用户编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsUsername" runat="server" Text="用户名称"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsRealName" runat="server" Text="真实姓名"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsUserQQ" runat="server" Text="QQ"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsUserMSN" runat="server" Text="MSN"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsUserPhone" runat="server" Text="用户手机"></asp:LinkButton>
                        </th>
                         <th>
                            <asp:LinkButton ID="lbtnsUserEmail" runat="server" Text="EMAIL"></asp:LinkButton>
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
                   <asp:Label ID="lblnUserID" runat="server" Text='<%#Bind("nUserID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsUsername" runat="server" Text='<%#Bind("sUsername") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsRealName" runat="server" Text='<%#Bind("sRealName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsUserQQ" runat="server" Text='<%#Bind("sUserQQ") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsUserMSN" runat="server" Text='<%#Bind("sUserMSN") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsUserPhone" runat="server" Text='<%#Bind("sUserPhone") %>'></asp:Label>
                </td>
                <td>
                   <asp:Label ID="lblsUserEmail" runat="server" Text='<%#Bind("sUserEmail") %>'></asp:Label>
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
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvUser">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

