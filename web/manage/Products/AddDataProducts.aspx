<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddDataProducts.aspx.cs" Inherits="manage_AddDataProducts" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<%@ Register src="../../usercontrol/MutileUploaderUserControl3.ascx" tagname="MutileUploaderUserControl3" tagprefix="uc2" %>


<%@ Register src="../usercontrol/ddlProductCateTreelist2.ascx" tagname="ddlProductCateTreelist2" tagprefix="uc3" %>


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
                                <asp:Label ID="lblnParentCategoryID" runat="server" Text="产品类别选择"></asp:Label>

                            </td>
                            <td class="SecondCol">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <uc3:ddlProductCateTreelist2 ID="ddlProductCateTreelist21" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>      
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblbHot" runat="server" Text="热门产品"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:CheckBox ID="cbbHot" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductNameCN" runat="server" Text="产品名称(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductNameCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductNameEN" runat="server" Text="产品名称(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductNameEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                        <td class="FirstCol">
                        <asp:Label ID="Label2" runat="server" Text="图片列表"></asp:Label><br />
                            <asp:Button ID="Button1" runat="server" CssClass="btnOrange" Text="清除图片" 
                                onclick="Button1_Click" />
                        </td>
                        <td class="SecondCol">
                           
                            <asp:Image ID="Image3" runat="server" Height="75px" Width="135px" />
                           
                            <asp:Image ID="Image4" runat="server" Visible="False" />
                           
                        </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                            <asp:Label ID="lblsImagePath" runat="server" Text="产品图片"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <uc2:MutileUploaderUserControl3 ID="MutileUploaderUserControl31" 
                                    runat="server" />
                                </td>
                        </tr>
                         <%--<tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSummaryCN" runat="server" Text="产品简介(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsSummaryCN" runat="server" Width="500px" Height="125px" 
                                    TextMode="MultiLine" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSummaryEN" runat="server" Text="产品简介(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsSummaryEN" runat="server" Width="500px" Height="125px" 
                                    TextMode="MultiLine" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                       <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPlaceoforiginCN" runat="server" Text="产地(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPlaceoforiginCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPlaceoforiginEN" runat="server" Text="产地(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPlaceoforiginEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsModelNoCN" runat="server" Text="型号(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsModelNoCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsModelNoEN" runat="server" Text="型号(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsModelNoEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPriceTermsCN" runat="server" Text="价格条款(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPriceTermsCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPriceTermsEN" runat="server" Text="价格条款(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPriceTermsEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPaymentTermsCN" runat="server" Text="付款方式(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPaymentTermsCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPaymentTermsEN" runat="server" Text="付款方式(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPaymentTermsEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPackageCN" runat="server" Text="包装(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPackageCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPackageEN" runat="server" Text="包装(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPackageEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMinimumOrderCN" runat="server" Text="最少起订量(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsMinimumOrderCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMinimumOrderEN" runat="server" Text="最少起订量(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsMinimumOrderEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsDeliveryTimeCN" runat="server" Text="交货时间(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsDeliveryTimeCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsDeliveryTimeEN" runat="server" Text="交货时间(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsDeliveryTimeEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsBrandNameCN" runat="server" Text="品牌名称(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsBrandNameCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsBrandNameEN" runat="server" Text="品牌名称(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsBrandNameEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsEnsitivityCN" runat="server" Text="灵敏度(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsEnsitivityCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsEnsitivityEN" runat="server" Text="灵敏度(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsEnsitivityEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsChannelBalanceCN" runat="server" Text="耳差(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsChannelBalanceCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsChannelBalanceEN" runat="server" Text="耳差(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsChannelBalanceEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsImpedanceCN" runat="server" Text="阻抗(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsImpedanceCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsImpedanceEN" runat="server" Text="阻抗(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsImpedanceEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsFrequencyCN" runat="server" Text="频率范围(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsFrequencyCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsFrequencyEN" runat="server" Text="频率范围(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsFrequencyEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsRatedPowerCN" runat="server" Text="额定功率(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsRatedPowerCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsRatedPowerEN" runat="server" Text="额定功率(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsRatedPowerEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMaximumPowerCN" runat="server" Text="最大功率(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsMaximumPowerCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMaximumPowerEN" runat="server" Text="最大功率(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsMaximumPowerEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>--%>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSummaryCN" runat="server" Text="产品属性(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl3" runat="server" 
                                    AutoGrowMinHeight="150" Height="350" Width="" 
                                  ></CKEditor:CKEditorControl>


                               
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSummaryEN" runat="server" Text="产品属性(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl4" runat="server" 
                                    AutoGrowMinHeight="150" Height="350" Width=""></CKEditor:CKEditorControl>


                               
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentCN" runat="server" Text="产品特性(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" 
                                    AutoGrowMinHeight="400" Height="500px" 
                                  ></CKEditor:CKEditorControl>


                               
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentEN" runat="server" Text="产品特性(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" 
                                    AutoGrowMinHeight="400" Height="500px"></CKEditor:CKEditorControl>


                               
                                <br />
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

