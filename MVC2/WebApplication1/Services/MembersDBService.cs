using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MembersDBService
    {
        // 建立與資料庫的連線字串
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["ASP.NET MVC"].ConnectionString;
        // 建立與資料庫連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);

        #region 註冊
        // 註冊新會員方法
        public void Register(Members newMember)
        {
            // 將密碼Hash過
            newMember.Password = HashPassword(newMember.Password);
            // sql新增語法 // IsAdmin預設為0
            string sql = $@"INSERT INTO Merbers (Account,Password,Name,Image,Email,AuthCode,IsAdmin) 
                         VALUES ('{newMember.Account}','{newMember.Password}','{newMember.Name}','{newMember.Image}','{newMember.Email}','{newMember.AuthCode}',0)";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Hash密碼
        // Hash密碼用的方法
        public string HashPassword(string Password)
        {
            // 宣告Hash時所添加的無意義亂數值
            string saltkey = "1q2w3e4r5t6y7u8i9o0po7tyy";
            // 將剛宣告的字串與密碼結合
            string saltAndPassword = String.Concat(Password, saltkey);
            // 定義SHA256的Hash物件
            SHA256CryptoServiceProvider sha256Hasher = new SHA256CryptoServiceProvider();
            // 取得密碼轉換成byte資料
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            // 取得Hash後byte資料
            byte[] HashData = sha256Hasher.ComputeHash(PasswordData);
            // 將Hash後byte資料轉成string
            string Hashresult = Convert.ToBase64String(HashData);
            //回傳Hash後結果
            return Hashresult;
        }
        #endregion

        #region 查詢一筆資料
        // 藉由帳號取得單筆資料的方法
        private Members GetDataByAccount(String Account)
        {
            Members Data = new Members();

            string sql = $@"SELECT * FROM Members WHERE Account = '{Account}'";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Data.Account = dr["Account"].ToString();
                Data.Password = dr["Password"].ToString();
                Data.Name = dr["Name"].ToString();
                Data.Email = dr["Email"].ToString();
                Data.AuthCode = dr["AuthCode"].ToString();
                Data.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
            }
            catch (Exception e)
            {
                Data = null;
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
        #endregion

        #region 查詢一筆公開性資料
        // 取得會員資料(取得非私密性資料 名字&照片&帳號)
        public Members GetDatabyAccount(string Account)
        {
            Members Data = new Members();

            string sql = $@"SELECT * FROM Members WHERE Account = '{Account}'";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Data.Image = dr["Image"].ToString();
                Data.Name = dr["Name"].ToString();
                Data.Account = dr["Account"].ToString();
            }
            catch (Exception e)
            {
                Data = null;
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
        #endregion

        #region 帳號註冊重複確認
        //確認要註冊帳號是否有被註冊過的方法
        public bool AccountCheck(string Account)
        {
            //藉由傳入帳號取得會員資料
            Members Data = GetDataByAccount(Account);
            //判斷是否有查詢到會員
            bool result = (Data == null);
            return result;
        }
        #endregion

        #region 信箱驗證
        // 信箱驗證碼驗證方法
        public string EmailValidate(string Account, string Authcode)
        {
            Members ValidateMember = GetDataByAccount(Account);
            string ValidateStr = string.Empty;
            if (ValidateMember != null)
            {
                if (ValidateMember.AuthCode == Authcode)
                {
                    string sql = $@"UPDATE Members SET AuthCode = '{string.Empty}' WHERE Account = '{Account}'";
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    ValidateStr = "驗證碼錯誤,請重新確認或再註冊";
                }
            }
            else
            {
                ValidateStr = "傳送資料錯誤,請重新確認或再註冊";
            }
            return ValidateStr;
        }
        #endregion

        #region 登入確認
        // 登入帳密確認方法 並回傳驗證後訊息
        public string LoginCheck(string Account, string Password)
        {
            Members LoginMember = GetDataByAccount(Account);
            if (LoginMember != null)
            {
                // 判斷是否有經過信箱認證 有經過認證認證欄位會被清空
                if (String.IsNullOrWhiteSpace(LoginMember.AuthCode))
                {
                    if (PasswordCheck(LoginMember, Password))
                    {
                        return "";
                    }
                    else
                    {
                        return "密碼輸入錯誤";
                    }
                }
                else
                {
                    return "此帳號尚未經過Email驗證,請去收信";
                }
            }
            else
            {
                return "無此會員帳號,請去註冊";
            }
        }
        #endregion

        #region 密碼確認
        // 進行密碼確認方法
        public bool PasswordCheck(Members CheckMember, string Password)
        {
            bool result = CheckMember.Password.Equals(HashPassword(Password));
            return result;
        }
        #endregion

        #region 變更密碼
        // 變更會員密碼方法 並回傳最後訊息
        public string ChangePassword(string Account, string Password, string newPassword)
        {
            Members LoginMember = new Members();
            if (PasswordCheck(LoginMember, Password))
            {
                LoginMember.Password = HashPassword(newPassword);
                string sql = $@"UPDATE Members SET Password = '{LoginMember.Password}' WHERE Account = '{Account}'";
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
                return "密碼修改成功";
            }
            else
            {
                return "舊密碼輸入錯誤";
            }
        }
        #endregion

        #region 取得角色
        // 取得會員的權限角色資料
        public string GetRole(string Account)
        {
            string Role = "User";

            Members LoginMember = GetDataByAccount(Account);
            // 判斷資料庫欄位 用已確認是否為Admin
            if (LoginMember.IsAdmin)
            {
                Role += ",Admin";
            }
            return Role;
        }
        #endregion

        #region 檢查圖片類型
        public bool CheckImage(string ContentType)
        {
            // 使用HTML的ContentType檢查
            switch (ContentType)
            {
                case "image/jpg":
                case "image/jpeg":
                case "image/png":
                    return true;

            }
            return false;
        }

        #endregion
    }
}