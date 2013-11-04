using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
public partial class manage_DataListProduct : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_Product"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_Product"] == null)
                ViewState["nPageRowCounmanage_Product"] = 8;
            return (int)ViewState["nPageRowCounmanage_Product"];
        }
    }
    public DataTable DataTableProduct
    {
        set
        {
            Cache.Remove("DataTableProduct");
            Cache.Insert("DataTableProduct", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTableProduct"] == null)
            {
                Cache.Insert("DataTableProduct", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTableProduct"];
        }
    }
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
        DataTable dtProductCate = new DataTable();
        dtProductCate = DBc.selectNormalTableofAll(false, "tb_ProductCategory");
        if (dtProductCate != null)
        {
            ddlProductCateTreelist21.ProductList = dtProductCate;
        }
        dt = DBc.selectNormalTableofAll(false, "tb_Product");
        if (dt != null)
        {
            DataTableProduct.Merge(dt);
            lvProduct.DataSource = dt;
            lvProduct.DataBind();
        }
        else
        {
            lvProduct.DataSource = null;
            lvProduct.DataBind();
        }
    }
    protected void lvProduct_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnProductID = (Label)lvProduct.Items[e.NewSelectedIndex].FindControl("lblnProductID"); ;
        Response.Redirect("AddDataProducts.aspx?nID=" + lblnProductID.Text.Trim());
    }
    protected void lvProduct_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        DBLL.clsPartners clPartners = new DBLL.clsPartners();
        DBLL.clsProduct clProduct = new DBLL.clsProduct(); 
        Label lblnID = (Label)lvProduct.Items[e.ItemIndex].FindControl("lblnProductID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            bool Result = dbcom.sp_DeleteNormalTableByID2(int.Parse(lblnID.Text), "tb_Product");
            if (Result)
            {
                //判断文件是不是存在
                DataTable dsPro = clProduct.Select_tb_ProductBynProductIDEnable(_nID);
                if (dsPro.Rows.Count > 0)
                {
                    //Image ImsImagePath = (Image)lvProduct.Items[e.ItemIndex].FindControl("sPImagePath");
                    //string sSaveFolderFullPath = Server.MapPath(ImsImagePath.ImageUrl);
                    string sSaveFolderFullPath = Server.MapPath(dsPro.Rows[0]["sPImagePath"].ToString());
                    if (File.Exists(sSaveFolderFullPath))
                    {
                        //如果存在则删除
                        File.Delete(sSaveFolderFullPath);
                    }

                    //Image ImsImagePath2 = (Image)lvProduct.Items[e.ItemIndex].FindControl("sThumbPath");
                    //string sSaveFolderFullPath2 = Server.MapPath(ImsImagePath2.ImageUrl);
                    string sSaveFolderFullPath2 = Server.MapPath(dsPro.Rows[0]["sThumbPath"].ToString());
                    if (File.Exists(sSaveFolderFullPath2))
                    {
                        //如果存在则删除
                        File.Delete(sSaveFolderFullPath2);
                    }
                }
            }
            ReBindPageList();
        }
    }
    protected void lvProduct_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.DBcommon DBc = new DBLL.DBcommon(); 
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblsProductNameCN = (Label)e.Item.FindControl("lblsProductNameCN");
                if (lblsProductNameCN.Text.Length > 10)
                {
                    lblsProductNameCN.Text = lblsProductNameCN.Text.Substring(0, 10).ToString() + "....";
                }
                Label lblsProductNameEN = (Label)e.Item.FindControl("lblsProductNameEN");
                if (lblsProductNameEN.Text.Length > 10)
                {
                    lblsProductNameEN.Text = lblsProductNameEN.Text.Substring(0, 10).ToString() + "....";
                }
            }
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");
            btnDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvProduct_PagePropertiesChanged(object sender, EventArgs e)
    {
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true);
        lvProduct.DataSource = DataTableProduct;
        lvProduct.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sSearch = txtSearch.Text;
        DBLL.clsProduct clspdc = new DBLL.clsProduct();
        DBLL.DBcommon DBc = new DBLL.DBcommon();
        DataTable dtpdc = new DataTable();
        if (ddlProductCateTreelist21.nSelectProductCategoryID > 0)
        {
            dtpdc = clspdc.Select_tb_ProductBynParentCategoryID(ddlProductCateTreelist21.nSelectProductCategoryID);
        }
        else dtpdc = DBc.selectNormalTableofAll(false, "tb_Product");
        if (dtpdc != null && dtpdc.Rows.Count > 0)
        {
            DataTable dtSearchpdc = new DataTable();
            string cmd = "sProductNameCN like '%" + sSearch + "%' ";
            cmd += " or ";
            cmd += "sProductNameEN like '%" + sSearch + "%' ";
            //cmd += "sSummaryCN like '%" + sSearch + "%' ";
            //cmd += " or ";
            //cmd += "sSummaryEN like '%" + sSearch + "%' ";
            DataRow[] rows = dtpdc.Select(cmd);

            foreach (DataColumn col in dtpdc.Columns)
            {
                dtSearchpdc.Columns.Add(col.ColumnName.ToString());
            }
            foreach (DataRow row in rows)
            {
                dtSearchpdc.Rows.Add(row.ItemArray);
            }
            //ProductList = new Model.dsProduct.tb_ProductDataTable();
            //ProductList.Merge(dtSearchpdc);
            lvProduct.DataSource = dtSearchpdc;
            lvProduct.DataBind();
        }
        //else
        //{
            //dtpdc = DBc.selectNormalTableofAll(false, "tb_Product");
            //if (dtpdc != null && dtpdc.Rows.Count > 0)
            //{
            //lvProduct.DataSource = null;
            //lvProduct.DataBind();
            //}
        //}
    }
}