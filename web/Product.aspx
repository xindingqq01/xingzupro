<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="style/treeview.css" rel="stylesheet" type="text/css" />
<link href="style/twopanelpage.css" rel="stylesheet" type="text/css" />
    <link href="manage/style/Button.css" rel="stylesheet" type="text/css" />
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
        disappearafter="500"    orientation="Vertical"  Visible="false"
         >
          <Items>
              
            </Items>
            <StaticMenuItemStyle   CssClass="staticmenuitem"/>
            <StaticSelectedStyle CssClass="staticmenuitemaselected" />
    </asp:Menu>
    <asp:TreeView ID="TreeView1" runat="server" ShowExpandCollapse="False"   
        CssClass="treeview" onselectednodechanged="TreeView1_SelectedNodeChanged">
    
  
    <HoverNodeStyle  CssClass="parentnodeselected"/>
    <SelectedNodeStyle CssClass="parentnodeselected"/>
    <LevelStyles>
    <asp:TreeNodeStyle  CssClass="parentnode"/>
    <asp:TreeNodeStyle CssClass="leafnode" />
    </LevelStyles>
    </asp:TreeView>
</div>
<div class="rightContent">
    <asp:Panel ID="Panel1" runat="server">
    
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" 
        RepeatDirection="Horizontal" 
            onselectedindexchanged="DataList1_SelectedIndexChanged" 
            oneditcommand="DataList1_EditCommand" 
            onitemdatabound="DataList1_ItemDataBound" >
            <ItemTemplate>
                <table  class="styleproductlist" >
               
                <tr>
                    <td>
                        <asp:Label ID="lblnProductID" runat="server" Text='<% #Bind("nProductID") %>' Visible="false"></asp:Label>
                        <asp:ImageButton ID="Image2" runat="server" Width="216px" Height="170px"  ImageUrl='<% #Bind("sThumbPath") %>' CommandName="edit"/>   </td>
                    
                </tr>
                <tr>
                    <td style=" padding-top:3px; padding-bottom:3px; text-align:center;">
                        <asp:Label ID="lblxingcn" runat="server" Text="型号: "></asp:Label>      <asp:LinkButton ID="LinkButton1" runat="server"  Text='<% #Bind("sProductNameCN") %>' CommandName="edit"></asp:LinkButton>  
                    <asp:Label ID="lblxingen" runat="server" Text="Type: "></asp:Label>      <asp:LinkButton ID="LinkButton2" runat="server"  Text='<% #Bind("sProductNameEN") %>' CommandName="edit"></asp:LinkButton>  </td>
                   
                </tr>
            </table>
            </ItemTemplate>
        </asp:DataList>
    <div style=" text-align:right;">


        <asp:Button ID="btnLast" runat="server" Text="<<"  CssClass="btndark" 
            onclick="btnLast_Click" />
        <asp:Label ID="lblCurtitle" runat="server" Text="页数:"></asp:Label>
        <asp:Label ID="lblcur" runat="server" Text="0"></asp:Label>
            
            <asp:Label ID="Label1" runat="server" Text="/"></asp:Label>
            
            <asp:Label ID="lbltotal" runat="server" Text="0"></asp:Label>

        <asp:Button ID="btnNext" runat="server" Text=">>" CssClass="btndark" 
            onclick="btnNext_Click" />
    </div>
    
    
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    <div class="ProductDetail">
   
    <div class="ProductDetailTop">
    
    <div class="BigIMG">
        <asp:Image ID="IMGbig" runat="server" Height="290px" Width="350px" />
        </div>
    
   
    
    <div class="DetailList">
        
    <ul>
        <li> <div class="smalltitle">
    <asp:Label ID="lblProductName" runat="server" Text="ProductName"></asp:Label></div></li>
        <li>

        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblProductCatetitle" runat="server" Text="  Product Category" 
                Font-Size="12px" ></asp:Label>
            <asp:Label ID="Label6" runat="server" Text=":  " Font-Size="12px" ></asp:Label>
            <asp:Label ID="lblProductCate" runat="server" Font-Size="12px" 
                ></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblsBrandNametitle" runat="server" Text="Brand" 
                        Font-Size="12px" ></asp:Label>
            <asp:Label ID="Label8" runat="server" Text=":  " Font-Size="12px" ></asp:Label>
            <asp:Label ID="lblsBrandName" runat="server" Font-Size="12px" 
                ></asp:Label>
                </td>
                
            </tr>
            
        </table>
            </li>
        <li>
           </li>
       <%-- <li>
            <asp:Label ID="lblSensitivitytitle" runat="server" Text="Sensitivity" 
                Font-Size="12px" ></asp:Label>
            <asp:Label ID="Label11" runat="server" Text=":  " Font-Size="12px" ></asp:Label>
            <asp:Label ID="lblSensitivity" runat="server" Font-Size="12px" ></asp:Label></li>
        <li>
            <asp:Label ID="lblchannelbalancetitle" runat="server" Text="Channel Balance" 
                Font-Size="12px" ></asp:Label>
            <asp:Label ID="Label14" runat="server" Text=":  " Font-Size="12px" ></asp:Label>
            <asp:Label ID="lblchannelbalance" runat="server" Font-Size="12px" ></asp:Label></li>
        <li>
            <asp:Label ID="lblimpedancetitle" runat="server" Text="Impedance" 
                Font-Size="11px" ></asp:Label>
            <asp:Label ID="Label17" runat="server" Text=":  " Font-Size="11px" ></asp:Label>
            <asp:Label ID="lblimpedance" runat="server" Font-Size="11px" ></asp:Label></li>
        <li>
            <asp:Label ID="lblfrequencyrangetitle" runat="server" Text="Frequency Range" 
                Font-Size="11px" ></asp:Label>
            <asp:Label ID="Label20" runat="server" Text=":  " Font-Size="11px" ></asp:Label>
            <asp:Label ID="lblfrequencyrange" runat="server" Font-Size="11px" ></asp:Label></li>
        <li>
            <asp:Label ID="lblratedpowertitle" runat="server" Text="Rated Power" 
                Font-Size="11px" ></asp:Label>
            <asp:Label ID="Label23" runat="server" Text=":  " Font-Size="11px" ></asp:Label>
            <asp:Label ID="lblratedpower" runat="server" Font-Size="11px" ></asp:Label></li>
        <li>
            <asp:Label ID="lblmaximumpowertitle" runat="server" Text="Maximum Power" 
                Font-Size="11px" ></asp:Label>
            <asp:Label ID="Label26" runat="server" Text=":  " Font-Size="11px" ></asp:Label>
            <asp:Label ID="lblmaximumpower" runat="server" Font-Size="11px" ></asp:Label></li>--%>
            <div id="divProductCate" runat="server" style=" padding:5px;"></div>
           
    </ul>
    </div>
    
    <div style=" clear:both;"></div>
    <%--<div id="divProductCate" runat="server" style=" padding:5px;"></div>--%>
    </div>
    <div class="divtitle">
        <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label></div>
    <div style="width:100%" id="divProductInfo" runat="server"></div>
    </div>
    </asp:Panel>
 </div>
<div style="clear:both;"></div>
</asp:Content>

