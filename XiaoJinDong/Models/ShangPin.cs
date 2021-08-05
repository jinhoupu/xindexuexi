using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiaoJinDong.Models
{
    public class ShangPin
    {
        public int ID { get; set; }
        public string TradeName { get; set; }
        public string Business { get; set; }
        public decimal CommodityPrice { get; set; }
        public string MainMapAddress { get; set; }
        public DateTime CreationTime { get; set; }
        public string ProductDetails { get; set; }
        public DateTime RevisionTime { get; set; }


    }
}