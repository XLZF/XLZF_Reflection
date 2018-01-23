using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLZF.DB.Interface;

namespace XLZF.DB.MySql
{
    public class DBhelper : IDBhelper
    {
        public DBhelper()
        {
            Console.WriteLine("这里是{0}无参构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }
    }
}
