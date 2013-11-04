using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnSetLanguage();
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL sys = new DBLL.OptionSysDBLL();
            //if (Session["languageGlobal"] == "en")
            //{
            //    contactdetail.InnerHtml = sys.GetOptionValue("en", "SystemSetting", "ContactUs");
            //}
            //else
            //{
            //    contactdetail.InnerHtml = sys.GetOptionValue("cn", "SystemSetting", "ContactUs");
            //}
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



        lbltitle.Text = langxml.getString("ContactUs", "Label", "lbltitle");

        lblsAddrtitle.Text = langxml.getString("Default", "Label", "lblsAddrtitle");
        lblsAddr.Text = langxml.getString("Default", "Label", "lblsAddr");
        lblsPhonetitle.Text = langxml.getString("Default", "Label", "lblsPhonetitle");
        lblsPhone.Text = langxml.getString("Default", "Label", "lblsPhone");
        lblsFaxtitle.Text = langxml.getString("Default", "Label", "lblsFaxtitle");
        lblsFax.Text = langxml.getString("Default", "Label", "lblsFax");
        lblsWebtitle.Text = langxml.getString("Default", "Label", "lblsWebtitle");
        lblsWeb.Text = langxml.getString("Default", "Label", "lblsWeb");
        lblsEmailtitle.Text = langxml.getString("Default", "Label", "lblsEmailtitle");
        lblsEmail.Text = langxml.getString("Default", "Label", "lblsEmail");
        lblcontitle1.Text = langxml.getString("Default", "Label", "lblcontitle1");
        lblcontitle2.Text = langxml.getString("Default", "Label", "lblcontitle2");
        lblcontitle3.Text = langxml.getString("Default", "Label", "lblcontitle3");
        lblcontitle4.Text = langxml.getString("Default", "Label", "lblcontitle4");
    }
}