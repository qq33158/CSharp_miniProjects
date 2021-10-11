using MVC1.Models;
using MVC1.Service;
using MVC1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class GuestbooksController : Controller
    {
        // 宣告Guestbooks資料表的Service物件
        private readonly GuestbooksDBService GuestbookService = new GuestbooksDBService();
        // GET: Guestbooks
        public ActionResult Index(string Search, int Page = 1)
        {
            //宣告一個新頁面模型
            GuestbooksViewModel Data = new GuestbooksViewModel();
            //將傳入值Search(搜尋)放入頁面模型中
            Data.Search = Search;
            //新增頁面模型中的分頁
            Data.Paging = new ForPaging(Page);
            //從Service中取得頁面所需陣列資料
            Data.DataList = GuestbookService.GetDataList(Data.Paging, Data.Search);
            //將頁面資料傳入View中
            return View(Data);
        }
        #region 新增留言
        // 新增留言一開始載入頁面
        public ActionResult Create()
        {
            return PartialView();
        }
        // 新增留言傳入資料時的Action
        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,Content")]Guestbooks Data)
        {
            GuestbookService.InsertGuestbooks(Data);
            return RedirectToAction("Index");
        }
        #endregion
        #region 修改留言
        //修改留言頁面要根據傳入編號來決定要修改的資料
        public ActionResult Edit(int Id)
        {
            //取得頁面所需資料，藉由Service取得
            Guestbooks Data = GuestbookService.GetDataById(Id);
            //將資料傳入View中
            return View(Data);
        }
        //修改留言傳入資料時的Action
        [HttpPost]
        public ActionResult Edit(int Id, [Bind(Include = "Name,Content")] Guestbooks UpdateData)
        {
            //修改資料的是否可修改判斷
            if (GuestbookService.CheckUpdate(Id))
            {
                //將編號設定至修改資料中
                UpdateData.Id = Id;
                //使用Service來修改資料
                GuestbookService.UpdateGuestbooks(UpdateData);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion
        #region 回覆留言
        //回覆留言頁面要根據傳入編號來決定要回覆的資料
        public ActionResult Reply(int Id)
        {
            //取得頁面所需資料，藉由Service取得
            Guestbooks Data = GuestbookService.GetDataById(Id);
            //將資料傳入View中
            return View(Data);
        }

        //修改留言傳入資料時的Action
        [HttpPost]
        public ActionResult Reply(int Id, [Bind(Include = "Reply,ReplyTime")] Guestbooks ReplyData)
        {
            //修改資料的是否可修改判斷
            if (GuestbookService.CheckUpdate(Id))
            {
                //將編號設定至回覆留言資料中
                ReplyData.Id = Id;
                //使用Service來回覆留言資料
                GuestbookService.ReplyGuestbooks(ReplyData);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion
        #region 刪除留言
        //刪除頁面要根據傳入編號來刪除資料
        public ActionResult Delete(int Id)
        {
            //使用Service來刪除資料
            GuestbookService.DeleteGuestbooks(Id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}