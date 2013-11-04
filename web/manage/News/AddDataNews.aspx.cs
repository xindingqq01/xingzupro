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
public partial class manage_AddDataNews : System.Web.UI.Page
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
                DBLL.clsNews clNews = new DBLL.clsNews();
                DataTable dt = clNews.Select_tb_NewsBynNewsID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nNewsID"].ToString();
                    RadioButtonList2.SelectedValue = dt.Rows[0]["nLangType"].ToString();
                    txtsTitle.Text = dt.Rows[0]["sTitle"].ToString();
                    txtsAuthor.Text = dt.Rows[0]["sAuthor"].ToString();
                    Image3.ImageUrl = dt.Rows[0]["sImagePath"].ToString();
                    if (Image3.ImageUrl != "")
                    {
                        lblsImagePath.Visible = false;
                        MutileUploaderUserControl31.Visible = false;
                        Label2.Visible = true;
                        Button1.Visible = true;
                        Image3.Visible = true;
                    }
                    else
                    {
                        lblsImagePath.Visible = true;
                        MutileUploaderUserControl31.Visible = true;
                        Label2.Visible = false;
                        Button1.Visible = false;
                        Image3.Visible = false;
                    }
                    CKEditorControl1.Text = dt.Rows[0]["sContent"].ToString();
                    txtnSorting.Text = dt.Rows[0]["nSorting"].ToString();
                    //绑定数据
                }
            }
            else
            {
                lblBigtitle.Text = "添加数据";
                btnUpdate.Visible = false;
                BtnAdd.Visible = true;
                Label2.Visible = false;
                Button1.Visible = false;
                Image3.Visible = false;
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
                    DBLL.clsNews clNews = new DBLL.clsNews();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                    bool _Result = false;
                    MutileUploaderUserControl31.sNewName = txtsTitle.Text;
                    MutileUploaderUserControl31.SavePath();
                    if (MutileUploaderUserControl31.filepathlist.Count > 0)
                    {
                        for (int i = 0; i < MutileUploaderUserControl31.filepathlist.Count; i++)
                        {
                            _Result = clNews.update_tb_NewsBynNewsID(nID, 0, int.Parse(RadioButtonList2.SelectedValue), txtsTitle.Text, txtsAuthor.Text, MutileUploaderUserControl31.filepathlist[i].ToString(), CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                        }
                    }
                    else
                    {
                        if (Image3.ImageUrl != "")
                        {
                            _Result = clNews.update_tb_NewsBynNewsID(nID, 0, int.Parse(RadioButtonList2.SelectedValue), txtsTitle.Text, txtsAuthor.Text, Image3.ImageUrl.ToString(), CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                        }
                        else
                        {
                            _Result = clNews.update_tb_NewsBynNewsID(nID, 0, int.Parse(RadioButtonList2.SelectedValue), txtsTitle.Text, txtsAuthor.Text, "", CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                        }
                    }
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
                DBLL.clsNews News = new DBLL.clsNews();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = 0;
                MutileUploaderUserControl31.sNewName = txtsTitle.Text;
                MutileUploaderUserControl31.SavePath();
                if (MutileUploaderUserControl31.filepathlist.Count > 0)
                {
                    for (int i = 0; i < MutileUploaderUserControl31.filepathlist.Count; i++)
                    {
                        _Result = News.insert_tb_News(0, int.Parse(RadioButtonList2.SelectedValue), txtsTitle.Text, txtsAuthor.Text, MutileUploaderUserControl31.filepathlist[i].ToString(), CKEditorControl1.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                    }
                }
                else
                {
                    _Result = News.insert_tb_News(0, int.Parse(RadioButtonList2.SelectedValue), txtsTitle.Text, txtsAuthor.Text, "", CKEditorControl1.Text, Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                }
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
        txtsTitle.Text = "";
        txtsAuthor.Text = "";
        txtnSorting.Text = "1";
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (string.IsNullOrEmpty(txtsTitle.Text))
        {
            ShowMsg1.InnerContent += "标题不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsAuthor.Text))
        {
            ShowMsg1.InnerContent += "作者不能为空<br/>";
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
        if (string.IsNullOrEmpty(txtsTitle.Text))
        {
            ShowMsg1.InnerContent += "标题不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsAuthor.Text))
        {
            ShowMsg1.InnerContent += "作者不能为空<br/>";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        int nID = 0;
        if (int.TryParse(hfID.Value.ToString(), out nID) && nID > 0)
        {
            DBLL.clsNews News = new DBLL.clsNews();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            bool _Result = News.update_tb_NewsBynNewsID(nID,0, int.Parse(RadioButtonList2.SelectedValue), txtsTitle.Text, txtsAuthor.Text, "", CKEditorControl1.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
            if (_Result)
            {
                string sSaveFolderFullPath = Server.MapPath(Image3.ImageUrl);
                if (File.Exists(sSaveFolderFullPath))
                {
                    //如果存在则删除
                    File.Delete(sSaveFolderFullPath);

                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sSaveFolderFullPath.Substring(0, sSaveFolderFullPath.LastIndexOf("\\")).ToString());
                    System.IO.FileInfo[] dirs = dir.GetFiles();
                    if (dirs.Length > 0)
                    {
                        //有子文件夹
                    }
                    else
                    {
                        Directory.Delete(sSaveFolderFullPath.Substring(0, sSaveFolderFullPath.LastIndexOf("\\")).ToString());
                    }
                }
                lblsImagePath.Visible = true;
                MutileUploaderUserControl31.Visible = true;
                Label2.Visible = false;
                Button1.Visible = false;
                Image3.Visible = false;
            }
        }
    }
}