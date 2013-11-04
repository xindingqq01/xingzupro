using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn("dwd");
            dt.Columns.Add(col);
            for (int i = 0; i < 6; i++)
            {
                DataRow newrow = dt.NewRow();
                newrow["dwd"] = "5";
                dt.Rows.Add(newrow);
            }
            lvStudent.DataSource = dt;
            lvStudent.DataBind();
        }
    }
    protected void lvStudent_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnUserID = (Label)lvStudent.Items[e.NewSelectedIndex].FindControl("lblnUserID"); ;
        Response.Redirect("AddData.aspx?nID=" + lblnUserID.Text.Trim());
    }
}