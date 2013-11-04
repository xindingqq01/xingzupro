using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class News : System.Web.UI.Page
{
    public DataTable DataTableNews
    {
        set
        {
            Cache.Remove("DataTableNews");
            Cache.Insert("DataTableNews", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTableNews"] == null)
            {
                Cache.Insert("DataTableNews", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTableNews"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

          
            DBLL.clsJob clsjob = new DBLL.clsJob();
            DBLL.DBcommon dbcon = new DBLL.DBcommon();

            BindData();
            lblcur.Text = (lvNews.PageIndex + 1).ToString();
            lbltotal.Text = lvNews.PageCount.ToString();

            int nNewsID=0;
            if (Request.QueryString["nNewsID"] != null && int.TryParse(Request.QueryString["nNewsID"].ToString(), out nNewsID) && nNewsID>0)
            {
                DBLL.clsNews clsnews = new DBLL.clsNews();
                DataTable dtnewsone = clsnews.Select_tb_NewsBynNewsID(nNewsID);
                if (dtnewsone != null && dtnewsone.Rows.Count > 0)
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Label1.Text = dtnewsone.Rows[0]["sTitle"].ToString();
                    lblsAuthor.Text = dtnewsone.Rows[0]["sAuthor"].ToString();
                    lblsCreatedBy.Text = dtnewsone.Rows[0]["dCreatedTime"].ToString();
                    Image1.ImageUrl = dtnewsone.Rows[0]["sImagePath"].ToString();
                    if (Image1.ImageUrl == "")
                    {
                        Image1.Visible = false;
                    }
                    divNewsdetail.InnerHtml = dtnewsone.Rows[0]["sContent"].ToString();
                }
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }


            
            if (DataTableNews == null || DataTableNews.Rows.Count < 1)
            {
                Label14.Visible = true;
            }
            else
            {
                Label14.Visible = false;
            }
        }
        OnSetLanguage();

    }
    public void BindData()
    {
        DBLL.DBcommon dbcon = new DBLL.DBcommon();
        if (Session["languageGlobal"] == "en")
        {
            DataTable dtNews = dbcon.GetDataTable("select  * from tb_News where bEnable=1 and  nLangType=1 order by nSorting desc,dCreatedTime desc");
            DataTableNews = dtNews;
            lvNews.DataSource = DataTableNews;
            lvNews.PageSize = 12;
            lvNews.DataBind();



        }
        else
        {
            DataTable dtNews = dbcon.GetDataTable("select  * from tb_News where bEnable=1 and  nLangType=0 order by nSorting desc,dCreatedTime desc");
            DataTableNews = dtNews;
            lvNews.DataSource = DataTableNews;
            lvNews.PageSize = 12;
            lvNews.DataBind();

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

       



        //GridView1.Columns[0]
        //((lvJobs.FindControl("table") as System.Web.UI.HtmlControls.HtmlTable).Rows[0] as
        //    System.Web.UI.HtmlControls.HtmlTableRow).Cells[0].InnerText = langxml.getString("Jsobs", "GridView", "Head1");

        //lblsPosition.Text = langxml.getString("Jsobs", "GridView", "Head1");
        //GridView1.Columns[0].HeaderText = langxml.getString("Jobs", "GridView", "Head1");
        //GridView1.Columns[1].HeaderText = langxml.getString("Jobs", "GridView", "Head2");
        //GridView1.Columns[2].HeaderText = langxml.getString("Jobs", "GridView", "Head3");
        //GridView1.Columns[3].HeaderText = langxml.getString("Jobs", "GridView", "Head4");
        lbltitle.Text = langxml.getString("Default", "Label", "lblnewsTitle");
        lblCurtitle.Text = langxml.getString("Product", "Label", "lblCurtitle");
        //Label3.Text = langxml.getString("News", "Label", "Label3");
        //Label5.Text = langxml.getString("News", "Label", "Label5");
        //Label9.Text = langxml.getString("News", "Label", "Label9");
        //Label7.Text = langxml.getString("News", "Label", "Label7");
        //Label13.Text = langxml.getString("Jobs", "Label", "Label13");
        //Label2.Text = langxml.getString("Jobs", "Label", "Label2");
        //Label11.Text = langxml.getString("Jobs", "Label", "Label11");
        btnBack.Text = langxml.getString("Jobs", "Button", "btnBack");
    }
    
   
  
   
    protected void btnBack_Click(object sender, EventArgs e)
    {
      //  Panel1.Visible = true;
      //  Panel2.Visible = false;
        Response.Redirect("News.aspx");
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        if (lvNews.PageIndex > 1)
        {
            lvNews.PageIndex = lvNews.PageIndex - 1;
            BindData();
            lblcur.Text = (lvNews.PageIndex ).ToString();
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (lvNews.PageIndex < lvNews.PageCount)
        {
            lvNews.PageIndex = lvNews.PageIndex + 1;
            BindData();
            lblcur.Text = (lvNews.PageIndex ).ToString();
        }
    }
    protected void lvNews_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Label lblnID = (Label)lvNews.Rows[e.NewSelectedIndex].FindControl("lblnID");
        int nNewsID = 0;
        if (int.TryParse(lblnID.Text, out nNewsID) && nNewsID > 0)
        {
            

            DBLL.clsNews clsnews = new DBLL.clsNews();
          DataTable dtnewsone=  clsnews.Select_tb_NewsBynNewsID(nNewsID);
          if (dtnewsone != null && dtnewsone.Rows.Count > 0)
          {
              Panel1.Visible = false;
              Panel2.Visible = true;
              Label1.Text = dtnewsone.Rows[0]["sTitle"].ToString();
              lblsAuthor.Text = dtnewsone.Rows[0]["sAuthor"].ToString();
              lblsCreatedBy.Text = dtnewsone.Rows[0]["dCreatedTime"].ToString();
              Image1.ImageUrl = dtnewsone.Rows[0]["sImagePath"].ToString();
              if (Image1.ImageUrl == "")
              {
                  Image1.Visible = false;
              }
              divNewsdetail.InnerHtml = dtnewsone.Rows[0]["sContent"].ToString();
          }
        }
    }
    protected void lvNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton lbtnnewstitle = (LinkButton)e.Row.FindControl("lbtnnewstitle");
            if (lbtnnewstitle.Text.Length > 80)
            {
                lbtnnewstitle.Text = lbtnnewstitle.Text.Substring(0, 80) + "......";
            }
        }
    }
}