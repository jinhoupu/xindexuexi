using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class ShangPinController : Controller
    {
        // GET: Shangpin
        public ActionResult ShangPin()//http://localhost:51420/Shangpin/Shangpin
        {
            string sql = string.Empty;
            sql = $"SELECT * FROM ShangPin";
            List<ShangPin> itemList = new List<ShangPin>();
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                itemList = DataTableExtension.ToList<ShangPin>(dt);
            }
            return View(itemList);
        }

        public ActionResult test()
        {
            return View();
        }
    }
}