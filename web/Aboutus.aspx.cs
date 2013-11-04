using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Aboutus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnSetLanguage();
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL sys = new DBLL.OptionSysDBLL();
         
            Panel1.Visible = true;
            Panel2.Visible = false;

            Menu1.Items[0].Selected = true;
            if (Session["languageGlobal"] == "en")
            {
                divIntro.InnerHtml = sys.GetOptionValue("en", "SystemSetting", "Introduction");
            }
            else
            {
                divIntro.InnerHtml = sys.GetOptionValue("cn", "SystemSetting", "Introduction");
            }


        }
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        DBLL.OptionSysDBLL sys = new DBLL.OptionSysDBLL();
     switch (e.Item.Value)
	{
        case "1":
            {
                Menu1.Items[0].Selected = true;

               if(Session["languageGlobal"]=="en")
               {
                   divIntro.InnerHtml = sys.GetOptionValue("en", "SystemSetting", "Introduction");
               }
               else
               {
                   divIntro.InnerHtml = sys.GetOptionValue("cn", "SystemSetting", "Introduction");
               }

                
                break;
            }
        case "2":
            {
                Menu1.Items[1].Selected = true;
                if (Session["languageGlobal"] == "en")
                {
                    divIntro.InnerHtml = sys.GetOptionValue("en", "SystemSetting", "Culture");
                }
                else
                {
                    divIntro.InnerHtml = sys.GetOptionValue("cn", "SystemSetting", "Culture");
                }
               
                break;
            }
        case "3":
            {
                Menu1.Items[2].Selected = true;
                if (Session["languageGlobal"] == "en")
                {
                    divIntro.InnerHtml = sys.GetOptionValue("en", "SystemSetting", "CoreTeam");
                }
                else
                {
                    divIntro.InnerHtml = sys.GetOptionValue("cn", "SystemSetting", "CoreTeam");
                }
               
                break;
            }
        case "4":
            {
                Menu1.Items[3].Selected = true;
                if (Session["languageGlobal"] == "en")
                {
                    divIntro.InnerHtml = sys.GetOptionValue("en", "SystemSetting", "Services");
                }
                else
                {
                    divIntro.InnerHtml = sys.GetOptionValue("cn", "SystemSetting", "Services");
                } 
                break;
            }
        case "5":
            {
                Menu1.Items[4].Selected = true;
                Panel1.Visible = false;
                Panel2.Visible = true;
                DBLL.DBcommon dbcom = new DBLL.DBcommon();
                DataTable dt=dbcom.selectNormalTableofAll(false, "tb_FAQs");
                ListView1.DataSource = dt;
                ListView1.DataBind();

                break;
            }
		default:break;
	}  
    }
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Label lblsQuestionCN = (Label)e.Item.FindControl("lblsQuestionCN");
        Label lblsQuestionEN = (Label)e.Item.FindControl("lblsQuestionEN");
        Label lblsAnswerCN = (Label)e.Item.FindControl("lblsAnswerCN");
        Label lblsAnswerEN = (Label)e.Item.FindControl("lblsAnswerEN");


        if (Session["languageGlobal"] == "en")
        {
            lblsQuestionCN.Visible = false;
            lblsQuestionEN.Visible=true;
            lblsAnswerCN.Visible = false;
            lblsAnswerEN.Visible = true;

        }
        else
        {
            lblsQuestionCN.Visible = true;
            lblsQuestionEN.Visible = false;
            lblsAnswerCN.Visible = true;
            lblsAnswerEN.Visible = false;
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
        lbltitle1.Text = langxml.getString("Aboutus", "Label", "lbltitle1");
        lbltitle2.Text = langxml.getString("Aboutus", "Label", "lbltitle2");
        // lblAdd_Education_News.Text = langxml.getString("AddNews", "Label", "lblAdd_Education_News");
        //button
        
        //btnSearch.Text = langxml.getString("MasterPage", "Button", "btnSearch");
        Menu1.Items[0].Text = langxml.getString("Aboutus", "MenuItem", "MenuItem1");
        Menu1.Items[1].Text = langxml.getString("Aboutus", "MenuItem", "MenuItem2");
        Menu1.Items[2].Text = langxml.getString("Aboutus", "MenuItem", "MenuItem3");
        Menu1.Items[3].Text = langxml.getString("Aboutus", "MenuItem", "MenuItem4");
        Menu1.Items[4].Text = langxml.getString("Aboutus", "MenuItem", "MenuItem5");
    }
}