using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using XLZF.DB.Interface;
using XLZF.Model;
using XLZF.DB.SqlServer;

namespace XLZF_KnowLedge
{
    /// <summary>
    /// 1.依赖接口，进行可配置扩展
    /// 2.不依赖接口，反射调用方法，包括私有方法，反射破坏单例
    /// 3.通过反射查找model
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 20180122 依赖接口，进行可配置扩展

            //string nameSpace = ConfigurationManager.AppSettings["XLZF.DB.Interface.IDBhelper"];

            //string[] namespaceArray = nameSpace.Split(',');

            //Assembly assembly1 = Assembly.Load(namespaceArray[1]);//反射入口， 动态加载DLL

            //Type type1 = assembly1.GetType(namespaceArray[0]);//基于类的完整名称 找出类型

            //object oDBhelper = Activator.CreateInstance(type1);//根据类型，创建对象

            //IDBhelper dbHelperRefletion = (IDBhelper)oDBhelper;//强转成接口类型

            //dbHelperRefletion.Query();//调用方法

            #endregion

            #region 20180123 通过反射  需要DLL名称，类的名称，方法的名称来找到指定的方法调用成功

            //Assembly assembly = Assembly.Load("XLZF.DB.SqlServer");//反射入口， 动态加载DLL

            //Type type = assembly.GetType("XLZF.DB.SqlServer.ReflectionTest");//基于类的完整名称 找出类型

            //object obj = Activator.CreateInstance(type);//根据类型创建对象

            //foreach (MemberInfo method in type.GetMethods())
            //{
            //    Console.WriteLine("名称：{0}", method.Name);
            //}

            //MethodInfo show1 = type.GetMethod("Show1");

            //show1.Invoke(obj, null);//无参

            //MethodInfo show2 = type.GetMethod("Show2");

            //show2.Invoke(obj, new object[] { 11 });//有参，需要的是object数组


            //MethodInfo show3 = type.GetMethod("Show3", new Type[] { });//无参，因为方法有重载，需要的是Type数组,为空

            //show3.Invoke(obj, null);//无参

            //MethodInfo show31 = type.GetMethod("Show3", new Type[] { typeof(int) });//有参，因为方法有重载，需要的是Type数组,typeof(int)

            //show31.Invoke(obj, new object[] { 11 });//有参，需要的是object数组

            //MethodInfo show32 = type.GetMethod("Show3", new Type[] { typeof(string) });//无参，因为方法有重载，需要的是Type数组,typeof(string)

            //show32.Invoke(obj, new object[] { "11" });//有参，需要的是object数组

            //MethodInfo show33 = type.GetMethod("Show3", new Type[] { typeof(int), typeof(string) });//无参，因为方法有重载，需要的是Type数组,typeof(int), typeof(string)

            //show33.Invoke(obj, new object[] { 1, "11" });//有参，需要的是object数组

            //MethodInfo show34 = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });//无参，因为方法有重载，需要的是Type数组,typeof(string), typeof(int)

            //show34.Invoke(obj, new object[] { "11", 1 });//有参，需要的是object数组


            ////当想调用这个类中的私有方法的时候，这么写。
            //MethodInfo show4 = type.GetMethod("Show4", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //show4.Invoke(obj, new object[] { "11" });

            ////突破单例的私有构造函数
            //Type typeSingle = assembly.GetType("XLZF.DB.SqlServer.Singleton");

            //object objSingle = Activator.CreateInstance(typeSingle, true);//true 的意思是 是 私有方法

            #endregion

            #region 20180123 反射进阶 通过反射找到数据表中的字段，reader出对应的值，返回一个model

            //正常写法
            People people = new People();

            people.Id = 1;

            people.Name = "张三";

            Console.WriteLine("people.Id={0} people.Name={1}", people.Id, people.Name);

            //不走寻常路
            Type type = typeof(People);//找到类型

            object obj = Activator.CreateInstance(type);//创建对象

            foreach (var prop in type.GetProperties())
            {
                if (prop.Name.Equals("Id"))
                {
                    prop.SetValue(obj, 12);
                }

                if (prop.Name.Equals("Name"))
                {
                    prop.SetValue(obj, "李四");
                }

                Console.WriteLine("属性名称是{0} 值是{1}", prop.Name, prop.GetValue(obj));
            }

            //更不走寻常路

            DBhelper dBhelper = new DBhelper();

            User user = dBhelper.QueryDomain<User>();

            #endregion

            Console.ReadKey();
        }
    }
}
