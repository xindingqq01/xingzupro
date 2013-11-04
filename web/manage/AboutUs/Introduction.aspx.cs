using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class manage_Introduction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            CKEditorControl1.Text = option.GetOptionValue("cn", "SystemSetting", "Introduction").ToString();
            CKEditorControl2.Text = option.GetOptionValue("en", "SystemSetting", "Introduction").ToString();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //判断session
            if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                option.UpdateOptionValue("cn", "SystemSetting", "Introduction", CKEditorControl1.Text);
                option.UpdateOptionValue("en", "SystemSetting", "Introduction", CKEditorControl2.Text);
                ShowMsg1.InnerContent = "更新成功!";
                ShowMsg1.Show();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //protected bool ValiAdd()
    //{
    //    bool bcheck = true;
    //    ShowMsg1.InnerContent = "";
    //    Regex r32 = new Regex(@"^[\d]+$");
    //    if (!r32.IsMatch(txtnSorting.Text))
    //    {
    //        ShowMsg1.InnerContent += "优先级必须填整数<br/>";
    //        bcheck = false;
    //    }
    //    return bcheck;
    //}
}