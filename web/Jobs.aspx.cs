using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Jobs : System.Web.UI.Page
{
    public DataTable DataTablejob
    {
        set
        {
            Cache.Remove("DataTablejobJobs");
            Cache.Insert("DataTablejobJobs", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTablejobJobs"] == null)
            {
                Cache.Insert("DataTablejobJobs", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTablejobJobs"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            DataPager1.PageSize = 10;
            DataPager2.PageSize = 10;
            DBLL.clsJob clsjob = new DBLL.clsJob();
            DBLL.DBcommon dbcon = new DBLL.DBcommon();
          DataTable dt=  dbcon.selectNormalTableofAll(false, "tb_Jobs");
          DataTablejob = dt;
          lvJobs.DataSource = DataTablejob;
          lvJobs.DataBind();

          PgeInfo();

        
          Panel1.Visible = true;
          Panel2.Visible = false;
          if (DataTablejob == null || DataTablejob.Rows.Count < 1)
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
    public void PgeInfo()
    {
        if (Session["languageGlobal"] == "en")
        {
            lbljobtotal.Text = "Total " + DataTablejob.Rows.Count.ToString() + " Jobs";
            lbleverpage.Text = "EachPage " + DataPager1.PageSize.ToString() + " Jobs";
            lblnpageindex.Text = "Page: " + (DataPager1.StartRowIndex / DataPager1.PageSize + 1).ToString() + "/" +
                (DataTablejob.Rows.Count / DataPager1.PageSize + 1).ToString();

            DataPager2.Visible = true;
            DataPager1.Visible = false;
        }
        else
        {
            lbljobtotal.Text = "共 " + DataTablejob.Rows.Count.ToString() + " 个职位";
            lbleverpage.Text = "每页 " + DataPager1.PageSize.ToString() + " 个";
            lblnpageindex.Text = "页次: " + (DataPager1.StartRowIndex / DataPager1.PageSize + 1).ToString() + "/" +
                (DataTablejob.Rows.Count / DataPager1.PageSize + 1).ToString();

            DataPager2.Visible = false;
            DataPager1.Visible = true;
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

       Label lblsPosition = (Label)this.lvJobs.FindControl("lblsPosition");
       lblsPosition.Text = langxml.getString("Jobs", "GridView", "Head1");
       Label lblsWorkingAddress = (Label)this.lvJobs.FindControl("lblsWorkingAddress");
       lblsWorkingAddress.Text = langxml.getString("Jobs", "GridView", "Head2");
       Label lblsCount = (Label)this.lvJobs.FindControl("lblsCount");
       lblsCount.Text = langxml.getString("Jobs", "GridView", "Head3");
       Label lblsJobYear = (Label)this.lvJobs.FindControl("lblsJobYear");
       lblsJobYear.Text = langxml.getString("Jobs", "GridView", "Head4");



           //GridView1.Columns[0]
        //((lvJobs.FindControl("table") as System.Web.UI.HtmlControls.HtmlTable).Rows[0] as
        //    System.Web.UI.HtmlControls.HtmlTableRow).Cells[0].InnerText = langxml.getString("Jsobs", "GridView", "Head1");
        
      //lblsPosition.Text = langxml.getString("Jsobs", "GridView", "Head1");
        //GridView1.Columns[0].HeaderText = langxml.getString("Jobs", "GridView", "Head1");
        //GridView1.Columns[1].HeaderText = langxml.getString("Jobs", "GridView", "Head2");
        //GridView1.Columns[2].HeaderText = langxml.getString("Jobs", "GridView", "Head3");
        //GridView1.Columns[3].HeaderText = langxml.getString("Jobs", "GridView", "Head4");
       lbltitle.Text = langxml.getString("Jobs", "Label", "lbltitle");
       Label3.Text = langxml.getString("Jobs", "Label", "Label3");
       Label5.Text = langxml.getString("Jobs", "Label", "Label5");
       Label9.Text = langxml.getString("Jobs", "Label", "Label9");
       Label7.Text = langxml.getString("Jobs", "Label", "Label7");
       Label13.Text = langxml.getString("Jobs", "Label", "Label13");
       Label2.Text = langxml.getString("Jobs", "Label", "Label2");
       Label11.Text = langxml.getString("Jobs", "Label", "Label11");
       btnBack.Text = langxml.getString("Jobs", "Button", "btnBack");
    }
    protected void lvJobs_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Label lblsJobPosition = (Label)e.Item.FindControl("lblsJobPosition");
        Label lblsJobPositionEN = (Label)e.Item.FindControl("lblsJobPositionEN");
        Label lblsJobAdr = (Label)e.Item.FindControl("lblsJobAdr");
        Label lblsJobAdrEN = (Label)e.Item.FindControl("lblsJobAdrEN");
        Label lblnJobCount = (Label)e.Item.FindControl("lblnJobCount");
        Label lblnJobCountEN = (Label)e.Item.FindControl("lblnJobCountEN");
        Label lblsJobYearEN = (Label)e.Item.FindControl("lblsJobYearEN");
        Label lblsJobYear = (Label)e.Item.FindControl("lblsJobYear");
        LinkButton lbtnDetailEN = (LinkButton)e.Item.FindControl("lbtnDetailEN");
        LinkButton lbtnDetail = (LinkButton)e.Item.FindControl("lbtnDetail");

        if (Session["languageGlobal"] == "en")
        {
            lblsJobPosition.Visible = false;
            lblsJobPositionEN.Visible = true;
            lblsJobAdr.Visible = false;
            lblsJobAdrEN.Visible = true;
            lblnJobCount.Visible = false;
            lblnJobCountEN.Visible = true;
            lblsJobYear.Visible = false;
            lblsJobYearEN.Visible = true;
            lbtnDetail.Visible = false;
            lbtnDetailEN.Visible = true;

        }
        else
        {
            lblsJobPosition.Visible = true;
            lblsJobPositionEN.Visible = false;
            lblsJobAdr.Visible = true;
            lblsJobAdrEN.Visible = false;
            lblnJobCount.Visible = true;
            lblnJobCountEN.Visible = false;
            lblsJobYear.Visible = true;
            lblsJobYearEN.Visible = false;
            lbtnDetail.Visible = true;
            lbtnDetailEN.Visible = false;
        }
    }
    protected void lvJobs_PagePropertiesChanged(object sender, EventArgs e)
    {
        if (Session["languageGlobal"] == "en")
            DataPager2.SetPageProperties(DataPager2.StartRowIndex, 10, false);
        else
            DataPager1.SetPageProperties(DataPager1.StartRowIndex, 10, false);
        lvJobs.DataSource = DataTablejob;
        lvJobs.DataBind();
        PgeInfo();
    }
    protected void lvJobs_LayoutCreated(object sender, EventArgs e)
    {
       
    }
    protected void lvJobs_ItemEditing(object sender, ListViewEditEventArgs e)
    {
     Label lblnID=(Label)   lvJobs.Items[e.NewEditIndex].FindControl("lblnID");
     int nID = 0;
     if (int.TryParse(lblnID.Text.Trim(), out nID) && nID > 0)
     {
         

         DBLL.clsJob dbjob = new DBLL.clsJob();
       DataTable dtjob=  dbjob.Select_tb_JobBynJobID(nID);
       if (dtjob != null && dtjob.Rows.Count > 0)
       {
           Panel1.Visible = false;
           Panel2.Visible = true;
           if (Session["languageGlobal"] == "en")
           {
               lblsJobPosition.Text = dtjob.Rows[0]["sJobPositionEN"].ToString();
               lblssJobAdr.Text = dtjob.Rows[0]["sJobAdrEN"].ToString();
               lblnJobCount.Text = dtjob.Rows[0]["nJobCountEN"].ToString();
               lblsJobYear.Text = dtjob.Rows[0]["sJobYearEN"].ToString();
               lblsJobSalary.Text = dtjob.Rows[0]["sJobSalaryEN"].ToString();
               lblsJobEducation.Text = dtjob.Rows[0]["sJobEducationEN"].ToString();
               lblsJobTime.Text = dtjob.Rows[0]["sJobYearEN"].ToString();
               divjobdetail.InnerHtml = dtjob.Rows[0]["sDetailsEN"].ToString();
           }
           else
           {
               lblsJobPosition.Text = dtjob.Rows[0]["sJobPosition"].ToString();
               lblssJobAdr.Text = dtjob.Rows[0]["sJobAdr"].ToString();
               lblnJobCount.Text = dtjob.Rows[0]["nJobCount"].ToString();
               lblsJobYear.Text = dtjob.Rows[0]["sJobYear"].ToString();
               lblsJobSalary.Text = dtjob.Rows[0]["sJobSalary"].ToString();
               lblsJobEducation.Text = dtjob.Rows[0]["sJobEducation"].ToString();
               lblsJobTime.Text = dtjob.Rows[0]["sJobYear"].ToString();
               divjobdetail.InnerHtml = dtjob.Rows[0]["sDetails"].ToString();
           }
       }
     }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
}