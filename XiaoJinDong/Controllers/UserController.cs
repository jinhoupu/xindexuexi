using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class UserController : Controller
    {
       // GET: User
        public ActionResult Index()
        {
            string sql = string.Empty;
            sql = $"SELECT * FROM Userjin";
            List<Userjin> itemList = new List<Userjin>();
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                itemList = DataTableExtension.ToList<Userjin>(dt);
            }
            return View(itemList);


        }

        public ActionResult AddAndUpdate()//http://localhost:51420/User/AddAndUpdate 小京东地址
        {
            return View();
        }


        public string jin()
        {
            return "jin";
        }
    }
   


}