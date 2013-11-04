<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Jobs.aspx.cs" Inherits="Jobs" %>

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
    
        <asp:Label ID="Label14" runat="server" Text="未添加数据"></asp:Label>
    
<asp:ListView ID="lvJobs" runat="server" onitemdatabound="lvJobs_ItemDataBound" 
        onpagepropertieschanged="lvJobs_PagePropertiesChanged" 
            onlayoutcreated="lvJobs_LayoutCreated" 
            onitemediting="lvJobs_ItemEditing"  >
        <LayoutTemplate>
            <table cellspacing="0" class="ListViewStyle" >
                <thead>
                    <tr class="ListViewHead">
                        <th>
                            <asp:Label ID="lblsPosition" runat="server" Text="Position"></asp:Label>
                            
                        </th>
                        <th>
                            <asp:Label ID="lblsWorkingAddress" runat="server" Text="WorkingAddress"></asp:Label>
                        </th>
                        <th>
                            <asp:Label ID="lblsCount" runat="server" Text="Count"></asp:Label>
                        </th>
                        <th>
                            <asp:Label ID="lblsJobYear" runat="server" Text="JobYear"></asp:Label>
                        </th>
                        <th>
                             
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
                    <asp:Label ID="lblnID" runat="server" Text='<% #Bind("nJobID") %>' Visible="false"></asp:Label>
                  <asp:Label ID="lblsJobPosition" runat="server" Text='<% #Bind("sJobPosition") %>' ></asp:Label>
                    <asp:Label ID="lblsJobPositionEN" runat="server" Text='<% #Bind("sJobPositionEN") %>'></asp:Label>
                   </td>
                <td>
                     <asp:Label ID="lblsJobAdr" runat="server" Text='<% #Bind("sJobAdr") %>'></asp:Label>
                    <asp:Label ID="lblsJobAdrEN" runat="server" Text='<% #Bind("sJobAdrEN") %>'></asp:Label>
                   </td>
                <td>
                  <asp:Label ID="lblsJobYearEN" runat="server" Text='<% #Bind("sJobYearEN") %>'></asp:Label>
                    <asp:Label ID="lblsJobYear" runat="server" Text='<% #Bind("sJobYear") %>'></asp:Label>
             </td>
                <td>
                <asp:Label ID="lblnJobCount" runat="server" Text='<% #Bind("nJobCount") %>' ></asp:Label>
                     <asp:Label ID="lblnJobCountEN" runat="server" Text='<% #Bind("nJobCountEN")%>'></asp:Label>
                 </td>
                
                <td>
                   <asp:LinkButton ID="lbtnDetailEN" runat="server" Text="Detail"  CommandName="edit"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnDetail" runat="server" Text="详细" CommandName="edit"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <div style=" width:100%; padding:10px 0 10px 0;">
    <div style=" float:left;width:300px; padding-top:28px;">
        <asp:Label ID="lbljobtotal" runat="server" Text="Label"></asp:Label>
&nbsp;
        <asp:Label ID="lbleverpage" runat="server" Text="Label"></asp:Label>
&nbsp;
        <asp:Label ID="lblnpageindex" runat="server" Text="Label"></asp:Label>
        </div>

        <div style=" float:right;  width:450px;padding-top:25px;">
            <asp:DataPager ID="DataPager1" runat="server"
   PagedControlID="lvJobs" PageSize="5">
   <Fields>
      <asp:NextPreviousPagerField FirstPageText="首页"  PreviousPageText="上一页" ShowFirstPageButton="True" 
      
      ButtonType="Button"    ShowNextPageButton="False" ShowPreviousPageButton="true"  ButtonCssClass="btndark"  />
      <asp:NumericPagerField   NumericButtonCssClass="stylenum" CurrentPageLabelCssClass="stylenum"/>
      <asp:NextPreviousPagerField LastPageText="尾页" ShowLastPageButton="True" 
       NextPageText="下一页"      ButtonType="Button" 
             ShowNextPageButton="true" ShowPreviousPageButton="False"   ButtonCssClass="btndark"/>
           
   </Fields>
   
</asp:DataPager>
       <asp:DataPager ID="DataPager2" runat="server"
   PagedControlID="lvJobs" PageSize="5">
   <Fields>
      <asp:NextPreviousPagerField FirstPageText="FirstPage"  PreviousPageText="PreviousPage" ShowFirstPageButton="True" 
      
      ButtonType="Button"    ShowNextPageButton="False" ShowPreviousPageButton="true"  ButtonCssClass="btndark"  />
      <asp:NumericPagerField   NumericButtonCssClass="stylenum" CurrentPageLabelCssClass="stylenum"/>
      <asp:NextPreviousPagerField LastPageText="LastPage" ShowLastPageButton="True" 
       NextPageText="NextPage"      ButtonType="Button" 
             ShowNextPageButton="true" ShowPreviousPageButton="False"   ButtonCssClass="btndark"/>
           
   </Fields>
   
</asp:DataPager>
        </div>

        <div style=" clear:both;"></div>
   </div>
   </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <div style=" width:100%; border-bottom:2px solid #ccc; padding:5px;">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="24px" 
                Font-Bold="True" Visible="False"></asp:Label>
        </div>
        <div>
        <table style=" width:100%;" class="tablejob">
        <tr>
        <td style=" width:350px;">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblsJobPosition" runat="server" Text="Label"></asp:Label>
            </td>
        <td>
           
            </td>

        
        </tr>
        <tr>
        <td>
             <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblssJobAdr" runat="server" Text="Label"></asp:Label>
            </td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblsJobTime" runat="server" Text="Label"></asp:Label>
            </td>
     
        
        </tr>
         <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblnJobCount" runat="server" Text="Label"></asp:Label>
             </td>
        <td>
            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblsJobSalary" runat="server" Text="Label"></asp:Label>
             </td>
     
        
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblsJobEducation" runat="server" Text="Label"></asp:Label>
             </td>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblsJobYear" runat="server" Text="Label"></asp:Label>
             </td>
     
        
        </tr>
        <tr>
        <td colspan="2">
        <div id="divjobdetail" runat="server">
        
        
        </div>
        
        
        </td>
        
        </tr>
        
        <tr>
        <td colspan="2" style=" text-align:center;">
        
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

