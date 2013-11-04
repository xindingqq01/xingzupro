using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataListMessages : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_Messages"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_Messages"] == null)
                ViewState["nPageRowCounmanage_Messages"] = 8;
            return (int)ViewState["nPageRowCounmanage_Messages"];
        }
    }
    public DataTable DataTableMessages
    {
        set
        {
            Cache.Remove("DataTableMessages");
            Cache.Insert("DataTableMessages", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTableMessages"] == null)
            {
                Cache.Insert("DataTableMessages", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTableMessages"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            int nPageSize = 0;
            if (nPageRowCount <= 0)
            {
                if (int.TryParse(option.GetOptionValue("FormatSetting", "GridViewFormat", "RowsCountDefault"), out nPageSize))
                {
                    nPageRowCount = nPageSize;

                }
                else
                {
                    nPageRowCount = common.GetGridViewPageCount();
                }

            }
            DataPager1.PageSize = nPageRowCount;
            ReBindPageList();
        }
    }
    public void ReBindPageList()
    {
        DBLL.DBcommon DBc = new DBLL.DBcommon();
        DataTable dt = new DataTable();
        dt = DBc.selectNormalTableofAll(false, "tb_Contact");
        if (dt != null)
        {
            DataTableMessages.Merge(dt);
            lvMessages.DataSource = dt;
            lvMessages.DataBind();
        }
        else
        {
            lvMessages.DataSource = null;
            lvMessages.DataBind();
        }
    }
    protected void lvMessages_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnContactID = (Label)lvMessages.Items[e.NewSelectedIndex].FindControl("lblnContactID"); ;
        Response.Redirect("DataMessages.aspx?nID=" + lblnContactID.Text.Trim());
    }
    protected void lvMessages_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label lblbCheck = (Label)e.Item.FindControl("lblbCheck");
            if (lblbCheck.Text == "False")
                lblbCheck.Text = "未阅";
            else
                lblbCheck.Text = "已阅";
        }
    }
    protected void lvMessages_PagePropertiesChanged(object sender, EventArgs e)
    {
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true);
        lvMessages.DataSource = DataTableMessages;
        lvMessages.DataBind();
    }
}