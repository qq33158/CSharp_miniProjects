using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC1.Service
{
    public class GuestbooksDBService
    {   
        // 建立與資料庫的連線字串
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["ASP.NET MVC"].ConnectionString;
        // 建立與資料庫連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);

        #region 查詢陣列資料
        //根據搜尋來取得資料陣列的方法
        public List<Guestbooks> GetDataList(ForPaging Paging, string Search)
        {
            //宣告要接受全部搜尋資料的物件
            List<Guestbooks> DataList = new List<Guestbooks>();
            if (!string.IsNullOrWhiteSpace(Search))
            {
                //有搜尋條件時
                SetMaxPaging(Paging, Search);
                DataList = GetAllDataList(Paging, Search);
            }
            else
            {
                //無搜尋條件時
                SetMaxPaging(Paging);
                DataList = GetAllDataList(Paging);
            }
            return DataList;
        }
        #endregion

        #region 設定最大頁數方法
        //無搜尋值的設定最大頁數方法
        public void SetMaxPaging(ForPaging Paging)
        {
            //計算列數
            int Row = 0;
            string sql = $@" SELECT * FROM Guestbooks;";
            //確保程式不會因執行錯誤而整個中斷
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Row++;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            //計算所需的總頁數
            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Row) / Paging.ItemNum));
            //重新設定正確的頁數，避免有不正確值傳入
            Paging.SetRightPage();
        }

        //有搜尋值的設定最大頁數方法
        public void SetMaxPaging(ForPaging Paging, string Search)
        {
            //計算列數
            int Row = 0;
            string sql = $@" SELECT * FROM Guestbooks WHERE Name LIKE '%{Search}%' OR Content LIKE '%{Search}%' OR Reply LIKE '%{Search}%' ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Row++;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            //計算所需的總頁數
            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Row) / Paging.ItemNum));
            //重新設定正確的頁數，避免有不正確值傳入
            Paging.SetRightPage();
        }
        #endregion


        // 取得陣列資料方法
        #region 搜尋資料方法
        //無搜尋值的搜尋資料方法
        public List<Guestbooks> GetAllDataList(ForPaging paging)
        {
            //宣告要回傳的搜尋資料為資料庫中的Guestbooks資料表
            List<Guestbooks> DataList = new List<Guestbooks>();
            string sql = $@" SELECT * FROM (SELECT row_number() over(order by Id) AS sort,* FROM Guestbooks ) m WHERE m.sort Between {(paging.NowPage - 1) * paging.ItemNum + 1} AND {paging.NowPage * paging.ItemNum} ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guestbooks Data = new Guestbooks();
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.Name = dr["Name"].ToString();
                    Data.Content = dr["Content"].ToString();
                    Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    //確定此則留言是否回覆，且不允許空白
                    //因C#是強型別語言，所以轉換時Datetime型態不允許存取null
                    if (!dr["ReplyTime"].Equals(DBNull.Value))
                    {
                        Data.Reply = dr["Reply"].ToString();
                        Data.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);
                    }
                    DataList.Add(Data);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return DataList;
        }

        //有搜尋值的搜尋資料方法
        public List<Guestbooks> GetAllDataList(ForPaging paging, string Search)
        {
            //宣告要回傳的搜尋資料為資料庫中的Guestbooks資料表
            List<Guestbooks> DataList = new List<Guestbooks>();
            string sql = $@" SELECT * FROM (SELECT row_number() over(order by Id) as sort,* FROM Guestbooks WHERE Name LIKE '%{Search}%' OR Content LIKE '%{Search}%' OR Reply LIKE '%{Search}%' ) m WHERE m.sort Between {(paging.NowPage - 1) * paging.ItemNum + 1} AND {paging.NowPage * paging.ItemNum} ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guestbooks Data = new Guestbooks();
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.Name = dr["Name"].ToString();
                    Data.Content = dr["Content"].ToString();
                    Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    //確定此則留言是否回覆，且不允許空白
                    //因C#是強型別語言，所以轉換時Datetime型態不允許存取null
                    if (!dr["ReplyTime"].Equals(DBNull.Value))
                    {
                        Data.Reply = dr["Reply"].ToString();
                        Data.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);
                    }
                    DataList.Add(Data);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return DataList;
        }
        #endregion
        #region 新增資料
        // 新增資料方法
        public void InsertGuestbooks(Guestbooks newData)
        {
            string sql = $@"INSERT INTO Guestbooks(Name,Content,CreateTime) VALUES ('{newData.Name}','{newData.Content}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region 查詢一筆資料
        // 藉由編號取得單筆資料的方法
        public Guestbooks GetDataById(int Id)
        {
            Guestbooks Data = new Guestbooks();
            string sql = $@"SELECT * FROM Guestbooks WHERE Id ={Id};";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.Name = dr["Name"].ToString();
                Data.Content = dr["Content"].ToString();
                Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                if (!string.IsNullOrWhiteSpace(dr["Reply"].ToString()))
                {
                    Data.Reply = dr["Reply"].ToString();
                    Data.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);
                }
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
        #region 修改留言
        //修改留言方法
        public void UpdateGuestbooks(Guestbooks UpdateData)
        {
            string sql = $@" UPDATE Guestbooks SET Name = '{UpdateData.Name}', Content = '{UpdateData.Content}' WHERE Id = {UpdateData.Id} ";
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
        #region 回覆留言
        //回覆留言方法
        public void ReplyGuestbooks(Guestbooks ReplyData)
        {
            string sql = $@" UPDATE Guestbooks SET Reply = '{ReplyData.Reply}',ReplyTime = '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}' WHERE Id = {ReplyData.Id} ";
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
        #region 檢查相關
        //修改資料判斷的方法
        public bool CheckUpdate(int Id)
        {
            //根據Id取得要修改的資料
            Guestbooks Data = GetDataById(Id);
            //判斷並回傳(判斷是否有資料以及是否有回覆)
            return (Data != null && Data.ReplyTime == null);
        }
        #endregion
        #region 刪除資料
        //刪除資料方法
        public void DeleteGuestbooks(int Id)
        {
            string sql = $@" Delete from Guestbooks where Id = {Id} ";
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
    }
}