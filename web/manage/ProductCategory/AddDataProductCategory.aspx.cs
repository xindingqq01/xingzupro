using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class manage_AddDataProductCategory : System.Web.UI.Page
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
                btnUpdate.Visible = true;
                DBLL.clsProductCategory clProductCategory = new DBLL.clsProductCategory();
                DataTable dt = clProductCategory.Select_tb_ProductCategoryBynProductCategoryID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nProductCategoryID"].ToString();
                    txtsProductCategoryNameCN.Text = dt.Rows[0]["sProductCategoryNameCN"].ToString();
                    txtsProductCategoryNameEN.Text = dt.Rows[0]["sProductCategoryNameEN"].ToString();
                    txtnSorting.Text = dt.Rows[0]["nSorting"].ToString();
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
        //判断session
        if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
        try
        {
            int nID = 0;
            if (int.TryParse(hfID.Value.ToString(), out nID) && nID > 0)
            {
                //更新
                if (ValiEdit())
                {
                    DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                    bool _Result = ProductCategory.update_tb_ProductCategoryBynProductCategoryID(nID, 0, txtsProductCategoryNameCN.Text, txtsProductCategoryNameEN.Text, "", "", Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                    if (_Result == true)
                    {
                        ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "UpdateSuccess");
                        ShowMsg1.Show();
                    }
                    else
                    {
                        //失败就一条
                        ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "UpdateFail");
                        ShowMsg1.Show();
                    }
                }
                else
                {
                    ShowMsg1.Show();
                }
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
            //判断session
            if (Session["User"] == null || Session["User"].ToString().Length < 1) Response.Redirect(Request.RawUrl);
            if (ValiAdd())
            {
                DBLL.clsProductCategory ProductCategory = new DBLL.clsProductCategory();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = ProductCategory.insert_tb_ProductCategory(0, txtsProductCategoryNameCN.Text, txtsProductCategoryNameEN.Text, "", "", Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                if (_Result > 0)
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertSuccess");
                    ShowMsg1.Show();
                    Clear();
                }
                else
                {
                    ShowMsg1.InnerContent = option.GetOptionValue("FormatSetting", "CommandControl", "InsertFail");
                    ShowMsg1.Show();
                }
            }
            else
            {
                ShowMsg1.Show();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        txtnSorting.Text = "1";
        txtsProductCategoryNameCN.Text = "";
        txtsProductCategoryNameEN.Text = "";
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (string.IsNullOrEmpty(txtsProductCategoryNameCN.Text))
        {
            ShowMsg1.InnerContent += "产品类别(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductCategoryNameEN.Text))
        {
            ShowMsg1.InnerContent += "产品类别(英文)不能为空<br/>";
            bcheck = false;
        }

        if (string.IsNullOrEmpty(txtnSorting.Text))
        {
            ShowMsg1.InnerContent += "优先级不能为空<br/>";
            bcheck = false;
        }
        if (!r32.IsMatch(txtnSorting.Text))
        {
            ShowMsg1.InnerContent += "优先级必须填整数<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (string.IsNullOrEmpty(txtsProductCategoryNameCN.Text))
        {
            ShowMsg1.InnerContent += "产品类别(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductCategoryNameEN.Text))
        {
            ShowMsg1.InnerContent += "产品类别(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtnSorting.Text))
        {
            ShowMsg1.InnerContent += "优先级不能为空<br/>";
            bcheck = false;
        }
        if (!r32.IsMatch(txtnSorting.Text))
        {
            ShowMsg1.InnerContent += "优先级必须填整数<br/>";
            bcheck = false;
        }
        return bcheck;
    }
}