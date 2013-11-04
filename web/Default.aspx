<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


  
        .style1 img
        {
             position:relative;
            top:4px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div class="divleftwidth">
<div class="divtitle">
<div class="lefttitle"><asp:Label ID="lbltitleproduct" runat="server" Text="Label"></asp:Label></div>
    
    <div class="rightmore"><asp:HyperLink ID="hlproduct" runat="server" Text="More" 
            style=" margin-right:6px;" Font-Bold="True" NavigateUrl="~/Product.aspx" ></asp:HyperLink></div>
   <div style=" clear:both;"></div>
    </div>

    
<div style="margin-top:10px; margin-bottom:10px;">
    
</div>

<div >

<div id="ProductsShowInFPBody">
  <div id="demo"  style ="width:580px;height:220px; overflow :hidden "> 
     <table >  

        <tr>
           <td>
             <div id="demo1" >                                                            
                       <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" 
        RepeatDirection="Horizontal" onitemdatabound="DataList1_ItemDataBound" 
                           oneditcommand="DataList1_EditCommand">
        <ItemTemplate>
            <table class="styleproductlist">
               
                <tr>
                    <td>
                        <asp:Label ID="lblnProductID" runat="server" Text='<% #Bind("nProductID") %>'  Visible="false"></asp:Label>
                        <asp:ImageButton ID="Image2" runat="server" Width="160px" Height="125px"  ImageUrl='<% #Bind("sThumbPath") %>' CommandName="edit"/>   </td>
                    
                </tr>
                <tr>
                    <td style=" padding-top:3px; padding-bottom:3px; text-align:center;">
                       <asp:Label ID="lblxingcn" runat="server" Text="型号: "></asp:Label>      <asp:LinkButton ID="LinkButton1" runat="server"  Text='<% #Bind("sProductNameCN") %>' CommandName="edit"></asp:LinkButton>  
                    <asp:Label ID="lblxingen" runat="server" Text="Type: "></asp:Label>      <asp:LinkButton ID="LinkButton2" runat="server"  Text='<% #Bind("sProductNameEN") %>' CommandName="edit"></asp:LinkButton>  </td>
                   
                </tr>
            </table>
        </ItemTemplate>

    </asp:DataList>  
              </div> 
             </td>
           <td>
             <div id="demo2"  >
              </div> 
                                
             </td>
         </tr>
     </table>
</div>  

<script type="text/javascript">
    var speed = 10;  //设置图片滚动速度
    demo2.innerHTML = demo1.innerHTML  //复制demo1为demo2
    function Marquee() {
        if (demo2.offsetWidth - demo.scrollLeft <= 0)   //当滚动至demo1与demo2交界时

            demo.scrollLeft -= demo1.offsetWidth     //dome跳到最左端
        else {
            demo.scrollLeft++
        }
    }
    var MyMar = window.setInterval(Marquee, speed)  //设置定时器
    demo.onmouseover = function () { clearInterval(MyMar) }  //鼠标移上时清除定时器达到滚动停止的目的
    demo.onmouseout = function () { MyMar = setInterval(Marquee, speed) } //鼠标移开时重设定时器，继续滚动
      </script>

      </div>

    
</div>

</div>
<div class="divrightwidth">

<div class="divtitle">
<div class="lefttitle"><asp:Label ID="lblnewsTitle" runat="server" Text="Label"></asp:Label></div>
    
    <div class="rightmore"><asp:HyperLink ID="HyperLink1" runat="server" Text="More" 
            style=" margin-right:6px;" Font-Bold="True"  NavigateUrl="~/News.aspx"></asp:HyperLink></div>
   <div style=" clear:both;"></div>
    </div>

    
<div style="margin-top:10px; margin-bottom:10px;">
    
</div>

<div style=" width:100%;">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%" ShowHeader="False" GridLines="None" 
        onrowdatabound="GridView1_RowDataBound" 
        onselectedindexchanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                <table class="newslist">
                <tr>
                <td >
                <asp:Label ID="lblnID" runat="server" Text='<% #bind("nNewsID") %>' Visible="false"></asp:Label>
                
                    <asp:Label ID="Label1" runat="server" Text="●" Font-Size=" 15px" ForeColor="#99cc33"></asp:Label>
                    <asp:LinkButton ID="lbtnnewstitle" runat="server"  Text='<% #bind("sTitle") %>' CommandName="select"></asp:LinkButton>
                
                </td>
                
                <td style="width:75px;">
                <asp:Label ID="lbltime" runat="server" Text='<% #bind("dCreatedTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                
                </td>
                
                </tr>
                
                </table>
                    
                </ItemTemplate>
            </asp:TemplateField>
          
        </Columns>
    </asp:GridView>
</div>

</div>
<div style=" clear:both; border-bottom:2px dotted #ccc; padding-top:10px;  margin-bottom:10px;"></div>
<div class="divleftwidth"  style=" width:100%;">

    
<div style="margin-top:10px; margin-bottom:10px;">
    
</div>

    
</div>

<div style=" clear:both;"></div>



</asp:Content>

