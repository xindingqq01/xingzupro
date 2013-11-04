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
public partial class manage_AddDataPartners : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int nID = 0;
            if (Request.QueryString["nID"] != null && int.TryParse(Request.QueryString["nID"].ToString(), out  nID) && nID > 0)
            {
                lblBigtitle.Text = "编辑数据";
                BtnAdd.Visible = false;
                DBLL.clsPartners clPartners = new DBLL.clsPartners();
                DataTable dt = clPartners.Select_tb_PartnersBynPartnersID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nPartnersID"].ToString();
                    txtsImageNameCN.Text = dt.Rows[0]["sImageNameCN"].ToString();
                    txtsImageNameEN.Text = dt.Rows[0]["sImageNameEN"].ToString();
                    Image3.ImageUrl = dt.Rows[0]["sImagePath"].ToString();
                    if (Image3.ImageUrl != "")
                    {
                        lblsImagePath.Visible = false;
                        Label2.Visible = true;
                        Button1.Visible = true;
                        Image3.Visible = true;
                    }
                    else
                    {
                        lblsImagePath.Visible = true;
                        Label2.Visible = false;
                        Button1.Visible = false;
                        Image3.Visible = false;
                    }
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
                if (ValiAdd())
                {
                    DBLL.clsPartners clPartners = new DBLL.clsPartners();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                    bool _Result = false;
                    MutileUploaderUserControlPartners.sNewName = txtsImageNameCN.Text;
                    MutileUploaderUserControlPartners.SavePath();
                    if (MutileUploaderUserControlPartners.filepathlist.Count > 0)
                    {
                        for (int i = 0; i < MutileUploaderUserControlPartners.filepathlist.Count; i++)
                        {
                            _Result = clPartners.update_tb_PartnersBynPartnersID(nID, txtsImageNameCN.Text,"","", txtsImageNameEN.Text, MutileUploaderUserControlPartners.filepathlist[i].ToString(), Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
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
                DBLL.clsPartners clPartners = new DBLL.clsPartners();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                int _Result = 0;
                MutileUploaderUserControlPartners.sNewName = txtsImageNameCN.Text;
                MutileUploaderUserControlPartners.SavePath();
                if (MutileUploaderUserControlPartners.filepathlist.Count > 0)
                {
                    for (int i = 0; i < MutileUploaderUserControlPartners.filepathlist.Count; i++)
                    {
                        _Result = clPartners.insert_tb_Partners(txtsImageNameCN.Text,"","", txtsImageNameEN.Text, MutileUploaderUserControlPartners.filepathlist[i].ToString(), Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
                    }
                }
                else
                {
                    _Result = clPartners.insert_tb_Partners(txtsImageNameCN.Text,"","", txtsImageNameEN.Text, "", Session["User"].ToString(), DateTime.Now, Session["User"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
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
        txtsImageNameCN.Text = "";
        txtnSorting.Text = "1";
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (string.IsNullOrEmpty(txtsImageNameCN.Text))
        {
            ShowMsg1.InnerContent += "合作伙伴名称不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsImageNameEN.Text))
        {
            ShowMsg1.InnerContent += "公司网址不能为空<br/>";
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
        DBLL.clsPartners clPartners = new DBLL.clsPartners();
        DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
        bool _Result = clPartners.update_tb_PartnersBynPartnersID(int.Parse(hfID.Value), txtsImageNameCN.Text,"","", txtsImageNameEN.Text, "", Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text));
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
            Label2.Visible = false;
            Button1.Visible = false;
            Image3.Visible = false;
        }
    }
}