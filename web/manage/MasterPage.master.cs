using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeLoginImage();
            if (Session["UserID"] != null && Session["User"] != null)
            {
                
            }
            else
            {
                //Response.Redirect("~/manage/Login.aspx");
                //lblusername.Text = "admin";
                Session["User"] = "admin";
            }
        }           
    }
    /// <summary>
    /// 鼠标经过改变Login图片按钮的图片
    /// </summary>
    private void ChangeLoginImage()
    {

        ImageButton1.Attributes.Add("onmouseover", "this.src='style/Images/b0001bl.png'");
        ImageButton1.Attributes.Add("onmouseout", "this.src='style/Images/b0001b.png'");
    }
}
