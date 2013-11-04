using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataListNews : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_News"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_News"] == null)
                ViewState["nPageRowCounmanage_News"] = 8;
            return (int)ViewState["nPageRowCounmanage_News"];
        }
    }
    public DataTable DataTableNews
    {
        set
        {
            Cache.Remove("DataTableNews");
            Cache.Insert("DataTableNews", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTableNews"] == null)
            {
                Cache.Insert("DataTableNews", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTableNews"];
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
        dt = DBc.selectNormalTableofAll(false, "tb_News");
        if (dt != null)
        {
            DataTableNews.Merge(dt);
            lvNews.DataSource = dt;
            lvNews.DataBind();
        }
        else
        {
            lvNews.DataSource = null;
            lvNews.DataBind();
        }
    }
    protected void lvNews_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnNewsID = (Label)lvNews.Items[e.NewSelectedIndex].FindControl("lblnNewsID"); ;
        Response.Redirect("AddDataNews.aspx?nID=" + lblnNewsID.Text.Trim());
    }
    protected void lvNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.DBcommon DBc = new DBLL.DBcommon();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblsTitle = (Label)e.Item.FindControl("lblsTitle");
                if (lblsTitle.Text.Length > 10)
                {
                    lblsTitle.Text = lblsTitle.Text.Substring(0, 10).ToString() + "....";
                }
                //Label lblsProductNameEN = (Label)e.Item.FindControl("lblsProductNameEN");
                //if (lblsProductNameEN.Text.Length > 10)
                //{
                //    lblsProductNameEN.Text = lblsProductNameEN.Text.Substring(0, 10).ToString() + "....";
                //}
            }
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");
            btnDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvNews_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvNews.Items[e.ItemIndex].FindControl("lblnNewsID");
        dbcom.sp_DeleteNormalTableByID(int.Parse(lblnID.Text), "tb_News");
        ReBindPageList();
    }
    protected void lvNews_PagePropertiesChanged(object sender, EventArgs e)
    {
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true);
        lvNews.DataSource = DataTableNews;
        lvNews.DataBind();
    }
}