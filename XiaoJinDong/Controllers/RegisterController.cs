using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class RegisterController : Controller
    {//注册


        public String aRegister(String userName, String passWord)
        {//登录

            string sql = string.Empty;
            sql = "SELECT * FROM [Userjin] where UserName = '" + userName + "' ";//查找数据库中是否有该用户名;
            //sql = $"SELECT * FROM [User] where NameUser = '{userName}'";
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)//如果数据库中列不为空，行大于零;说明数据库中有该用户名，
                {
                    return "该用户已存在";
                }
                else
                {
                    String insertSql = @"INSERT INTO Userjin(UserName ,Password,Phone,CreationTime,ChangeTime)
VALUES('" + userName + "', '" + passWord + "', '18270407226', getdate(), getdate()); ";
                    int count = sqlHelper.ExecuteNonQuery(insertSql,CommandType.Text);//执行INSERT语句;
                    return "注册成功";
                }
            }

        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
    }
}