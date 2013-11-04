<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
         .style1
        {
            font-size:12px;
            padding:3px;
             padding-left:12px;
              padding-right:0px;
              text-align:left;
              width:90px;
                vertical-align:middle;
           border-bottom:2px dotted #ccc;
            
        }
        .style1 img
        {
             position:relative;
            top:4px;
        }
        .style2
        {
            position:relative;
            left:-8px;
            text-align:left;
            font-size:13px;
            vertical-align:middle;
           border-bottom:2px dotted #ccc;
        }
    </style>
<link href="style/onelan.css" rel="stylesheet" type="text/css" />

    <link href="manage/style/ShowMessage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style=" background:#ccc; height:20px; width:100%"></div>

<div style=" float:left; width:520px; padding-top:60px;">

    <asp:Image ID="Image1" runat="server"  Width="520px" ImageUrl="~/style/images/map.jpg"/>

</div>
<div style="float: right; width:400px; padding-top:60px;">
<div class="rtitle1">
<table style=" width:100%;">
<tr>
<td  style=" vertical-align:bottom; width:200px;">
    <asp:Image ID="Image3" runat="server" ImageUrl="~/style/images/daarrow.gif" />
<asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label>

</td>
<td>

 <asp:Image ID="Image2"
        runat="server" ImageUrl="~/style/images/nv.jpg"  Width="200px"  />

</td>



</tr>

</table>
    
   </div>
<%--<div style=" padding-left:28px; padding-top:20px;">

    <asp:Label ID="Label1" runat="server" Text="中山市丞恩电子有限公司" Font-Size="19px" style=" font-weight:lighter;"></asp:Label><br />




</div>--%>

        <table style="width: 100%;">
          <tr>
    <td style=" text-align:center; padding:3px; width:100px;">
        <asp:Label ID="lblcontitle1" runat="server" Text="Label" Font-Size="18px"></asp:Label>
        </td>
    <td style=" text-align:left;  " >
        <asp:Label ID="lblcontitle2" runat="server" Text="Label" Font-Size="13px"></asp:Label><br />
        <asp:Label ID="lblcontitle3" runat="server" Text="Label" Font-Size="13px"></asp:Label>
        </td>
    <td style=" text-align:left; padding:3px;">
        <asp:Label ID="lblcontitle4" runat="server" Text="Label" Font-Size="18px"></asp:Label>
        </td>
    </tr>
    <tr>
    <td colspan="3">
    
        <table style="width: 100%;">
            <tr >
                <td class="style1">
                    
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/style/images/newsfront.gif" />
                    
                    <asp:Label ID="lblsAddrtitle" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style2" >
                    
                    <asp:Label ID="lblsAddr" runat="server" Text="Label"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td class="style1">
                    
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/style/images/newsfront.gif" />
                    
                    <asp:Label ID="lblsPhonetitle" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style2">
                    
                    <asp:Label ID="lblsPhone" runat="server" Text="0571-"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="style1">
                    <asp:Image ID="Image10" runat="server" 
                        ImageUrl="~/style/images/newsfront.gif" />
                    <asp:Label ID="lblsFaxtitle" runat="server" Text="Label"></asp:Label>
                    
                </td>
                <td class="style2">
                    
                    <asp:Label ID="lblsFax" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
             <tr>
                <td class="style1">
                    <asp:Image ID="Image11" runat="server" 
                        ImageUrl="~/style/images/newsfront.gif" />
                    <asp:Label ID="lblsWebtitle" runat="server" Text="Label"></asp:Label>
                    
                </td>
                <td class="style2">
                    
                    <asp:Label ID="lblsWeb" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
             <tr>
                <td class="style1">
                    <asp:Image ID="Image12" runat="server" 
                        ImageUrl="~/style/images/newsfront.gif" />
                    <asp:Label ID="lblsEmailtitle" runat="server" Text="Label"></asp:Label>
                    
                </td>
                <td class="style2">
                    
                    <asp:Label ID="lblsEmail" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
        </table>
        </td>
    </tr>
    
    
    
    
    </table>
    
    
<%--<div id="contactdetail" runat="server" style=" padding-left:20px; padding-top:15px; font-size:14px;" ></div>
--%>
</div>

<div style=" clear:both; padding-bottom:60px;"></div>
</asp:Content>

