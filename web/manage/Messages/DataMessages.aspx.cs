using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataMessages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int nID=0;
            if (Request.QueryString["nID"] != null && int.TryParse(Request.QueryString["nID"].ToString(), out  nID) && nID > 0)
            {
                lblBigtitle.Text = "留言明细";
                DBLL.clsContact clContact = new DBLL.clsContact();
                DataTable dt = clContact.Select_tb_ContactBynContactID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nContactID"].ToString();
                    txtsName.Text = dt.Rows[0]["sName"].ToString();
                    txtsCompanyName.Text = dt.Rows[0]["sCompanyName"].ToString();
                    txtsPhone.Text = dt.Rows[0]["sPhone"].ToString();
                    txtsPositon.Text = dt.Rows[0]["sPositon"].ToString();
                    txtsEmail.Text = dt.Rows[0]["sEmail"].ToString();
                    txtsWeb.Text = dt.Rows[0]["sWeb"].ToString();
                    txtsContent.Text = dt.Rows[0]["sContents"].ToString();
                    //绑定数据
                }
                try
                {
                    bool _Result = clContact.update_tb_ContactBynContactID(nID,  true);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("DataListMessages.aspx");
        }
        catch (Exception)
        {
            throw;
        }
    }
}