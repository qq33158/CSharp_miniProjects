using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookWeb.Models;

namespace MvcBookWeb.Controllers
{
    public class HomeController : Controller
    {
        // 建立 BookDBEntities 物件 db
        BookDBEntities db = new BookDBEntities();
        // 連結網站/Home/Index 會執行Index()方法
        public ActionResult Index()
        {
            // 依單價遞減排序
            var bookList = db.書籍.OrderBy(m => m.單價).ToList();
            return View(bookList);
        }
        // 連結網站/Home/Index/Delete/書號參數 會執行Delete()方法 
        public ActionResult Delete(string id)
        {
            var book = db.書籍.Where(m => m.書號 == id).FirstOrDefault();
            string fileName = book.圖示;
            if (fileName != "")
            {
                System.IO.File.Delete(Server.MapPath("~/Images") + "/" + fileName);
            }
            db.書籍.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // 連結網站/Home/Index/Create 會執行Create()方法
        public ActionResult Create()
        {
            return View();
        }
        // 當在Create.cshtml按下Submit鈕會執行方法
        [HttpPost]
        public ActionResult Create(string 書號, string 書名, int 單價, HttpPostedFileBase 圖示)
        {
            string fileName = "";
            // 檔案上傳
            if (圖示 != null)
            {
                if (圖示.ContentLength > 0)
                {
                    fileName = System.IO.Path.GetFileName(圖示.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Images"), fileName);
                    圖示.SaveAs(path);
                }
            }
            // 新增書籍紀錄
            書籍 book = new 書籍();
            book.書號 = 書號;
            book.書名 = 書名;
            book.單價 = 單價;
            book.圖示 = fileName;
            db.書籍.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // 連結網站/Home/Edit 會執行Edit()方法
        public ActionResult Edit(string id)
        {
            var book = db.書籍.Where(m => m.書號 == id).FirstOrDefault();
            return View(book);
        }
        // 當在Edit.cshtml按下Submit鈕會執行方法
        [HttpPost]
        public ActionResult Edit(string 書號, string 書名, int 單價, HttpPostedFileBase 圖示, string 舊圖示)
        {
            string fileName = "";
            // 檔案上傳
            if (圖示 != null)
            {
                if (圖示.ContentLength > 0)
                {
                    fileName = System.IO.Path.GetFileName(圖示.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Images"), fileName);
                    圖示.SaveAs(path);
                }
            }
            else
            {
                fileName = 舊圖示;
            }
            // 修改指定書籍資料
            var book = db.書籍.Where(m => m.書號 == 書號).FirstOrDefault();
            book.書號 = 書號;
            book.書名 = 書名;
            book.單價 = 單價;
            book.圖示 = fileName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}