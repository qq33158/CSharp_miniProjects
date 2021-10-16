using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Album
    {
        public int Alb_Id { get; set; }
        public string FileName { get; set; }
        public String Url { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }
        public DateTime CreateTime { get; set; }
        //Member資料表 (外鍵)
        public Members Member { get; set; } = new Members();
    }
}