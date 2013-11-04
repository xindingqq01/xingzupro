using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Partners : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            OnSetLanguage();
            DBLL.DBcommon dbcon = new DBLL.DBcommon();
         DataTable dt=   dbcon.selectNormalTableofAll(false, "tb_Partners");
         DataList1.DataSource = dt;
         DataList1.DataBind();

         if (dt == null || dt.Rows.Count < 1)
         {
             Label14.Visible = true;
         }
         else
         {
             Label14.Visible = false;
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
        lbltitle.Text = langxml.getString("Partners", "Label", "lbltitle");
        Label14.Text = langxml.getString("Partners", "Label", "Label14");
        // lblAdd_Education_News.Text = langxml.getString("AddNews", "Label", "lblAdd_Education_News");
        //button

        
    }
}