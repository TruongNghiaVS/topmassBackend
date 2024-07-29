using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        private IEnumerable<PropertyInfo> GetProperties(bool excludeKey = false)
        {
            var properties = typeof(UserModel).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            return properties;
        }



        static void Main(string[] args)
        {
            IDbConnection GetConnection()
            {
                var con = new SqlConnection("Server=192.168.1.3,1433; Initial Catalog=jobvieclam;User ID=crm;Password=Vietstar@2018; Persist Security Info=False;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;Integrated Security=false;");
                con.Open();
                return con;
            }
            var tableName = "userModel";
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE {tableName} SET ");

            var modelUser = new UserModel()
            {
                Id = 1,
                UserName = "NghiaI06",
                Password = "NghiaI06"
            };
            var properties = typeof(UserModel).GetProperties();
            var p = new DynamicParameters();
            foreach (var item in properties)
            {
                var tempCol = item.Name;
                var tempVal = item.GetValue(modelUser);
                p.Add(tempCol, tempVal);
                if (tempCol.ToLower() == "id")
                {
                    continue;
                }
                query.Append($"{tempCol} = @{tempCol},");
            }

            query.Remove(query.Length - 1, 1);
            query.Append($" WHERE id = @Id ");
            var rowsEffected = 0;
            using (var con = GetConnection())
            {
                try
                {
                    rowsEffected = con.Execute(query.ToString(), p);
                    Console.WriteLine(rowsEffected);
                }
                catch (Exception e)
                {

                    throw;
                }


            }
        }



    }
}

