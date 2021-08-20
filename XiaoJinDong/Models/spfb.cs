using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiaoJinDong.Models
{
    public class spfb
    {
        public int ID { get; set; }
        public string TradeName { get; set; }
        public string CommodityAbbreviation { get; set; }
        public decimal CommodityPrice { get; set; }
        public int stock { get; set; }
        public DateTime CreationTime { get; set; }
        public string CommodityLocation { get; set; }
        public DateTime ChangeTime { get; set; }
        public string ItemNo { get; set; }
        public string KeyWord { get; set; }
        public string Company { get; set; }
        public string weight { get; set; }
        public int BarCode { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal VIPPrice { get; set; }
        public decimal CostPrice { get; set; }
        public DateTime ScheduledShelfTime { get; set; }

    }
}