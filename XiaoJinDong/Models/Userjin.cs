using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiaoJinDong.Models
{
    public class Userjin
    {
        //insert into Userjin(UserName, Password, Phone, CreationTime, ChangeTime) values('jin', '123456','171', GETDATE(),'2021.07.03 14:54')

        // <summary>
        // 用户名
        // </summary>
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ChangeTime { get; set; }
        public int ID { get; set; }

    }
}