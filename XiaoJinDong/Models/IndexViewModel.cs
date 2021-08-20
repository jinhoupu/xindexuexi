using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiaoJinDong.Models
{
    public class IndexViewModel
    {
        public spfb Product { get; set; }
        public List<spfb> ProductRecommend { get; set; }
    }
}