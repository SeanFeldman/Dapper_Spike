using System;
using System.Configuration;
using System.Data.OleDb;
using Dapper;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new SecurityHelper().GetHashedPassword("sean", "myhash"));
            //Console.WriteLine(new SecurityHelper().GetHashedPassword("ran", "yourhash"));
            
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new OleDbConnection(connectionString))
            {
                var users = connection.Query<User>("select * from Users");
                foreach (var user in users)
                {
                    Console.WriteLine("Login '{0}' with hashed password '{1}' using salt '{2}'", user.Login, user.Password, user.Salt);
                }
            }


            Console.ReadLine();
        }
    }
}
