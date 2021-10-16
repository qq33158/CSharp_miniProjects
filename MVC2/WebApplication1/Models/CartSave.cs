using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CartSave
    {
        public string Account { get; set; }
        public string Cart_Id { get; set; }
        //Member資料表 (外鍵)
        public Members Member { get; set; } = new Members();
    }
}