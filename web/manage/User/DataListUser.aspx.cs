using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataListUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReBindPageList();
        }
    }
    public void ReBindPageList()
    {
        DBLL.DBcommon DBc = new DBLL.DBcommon();
        DataTable dt = new DataTable();
        dt = DBc.selectNormalTableofAll(false, "tb_User");
        if (dt != null)
        {
            lvUser.DataSource = dt;
            lvUser.DataBind();
        }
        else
        {
            lvUser.DataSource = null;
            lvUser.DataBind();
        }
    }
    protected void lvUser_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnUserID = (Label)lvUser.Items[e.NewSelectedIndex].FindControl("lblnUserID"); ;
        Response.Redirect("AddDataUser.aspx?nID=" + lblnUserID.Text.Trim());
    }
}