using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace Security
{
	//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)
    /// <summary>
    /// ValidateBase 底层页
    /// </summary>
    public class ValidateBase : System.Web.UI.Page
    {
        public ValidateBase()
        {
           
        }
        /// <summary>
        /// 存放验证码值
        /// </summary>
        public string strValidate
        {
            get
            {
                if (Session["ValidateCode"] != null)
                    return Session["ValidateCode"].ToString();
                else
                    return "";
            }
            set
            {
                Session["ValidateCode"] = value;
            }
        }
        /// <summary>
        /// 存放登入信息
        /// </summary>
        public string strUser
        {
            get
            {
                if (Session["strUser"] != null)
                    return Session["strUser"].ToString();
                else
                    return "";
            }
            set
            {
                Session["strUser"] = value;
            }
        }
    }
}