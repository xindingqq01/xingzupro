﻿<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataListFAQ.aspx.cs" Inherits="manage_DataListFAQ" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">

    
    <asp:ListView ID="lvFAQ" runat="server" 
        onselectedindexchanging="lvFAQ_SelectedIndexChanging" 
        onitemdatabound="lvFAQ_ItemDataBound" onitemdeleting="lvFAQ_ItemDeleting" 
        onpagepropertieschanged="lvFAQ_PagePropertiesChanged" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnFAQID" runat="server" CommandArgument="nFAQID" 
                                CommandName="Sorting" Text="FAQ编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsQuestionCN" runat="server" Text="问题(中文)"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsQuestionEN" runat="server" Text="问题(英文)"></asp:LinkButton>
                        </th>
                         <th>
                            <asp:LinkButton ID="lbtnsAnswerCN" runat="server" Text="答案(中文)"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsAnswerEN" runat="server" Text="答案(英文)"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnnSorting" runat="server" Text="优先级"></asp:LinkButton>
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
                   <asp:Label ID="lblnFAQID" runat="server" Text='<%#Bind("nFAQID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsQuestionCN" runat="server" Text='<%#Bind("sQuestionCN") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsQuestionEN" runat="server" Text='<%#Bind("sQuestionEN") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="lblsAnswerCN" runat="server" Text='<%#Bind("sAnswerCN") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsAnswerEN" runat="server" Text='<%#Bind("sAnswerEN") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="lblnSorting" runat="server" Text='<%#Bind("nSorting") %>'></asp:Label>
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
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvFAQ">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

