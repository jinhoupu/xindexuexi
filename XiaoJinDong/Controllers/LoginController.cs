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

        public String SignIn(String userName, String passWord)
        {//登录

            string sql = string.Empty;
            sql = "SELECT * FROM [Userjin] where UserName = '" + userName + "' ";//查找数据库中是否有该用户名;
            //sql = $"SELECT * FROM [User] where NameUser = '{userName}'";
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)//如果数据库中列不为空，行大于零;说明数据库中有该用户名，
                {
                    sql = "SELECT * FROM [Userjin] where userName='" + userName + "' and passWord = '" + passWord + "' ";//用户名加密码与数据库中的数据相匹配
                    DataTable dtPassWord = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                    if (dtPassWord != null && dtPassWord.Rows.Count > 0)
                    {
                        return "登录成功"; 
                    }
                    else
                    {
                        return "密码错误";
                    }
                }
                else
                {
                    return "没有这个用户";
                    //没有这个用户；
                }
            }
            
        }

        // GET: Login
        public ViewResult Index()
        {
            return View();
        }
    }
}