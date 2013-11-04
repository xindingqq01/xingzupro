using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {



            OnSetLanguage();

            DBLL.OptionSysDBLL sys=new DBLL.OptionSysDBLL();
            DBLL.DBcommon dbcom = new DBLL.DBcommon();
       

            DBLL.clsProduct clspro=new DBLL.clsProduct();
            DataTable dtProduct = clspro.Select_tb_ProductBybHot(true);
            DataList1.DataSource=dtProduct;
            DataList1.DataBind();

            if (Session["languageGlobal"] == "en")
            {
                DataTable dtNews = dbcom.GetDataTable("select top 5 * from tb_News where bEnable=1 and  nLangType=1 order by nSorting desc,dCreatedTime desc");
                GridView1.DataSource = dtNews;
                GridView1.DataBind();
                

               
            }
            else
            {
                DataTable dtNews = dbcom.GetDataTable("select top 5 * from tb_News where bEnable=1 and  nLangType=0 order by nSorting desc,dCreatedTime desc");
                GridView1.DataSource = dtNews;
                GridView1.DataBind();
               
            }
        }
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
        // lblAdd_Education_News.Text = langxml.getString("AddNews", "Label", "lblAdd_Education_News");
        //button

        lbltitleproduct.Text = langxml.getString("Default", "Label", "lbltitleproduct");
        lblnewsTitle.Text = langxml.getString("Default", "Label", "lblnewsTitle");
       
        //lbtnshoucang.Text = langxml.getString("MasterPage", "Label", "lbtnshoucang");
        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton lbtnnewstitle = (LinkButton)e.Row.FindControl("lbtnnewstitle");
            if (lbtnnewstitle.Text.Length > 16)
            {
                lbtnnewstitle.Text = lbtnnewstitle.Text.Substring(0,15)+"...";
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
        {
            lblxingen.Visible = true;
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
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        Label lblnProductID = (Label)e.Item.FindControl("lblnProductID");
        int nProductID = 0;
        if (int.TryParse(lblnProductID.Text, out nProductID) && nProductID > 0)
        {
            Response.Redirect("Product.aspx?nProductID=" + nProductID.ToString());
        }
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Label lblnID = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("lblnID");
        int nNewsID = 0;
        if (int.TryParse(lblnID.Text, out nNewsID) && nNewsID > 0)
        {
            Response.Redirect("News.aspx?nNewsID=" + lblnID.Text.ToString());

          
        }
    }
}