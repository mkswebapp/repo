﻿using DemoWebAPI.DB;
using DemoWebAPI.Repository;
using DemoWebAPI.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new DatabaseFactory();
            var iou = new UnitOfWork(rep);
            DemoWebAPI.Repository.ProductRepository ee = new DemoWebAPI.Repository.ProductRepository(rep);
            ProductService productsService  = new ProductService(iou, ee);

            var products = productsService.GetAll();
            foreach (DemoWebAPI.DB.Product item in products)
            {
                Console.WriteLine(item.Name);
            }
        }
    }


}
