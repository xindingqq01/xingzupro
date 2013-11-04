using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using Security;
namespace Security
{
	//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

    public partial class ValidateCode : ValidateBase
    {
        /// <summary>
        /// 验证码长度
        /// </summary>
        private int codeLen = 5;
        /// <summary>
        /// 图片清晰度
        /// </summary>
        private int fineness = 85;
        // 图片宽度
        private int imgWidth = 80;
        // 图片高度
        private int imgHeight = 24;
        // 字体家族名称
        private string fontFamily = "Times New Roman";
        // 字体大小
        private int fontSize = 14;
        // 字体样式
        private int fontStyle = 0;
        // 绘制起始坐标 X
        private int posX = 0;
        // 绘制起始坐标 Y
        private int posY = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string validateCode = CreateValidateCode();//生成验证码

            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);// 生成BITMAP图像

            DisturbBitmap(bitmap);// 图像背景

            DrawValidateCode(bitmap, validateCode);// 绘制验证码图像

            bitmap.Save(Response.OutputStream,ImageFormat.Gif);// 保存验证码图像，等待输出
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        private string CreateValidateCode()
        {
            string validateCode = "";
            Random random = new Random();// 随机数对象
            for (int i = 0; i < codeLen; i++)
            {
                //int n = random.Next(26); // 26: a - z  字符
                //validateCode += (char)(n + 65); // 将数字转换成大写字母

                int n = random.Next(10); //数字
                validateCode += n.ToString();
            }
            base.strValidate = validateCode;// 保存验证码
            return validateCode;
        }
        /// <summary>
        /// 图像背景
        /// </summary>
        /// <param name="bitmap"></param>
        private void DisturbBitmap(Bitmap bitmap)
        {
            Random random = new Random();// 通过随机数生成
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if (random.Next(90) <= this.fineness)
                        bitmap.SetPixel(i, j, Color.White);
                }
            }
        }
        /// <summary>
        /// 绘制验证码图像,bitmap 图板,validateCode 验证码值
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="validateCode"></param>
        private void DrawValidateCode(Bitmap bitmap, string validateCode)
        {
            Graphics g = Graphics.FromImage(bitmap);// 获取绘制器对象

            Font font = new Font(fontFamily, fontSize, FontStyle.Bold);// 设置绘制字体

            g.DrawString(validateCode, font, Brushes.Black, posX, posY);// 绘制验证码图像
        }
    }
}