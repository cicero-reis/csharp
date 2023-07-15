using System;
using System.Globalization;
using System.Collections.Generic;
using App.Entities;
using App.Services;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');

                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);

                list.Add(new Product(vect[0], price));
            }

            Product p = CalculationService.Max(list);

            Console.WriteLine("Most expensive: ");

            Console.WriteLine(p);
        }
    }
}