using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplication1.Services
{
    public class MailService
    {
        private string gmail_account = "";
        private string gmail_password = "";
        private string gmail_mail = "";

        #region 寄會員認證信
        // 產生驗證碼方法
        public string GetValidateCode()
        {
            string[] Code ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"
                           , "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y"
                           , "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b"
                           , "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n"
                           , "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string ValidateCode = string.Empty;

            Random rd = new Random();

            for (int i = 0; i < 10; i++)
            {
                ValidateCode += Code[rd.Next(Code.Count())];
            }
            return ValidateCode;
        }
        // 將使用者資料填入驗證信範本中
        public string GetRegisterMailBody(string TempString, string UserName, string ValidateUrl)
        {
            TempString = TempString.Replace("{{UserName}}", UserName);
            TempString = TempString.Replace("{{ValidateUrl}}", ValidateUrl);
            return TempString;
        }
        // 寄驗證信方法
        public void SendRegisterMail(string MailBody, string ToEmail)
        {
            // gmail為例
            // 建立寄信用Smtp物件 
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            // 設定使用的port
            SmtpServer.Port = 587;
            // 建立使用者憑證 設定帳戶
            SmtpServer.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);
            // 開啟SSL
            SmtpServer.EnableSsl = true;
            // 宣告信件內容物件
            MailMessage mail = new MailMessage();
            // 設定來源信箱
            mail.From = new MailAddress(gmail_mail);
            // 設定收信者信箱
            mail.To.Add(ToEmail);
            // 設定信件主旨
            mail.Subject = "會員註冊確認信";
            // 設定信件內容
            mail.Body = MailBody;
            // 設定信件內容為HTML格式
            mail.IsBodyHtml = true;
            // 送出信件
            SmtpServer.Send(mail);
        }
        #endregion
    }
}