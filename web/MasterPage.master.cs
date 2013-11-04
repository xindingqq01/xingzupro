using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnSetLanguage();
        if(!IsPostBack)
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
        //lblserphone.Text = langxml.getString("MasterPage", "Label", "lblserphone");
        lbtnshoucang.Text = langxml.getString("MasterPage", "Label", "lbtnshoucang");
        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
        lbtncn.Text = langxml.getString("MasterPage", "LinkButton", "lbtncn");
        lbtnen.Text = langxml.getString("MasterPage", "LinkButton", "lbtnen");
        
       // Label1.Text = langxml.getString("MasterPage", "Label", "Label1");

        Menu5.Items[0].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem1");
        Menu5.Items[1].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem2");
        Menu5.Items[2].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem3");
        Menu5.Items[3].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem4");
        Menu5.Items[4].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem5");
        Menu5.Items[5].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem6");
        Menu5.Items[6].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem7");
        Menu5.Items[7].Text = langxml.getString("MasterPage", "MenuItem", "MenuItem8");
    }
    protected void lbtncn_Click(object sender, EventArgs e)
    {
        Session["languageGlobal"] = "cn";
        Response.Redirect(Request.RawUrl);
    }
    protected void lbtnen_Click(object sender, EventArgs e)
    {
        Session["languageGlobal"] = "en";
        Response.Redirect(Request.RawUrl);
    }
}
