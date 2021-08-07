using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]

        public ActionResult SignIn(String userName, String passWord)
        {//登录

            string sql = string.Empty;
            sql = "SELECT * FROM [Userjin] where UserName = '" + userName + "' ";
            //sql = $"SELECT * FROM [User] where NameUser = '{userName}'";
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sql = "SELECT * FROM [Userjin] where userName='" + userName + "' and passWord = '" + passWord + "' ";
                    DataTable dtPassWord = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                    if (dtPassWord != null && dtPassWord.Rows.Count > 0)
                    {
                        return RedirectToRoute(  //跳转到指定Action
                           new
                           {
                               controller = "Shangpin",
                               action = "Shangpin"
                           });
                    }
                    else
                    {
                    }//密码错误
                }
                else
                {
                    //没有这个用户；
                }
            }
            return View();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}