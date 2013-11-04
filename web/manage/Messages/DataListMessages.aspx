<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataListMessages.aspx.cs" Inherits="manage_DataListMessages" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">

    
    <asp:ListView ID="lvMessages" runat="server" 
        onselectedindexchanging="lvMessages_SelectedIndexChanging" 
        onitemdatabound="lvMessages_ItemDataBound" 
        onpagepropertieschanged="lvMessages_PagePropertiesChanged" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnContactID" runat="server" CommandArgument="nContactID" 
                                CommandName="Sorting" Text="留言编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsName" runat="server" Text="客户名字"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsCompanyName" runat="server" Text="所属公司"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsPhone" runat="server" Text="联系电话"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsPositon" runat="server" Text="职位"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsEmail" runat="server" Text="电子邮件"></asp:LinkButton>
                        </th>
                         <th>
                            <asp:LinkButton ID="lbtnsWeb" runat="server" Text="网址"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="ltbnbCheck" runat="server" Text="是否已阅"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtndUpdatedTimetitle" runat="server" 
                                CommandArgument="dUpdatedTime" CommandName="Sorting" Text="留言时间"></asp:LinkButton>
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
                   <asp:Label ID="lblnContactID" runat="server" Text='<%#Bind("nContactID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsName" runat="server" Text='<%#Bind("sName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsCompanyName" runat="server" Text='<%#Bind("sCompanyName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsPhone" runat="server" Text='<%#Bind("sPhone") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsPositon" runat="server" Text='<%#Bind("sPositon") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsEmail" runat="server" Text='<%#Bind("sEmail") %>'></asp:Label>
                </td>
                <td>
                   <asp:Label ID="lblsWeb" runat="server" Text='<%#Bind("sWeb") %>'></asp:Label>
                </td>
                <td>
                   <asp:Label ID="lblbCheck" runat="server" Text='<%#Bind("bCheck") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbldUpdatedTimee" runat="server" 
                        Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="select" 
                        CssClass="btnOrange" Text="查看" />
                    <%--<asp:Button ID="btnDelete" runat="server" CommandName="delete" 
                        CssClass="btnGreen" Text="删除" />--%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvMessages">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

