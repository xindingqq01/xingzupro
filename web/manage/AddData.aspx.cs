using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_AddData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int nID=0;
            if (Request.QueryString["nID"] != null && int.TryParse(Request.QueryString["nID"].ToString(), out  nID) && nID > 0)
            {
                lblBigtitle.Text = "编辑数据";
                BtnAdd.Visible = false;
                btnUpdate.Visible = false;
                DBLL.clsProduct clsp = new DBLL.clsProduct();
              DataTable dt=  clsp.Select_tb_ProductBynProductID(nID);
                if(dt!=null&&dt.Rows.Count>0)
                {
                    hfID.Value = dt.Rows[0]["nProductID"].ToString();
                    txtsGroupName.Text = dt.Rows[0]["nProductID"].ToString();
                    //绑定数据
                }
                
            }
            else
            {
                lblBigtitle.Text = "添加数据";
                btnUpdate.Visible = false;
                BtnAdd.Visible = true;
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int nID = 0;
            if (int.TryParse(hfID.Value.ToString(), out nID) && nID > 0)
            {
                //更新
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception)
        {

            throw;
        }
    }
}