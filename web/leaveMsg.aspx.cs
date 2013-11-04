using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Security;
public partial class leaveMsg : ValidateBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnSetLanguage();
        if (!IsPostBack)
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DBLL.clsContact clscon = new DBLL.clsContact();
            int result = clscon.insert_tb_Contact("", txtsName.Text, txtsCompanyName.Text, "", txtsEmail.Text, "", txtsPhone.Text, txtsContent.Text, "", DateTime.Now, "", DateTime.Now, true, 0,
                false, txtsWeb.Text, txtsJob.Text);

            if (txtsVali.Text == base.strValidate)
            {
                if (result > 0)
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
                    ShowMsg1.InnerContent = langxml.getString("leaveMsg", "ShowMsg", "ShowMsgContent");
                    
                    ShowMsg1.Show();
                    Clear();
                }
                else
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
                    ShowMsg1.InnerContent = langxml.getString("leaveMsg", "ShowMsg", "ShowMsgFAILContent");
                    ShowMsg1.Show();
                    Clear();
                }
            }
            else
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
                ShowMsg1.InnerContent = langxml.getString("leaveMsg", "ShowMsg", "ShowMsgFAILVali");
                ShowMsg1.Show();
                Clear();
            }

           
        }
        catch (Exception)
        {
            
            throw;
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
        ShowMsg1.TitleName = langxml.getString("leaveMsg", "ShowMsg", "ShowMsgTitle");
        ShowMsg1.InnerContent = langxml.getString("leaveMsg", "ShowMsg", "ShowMsgContent");
        // lblAdd_Education_News.Text = langxml.getString("AddNews", "Label", "lblAdd_Education_News");
        //button
        lblsCompanyName.Text = langxml.getString("leaveMsg", "Label", "lblsCompanyName");
        lblsContent.Text = langxml.getString("leaveMsg", "Label", "lblsContent");
        lblsEmail.Text = langxml.getString("leaveMsg", "Label", "lblsEmail");
        lblsJob.Text = langxml.getString("leaveMsg", "Label", "lblsJob");
        lblsName.Text = langxml.getString("leaveMsg", "Label", "lblsName");
        lblsPhone.Text = langxml.getString("leaveMsg", "Label", "lblsPhone");
        lblsWeb.Text = langxml.getString("leaveMsg", "Label", "lblsWeb");
        lbltitle.Text = langxml.getString("leaveMsg", "Label", "lbltitle");

        btnSubmit.Text = langxml.getString("leaveMsg", "Button", "btnSubmit");
    }
    public void Clear()
    {
        foreach(Control c in Controls)
        {
            if (c.GetType().Name == "TextBox")
            {
                TextBox txtbox = (TextBox)c;
                txtbox.Text = "";
            }
            
        }
    }
}