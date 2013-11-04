<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="manage_DataList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="数据列表"></asp:Label></div>
<div class="rightcontent">

    
    <asp:ListView ID="lvStudent" runat="server" 
        onselectedindexchanging="lvStudent_SelectedIndexChanging" >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle">
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:LinkButton ID="lbtnIDtitle" runat="server" CommandArgument="nID" 
                                CommandName="Sorting" Text="编号"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsUserNameTitle" runat="server" Text="用户名"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsStudentName" runat="server" Text="学员名称"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnnStudentGrade" runat="server" Text="年级"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsStudentPhone" runat="server" Text="学员电话"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton ID="lbtnsStudentSchool" runat="server" Text="在读学校"></asp:LinkButton>
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
                   <asp:Label ID="lblnUserID" runat="server" Text=''></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsUsername" runat="server" Text='<%#Bind("dwd") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsStudentName" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblnStudentGrade" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsStudentPhone" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsStudentSchool" runat="server" Text=""></asp:Label>
                </td>
                <td>
                   
                </td>
                <td>
                   <%-- <asp:Label ID="lbldUpdatedTimee" runat="server" 
                        Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd}") %>'></asp:Label>--%>
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
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvStudent">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btnBlue" ButtonType="Button" 
                FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
        </Fields>
    </asp:DataPager>

</div>
</asp:Content>

