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
public partial class manage_AddDataProducts : System.Web.UI.Page
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
                DBLL.DBcommon DBc = new DBLL.DBcommon();
                DataTable dtProductCate = new DataTable();
                dtProductCate = DBc.selectNormalTableofAll(false, "tb_ProductCategory");
                if (dtProductCate != null)
                {
                    //ddlnParentCategoryID.DataSource = dtProductCate;
                    //ddlnParentCategoryID.DataValueField = "nProductCategoryID";
                    //ddlnParentCategoryID.DataTextField = "sProductCategoryNameCN";
                    //ddlnParentCategoryID.DataBind();
                    ddlProductCateTreelist21.ProductList = dtProductCate;
                }

                DBLL.clsProduct clProduct = new DBLL.clsProduct();
                DataTable dt = clProduct.Select_tb_ProductBynProductID(nID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["nProductID"].ToString();
                    cbbHot.Checked = bool.Parse(dt.Rows[0]["bHot"].ToString());
                    txtsProductNameCN.Text = dt.Rows[0]["sProductNameCN"].ToString();
                    txtsProductNameEN.Text = dt.Rows[0]["sProductNameEN"].ToString();
                    //txtsEnsitivityCN.Text = dt.Rows[0]["sEnsitivityCN"].ToString();
                    //txtsEnsitivityEN.Text = dt.Rows[0]["sEnsitivityEN"].ToString();
                    //txtsChannelBalanceCN.Text = dt.Rows[0]["sChannelBalanceCN"].ToString();
                    //txtsChannelBalanceEN.Text = dt.Rows[0]["sChannelBalanceEN"].ToString();
                    //txtsImpedanceCN.Text = dt.Rows[0]["sImpedanceCN"].ToString();
                    //txtsImpedanceEN.Text = dt.Rows[0]["sImpedanceEN"].ToString();
                    //txtsFrequencyCN.Text = dt.Rows[0]["sFrequencyCN"].ToString();
                    //txtsFrequencyEN.Text = dt.Rows[0]["sFrequencyEN"].ToString();
                    //txtsRatedPowerCN.Text = dt.Rows[0]["sRatedPowerCN"].ToString();
                    //txtsRatedPowerEN.Text = dt.Rows[0]["sRatedPowerEN"].ToString();
                    //txtsMaximumPowerCN.Text = dt.Rows[0]["sMaximumPowerCN"].ToString();
                    //txtsMaximumPowerEN.Text = dt.Rows[0]["sMaximumPowerEN"].ToString();
                    CKEditorControl3.Text = dt.Rows[0]["sSummaryCN"].ToString();
                    CKEditorControl4.Text = dt.Rows[0]["sSummaryEN"].ToString();
                    txtsBrandNameCN.Text = dt.Rows[0]["sBrandNameCN"].ToString();
                    txtsBrandNameEN.Text = dt.Rows[0]["sBrandNameEN"].ToString();
                    CKEditorControl1.Text = dt.Rows[0]["sIntroCN"].ToString();
                    CKEditorControl2.Text = dt.Rows[0]["sIntroEN"].ToString();
                    ddlProductCateTreelist21.setnSelectID(int.Parse(dt.Rows[0]["nProductCategoryID"].ToString()));
                    Image3.ImageUrl = dt.Rows[0]["sPImagePath"].ToString();
                    //Imagestring.ImageUrl = "";
                    Image4.ImageUrl = dt.Rows[0]["sThumbPath"].ToString();
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
                    txtnSorting.Text = dt.Rows[0]["nSorting"].ToString();
                    //绑定数据
                }
            }
            else
            {
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
                CKEditorControl3.Text = option.GetOptionValue("cn", "SystemSetting", "ProductCateTemplate");
                CKEditorControl4.Text = option.GetOptionValue("en", "SystemSetting", "ProductCateTemplate");


                lblBigtitle.Text = "添加数据";
                btnUpdate.Visible = false;
                BtnAdd.Visible = true;
                DBLL.DBcommon DBc = new DBLL.DBcommon();
                DataTable dt = new DataTable();
                dt = DBc.selectNormalTableofAll(false, "tb_ProductCategory");
                if (dt != null)
                {
                    //ddlnParentCategoryID.DataSource = dt;
                    //ddlnParentCategoryID.DataValueField = "nProductCategoryID";
                    //ddlnParentCategoryID.DataTextField = "sProductCategoryNameCN";
                    //ddlnParentCategoryID.DataBind();
                    ddlProductCateTreelist21.ProductList = dt;
                }
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
                    DBLL.clsProduct Product = new DBLL.clsProduct();
                    DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();

                    string sSavepath = "";
                    //生成缩略图 
                    HttpFileCollection postedFiles = Request.Files;
                    if (postedFiles.Count > 0)
                    {
                        if (postedFiles[0].ContentLength > 0)
                        {
                            System.Drawing.Image image, newimage; //定义image类的对象
                            string imagePath; 　 //图片路径
                            string imageType; 　 //图片类型
                            string imageName; 　 //图片名称
                            //提供一个回调方法,用于确定Image对象在执行生成缩略图操作时何时提前取消执行
                            //如果此方法确定 GetThumbnailImage 方法应提前停止执行，则返回 true；否则返回 false
                            System.Drawing.Image.GetThumbnailImageAbort callb = null;


                            string basepath = "~/ProductsUpload" + "/temp/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                DateTime.Now.Second.ToString() + "/";

                            string sSaveFolderFullPath = Server.MapPath(basepath);

                            if (!System.IO.Directory.Exists(sSaveFolderFullPath))
                            {
                                Directory.CreateDirectory(sSaveFolderFullPath);
                            }


                            string thbasepath = "~/ProductsUpload" + "/thumb/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                DateTime.Now.Second.ToString() + "/";

                            string thsSaveFolderFullPath = Server.MapPath(thbasepath);

                            if (!System.IO.Directory.Exists(thsSaveFolderFullPath))
                            {
                                Directory.CreateDirectory(thsSaveFolderFullPath);
                            }


                            imagePath = postedFiles[0].FileName;
                            //取得图片类型
                            imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
                            //取得图片名称
                            imageName = imagePath.Substring(imagePath.LastIndexOf("\\") + 1);
                            Stream imgStream = postedFiles[0].InputStream;//流文件，准备读取上载文件的内容
                            int imgLen = postedFiles[0].ContentLength;    //上载文件大小
                            //string imgName = txtImageName.Text;                   //图片名称


                            //string imgnm = txtImageName.Text;
                            byte[] imgBinaryData = new byte[imgLen];//


                            int n = imgStream.Read(imgBinaryData, 0, imgLen);



                            //保存到虚拟路径
                            postedFiles[0].SaveAs(sSaveFolderFullPath + "\\" + imageName);
                            ////显示原图
                            //imageSource.ImageUrl = "upFile/" + imageName;
                            //为上传的图片建立引用
                            image = System.Drawing.Image.FromFile(sSaveFolderFullPath + "\\" + imageName);

                            //int smallW = 100;//小图片宽
                            //int smallH = smallW * image.Height / image.Width;//小图片高

                            int smallH = 100;
                            int smallW = smallH * image.Width / image.Height;
                            //生成缩略图
                            newimage = image.GetThumbnailImage(smallW, smallH, callb, new System.IntPtr());
                            //把缩略图保存到指定的虚拟路径
                            newimage.Save(thsSaveFolderFullPath + "\\" + imageName);
                            //释放image对象占用的资源
                            image.Dispose();
                            //释放newimage对象的资源
                            newimage.Dispose();

                            sSavepath = thbasepath + imageName;
                        }
                    }
                    bool _Result = false;
                    if (Image3.ImageUrl != "")
                    {
                        _Result = Product.update_tb_ProductBynProductID(nID, ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, Image3.ImageUrl, txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), Image4.ImageUrl, "", "", "", "", "", "", "", "", "", "", "", "", txtsBrandNameCN.Text, txtsBrandNameEN.Text);
          
                    }
                    else
                    {
                        if (sSavepath != "")
                        {
                            MutileUploaderUserControl31.SavePath();
                            _Result = Product.update_tb_ProductBynProductID(nID, ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, MutileUploaderUserControl31.filepathlist[0].ToString(), txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), sSavepath, "", "", "", "", "", "", "", "", "", "", "", "", txtsBrandNameCN.Text, txtsBrandNameEN.Text);
                        }
                        else
                            _Result = Product.update_tb_ProductBynProductID(nID, ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, "", txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), "", "", "", "", "", "", "", "", "", "", "", "", "", txtsBrandNameCN.Text, txtsBrandNameEN.Text);
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
                DBLL.clsProduct Product = new DBLL.clsProduct();
                DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();

                string sSavepath = "";
                //生成缩略图 
                HttpFileCollection postedFiles = Request.Files;
                if (postedFiles.Count > 0)
                {
                    if (postedFiles[0].ContentLength > 0)
                    {
                        System.Drawing.Image image, newimage; //定义image类的对象
                        string imagePath; 　 //图片路径
                        string imageType; 　 //图片类型
                        string imageName; 　 //图片名称
                        //提供一个回调方法,用于确定Image对象在执行生成缩略图操作时何时提前取消执行
                        //如果此方法确定 GetThumbnailImage 方法应提前停止执行，则返回 true；否则返回 false
                        System.Drawing.Image.GetThumbnailImageAbort callb = null;


                        string basepath = "~/ProductsUpload" + "/temp/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                                 DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                                 DateTime.Now.Second.ToString() + "/";

                        string sSaveFolderFullPath = Server.MapPath(basepath);

                        if (!System.IO.Directory.Exists(sSaveFolderFullPath))
                        {
                            Directory.CreateDirectory(sSaveFolderFullPath);
                        }


                        string thbasepath = "~/ProductsUpload" + "/thumb/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                            DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                            DateTime.Now.Second.ToString() + "/";

                        string thsSaveFolderFullPath = Server.MapPath(thbasepath);

                        if (!System.IO.Directory.Exists(thsSaveFolderFullPath))
                        {
                            Directory.CreateDirectory(thsSaveFolderFullPath);
                        }


                        imagePath = postedFiles[0].FileName;
                        //取得图片类型
                        imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
                        //取得图片名称
                        imageName = imagePath.Substring(imagePath.LastIndexOf("\\") + 1);
                        Stream imgStream = postedFiles[0].InputStream;//流文件，准备读取上载文件的内容
                        int imgLen = postedFiles[0].ContentLength;    //上载文件大小
                        //string imgName = txtImageName.Text;                   //图片名称


                        //string imgnm = txtImageName.Text;
                        byte[] imgBinaryData = new byte[imgLen];//


                        int n = imgStream.Read(imgBinaryData, 0, imgLen);



                        //保存到虚拟路径
                        postedFiles[0].SaveAs(sSaveFolderFullPath + "\\" + imageName);
                        ////显示原图
                        //imageSource.ImageUrl = "upFile/" + imageName;
                        //为上传的图片建立引用
                        image = System.Drawing.Image.FromFile(sSaveFolderFullPath + "\\" + imageName);

                        //int smallW = 100;//小图片宽
                        //int smallH = smallW * image.Height / image.Width;//小图片高

                        int smallH = 100;
                        int smallW = smallH * image.Width / image.Height;
                        //生成缩略图
                        newimage = image.GetThumbnailImage(smallW, smallH, callb, new System.IntPtr());
                        //把缩略图保存到指定的虚拟路径
                        newimage.Save(thsSaveFolderFullPath + "\\" + imageName);
                        //释放image对象占用的资源
                        image.Dispose();
                        //释放newimage对象的资源
                        newimage.Dispose();

                        sSavepath = thbasepath + imageName;
                    }
                }
                MutileUploaderUserControl31.SavePath();
                int _Result=0;
                if(MutileUploaderUserControl31.filepathlist.Count>0)
                    _Result = Product.insert_tb_Product(ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, MutileUploaderUserControl31.filepathlist[0].ToString(), txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), sSavepath, "","", "", "","", "", "", "","", "", "","", txtsBrandNameCN.Text, txtsBrandNameEN.Text);
                else
                    _Result = Product.insert_tb_Product(ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, "", txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), "", "","", "", "","", "", "", "","", "", "","", txtsBrandNameCN.Text, txtsBrandNameEN.Text);
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
        cbbHot.Checked = false;
        txtsProductNameCN.Text = "";
        txtsProductNameEN.Text = "";
        //txtsEnsitivityCN.Text = "";
        //txtsEnsitivityEN.Text = "";
        //txtsChannelBalanceCN.Text = "";
        //txtsChannelBalanceEN.Text = "";
        //txtsImpedanceCN.Text = "";
        //txtsImpedanceEN.Text = "";
        //txtsFrequencyCN.Text = "";
        //txtsFrequencyEN.Text = "";
        //txtsRatedPowerCN.Text = "";
        //txtsRatedPowerEN.Text = "";
        //txtsMaximumPowerCN.Text = "";
        //txtsMaximumPowerEN.Text = "";
         CKEditorControl3.Text="";
         CKEditorControl4.Text = "";
        txtsBrandNameCN.Text = "";
        txtsBrandNameEN.Text = "";
        CKEditorControl1.Text = "";
        CKEditorControl2.Text = "";
        DBLL.DBcommon DBc = new DBLL.DBcommon();
        DataTable dtProductCate = new DataTable();
        dtProductCate = DBc.selectNormalTableofAll(false, "tb_ProductCategory");
        if (dtProductCate != null)
        {
            ddlProductCateTreelist21.ProductList = dtProductCate;
        }
        txtnSorting.Text = "1";
    }
    protected bool ValiAdd()
    {
        bool bcheck = true;
        ShowMsg1.InnerContent = "";
        Regex r32 = new Regex(@"^[\d]+$");
        if (ddlProductCateTreelist21.nSelectProductCategoryID == 0)
        {
            ShowMsg1.InnerContent += "请选择其中一种产品类别<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductNameCN.Text))
        {
            ShowMsg1.InnerContent += "产品名称(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductNameEN.Text))
        {
            ShowMsg1.InnerContent += "产品名称(英文)不能为空<br/>";
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
        if (string.IsNullOrEmpty(txtsProductNameCN.Text))
        {
            ShowMsg1.InnerContent += "产品名称(中文)不能为空<br/>";
            bcheck = false;
        }
        if (string.IsNullOrEmpty(txtsProductNameEN.Text))
        {
            ShowMsg1.InnerContent += "产品名称(英文)不能为空<br/>";
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
        DBLL.clsProduct clProduct = new DBLL.clsProduct();
        DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
        //bool _Result = clProduct.update_tb_ProductBynProductID(int.Parse(hfID.Value), ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, "", txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), "", txtsEnsitivityCN.Text, txtsEnsitivityEN.Text, txtsChannelBalanceCN.Text, txtsChannelBalanceEN.Text, txtsImpedanceCN.Text, txtsImpedanceEN.Text, txtsFrequencyCN.Text, txtsFrequencyEN.Text, txtsRatedPowerCN.Text, txtsRatedPowerEN.Text, txtsMaximumPowerCN.Text, txtsMaximumPowerEN.Text, txtsBrandNameCN.Text, txtsBrandNameEN.Text);
        bool _Result = clProduct.update_tb_ProductBynProductID(int.Parse(hfID.Value), ddlProductCateTreelist21.nSelectProductCategoryID, cbbHot.Checked, "", txtsProductNameCN.Text, txtsProductNameEN.Text, CKEditorControl3.Text, CKEditorControl4.Text, CKEditorControl1.Text, CKEditorControl2.Text, Session["user"].ToString(), DateTime.Now, true, int.Parse(txtnSorting.Text), "","","", "", "","", "", "", "","", "", "","", txtsBrandNameCN.Text, txtsBrandNameEN.Text);
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
            Image3.ImageUrl = "";
            Image4.ImageUrl = "";
        }
    }
}