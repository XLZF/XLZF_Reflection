using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLZF.DB.SqlServer
{
    /// <summary>
    /// 单例示范
    /// </summary>
    public sealed class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("单例构造函数");
        }

        private static Singleton singleton = new Singleton();

        public static Singleton Createsingleton()
        {
            return singleton;
        }
    }
}
