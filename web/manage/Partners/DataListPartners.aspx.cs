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
public partial class manage_DataListPartners : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_Partners"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_Partners"] == null)
                ViewState["nPageRowCounmanage_Partners"] = 8;
            return (int)ViewState["nPageRowCounmanage_Partners"];
        }
    }
    public DataTable DataTablePartners
    {
        set
        {
            Cache.Remove("DataTablePartners");
            Cache.Insert("DataTablePartners", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTablePartners"] == null)
            {
                Cache.Insert("DataTablePartners", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTablePartners"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReBindPageList();
        }
    }
    public void ReBindPageList()
    {
        DBLL.DBcommon DBc = new DBLL.DBcommon();
        DataTable dt = new DataTable();
        dt = DBc.selectNormalTableofAll(false, "tb_Partners");
        if (dt != null)
        {
            DataTablePartners.Merge(dt);
            lvPartners.DataSource = dt;
            lvPartners.DataBind();
        }
        else
        {
            lvPartners.DataSource = null;
            lvPartners.DataBind();
        }
    }
    protected void lvPartners_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnPartnersID = (Label)lvPartners.Items[e.NewSelectedIndex].FindControl("lblnPartnersID"); ;
        Response.Redirect("AddDataPartners.aspx?nID=" + lblnPartnersID.Text.Trim());
    }
    protected void lvPartners_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void lvPartners_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.clsPartners clPartners = new DBLL.clsPartners();
        Label lblnID = (Label)lvPartners.Items[e.ItemIndex].FindControl("lblnPartnersID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            bool Result = clPartners.sp_DeleteNormalTableByIDPartners(_nID, "tb_Partners");
            if (Result)
            {
                //判断文件是不是存在
                Image ImsImagePath = (Image)lvPartners.Items[e.ItemIndex].FindControl("sImagePath");
                string sSaveFolderFullPath = Server.MapPath(ImsImagePath.ImageUrl);
                if (File.Exists(sSaveFolderFullPath))
                {
                    //如果存在则删除
                    File.Delete(sSaveFolderFullPath);
                }
            }
            ReBindPageList();
        }
    }
    protected void lvPartners_PagePropertiesChanged(object sender, EventArgs e)
    {
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true);
        lvPartners.DataSource = DataTablePartners;
        lvPartners.DataBind();
    }
}