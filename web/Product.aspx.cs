using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Product : System.Web.UI.Page
{
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
    public int nCurrentProductPage
    {
      
        set
        {
            if (value < 1) ViewState["nCurrentProductPage"] = 1;
            else  ViewState["nCurrentProductPage"] = value;
        }
        get
        {
            if (ViewState["nCurrentProductPage"] == null)
                ViewState["nCurrentProductPage"] = 1;
            return (int)ViewState["nCurrentProductPage"];
        }
    
    }
    protected void Page_Load(object sender, EventArgs e)
    {
         OnSetLanguage();
         if (!IsPostBack)
         {
             
             Panel1.Visible = true;
             Panel2.Visible = false;
             DBLL.clsProductCategory clspc = new DBLL.clsProductCategory();
             DBLL.DBcommon dbcom = new DBLL.DBcommon();
             DataTable dtProductCategory = dbcom.selectNormalTableofAll(false,"tb_ProductCategory");

             
             DBLL.TreeViewFromTableBLL tvfbll = new DBLL.TreeViewFromTableBLL();


             tvfbll.nRootParentID = 0;
             tvfbll.FatherIDColumnName = dtProductCategory.Columns["nParentCategoryID"].ColumnName;
             //   tvfbll.NavigateUrlColumnName = "ProductList.aspx?nProductCategoryIDColumn=" + pcdt.nProductCategoryIDColumn.ColumnName;
             tvfbll.NodeValueColumnName = dtProductCategory.Columns["nProductCategoryID"].ColumnName;
             if (Session["languageGlobal"] == "en") tvfbll.NodeTextColumnName = dtProductCategory.Columns["sProductCategoryNameEN"].ColumnName;
             else tvfbll.NodeTextColumnName = dtProductCategory.Columns["sProductCategoryNameCN"].ColumnName;
             tvfbll.bIsClick = true;


             TreeNode[] nodepages = tvfbll.GetTreeNodes(dtProductCategory);
             TreeView1.Nodes.Clear();
             if (nodepages != null && nodepages.Length > 0)
             {
                 for (int i = 0; i < nodepages.Length; i++)
                 {
                     if (nodepages[i].Text.Length > 18)
                     {
                         nodepages[i].ToolTip = nodepages[i].Text;
                         nodepages[i].Text = nodepages[i].Text.Substring(0, 18) + "...";

                     }
                     TreeView1.Nodes.Add(nodepages[i]);
                 }
             }
             TreeView1.ExpandDepth = 1;



             DataTable dtProduct = dbcom.selectNormalTableofAll(false, "tb_Product");
             DataTableProduct = dtProduct;
             BindProductData(dtProduct);


             string sMenuname = "";
             if (Session["languageGlobal"] == "en")
             {
                 sMenuname = "sProductCategoryNameEN";
             }
             else
             {
                 sMenuname = "sProductCategoryNameCN";
             }
             if (dtProductCategory!=null&& dtProductCategory.Rows.Count>0)
             {
             foreach (DataRow row in dtProductCategory.Rows)
             {
                 MenuItem menuitem1 = new MenuItem(row[sMenuname].ToString(), row["nProductCategoryID"].ToString(), "~/style/images/newsfront.gif");
                 Menu1.Items.Add(menuitem1);
             }
             }

             int nProductID = 0;
             if (Request.QueryString["nProductID"] != null && int.TryParse(Request.QueryString["nProductID"], out nProductID))
             {
                 if (nProductID > 0)
                 {
                     Bind(nProductID);
                 }
             }
         }
    }


    public void BindProductData(DataTable dtProduct)
    {
        //int curpage = 20;
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dtProduct.DefaultView;
        ps.AllowPaging = true;
        ps.PageSize = 18;
        ps.CurrentPageIndex = nCurrentProductPage - 1;
        lblcur.Text = nCurrentProductPage.ToString();
        lbltotal.Text = ((dtProduct.Rows.Count + ps.PageSize-1) / ps.PageSize).ToString();
        DataList1.DataSource = ps;
        DataList1.DataBind();
    }
    public void OnSetLanguage()
    {
        string xmlfilepath = ConfigurationManager.AppSettings["xmlfilepath"].ToString();
        if (Session["languageGlobal"] != null)
        {
            xmlfilepath = xmlfilepath.Replace("[filename]", Session["languageGlobal"].ToString());

        }
        else
        {
            xmlfilepath = xmlfilepath.Replace("[filename]", "cn");


        }
        clslang langxml = new clslang(xmlfilepath);
        langxml.XmlLoad();

        //Label
        lbltitle1.Text = langxml.getString("Product", "Label", "lbltitle1");
        lbltitle2.Text = langxml.getString("Product", "Label", "lbltitle2");
        lbltitle.Text = langxml.getString("Product", "Label", "lbltitle");
        lblCurtitle.Text = langxml.getString("Product", "Label", "lblCurtitle");
        lblProductCatetitle.Text = langxml.getString("Product", "Label", "lblProductCatetitle");
        lblsBrandNametitle.Text = langxml.getString("Product", "Label", "lblsBrandNametitle");
        //lblSensitivitytitle.Text = langxml.getString("Product", "Label", "lblSensitivity");
        //lblchannelbalancetitle.Text = langxml.getString("Product", "Label", "lblchannelbalance");
        //lblimpedancetitle.Text = langxml.getString("Product", "Label", "lblimpedance");
        //lblfrequencyrangetitle.Text = langxml.getString("Product", "Label", "lblfrequencyrange");
        //lblratedpowertitle.Text = langxml.getString("Product", "Label", "lblratedpower");
        //lblmaximumpowertitle.Text = langxml.getString("Product", "Label", "lblmaximumpower");
        // lblAdd_Education_News.Text = langxml.getString("AddNews", "Label", "lblAdd_Education_News");
        //button

        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
       
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < this.TreeView1.Nodes.Count; i++)
        //{//跌迭根节点
        //    if (this.TreeView1.SelectedNode.Parent == null)
        //    {
        //        if (this.TreeView1.SelectedValue == this.TreeView1.Nodes[i].Value)
        //        {//如果选中的是根节点,就展开

        //            this.TreeView1.SelectedNode.Expanded = true;

        //        }
        //        else
        //        {//如果选中的不是根节点

        //            this.TreeView1.Nodes[i].NavigateUrl = "";
        //            this.TreeView1.Nodes[i].Expanded = false;

        //        }
        //    }
        //}
        int _nProID = 0;
        if (int.TryParse(this.TreeView1.SelectedValue, out _nProID) && _nProID > 0)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            DBLL.clsProduct pro=new DBLL.clsProduct();
            DataTable dtProduct = pro.Select_tb_ProductBynParentCategoryID(_nProID);
            if (dtProduct != null) DataTableProduct = dtProduct;
            else DataTableProduct = new DataTable();
            BindProductData(DataTableProduct);
        }
       // TreeView1.SelectedNode.NavigateUrl = "Product.aspx?nSelelctProductCateID=" + TreeView1.SelectedNode.Value;
     
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        nCurrentProductPage--;
        BindProductData(DataTableProduct);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        nCurrentProductPage++;
        BindProductData(DataTableProduct);
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        Label lblnProductID = (Label)e.Item.FindControl("lblnProductID");
        int nProductID = 0;
       if (int.TryParse(lblnProductID.Text, out nProductID) && nProductID > 0)
        {
            Bind(nProductID);
       }
    }
    public void Bind(int nProductID)
    {
        


            DBLL.clsProduct clspro = new DBLL.clsProduct();
            DBLL.clsProductCategory clsprocate = new DBLL.clsProductCategory();
            DataTable dtpro = clspro.Select_tb_ProductBynProductID(nProductID);
            if (dtpro != null && dtpro.Rows.Count > 0)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                DataRow dtprorow = dtpro.Rows[0];
                DataTable dtprocate = clsprocate.Select_tb_ProductCategoryBynProductCategoryID(int.Parse(dtprorow["nProductCategoryID"].ToString()));
                if (Session["languageGlobal"] == "en")
                {
                    lblProductName.Text = dtprorow["sProductNameEN"].ToString();
                    lblProductCate.Text = dtprocate.Rows[0]["sProductCategoryNameEN"].ToString();
                    lblsBrandName.Text = dtprorow["sBrandNameEN"].ToString();
                    divProductInfo.InnerHtml = dtprorow["sIntroEN"].ToString();
                    divProductCate.InnerHtml = dtprorow["sSummaryEN"].ToString();
                    IMGbig.ImageUrl = dtprorow["sPImagePath"].ToString();
                    //lblSensitivity.Text = dtprorow["sEnsitivityCN"].ToString();
                    //lblchannelbalance.Text = dtprorow["sChannelBalanceCN"].ToString();
                    //lblimpedance.Text = dtprorow["sImpedanceCN"].ToString();
                    //lblfrequencyrange.Text = dtprorow["sFrequencyCN"].ToString();
                    //lblratedpower.Text = dtprorow["sRatedPowerCN"].ToString();
                    //lblmaximumpower.Text = dtprorow["sMaximumPowerCN"].ToString();
                }
                else
                {
                    lblProductName.Text = dtprorow["sProductNameCN"].ToString();
                    lblProductCate.Text = dtprocate.Rows[0]["sProductCategoryNameCN"].ToString();
                    lblsBrandName.Text = dtprorow["sBrandNameCN"].ToString();
                    divProductInfo.InnerHtml = dtprorow["sIntroCN"].ToString();
                    divProductCate.InnerHtml = dtprorow["sSummaryCN"].ToString();
                    IMGbig.ImageUrl = dtprorow["sPImagePath"].ToString();
                    //lblSensitivity.Text = dtprorow["sEnsitivityEN"].ToString();
                    //lblchannelbalance.Text = dtprorow["sChannelBalanceEN"].ToString();
                    //lblimpedance.Text = dtprorow["sImpedanceEN"].ToString();
                    //lblfrequencyrange.Text = dtprorow["sFrequencyEN"].ToString();
                    //lblratedpower.Text = dtprorow["sRatedPowerEN"].ToString();
                    //lblmaximumpower.Text = dtprorow["sMaximumPowerEN"].ToString();
                }


            }
        
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lblxingcn = (Label)e.Item.FindControl("lblxingcn");

        Label lblxingen = (Label)e.Item.FindControl("lblxingen");
        LinkButton LinkButton1 = (LinkButton)e.Item.FindControl("LinkButton1");
        LinkButton LinkButton2 = (LinkButton)e.Item.FindControl("LinkButton2");
        if (Session["languageGlobal"] == "en")
        { lblxingen.Visible = true;
        lblxingcn.Visible = false;
        LinkButton1.Visible = false;
        LinkButton2.Visible = true;
        
        
        }
        else
        {
            lblxingen.Visible = false;
            lblxingcn.Visible = true;
            LinkButton1.Visible = true;
            LinkButton2.Visible = false;
        }
        if (LinkButton1.Text.Length > 10)
        {
            LinkButton1.ToolTip = LinkButton1.Text;
            LinkButton1.Text = LinkButton1.Text.Substring(0, 10) + "....";
        }
        if (LinkButton2.Text.Length > 15)
        {
            LinkButton2.ToolTip = LinkButton1.Text;
            LinkButton2.Text = LinkButton1.Text.Substring(0, 15) + "....";
        }
    }
}