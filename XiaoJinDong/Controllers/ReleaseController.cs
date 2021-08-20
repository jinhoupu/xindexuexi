using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoJinDong.Models;

namespace XiaoJinDong.Controllers
{
    public class ReleaseController : Controller
    {
        [HttpPost]
        public String aRelease(String TradeName, String CommodityPrice, String CommodityAbbreviation, String stock, 
            String CommodityLocation, String ItemNo, String CostPrice, String KeyWord,
            String Company, String weight, String BarCode, String MarketPrice, String VIPPrice, String ScheduledShelfTime)
        {//登录

            string sql = string.Empty;
            sql = "SELECT * FROM [spfb] where TradeName = '" + TradeName + "' ";//查找数据库中是否有该用户名;
            //sql = $"SELECT * FROM [User] where NameUser = '{userName}'";
            using (SqlHelper sqlHelper = new SqlHelper())
            {
                DataTable dt = sqlHelper.ExecuteQuery(sql, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)//如果数据库中列不为空，行大于零;说明数据库中有该用户名，
                {
                    return "该商品已存在";
                }
                else
                {
                    string insertSql = @"INSERT INTO spfb(TradeName,CommodityPrice,CreationTime,ChangeTime,
CommodityAbbreviation,stock,CommodityLocation,ItemNo,CostPrice,KeyWord,Company,weight,BarCode,MarketPrice,VIPPrice,ScheduledShelfTime)
VALUES('" + TradeName + "','" + CommodityPrice + "', getdate(), getdate(),'" + CommodityAbbreviation + "','" + stock + "'," +
"'" + CommodityLocation + "','" + ItemNo + "','" + CostPrice + "','" + KeyWord + "','" + Company + "','" + weight + "'," +
"'" + BarCode + "','" + MarketPrice + "','" + VIPPrice + "','" + ScheduledShelfTime + "')";
                    int count = sqlHelper.ExecuteNonQuery(insertSql, CommandType.Text);//执行INSERT语句;
                    return "修改成功";
                }
            }

        }
        // GET: Release
        public ActionResult Release()
            {
                return View();
            }
    }
    
}