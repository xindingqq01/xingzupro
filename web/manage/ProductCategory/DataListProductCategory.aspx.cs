using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataListProductCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReBindPageList();
        }
    }
    public void ReBindPageList()
    {
        DBLL.DBcommon DBc = new DBLL.DBcommon();
        DataTable dt = new DataTable();
        dt = DBc.selectNormalTableofAll(false, "tb_ProductCategory");
        if (dt != null)
        {
            lvProductCategory.DataSource = dt;
            lvProductCategory.DataBind();
        }
        else
        {
            lvProductCategory.DataSource = null;
            lvProductCategory.DataBind();
        }
    }
    protected void lvProductCategory_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnProductCategoryID = (Label)lvProductCategory.Items[e.NewSelectedIndex].FindControl("lblnProductCategoryID"); ;
        Response.Redirect("AddDataProductCategory.aspx?nID=" + lblnProductCategoryID.Text.Trim());
    }
    protected void lvProductCategory_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.DBcommon DBc = new DBLL.DBcommon();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    Label lblsProductNameCN = (Label)e.Item.FindControl("lblsProductNameCN");
            //    if (lblsProductNameCN.Text.Length > 10)
            //    {
            //        lblsProductNameCN.Text = lblsProductNameCN.Text.Substring(0, 10).ToString() + "....";
            //    }
            //    Label lblsProductNameEN = (Label)e.Item.FindControl("lblsProductNameEN");
            //    if (lblsProductNameEN.Text.Length > 10)
            //    {
            //        lblsProductNameEN.Text = lblsProductNameEN.Text.Substring(0, 10).ToString() + "....";
            //    }
            //}
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");
            btnDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvProductCategory_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvProductCategory.Items[e.ItemIndex].FindControl("lblnProductCategoryID");
        dbcom.sp_DeleteNormalTableByID(int.Parse(lblnID.Text), "tb_ProductCategory");
        ReBindPageList();
    }
}