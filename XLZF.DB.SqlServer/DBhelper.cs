using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLZF.DB.Interface;
using System.Configuration;
using System.Data.SqlClient;

namespace XLZF.DB.SqlServer
{
    public class DBhelper : IDBhelper
    {
        private static string ConnectionStringTesting = ConfigurationManager.ConnectionStrings["Business_Sqlserver"].ConnectionString;

        public DBhelper()
        {
            Console.WriteLine("这里是{0}无参构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }

        /// <summary>
        /// 泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T QueryDomain<T>()
        {
            int id = 2;

            /*          
            
            SELECT [Id]
                  ,[Name]
                  ,[Account]
                  ,[Password]
                  ,[Email]
                  ,[Mobile]
                  ,[CompanyId]
                  ,[CompanyName]
                  ,[State]
                  ,[UserType]
                  ,[LastLoginTime]
                  ,[CreateTime]
                  ,[Create_User_Id]
                  ,[LastUpdate_User_Id]
                  ,[LastUpdate_Datetime]
              FROM [dbo].[User]

              where Id= 2

             */

            Type type = typeof(T);//找到分类

            T t = (T)Activator.CreateInstance(type);//创建对象,这有一个强制转换

            string columns = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));//linq 把所有的属性替换成加[] 的字符串，并且以逗号分隔

            string sql = string.Format("SELECT {0} from [{1}] where Id = {2}", columns, type.Name, id);

            using (SqlConnection conn = new SqlConnection(ConnectionStringTesting))
            {
                SqlCommand command = new SqlCommand(sql, conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//自动关闭

                if (reader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, reader[prop.Name]);

                        Console.WriteLine("属性是{0}", prop.Name);
                    }

                    return t;
                }
            }

            return default(T);
        }
    }
}
