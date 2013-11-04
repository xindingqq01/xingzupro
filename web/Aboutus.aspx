<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Aboutus.aspx.cs" Inherits="Aboutus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="style/twopanelpage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div style=" background:#ccc; height:20px; width:100%"></div>
<div class="leftbar">
<div class="divleftbartitle">
    <asp:Label ID="lbltitle1" runat="server" Text="About      " ForeColor="#008FD7"></asp:Label>
    <asp:Label ID="lbltitle2"
        runat="server" Text="Us"></asp:Label>
</div>



    <asp:Menu ID="Menu1" runat="server"  StaticDisplayLevels="1" MaximumDynamicDisplayLevels="1"  
        disappearafter="500"    orientation="Vertical" 
        onmenuitemclick="Menu1_MenuItemClick" >
          <Items>
                <asp:MenuItem Text="Introduction" Value="1" ImageUrl="~/style/images/newsfront.gif"></asp:MenuItem>
                <asp:MenuItem Text="Culture" Value="2" ImageUrl="~/style/images/newsfront.gif"></asp:MenuItem>
                <asp:MenuItem Text="Core team" Value="3" ImageUrl="~/style/images/newsfront.gif"></asp:MenuItem>
                <asp:MenuItem Text="Service" Value="4" ImageUrl="~/style/images/newsfront.gif"></asp:MenuItem>
             <asp:MenuItem Text="Ask" Value="5" ImageUrl="~/style/images/newsfront.gif" ></asp:MenuItem>
             
            </Items>
            <StaticMenuItemStyle   CssClass="staticmenuitem"/>
            <StaticSelectedStyle CssClass="staticmenuitemaselected" />
    </asp:Menu>
</div>
<div class="rightContent">
    <asp:Panel ID="Panel1" runat="server">
    <div id="divIntro" runat="server" style=" width:550px; float:left;">
    </div>
    <div style=" float:right; width:142px; padding-top:20px;">
        <asp:Image ID="Image7" runat="server" ImageUrl="~/style/images/aboutus.gif" 
            Width="140px" />
    </div>
    <div style=" clear:both;">
    </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:ListView ID="ListView1" runat="server" 
            onitemdatabound="ListView1_ItemDataBound">
        <LayoutTemplate>
            <table cellspacing="0">
                <thead>
                   
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr >
               
                <td style=" font-size:14px; color:#2e2e2e; padding:5px;">
                    <asp:Label ID="lblsQuestionCN" runat="server" Text='<%#Bind("sQuestionCN") %>'></asp:Label>
                     <asp:Label ID="lblsQuestionEN" runat="server" Text='<%#Bind("sQuestionEN") %>'></asp:Label>
                </td>
               
               
            </tr>
             <tr>
               
                <td style=" font-size:14px; color:#333; padding:5px;">
                   <asp:Label ID="lblsAnswerCN" runat="server" Text='<%#Bind("sAnswerCN") %>'></asp:Label>
                    <asp:Label ID="lblsAnswerEN" runat="server" Text='<%#Bind("sAnswerEN") %>'></asp:Label>
                </td>
               
               
            </tr>
        </ItemTemplate>
        </asp:ListView>
    </asp:Panel>
 </div>
<div style="clear:both;"></div>
</asp:Content>

