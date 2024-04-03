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
            IEnumerable<Department> Departments = repo.GetAllDepartments();

            //foreach(Department dep in Departments)
            //{
            //    Console.WriteLine($"{dep.DepartmentID} {dep.Name}");
            //}

            DapperProductRepository prodRepo = new DapperProductRepository(conn);

            prodRepo.CreateProduct("Jellybean", 78, 1);

            IEnumerable<Product> products = prodRepo.GetAllProducts();

            foreach(var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price} {prod.OnSale} {prod.StockLevel}");
            }
        }
    }
}