using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Article
    {
        public int A_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Account { get; set; }
        public DateTime CreateTime { get; set; }
        public int Watch { get; set; }
        //Member資料表 (外鍵)
        public Members Member { get; set; } = new Members();
    }
}