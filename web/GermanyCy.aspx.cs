using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
public partial class GermanyCy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnSetLanguage();
        if (!IsPostBack)
        {

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
        lbltitle.Text = langxml.getString("GermanyCy", "Label", "lbltitle");
        lbltemp.Text = langxml.getString("MasterPage", "Label", "lbltemp");
    }
}