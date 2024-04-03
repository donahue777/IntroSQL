using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace IntroSQL
{
    class program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            DepartmentRepository repo = new DepartmentRepository(conn);
            var Departments = repo.GetAllDepartments();

            foreach(var dep in Departments)
            {
                Console.WriteLine($"{dep.DepartmentID} {dep.Name}");
            }
        }
    }
}