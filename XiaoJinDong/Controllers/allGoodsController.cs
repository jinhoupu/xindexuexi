using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class allGoodsController : Controller
    {
        public ActionResult allGoods(string name, string name2,string name3)//http://localhost:51420/allGoods/aAllGoods
        {

            string sql = string.Empty;
            sql = $"SELECT * FROM spfb where TradeName like '%{name}%'and ItemNo like '%{name2}%' and BarCode like '%{name3}%' ";
            List<spfb> itemList = new List<spfb>();
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                itemList = DataTableExtension.ToList<spfb>(dt);
            }
            return View(itemList);
        }

        }
}