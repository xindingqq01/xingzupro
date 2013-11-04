using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
public partial class manage_AddDataFAQ : System.Web.UI.Page
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
                DBLL.clsFAQs clFAQ = new DBLL.clsFAQs();
                DataTable dt = clFAQ.Select_tb_FAQsBynFAQID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nFAQID"].ToString();
                    txtsQuestionCN.Text = dt.Rows[0]["sQuestionCN"].ToString();
                    txtsQuestionEN.Text = dt.Rows[0]["sQuestionEN"].ToString();
                    txtsAnswerCN.Text = dt.Rows[0]["sAnswerCN"].ToString();
                    txtsAnswerEN.Text = dt.Rows[0]["sAnswerEN"].ToString();
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
                if (Vali())
                {
                    DBLL.clsFAQs clFAQ = new DBLL.clsFAQs();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                    bool _Result = clFAQ.update_tb_FAQsBynFAQID(int.Parse(hfID.Value), txtsQuestionCN.Text, txtsQuestionEN.Text, txtsAnswerCN.Text, txtsAnswerEN.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
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
            if (Vali())
            {
                DBLL.clsFAQs clFAQ = new DBLL.clsFAQs();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = clFAQ.insert_tb_FAQs(txtsQuestionCN.Text, txtsQuestionEN.Text, txtsAnswerCN.Text, txtsAnswerEN.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
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
        txtsQuestionCN.Text = "";
        txtsQuestionEN.Text = "";
        txtsAnswerCN.Text = "";
        txtsAnswerEN.Text = "";
        txtnSorting.Text = "1";
    }
    protected bool Vali()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (string.IsNullOrEmpty(txtsQuestionCN.Text))
        {
            ShowMsg1.InnerContent += "问题(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsQuestionEN.Text))
        {
            ShowMsg1.InnerContent += "问题（英文）不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsAnswerCN.Text))
        {
            ShowMsg1.InnerContent += "答案(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsAnswerEN.Text))
        {
            ShowMsg1.InnerContent += "答案（英文）不能为空<br/>";
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