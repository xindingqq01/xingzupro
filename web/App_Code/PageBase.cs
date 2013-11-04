using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Security;
namespace Security
{
	//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

    /// <summary>
    /// PageBase 的摘要说明
    /// </summary>
    public class PageBase : ValidateBase
    {
        public PageBase()
        {
            //在这里判断 Session ,出错.
        }
        override protected void OnInit(EventArgs e)//基页判断登入 Session ,要这样写
        {
            base.OnInit(e);
            if (base.strUser.ToString().Trim() == "")
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}