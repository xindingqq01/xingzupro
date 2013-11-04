<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DropSorting.ascx.cs" Inherits="usercontrol_DropDownList_DropSorting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="140px">
        </asp:DropDownList>
    </ContentTemplate>

</asp:UpdatePanel>
