<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="manage_Login" %>

<%@ Register src="usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>chenen</title>
    <link href="style/Login.css" rel="stylesheet" type="text/css" />
    <link href="style/ShowMessage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    <div id="loginpanelwrap">
  	
	<div class="loginheader">
    <div class="logintitle"><a href="#">承恩企业网站后台</a></div>
    </div>

     
    <div class="loginform">
        
        <div class="loginform_row">
        <asp:Label ID="Label1" runat="server" Text="Username:" CssClass="loginform_rowlabel"></asp:Label>
         <asp:TextBox ID="txtUsername" class="loginform_input" runat="server"   maxlength="128"  ></asp:TextBox>
        </div>
        <div class="loginform_row">
        <asp:Label ID="Label2" runat="server" Text="Password:" CssClass="loginform_rowlabel"></asp:Label>
        
        <asp:TextBox ID="txtPassword" class="loginform_input" runat="server"   maxlength="128" ></asp:TextBox>
        
        </div>
        <div class="loginform_rowBottom">
            <asp:Button ID="btnSubmit" runat="server"   onclick="ibtnLogin_Click" class="loginform_submit" Text="Log In"/>
        </div> 
        <div class="clear"></div>
    </div>
 

</div>

   


    <%--<div  class="divLoginMain">
  
<div id="login-box">

<H2><asp:Image ID="Image1" runat="server" ImageUrl="~/style/images/LOGOHD.png" 
        Width="300px" /></H2>
点击登陆，进入到我们的家园
<br />

<div id="login-box-name" style="margin-top:20px;">用户名:</div>
<div id="login-box-field" style="margin-top:20px;">
  </div>
<div id="login-box-name">密码:</div>

<div id="login-box-field"> 
</div>
<br />
<span class="login-box-options"><input type="checkbox" name="1" value="1"> Remember Me <a href="#" style="margin-left:30px;">Forgot password?</a></span>
<br />


    <asp:ImageButton ID="ibtnLogin" runat="server"  
        ImageUrl="~/style/images/login-btn.png" onclick="ibtnLogin_Click" />
    <uc1:ShowMsg ID="ShowMsg1" runat="server" />
</div>


</div>--%>

    </form>
</body>
</html>
