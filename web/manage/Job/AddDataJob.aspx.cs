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
public partial class manage_AddDataJob : System.Web.UI.Page
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
                DBLL.clsJob clJob = new DBLL.clsJob();
                DataTable dt = clJob.Select_tb_JobBynJobID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nJobID"].ToString();
                    txtsJobPosition.Text = dt.Rows[0]["sJobPosition"].ToString();
                    txtsJobAdr.Text = dt.Rows[0]["sJobAdr"].ToString();
                    txtnJobCount.Text = dt.Rows[0]["nJobCount"].ToString();
                    CKEditorControl1.Text = dt.Rows[0]["sDetails"].ToString();
                    txtsJobYear.Text = dt.Rows[0]["sJobYear"].ToString();
                    txtsJobSalary.Text = dt.Rows[0]["sJobSalary"].ToString();
                    txtsJobEducation.Text = dt.Rows[0]["sJobEducation"].ToString();
                    txtsJobPositionEN.Text = dt.Rows[0]["sJobPositionEN"].ToString();
                    txtsJobAdrEN.Text = dt.Rows[0]["sJobAdrEN"].ToString();
                    txtnJobCountEN.Text = dt.Rows[0]["nJobCountEN"].ToString();
                    CKEditorControl2.Text = dt.Rows[0]["sDetailsEN"].ToString();
                    txtsJobYearEN.Text = dt.Rows[0]["sJobYearEN"].ToString();
                    txtsJobSalaryEN.Text = dt.Rows[0]["sJobSalaryEN"].ToString();
                    txtsJobEducationEN.Text = dt.Rows[0]["sJobEducationEN"].ToString();
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
                if (ValiAdd())
                {
                    DBLL.clsJob clJob = new DBLL.clsJob();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                    bool _Result = clJob.update_tb_JobBynJobID(nID, txtsJobPosition.Text, txtsJobAdr.Text, txtsJobYear.Text, txtsJobSalary.Text, txtsJobEducation.Text, txtnJobCount.Text, DateTime.Now, CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, 1,txtsJobPositionEN.Text,txtsJobAdrEN.Text,txtsJobYearEN.Text,txtsJobSalaryEN.Text,txtsJobEducationEN.Text,txtnJobCountEN.Text,CKEditorControl2.Text);
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
                DBLL.clsJob clJob = new DBLL.clsJob();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = clJob.insert_tb_Job(txtsJobPosition.Text, txtsJobAdr.Text, txtsJobYear.Text, txtsJobSalary.Text, txtsJobEducation.Text, txtnJobCount.Text, DateTime.Now, CKEditorControl1.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, 1, txtsJobPositionEN.Text, txtsJobAdrEN.Text, txtsJobYearEN.Text, txtsJobSalaryEN.Text, txtsJobEducationEN.Text, txtnJobCountEN.Text, CKEditorControl2.Text);
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
        txtnJobCount.Text = "";
        txtsJobAdr.Text = "";
        txtsJobEducation.Text = "";
        txtsJobPosition.Text = "";
        txtsJobSalary.Text = "";
        txtsJobYear.Text = "";
        CKEditorControl1.Text = "";

        txtsJobPositionEN.Text = "";
        txtsJobAdrEN.Text = "";
        txtnJobCountEN.Text = "";
        CKEditorControl2.Text = "";
        txtsJobYearEN.Text = "";
        txtsJobSalaryEN.Text = "";
        txtsJobEducationEN.Text = "";
        txtnSorting.Text = "1";
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (string.IsNullOrEmpty(txtsJobPosition.Text))
        {
            ShowMsg1.InnerContent += "招聘职位(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobPositionEN.Text))
        {
            ShowMsg1.InnerContent += "招聘职位(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobAdr.Text))
        {
            ShowMsg1.InnerContent += "工作地点(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobAdrEN.Text))
        {
            ShowMsg1.InnerContent += "工作地点(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobYear.Text))
        {
            ShowMsg1.InnerContent += "工作经验(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobYearEN.Text))
        {
            ShowMsg1.InnerContent += "工作经验(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobSalary.Text))
        {
            ShowMsg1.InnerContent += "月薪(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobSalaryEN.Text))
        {
            ShowMsg1.InnerContent += "月薪(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobEducation.Text))
        {
            ShowMsg1.InnerContent += "学历(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsJobEducationEN.Text))
        {
            ShowMsg1.InnerContent += "学历(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtnJobCount.Text))
        {
            ShowMsg1.InnerContent += "招聘人数(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtnJobCountEN.Text))
        {
            ShowMsg1.InnerContent += "招聘人数(英文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(CKEditorControl1.Text))
        {
            ShowMsg1.InnerContent += "职位明细(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(CKEditorControl2.Text))
        {
            ShowMsg1.InnerContent += "职位明细(英文)不能为空<br/>";
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