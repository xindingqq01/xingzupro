<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Partners.aspx.cs" Inherits="Partners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="style/onelan.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style=" background:#ccc; height:20px; width:100%"></div>
 <div class="divCenterOne">
 <div class="divvCenterOnetitle">
 
     <asp:Label ID="lbltitle" runat="server" Text="Partners"></asp:Label>
 
 
 
 
 </div>
 
 
 <div>
     <asp:Label ID="Label14" runat="server" Text="资料更新维护中......"></asp:Label>
     <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
         RepeatDirection="Horizontal">
         <ItemTemplate>
        <div class="datalist">
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<% #Bind("sWebAdr") %>'>
         <div class="divimg">
             <asp:Image ID="Image3" runat="server" Height="108px" Width="148px" 
              ImageUrl='<% #Bind("sImagePath") %>' ToolTip='<% #Bind("sImageNameEN") %>' /></div></asp:HyperLink>
         </div>
         </ItemTemplate>
        
     </asp:DataList>
 
 </div>
 
 </div>


</asp:Content>

