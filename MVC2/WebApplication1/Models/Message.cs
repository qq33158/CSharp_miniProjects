using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Message
    {
        // 文章編號
        public int A_Id { get; set; }
        // 留言編號
        public int M_Id { get; set; }
        public string Account { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        //Member資料表 (外鍵)
        public Members Member { get; set; } = new Members();
    }
}