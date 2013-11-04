using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class manage_DataListFAQ : System.Web.UI.Page
{
    public int nPageRowCount
    {
        set
        {
            ViewState["nPageRowCounmanage_FAQ"] = value;
        }
        get
        {
            if (ViewState["nPageRowCounmanage_FAQ"] == null)
                ViewState["nPageRowCounmanage_FAQ"] = 8;
            return (int)ViewState["nPageRowCounmanage_FAQ"];
        }
    }
    public DataTable DataTableFAQ
    {
        set
        {
            Cache.Remove("DataTableFAQ");
            Cache.Insert("DataTableFAQ", value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
        }
        get
        {
            if (Cache["DataTableFAQ"] == null)
            {
                Cache.Insert("DataTableFAQ", new DataTable(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(2, 0, 0));
            }

            return (DataTable)Cache["DataTableFAQ"];
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
        dt = DBc.selectNormalTableofAll(false, "tb_FAQs");
        if (dt != null)
        {
            DataTableFAQ.Merge(dt);
            lvFAQ.DataSource = dt;
            lvFAQ.DataBind();
        }
        else
        {
            lvFAQ.DataSource = null;
            lvFAQ.DataBind();
        }
    }
    protected void lvFAQ_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        Label lblnFAQID = (Label)lvFAQ.Items[e.NewSelectedIndex].FindControl("lblnFAQID"); ;
        Response.Redirect("AddDataFAQ.aspx?nID=" + lblnFAQID.Text.Trim());
    }
    protected void lvFAQ_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();

            Label lblsQuestionEN = (Label)e.Item.FindControl("lblsQuestionEN");
            if (lblsQuestionEN.Text.Length > 8)
            {
                lblsQuestionEN.Text = lblsQuestionEN.Text.Substring(0, 8).ToString() + "....";
            }
            Label lblsQuestionCN = (Label)e.Item.FindControl("lblsQuestionCN");
            if (lblsQuestionCN.Text.Length > 8)
            {
                lblsQuestionCN.Text = lblsQuestionCN.Text.Substring(0, 8).ToString() + "....";
            }

            Label lblsAnswerCN = (Label)e.Item.FindControl("lblsAnswerCN");
            if (lblsAnswerCN.Text.Length > 8)
            {
                lblsAnswerCN.Text = lblsAnswerCN.Text.Substring(0, 8).ToString() + "....";
            }
            Label lblsAnswerEN = (Label)e.Item.FindControl("lblsAnswerEN");
            if (lblsAnswerEN.Text.Length > 8)
            {
                lblsAnswerEN.Text = lblsAnswerEN.Text.Substring(0, 8).ToString() + "....";
            }

            ImageButton imgDelete = (ImageButton)e.Item.FindControl("imgDelete");
            imgDelete.OnClientClick = "javascript:if (confirm('" + option.GetOptionValue("FormatSetting", "CommandControl", "bIsDelete") + "')){$('#EntryForm').block({ message: null });}else{return false;}";

        }
        catch (Exception)
        {
        }
    }
    protected void lvFAQ_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        DBLL.DBcommon dbcom = new DBLL.DBcommon();
        Label lblnID = (Label)lvFAQ.Items[e.ItemIndex].FindControl("lblnFAQID");
        int _nID = 0;
        if (int.TryParse(lblnID.Text.Trim(), out _nID) && _nID > 0)
        {
            dbcom.sp_DeleteNormalTableByID(_nID, "tb_FAQs");
            ReBindPageList();
        }
    }
    protected void lvFAQ_PagePropertiesChanged(object sender, EventArgs e)
    {
        DataPager1.SetPageProperties(DataPager1.StartRowIndex, nPageRowCount, true);
        lvFAQ.DataSource = DataTableFAQ;
        lvFAQ.DataBind();
    }
}