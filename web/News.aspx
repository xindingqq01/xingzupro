<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="style/onelan.css" rel="stylesheet" type="text/css" />
    <link href="style/ListView.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/ShowMessage.css" rel="stylesheet" type="text/css" />
    <link href="style/gridview.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/Button.css" rel="stylesheet" type="text/css" />
    <style>
    .stylenum
    {
        padding:1px;
        padding-left:2px;
        padding-right:2px;
        color:#333;
        font-size:14px;
         position:relative;
         top:-2px;
    }
     .stylenum a
     {
        
         color:#333;
         font-size:14px;
     }
     .tablejob td
     {
         padding:5px;
         font-size:15px;
     }
     .tablejob td input
     {
          padding-left:4px;
          padding-right:4px;
     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div style=" background:#ccc; height:20px; width:100%"></div>
<div class="top">
<div class="toptitle">
    <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label></div>
</div>

<div  class="divCenterOne">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <asp:Panel ID="Panel1" runat="server">
    
        <asp:Label ID="Label14" runat="server" Text="网站资料更新中。。。。。。"></asp:Label>
    
<asp:GridView ID="lvNews" runat="server" AutoGenerateColumns="False" 
        Width="100%" ShowHeader="False" GridLines="None" 
            onselectedindexchanging="lvNews_SelectedIndexChanging" 
             onrowdatabound="lvNews_RowDataBound" 
        >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                <table class="newslist" style=" font-size:13px;">
                <tr>
                 <td>
                     <asp:Label ID="lblnID" runat="server" Text='<% #bind("nNewsID") %>' Visible="false"></asp:Label>
                
                <asp:Image ID="Image4" runat="server"   ImageUrl="~/style/images/newsfront.gif"  style=" position:relative;top:3px; background-color:#fff;"/>
                    <asp:LinkButton ID="lbtnnewstitle" runat="server"  Text='<% #bind("sTitle") %>' CommandName="select"></asp:LinkButton>
                
                </td>
                <td style="width:75px;">
                <asp:Label ID="lblsAuthor" runat="server" Text='<% #bind("sAuthor") %>'></asp:Label>
                
                </td>
                <td style="width:100px;">
                <asp:Label ID="lbltime" runat="server" Text='<% #bind("dCreatedTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                
                </td>
                
                </tr>
                
                </table>
                    
                </ItemTemplate>
            </asp:TemplateField>
          
        </Columns>
    </asp:GridView>
    <div style=" text-align:center;">


        <asp:Button ID="btnLast" runat="server" Text="<<"  CssClass="btndark" 
            onclick="btnLast_Click" />
        <asp:Label ID="lblCurtitle" runat="server" Text="页数:"></asp:Label>
        <asp:Label ID="lblcur" runat="server" Text="0"></asp:Label>
            
            <asp:Label ID="Label4" runat="server" Text="/"></asp:Label>
            
            <asp:Label ID="lbltotal" runat="server" Text="0"></asp:Label>

        <asp:Button ID="btnNext" runat="server" Text=">>" CssClass="btndark" 
            onclick="btnNext_Click" />
    </div>
   </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" >
        <div style=" width:100%; border-bottom:2px solid #ccc; padding:5px; font-size:13px; text-align: center;">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="22px" 
                Font-Bold="True" Visible="true" style=" margin-bottom:20px;"></asp:Label>   <br />

           &nbsp;    <asp:Label ID="lblsAuthor" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblsCreatedBy" runat="server" Text="Label"></asp:Label>
            
        </div>
        <div style=" min-height:500px;">
        <table style=" width:100%;" class="tablejob">
     <tr>
        <td colspan="2" style=" text-align: center;">
        
            <asp:Image ID="Image1" runat="server"  Width="60%"/>
        
        </td>
        <tr>
        <td colspan="2">
        <div id="divNewsdetail" runat="server">
        
        
        </div>
        
        
        </td>
        
        </tr>
        
        <tr>
        <td colspan="2"  style=" text-align:center;">
        
            <asp:Button ID="btnBack" runat="server" Text="Button" CssClass="btndark" 
                onclick="btnBack_Click" />
        
        </td>
        
        </tr>
        
        </table>
        
        </div>


    </asp:Panel>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    

</div>
</asp:Content>

