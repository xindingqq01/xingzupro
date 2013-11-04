<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddDataJob.aspx.cs" Inherits="manage_AddDataJob" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="rightBigTitle"><asp:Label ID="lblBigtitle" runat="server" Text="添加数据"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
<div class="rightcontent">

<table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobPosition" runat="server" Text="招聘职位(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                 <asp:TextBox ID="txtsJobPosition" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobPositionEN" runat="server" Text="招聘职位(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                 <asp:TextBox ID="txtsJobPositionEN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobAdr" runat="server" Text="工作地点(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobAdr" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobAdrEN" runat="server" Text="工作地点(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobAdrEN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobYear" runat="server" Text="工作经验(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobYear" runat="server" ></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobYearEN" runat="server" Text="工作经验(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobYearEN" runat="server" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobSalary" runat="server" Text="月薪(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobSalary" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobSalaryEN" runat="server" Text="月薪(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobSalaryEN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobEducation" runat="server" Text="学历(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobEducation" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsJobEducationEN" runat="server" Text="学历(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsJobEducationEN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnJobCount" runat="server" Text="招聘人数(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtnJobCount" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnJobCountEN" runat="server" Text="招聘人数(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtnJobCountEN" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsDetails" runat="server" Text="职位详细(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                 <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="400px"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsDetailsEN" runat="server" Text="职位详细(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                 <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" Height="400px"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnSorting" runat="server" Text="优先级"></asp:Label>
                            </td>
                            <td class="SecondCol">
                            <asp:TextBox ID="txtnSorting" runat="server">1</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                            </td>
                            <td class="SecondCol">
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    Text="添加" onclick="BtnAdd_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnOrange" 
                                    Text="修改" onclick="btnUpdate_Click" /><asp:Button ID="BtnClear" 
                                    runat="server" CssClass="btnGreen" Text="清空" onclick="BtnClear_Click"
                                        />
                                <asp:HiddenField ID="hfID" runat="server" />
                            </td>
                        </tr>
                    </table>

                    </div>
</asp:Content>

