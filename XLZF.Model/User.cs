using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLZF.Model
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        /// <summary>
        /// 用户状态 0 正常 1 冻结 2 删除
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 用户类型 1 普通用户 2 管理员 4 超级管理员
        /// </summary>
        public int UserType { get; set; }

        public DateTime LastLoginTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int Create_User_Id { get; set; }

        public int LastUpdate_User_Id { get; set; }

        public DateTime LastUpdate_Datetime { get; set; }
    }
}
