using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataListJob : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_Job"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_Job"] == null)
                ViewState["nPageRowCounmanage_Job"] = 8;
            return (int)ViewState["nPageRowCounmanage_Job"];
        }
    }
    public DataTable DataTableJob
    {
        set
        {
            Cache.Remove("DataTableJob");
            Cache.Insert("DataTableJob", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTableJob"] == null)
            {
                Cache.Insert("DataTableJob", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTableJob"];
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
        dt = DBc.selectNormalTableofAll(false, "tb_Jobs");
        if (dt != null)
        {
            DataTableJob.Merge(dt);
            lvJob.DataSource = dt;
            lvJob.DataBind();
        }
        else
        {
            lvJob.DataSource = null;
            lvJob.DataBind();
        }
    }
    protected void lvJob_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnJobID = (Label)lvJob.Items[e.NewSelectedIndex].FindControl("lblnJobID"); ;
        Response.Redirect("AddDataJob.aspx?nID=" + lblnJobID.Text.Trim());
    }
    protected void lvJob_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.DBcommon DBc = new DBLL.DBcommon();
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    Label lblsTitle = (Label)e.Item.FindControl("lblsTitle");
            //    if (lblsTitle.Text.Length > 10)
            //    {
            //        lblsTitle.Text = lblsTitle.Text.Substring(0, 10).ToString() + "....";
            //    }
            //}
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");
            btnDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {

        }
    }
    protected void lvJob_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvJob.Items[e.ItemIndex].FindControl("lblnJobID");
        dbcom.sp_DeleteNormalTableByID(int.Parse(lblnID.Text), "tb_Jobs");
        ReBindPageList();
    }
    protected void lvJob_PagePropertiesChanged(object sender, EventArgs e)
    {
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true);
        lvJob.DataSource = DataTableJob;
        lvJob.DataBind();
    }
}