using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_Products_template : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
            CKEditorControlc.Text = option.GetOptionValue("cn", "SystemSetting", "ProductCateTemplate");
            CKEditorControle.Text = option.GetOptionValue("en", "SystemSetting", "ProductCateTemplate");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBLL.OptionSysDBLL option = new DBLL.OptionSysDBLL();
        option.UpdateOptionValue("en", "SystemSetting", "ProductCateTemplate", CKEditorControle.Text);
        option.UpdateOptionValue("cn", "SystemSetting", "ProductCateTemplate", CKEditorControlc.Text);
    }
}