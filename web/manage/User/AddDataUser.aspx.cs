using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_AddDataUser : System.Web.UI.Page
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
                DBLL.clsUser clUser = new DBLL.clsUser();
                DataTable dt = clUser.Select_tb_UserBynUserID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nUserID"].ToString();
                    RadioButtonList2.SelectedValue = dt.Rows[0]["nUserType"].ToString();
                    txtsUsername.Text = dt.Rows[0]["sUsername"].ToString();
                    txtsPassword0.Text = dt.Rows[0]["sPassword"].ToString();
                    txtsPassword1.Text = dt.Rows[0]["sPassword"].ToString();
                    RadioButtonList1.SelectedValue = dt.Rows[0]["nUserSex"].ToString();
                    txtsRealName.Text = dt.Rows[0]["sRealName"].ToString();
                    txtsUserQQ.Text = dt.Rows[0]["sUserQQ"].ToString();
                    txtsUserMSN.Text = dt.Rows[0]["sUserMSN"].ToString();
                    txtsUserPhone.Text = dt.Rows[0]["sUserPhone"].ToString();
                    txtsUserEmail.Text = dt.Rows[0]["sUserEmail"].ToString();
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
                    DBLL.clsUser user = new DBLL.clsUser();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                    bool _Result = user.update_tb_UserBynUserID(nID, txtsUsername.Text, txtsPassword0.Text, txtsRealName.Text, int.Parse(RadioButtonList1.SelectedValue), txtsUserQQ.Text, txtsUserMSN.Text, txtsUserPhone.Text, txtsUserEmail.Text, int.Parse(RadioButtonList2.SelectedValue), Session["user"].ToString(), DateTime.Now, true, 1, true, true);
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
                DBLL.clsUser user = new DBLL.clsUser();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = user.insert_tb_User(txtsUsername.Text, txtsPassword0.Text, txtsRealName.Text, int.Parse(RadioButtonList1.SelectedValue), txtsUserQQ.Text, txtsUserMSN.Text, txtsUserPhone.Text, txtsUserEmail.Text, int.Parse(RadioButtonList2.SelectedValue), Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, 1, true, true);
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
        RadioButtonList2.SelectedIndex = 0;
        txtsUsername.Text = "";
        txtsPassword0.Text = "";
        txtsPassword1.Text = "";
        txtsRealName.Text = "";
        RadioButtonList1.SelectedIndex = 0;
        txtsUserQQ.Text = "";
        txtsUserMSN.Text = "";
        txtsUserPhone.Text = "";
        txtsUserEmail.Text = "";
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsUsername.Text))
        {
            ShowMsg1.InnerContent += "用户名称不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsPassword0.Text))
        {
            ShowMsg1.InnerContent += "为了安全,密码不能为空<br/>";
            bcheck = false;
        }
        if (txtsPassword0.Text != txtsPassword1.Text)
        {
            ShowMsg1.InnerContent += "密码确认不正确<br/>";
            bcheck = false;
        }
        return bcheck;
    }
    protected bool ValiEdit()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        if (string.IsNullOrEmpty(txtsUsername.Text))
        {
            ShowMsg1.InnerContent += "用户登录名称不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsPassword0.Text))
        {
            ShowMsg1.InnerContent += "为了安全,密码不能为空<br/>";
            bcheck = false;
        }
        if (txtsPassword0.Text != txtsPassword1.Text)
        {
            ShowMsg1.InnerContent += "密码确认不正确<br/>";
            bcheck = false;
        }
        return bcheck;
    }
}