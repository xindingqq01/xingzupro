using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_DropDownList_DropSorting : System.Web.UI.UserControl
{
    public int nCount
    {
        set
        {
            ViewState["nCountDropSorting"] = value;
        }
        get
        {
            if (ViewState["nCountDropSorting"] == null)
                ViewState["nCountDropSorting"] = 10;
            return (int)ViewState["nCountDropSorting"];
        }
    }
    public int nChoseNum
    {
        set
        {
            ViewState["nChoseNumDropSorting"] = value;
        }
        get
        {
            if (ViewState["nChoseNumDropSorting"] == null)
                ViewState["nChoseNumDropSorting"] = 0;
            return (int)ViewState["nChoseNumDropSorting"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            for (int i = 0; i < nCount; i++)
            {
                ListItem item = new ListItem(nCount.ToString(), nCount.ToString());
                DropDownList1.Items.Add(item);
            }

            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Value == nChoseNum.ToString())
                {
                    DropDownList1.Items[i].Selected = true;
                    break;
                }
            }
        }
    }
    public void SetChoseNum(int num)
    {
        nChoseNum = num;
        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            if (DropDownList1.Items[i].Value == nChoseNum.ToString())
            {
                DropDownList1.Items[i].Selected = true;
                break;
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int _num = 0;
            if (int.TryParse(DropDownList1.SelectedValue, out _num))
            {
                nChoseNum = _num;
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}