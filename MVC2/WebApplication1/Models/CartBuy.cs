using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CartBuy
    {
        public string Cart_Id { get; set; }
        public string Item_id { get; set; }
        // Item資料表 (外鍵)
        public Item Item { get; set; } = new Item();
    }
}