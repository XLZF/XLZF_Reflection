using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLZF.DB.SqlServer
{
    /// <summary>
    /// 反射测试类
    /// </summary>
    public class ReflectionTest
    {
        public ReflectionTest()
        {
            Console.WriteLine("这里是{0}的无参构造函数", this.GetType().FullName);
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine("这里是{0}的有参构造函数", this.GetType().FullName);
        }

        public void Show1()
        {
            Console.WriteLine("这里是{0}的show1", this.GetType());
        }

        public void Show2(int id)
        {
            Console.WriteLine("这里是{0}的show2", this.GetType());
        }

        public void Show3()
        {
            Console.WriteLine("这里是{0}的show3", this.GetType());
        }

        public void Show3(int id)
        {
            Console.WriteLine("这里是{0}的show3_1", this.GetType());
        }

        public void Show3(string name)
        {
            Console.WriteLine("这里是{0}的show3_2", this.GetType());
        }

        public void Show3(int id, string name)
        {
            Console.WriteLine("这里是{0}的show3_3", this.GetType());
        }

        public void Show3(string name, int id)
        {
            Console.WriteLine("这里是{0}的show3_4", this.GetType());
        }

        private void Show4(string name)
        {
            Console.WriteLine("这里是{0}的show4", this.GetType());
        }
    }
}
