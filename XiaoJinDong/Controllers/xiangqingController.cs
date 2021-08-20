using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class xiangqingController : Controller
    {
        // GET: xiangqing
        public ActionResult Index(int id)
        {
            string sql = string.Empty;
            sql = "SELECT * FROM [spfb] where id = '" + id + "' ";//查找数据库中是否有该用户名;      //sql = $"SELECT * FROM [User] where NameUser = '{userName}'";
            spfb spfb = new spfb();
            List<spfb> itemList = new List<spfb>();
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)//如果数据库中列不为空，行大于零;说明数据库中有该用户名，
                {
                    itemList = DataTableExtension.ToList<spfb>(dt);
                }
                if (itemList != null && itemList.Count > 0)
                {
                    spfb = itemList.FirstOrDefault();
                }
            }
            sql = "select top(5) * from spfb order by CreationTime desc";//查找数据库中是否有该用户名;      //sql = $"SELECT * FROM [User] where NameUser = '{userName}'";
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)//如果数据库中列不为空，行大于零;说明数据库中有该用户名，
                {
                    itemList = DataTableExtension.ToList<spfb>(dt);
                }
            }
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Product = spfb,
                ProductRecommend = itemList,
            };
            return View(indexViewModel);//product
        }
    }
}